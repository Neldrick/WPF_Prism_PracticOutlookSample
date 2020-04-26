# WPF Prism

### 1.Region Manager

Region Manager is used to fill content to specific region as we design.
e.g.
```<ContentControl prism:RegionManager.RegionName="{x:Static core:RegionNames.RibbonRegion}"/>```
above code we have a content control with region name <span style="color: red;">RibbonRegion</span>

We can filled it by 
```_regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));```

There are only 4 type of control is able to be used without customization:

1. ContentControl
2. ItemsControl
3. ListBox
4. TabControl

### 2.Delegate Command

DelegateCommand can bind to a control and trigger the action in viewModel 
e.g.
```<Button Command={Binding HelloCommand} Content="testing"/>```
Then inside ViewModel we can have 
```DelegateCommand HelloCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnable)```
with above code we can write  <span style="color: red;">Execute</span> function and  <span style="color: red;">CanExecute</span> function.

If <span style="color: red;">CanExecute</span> haven't passed in constructor, it will treated as a simple command and always able to execute.

There are only types of control predefined with prism command:

1. ButtonBase : Button, RadioButton
2. MenuItem
3. Hyperlink

Other type would require the i.eventrigger:
```
xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
  <i:Interaction.Triggers>
      <i:EventTrigger EventName="MouseDoubleClick">
         <i:InvokeCommandAction Command="{Binding CommandToBindTo}" 
                                CommandParameter="{Binding CommandParameterToBindTo}" />
         // prism one which allow pass parameter from parent would be :
         <!-- This action will invoke the selected command in the view model and pass the parameters of the event to it. -->
         <prism:InvokeCommandAction Command="{Binding CommandToBind} TriggerParameterPath="">
      </i:EventTrigger>
   </i:Interaction.Triggers>
```
TriggerParameterPath that is used to specify the member (possibly nested) of the parameter passed as the command parameter.

### 3.CompositCommands

This one is used to collect command together and execute them. We can treat it as a Command collection.
