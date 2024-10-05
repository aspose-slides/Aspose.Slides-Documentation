---
title: チャートの凡例
type: docs
url: /java/chart-legend/
---

## **凡例の配置**
凡例のプロパティを設定するために、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャートの凡例の位置とサイズを設定しています。

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add a clustered column chart on the slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Set Legend Properties
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Write presentation to disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **凡例のフォントサイズを設定する**
Aspose.Slides for Java では、開発者が凡例のフォントサイズを設定できるようにしています。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **個別凡例のフォントサイズを設定する**
Aspose.Slides for Java では、開発者が個別の凡例エントリのフォントサイズを設定できるようにしています。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```