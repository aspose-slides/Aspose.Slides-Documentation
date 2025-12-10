---
title: Javaを使用したプレゼンテーションの円グラフカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/java/pie-chart/
keywords:
- 円グラフ
- グラフ管理
- グラフカスタマイズ
- グラフオプション
- グラフ設定
- プロットオプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slidesを使用してJavaで円グラフを作成・カスタマイズし、PowerPointへエクスポートできる方法を学び、数秒でデータストーリーテリングを強化します。"
---

## **パイ・オブ・パイ および バー・オブ・パイ チャートの第二プロットオプション**
Aspose.Slides for Java は、パイ・オブ・パイまたはバー・オブ・パイチャートの第二プロットオプションをサポートします。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの第二プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、パイ・オブ・パイチャートのさまざまなプロパティを設定しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // スライドにチャートを追加します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // さまざまなプロパティを設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // プレゼンテーションをディスクに保存します
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **自動パイチャートスライスカラーの設定**
Aspose.Slides for Java は、パイチャートのスライスカラーを自動的に設定する簡単な API を提供します。サンプルコードは、上記プロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初の系列の「値を表示」を設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // デフォルトデータでチャートを追加します
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // チャートタイトルを設定します
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初の系列に値の表示を設定します
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // チャートデータシートのインデックスを設定します
    int defaultWorksheetIndex = 0;

    // チャートデータのワークシートを取得します
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // デフォルトで生成された系列とカテゴリを削除します
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 新しいカテゴリを追加します
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // 新しい系列を追加します
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

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


## **よくある質問**

**「パイ・オブ・パイ」および「バー・オブ・パイ」バリエーションはサポートされていますか？**

はい、ライブラリは[パイチャートの第二プロット](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)（「パイ・オブ・パイ」および「バー・オブ・パイ」タイプを含む）をサポートしています。

**チャートだけを画像（たとえば PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体ではなく、チャート自体を画像（PNG など）として[エクスポート](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-)できます。