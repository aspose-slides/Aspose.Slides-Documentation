---
title: Chart Calculations
type: docs
weight: 50
url: /cpp/chart-calculations/
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


## **Calculate Actual Position of Parent Chart Elements**
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

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for C++ you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Set Data Range for Chart**
Aspose.Slides for C++ has provided the simplest API to set the data range for chart in an easiest way. To set the data range for chart:

- Open an instance of Presentation class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

The code examples that follow how to update a chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

