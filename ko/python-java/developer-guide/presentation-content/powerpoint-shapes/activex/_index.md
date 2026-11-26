---
title: Python을 사용한 프레젠테이션의 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/python-java/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 텍스트 상자, 명령 단추 및 미디어 플레이어와 같은 대화형 요소를 PowerPoint 슬라이드에 제공합니다. Aspose.Slides for Python via Java는 슬라이드의 컨트롤을 [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) 를 통해 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하거나 슬라이드에서 이동하거나 제거할 수 있습니다.

## **ActiveX 컨트롤 및 저장된 속성 목록**

익숙하지 않은 템플릿을 검사하려면 읽기 전용으로 열고 각 슬라이드의 컨트롤을 반복합니다. 예제는 슬라이드 번호, 컨트롤 이름, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), 및 [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties)에서 각 키-값 쌍을 보고합니다. 컨트롤을 활성화하거나 이벤트 또는 매크로를 호출하거나 값을 변경하거나 파일을 저장하지 않고 프레젠테이션을 읽습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

`ActiveX.pptm`의 선택된 출력은 텍스트 상자와 명령 단추를 보여 줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

`[]` 로 빈 속성 컬렉션이 표시됩니다. 바이너리 저장소를 사용하는 컨트롤의 경우 [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) 은 `None` 을 반환할 수 있으며, 이는 `Properties unavailable` 로 표시됩니다. 이름만 필요하면 컬렉션이 사용 가능한지 확인한 후 [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) 를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 런타임에 추가 속성을 지원할 수 있습니다.

## **ActiveX 컨트롤 수정**

예제는 첫 번째 슬라이드에 `TextBox1`이라는 텍스트 상자와 `CommandButton1`이라는 명령 단추가 있는 매크로 사용 프레젠테이션을 기대합니다. 텍스트 상자 값과 단추 캡션을 변경하기 위해 [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) 을 사용합니다. 각 컨트롤은 활성화 전에 PowerPoint가 표시할 수 있는 정적 미리보기도 가집니다. 업데이트된 텍스트와 모양을 보여 주는 PNG를 각 컨트롤에 제공하십시오. 예제는 이러한 이미지를 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) 을 통해 할당합니다.

예제는 [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) 으로 프레임을 설정하여 첫 번째 슬라이드의 모든 컨트롤을 100 포인트 아래로 이동시킵니다. 편집된 프레젠테이션을 PPTM 형식으로 저장하고, 그 후 [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) 을 사용하여 해당 슬라이드에서 모든 ActiveX 컨트롤이 제거된 두 번째 사본을 저장합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1`이라는 플레이어가 포함된 템플릿으로 시작합니다. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 은 전체 슬라이드를 새 프레젠테이션으로 복사합니다. 예제는 플레이어의 `URL`을 [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) 에 설정하고 복제된 슬라이드를 출력의 유일한 슬라이드로 저장합니다. 비디오 파일은 외부에 남아 있으므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤을 활성화하지 않고도 해당 속성과 위치를 포함하여 읽고 저장할 수 있습니다.

**ActiveX 컨트롤은 OLE 개체와 어떻게 다릅니까?**

ActiveX 컨트롤은 사용자가 텍스트를 입력하거나 버튼을 클릭하는 등 슬라이드와 상호 작용할 수 있게 합니다. [OLE 개체](/slides/ko/python-java/manage-ole/) 는 슬라이드가 다른 애플리케이션에서 관리되는 콘텐츠(예: Excel 워크시트)를 포함하거나 연결하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 계속 트리거합니까?**

PPTM과 같은 매크로 사용 형식으로 프레젠테이션을 저장하여 VBA 프로젝트를 유지하십시오. Windows용 PowerPoint는 보안 설정에서 ActiveX 컨트롤과 매크로 모두를 허용할 때 기존 이벤트 처리기를 실행할 수 있습니다.