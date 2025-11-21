---
title: Pythonでプレゼンテーションチャートにトレンドラインを追加
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
- 多項式トレンドライン
- べきトレンドライン
- カスタムトレンドライン
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のチャートにトレンドラインを迅速に追加およびカスタマイズできます。予測精度を向上させ、オーディエンスを引き付ける実用的なガイドとコード例をご紹介します。"
---

## **トレンドラインの追加**
Aspose.Slides for Python via .NET は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します:

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意のタイプを指定します（この例では ChartType.CLUSTERED_COLUMN を使用）。
1. 系列 1 に指数トレンドラインを追加します。
1. 系列 1 に線形トレンドラインを追加します。
1. 系列 2 に対数トレンドラインを追加します。
1. 系列 2 に移動平均トレンドラインを追加します。
1. 系列 3 に多項式トレンドラインを追加します。
1. 系列 3 にべきトレンドラインを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き出します。

以下のコードは、トレンドライン付きチャートを作成するために使用されます。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 空のプレゼンテーションを作成
with slides.Presentation() as pres:

    # クラスタードカラムチャートを作成
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # 系列 1 に指数トレンドラインを追加
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # 系列 1 に線形トレンドラインを追加
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # 系列 2 に対数トレンドラインを追加
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # 系列 2 に移動平均トレンドラインを追加
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # 系列 3 に多項式トレンドラインを追加
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # 系列 3 にべきトレンドラインを追加
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # プレゼンテーションを保存
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```




## **カスタムラインの追加**
Aspose.Slides for Python via .NET は、チャートにカスタムラインを追加するためのシンプルな API を提供します。プレゼンテーションの選択されたスライドにシンプルな直線を追加するには、以下の手順に従ってください:

- Presentation クラスのインスタンスを作成する
- インデックスを使用してスライドの参照を取得する
- Shapes オブジェクトが提供する AddChart メソッドを使用して新しいチャートを作成する
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して Line タイプの AutoShape を追加する
- 図形の線の色を設定する
- 変更されたプレゼンテーションを PPTX ファイルとして書き出す

以下のコードは、カスタムライン付きチャートを作成するために使用されます。
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


## **FAQ**

**トレンドラインの「forward」および「backward」とは何ですか？**

トレンドラインを前方/後方に投影した長さを表します。散布図（XY）チャートの場合は軸の単位で、散布図以外の場合はカテゴリ数で示します。負の値は許可されません。

**プレゼンテーションを PDF または SVG にエクスポートしたり、スライドを画像としてレンダリングしたりしたときにトレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) / [SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。チャートの一部であるトレンドラインはこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/python-net/create-shape-thumbnails/)するメソッドも利用可能です。