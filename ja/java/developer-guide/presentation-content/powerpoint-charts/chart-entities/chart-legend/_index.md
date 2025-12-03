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
description: "Aspose.Slides for Java を使用してチャート凡例をカスタマイズし、PowerPoint プレゼンテーションを最適化するために、特別な凡例書式設定を行います。"
---

## **凡例の配置**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを書き出して PPTX ファイルとして保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドにクラスタ化された縦棒グラフを追加
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // 凡例のプロパティを設定
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // プレゼンテーションを書き出してディスクに保存
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **凡例のフォントサイズの設定**
Aspose.Slides for Java を使用すると、開発者は凡例のフォントサイズを設定できます。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- 既定のチャートを作成します。
- フォントサイズを設定します。
- 最小軸の値を設定します。
- 最大軸の値を設定します。
- プレゼンテーションをディスクに書き込みます。

```java
// Presentation クラスのインスタンスを作成
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


## **個別凡例のフォントサイズの設定**
Aspose.Slides for Java を使用すると、開発者は個別の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- 既定のチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸の値を設定します。
- 最大軸の値を設定します。
- プレゼンテーションをディスクに書き込みます。

```java
// Presentation クラスのインスタンスを作成
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

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。非オーバーレイモード（[setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)）を使用します。この場合、プロット領域が縮小して凡例を収容します。

**凡例ラベルを複数行にすることはできますか？**

はい。スペースが不足すると長いラベルは自動的に折り返されます。改行文字をシリーズ名に含めることで強制的な改行もサポートされます。

**凡例をプレゼンテーションのテーマカラー スキームに従わせるにはどうすればよいですか？**

凡例やそのテキストに対して明示的な色/塗りつぶし/フォントを設定しないでください。そうすればテーマから継承され、デザインが変更されたときに正しく更新されます。