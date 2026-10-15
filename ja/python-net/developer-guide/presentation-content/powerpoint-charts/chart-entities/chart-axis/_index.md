---
title: Python を使用したプレゼンテーションのチャート軸カスタマイズ
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
- 軸ライン
- 日付形式
- 軸タイトル
- 軸位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、レポートや可視化のために PowerPoint と OpenDocument のプレゼンテーションでチャート軸をカスタマイズする方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の切り替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、対数スケーリングについてカバーしています。

## **チャートの縦軸の最大値を取得**

[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、デフォルトデータの面グラフを追加します。計算された軸の値を読む前に、チャートレイアウトが最新になるように [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) を呼び出します。

軸の上限と下限を取得するには [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) と [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) を使用し、目盛り間隔は [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) と [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) で取得します。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) と [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) は日付軸に関連する時間単位スケールを提供します。サンプルはこれらの値をローカル変数に保存し、チャートを保存します。

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

[swap_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) を使用して、チャートデータ内の系列とカテゴリの役割を入れ替えます。元のカテゴリが系列になり、元の系列がカテゴリになります。これはデータのグループ化方法を変更しますが、横軸と縦軸を入れ替えるわけではありません。サンプルは [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えます。結果として 4 系列と 3 カテゴリのチャートが保存されます。

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

[is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) を使用してカテゴリ軸または値軸の順序を逆にします。たとえば、横棒グラフでプロジェクトの段階をワークシートと同じ順序（計画、開発、テスト）で上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ワークブックのデータを並べ替えたり再配置したりはしません。一方、[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) は系列とカテゴリの役割を入れ替えます。

以下の例は、3 つの段階と 1 系列の横棒グラフを作成します。プレゼンテーションは 3 枚のスライド（通常順序、カテゴリ逆順、値逆順）として保存されます。各コピーは同じデータセットを使用し、各コピーで逆にする軸は 1 本だけです。

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

    # スライド 2: 最初のカテゴリを上部に表示する。
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 水平値軸を下部に保持する。
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # スライド 3: 水平数値スケールのみを逆にする。
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

軸を逆にすると、垂直軸をプロットの反対側に移動させることもできます。[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) は、構成中の軸が他の軸と交差する位置を制御します。スライド 2 では、逆にしたカテゴリ軸で `MAXIMUM` を設定すると、横方向の値軸が下部に保持されます。特定の交差点を指定するには [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) を使用します。方向を変更する際は交差設定を確認してください。特にチャートにカスタム交差点が設定されている場合は注意が必要です。`is_plot_order_reversed` を `False` に戻すと通常の描画方向に復元されますが、交差設定は別個です。

| 通常順序（スライド 1） | カテゴリ逆順（スライド 2） | 値逆順（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸の順序の横棒グラフ](axis-order-normal.png) | ![上から下へカテゴリが表示される横棒グラフ](axis-order-categories-reversed.png) | ![値軸が逆になり、右側がゼロになる横棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブック行の順序は変更されません。 | カテゴリは通常順序のままで、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。サンプルはデフォルトデータの折れ線グラフを作成し、縦軸を非表示にして保存します。

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

横軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。サンプルはデフォルトデータの折れ線グラフを作成し、横軸を非表示にして保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸を変更する**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を設定して、日付軸またはテキストカテゴリ軸を選択します。このサンプルは `ExistingChart.pptx` が必要で、最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリセルに数値の Excel 日付が格納されています。横軸を日付軸に変更します。[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) を `False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) を `1`、[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) を月に設定すると、1 ヶ月間隔で主目盛りが配置されます。

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

## **カテゴリ軸ラベル間隔を制御する**

チャートに多数のカテゴリがある場合、カテゴリやデータポイントを削除せずに表示ラベルの数を減らすことができます。[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) を `False` にし、[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) で目的のカテゴリ間隔を指定します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから開始します。

| 間隔 | サンプルで表示されるラベル |
| --- | --- |
| `1` | カテゴリ 1, カテゴリ 2, カテゴリ 3, ... カテゴリ 24 |
| `2` | カテゴリ 1, カテゴリ 3, カテゴリ 5, ... カテゴリ 23 |
| `3` | カテゴリ 1, カテゴリ 4, カテゴリ 7, ... カテゴリ 22 |

間隔 `3` は 3 番目ごとのラベルだけを表示し、表示ラベルの間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を選択しますが、必ずしもすべてのラベルを表示するわけではありません。

目盛りには別個の設定があります。[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) を `False` にし、[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) で間隔を設定します。たとえば `1` は各カテゴリ間隔に目盛りを配置し、ラベルは 3 番目ごとに表示されます。[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を可視スタイルに設定すると結果が確認できます。いずれかの自動設定プロパティを `True` に戻すと、チャートが間隔を再度自動選択します。

以下の自己完結型サンプルは 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライド（自動間隔、手動ラベル間隔と独立目盛り、復元された自動間隔）として保存します。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。横方向のラベルテキストにより密度の違いが分かりやすくなります。

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

    # スライド 2: 3 番目ごとのラベルを表示し、各カテゴリに目盛りを保持する。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # スライド 3: チャートに両方の間隔を再度選択させる。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自動間隔（スライド 1）:** このレンダリングでは、2 番目のカテゴリラベルごとに表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラに応じて変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りは各カテゴリ間隔に残ります。ラベルのない列も含めてすべての 24 列が同じ値で表示されます。スライド 3 は上記の自動外観に戻ります。

![すべての 24 列が表示された手動カテゴリラベル間隔（間隔 3）](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、面、棒グラフのカテゴリ軸など）ではこのカテゴリ数間隔を使用します。列グラフでは横軸、横棒グラフでは縦軸がカテゴリ軸になるため、[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) にこれらの設定を適用します。目盛り間隔は系列軸を持つチャートにも適用できます。

カテゴリラベル間隔を使用して値軸の数値スケールを設定しないでください。値軸では [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) が値の差を指定します（例: `10` の主単位は 0、10、20…）。カテゴリラベル間隔 `3` はデータの値に関係なくカテゴリ位置を数えるだけです。散布図とバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主単位とスケールを使用してください。

## **カテゴリ軸値の日付形式を設定する**

サンプルはデフォルトのチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation シリアル番号として格納されます。[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を日付軸に設定し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) を無効にし、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) に `yyyy` を割り当てると、セル書式設定に関係なくカテゴリラベルが4桁の年として表示されます。

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

縦軸の [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) を有効にし、タイトルテキストを提供し、[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) を設定してタイトルを回転させます。角度は度数で測定され、このサンプルは値軸タイトルを 90 度回転させた列グラフを保存します。

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

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) を使用して、値軸がカテゴリ軸とカテゴリ目盛りの間で交差するか、目盛り上で交差するかを制御します。このプロパティはカテゴリ軸に適用されます。サンプルは列グラフの横カテゴリ軸で `True` に設定し、結果を保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートの値軸に表示単位を設定する**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) を設定して、基になるデータを変更せずに値軸のラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) を `MILLIONS` に設定すると、60,000,000 が 60 と表示されます。サンプルは列グラフを作成し、縦軸に百万単位の表示単位を適用します。

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

対数値軸は、正の値が数オーダーにわたって広がっている場合に有用です。たとえば、サービスが 5 期間にわたり 10、100、1,000、10,000、100,000 件のリクエストを受信したとします。線形スケールでは小さい値がゼロ付近に密集して表示されます。対数スケールにすると、等間隔が等比率を表すため、相対的な成長を比較しやすくなります。

値軸の [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) を `True` に設定し、[log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは追加されません。トレンドラインはデータのフィット関係を表す別機能です。

### **値軸と基数を選択する**

折れ線や列グラフの場合、値軸は [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) です。横棒グラフの場合は [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) です。散布図とバブルチャートは 2 つの値軸を持つため、X 値に水平軸、Y 値に垂直軸、または両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（包括）までの基数が使用可能で、`2.5` のような小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

### **線形と対数スケーリングの比較**

以下の自己完結型サンプルは、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

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

    # 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更します。
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、較小値が判別しにくくなります。

![線形値軸上に 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 スケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数のまま表示されます。

![基数 10 の対数値軸上に同じ 5 つのリクエスト数を示す PowerPoint のグラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値だけを表示できます。使用前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。分析上それらの値を除外することが適切な場合は、除外した旨を説明してください。小さい正の数に静かに置き換えてはいけません。これはデータの意味を変えてしまいます。対数軸の手動で設定した最小値または最大値も正でなければなりません。

## **よくある質問**

**1. 1 つの軸が他方の軸と交差する値（軸交差）を設定するにはどうすればよいですか？**

[Cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) を使用して交差動作を選択します。数値的な交差位置を指定するには [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) を設定します。これらの設定により、軸交差位置を適切なベースラインへ移動できます。

**2. 目盛りラベルの位置を軸に対してどのように設定できますか？**

[Tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) を使用し、[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) の `LOW`, `HIGH`, `NEXT_TO`, `NONE` のいずれかを指定します。目盛り自体を制御するには、[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) または [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) を使用します。これらはラベル位置設定とは別です。