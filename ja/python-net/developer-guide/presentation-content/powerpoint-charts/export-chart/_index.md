---
title: "Pythonでプレゼンテーションのチャートをエクスポート"
linktitle: "チャートのエクスポート"
type: docs
weight: 90
url: /ja/python-net/export-chart/
keywords:
- "チャート"
- "チャートから画像へ"
- "画像としてのチャート"
- "チャート画像の抽出"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PPT、PPTX、ODP 形式のプレゼンテーション チャートをエクスポートする方法を学び、任意のワークフローへレポートを効率化します。"
---

## **チャート画像の取得**
Aspose.Slides for Python via .NET は、特定のチャートの画像抽出をサポートしています。以下にサンプル例を示します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```


## **FAQ**

**チャートをラスター画像ではなくベクター（SVG）としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/)でSVGとして保存できます。

**エクスポートしたチャートの正確なサイズをピクセル単位で設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる image-rendering のオーバーロードを使用します。ライブラリは指定された寸法/スケールでオブジェクトのレンダリングをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合、どうすればよいですか？**

[必要なフォントをロード](/slides/ja/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) これにより、チャートのレンダリングがメトリックとテキストの外観を保持します。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

[API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[ドキュメント](/slides/ja/python-net/convert-powerpoint/) のエクスポートセクションで出力ターゲット（[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/ja/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ja/python-net/convert-powerpoint-to-html/), など）と関連するレンダリングオプションを確認してください。