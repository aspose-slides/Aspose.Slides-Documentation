---
title: 在 .NET 中將 PowerPoint 簡報轉換為含筆記的 PDF
linktitle: PowerPoint 轉 PDF 含筆記
type: docs
weight: 50
url: /zh-hant/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PDF
- 簡報轉 PDF
- 投影片轉 PDF
- PPT 轉 PDF
- PPTX 轉 PDF
- 將簡報儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 演講者筆記
- 含筆記的 PDF
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PPT 與 PPTX 格式轉換為含筆記的 PDF。保留版面配置與演講者筆記，以製作專業簡報。"
---
## **概述**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為含有演講者筆記的 PDF 格式。此指南將說明必須的步驟，並提供程式碼範例，協助您有效完成此任務。閱讀完本文後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留演講者筆記。
- 自訂輸出 PDF，確保演講者筆記依您的需求被包含與格式化。

## **將 PowerPoint 轉換為含筆記的 PDF**

`Save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別中用來將 PPT 或 PPTX 簡報轉換為含演講者筆記的 PDF。使用 Aspose.Slides，您只需載入簡報，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 類別設定版面配置以包含演講者筆記，然後將檔案另存為 PDF。以下程式碼片段示範如何在「筆記投影片」檢視模式下，將範例簡報轉換為 PDF。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 配置 PDF 選項以渲染演講者筆記。
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在投影片下方渲染演講者筆記。
        }
    };

    // 將簡報儲存為含筆記的 PDF。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
您可能想要查看 Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}