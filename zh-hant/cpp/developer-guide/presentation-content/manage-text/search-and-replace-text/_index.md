---
title: 在 C++ 中搜尋與取代 PowerPoint 簡報文字
linktitle: 搜尋與取代文字
type: docs
weight: 55
url: /zh-hant/cpp/search-and-replace-text/
keywords:
- 搜尋文字
- 突顯文字
- 取代文字
- 正則表達式
- 結果回呼
- 文字框
- 稽核報告
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 PowerPoint 簡報中搜尋、突顯與取代文字，同時使用 Aspose.Slides for C++ 收集每一次符合。"
---
## **概觀**

Aspose.Slides for C++ 可在單一文字框或整個簡報中搜尋、突顯與取代文字。每個操作皆可透過結果回呼通知應用程式每一個符合項目，使得在更新簡報的同時建立包含符合文字、其上下文、位置、文字框與投影片編號的稽核軌跡。

此功能在審閱、遮蔽、術語檢查、範本清理與自動報告工作流程中相當有用。

在以下第一組範例中，我們使用名為「sample.pptx」的檔案，其第一張投影片上有一個文字方塊，內容如下：

![範例文字](sample_text.png)

## **選擇搜尋範圍**

使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 上的方法將操作限制於單一文字框。使用 [IPresentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/) 上的方法則可處理簡報中所有適用的文字。

| 操作 | 單一文字框 | 整個簡報 |
|---|---|---|
| 突顯文字文字 | [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlighttext/) |
| 突顯正規表達式符合項目 | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlightregex/) |
| 取代文字 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replacetext/) |
| 取代正規表達式符合項目 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replaceregex/) |

## **設定文字匹配**

對於文字文字操作，使用 [ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/) 來控制匹配方式：

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 僅限完整單字匹配。
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 控制是否必須符合大小寫。
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 在簡報層級的搜尋、取代與突顯操作中亦包含投影片備註。

正規表達式操作使用 `System::Text::RegularExpressions::Regex`，因此大小寫敏感度與單字邊界等規則由正則表達式本身及其選項決定。

## **使用回呼蒐集符合資訊**

實作 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifindresultcallback/) 以接收每一次符合的通知。其 [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifindresultcallback/foundresult/) 方法會提供相關文字框、來源文字、符合文字與符合位置。

回呼不會直接取得投影片編號。下方的實作會從 [ISlideComponent::get_Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecomponent/get_slide/) 取得，並且透過 [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inotesslide/get_parentslide/) 處理備註投影片中的文字。可為投影片編號設為可為 null，以便同一結果模型也能表達其他類型投影片的文字。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
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
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
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

對於取代操作，`FoundText` 會包含原始符合文字，回呼即可精確記錄哪些詞彙被取代。

## **突顯文字**

使用 [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/) 方法在文字框中突顯文字文字。傳入 [ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/) 以控制搜尋，並提供回呼以蒐集符合細節。

下方程式碼示範先突顯所有 **"try"** 字元，再僅突顯完整單字 **"to"**。兩次搜尋皆會將符合項目回報給同一回呼。

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

// 取得第一張投影片的第一個形狀。
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// 在文字框中突顯所有 "try" 的出現。
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// 僅突顯完整單字 "to"。
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

![突顯的文字](highlighted_text.png)

## **使用正規表達式突顯文字**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/) 方法會突顯文字框中符合正規表達式的文字。

以下程式碼突顯所有包含七個以上字元的單字，並蒐集每一次符合：

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

![使用正規表達式突顯的文字](highlighted_text_using_regex.png)

## **在簡報中突顯文字**

使用 [IPresentation::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlighttext/) 與 [IPresentation::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/highlightregex/) 來搜尋簡報中所有適用的文字框。下例在同一簡報中突顯文字文字與所有電子郵件位址，且為兩次搜尋保留獨立的結果集合。

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

使用 [ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/) 取代文字文字，使用 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/) 取代符合正則表達式的文字。這些方法會在既有文字框內直接更新符合文字，保留周邊文字的格式，而不會以純文字字串重新建立文字框。

以下範例先標準化拼寫變形，接著取代版本標籤。相同的回呼會記錄兩個操作所匹配的原始詞彙。

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

若一次符合跨越不同格式的段落，請檢查輸出以確認取代文字應套用哪種格式。

## **在簡報中取代文字**

使用 [IPresentation::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replacetext/) 與 [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/replaceregex/) 在整個簡報中套用相同的操作。此功能適用於範本清理、術語更新與遮蔽。

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

## **將符合項目分組以供報告**

由於每個結果都儲存了投影片編號與文字框，應用程式可依照稽核、報告或審閱工作流程將符合項目分組。以下範例先依投影片，再依文字框分組蒐集的結果：

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

## **常見問與答**

**如何只搜尋單一文字方塊而非整個簡報？**

取得該圖形的文字框，然後在該文字框上呼叫 [ITextFrame::HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/)、[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/)、[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/) 或 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/)。簡報層級的方法則會處理所有適用的文字框。

**如何匹配完整單字且符合正確的大小寫？**

將 [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) 與 [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) 設為 `true`，並將選項傳遞給文字文字的突顯或取代方法。對於正規表達式，請在 `System::Text::RegularExpressions::Regex` 本身定義單字邊界與大小寫敏感度。

**搜尋與取代時可以包含投影片備註中的文字嗎？**

可以。於簡報層級的文字文字操作時，將 [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/set_includenotes/) 設為 `true`。上方示範的回呼實作會將備註投影片中的符合項目對應回其父投影片編號。

**如何在不再次掃描簡報的情況下產生報告？**

將 [IFindResultCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifindresultcallback/) 實作傳遞給突顯或取代操作。回呼會在操作執行期間即時收到每一次符合，讓應用程式能儲存來源文字、符合文字、位置、文字框與衍生的投影片編號，以供之後分組或匯出。

**取代文字時會保留其格式嗎？**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replacetext/) 與 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/replaceregex/) 會在既有文字框內修改符合文字，並保留周圍部分的格式。如果一次符合跨越不同格式的段落，請檢查結果以確保取代文字使用所需的樣式。