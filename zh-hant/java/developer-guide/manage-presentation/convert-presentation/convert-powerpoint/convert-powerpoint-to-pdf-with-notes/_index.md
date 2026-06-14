---
title: 使用 Java 將 PowerPoint 簡報轉換為含備註的 PDF
linktitle: PowerPoint 轉 PDF（含備註）
type: docs
weight: 50
url: /zh-hant/java/convert-powerpoint-to-pdf-with-notes/
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
- 將簡報另存為 PDF
- 將 PPT 另存為 PDF
- 將 PPTX 另存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 投影片備註
- 含備註的 PDF
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PPT 與 PPTX 格式轉換為含備註的 PDF。保留版面配置與投影片備註，以打造專業簡報。"
---
## **概觀**

在本篇文章中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為包含投影片備註的 PDF 格式。本指南將說明必要的步驟，並提供程式碼範例，協助您有效完成此任務。閱讀完本篇文章後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留投影片備註。
- 客製化輸出的 PDF，確保備註依據您的需求正確納入並排版。

## **將 PowerPoint 轉換為含備註的 PDF**

`save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別中使用，將 PPT 或 PPTX 簡報轉換為帶有投影片備註的 PDF。使用 Aspose.Slides 時，您只需載入簡報，透過 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 類別設定版面配置以包含備註，然後將檔案另存為 PDF。以下程式碼片段示範如何在備註投影片檢視模式下，將範例簡報轉換為 PDF。

```java
Presentation presentation = new Presentation("sample.pptx");

// 設定 PDF 選項以呈現投影片備註。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方呈現投影片備註。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
您可能想要查看 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}