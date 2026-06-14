---
title: 使用 C++ 將 PowerPoint 簡報轉換為含備註的 PDF
linktitle: PowerPoint 轉 PDF 含備註
type: docs
weight: 50
url: /zh-hant/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PPT 與 PPTX 格式轉換為含備註的 PDF。保留版面配置與講者備註，打造專業簡報。"
---
## **概述**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為帶有講者備註的 PDF 格式。本指南將說明必要的步驟並提供程式碼範例，協助您有效完成此任務。閱讀完本文後，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留講者備註。
- 自訂輸出 PDF，以確保講者備註被納入且依您的需求進行格式化。

## **將 PowerPoint 轉換為包含備註的 PDF**

`Save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別中使用，以將 PPT 或 PPTX 簡報轉換為包含講者備註的 PDF。使用 Aspose.Slides，您只需載入簡報，透過 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別設定版面選項以包含講者備註，然後將檔案另存為 PDF。以下程式碼片段示範如何將範例簡報轉換為備註投影片檢視的 PDF。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 設定 PDF 選項以呈現講者備註。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在投影片下方呈現講者備註。
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 將簡報儲存為含講者備註的 PDF。
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
您可能想要查看 Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}