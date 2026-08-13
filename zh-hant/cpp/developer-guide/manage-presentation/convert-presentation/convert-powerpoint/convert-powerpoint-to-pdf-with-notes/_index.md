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
- 將簡報儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 演講者備註
- 含備註的 PDF
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PPT 與 PPTX 格式轉換為含備註的 PDF。保留版面配置與演講者備註，以製作專業簡報。"
---
## **概覽**

在本文中，您將學習如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為包含演講者備註的 PDF 格式。本指南將說明必要的步驟並提供程式碼範例，以協助您高效完成此任務。閱讀本文結束時，您將能夠：

- 實作轉換流程，將 PowerPoint 投影片轉換為 PDF 文件，同時保留演講者備註。
- 自訂輸出 PDF，確保演講者備註已包含且依照您的需求進行格式化。

## **將 PowerPoint 轉換為含備註的 PDF**

`Save` 方法位於 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別中，可用於將 PPT 或 PPTX 簡報轉換為包含演講者備註的 PDF。使用 Aspose.Slides，您只需載入簡報，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別設定版面配置以包含演講者備註，然後將檔案儲存為 PDF。以下程式碼片段示範如何將範例簡報轉換為「備註投影片」檢視模式的 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 配置 PDF 選項以呈現演講者備註。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在投影片下方呈現演講者備註。
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
您可能想要查看 Aspose [線上 PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion)。 
{{% /alert %}}