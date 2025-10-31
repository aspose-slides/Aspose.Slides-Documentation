---
title: Python を使用したプレゼンテーションの円グラフのカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/python-net/pie-chart/
keywords:
- 円グラフ
- グラフの管理
- グラフのカスタマイズ
- グラフオプション
- グラフ設定
- プロットオプション
- スライス色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して円グラフを作成およびカスタマイズする方法を学び、PowerPoint や OpenDocument へエクスポート可能で、数秒でデータストーリーテリングを強化します。"
---

## **円の円グラフおよび棒円グラフの第2プロットオプション**

Aspose.Slides for Python via .NET は、円の円グラフや棒円グラフの第2プロットオプションをサポートしています。このトピックでは、例を使用して Aspose.Slides でこれらのオプションを指定する方法を示します。プロパティを指定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのオブジェクトをインスタンス化します。
2. スライドにチャートを追加します。
3. チャートの第2プロットオプションを指定します。
4. プレゼンテーションをディスクに保存します。

以下の例では、円の円グラフのさまざまなプロパティを設定しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:
    # スライドにチャートを追加
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # 異なるプロパティを設定
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # プレゼンテーションをディスクに保存
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **円グラフスライスの自動カラー設定**

Aspose.Slides for Python via .NET は、円グラフのスライスの自動カラー設定を行うシンプルな API を提供します。サンプルコードは上記のプロパティ設定を適用しています。

1. Presentation クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. チャートのタイトルを設定します。
5. 最初のシリーズで値を表示するよう設定します。
6. チャート データシートのインデックスを設定します。
7. チャート データ ワークシートを取得します。
8. デフォルトで生成されたシリーズとカテゴリを削除します。
9. 新しいカテゴリを追加します。
10. 新しいシリーズを追加します。

修正したプレゼンテーションを PPTX ファイルに保存します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスをインスタンス化
with slides.Presentation() as presentation:
	# 最初のスライドにアクセス
	slide = presentation.slides[0]

	# デフォルトデータでチャートを追加
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# チャートのタイトルを設定
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# 最初のシリーズで値を表示するよう設定
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# チャート データシートのインデックスを設定
	defaultWorksheetIndex = 0

	# チャート データ ワークシートを取得
	fact = chart.chart_data.chart_data_workbook

	# デフォルトで生成されたシリーズとカテゴリを削除
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 新しいカテゴリを追加
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# 新しいシリーズを追加
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# ここでシリーズデータを入力
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**「円の円グラフ」および「円の棒グラフ」のバリエーションはサポートされていますか？**

はい、ライブラリは[サポートしています](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)円グラフのセカンダリプロットを提供し、「円の円グラフ」および「円の棒グラフ」タイプを含みます。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)（PNG など）できます。