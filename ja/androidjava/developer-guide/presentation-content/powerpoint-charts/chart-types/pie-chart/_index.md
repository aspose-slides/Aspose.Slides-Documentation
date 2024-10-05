---
title: パイチャート
type: docs
url: /androidjava/pie-chart/
---

## **パイオブパイおよびバーボブパイチャートの第二プロットオプション**
Aspose.Slides for Android via Javaは、パイオブパイまたはバーボブパイチャートの第二プロットオプションをサポートしています。このトピックでは、Aspose.Slidesを使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の操作を行います。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートの第二プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、パイオブパイチャートの異なるプロパティを設定しました。

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // スライドにチャートを追加します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 異なるプロパティを設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // プレゼンテーションをディスクに書き込みます
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **自動パイチャートスライスの色を設定する**
Aspose.Slides for Android via Javaは、自動パイチャートスライスの色を設定するためのシンプルなAPIを提供します。サンプルコードは、上記のプロパティを設定します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初の系列に値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータワークシートを取得します。
1. デフォルト生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

修正されたプレゼンテーションをPPTXファイルに書き込みます。

```java
// Presentationクラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // デフォルトデータを持つチャートを追加します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // チャートのタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("サンプルタイトル");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初の系列に値を表示するように設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // チャートデータシートのインデックスを設定します
    int defaultWorksheetIndex = 0;

    // チャートデータワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // デフォルト生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "第一四半期"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "第二四半期"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "第三四半期"));

    // 新しい系列を追加します
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "系列1"), chart.getType());

    // 系列データを設定します
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```