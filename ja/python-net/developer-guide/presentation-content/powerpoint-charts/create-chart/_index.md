---
title: PythonでPowerPointプレゼンテーションのチャートを作成または更新
linktitle: チャートを作成または更新
type: docs
weight: 10
url: /ja/python-net/create-chart/
keywords:
- チャートを追加
- チャートを作成
- チャートを編集
- チャートを変更
- チャートを更新
- 散布図
- 円グラフ
- 折れ線グラフ
- ツリーマップチャート
- 株価チャート
- 箱ひげ図
- ファンネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPointプレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションでチャートを作成およびカスタマイズする方法を学びます。プレゼンテーションにチャートを追加、書式設定、編集する方法を、Python の実用的なコード例とともに解説します。"
---

## **概要**

本記事では、Aspose.Slides for Python via .NET を使用してチャートを作成およびカスタマイズする方法について包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを入力し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャートオブジェクトの初期化から、系列、軸、凡例の構成まで、各ステップを示す詳細なコード例が掲載されています。このガイドに従うことで、動的なチャート生成をアプリケーションに統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法を確実に理解できます。

## **チャートの作成**

チャートは、データをすばやく可視化し、テーブルやスプレッドシートからはすぐには分からない洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、次のことが可能です。

* 大量のデータをプレゼンテーション内の単一スライドに集約、圧縮、要約できる；
* データのパターンやトレンドを明らかにできる；
* 時間の経過や特定の測定単位に対するデータの方向性と勢いを推測できる；
* 外れ値、異常、偏差、エラー、意味のないデータを発見できる；
* 複雑なデータを伝達またはプレゼンテーションできる。

PowerPoint では、*挿入* 機能を使用して多数のテンプレートからチャートを作成できます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく通常のチャートと、カスタムチャートの両方を作成できます。

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体は、[Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) 名前空間の下にあります。この列挙体の値は、さまざまなチャートタイプに対応しています。  
{{% /alert %}} 

### **クラスター化列チャートの作成**

このセクションでは、Aspose.Slides for Python via .NET を使用してクラスター化列チャートを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化列チャートが生成される様子をご確認ください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを指定し、`ChartType.CLUSTERED_COLUMN` タイプでチャートを追加します。  
1. チャートにタイトルを追加します。  
1. チャートのデータワークシートにアクセスします。  
1. すべてのデフォルト系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 系列に塗りつぶし色を適用します。  
1. 系列にラベルを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはクラスター化列チャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトデータを持つクラスター化列チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # チャートのタイトルを設定します。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列に値を表示するよう設定します。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャートデータシートのインデックスを設定します。
    worksheet_index = 0

    # チャートデータのワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成された系列とカテゴリを削除します。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しい系列を追加します。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # 最初のチャート系列を取得します。
    series = chart.chart_data.series[0]

    # 系列データを入力します。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 系列の塗りつぶし色を設定します。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 2 番目のチャート系列を取得します。
    series = chart.chart_data.series[1]

    # 系列データを入力します。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # 系列の塗りつぶし色を設定します。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 最初のラベルにカテゴリ名を表示するよう設定します。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 3 番目のラベルに値を表示するよう系列を設定します。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Clustered Column chart](clustered_column_chart.png)

### **散布図チャートの作成**

散布図（散布プロットまたは x-y グラフとも呼ばれる）は、2 つの変数間のパターンや相関関係を確認する際に使用されます。

散布図を使用する場面:

* ペアになった数値データがあるとき。  
* 2 つの変数が相互に関連しているとき。  
* 2 つの変数が関係しているかどうかを判定したいとき。  
* 従属変数に対して複数の値を持つ独立変数があるとき。

この Python コードは、異なるマーカー系列を持つ散布図の作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトの散布図チャートを作成します。
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # チャートデータシートのインデックスを設定します。
    worksheet_index = 0

    # チャートデータのワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトの系列を削除します。
    chart.chart_data.series.clear()

    # 新しい系列を追加します。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # 最初のチャート系列を取得します。
    series = chart.chart_data.series[0]

    # 系列に新しいポイント (1:3) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # 新しいポイント (2:10) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # 系列のタイプを変更します。
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # チャート系列のマーカーを変更します。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 2 番目のチャート系列を取得します。
    series = chart.chart_data.series[1]

    # チャート系列に新しいポイント (5:2) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # 新しいポイント (3:1) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # 新しいポイント (2:2) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # 新しいポイント (5:1) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # チャート系列のマーカーを変更します。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Scatter chart](scatter_chart.png)

### **円グラフの作成**

円グラフは、データの全体に対する部分の関係を示すのに最適です。特に、カテゴリラベルと数値が対応している場合に有用です。ただし、要素やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.PIE` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. チャートに新しいポイントを追加し、円グラフのセクターにカスタムカラーを適用します。  
1. 系列のラベルを設定します。  
1. 系列ラベルにリーダーラインを有効にします。  
1. 円グラフの回転角度を設定します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは円グラフの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトデータを持つチャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # チャートのタイトルを設定します。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列に値を表示するよう設定します。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャートデータシートのインデックスを設定します。
    worksheet_index = 0

    # チャートデータのワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成された系列とカテゴリを削除します。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # 新しい系列を追加します。
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 系列データを入力します。
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # セクタの色を設定します。
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # セクタの枠線を設定します。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # セクタの枠線を設定します。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # セクタの枠線を設定します。
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 新しい系列の各カテゴリにカスタムラベルを作成します。
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # 系列にリーダーラインを表示するよう設定します。
    series.labels.default_data_label_format.show_leader_lines = True

    # 円グラフのセクタの回転角度を設定します。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Pie chart](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（ライン グラフ）は、時間経過に伴う値の変化を示すのに最適です。大量のデータを一度に比較したり、時間軸に沿った変化やトレンドを追跡したり、データ系列の異常をハイライトしたりすることができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.LINE` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは折れ線グラフの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


デフォルトでは、折れ線グラフのポイントは直線で連結されます。破線で結びたい場合は、以下のように破線タイプを指定できます:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


結果:

![The Line chart](line_chart.png)

### **ツリーマップチャートの作成**

ツリーマップチャートは、売上データなどでカテゴリごとの相対的なサイズを示し、各カテゴリ内で大きな貢献をしている項目に注目させるのに最適です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.TREEMAP` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはツリーマップチャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # ブランチ 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # ブランチ 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Treemap chart](treemap_chart.png)

### **株価チャートの作成**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場のトレンドやボラティリティを分析するのに役立ちます。投資家やアナリストが情報に基づいた意思決定を行うための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.OPEN_HIGH_LOW_CLOSE` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. HiLowLines の書式を指定します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは株価チャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Stock chart](stock_chart.png)

### **箱ひげ図の作成**

箱ひげ図は、中央値、四分位数、外れ値などの主要な統計指標を要約してデータの分布を表示します。探索的データ分析や統計的研究で、データの変動性や異常を迅速に把握するのに非常に有用です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.BOX_AND_WHISKER` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは箱ひげ図の作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **ファンネルチャートの作成**

ファンネルチャートは、プロセスの各段階でデータ量が減少する様子を可視化します。コンバージョン率の分析、ボトルネックの特定、販売やマーケティングプロセスの効率追跡に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.FUNNEL` タイプのチャートを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはファンネルチャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Funnel chart](funnel_chart.png)

### **サンバーストチャートの作成**

サンバーストチャートは階層データを同心円状のリングで表現し、部分と全体の関係を示します。入れ子構造のカテゴリやサブカテゴリをコンパクトに視覚化するのに最適です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.SUNBURST` タイプのチャートを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはサンバーストチャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # ブランチ 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # ブランチ 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Sunburst chart](sunburst_chart.png)

### **ヒストグラムチャートの作成**

ヒストグラムは数値データを範囲（ビン）に分けて分布を示します。頻度、偏り、広がりなどのパターンや外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを指定して `ChartType.HISTOGRAM` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはヒストグラムチャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Histogram chart](histogram_chart.png)

### **レーダーチャートの作成**

レーダーチャートは多変量データを二次元で表現し、複数の変数を同時に比較できます。パフォーマンス指標や属性の強み・弱みを特定するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データを指定して `ChartType.RADAR` タイプのチャートを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはレーダーチャートの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Radar chart](radar_chart.png)

### **マルチカテゴリチャートの作成**

マルチカテゴリチャートは、複数のカテゴリグループにまたがるデータを同時に比較できるため、複雑な多層データセットのトレンドや関係を分析する際に有用です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. デフォルトデータで `ChartType.CLUSTERED_COLUMN` タイプのチャートを追加します。  
1. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. デフォルトの系列とカテゴリをクリアします。  
1. 新しい系列とカテゴリを追加します。  
1. 系列用の新しいチャートデータを追加します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはマルチカテゴリチャートの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # 系列を追加します。
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # チャートを含むプレゼンテーションを保存します。
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The multi category chart](multi_category_chart.png)

### **マップチャートの作成**

マップチャートは、国・州・市などの地理的領域に情報をマッピングし、地域ごとのトレンドや人口統計、空間分布を視覚的に分析できます。

この Python コードはマップチャートの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![The Map chart](map_chart.png)

### **組み合わせチャートの作成**

組み合わせチャート（コンボチャート）は、単一グラフ内に2つ以上のチャートタイプを組み合わせます。これにより、複数データセット間の違いや関係をハイライト、比較、検証できます。

![The combination chart](combination_chart.png)

以下の Python コードは、上記の組み合わせチャートを PowerPoint プレゼンテーションに作成する方法を示しています:
```python
def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # チャートのタイトルを設定します。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # チャートの凡例を設定します。
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # デフォルトで生成された系列とカテゴリを削除します。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # 最初のシリーズを追加します。
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # 水平軸を設定します。
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # 垂直軸を設定します。
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # 垂直の主要グリッドラインの色を設定します。
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # セカンダリ水平軸を設定します。
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # セカンダリ垂直軸を設定します。
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```


## **チャートの更新**

Aspose.Slides for Python via .NET を使用すると、チャートデータ、書式設定、スタイルを変更して PowerPoint のチャートを更新できます。この機能により、プレゼンテーションを動的コンテンツで最新の状態に保ち、チャートが現在のデータとビジュアル基準を正確に反映できるようになります。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータワークシートにアクセスします。  
1. 系列の値を変更してチャートデータ系列を修正します。  
1. 新しい系列を追加し、そのデータを入力します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはチャートの更新方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # チャートデータシートのインデックスを設定します。
            worksheet_index = 0

            # チャートデータのワークブックを取得します。
            workbook = chart.chart_data.chart_data_workbook

            # チャートのカテゴリ名を変更します。
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # 最初のチャート系列を取得します。
            series = chart.chart_data.series[0]

            # 系列データを更新します。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # 系列名を変更します。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 2 番目のチャート系列を取得します。
            series = chart.chart_data.series[1]

            # 系列データを更新します。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # 系列名を変更します。
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # 新しい系列を追加します。
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # 系列データを入力します。
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # チャートを含むプレゼンテーションを保存します。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **チャートのデータ範囲設定**

Aspose.Slides for Python via .NET では、ワークシートの特定範囲をチャートデータのソースとして定義できます。これにより、ワークシートの一部をチャートにマッピングし、どのセルが系列やカテゴリに寄与するかを制御できます。その結果、ワークシートの最新データ変更に合わせてチャートを簡単に更新・同期でき、PowerPoint プレゼンテーションが常に正確な情報を反映します。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートデータにアクセスし、範囲を設定します。  
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Python コードはチャートのデータ範囲設定方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

    # PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
    with slides.Presentation("ExistingChart.pptx") as presentation:

        # 最初のスライドにアクセスします。
        slide = presentation.slides[0]

        for shape in slide.shapes:
            if isinstance(shape, charts.Chart) and shape.name == chart_name:
                chart = shape
                chart.chart_data.set_range("Sheet1!A1:B4")

        presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **チャートのデフォルトマーカー使用**

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるデフォルトマーカー記号が割り当てられます。

この Python コードは、系列マーカーを自動的に設定する方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # 系列データを入力します。
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Aspose.Slides for Python via .NET がサポートするチャートタイプは何ですか？**

Aspose.Slides for Python via .NET は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなど、幅広いチャートタイプをサポートします。この柔軟性により、データ可視化のニーズに最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。次に、チャートタイプと初期データを指定してチャート追加メソッドを呼び出します。これにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスし、デフォルトの系列とカテゴリをクリアしてから、独自のデータを追加します。これにより、最新データを反映するようにプログラムでチャートを更新できます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for Python via .NET は豊富なカスタマイズオプションを提供します。色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。
