---
title: プレゼンテーションで Python を使用したチャート データ ラベルの管理
linktitle: データ ラベル
type: docs
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-data-label/
keywords:
- chart
- data label
- data precision
- percentage
- label distance
- label location
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---

## **概要**

チャートのデータ ラベルは、チャート データ シリーズや個々のデータ ポイントの詳細を示します。読者はデータ シリーズをすばやく特定でき、チャートの理解が容易になります。Aspose.Slides for Python では、任意のチャートに対してデータ ラベルを有効化、カスタマイズ、書式設定でき、表示内容（値、パーセンテージ、シリーズ名またはカテゴリ名）、ラベルの位置、外観（フォント、数値書式、区切り記号、リーダーラインなど）を選択できます。本記事では、チャートに分かりやすく情報豊富なラベルを追加するために必要な主要 API とサンプルを紹介します。

## **データ ラベルの精度設定**

チャート データ ラベルは数値を表示することが多く、一定の小数点以下桁数が求められます。このセクションでは、適切な数値書式を適用して Aspose.Slides のデータ ラベルの小数点以下桁数を制御する方法を示します。

次の Python サンプルは、チャート データ ラベルの数値精度を設定する方法を示しています。

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

Aspose.Slides を使用すると、チャートのデータ ラベルとしてパーセンテージを表示できます。以下の例は、各ポイントのカテゴリ内シェアを計算し、ラベルにパーセンテージを表示する方法を示しています。

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

    # チャートを含むプレゼンテーションを保存します。
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート データ ラベルにパーセント記号を付加**

このセクションでは、チャート データ ラベルにパーセンテージを表示し、パーセント記号を付加する方法を示します。シリーズ全体または個別のポイントに対してパーセンテージ値を有効化する方法（円グラフ、ドーナツ グラフ、100% 積み上げチャートに最適）と、ラベル オプションやカスタム数値書式で書式を制御する方法を学びます。

次の Python 例は、チャートのデータ ラベルにパーセント記号を追加する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # インデックスでスライド参照を取得します。
    slide = presentation.slides[0]

    # スライドに PercentsStackedColumn チャートを作成します。
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # チャート データのワークブックを取得します。
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

    # 2 番目のシリーズを追加します。
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # 塗りつぶしタイプとカラーを設定します。
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

## **軸からのラベル距離を設定**

このセクションでは、Aspose.Slides でデータ ラベルとチャート 軸間の距離を制御する方法を示します。このオフセットを調整すると、重なりを防ぎ、密集したビジュアルの可読性が向上します。

次の Python コードは、軸ベースのチャートでカテゴリ軸からラベル距離を設定する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # スライド参照を取得します。
    slide = presentation.slides[0]

    # スライドにクラスター化された縦棒チャートを作成します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # カテゴリ（水平）軸からのラベル距離を設定します。
    chart.axes.horizontal_axis.label_offset = 500

    # プレゼンテーションを保存します。
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **ラベル位置の調整**

軸を使用しないチャート（例: 円グラフ）を作成する場合、データ ラベルが端に近すぎることがあります。その際は、リーダーラインがはっきり表示されるようにラベル位置を調整します。

次の Python コードは、円グラフのラベル位置を調整する方法を示しています。

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

**データ ラベルが密集したチャートで重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダーライン、フォント サイズの縮小を組み合わせます。必要に応じて一部のフィールド（例: カテゴリ）を非表示にするか、極端または重要なポイントだけにラベルを表示します。

**ゼロ、負の値、または空の値に対してラベルを無効にするにはどうすればよいですか？**

ラベルを有効化する前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF／画像にエクスポートする際にラベルのスタイルを一貫させるにはどうすればよいですか？**

フォント（ファミリ、サイズ）を明示的に設定し、レンダリング側にフォントが存在することを確認してフォールバックを防止します。