---
title: Python을 사용한 PowerPoint 프레젠테이션의 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 명확한 코드 샘플로 PowerPoint SmartArt를 만들고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하세요."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Python via Java를 사용하면 SmartArt를 만들고, 노드에서 텍스트를 읽고, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 표시되는 텍스트를 읽으려면 [SmartArt.getAllNodes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#getAllNodes)를 순회한 다음, [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartshape/#getTextFrame)에서 반환된 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)을 읽습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배열되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 만든 뒤, 이를 `BasicProcess` 값으로 변경하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 노드가 숨겨져 있는지 확인하기**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#isHidden)는 SmartArt 데이터 모델에서 노드가 숨겨져 있는지를 나타냅니다. 선택한 레이아웃이 노드를 눈에 보이는 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout)와 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout)는 자식 노드가 상위 노드 아래에서 어떻게 배열되는지를 정의합니다. 예를 들어, 선택된 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 값을 사용합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링이나 뒤집기를 지원합니까?**

예. 선택한 SmartArt 레이아웃이 뒤집기를 지원하는 경우, [SmartArt.setReversed](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/#setReversed) 메서드는 다이어그램 방향을 왼쪽‑오른쪽에서 오른쪽‑왼쪽으로, 또는 그 반대로 전환합니다.

**SmartArt를 같은 슬라이드 또는 다른 프레젠테이션에 복사하면서 서식을 유지하려면 어떻게 해야 하나요?**

SmartArt가 포함된 슬라이드에 대해 [SmartArt 모양 복제](/slides/ko/python-java/shape-manipulations/)를 [ShapeCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addClone)와 함께 사용하거나, 해당 슬라이드 전체를 [전체 슬라이드 복제](/slides/ko/python-java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 보존합니다.

**프리뷰나 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

[슬라이드 렌더링](/slides/ko/python-java/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 변환합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**슬라이드에 여러 개가 있을 경우 특정 SmartArt 개체를 어떻게 찾을 수 있나요?**

SmartArt 모양에 고유한 [Shape.getAlternativeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getAlternativeText) 또는 [Shape.getName](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getName) 값을 설정하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getShapes)에서 해당 값을 검색한 다음, 일치하는 모양이 [SmartArt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartart/)인지 확인합니다.