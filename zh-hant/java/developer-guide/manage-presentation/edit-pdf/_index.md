---
title: 在 Java 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/java/edit-pdf/
keywords:
- 編輯 PDF
- 替換 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- Java
- Aspose.Slides
description: "在 Java 中透過將 PDF 匯入 Aspose.Slides、取代文字，並將修改後的簡報儲存回 PDF 來編輯 PDF 文件。"
---
## **概述**

Aspose.Slides for Java 讓您透過將 PDF 頁面匯入為投影片、修改簡報，並再匯出回 PDF，來編輯 PDF 內容。本文展示一個簡單的文字取代範例。簡報保留在記憶體中，因此存儲中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [addFromPdf](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) 匯入頁面，使用 [replaceText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 更新文字，並使用 [save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 匯出結果。

以下範例假設 `input.pdf` 在匯入後包含可編輯的文字「Draft」。它會將該字替換為「Final」並寫入 `edited.pdf`。在匯入前清除初始投影片可防止輸出中出現額外的空白頁面。搜尋會以相同大小寫匹配完整單字；`null` 表示不需要結果回呼。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

欲取得更多選項，請參閱 [Search and Replace Text](/slides/zh-hant/java/search-and-replace-text/) 和 [Convert PowerPoint to PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於匯入的文字，而不適用於掃描影像中的文字。轉換可能會影響版面配置與格式，請檢查輸出內容，特別是當取代文字較原文字更長時。
{{% /alert %}}

## **常見問題**

**在匯出 PDF 之前需要先儲存 PPTX 檔案嗎？**

不需要。您可以在記憶體中編輯並匯出同一份簡報。只有在您還想在 PowerPoint 中繼續編輯時才儲存 PPTX 副本；請參閱 [Save Presentations](/slides/zh-hant/java/save-presentation/)。

**為什麼某些文字可能保持不變？**

此範例以完整單字「Draft」且大小寫完全相同進行匹配。以影像形式匯入或分散於不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容並針對您的文件調整搜尋方式。