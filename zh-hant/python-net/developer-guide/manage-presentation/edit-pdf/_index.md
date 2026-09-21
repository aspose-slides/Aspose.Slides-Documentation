---
title: 在 Python 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/python-net/edit-pdf/
keywords:
- 編輯 PDF
- 替換 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- Python
- Aspose.Slides
description: "在 Python 中透過 Aspose.Slides 匯入 PDF，取代文字，並將修改後的簡報儲存回 PDF，以編輯 PDF 文件。"
---
## **概述**

Aspose.Slides for Python via .NET 讓您透過將 PDF 頁面匯入為投影片、修改簡報，並將其匯出回 PDF 來編輯 PDF 內容。本文示範簡單的文字取代。簡報保留在記憶體中，因此儲存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [add_from_pdf](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidecollection/add_from_pdf/) 匯入頁面，使用 [replace_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/replace_text/) 更新文字，並使用 [save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 匯出結果。

以下範例假設在匯入後 `input.pdf` 包含可編輯的文字 "Draft"。它會將該字詞取代為 "Final" 並寫入 `edited.pdf`。在匯入前清除初始投影片可避免輸出中出現額外的空白頁面。搜尋會以完整單詞且相同大小寫進行匹配；`None` 表示不需要結果回呼。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

如需更多選項，請參閱 [Search and Replace Text](/slides/zh-hant/python-net/search-and-replace-text/) 與 [Convert PowerPoint to PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於匯入的文字，而不適用於掃描圖像內的文字。轉換可能會影響版面配置和格式，請檢查輸出結果，特別是當取代文字長度超過原文字時。
{{% /alert %}}

## **常見問題**

**我需要在匯出 PDF 前先儲存 PPTX 檔案嗎？**

不需要。您可以在記憶體中編輯並匯出相同的簡報。僅在您想要在 PowerPoint 中繼續編輯時才儲存 PPTX 副本；請參閱 [Save Presentations](/slides/zh-hant/python-net/save-presentation/)。

**為什麼有些文字仍然沒有被更改？**

此範例以完全相同的大小寫匹配完整單詞 "Draft"。以圖像匯入的文字或分散在不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容並針對您的文件調整搜尋。