---
title: JavaScript を使用して Treemap と Sunburst チャートのデータポイントをカスタマイズする
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ツリーマップチャート
- サンバーストチャート
- 階層チャート
- データポイント
- データラベル
- ブランチカラー
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、ツリーマップとサンバーストチャートで階層データを作成し、レベル、ラベル、カラーをカスタマイズする方法を学びます。"
---
## **概要**

Treemap と Sunburst のチャートは同じ階層データを表示しますが、レイアウトが異なります。Treemap は階層を入れ子になった矩形で表し、矩形の面積がリーフの値を示します。Sunburst は同心円状のリングで表し、最上位のグループは中心に近く、リーフカテゴリは外側のリングに配置されます。

Aspose.Slides for Node.js via Java では、各数値は [ChartDataPoint](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/) です。その [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) メソッドでリーフと親グループにアクセスできます。本記事ではこのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成・書式設定する方法を示します。

![Consumer と Business のブランチを含むツリーマップチャート](treemap-hierarchy.png)

![同じ Consumer と Business の階層を持つサンバーストチャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、レベルの理解**

以下のサンプルは 3 つのカテゴリレベルと 1 つの数値系列で構成されています。

| ブランチ | ステム | リーフ | 収益 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

各行は 1 つのリーフカテゴリと 1 つのデータポイントを作成します。カテゴリのグルーピングレベルは、そのリーフから親までのパスを表します。最初の行のパスは `Consumer > Computers > Laptops` です。

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) が返すインデックスはリーフから上方向へ進みます。

| `getDataPointLevels()` インデックス | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | Leaf | 値の矩形 | 外側リングのセグメント |
| `1` | Stem | 親矩形またはヘッダー | 中間リングのセグメント |
| `2` | Branch | 最上位矩形またはヘッダー | 内側リングのセグメント |

この順序は両方のチャートタイプで同じです。親セグメントは複数のリーフで共有されます。書式設定するには、そのグループ内の最初のデータポイントの対応レベルを使用します。たとえば `Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`dataPoints.get_Item(0)` や `dataPoints.get_Item(6)` といった説明のない式を使うよりも、これらのポイントへの参照を保持した方が分かりやすく安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全なサンプルは、1枚目のスライドに Treemap、2枚目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチラベルを書式設定し、プレゼンテーションを保存します。

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // リーフカテゴリを追加します。グルーピング項目は新しいグループが始まるときだけ設定されます;
        // その後のカテゴリは別の項目が設定されるまで同じグループに残ります。
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Tablets リーフにカテゴリと値を表示します。
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // そのブランチの最初のリーフを介して Consumer ブランチの書式を設定します。
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // そのステムの最初のリーフを介して Software ステムの書式を設定します。
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout は Treemap の親ラベルに影響し、Sunburst はリングセグメントを使用します。
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

カテゴリセルと値セルは同じワークシート行を使用するため、コレクションの位置は常に揃っています。既存のチャートを操作する場合は、まずカテゴリ行を確認し、書式設定したいデータポイントとレベルへの名前付き参照を保存してください。

## **動作と実用上の考慮事項**

### **ツリーマップとサンバーストの違い**

- ツリーマップは面積で値を、入れ子矩形で階層を表現します。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout)` メソッドでこのチャートタイプの親ラベル表示を制御します。
- サンバーストは角度で値を、リングの深さで階層を表現します。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout)` はリングラベルには作用しません。
- 両チャートは同じカテゴリグルーピングレベルと、`[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels)` が返すリーフ→親の順序を使うため、データ構築とレベル書式設定のコードを共有できます。
- 親値は子リーフから計算されます。ブランチやステム用に別個の数値ポイントを追加しないでください。

### **ソートとセグメントの順序**

チャートのレイアウトエンジンが矩形やリングセグメントの最終配置を決定します。関連するカテゴリ行はまとめてから追加してください。ただし、特定の矩形位置や開始角度に依存しないでください。順序に意味がある場合はラベルに含めるか、明示的なカテゴリ軸を持つチャートタイプを使用します。

### **テーマと固定色**

書式設定されていないチャートレベルはプレゼンテーションテーマから色を継承します。例では予測可能な出力のために明示的な RGB 塗りを使用しています。テーマ変更に合わせたい場合は固定 RGB の代わりにスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。ブランチやステムの塗りを変更した後はラベルのコントラストも確認してください。

### **ラベルと利用可能スペース**

セグメントが小さすぎると PowerPoint はラベルを非表示または切り詰めます。チャートサイズを大きくする、カテゴリ名を短くする、あるいは表示するラベル項目を減らすと、より明瞭な結果が得られます。`[DataLabelFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datalabelformat/)` を使ってカテゴリ名、系列名、値を組み合わせられますが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX で保存するとチャートは編集可能です。Aspose.Slides がプレゼンテーションを PDF や画像にレンダリングする際、サポートされている塗りとラベル設定がそのまま描画されます。フォントの置き換えや利用可能なレイアウトスペースの差異により改行やラベル可視性が変わることがあるため、必要なフォントをインストールし、重要なエクスポート先で結果を検証してください。

## **よくある質問**

**親レベルを変更すると複数のリーフに影響するのはなぜですか？**

ブランチやステムは共有されるビジュアルセグメントです。その `[ChartDataPointLevel](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapointlevel/)` は子リーフから取得できますが、書式設定はその共有親セグメント全体に適用され、個々のリーフだけに限定されません。

**データラベルが表示されないのはなぜですか？**

まずラベルの `[DataLabelFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datalabelformat/)` オブジェクトで必要なフィールドを有効にします。次にセグメントに十分なスペースがあるか確認してください。Treemap の親ラベルレイアウト、チャートサイズ、ラベル長、フォントサイズ、そして有効化したフィールド数がラベル表示可否に影響します。

**セグメントの正確な順序や座標を設定できますか？**

行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウトエンジンが階層、値、利用可能スペースから計算します。

**プレゼンテーションのテーマを変更した後、色が変わるのはなぜですか？**

テーマベースの塗りはプレゼンテーションのパレットに従うよう設計されています。固定したいレベルには明示的な RGB 色を適用するか、テーマ変更に合わせてスキームカラーを使用してください。

**PDF や画像へのエクスポート時にカスタム書式設定は保持されますか？**

はい、サポートされているチャートの塗りとラベル設定はレンダリング時に含まれます。システム間で結果を統一するには、必要なフォントを用意し、ラベルのフィットはレイアウトに依存するため最終エクスポートサイズをテストしてください。

## **関連項目**

- [ツリーマップチャートの作成](/slides/ja/nodejs-java/create-chart/#creating-tree-map-charts)
- [サンバーストチャートの作成](/slides/ja/nodejs-java/create-chart/#creating-sunburst-charts)
- [プレゼンテーションチャートのエクスポート](/slides/ja/nodejs-java/export-chart/)
- [プレゼンテーションテーマの管理](/slides/ja/nodejs-java/presentation-theme/)