---
title: 在 C++ 中的進階簡報文字擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/cpp/extract-text-from-presentation/
keywords:
- 擷取文字
- 從投影片擷取文字
- 從簡報擷取文字
- 從 PowerPoint 擷取文字
- 從 OpenDocument 擷取文字
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
- 取得文字
- 從投影片取得文字
- 從簡報取得文字
- 從 PowerPoint 取得文字
- 從 OpenDocument 取得文字
- 從 PPT 取得文字
- 從 PPTX 取得文字
- 從 ODP 取得文字
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速從 PowerPoint 與 OpenDocument 簡報擷取文字。遵循我們簡單、一步步的指南以節省時間。"
---
## **概觀**

從簡報中擷取文字是開發人員處理投影片內容時常見且必要的工作。無論您是處理 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，還是 OpenDocument 簡報 (ODP)，取得文字資料對於分析、自動化、索引或內容遷移都有關鍵作用。

本文提供了使用 Aspose.Slides for C++ 從各種簡報格式（包括 PPT、PPTX 和 ODP）有效擷取文字的完整指南。您將學會如何系統性地遍歷簡報元素，精確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for C++ 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/) 命名空間，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/) 類別。此類別提供多個重載的靜態方法，用於從整個簡報或單一投影片擷取所有文字。若要從簡報中的投影片擷取文字，請使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受一個 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseslide/) 物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 物件陣列，保留所有文字格式資訊。

以下程式碼片段會擷取簡報第一張投影片的所有文字：

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **從簡報擷取文字**

若要掃描整個簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/) 類別提供的 [GetAllTextFrames](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/getalltextframes/) 靜態方法。它接受兩個參數：

1. 首先，一個代表 PowerPoint 或 OpenDocument 簡報的 [IPresentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/) 物件，將從中擷取文字。
1. 其次，一個 `Boolean` 值，指示在掃描簡報文字時是否應包含母版投影片。

此方法回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 物件陣列，內含文字格式資訊。以下程式碼會掃描簡報（含母版投影片）的文字與格式細節：

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **分類與快速文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/) 類別同樣提供了從簡報擷取所有文字的方法：

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textextractionarrangingmode/) 列舉參數指示文字擷取結果的組織模式，可設為下列值：
- `Unarranged` - 未依投影片位置排列的原始文字。
- `Arranged` - 文字依投影片上的順序排列。

在速度至關重要時，可使用未排列模式；它比排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationtext/) 代表從簡報擷取的原始文字。其 `get_SlidesText()` 方法回傳一個 [ISlideText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidetext/) 物件陣列。每個物件代表對應投影片上的文字。類型為 [ISlideText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidetext/) 的物件擁有以下方法：

- `get_Text()` - 投影片形狀內的文字。
- `get_MasterText()` - 與此投影片相關的母版投影片形狀內的文字。
- `get_LayoutText()` - 與此投影片相關的版面配置投影片形狀內的文字。
- `get_NotesText()` - 投影片備註形狀內的文字。
- `get_CommentsText()` - 與此投影片相關的評論文字。

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **常見問題**

**Aspose.Slides 在大量簡報的文字擷取過程中速度如何？**

Aspose.Slides 針對高效能進行了最佳化，即使是 [大型簡報](/slides/zh-hant/cpp/open-presentation/)，也能快速處理，適用於即時或批次處理情境。

**Aspose.Slides 能否從簡報中的表格與圖表擷取文字？**

可以。Aspose.Slides 能從許多投影片元素（包括表格與圖表相關物件）擷取文字，讓您能存取並分析常見簡報結構中的文字內容。

**擷取簡報文字是否需要特別的 Aspose.Slides 授權？**

您可使用 Aspose.Slides 的免費試用版進行文字擷取，但會有 [某些限制](/slides/zh-hant/cpp/licensing/)，例如只能處理有限張數的投影片。若需無限制使用並處理更大的簡報，建議購買完整授權。