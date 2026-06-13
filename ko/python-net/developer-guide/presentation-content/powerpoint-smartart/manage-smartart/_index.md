---
title: Python을 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt의 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하는 명확한 코드 샘플을 활용하세요."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Python via .NET을 사용하면 SmartArt를 만들고, 노드에서 텍스트를 읽고, 레이아웃을 변경하고, 숨겨진 노드를 검사하며, 조직도 레이아웃을 구성하고, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 표시된 텍스트를 읽으려면 [SmartArt.all_nodes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/all_nodes/)를 순회한 다음 [SmartArtShape.text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartshape/text_frame/)이 반환하는 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 읽습니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배열되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 값을 사용하여 SmartArt 개체를 생성하고, 이를 `BASIC_PROCESS` 값으로 변경한 뒤 프레젠테이션을 저장합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartnode/is_hidden/)은 SmartArt 데이터 모델에서 노드가 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 해당 노드를 보이는 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **조직도 레이아웃 가져오기 또는 설정**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/)은 자식 노드가 부모 노드 아래에서 어떻게 배치되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 값으로 설정합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 구조 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 값을 사용합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt는 RTL 언어에 대한 미러링 또는 뒤집기를 지원합니까?**

예. 선택한 SmartArt 레이아웃이 뒤집기를 지원하는 경우, [SmartArt.is_reversed](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/is_reversed/) 속성은 다이어그램 방향을 왼쪽에서 오른쪽에서 오른쪽에서 왼쪽으로 전환합니다.

**같은 슬라이드 또는 다른 프레젠테이션에 SmartArt를 복사하면서 서식을 유지하려면 어떻게 해야 하나요?**

SmartArt 모양을 [clone the SmartArt shape](/slides/ko/python-net/shape-manipulations/)와 [ShapeCollection.add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_clone/)을 사용하거나 SmartArt가 포함된 전체 슬라이드를 [clone the whole slide](/slides/ko/python-net/clone-slides/) 할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**SmartArt를 미리 보기나 웹 내보내기를 위해 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

슬라이드 전체를 PNG 또는 JPEG로 [Render the slide](/slides/ko/python-net/convert-powerpoint-to-png/)하거나 프레젠테이션 전체를 변환할 수 있습니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개의 SmartArt 객체가 있을 때 특정 객체를 슬라이드에서 어떻게 찾을 수 있나요?**

SmartArt 모양에 고유한 [Shape.alternative_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/alternative_text/) 또는 [Shape.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/name/) 값을 설정하고, 해당 값을 [Slide.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/shapes/)에서 검색한 다음, 일치하는 모양이 [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/)인지 확인합니다.