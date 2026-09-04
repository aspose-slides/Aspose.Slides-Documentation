---
title: ActiveX
type: docs
weight: 200
url: /ko/python-java/examples/elements/activex/
keywords:
- 코드 예제
- ActiveX
- ActiveX 컨트롤
- ActiveX 속성
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 실용적인 코드 예제를 제공합니다."
---
이 문서에서는 **Aspose.Slides for Python via Java**를 사용하여 프레젠테이션에 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다. 액세스 및 제거 예제는 첫 번째 예제에서 만든 `add_activex.pptm`을 사용합니다.

## **ActiveX 컨트롤 추가**

첫 번째 슬라이드에 Windows Media Player 컨트롤을 삽입하고 프레젠테이션을 PPTM 파일로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player 컨트롤 추가.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX 컨트롤 액세스**

슬라이드에 있는 첫 번째 ActiveX 컨트롤의 이름과 자동 재생 설정을 읽어옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 첫 번째 ActiveX 컨트롤에 액세스.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **ActiveX 컨트롤 제거**

슬라이드에서 첫 번째 ActiveX 컨트롤을 삭제하고 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 첫 번째 ActiveX 컨트롤 제거.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **ActiveX 속성 설정**

Windows Media Player 컨트롤을 추가하고 자동 재생을 비활성화하며 재생 컨트롤을 숨깁니다. 문자열로 속성 값을 할당하려면 [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/ko/python-java/aspose.slides/controlpropertiescollection/#set_Item)를 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Windows Media Player 컨트롤을 추가하고 속성을 구성합니다.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```