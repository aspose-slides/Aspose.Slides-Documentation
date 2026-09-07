---
title: 在 Python via Java 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/python-java/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.Xml
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides for Python via Java，將 PowerPoint 與 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概覽**

Aspose.Slides for Python via Java 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字為基礎的表示方式來檢查簡報結構、排除產生文件的問題、在自動化測試中比較輸出，或與使用 XML 而非簡報封裝的工作流程整合時，XML 輸出非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法，搭配來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 類別的 [Xml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Xml) 值。您可以將結果直接寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}
[SaveFormat.Xml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Xml) 會建立 PowerPoint XML 簡報。它不會提取 PPTX 封裝內部的各個 Office Open XML 部分。如需確切的 PPTX 包部件，例如 `ppt/presentation.xml` 或單一投影片的 XML 檔案，請直接檢查 PPTX 封裝本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 [SaveFormat.Xml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Xml) 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **將 XML 輸出寫入串流**

在 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管線）時，使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 的串流重載。以下範例將結果寫入 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)，並取得作為 Python bytes 物件的 XML：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # 將 xml_data 傳遞給工作流程中的下一個元件。
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **將 XML 與簡報及匯出格式比較**

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 常見用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢查結構、排除問題、比較產生的輸出，以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 與舊版 PowerPoint 工作流程的相容性 |
| PPTX (`.pptx`) | 含有多個部件的 Office Open XML 套件 | 常規 PowerPoint 編輯與簡報交換 |
| PDF or TIFF | 固定版面頁面或多頁影像 | 檢視、列印與歸檔 |
| PNG, JPEG, or SVG | 單一投影片的渲染表示 | 縮圖、預覽與影像資產 |
| HTML or HTML5 | 以 Web 為導向的簡報輸出 | 瀏覽器檢視與網路發佈 |

與 PPT 和 PPTX 不同，XML 輸出主要用於檢查與以資料為導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[supported file formats](/slides/zh-hant/python-java/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅可儲存的格式，因此在工作流程需要將匯出的檔案重新載入 Aspose.Slides 以持續編輯時，請勿使用它。

## **常見問答**

**XML 匯出與儲存 PPTX 檔案相同嗎？**

不是。PPTX 是包含多個 Office Open XML 部件的套件，而 [SaveFormat.Xml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Xml) 會建立 PowerPoint XML 簡報檔案。

**我可以不在磁碟上建立檔案而儲存 XML 輸出嗎？**

可以。將可寫入的 Java 輸出串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)。例如，使用 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML 簡報目前僅支援儲存，尚未支援載入。若需要往返編輯，請使用 PPTX 或其他支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**

不會。XML 轉換會寫入結構化的簡報資料。若需頁面導向的輸出，請使用 PDF 或 TIFF；若需單張投影片影像，請使用 PNG、JPEG 或 SVG。