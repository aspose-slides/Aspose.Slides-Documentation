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
- 軸位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、レポートや可視化のための PowerPoint および OpenDocument プレゼンテーションでチャート軸をカスタマイズする方法を学びましょう。"
---
## **概要**

本記事では、Aspose.Slides for Python via .NET を使用したチャート軸のカスタマイズ方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて取り上げます。

## **縦軸の最大値を取得する**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、デフォルトデータのエリアチャートを追加します。計算された軸の値を取得する前に、チャートのレイアウトが最新になるように [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) を呼び出します。

軸の上限と下限を取得するには [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) と [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) を使用し、目盛り間隔は [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) と [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) から取得します。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) と [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) は日付軸に関連する時間単位のスケールを提供します。例ではこれらの値をローカル変数に保存し、チャートを保存します。

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

[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) を使用して、チャートデータ内の系列とカテゴリの役割を交換します。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。例では [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替える前に設定します。4 系列と 3 カテゴリのチャートを保存します。

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

## **折れ線グラフの垂直軸を非表示にする**

垂直軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。例ではデフォルトデータの折れ線グラフを作成し、垂直軸を非表示にした状態で保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの水平軸を非表示にする**

水平軸の [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) を `False` に設定して非表示にします。例ではデフォルトデータの折れ線グラフを作成し、水平軸を非表示にした状態で保存します。

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

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を設定して、日付またはテキストのカテゴリ軸を選択します。この例は `ExistingChart.pptx` を必要とし、最初のスライドの最初の図形としてチャートがあり、カテゴリセルに数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) を `False`、[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) を `1`、[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) を `months` に設定すると、主要目盛りが 1 ヶ月間隔で配置されます。

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

## **カテゴリ軸ラベルの間隔を制御する**

チャートに多数のカテゴリがある場合、カテゴリやデータポイントを削除せずに表示ラベルの数を減らすことができます。[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) を `False` に設定し、続いて [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) に希望のカテゴリ間隔を指定します。テキストカテゴリが通常の順序で並んでいる場合、カウントは最初のカテゴリから開始されます。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | カテゴリ 1, カテゴリ 2, カテゴリ 3, … カテゴリ 24 |
| `2` | カテゴリ 1, カテゴリ 3, カテゴリ 5, … カテゴリ 23 |
| `3` | カテゴリ 1, カテゴリ 4, カテゴリ 7, … カテゴリ 22 |

`3` の間隔は 3 番目ごとのラベルのみを表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りそのものにも個別の設定があります。[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) を `False` にし、[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) で間隔を設定します。例として、`1` を指定すると各カテゴリ間隔に目盛りが配置され、ラベルは 3 つごとにのみ表示されます。[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を可視スタイルに設定して結果を確認してください。自動間隔プロパティを `True` に戻すと、チャートが再び自動で間隔を選択します。

以下の自己完結型サンプルは 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔手動設定（目盛りは独立）、自動間隔に復元。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。水平ラベルテキストにより密度の違いが視覚的に分かりやすくなります。

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

    # スライド 2: 3 つごとのラベルを表示し、各カテゴリに目盛りを残す。
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

**自動間隔（スライド 1）:** この表示では、2 番目のカテゴリラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラーにより変わります。

![自動カテゴリラベル間隔（すべての 24 列が表示）](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含め、24 列すべてが同じ値で表示されます。スライド 3 は上記の自動表示に戻します。

![手動カテゴリラベル間隔（3）で 24 列すべてが表示](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) に適用してください。目盛り間隔は、系列軸を持つチャートの系列軸にも適用できます。

カテゴリラベル間隔を値軸の数値スケール設定に使用しないでください。値軸では [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) が数値の差を指定します（例: `10` の主要単位は 0, 10, 20 …）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) に記載の時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸値の日時書式を設定する**

例ではデフォルトのチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation シリアル番号として格納されています。[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) を日付軸に設定し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) を無効にし、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) に `yyyy` を割り当てると、セル書式に関係なくカテゴリラベルが 4 桁の年で表示されます。

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

垂直軸の [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) を有効にし、タイトルテキストを設定して [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) で回転させます。角度は度で測定され、例では値軸タイトルを 90 度回転させた列グラフを保存します。

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

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) を使用して、値軸がカテゴリ軸とカテゴリ間またはカテゴリ目盛り上で交差するかを制御します。このプロパティはカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `True` を設定し、結果を保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート値軸の表示単位を設定する**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) を設定して、データ自体を変更せずに値軸のラベルをスケールします。[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) を `MILLIONS` にすると、60,000,000 が 60 と表示されます。例では列グラフを作成し、垂直軸にミリオン表示単位を適用します。

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

対数値軸は、正の値が数桁にわたって広がる場合に便利です。例として、あるサービスが 5 つの期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取ったとします。線形スケールでは小さい値がゼロ付近に密集して見えますが、対数スケールにすると相対的な増加が比較しやすくなります。等距離が等比率を表すためです。

値軸の [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) を `True` に設定し、[log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) で基数を選択します。これは既存の値の表示方法を変更しますが、データや対数トレンドラインを追加するわけではありません。トレンドラインはデータのフィット関係を表す別機能です。

### **値軸と基数を選択する**

折れ線または列グラフでは、値軸は [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) です。水平棒グラフでは [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) が値軸になります。散布図とバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、あるいは両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` までの整数基数が使用可能で、`2.5` のような小数もサポートされます。基数 `10` の場合、10、100、1,000、10,000 といった連続するべき乗が等間隔で配置されます。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。両スライドとも同じデータを保持します。

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

**線形スケール（スライド 1）:** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、他の値が判別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離が等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケール上で直線的に上昇する線となります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示す PowerPoint のグラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは厳密に正の値のみ表示できます。使用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか別途表示してください。分析上それらの値を除外する場合は、その理由を説明し、データの意味が変わらないようにしてください。対数軸の手動で設定した最小値または最大値も正でなければなりません。

## **FAQ**

**軸が交差する位置（軸交差）を指定するにはどうすればよいですか？**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) を使用して交差動作を選択します。数値の交差位置を指定するには [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) を設定します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛ラベルの位置を軸に対してどのように設定できますか？**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) の `LOW`、`HIGH`、`NEXT_TO`、`NONE` のいずれかを使用して [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) を設定します。目盛り自体を制御するには、[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) または [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) を使用します。これらはラベル位置設定とは別です。