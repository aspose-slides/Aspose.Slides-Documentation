---
title: 使用 Python 將簡報轉換為含備註的 PDF
linktitle: 簡報轉 PDF（含備註）
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
- 講者備註
- 含備註的 PDF
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 將 PPT、PPTX 和 ODP 格式轉換為含備註的 PDF。保留版面配置與講者備註，打造專業的簡報。"
---
## **概覽**

在本篇文章中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為包含講者備註的 PDF 格式。此指南將說明相關步驟，並提供程式碼範例，協助您有效完成此任務。閱讀完本篇文章後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 檔，同時保留講者備註。
- 自訂輸出 PDF，確保講者備註依您的需求被包含與格式化。

若要在匯出前設定註記頁面的尺寸與方向，請參閱 [Notes Page Size](/slides/zh-hant/python-net/notes-size/)。

## **將 PowerPoint 轉換為含備註的 PDF**

可以使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的 `save` 方法，將 PPT 或 PPTX 簡報轉換為包含講者備註的 PDF。使用 Aspose.Slides 時，只需載入簡報、透過 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 類別設定版面配置以包含講者備註，然後將檔案儲存為 PDF。以下程式碼片段示範如何將範例簡報以「備註投影片」視圖轉換為 PDF。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # 設定 PDF 選項以呈現講者備註。
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # 將簡報儲存為含備註的 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
您可能想要試用 Aspose 的 [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/zh-hant/conversion)。
{{% /alert %}}