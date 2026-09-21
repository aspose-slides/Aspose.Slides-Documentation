---
title: 在 PHP 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/php-java/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- PHP
- Aspose.Slides
description: "在 PHP 中編輯 PDF 文件，方法是將其匯入 Aspose.Slides、取代文字，然後將修改後的簡報另存為 PDF。"
---
## **概觀**

Aspose.Slides for PHP via Java 讓您透過將 PDF 頁面匯入為投影片、修改簡報，並再匯出回 PDF，來編輯 PDF 內容。本文示範簡單的文字取代。簡報保留在記憶體中，儲存中介的 PPTX 檔案為可選項。

## **在 PDF 中取代文字**

使用 [SlideCollection::addFromPdf](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/#addFromPdf) 匯入頁面，使用 [Presentation::replaceText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#replaceText) 更新文字，並使用 [Presentation::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 匯出結果。

以下範例假設 `input.pdf` 在匯入後包含可編輯的文字「Draft」。它會將該字取代為「Final」並寫入 `edited.pdf`。在匯入前先清除初始投影片可防止輸出中出現額外的空白頁面。搜尋會以全字且區分大小寫的方式匹配；`null` 表示不需要結果回呼。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

欲了解更多選項，請參閱 [Search and Replace Text](/slides/zh-hant/php-java/search-and-replace-text/) 與 [Convert PowerPoint to PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於匯入的文字，掃描圖像內的文字不會被處理。轉換可能影響版面配置與格式，請務必檢查輸出結果，特別是當取代文字長度超過原文字時。
{{% /alert %}}

## **常見問題**

**我需要先儲存 PPTX 檔案再匯出 PDF 嗎？**

不需要。您可以在記憶體中直接編輯並匯出同一份簡報。只有在您仍想在 PowerPoint 中繼續編輯時才需要儲存 PPTX 副本；請參閱 [Save Presentations](/slides/zh-hant/php-java/save-presentation/)。

**為何有些文字仍未被更改？**

範例使用完全相符且大小寫相同的全字「Draft」作為搜尋條件。若文字以圖像形式匯入或分散於不同文字框，則不一定會匹配搜尋。請檢查匯入的內容並針對您的文件調整搜尋條件。