---
title: Treemap と Sunburst チャートのデータポイントを .NET でカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap チャート
- Sunburst チャート
- 階層チャート
- データポイント
- データラベル
- ブランチカラー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、階層データの作成と Treemap と Sunburst チャートのレベル、ラベル、カラーをカスタマイズする方法を学びます。"
---
## **概要**

Treemap と Sunburst のチャートは同じ階層データを表示しますが、レイアウトが異なります。Treemap は階層をネストされた矩形で描画し、矩形の面積が葉の値を表します。Sunburst は同心円状のリングで描画し、トップレベルのグループが中心付近に、葉のカテゴリが外側のリングに配置されます。

Aspose.Slides for .NET では、各数値は [IChartDataPoint](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/) です。その [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) コレクションで葉と親グループにアクセスできます。この記事ではそのマッピングを解説し、同じサンプルデータから両方のチャートタイプを作成・書式設定する方法を示します。

![Consumer と Business の支店を示す Treemap チャート](treemap-hierarchy.png)

![同じ Consumer と Business の階層を示す Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、レベルの理解**

以下で使用するサンプルは、3 つのカテゴリレベルと 1 つの数値系列です。

| 支店 | 部門 | 項目 | 収益 |
| --- | --- | --- | ---: |
| 消費者 | コンピュータ | ノートパソコン | 12 |
| 消費者 | コンピュータ | デスクトップ | 8 |
| 消費者 | モバイル | 電話 | 15 |
| 消費者 | モバイル | タブレット | 6 |
| ビジネス | サービス | コンサルティング | 10 |
| ビジネス | サービス | サポート | 7 |
| ビジネス | ソフトウェア | ライセンス | 11 |
| ビジネス | ソフトウェア | サブスクリプション | 14 |

各行は 1 つの葉カテゴリと 1 つのデータポイントを作成します。カテゴリのグループ化レベルは、その葉から親までのパスを示します。最初の行の場合、パスは `Consumer > Computers > Laptops` です。

[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) のインデックスは葉から上方向に進みます。

| `DataPointLevels` index | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | 葉 | 値の矩形 | 外側リングのセグメント |
| `1` | ステム | 親矩形またはヘッダー | 中間リングのセグメント |
| `2` | 支店 | トップレベル矩形またはヘッダー | 内側リングのセグメント |

この順序は両方のチャートタイプで同じですが、視覚的レイアウトは異なります。親セグメントは複数の葉で共有されます。書式設定するには、そのグループ内の最初のデータポイントの対応レベルを使用します。例えば、`Consumer` 支店は `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`dataPoints[0]` や `dataPoints[6]` のような説明のない式を使うよりも、これらのポイントへの参照を保持した方が明確で安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全なサンプルは、1 枚目のスライドに Treemap、2 枚目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、支店ラベルを書式設定し、プレゼンテーションを保存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // 葉カテゴリーを追加します。グループ化項目は新しいグループが開始されたときにのみ設定されます;
    // 以下のカテゴリは別の項目が設定されるまでそのグループに留まります。
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // タブレットの葉にカテゴリと値を表示します。
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // そのブランチの最初の葉を介して Consumer ブランチを書式設定します。
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // そのステムの最初の葉を介して Software ステムを書式設定します。
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout は Treemap の親ラベルに影響します; Sunburst はリングセグメントを使用します。
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

カテゴリセルと値セルは同じワークシート行を使用するため、コレクション位置が揃ったままです。既存のチャートを操作する場合は、まずカテゴリ行を確認し、書式設定対象のデータポイントとレベルへの名前付き参照を保存してください。

## **動作と実務上の考慮事項**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を表現し、ネストされた矩形で階層を示します。[IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/parentlabellayout/) プロパティはこのチャートタイプで親ラベルの表示方法を制御します。
- Sunburst は角度で値を表現し、リングの深さで階層を示します。[IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartseries/parentlabellayout/) はリングラベルを制御しません。
- 両方のチャートタイプは同じカテゴリグループ化レベルと `DataPointLevels` の葉から親への順序を使用するため、データ構築とレベル書式設定のコードは共有できます。
- 親の値は子孫の葉から計算されます。支店やステム用に別個の数値ポイントを追加しないでください。

### **ソートとセグメント順序**

チャートレイアウトエンジンが矩形とリングセグメントの最終配置を決定します。関連するカテゴリ行をまとめてから追加してください。ただし、特定の矩形位置や開始角度に依存しないでください。順序が意味を持つ場合は、ラベルに含めるか、明示的なカテゴリ軸を持つチャートタイプを使用します。

### **テーマと固定カラー**

書式設定されていないチャートレベルはプレゼンテーションテーマから色を継承します。サンプルでは予測可能な出力のために明示的な RGB 塗りを使用しています。テーマ変更に追随させたい場合は、固定 RGB の代わりにスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。また、支店やステムの塗りを変更した後はラベルのコントラストも確認してください。

### **ラベルと利用可能スペース**

セグメントが小さすぎると PowerPoint がラベルを非表示にしたり切り詰めたりします。チャートサイズを大きくする、カテゴリ名を短くする、または表示するラベル項目を減らすことで、より明瞭な結果が得られます。ラベルは [IDataLabelFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/) を使ってカテゴリ名、シリーズ名、値を組み合わせられますが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX で保存するとチャートは編集可能なままです。Aspose.Slides がプレゼンテーションを PDF または画像にレンダリングする際、サポートされている塗りとラベル設定がチャートに反映されます。フォント置換や利用可能なレイアウト領域の差異により改行やラベルの表示が変わることがあるため、必要なフォントをインストールし、エクスポート先での表示を確認してください。

## **よくある質問**

**親レベルを変更すると複数の葉に影響するのはなぜですか？**

支店やステムは共有されるビジュアルセグメントです。その [IChartDataPointLevel](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatapointlevel/) は子孫の葉から取得できますが、書式設定はその共有親セグメント全体に適用され、個々の葉だけに限定されません。

**データラベルが欠落しているのはなぜですか？**

まずラベルの [IDataLabelFormat](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/idatalabelformat/) オブジェクトで必要なフィールドを有効にします。その上でセグメントに十分なスペースがあるか確認してください。Treemap の親ラベルレイアウト、チャートサイズ、ラベル長、フォントサイズ、使用フィールド数がラベル表示の可否に影響します。

**セグメントの正確な順序や座標を設定できますか？**

行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウトエンジンが階層、値、利用可能スペースから自動的に計算します。

**プレゼンテーションテーマが変更された後に色が変わるのはなぜですか？**

テーマベースの塗りはプレゼンテーションのパレットに従うよう設計されています。固定しておきたいレベルには明示的な RGB 色を適用するか、テーマ変更に追随させる場合はスキームカラーを使用してください。

**PDF や画像エクスポートでカスタム書式設定は保持されますか？**

はい、サポートされているチャートの塗りとラベル設定はレンダリング時に含まれます。システム間で結果を統一するには、必要なフォントを用意し、ラベルのフィットはレイアウト依存であるため最終エクスポートサイズでテストしてください。

## **関連項目**

- [Treemap チャートの作成](/slides/ja/net/create-chart/#create-tree-map-charts)
- [Sunburst チャートの作成](/slides/ja/net/create-chart/#create-sunburst-charts)
- [プレゼンテーションチャートのエクスポート](/slides/ja/net/export-chart/)
- [プレゼンテーションテーマの管理](/slides/ja/net/presentation-theme/)