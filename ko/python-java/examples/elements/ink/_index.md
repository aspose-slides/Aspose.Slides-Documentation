---
title: 잉크
type: docs
weight: 180
url: /ko/python-java/examples/elements/ink/
keywords:
- 코드 예제
- 잉크
- 잉크 접근
- 잉크 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java 프레젠테이션에서 잉크 도형에 접근하고 제거합니다. PPT, PPTX 및 ODP 파일을 포함합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 기존 잉크 도형에 접근하고 이를 제거하는 예제를 제공합니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치하십시오. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

{{% alert color="info" title="참고" %}}
잉크 도형은 특수 장치에서 입력된 사용자 데이터를 나타냅니다. Aspose.Slides는 새로운 잉크 스트로크를 프로그래밍 방식으로 생성할 수 없지만, 기존 잉크를 읽고 수정할 수 있습니다.
{{% /alert %}}

## **잉크 접근**

슬라이드의 첫 번째 잉크 도형에서 태그를 읽습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # 필요에 따라 tag_name을 사용합니다.
finally:
    presentation.dispose()
```

## **잉크 제거**

슬라이드에 잉크 도형이 존재하면 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```