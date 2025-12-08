---
title: Pythonでチャートデータテーブルをカスタマイズ
linktitle: チャート データテーブル
type: docs
url: /ja/python-net/chart-data-table/
keywords:
- チャート データ
- データテーブル
- フォント プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PPT、PPTX、ODP のチャートデータテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for Python via .NET は、シリーズの色でカテゴリの色を変更するサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

以下にサンプル例が示されています。
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


## **よくある質問**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートしたときにデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)/[image](/slides/ja/python-net/convert-powerpoint-to-png/)にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれた任意のチャートについて、チャートのプロパティを使用してデータテーブルが[is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)かどうかを確認し、変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく確認する方法は？**

各チャートのデータテーブルが[is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)かを示すプロパティを確認し、スライドを走査して有効なチャートを特定します。