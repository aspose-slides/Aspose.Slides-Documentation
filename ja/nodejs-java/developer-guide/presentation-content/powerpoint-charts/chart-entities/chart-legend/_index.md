---
title: チャート凡例
type: docs
url: /ja/nodejs-java/chart-legend/
---

## **凡例の位置指定**

凡例のプロパティを設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、チャートの凡例の位置とサイズを設定しています。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // スライドの参照を取得する
    var slide = pres.getSlides().get_Item(0);
    // スライドにクラスター化された縦棒チャートを追加する
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // 凡例のプロパティを設定する
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // プレゼンテーションをディスクに保存する
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **凡例のフォントサイズを設定**

Aspose.Slides for Node.js via Java を使用すると、開発者は凡例のフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを生成します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **個別凡例エントリのフォントサイズを設定**

Aspose.Slides for Node.js via Java を使用すると、開発者は個別の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- Presentation クラスのインスタンスを生成します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的に領域を確保するようにできますか？**

はい。非オーバーレイモード（[setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)）を使用します。この場合、プロット領域が縮小して凡例を収めるようになります。

**凡例ラベルを複数行にすることはできますか？**

はい。スペースが不足している場合、長いラベルは自動的に折り返されます。改行文字をシリーズ名に入れることで、強制的に改行することも可能です。

**凡例をプレゼンテーションテーマの配色に合わせるにはどうすればよいですか？**

凡例やそのテキストに明示的な色・塗りつぶし・フォントを設定しないでください。そうすればテーマから継承され、デザインが変更された際にも正しく更新されます。