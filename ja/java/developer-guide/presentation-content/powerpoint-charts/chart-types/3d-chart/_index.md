---
title: 3Dチャート
type: docs
url: /java/3d-chart/
---

## **3DチャートのRotationX、RotationY、およびDepthPercentsプロパティを設定する**
Aspose.Slides for Javaは、これらのプロパティを設定するためのシンプルなAPIを提供します。以下の記事では、**X、Y回転、DepthPercents**などのさまざまなプロパティを設定する方法を説明します。サンプルコードは、上記のプロパティを設定する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3Dプロパティを設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // デフォルトデータでチャートを追加
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;
    
    // チャートデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // シリーズを追加
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "シリーズ 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "シリーズ 2"), chart.getType());
    
    // カテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"));
    
    // Rotation3Dプロパティを設定
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // 2番目のチャート系列を取得
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // シリーズデータを入力
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // OverLap値を設定
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // プレゼンテーションをディスクに書き込み
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```