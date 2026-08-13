---
title: 於 Android 上將 PowerPoint 簡報轉換為含備註的 PDF
linktitle: PowerPoint 轉 PDF 含備註
type: docs
weight: 50
url: /zh-hant/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- 演講者備註
- 含備註的 PDF
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 環境將 PPT 與 PPTX 格式轉換為含備註的 PDF。保留版面配置與演講者備註，以呈現專業的簡報。"
---
## **概觀**

在本篇文章中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為含演講者備註的 PDF 格式。此指南將說明必要的步驟並提供程式碼範例，協助您有效完成此任務。閱讀完本篇文章後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留演講者備註。
- 自訂輸出 PDF，確保演講者備註已包含且依需求進行格式設定。

## **將 PowerPoint 轉換為含備註的 PDF**

`save` 方法位於 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別中，可用於將 PPT 或 PPTX 簡報轉換為含演講者備註的 PDF。使用 Aspose.Slides，只需載入簡報，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 類別設定版面配置以包含演講者備註，然後將檔案儲存為 PDF。以下程式碼片段示範如何將範例簡報轉換為備註投影片檢視的 PDF。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// 設定 PDF 選項以呈現演講者備註。
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方呈現演講者備註。

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// 儲存簡報為含演講者備註的 PDF。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
您可能想要查看 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}