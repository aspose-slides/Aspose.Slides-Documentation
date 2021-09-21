---
title: Chart Plot Area
type: docs
url: /cpp/chart-plot-area/
---

## **Get Width, Height of Chart Plot Area**
Aspose.Slides for C++ provides a simple API for . 

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart::ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::DynamicCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Save presentation with chart
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Set Layout Mode of Chart Plot Area**
Aspose.Slides for C++ provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

