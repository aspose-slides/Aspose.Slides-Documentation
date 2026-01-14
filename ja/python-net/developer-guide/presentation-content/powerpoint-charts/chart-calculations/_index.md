---
title: Pythonでのプレゼンテーション向けチャート計算の最適化
linktitle: チャート計算
type: docs
weight: 50
url: /ja/python-net/chart-calculations/
keywords:
- チャート計算
- チャート要素
- 要素の位置
- 実際の位置
- 子要素
- 親要素
- チャート値
- 実際の値
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP のチャート計算、データ更新、精度制御を理解し、実用的なコード例を通じて学びます。"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for Python via .NET は、これらのプロパティを取得するためのシンプルな API を提供します。この API は、チャート要素の実際の値を計算するのに役立ちます。実際の値には、[IActualLayout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/iactuallayout/) クラスを継承する要素の位置 (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) と、実際の軸の値 (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale) が含まれます。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```


## **親チャート要素の実際の位置を計算する**
Aspose.Slides for Python via .NET は、これらのプロパティを取得するためのシンプルな API を提供します。IActualLayout のプロパティは、親チャート要素の実際の位置に関する情報を提供します。プロパティに実際の値を設定するには、事前にメソッド IChart.ValidateChartLayout() を呼び出す必要があります。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```


## **チャートから情報を非表示にする**
このトピックでは、チャートから情報を非表示にする方法を理解できるように説明します。Aspose.Slides for Python via .NET を使用すると、**タイトル、縦軸、横軸** および **グリッド線** をチャートから非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # チャートのタイトルを非表示にする
    chart.has_title = False

    # 値軸を非表示にする
    chart.axes.vertical_axis.is_visible = False

    # カテゴリ軸の表示
    chart.axes.horizontal_axis.is_visible = False

    # 凡例を非表示にする
    chart.has_legend = False

    # 主目盛線を非表示にする
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # シリーズの線色を設定する
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**外部の Excel ワークブックはデータソースとして機能しますか、再計算にどのように影響しますか？**

はい。チャートは外部ワークブックを参照できます。外部ソースに接続または更新すると、数式と値がそのワークブックから取得され、チャートは開く/編集する操作中に更新を反映します。API では、[外部ワークブックを指定する](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) パスを設定し、リンクされたデータを管理できます。

**回帰を自分で実装せずにトレンドラインを計算・表示できますか？**

はい。[トレンドライン](/slides/ja/python-net/trend-line/)（線形、指数、その他）は Aspose.Slides によって追加および更新されます。パラメータはシリーズデータから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンク付きの複数のチャートがある場合、各チャートが計算に使用するワークブックを制御できますか？**

はい。各チャートはそれぞれの[外部ワークブック](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を指すことができ、または他のチャートとは独立してチャートごとに外部ワークブックを作成/置換できます。