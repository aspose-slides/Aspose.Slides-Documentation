---
title: Python via Java でプレゼンテーションのチャートをエクスポート
linktitle: チャートをエクスポート
type: docs
weight: 90
url: /ja/python-java/export-chart/
keywords:
- チャート
- チャートから画像へ
- 画像としてのチャート
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してプレゼンテーションのチャートをエクスポートする方法を学び、PPT および PPTX 形式をサポートし、あらゆるワークフローでのレポート作成を効率化します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーションからチャートを画像としてエクスポートできます。本記事では、チャートから画像を取得して保存する方法を示します。これは、PowerPoint のプレゼンテーション外でチャートのビジュアルを再利用する必要がある場合に役立ちます。

基本的な画像エクスポートのワークフローに加えて、この記事ではエクスポートに関する一般的な質問にも対処します。具体的には、チャートの内容を SVG に保存する方法、レンダリングオプションで出力サイズを制御する方法、ラベルや凡例の外観を保つためにフォントを読み込む方法、レンダリング時にテーマ、スタイル、塗り、エフェクトなど元のプレゼンテーションの書式設定を保持する方法です。

## **チャート画像の取得**
Aspose.Slides for Python via Java は、特定のチャートの画像抽出をサポートしています。以下の例でその方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **よくある質問**

**チャートをラスタ画像ではなくベクタ (SVG) としてエクスポートできますか？**

はい。チャートはシェイプであり、その内容は[shape-to-SVG 保存メソッド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#writeAsSvgToBytes)を使用して SVG に保存できます。

**エクスポートしたチャートのサイズをピクセル単位で正確に設定するにはどうすればよいですか？**

サイズまたはスケールを指定できる画像レンダリングのオーバーロードを使用してください。ライブラリは指定された寸法/スケールでオブジェクトをレンダリングすることをサポートしています。

**エクスポート後にラベルや凡例のフォントが正しく表示されない場合はどうすればよいですか？**

[必要なフォントをロード](/slides/ja/python-java/custom-font/)し、[FontsLoader](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/) を使用して、チャートのレンダリングがメトリクスとテキストの外観を保持するようにしてください。

**エクスポートは PowerPoint のテーマ、スタイル、エフェクトを尊重しますか？**

はい。Aspose.Slides のレンダラーはプレゼンテーションの書式設定（テーマ、スタイル、塗り、エフェクト）に従うため、チャートの外観が保持されます。

**チャート画像以外の利用可能なレンダリング/エクスポート機能はどこで確認できますか？**

出力先（[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/ja/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/) など）や関連するレンダリングオプションについては、[API](https://reference.aspose.com/slides/ja/python-java/aspose.slides/)/[ドキュメント](/slides/ja/python-java/convert-powerpoint/) を参照してください。