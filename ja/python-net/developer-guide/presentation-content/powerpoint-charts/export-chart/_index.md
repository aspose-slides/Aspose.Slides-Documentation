---
title: プレゼンテーションのチャートをPythonでエクスポート
linktitle: チャートのエクスポート
type: docs
weight: 90
url: /ja/python-net/export-chart/
keywords:
- チャート
- チャートを画像に変換
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してプレゼンテーションのチャートをエクスポートする方法を学びます。PPT、PPTX、ODP 形式をサポートし、任意のワークフローへのレポート作成を効率化します。"
---

## **チャート画像の取得**
Aspose.Slides for Python via .NET は、特定のチャートの画像を抽出する機能を提供します。以下にサンプル例を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **よくある質問**

**チャートをラスタ画像ではなくベクタ (SVG) としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は [shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/) を使用して SVG として保存できます。

**エクスポートしたチャートのピクセル単位の正確なサイズはどのように指定できますか？**

サイズまたはスケールを指定できる画像レンダリングのオーバーロードを使用します。ライブラリは指定した寸法やスケールでオブジェクトのレンダリングをサポートします。

**エクスポート後、ラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

[必要なフォントをロード](/slides/ja/python-net/custom-font/) し、[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) を使用してチャートのレンダリングがメトリックとテキストの外観を保持できるようにします。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを考慮しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗りつぶし、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外に利用可能なレンダリング／エクスポート機能はどこで確認できますか？**

[A​PI](/slides/ja/python-net/export/)／[ドキュメント](/slides/ja/python-net/convert-powerpoint/) のエクスポートセクションを参照してください。出力先には [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/) などがあり、関連するレンダリングオプションも提供されています。