---
title: Customize Plot Areas of Presentation Charts in С++
linktitle: Plot Area
type: docs
url: /cpp/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Discover how to customize chart plot areas in PowerPoint presentations with Aspose.Slides for С++. Improve your slide visuals effortlessly."
---

## **Get Width and Height of a Chart Plot Area**
Aspose.Slides for C++ provides a simple API for . 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart::ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Save presentation with chart
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **Set the Layout Mode of a Chart Plot Area**
Aspose.Slides for C++ provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**In what units are ActualX, ActualY, ActualWidth, and ActualHeight returned?**

In points; 1 inch = 72 points. These are Aspose.Slides coordinate units.

**How does the Plot Area differ from the Chart Area in terms of content?**

The Plot Area is the data drawing region (series, gridlines, trendlines, etc.); the Chart Area includes the surrounding elements (title, legend, etc.). In 3D charts, the Plot Area also includes the walls/floor and the axes.

**How are the Plot Area’s X, Y, Width, and Height interpreted when layout is manual?**

They are fractions (0–1) of the chart’s overall size; in this mode, auto-positioning is disabled and the fractions you set are used.

**Why did the Plot Area position change after adding/moving the legend?**

The legend sits in the chart area outside the Plot Area but affects layout and available space, so the Plot Area may shift when auto-positioning is in effect. (This is standard behavior for PowerPoint charts.)
