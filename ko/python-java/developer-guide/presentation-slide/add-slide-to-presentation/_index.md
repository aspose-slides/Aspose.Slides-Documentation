---
title: Python에서 프레젠테이션에 슬라이드 추가
linktitle: 슬라이드 추가
type: docs
weight: 10
url: /ko/python-java/add-slide-to-presentation/
keywords:
- 슬라이드 추가
- 슬라이드 생성
- 빈 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 슬라이드를 쉽게 추가할 수 있습니다—몇 초 만에 원활하고 효율적인 슬라이드 삽입이 가능합니다."
---
## **Overview**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에 슬라이드를 추가할 수 있습니다. 프레젠테이션에는 마스터/레이아웃 슬라이드와 일반 슬라이드가 포함되며, 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다. 각 슬라이드는 고유 ID를 가지며, 슬라이드가 없는 프레젠테이션 파일은 지원되지 않습니다.

이 문서에서는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 생성하고, 슬라이드 컬렉션에 액세스한 뒤, 빈 슬라이드를 추가하고, 새로 추가된 슬라이드를 활용한 뒤, 업데이트된 프레젠테이션을 저장하는 방법을 설명합니다. 또한 특정 위치에 슬라이드를 삽입하거나 레이아웃을 사용하는 방법, 새로 만든 프레젠테이션에 존재하는 빈 슬라이드에 대한 내용도 다룹니다.

## **Add a Slide to a Presentation**

프레젠테이션 파일에 슬라이드를 추가하는 방법을 논의하기 전에 슬라이드에 관한 몇 가지 사실을 살펴보겠습니다. 각 PowerPoint 프레젠테이션 파일에는 **마스터/레이아웃** 슬라이드와 **일반** 슬라이드가 포함됩니다. 프레젠테이션 파일에는 최소 하나의 슬라이드가 있어야 하며, 슬라이드가 없는 파일은 Aspose.Slides for Python via Java에서 지원되지 않습니다. 각 슬라이드는 고유 ID를 가지며, 모든 일반 슬라이드는 0부터 시작하는 인덱스로 정렬됩니다.

Aspose.Slides for Python via Java을 사용하면 개발자가 프레젠테이션에 빈 슬라이드를 추가할 수 있습니다. 프레젠테이션에 빈 슬라이드를 추가하려면 다음 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 제공하는 [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides) 메서드를 사용하여 [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체에 대한 참조를 얻습니다.
- [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [addEmptySlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addEmptySlide) 메서드를 호출하여 프레젠테이션 슬라이드 컬렉션의 끝에 빈 슬라이드를 추가합니다.
- 새로 추가된 빈 슬라이드로 작업을 수행합니다.
- 마지막으로 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체를 사용하여 프레젠테이션 파일을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Presentation 클래스를 인스턴스화합니다. 이 클래스는 프레젠테이션 파일을 나타냅니다.
presentation = Presentation()
try:
    # 슬라이드 컬렉션을 가져옵니다.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # 슬라이드 컬렉션에 빈 슬라이드를 추가합니다.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # 새로 추가된 슬라이드에 대한 작업을 수행합니다.

    # PPTX 파일을 디스크에 저장합니다.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

예. 라이브러리는 슬라이드 컬렉션과 [insert](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertClone) 작업을 지원하므로 끝에만이 아니라 필요한 인덱스에 슬라이드를 추가할 수 있습니다.

**Are the theme/styles preserved when adding a slide based on a layout?**

예. 레이아웃은 마스터로부터 형식을 상속하며, 새 슬라이드는 선택한 레이아웃과 해당 마스터로부터 형식을 상속합니다.

**Which slide is present in a new "empty" presentation before adding slides?**

새롭게 만든 프레젠테이션에는 인덱스 0인 빈 슬라이드가 하나 이미 포함되어 있습니다. 삽입 인덱스를 계산할 때 이 점을 고려해야 합니다.

**How do I choose the "right" layout for a new slide if the master has many options?**

일반적으로 필요한 구조(예: Title and Content, Two Content 등)에 맞는 [LayoutSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslide/)을 선택합니다. 해당 레이아웃이 없을 경우 [add it to the master](/slides/ko/python-java/slide-layout/)하고 사용할 수 있습니다.