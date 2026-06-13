---
title: 잉크
type: docs
weight: 180
url: /ko/python-net/examples/elements/ink/
keywords:
- 잉크
- 잉크 접근
- 잉크 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 슬라이드의 디지털 잉크를 처리합니다: 펜 스트로크를 추가하고, 경로를 편집하고, 색상과 굵기를 설정하며, PowerPoint와 OpenDocument용 결과를 내보냅니다."
---
기존 잉크 도형에 접근하고 이를 제거하는 예제를 **Aspose.Slides for Python via .NET**을 사용하여 제공합니다.

> ❗ **참고:** 잉크 도형은 특수 장치에서 사용자의 입력을 나타냅니다. Aspose.Slides는 프로그래밍 방식으로 새로운 잉크 스트로크를 만들 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.

## **잉크 접근**

슬라이드에서 첫 번째 잉크 도형을 가져옵니다.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **잉크 제거**

슬라이드에서 잉크 도형을 삭제합니다.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 Ink 객체라고 가정합니다.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```