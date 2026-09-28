---
title: .NET에서 프레젠테이션 텍스트 형식 지정
linktitle: 텍스트 형식 지정
type: docs
weight: 50
url: /ko/net/text-formatting/
keywords:
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 패밀리
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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 형식화하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 지정할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 포맷하는 방법을 보여줍니다. 배경 색, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 고정, 탭 정지 및 언어 설정을 다룹니다.

별도 명시가 없는 한, 예제는 [sample.pptx](sample.pptx)를 사용합니다. 첫 번째 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 단락에 아래에 표시된 텍스트가 포함되어 있습니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵은 부분을 선택하는 예제는 상속된 굵은 형식을 포함한 효과적인 형식을 사용합니다:

![샘플 텍스트](sample_text.png)

리터럴 텍스트나 정규식 일치를 찾고 강조하려면, [Search and Replace Text](/slides/ko/net/search-and-replace-text/)를 참조하세요.

## **텍스트 배경 색 설정**

단락의 기본 강조 색을 설정하려면 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaultportionformat/)을 사용하고, 개별 텍스트 부분에 대해서는 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/highlightcolor/)을 사용하십시오.

다음 예제는 첫 번째 단락의 기본값으로 연한 회색 강조를 설정합니다. 개별 부분에 대한 명시적 강조 색은 이 기본값보다 우선합니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 전체 단락에 대한 강조 색을 설정합니다.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

결과:

![회색 단락](gray_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 대한 배경 색을 설정하는 방법을 보여줍니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/alignment/)을 사용하여 텍스트 프레임 내에서 단락 정렬을 지정합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 정렬 등일 수 있습니다.

다음 코드 예제는 단락을 **가운데**에 정렬하는 방법을 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 단락의 정렬을 가운데로 설정합니다.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **텍스트 투명도 설정**

텍스트 투명도는 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/fillformat/)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 스케일의 ARGB 알파 채널 값이며, 투명도 백분율이 아닙니다.

아래 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 텍스트에 반투명 검정 채우기를 설정합니다.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

결과:

![투명한 단락](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

결과:

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/spacing/)을 사용하여 텍스트 상자 내 문자 사이 간격을 넓히거나 좁힐 수 있습니다. 예제에서는 3포인트 간격을 추가합니다; 음수 값은 텍스트를 압축합니다.

다음 C# 코드는 **전체 단락**의 문자 간격을 확장하는 방법을 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 문자 간격을 확장합니다.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 문자 간격을 확장하는 방법을 보여줍니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // 참고: 문자 간격을 압축하려면 음수 값을 사용합니다.
        portion.PortionFormat.Spacing = 3;  // 문자 간격을 확장합니다.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 커닝 비활성화**

일부 경우 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에 표시된 동일한 텍스트보다 약간 더 조밀하게 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대한 커닝 데이터를 무시할 수 있기 때문이며, 해당 글꼴이 유효한 커닝 정보를 가지고 있고 PowerPoint 설정에서 커닝이 활성화되어 있어도 발생합니다.

이러한 경우 렌더링 결과를 PowerPoint와 가깝게 만들려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 커닝을 비활성화할 수 있습니다. [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/kerningminimalsize/)을 실제 글꼴 크기보다 큰 값으로 설정하십시오. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"가 필요합니다. 효과적인 글꼴 이름(상속된 글꼴 포함)을 확인하고 Roboto를 사용하는 부분에 대해 100포인트 임계값을 설정합니다. 이 설정은 100포인트 미만의 글꼴 크기를 가진 일치하는 부분에 대한 커닝을 비활성화합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

임계값 이하의 일치하는 텍스트에 대해 이 설정은 커닝을 방지하고, 해당 PowerPoint 특정 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint의 시각적 출력과 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaultportionformat/)을 통해 단락 수준에서 설정하거나, 개별 부분에 대해서는 [IPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/)을 통해 설정할 수 있습니다.

다음 예제는 첫 번째 단락의 기본 글꼴을 12포인트 Times New Roman으로 설정하고, 굵게, 기울임꼴 및 점선 밑줄 서식을 적용합니다. 개별 부분에 대한 명시적 서식은 이러한 기본값보다 우선합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 단락에 대한 글꼴 속성을 설정합니다.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

결과:

![단락의 글꼴 속성](font_properties_for_paragraph.png)

다음 예제는 효과적인 서식이 굵게인 부분에 13포인트 Times New Roman, 기울임꼴 및 점선 밑줄을 적용합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

결과:

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 회전 설정**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/textverticaltype/)을 사용하여 도형 내에서 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 도형의 텍스트 방향을 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ko/net/aspose.slides/textverticaltype/)으로 설정하여 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

결과:

![텍스트 회전](text_rotation.png)

## **텍스트 프레임 맞춤 회전 설정**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/rotationangle/)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

아래 코드 예제는 도형 내에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

결과:

![맞춤 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spacebefore/), 및 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/spacewithin/)을 제공하여 단락 간격을 제어합니다. 이러한 속성은 다음과 같이 사용됩니다:

* 양수 값을 사용하여 줄 간격을 줄 높이의 백분율로 지정합니다.
* 음수 값을 사용하여 줄 간격을 포인트 단위로 지정합니다.

다음 예제는 첫 번째 단락의 내부 간격을 줄 높이의 200% (두 배 간격)로 설정합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

결과:

![단락 내부 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

단락 줄 바꿈 규칙은 좁은 텍스트 블록 및 라틴어와 동아시아 텍스트가 혼합된 프레젠테이션에 유용합니다. 다음 속성은 [IParagraphFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/)에 속하므로 전체 단락에 적용됩니다:

- [LatinLineBreak](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/latinlinebreak/)은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서는 이를 변경하면 인접한 동아시아 텍스트와 구두점의 줄 바꿈 위치도 변경될 수 있습니다.
- [EastAsianLineBreak](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/eastasianlinebreak/)은 동아시아 줄 바꿈 규칙을 제어하며, 줄 시작 및 끝 문자에 대한 제한을 포함합니다.

이 규칙은 텍스트 프레임 내 자동 래핑을 활성화하는 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/wraptext/)를 대체하지 않습니다. 래핑이 발생할 때 레이아웃에 영향을 주며, 줄 바꿈 문자를 삽입하지는 않습니다. 명시적인 줄 바꿈은 가용 너비와 무관하게 단락 내에 새로운 줄을 강제합니다.

다음 독립형 예제는 중국어와 라틴어 텍스트가 포함된 좁은 텍스트 블록을 생성합니다. 두 줄 바꿈 속성을 명시적으로 설정하고 "line_breaking.pptx"로 저장합니다. 각 규칙을 실험하려면 다른 설정을 고정한 상태에서 해당 속성 값을 변경하십시오. 예제는 24포인트 Arial 및 SimSun을 사용하고 프레임 너비는 160포인트, 수평 텍스트 프레임 여백은 0입니다. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/autofittype/)을 [TextAutofitType.None](https://reference.aspose.com/slides/ko/net/aspose.slides/textautofittype/)으로 설정하여 텍스트 크기와 프레임 크기가 고정되도록 합니다.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **행 매달린 구두점 제어**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/hangingpunctuation/)은 해당 구두점이 다음 줄을 차지하지 않고 텍스트 줄의 오른쪽 가장자리를 넘어 확장되도록 허용합니다. 이는 전체 단락에 적용되며 행 매달린 들여쓰기와는 다릅니다.

다음 독립형 예제는 100포인트 너비의 텍스트 프레임에서 행 매달린 구두점을 활성화하고 "hanging_punctuation.pptx"로 저장합니다. 24포인트 Arial 및 수평 텍스트 프레임 여백 0인 경우, 마지막 마침표는 "sentence" 뒤에 남아 오른쪽 텍스트 가장지를 넘어갑니다. 속성을 [NullableBool.False](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)로 설정하여 비교할 수 있습니다: 이 설정에서는 마침표가 별도의 줄에 배치됩니다. 래핑이 활성화되고 자동 맞춤이 비활성화되어 가용 너비가 고정됩니다.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

모든 구두점이 매달릴 수 있는 것은 아닙니다. 위에서 설명한 [글꼴 및 레이아웃 조건](#conditions-and-limitations)도 이 비교에 적용됩니다: 글꼴, 가용 너비, 여백 또는 자동 맞춤 설정을 변경하면 눈에 보이는 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/autofittype/)은 텍스트가 컨테이너 경계를 초과할 때 동작 방식을 결정합니다. 텍스트가 축소, 넘침, 또는 도형을 자동으로 크기 조정하도록 제어하는 데 사용합니다. 다음 예제는 도형을 텍스트에 맞게 크기 조정하도록 구성하고 결과를 "autofit_type.pptx"로 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

자동 래핑 후 라인 수를 세고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 미치는지 보려면, [Count Rendered Lines](/slides/ko/net/manage-paragraph/)를 참조하십시오. 라인 수만으로는 텍스트가 컨테이너를 초과했는지 여부를 판단할 수 없습니다.

## **텍스트 프레임 앵커 설정**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/anchoringtype/)은 텍스트가 도형 내부에서 수직으로 배치되는 방식을 정의합니다(예: 위, 중간, 아래). 다음 예제는 텍스트를 첫 번째 도형의 아래쪽에 고정하고 결과를 "text_anchor.pptx"로 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **텍스트 탭 설정**

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/defaulttabsize/)와 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraphformat/tabs/)을 사용하여 단락의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이 설정은 탭 문자를 포함한 텍스트에 영향을 줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

결과:

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/)를 제공하여 텍스트 부분의 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행하는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"와 최소 하나의 단락이 필요합니다. 첫 번째 단락의 내용을 "1。"으로 교체하고 글꼴을 SimSun으로 설정한 다음, 간체 중국어 교정 언어(`zh-CN`)를 지정합니다. 결과를 "proofing_language.pptx"로 저장합니다:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// 교정 언어를 간체 중국어로 설정합니다.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **기본 언어 설정**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaulttextlanguage/)를 사용하여 프레젠테이션을 로드하거나 생성할 때 생성되는 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정한 프레젠테이션을 만들고, 텍스트 상자를 추가한 뒤 첫 번째 텍스트 부분에 대해 `en-US`를 출력합니다.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 새 사각형 도형을 텍스트와 함께 추가합니다.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 첫 번째 부분의 언어를 확인합니다.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/defaulttextstyle/)을 사용하십시오.

다음 예제는 새 프레젠테이션에서 최상위 단락에 대한 기본값으로 14포인트 굵은 글꼴을 설정하고 "default_text_style.pptx"로 저장합니다. 텍스트는 더 구체적인 서식이 이를 덮어쓰지 않는 한 이러한 기본값을 상속받을 수 있습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// 최상위 수준 단락 형식을 가져옵니다.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All-Caps 효과를 사용한 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력된 텍스트도 슬라이드에서 대문자로 표시됩니다. Aspose.Slides로 해당 텍스트 부분을 가져오면 라이브러리는 입력된 그대로 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/ko/net/aspose.slides/textcaptype/)을 확인하고 값이 `All`일 때 반환 문자열을 대문자로 변환합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "sample2.pptx"가 필요합니다. 첫 번째 단락의 첫 번째 부분에 **All Caps** 효과가 적용된 "Hello, Aspose!"가 포함되어 있습니다(아래 참조).

![All Caps 효과](all_caps_effect.png)

아래 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 해야 하나요?**

슬라이드의 표에서 텍스트를 수정하려면 [ITable](https://reference.aspose.com/slides/ko/net/aspose.slides/itable/)을 사용하십시오. 셀을 순회하면서 각 셀을 [ICell.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/icell/textframe/)을 통해 업데이트하고, 단락 서식은 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/paragraphformat/)을 통해 지정합니다.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 적용하려면 어떻게 해야 하나요?**

텍스트에 그라디언트 색을 적용하려면 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/fillformat/)을 사용하십시오. [IFillFormat.FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/ifillformat/filltype/)을 [FillType.Gradient](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)으로 설정하고, 그라디언트 스톱, 방향 및 투명도를 구성합니다.