---
title: Java を使用したプレゼンテーションでの円グラフのカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/java/pie-chart/
keywords:
- 円グラフ
- チャート管理
- チャートカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用した Java で円グラフを作成・カスタマイズし、PowerPoint にエクスポートできる方法を学び、データストーリーテリングを数秒で向上させましょう。"
---

## **Pie of Pie および Bar of Pie グラフの第2プロットオプション**
Aspose.Slides for Java は、Pie of Pie または Bar of Pie グラフの第2プロットオプションをサポートしています。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の手順を実行します:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの第2プロットオプションを指定します。
4. プレゼンテーションを書き込みます。

以下の例では、Pie of Pie グラフのさまざまなプロパティを設定しています。
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


## **自動円グラフスライス色の設定**
Aspose.Slides for Java は、自動的に円グラフスライスの色を設定するシンプルな API を提供します。サンプルコードは、上記のプロパティ設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. チャートのタイトルを設定します。
5. 最初の系列で値を表示するように設定します。
6. チャートデータシートのインデックスを設定します。
7. チャートデータのワークシートを取得します。
8. デフォルトで生成された系列とカテゴリを削除します。
9. 新しいカテゴリを追加します。
10. 新しい系列を追加します。

変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 既定データでチャートを追加
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // チャートのタイトルを設定
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初の系列で値を表示するように設定
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;

    // チャートデータのワークシートを取得
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

    // 系列データを設定
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

**'Pie of Pie' と 'Bar of Pie' のバリエーションはサポートされていますか？**

はい、ライブラリは[サポート](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)しており、'Pie of Pie' と 'Bar of Pie' のタイプを含む円グラフのセカンダリプロットを利用できます。

**チャートだけを画像（例：PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体を含めずに、チャート自体を画像（PNG など）として[エクスポート](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-)できます。