---
title: Pythonでプレゼンテーション用チャート計算を最適化
linktitle: チャート計算
type: docs
weight: 50
url: /ja/python-net/chart-calculations/
keywords:
- チャート計算
- チャート要素
- 要素位置
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
description: "Aspose.Slides for Python via .NETでPPT、PPTX、ODP用のチャート計算、データ更新、および精度制御を理解し、実用的なコード例を提供します。"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for Python via .NET は、これらのプロパティを取得するためのシンプルな API を提供します。これにより、チャート要素の実際の値を計算できます。実際の値には、IActualLayout インターフェイスを実装する要素の位置 (IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight) と実際の軸の値 (IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale) が含まれます。
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
Aspose.Slides for Python via .NET は、これらのプロパティを取得するためのシンプルな API を提供します。IActualLayout のプロパティは、親チャート要素の実際の位置に関する情報を提供します。プロパティに実際の値を設定するには、事前に IChart.ValidateChartLayout() メソッドを呼び出す必要があります。
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
このトピックでは、チャートから情報を非表示にする方法を説明します。Aspose.Slides for Python via .NET を使用すると、**タイトル、縦軸、横軸** および **グリッド線** をチャートから非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # チャートタイトルを非表示にする
    chart.has_title = False

    # 値軸を非表示にする
    chart.axes.vertical_axis.is_visible = False

    # カテゴリ軸の表示設定
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

    # 系列の線の色を設定する
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**外部の Excel ワークブックをデータ ソースとして使用できますか、また再計算にどのように影響しますか？**
はい。チャートは外部ワークブックを参照できます。外部ソースに接続またはリフレッシュすると、数式と値はそのワークブックから取得され、チャートは開閉/編集操作中に更新を反映します。API を使用して、外部ワークブックのパスを[指定できます](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) し、リンクされたデータを管理できます。

**回帰を自分で実装せずにトレンドラインを計算・表示できますか？**
はい。[トレンドライン](/slides/ja/python-net/trend-line/)（線形、指数、その他）は Aspose.Slides によって追加および更新されます。パラメータは系列データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンク付きの複数のチャートがある場合、各チャートが計算値に使用するワークブックを制御できますか？**
はい。各チャートはそれぞれ独自の[外部ワークブック](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を指すことができ、またはチャートごとに外部ワークブックを作成/置換して、他のチャートとは独立して管理できます。