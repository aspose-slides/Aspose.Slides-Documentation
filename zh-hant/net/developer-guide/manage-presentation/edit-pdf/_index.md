---
title: 在 .NET 中編輯 PDF 文件
linktitle: 編輯 PDF
type: docs
weight: 65
url: /zh-hant/net/edit-pdf/
keywords:
- 編輯 PDF
- 取代 PDF 文字
- PDF 轉 PPTX
- PPTX 轉 PDF
- .NET
- C#
- Aspose.Slides
description: "在 C# 中透過導入至 Aspose.Slides、取代文字，並將修改後的簡報保存回 PDF，來編輯 PDF 文件。"
---
## **概觀**

Aspose.Slides for .NET 允許您透過將 PDF 頁面匯入為投影片、修改簡報，並匯出回 PDF 來編輯 PDF 內容。本文章示範簡單的文字取代。簡報保留在記憶體中，因此儲存中間的 PPTX 檔案是可選的。

## **在 PDF 中取代文字**

使用 [AddFromPdf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/addfrompdf/) 匯入頁面，使用 [ReplaceText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/replacetext/) 更新文字，並使用 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 匯出結果。

以下範例假設 `input.pdf` 匯入後包含可編輯的文字「Draft」。它會將該字詞取代為「Final」並寫入 `edited.pdf`。在匯入前清除初始投影片可避免輸出中出現額外的空白頁面。搜尋會以相同大小寫匹配完整單字；`null` 表示不需要結果回呼。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

欲了解更多選項，請參閱 [搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/) 與 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
文字取代僅適用於匯入的文字，而非掃描影像中的文字。轉換可能會影響版面配置與格式，因此請檢查輸出，特別是當取代文字長於原始文字時。
{{% /alert %}}

## **常見問題**

**在匯出 PDF 前，我需要先儲存 PPTX 檔案嗎？**

不需要。您可以在記憶體中直接編輯並匯出相同的簡報。只有在您還想在 PowerPoint 中繼續編輯時才需要另存 PPTX 副本；請參閱 [儲存簡報](/slides/zh-hant/net/save-presentation/)。

**為什麼有些文字仍保持不變？**

此範例以完全相同的大小寫匹配完整單字「Draft」。以影像形式匯入的文字或分散於多個文字框的文字不一定會符合搜尋。請檢查匯入的內容，並依據您的文件調整搜尋條件。