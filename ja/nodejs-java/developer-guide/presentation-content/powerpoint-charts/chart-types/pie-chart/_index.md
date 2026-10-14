---
title: JavaScript を使用してプレゼンテーションの円グラフをカスタマイズする
linktitle: 円グラフ
type: docs
url: /ja/nodejs-java/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して JavaScript で円グラフを作成およびカスタマイズします。セカンダリ プロットを構成し、データラベルを表示し、PowerPoint で自動スライスカラーを適用します。"
---
## **概要**

この記事では、Aspose.Slides で円グラフを操作する方法について説明します。Pie of Pie および Bar of Pie チャートのセカンダリ プロット オプションの構成方法と、標準円グラフのスライスの自動着色を有効にする方法を示します。

例では、スライドへのチャート追加、シリーズおよびラベル設定の調整、既定のチャートデータをカスタムのカテゴリと値に置き換える、そして更新されたプレゼンテーションの保存といったチャートカスタマイズ作業に焦点を当てています。

## **Pie of Pie および Bar of Pie チャートのセカンダリ プロット オプション**

Aspose.Slides for Node.js via Java は、Pie of Pie および Bar of Pie チャートのセカンダリ プロット オプションをサポートしています。これらのオプションは、セカンダリ プロットのサイズと、データポイントが 2 つのプロット間でどのように分割されるかを制御します。

次の例は、新しいプレゼンテーションに Pie of Pie チャートを作成し、データポイントの値をラベルとして表示します。[setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) メソッドはセカンダリ プロットのサイズをメイン プロットの 149% に設定します。[setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) はパーセンテージベースの分割を選択し、[setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) はしきい値を 53% に設定します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // 値を表示し、セカンダリ プロットを構成します。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **セカンダリ プロットのカテゴリを選択**

パーセンテージ値に関係なく、特定のカテゴリをセカンダリ プロットでグループ化したい場合はカスタム分割を使用します。例えば、売上レポートで Online と Events を一緒に表示すると、読者はこれら 2 つのチャネルを比較でき、全体売上の 35% と 10% を占めていても問題ありません。

[setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) を [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) とともに呼び出し、[getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) でポイントを選択します。コレクションの [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) メソッドはシリーズ内のゼロベースインデックスを受け取ります。[addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) を使用してデータポイント オブジェクトを追加します。この例では、インデックス 1 が Online を選択し、インデックス 3 のポイントが Events を選択します。Partners も一時的に追加され、その後 [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) で除外されます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // デフォルト データをチャネル別の売上に置き換えます。
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online をゼロベース インデックスで、Events をデータポイント オブジェクトで選択します。
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners を選択から除外します（ソース データは削除しません）。
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) と Events (10) はセカンダリ プロットで別々のスライスとして表示されます。プライマリ プロットでは、Retail (40) と Partners (15) と共に、これらは 45 の値を持つ 1 つの結合スライスで表されます。カスタム選択から Partners を除外しても、プライマリ プロットには残り、カテゴリやその値がチャートの元データから削除されるわけではありません。

以下の画像は、PowerPoint で保存されたプレゼンテーションを示します：

![セカンダリ プロットに Online と Events を含み、プライマリ プロットでその合計値 45 を示す Pie of Pie チャート](pie_of_pie_custom.png)

## **自動円グラフ スライスの色設定**

Aspose.Slides for Node.js via Java は、円グラフのスライスに自動的に異なる色を割り当てることができます。次の例は、センタリングされたタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) メソッドは 20、50、30 の値をラベルとして表示し、[setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) は各スライスに個別の色を有効にします。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // 中央揃えのチャート タイトルを追加します。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 最初のワークシートを使用して既定のデータを置き換えます。
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 値を表示し、スライスに異なる色を割り当てます。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 円グラフのセカンダリ プロットをサポートしており、Pie of Pie と Bar of Pie のタイプを含みます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[export the chart itself as an image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)（PNG など）を使用すれば、プレゼンテーション全体をエクスポートせずにチャートだけを画像としてエクスポートできます。