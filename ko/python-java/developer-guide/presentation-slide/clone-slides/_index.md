---
title: "Python에서 프레젠테이션 슬라이드 복제"
linktitle: "슬라이드 복제"
type: docs
weight: 35
url: /ko/python-java/clone-slides/
keywords:
- "슬라이드 복제"
- "슬라이드 복사"
- "슬라이드 저장"
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 슬라이드를 빠르게 복제하세요. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

복제는 무언가를 정확히 복사하거나 복제하는 과정입니다. Aspose.Slides for Python via Java는 任意의 슬라이드를 복사하거나 복제한 뒤 해당 복제 슬라이드를 현재 프레젠테이션이나 다른 열린 프레젠테이션에 삽입할 수 있게 합니다. 슬라이드 복제 과정은 원본 슬라이드를 변경하지 않고도 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 여러 방법이 있습니다:

- 프레젠테이션 내에서 끝에 복제한다.
- 프레젠테이션 내의 다른 위치에 복제한다.
- 다른 프레젠테이션의 끝에 복제한다.
- 다른 프레젠테이션의 다른 위치에 복제한다.
- 마스터 슬라이드와 함께 다른 프레젠테이션에 복제한다.

Aspose.Slides for Python via Java에서는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 노출하는 슬라이드 컬렉션([Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 객체의 컬렉션)이 위에서 설명한 슬라이드 복제 유형을 수행하기 위해 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 및 [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertClone) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 복제**

슬라이드를 복제하고 동일한 프레젠테이션 파일에서 기존 슬라이드의 끝에 사용하려면, 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체를 가져옵니다.
3. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드를 호출하고 복제할 슬라이드를 해당 메서드의 매개변수로 전달합니다.
4. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # 같은 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # 수정된 프레젠테이션을 디스크에 저장합니다
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **프레젠테이션 내 다른 위치에 슬라이드 복제**

슬라이드를 복제하고 동일한 프레젠테이션 파일 내에서 다른 위치에 사용하려면, [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertClone) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체에서 [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides) 메서드가 반환하는 슬라이드 컬렉션에 대한 참조를 가져옵니다.
3. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertClone) 메서드를 호출하고 복제할 슬라이드와 새 위치에 대한 인덱스를 매개변수로 전달합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 인덱스 1(위치 2)에 있는 슬라이드를 인덱스 2(위치 3)로 복제했습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # 프레젠테이션의 슬라이드 컬렉션을 가져옵니다
    slides = presentation.getSlides()

    # 같은 프레젠테이션 내 지정된 인덱스로 원하는 슬라이드를 복제합니다
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # 수정된 프레젠테이션을 디스크에 저장합니다
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **다른 프레젠테이션 끝에 슬라이드 복제**

한 프레젠테이션에서 슬라이드를 복제해 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용해야 하는 경우:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
3. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체에서 [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides) 메서드가 반환하는 슬라이드 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체를 가져옵니다.
4. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 끝으로 복제했습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 슬라이드를 복제할 대상 PPTX를 위해 Presentation 클래스를 인스턴스화합니다
    destination_presentation = Presentation()
    try:
        # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # 대상 프레젠테이션을 디스크에 저장합니다
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **다른 프레젠테이션의 다른 위치에 슬라이드 복제**

한 프레젠테이션에서 슬라이드를 복제해 다른 프레젠테이션 파일의 특정 위치에 사용해야 하는 경우:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
3. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체를 가져옵니다.
4. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#insertClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

```python
import jpway
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # 슬라이드를 복제할 대상 PPTX를 위해 Presentation 클래스를 인스턴스화합니다
    destination_presentation = Presentation()
    try:
        # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 지정된 인덱스로 복제합니다
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # 대상 프레젠테이션을 디스크에 저장합니다
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **마스터 슬라이드와 함께 다른 프레젠테이션에 슬라이드 복제**

한 프레젠테이션에서 마스터 슬라이드와 함께 슬라이드를 복제해 다른 프레젠테이션에 사용하려면, 먼저 원본 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 슬라이드를 복제할 때 복제된 마스터 슬라이드를 사용합니다. [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드는 원본이 아닌 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 복제하려면 아래 단계에 따라 진행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. 슬라이드를 복제할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
3. 복제할 슬라이드와 해당 마스터 슬라이드에 접근합니다.
4. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 노출하는 Masters 컬렉션을 참조하여 [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/) 객체를 가져옵니다.
5. [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/#addClone) 메서드를 호출하고 원본 PPTX의 마스터를 매개변수로 전달합니다.
6. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체를 가져옵니다.
7. [SlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 복제된 마스터 슬라이드를 매개변수로 전달합니다.
8. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 마스터와 함께 슬라이드를 복제하여 대상 프레젠테이션의 끝에 추가했습니다. 이때 원본 슬라이드의 마스터를 사용했습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # 슬라이드를 복제할 대상 프레젠테이션을 위해 Presentation 클래스를 인스턴스화합니다 (복제 대상)
    destination_presentation = Presentation()
    try:
        # 소스 프레젠테이션의 슬라이드 컬렉션에서 슬라이드를 인스턴스화하고
        # 마스터 슬라이드와 함께
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 마스터와 함께 복제합니다
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # 대상 프레젠테이션을 디스크에 저장합니다
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **지정된 섹션 끝에 슬라이드 복제**

슬라이드를 복제하고 동일한 프레젠테이션 파일 내에서 다른 섹션에 사용하려면, [**SlideCollection**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/) 클래스가 제공하는 [**addClone**](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidecollection/#addClone) 메서드를 사용하십시오. Aspose.Slides for Python via Java를 사용하면 첫 번째 섹션에서 슬라이드를 복제한 뒤 동일한 프레젠테이션의 두 번째 섹션에 삽입할 수 있습니다.

다음 코드 스니펫은 슬라이드를 복제하고 지정된 섹션에 복제된 슬라이드를 삽입하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # 대상 프레젠테이션을 디스크에 저장합니다
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **슬라이드 크기 일치 보장**

슬라이드를 다른 프레젠테이션으로 복제할 때, 대상 프레젠테이션의 슬라이드 크기가 원본과 동일한지 확인하십시오. 슬라이드 크기가 다르면 Aspose.Slides는 복제된 도형을 자동으로 크기 조정하지 않으며, 도형의 원래 좌표와 크기가 유지되어 내용이 정렬이 맞지 않거나 슬라이드 경계를 넘어 표시될 수 있습니다.

마스터와 슬라이드를 복제하기 전에 대상 프레젠테이션의 슬라이드 크기를 원본에 맞게 설정할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

마스터와 슬라이드를 복제하기 전에 이 작업을 수행하십시오.

## **FAQ**

**스피커 노트와 검토자 의견도 복제되나요?**

예. 노트 페이지와 검토 의견이 복제에 포함됩니다. 원하지 않으면 삽입 후 [제거하십시오](/slides/ko/python-java/presentation-notes/) 하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)에 연결된 경우, 해당 연결이 [OLE object](/slides/ko/python-java/manage-ole/) 로 보존됩니다. 파일 간 이동 후 데이터 가용성 및 새로 고침 동작을 확인하십시오.

**복제본의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제본을 삽입하고 원하는 [섹션](/slides/ko/python-java/slide-section/)에 배치할 수 있습니다. 대상 섹션이 존재하지 않으면 먼저 섹션을 생성한 후 슬라이드를 이동하십시오.