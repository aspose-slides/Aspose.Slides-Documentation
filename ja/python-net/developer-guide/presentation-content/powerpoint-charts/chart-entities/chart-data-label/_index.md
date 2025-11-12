---
title: Python を使用したプレゼンテーションのチャート データ ラベルの管理
linktitle: データ ラベル
type: docs
url: /ja/python-net/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: PowerPoint および OpenDocument のプレゼンテーションに、Aspose.Slides for Python via .NET を使用してチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。
---

## **概要**

チャート上のデータ ラベルは、チャート データ シリーズまたは個々のデータ ポイントに関する詳細を示します。これにより、読者はデータ シリーズをすばやく識別でき、チャートの理解が容易になります。Aspose.Slides for Python では、任意のチャートに対してデータ ラベルを有効化、カスタマイズ、書式設定できます。表示する内容（値、パーセンテージ、シリーズ名またはカテゴリ名）、ラベルの配置位置、外観（フォント、数値書式、区切り文字、リーダーラインなど）を選択できます。本稿では、チャートに明確で情報豊富なラベルを追加するために必要な主要 API とサンプルを紹介します。

## **データ ラベルの精度設定**

チャートのデータ ラベルは数値を表示することが多く、一定の精度が求められます。このセクションでは、Aspose.Slides でデータ ラベルの小数点以下桁数を制御する方法を、適切な数値書式を適用して示します。

以下の Python の例は、チャート データ ラベルの数値精度を設定する方法を示しています：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **パーセンテージをラベルとして表示**

Aspose.Slides を使用すると、チャート上のデータ ラベルとしてパーセンテージを表示できます。以下の例は、各ポイントのカテゴリ内シェアを計算し、ラベルにパーセンテージを表示する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Save the presentation containing the chart.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート データ ラベルにパーセント記号を表示**

このセクションでは、チャート データ ラベルにパーセント記号を含めて表示する方法を示します。シリーズ全体または個別のポイント（円グラフ、ドーナツ、100% スタックドチャートに最適）に対してパーセンテージ値を有効にし、ラベル オプションまたはカスタム数値書式で書式設定を制御する方法を学びます。

以下の Python の例は、チャートのデータ ラベルにパーセント記号を追加する方法を示しています：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # スライドをインデックスで取得します。
    slide = presentation.slides[0]

    # スライドに PercentsStackedColumn チャートを作成します。
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # チャート データのブックを取得します。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # 新しいシリーズを追加します。
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # シリーズの塗りつぶし色を設定します。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ラベル書式プロパティを設定します。
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # 新しいシリーズを追加します。
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # 塗りつぶしタイプと色を設定します。
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # プレゼンテーションを保存します。
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **軸からのラベル距離の設定**

このセクションでは、Aspose.Slides でデータ ラベルとチャート軸間の距離を制御する方法を示します。このオフセットを調整することで、重なりを防ぎ、密集したビジュアルの可読性を向上させます。

以下の Python コードは、軸ベースのチャートでカテゴリ軸からラベルまでの距離を設定する方法を示しています：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # スライドを取得します。
    slide = presentation.slides[0]

    # スライドにクラスター化カラム チャートを作成します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # カテゴリ（水平）軸からのラベル距離を設定します。
    chart.axes.horizontal_axis.label_offset = 500

    # プレゼンテーションを保存します。
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **ラベル位置の調整**

軸を使用しないチャート（例: 円グラフ）を作成すると、データ ラベルが端に近すぎることがあります。その場合は、リーダーラインがはっきり表示されるようにラベル位置を調整します。

以下の Python コードは、円グラフでラベル位置を調整する方法を示しています：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![ラベル位置の変更](changed_label_position.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**  
自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、一部のフィールド（例: カテゴリ）を非表示にするか、極端なポイントや重要なポイントにだけラベルを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**  
ラベルを有効にする前にデータポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際にラベルのスタイルを一貫させるにはどうすればよいですか？**  
フォント（ファミリー、サイズ）を明示的に設定し、レンダリング側でフォントが利用可能か確認してフォールバックを防ぎます。