---
title: Python을 사용한 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/python-net/manage-smartart/
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
description: "Aspose.Slides for Python via .NET를 사용하여 명확한 코드 샘플로 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우고 슬라이드 디자인 및 자동화를 가속화하십시오."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Python via .NET를 사용하면 SmartArt를 만들고, 노드에서 텍스트를 읽고, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 노드 모양에서 텍스트를 읽으려면 [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/)을 반복한 다음 [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/)에서 반환된 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)을 읽습니다.

예제는 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 모양으로 SmartArt 개체가 있는 프레젠테이션이 필요합니다. 각 사용 가능한 텍스트 프레임을 콘솔에 출력합니다.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배열되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 값을 사용하여 SmartArt 개체를 만든 다음 `BASIC_PROCESS` 값으로 변경하고 프레젠테이션을 저장합니다. [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/)에 전달된 위치와 크기는 포인트 단위입니다. 레이아웃을 변경하려면 [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/)을 설정합니다.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/)은 노드가 SmartArt 데이터 모델에서 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 해당 노드를 보이게 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 값을 사용하는 SmartArt 개체에 노드를 추가하고 추가된 노드의 숨김 상태를 확인합니다. 노드가 숨겨진 경우 메시지를 출력하고 다이어그램을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/)은 상위 노드 아래에 하위 노드가 어떻게 배열되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/)에 따라 하위 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리게 설정할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 값으로 설정합니다. 0 기반 인덱스 `0`은 첫 번째 최상위 노드를 선택하며, 해당 하위 노드들은 선택된 배열을 사용합니다. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 값을 사용하십시오. 이 예제는 이미지 자리 표시자가 있는 다이어그램을 저장하지만 자리 표시자에 이미지를 채우지는 않습니다.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **레거시 다이어그램을 그룹 형태로 변환하기**

기존 프레젠테이션을 현대화할 때 PowerPoint 97–2003에서 처음 만든 조직도를 업데이트해야 할 수 있습니다. Aspose.Slides는 이러한 레거시 다이어그램을 [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) 개체로 나타냅니다. 다이어그램을 개별 시각 요소를 편집할 수 있는 그룹 형태로 변환하려면 [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/)를 사용하십시오. 자세한 내용은 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)를 참조하십시오.

변환은 원본 다이어그램을 제거하지 않고 형태 컬렉션에 새 그룹을 추가합니다. 변환이 성공하면 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/)를 사용해 원본을 제거하여 중복 콘텐츠를 방지합니다. 형태를 추가하고 제거하는 동안 반복이 중단되지 않도록 변환하기 전에 레거시 다이어그램을 리스트에 수집하십시오.

다음 예제는 프레젠테이션을 열고, 모든 슬라이드를 검색하고, 다이어그램을 형태 그룹으로 변환한 뒤, 업데이트된 프레젠테이션을 PPTX로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

저장된 프레젠테이션은 변환된 레거시 다이어그램 대신 편집 가능한 형태 그룹을 포함하며, 원본 다이어그램은 남아 있지 않습니다. PPTX를 PowerPoint에서 열어 각 그룹 내 개별 요소(텍스트, 채우기, 위치 등)를 편집할 수 있습니다.

## **FAQ**

**SmartArt가 RTL 언어에 대한 미러링 또는 반전 기능을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 반전을 지원하는 경우, [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) 속성이 다이어그램 방향을 왼쪽‑오른쪽에서 오른쪽‑왼쪽으로, 또는 그 반대로 전환합니다.

**형식이 유지된 상태로 같은 슬라이드 또는 다른 프레젠테이션에 SmartArt를 복사하려면 어떻게 해야 합니까?**

[SmartArt 모양 복제](/slides/ko/python-net/shape-manipulations/)를 [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)으로 하거나, [전체 슬라이드 복제](/slides/ko/python-net/clone-slides/)를 사용해 SmartArt가 포함된 슬라이드를 복제할 수 있습니다. 두 방법 모두 크기, 위치 및 형식을 유지합니다.

**프리뷰 또는 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 해야 합니까?**

[슬라이드 렌더링](/slides/ko/python-net/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 렌더링하십시오. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개의 SmartArt 개체가 있는 경우 특정 SmartArt 개체를 슬라이드에서 어떻게 찾을 수 있습니까?**

SmartArt 모양에 고유한 [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) 또는 [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) 값을 설정하고, 해당 값을 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)에서 검색한 다음, 일치하는 형태가 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)인지 확인합니다.