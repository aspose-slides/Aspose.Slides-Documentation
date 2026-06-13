---
title: 수식 텍스트
type: docs
weight: 160
url: /ko/python-net/examples/elements/math-text/
keywords:
- 수식 텍스트
- 수식 텍스트 추가
- 수식 텍스트 접근
- 수식 텍스트 제거
- 수식 텍스트 서식 지정
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용해 수식 텍스트 작업: 방정식, 분수, 근호, 첨자, 서식 지정 등을 만들고 편집하며 PPT 및 PPTX 결과를 렌더링합니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 수학 텍스트 도형을 작업하고 수식을 서식 지정하는 방법을 보여줍니다.

## **수식 텍스트 추가**

분수와 피타고라스 정리를 포함하는 수식 도형을 만듭니다.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 슬라이드에 수식 도형을 추가합니다.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # 수식 단락에 접근합니다.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # 간단한 분수 x / y를 추가합니다.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # 방정식 c² = a² + b²를 추가합니다.
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **수식 텍스트 접근**

슬라이드에서 수식 단락을 포함하는 도형을 찾습니다.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 수학 단락을 포함하는 첫 번째 도형을 찾습니다.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **수식 텍스트 제거**

슬라이드에서 수식 도형을 삭제합니다.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 수식 텍스트를 포함한 도형이라고 가정합니다.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **수식 텍스트 서식 지정**

수식 부분의 글꼴 속성을 설정합니다.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 수식 텍스트를 포함한 도형이라고 가정합니다.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```