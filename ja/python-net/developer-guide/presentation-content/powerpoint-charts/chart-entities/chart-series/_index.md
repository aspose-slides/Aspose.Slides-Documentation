---
title: チャート系列
type: docs
url: /python-net/chart-series/
keywords: "チャート系列, 系列の色, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointプレゼンテーションのチャート系列"
---

系列は、チャートにプロットされた数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列の重なりを設定する**

[IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/)プロパティを使用すると、2Dチャート上でバーと列がどれだけ重なるべきかを指定できます（範囲：-100から100）。このプロパティは親系列グループのすべての系列に適用されます：これは適切なグループプロパティの投影です。したがって、このプロパティは読み取り専用です。

`parent_series_group.overlap`の読み書き可能プロパティを使用して、`overlap`の好みの値を設定します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドにクラスター化されたコラムチャートを追加します。
1. 最初のチャート系列にアクセスします。
1. チャート系列の`parent_series_group`にアクセスし、系列の好みの重なり値を設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPythonコードは、チャート系列の重なりを設定する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # チャートを追加
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # 系列の重なりを設定
        series[0].parent_series_group.overlap = -30

    # プレゼンテーションファイルをディスクに書き込む
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **系列の色を変更する**
Aspose.Slides for Python via .NETを使用すると、次の方法で系列の色を変更できます：

1. `Presentation`クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列にアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正したプレゼンテーションを保存します。

このPythonコードは、系列の色を変更する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[1]
	
	point.explosion = 30
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **系列カテゴリの色を変更する**
Aspose.Slides for Python via .NETを使用すると、次の方法で系列カテゴリの色を変更できます：

1. `Presentation`クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列カテゴリにアクセスします。
1. 好みの塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正したプレゼンテーションを保存します。

このPythonコードは、シリーズカテゴリの色を変更する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[0]
	
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **系列の名前を変更する** 

デフォルトでは、チャートの凡例名は、データの各列または行の上にあるセルの内容です。 

例（サンプル画像）では、 

* 列は*系列 1, 系列 2,* および *系列 3*です；
* 行は *カテゴリー 1, カテゴリー 2, カテゴリー 3,* および *カテゴリー 4*です。 

Aspose.Slides for Python via .NETを使用すると、チャートのデータと凡例で系列名を更新または変更できます。 

このPythonコードは、チャートデータ`ChartDataWorkbook`内で系列名を変更する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "新しい名前"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

このPythonコードは、`Series`を通じて系列名を凡例で変更する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "新しい名前"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **チャートシリーズの塗りつぶし色を設定する**

Aspose.Slides for Python via .NETを使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を次のように設定できます：

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスによってスライドの参照を取得します。
3. お好みのタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType.CLUSTERED_COLUMN`を使用しました）。
4. チャートシリーズにアクセスし、塗りつぶし色を自動に設定します。
5. プレゼンテーションをPPTXファイルに保存します。

このPythonコードは、チャート系列の自動塗りつぶし色を設定する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # クラスター化されたコラムチャートを作成
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # 系列の塗りつぶし形式を自動に設定
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # プレゼンテーションファイルをディスクに書き込む
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート系列の塗りつぶし色を反転させる**
Aspose.Slidesを使用すると、プロット領域内のチャート系列の逆塗りつぶし色を次の方法で設定できます：

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスによってスライドの参照を取得します。
3. お好みのタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType.CLUSTERED_COLUMN`を使用しました）。
4. チャート系列にアクセスし、塗りつぶし色を反転させるように設定します。
5. プレゼンテーションをPPTXファイルに保存します。

このPythonコードは、操作を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しい系列とカテゴリを追加
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "系列 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "カテゴリー 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "カテゴリー 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "カテゴリー 3"))

    # 最初のチャート系列を取り出し、系列データを追加
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **値が負のときに系列を反転させる**
Aspose.Slidesは、`ChartDataPoint.invert_if_negative`プロパティを通じて反転を設定できます。プロパティを使用して反転を設定すると、データポイントは負の値を取得したときにその色を反転させます。

このPythonコードは、操作を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
	series = chart.chart_data.series
	chart.chart_data.series.clear()

	series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series[0].invert_if_negative = False

	series[0].data_points[2].invert_if_negative = True

	pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **特定のデータポイントのデータをクリアする**
Aspose.Slides for Python via .NETを使用すると、特定のチャート系列の`data_points`データを次のようにクリアできます：

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. インデックスを通じてチャートの参照を取得します。
4. すべてのチャート`data_points`を反復処理し、`x_value`と`y_value`をnullに設定します。
5. 特定のチャート系列のすべての`data_points`をクリアします。
6. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPythonコードは、操作を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **系列の間隔幅を設定する**
Aspose.Slides for Python via .NETを使用すると、**`gap_width`**プロパティを通じて系列の間隔幅を次のように設定できます：

1. `Presentation`クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 任意のチャート系列にアクセスします。
5. `gap_width`プロパティを設定します。
6. 修正したプレゼンテーションをPPTXファイルに書き込みます。

このPythonコードは、系列の間隔幅を設定する方法を示しています：

```py
# 空のプレゼンテーションを作成 
with slides.Presentation() as presentation:

    # プレゼンテーションの最初のスライドにアクセス
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # チャートデータシートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # 系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.type)

    # カテゴリを追加
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "カテゴリー 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "カテゴリー 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "カテゴリー 3"))

    # 二番目のチャート系列を取得
    series = chart.chart_data.series[1]

    # 系列データを補充
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # GapWidth値を設定
    series.parent_series_group.gap_width = 50

    # プレゼンテーションをディスクに保存
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```