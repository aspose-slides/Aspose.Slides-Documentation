---
title: Python을 사용하여 프레젠테이션에서 SmartArt Shape 노드 관리
linktitle: SmartArt Shape 노드
type: docs
weight: 30
url: /ko/python-net/manage-smartart-shape-node/
keywords:
- SmartArt 노드
- 하위 노드
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
description: "Aspose.Slides for Python via .NET를 사용하여 PPT, PPTX 및 ODP에서 SmartArt shape 노드를 관리합니다. 프레젠테이션을 효율화할 수 있는 명확한 코드 샘플과 팁을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드로 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새 노드 및 하위 노드 추가, 특정 위치에 하위 노드 삽입, 기존 노드에 접근, 그리고 텍스트, 레벨 및 위치를 읽을 수 있습니다.

이 문서에서는 SmartArt 모양 노드를 관리하는 방법을 설명합니다. 노드 삭제, 인덱스 또는 위치에 따라 하위 노드 작업, 보조 노드를 일반 노드로 전환, SmartArt 노드 모양의 위치, 크기 및 회전 조정, 노드 채우기 형식 설정, 그리고 SmartArt 하위 노드의 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for Python via .NET는 SmartArt 모양을 가장 쉽게 관리할 수 있는 가장 단순한 API를 제공합니다. 다음 샘플 코드는 SmartArt 모양 안에 노드와 하위 노드를 추가하는 데 도움이 됩니다.

- [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArt로 형변환합니다.
- SmartArt 모양의 NodeCollection에 새 Node를 추가하고 TextFrame에 텍스트를 설정합니다.
- 이제 새로 추가된 SmartArt Node에 하위 Node를 추가하고 TextFrame에 텍스트를 설정합니다.
- 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:

        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # 새로운 SmartArt 노드 추가
            node1 = shape.all_nodes.add_node()
            # 텍스트 추가
            node1.text_frame.text = "Test"

            # 상위 노드에 새로운 하위 노드 추가. 컬렉션 끝에 추가됩니다
            new_node = node1.child_nodes.add_node()

            # 텍스트 추가
            new_node.text_frame.text = "New Node Added"

    # 프레젠테이션 저장
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **특정 위치에 SmartArt 노드 추가**
다음 샘플 코드에서는 SmartArt 모양의 해당 노드에 속하는 하위 노드를 특정 위치에 추가하는 방법을 설명합니다.

- `Presentation` 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 접근한 슬라이드에 StackedList 유형의 SmartArt 모양을 추가합니다.
- 추가된 SmartArt 모양에서 첫 번째 노드에 접근합니다.
- 이제 선택된 노드에 대해 위치 2에 하위 노드를 추가하고 텍스트를 설정합니다.
- 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 프레젠테이션 인스턴스 생성
with slides.Presentation() as pres:
    # 프레젠테이션 슬라이드에 접근
    slide = pres.slides[0]

    # Smart Art IShape 추가
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # 인덱스 0에 있는 SmartArt 노드 접근
    node = smart.all_nodes[0]

    # 상위 노드에서 위치 2에 새로운 하위 노드 추가
    chNode = node.child_nodes.add_node_by_position(2)

    # 텍스트 추가
    chNode.text_frame.text = "Sample text Added"

    # 프레젠테이션 저장
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 노드 접근**
다음 샘플 코드는 SmartArt 모양 내부의 노드에 접근하는 데 도움이 됩니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 모양을 추가할 때만 설정되므로 변경할 수 없습니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArt로 형변환합니다.
- SmartArt 모양 내부의 모든 Node를 순회합니다.
- SmartArt Node의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:
        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # SmartArt 내부의 모든 노드를 순회합니다
            for i in range(len(shape.all_nodes)):
                # 인덱스 i에 있는 SmartArt 노드 접근
                node = shape.all_nodes[i]

                # SmartArt 노드 매개변수 출력
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **SmartArt 하위 노드 접근**
다음 샘플 코드는 SmartArt 모양의 각 노드에 속하는 하위 노드에 접근하는 데 도움이 됩니다.

- PresentationEx 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArtEx로 형변환합니다.
- SmartArt 모양 내부의 모든 Node를 순회합니다.
- 선택된 각 SmartArt 모양 Node에 대해 해당 노드 내부의 모든 하위 Node를 순회합니다.
- 하위 Node의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:
        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # SmartArt 내부의 모든 노드를 순회합니다
            for node0 in shape.all_nodes:
                # 하위 노드를 순회합니다
                for j in range(len(node0.child_nodes)):
                    # SmartArt 노드의 하위 노드에 접근합니다
                    node = node0.child_nodes[j]

                    # SmartArt 하위 노드 매개변수를 출력합니다
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **특정 위치에 SmartArt 하위 노드 접근**
이 예제에서는 SmartArt 모양의 각 노드에 속하는 하위 노드를 특정 위치에서 접근하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- StackedList 유형의 SmartArt 모양을 추가합니다.
- 추가된 SmartArt 모양에 접근합니다.
- 접근된 SmartArt 모양에서 인덱스 0에 해당하는 노드에 접근합니다.
- 이제 GetNodeByPosition() 메서드를 사용하여 접근된 SmartArt 노드의 위치 1에 있는 하위 노드에 접근합니다.
- 하위 노드의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 프레젠테이션 인스턴스 생성
with slides.Presentation() as pres:
    # 첫 번째 슬라이드에 접근
    slide = pres.slides[0]
    # 첫 번째 슬라이드에 SmartArt 모양 추가
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # 인덱스 0에 있는 SmartArt 노드에 접근
    node = smart.all_nodes[0]
    # 상위 노드에서 위치 1에 있는 하위 노드에 접근
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt 하위 노드 매개변수 출력
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```

## **SmartArt 노드 제거**
이 예제에서는 SmartArt 모양 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArt로 형변환합니다.
- SmartArt에 0개 이상의 노드가 있는지 확인합니다.
- 삭제할 SmartArt 노드를 선택합니다.
- 이제 RemoveNode() 메서드를 사용하여 선택된 노드를 제거하고 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:
        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # 모양을 SmartArtEx로 형변환합니다
            if len(shape.all_nodes) > 0:
                # 인덱스 0에 있는 SmartArt 노드에 접근합니다
                node = shape.all_nodes[0]

                # 선택된 노드 제거
                shape.all_nodes.remove_node(node)

    # 프레젠테이션 저장
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **특정 위치에 SmartArt 노드 제거**
이 예제에서는 특정 위치에서 SmartArt 모양 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArt로 형변환합니다.
- 인덱스 0에 있는 SmartArt 모양 노드를 선택합니다.
- 이제 선택된 SmartArt 노드에 2개 이상의 하위 노드가 있는지 확인합니다.
- 이제 RemoveNodeByPosition() 메서드를 사용하여 위치 1에 있는 노드를 제거합니다.
- 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:
        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # 모양을 SmartArt로 형변환합니다
            if len(shape.all_nodes) > 0:
                # 인덱스 0에 있는 SmartArt 노드에 접근합니다
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # 위치 1에 있는 하위 노드 제거
                    node.child_nodes.remove_node(1)

    # 프레젠테이션 저장
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 하위 노드에 대한 사용자 정의 위치 설정**
이제 Aspose.Slides for Python via .NET는 SmartArtShape의 X 및 Y 속성을 설정하는 것을 지원합니다. 아래 코드 스니펫은 사용자 정의 SmartArtShape 위치, 크기 및 회전을 설정하는 방법을 보여주며, 새 노드를 추가하면 모든 노드의 위치와 크기가 다시 계산된다는 점에 유의하십시오.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 원하는 프레젠테이션을 로드합니다
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt 모양을 새 위치로 이동합니다
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# SmartArt 모양의 너비를 변경합니다
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# SmartArt 모양의 높이를 변경합니다
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# SmartArt 모양의 회전을 변경합니다
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **보조 노드 확인**
다음 샘플 코드에서는 SmartArt 노드 컬렉션에서 보조 노드를 식별하고 이를 변경하는 방법을 조사합니다.

- PresentationEx 클래스의 인스턴스를 생성하고 SmartArt 모양이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용하여 두 번째 슬라이드의 참조를 가져옵니다.
- 첫 번째 슬라이드 내의 모든 모양을 순회합니다.
- 모양이 SmartArt 유형인지 확인하고, SmartArt인 경우 선택된 모양을 SmartArtEx로 형변환합니다.
- SmartArt 모양 내부의 모든 노드를 순회하고 보조 노드인지 확인합니다.
- 보조 노드의 상태를 일반 노드로 변경합니다.
- 프레젠테이션을 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# 프레젠테이션 인스턴스 생성
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # 첫 번째 슬라이드 내 모든 모양을 순회합니다
    for shape in pres.slides[0].shapes:
        # 모양이 SmartArt 유형인지 확인합니다
        if type(shape) is art.SmartArt:
            # SmartArt 모양의 모든 노드를 순회합니다
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # 노드가 보조 노드인지 확인합니다
                if node.is_assistant:
                    # 보조 노드를 false로 설정하고 일반 노드로 전환합니다
                    node.is_assistant = False
    # 프레젠테이션 저장
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **노드 채우기 형식 설정**
Aspose.Slides for Python via .NET를 사용하면 사용자 정의 SmartArt 모양을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서에서는 SmartArt 모양을 생성하고 접근하며 Aspose.Slides for Python via .NET를 사용하여 채우기 형식을 설정하는 방법을 설명합니다.

다음 단계에 따라 진행하십시오:

- `Presentation` 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- LayoutType을 설정하여 SmartArt 모양을 추가합니다.
- SmartArt 모양 노드의 FillFormat을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # 슬라이드에 접근
    slide = presentation.slides[0]

    # SmartArt 모양과 노드 추가
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # 노드 채우기 색상 설정
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # 프레젠테이션 저장
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt 하위 노드 썸네일 생성**
개발자는 아래 단계에 따라 SmartArt 하위 노드의 썸네일을 생성할 수 있습니다:

1. PPTX 파일을 나타내는 `Presentation` 클래스를 인스턴스화합니다.
2. SmartArt를 추가합니다.
3. 인덱스를 사용하여 노드의 참조를 가져옵니다.
4. 썸네일 이미지를 가져옵니다.
5. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

아래 예제는 SmartArt 하위 노드의 썸네일을 생성합니다.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다 
with slides.Presentation() as presentation: 
    # SmartArt 추가 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # 인덱스를 사용하여 노드에 대한 참조를 가져옵니다  
    node = smart.nodes[1]

    # 썸네일 가져오기
    with node.shapes[0].get_image() as bmp:
        # 썸네일 저장
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**SmartArt 애니메이션이 지원됩니까?**

예. SmartArt는 일반 도형으로 취급되므로 [표준 애니메이션 적용](/slides/ko/python-net/shape-animation/) (입장, 종료, 강조, 경로) 및 타이밍 조정이 가능합니다. 필요에 따라 SmartArt 노드 내부의 도형에도 애니메이션을 적용할 수 있습니다.

**내부 ID를 모를 경우 슬라이드에서 특정 SmartArt를 신뢰성 있게 찾으려면 어떻게 해야 하나요?**

SmartArt에 [대체 텍스트](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/alternative_text/)를 지정하고 검색합니다. SmartArt에 고유한 AltText를 설정하면 내부 식별자에 의존하지 않고 프로그래밍 방식으로 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지됩니까?**

예. Aspose.Slides는 [PDF 내보내기](/slides/ko/python-net/convert-powerpoint-to-pdf/) 중에 SmartArt를 높은 시각적 정확도로 렌더링하여 레이아웃, 색상 및 효과를 보존합니다.

**전체 SmartArt 이미지를 추출할 수 있나요(미리보기나 보고서용 등)?**

예. SmartArt 모양을 [래스터 형식](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/get_image/) 또는 [SVG](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/write_as_svg/) 로 렌더링하여 확장 가능한 벡터 출력으로 만들 수 있으므로 썸네일, 보고서 또는 웹 사용에 적합합니다.