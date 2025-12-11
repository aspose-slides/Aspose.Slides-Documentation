---
title: Android のプレゼンテーションでチャートの凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/androidjava/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用してチャート凡例をカスタマイズし、カスタマイズされた凡例書式で PowerPoint プレゼンテーションを最適化します。"
---

## **凡例の配置**
凡例のプロパティを設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、チャートの凡例の位置とサイズを設定しています。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スライドにクラスター化された縦棒グラフを追加
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // 凡例のプロパティを設定
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // プレゼンテーションをディスクに保存
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **凡例のフォントサイズの設定**
Aspose.Slides for Android via Java を使用すると、開発者は凡例のフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションを書き込みます。
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


## **個別凡例エントリのフォントサイズの設定**
Aspose.Slides for Android via Java を使用すると、開発者は個々の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションを書き込みます。
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


## **よくある質問**

**凡例を有効にして、チャートが自動的に凡例のためのスペースを確保し、重ね合わせないようにできますか？**
はい。非オーバーレイモード（[setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)）を使用します。この場合、プロット領域が縮小され、凡例を収めます。

**凡例ラベルを複数行にできますか？**
はい。スペースが不足すると長いラベルは自動的に折り返されます。強制改行は、シリーズ名に改行文字を入れることでサポートされます。

**凡例をプレゼンテーションテーマのカラースキームに従わせるにはどうすればよいですか？**
凡例やそのテキストに対して明示的な色・塗りつぶし・フォントを設定しないでください。そうすればテーマから継承され、デザイン変更時に正しく更新されます。