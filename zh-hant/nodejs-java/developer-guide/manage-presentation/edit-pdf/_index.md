---
title: 在 JavaScript 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/nodejs-java/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中透過匯入至 Aspose.Slides、取代文字，並將修改後的簡報儲存回 PDF，來編輯 PDF 文件。"
---
## **概觀**

Aspose.Slides for Node.js via Java 讓您透過將 PDF 頁面匯入為投影片、修改簡報，然後再匯出回 PDF 來編輯 PDF 內容。本篇文章示範簡單的文字取代。簡報保留在記憶體中，因此儲存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [addFromPdf](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/#addFromPdf) 匯入頁面，使用 [replaceText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#replaceText) 更新文字，並使用 [save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 匯出結果。

以下範例假設 `input.pdf` 在匯入後包含可編輯的文字「Draft」。它會將該文字取代為「Final」並寫入 `edited.pdf`。在匯入前清除初始投影片可避免輸出中出現額外的空白頁。搜尋會以完整單字且大小寫相同的方式匹配；`null` 表示不需要結果回呼。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

欲取得更多選項，請參閱 [Search and Replace Text](/slides/zh-hant/nodejs-java/search-and-replace-text/) 與 [Convert PowerPoint to PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於已匯入的文字，而不適用於掃描圖像中的文字。轉換可能會影響版面配置與格式，因此請檢查輸出結果，特別是當取代文字長度超過原文字時。
{{% /alert %}}

## **常見問題**

**在匯出 PDF 之前需要先儲存 PPTX 檔案嗎？**

不需要。您可以在記憶體中編輯並匯出同一個簡報。僅在您還想在 PowerPoint 中繼續編輯時才儲存 PPTX 副本；請參閱 [Save Presentations](/slides/zh-hant/nodejs-java/save-presentation/)。

**為什麼有些文字仍未變更？**

此範例以完整單字「Draft」且完全相同的大小寫進行匹配。以影像匯入的文字或分散於不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容並針對您的文件調整搜尋方式。