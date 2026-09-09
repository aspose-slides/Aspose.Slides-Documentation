---
title: 在 Python 中將 PowerPoint 簡報轉換為含備註的 PDF
linktitle: PowerPoint 轉 PDF 含備註
type: docs
weight: 50
url: /zh-hant/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- PPTX 轉 PDF
- 將簡報儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 講者備註
- 含備註的 PDF
- Python
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Python via Java 將 PPT 與 PPTX 簡報轉換為含講者備註的 PDF。設定備註位置並保留長備註。
---
## **概述**

本篇文章說明如何使用 Aspose.Slides for Python via Java 將 PowerPoint 簡報轉換為包含講者備註的 PDF。您可以在每張投影片下方加入備註，並允許較長的備註延伸至其他頁面。其他 PDF 匯出設定，請參閱 [Convert PowerPoint to PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)。

## **將 PowerPoint 轉換為包含備註的 PDF**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法將 PPT 或 PPTX 簡報匯出為 PDF。若要包含講者備註，建立一個 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 物件，並使用其 [setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法配置備註位置。將此版面配置指派給 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/)，使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)。

以下範例會載入 `sample.pptx`，並將其匯出為 `output.pdf`，在投影片下方顯示講者備註：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # 設定 PDF 選項以呈現講者備註。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # 將簡報儲存為含講者備註的 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
您也可以嘗試 [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/zh-hant/conversion)。
{{% /alert %}}

## **FAQ**

**如何防止長篇講者備註被截斷？**

使用 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomFull)，如上例所示。此設定會顯示完整備註，必要時使用額外頁面。

**我可以將每張投影片及其備註保留在同一頁面嗎？**

使用 [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomTruncated)。此設定會將備註限制在一頁內，超出部分會被截斷。

**如何匯出沒有講者備註的投影片？**

省略備註版面配置，使用在 [Convert PowerPoint to PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/) 中描述的標準 PDF 匯出方式。