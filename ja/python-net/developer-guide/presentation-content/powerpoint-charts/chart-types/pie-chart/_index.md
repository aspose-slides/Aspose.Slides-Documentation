---
title: Python を使用したプレゼンテーションの円グラフのカスタマイズ
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
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して円グラフを作成・カスタマイズする方法を学び、PowerPoint や OpenDocument へエクスポートでき、数秒でデータストーリーテリングを強化します。"
---

## **Pie of Pie と Bar of Pie チャートの二次プロットオプション**
Aspose.Slides for Python via .NET は、現在、Pie of Pie または Bar of Pie チャートの二次プロットオプションをサポートしています。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法をサンプルで確認します。プロパティを指定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの二次プロットオプションを指定します。
1. プレゼンテーションを書き出します。

以下の例では、Pie of Pie チャートのさまざまなプロパティを設定しています。
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





## **自動 Pie チャート スライスの色を設定**
Aspose.Slides for Python via .NET は、円グラフスライスの自動色設定用のシンプルな API を提供します。サンプルコードは上記プロパティの設定を適用します。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャート タイトルを設定します。
1. 最初の系列で値の表示を有効にします。
1. チャート データ シートのインデックスを設定します。
1. チャート データ ワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

変更したプレゼンテーションを PPTX ファイルに書き出します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX ファイルを表す Presentation クラスのインスタンス化
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

	# 最初の系列で値の表示を有効にする
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# チャート データシートのインデックスを設定
	defaultWorksheetIndex = 0

	# チャート データ ワークシートを取得
	fact = chart.chart_data.chart_data_workbook

	# デフォルトで生成された系列とカテゴリを削除
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 新しいカテゴリを追加
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# 新しい系列を追加
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# 系列データを入力
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**「Pie of Pie」および「Bar of Pie」のバリエーションはサポートされていますか？**

はい、ライブラリは二次プロットをサポートしており、[Pie of Pie](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) と [Bar of Pie](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) のタイプが利用可能です。

**チャートだけを画像（例: PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体ではなく、チャート自体を画像として[エクスポート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)できます（PNG など）。