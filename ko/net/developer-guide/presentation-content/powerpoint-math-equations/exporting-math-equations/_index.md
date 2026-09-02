---
title: .NET에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/net/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- LaTeX로 방정식 내보내기
- PowerPoint에서 LaTeX로
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션의 수학 방정식을 LaTeX 또는 MathML로 직접 내보냅니다."
---
## **Introduction**

Aspose.Slides for .NET는 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다. 

{{% alert color="primary" %}} 

방정식을 LaTeX 또는 MathML로 직접 내보낼 수 있으며, MathML은 웹 및 다양한 애플리케이션에서 사용되는 인기 있는 수학 콘텐츠 표준입니다.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides는 PowerPoint 수학 방정식을 중간 MathML 파일이나 외부 변환기 없이 직접 LaTeX로 변환할 수 있습니다. 수학 방정식은 텍스트 프레임에 [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/)으로 저장됩니다. [MathPortion.MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/mathparagraph/)를 사용하여 [IMathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathparagraph/)를 얻고, 그 다음 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/imathparagraph/tolatex/)를 호출합니다. 메서드는 문자열을 반환하며, 이를 저장, 표시, 다른 애플리케이션에 전송하거나 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하고, 모든 수학 부분을 찾아 각각의 방정식을 별도의 `.tex` 파일에 기록합니다:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ko/net/aspose.slides.util/slideutil/getalltextboxes/)는 슬라이드에서 찾은 모든 텍스트 프레임을 반환합니다. [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/) 유형 검사는 일반 텍스트와 이미지와 구별되는 편집 가능한 실제 방정식을 분리합니다.

LaTeX 엔진 및 문서 템플릿은 모두 동일한 명령, 패키지 또는 유니코드 문자를 지원하지 않을 수 있습니다. 반환된 문자열을 애플리케이션에서 사용하는 LaTeX 엔진으로 테스트하십시오. 해당 환경에서 기호나 Office Math 요소에 적합한 표현이 없으면, 반환된 문자열에서 프로젝트별 명령으로 교체하거나 방정식을 건너뛰고 문제를 기록하십시오.

## **Save Math Equations as MathML**

인간은 LaTeX와 같은 일부 방정식 형식의 코드를 쉽게 작성할 수 있지만, MathML은 애플리케이션에 의해 자동으로 생성되도록 설계되었기 때문에 코드를 직접 작성하기 어렵습니다. 프로그램은 MathML이 XML 형식이기 때문에 쉽게 읽고 구문 분석할 수 있어, 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다. 

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**MathML로 정확히 무엇이 내보내집니까—단락 전체인가요, 개별 수식 블록인가요?**

전체 수학 단락([MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathblock/))을 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드의 개체가 일반 텍스트나 이미지가 아니라 수학 수식임을 어떻게 알 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)를 갖습니다. [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션의 MathML은 어디에서 오는 건가요—PowerPoint 전용인가요, 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 다양한 애플리케이션과 웹에서 널리 사용됩니다.

**테이블, SmartArt, 그룹 등 내부의 수식 내보내기가 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)가 있는 텍스트 부분(즉, 실제 PowerPoint 수식)이 포함되어 있으면 내보냅니다. 수식이 이미지로 삽입된 경우에는 내보낼 수 없습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML을 기록하는 것은 수식 내용을 직렬화하는 것이며, 프레젠테이션 파일을 수정하지 않습니다.