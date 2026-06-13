---
title: .NET에서 프레젠테이션 텍스트 서식 지정
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/net/text-formatting/
keywords:
- 텍스트 강조
- 정규식
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 계열
- 텍스트 회전
- 회전 각도
- 텍스트 프레임
- 줄 간격
- 자동 맞춤 속성
- 텍스트 프레임 앵커
- 텍스트 탭
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 서식 지정하고 스타일을 적용합니다. 글꼴, 색상, 정렬 등을 사용자 정의할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 하이라이트, 배경 색상, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 앵커링, 탭 정지 및 언어 설정을 다룹니다.

아래 예제에서는 첫 번째 슬라이드에 단일 텍스트 상자가 포함된 "sample.pptx" 파일을 사용합니다. 해당 텍스트 상자에는 다음과 같은 텍스트가 있습니다:

![샘플 텍스트](sample_text.png)

## **텍스트 강조**

텍스트 프레임 내에서 특정 샘플과 일치하는 텍스트를 강조 표시해야 할 때는 [ITextFrame.HighlightText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlighttext/) 메서드를 사용합니다. 이 메서드는 일치하는 텍스트 조각에 하이라이트 색을 적용하며, [TextSearchOptions](https://reference.aspose.com/slides/ko/net/aspose.slides/textsearchoptions/)와 함께 사용하여 검색 방식을 제어할 수 있습니다(예: 전체 단어만 일치시키기).

아래 코드 예제는 문자 **"try"**의 모든 발생을 하이라이트한 다음, 전체 단어 **"to"**만 하이라이트합니다.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // 첫 번째 슬라이드에서 첫 번째 도형을 가져옵니다.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // 도형에서 "try" 단어를 강조합니다.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // 도형에서 "to" 단어를 강조합니다.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

결과:

![하이라이트된 텍스트](highlighted_text.png)

## **정규 표현식을 사용한 텍스트 강조**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/highlightregex/) 메서드는 정규 표현식으로 찾은 텍스트 일치를 하이라이트합니다. .NET에서는 이 API가 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 노출됩니다.

아래 코드 예제는 **7자 이상**인 모든 단어를 하이라이트합니다:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // 7자 이상인 모든 단어를 강조합니다.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

결과:

![정규 표현식을 사용한 하이라이트된 텍스트](highlighted_text_using_regex.png)

## **텍스트 배경 색상 설정**

[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaultportionformat/)을 사용하여 단락의 기본 하이라이트 색상을 설정하거나, 개별 텍스트 부분에 대해서는 [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/highlightcolor/)를 사용합니다.

다음 코드 예제는 **전체 단락**에 배경 색을 설정하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 전체 단락에 대한 강조 색을 설정합니다.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

결과:

![회색 단락](gray_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 배경 색을 설정하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 텍스트 부분에 대한 강조 색을 설정합니다.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/)을 사용하여 텍스트 프레임 내 단락 정렬을 설정합니다. 값은 중앙, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등으로 지정할 수 있습니다.

다음 코드 예제는 단락을 **가운데**에 정렬하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 단락의 정렬을 가운데로 설정합니다.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/fillformat/)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 범위의 ARGB 알파 채널 값이며, 투명도 비율이 아닙니다.

아래 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 텍스트의 채우기 색을 투명 색으로 설정합니다.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

결과:

![투명한 단락](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 텍스트 부분의 투명도를 설정합니다.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

결과:

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/spacing/)을 사용하여 텍스트 상자 내 문자 사이의 간격을 확장하거나 축소합니다.

다음 C# 코드는 **전체 단락**의 문자 간격을 확장하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 주의: 문자 간격을 압축하려면 음수 값을 사용합니다.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 문자 간격을 늘립니다.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 문자 간격을 확장하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 주의: 문자 간격을 압축하려면 음수 값을 사용합니다.
            portion.PortionFormat.Spacing = 3;  // 문자 간격을 늘립니다.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

경우에 따라 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 표시되는 동일한 텍스트보다 약간 더 조밀하게 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대한 커닝 데이터를 무시할 수 있기 때문이며, 글꼴에 유효한 커닝 정보가 포함되어 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 렌더링 결과를 PowerPoint와 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/kerningminimalsize/)을 실제 글꼴 크기보다 현저히 크게 설정합니다:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

이 설정은 일치하는 텍스트 부분에 커닝이 적용되는 것을 방지하며, PowerPoint 고유 동작으로 인해 영향을 받는 글꼴에 대해 Aspose.Slides의 렌더링을 PowerPoint의 시각적 출력과 일치시키는 데 도움이 됩니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaultportionformat/)을 통해 단락 수준에서 설정하거나, [IPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/)을 통해 개별 부분에 설정할 수 있습니다.

다음 코드는 전체 단락에 대한 글꼴 및 텍스트 스타일을 설정합니다: 글꼴 크기, 굵게, 기울임, 점선 밑줄 및 Times New Roman 글꼴을 단락의 모든 부분에 적용합니다.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 단락에 대한 글꼴 속성을 설정합니다.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

결과:

![단락의 글꼴 속성](font_properties_for_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 유사한 속성을 적용합니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 텍스트 부분에 대한 글꼴 속성을 설정합니다.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

결과:

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/textverticaltype/)을 사용하여 도형 내에서 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 도형의 텍스트 방향을 `Vertical270`으로 설정하며, 이는 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임 사용자 지정 회전 설정**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/rotationangle/)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)의 사용자 지정 회전 각도를 설정합니다.

아래 코드 예제는 도형 내에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

결과:

![사용자 지정 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 단락 간격을 제어하기 위해 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spacebefore/), 및 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spacewithin/)를 제공합니다. 이러한 속성은 다음과 같이 사용됩니다:

* 양수 값을 사용하여 줄 간격을 줄 높이의 백분율로 지정합니다.
* 음수 값을 사용하여 줄 간격을 포인트 단위로 지정합니다.

다음 코드 예제는 단락 내에서 줄 간격을 지정하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

결과:

![단락 내 줄 간격](line_spacing.png)

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/autofittype/)은 텍스트가 컨테이너 경계를 초과할 때의 동작을 결정합니다. 이를 사용하여 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어할 수 있습니다.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **텍스트 프레임 앵커 설정**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/anchoringtype/)은 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다(예: 상단, 중간, 하단).

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **텍스트 탭 설정**

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaulttabsize/) 및 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/tabs/)을 사용하여 단락의 탭 정지를 구성합니다.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

결과:

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [IPortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/languageid/)를 제공하며, 이를 통해 텍스트 부분의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사에 사용되는 언어를 결정합니다.

다음 코드 예제는 텍스트 부분의 교정 언어를 설정하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // 교정 언어의 Id를 설정합니다.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **기본 언어 설정**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaulttextlanguage/)를 사용하여 프레젠테이션을 로드하거나 만들 때 생성되는 텍스트의 기본 언어를 정의합니다.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // 텍스트가 있는 새 사각형 도형을 추가합니다.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 첫 번째 부분의 언어를 확인합니다.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/defaulttextstyle/)을 사용합니다.

다음 코드 예제는 새 프레젠테이션의 모든 슬라이드에 대해 14pt 크기의 기본 굵은 글꼴을 설정하는 방법을 보여줍니다.

```cs
using (var presentation = new Presentation())
{
    // 최상위 단락 서식을 가져옵니다.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **All-Caps 효과를 사용한 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력되었더라도 슬라이드에 대문자로 표시됩니다. Aspose.Slides로 이러한 텍스트 부분을 가져오면 라이브러리는 입력된 그대로 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/net/aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환합니다.

예를 들어 sample2.pptx 파일의 첫 번째 슬라이드에 다음과 같은 텍스트 상자가 있다고 가정해 보겠습니다.

![All Caps 효과](all_caps_effect.png)

아래 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 합니까?**

슬라이드의 표에서 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/)을 사용합니다. 셀을 순회하면서 각각의 셀을 [ICell.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/textframe/)을 통해 업데이트하고, 단락 서식은 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/paragraphformat/)을 통해 지정합니다.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 적용하려면 어떻게 합니까?**

텍스트에 그라디언트 색을 적용하려면 [IPortionFormat.FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/fillformat/)을 사용합니다. [IFillFormat.FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformat/filltype/)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)으로 설정하고, 그라디언트 정지점, 방향 및 투명도를 구성합니다.