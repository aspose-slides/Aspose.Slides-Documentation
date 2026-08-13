---
title: 將 PowerPoint 簡報轉換為 .NET 中的 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/net/convert-powerpoint-to-word/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 Word
- 簡報 轉 Word
- 投影片 轉 Word
- PPT 轉 Word
- PPTX 轉 Word
- PowerPoint 轉 DOCX
- 簡報 轉 DOCX
- 投影片 轉 DOCX
- PPT 轉 DOCX
- PPTX 轉 DOCX
- PowerPoint 轉 DOC
- 簡報 轉 DOC
- 投影片 轉 DOC
- PPT 轉 DOC
- PPTX 轉 DOC
- 儲存 PPT 為 DOCX
- 儲存 PPTX 為 DOCX
- 匯出 PPT 為 DOCX
- 匯出 PPTX 為 DOCX
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中將 PowerPoint PPT 與 PPTX 投影片轉換為可編輯的 Word 文件，精確保留版面配置、圖像與格式。"
---
## **概觀**

本文為開發人員提供使用 Aspose.Slides for .NET 與 Aspose.Words for .NET 將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件的解決方案。一步步的指南將帶您完成轉換過程的每個階段。

## **將簡報轉換為 Word 文件**

請依照以下說明，將 PowerPoint 或 OpenDocument 簡報轉換為 Word 文件：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別並載入簡報檔案。
2. 實例化 [Document](https://reference.aspose.com/words/net/aspose.words/document/) 與 [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 類別，以產生 Word 文件。
3. 使用 [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 屬性設定 Word 文件的頁面大小，使其與簡報相同。
4. 使用 [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 屬性設定 Word 文件的邊距。
5. 使用 [Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 屬性遍歷所有簡報投影片。
    - 使用 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 介面的 `GetImage` 方法產生投影片影像，並儲存至記憶體串流。
    - 使用 [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 類別的 `InsertImage` 方法將投影片影像加入 Word 文件。
6. 將 Word 文件儲存至檔案。

假設我們有一個名為「sample.pptx」的簡報，其內容如下：

![PowerPoint presentation](PowerPoint.png)

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為 Word 文件：

```cs
using Aspose.Slides;
using Aspose.Words;

// 載入簡報檔案。
using var presentation = new Presentation("sample.pptx");

// 建立 Document 與 DocumentBuilder 物件。
var document = new Document();
var builder = new DocumentBuilder(document);

// 設定 Word 文件的頁面大小。
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// 設定 Word 文件的邊距。
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// 歸遍所有簡報投影片。
foreach (var slide in presentation.Slides)
{
    // 產生投影片影像並儲存至記憶體串流。
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // 將投影片影像加入 Word 文件。
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// 將 Word 文件儲存至檔案。
document.Save("output.docx");
```

結果：

![Word document](Word.png)

{{% alert color="info" %}} 
試用我們的[**線上 PPT 轉 Word 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word) ，了解將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件能為您帶來什麼好處。 
{{% /alert %}}

## **常見問題**

### 需要安裝哪些元件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？

您只需在 C# 專案中加入對應的 [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) 與 [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) NuGet 套件。兩個函式庫皆為獨立 API，無需安裝 Microsoft Office。

### 是否支援所有 PowerPoint 與 OpenDocument 簡報格式？

Aspose.Slides for .NET [支援所有簡報格式](/slides/zh-hant/net/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您能處理使用各種版本 Microsoft PowerPoint 所建立的簡報。