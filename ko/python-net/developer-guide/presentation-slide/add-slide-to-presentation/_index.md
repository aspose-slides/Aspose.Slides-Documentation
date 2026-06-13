---
title: Python으로 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/python-net/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 만들기
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 손쉽게 추가합니다—몇 초 만에 원활하고 효율적인 슬라이드 삽입을 제공합니다."
---
## **개요**

프레젠테이션에 슬라이드를 추가하기 전에 PowerPoint가 슬라이드를 어떻게 구성하는지 이해하는 것이 도움이 됩니다. 각 프레젠테이션에는 마스터 슬라이드, 선택적인 레이아웃 슬라이드 및 하나 이상의 일반 슬라이드가 포함됩니다. 모든 슬라이드에는 고유 ID가 있으며 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 이 문서에서는 Aspose.Slides for Python을 사용하여 슬라이드를 만들고 적절한 레이아웃을 선택하는 방법을 보여 줍니다.

## **프레젠테이션에 슬라이드 추가**

Aspose.Slides를 사용하면 기존 레이아웃 슬라이드를 기반으로 새 슬라이드를 추가할 수 있습니다. 아래 예제는 프레젠테이션의 각 레이아웃을 순회하면서 해당 레이아웃을 사용하는 슬라이드를 추가하고 파일을 저장합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. SlideCollection에 접근합니다.
1. `presentation.layout_slides`의 각 항목에 대해 `add_empty_slide`를 호출하여 해당 레이아웃을 사용하는 슬라이드를 추가합니다.
1. 새로 추가된 슬라이드를 필요에 따라 수정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 슬라이드 컬렉션에 접근합니다.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # 슬라이드 컬렉션에 빈 슬라이드를 추가합니다.
        slides.add_empty_slide(layout_slide)

    # 새로 추가된 슬라이드에 대해 작업을 수행합니다.

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**특정 위치에 새 슬라이드를 삽입할 수 있나요, 끝에만 추가하는 것이 아니라?**

예. 이 라이브러리는 슬라이드 컬렉션과 [insert](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slidecollection/insert_clone/) 작업을 지원하므로, 끝에만 추가하는 것이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**레이아웃을 기반으로 슬라이드를 추가할 때 테마/스타일이 보존되나요?**

예. 레이아웃은 마스터로부터 서식을 상속받으며, 새 슬라이드는 선택한 레이아웃과 해당 마스터로부터 상속받습니다.

**슬라이드를 추가하기 전에 새 “빈” 프레젠테이션에 어떤 슬라이드가 존재하나요?**

새로 만든 프레젠테이션에는 이미 인덱스 0인 빈 슬라이드가 하나 포함되어 있습니다. 삽입 인덱스를 계산할 때 이는 중요합니다.

**마스터에 옵션이 많이 있을 때 새 슬라이드에 올바른 레이아웃을 어떻게 선택하나요?**

일반적으로 필요한 구조([Title and Content, Two Content, 등])에 맞는 LayoutSlide를 선택합니다. 해당 레이아웃이 없으면 [add it to the master](/slides/ko/python-net/slide-layout/)를 사용해 마스터에 추가한 뒤 사용할 수 있습니다.