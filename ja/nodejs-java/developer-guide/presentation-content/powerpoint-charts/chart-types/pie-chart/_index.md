---
title: 円グラフ
type: docs
url: /ja/nodejs-java/pie-chart/
---

## **パイ・オブ・パイ と バー・オブ・パイ チャートの第2プロットオプション**
Aspose.Slides for Node.js via Java は、パイ・オブ・パイ または バー・オブ・パイ チャートの第2プロットオプションをサポートするようになりました。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法を示します。プロパティを指定するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの第2プロットオプションを指定します。
1. プレゼンテーションを書き込みます。

以下の例では、パイ・オブ・パイ チャートのさまざまなプロパティを設定しています。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // スライドにチャートを追加する
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // さまざまなプロパティを設定する
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // プレゼンテーションをディスクに保存する
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **自動パイチャートスライスカラーの設定**
Aspose.Slides for Node.js via Java は、自動パイチャートのスライスカラーを設定するためのシンプルな API を提供します。サンプルコードは、上記のプロパティ設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初の系列を値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```javascript
// Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // デフォルトデータでチャートを追加する
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // チャートのタイトルを設定する
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // 最初の系列を値を表示するように設定する
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // チャート データ シートのインデックスを設定する
    var defaultWorksheetIndex = 0;
    // チャート データ ワークシートを取得する
    var fact = chart.getChartData().getChartDataWorkbook();
    // デフォルトで生成された系列とカテゴリを削除する
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 新しいカテゴリを追加する
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // 新しい系列を追加する
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // 系列データを入力しています
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**「Pie of Pie」および「Bar of Pie」バリエーションはサポートされていますか？**

はい、ライブラリは[サポート](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)しています。ピーチャートのセカンダリプロットで、「Pie of Pie」および「Bar of Pie」タイプを含みます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)できます（PNG など）。プレゼンテーション全体を含めずにエクスポート可能です。