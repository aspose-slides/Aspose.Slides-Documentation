---
title: 在 C++ 中搜尋與取代 PowerPoint 簡報的文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/cpp/search-and-replace-text/
keywords:
- 搜尋文字
- 標註文字
- 取代文字
- 正規表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中搜尋、標註與取代文字，同時收集每一次匹配。"
---
## **概述**

Aspose.Slides for C++ 可以在單一文字框或整個簡報中搜尋、標註和取代文字。每個操作也可以透過結果回呼通知應用程式每一次匹配。這使得在更新簡報的同時，能建立包含匹配文字、其上下文、位置、文字框與投影片編號的稽核追蹤。

這些功能對於審閱、編輯隱私、術語檢查、範本清理以及自動化報告工作流程非常有用。

在以下第一個範例中，我們使用名為 "sample.pptx" 的檔案，該檔案在第一張投影片上包含一個單一文字方塊，內含以下文字：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)的方法將作業限制在單一文字框。使用[IPresentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/)的方法處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 標註純文字 | [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlighttext/) |
| 標註正規表達式匹配 | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlightregex/) |
| 取代純文字 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replacetext/) |
| 取代正規表達式匹配 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replaceregex/) |

## **設定文字匹配**

對於純文字操作，使用[ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/)來控制匹配：

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 限制匹配僅為完整單詞。
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 控制是否必須匹配字元大小寫。
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 將投影片備註納入簡報層級的搜尋、取代與標註操作。

正規表達式操作使用 `System::Text::RegularExpressions::Regex`，因此大小寫敏感度與單詞邊界等匹配規則由正則表達式本身及其選項定義。

## **識別文字框的擁有者**

通用的文字處理工作流程常在搜尋、取代、驗證或匯出文字時收到[ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。使用[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentshape/)和[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentcell/)可判斷是哪個簡報物件擁有此文字框。

預期值取決於擁有者：

| 文字框擁有者 | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape 或其他包含文字的圖形 | 擁有的[IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) | `nullptr` |
| 表格儲存格 | `nullptr` | 擁有的[ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/) |

兩個方法皆提供唯讀導覽。呼叫它們不會移動文字框或變更其擁有者。通用程式碼應檢查兩個值是否為`nullptr`，並處理兩者皆不可用的情況。

以下範例使用[SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/getalltextframes/)遍歷簡報中的文字框。對於圖形，會回報圖形名稱、C++ 執行時類型以及所在投影片。對於表格儲存格，會回報零基礎的欄與列座標以及所在投影片。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

對於 SmartArt 內容，遍歷[ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/ismartartnode/get_shapes/)中的圖形，並存取每個[ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/ismartartshape/get_textframe/)。文字框可透過[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentshape/)追溯至其關聯的圖形，而[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentcell/)則回傳`nullptr`。因此，範例中的圖形分支也會處理來自 SmartArt 節點的文字。

## **使用回呼收集匹配資訊**

實作[IFindResultCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifindresultcallback/)以接收每一次匹配的通知。其[IFindResultCallback::FoundResult](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifindresultcallback/foundresult/)方法提供相關的文字框、來源文字、匹配文字與匹配位置。

回呼不會直接收到投影片編號。以下實作從[ISlideComponent::get_Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecomponent/get_slide/)推導編號，並同時處理透過[INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslide/get_parentslide/)在備註投影片中找到的文字。可為空的投影片編號允許相同的結果模型表示與其他投影片類型相關的文字。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

對於取代操作，`FoundText` 包含原始匹配文字，回呼因此能精確記錄哪些詞彙被取代。

## **標註文字**

使用[ITextFrame::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/)方法在文字框中標註純文字匹配。傳入[ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/)控制搜尋，並提供回呼以收集匹配細節。

以下程式碼範例先標註所有 **"try"** 字元的出現，接著僅標註完整單詞 **"to"**。兩次搜尋皆將匹配結果回報給同一回呼。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 取得第一張投影片的第一個圖形。
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// 在文字框中標註所有出現的「try」。
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// 僅標註完整單詞「to」。
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![已標註的文字](highlighted_text.png)

## **使用正規表達式標註文字**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/)方法標註文字框中符合正規表達式的文字匹配。

以下程式碼標註所有包含七個以上字元的單詞，並收集每一次匹配：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![使用正規表達式標註的文字](highlighted_text_using_regex.png)

## **跨簡報標註文字**

使用[IPresentation::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlighttext/)與[IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlightregex/)搜尋簡報中所有適用的文字框。以下範例同時標註一個純文字術語與所有電子郵件地址，並為兩個搜尋保留獨立的結果集合。

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **在文字框中取代文字**

使用[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/)取代純文字，使用[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/)進行基於模式的取代。這些方法會在既有文字框內更新匹配文字，保留其周圍部分的格式，而不是以純字串重新建構文字框。

以下範例先標準化一個拼寫變體，然後取代版本標籤。相同的回呼記錄兩個操作所匹配的原始詞彙。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果某個匹配跨越不同格式的區段，請檢查輸出以確認應套用哪種格式於取代文字。

## **跨簡報取代文字**

使用[IPresentation::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replacetext/)與[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replaceregex/)在整個簡報套用相同的操作。此功能適用於範本清理、術語更新與編輯隱私。

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **分組匹配以供報告**

因為每個結果都儲存其投影片編號與文字框，應用程式可以依照稽核、報告或審閱工作流程將匹配分組。以下範例先依投影片再依文字框分組收集的結果：

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **常見問題**

**如何僅搜尋單一文字方塊，而非整個簡報？**

取得圖形的文字框，然後對該文字框呼叫[ITextFrame::HighlightText]、[ITextFrame::HighlightRegex]、[ITextFrame::ReplaceText]或[ITextFrame::ReplaceRegex]。簡報層級的方法則會處理所有適用的文字框。

**如何匹配完整單詞且大小寫正確？**

對[ITextSearchOptions::set_WholeWordsOnly]與[ITextSearchOptions::set_CaseSensitive]傳入`true`，並將選項傳遞給純文字的標註或取代方法。對於正規表達式，請在`System::Text::RegularExpressions::Regex`本身定義單詞邊界與大小寫敏感度。

**搜尋與取代可以包含投影片備註中的文字嗎？**

可以。於使用簡報層級的純文字操作時，將[ITextSearchOptions::set_IncludeNotes]設為`true`。上述回呼實作會將備註投影片中的匹配映射回其母投影片編號。

**如何在不第二次掃描簡報的情況下建立報告？**

將[IFindResultCallback]實作傳遞給標註或取代操作。回呼會在操作執行期間收到每一次匹配，因而可儲存來源文字、匹配文字、位置、文字框與推導出的投影片編號，以供稍後分組或匯出。

**取代文字會保留其格式嗎？**

[ITextFrame::ReplaceText]與[ITextFrame::ReplaceRegex]會在既有文字框內修改匹配文字，並保留其周圍部分的格式。如果匹配跨越不同格式的區段，請檢查結果以確保取代後使用的樣式符合預期。