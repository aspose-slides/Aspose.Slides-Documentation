---
title: Python에서 PowerPoint 슬라이드 복제하기
linktitle: 슬라이드 복제
type: docs
weight: 40
url: /ko/python-net/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 슬라이드를 빠르게 복제하거나 중복하세요. 명확한 코드 예제와 팁을 따라 몇 초 만에 PPT 생성을 자동화하고 생산성을 높이며 수작업을 없앨 수 있습니다."
---
## **소개**

클로닝은 무언가를 정확히 복제하거나 복사하는 과정입니다. Aspose.Slides는 슬라이드를 복사(클론)한 후 해당 클론된 슬라이드를 현재 프레젠테이션이나 다른 열린 프레젠테이션에 삽입할 수 있도록 지원합니다. 슬라이드 클로닝을 통해 원본 슬라이드에 영향을 주지 않고 새 슬라이드를 수정할 수 있습니다. 슬라이드를 클론하는 방법에는 여러 가지가 있습니다:

- 프레젠테이션의 끝에 클론하기.
- 프레젠테이션 내 다른 위치에 클론하기.
- 다른 프레젠테이션의 끝에 클론하기.
- 다른 프레젠테이션의 다른 위치에 클론하기.
- 다른 프레젠테이션의 특정 위치에 클론하기.

Aspose.Slides for Python via .NET에서 [slide collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)을 노출하는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 개체는 이러한 유형의 슬라이드 클로닝을 수행하기 위해 `add_clone` 및 `insert_clone` 메서드를 제공합니다.

## **설치**

```bash
pip install aspose.slides
```

## **같은 프레젠테이션 내 끝에 클론하기**

같은 프레젠테이션 내에서 슬라이드를 클론하고 기존 슬라이드 끝에 추가하려면 `add_clone` 메서드를 사용합니다. 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 개체에서 슬라이드 컬렉션을 가져옵니다.
1. 클론할 슬라이드를 전달하면서 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)에 `add_clone` 메서드를 호출합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 예제에서는 첫 번째 슬라이드(인덱스 0)를 클론하여 프레젠테이션 끝에 추가합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다.
    presentation.slides.add_clone(presentation.slides[0])
    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **같은 프레젠테이션 내 특정 위치에 클론하기**

같은 프레젠테이션 내에서 슬라이드를 클론하고 다른 위치에 배치하려면 `insert_clone` 메서드를 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 개체에서 슬라이드 컬렉션을 가져옵니다.
1. 클론할 슬라이드와 새 위치의 대상 인덱스를 전달하면서 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)에 `insert_clone` 메서드를 호출합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 예제에서는 인덱스 1(위치 2)의 슬라이드를 인덱스 2(위치 3)로 클론합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # 동일한 프레젠테이션 내 지정된 위치(인덱스)에 원하는 슬라이드를 복제합니다.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # 수정된 프레젠테이션을 디스크에 저장합니다.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **다른 프레젠테이션 끝에 클론하기**

한 프레젠테이션에서 슬라이드를 클론하여 다른 프레젠테이션 끝에 추가하려면:

1. 슬라이드를 복사할 원본 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 슬라이드가 추가될 대상 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 대상 프레젠테이션의 슬라이드 컬렉션을 가져옵니다.
1. 대상 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)에 `add_clone`을 호출하고 원본 프레젠테이션의 슬라이드를 전달합니다.
1. 수정된 대상 프레젠테이션을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0 슬라이드를 대상 프레젠테이션 끝에 클론합니다.

```py
import aspose.slides as slides

# 소스 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 슬라이드가 복제될 대상 PPTX를 위한 Presentation 클래스를 인스턴스화합니다.
    with slides.Presentation() as target_presentation:
        # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # 대상 프레젠테이션을 디스크에 저장합니다.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **다른 프레젠테이션 특정 위치에 클론하기**

한 프레젠테이션에서 슬라이드를 클론하여 다른 프레젠테이션의 특정 위치에 삽입하려면:

1. 슬라이드를 복사할 원본 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 슬라이드가 추가될 대상 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 대상 프레젠테이션의 슬라이드 컬렉션을 가져옵니다.
1. 대상 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)에 `insert_clone` 메서드를 호출하고 원본 슬라이드와 원하는 대상 인덱스를 전달합니다.
1. 수정된 대상 프레젠테이션을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0 슬라이드를 대상 프레젠테이션의 인덱스 2(위치 3)로 클론합니다.

```py
import aspose.slides as slides

# 소스 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # 슬라이드가 복제될 대상 PPTX를 위한 Presentation 클래스를 인스턴스화합니다.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # 소스의 첫 번째 슬라이드를 대상 프레젠테이션의 인덱스 2에 복제된 슬라이드로 삽입합니다.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # 대상 프레젠테이션을 디스크에 저장합니다.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **마스터 슬라이드와 함께 슬라이드 클론하기**

한 프레젠테이션에서 **마스터와 함께** 슬라이드를 클론하여 다른 프레젠테이션에서 사용하려면 먼저 원본 프레젠테이션의 필요한 마스터 슬라이드를 대상 프레젠테이션에 클론해야 합니다. 그런 다음 해당 대상 마스터를 사용해 슬라이드를 클론합니다. `add_clone(Slide, MasterSlide)` 메서드는 **원본이 아닌 대상 프레젠테이션의 마스터 슬라이드**를 기대합니다.

마스터와 함께 슬라이드를 클론하려면 다음 단계를 따르세요:

1. 슬라이드를 복사할 원본 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 대상 프레젠테이션에 대해 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 클론할 원본 슬라이드와 해당 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 마스터 컬렉션에서 [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/)을 가져옵니다.
1. 대상 [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/)에 `add_clone`을 호출하여 원본 마스터를 클론합니다.
1. 대상 프레젠테이션의 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)을 가져옵니다.
1. 대상 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/)에 `add_clone`을 호출하고 원본 슬라이드와 클론된 대상 마스터를 전달합니다.
1. 수정된 대상 프레젠테이션을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0 슬라이드를 원본에서 클론한 마스터와 함께 대상 프레젠테이션 끝에 추가합니다.

```py
import aspose.slides as slides

# 소스 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # 슬라이드가 복제될 대상 프레젠테이션을 위한 Presentation 클래스를 인스턴스화합니다.
    with slides.Presentation() as target_presentation:
        # 소스 프레젠테이션에서 첫 번째 슬라이드를 가져옵니다.
        source_slide = source_presentation.slides[0]
        # 첫 번째 슬라이드가 사용하는 마스터 슬라이드를 가져옵니다.
        source_master = source_slide.layout_slide.master_slide
        # 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # 복제된 마스터를 사용하여 소스 프레젠테이션의 슬라이드를 대상 프레젠테이션 끝에 복제합니다.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # 대상 프레젠테이션을 디스크에 저장합니다.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **지정된 섹션 끝에 클론하기**

Aspose.Slides for Python via .NET을 사용하면 프레젠테이션의 한 섹션에서 슬라이드를 클론하고 같은 프레젠테이션 내 다른 섹션에 삽입할 수 있습니다. 이를 위해 [SlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/) 클래스의 `add_clone(Slide, Section)` 메서드를 사용합니다.

다음 Python 예제는 슬라이드를 클론하고 클론을 지정된 섹션에 삽입하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# 새 빈 프레젠테이션을 생성합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드의 레이아웃을 기반으로 빈 슬라이드를 추가합니다.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # 새 슬라이드에 타원 모양을 추가합니다; 이 슬라이드는 나중에 복제됩니다.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # 첫 번째 슬라이드의 레이아웃을 기반으로 또 다른 빈 슬라이드를 추가합니다.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # "Section2" 라는 이름의 섹션을 만들고 slide2에서 시작합니다.
    section = presentation.sections.add_section("Section2", slide2)
    # 이전에 만든 슬라이드를 "Section2" 섹션에 복제합니다.
    presentation.slides.add_clone(slide, section)
    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### 발표자 메모와 검토자 주석도 클론되나요?

예. 메모 페이지와 검토 주석이 클론에 포함됩니다. 필요하지 않다면 삽입 후 [제거](/slides/ko/python-net/presentation-notes/)하십시오.

### 차트 및 차트 데이터 소스는 어떻게 처리되나요?

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE로 삽입된 워크북)에 연결되어 있었다면 해당 연결이 [OLE 개체](/slides/ko/python-net/manage-ole/)로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

### 클론의 삽입 위치와 섹션을 제어할 수 있나요?

예. 특정 슬라이드 인덱스에 클론을 삽입하고 원하는 [섹션](/slides/ko/python-net/slide-section/)에 배치할 수 있습니다. 대상 섹션이 존재하지 않을 경우 먼저 생성한 다음 슬라이드를 이동하십시오.