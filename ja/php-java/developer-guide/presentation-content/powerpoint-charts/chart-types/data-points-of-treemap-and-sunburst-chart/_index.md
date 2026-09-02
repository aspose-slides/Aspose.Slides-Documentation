---
title: PHPでTreemapとSunburstチャートのデータポイントをカスタマイズ
linktitle: TreemapとSunburstチャートのデータポイント
type: docs
url: /ja/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、階層データの作成と Treemap と Sunburst チャートのレベル、ラベル、色のカスタマイズ方法を学びます。"
---
## **概要**

Treemap と Sunburst チャートは同じ階層データを表示しますが、レイアウトが異なります。Treemap は階層をネストされた矩形で描画し、その面積がリーフの値を表します。Sunburst は同心円状のリングで描画し、上位レベルのグループは中心に近く、リーフカテゴリは外側のリングに配置されます。

Aspose.Slides for PHP via Java では、各数値は [ChartDataPoint](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/) です。その [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) メソッドはリーフとその親グループへのアクセスを提供します。本記事ではそのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成および書式設定する方法を示します。

![Consumer と Business のブランチを含む Treemap チャート](treemap-hierarchy.png)

![同じ Consumer と Business 階層を持つ Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、およびレベルの理解**

以下で使用するサンプルは 3 つのカテゴリレベルと 1 つの数値系列を持ちます:

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

各行は 1 つのリーフカテゴリと 1 つのデータポイントを作成します。カテゴリのグループ化レベルはそのリーフから親へ向かうパスを示します。最初の行の場合、パスは `Consumer > Computers > Laptops` です。

[ChartDataPoint.getDataPointLevels] が返すインデックスはリーフから上方向へ進みます:

| `getDataPointLevels()` インデックス | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | リーフ | Value rectangle | Outer-ring segment |
| `1` | ステム | Parent rectangle or header | Middle-ring segment |
| `2` | ブランチ | Top-level rectangle or header | Inner-ring segment |

この順序は両方のチャートタイプで同じですが、視覚レイアウトは異なります。親セグメントは複数のリーフで共有されます。書式設定するには、そのグループ内の最初のデータポイントの対応レベルを使用します。たとえば `Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`$dataPoints->get_Item(0)` や `$dataPoints->get_Item(6)` のような説明のない式を使用するよりも、これらのポイントへの参照を保持した方が明確で安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全なサンプルは、最初のスライドに Treemap、2 番目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチラベルを書式設定し、プレゼンテーションを保存します。

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // リーフカテゴリを追加します。新しいグループが始まるときにのみグルーピング項目が設定されます;
        // 後続のカテゴリは別の項目が設定されるまでそのグループに残ります。
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Tablets リーフにカテゴリと値を表示します。
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Consumer ブランチを、そのブランチ内の最初のリーフを通じて書式設定します。
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Software ステムを、そのステム内の最初のリーフを通じて書式設定します。
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout は Treemap の親ラベルに影響します; Sunburst はリングセグメントを使用します。
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

カテゴリセルと値セルは同じワークシート行を使用するため、コレクション位置は揃ったままになります。既存のチャートを操作する場合は、最初にカテゴリ行を確認し、書式設定対象のデータポイントとレベルへの名前付き参照を保存してください。

## **動作と実務的な考慮事項**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を、ネストされた矩形で階層を表現します。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setParentLabelLayout)` メソッドはこのチャートタイプで親ラベルの表示方法を制御します。
- Sunburst は角度で値を、リングの深さで階層を表現します。`[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setParentLabelLayout)` はリングラベルを制御しません。
- 両方のチャートタイプは同じカテゴリグループ化レベルと、[ChartDataPoint.getDataPointLevels] が返すリーフから親への順序を使用するため、データ構築およびレベル書式設定コードを共有できます。
- 親の値は子リーフから計算されます。ブランチやステム用に別個の数値ポイントを追加しないでください。

### **並び替えとセグメント順序**

チャートのレイアウトエンジンが矩形やリングセグメントの最終配置を決定します。関連するカテゴリ行をまとめてから追加してください。ただし、特定の矩形位置や開始角度に依存しないでください。順序が意味を持つ場合はラベルに含めるか、明示的なカテゴリ軸を持つチャートタイプを使用します。

### **テーマと固定色**

書式設定されていないチャートレベルはプレゼンテーションテーマから色を継承します。例では予測可能な出力のために明示的な RGB 塗りを使用しています。テーマの変更に追従させる場合はスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。また、ブランチやステムの塗りを変更した後はラベルのコントラストも確認してください。

### **ラベルと利用可能なスペース**

セグメントが小さすぎると PowerPoint がラベルを非表示または切り詰めることがあります。チャートサイズを大きくする、カテゴリ名を短くする、表示するラベル項目を減らすなどで、より明確な結果が得られます。`[DataLabelFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/)` を使用してカテゴリ名、系列名、値を組み合わせることは可能ですが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX で保存するとチャートは編集可能な状態で保持されます。Aspose.Slides がプレゼンテーションを PDF や画像にレンダリングする際、サポートされている塗りとラベル設定がチャートに反映されます。フォントの置き換えや利用可能なレイアウトスペースの差異により改行やラベル表示が変わることがあるため、必要なフォントをインストールし、重要なエクスポート先での確認を行ってください。

## **FAQ**

**なぜ親レベルを変更すると複数のリーフに影響が及ぶのですか？**

ブランチまたはステムは共有されるビジュアルセグメントです。その `[ChartDataPointLevel](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapointlevel/)` は子リーフから取得できますが、書式設定はその共有親セグメント全体に適用されます。

**データラベルが欠落しているのはなぜですか？**

まずラベルの `[DataLabelFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/)` オブジェクトで必要なフィールドを有効にします。その後、セグメントに十分なスペースがあるか確認してください。Treemap の親ラベルレイアウト、チャートのサイズ、ラベル長、フォントサイズ、有効フィールド数がラベル表示に影響します。

**セグメントの正確な順序や座標を指定できますか？**

行の順序を制御し、各グループを連続させることはできますが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウトエンジンが階層、値、利用可能スペースに基づいて計算します。

**プレゼンテーションテーマを変更すると色が変わるのはなぜですか？**

テーマベースの塗りはプレゼンテーションのパレットに従うよう設計されています。固定したいレベルには明示的な RGB 色を設定するか、テーマ変更に追従させる場合はスキームカラーを使用してください。

**PDF や画像へのエクスポート時にカスタム書式は保持されますか？**

はい、サポートされているチャートの塗りとラベル設定はレンダリング時に含まれます。システム間で一貫した結果を得るために必要なフォントを用意し、ラベルのフィッティングはレイアウトに依存するため最終エクスポートサイズでテストしてください。

## **関連項目**

- [Treemap チャートの作成](/slides/ja/php-java/create-chart/#create-tree-map-charts)
- [Sunburst チャートの作成](/slides/ja/php-java/create-chart/#create-sunburst-charts)
- [プレゼンテーションチャートのエクスポート](/slides/ja/php-java/export-chart/)
- [プレゼンテーションテーマの管理](/slides/ja/php-java/presentation-theme/)