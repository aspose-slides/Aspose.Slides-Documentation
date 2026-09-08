---
title: Python via Java で PDF または HTML からプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/python-java/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDF のインポート
- HTML のインポート
- PDF からプレゼンテーションへ
- PDF から PPT へ
- PDF から PPTX へ
- PDF から ODP へ
- HTML からプレゼンテーションへ
- HTML から PPT へ
- HTML から PPTX へ
- HTML から ODP へ
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python（Java 経由）で PDF および HTML コンテンツを PowerPoint プレゼンテーションにインポートし、結果を PPTX ファイルとして保存する方法を学びます。"
---
## **イントロダクション**

Aspose.Slides for Python via Java は、Microsoft PowerPoint を使用せずに PDF ページや HTML コンテンツを PowerPoint スライドに変換できます。 [SlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/) クラスは、インポートされたコンテンツをプレゼンテーションに追加するための [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) と [addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromHtml) を提供します。

HTML の配置をより細かく制御するには、[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) を使用して生成されたスライドをコレクションインデックスに挿入したり、既存のスライド上の利用可能なスペースに配置し始めることができます。長い HTML は自動的に追加のスライドにページ分割され、ソースは文字列またはストリームとして提供でき、外部リソースはベース URI を指定した [ExternalResourceResolver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/externalresourceresolver/) を介して読み込めます。返される [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) 配列は、影響を受けたスライドと新しく作成されたスライドを示します。

## **PDF からのインポート**

PDF ドキュメントを PowerPoint プレゼンテーションに変換するには、コンテンツをスライドコレクションにインポートし、結果を PPTX ファイルとして保存します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 新しい [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成します。  
2. PDF ファイルへのパスを指定して [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) を呼び出します。  
3. [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) とともに呼び出して、プレゼンテーションを PPTX ファイルに書き込みます。

以下の Python の例は PDF ドキュメントをインポートし、生成されたスライドを PowerPoint プレゼンテーションとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

インポートはスライドを追加するため、デフォルトの空白スライドがプレゼンテーションに残ります。インポートされたページのみを残すには、インポート前に [SlideCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#clear) でスライドコレクションをクリアします。

[addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) メソッドは追加されたスライドを返します。インポートされたスライドだけを処理する必要がある場合に便利です。

{{% alert title="Tip" color="success" %}}
無料の [PDF to PowerPoint](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) Web アプリを試して、この変換ワークフローを実際に確認してください。
{{% /alert %}}

## **HTML からのインポート**

Aspose.Slides は HTML ドキュメントからもスライドを作成できます。ソースは HTML テキストまたはストリームとして提供できます。以下の手順はファイルストリームを使用します。

1. 新しい [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成します。  
2. HTML ファイルを読み取り用に開き、ストリームを [addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromHtml) に渡します。  
3. [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) とともに呼び出して、結果を PPTX ファイルに書き込みます。

以下の Python の例は HTML ドキュメントをインポートし、生成されたスライドを PowerPoint プレゼンテーションとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML コンテンツの挿入**

HTML 生成スライドを追加ではなく特定の位置に配置する必要がある場合は、[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) を使用します。インデックスはゼロベースで、インポート開始位置を示します。

`useSlideWithIndexAsStart` 引数は、インポーターがその位置をどのように使用するかを制御します:

- `False` の場合、インポーターは指定されたインデックスに新しいスライドを作成し、以降のスライドをシフトします。  
- `True` の場合、インポーターはそのインデックスの既存スライド上の利用可能なスペースにコンテンツの配置を開始します。HTML が収まりきらない場合、Aspose.Slides は自動的にページ分割し、開始スライドの直後に追加スライドを挿入します。

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) は [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) オブジェクトの配列を返します。新しいスライドで挿入が開始された場合、返される各項目は新規作成されたものです。既存のスライドが開始位置として使用された場合、配列にはその影響を受けたスライドと、その後に続く新しいオーバーフロースライドが含まれます。プレゼンテーションのスライド数から影響範囲を計算する代わりに、この配列を調べることができます。

### **新しいスライドとして HTML を挿入**

以下の例は HTML を文字列として提供し、生成されたスライドをコレクションインデックス `1` に挿入します。`False` を渡すと、既存のスライドは位置を空けるためにシフトされる以外は変更されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **既存スライドから開始**

次の例は HTML をストリームで提供します。既存のテンプレートスライド上のヘッダーシェイプを保持し、占有領域の下からインポートを開始し、長い本文は新しいスライドへ継続させます。

HTML には相対画像 URL も含まれています。[ExternalResourceResolver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/externalresourceresolver/) がリソースを取得し、ベース URI がインポーターに `images/logo.png` の解決方法を指示します。この例では、そのファイルは `html-assets/images/logo.png` にあることが想定されています。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
制限のない外部リソースリゾルバーは、HTML が参照するローカルまたはネットワーク上のリソースを読み取ることができます。信頼できない入力に対しては、HTML をインポートする前に、許可されたスキーム、ディレクトリ、ホストのホワイトリストに対してリソース URL を検証およびサニタイズしてください。
{{% /alert %}}

## **FAQ**

**PDF をインポートするときに Aspose.Slides はテーブルを検出できますか？**

はい。 [PdfImportOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfimportoptions/) オブジェクトを作成し、`True` を指定して [setDetectTables](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfimportoptions/#setDetectTables) を呼び出し、そのオプションを [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) に渡します。テーブル認識の精度は、元の PDF の構造と複雑さに依存します。

{{% alert title="Note" color="info" %}}
HTML をインポートした後、スライドを [images](/slides/ja/python-java/convert-powerpoint-to-png/)、[TIFF](/slides/ja/python-java/convert-powerpoint-to-tiff/)、または [SVG](/slides/ja/python-java/render-slide-as-svg/) にエクスポートすることもできます。
{{% /alert %}}