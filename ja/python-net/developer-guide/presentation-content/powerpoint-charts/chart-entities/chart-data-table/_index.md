---
title: Pythonでチャートデータテーブルをカスタマイズ
linktitle: データテーブル
type: docs
url: /ja/python-net/chart-data-table/
keywords:
- チャートデータ
- データテーブル
- フォントプロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して、Python で PPT、PPTX、ODP 用のチャートデータテーブルをカスタマイズし、プレゼンテーションの効率と魅力を高めます。"
---

## **チャート データ テーブルのフォント プロパティを設定**
Aspose.Slides for Python via .NET は、系列のカテゴリの色を変更する機能をサポートしています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラス オブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートのテーブルを設定します。
1. フォントの高さを設定します。
1. 変更したプレゼンテーションを保存します。

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


## **よくある質問**
**チャートのデータテーブルの値の横に小さな凡例キーを表示できますか？**

はい。データテーブルは[凡例キー](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)をサポートしており、オン/オフを切り替えることができます。

**プレゼンテーションを PDF、HTML、または画像にエクスポートする際、データテーブルは保持されますか？**

はい。Aspose.Slides はチャートをスライドの一部としてレンダリングするため、エクスポートされた[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)/[image](/slides/ja/python-net/convert-powerpoint-to-png/)にはデータテーブル付きのチャートが含まれます。

**テンプレートファイルから取得したチャートのデータテーブルはサポートされていますか？**

はい。既存のプレゼンテーションまたはテンプレートから読み込んだすべてのチャートについて、チャートのプロパティを使用してデータテーブルが[表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)を確認し、変更できます。

**ファイル内のどのチャートでデータテーブルが有効になっているかをすばやく確認するにはどうすればよいですか？**

データテーブルが[表示されているか](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)を示す各チャートのプロパティを確認し、スライドを順に走査して有効なチャートを特定します。