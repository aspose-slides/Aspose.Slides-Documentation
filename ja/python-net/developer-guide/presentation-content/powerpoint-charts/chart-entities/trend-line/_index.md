---
title: Python でプレゼンテーション チャートにトレンドラインを追加する
linktitle: トレンドライン
type: docs
url: /ja/python-net/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- ポリノミアルトレンドライン
- べき乗トレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint チャートにトレンドラインをすばやく追加・カスタマイズし、観客を惹きつける実用的なガイド。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーションのチャートにトレンドラインを追加する方法を説明します。チャートの作成、チャート系列へのトレンドラインの追加、および指数、線形、対数、移動平均、ポリノミアル、べき乗など複数のトレンドラインタイプの操作方法を示します。

また、ラインシェイプを挿入してチャートにカスタムラインを追加する方法と、前方・後方のトレンドライン投影値や、PDF や SVG へのエクスポート、画像としてチャートをレンダリングする際にトレンドラインが保持されるかどうかに関する簡易 FAQ も含まれています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **トレンドラインの追加**

チャート系列にトレンドラインを追加するには、[TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) を使用し、タイプは [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) で選択します。この例では、デフォルトデータを用いたクラスター化された縦棒チャートを作成し、3 系列それぞれに 2 本のトレンドラインを追加します。

指数トレンドラインは [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) と [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) によって式と決定係数の表示を非表示にし、線形トレンドラインは赤色です。対数トレンドラインはカスタムラベルのために [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) を使用します。移動平均は 3 データポイントの [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) とカスタム [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) を使用します。

ポリノミアルトレンドラインは [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) が 3 で、[forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) により 1 カテゴリ前方に拡張します。べき乗トレンドラインは [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) を使用して 1 カテゴリ後方に拡張します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

## **トレンドラインの切片の設定**

[intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) を使用して、X = 0 でトレンドラインの Y 値を固定します。この設定は線形、指数、ポリノミアルのトレンドラインでサポートされています。

例えば、生産コストモデルでは、非ゼロの生産量で測定した結果が異なる基準線を示唆していても、既知の固定コスト 100 から開始する必要がある場合があります。線形トレンドラインの場合、切片を固定すると方程式 `y = ax + b` が `b = 100` に制約され、傾きはその制約の下でデータに合わせてフィットします。これは既にフィットした線を単に移動させるだけではありません。軸交差設定はチャート軸が交わる位置を制御し、フィットしたトレンドラインの係数を変更するものではありません。

以下の例では、1 から 4 の生産量とコスト 170、200、230、260 の散布図 (XY) チャートを作成します。デフォルトの自動切片でチャートを保存し、切片を 100 に設定して 2 番目の PPTX を保存します。2 つのファイルは切片設定のみが異なります。トレンドラインは式を表示し、X = 0 まで遡って表示されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

自動計算の場合、これらのデータは `y = 30x + 140` を生成します。切片を 100 に設定すると、約 `y = 43.33x + 100` となります。ゼロ点でのフィット値が既知の基準線と一致しますが、線はすべてのデータ点を通過しなくなります。

| 自動切片 | 切片 100 の固定 |
| --- | --- |
| ![自動計算された切片 140 を持つ線形トレンドライン](intercept-automatic.png) | ![切片 100 が固定された線形トレンドライン](intercept-fixed.png) |

両方の画像は同じデータと軸スケールを使用しています。トレンドラインは X = 0 まで遡って切片を示しています。

デフォルトでは、このプロパティは `float("nan")` を含み、ゼロではなく未指定の切片を表します。その後、切片はデータから自動的に計算されます。

## **カスタムラインの追加**

カスタムラインは、系列データから計算されたトレンドラインではなく、チャート上に描画するシェイプです。この例では、[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) を使用して、チャート上に水平ラインをスライドに追加します。ラインの位置はポイント単位のスライド座標で指定され、チャートの左端から始まり、チャートの高さの半分の位置に配置されます。幅はチャートの幅と同じです。[line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) でラインを実線の赤色に設定します。

## **FAQ**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

それらはトレンドラインを前方または後方に投影した長さを表します。散布図 (XY) の場合は軸単位で、非散布図の場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングした場合、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) または [SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、[チャートの画像をエクスポート](/slides/ja/python-net/create-shape-thumbnails/) するメソッドも利用可能です。