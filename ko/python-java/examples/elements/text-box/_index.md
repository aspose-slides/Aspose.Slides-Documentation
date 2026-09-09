---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/python-java/examples/elements/text-box/
keywords:
- 코드 예제
- 텍스트 상자
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 텍스트 상자를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 추가, 서식 지정, 찾기 및 제거합니다."
---
**Aspose.Slides for Python via Java**에서 텍스트 상자는 텍스트를 포함하는 자동 도형입니다. 거의 모든 도형에 텍스트를 넣을 수 있지만, 일반적인 텍스트 상자는 채우기나 테두리가 없으며 텍스트만 표시합니다.

이 가이드는 텍스트 상자를 프로그래밍 방식으로 추가, 접근 및 제거하는 방법을 설명합니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

## **텍스트 상자 추가**

사각형을 만들고, 채우기와 테두리를 제거한 뒤 서식이 적용된 텍스트를 할당합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 사각형 도형을 생성합니다.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # 채우기와 테두리를 제거하여 텍스트만 표시합니다.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # 기본 텍스트 서식을 설정합니다.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **내용으로 텍스트 상자 접근**

샘플 텍스트 상자를 추가한 다음, 텍스트에 "Slide" 키워드가 포함된 도형을 찾습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # 일치하는 텍스트 상자를 사용합니다.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **내용으로 텍스트 상자 제거**

첫 번째 슬라이드에서 특정 키워드를 포함하는 텍스트 상자를 찾아 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
반복 중에 도형 컬렉션이 변경되는 것을 방지하기 위해, 제거하기 전에 일치하는 도형을 별도의 리스트에 수집하십시오.
{{% /alert %}}