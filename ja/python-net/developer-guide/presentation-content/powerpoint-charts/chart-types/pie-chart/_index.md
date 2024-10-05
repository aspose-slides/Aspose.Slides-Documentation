---
title: パイチャート
type: docs
url: /python-net/pie-chart/
keywords: "パイチャート, プロットオプション, スライスの色, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointプレゼンテーションにおけるパイチャートのプロットオプションとスライスの色"
---

## **パイチャートおよびバーオブパイチャートの第2プロットオプション**
Aspose.Slides for Python via .NETは、パイオブパイまたはバーオブパイチャートの第2プロットオプションをサポートしています。このトピックでは、Aspose.Slidesを使用してこれらのオプションを指定する方法について、例を用いて見ていきます。プロパティを指定するために、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの第2プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、パイオブパイチャートのさまざまなプロパティを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentationクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # スライドにチャートを追加
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # 異なるプロパティを設定
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # プレゼンテーションをディスクに書き込む
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **自動パイチャートスライスの色を設定**
Aspose.Slides for Python via .NETは、自動パイチャートスライドの色を設定するためのシンプルなAPIを提供しています。サンプルコードは、上記のプロパティを設定します。

1. Presentationクラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータを使用してチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初のシリーズの値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータワークシートを取得します。
1. デフォルトで生成されたシリーズとカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しいシリーズを追加します。

修正されたプレゼンテーションをPPTXファイルに書き込みます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation() as presentation:
	# 最初のスライドにアクセス
	slide = presentation.slides[0]

	# デフォルトデータを使用してチャートを追加
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# チャートのタイトルを設定
	chart.chart_title.add_text_frame_for_overriding("サンプルタイトル")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# 最初のシリーズの値を表示
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# チャートデータシートのインデックスを設定
	defaultWorksheetIndex = 0

	# チャートデータワークシートを取得
	fact = chart.chart_data.chart_data_workbook

	# デフォルトで生成されたシリーズとカテゴリを削除
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 新しいカテゴリを追加
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "第1四半期"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "第2四半期"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "第3四半期"))

	# 新しいシリーズを追加
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "シリーズ1"), chart.type)

	# シリーズデータを追加
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```