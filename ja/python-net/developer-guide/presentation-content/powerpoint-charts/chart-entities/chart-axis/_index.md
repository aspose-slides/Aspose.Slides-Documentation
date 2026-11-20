---
title: Python を使用したプレゼンテーションのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-net/chart-axis/
keywords:
- チャート軸
- 縦軸
- 横軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、レポートや可視化のための PowerPoint および OpenDocument プレゼンテーションでチャート軸をカスタマイズする方法を学びましょう。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて取り上げます。

## **チャートの縦軸で最大値を取得する**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、デフォルト データでエリアチャートを追加します。計算された軸の値を読む前に、チャート レイアウトが最新になるように [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) を呼び出します。

軸の限界を取得するには [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) と [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) を読み取り、目盛り間隔は [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) と [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) を使用します。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) と [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) は時間単位のスケールを提供し、日付軸に関連します。例では、これらの値をローカル変数に保存し、チャートを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **軸間のデータを入れ替える**

[swap_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) を使用して、チャート データで系列とカテゴリの役割を入れ替えます。以前のカテゴリは系列になり、以前の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。例では、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替える前に設定します。4 系列と 3 カテゴリを持つチャートを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **軸のプロット順序を逆にする**

[is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) を使用してカテゴリ軸または値軸の順序を逆にします。たとえば、水平棒グラフでプロジェクトの段階をワークシートと同じ順序（Planning、Development、Testing）で上から下へ表示できます。軸を逆にするとプロット方向が変わりますが、ワークブック データの並び替えや再配置は行われません。比較すると、[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) は系列とカテゴリの役割を入れ替えます。

以下の例は、3 つの段階と 1 系列の水平棒グラフを作成します。通常順序、カテゴリ逆順、値逆順の 3 スライドを含むプレゼンテーションを保存します。各コピーは同じデータセットを使用し、各コピーで 1 つの軸のみが逆に設定されています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # スライド 2: 最初のカテゴリを上部に表示。
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 水平値軸を下部に保持。
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # スライド 3: 水平数値スケールのみを逆にする。
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

軸を逆にすると、垂直軸をプロットの反対側に移動できることもあります。[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) は、他の軸が設定対象の軸と交差する位置を制御します。スライド 2 では、逆順のカテゴリ軸で `MAXIMUM` に設定すると、水平値軸が下部に保持されます。特定の交差点を指定する場合は [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) を使用します。方向を変更する際は交差設定を確認してください。特にチャートにカスタム交差点が設定されている場合は注意が必要です。`is_plot_order_reversed` を `False` に戻すと通常のプロット方向に復元されます。交差設定は別個です。

| 通常順序（スライド 1） | カテゴリ逆順（スライド 2） | 値逆順（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸順序の水平棒グラフ](axis-order-normal.png) | ![カテゴリが上から下へ表示される水平棒グラフ](axis-order-categories-reversed.png) | ![値軸が逆順で右側がゼロの水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | Planning、Development、Testing が上から下へ表示されます。値とワークブックの行順は変更されません。 | カテゴリは通常順序のままで、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

垂直軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。例ではデフォルト データで折れ線グラフを作成し、縦軸を非表示にした状態で保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの横軸を非表示にする**

水平軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。例ではデフォルト データで折れ線グラフを作成し、水平軸を非表示にした状態で保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートのグリッド線を表示または非表示にする**

[show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) と [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) を読み取って、軸が表示しているグリッド線を確認します。両プロパティは読み取り専用です。マイナー グリッド線を表示するには、[minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) の線の塗りを実線に設定し、可視色を選択します。非表示にするには塗りタイプを `FillType.NO_FILL` に設定します。メジャー グリッド線については、[major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format` を使用します。塗りを変更しても軸の表示や目盛りは保持されます。

このクラスター化縦棒グラフの垂直軸は、メジャー グリッド線が表示され、マイナー グリッド線が非表示の状態で開始します。例ではまずマイナー グリッド線をオレンジ色で表示し、保存前に再び非表示にします。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| マイナー グリッド線 有効 | マイナー グリッド線 非表示 |
| --- | --- |
| ![縦軸の主要グリッド線間にあるオレンジ色のマイングリッド線](minor-gridlines-enabled.png) | ![主要グリッド線のみが表示された同じ縦棒グラフ](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を設定して、日付軸またはテキスト軸を選択します。この例では `ExistingChart.pptx` が必要です。最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリ セルには数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) を `False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) を `1`、[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) を months に設定すると、メジャー 目盛りが 1 か月ごとに配置されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

### **データからカテゴリ軸の種類を決定する**

カテゴリを設定した後に [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) を呼び出し、続いて [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を読み取って選択結果を確認します。テキスト ラベルまたは数値の日付が入力されるチャートに便利です。このメソッドは呼び出し時点でタイプを決定し、後からデータが変化しても自動的に再評価される持続モードはありません。カテゴリを置き換えた後に再度呼び出してください。

以下の例はテキスト カテゴリのチャートを作成し、`TEXT` と出力します。その後、カテゴリ セルの値を日付に置き換えてメソッドを再度呼び出すと `DATE` と出力します。日付は数値の OLE Automation シリアル値として格納され、ここでは 1899 年 12 月 30 日からの日数として計算されます。表示形式は [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) が制御し、テキストを数値の日付に変換するわけではありません。カテゴリ セルの詳細については [チャート ワークブック](/slides/ja/python-net/chart-workbook/) を参照してください。

入力がテキスト カテゴリか数値日付か既知の場合は自動判定を使用します。普通の数値ラベル、混合カテゴリ、空データの場合は、意図した意味に合わせて明示的に [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を設定してください。数値だけではカテゴリが日付であることは判断できません。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # テキスト

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 日付

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数あるチャートでは、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) を `False` にし、[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) に希望のカテゴリ間隔を設定します。テキスト カテゴリが通常順序の場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔 `3` は 3 番目ごとのラベルのみ表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を決定しますが、必ずしもすべてのラベルを表示するわけではありません。

目盛りは別個に制御できます。[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) を `False` にし、[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) で間隔を設定します。たとえば `1` はラベルが 3 番目ごとに表示されても、すべてのカテゴリ間隔に目盛りを配置します。[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を可視スタイルに設定すると結果が確認できます。自動間隔プロパティを `True` に戻すと、チャートが再び自動で間隔を選択します。

以下のセルフコンテインド例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔を手動で設定し目盛りは独立、そして自動間隔に復元。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベルテキストが密度の違いを見やすくします。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # スライド 2: 3 つごとにラベルを表示し、各カテゴリに目盛りは残す。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # スライド 3: チャートに両方の間隔を再び自動選択させる。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自動間隔（スライド 1）:** このレンダリングでは、2 番目のカテゴリ ラベルが表示され、2 行に折り返されます。自動結果はチャート サイズ、フォント、レンダラにより変わります。

![自動間隔で 24 列すべてが表示されたカテゴリ ラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目のラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含めて 24 列すべてが同じ値で表示されます。スライド 3 は自動表示に戻ります。

![手動で間隔 3 に設定し 24 列すべてが表示されたカテゴリ ラベル間隔](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ カウント間隔を使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) に適用してください。目盛り間隔は、系列軸を持つチャートの系列軸にも適用できます。

カテゴリ ラベル間隔を値軸の数値スケール設定に使用しないでください。値軸では [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) が値の差を指定します（例：`10` のメジャー ユニットは 0、10、20…）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキスト カテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#カテゴリ軸を変更する) で説明した時間ベースのメジャー ユニットとスケールを使用してください。

## **カテゴリ軸の値の日時形式を設定する**

例ではデフォルトのチャート データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation シリアル番号として格納されます。[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を日付軸に設定し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) を無効にし、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) に `yyyy` を割り当てて、セルの書式設定に関係なくカテゴリ ラベルが 4 桁の年だけ表示されるようにします。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート軸タイトルの回転角度を設定する**

垂直軸の [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) を有効にし、タイトル テキストを設定し、[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) でタイトルを回転させます。角度は度数で測定され、例では値軸タイトルを 90 度回転させた柱状グラフを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸または値軸の位置を設定する**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) を使用して、値軸がカテゴリ軸の間（カテゴリ間）またはカテゴリ目盛り位置で交差するかを制御します。このプロパティはカテゴリ軸に適用されます。例では柱状グラフの水平カテゴリ軸に `True` を設定し、結果を保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート値軸に表示単位を設定する**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) を設定して、基になるデータを変更せずに値軸のラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) を `MILLIONS` に設定すると、60,000,000 の値が 60 と表示されます。例では柱状グラフを作成し、垂直軸にミリオン表示単位を適用します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **対数値軸を構成する**

正の値が数桁にわたって広がる場合、対数値軸が便利です。たとえば、あるサービスが 5 つの期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取るとします。線形スケールでは小さい値がゼロ付近に集中して見にくくなります。対数スケールでは相対的な成長が比較しやすくなり、等距離が等比率を表します。

値軸の [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) を `True` に設定し、[log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは追加されません。トレンドラインはデータのフィット関係を表す別機能です。

### **値軸と基数を選択する**

折れ線グラフや柱状グラフでは値軸は [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) です。水平棒グラフの場合は [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) が値軸になります。散布図やバブルチャートは 2 つの値軸を持つため、X 値は水平軸、Y 値は垂直軸、または両方を選択してください。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（包括）までの基数が使用でき、`2.5` のような小数基数もサポートされます。基数 `10` の場合、10、100、1,000、10,000 などの連続したべき乗が等間隔になります。

### **線形と対数スケーリングを比較する**

以下のセルフコンテインド例は、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 枚目で基数 10 の対数値軸を有効にします。両方のスライドは同じデータを保持します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 最初のスライドは線形のままにし、コピーの値軸のスケールだけを変更します。
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、小さい値が区別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値のみ表示できます。使用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。分析上それらの値を除外するのが適切な場合は、その理由を説明してください。小さな正の数に置き換えるとデータの意味が変わります。対数軸の手動で設定された最小値または最大値も正の数である必要があります。

## **よくある質問**

**軸が他の軸と交差する位置（軸交差）をどのように設定しますか？**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) を使用して交差動作を選択します。数値の交差位置を指定するには [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) を設定します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置できますか？**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) の `LOW`、`HIGH`、`NEXT_TO`、`NONE` を使用して [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) を設定します。目盛り自体を制御するには、[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) または [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) を使用します。これらはラベル配置とは別枠です。