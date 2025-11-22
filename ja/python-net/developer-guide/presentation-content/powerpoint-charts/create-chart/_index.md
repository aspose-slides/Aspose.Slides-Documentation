---
title: PythonでPowerPointプレゼンテーションのチャートを作成または更新する
linktitle: チャートを作成または更新する
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
- ファネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPointプレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでチャートを作成およびカスタマイズする方法を学びます。チャートの追加、書式設定、編集を実際の Python コード例と共に解説します。"
---

## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してチャートを作成およびカスタマイズするための包括的なガイドを提供します。スライドにプログラムでチャートを追加し、データを設定し、特定のデザイン要件に合わせてさまざまな書式設定オプションを適用する方法を学びます。記事全体で、プレゼンテーションとチャートオブジェクトの初期化からシリーズ、軸、凡例の設定まで、各手順を示す詳細なコード例が示されています。このガイドに従うことで、動的なチャート生成をアプリケーションに統合し、データ駆動型プレゼンテーションの作成プロセスを効率化する方法をしっかりと理解できます。

## **チャートの作成**

チャートは、データをすばやく視覚化し、表やスプレッドシートではすぐに分からない洞察を得るのに役立ちます。

**チャートを作成する理由**

チャートを使用すると、  

* 大量のデータを 1 つのスライドに集約、要約、凝縮できる  
* データのパターンやトレンドを明らかにできる  
* 時間や特定の測定単位に対するデータの方向性や勢いを推測できる  
* 異常値、逸脱、エラー、意味のないデータを検出できる  
* 複雑なデータを伝達または提示できる  

PowerPoint では、*Insert* 機能を使用して多数のチャートテンプレートからチャートを作成できます。Aspose.Slides を使用すると、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体は [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) 名前空間にあります。この列挙体の値はさまざまなチャートタイプに対応します。
{{% /alert %}} 

### **クラスター化縦棒グラフの作成**

このセクションでは、Aspose.Slides for Python via .NET を使用してクラスター化縦棒グラフを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、シリーズ、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順で標準的なクラスター化縦棒グラフが生成されます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.CLUSTERED_COLUMN` タイプを指定します。  
4. チャートにタイトルを追加します。  
5. チャートのデータ ワークシートにアクセスします。  
6. 既定のシリーズとカテゴリをすべてクリアします。  
7. 新しいシリーズとカテゴリを追加します。  
8. チャートシリーズ用の新しいデータを追加します。  
9. チャートシリーズに塗りつぶし色を適用します。  
10. チャートシリーズにラベルを追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはクラスター化縦棒グラフの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:

    # 最初のスライドへアクセス。
    slide = presentation.slides[0]

    # デフォルト データでクラスター化縦棒チャートを追加。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # チャートのタイトルを設定。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列に値を表示。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャート データシートのインデックスを設定。
    worksheet_index = 0

    # チャート データ ワークブックを取得。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成された系列とカテゴリを削除。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しい系列を追加。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # 新しいカテゴリを追加。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # 最初のチャート系列を取得。
    series = chart.chart_data.series[0]

    # 系列データを入力。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 系列の塗りつぶし色を設定。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 2 番目のチャート系列を取得。
    series = chart.chart_data.series[1]

    # 系列データを入力。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # 系列の塗りつぶし色を設定。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 最初のラベルにカテゴリ名を表示。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 3 番目のラベルに値を表示させるよう系列を設定。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # プレゼンテーションを PPTX ファイルとしてディスクに保存。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![クラスター化縦棒グラフ](clustered_column_chart.png)

### **散布図の作成**

散布図（散布プロットまたは XY グラフとも呼ばれます）は、2 つの変数間のパターンや相関関係を確認する際によく使用されます。

散布図を使用するケース  

* 対になった数値データがある場合  
* 2 つの変数がペアで相関しやすい場合  
* 2 変数が関連しているかどうかを判定したい場合  
* 従属変数に対して複数の独立変数の値がある場合  

この Python コードは、異なるマーカ系列を持つ散布図の作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセス。
    slide = presentation.slides[0]

    # デフォルトの散布図を作成。
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # チャート データシートのインデックスを設定。
    worksheet_index = 0

    # チャート データ ワークブックを取得。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトの系列を削除。
    chart.chart_data.series.clear()

    # 新しい系列を追加。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # 最初のチャート系列を取得。
    series = chart.chart_data.series[0]

    # 系列に新しいポイント (1:3) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # 新しいポイント (2:10) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # 系列の種類を変更。
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # チャート系列のマーカーを変更。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 2番目のチャート系列を取得。
    series = chart.chart_data.series[1]

    # 系列に新しいポイント (5:2) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # 新しいポイント (3:1) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # 新しいポイント (2:2) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # 新しいポイント (5:1) を追加。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # チャート系列のマーカーを変更。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![散布図](scatter_chart.png)

### **円グラフの作成**

円グラフは、特にカテゴリラベルに数値が紐付くデータにおいて、全体に対する部分の関係を示すのに最適です。ただし、項目やラベルが多数ある場合は、棒グラフの使用も検討してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.PIE` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. 円グラフのセクタにカスタムカラーを適用しながら新しいポイントを追加します。  
9. 系列のラベルを設定します。  
10. 系列ラベルにリーダー線を有効にします。  
11. 円グラフの回転角度を設定します。  
12. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードは円グラフの作成方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンス化。
with slides.Presentation() as presentation:

    # 最初のスライドへアクセス。
    slide = presentation.slides[0]

    # デフォルト データでチャートを追加。
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # チャートのタイトルを設定。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初の系列に値を表示。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # チャート データシートのインデックスを設定。
    worksheet_index = 0

    # チャート データ ワークブックを取得。
    workbook = chart.chart_data.chart_data_workbook

    # デフォルトで生成された系列とカテゴリを削除。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいカテゴリを追加。
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # 新しい系列を追加。
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 系列データを入力。
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # セクタの色を設定。
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # セクタの枠線を設定。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # セクタの枠線を設定。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # セクタの枠線を設定。
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 新しい系列の各カテゴリにカスタム ラベルを作成。
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # 系列にリーダーラインを表示させる。
    series.labels.default_data_label_format.show_leader_lines = True

    # 円グラフのセクタの回転角度を設定。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # プレゼンテーションを PPTX ファイルとしてディスクに保存。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![円グラフ](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（折れ線チャート）は、時間経過に伴う値の変化を示すのに最適です。折れ線グラフを使用すると、多量のデータを一度に比較し、時間に伴う変化やトレンドを追跡し、データ系列の異常をハイライトできます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.LINE` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードは折れ線グラフの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


デフォルトでは、折れ線グラフのポイントは直線で連結されます。ダッシュで結びたい場合は、以下のようにダッシュタイプを指定します:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


結果:

![折れ線グラフ](line_chart.png)

### **ツリーマップチャートの作成**

ツリーマップチャートは、販売データなどでカテゴリごとの相対サイズを示し、各カテゴリ内の大きな貢献項目に注意を引く際に最適です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.TREEMAP` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

![ツリーマップチャート](treemap_chart.png)

### **株価チャートの作成**

株価チャートは、始値・高値・安値・終値などの金融データを表示し、市場のトレンドや変動性を分析するのに役立ちます。投資家やアナリストが情報に基づいた意思決定を行うための重要な洞察を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.OPEN_HIGH_LOW_CLOSE` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. HiLowLines の書式を指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

![株価チャート](stock_chart.png)

### **箱ひげ図の作成**

箱ひげ図は、中央値、四分位、外れ値などの統計指標を要約してデータの分布を示します。探索的データ分析や統計的研究で、データの変動性や異常を迅速に把握するのに便利です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.BOX_AND_WHISKER` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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


### **ファネルチャートの作成**

ファネルチャートは、段階的にデータ量が減少するプロセスを可視化し、転換率の分析やボトルネックの特定、販売・マーケティングプロセスの効率測定に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.FUNNEL` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはファネルチャートの作成方法を示しています:
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

![ファネルチャート](funnel_chart.png)

### **サンバーストチャートの作成**

サンバーストチャートは階層データを同心円状に表現し、部分と全体の関係を示します。入れ子になったカテゴリやサブカテゴリをコンパクトに可視化するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.SUNBURST` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

![サンバーストチャート](sunburst_chart.png)

### **ヒストグラムチャートの作成**

ヒストグラムチャートは、数値データを範囲（ビン）に分割して分布を表現し、頻度や歪み、広がり、外れ値の検出に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.HISTOGRAM` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

![ヒストグラムチャート](histogram_chart.png)

### **レーダーチャートの作成**

レーダーチャートは多変量データを二次元で表現し、複数の変数を同時に比較できるようにします。パフォーマンス指標や属性の強み・弱みを把握するのに有用です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.RADAR` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはレーダーチャートの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![レーダーチャート](radar_chart.png)

### **マルチカテゴリチャートの作成**

マルチカテゴリチャートは、複数のカテゴリ グループを同時に表示し、複雑な多層データセットのトレンドや関係を比較するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルトデータでチャートを追加し、`ChartType.CLUSTERED_COLUMN` タイプを指定します。  
4. チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスします。  
5. 既定のシリーズとカテゴリをクリアします。  
6. 新しいシリーズとカテゴリを追加します。  
7. チャートシリーズ用の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

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

![マルチカテゴリチャート](multi_category_chart.png)

### **マップチャートの作成**

マップチャートは国、州、都市などの特定の場所に情報をマッピングして地理データを可視化します。地域別トレンドや人口統計、空間分布を分かりやすく示すのに役立ちます。

この Python コードはマップチャートの作成方法を示しています:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![マップチャート](map_chart.png)

### **コンビネーションチャートの作成**

コンビネーションチャート（コンボチャート）は、2 つ以上のチャートタイプを 1 つのグラフに組み合わせたものです。異なるデータセット間の違いをハイライト、比較、検証でき、相互の関係性を把握しやすくします。

![コンビネーションチャート](combination_chart.png)

この Python コードは PowerPoint プレゼンテーション内にコンビネーションチャートを作成する方法を示しています:
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

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

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **チャートの更新**

Aspose.Slides for Python via .NET を使用すると、チャート データ、書式設定、スタイリングを変更して PowerPoint のチャートを更新できます。この機能により、プレゼンテーションを動的コンテンツで最新の状態に保ち、チャートが現在のデータとビジュアル基準を正確に反映するようにできます。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査してチャートを検索します。  
4. チャートのデータ ワークシートにアクセスします。  
5. 系列値を変更してチャート データ シリーズを修正します。  
6. 新しい系列を追加し、そのデータを入力します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはチャートの更新方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX ファイルを表す Presentation クラスのインスタンス化。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 最初のスライドにアクセス。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # チャート データシートのインデックスを設定。
            worksheet_index = 0

            # チャート データ ワークブックを取得。
            workbook = chart.chart_data.chart_data_workbook

            # チャートのカテゴリ名を変更。
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # 最初のチャート系列を取得。
            series = chart.chart_data.series[0]

            # 系列データを更新。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # 系列名を変更。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 2 番目のチャート系列を取得。
            series = chart.chart_data.series[1]

            # 系列データを更新。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # 系列名を変更。
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # 新しい系列を追加。
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # 系列データを入力。
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # チャート付きプレゼンテーションを保存。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **チャートのデータ範囲設定**

Aspose.Slides for Python via .NET は、ワークシートの特定範囲をチャート データのソースとして定義する柔軟性を提供します。これにより、ワークシートの一部をチャートに直接マッピングし、どのセルが系列やカテゴリに寄与するかを制御できます。その結果、ワークシートの最新データに合わせてチャートを簡単に更新・同期でき、PowerPoint プレゼンテーションが常に正確な情報を反映します。

1. チャートを含むプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査してチャートを検索します。  
4. チャート データを取得し、範囲を設定します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。  

この Python コードはチャートのデータ範囲を設定する方法を示しています:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# PPTX ファイルを表す Presentation クラスのインスタンス化。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 最初のスライドにアクセス。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **チャートのデフォルト マーカー使用**

チャートでデフォルト マーカーを使用すると、各系列に自動的に異なるデフォルト マーカー シンボルが割り当てられます。

この Python コードは系列マーカーを自動的に設定する方法を示しています:
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

**Aspose.Slides for Python via .NET がサポートするチャート タイプは何ですか？**

Aspose.Slides for Python via .NET は、棒グラフ、折れ線グラフ、円グラフ、エリア グラフ、散布図、ヒストグラム、レーダー グラフなど、幅広いチャート タイプをサポートします。この柔軟性により、データ可視化のニーズに最適なチャートを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

まず [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドを取得し、チャート追加メソッドを呼び出してチャート タイプと初期データを指定します。これにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されるデータを更新するには？**

チャートのデータ ワークブック ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) にアクセスし、既定の系列とカテゴリをクリアしてからカスタム データを追加します。これにより、最新データを反映するようにプログラムでチャートをリフレッシュできます。

**チャートの外観をカスタマイズできますか？**

はい。Aspose.Slides for Python via .NET は豊富なカスタマイズ オプションを提供します。色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせて調整できます。