---
title: 將 PowerPoint 簡報轉換為 C++ 中的 Word 文件
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
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT 和 PPTX 投影片轉換為可編輯的 Word 文件，並保留精確的版面配置、圖像和格式。"
---
## **簡介**

如果您打算以新方式使用簡報（PPT 或 PPTX）中的文字內容或資訊，將簡報轉換為 Word（DOC 或 DOCX）可能會對您有幫助。

* 相較於 Microsoft PowerPoint，Microsoft Word 應用程式在內容工具或功能方面更為完善。
* 除了 Word 的編輯功能外，您還可以受惠於增強的協作、列印和分享功能。

{{% alert color="primary" %}} 
您可能想試用我們的[**簡報轉 Word 線上轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word)，了解從投影片文字內容工作可獲得的好處。 
{{% /alert %}} 

## **Aspose.Slides 與 Aspose.Words**

要將 PowerPoint 檔案 (PPTX 或 PPT) 轉換為 Word (DOCX 或 DOC)，您需要同時擁有 [Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/) 和 [Aspose.Words for C++](https://products.aspose.com/words/cpp/)。

作為獨立 API，[Aspose.Slides](https://products.aspose.app/slides) for C++ 提供可從簡報中擷取文字的功能。

[Aspose.Words](https://docs.aspose.com/words/cpp/) 是一個先進的文件處理 API，允許應用程式在不使用 Microsoft Word 的情況下產生、修改、轉換、渲染、列印檔案以及執行其他文件相關工作。

## **將 PowerPoint 簡報轉換為 Word 文件**

使用以下程式碼片段將 PowerPoint 轉換為 Word：

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // 生成並插入投影片影像
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```

## **常見問題**

**需要安裝哪些元件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？**

您只需要將 [Aspose.Slides for C++](https://releases.aspose.com/slides/zh-hant/cpp/) 與 [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) 的相應套件加入專案即可。兩個程式庫皆作為獨立 API 運作，無需安裝 Microsoft Office。

**是否支援所有 PowerPoint 與 OpenDocument 簡報格式？**

Aspose.Slides [支援所有簡報格式](/slides/zh-hant/cpp/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您能使用各版本 Microsoft PowerPoint 所建立的簡報。