---
title: Android のプレゼンテーションでパイチャートをカスタマイズする
linktitle: パイチャート
type: docs
url: /ja/androidjava/pie-chart/
keywords:
- パイチャート
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスの色
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java でパイチャートを作成およびカスタマイズする方法を学び、PowerPoint へエクスポート可能で、数秒でデータストーリーテリングを強化します。"
---

## **パイ・オブ・パイ および バー・オブ・パイ チャートの第2プロットオプション**
Aspose.Slides for Android via Java は、Pie of Pie または Bar of Pie チャートの第2プロットオプションをサポートするようになりました。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の手順を実行します。

1. Instantiate [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

以下の例では、Pie of Pie チャートのさまざまなプロパティを設定しています。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // スライドにチャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 異なるプロパティを設定
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // プレゼンテーションをディスクに保存
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **自動パイチャートスライスの色を設定**
Aspose.Slides for Android via Java は、パイチャートスライスの自動色設定のためのシンプルな API を提供します。サンプルコードは上記のプロパティ設定を適用しています。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.

Write the modified presentation to a PPTX file.
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // デフォルトデータでチャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // チャートのタイトルを設定
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 1 番目の系列で値を表示
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;

    // チャートデータワークシートを取得
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // デフォルトで生成された系列とカテゴリを削除
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいカテゴリを追加
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // 新しい系列を追加
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // 系列データを現在設定
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) a secondary plot for pie charts, including the 'Pie of Pie' and 'Bar of Pie' types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (such as PNG) without the entire presentation.