---
title: 円グラフ
type: docs
url: /ja/java/pie-chart/
---

## **円グラフのセカンドプロットオプション**
Aspose.Slides for Javaは、円グラフまたは円の円グラフのセカンドプロットオプションをサポートしています。このトピックでは、Aspose.Slidesを使用してそれらのオプションを指定する方法を示します。プロパティを指定するには、次のようにします。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのオブジェクトをインスタンス化します。
1. スライドにグラフを追加します。
1. グラフのセカンドプロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、円の円グラフの異なるプロパティを設定しています。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドにグラフを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 異なるプロパティを設定
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // プレゼンテーションをディスクに書き込み
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **自動円グラフスライスの色を設定**
Aspose.Slides for Javaは、自動円グラフスライドの色を設定するためのシンプルなAPIを提供します。サンプルコードは、上記のプロパティを設定します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでグラフを追加します。
1. グラフのタイトルを設定します。
1. 最初のシリーズに値を表示するように設定します。
1. グラフデータシートのインデックスを設定します。
1. グラフデータワークシートを取得します。
1. デフォルトで生成されたシリーズとカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しいシリーズを追加します。

修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // デフォルトデータでグラフを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // グラフのタイトルを設定
    chart.getChartTitle().addTextFrameForOverriding("サンプルタイトル");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初のシリーズに値を表示するように設定
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // グラフデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;

    // グラフデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // デフォルトで生成されたシリーズとカテゴリを削除
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいカテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "第一四半期"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "第二四半期"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "第三四半期"));

    // 新しいシリーズを追加
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "シリーズ 1"), chart.getType());

    // シリーズデータを設定
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```