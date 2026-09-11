---
title: Python에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/python-java/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- LaTeX로 방정식 내보내기
- PowerPoint를 LaTeX로
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 수학 방정식을 LaTeX 또는 MathML로 직접 내보냅니다."
---
## **소개**

Aspose.Slides는 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용해야 할 수 있습니다.

{{% alert color="info" title="Note" %}}
수학 방정식을 LaTeX 또는 MathML로 직접 내보낼 수 있으며, 이는 웹 및 다양한 애플리케이션에서 사용되는 인기 있는 수학 콘텐츠 표준입니다.
{{% /alert %}}

## **LaTeX로 수학 방정식 내보내기**

Aspose.Slides는 PowerPoint 수학 방정식을 직접 LaTeX로 변환할 수 있으며, 중간 MathML 파일이나 외부 변환기가 필요하지 않습니다. 수학 방정식은 텍스트 프레임에 [MathPortion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathportion/) 형태로 저장됩니다. [MathPortion.getMathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathportion/#getMathParagraph) 를 사용하여 [MathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/) 를 가져온 다음, [MathParagraph.toLatex](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/#toLatex) 를 호출합니다. 이 메서드는 문자열을 반환하며, 이를 저장하거나 표시하고, 다른 애플리케이션에 보내거나 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하고, 모든 수학 부분을 찾아 각각의 방정식을 별도의 `.tex` 파일에 기록합니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/#getAllTextBoxes) 은 슬라이드에서 찾은 모든 텍스트 프레임을 반환합니다. [MathPortion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathportion/) 유형 검사는 일반 텍스트와 이미지와 구분되는 실제 편집 가능한 방정식을 분리합니다.

LaTeX 엔진 및 문서 템플릿은 모두 동일한 명령, 패키지 또는 유니코드 문자를 지원하지 않을 수 있습니다. 반환된 문자열을 애플리케이션에서 사용하는 LaTeX 엔진으로 테스트하십시오. 해당 환경에서 기호나 Office Math 요소에 적절한 표현이 없으면, 반환 문자열의 해당 부분을 프로젝트 전용 명령으로 대체하거나 방정식을 건너뛰고 문제를 기록해 검토하십시오.

## **MathML로 수학 방정식 저장**

LaTeX와 같은 일부 방정식 형식은 손쉽게 코드를 작성할 수 있지만, MathML은 손으로 작성하기 어려운 이유가 자동으로 애플리케이션에서 생성되도록 설계되었기 때문입니다. MathML은 XML 기반이므로 프로그램이 쉽게 읽고 구문 분석할 수 있어, 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다.

다음 샘플 코드는 프레젠테이션의 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**MathML로 내보내는 대상은 단락 전체인지 개별 수식 블록인지 정확히 무엇인가요?**

전체 수학 단락([MathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathblock/)) 중 하나를 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드에 있는 객체가 일반 텍스트나 이미지가 아니라 수학 수식인지 어떻게 확인할 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathportion/)에 포함되어 있으며 [MathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/) 를 가지고 있습니다. [MathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/) 가 없는 이미지나 일반 텍스트 부분은 내보낼 수 없는 수식입니다.

**프레젠테이션의 MathML은 어디에서 오는가요—PowerPoint 전용인가요, 아니면 표준인가요?**

내보내기는 표준 MathML(XML)을 목표로 합니다. Aspose는 프레젠테이션 서브셋인 Presentation MathML을 사용하며, 이는 다양한 애플리케이션과 웹에서 널리 사용되는 표준입니다.

**표, SmartArt, 그룹 등 내부에 포함된 수식도 내보낼 수 있나요?**

예, 해당 객체가 [MathParagraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/mathparagraph/) 를 포함한 텍스트 부분을 가지고 있다면(즉, 실제 PowerPoint 수식인 경우) 내보낼 수 있습니다. 수식이 이미지 형태로 삽입된 경우에는 내보낼 수 없습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML 기록은 수식 내용의 직렬화이며, 프레젠테이션 파일을 수정하지 않습니다.