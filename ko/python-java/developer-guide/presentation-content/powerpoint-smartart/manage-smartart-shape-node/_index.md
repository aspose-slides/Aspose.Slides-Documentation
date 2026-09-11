---
title: 프레젠테이션에서 Python을 사용하여 SmartArt 도형 노드 관리
linktitle: SmartArt 도형 노드
type: docs
weight: 30
url: /ko/python-java/manage-smartart-shape-node/
keywords:
- SmartArt 노드
- 자식 노드
- 노드 추가
- 노드 위치
- 노드 접근
- 노드 제거
- 사용자 정의 위치
- 보조 노드
- 채우기 형식
- 노드 렌더링
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PPT 및 PPTX에서 SmartArt 도형 노드를 관리합니다. 명확한 코드 샘플과 팁을 제공하여 프레젠테이션을 효율화하세요."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드를 통해 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새 노드와 자식 노드를 추가하고, 특정 위치에 자식 노드를 삽입하고, 기존 노드에 접근하며 텍스트, 수준 및 위치를 읽을 수 있습니다.

이 문서는 SmartArt 도형 노드를 관리하는 방법을 설명합니다. 노드 제거, 인덱스 또는 위치를 기준으로 자식 노드 작업, 보조 노드를 일반 노드로 변경, SmartArt 노드 도형의 위치·크기·회전 조정, 노드 채우기 형식 설정, SmartArt 자식 노드에 대한 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for Python via Java는 SmartArt 도형을 관리하는 API를 제공합니다. 다음 예제는 SmartArt 도형에 노드와 자식 노드를 추가합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. SmartArt 도형의 [node collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getAllNodes)에 [새 노드 추가](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#addNode)하고 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)을 통해 텍스트를 설정합니다.
1. 새 노드에 [자식 노드](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#getChildNodes)를 [추가](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#addNode)하고 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)을 통해 텍스트를 설정합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **특정 위치에 SmartArt 노드 추가**
다음 예제는 SmartArt 노드에 특정 위치에 자식 노드를 추가합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 슬라이드에 [StackedList](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/#StackedList) 레이아웃을 사용한 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 도형을 추가합니다.
1. 추가된 SmartArt 도형의 첫 번째 노드에 접근합니다.
1. [addNodeByPosition](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition)을 사용해 선택된 노드에 위치 2의 자식 노드를 추가하고 텍스트를 설정합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 노드 접근**
다음 예제는 SmartArt 도형의 노드에 접근합니다. [getLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getLayout)으로 반환된 레이아웃은 읽기 전용이며 SmartArt 도형이 추가될 때 설정됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. SmartArt 도형의 모든 [nodes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getAllNodes)를 반복합니다.
1. 각 SmartArt 노드의 위치, 수준 및 텍스트를 읽고 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt 자식 노드 접근**
다음 예제는 SmartArt 도형의 각 노드에 대한 자식 노드에 접근합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. SmartArt 도형의 모든 [nodes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getAllNodes)를 반복합니다.
1. 각 노드에 대해 해당 [child nodes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#getChildNodes)를 반복합니다.
1. [child node](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#getChildNodes)의 위치, 수준 및 텍스트를 읽고 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **특정 위치에 SmartArt 자식 노드 접근**
다음 예제는 부모 노드 컬렉션에서 특정 인덱스에 있는 자식 노드에 접근합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. [StackedList](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/#StackedList) 레이아웃을 사용한 SmartArt 도형을 추가합니다.
1. 추가된 SmartArt 도형에 접근합니다.
1. SmartArt 도형에서 인덱스 0의 노드에 접근합니다.
1. [get_Item](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#get_Item)을 사용해 인덱스 1의 자식 노드에 접근합니다.
1. [child node](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#getChildNodes)의 위치, 수준 및 텍스트를 읽고 표시합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt 노드 제거**
다음 예제는 SmartArt 도형에서 노드를 제거합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 도형에 최소 하나의 노드가 포함되어 있는지 확인합니다.
1. 삭제할 SmartArt 노드를 선택합니다.
1. [removeNode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#removeNode)를 사용해 선택한 노드를 제거합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **특정 위치에서 SmartArt 노드 제거**
다음 예제는 SmartArt 노드 컬렉션에서 특정 인덱스에 있는 자식 노드를 제거합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. 존재한다면 인덱스 0의 SmartArt 노드에 접근합니다.
1. 선택한 SmartArt 노드에 최소 두 개의 자식 노드가 있는지 확인합니다.
1. [removeNode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnodecollection/#removeNode)를 사용해 인덱스 1의 자식 노드를 제거합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 객체에서 자식 노드의 사용자 정의 위치 설정**
Aspose.Slides for Python via Java는 [SmartArtShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartshape/)의 위치를 [setX](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setX)와 [setY](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setY)로 설정하는 것을 지원합니다. 다음 예제는 SmartArt 노드 도형에 사용자 정의 위치, 크기 및 회전을 설정합니다. 새 노드를 추가하면 모든 노드의 위치와 크기가 다시 계산됩니다. 사용자 정의 위치 지정으로 필요에 따라 노드를 배치할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **보조 노드 확인**
{{% alert color="info" title="참고" %}} 

이 섹션에서는 Aspose.Slides for Python via Java를 사용해 프레젠테이션 슬라이드에 프로그래밍 방식으로 추가된 SmartArt 도형을 살펴봅니다.

{{% /alert %}} 

다음 원본 SmartArt 도형이 예제에 사용됩니다.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**그림: 슬라이드에 있는 원본 SmartArt 도형**|

다음 예제는 SmartArt 노드 컬렉션에서 보조 노드를 식별하고 이를 일반 노드로 변경합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. 첫 번째 슬라이드에 있는 모든 도형을 반복합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 인스턴스인지 확인합니다.
1. SmartArt 도형의 모든 노드를 반복하고 [Assistant Nodes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#isAssistant)인지 확인합니다.
1. 각 보조 노드를 일반 노드로 변경합니다.
1. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**그림: 슬라이드에 있는 SmartArt 도형에서 보조 노드가 일반 노드로 변경됨**|

## **노드 채우기 형식 설정**
Aspose.Slides for Python via Java를 사용하면 사용자 지정 SmartArt 도형을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서는 SmartArt 도형을 만들고 접근하며 채우기 형식을 설정하는 방법을 설명합니다.

아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드를 가져옵니다.
1. [ClosedChevronProcess](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) 레이아웃을 사용한 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/) 도형을 추가합니다.
1. SmartArt 도형 노드에 대한 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getFillFormat)을 설정합니다.
1. 변경된 프레젠테이션을 PPTX 파일로 작성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 자식 노드의 썸네일 생성**
SmartArt 자식 노드의 썸네일을 생성하려면 다음 단계를 수행하세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. [SmartArt 도형 추가](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addSmartArt)를 수행합니다.
1. 인덱스로 노드를 가져옵니다.
1. 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**SmartArt 애니메이션이 지원되나요?**

예. SmartArt는 일반 도형으로 취급되므로 [표준 애니메이션](/slides/ko/python-java/shape-animation/) (입장, 퇴장, 강조, 움직임 경로)를 적용하고 타이밍을 조정할 수 있습니다. 필요에 따라 SmartArt 노드 내부의 도형에도 애니메이션을 적용할 수 있습니다.

**슬라이드에서 특정 SmartArt를 내부 ID 없이 신뢰성 있게 찾으려면 어떻게 해야 하나요?**

[alternative text](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText)를 사용해 지정하고 검색하세요. SmartArt에 고유한 대체 텍스트를 설정하면 내부 식별자에 의존하지 않고 프로그래밍 방식으로 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. Aspose.Slides는 [PDF 내보내기](/slides/ko/python-java/convert-powerpoint-to-pdf/) 중 SmartArt를 높은 시각적 정확도로 렌더링하여 레이아웃, 색상 및 효과를 보존합니다.

**전체 SmartArt의 이미지를 추출할 수 있나요(미리보기나 보고서용)?**

예. SmartArt 도형을 [래스터 형식](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getImage)이나 [SVG](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#writeAsSvgToBytes)로 렌더링할 수 있어 썸네일, 보고서 또는 웹 사용에 적합한 확장 가능한 출력물을 얻을 수 있습니다.