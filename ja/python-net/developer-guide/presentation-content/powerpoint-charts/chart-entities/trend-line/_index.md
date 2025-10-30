---
title: "Pythonでプレゼンテーションチャートにトレンドラインを追加する"
linktitle: "トレンドライン"
type: docs
url: /ja/python-net/trend-line/
keywords:
- "チャート"
- "トレンドライン"
- "指数トレンドライン"
- "線形トレンドライン"
- "対数トレンドライン"
- "移動平均トレンドライン"
- "多項式トレンドライン"
- "べき乗トレンドライン"
- "カスタムトレンドライン"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のチャートにトレンドラインをすばやく追加・カスタマイズできます。予測精度を向上させ、オーディエンスを引きつけるための実践的なガイドとコード例をご提供します。"
---

## **トレンドラインの追加**
Aspose.Slides for Python via .NET は、さまざまなチャートトレンドラインを管理するシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータを使用して、任意のタイプのチャートを追加します（この例では ChartType.CLUSTERED_COLUMN を使用）。
4. チャート系列 1 に指数トレンドラインを追加します。
5. チャート系列 1 に線形トレンドラインを追加します。
6. チャート系列 2 に対数トレンドラインを追加します。
7. チャート系列 2 に移動平均トレンドラインを追加します。
8. チャート系列 3 に多項式トレンドラインを追加します。
9. チャート系列 3 にべき乗トレンドラインを追加します。
10. 変更したプレゼンテーションを PPTX ファイルに保存します。

以下のコードはトレンドライン付きチャートを作成します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 空のプレゼンテーションを作成
with slides.Presentation() as pres:

    # クラスター化された縦棒チャートを作成
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # チャート系列 1 に指数トレンドラインを追加
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # チャート系列 1 に線形トレンドラインを追加
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # チャート系列 2 に対数トレンドラインを追加
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # チャート系列 2 に移動平均トレンドラインを追加
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # チャート系列 3 に多項式トレンドラインを追加
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # チャート系列 3 にべき乗トレンドラインを追加
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # プレゼンテーションを保存
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムラインの追加**
Aspose.Slides for Python via .NET は、チャートにカスタムラインを追加するシンプルな API を提供します。プレゼンテーションの選択スライドにシンプルな直線を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトの AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトの AddAutoShape メソッドを使用してラインタイプの AutoShape を追加します
- シェイプのラインの色を設定します
- 変更したプレゼンテーションを PPTX ファイルとして保存します

以下のコードはカスタムライン付きチャートを作成します。

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

**トレンドラインの 'forward' と 'backward' は何を意味しますか？**  

トレンドラインを前方または後方に延長した長さを示します。散布図（XY）チャートの場合は軸単位で、散布図以外のチャートの場合はカテゴリ数で表されます。0 以上の値のみが許可されます。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりした場合、トレンドラインは保持されますか？**  

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/) に変換し、チャートを画像にレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/python-net/create-shape-thumbnails/) するメソッドも利用可能です。