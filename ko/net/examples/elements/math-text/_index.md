---
title: 수학 텍스트
type: docs
weight: 160
url: /ko/net/examples/elements/math-text/
keywords:
- 수학 텍스트
- 수학 텍스트 추가
- 수학 텍스트 액세스
- 수학 텍스트 제거
- 수학 텍스트 서식 지정
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 수학 텍스트 예제를 탐색합니다: C#를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 방정식, 분수, 행렬 및 기호를 만들고 서식 지정합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 수학 텍스트 도형 작업 및 방정식 서식 지정 방법을 보여줍니다.

## **수학 텍스트 추가**

분수와 피타고라스 공식을 포함하는 수학 도형을 만듭니다.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 슬라이드에 수학 도형을 추가합니다.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // 수학 단락에 접근합니다.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // 간단한 분수 추가: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // 방정식 추가: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **수학 텍스트 액세스**

슬라이드에서 수학 단락을 포함하는 도형을 찾습니다.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // 첫 번째 수학 단락을 포함하는 도형을 찾습니다.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // 예: 분수를 생성합니다 (여기에 추가되지 않음).
        var fraction = new MathematicalText("x").Divide("y");

        // 필요에 따라 mathParagraph 또는 fraction을 사용합니다...
    }
}
```

## **수학 텍스트 제거**

슬라이드에서 수학 도형을 삭제합니다.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **수학 텍스트 서식 지정**

수학 부분에 대한 글꼴 속성을 설정합니다.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```