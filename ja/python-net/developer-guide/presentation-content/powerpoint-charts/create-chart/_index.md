---
title: Python で PowerPoint プレゼンテーションのチャートを作成または更新
linktitle: チャートの作成または更新
type: docs
weight: 10
url: /ja/python-net/create-chart/
keywords:
  - チャートの追加
  - チャートの作成
  - チャートの編集
  - チャートの変更
  - チャートの更新
  - 散布図
  - 円グラフ
  - 折れ線グラフ
  - ツリーマップグラフ
  - 株価チャート
  - 箱ひげ図
  - ファンネルチャート
  - サンバーストチャート
  - ヒストグラムチャート
  - レーダーチャート
  - マルチカテゴリチャート
  - PowerPoint プレゼンテーション
  - Python
  - Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでチャートを作成およびカスタマイズする方法を学びます。プレゼンテーションにチャートを追加、書式設定、編集する方法を、Python の実用的なコード例とともに解説します。"
---
## **概要**

本記事では、Aspose.Slides for Python via .NET を使用してチャートを作成およびカスタマイズする方法を説明します。スライドにチャートを追加し、データを設定し、デザイン要件に合わせて書式設定する方法を学べます。コード例には、プレゼンテーションとチャートの作成、シリーズ・軸・凡例の設定、アプリケーションへのチャート生成の統合が含まれています。

## **チャートの作成**

チャートは、データをすばやく可視化し、テーブルやスプレッドシートからはすぐに分からない洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、次のことができます。

* 大量のデータを 1 つのスライドに集約、要約、凝縮できる。
* データのパターンやトレンドを明らかにできる。
* 時間経過や特定の測定単位に対するデータの方向性や勢いを推測できる。
* 外れ値、異常、偏差、エラー、意味不明なデータを検出できる。
* 複雑なデータを効果的に伝達・提示できる。

PowerPoint では、*Insert* 機能を使って多種多様なテンプレートからチャートを作成できます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートと、独自のカスタムチャートの両方を作成できます。

{{% alert color="info" title="Note" %}}
[ChartType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/charttype/) 列挙体は、[Aspose.Slides.Charts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/) 名前空間にあります。この列挙体の値は、さまざまなチャートタイプに対応しています。
{{% /alert %}}

### **クラスター化縦棒グラフの作成**

このセクションでは、Aspose.Slides for Python via .NET を使用してクラスター化縦棒グラフを作成する方法を説明します。プレゼンテーションを初期化し、チャートを追加し、タイトル、データ、シリーズ、カテゴリ、スタイルなどの要素をカスタマイズする手順を学びます。以下の手順で標準的なクラスター化縦棒グラフが生成されます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.CLUSTERED_COLUMN` を指定します。  
1. チャートにタイトルを追加します。  
1. チャートのデータ ワークシートにアクセスします。  
1. 既定のシリーズとカテゴリをすべてクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. チャートシリーズに塗りつぶし色を適用します。  
1. チャートシリーズにラベルを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、クラスター化縦棒グラフの作成方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルト データでクラスター化縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # チャートのタイトルを設定します。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # チャート データ シートのインデックスを設定します。
    worksheet_index = 0

    # チャート データ ワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成されたシリーズとカテゴリを削除します。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいシリーズを追加します。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # 最初のチャートシリーズを取得します。
    series = chart.chart_data.series[0]

    # シリーズ データを入力します。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # シリーズの塗りつぶし色を設定します。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 2 番目のチャートシリーズを取得します。
    series = chart.chart_data.series[1]

    # シリーズ データを入力します。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # シリーズの塗りつぶし色を設定します。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 最初のラベルにカテゴリ名を表示するよう設定します。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 3 番目のラベルに値を表示するようシリーズを設定します。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The clustered column chart](clustered_column_chart.png)

### **散布図の作成**

散布図（スキャッタープロットまたは x‑y グラフ）は、2 つの変数間のパターンや相関関係を確認する際に使用されます。

散布図を使用するシーン:

* 数値データがペアになっている場合。  
* 2 つの変数が相関しやすい場合。  
* 2 変数が関連しているかどうかを判定したい場合。  
* 従属変数に対して複数の独立変数の値がある場合。

この Python コードは、シリーズごとに異なるマーカーを使用した散布図の作成方法を示しています。

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

    # チャート データ シートのインデックスを設定します。
    worksheet_index = 0

    # チャート データ ワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトのシリーズを削除します。
    chart.chart_data.series.clear()

    # 新しいシリーズを追加します。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # 最初のチャートシリーズを取得します。
    series = chart.chart_data.series[0]

    # シリーズに新しいポイント (1:3) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # 新しいポイント (2:10) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # シリーズのタイプを変更します。
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # チャートシリーズのマーカーを変更します。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 2 番目のチャートシリーズを取得します。
    series = chart.chart_data.series[1]

    # チャートシリーズに新しいポイント (5:2) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # 新しいポイント (3:1) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # 新しいポイント (2:2) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # 新しいポイント (5:1) を追加します。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # チャートシリーズのマーカーを変更します。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The scatter chart](scatter_chart.png)

### **円グラフの作成**

円グラフは、特にカテゴリ ラベルと数値が紐付くデータで、全体に対する割合を示すのに最適です。ただし、項目やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.PIE` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. チャートのポイントを追加し、円グラフのセクターにカスタム 色を適用します。  
1. シリーズのラベルを設定します。  
1. ラベル用のリーダー 線を有効にします。  
1. 円グラフの回転角度を設定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、円グラフの作成方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルト データでチャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # チャートのタイトルを設定します。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # チャート データ シートのインデックスを設定します。
    worksheet_index = 0

    # チャート データ ワークブックを取得します。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成されたシリーズとカテゴリを削除します。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # 新しいシリーズを追加します。
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # シリーズ データを入力します。
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # セクターの色を設定します。
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # セクターの枠線を設定します。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # セクターの枠線を設定します。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # セクターの枠線を設定します。
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 新しいシリーズの各カテゴリにカスタムラベルを作成します。
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # シリーズのラベルにリーダー ラインを表示するよう設定します。
    series.labels.default_data_label_format.show_leader_lines = True

    # 円グラフのセクターの回転角度を設定します。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The pie chart](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（ライン グラフ）は、時間経過に伴う値の変化を示すのに適しています。折れ線グラフを使用すると、大量のデータを同時に比較し、トレンドを追跡し、データ系列の異常を強調表示できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.LINE` を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、折れ線グラフの作成方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

デフォルトでは、折れ線グラフのポイントは直線で結ばれます。ダッシュ線で結びたい場合は、次のようにダッシュ タイプを指定できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The line chart](line_chart.png)

### **ツリーマップ グラフの作成**

ツリーマップ グラフは、売上データでカテゴリごとの相対的なサイズを示し、各カテゴリ内で大きな貢献度を持つ項目に注目させるのに最適です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.TREEMAP` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ツリーマップ グラフの作成方法を示しています。

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

![The treemap chart](treemap_chart.png)

### **株価チャートの作成**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場トレンドや変動性の分析に役立ちます。投資家やアナリストが情報に基づいた意思決定を行うための重要なインサイトを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.OPEN_HIGH_LOW_CLOSE` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. 高低線の書式を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、株価チャートの作成方法を示しています。

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

![The stock chart](stock_chart.png)

### **箱ひげ図の作成**

箱ひげ図は、中央値・四分位数・外れ値などの統計指標でデータ分布を要約し、データの変動性や異常を迅速に把握するのに適しています。探索的データ分析や統計的研究で広く利用されます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.BOX_AND_WHISKER` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、箱ひげ図の作成方法を示しています。

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

### **ファンネル チャートの作成**

ファンネル チャートは、段階的にデータ量が減少していくプロセスを可視化し、コンバージョン率の分析やボトルネックの特定、販売やマーケティングの効率測定に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.FUNNEL` を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ファンネル チャートの作成方法を示しています。

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

![The funnel chart](funnel_chart.png)

### **サンバースト チャートの作成**

サンバースト チャートは階層データを同心円状に表現し、全体に対する部分の関係をコンパクトに示します。入れ子構造のカテゴリやサブカテゴリを視覚的に把握するのに最適です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.SUNBURST` を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、サンバースト チャートの作成方法を示しています。

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

![The sunburst chart](sunburst_chart.png)

### **ヒストグラム チャートの作成**

ヒストグラムは数値データをビン（区間）に分けて分布を表現し、頻度・歪み・散布などのパターンや外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.HISTOGRAM` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズを追加し、データ ポイントで埋めます。ヒストグラムにはカテゴリがなく、ビンは値から自動計算されます。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、ヒストグラム チャートの作成方法を示しています。

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

![The histogram chart](histogram_chart.png)

### **レーダー チャートの作成**

レーダー チャートは多変量データを二次元で表現し、複数の変数を同時に比較できるため、パフォーマンス指標や属性間の強み・弱みを把握するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. データを含むチャートを追加し、`ChartType.RADAR` を指定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、レーダー チャートの作成方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The radar chart](radar_chart.png)

### **マルチカテゴリ チャートの作成**

マルチカテゴリ チャートは、複数のカテゴリ グループを同時に表示し、複数次元にわたる値の比較を可能にします。複雑で多層的なデータセットのトレンドや関係性を分析する際に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. デフォルト データでチャートを追加し、`ChartType.CLUSTERED_COLUMN` を指定します。  
1. チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
1. 既定のシリーズとカテゴリをクリアします。  
1. 新しいシリーズとカテゴリを追加します。  
1. チャートシリーズの新しいデータを追加します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、マルチカテゴリ チャートの作成方法を示しています。

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

    # シリーズを追加します。
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

![The multi-category chart](multi_category_chart.png)

### **マップ チャートの作成**

マップ チャートは、国・州・都市などの特定の場所にデータをマッピングし、地域別トレンドや人口統計、空間分布を視覚的に分析するのに適しています。

この Python コードは、マップ チャートの作成方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![The map chart](map_chart.png)

### **複合チャートの作成**

複合チャート（コンボ チャート）は、1 つのグラフ内に 2 種類以上のチャートタイプを組み合わせます。これにより、複数データセット間の関係や差異を強調・比較できます。

![The combination chart](combination_chart.png)

以下の Python コードは、上図の複合チャートを PowerPoint プレゼンテーションに作成する方法を示しています。

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

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

    # デフォルトで生成されたシリーズとカテゴリを削除します。
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

    # 垂直軸の主要グリッド線の色を設定します。
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

Aspose.Slides for Python via .NET を使用すれば、チャートのデータ、書式設定、スタイルを更新して PowerPoint プレゼンテーションを最新の状態に保つことができます。

1. チャートを含むプレゼンテーションを開くために、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャートのデータ ワークシートにアクセスします。  
1. シリーズの値を変更してデータ シリーズを更新します。  
1. 新しいシリーズを追加し、データを入力します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、チャートの更新方法を示しています。

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

            # チャート データ シートのインデックスを設定します。
            worksheet_index = 0

            # チャート データ ワークブックを取得します。
            workbook = chart.chart_data.chart_data_workbook

            # チャートのカテゴリ名を変更します。
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # 最初のチャートシリーズを取得します。
            series = chart.chart_data.series[0]

            # シリーズ データを更新します。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # シリーズ名を変更しています。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 2 番目のチャートシリーズを取得します。
            series = chart.chart_data.series[1]

            # シリーズ データを更新します。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # シリーズ名を変更しています。
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # 新しいシリーズを追加します。
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # シリーズ データを入力します。
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # チャートを含むプレゼンテーションを保存します。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートのデータ範囲の設定**

Aspose.Slides for Python via .NET では、特定のワークシート範囲をチャートのデータ ソースとして使用できます。これにより、どのセルがシリーズやカテゴリに使用されるかを制御し、ワークシートの変更をチャートに反映させることが可能です。

1. チャートを含むプレゼンテーションを開くために、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. すべてのシェイプを走査してチャートを見つけます。  
1. チャート データにアクセスし、範囲を設定します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、チャートのデータ範囲を設定する方法を示しています。

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

## **チャートでデフォルト マーカーを使用する**

デフォルトのマーカーを使用すると、各シリーズに自動的に異なるマーカー記号が割り当てられます。

この Python コードは、シリーズのマーカーを自動設定する方法を示しています。

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

    # シリーズ データを入力します。
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

Aspose.Slides for Python via .NET は、棒、折れ線、円、領域、散布図、ヒストグラム、レーダーなど、幅広いチャートタイプに対応しています。これにより、データ可視化のニーズに最適なチャートを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得します。その後、チャートを追加するメソッドを呼び出し、チャートタイプと初期データを指定します。これにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータ ワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスし、既定のシリーズとカテゴリをクリアしてからカスタム データを追加します。これにより、プログラムから最新データにリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for Python via .NET は、色、フォント、ラベル、凡例など、書式設定要素を幅広くカスタマイズできる機能を提供しています。これにより、デザイン要件に合わせてチャートの見た目を自由に調整できます。