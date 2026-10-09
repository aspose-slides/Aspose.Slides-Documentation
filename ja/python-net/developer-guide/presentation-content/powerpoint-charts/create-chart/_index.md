---
title: PythonでPowerPointプレゼンテーションのチャートを作成または更新
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
- 散布図チャート
- 円グラフ
- 折れ線グラフ
- ツリーマップチャート
- 株価チャート
- 箱ひげ図チャート
- ファンネルチャート
- サンバーストチャート
- ヒストグラムチャート
- レーダーチャート
- マルチカテゴリチャート
- PowerPointプレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションでチャートを作成およびカスタマイズする方法を学びます。プレゼンテーション内でのチャートの追加、書式設定、編集を、Python の実用的なコード例とともに解説しています。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してチャートを作成およびカスタマイズする方法を説明します。スライドにチャートを追加し、データを入力し、デザイン要件に合わせて書式設定する方法を学びます。コード例では、プレゼンテーションとチャートの作成、系列、軸、凡例の設定、そしてアプリケーションへのチャート生成の統合について扱っています。

## **チャートの作成**

チャートは、データをすばやく可視化し、表やスプレッドシートだけではすぐに分からない洞察を得るのに役立ちます。

**チャートを作成する理由**

* プレゼンテーションの1枚のスライドに大量のデータを集約、凝縮、要約する  
* データのパターンやトレンドを明らかにする  
* 時間経過や特定の測定単位に対するデータの方向性や勢いを推測する  
* 外れ値、異常、偏差、エラー、意味のないデータを検出する  
* 複雑なデータを伝える、または提示する  

PowerPoint では、*挿入* 機能を使用してチャートを作成でき、さまざまなタイプのチャートを設計するためのテンプレートが提供されます。Aspose.Slides を使用すれば、一般的なチャートタイプに基づく標準チャートとカスタムチャートの両方を作成できます。

{{% alert color="info" title="Note" %}}
[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体は [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) 名前空間の下にあります。この列挙体の値はさまざまなチャートタイプに対応しています。
{{% /alert %}}

### **クラスター化列チャートの作成**

このセクションでは、Aspose.Slides for Python via .NET を使用してクラスター化列チャートを作成する方法を説明します。プレゼンテーションの初期化、チャートの追加、タイトル、データ、系列、カテゴリ、スタイリングなどの要素のカスタマイズ方法を学びます。以下の手順に従って、標準的なクラスター化列チャートがどのように生成されるかを確認してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.CLUSTERED_COLUMN` タイプを指定します。  
4. チャートにタイトルを追加します。  
5. チャートのデータワークシートにアクセスします。  
6. デフォルトの系列とカテゴリをすべてクリアします。  
7. 新しい系列とカテゴリを追加します。  
8. チャート系列の新しいデータを追加します。  
9. チャート系列に塗りつぶしカラーを適用します。  
10. チャート系列にラベルを追加します。  
11. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルト データでクラスター化列チャートを追加します。
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

    # 最初のラベルにカテゴリ名を表示します。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 系列の 3 番目のラベルに値を表示します。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![クラスター化列チャート](clustered_column_chart.png)

### **散布図チャートの作成**

散布図（散布プロットまたは x‑y グラフとも呼ばれます）は、2 つの変数間のパターンを確認したり相関関係を示したりするために使用されます。

散布図を使用すべき状況は次のとおりです。

* 数値データがペアで存在する場合。  
* 相互に関連性の高い 2 つの変数がある場合。  
* 2 変数が関連しているかどうかを判断したい場合。  
* 従属変数に対して複数の値を持つ独立変数がある場合。

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

    # デフォルト系列を削除します。
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

![散布図](scatter_chart.png)

### **円グラフの作成**

円グラフは、データの全体に対する構成比を示すのに最適です。特に、カテゴリラベルと数値が対応する場合に有効です。ただし、構成要素やラベルが多数ある場合は、棒グラフの使用を検討してください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.PIE` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. チャートに新しいポイントを追加し、円グラフのセクタにカスタムカラーを適用します。  
9. 系列のラベルを設定します。  
10. 系列ラベルにリーダー線を有効にします。  
11. 円グラフの回転角度を設定します。  
12. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

    # セクタの境界線を設定します。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # セクタの境界線を設定します。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # セクタの境界線を設定します。
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

    # 系列にリーダー ラインを表示するよう設定します。
    series.labels.default_data_label_format.show_leader_lines = True

    # 円グラフのセクタの回転角度を設定します。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # プレゼンテーションを PPTX ファイルとしてディスクに保存します。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![円グラフ](pie_chart.png)

### **折れ線グラフの作成**

折れ線グラフ（折れ線プロットとも呼ばれます）は、時間経過に伴う値の変化を示したい場合に最適です。折れ線グラフを使用すると、膨大なデータを一度に比較し、時間経過による変化やトレンドを追跡し、データ系列の異常をハイライトすることなどが可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.LINE` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

デフォルトでは、折れ線グラフのポイントは直線で連結されます。ポイントを破線で結びたい場合は、以下のように希望の破線タイプを指定できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![折れ線グラフ](line_chart.png)

### **ツリーマップチャートの作成**

ツリーマップチャートは、データカテゴリの相対的なサイズを示し、各カテゴリ内で大きく寄与する項目にすばやく注目させたい販売データに最適です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.TREEMAP` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

株価チャートは、始値・高値・安値・終値といった金融データを表示し、市場のトレンドや変動性を分析するのに役立ちます。これらのチャートは、株式のパフォーマンスに関する重要な洞察を提供し、投資家やアナリストが情報に基づいた意思決定を行うのを支援します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.OPEN_HIGH_LOW_CLOSE` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 高低線の書式を指定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

箱ひげ図は、データの分布を表示し、中央値、四分位数、外れ値などの主要な統計指標を要約します。探索的データ分析や統計研究で、データの変動性や異常を迅速に把握するのに役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.BOX_AND_WHISKER` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

ファンネルチャートは、プロセスの段階的な減少を視覚化する際に使用され、各ステップでデータ量がどれだけ減少するかを示します。コンバージョン率の分析、ボトルネックの特定、販売やマーケティングプロセスの効率追跡に特に有用です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.FUNNEL` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

![ファンネルチャート](funnel_chart.png)

### **サンバーストチャートの作成**

サンバーストチャートは階層データを同心円状のリングで表現し、部分と全体の関係を示します。複数レベルのカテゴリやサブカテゴリをコンパクトに表示するのに適しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.SUNBURST` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

ヒストグラムチャートは、数値データを範囲（ビン）に分割して分布を示します。頻度、歪み、広がりなどのパターンや外れ値の検出に特に有用です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.HISTOGRAM` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列を追加し、データポイントで入力します。ヒストグラムにはカテゴリがなく、ビンは値から自動計算されます。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

レーダーチャートは、多変量データを二次元で表示し、複数変数を同時に比較できるようにします。パフォーマンス指標や属性のパターン、強み、弱みの把握に役立ちます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むチャートを追加し、`ChartType.RADAR` タイプを指定します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![レーダーチャート](radar_chart.png)

### **マルチカテゴリチャートの作成**

マルチカテゴリチャートは、複数のカテゴリグループを同時に比較できるようにし、複雑な多層データセットのトレンドや関係性を分析する際に便利です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. デフォルト データでチャートを追加し、`ChartType.CLUSTERED_COLUMN` タイプを指定します。  
4. チャートのデータワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスします。  
5. デフォルトの系列とカテゴリをクリアします。  
6. 新しい系列とカテゴリを追加します。  
7. チャート系列の新しいデータを追加します。  
8. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

    # チャート付きでプレゼンテーションを保存します。
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![マルチカテゴリチャート](multi_category_chart.png)

### **マップチャートの作成**

マップチャートは、国・州・市などの特定の場所に情報をマッピングすることで地理データを可視化します。地域別のトレンドや人口統計、空間分布の分析に非常に有用です。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![マップチャート](map_chart.png)

### **組み合わせチャートの作成**

組み合わせチャート（またはコンボチャート）は、1 つのグラフ内に 2 つ以上のチャートタイプを組み合わせます。このチャートを使用すると、複数のデータセット間の違いをハイライト、比較、検証でき、相関関係を把握しやすくなります。

![組み合わせチャート](combination_chart.png)

以下の Python コードは、上図の組み合わせチャートを PowerPoint プレゼンテーションで作成する方法を示しています。

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

    # 最初の系列を追加します。
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

    # 垂直軸の主目盛線の色を設定します。
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # 二次水平軸を設定します。
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # 二次垂直軸を設定します。
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

Aspose.Slides for Python via .NET は、チャートのデータ、書式設定、スタイリングを更新して PowerPoint プレゼンテーションを最新の状態に保つことができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成して、チャートが含まれるプレゼンテーションを開きます。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査してチャートを見つけます。  
4. チャートのデータワークシートにアクセスします。  
5. 系列の値を変更してチャートデータ系列を修正します。  
6. 新しい系列を追加し、そのデータを入力します。  
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

            # 最初のチャート系列を取得します。
            series = chart.chart_data.series[0]

            # 系列データを更新します。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # 系列名を変更しています。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 2 番目のチャート系列を取得します。
            series = chart.chart_data.series[1]

            # 系列データを更新します。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # 系列名を変更しています。
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

            # チャート付きでプレゼンテーションを保存します。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートのデータ範囲の設定**

[チャートのデータ範囲の取得](/slides/ja/python-net/chart-workbook/#retrieve-a-charts-data-range) を参照して、既存のチャートで使用されている範囲を確認してください。

Aspose.Slides for Python via .NET は、特定のワークシート範囲をチャートのデータソースとして使用できます。これにより、どのセルが系列やカテゴリに供給されるかを制御でき、ワークシートの変更をチャートに反映させることができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成して、チャートが含まれるプレゼンテーションを開きます。  
2. インデックスを使用してスライドへの参照を取得します。  
3. すべてのシェイプを走査してチャートを見つけます。  
4. チャートデータをアクセスし、範囲を設定します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

## **チャートでデフォルトマーカーを使用する**

チャートでデフォルトマーカーを使用すると、各系列に自動的に異なるマーカー記号が割り当てられます。

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

Aspose.Slides for Python via .NET は、棒、折れ線、円、エリア、散布、ヒストグラム、レーダーなど、幅広いチャートタイプをサポートしています。この柔軟性により、データ可視化の要件に最適なチャートタイプを選択できます。

**スライドに新しいチャートを追加するにはどうすればよいですか？**

新しいチャートを追加するには、まず [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスを使用して目的のスライドを取得し、チャート追加メソッドを呼び出してチャートタイプと初期データを指定します。このプロセスにより、チャートがプレゼンテーションに直接組み込まれます。

**チャートに表示されているデータを更新するにはどうすればよいですか？**

チャートのデータは、データワークブック（[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)）にアクセスし、デフォルトの系列とカテゴリをクリアしてから、カスタムデータを追加することで更新できます。これにより、最新データを反映するようにプログラムでチャートをリフレッシュできます。

**チャートの外観をカスタマイズすることは可能ですか？**

はい、Aspose.Slides for Python via .NET は豊富なカスタマイズオプションを提供します。色、フォント、ラベル、凡例、その他の書式設定要素を変更して、チャートの外観を特定のデザイン要件に合わせることができます。