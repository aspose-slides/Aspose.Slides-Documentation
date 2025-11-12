---
title: Customize Data Points in Treemap and Sunburst Charts in .NET
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap chart
- sunburst chart
- data point
- label color
- branch color
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to manage data points in treemap and sunburst charts with Aspose.Slides for .NET, compatible with PowerPoint and OpenDocument formats."
---

Among other types of PowerPoint charts, there are two "hierarchical" types - **Treemap** and **Sunburst** chart (also known as Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph or Multi Level Pie Chart). These charts display hierarchical data organized as a tree - from leaves to the top of the branch. Leaves are defined by the series data points, and each subsequent nested grouping level defined by the corresponding category. Aspose.Slides for .NET allows to format data points of Sunburst Chart and Treemap in C#.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:



```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


If there is a need to format data points of the chart, we should use the following:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) classes 
and [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) objects. 
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) class has 
two properties: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) and 
[**DataLabel** ](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label)which 
provide access to corresponding settings.
## **Show Data Point Value**
Show value of "Leaf 4" data point:



```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Set Data Point Label and Color**
Set "Branch 1" data label to show series name ("Series1") instead of category name. Then set text color to yellow:



```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Set Data Point Branch Color**

Change color of "Stem 4" branch:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**

No. PowerPoint sorts segments automatically (typically by descending values, clockwise). Aspose.Slides mirrors this behavior: you can’t change the order directly; you achieve it by preprocessing the data.

**How does the presentation theme affect the colors of segments and labels?**

Chart colors inherit the presentation’s [theme/palette](/slides/net/presentation-theme/) unless you explicitly set fills/fonts. For consistent results, lock in solid fills and text formatting at the required levels.

**Will export to PDF/PNG preserve custom branch colors and label settings?**

Yes. When exporting the presentation, chart settings (fills, labels) are preserved in the output formats because Aspose.Slides renders with the chart’s formatting applied.

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**

Yes. After the chart layout is validated, `ActualX`/`ActualY` are available for elements (for example, a [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), which helps with precise positioning of overlays.
