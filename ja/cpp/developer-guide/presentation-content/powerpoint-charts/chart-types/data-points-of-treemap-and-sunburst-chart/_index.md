---
title: C++ での Treemap と Sunburst チャートのデータポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap チャート
- Sunburst チャート
- 階層チャート
- データポイント
- データラベル
- ブランチカラー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、Treemap と Sunburst チャートで階層データを作成し、レベル、ラベル、色をカスタマイズする方法を学びます。"
---
## **概要**

Treemap と Sunburst のチャートは同じ階層データを表示しますが、レイアウトが異なります。Treemap は階層を入れ子になった矩形で描画し、矩形の面積が葉の値を表します。Sunburst は同心円状のリングで描画し、トップレベルのグループが中心に近く、葉カテゴリが外側のリングに配置されます。

Aspose.Slides for C++ では、各数値は [IChartDataPoint](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapoint/) です。その [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) メソッドにより、葉とその親グループにアクセスできます。この記事ではそのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成および書式設定する方法を示します。

![Consumer と Business のブランチを持つ Treemap チャート](treemap-hierarchy.png)

![Consumer と Business のブランチを持つ Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、レベルの理解**

以下で使用するサンプルは 3 つのカテゴリレベルと 1 つの数値系列から構成されています。

| ブランチ | ステム | リーフ | 収益 |
| --- | --- | --- | ---: |
| コンシューマー | コンピュータ | ノートパソコン | 12 |
| コンシューマー | コンピュータ | デスクトップ | 8 |
| コンシューマー | モバイル | 携帯電話 | 15 |
| コンシューマー | モバイル | タブレット | 6 |
| ビジネス | サービス | コンサルティング | 10 |
| ビジネス | サービス | サポート | 7 |
| ビジネス | ソフトウェア | ライセンス | 11 |
| ビジネス | ソフトウェア | サブスクリプション | 14 |

各行は 1 つの葉カテゴリと 1 つのデータポイントを作成します。カテゴリのグルーピングレベルは、葉からその親までのパスを表します。最初の行のパスは `Consumer > Computers > Laptops` です。

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) が返すインデックスは葉から上方向に進みます。

| `get_DataPointLevels()` インデックス | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

この順序は両方のチャートタイプで同じですが、視覚的レイアウトは異なります。親セグメントは複数の葉で共有されます。書式設定するには、そのグループ内の最初のデータポイントの該当レベルを使用します。たとえば、`Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`dataPoints->idx_get(0)` や `dataPoints->idx_get(6)` のような説明のない式を使うよりも、これらのポイントへの参照を保持した方が明確で安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全な例は、1 枚目のスライドに Treemap、2 枚目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチ ラベルを書式設定し、プレゼンテーションを保存します。

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // 葉カテゴリを追加します。グルーピング項目は新しいグループが始まったときにのみ設定されます;
    // 以下のカテゴリは別の項目が設定されるまでそのグループに残ります。
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // タブレット葉にカテゴリと値を表示します。
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // そのブランチの最初の葉を通じて Consumer ブランチを書式設定します。
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // そのステムの最初の葉を通じて Software ステムを書式設定します。
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout は Treemap の親ラベルに影響し、Sunburst はリング セグメントを使用します。
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

カテゴリ セルと値セルは同じワークシート行を使用するため、コレクション位置が揃ったままになります。既存のチャートを操作する場合は、まずカテゴリ行を確認し、書式設定したいデータポイントとレベルへの名前付き参照を保存してください。

## **動作と実用的な考慮事項**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を示し、入れ子の矩形で階層を示します。`[IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/)` メソッドでこのチャートタイプの親ラベルの表示方法を制御します。
- Sunburst は角度で値を示し、リングの深さで階層を示します。`[IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/)` はリング ラベルを制御しません。
- 両方のチャートタイプは同じカテゴリグルーピングレベルと、`[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/)` が返す葉から親への順序を使用するため、データ構築およびレベル書式設定のコードを共有できます。
- 親の値は子孫の葉から計算されます。ブランチやステム用に別個の数値ポイントを追加しないでください。

### **ソートとセグメントの順序**

チャートのレイアウト エンジンが矩形やリング セグメントの最終配置を決定します。追加する前に関連するカテゴリ行を一緒に並べておくとよいですが、特定の矩形位置や開始角度に依存しないでください。順序が意味を持つ場合はラベルに含めるか、明示的なカテゴリ軸を持つチャート タイプを使用してください。

### **テーマと固定色**

書式設定されていないチャートレベルはプレゼンテーションのテーマから色を継承します。例では予測可能な出力のために明示的な RGB 塗りつぶしを使用しています。テーマ変更に追随させたい場合は固定 RGB の代わりにスキームカラーを使用し、すべてのレベルを書き換えるのは避けてください。また、ブランチやステムの塗りつぶしを変更した後はラベルのコントラストも確認してください。

### **ラベルと利用可能なスペース**

セグメントが小さすぎると PowerPoint はラベルを非表示にしたり切り詰めたりします。チャートサイズを大きくしたり、カテゴリ名を短くしたり、表示するラベル項目を減らすと、より明瞭な結果が得られます。`[IDataLabelFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatalabelformat/)` を使用してカテゴリ名、シリーズ名、値を組み合わせることはできますが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX に保存するとチャートは編集可能なままです。Aspose.Slides がプレゼンテーションを PDF や画像にレンダリングする際、サポートされている塗りつぶしとラベル設定がチャートに反映されます。フォントの置き換えや利用可能なレイアウトスペースの差異により改行やラベルの可視性が変わることがあるため、必要なフォントをインストールし、重要なエクスポート先での表示を検証してください。

## **FAQ**

**なぜ親レベルを変更すると複数の葉に影響するのですか？**

ブランチやステムは共有されたビジュアル セグメントです。その `[IChartDataPointLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/ichartdatapointlevel/)` は子孫の葉から到達できますが、書式設定はその共有された親セグメント全体に適用されます。

**なぜデータラベルが欠落しているのですか？**

まずラベルの `[IDataLabelFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/idatalabelformat/)` オブジェクトで必要な項目を有効にします。その後、セグメントに十分なスペースがあるか確認してください。Treemap の親ラベルレイアウト、チャートのサイズ、ラベル長、フォントサイズ、そして有効にした項目数がラベル表示に影響します。

**セグメントの正確な順序や座標を設定できますか？**

ソース行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウト エンジンが階層、値、利用可能スペースから計算します。

**プレゼンテーションのテーマが変わると色が変わるのはなぜですか？**

テーマベースの塗りつぶしはプレゼンテーションのカラーパレットに従うよう設計されています。固定しておきたいレベルには明示的な RGB 色を適用するか、テーマ変更に合わせてスキームカラーを使用してください。

**PDF や画像エクスポートでカスタム書式設定は保持されますか？**

はい、サポートされているチャートの塗りつぶしとラベル設定はレンダリング時に含まれます。システム間で一貫した結果を得るには、必要なフォントを用意し、ラベルのフィッティングはレイアウトに依存するため最終エクスポートサイズでテストしてください。

## **関連項目**

- [Treemap チャートの作成](/slides/ja/cpp/create-chart/#create-tree-map-charts)
- [Sunburst チャートの作成](/slides/ja/cpp/create-chart/#create-sunburst-charts)
- [プレゼンテーションのチャートのエクスポート](/slides/ja/cpp/export-chart/)
- [プレゼンテーションテーマの管理](/slides/ja/cpp/presentation-theme/)