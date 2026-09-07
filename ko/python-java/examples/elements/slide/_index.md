---
title: 슬라이드
type: docs
weight: 10
url: /ko/python-java/examples/elements/slide/
keywords:
- 코드 예제
- 슬라이드
- 파워포인트
- 오픈문서
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 슬라이드를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션용 Python 코드 예제로 슬라이드 추가, 액세스, 복제, 재정렬 및 제거합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 슬라이드를 추가, 액세스, 복제, 재정렬 및 제거하는 방법을 보여주는 예제를 제공합니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택합니다. 이 예제는 빈 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
각 슬라이드 레이아웃은 전체 디자인 및 자리표시자 구조를 정의하는 마스터 슬라이드에서 파생됩니다. 아래 이미지에서는 PowerPoint에서 마스터 슬라이드와 해당 레이아웃이 어떻게 구성되는지 보여줍니다.
{{% /alert %}}

![마스터 및 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드 액세스**

슬라이드는 0부터 시작하는 인덱스를 사용하여 액세스하거나, 참조를 기반으로 슬라이드의 인덱스를 찾을 수 있습니다. 이는 특정 슬라이드를 순회하거나 수정할 때 유용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 다른 빈 슬라이드를 추가합니다.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # 인덱스로 슬라이드에 액세스합니다.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # 참조에서 슬라이드의 인덱스를 가져온 다음 인덱스로 액세스합니다.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **슬라이드 복제**

기존 슬라이드를 복제합니다. 복제된 슬라이드는 자동으로 슬라이드 컬렉션의 끝에 추가됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **슬라이드 재정렬**

슬라이드의 순서를 새 인덱스로 이동하여 변경합니다. 이 예제에서는 복제된 슬라이드를 첫 번째 위치로 이동합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **슬라이드 제거**

슬라이드 컬렉션에 슬라이드 참조를 전달하여 슬라이드를 제거합니다. 이 예제에서는 두 번째 슬라이드를 추가한 다음 원본 슬라이드를 제거하여 새 슬라이드만 남깁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```