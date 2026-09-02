---
title: C++에서 PowerPoint 프레젠테이션의 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/cpp/search-and-replace-text/
keywords:
- 텍스트 검색
- 텍스트 강조
- 텍스트 교체
- 정규식
- 결과 콜백
- 텍스트 프레임
- 감사 보고서
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하면서 모든 일치를 수집합니다."
---
## **개요**

Aspose.Slides for C++는 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 표시 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 일치 항목마다 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치된 텍스트, 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함하는 감사 로그를 동시에 작성할 수 있습니다.

이 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 “sample.pptx” 파일을 사용합니다.

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)의 메서드를 사용하면 작업을 하나의 텍스트 프레임으로 제한할 수 있습니다. [IPresentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/)의 메서드를 사용하면 프레젠테이션 전체의 적용 가능한 모든 텍스트를 처리합니다.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 텍스트 리터럴 강조 | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/highlighttext/) |
| 정규식 일치 강조 | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/highlightregex/) |
| 텍스트 리터럴 교체 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/replacetext/) |
| 정규식 일치 교체 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/replaceregex/) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에서는 [ITextSearchOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/)를 사용해 매칭을 제어합니다.

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/)은 전체 단어에만 일치하도록 제한합니다.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_casesensitive/)은 대소문자 일치를 요구할지 제어합니다.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_includenotes/)는 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 `System::Text::RegularExpressions::Regex`를 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 정규식 자체와 옵션에 의해 정의됩니다.

## **콜백으로 일치 정보 수집**

[IFindResultCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifindresultcallback/)을 구현하여 모든 일치에 대한 알림을 받을 수 있습니다. 해당 인터페이스의 [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifindresultcallback/foundresult/) 메서드는 연관된 텍스트 프레임, 원본 텍스트, 일치 텍스트 및 일치 위치를 제공합니다.

콜백은 슬라이드 번호를 직접 받지 않습니다. 아래 구현은 [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islidecomponent/get_slide/)에서 파생하고, [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotesslide/get_parentslide/)을 통해 노트 슬라이드의 텍스트도 처리합니다. nullable 슬라이드 번호를 사용하면 동일한 결과 모델이 다른 슬라이드 유형에 연결된 텍스트를 나타낼 수 있습니다.

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

교체 작업에서는 `FoundText`가 원본 일치 텍스트를 포함하므로 콜백은 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[ITextFrame::HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlighttext/) 메서드를 사용해 텍스트 프레임 내 리터럴 텍스트 일치를 강조합니다. 검색을 제어하려면 [ITextSearchOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/)를 전달하고, 일치 상세 정보를 수집하려면 콜백을 전달합니다.

아래 코드 예제는 **“try”** 문자들의 모든 발생을 강조한 다음, 전체 단어 **“to”**만 강조합니다. 두 검색 모두 같은 콜백에 일치를 보고합니다.

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

// 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// 텍스트 프레임에서 "try"의 모든 발생을 강조합니다.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// 전체 단어 "to"만 강조합니다.
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

결과:

![하이라이트된 텍스트](highlighted_text.png)

## **정규식으로 텍스트 강조**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlightregex/) 메서드는 정규식으로 찾은 텍스트 일치를 텍스트 프레임에 강조합니다.

다음 코드는 길이가 7자 이상인 모든 단어를 강조하고 각 일치를 수집합니다.

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

결과:

![정규식을 사용한 하이라이트된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체에서 텍스트 강조**

[IPresentation::HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/highlighttext/)와 [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/highlightregex/)를 사용해 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 각각 별도 결과 컬렉션에 저장하면서 강조합니다.

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

## **텍스트 프레임에서 텍스트 교체**

리터럴 텍스트에는 [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replacetext/)를, 패턴 기반 교체에는 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replaceregex/)를 사용합니다. 이러한 메서드는 기존 텍스트 프레임 내부의 일치 텍스트만 업데이트하므로 주변 부분의 서식은 유지됩니다.

다음 예제는 철자 변형을 표준화한 뒤 버전 레이블을 교체합니다. 동일한 콜백이 두 작업 모두에서 원본 용어를 기록합니다.

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

하나의 일치가 서로 다른 서식을 가진 부분을 포함하는 경우, 교체 텍스트에 적용될 서식을 확인하기 위해 출력을 검토하십시오.

## **프레젠테이션 전체에서 텍스트 교체**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/replacetext/)와 [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipresentation/replaceregex/)를 사용해 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

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

## **보고서를 위한 일치 그룹화**

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로, 애플리케이션은 감사, 보고 또는 검토 워크플로를 위해 일치를 그룹화할 수 있습니다. 아래 예제는 수집된 결과를 먼저 슬라이드별, 다음 텍스트 프레임별로 그룹화합니다.

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

## **FAQ**

**하나의 텍스트 상자만 검색하고 전체 프레젠테이션은 어떻게 피합니까?**

해당 도형의 텍스트 프레임을 가져와서 [ITextFrame::HighlightText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replacetext/), [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replaceregex/) 중 하나를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어와 정확한 대소문자를 어떻게 매칭합니까?**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/)와 [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_casesensitive/)를 `true`로 설정하고 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 `System::Text::RegularExpressions::Regex` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함될 수 있습니까?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextsearchoptions/set_includenotes/)를 `true`로 설정합니다. 위의 콜백 구현은 노트 슬라이드의 일치를 해당 부모 슬라이드 번호로 매핑합니다.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 만들려면 어떻게 해야 합니까?**

[IFindResultCallback](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ifindresultcallback/) 구현을 강조 또는 교체 작업에 전달합니다. 콜백은 작업이 진행되는 동안 모든 일치를 받으므로, 애플리케이션은 원본 텍스트, 일치 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 보존됩니까?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replacetext/)와 [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/replaceregex/)는 기존 텍스트 프레임 내부의 일치 텍스트를 수정하고 주변 부분 서식을 유지합니다. 일치가 서로 다른 서식을 가진 부분에 걸쳐 있는 경우, 교체 텍스트가 원하는 스타일을 사용하도록 결과를 확인하십시오.