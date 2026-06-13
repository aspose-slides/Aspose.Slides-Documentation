---
title: C++를 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/cpp/manage-smartart/
keywords:
- 스마트아트
- 스마트아트 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 명확한 코드 샘플로 PowerPoint SmartArt를 구축하고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하세요."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for C++를 사용하면 SmartArt를 생성하고, 노드에서 텍스트를 읽고, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 모양이 포함될 수 있습니다. 표시된 텍스트를 읽으려면 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartart/get_allnodes/)을 반복한 다음, [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartshape/get_textframe/)이 반환하는 [ITextFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframe/)을 읽으십시오.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 생성하고, 이를 `BasicProcess` 값으로 변경한 뒤 프레젠테이션을 저장합니다.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SmartArt 노드가 숨겨져 있는지 확인**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartnode/get_ishidden/)은(는) SmartArt 데이터 모델에서 노드가 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 노드를 가시적인 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) 및 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/)은(는) 부모 노드 아래에 자식 노드가 배치되는 방식을 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리게 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링 또는 반전을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 반전을 지원하는 경우, [SmartArt::set_IsReversed](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/smartart/set_isreversed/) 메서드는 다이어그램 방향을 왼쪽-오른쪽에서 오른쪽-왼쪽으로, 또는 그 반대로 전환합니다.

**포맷을 유지하면서 SmartArt를 동일한 슬라이드 또는 다른 프레젠테이션으로 복사하려면 어떻게 합니까?**

스마트아트를 포함하는 슬라이드에서 [ShapeCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shapecollection/addclone/)을 사용하여 [SmartArt 모양을 복제](/slides/ko/cpp/shape-manipulations/)하거나, 전체 슬라이드를 [복제](/slides/ko/cpp/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 보존합니다.

**미리보기 또는 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 해야 합니까?**

슬라이드 또는 전체 프레젠테이션을 PNG 또는 JPEG 형식으로 [렌더링](/slides/ko/cpp/convert-powerpoint-to-png/)하십시오. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개가 있는 경우 슬라이드에서 특정 SmartArt 개체를 어떻게 찾을 수 있습니까?**

SmartArt 모양에 고유한 [Shape::set_AlternativeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/set_alternativetext/) 또는 [Shape::set_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/shape/set_name/) 값을 설정하고, [BaseSlide::get_Shapes](https://reference.aspose.com/slides/ko/cpp/aspose.slides/baseslide/get_shapes/)에서 해당 값을 검색한 다음, 일치하는 모양이 [ISmartArt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/ismartart/)인지 확인하십시오.