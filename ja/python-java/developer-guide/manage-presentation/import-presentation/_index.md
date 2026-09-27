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
description: "Aspose.Slides を使用して、Python via Java で PDF および HTML コンテンツを PowerPoint プレゼンテーションにインポートし、結果を PPTX ファイルとして保存する方法を学びます。"
---
## **はじめに**

Aspose.Slides for Python via Java を使用すると、Microsoft PowerPoint を使用せずに PDF ページや HTML コンテンツを PowerPoint スライドに変換できます。SlideCollection クラスは、インポートしたコンテンツをプレゼンテーションに追加するための [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) と [addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromHtml) を提供します。

HTML の配置をより細かく制御したい場合は、[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) を使用して、コレクションのインデックスにスライドを挿入したり、既存スライド上の空き領域に埋め込みを開始したりできます。長い HTML は自動的に追加スライドにページ分割され、ソースは文字列またはストリームで提供でき、外部リソースはベース URI を使用して [ExternalResourceResolver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/externalresourceresolver/) で読み込めます。返される [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) 配列は、影響を受けたスライドと新しく作成されたスライドを示します。

## **PDF からのインポート**

PDF ドキュメントを PowerPoint プレゼンテーションに変換するには、スライドコレクションに内容をインポートし、結果を PPTX ファイルとして保存します。

![pdf-to-powerpoint](pdf-to-powerpoint.png){: style="zoom: 50%;" }

1. 新しい [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成します。  
2. PDF ファイルへのパスを指定して [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) を呼び出します。  
3. [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を指定して [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を実行し、プレゼンテーションを PPTX ファイルに書き出します。

以下の Python サンプルは PDF ドキュメントをインポートし、生成されたスライドを PowerPoint プレゼンテーションとして保存します。

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

インポートはスライドを追加する形で行われるため、デフォルトの空白スライドはプレゼンテーションに残ります。インポートしたページだけを残したい場合は、インポート前に [SlideCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#clear) でスライドコレクションをクリアしてください。

[addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) メソッドは追加されたスライドを返すので、インポートされたスライドだけを処理したいときに便利です。

{{% alert title="Tip" color="success" %}}
無料の [PDF から PowerPoint へ](https://products.aspose.app/slides/ja/import/pdf-to-powerpoint) Web アプリを使って、この変換ワークフローを実際に試してみてください。
{{% /alert %}}

## **HTML からのインポート**

Aspose.Slides は HTML ドキュメントからスライドを作成することもできます。ソースは HTML テキストまたはストリームとして提供できます。以下の手順はファイルストリームを使用した例です。

1. 新しい [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成します。  
2. HTML ファイルを読み取り用に開き、ストリームを [addFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromHtml) に渡します。  
3. [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を指定して [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を実行し、結果を PPTX ファイルに書き出します。

以下の Python サンプルは HTML ドキュメントをインポートし、生成されたスライドを PowerPoint プレゼンテーションとして保存します。

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

HTML で生成されたスライドを末尾に追加するのではなく、特定の位置に配置する必要がある場合は、[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) を使用します。インデックスは 0 ベースで、インポート開始位置を示します。

`useSlideWithIndexAsStart` 引数はインポーターがその位置をどのように使用するかを制御します。

- `False` の場合、指定したインデックスに新しいスライドを作成し、その後に続くスライドをシフトします。  
- `True` の場合、指定したインデックスの既存スライド上の空き領域にコンテンツの配置を開始します。HTML が収まりきらない場合、Aspose.Slides は自動的にページ分割し、開始スライドの直後に追加スライドを挿入します。

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#insertFromHtml) は [Slide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) オブジェクトの配列を返します。挿入が新しいスライド上で開始された場合、返されるすべての項目は新規作成されたスライドです。既存スライドを開始位置として使用した場合、配列にはその影響を受けたスライドが最初に含まれ、続いてオーバーフロー分の新しいスライドが続きます。この配列を調べることで、プレゼンテーションのスライド数から影響範囲を計算する必要がなくなります。

### **HTML を新しいスライドとして挿入**

以下の例は HTML を文字列として提供し、コレクションインデックス `1` に生成スライドを挿入します。`False` を渡すと、既存スライドはそのままで位置だけがシフトされます。

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

次の例はストリーム経由で HTML を提供します。テンプレートスライド上のヘッダーシェイプは保持したまま、占有領域の下からインポートを開始し、長い本文は新しいスライドへと続きます。

HTML には相対パスの画像 URL も含まれています。`ExternalResourceResolver` がリソースを取得し、ベース URI が `images/logo.png` を解決する方法をインポーターに指示します。この例では、画像は `html-assets/images/logo.png` に配置されていることを想定しています。

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
制限のない外部リソースリゾルバーは、HTML が参照するローカルまたはネットワーク上のリソースを読み取ることができます。信頼できない入力については、インポート前に許可されたスキーム、ディレクトリ、ホストのホワイトリストに対してリソース URL を検証・サニタイズしてください。
{{% /alert %}}

## **FAQ**

**PDF をインポートする際に Aspose.Slides は表を検出できますか？**

はい。`PdfImportOptions` オブジェクトを作成し、`setDetectTables` を `True` で呼び出してから、そのオプションを [addFromPdf](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addFromPdf) に渡します。表認識の精度は元の PDF の構造と複雑さに依存します。

{{% alert title="Note" color="info" %}}
HTML をインポートした後、スライドを [画像](/slides/ja/python-java/convert-powerpoint-to-png/)、[TIFF](/slides/ja/python-java/convert-powerpoint-to-tiff/)、または [SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/) にエクスポートすることもできます。
{{% /alert %}}