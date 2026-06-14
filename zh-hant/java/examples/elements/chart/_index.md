---
title: 圖表
type: docs
weight: 60
url: /zh-hant/java/examples/elements/chart/
keywords:
- 程式碼範例
- 圖表
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 精通圖表：建立、格式化、繫結資料，並以 Java 範例將圖表匯出為 PPT、PPTX 與 ODP。"
---
以下示例說明如何在 **Aspose.Slides for Java** 中新增、存取、移除以及更新不同的圖表類型。下面的程式碼片段展示了基本的圖表操作。

## **新增圖表**

此方法在第一張投影片上新增一個簡單的面積圖。

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 在第一張投影片上新增一個簡單的面積圖。
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **存取圖表**

建立圖表後，您可以透過形狀集合取得它。

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // 存取投影片上的第一個圖表。
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

## **移除圖表**

以下程式碼會從投影片中移除圖表。

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // 移除圖表。
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **更新圖表資料**

您可以更改圖表屬性，例如標題。

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // 更改圖表標題。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```