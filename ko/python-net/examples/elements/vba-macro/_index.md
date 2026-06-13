---
title: Vba 매크로
type: docs
weight: 150
url: /ko/python-net/examples/elements/vba-macro/
keywords:
- VBA 매크로
- VBA 매크로 추가
- VBA 매크로 액세스
- VBA 매크로 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 VBA 매크로 작업: 프로젝트와 모듈을 추가하거나 편집하고, 매크로에 서명하거나 제거하며, 프레젠테이션을 PPT, PPTX 및 ODP 형식으로 저장합니다."
---
**Aspose.Slides for Python via .NET**을 사용하여 VBA 매크로를 추가, 액세스 및 제거하는 방법을 보여줍니다.

## **VBA 매크로 추가**

VBA 프로젝트와 간단한 매크로 모듈이 포함된 프레젠테이션을 생성합니다.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # VBA 프로젝트를 초기화합니다.
        presentation.vba_project = slides.vba.VbaProject()

        # "Module"이라는 빈 모듈을 추가합니다.
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA 매크로 액세스**

VBA 프로젝트에서 첫 번째 모듈을 가져옵니다.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA 매크로 제거**

VBA 프로젝트에서 모듈을 삭제합니다.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # 프레젠테이션에 VBA 프로젝트와 최소 하나의 모듈이 포함되어 있다고 가정합니다.
        module = presentation.vba_project.modules[0]

        # 프로젝트에서 모듈을 제거합니다.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```