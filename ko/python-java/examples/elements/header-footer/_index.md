---
title: 헤더 및 푸터
type: docs
weight: 220
url: /ko/python-java/examples/elements/header-footer/
keywords:
- 코드 예제
- 헤더
- 푸터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 슬라이드 헤더와 푸터를 제어합니다: PPT, PPTX 및 ODP 프레젠테이션에 날짜, 슬라이드 번호 및 사용자 지정 텍스트를 추가합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 바닥글을 추가하고 날짜 및 시간 자리표시자를 업데이트하는 방법을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후에 API를 가져옵니다.

## **바닥글 추가**

슬라이드의 바닥글 영역에 텍스트를 추가하고 표시되도록 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **날짜 및 시간 업데이트**

슬라이드의 날짜 및 시간 자리표시자를 수정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```