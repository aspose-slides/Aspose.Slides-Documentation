---
title: Python を使用したプレゼンテーションでの円グラフのカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/python-net/pie-chart/
keywords:
- 円グラフ
- チャートの管理
- チャートのカスタマイズ
- チャートオプション
- チャート設定
- プロットオプション
- スライスの色
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python で円グラフを作成およびカスタマイズします。二次プロットを設定し、データ ラベルを表示し、PowerPoint で自動スライスの色を適用します。"
---
## **概要**

この記事では、Aspose.Slides で円グラフを操作する方法を説明します。Pie of Pie および Bar of Pie チャートの二次プロット オプションの設定方法と、標準の円グラフに対する自動スライス着色の有効化方法を示します。

例では、スライドにチャートを追加し、系列とラベルの設定を調整し、既定のチャート データをカスタム カテゴリと値に置き換えて、更新されたプレゼンテーションを保存するカスタマイズ タスクに焦点を当てています。

## **Pie of Pie および Bar of Pie チャートの二次プロット オプション**

Aspose.Slides for Python via .NET は、Pie of Pie と Bar of Pie チャートの二次プロット オプションをサポートします。これらのオプションは、二次プロットのサイズと、データ ポイントが 2 つのプロット間でどのように分割されるかを制御します。

次の例は、新しいプレゼンテーションに Pie of Pie チャートを作成し、データ ポイントの値をラベルとして表示します。[second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) プロパティは二次プロットのサイズをメイン プロットの 149% に設定します。[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) はパーセンテージベースの分割を選択し、[pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) は閾値を 53% に設定します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # 値を表示し、二次プロットを設定します。
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **二次プロットのカテゴリを選択する**

カスタム分割を使用すると、パーセンテージ値に関係なく特定のカテゴリを二次プロットにグループ化できます。たとえば、売上レポートでオンラインとイベントを一緒に表示し、合計売上の 35% と 10% を占めていても 2 つのチャネルを比較できるようにします。

[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) を [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) に設定し、[pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) でポイントを選択します。コレクションの [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) メソッドは、系列内のゼロベース インデックスまたはデータ ポイント オブジェクトのいずれかを受け取ります。この例ではインデックス 1 がオンライン、インデックス 3 がイベントを選択します。Partners も一時的に追加され、[remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) で除外されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # デフォルト データをチャネル別の売上に置き換えます。
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Online をゼロベース インデックスで、Events をデータ ポイント オブジェクトで選択します。
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Partners を選択から除外します（元データは削除しません）。
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

オンライン (35) とイベント (10) は二次プロットで個別のスライスとして表示されます。一次プロットでは、45 の合計値で 1 つの結合スライスとして表され、Retail (40) と Partners (15) と並びます。Partners をカスタム選択から除外しても、一次プロットには残り、カテゴリやその値がチャートの元データから削除されることはありません。

以下の画像は PowerPoint で保存されたプレゼンテーションを示しています。

![二次プロットにオンラインとイベントがあり、一次プロットで 45 の結合値になる Pie of Pie チャート](pie_of_pie_custom.png)

## **円グラフのスライスの自動着色を設定する**

Aspose.Slides for Python via .NET は、円グラフのスライスに自動的に異なる色を割り当てることができます。次の例は、中央にタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) プロパティは値 20、50、30 をラベルとして表示し、[is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) は各スライスに異なる色を有効にします。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # 中央揃えのチャートタイトルを追加します。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 最初のワークシートを使用して既定のデータを置き換えます。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # 値を表示し、スライスに異なる色を割り当てます。
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリは二次プロットを **[サポートしています](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)**（Pie of Pie と Bar of Pie タイプを含む） 。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、**[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)** （PNG など） でき、プレゼンテーション全体をエクスポートする必要はありません。