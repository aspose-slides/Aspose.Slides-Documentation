---
title: 在 Android 上編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/androidjava/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉換為 PPTX
- PPTX 轉換為 PDF
- Android
- Java
- Aspose.Slides
description: "使用 Java 在 Android 上編輯 PDF 文件，方法是將其匯入 Aspose.Slides，取代文字，並將修改後的簡報儲存回 PDF。"
---
## **概觀**

Aspose.Slides for Android via Java 讓您透過將 PDF 頁面匯入為投影片、修改簡報，然後再匯出回 PDF 來編輯 PDF 內容。本文示範一個簡單的文字取代。簡報保留在記憶體中，因此儲存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [addFromPdf](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) 來匯入頁面，使用 [replaceText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) 來更新文字，並使用 [save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 來匯出結果。

以下範例假設 `input.pdf` 在匯入後包含可編輯的「Draft」字詞。程式會將該字詞取代為「Final」並寫入 `edited.pdf`。在匯入前清除第一張投影片可避免輸出中出現額外的空白頁面。搜尋會以完整字詞且同樣大小寫進行比對；`null` 代表不需要結果回呼。

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

欲取得更多選項，請參閱 [搜尋與取代文字](/slides/zh-hant/androidjava/search-and-replace-text/) 與 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}

文字取代只會作用於已匯入的文字，而不會作用於掃描影像中的文字。轉換可能會影響版面配置與格式，請務必檢查輸出結果，尤其是取代文字長於原文字時。

{{% /alert %}}

## **常見問題**

**我需要先儲存 PPTX 檔案再匯出 PDF 嗎？**

不需要。您可以在記憶體中直接編輯並匯出同一個簡報。只有在您還想在 PowerPoint 中繼續編輯時才需要儲存 PPTX 副本；請參閱 [儲存簡報](/slides/zh-hant/androidjava/save-presentation/)。

**為什麼有些文字仍未變更？**

範例是以完整的「Draft」字詞且完全相同的大小寫進行比對。以影像形式匯入的文字或分散於不同文字框的文字未必會符合搜尋條件。請檢查匯入的內容，並依文件需求調整搜尋方式。