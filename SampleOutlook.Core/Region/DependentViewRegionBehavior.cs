using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SampleOutlook.Core.Region
{
    public class DependentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _container;

        Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

        public DependentViewRegionBehavior(IContainerExtension container)
        {
            _container = container;
        }
        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach( var view in e.NewItems)
                {
                    List<DependentViewInfo> dependentViews = new List<DependentViewInfo>();

                    // check if view is already has dependents
                    if (_dependentViewCache.ContainsKey(view))
                    {
                        // reuse
                        dependentViews = _dependentViewCache[view];
                    }
                    else
                    {
                        // get the attributes
                        var atts = GetCustomAttributes<DependentViewAttribute>(view.GetType());

                        // foreach att we need to create the view find the region then inject the view into the region
                        foreach (var att in atts)
                        {
                            var info = new DependentViewInfo(att, _container);

                            if(info.View is ISupportDataContext infoDC && view is ISupportDataContext viewDC)
                            {
                                infoDC.DataContext = viewDC.DataContext;
                            }                            
                            dependentViews.Add(info);
                        }                       
                        _dependentViewCache.Add(view, dependentViews);
                    }

                    dependentViews.ForEach(x =>
                    {
                        if (x.View is TabItem tabView)
                        {
                            tabView.IsSelected = true;
                        }
                        Region.RegionManager.Regions[x.Region].Add(x.View);
                    });
                }

            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oldView in e.OldItems)
                {
                    if (_dependentViewCache.ContainsKey(oldView))
                    {
                        var dependentViews = _dependentViewCache[oldView];
                        dependentViews.ForEach(x => Region.RegionManager.Regions[x.Region].Remove(x.View));

                        // if required to perm remove , remove from cache
                        if (!ShouldKeepAlive(oldView))
                        {
                            _dependentViewCache.Remove(oldView);
                        }
                    }
                }
            }
        }

        private bool ShouldKeepAlive(object oldView)
        {
            var regionLifetime = GetViewOrDataContextLifeTime(oldView);
            if(regionLifetime != null)
            {
                return regionLifetime.KeepAlive;
            }
            
            return true;
        }

        private IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
        {
            if(view is IRegionMemberLifetime regionMemberLifetime)
            {
                return regionMemberLifetime;
            }

            if(view is FrameworkElement frameworkElements)
            {
                return frameworkElements.DataContext as IRegionMemberLifetime;
            }

            return null;
        }

        private static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}
