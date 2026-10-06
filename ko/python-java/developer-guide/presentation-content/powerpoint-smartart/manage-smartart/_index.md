---
title: Python을 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
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
description: "명확한 코드 샘플을 사용하여 슬라이드 디자인 및 자동화를 가속화하면서 Python via Java용 Aspose.Slides로 PowerPoint SmartArt를 만들고 편집하는 방법을 배웁니다."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Python via Java를 사용하면 SmartArt를 생성하고, 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하며, 조직도 레이아웃을 구성하고, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드는 하나 이상의 모양을 포함할 수 있습니다. 노드 모양에서 텍스트를 읽으려면 [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes)를 반복하고, [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame)이 반환하는 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)을 읽습니다.

예제는 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 모양으로 SmartArt 개체가 포함된 프레젠테이션이 필요합니다. 사용 가능한 각 텍스트 프레임을 콘솔에 출력합니다.

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

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 만들고, 이를 `BasicProcess` 값으로 변경한 뒤 프레젠테이션을 저장합니다. [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt)에 전달되는 위치와 크기는 포인트 단위로 측정됩니다. 레이아웃을 변경하려면 [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout)를 사용하십시오.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden)은(는) SmartArt 데이터 모델에서 노드가 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 노드를 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고, 추가된 노드의 숨김 상태를 확인합니다. 노드가 숨겨져 있으면 메시지를 출력하고 다이어그램을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) 및 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout)은(는) 하위 노드가 상위 노드 아래에서 어떻게 배치되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/)에 따라 하위 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다. 0부터 시작하는 인덱스 `0`은 첫 번째 최상위 노드를 선택하며, 해당 노드의 하위 노드는 선택된 배열을 사용합니다. 수정된 프레젠테이션은 이후 저장됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리표시자를 포함하는 계층 구조 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오. 이 예제는 이미지 자리표시자가 있는 다이어그램을 저장하지만, 자리표시자에 이미지를 채우지는 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **레거시 다이어그램을 도형 그룹으로 변환**

기존 프레젠테이션을 최신화할 때 PowerPoint 97–2003에서 원래 만든 조직도를 업데이트해야 할 수 있습니다. Aspose.Slides는 이러한 레거시 다이어그램을 [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) 객체로 나타냅니다. 다이어그램을 도형 그룹으로 변환하려면 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape)을 사용하여 개별 시각 요소를 편집할 수 있게 합니다. 자세한 내용은 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)를 참조하십시오.

변환은 원본 다이어그램을 제거하지 않고 도형 컬렉션에 새 그룹을 추가합니다. 변환이 성공하면 [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove)을 사용하여 원본을 제거하여 중복 내용을 방지합니다. 도형을 추가하고 제거하면서 반복이 중단되지 않도록 변환하기 전에 레거시 다이어그램을 목록에 수집하십시오.

다음 예제는 프레젠테이션을 열고 모든 슬라이드를 검색한 뒤 다이어그램을 도형 그룹으로 변환하고 업데이트된 프레젠테이션을 PPTX 형식으로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

저장된 프레젠테이션에는 변환된 레거시 다이어그램 대신 편집 가능한 도형 그룹이 포함되며 원본 다이어그램은 남아 있지 않습니다. PowerPoint에서 PPTX를 열어 각 그룹 내 개별 요소(텍스트, 채우기 또는 위치 등)를 편집할 수 있습니다.

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링 또는 뒤집기를 지원합니까?**

예. 선택한 SmartArt 레이아웃이 뒤집기를 지원하는 경우, [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) 메서드는 다이어그램 방향을 왼쪽‑오른쪽에서 오른쪽‑왼쪽으로, 또는 그 반대로 전환합니다.

**포맷을 유지하면서 SmartArt를 동일 슬라이드 또는 다른 프레젠테이션에 복사하려면 어떻게 해야 합니까?**

[SmartArt 모양 복제](/slides/ko/python-java/shape-manipulations/)을 [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone)와 함께 사용하거나, [전체 슬라이드 복제](/slides/ko/python-java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**SmartArt를 미리 보기나 웹 내보내기를 위해 래스터 이미지로 렌더링하려면 어떻게 해야 합니까?**

[슬라이드 렌더링](/slides/ko/python-java/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 렌더링합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**슬라이드에 여러 개의 SmartArt 개체가 있는 경우 특정 SmartArt 개체를 어떻게 찾을 수 있나요?**

[Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) 또는 [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName)를 사용하여 SmartArt 모양에 고유한 대체 텍스트나 이름을 할당하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes)에서 해당 값을 검색한 다음 일치하는 모양이 [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/)인지 확인합니다.