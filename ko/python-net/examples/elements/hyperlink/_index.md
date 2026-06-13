---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/python-net/examples/elements/hyperlink/
keywords:
- 하이퍼링크
- 하이퍼링크 추가
- 하이퍼링크 접근
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 하이퍼링크를 추가, 편집 및 제거합니다: 텍스트, 도형, 슬라이드, URL 및 이메일을 연결하고; PPT, PPTX 및 ODP에 대한 대상 및 동작을 설정합니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 도형의 하이퍼링크를 추가, 접근, 제거 및 업데이트하는 방법을 보여줍니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 포함된 사각형 도형을 만듭니다.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크 접근**

도형 텍스트 부분에서 하이퍼링크 정보를 읽습니다.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 삭제합니다.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상을 변경합니다. `HyperlinkManager`를 사용하여 이미 하이퍼링크가 포함된 텍스트를 수정하면 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # 기존 텍스트 내부의 하이퍼링크를 변경할 때는
        # 속성을 직접 설정하는 대신 HyperlinkManager를 사용해야 합니다.
        # 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```