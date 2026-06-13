---
title: Python에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/python-net/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint에서 MathML로 수학 방정식을 원활하게 내보내고, 서식을 유지하며 호환성을 향상시킵니다."
---
## **Introduction**

Aspose.Slides for Python via .NET를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 슬라이드에서 방정식을 추출하여 다른 프로그램이나 플랫폼에서 재사용해야 할 수 있습니다.

{{% alert color="primary" %}}
MathML으로 방정식을 내보낼 수 있습니다. MathML은 웹 및 다양한 응용 프로그램에서 수학 콘텐츠를 표현하기 위해 널리 사용되는 표준입니다.
{{% /alert %}}

## **Save Math Equations as MathML**

비록 사람은 LaTeX를 쉽게 작성할 수 있지만, MathML은 일반적으로 애플리케이션에 의해 자동으로 생성됩니다. MathML은 XML 기반이므로 프로그램이 신뢰성 있게 읽고 파싱할 수 있어 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여 줍니다:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

전체 수학 단락([MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathblock/))을 MathML로 내보낼 수 있습니다. 두 종류 모두 MathML을 작성하는 메서드를 제공합니다.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)를 가집니다. [MathParagraph]가 없는 이미지나 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 애플리케이션 및 웹 전반에 널리 사용됩니다.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

예, 해당 객체가 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)가 있는 텍스트 부분을 포함하고 있으면(즉, 실제 PowerPoint 수식) 내보낼 수 있습니다. 수식이 이미지로 삽입된 경우는 내보낼 수 없습니다.

**Does exporting to MathML modify the original presentation?**

아니요. MathML을 작성하는 것은 수식 내용을 직렬화하는 것이며, 프레젠테이션 파일을 수정하지 않습니다.