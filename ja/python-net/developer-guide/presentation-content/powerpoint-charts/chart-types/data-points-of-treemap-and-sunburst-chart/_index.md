---
title: PythonでTreemapおよびSunburstチャートのデータポイントをカスタマイズする
linktitle: TreemapとSunburstチャートのデータポイント
type: docs
url: /ja/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemapチャート
- Sunburstチャート
- 階層チャート
- データポイント
- データラベル
- ブランチカラー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、Treemap と Sunburst チャートで階層データを作成し、レベル、ラベル、カラーをカスタマイズする方法を学びます。"
---
## **概要**

Treemap と Sunburst のチャートは同じタイプの階層データを表示しますが、レイアウトが異なります。Treemap は階層を入れ子の矩形で表し、矩形の面積がリーフ値を表します。Sunburst は同心円状のリングで表し、最上位のグループが中心付近に配置され、リーフカテゴリは外側のリングに配置されます。

Aspose.Slides for Python via .NET では、各数値は [ChartDataPoint](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/) です。その [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) コレクションを使用すると、リーフとその親グループにアクセスできます。本稿ではこのマッピングを説明し、同じサンプルデータから両方のチャートタイプを作成および書式設定する方法を示します。

![Consumer と Business のブランチを持つ Treemap チャート](treemap-hierarchy.png)

![同じ Consumer と Business の階層を持つ Sunburst チャート](sunburst-hierarchy.png)

## **カテゴリ、データポイント、レベルの理解**

以下で使用するサンプルは、3 つのカテゴリレベルと 1 つの数値系列を持ちます。

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

各行は 1 つのリーフカテゴリと 1 つのデータポイントを作成します。カテゴリのグループ化レベルは、そのリーフから親までのパスを表します。1 行目のパスは `Consumer > Computers > Laptops` です。

[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) のインデックスはリーフから上方向に進みます。

| `data_point_levels` index | 論理レベル | Treemap 表現 | Sunburst 表現 |
| ---: | --- | --- | --- |
| `0` | リーフ | 値矩形 | 外側リングセグメント |
| `1` | ステム | 親矩形またはヘッダー | 中間リングセグメント |
| `2` | ブランチ | 最上位矩形またはヘッダー | 内側リングセグメント |

この順序は、視覚的レイアウトは異なりますが、両方のチャートタイプで同じです。親セグメントは複数のリーフで共有されます。書式設定するには、そのグループ内の最初のデータポイントの対応するレベルを使用します。例えば、`Consumer` ブランチは `Laptops` ポイントから始まり、`Software` ステムは `Licenses` ポイントから始まります。`data_points[0]` や `data_points[6]` のような説明のない式を使用するよりも、これらのポイントへの参照を保持する方が分かりやすく安全です。

## **両方のチャートタイプの作成とカスタマイズ**

以下の完全な例は、最初のスライドに Treemap、2 番目のスライドに Sunburst を作成します。階層を構築し、`Tablets` の値を表示し、選択したレベルに固定色を適用し、ブランチラベルをフォーマットし、プレゼンテーションを保存します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # リーフカテゴリを追加します。新しいグループが開始されるときにのみグルーピング項目が設定され、以降のカテゴリは別の項目が設定されるまでそのグループに残ります。
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Tablets リーフにカテゴリと値を表示します。
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # そのブランチの最初のリーフを介して Consumer ブランチをフォーマットします。
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # そのステムの最初のリーフを介して Software ステムをフォーマットします。
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout は Treemap の親ラベルに影響し、Sunburst はリングセグメントを使用します。
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

カテゴリセルと値セルは同じワークシート行を使用するため、コレクション内の位置は揃ったままです。既存のチャートを操作する場合は、まずカテゴリ行を確認し、書式設定するデータポイントとレベルへの名前付き参照を保存します。

## **動作と実用的な考慮事項**

### **Treemap と Sunburst の違い**

- Treemap は面積で値を表し、入れ子の矩形で階層を表現します。[ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/parent_label_layout/) プロパティは、このチャートタイプにおける親ラベルの表示方法を制御します。
- Sunburst は角度で値を表し、リングの深さで階層を表現します。[ChartSeries.parent_label_layout](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/parent_label_layout/) はリングラベルを制御しません。
- 両方のチャートタイプは同じカテゴリのグループ化レベルと `data_point_levels` におけるリーフから親への順序を使用するため、データ構築およびレベルの書式設定コードを共有できます。
- 親の値は子孫リーフから計算されます。ブランチやステム用に別個の数値ポイントを追加しないでください。

### **ソートとセグメント順序**

チャートのレイアウトエンジンが矩形とリングセグメントの最終位置を決定します。関連するカテゴリ行をまとめてから追加してください。ただし、特定の矩形位置や開始角度に依存しないでください。順序に意味がある場合は、ラベルに含めるか、明示的なカテゴリ軸を持つチャートタイプを使用してください。

### **テーマと固定色**

書式設定されていないチャートレベルはプレゼンテーションのテーマから色を継承します。例では予測可能な出力のために明示的な RGB 塗りつぶしを使用しています。チャートをテーマ変更に追従させる場合は、固定の RGB 値ではなくスキームカラーを使用し、すべてのレベルを上書きしないようにしてください。ブランチやステムの塗りつぶしを変更した後は、ラベルのコントラストも確認してください。

### **ラベルと利用可能スペース**

PowerPoint はセグメントが小さすぎる場合、ラベルを非表示にしたり切り詰めたりすることがあります。チャートサイズを大きくしたり、カテゴリ名を短くしたり、表示するラベル項目を減らすことで、通常はより分かりやすい結果になります。ラベルは [DataLabelFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabelformat/) を使用してカテゴリ名、系列名、値を組み合わせることができますが、すべての項目を有効にすると階層チャートの可読性が低下することがあります。

### **エクスポートとレンダリング**

PPTX として保存すると、チャートは編集可能なままです。Aspose.Slides がプレゼンテーションを PDF または画像にレンダリングする際、サポートされている塗りつぶしとラベル設定がチャートとともに描画されます。フォントの置き換えや利用可能なレイアウトスペースのわずかな違いが改行やラベルの表示に影響することがあるため、必要なフォントをインストールし、重要なエクスポート先を確認してください。

## **FAQ**

**親レベルを変更すると複数のリーフに影響するのはなぜですか？**

ブランチやステムは共有された視覚セグメントです。その [ChartDataPointLevel](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointlevel/) は子孫リーフを通じて取得できますが、書式設定はそのリーフだけでなく、共有された親セグメントに適用されます。

**データラベルが欠落しているのはなぜですか？**

まず、ラベルの [DataLabelFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabelformat/) オブジェクトで必要な項目を有効にします。その後、セグメントに十分なスペースがあるか確認してください。Treemap の親ラベルレイアウト、チャートのサイズ、ラベルの長さ、フォントサイズ、そして有効にした項目数が、ラベルの表示可否に影響します。

**セグメントの正確な順序や座標を設定できますか？**

ソース行の順序を制御し、各グループを連続させることは可能ですが、Treemap の矩形や Sunburst の角度を正確に指定することはできません。チャートのレイアウトエンジンは階層、値、利用可能なスペースから計算します。

**プレゼンテーションのテーマを変更した後、色が変わるのはなぜですか？**

テーマベースの塗りつぶしはプレゼンテーションのパレットに従うよう設計されています。固定したままにすべきレベルには明示的な RGB 色を適用するか、新しいテーマに適応する場合はスキームカラーを使用してください。

**カスタム書式設定は PDF や画像エクスポートで保持されますか？**

はい、レンダリング時にサポートされているチャートの塗りつぶしとラベル設定は保持されます。システム間で一貫した結果を得るために、必要なフォントを利用可能にし、ラベルのフィットはレイアウトに依存するため、最終的なエクスポートサイズをテストしてください。

## **参照**

- [Treemap チャートの作成](/slides/ja/python-net/create-chart/#create-tree-map-charts)
- [Sunburst チャートの作成](/slides/ja/python-net/create-chart/#create-sunburst-charts)
- [プレゼンテーションチャートのエクスポート](/slides/ja/python-net/export-chart/)
- [プレゼンテーションテーマの管理](/slides/ja/python-net/presentation-theme/)