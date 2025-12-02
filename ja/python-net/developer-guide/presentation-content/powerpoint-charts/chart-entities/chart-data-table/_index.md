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
description: "Aspose.Slides を使用して、Python で PPT、PPTX、ODP のチャート データテーブルをカスタマイズし、プレゼンテーションの効率と魅力を向上させます。"
---

## **チャート データテーブルのフォント プロパティを設定する**
Aspose.Slides for Python via .NET は、系列内のカテゴリの色を変更する機能をサポートしています。

1. Presentation クラスオブジェクトをインスタンス化します。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用します。
1. スライドにチャートを追加します。
1. チャート テーブルを設定します。
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

はい。データテーブルは[legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/) をサポートしており、オンまたはオフにできます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートした際にデータテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)/[image](/slides/ja/python-net/convert-powerpoint-to-png/) にはデータテーブルを含むチャートが含まれます。

**テンプレート ファイルから取得したチャートでもデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込まれたチャートについても、チャートのプロパティを使用してデータテーブルが[is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)かどうかを確認および変更できます。

**ファイル内でデータテーブルが有効になっているチャートを素早く見つけるにはどうすればよいですか？**

各チャートのデータテーブルが[is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)かどうかを示すプロパティをチェックし、スライドを反復処理して有効なチャートを特定します。