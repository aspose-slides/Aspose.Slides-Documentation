---
title: PythonでPowerPointプレゼンテーションのチャートを作成
linktitle: チャートを作成
type: docs
weight: 10
url: /python-net/create-chart/
keywords: "チャート作成, 散布図, 円グラフ, ツリーマップチャート, 株式チャート, ボックス・ウィスカー図, ヒストグラムチャート, ファunnelチャート, サンバーストチャート, マルチカテゴリーチャート, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションのチャートを作成"
---

## **チャートを作成**

チャートは、人々がデータを迅速に視覚化し、テーブルやスプレッドシートからはすぐには明らかでない洞察を得るのに役立ちます。

**なぜチャートを作成するのか？**

チャートを使用することで、次のことが可能になります。

* プレゼンテーションの1つのスライド上に大量のデータを集約、圧縮、または要約する
* データ内のパターンやトレンドを明らかにする
* 特定の測定単位に対して、時間の経過や特定の状況におけるデータの方向性と勢いを推測する
* アウトライヤー、異常、偏差、エラー、意味不明なデータなどを見つける
* 複雑なデータを伝達または提示する

PowerPointでは、さまざまな種類のチャートをデザインするために使用されるテンプレートを提供する挿入機能を通じてチャートを作成できます。Aspose.Slidesを使用すると、一般的なチャートタイプに基づく通常のチャートとカスタムチャートを作成できます。

{{% alert color="primary" %}} 

チャートを作成できるようにするために、Aspose.Slidesは[Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/)名前空間の下に[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)列挙を提供します。この列挙のメンバーは、さまざまなチャートタイプに対応しています。

{{% /alert %}} 

### **通常のチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. データを含むチャートを追加し、好みのチャートタイプを指定します。
1. チャートのタイトルを追加します。
1. チャートデータワークシートにアクセスします。
1. すべてのデフォルト系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. チャート系列のフィルカラーを追加します。
1. チャート系列のラベルを追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このPythonコードは、通常のチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation() as pres:

    # 最初のスライドにアクセス
    sld = pres.slides[0]

    # デフォルトデータでチャートを追加
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # チャートのタイトルを設定
    chart.chart_title.add_text_frame_for_overriding("サンプルタイトル")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列を値を表示するように設定
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャートデータシートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デフォルト生成された系列とカテゴリを削除
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # 新しい系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.type)

    # 新しいカテゴリを追加
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"))

    # 最初のチャート系列を取得
    series = chart.chart_data.series[0]

    # 系列データをポピュレートする

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # 系列のフィルカラーを設定
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 二番目のチャート系列を取得
    series = chart.chart_data.series[1]

    # 系列データをポピュレートする
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 系列のフィルカラーを設定
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 最初のラベルはカテゴリ名を表示する
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # 3つ目のラベルに値を表示
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # チャートでプレゼンテーションを保存
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```

### **散布図を作成する**
散布図（散布プロットやx-yグラフとも呼ばれる）は、パターンを確認したり、2つの変数間の相関関係を示すためによく使用されます。 

散布図を使用する理由は次のとおりです。

* ペアになった数値データがある
* 2つの変数がうまくペアリングされている
* 2つの変数が関連しているかどうかを判断したい
* 独立変数に対して従属変数が複数の値を持つ

このPythonコードは、異なるマーカー系列を持つ散布図を作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # デフォルトチャートを作成
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # デフォルトチャートデータワークシートのインデックスを取得
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デモ系列を削除
    chart.chart_data.series.clear()

    # 新しい系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.type)

    # 最初のチャート系列を取得
    series = chart.chart_data.series[0]

    # 新しいポイント (1:3) を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # 新しいポイント (2:10)を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # 系列の種類を編集
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # 2番目のチャート系列を取得
    series = chart.chart_data.series[1]

    # 新しいポイント (5:2) を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # 新しいポイント (3:1)を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # 新しいポイント (2:2)を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # 新しいポイント (5:1)を追加
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # 系列のマーカーを変更
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **円グラフを作成する**

円グラフは、特にデータに数値のラベルが含まれている場合に、部分と全体の関係を示すのに最適です。ただし、データに多くの部分やラベルが含まれている場合は、代わりに棒グラフを使用することを検討してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータとともにチャートを追加し、希望するタイプ（この場合は`ChartType.PIE`）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 円グラフのセクターにカスタムカラーを追加します。
1. 系列のラベルを設定します。
1. 系列ラベルのリーダー線を設定します。
1. 円グラフスライドの回転角度を設定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、円グラフを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation() as presentation:

    # 最初のスライドにアクセス
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # チャートのタイトルを設定
    chart.chart_title.add_text_frame_for_overriding("サンプルタイトル")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列を値を表示するように設定
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャートデータシートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # デフォルト生成された系列とカテゴリを削除
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいカテゴリを追加
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "第一四半期"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "第二四半期"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "第三四半期"))

    # 新しい系列を追加
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "系列 1"), chart.type)

    # 系列データをポピュレートする
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # 新しいポイントを追加し、セクターの色を設定
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # セクターの枠線を設定
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # セクターの枠線を設定
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # セクターの枠線を設定
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 新しい系列の各カテゴリのカスタムラベルを作成
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # チャートのリーダーラインを表示します
    series.labels.default_data_label_format.show_leader_lines = True

    # 円グラフのセクターの回転角度を設定
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # チャートでプレゼンテーションを保存
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **折れ線グラフを作成する**

折れ線グラフ（折れ線グラフとも呼ばれる）は、時間の経過に伴う値の変化を示す場合に最適です。折れ線グラフを使用すると、一度に多くのデータを比較したり、時間の経過に伴う変更やトレンドを追跡したり、データ系列の異常を強調表示したりできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータとともにチャートを追加し、希望するタイプ（この場合は`ChartType.Line`）を指定します。
1. チャートデータ[IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/)にアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、折れ線グラフを作成する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

デフォルトでは、折れ線グラフのポイントは直線で結ばれています。ポインタをダッシュで結ぶ場合は、この方法で好みのダッシュタイプを指定できます：

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **ツリーマップチャートを作成する**

ツリーマップチャートは、販売データに最適で、データカテゴリの相対的なサイズを示し、同時に各カテゴリに大きく寄与する項目に迅速に注意を向けさせることができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータとともにチャートを追加し、希望するタイプ（この場合は`ChartType.TREEMAP`）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、ツリーマップチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branch 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Leaf4"))

    #branch 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```

### **株式チャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータでチャートを追加し、希望するタイプ（ChartType.OPEN_HIGH_LOW_CLOSE）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. HiLowLines形式を指定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

サンプルPythonコードを使用して株式チャートを作成します：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```

### **ボックス・ウィスカー図を作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータでチャートを追加し、希望するタイプ（ChartType.BOX_AND_WHISKER）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、ボックス・ウィスカー図を作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "カテゴリ 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))

    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```

### **ファunnelチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータでチャートを追加し、希望するタイプ（ChartType.Funnel）を指定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、ファunnelチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "カテゴリ 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "カテゴリ 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "カテゴリ 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "カテゴリ 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "カテゴリ 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "カテゴリ 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **サンバーストチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータでチャートを追加し、希望するタイプ（この場合は`ChartType.SUNBURST`）を指定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、サンバーストチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branch 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Leaf4"))

    #branch 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```

### **ヒストグラムチャートを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。 
1. データを含むチャートを追加し、希望するチャートの種類（この場合は`ChartType.HISTOGRAM`）を指定します。
1. チャートデータ`IChartDataWorkbook`にアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、ヒストグラムチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **レーダーチャートを作成する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。 
1. データを含むチャートを追加し、希望するチャートの種類（この場合は`ChartType.RADAR`）を指定します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、レーダーチャートを作成する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **マルチカテゴリーチャートを作成する**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. デフォルトデータとともにチャートを追加し、希望するタイプ（ChartType.ClusteredColumn）を指定します。
1. チャートデータIChartDataWorkbookにアクセスします。
1. デフォルトの系列とカテゴリをクリアします。
1. 新しい系列とカテゴリを追加します。
1. チャート系列のために新しいチャートデータを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに書き出します。

このPythonコードは、マルチカテゴリーチャートを作成する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()

    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # 新しい系列を追加
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "系列 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # チャートでプレゼンテーションを保存
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **マップチャートを作成する**

マップチャートは、データを含むエリアの視覚化です。マップチャートは、地理的領域全体のデータや値を比較するのに最適です。

このPythonコードは、マップチャートを作成する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **組み合わせチャートを作成する**

組み合わせチャート（またはコンボチャート）は、1つのグラフ上に2つ以上のチャートを組み合わせたものです。このチャートを使用すると、2つ（またはそれ以上）のデータセットの違いを強調表示、比較、またはレビューできます。こうすることで、データセット間に関係があるかどうかを確認できます。

![combination-chart-ppt](combination-chart-ppt.png)

このPythonコードは、PowerPoint内で組み合わせチャートを作成する方法を示しています：

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "シリーズ 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "シリーズ 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "カテゴリ 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "カテゴリ 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "カテゴリ 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "シリーズ 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "シリーズ 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **チャートの更新**

1. チャートを含むプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスをインスタンス化します。
2. インデックスを通じてスライドの参照を取得します。
3. 所望のチャートを見つけるためにすべての形状を巡回します。
4. チャートデータワークシートにアクセスします。
5. 系列の値を変更することによってチャートデータ系列データを修正します。
6. 新しい系列を追加し、そのデータを入力します。
7. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このPythonコードは、チャートを更新する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # 最初のスライドを取得
    sld = pres.slides[0]

    # デフォルトデータでチャートを追加
    chart = sld.shapes[0]

    # チャートデータシートのインデックスを設定
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    fact = chart.chart_data.chart_data_workbook

    # チャートカテgory名を変更
    fact.get_cell(defaultWorksheetIndex, 1, 0, "修正されたカテゴリ 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "修正されたカテゴリ 2")

    # 最初のチャートシリーズを取得
    series = chart.chart_data.series[0]

    # 系列データを更新する
    fact.get_cell(defaultWorksheetIndex, 0, 1, "新しい_系列1")# 系列名を修正
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # 二番目のチャートシリーズを取得
    series = chart.chart_data.series[1]

    # 系列データを更新する
    fact.get_cell(defaultWorksheetIndex, 0, 2, "新しい_系列2")# 系列名を修正
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99

    # 新しい系列を追加
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "系列 3"), chart.type)

    # 第三のチャートシリーズを取得
    series = chart.chart_data.series[2]

    # 系列データをポピュレートする
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # チャートでプレゼンテーションを保存
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートのデータ範囲を設定する**

1. チャートを含むプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスをインスタンス化します。
2. インデックスを通じてスライドの参照を取得します。
3. 所望のチャートを見つけるためにすべての形状を巡回します。
4. チャートデータにアクセスし、範囲を設定します。
5. 修正されたプレゼンテーションをPPTXファイルとして書き出します。

このPythonコードは、チャートのデータ範囲を設定する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 最初のスライドを取得し、デフォルトデータでチャートを追加
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートにデフォルトマーカーを使用する**
チャートでデフォルトマーカーを使用すると、各チャートシリーズが自動的に異なるデフォルトマーカーシンボルを取得します。

このPythonコードは、チャートシリーズのマーカーを自動的に設定する方法を示しています：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "系列 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "シリーズ 2"), chart.type)
    # 二番目のチャートシリーズを取得
    series2 = chart.chart_data.series[1]

    # 系列データをポピュレートする
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```