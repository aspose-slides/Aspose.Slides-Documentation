---
title: C++을 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하는 명확한 코드 샘플을 제공합니다."
---
## **개요**

SmartArt은 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for C++를 사용하면 SmartArt를 생성하고, 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드는 하나 이상의 모양을 포함할 수 있습니다. 노드 모양에서 텍스트를 읽으려면 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/)을 순회한 다음 [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/)이 반환하는 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)을 읽습니다.

예제는 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 모양으로 SmartArt 개체가 포함된 프레젠테이션이 필요합니다. 각 사용 가능한 텍스트 프레임을 콘솔에 출력합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 만든 다음 `BasicProcess` 값으로 변경하고 프레젠테이션을 저장합니다. [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/)에 전달되는 위치와 크기는 포인트 단위입니다. 레이아웃을 변경하려면 [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/)을 사용합니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/)은 노드가 SmartArt 데이터 모델에서 숨겨져 있는지를 나타냅니다. 선택한 레이아웃이 해당 노드를 가시적인 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고, 추가된 노드의 숨김 상태를 확인합니다. 노드가 숨겨져 있으면 메시지를 출력하고 다이어그램을 저장합니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) 및 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/)은 부모 노드 아래에 자식 노드가 배치되는 방식을 정의합니다. 예를 들어 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에서 매달리게 할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다. 0부터 시작하는 인덱스 `0`은 최상위 노드 첫 번째를 선택하며, 해당 자식 노드들은 선택된 배열을 사용합니다. 수정된 프레젠테이션을 저장합니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 구조 다이어그램용으로 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 값을 사용합니다. 이 예제는 이미지 자리 표시자가 있는 다이어그램을 저장하지만 자리 표시자를 이미지로 채우지는 않습니다.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **레거시 다이어그램을 그룹 형태로 변환**

기존 프레젠테이션을 최신화할 때 PowerPoint 97–2003에서 만든 조직도를 업데이트해야 할 수 있습니다. Aspose.Slides는 이러한 레거시 다이어그램을 [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) 객체로 나타냅니다. [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/)를 사용하면 다이어그램을 그룹 형태로 변환하여 개별 시각 요소를 편집할 수 있습니다. 자세한 내용은 [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/)를 참조하세요.

변환은 원본 다이어그램을 제거하지 않고 형태 컬렉션에 새 그룹을 추가합니다. 변환이 성공하면 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/)를 사용해 원본을 삭제하여 중복 콘텐츠를 방지합니다. 형태를 추가·제거하는 동안 반복이 중단되지 않도록 변환 전 레거시 다이어그램을 벡터에 수집합니다.

다음 예제는 프레젠테이션을 열고 모든 슬라이드를 검색한 뒤 다이어그램을 그룹 형태로 변환하고 업데이트된 프레젠테이션을 PPTX로 저장합니다.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

저장된 프레젠테이션은 변환된 레거시 다이어그램 대신 편집 가능한 그룹 형태를 포함하며, 원본 다이어그램은 남아 있지 않습니다. PPTX를 PowerPoint에서 열어 각 그룹 내 텍스트, 채우기 또는 위치와 같은 개별 요소를 편집할 수 있습니다.

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링 또는 반전을 지원하나요?**

예. [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) 메서드는 선택한 SmartArt 레이아웃이 반전을 지원할 경우 다이어그램 방향을 왼쪽에서 오른쪽에서 오른쪽에서 왼쪽(또는 그 반대로) 전환합니다.

**형식을 유지하면서 같은 슬라이드 또는 다른 프레젠테이션으로 SmartArt를 복사하려면 어떻게 해야 하나요?**

[ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)을 사용해 SmartArt 모양을 [복제](/slides/ko/cpp/shape-manipulations/)하거나 SmartArt가 포함된 전체 슬라이드를 [복제](/slides/ko/cpp/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 형식을 유지합니다.

**미리 보기 또는 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 하나요?**

[슬라이드](/slides/ko/cpp/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 변환합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**슬라이드에 여러 SmartArt 개체가 있을 때 특정 개체를 어떻게 찾나요?**

SmartArt 모양에 고유한 [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) 또는 [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) 값을 설정하고, [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)에서 해당 값을 검색한 다음, 일치하는 모양이 [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/)인지 확인합니다.