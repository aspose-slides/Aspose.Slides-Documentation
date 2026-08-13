---
title: 在 C++ 中將 PowerPoint 簡報轉換為 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/cpp/convert-powerpoint-to-word/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
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
- 將 PPT 儲存為 DOCX
- 將 PPTX 儲存為 DOCX
- 匯出 PPT 為 DOCX
- 匯出 PPTX 為 DOCX
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT 與 PPTX 投影片轉換為可編輯的 Word 文件，精確保留版面配置、影像與格式。"
---
## **簡介**

如果您計畫以新方式使用簡報（PPT 或 PPTX）中的文字內容或資訊，將簡報轉換為 Word（DOC 或 DOCX）可能會對您有所幫助。

* 與 Microsoft PowerPoint 相比，Microsoft Word 應用程式在內容處理上提供了更多工具和功能。  
* 除了 Word 的編輯功能外，您還可以受益於加強的協作、列印和分享功能。

{{% alert color="info" %}} 
您可以嘗試我們的[**簡報轉 Word 線上轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word)，了解從投影片中取得文字內容的好處。 
{{% /alert %}} 

## **Aspose.Slides 與 Aspose.Words**

若要將 PowerPoint 檔案（PPTX 或 PPT）轉換為 Word（DOCX 或 DOC），您需要同時使用 [Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/) 與 [Aspose.Words for C++](https://products.aspose.com/words/cpp/)。

作為獨立 API 的 [Aspose.Slides](https://products.aspose.app/slides) for C++ 提供了從簡報中擷取文字的功能。

[Aspose.Words](https://docs.aspose.com/words/cpp/) 是一個先進的文件處理 API，允許應用程式在不使用 Microsoft Word 的情況下生成、修改、轉換、呈現、列印檔案以及執行其他文件相關任務。

## **將 PowerPoint 簡報轉換為 Word 文件**

使用以下程式碼片段將 PowerPoint 轉換為 Word：

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // 產生投影片影像作為位元組陣列串流
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // 插入投影片的文字
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **常見問題集**

### 需要安裝哪些組件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？

只需將 [Aspose.Slides for C++](https://releases.aspose.com/slides/zh-hant/cpp/) 與 [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) 的相應套件加入您的專案即可。兩個庫皆為獨立 API，無需安裝 Microsoft Office。

### 是否支援所有 PowerPoint 與 OpenDocument 簡報格式？

Aspose.Slides [支援所有簡報格式](/slides/zh-hant/cpp/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您可以處理在不同版本的 Microsoft PowerPoint 中建立的簡報。