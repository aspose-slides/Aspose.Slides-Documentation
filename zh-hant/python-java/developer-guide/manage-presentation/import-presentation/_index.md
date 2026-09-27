---
title: 在 Python via Java 中從 PDF 或 HTML 匯入簡報
linktitle: 匯入簡報
type: docs
weight: 60
url: /zh-hant/python-java/import-presentation/
keywords:
- 匯入簡報
- 匯入投影片
- 匯入 PDF
- 匯入 HTML
- PDF 轉簡報
- PDF 轉 PPT
- PDF 轉 PPTX
- PDF 轉 ODP
- HTML 轉簡報
- HTML 轉 PPT
- HTML 轉 PPTX
- HTML 轉 ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python via Java 中將 PDF 與 HTML 內容匯入 PowerPoint 簡報，並將結果儲存為 PPTX 檔案。"
---
## **簡介**

Aspose.Slides for Python via Java 可以在沒有 Microsoft PowerPoint 的情況下，將 PDF 頁面或 HTML 內容轉換為 PowerPoint 投影片。 [SlideCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/) 類別提供 [addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromPdf) 與 [addFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromHtml) 以將匯入的內容附加到簡報。

若需要更高的 HTML 版面控制， [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertFromHtml) 可以在集合索引處插入產生的投影片，或在現有投影片的可用空間中開始填充。過長的 HTML 會自動分頁至額外的投影片，來源可以是字串或串流，且可透過具有基礎 URI 的 [ExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/externalresourceresolver/) 載入外部資源。回傳的 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 陣列會標示受影響的投影片與新建立的投影片。

## **從 PDF 匯入**

將 PDF 文件轉換為 PowerPoint 簡報，將其內容匯入投影片集合並將結果儲存為 PPTX 檔案。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 建立一個新的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件。
2. 使用 PDF 檔案路徑呼叫 [addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromPdf)。
3. 使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Pptx) 呼叫 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) ，將簡報寫入 PPTX 檔案。

以下 Python 範例匯入 PDF 文件並將產生的投影片儲存為 PowerPoint 簡報：

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

預設的空白投影片仍會保留在簡報中，因為匯入會附加投影片。若只想保留匯入的頁面，請在匯入前使用 [SlideCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#clear) 清除投影片集合。

[addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromPdf) 方法會回傳其新增的投影片，這在只需要處理匯入的投影片時相當有用。

{{% alert title="Tip" color="success" %}}
試用免費的 [PDF to PowerPoint](https://products.aspose.app/slides/zh-hant/import/pdf-to-powerpoint) 網頁應用程式，實際體驗此轉換工作流程。
{{% /alert %}}

## **從 HTML 匯入**

Aspose.Slides 也能從 HTML 文件建立投影片。來源可以是 HTML 文字或串流。以下步驟使用檔案串流：

1. 建立一個新的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件。
2. 開啟 HTML 檔案進行讀取，並將串流傳遞給 [addFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromHtml)。
3. 使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Pptx) 呼叫 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) ，將結果寫入 PPTX 檔案。

以下 Python 範例匯入 HTML 文件並將產生的投影片儲存為 PowerPoint 簡報：

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

## **插入 HTML 內容**

當必須將 HTML 產生的投影片放置在特定位置而非附加時，請使用 [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertFromHtml)。索引是從零開始，指明匯入開始的位置。

`useSlideWithIndexAsStart` 參數決定匯入程式如何使用此位置：

- 設為 `False` 時，匯入程式會在指定索引建立新投影片，並將後續投影片向後移動。
- 設為 `True` 時，匯入程式會在該索引的現有投影片的可用空間中開始放置內容。如果 HTML 內容無法容納，Aspose.Slides 會自動分頁，並於起始投影片之後立即插入額外投影片。

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#insertFromHtml) 會回傳一個 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 物件的陣列。若插入從新投影片開始，回傳的每個項目皆為新建立的投影片。若使用現有投影片作為起始，陣列會先包含受影響的那張投影片，之後是任何新產生的溢位投影片。您可以直接檢查此陣列，而不必根據簡報的投影片數量計算受影響的範圍。

### **將 HTML 作為新投影片插入**

以下範例以字串提供 HTML，並在集合索引 `1` 處插入產生的投影片。傳遞 `False` 會保留既有投影片，只是將它們向後移動以騰出空間。

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

### **從現有投影片開始**

下一個範例透過串流提供 HTML。它保留現有範本投影片上的標題形狀，從佔用區域下方開始匯入，並讓較長的正文延伸至新投影片。

HTML 也包含相對圖片 URL。 [ExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/externalresourceresolver/) 取得資源，而基礎 URI 告訴匯入程式如何解析 `images/logo.png`。在此範例中，該檔案預期位於 `html-assets/images/logo.png`。

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
未受限制的外部資源解析器可能會讀取 HTML 中引用的本機或網路資源。對於不受信任的輸入，請在匯入 HTML 前，根據允許的方案、目錄與主機清單，驗證並清理資源 URL。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 在匯入 PDF 時能偵測表格嗎？**

可以。建立一個 [PdfImportOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfimportoptions/) 物件，以 `True` 呼叫 [setDetectTables](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfimportoptions/#setDetectTables)，再將此選項傳遞給 [addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromPdf)。表格辨識的品質取決於來源 PDF 的結構與複雜度。

{{% alert title="Note" color="info" %}}
匯入 HTML 後，您也可以將投影片匯出為 [images](/slides/zh-hant/python-java/convert-powerpoint-to-png/)、[TIFF](/slides/zh-hant/python-java/convert-powerpoint-to-tiff/)，或 [SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/)。
{{% /alert %}}