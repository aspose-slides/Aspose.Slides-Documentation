---
title: .NET에서 PowerPoint 프레젠테이션의 텍스트 검색 및 교체
linktitle: 텍스트 검색 및 교체
type: docs
weight: 55
url: /ko/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하고 모든 매치를 수집합니다."
---
## **개요**

Aspose.Slides for .NET은 개별 텍스트 프레임 또는 전체 프레젠테이션에서 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 매치마다 애플리케이션에 알릴 수 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 매치된 텍스트, 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함하는 감사 추적을 동시에 작성할 수 있습니다.

이 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 텍스트 상자 내용은 다음과 같습니다:

![Sample text](sample_text.png)

## **검색 범위 선택**

[ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)의 메서드를 사용하면 작업을 하나의 텍스트 프레임으로 제한할 수 있습니다. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)의 메서드를 사용하면 프레젠테이션 전체의 모든 적용 가능한 텍스트를 처리합니다.

| 작업 | 하나의 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlighttext/) |
| 정규식 매치 강조 | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlightregex/) |
| 리터럴 텍스트 교체 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replacetext/) |
| 정규식 매치 교체 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replaceregex/) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업의 경우 [TextSearchOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/)를 사용해 매칭을 제어합니다.

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/wholewordsonly/)은 전체 단어와 일치하도록 제한합니다.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/casesensitive/)은 대소문자 일치를 제어합니다.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/includenotes/)는 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 .NET `Regex`를 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 및 옵션에 의해 정의됩니다.

## **콜백을 통한 매치 정보 수집**

[IFindResultCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/)을 구현하여 모든 매치에 대한 알림을 받습니다. 해당 인터페이스의 [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/foundresult/) 메서드는 관련 텍스트 프레임, 원본 텍스트, 매치된 텍스트 및 매치 위치를 제공합니다.

콜백은 슬라이드 번호를 직접 받지 않습니다. 아래 구현은 부모 슬라이드에서 번호를 파생하고 슬라이드 노트에 있는 텍스트도 처리합니다. nullable 슬라이드 번호를 사용하면 동일한 결과 모델로 다른 슬라이드 유형에 연결된 텍스트를 나타낼 수 있습니다.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

교체 작업의 경우 `FoundText`에 원래 매치된 텍스트가 포함되므로 콜백이 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/) 메서드를 사용해 텍스트 프레임 내 리터럴 텍스트 매치를 강조합니다. 검색을 제어하기 위해 [TextSearchOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/)를 전달하고, 매치 상세 정보를 수집하기 위해 콜백을 전달합니다.

아래 코드 예제는 문자 **"try"**의 모든 발생을 강조한 뒤, 전체 단어 **"to"**만 강조합니다. 두 검색 모두 동일한 콜백에 매치를 보고합니다.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

결과:

![The highlighted text](highlighted_text.png)

## **정규식을 사용한 텍스트 강조**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/) 메서드는 정규식으로 찾은 텍스트 매치를 텍스트 프레임에서 강조합니다.

다음 코드는 7자 이상인 모든 단어를 강조하고 각 매치를 수집합니다:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

결과:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlighttext/)와 [Presentation.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlightregex/)를 사용해 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 각각 별도 결과 컬렉션에 저장하면서 강조합니다.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **텍스트 프레임 내부 텍스트 교체**

리터럴 텍스트의 경우 [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/)를, 패턴 기반 교체의 경우 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)를 사용합니다. 이 메서드들은 기존 텍스트 프레임 내에서 매치된 텍스트만 업데이트하므로 주변 서식은 유지되고 전체 문자열로 프레임을 재구성하지 않습니다.

다음 예제는 철자 변형을 표준화한 뒤 버전 라벨을 교체합니다. 동일한 콜백이 두 작업에서 매치된 원본 용어를 기록합니다.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

하나의 매치가 서로 다른 서식이 적용된 구간을 포함하는 경우, 교체 텍스트에 적용될 서식을 확인하려면 결과를 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replacetext/)와 [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replaceregex/)를 사용해 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **보고를 위한 매치 그룹화**

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로 애플리케이션은 매치를 감사, 보고 또는 검토 워크플로에 따라 그룹화할 수 있습니다. 다음 예제는 수집된 결과를 먼저 슬라이드별, 그 다음 텍스트 프레임별로 그룹화합니다:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**하나의 텍스트 상자만 검색하고 전체 프레젠테이션은 제외하려면 어떻게 해야 하나요?**

해당 도형의 텍스트 프레임을 가져와 [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/), 또는 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**전체 단어에 대해 정확한 대소문자를 맞추려면 어떻게 해야 하나요?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/wholewordsonly/)와 [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/casesensitive/)를 `true`로 설정하고 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우 .NET `Regex` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체에 슬라이드 노트의 텍스트도 포함될 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/includenotes/)를 `true`로 설정합니다. 위의 콜백 구현은 노트 슬라이드의 매치를 부모 슬라이드 번호로 매핑합니다.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

강조 또는 교체 작업에 [IFindResultCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/) 구현을 전달합니다. 콜백은 작업 실행 중에 모든 매치를 받으며, 애플리케이션은 이후 그룹화 또는 내보내기를 위해 원본 텍스트, 매치된 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장할 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/)와 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)는 기존 텍스트 프레임 내에서 매치된 텍스트만 수정하고 주변 서식을 유지합니다. 매치가 서로 다른 서식 구간을 포함하는 경우, 교체 텍스트가 원하는 스타일을 사용하도록 결과를 확인하십시오.