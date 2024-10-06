---
title: トレンドライン
type: docs
url: /ja/androidjava/trend-line/
---

## **トレンドラインの追加**
Aspose.Slides for Android via Javaは、さまざまなチャートのトレンドラインを管理するためのシンプルなAPIを提供します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを使ってスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意のタイプを選択します（この例ではChartType.ClusteredColumnを使用）。
1. チャート系列1に対して指数トレンドラインを追加します。
1. チャート系列1に対して線形トレンドラインを追加します。
1. チャート系列2に対して対数トレンドラインを追加します。
1. チャート系列2に対して移動平均トレンドラインを追加します。
1. チャート系列3に対して多項式トレンドラインを追加します。
1. チャート系列3に対して幾何トレンドラインを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

以下のコードはトレンドライン付きのチャートを作成するために使用されます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // クラスタ列チャートを作成
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // チャート系列1のために指数トレンドラインを追加
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // チャート系列1のために線形トレンドラインを追加
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // チャート系列2のために対数トレンドラインを追加
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("新しい対数トレンドライン");
    
    // チャート系列2のために移動平均トレンドラインを追加
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("新しいトレンドライン名");
    
    // チャート系列3のために多項式トレンドラインを追加
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // チャート系列3のために幾何トレンドラインを追加
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // プレゼンテーションを保存
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタムラインの追加**
Aspose.Slides for Android via Javaは、チャートにカスタムラインを追加するためのシンプルなAPIを提供します。プレゼンテーションの選択されたスライドにシンプルな平面ラインを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapesオブジェクトで公開されているAddChartメソッドを使用して新しいチャートを作成します
- Shapesオブジェクトで公開されているAddAutoShapeメソッドを使用して線形タイプのAutoShapeを追加します
- 形状のラインの色を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き出します

以下のコードはカスタムライン付きのチャートを作成するために使用されます。

```java
// Presentationクラスのインスタンスを作成
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