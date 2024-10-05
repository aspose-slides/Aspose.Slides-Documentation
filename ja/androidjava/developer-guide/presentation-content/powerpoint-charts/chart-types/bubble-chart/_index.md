---
title: バブルチャート
type: docs
url: /androidjava/bubble-chart/
---

## **バブルチャートサイズスケーリング**
Aspose.Slides for Android via Javaは、バブルチャートサイズスケーリングをサポートしています。Aspose.Slides for Android via Javaの [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--)、および [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-)メソッドが追加されました。以下にサンプル例を示します。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **データをバブルチャートサイズとして表現する**
メソッド [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) および [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) が [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) インターフェース、及び関連クラスに追加されました。**BubbleSizeRepresentation** は、バブルチャートのバブルサイズ値がどのように表現されるかを指定します。可能な値は、[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) および [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width) です。それに応じて、データをバブルチャートサイズとして表現する方法を指定するために [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) 列挙体が追加されました。サンプルコードは以下に示します。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```