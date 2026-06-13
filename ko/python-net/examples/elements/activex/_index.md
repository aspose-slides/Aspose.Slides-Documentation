---
title: ActiveX
type: docs
weight: 200
url: /ko/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 추가
- ActiveX 액세스
- ActiveX 제거
- ActiveX 속성
- 코드 예제
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 ActiveX 컨트롤을 찾고, 수정하고, 제거하는 방법을 배우고, PowerPoint 프레젠테이션의 속성 업데이트를 포함합니다."
---
프레젠테이션에서 **Aspose.Slides for Python via .NET**을 사용하여 ActiveX 컨트롤을 추가, 액세스, 제거 및 구성하는 방법을 보여줍니다.

## **ActiveX 컨트롤 추가**

새 ActiveX 컨트롤을 삽입합니다.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 새 ActiveX 컨트롤 (TextBox)을 추가합니다.
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX 컨트롤 액세스**

슬라이드에 있는 첫 번째 ActiveX 컨트롤의 정보를 읽어옵니다.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 ActiveX 컨트롤에 액세스합니다.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # 컨트롤 이름을 출력합니다.
            print(f"Control Name: {control.name}")
```

## **ActiveX 컨트롤 제거**

슬라이드에서 기존 ActiveX 컨트롤을 삭제합니다.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # 첫 번째 ActiveX 컨트롤을 제거합니다.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX 속성 설정**

여러 ActiveX 속성을 구성합니다.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Control 컬렉션에 최소 하나의 Control이 포함되어 있다고 가정합니다.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```