---
title: Python으로 프레젠테이션 슬라이드 접근
linktitle: 슬라이드 접근
type: docs
weight: 20
url: /ko/python-net/access-slide-in-presentation/
keywords:
- 슬라이드 접근
- 슬라이드 인덱스
- 슬라이드 ID
- 슬라이드 위치
- 위치 변경
- 슬라이드 속성
- 슬라이드 번호
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 슬라이드를 접근하고 관리하는 방법을 배웁니다. 코드 예제로 생산성을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Python을 사용하여 PowerPoint 프레젠테이션에서 특정 슬라이드에 액세스하는 방법을 설명합니다. 프레젠테이션을 열고, 슬라이드를 인덱스 또는 고유 ID로 참조하며, 파일 내 탐색에 필요한 기본 슬라이드 정보를 읽는 방법을 보여줍니다. 이러한 기술을 사용하면 검사하거나 처리하려는 정확한 슬라이드를 안정적으로 찾을 수 있습니다.

## **인덱스로 슬라이드에 액세스**

프레젠테이션의 슬라이드는 위치에 따라 0부터 인덱싱됩니다. 첫 번째 슬라이드의 인덱스는 0이고, 두 번째 슬라이드의 인덱스는 1이며, 이와 같이 진행됩니다.

The [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class (which represents a presentation file) exposes slides through a [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/) of [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) objects.

The following Python code shows how to access a slide by its index:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 생성합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 인덱스로 슬라이드를 가져옵니다.
    slide = presentation.slides[0]
```

## **ID로 슬라이드에 액세스**

프레젠테이션의 각 슬라이드에는 고유한 ID가 연결되어 있습니다. 해당 ID를 대상으로 하려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 노출되는 [get_slide_by_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_slide_by_id/) 메서드를 사용할 수 있습니다. 

The following Python code shows how to provide a valid slide ID and access that slide through the [get_slide_by_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/get_slide_by_id/) method:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 생성합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 슬라이드 ID를 가져옵니다.
    id = presentation.slides[0].slide_id
    # 해당 ID로 슬라이드에 접근합니다.
    slide = presentation.get_slide_by_id(id)
```

## **슬라이드 위치 변경**

Aspose.Slides를 사용하면 슬라이드의 위치를 변경할 수 있습니다. 예를 들어, 첫 번째 슬라이드를 두 번째 슬라이드로 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 위치를 변경하려는 슬라이드에 대한 참조를 가져옵니다.
1. [slide_number](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/slide_number/) 속성을 통해 슬라이드의 새 위치를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

The following Python code moves the slide in position 1 to position 2:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 위치가 변경될 슬라이드를 가져옵니다.
    slide = presentation.slides[0]
    # 슬라이드의 새 위치를 설정합니다.
    slide.slide_number = 2
    # 수정된 프레젠테이션을 저장합니다.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

첫 번째 슬라이드가 두 번째가 되고, 두 번째 슬라이드가 첫 번째가 됩니다. 슬라이드 위치를 변경하면 다른 슬라이드가 자동으로 조정됩니다.

## **슬라이드 번호 설정**

[first_slide_number](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/first_slide_number/) 속성([Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스에서 노출)을 사용하면 프레젠테이션의 첫 번째 슬라이드에 새 번호를 지정할 수 있습니다. 이 작업은 다른 슬라이드 번호를 다시 계산하게 합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 슬라이드 번호를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

The following Python code demonstrates an operation where the first slide number is set to 10:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    # 슬라이드 번호를 설정합니다.
    presentation.first_slide_number = 10
    # 수정된 프레젠테이션을 저장합니다.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

첫 번째 슬라이드를 건너뛰고 싶다면 두 번째 슬라이드부터 번호를 시작하고 (첫 번째 슬라이드에서는 번호를 숨김) 다음과 같이 할 수 있습니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # 프레젠테이션에서 첫 번째 슬라이드의 번호를 설정합니다.
    presentation.first_slide_number = 0

    # 모든 슬라이드에 슬라이드 번호를 표시합니다.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 첫 번째 슬라이드에서 슬라이드 번호를 숨깁니다.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 수정된 프레젠테이션을 저장합니다.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**사용자가 보는 슬라이드 번호가 컬렉션의 0 기반 인덱스와 일치합니까?**

슬라이드에 표시되는 번호는 임의의 값(예: 10)부터 시작할 수 있으며 인덱스와 일치할 필요가 없습니다; 이 관계는 프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/first_slide_number/) 설정에 의해 제어됩니다.

**숨겨진 슬라이드가 인덱싱에 영향을 줍니까?**

예. 숨겨진 슬라이드는 컬렉션에 남아 있으며 인덱싱에 포함됩니다. "숨김"은 표시 여부를 의미할 뿐, 컬렉션 내 위치와는 무관합니다.

**다른 슬라이드가 추가되거나 제거될 때 슬라이드의 인덱스가 변경됩니까?**

예. 인덱스는 항상 현재 슬라이드 순서를 반영하며 삽입, 삭제, 이동 작업 시 재계산됩니다.