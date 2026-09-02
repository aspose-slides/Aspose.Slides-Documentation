---
title: 在 Python 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/python-net/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.XML
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 PowerPoint 與 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for Python via .NET 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字為基礎的表示方式來檢視簡報結構、排除產生的文件問題、在自動化測試中比較輸出，或是整合需要 XML 而非簡報套件的工作流程時，XML 輸出非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法，並使用來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 列舉的 `XML` 值。您可以將結果直接寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` 會建立 PowerPoint XML 簡報。它不會抽取 PPTX 套件內部的各個 Office Open XML 部分。若您需要完整的 PPTX 套件部件，例如 `ppt/presentation.xml` 或單獨的投影片 XML 檔案，請直接檢查 PPTX 套件本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 `SaveFormat.XML` 傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管線）時，請使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 的串流重載。以下範例將結果寫入 [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) 串流，並將其倒回以供後續讀取：

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # 將 xml_stream 傳遞給工作流程中的下一個元件。
```

## **將 XML 與簡報及匯出格式比較**

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 常見用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢視結構、排除問題、比較產生的輸出，以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 與舊版 PowerPoint 工作流程的相容性 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 套件 | 常規 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面頁面或多頁影像 | 觀賞、列印與保存 |
| PNG、JPEG 或 SVG | 單張投影片的渲染表示 | 縮圖、預覽與影像資產 |
| HTML 或 HTML5 | 針對網路的簡報輸出 | 瀏覽器檢視與網站發佈 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢視與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[支援的檔案格式](/slides/zh-hant/python-net/supported-file-formats/) 表格將 PowerPoint XML 簡報列為僅能儲存的格式，因此當工作流程必須將匯出的檔案重新載入 Aspose.Slides 以進行後續編輯時，請勿使用此格式。

## **常見問題**

**`SaveFormat.XML` 與儲存 PPTX 檔案相同嗎？**  
否。PPTX 是一個包含多個 Office Open XML 部件的套件，而 `SaveFormat.XML` 會建立 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**  
可以。將可寫入的串流傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)。例如，使用 [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) 串流進行記憶體內處理。

**Aspose.Slides 可以再次載入匯出的 XML 檔案嗎？**  
否。PowerPoint XML 簡報目前僅支援儲存，不支援載入。若需要往返編輯，請使用 PPTX 或其他支援的簡報格式。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**  
否。XML 轉換會寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF；若需要單張投影片的影像，請使用 PNG、JPEG 或 SVG。