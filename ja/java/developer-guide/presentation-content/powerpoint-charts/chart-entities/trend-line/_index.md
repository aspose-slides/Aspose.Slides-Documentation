---
title: Java のプレゼンテーションチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/java/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べきトレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint のチャートにトレンドラインをすばやく追加・カスタマイズし、聴衆を引き付ける実用的なガイド。"
---

## **トレンドラインを追加**
Aspose.Slides for Java は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと任意のタイプ（この例では ChartType.ClusteredColumn を使用）でチャートを追加します。
4. チャートシリーズ 1 に指数トレンドラインを追加します。
5. チャートシリーズ 1 に線形トレンドラインを追加します。
6. チャートシリーズ 2 に対数トレンドラインを追加します。
7. チャートシリーズ 2 に移動平均トレンドラインを追加します。
8. チャートシリーズ 3 に多項式トレンドラインを追加します。
9. チャートシリーズ 3 にべきトレンドラインを追加します。
10. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードは、トレンドライン付きのチャートを作成するために使用されます。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // クラスタ化縦棒チャートを作成します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // チャートシリーズ 1 に指数トレンドラインを追加します
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // チャートシリーズ 1 に線形トレンドラインを追加します
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // チャートシリーズ 2 に対数トレンドラインを追加します
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // チャートシリーズ 2 に移動平均トレンドラインを追加します
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // チャートシリーズ 3 に多項式トレンドラインを追加します
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // チャートシリーズ 3 にべきトレンドラインを追加します
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // プレゼンテーションを保存します
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```



## **カスタムラインを追加**
Aspose.Slides for Java は、チャートにカスタムラインを追加するためのシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトの AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトの AddAutoShape メソッドを使用して、ラインタイプの AutoShape を追加します
- シェイプの線の色を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き込みます

以下のコードは、カスタムライン付きのチャートを作成するために使用されます。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

トレンドラインを前方または後方に延長した長さを表します。散布図（XY）チャートの場合は軸単位で、散布図以外のチャートの場合はカテゴリ数で表されます。負の値は許可されません。

**プレゼンテーションを PDF や SVG にエクスポートする場合、またはスライドを画像としてレンダリングする場合、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを[PDF](/slides/ja/java/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/java/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を[エクスポートする](/slides/ja/java/create-shape-thumbnails/) メソッドも利用可能です。