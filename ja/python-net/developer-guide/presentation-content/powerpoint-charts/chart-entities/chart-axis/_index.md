---
title: プレゼンテーションのチャート軸をPythonでカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-net/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸プロパティ
- 最大値
- 最小値
- 軸ライン
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、レポートや可視化のために PowerPoint および OpenDocument プレゼンテーションのチャート軸をカスタマイズする方法をご紹介します。"
---

## **チャートの垂直軸の最大値を取得**
Aspose.Slides for Python via .NET を使用すると、垂直軸の最小値と最大値を取得できます。以下の手順を実行してください:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. 最初のスライドにアクセスします。  
1. デフォルト データでチャートを追加します。  
1. 軸の実際の最大値を取得します。  
1. 軸の実際の最小値を取得します。  
1. 軸の実際の主単位を取得します。  
1. 軸の実際の副単位を取得します。  
1. 軸の実際の主単位スケールを取得します。  
1. 軸の実際の副単位スケールを取得します。

このサンプルコード（上記手順の実装）は、Python で必要な値を取得する方法を示します:
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
	
	# プレゼンテーションを保存します
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **軸間のデータの入れ替え**
Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。垂直軸（Y 軸）のデータが水平軸（X 軸）に、逆も同様に移動します。

この Python コードは、チャートの軸間でデータを入れ替える方法を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # 行と列を入れ替える
    chart.chart_data.switch_row_column()
            
    # プレゼンテーションを保存
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```


## **折れ線グラフの垂直軸を無効化**

この Python コードは、折れ線グラフの垂直軸を非表示にする方法を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```


## **折れ線グラフの水平軸を無効化**

このコードは、折れ線グラフの水平軸を非表示にする方法を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```


## **カテゴリ軸の変更**

**CategoryAxisType** プロパティを使用して、希望するカテゴリ軸のタイプ（**date** または **text**）を指定できます。この Python のコードは、その操作を示しています:
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


## **カテゴリ軸値の日付形式の設定**

Aspose.Slides for Python via .NET を使用すると、カテゴリ軸の値の日付形式を設定できます。この操作は以下の Python コードで示されています:
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


## **チャート軸タイトルの回転角度の設定**

Aspose.Slides for Python via .NET を使用すると、チャート軸タイトルの回転角度を設定できます。この Python コードで操作を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```


## **カテゴリ軸または値軸の位置軸の設定**

Aspose.Slides for Python via .NET を使用すると、カテゴリ軸または値軸の位置軸を設定できます。この Python コードは、その手順を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


## **チャート値軸に表示単位ラベルを有効化**

Aspose.Slides for Python via .NET を使用すると、チャートの値軸に単位ラベルを表示するよう構成できます。この Python コードでその操作を示します:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**軸が互いに交差する値（軸交点）を設定するにはどうすればよいですか？**

軸には [crossing 設定](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) があり、0 で交差させるか、最大のカテゴリ/値で交差させるか、特定の数値で交差させるかを選択できます。これは X 軸を上下にずらしたり、基準線を強調したりするのに便利です。

**目盛ラベルを軸に対して（横に、外側、内側）どのように配置できますか？**

[label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) を "cross"、"outside"、または "inside" に設定します。これにより可読性が向上し、特に小さなチャートでスペースの節約に役立ちます。