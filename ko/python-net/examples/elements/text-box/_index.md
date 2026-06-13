---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/python-net/examples/elements/text-box/
keywords:
- 텍스트 상자
- 텍스트 상자 추가
- 텍스트 상자 접근
- 텍스트 상자 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 텍스트 상자를 만들고 서식 지정합니다: 글꼴, 정렬, 자동 줄바꿈, 자동 맞춤 및 PowerPoint와 OpenDocument용 슬라이드 다듬기에 필요한 링크를 설정합니다."
---
In Aspose.Slides에서 **text box**는 `AutoShape`으로 표현됩니다. 거의 모든 도형에 텍스트를 넣을 수 있지만, 일반적인 텍스트 상자는 채우기나 테두리가 없으며 텍스트만 표시합니다.

이 가이드는 텍스트 상자를 프로그래밍 방식으로 추가, 접근 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 채우기와 테두리가 없고 서식이 지정된 텍스트가 포함된 `AutoShape`에 불과합니다. 다음은 텍스트 상자를 만드는 방법입니다:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 사각형 모양을 생성합니다 (기본값은 채우기와 테두리가 있고 텍스트는 없습니다).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # 채우기와 테두리를 제거하여 일반적인 텍스트 상자처럼 보이게 합니다.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # 텍스트 서식을 설정합니다.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # 실제 텍스트 내용을 할당합니다.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Note:** 비어 있지 않은 `TextFrame`을 포함하는 모든 `AutoShape`은 텍스트 상자로 사용할 수 있습니다.

## **내용으로 텍스트 상자 접근**

특정 키워드(예: "Slide")가 포함된 모든 텍스트 상자를 찾으려면 도형들을 순회하면서 텍스트를 확인합니다:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # 편집 가능한 텍스트는 AutoShape에만 포함될 수 있습니다.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # 일치하는 텍스트 상자로 무언가를 수행합니다.
                    pass
```

## **내용으로 텍스트 상자 제거**

이 예제는 첫 번째 슬라이드에서 특정 키워드가 포함된 모든 텍스트 상자를 찾아 삭제합니다:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # 제거할 모양을 찾습니다. AutoShape이며 "Slide"이라는 단어가 포함된 경우.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # 일치하는 각 모양을 슬라이드에서 제거합니다.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** 반복 중에 컬렉션을 수정하는 오류를 방지하려면 항상 도형 컬렉션의 복사본을 만든 후 수정하십시오.