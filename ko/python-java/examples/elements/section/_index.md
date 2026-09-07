---
title: 섹션
type: docs
weight: 90
url: /ko/python-java/examples/elements/section/
keywords:
- 코드 예제
- 섹션
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 프레젠테이션 섹션을 관리합니다: 섹션을 추가, 접근, 제거 및 이름을 바꾸는 Python 코드 예제와 함께."
---
프레젠테이션 섹션을 관리하는 예제—프로그래밍 방식으로 추가, 접근, 제거 및 이름 바꾸기를 **Aspose.Slides for Python via Java**를 사용하여 수행합니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후에 API를 가져옵니다.

## **섹션 추가**

특정 슬라이드에서 시작하는 섹션을 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 섹션의 시작을 표시하는 슬라이드를 지정합니다.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **섹션 접근**

프레젠테이션에서 섹션 정보를 읽어옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # 인덱스로 섹션에 접근합니다.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **섹션 제거**

이전에 추가된 섹션을 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # 첫 번째 섹션을 제거합니다.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **섹션 이름 바꾸기**

기존 섹션의 이름을 변경합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```