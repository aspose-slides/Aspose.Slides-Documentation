---
title: チャートの軸
type: docs
url: /ja/python-net/chart-axis/
keywords: "PowerPoint チャート軸, プレゼンテーション チャート, Python, チャート軸の操作, チャートデータ"
description: "PythonでPowerPointのチャート軸を編集する"
---


## **チャートの垂直軸の最大値を取得する**
Aspose.Slides for Python via .NETを使用すると、垂直軸の最小値と最大値を取得できます。これらのステップに従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを持つチャートを追加します。
1. 軸の実際の最大値を取得します。
1. 軸の実際の最小値を取得します。
1. 軸の実際の主単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコード—上記のステップの実装—は、Pythonで必要な値を取得する方法を示しています：

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


## **軸間でデータを入れ替える**
Aspose.Slidesを使用すると、軸間でデータを迅速に入れ替えることができます。垂直軸（y軸）のデータが水平軸（x軸）に移動し、その逆も同様です。

このPythonコードは、チャートの軸間でデータを入れ替えるタスクを実行する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 空のプレゼンテーションを作成します
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # 行と列を入れ替えます
    chart.chart_data.switch_row_column()
            
    # プレゼンテーションを保存します
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの垂直軸を無効にする**

このPythonコードは、折れ線グラフの垂直軸を非表示にする方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **折れ線グラフの水平軸を無効にする**

このコードは、折れ線グラフの水平軸を非表示にする方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリー軸を変更する**

**CategoryAxisType**プロパティを使用して、希望するカテゴリー軸のタイプ（**日付**または**テキスト**）を指定できます。このPythonコードは、操作を示しています：

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

## **カテゴリー軸値の日付形式を設定する**
Aspose.Slides for Python via .NETを使用すると、カテゴリー軸の値の日付形式を設定できます。この操作は、次のPythonコードで示されています：

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

## **チャート軸タイトルの回転角を設定する**
Aspose.Slides for Python via .NETを使用すると、チャート軸タイトルの回転角を設定できます。このPythonコードが操作を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **カテゴリー軸または値軸での位置軸の設定**
Aspose.Slides for Python via .NETを使用すると、カテゴリー軸または値軸の位置軸を設定できます。このPythonコードは、タスクを実行する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート値軸に表示単位ラベルを有効にする**
Aspose.Slides for Python via .NETを使用すると、チャートが値軸に単位ラベルを表示するように構成できます。このPythonコードが操作を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```