---
title: Python で Treemap と Sunburst チャートのデータポイントをカスタマイズする
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/python-java/data-points-of-treemap-and-sunburst-chart/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、階層データの作成と Treemap および Sunburst チャートのレベル、ラベル、色のカスタマイズ方法を学びます。"
---
## **概要**

Treemap と Sunburst チャートは同じ種類の階層データを表示しますが、レイアウトが異なります。Treemap は階層を入れ子になった矩形で描画し、矩形の面積がリーフの値を表します。Sunburst は同心円状のリングで描画し、最上位のグループが中心に近く、リーフカテゴリが外側のリングに配置されます。

Aspose.Slides for Python via Java では、各数値は [ChartDataPoint](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/) です。その [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) メソッドでリーフと親グループにアクセスできます。本記事ではそのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成・書式設定する方法を示します。

![Consumer と Business ブランチを含む Treemap チャート](treemap-hierarchy.png)

![同じ Consumer と Business 階層を含む Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、レベルの理解**

以下のサンプルは 3 つのカテゴリレベルと 1 つの数値系列から構成されています。

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

各行は 1 つのリーフカテゴリと 1 つのデータポイントを作成します。カテゴリのグループ化レベルは、そのリーフから親へたどるパスを表します。最初の行の場合、パスは `Consumer > Computers > Laptops` です。

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) が返すインデックスはリーフから上向きです。

| `getDataPointLevels()` インデックス | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | リーフ | 値の矩形 | 外側リングのセグメント |
| `1` | ステム | 親矩形またはヘッダー | 中間リングのセグメント |
| `2` | ブランチ | 最上位矩形またはヘッダー | 内側リングのセグメント |

この順序は両方のチャートタイプで同じですが、視覚的レイアウトは異なります。親セグメントは複数のリーフで共有されます。書式設定するには、そのグループ内の最初のデータポイントの対応レベルを使用します。たとえば `Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`data_points.get_Item(0)` や `data_points.get_Item(6)` のような説明のない式を使用するよりも、これらのポイントへの参照を保持する方が明確で安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全なサンプルは、1 枚目のスライドに Treemap、2 枚目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチラベルを書式設定し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # リーフカテゴリを追加します。新しいグループが開始されたときにのみグループ項目が設定され、以降のカテゴリは別の項目が設定されるまでそのグループに属します。
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Tablets のリーフにカテゴリと値を表示します。
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Consumer ブランチを、そのブランチ内の最初のリーフを通じて書式設定します。
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Software ステムを、そのステム内の最初のリーフを通じて書式設定します。
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout は Treemap の親ラベルに影響します。Sunburst はリングセグメントを使用します。
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

カテゴリセルと値セルは同じワークシート行を使用するため、コレクション位置が一致したままです。既存のチャートを操作する場合は、最初にカテゴリ行を確認し、書式設定したいデータポイントとレベルへの名前付き参照を保存してください。

## **動作と実用的考慮点**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を示し、入れ子矩形で階層を示します。`ChartSeries.setParentLabelLayout` メソッドはこのチャートタイプで親ラベルの表示方法を制御します。  
- Sunburst は角度で値を示し、リングの深さで階層を示します。`ChartSeries.setParentLabelLayout` はリングラベルには影響しません。  
- 両チャートタイプは同じカテゴリグループ化レベルと、`ChartDataPoint.getDataPointLevels` が返すリーフ→親の順序を使用するため、データ構築とレベル書式設定コードを共有できます。  
- 親の値は下位リーフから計算されます。ブランチやステムに別個の数値ポイントを追加しないでください。

### **ソートとセグメント順序**

チャートレイアウトエンジンが矩形やリングセグメントの最終配置を決定します。追加前に関連するカテゴリ行をまとめておくとよいですが、特定の矩形位置や開始角度に依存しないでください。順序に意味がある場合はラベルに組み込むか、明示的なカテゴリ軸を持つチャートタイプを使用します。

### **テーマと固定色**

書式設定されていないチャートレベルはプレゼンテーションのテーマから色を継承します。例では予測可能な出力のために明示的な RGB 塗りつぶしを使用しています。テーマ変更に追従させたい場合は固定 RGB の代わりにスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。また、ブランチやステムの塗りつぶしを変更した後はラベルのコントラストも確認してください。

### **ラベルと利用可能スペース**

セグメントが小さすぎると PowerPoint はラベルを非表示または切り詰めることがあります。チャートサイズを大きくする、カテゴリ名を短くする、表示するラベル項目を減らすと、結果がクリアになります。`DataLabelFormat` を使用してカテゴリ名、系列名、値を組み合わせることは可能ですが、すべての項目を有効にすると階層チャートの可読性が低下しがちです。

### **エクスポートとレンダリング**

PPTX で保存するとチャートは編集可能なままです。Aspose.Slides がプレゼンテーションを PDF や画像にレンダリングする際、サポートされている塗りつぶしとラベル設定がチャートに反映されます。フォントの置き換えや利用可能レイアウトスペースの差異により改行やラベル表示が変わることがあるため、必要なフォントをインストールし、重要なエクスポート先での結果を検証してください。

## **FAQ**

**なぜ親レベルを変更すると複数のリーフに影響するのですか？**

ブランチやステムは共有されるビジュアルセグメントです。その `[ChartDataPointLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointlevel/)` は子孫リーフから取得できますが、書式設定は共有された親セグメント全体に適用されます。

**データラベルが表示されないのはなぜですか？**

まずラベルの `[DataLabelFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/)` オブジェクトで必要なフィールドを有効にしてください。その後、セグメントに十分な空間があるか確認します。Treemap の親ラベルレイアウト、チャートサイズ、ラベル長、フォントサイズ、そして有効フィールド数がラベル表示可否に影響します。

**セグメントの正確な順序や座標を指定できますか？**

ソース行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。レイアウトエンジンが階層・値・利用可能スペースから計算します。

**テーマ変更後に色が変わるのはなぜですか？**

テーマベースの塗りつぶしはプレゼンテーションのパレットに従うよう設計されています。固定したいレベルには明示的な RGB 色を適用するか、新しいテーマに合わせてスキームカラーを使用してください。

**PDF や画像エクスポートでカスタム書式は保持されますか？**

はい、サポートされているチャートの塗りつぶしとラベル設定はレンダリング時に含まれます。システム間で一貫した結果を得るには必要なフォントを用意し、ラベルのフィットはレイアウト依存であるため最終エクスポートサイズをテストしてください。

## **See Also**

- [Create Treemap charts](/slides/ja/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/ja/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/ja/python-java/export-chart/)
- [Manage presentation themes](/slides/ja/python-java/presentation-theme/)