---
title: Python を使用したプレゼンテーションのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-axis/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでレポートや可視化用にチャート軸をカスタマイズする方法を紹介します。"
---

## **チャートの縦軸で最大値を取得する**
Aspose.Slides for Python via .NET を使用すると、縦軸の最小値と最大値を取得できます。以下の手順を実行してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 軸の実際の最大値を取得します。
1. 軸の実際の最小値を取得します。
1. 軸の実際の主単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

上記手順を実装したサンプルコードは、Python で必要な値を取得する方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **軸間のデータ入れ替え**
Aspose.Slides を使用すると、軸間のデータをすばやく入れ替えることができます。縦軸（y 軸）のデータが横軸（x 軸）に、逆も同様に移動します。

以下の Python コードは、チャートの軸間でデータを入れ替える方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの縦軸を非表示にする**

以下の Python コードは、折れ線グラフの縦軸を非表示にする方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの横軸を非表示にする**

このコードは、折れ線グラフの横軸を非表示にする方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸の変更**

**CategoryAxisType** プロパティを使用して、希望するカテゴリ軸タイプ（**date** または **text**）を指定できます。以下の Python コードはその操作例です。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸の値の日時形式を設定する**
Aspose.Slides for Python via .NET を使用して、カテゴリ軸の値の日時形式を設定できます。操作は次の Python コードで示されています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート軸タイトルの回転角度を設定する**
Aspose.Slides for Python via .NET を使用して、チャート軸タイトルの回転角度を設定できます。以下の Python コードで操作を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸または数値軸での軸位置の設定**
Aspose.Slides for Python via .NET を使用して、カテゴリ軸または数値軸で軸位置を設定できます。以下の Python コードがその手順を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート数値軸に表示単位ラベルを有効にする**
Aspose.Slides for Python via .NET では、チャートの数値軸に単位ラベルを表示するよう設定できます。次の Python コードが操作例です。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**軸が交差する位置（軸交差）をどのように設定しますか？**

軸は [crossing setting](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) を提供しています。ゼロ、最大カテゴリ/値、または特定の数値で交差させるか選択できます。これにより X 軸を上下にシフトしたり、ベースラインを強調したりできます。

**目盛ラベルを軸に対してどのように配置しますか（横、外側、内側）？**

[label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を "cross"、"outside"、または "inside" に設定します。可読性に影響し、スペースが限られた小さなチャートで特に有用です。