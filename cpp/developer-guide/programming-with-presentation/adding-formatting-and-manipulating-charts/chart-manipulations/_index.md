---
title: Chart Manipulations
type: docs
weight: 20
url: /cpp/chart-manipulations/
---

## **Chart Manipulations**
Aspose.Slides for C++ now supports animating the chart elemets. **Series**, **Categories**, **Series Elements**, **Categories Elements** could be animated because new method **IEffect** **AddEffect** and two new enums **EffectChartMajorGroupingType** and **EffectChartMinorGroupingType** have been introduced.
### **Animating a Series**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the series.
1. Write the presentation file to disk.

In the example given below, we animated chart series.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}
### **Animating a Category**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the Category.
1. Write the presentation file to disk.

In the example given below, we animated chart category.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}
### **Animating Series Elements**
If you want to animate series elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate series elements.
1. Write the presentation file to disk.

In the example given below, we have animated series' elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}
### **Animating Categories Elements**
If you want to animate categories elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate categories elements.
1. Write the presentation file to disk.

In the example given below, we have animated categories elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}
### **Switch Data over axis**
A new property has been added which Swap the data over the axis. Data being charted on the X axis will move to the Y axis and vice versa. Below sample example is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SwitchChartRowColumns-SwitchChartRowColumns.cpp" >}}
### **Changing Category axis**
**CategoryAxisType** can be changed to Date or Text.However, **CategoryAxisType.Auto** is not supported at the moment. New property **CategoryAxisType** has been added to **IAxis** and Axis classes which specifies type of category axis.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeChartCategoryAxis-ChangeChartCategoryAxis.cpp" >}}
### **Using Callouts**
New property **ShowLabelAsDataCallout** has been added to **DataLabelFormat** class and **IDataLabelFormat** interface, which determines either specified chart's data label will be displayed as data callout or as data label. In the example given below, we have set the Callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}
### **Specifying center gap in Doughnut Chart**
In order to specify the size of the hole in a doughnut chart. Please follow the steps below:

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}
### **Setting the RotationX, RotationY and DepthPercents properties of 3D Chart**
Aspose.Slides for C++ provides a simple API for setting these properties. This following article will help you how set different properties like X,Y Rotation , **DepthPercents** etc. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}
### **Calculates actual values of chart elements**
Aspose.Slides for C++ provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-ValidateChartLayoutAdded-ValidateChartLayoutAdded.cs" >}}
### **Get Actual Max value of vertical axis on a chart**
Aspose.Slides for C++ provides a simple API for getting value of vertical axis. 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Get actual maximum value on the axis.
1. Get actual minimum value on the axis.
1. Get actual major unit of the axis.
1. Get actual minor unit of the axis.
1. Get actual major unit scale of the axis.
1. Get actual minor unit scale of the axis.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-GetValuesAndUnitScaleFromAxis-GetValuesAndUnitScaleFromAxis.cs" >}}
### **Get Width, Height for ChartPlotArea**
Aspose.Slides for C++ provides a simple API for . 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart.ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-GetWidthHeightFromChartPlotArea-GetWidthHeightFromChartPlotArea.cs" >}}
### **Calculates actual position of parent chart elements**
Aspose.Slides for C++ provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-IActualLayoutAdded-IActualLayoutadded.cs" >}}
### **Setting the GapWidth property of Chart Series**
Aspose.Slides for C++ provides a simple API for setting **GapWidth** property. The sample code applies setting the **GapWidth** property.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set GapWidth property.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetGapWidth-SetGapWidth.cpp" >}}
### **Setting the WorkBook Cell As Chart DataLabel**
Aspose.Slides for C++ provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-UsingWorkBookChartcellAsDatalabel-UsingWorkBookChartcellAsDatalabel.cs" >}}
### **Get chart external data source workbook path**
Aspose.Slides for C++ provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-DataSourceTypePropertyAdded-DataSourceTypePropertyAdded.cs" >}}
### **Second plot options for Pie of Pie and Bar of Pie chart**
Aspose.Slides for C++ now supports, second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will see with example how to Specify these options using Aspose.Slides. In order to specify the properties. Please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}
### **Setting the RotationX, RotationY and DepthPercents properties of 3D Chart**
Aspose.Slides for C++ provides a simple API for setting these properties. This following article will help you how set different properties like X,Y Rotation , DepthPercents etc. The sample code applies setting the above said properties.

1. Create an instance of the Presentation class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}
### **Setting automatic pie chart slice colors**
Aspose.Slides for C++ provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the Presentation class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.

Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}
### **Setting Precision of Data in chart Data Labels**
Aspose.Slides for C++ provides a simple API for setting precision of data in chart data label. Below sample example is given. 



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingPrecisionOfDataLabel-SettingPrecisionOfDataLabel.cpp" >}}
### **Support for setting date format for Category Axis Value**
Aspose.Slides for C++ provides a simple API for setting date format for category axis value. Below sample example is given.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DateFormatForCategoryAxis-DateFormatForCategoryAxis.cpp" >}}
### **Support for setting rotation angle for chart axis title**
Aspose.Slides for C++ provides a simple API for setting rotation angle for chart axis title. Below sample example is given.  



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-VerticalAxisRotationAngle-VerticalAxisRotationAngle.cpp" >}}
### **Support of setting Position Axis in Category or Value Axis**
Aspose.Slides for C++ provides a simple API for setting Position axis in category or Value axis. Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingPositionAxis-SettingPositionAxis.cpp" >}}
### **Support for displaying Unit label on Chart value axis**
Aspose.Slides for C++ provides support for showing Display unit label on chart value axis. Below sample example is given. 



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ShowDisplayUnitLabelOnChartValueAxis-ShowDisplayUnitLabelOnChartValueAxis.cpp" >}}
### **Support for Bubble chart Size scaling**
Aspose.Slides for C++ provides support for Bubble chart size scaling. In Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** and **IChartSeriesGroup.BubbleSizeScale** properties have been added. Below sample example is given. 



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}
### **Get Chart Image**
Aspose.Slides for C++ provides support for extracting image of specific chart. Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetChartImage-GetChartImage.cpp" >}}
### **Changing Series Color**
Aspose.Slides for C++ provides support for changing series color. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

` `Below sample example is given. 



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangingSeriesColor-ChangingSeriesColor.cpp" >}}
### **Setting chart area rounded borders**
Aspose.Slides for C++ provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. Set fill type and fill color of chart
1. Set round corner property True.
1. Save modified presentation. 

` `Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}
### **Change color of categories in a series**
Aspose.Slides for C++ provides support for changing color of categories in a series color. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

` `Below sample example is given. 



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeColorOfCategoriesInSeries-ChangeColorOfCategoriesInSeries.cpp" >}}
### **Setting font properties for chart data table**
Aspose.Slides for C++ provides support for changing color of categories in a series color. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

` `Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}


### **Setting Callout For Doughnut chart**
Aspose.Slides for C++ provides support for setting series data label callout shape for a Doughnut chart. Below sample example is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}
### ` `**Hide Information From Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for C++ you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}
### **Set Font Properties for Chart**
Aspose.Slides for C++ provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart.

- Instantiate Presentation class object.
- Add chart on the slide.
- Set font height.
- Save modified presentation.

Below sample example is given.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}


