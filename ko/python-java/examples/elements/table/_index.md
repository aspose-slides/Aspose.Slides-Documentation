---
title: 테이블
type: docs
weight: 120
url: /ko/python-java/examples/elements/table/
keywords:
- 코드 예제
- 테이블
- 테이블 추가
- 테이블 접근
- 테이블 제거
- 셀 병합
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 테이블을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 테이블을 추가, 접근, 제거 및 셀 병합을 수행합니다."
---
**Aspose.Slides for Python via Java**를 사용하여 테이블을 추가하고, 접근하고, 제거하고, 셀을 병합하는 예제입니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 임포트하고, JVM이 실행된 후 API를 임포트합니다.

## **테이블 추가**

두 행과 두 열을 가진 간단한 테이블을 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **테이블에 접근**

슬라이드에서 첫 번째 테이블 쉐이프를 가져옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # 슬라이드에서 첫 번째 테이블에 접근합니다.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **테이블 제거**

슬라이드에서 테이블을 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **테이블 셀 병합**

테이블의 인접한 셀을 하나의 셀로 병합합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # 셀 병합합니다.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```