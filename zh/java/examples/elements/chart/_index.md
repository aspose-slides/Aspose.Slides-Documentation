---
title: 图表
type: docs
weight: 60
url: /zh/java/examples/elements/chart/
keywords:
- 代码示例
- 图表
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 掌握图表：创建、格式化、绑定数据，并通过 Java 示例将图表导出为 PPT、PPTX 和 ODP。"
---
以下示例展示了使用 **Aspose.Slides for Java** 添加、访问、删除和更新不同图表类型。下面的代码片段演示了基本的图表操作。

## **添加图表**

此方法在第一张幻灯片中添加一个简单的面积图。

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 向第一张幻灯片添加一个简单的面积图。
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **访问图表**

创建图表后，您可以通过形状集合检索它。

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // 访问幻灯片上的第一个图表。
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

## **删除图表**

以下代码从幻灯片中删除图表。

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // 移除图表。
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **更新图表数据**

您可以更改图表属性，例如标题。

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // 更改图表标题。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```