---
title: Chart
type: docs
weight: 60
url: /androidjava/examples/elements/chart/
keywords:
- code example
- chart
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Master charts with Aspose.Slides for Android: create, format, bind data, and export charts in PPT, PPTX, and ODP with Java examples."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for Android via Java**. The snippets below demonstrate basic chart operations.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Add a simple area chart to the first slide.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Chart**

After creating a chart, you can retrieve it through the shape collection.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Access the first chart on the slide.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Remove the chart.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Update Chart Data**

You can change chart properties such as the title.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Change the chart title.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```
