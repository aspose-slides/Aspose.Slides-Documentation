---
title: チャートデータテーブル
type: docs
url: /python-net/chart-data-table/
keywords: "フォントプロパティ、チャートデータテーブル、PowerPointプレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションのチャートデータベーステーブルのフォントプロパティを設定する"
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for Python via .NETは、系列の色におけるカテゴリの色を変更するためのサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```