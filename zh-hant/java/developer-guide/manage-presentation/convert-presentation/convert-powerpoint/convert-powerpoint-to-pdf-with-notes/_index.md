---
title: 使用 Java 轉換 PowerPoint 簡報為含備註的 PDF
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
- 講者備註
- 含備註的 PDF
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PPT 與 PPTX 轉換為含備註的 PDF。保留版面配置與講者備註，打造專業簡報。"
---
## **概述**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為包含講者備註的 PDF 格式。本指南將說明必要的步驟並提供程式碼範例，協助您有效完成此任務。閱讀完本文後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留講者備註。
- 自訂輸出 PDF，確保講者備註被納入並依您的需求進行格式化。

若需在匯出前設定備註頁面的尺寸與方向，請參閱 [備註頁面大小](/slides/zh-hant/java/notes-size/)。

## **將 PowerPoint 轉換為含備註的 PDF**

`save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別中使用，將 PPT 或 PPTX 簡報轉換為含講者備註的 PDF。使用 Aspose.Slides 時，只需載入簡報、使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/notescommentslayoutingoptions/) 類別設定版面配置以包含講者備註，然後將檔案另存為 PDF。以下程式碼範例示範如何在備註投影片模式下將範例簡報轉換為 PDF。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// 配置 PDF 選項以呈現講者備註。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方呈現講者備註。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// 將簡報儲存為含講者備註的 PDF。
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
您可能想要試用 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。
{{% /alert %}}