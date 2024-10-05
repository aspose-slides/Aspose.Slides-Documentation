---
title: トレンドライン
type: docs
url: /python-net/trend-line/
keywords: "トレンドライン、カスタムライン PowerPoint プレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "Python で PowerPoint プレゼンテーションにトレンドラインとカスタムラインを追加する"
---

## **トレンドラインを追加する**
Aspose.Slides for Python via .NET は、さまざまなチャートのトレンドラインを管理するための簡単な API を提供します：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つ任意の種類（この例では ChartType.CLUSTERED_COLUMN を使用）でチャートを追加します。
1. チャートシリーズ 1 に指数的トレンドラインを追加します。
1. チャートシリーズ 1 に線形トレンドラインを追加します。
1. チャートシリーズ 2 に対数トレンドラインを追加します。
1. チャートシリーズ 2 に移動平均トレンドラインを追加します。
1. チャートシリーズ 3 に多項式トレンドラインを追加します。
1. チャートシリーズ 3 にパワートレンドラインを追加します。
1. 修正したプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードは、トレンドラインを持つチャートを作成するために使用されます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 空のプレゼンテーションを作成する
with slides.Presentation() as pres:

    # クラスタ化されたコラムチャートを作成する
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # チャートシリーズ 1 に指数的トレンドラインを追加する
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # チャートシリーズ 1 に線形トレンドラインを追加する
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # チャートシリーズ 2 に対数トレンドラインを追加する
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("新しい対数トレンドライン")

    # チャートシリーズ 2 に移動平均トレンドラインを追加する
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "新しいトレンドライン名"

    # チャートシリーズ 3 に多項式トレンドラインを追加する
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # チャートシリーズ 3 にパワートレンドラインを追加する
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # プレゼンテーションを保存する
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **カスタムラインを追加する**
Aspose.Slides for Python via .NET は、チャートにカスタムラインを追加するための簡単な API を提供します。プレゼンテーションの選択されたスライドに単純な平面ラインを追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトによって公開される AddChart メソッドを使用して新しいチャートを作成します。
- Shapes オブジェクトによって公開される AddAutoShape メソッドを使用して、ラインタイプのオートシェイプを追加します。
- シェイプのラインの色を設定します。
- 修正したプレゼンテーションを PPTX ファイルとして書き込みます。

以下のコードは、カスタムラインを持つチャートを作成するために使用されます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```