---
title: Python を使用したプレゼンテーションのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-net/chart-axis/
keywords:
- chart axis
- vertical axis
- horizontal axis
- customize axis
- manipulate axis
- manage axis
- axis properties
- max value
- min value
- axis line
- date format
- axis title
- axis position
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでレポートや可視化用のチャート軸をカスタマイズする方法をご紹介します。"
---

## **縦軸の最大値を取得する方法**
Aspose.Slides for Python via .NET を使用すると、縦軸の最小値と最大値を取得できます。以下の手順を実行してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 最初のスライドにアクセスします。  
3. デフォルトデータでチャートを追加します。  
4. 軸の実際の最大値を取得します。  
5. 軸の実際の最小値を取得します。  
6. 軸の実際の主単位を取得します。  
7. 軸の実際の補助単位を取得します。  
8. 軸の実際の主単位スケールを取得します。  
9. 軸の実際の補助単位スケールを取得します。

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

## **軸間でデータを入れ替える**
Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。縦軸（y 軸）に表示されているデータが横軸（x 軸）に、逆も同様に移動します。

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

## **折れ線グラフの縦軸を無効化する**

以下の Python コードは、折れ線グラフの縦軸を非表示にする方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの横軸を無効化する**

以下のコードは、折れ線グラフの横軸を非表示にする方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸の変更**

**CategoryAxisType** プロパティを使用して、希望のカテゴリ軸タイプ（**date** または **text**）を指定できます。以下の Python コードはその操作例です。

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

## **カテゴリ軸値の日時書式設定**
Aspose.Slides for Python via .NET を使って、カテゴリ軸値の日時書式を設定できます。以下の Python コードで操作を確認してください。

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

## **チャート軸タイトルの回転角度設定**
Aspose.Slides for Python via .NET を使用すると、チャート軸タイトルの回転角度を設定できます。以下の Python コードで操作例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリ軸または値軸の位置軸設定**
Aspose.Slides for Python via .NET では、カテゴリ軸または値軸の位置軸を設定できます。以下の Python コードで手順を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **値軸に表示単位ラベルを有効化する**
Aspose.Slides for Python via .NET では、チャートの値軸に単位ラベルを表示するよう設定できます。以下の Python コードで操作を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**軸が相交する位置（軸交差点）をどのように設定しますか？**

軸には [crossing setting](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) があり、0、最大カテゴリ/値、または特定の数値で交差させるか選択できます。これは X 軸を上下にシフトしたり、基準線を強調したりする際に便利です。

**目盛ラベルの位置（軸の横、外側、内側）をどのように設定しますか？**

[label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を "cross"、"outside"、または "inside" に設定します。これにより可読性が向上し、特に小さなチャートでスペースを節約できます。