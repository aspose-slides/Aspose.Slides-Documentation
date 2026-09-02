---
title: Python에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/python-net/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- LaTeX로 방정식 내보내기
- PowerPoint에서 LaTeX로
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션의 수학 방정식을 LaTeX 또는 MathML로 직접 내보냅니다."
---
## **소개**

Aspose.Slides for Python via .NET를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 슬라이드에서 방정식을 추출하여 다른 프로그램이나 플랫폼에서 재사용해야 할 수 있습니다.

{{% alert color="primary" %}}
방정식을 LaTeX 또는 웹 및 여러 애플리케이션에서 사용되는 인기 있는 수학 콘텐츠 표준인 MathML로 직접 내보낼 수 있습니다.
{{% /alert %}}

## **수학 방정식을 LaTeX로 내보내기**

Aspose.Slides는 PowerPoint 수학 방정식을 직접 LaTeX로 변환할 수 있으며 중간 MathML 파일이나 외부 변환기가 필요하지 않습니다. 수학 방정식은 텍스트 프레임에 [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/) 형태로 저장됩니다. [MathPortion.math_paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/math_paragraph/)을 사용하여 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)을 얻은 다음 [MathParagraph.to_latex](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)를 호출합니다. 이 메서드는 문자열을 반환하며, 이를 저장하거나 표시하거나 다른 애플리케이션에 보내거나 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하고, 모든 수학 부분을 찾아 각 방정식을 별도의 `.tex` 파일에 씁니다:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/get_all_text_boxes/)는 슬라이드에서 찾은 모든 텍스트 프레임을 반환합니다. [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/) 유형 검사는 일반 텍스트와 이미지에서 실제 편집 가능한 방정식을 구분합니다.

LaTeX 엔진과 문서 템플릿은 동일한 명령, 패키지 또는 유니코드 문자를 모두 지원하지 않을 수 있습니다. 애플리케이션에서 사용하는 LaTeX 엔진으로 반환된 문자열을 테스트하십시오. 해당 환경에 적합한 표현이 없는 기호나 Office Math 요소가 있을 경우, 반환 문자열에서 프로젝트별 명령으로 교체하거나 방정식을 건너뛰고 문제를 기록하여 검토하십시오.

## **수학 방정식을 MathML로 저장**

인간이 LaTeX를 쉽게 작성할 수 있지만, MathML은 일반적으로 애플리케이션에 의해 자동으로 생성됩니다. MathML은 XML 기반이므로 프로그램이 이를 신뢰성 있게 읽고 구문 분석할 수 있어 여러 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:

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

**MathML로 정확히 무엇이 내보내지나요—문단 전체인가요, 개별 수식 블록인가요?**

전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathblock/))을 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 쓰는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수학 수식이라는 것을 어떻게 알 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)를 가지고 있습니다. [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션에서 MathML은 어디서 오는 건가요—PowerPoint 전용인가요, 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 표준의 프레젠테이션 서브셋인 Presentation MathML을 사용하며, 이는 애플리케이션과 웹 전반에 걸쳐 널리 사용됩니다.

**표, SmartArt, 그룹 등 안에 포함된 수식을 내보내는 것이 지원되나요?**

예, 해당 객체가 [MathParagraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides.mathtext/mathparagraph/)가 있는 텍스트 부분을 포함하고 있다면(즉, 실제 PowerPoint 수식) 내보내집니다. 수식이 이미지로 삽입된 경우에는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 변경되나요?**

아니요. MathML을 쓰는 것은 수식 내용의 직렬화이며, 프레젠테이션 파일을 수정하지 않습니다.