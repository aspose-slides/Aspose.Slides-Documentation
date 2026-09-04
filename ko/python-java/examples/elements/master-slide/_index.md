---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/python-java/examples/elements/master-slide/
keywords:
- 코드 예제
- 마스터 슬라이드
- 마스터 슬라이드 추가
- 마스터 슬라이드 액세스
- 마스터 슬라이드 제거
- 사용되지 않는 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 마스터 슬라이드를 관리합니다: PowerPoint와 OpenDocument 프레젠테이션에서 마스터를 만들고, 액세스하고, 제거하며, 정리합니다."
---
마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층 구조의 최상위 수준을 형성합니다. **마스터 슬라이드**는 배경, 로고 및 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드로부터 상속되며, **보통 슬라이드**는 레이아웃 슬라이드로부터 상속됩니다.

이 문서에서는 **Aspose.Slides for Python via Java**를 사용하여 마스터 슬라이드를 생성, 수정 및 관리하는 방법을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 임포트하고, JVM이 실행된 후 API를 임포트합니다.

## **마스터 슬라이드 추가**

이 예제는 기본 마스터 슬라이드를 복제하여 새 마스터 슬라이드를 만드는 방법을 보여줍니다. 그런 다음 레이아웃 상속을 통해 모든 슬라이드에 회사 이름 배너를 추가합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # 기본 마스터 슬라이드를 복제합니다.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # 마스터 슬라이드 상단에 회사 이름 배너를 추가합니다.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # 새 마스터 슬라이드를 레이아웃 슬라이드에 할당합니다.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # 레이아웃 슬라이드를 프레젠테이션의 첫 번째 슬라이드에 할당합니다.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
마스터 슬라이드는 모든 슬라이드에 일관된 브랜딩이나 공유 디자인 요소를 적용할 수 있는 방법을 제공합니다. 마스터에 대한 변경 사항은 종속 레이아웃 및 보통 슬라이드에 자동으로 반영됩니다.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
마스터 슬라이드에 추가된 도형과 서식은 레이아웃 슬라이드에 상속되고, 다시 해당 레이아웃을 사용하는 모든 보통 슬라이드에 상속됩니다. 아래 이미지는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 렌더링되는 방식을 보여줍니다.
{{% /alert %}}

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

프레젠테이션의 마스터 컬렉션을 통해 마스터 슬라이드에 접근할 수 있습니다. 이 예제는 첫 번째 마스터 슬라이드를 가져와 배경 유형을 변경합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **마스터 슬라이드 제거**

마스터 슬라이드는 더 이상 사용되지 않을 때 인덱스 또는 참조로 제거할 수 있습니다. 이 예제는 복제된 마스터 슬라이드를 프레젠테이션에 할당한 다음 인덱스로 원본 마스터를 제거합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # 인덱스로 사용되지 않는 원본 마스터 슬라이드를 제거합니다.
    presentation.getMasters().removeAt(0)

    # 또는, 사용되지 않는 마스터 슬라이드를 참조로 제거합니다:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # 사용되지 않는 모든 마스터 슬라이드를 제거합니다. Preserve로 표시된 슬라이드도 포함합니다.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```