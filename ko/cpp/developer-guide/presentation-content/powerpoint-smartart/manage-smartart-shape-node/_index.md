---
title: C++를 사용하여 프레젠테이션에서 SmartArt 도형 노드 관리
linktitle: SmartArt 도형 노드
type: docs
weight: 30
url: /ko/cpp/manage-smartart-shape-node/
keywords:
- SmartArt 노드
- 자식 노드
- 노드 추가
- 노드 위치
- 노드 접근
- 노드 제거
- 사용자 지정 위치
- 보조 노드
- 채우기 형식
- 노드 렌더링
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PPT 및 PPTX에서 SmartArt 도형 노드를 관리합니다. 프레젠테이션을 효율화하기 위한 명확한 코드 샘플과 팁을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드를 통해 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새 노드와 자식 노드를 추가하고, 특정 위치에 자식 노드를 삽입하고, 기존 노드에 접근하며 텍스트, 레벨 및 위치를 읽을 수 있습니다.

이 문서에서는 SmartArt 도형 노드를 관리하는 방법을 설명합니다. 노드 제거, 인덱스 또는 위치를 통해 자식 노드 작업, 보조 노드를 일반 노드로 변환, SmartArt 노드 도형의 위치·크기·회전 조정, 노드 채우기 형식 설정, SmartArt 자식 노드의 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for C++는 SmartArt 도형을 가장 간단하게 관리할 수 있는 API를 제공합니다. 다음 샘플 코드는 SmartArt 도형 내부에 노드와 자식 노드를 추가하는 방법을 보여줍니다.

- SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArt으로 형변환합니다.
- SmartArt NodeCollection에 새 노드를 추가하고 TextFrame에 텍스트를 설정합니다.
- 새로 추가된 SmartArt 노드에 자식 노드를 추가하고 TextFrame에 텍스트를 설정합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **특정 위치에 SmartArt 노드 추가**
다음 샘플 코드는 SmartArt 도형의 각각의 노드에 속하는 자식 노드를 특정 위치에 추가하는 방법을 설명합니다.

- `Presentation` 클래스 인스턴스를 생성합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 액세스한 슬라이드에 StackedList 유형의 SmartArt 도형을 추가합니다.
- 추가된 SmartArt 도형에서 첫 번째 노드에 접근합니다.
- 선택한 노드에 대해 위치 2에 자식 노드를 추가하고 텍스트를 설정합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **SmartArt 노드 접근**
다음 샘플 코드는 SmartArt 도형 내부의 노드에 접근하는 방법을 보여줍니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 도형이 추가될 때만 설정된다는 점에 유의하세요.

- `Presentation` 클래스 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArt으로 형변환합니다.
- SmartArt 도형 내부의 모든 노드를 순회합니다.
- SmartArt 노드의 위치, 레벨 및 텍스트와 같은 정보를 표시합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt 자식 노드 접근**
다음 샘플 코드는 SmartArt 도형의 각각의 노드에 속하는 자식 노드에 접근하는 방법을 보여줍니다.

- PresentationEx 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArtEx로 형변환합니다.
- SmartArt 도형 내부의 모든 노드를 순회합니다.
- 선택한 SmartArt 도형 노드마다 해당 노드의 모든 자식 노드를 순회합니다.
- 자식 노드의 위치, 레벨 및 텍스트와 같은 정보를 표시합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **특정 위치에 SmartArt 자식 노드 접근**
다음 예제에서는 SmartArt 도형의 각각의 노드에 속하는 특정 위치의 자식 노드에 접근하는 방법을 배웁니다.

- `Presentation` 클래스 인스턴스를 생성합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- StackedList 유형의 SmartArt 도형을 추가합니다.
- 추가된 SmartArt 도형에 접근합니다.
- 인덱스 0에 있는 노드에 접근합니다.
- GetNodeByPosition() 메서드를 사용해 해당 SmartArt 노드의 위치 1에 있는 자식 노드에 접근합니다.
- 자식 노드의 위치, 레벨 및 텍스트와 같은 정보를 표시합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt 노드 제거**
다음 예제에서는 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArt으로 형변환합니다.
- SmartArt에 0개 이상의 노드가 있는지 확인합니다.
- 삭제할 SmartArt 노드를 선택합니다.
- RemoveNode() 메서드를 사용해 선택한 노드를 제거하고 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **특정 위치에 SmartArt 노드 제거**
다음 예제에서는 특정 위치에서 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

- `Presentation` 클래스 인스턴스를 생성하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용해 첫 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArt으로 형변환합니다.
- 인덱스 0에 있는 SmartArt 도형 노드를 선택합니다.
- 선택한 SmartArt 노드에 2개 이상의 자식 노드가 있는지 확인합니다.
- RemoveNodeByPosition() 메서드를 사용해 위치 1에 있는 노드를 제거합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **SmartArt 자식 노드에 사용자 지정 위치 설정**
이제 Aspose.Slides는 SmartArtShape의 X 및 Y 속성 설정을 지원합니다. 아래 코드 조각은 사용자 지정 SmartArtShape 위치, 크기 및 회전을 설정하는 방법을 보여주며, 새 노드를 추가하면 모든 노드의 위치와 크기가 다시 계산된다는 점에 유의하십시오.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **보조 노드 확인**
다음 샘플 코드는 SmartArt 노드 컬렉션에서 보조 노드를 식별하고 이를 변경하는 방법을 조사합니다.

- PresentationEx 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
- 인덱스를 사용해 두 번째 슬라이드에 대한 참조를 얻습니다.
- 첫 번째 슬라이드의 모든 도형을 순회합니다.
- 도형이 SmartArt 유형인지 확인하고, SmartArt이면 해당 도형을 SmartArtEx로 형변환합니다.
- SmartArt 도형 내부의 모든 노드를 순회하면서 보조 노드인지 확인합니다.
- 보조 노드의 상태를 일반 노드로 변경합니다.
- 프레젠테이션을 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **노드 채우기 형식 설정**
Aspose.Slides for C++를 사용하면 사용자 지정 SmartArt 도형을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서는 SmartArt 도형을 만들고 접근하며 채우기 형식을 설정하는 방법을 설명합니다.

아래 단계에 따라 진행하세요:

- `Presentation` 클래스 인스턴스를 생성합니다.
- 인덱스를 사용해 슬라이드에 대한 참조를 얻습니다.
- LayoutType을 지정하여 SmartArt 도형을 추가합니다.
- SmartArt 도형 노드에 대한 FillFormat을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **SmartArt 자식 노드 썸네일 생성**
다음 단계에 따라 개발자는 SmartArt 자식 노드의 썸네일을 생성할 수 있습니다.

1. PPTX 파일을 나타내는 `Presentation` 클래스를 인스턴스화합니다.
2. SmartArt를 추가합니다.
3. 인덱스를 사용해 노드에 대한 참조를 얻습니다.
4. 썸네일 이미지를 가져옵니다.
5. 원하는 이미지 형식으로 썸네일을 저장합니다.

아래 예제는 SmartArt 자식 노드의 썸네일을 생성합니다.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**SmartArt 애니메이션이 지원되나요?**

예. SmartArt는 일반 도형으로 취급되므로 [표준 애니메이션](/slides/ko/cpp/shape-animation/) (입장, 퇴장, 강조, 이동 경로)을 적용하고 타이밍을 조정할 수 있습니다. 필요에 따라 SmartArt 노드 내부의 도형도 애니메이션할 수 있습니다.

**슬라이드 내 특정 SmartArt를 내부 ID 없이 안정적으로 찾으려면 어떻게 해야 하나요?**

[대체 텍스트](/reference.aspose.com/slides/ko/cpp/aspose.slides/shape/set_alternativetext/)를 사용해 지정하고 검색하세요. SmartArt에 고유한 AltText를 설정하면 내부 식별자에 의존하지 않고 프로그래밍matically 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. Aspose.Slides는 [PDF 내보내기](/slides/ko/cpp/convert-powerpoint-to-pdf/) 중 SmartArt를 고화질로 렌더링하여 레이아웃, 색상 및 효과를 그대로 유지합니다.

**전체 SmartArt 이미지(미리보기나 보고서용)를 추출할 수 있나요?**

예. SmartArt 도형을 [래스터 형식](/reference.aspose.com/slides/ko/cpp/aspose.slides/shape/getimage/)이나 [SVG](/reference.aspose.com/slides/ko/cpp/aspose.slides/shape/writeassvg/)로 렌더링하여 썸네일, 보고서 또는 웹용으로 활용할 수 있습니다.