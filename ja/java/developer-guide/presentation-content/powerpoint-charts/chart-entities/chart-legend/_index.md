---
title: Java を使用したプレゼンテーションでのチャート凡例のカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、チャート凡例をカスタマイズし、PowerPoint プレゼンテーションの凡例書式設定を最適化します。"
---

## **凡例の位置設定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、チャートの凡例の位置とサイズを設定しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // スライドの参照を取得します
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドにクラスタ化列チャートを追加します
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // 凡例のプロパティを設定します
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // プレゼンテーションをディスクに保存します
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **凡例のフォントサイズの設定**
Aspose.Slides for Javaでは、開発者が凡例のフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```java
// Presentation クラスのインスタンスを作成します
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


## **個別凡例エントリのフォントサイズの設定**
Aspose.Slides for Javaでは、開発者が個々の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```java
// Presentation クラスのインスタンスを作成します
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


## **FAQ**

**凡例を有効にして、チャートが凡例のために自動的に領域を確保し、重ね合わせないようにできますか？**
はい。非オーバーレイ モード（[setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)）を使用します。この場合、プロット領域が縮小して凡例を収めます。

**複数行の凡例ラベルを作成できますか？**
はい。スペースが不足すると長いラベルは自動的に折り返されます。改行文字をシリーズ名に含めることで強制的な改行もサポートされます。

**凡例をプレゼンテーションのテーマのカラースキームに合わせるにはどうすればよいですか？**
凡例やそのテキストに明示的な色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変更されても正しく更新されます。