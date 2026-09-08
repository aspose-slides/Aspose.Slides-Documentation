---
title: Python에서 프레젠테이션의 Flash 개체 추출
linktitle: Flash
type: docs
weight: 10
url: /ko/python-java/flash/
keywords:
- Flash 추출
- Flash 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 Flash 개체를 추출하는 방법을 배우고, 완전한 코드 샘플과 모범 사례를 확인하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션에서 Flash 개체를 추출하는 방법을 설명합니다. 슬라이드의 컨트롤 컬렉션에서 이름으로 Flash 컨트롤을 찾아내고 포함된 SWF 개체 데이터를 처리하는 방법을 보여줍니다.

## **프레젠테이션에서 Flash 개체 추출**

Java를 통해 Python용 Aspose.Slides는 프레젠테이션에서 Flash 개체를 추출할 수 있는 기능을 제공합니다. 이름으로 Flash 컨트롤에 접근하여 프레젠테이션에서 추출할 수 있으며, 저장된 SWF 개체 데이터도 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**Flash 콘텐츠를 추출할 때 지원되는 프레젠테이션 형식은 무엇입니까?**

[Aspose.Slides는](/slides/ko/python-java/supported-file-formats/) PPT 및 PPTX와 같은 주요 PowerPoint 형식을 지원합니다. 이 형식들을 로드하고 컨트롤에 접근할 수 있으며, Flash 관련 ActiveX 요소도 포함됩니다.

**Flash가 포함된 프레젠테이션을 HTML5로 변환하면서 Flash 상호작용을 유지할 수 있나요?**

아니요. Aspose.Slides는 SWF 콘텐츠를 실행하거나 해당 상호작용을 변환하지 않습니다. [HTML](/slides/ko/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/ko/python-java/export-to-html5/) 로의 내보내기는 지원되지만, 지원 종료로 인해 최신 브라우저에서는 Flash가 재생되지 않습니다. 권장 방법은 내보내기 전에 Flash를 비디오나 HTML5 애니메이션과 같은 대체 방식으로 교체하는 것입니다.

**보안 측면에서, Aspose.Slides가 프레젠테이션을 읽는 동안 SWF 파일을 실행하나요?**

아니요. Aspose.Slides는 Flash를 파일에 포함된 바이너리 데이터로 취급하며, 처리 중에 SWF 콘텐츠를 실행하지 않습니다.

**Flash와 함께 OLE를 통해 포함된 다른 파일이 있는 프레젠테이션은 어떻게 처리해야 하나요?**

Aspose.Slides는 [OLE 삽입 개체 추출](/slides/ko/python-java/manage-ole/)을 지원하므로, Flash 컨트롤과 다른 OLE 삽입 문서를 함께 한 번에 처리하여 모든 관련 삽입 콘텐츠를 처리할 수 있습니다.