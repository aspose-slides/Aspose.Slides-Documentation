---
title: Android のプレゼンテーションチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/androidjava/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べき乗トレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint のチャートにトレンドラインをすばやく追加およびカスタマイズし、聴衆を引き付ける実用的なガイド。"
---

## **トレンドラインを追加**
Aspose.Slides for Android via Java は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します。

1. [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと任意のタイプのチャートを追加します（この例では ChartType.ClusteredColumn を使用）。
1. チャート系列 1 に指数トレンドラインを追加します。
1. チャート系列 1 に線形トレンドラインを追加します。
1. チャート系列 2 に対数トレンドラインを追加します。
1. チャート系列 2 に移動平均トレンドラインを追加します。
1. チャート系列 3 に多項式トレンドラインを追加します。
1. チャート系列 3 にべき乗トレンドラインを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコードはトレンドライン付きチャートを作成するために使用されます。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // クラスタード・カラム チャートを作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // チャート系列 1 に指数トレンドラインを追加
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // チャート系列 1 に線形トレンドラインを追加
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // チャート系列 2 に対数トレンドラインを追加
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // チャート系列 2 に移動平均トレンドラインを追加
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // チャート系列 3 に多項式トレンドラインを追加
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // チャート系列 3 にべき乗トレンドラインを追加
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // プレゼンテーションを保存
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カスタムラインを追加**
Aspose.Slides for Android via Java は、チャートにカスタムラインを追加するシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する AddChart メソッドを使用して新しいチャートを作成します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して線タイプの AutoShape を追加します。
- シェイプの線の色を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下のコードはカスタムライン付きチャートを作成するために使用されます。
```java
// Presentation クラスのインスタンスを作成
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

トレンドラインを前方または後方に投影した長さを表します。散布図（XY）チャートの場合は軸の単位で、散布図以外のチャートの場合はカテゴリ数で表されます。負の値は使用できません。

**トレンドラインは PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりしたときに保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/androidjava/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像をエクスポートするためのメソッドも利用可能です。