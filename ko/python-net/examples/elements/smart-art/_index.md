---
title: 스마트아트
type: docs
weight: 140
url: /ko/python-net/examples/elements/smart-art/
keywords:
- 스마트아트
- 스마트아트 추가
- 스마트아트 접근
- 스마트아트 제거
- 스마트아트 레이아웃
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 SmartArt를 만들고 편집합니다: 노드를 추가하고, 레이아웃과 스타일을 변경하며, 정확하게 도형으로 변환하고, PPT, PPTX 및 ODP 형식으로 내보냅니다."
---
**Aspose.Slides for Python via .NET** 을 사용하여 SmartArt 그래픽을 추가하고, 접근하고, 제거하고, 레이아웃을 변경하는 방법을 보여줍니다.

## **SmartArt 추가**

내장 레이아웃 중 하나를 사용하여 SmartArt 그래픽을 삽입합니다.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 접근**

슬라이드에서 첫 번째 SmartArt 객체를 가져옵니다.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 SmartArt 모양에 접근합니다.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **SmartArt 제거**

슬라이드에서 SmartArt 모양을 삭제합니다.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 SmartArt 객체라고 가정합니다.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 레이아웃 변경**

기존 SmartArt 그래픽의 레이아웃 유형을 업데이트합니다.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 SmartArt 객체라고 가정합니다.
        smart_art = slide.shapes[0]

        # SmartArt 레이아웃을 변경합니다.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```