---
title: Pythonでチャート データテーブルをカスタマイズ
linktitle: データテーブル
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
description: "Aspose.Slides を使用して、PPT、PPTX、ODP 用のチャート データテーブルを Python でカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォントプロパティの設定**
Aspose.Slides for Python via .NET は、系列の色のカテゴリの色を変更する機能をサポートします。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 変更されたプレゼンテーションを保存します。

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


## **FAQ**

**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)をサポートしており、オンまたはオフに切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートしたときにデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部として描画するため、エクスポートされた[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)/[image](/slides/ja/python-net/convert-powerpoint-to-png/)にはデータテーブルを含むチャートが含まれます。

**テンプレートファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートからロードされたチャートについては、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)を確認および変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかを素早く確認するにはどうすればよいですか？**

各チャートのデータテーブルが[表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)を示すプロパティを確認し、スライドを走査して有効になっているチャートを特定します。