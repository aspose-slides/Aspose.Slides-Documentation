---
title: Chart
type: docs
weight: 60
url: /cpp/examples/elements/chart/
keywords:
- code example
- chart
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Master charts with Aspose.Slides for C++: create, format, bind data, and export charts in PPT, PPTX, and ODP with C++ examples."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for C++**. The snippets below demonstrate basic chart operations.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```cpp
static void AddChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Add a simple area chart to the first slide.
    auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 50, 50, 400, 300);

    presentation->Dispose();
}
```

## **Access a Chart**

After creating a chart, you can retrieve it through the shape collection.

```cpp
static void AccessChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 400, 300);

    // Access the first chart on the slide.
    auto firstChart = SharedPtr<IChart>();
    for (auto&& shape : slide->get_Shapes()) {
        if (ObjectExt::Is<IChart>(shape)) {
            firstChart = ExplicitCast<IChart>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```cpp
static void RemoveChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 300);

    // Remove the chart.
    slide->get_Shapes()->Remove(chart);

    presentation->Dispose();
}
```

## **Update Chart Data**

You can change chart properties such as the title.

```cpp
static void UpdateChartData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 400, 300);

    // Change the chart title.
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sales Report");

    presentation->Dispose();
}
```
