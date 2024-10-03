---
title: Data Points of Treemap and Sunburst Chart
type: docs
url: /python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "Sunburst chart, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add sunburst chart in PowerPoint presentation in Python"
---

Among other types of PowerPoint charts, there are two "hierarchical" types - **Treemap** and **Sunburst** chart (also known as Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph or Multi Level Pie Chart). These charts display hierarchical data organized as a tree - from leaves to the top of the branch. Leaves are defined by the series data points, and each subsequent nested grouping level defined by the corresponding category. Aspose.Slides for Python via .NET allows to format data points of Sunburst Chart and Treemap in Python.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Let’s start with adding a new Sunburst chart to the presentation:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="See also" %}} 
- [**Creating Sunburst Chart**](/slides/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


If there is a need to format data points of the chart, we should use the following:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/), 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) classes 
and [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) property 
provide access to format data points of Treemap and Sunburst charts. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
is used for accessing multi-level categories - it represents the container of 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) objects. 
Basically it is a wrapper for 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) with 
the properties added specific for data points. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) class has 
two properties: [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) and 
[**DataLabel** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)which 
provide access to corresponding settings.
## **Show Data Point Value**
Show value of "Leaf 4" data point:



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Set Data Point Label and Color**
Set "Branch 1" data label to show series name ("Series1") instead of category name. Then set text color to yellow:



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Set Data Point Branch Color**

Change color of "Stem 4" branch:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)



