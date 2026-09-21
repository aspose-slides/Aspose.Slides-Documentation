---
title: 使用 Python via Java 編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/python-java/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- Python
- Java
- Aspose.Slides
description: "透過 Java 使用 Python，將 PDF 文件匯入 Aspose.Slides，取代文字，並將修改後的簡報儲存回 PDF。"
---
## **概述**

Aspose.Slides for Python via Java 讓您透過將 PDF 頁面匯入為投影片、修改簡報，並匯出回 PDF 來編輯 PDF 內容。本文章示範一個簡單的文字取代。簡報保留在記憶體中，因此保存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addFromPdf) 匯入頁面，使用 [replaceText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#replaceText) 更新文字，並使用 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 匯出結果。

以下範例假設 `input.pdf` 在匯入後包含可編輯的文字 "Draft"。它會將該字取代為 "Final"，並寫入 `edited.pdf`。在匯入前清除初始投影片可防止輸出中出現額外的空白頁面。搜尋會以相同大小寫匹配完整單字；`None` 表示不需要結果回呼。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

欲了解更多選項，請參閱 [Search and Replace Text](/slides/zh-hant/python-java/search-and-replace-text/) 與 [Convert PowerPoint to PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於已匯入的文字，而不會作用於掃描圖像中的文字。轉換可能會影響版面配置與格式，因此請檢查輸出，特別是當取代文字比原文字更長時。
{{% /alert %}}

## **常見問題**

**在匯出 PDF 之前，我需要先保存 PPTX 檔案嗎？**

不需要。您可以在記憶體中編輯並匯出相同的簡報。只有在您還想在 PowerPoint 中繼續編輯時才需要保存 PPTX 副本；請參閱 [Save Presentations](/slides/zh-hant/python-java/save-presentation/)。

**為何某些文字仍保持不變？**

此範例以完全相同的大小寫匹配完整單字「Draft」。以影像形式匯入的文字或分散於不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容並依文件調整搜尋方式。