---
title: 在 Android 上將 PowerPoint 簡報轉換為含備註的 PDF
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
- 將簡報另存為 PDF
- 將 PPT 另存為 PDF
- 將 PPTX 另存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 講者備註
- 含備註的 PDF
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 透過 Java，將 PPT 與 PPTX 格式轉換為含備註的 PDF。保留版面配置與講者備註，以製作專業簡報。"
---
## **概覽**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為包含講者備註的 PDF 格式。本指南將說明必要的步驟，並提供程式碼範例，協助您有效完成此任務。閱讀完本文後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留講者備註。
- 自訂輸出 PDF，確保講者備註被納入並依您的需求進行格式化。

## **將 PowerPoint 轉換為含備註的 PDF**

您可以使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別中的 `save` 方法，將 PPT 或 PPTX 簡報轉換為包含講者備註的 PDF。使用 Aspose.Slides，只需載入簡報、使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 類別設定版面配置以納入講者備註，然後將檔案另存為 PDF。以下程式碼片段示範如何將範例簡報在備註投影片檢視中轉換為 PDF。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// 配置 PDF 選項以渲染講者備註。
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在投影片下方呈現講者備註。

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// 將簡報儲存為含講者備註的 PDF。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
您可能想要查看 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}