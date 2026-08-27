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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 텍스트를 검색, 강조 및 교체하면서 모든 일치를 수집합니다."
---
## **개요**

Aspose.Slides for .NET은 개별 텍스트 프레임이나 전체 프레젠테이션에 대해 텍스트를 검색, 강조 및 교체할 수 있습니다. 각 작업은 결과 콜백을 통해 각 일치를 애플리케이션에 알릴 수도 있습니다. 이를 통해 프레젠테이션을 업데이트하면서 일치한 텍스트, 해당 컨텍스트, 위치, 텍스트 프레임 및 슬라이드 번호를 포함하는 감사 추적을 동시에 구축할 수 있습니다.

이 기능은 검토, 민감 정보 삭제, 용어 검사, 템플릿 정리 및 자동 보고 워크플로에 유용합니다.

아래 첫 번째 예시에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 해당 텍스트 상자에는 다음과 같은 텍스트가 들어 있습니다:

![샘플 텍스트](sample_text.png)

## **검색 범위 선택**

[ITextFrame] 메서드를 사용하여 작업을 하나의 텍스트 프레임으로 제한합니다. [Presentation] 메서드를 사용하여 프레젠테이션의 모든 적용 가능한 텍스트를 처리합니다.

| 작업 | 단일 텍스트 프레임 | 전체 프레젠테이션 |
|---|---|---|
| 리터럴 텍스트 강조 | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlighttext/) |
| 정규식 일치 강조 | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlightregex/) |
| 리터럴 텍스트 교체 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replacetext/) |
| 정규식 일치 교체 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replaceregex/) |

## **텍스트 매칭 구성**

리터럴 텍스트 작업에는 [TextSearchOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/)를 사용하여 매칭을 제어합니다:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/wholewordsonly/)는 일치를 전체 단어로 제한합니다.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/casesensitive/)는 문자 대소문자 일치를 제어합니다.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/includenotes/)는 프레젠테이션 수준 검색, 교체 및 강조 작업에 슬라이드 노트를 포함합니다.

정규식 작업은 .NET `Regex`를 사용하므로 대소문자 구분 및 단어 경계와 같은 매칭 규칙은 표현식 및 옵션에 의해 정의됩니다.

## **텍스트 프레임 소유자 식별**

일반적인 텍스트 처리 워크플로는 검색, 교체, 검증 또는 텍스트 내보내기 중에 종종 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)을 받습니다. [ITextFrame.ParentShape](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentshape/)와 [ITextFrame.ParentCell](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentcell/)을 사용하여 텍스트 프레임을 소유하는 프레젠테이션 개체를 결정합니다.

예상값은 소유자에 따라 다릅니다:

| 텍스트 프레임 소유자 | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape 또는 다른 텍스트 포함 도형 | 소유 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) | `null` |
| 표 셀 | `null` | 소유 [ICell](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/) |

두 속성은 읽기 전용 탐색 속성입니다. 이를 읽어도 텍스트 프레임이 이동하거나 소유자가 변경되지 않습니다. 일반 코드는 두 값이 `null`인지 확인하고, 두 소유자 모두 없을 가능성을 처리해야 합니다.

다음 예제는 [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextframes/)를 사용하여 프레젠테이션의 텍스트 프레임을 순회합니다. 도형의 경우 도형 이름, 도형 유형 및 포함 슬라이드를 보고합니다. 표 셀의 경우 0부터 시작하는 열 및 행 좌표와 포함 슬라이드를 보고합니다.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

SmartArt 콘텐츠의 경우 [ISmartArtNode.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartartnode/shapes/)의 도형을 순회하고 각각의 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartartshape/textframe/)에 접근합니다. 텍스트 프레임은 [ITextFrame.ParentShape](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentshape/)를 통해 해당 도형과 연결될 수 있으며, [ITextFrame.ParentCell](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/parentcell/)은 `null`입니다. 따라서 예제의 도형 분기는 SmartArt 노드의 텍스트도 처리합니다.

## **콜백을 사용한 매치 정보 수집**

[IFindResultCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/)을 구현하여 모든 매치에 대한 알림을 받습니다. 해당 [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/foundresult/) 메서드는 관련 텍스트 프레임, 원본 텍스트, 매치된 텍스트 및 매치 위치를 제공합니다.

콜백은 슬라이드 번호를 직접 받지 않습니다. 아래 구현은 이를 상위 슬라이드에서 파생하고 슬라이드 노트에 있는 텍스트도 처리합니다. nullable 슬라이드 번호를 사용하면 동일한 결과 모델이 다른 슬라이드 유형과 연관된 텍스트를 나타낼 수 있습니다.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

교체 작업의 경우 `FoundText`에 원본 매치 텍스트가 포함되어 있어 콜백에서 정확히 어떤 용어가 교체되었는지 기록할 수 있습니다.

## **텍스트 강조**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/) 메서드를 사용하여 텍스트 프레임에서 리터럴 텍스트 매치를 강조합니다. 검색을 제어하려면 [TextSearchOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/)를 전달하고 매치 세부 정보를 수집하려면 콜백을 전달합니다.

아래 코드 예제는 문자 **"try"**의 모든 발생을 강조한 다음 전체 단어 **"to"**만 강조합니다. 두 검색 모두 동일한 콜백에 매치를 보고합니다.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// 텍스트 프레임에서 "try"가 나타나는 모든 위치를 강조합니다.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// 전체 단어 "to"만 강조합니다.
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

결과:

![강조된 텍스트](highlighted_text.png)

## **정규식 사용 텍스트 강조**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/) 메서드는 텍스트 프레임에서 정규식으로 찾은 텍스트 매치를 강조합니다.

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

![정규식을 사용한 강조된 텍스트](highlighted_text_using_regex.png)

## **프레젠테이션 전체 텍스트 강조**

[Presentation.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlighttext/)와 [Presentation.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/highlightregex/)를 사용하여 프레젠테이션의 모든 적용 가능한 텍스트 프레임을 검색합니다. 다음 예제는 리터럴 용어와 모든 이메일 주소를 강조하고 두 검색에 대해 별도의 결과 컬렉션을 유지합니다.

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

## **텍스트 프레임 내 텍스트 교체**

리터럴 텍스트에는 [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/)를, 패턴 기반 교체에는 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)를 사용합니다. 이러한 메서드는 기존 텍스트 프레임 내에서 매치된 텍스트를 업데이트하며, 전체 문자열로 텍스트 프레임을 재구성하는 대신 주변 부분의 서식을 유지합니다.

다음 예제는 철자 변형을 표준화하고 버전 레이블을 교체합니다. 동일한 콜백이 두 작업에서 매치된 원본 용어를 기록합니다.

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

매치가 서로 다른 서식을 가진 부분에 걸쳐 있는 경우, 교체 텍스트에 적용될 서식을 확인하기 위해 출력물을 검토하십시오.

## **프레젠테이션 전체 텍스트 교체**

[Presentation.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replacetext/)와 [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/replaceregex/)를 사용하여 프레젠테이션 전체에 동일한 작업을 적용합니다. 이는 템플릿 정리, 용어 업데이트 및 민감 정보 삭제에 유용합니다.

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

각 결과가 슬라이드 번호와 텍스트 프레임을 저장하므로, 애플리케이션은 매치를 감사, 보고 또는 검토 워크플로에 맞게 그룹화할 수 있습니다. 다음 예제는 수집된 결과를 먼저 슬라이드별로, 그 다음 텍스트 프레임별로 그룹화합니다:

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

**전체 프레젠테이션이 아닌 하나의 텍스트 상자만 검색하려면 어떻게 해야 하나요?**

도형의 텍스트 프레임을 가져와 해당 텍스트 프레임에서 [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/), 또는 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)를 호출합니다. 프레젠테이션 수준 메서드는 모든 적용 가능한 텍스트 프레임을 처리합니다.

**올바른 대소문자를 사용해 전체 단어를 매치하려면 어떻게 해야 하나요?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/wholewordsonly/)와 [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/casesensitive/)를 `true`로 설정하고, 옵션을 리터럴 텍스트 강조 또는 교체 메서드에 전달합니다. 정규식의 경우, .NET `Regex` 자체에 단어 경계와 대소문자 구분을 정의합니다.

**검색 및 교체가 슬라이드 노트의 텍스트도 포함할 수 있나요?**

예. 프레젠테이션 수준 리터럴 텍스트 작업을 사용할 때 [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/includenotes/)를 `true`로 설정합니다. 위에 표시된 콜백 구현은 노트 슬라이드의 매치를 해당 상위 슬라이드 번호로 매핑합니다.

**프레젠테이션을 두 번 스캔하지 않고 보고서를 만들려면 어떻게 해야 하나요?**

강조 또는 교체 작업에 [IFindResultCallback](https://reference.aspose.com/slides/ko/net/aspose.slides/ifindresultcallback/) 구현을 전달합니다. 콜백은 작업이 수행되는 동안 모든 매치를 받아 애플리케이션이 원본 텍스트, 매치된 텍스트, 위치, 텍스트 프레임 및 파생된 슬라이드 번호를 저장해 나중에 그룹화하거나 내보낼 수 있습니다.

**텍스트 교체 시 서식이 유지되나요?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replacetext/)와 [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/replaceregex/)는 기존 텍스트 프레임 내에서 매치된 텍스트를 수정하고 주변 부분의 서식을 유지합니다. 매치가 서로 다른 서식을 가진 부분에 걸쳐 있는 경우, 교체가 원하는 스타일을 사용하도록 결과를 확인하십시오.