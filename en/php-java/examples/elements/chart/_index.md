---
title: Chart
type: docs
weight: 60
url: /php-java/examples/elements/chart/
keywords:
- chart
- add chart
- access chart
- remove chart
- update chart
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Create and customize charts in PHP with Aspose.Slides: add data, format series, axes and labels, change types, and export—works with PPT, PPTX and ODP."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for PHP via Java**. The snippets below demonstrate basic chart operations.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Add a simple column chart to the slide.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Chart**

Retrieve the chart from the shape collection.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first chart on the slide.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is the chart.
        $chart = $slide->getShapes()->get_Item(0);

        // Remove the chart.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update Chart Data**

You can change chart properties such as the title.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is the chart.
        $chart = $slide->getShapes()->get_Item(0);

        // Change the chart title.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
