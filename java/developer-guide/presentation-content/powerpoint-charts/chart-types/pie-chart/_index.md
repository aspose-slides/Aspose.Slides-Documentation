---
title: Pie Chart
type: docs
url: /java/pie-chart/
---

## **Set Second Plot Options in Pie Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will see with example how to specify these options using Aspose.Slides.

{{% /alert %}} 

In order to specify the properties, please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SecondPlotOptionsForPieOfPieAndBarOfPieChart-SecondPlotOptionsForPieOfPieAndBarOfPieChart.java" >}}


## **Set Slice Color in Pie Chart**
`      `Aspose.Slides for Java provides a simple API for setting automatic pie chart slice colors. The sample code applies setting the above said properties.

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
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.java" >}}

## **Set Sector Color in Pie Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add custom charts to their slides from scratch. This article explains how to create a pie chart and set different colors for its sectors.

{{% /alert %}} 

Aspose.Slides for Java provides an API for creating and filling pie charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type ([ChartType.Pie](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Access the chart data [IChartDataWorkbook](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IChartDataWorkbook).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for charts and add custom colors for the pie chart's sectors.
1. Set labels for series.
1. Set leader lines for series labels.
1. Set the rotation angle for pie chart slides.
1. Write the modified presentation to a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingPieChartSectorColors-SettingPieChartSectorColors.java" >}}

The above code snippet create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/qSbb9f1.png)|
| :- |
|**Figure: Pie chart added to the slide**|