---
title: .NET에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 수식 내보내기
type: docs
weight: 30
url: /ko/net/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint에서 MathML로 수학 방정식을 원활하게 내보내고, 형식을 유지하며 호환성을 향상시킵니다."
---
## **소개**

Aspose.Slides for .NET를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다. 

{{% alert color="primary" %}} 

방정식을 MathML로 내보낼 수 있습니다. MathML은 웹 및 다양한 응용 프로그램에서 사용되는 수학 방정식 및 유사 콘텐츠를 위한 널리 쓰이는 형식 또는 표준입니다. 

{{% /alert %}}

## **수학 방정식을 MathML로 저장**

사람은 LaTeX와 같은 일부 방정식 형식의 코드를 쉽게 작성할 수 있지만, MathML 코드는 앱이 자동으로 생성하도록 설계되었기 때문에 직접 작성하기 어렵습니다. 프로그램은 MathML 코드가 XML 형태이기 때문에 쉽게 읽고 구문 분석할 수 있어, 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다. 

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

## **자주 묻는 질문**

**MathML로 내보내는 대상은 전체 문단인가요, 개별 수식 블록인가요?**

전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathblock/))을 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드의 개체가 일반 텍스트나 이미지가 아닌 수학 수식임을 어떻게 확인할 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)를 갖습니다. [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션의 MathML은 어디서 제공되나요—PowerPoint 전용인가요, 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 다양한 응용 프로그램과 웹에서 널리 사용됩니다.

**표, SmartArt, 그룹 등 내부에 있는 수식을 내보내는 것이 지원되나요?**

예, 해당 개체에 [MathParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides.mathtext/mathparagraph/)가 포함된 텍스트 부분(즉, 실제 PowerPoint 수식)이 있으면 내보냅니다. 수식이 이미지로 삽입된 경우에는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML 기록은 수식 내용을 직렬화하는 작업이며, 프레젠테이션 파일을 수정하지 않습니다.