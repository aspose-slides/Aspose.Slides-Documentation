---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/python-java/examples/elements/layout-slide/
keywords:
- 코드 예제
- 레이아웃 슬라이드
- 레이아웃 슬라이드 추가
- 레이아웃 슬라이드 액세스
- 레이아웃 슬라이드 제거
- 사용되지 않는 레이아웃 슬라이드
- 레이아웃 슬라이드 복제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 레이아웃 슬라이드를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 레이아웃을 추가, 액세스, 제거, 정리 및 복제합니다."
---
이 문서에서는 Java를 통해 Python용 Aspose.Slides를 사용하여 **레이아웃 슬라이드**를 다루는 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 액세스, 복제 및 제거할 수 있으며, 사용되지 않는 레이아웃을 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

## **레이아웃 슬라이드 추가**

재사용 가능한 서식을 정의하기 위해 사용자 지정 레이아웃 슬라이드를 생성합니다. 다음 예제에서는 새 레이아웃에 텍스트 상자를 추가하고 이를 사용하는 두 개의 슬라이드를 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # 빈 레이아웃 유형과 사용자 지정 이름으로 레이아웃 슬라이드를 생성합니다.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # 레이아웃 슬라이드에 텍스트 상자를 추가합니다.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # 레이아웃에서 텍스트를 상속받는 슬라이드 두 개를 추가합니다.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Note 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하고 여러 슬라이드에서 재사용할 수 있습니다.
> 💡 **Note 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면 해당 레이아웃을 기반으로 하는 모든 슬라이드가 공유된 내용을 자동으로 표시합니다.
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 개의 슬라이드를 보여줍니다.

![레이아웃 콘텐츠를 상속받은 슬라이드](layout-slide-result.png)

## **레이아웃 슬라이드에 액세스**

인덱스 또는 레이아웃 유형(예: 빈 레이아웃, 제목, 섹션 헤더)으로 레이아웃 슬라이드에 접근할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # 인덱스로 레이아웃 슬라이드에 접근합니다.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # 유형으로 레이아웃 슬라이드에 접근합니다.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **레이아웃 슬라이드 제거**

필요하지 않을 때 특정 레이아웃 슬라이드를 제거합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **사용되지 않는 레이아웃 슬라이드 제거**

일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거하여 프레젠테이션 크기를 줄입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **레이아웃 슬라이드 복제**

레이아웃 슬라이드를 복제하고 복사본을 레이아웃 슬라이드 컬렉션의 끝에 추가합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Summary:** 레이아웃 슬라이드는 프레젠테이션 전체에 일관된 서식을 유지하는 데 도움이 됩니다. Aspose.Slides를 사용하면 필요에 따라 레이아웃을 생성, 관리, 재사용 및 정리할 수 있습니다.