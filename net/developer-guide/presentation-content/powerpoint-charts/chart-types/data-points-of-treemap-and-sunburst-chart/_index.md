---
title: Data Points of Treemap and Sunburst Chart
type: docs
url: /net/data-points-of-treemap-and-sunburst-chart/
keywords: "Sunburst graph"
description: "Sunburst Graph, Sunburst Diagram, Sunburst Chart, Radial Chart, Radial Graph or Multi Level Pie Chart with Aspose.Slides."
---

Among other types of PowerPoint charts, there are two "hierarchical" types - **Treemap** and **Sunburst** chart (also known as Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph or Multi Level Pie Chart). These charts display hierarchical data organized as a tree - from leaves to the top of the branch. Leaves are defined by the series data points, and each subsequent nested grouping level defined by the corresponding category. Aspose.Slides for .NET allows to format data points of Sunburst Chart and Treemap in C#.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:



{{< gist "aspose-com-gists" "3b16a6c14d909756ef521e46bb23a002" "Add-Sunburst-Chart-for-Data-Points-Example-with-Aspose-Slides.cs" >}}
{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


If there is a need to format data points of the chart, we should use the following:

[**IChartDataPointLevelsManager**](https://apireference.aspose.com/net/slides/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://apireference.aspose.com/net/slides/aspose.slides.charts/ichartdatapointlevel) classes 
and [**IChartDataPoint.DataPointLevels**](https://apireference.aspose.com/net/slides/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://apireference.aspose.com/net/slides/aspose.slides.charts/IChartDataPointLevelsManager) 
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://apireference.aspose.com/net/slides/aspose.slides.charts/IChartDataPointLevel) objects. 
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://apireference.aspose.com/net/slides/aspose.slides.charts/IChartCategoryLevelsManager) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://apireference.aspose.com/net/slides/aspose.slides.charts/IChartDataPointLevel) class has 
two properties: [**Format**](https://apireference.aspose.com/net/slides/aspose.slides.charts/ichartdatapointlevel/properties/format) and 
[**DataLabel** ](https://apireference.aspose.com/net/slides/aspose.slides.charts/ichartdatapointlevel/properties/label)which 
provide access to corresponding settings.
## **Show Data Point Value**
Show value of "Leaf 4" data point:



{{< gist "aspose-com-gists" "737f4707d1e0545a77766028e90f0c58" "Show-Data-Point-Value-with-Aspose-Slides.cs" >}}

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Set Data Point Label and Color**
Set "Branch 1" data label to show series name ("Series1") instead of category name. Then set text color to yellow:



{{< gist "aspose-com-gists" "9250993b9a0512bd2236060210247828" "Set-Data-Point-Label-and-Color-with-Aspose-Slides.cs" >}}

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Set Data Point Branch Color**
Change color of "Steam 4" branch:



{{< gist "aspose-com-gists" "aa2689da77eb5d49daee2ddf24c8b7e" "Set-Data-Point-Branch-Color-with-Aspose-Slides.cs" >}}

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)




