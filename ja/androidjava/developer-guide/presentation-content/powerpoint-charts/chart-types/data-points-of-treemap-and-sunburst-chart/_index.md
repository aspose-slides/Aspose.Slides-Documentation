---
title: Android の Treemap および Sunburst チャートにおけるデータポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap チャート
- Sunburst チャート
- 階層チャート
- データポイント
- データラベル
- ブランチカラー
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、階層データの作成方法と Treemap および Sunburst チャートのレベル、ラベル、カラーのカスタマイズ方法を学びます。"
---
## **概要**

Treemap と Sunburst のチャートは同じ種類の階層データを表示しますが、レイアウトが異なります。Treemap は階層をネストされた矩形で描画し、矩形の面積がリーフの値を表します。Sunburst は同心円状のリングで描画し、最上位のグループが中心に近く、リーフのカテゴリは外側のリングに配置されます。

Aspose.Slides for Android via Java では、各数値は [IChartDataPoint](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/) です。その [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) メソッドでリーフとその親グループにアクセスできます。本稿ではこのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成・書式設定する方法を示します。

![Consumer と Business のブランチを持つ Treemap チャート](treemap-hierarchy.png)

![同じ Consumer と Business の階層を持つ Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データ ポイント、レベルの理解**

以下のサンプルは 3 つのカテゴリ レベルと 1 つの数値系列で構成されています。

| ブランチ | ステム | リーフ | 売上 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

各行は 1 つのリーフ カテゴリと 1 つのデータ ポイントを作成します。カテゴリのグルーピング レベルは、そのリーフから親へたどるパスを表します。最初の行の場合、パスは `Consumer > Computers > Laptops` です。

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) が返すインデックスは、リーフから上方向に進みます。

| `getDataPointLevels()` インデックス | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | リーフ | 値矩形 | 外側リングのセグメント |
| `1` | ステム | 親矩形またはヘッダー | 中間リングのセグメント |
| `2` | ブランチ | 最上位矩形またはヘッダー | 内側リングのセグメント |

この順序は両方のチャートタイプで同じですが、見た目のレイアウトは異なります。親セグメントは複数のリーフで共有されます。書式設定するには、そのグループ内の最初のデータ ポイントの該当レベルを使用します。たとえば、`Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。これらのポイントへの参照を保持する方が、`dataPoints.get_Item(0)` や `dataPoints.get_Item(6)` のような説明のない式を使用するよりも明確で安全です。

## **両方のチャートタイプの作成とカスタマイズ**

次の完全な例は、1 枚目のスライドに Treemap、2 枚目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチ ラベルを書式設定し、プレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // リーフカテゴリを追加します。新しいグループが開始されたときにのみグルーピング項目が設定されます;
        // それ以降のカテゴリは別の項目が設定されるまでそのグループに留まります。

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // タブレットのリーフにカテゴリと値を表示します。
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // そのブランチの最初のリーフを使用して Consumer ブランチの書式設定を行います。
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // そのステムの最初のリーフを使用して Software ステムの書式設定を行います。
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout は Treemap の親ラベルに影響します。Sunburst はリングセグメントを使用します。
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

カテゴリ セルと値セルは同じワークシート行を使用するため、コレクションの位置は常に揃っています。既存のチャートを操作する場合は、まずカテゴリ行を確認し、書式設定対象のデータ ポイントとレベルへの名前付き参照を保存してください。

## **動作上の考慮点と実用的な注意事項**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を示し、ネストされた矩形で階層を示します。`[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)` メソッドでこのチャートタイプの親ラベル表示を制御します。
- Sunburst は角度で値を示し、リングの深さで階層を示します。`[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)` はリング ラベルには影響しません。
- 両方のチャートは同じカテゴリ グルーピング レベルと、`[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)` が返すリーフ→親の順序を使用するため、データ構築とレベル書式設定のコードを共有できます。
- 親の値は子孫リーフから計算されます。ブランチやステム用に別個の数値ポイントを追加しないでください。

### **ソートとセグメント順序**

チャートのレイアウト エンジンが矩形やリング セグメントの最終配置を決定します。関連するカテゴリ行はまとめてから追加してください。ただし、特定の矩形位置や開始角度に依存しないでください。順序に意味がある場合はラベルに含めるか、明示的なカテゴリ軸を持つチャート タイプを使用します。

### **テーマと固定色**

書式設定されていないチャート レベルはプレゼンテーションのテーマから色を継承します。例では予測可能な結果を得るために明示的な RGB 塗りを使用しています。テーマ変更に追従させたい場合は固定 RGB 値の代わりにスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。また、ブランチやステムの塗りを変更した後はラベルのコントラストを確認してください。

### **ラベルと利用可能スペース**

セグメントが小さすぎると PowerPoint はラベルを非表示にしたり切り詰めたりします。チャート サイズを大きくする、カテゴリ名を短くする、または表示するラベル項目を減らすと、より分かりやすい結果が得られます。`[IDataLabelFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/)` でカテゴリ名、系列名、値を組み合わせられますが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX で保存するとチャートは編集可能なままです。Aspose.Slides がプレゼンテーションを PDF や画像にレンダリングする際、サポートされた塗りとラベル設定がチャートに反映されます。フォント置換や利用可能なレイアウト空間の差異により改行やラベル表示が変わることがあるため、必要なフォントをインストールし、重要なエクスポート先で確認してください。

## **FAQ**

**親レベルを変更すると複数のリーフに影響が出るのはなぜですか？**

ブランチやステムは共有されるビジュアル セグメントです。その `[IChartDataPointLevel](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointlevel/)` は子孫リーフからアクセスできますが、書式設定はそのリーフだけでなく共有される親セグメントに対して行われます。

**データ ラベルが表示されないのはなぜですか？**

まずラベルの `[IDataLabelFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/)` オブジェクトで必要なフィールドを有効にします。その後、セグメントに十分なスペースがあるかを確認します。Treemap の親ラベルレイアウト、チャート サイズ、ラベル長、フォント サイズ、そして有効化されたフィールド数がラベル表示の可否に影響します。

**セグメントの正確な順序や座標を指定できますか？**

ソース行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウト エンジンが階層、値、利用可能スペースから自動的に計算します。

**プレゼンテーションのテーマが変更された後に色が変わるのはなぜですか？**

テーマ ベースの塗りはプレゼンテーション パレットに従うよう設計されています。固定したままにしたいレベルには明示的な RGB カラーを適用するか、新しいテーマに合わせてスキームカラーを使用してください。

**PDF や画像へのエクスポートでカスタム書式設定は保持されますか？**

はい、サポートされたチャートの塗りとラベル設定はレンダリング時に含まれます。システム間で一貫した結果を得るには、必要なフォントを用意し、ラベルのフィットはレイアウトに依存するため最終エクスポート サイズでテストしてください。

## **関連項目**

- [Create Treemap charts](/slides/ja/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ja/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ja/androidjava/export-chart/)
- [Manage presentation themes](/slides/ja/androidjava/presentation-theme/)