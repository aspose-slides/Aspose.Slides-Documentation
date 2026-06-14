---
title: 在 Python 中將簡報轉換為含備註的 PDF
linktitle: 簡報轉 PDF 含備註
type: docs
weight: 50
url: /zh-hant/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- 轉換 ODP
- PowerPoint 轉 PDF
- OpenDocument 轉 PDF
- 簡報轉 PDF
- PPT 轉 PDF
- PPTX 轉 PDF
- ODP 轉 PDF
- 投影片備註
- 含備註的 PDF
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 將 PPT、PPTX 與 ODP 格式轉換為含備註的 PDF。保留版面配置與投影片備註，以製作專業的簡報。"
---
## **概觀**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為含有投影片備註的 PDF 格式。本指南將說明必要的步驟，並提供程式碼範例，協助您有效完成此任務。閱讀完本文後，您將能夠：

- 實作轉換程序，將 PowerPoint 投影片轉換為 PDF 文件，同時保留投影片備註。
- 自訂輸出 PDF，確保備註依您的需求被納入並正確格式化。

## **將 PowerPoint 轉換為含備註的 PDF**

`save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別中使用，以將 PPT 或 PPTX 簡報轉換為含投影片備註的 PDF。使用 Aspose.Slides，您只需載入簡報，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 類別設定版面配置以包含投影片備註，然後將檔案儲存為 PDF。以下程式碼片段示範如何在「備註投影片」檢視中將範例簡報轉換為 PDF。

```py
with slides.Presentation("sample.pptx") as presentation:

    # 配置 PDF 選項以呈現投影片備註。
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # 將簡報儲存為含投影片備註的 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 

您可能想要試用 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。 

{{% /alert %}}