---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/python-java/examples/elements/hyperlink/
keywords:
- 코드 예제
- 하이퍼링크
- 하이퍼링크 추가
- 하이퍼링크 액세스
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 하이퍼링크를 추가하고 관리합니다: PPT, PPTX 및 ODP 프레젠테이션에서 링크를 생성, 액세스, 제거 및 업데이트합니다."
---
이 문서에서는 **Aspose.Slides for Python via Java**를 사용하여 도형에 하이퍼링크를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 있는 사각형 도형을 만듭니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **하이퍼링크 액세스**

도형 텍스트 부분에서 하이퍼링크 정보를 읽습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상 URL을 변경합니다. 이미 하이퍼링크가 포함된 텍스트를 수정하려면 [HyperlinkManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/)를 사용합니다. 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # 기존 텍스트 안의 하이퍼링크를 변경할 때는
    # HyperlinkManager를 사용해야 하며 직접 속성을 설정하지 않아야 합니다.
    # 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```