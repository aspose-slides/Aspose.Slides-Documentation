---
title: Python でチャート データ テーブルをカスタマイズ
linktitle: データ テーブル
type: docs
url: /ja/python-net/chart-data-table/
keywords:
- チャート データ
- データ テーブル
- フォント プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PPT、PPTX、ODP のチャート データ テーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データ テーブルのフォント プロパティの設定**
Aspose.Slides for Python via .NET は、シリーズのカテゴリの色を変更するサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャート テーブルを設定します。
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

**チャートのデータ テーブルの値の横に小さな凡例キーを表示できますか？**

はい。データ テーブルは [凡例キー](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/) をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートすると、データ テーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)/[image](/slides/ja/python-net/convert-powerpoint-to-png/) にはデータ テーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータ テーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込んだチャートについても、チャートのプロパティを使用してデータ テーブルが [表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) を確認し、変更できます。

**ファイル内のどのチャートでデータ テーブルが有効になっているかをすぐに見つけるにはどうすればよいですか？**

各チャートのデータ テーブルが [表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) を示すプロパティを確認し、スライドを順に走査して有効になっているチャートを特定します。