---
title: Python으로 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/python-net/activex/
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션에서 ActiveX 텍스트 상자와 버튼을 편집하고, 컨트롤 미리보기를 업데이트하며, Windows Media Player 컨트롤을 재사용합니다."
---
## **소개**

ActiveX 컨트롤은 PowerPoint 슬라이드에 텍스트 상자, 명령 단추 및 미디어 플레이어와 같은 상호 작용 요소를 제공합니다. Aspose.Slides for Python via .NET은 슬라이드의 컨트롤을 [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/)를 통해 노출합니다. 이 컬렉션을 사용하여 컨트롤을 편집하거나 슬라이드에서 이동하거나 제거할 수 있습니다.

## **ActiveX 컨트롤 및 저장된 속성 목록**

알지 못하는 템플릿을 조사하려면 해당 템플릿을 읽기 전용으로 열고 각 슬라이드의 컨트롤을 반복합니다. 이 예제는 슬라이드 번호, 컨트롤 이름, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), 그리고 [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) 안의 모든 키‑값 쌍을 보고합니다. 프레젠테이션을 읽을 때 컨트롤을 활성화하거나 이벤트·매크로를 호출하거나 값을 변경하거나 파일을 저장하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

`ActiveX.pptm`에서 선택된 출력은 텍스트 상자와 명령 단추를 보여줍니다.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

비어 있는 속성 컬렉션은 `[]`로 표시됩니다. 바이너리 저장소를 사용하는 컨트롤의 경우 `properties`가 `None`을 반환할 수 있으며, 이는 `Properties unavailable`로 표시됩니다. 이름만 필요하면 `None` 여부를 확인한 후 [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/)를 사용하십시오. 보고서는 프레젠테이션에서 사용할 수 있는 속성을 나열합니다. 컨트롤은 런타임에 추가 속성을 지원할 수도 있습니다.

## **ActiveX 컨트롤 수정**

이 예제는 첫 번째 슬라이드에 `TextBox1`이라는 텍스트 상자와 `CommandButton1`이라는 명령 단추가 있는 매크로 사용 가능 프레젠테이션을 전제로 합니다. [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/)을 사용하여 텍스트 상자 값을 변경하고 단추 캡션을 수정합니다. 각 컨트롤에는 활성화 전에 PowerPoint에서 표시할 수 있는 정적 미리보기가 있습니다. 업데이트된 텍스트와 모양을 보여주는 PNG를 각 컨트롤에 제공하십시오. 예제는 이러한 이미지를 [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/)을 통해 할당합니다.

예제는 첫 번째 슬라이드의 모든 컨트롤을 [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/)을 변경하여 100포인트 아래로 이동시킵니다. 편집된 프레젠테이션을 PPTM 형식으로 저장한 후, [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/)을 사용해 해당 슬라이드에서 모든 ActiveX 컨트롤을 제거한 두 번째 사본을 저장합니다.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX 미디어 플레이어 컨트롤 추가**

구성된 Windows Media Player 컨트롤을 재사용하려면 첫 번째 슬라이드에 `WindowsMediaPlayer1`이라는 플레이어가 포함된 템플릿으로 시작합니다. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/)은 전체 슬라이드를 새 프레젠테이션으로 복제합니다. 예제는 플레이어의 `URL`을 [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/)에 설정하고 복제된 슬라이드를 출력 파일의 유일한 슬라이드로 저장합니다. 비디오 파일은 외부에 유지되므로 재생 중에 플레이어가 접근할 수 있는 경로를 선택하십시오.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides가 ActiveX 컨트롤을 실행하지 않고 보존할 수 있나요?**

예. Aspose.Slides는 컨트롤과 그 속성 및 위치를 활성화하지 않고 읽고 저장할 수 있습니다.

**ActiveX 컨트롤과 OLE 객체는 어떻게 다르나요?**

ActiveX 컨트롤은 사용자가 텍스트를 입력하거나 버튼을 클릭하는 등 슬라이드와 직접 상호 작용하도록 합니다. [OLE object](/slides/ko/python-net/manage-ole/)는 슬라이드가 다른 애플리케이션에서 관리하는 콘텐츠(예: Excel 워크시트)를 포함하거나 링크하도록 합니다.

**Aspose.Slides로 프레젠테이션을 저장한 후에도 ActiveX 이벤트가 VBA 매크로를 트리거하나요?**

PPTM과 같은 매크로 사용 가능 형식으로 프레젠테이션을 저장하면 VBA 프로젝트가 유지됩니다. Windows용 PowerPoint에서 보안 설정이 ActiveX 컨트롤과 매크로 모두를 허용하면 기존 이벤트 처리기가 실행될 수 있습니다.