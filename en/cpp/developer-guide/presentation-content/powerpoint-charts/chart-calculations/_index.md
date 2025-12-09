---
title: Optimize Chart Calculations for Presentations in C++
linktitle: Chart Calculations
type: docs
weight: 50
url: /cpp/chart-calculations/
keywords:
- chart calculations
- chart elements
- element position
- actual position
- child element
- parent element
- chart values
- actual value
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Understand chart calculations, data updates, and precision control in Aspose.Slides for C++ for PPT and PPTX, with practical C++ code examples."
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for C++ provides a simple API for getting these properties. This will help you to calculate actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) and actual axes values (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Saving presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **Calculate the Actual Position of Parent Chart Elements**
Aspose.Slides for C++ provides a simple API for getting these properties. Methods of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart::ValidateChartLayout() previously to fill properties with actual values.

``` cpp
// Creating empty presentation
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Hide Chart Elements**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for C++ you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Set a Data Range for a Chart**
Aspose.Slides for C++ has provided the simplest API to set the data range for chart in an easiest way. To set the data range for chart:

- Open an instance of Presentation class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

The code examples that follow how to update a chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Yes. A chart can reference an external workbook: when you connect or refresh the external source, formulas and values are taken from that workbook, and the chart reflects the updates during open/edit operations. The API lets you [specify the external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) path and manage the linked data.

**Can I compute and display trendlines without implementing regression myself?**

Yes. [Trendlines](/slides/cpp/trend-line/) (linear, exponential, and others) are added and updated by Aspose.Slides; their parameters are recalculated from the series data automatically, so you don’t need to implement your own calculations.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Yes. Each chart can point to its own [external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), or you can create/replace an external workbook per chart independently of the others.
