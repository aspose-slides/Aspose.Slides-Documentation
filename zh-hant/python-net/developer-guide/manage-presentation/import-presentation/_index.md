---
title: 使用 Python 匯入簡報
linktitle: 匯入簡報
type: docs
weight: 60
url: /zh-hant/python-net/import-presentation/
keywords:
- 匯入 PowerPoint
- 匯入簡報
- 匯入投影片
- PDF 轉簡報
- PDF 轉 PPT
- PDF 轉 PPTX
- PDF 轉 ODP
- HTML 轉簡報
- HTML 轉 PPT
- HTML 轉 PPTX
- HTML 轉 ODP
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中輕鬆匯入 PDF 與 HTML 文件至 PowerPoint 與 OpenDocument 簡報，實現無縫且高效能的投影片處理。"
---
## **簡介**

使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/zh-hant/python-net/)，您可以從其他檔案格式匯入內容至簡報。[SlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/) 類別提供從 PDF、HTML 及其他來源匯入投影片的方法。

## **將 PDF 轉換為簡報**

本節說明如何使用 Aspose.Slides 將 PDF 轉換為簡報。它將引導您匯入 PDF、將其頁面轉換為投影片，並將結果儲存為 PPTX 檔案。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 呼叫 [add_from_pdf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_from_pdf/) 方法並傳入 PDF 檔案。  
3. 使用 [save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 PowerPoint 格式。

以下 Python 範例示範將 PDF 轉換為簡報：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
您或許想試用 **Aspose 的免費** [PDF to PowerPoint](https://products.aspose.app/slides/zh-hant/import/pdf-to-powerpoint) 網路應用程式—它是此處描述流程的即時實作。
{{% /alert %}}

## **將 HTML 轉換為簡報**

本節說明如何使用 Aspose.Slides 將 HTML 內容匯入簡報。它涵蓋載入 HTML、將其轉換為保留文字、圖像和基本格式的投影片，並將結果儲存為 PPTX 檔案。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 呼叫 [add_from_html](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_from_html/) 方法並傳入 HTML 檔案。  
3. 使用 [save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 PowerPoint 格式。

以下 Python 範例示範將 HTML 轉換為簡報：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**匯入 PDF 時表格是否會被保留，且其偵測能否改善？**

匯入過程中可偵測表格；[PdfImportOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.importing/pdfimportoptions/) 包含一個 [detect_tables](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) 參數，可啟用表格辨識。其有效性取決於 PDF 的結構。

{{% alert title="Note" color="info" %}}
您也可以使用 Aspose.Slides 將 HTML 轉換為其他常見檔案格式：

* [HTML 轉圖片](https://products.aspose.com/slides/zh-hant/python-net/conversion/html-to-image/)
* [HTML 轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/html-to-jpg/)
* [HTML 轉 XML](https://products.aspose.com/slides/zh-hant/python-net/conversion/html-to-xml/)
* [HTML 轉 TIFF](https://products.aspose.com/slides/zh-hant/python-net/conversion/html-to-tiff/)
{{% /alert %}}