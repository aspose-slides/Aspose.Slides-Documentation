---
title: 슬라이드
type: docs
weight: 10
url: /ko/python-net/examples/elements/slide/
keywords:
- 슬라이드
- 슬라이드 추가
- 슬라이드 접근
- 슬라이드 인덱스
- 슬라이드 복제
- 슬라이드 재정렬
- 슬라이드 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용한 Python에서 슬라이드 관리: 슬라이드 생성, 복제, 재정렬, 숨기기, 배경 및 크기 설정, 전환 적용, PowerPoint 및 OpenDocument용 내보내기."
---
이 문서에서는 **Aspose.Slides for Python via .NET**을 사용하여 슬라이드를 다루는 방법을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 접근, 복제, 재정렬 및 제거하는 방법을 배우게 됩니다.

아래 각 예제는 간단한 설명과 그 뒤에 Python 코드 스니펫을 포함합니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # 각 슬라이드는 레이아웃을 기반으로 하며, 레이아웃 자체는 마스터 슬라이드를 기반으로 합니다.
        # 새 슬라이드를 만들기 위해 Blank 레이아웃을 사용합니다.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **팁:** 각 슬라이드 레이아웃은 마스터 슬라이드에서 파생되며, 마스터 슬라이드는 전체 디자인과 자리표시자 구조를 정의합니다. 아래 이미지는 마스터 슬라이드와 해당 레이아웃이 PowerPoint에서 어떻게 구성되는지를 보여줍니다.

![마스터와 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드에 접근**

인덱스를 사용하여 슬라이드에 접근할 수 있습니다. 이는 슬라이드를 순회하거나 특정 슬라이드를 수정할 때 유용합니다.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # 인덱스로 슬라이드에 접근합니다.
        first_slide = presentation.slides[0]
```

## **슬라이드 복제**

이 예제는 기존 슬라이드를 복제하는 방법을 보여줍니다. 복제된 슬라이드는 슬라이드 컬렉션의 끝에 자동으로 추가됩니다.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드를 복제합니다; 프레젠테이션 끝에 추가됩니다.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 재정렬**

슬라이드를 새로운 인덱스로 이동시켜 순서를 변경할 수 있습니다. 여기서는 슬라이드를 첫 번째 위치로 이동합니다.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # 슬라이드를 첫 번째 위치로 이동합니다 (다른 슬라이드가 아래로 이동합니다).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 제거**

슬라이드를 제거하려면 해당 슬라이드를 참조하고 `remove`를 호출하면 됩니다. 이 예제에서는 첫 번째 슬라이드를 제거합니다.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드를 제거합니다.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```