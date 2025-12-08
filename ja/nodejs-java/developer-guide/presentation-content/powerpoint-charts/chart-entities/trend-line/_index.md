---
title: トレンドライン
type: docs
url: /ja/nodejs-java/trend-line/
---

## **トレンドラインを追加**

Aspose.Slides for Node.js via Java は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します:

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルト データと任意のタイプ (この例では ChartType.ClusteredColumn) のチャートを追加します。
1. シリーズ 1 のチャートに指数トレンドラインを追加します。
1. シリーズ 1 のチャートに線形トレンドラインを追加します。
1. シリーズ 2 のチャートに対数トレンドラインを追加します。
1. シリーズ 2 のチャートに移動平均トレンドラインを追加します。
1. シリーズ 3 のチャートに多項式トレンドラインを追加します。
1. シリーズ 3 のチャートに冪トレンドラインを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードはトレンドライン付きチャートを作成するために使用されます。
```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // クラスタ化カラムチャートを作成しています
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // チャート系列 1 に指数トレンドラインを追加しています
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // チャート系列 1 に線形トレンドラインを追加しています
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // チャート系列 2 に対数トレンドラインを追加しています
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // チャート系列 2 に移動平均トレンドラインを追加しています
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // チャート系列 3 に多項式トレンドラインを追加しています
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // チャート系列 3 にべき乗トレンドラインを追加しています
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // プレゼンテーションを保存しています
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタムラインを追加**

Aspose.Slides for Node.js via Java は、チャートにカスタムラインを追加するためのシンプルな API を提供します。プレゼンテーションの対象スライドにシンプルな直線を追加するには、以下の手順に従ってください:

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトが公開する AddChart メソッドで新しいチャートを作成します
- Shapes オブジェクトが公開する AddAutoShape メソッドでラインタイプの AutoShape を追加します
- 図形の線の色を設定します
- 変更されたプレゼンテーションを PPTX ファイルとして書き込みます

以下のコードはカスタムライン付きチャートを作成するために使用されます。
```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**トレンドラインにおける「前方」および「後方」とは何ですか？**

トレンドラインを前方/後方に投影した長さです: 散布図 (XY) チャートの場合は軸の単位、散布図以外のチャートの場合はカテゴリの数で表されます。負の値は許可されません。

**トレンドラインは PDF、SVG にエクスポートしたり、スライドを画像にレンダリングしたりしたときに保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/nodejs-java/render-a-slide-as-an-svg-image/) に変換し、チャートを画像にレンダリングします。チャートの一部であるトレンドラインはこれらの操作中に保持されます。また、[チャートの画像をエクスポート](/slides/ja/nodejs-java/create-shape-thumbnails/) するメソッドも利用可能です。