using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOutlook.Core.Region
{
    public class DependentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionBehavior";
        private readonly IContainerExtension _container;

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
                    var dependentViews = new List<DependentViewInfo>();

                    // get the attributes
                    var atts = GetCustomAttributes<DependentViewAttribute>(view.GetType());

                    // foreach att we need to create the view find the region then inject the view into the region
                    foreach(var att in atts)
                    {
                        var info = new DependentViewInfo(att,_container);

                        dependentViews.Add(info);
                    }

                    dependentViews.ForEach(x => Region.RegionManager.Regions[x.Region].Add(x.View));
                }

            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {

            }
        }

        private static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}
