---
title: .NET에서 PowerPoint 프레젠테이션의 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/net/manage-smartart/
keywords:
- SmartArt
- SmartArt 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 명확한 C# 코드 샘플로 PowerPoint SmartArt를 만들고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하세요."
---
## **개요**

SmartArt는 노드, 노드 도형 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for .NET을 사용하면 SmartArt를 생성하고, 노드의 텍스트를 읽으며, 레이아웃을 변경하고, 숨김 노드를 검사하고, 조직도 레이아웃을 구성하며, 사진 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 도형이 포함될 수 있습니다. 표시된 텍스트를 읽으려면 [ISmartArt.AllNodes](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartart/allnodes/)를 순회한 다음 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartartshape/textframe/)에서 반환된 [ITextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/)을 읽습니다.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 어떻게 배열되고 연결되는지를 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 값을 사용하여 SmartArt 개체를 만든 다음 `BasicProcess` 값으로 변경하고 프레젠테이션을 저장합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArt 노드가 숨김인지 확인**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartartnode/ishidden/)은 노드가 SmartArt 데이터 모델에서 숨김 상태인지 여부를 나타냅니다. 선택된 레이아웃에 표시되지 않더라도 숨김 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **조직도 레이아웃 가져오기 및 설정**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우 [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/)이 부모 노드 아래에서 자식 노드가 어떻게 배치되는지를 정의합니다. 예를 들어 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리게 할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**SmartArt가 RTL 언어에 대한 미러링 또는 반전 기능을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 반전을 지원하는 경우 [IsReversed](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/smartart/isreversed/) 속성을 사용하여 다이어그램 방향을 왼쪽‑→‑오른쪽에서 오른쪽‑→‑왼쪽으로(또는 그 반대로) 전환할 수 있습니다.

**형식을 유지하면서 동일한 슬라이드 또는 다른 프레젠테이션에 SmartArt를 복사하려면 어떻게 해야 합니까?**

[ShapeCollection.AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/shapecollection/addclone/)을 사용하여 SmartArt 도형을 [클론]( /slides/ko/net/shape-manipulations/)하거나 SmartArt가 포함된 전체 슬라이드를 [클론]( /slides/ko/net/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**미리 보기 또는 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 해야 합니까?**

슬라이드([/slides/ko/net/convert-powerpoint-to-png/]) 또는 전체 프레젠테이션을 PNG 또는 JPEG 형식으로 변환하면 SmartArt가 슬라이드의 일부로 렌더링됩니다.

**여러 개의 SmartArt가 있을 때 특정 SmartArt 개체를 슬라이드에서 찾으려면 어떻게 해야 합니까?**

SmartArt 도형에 고유한 [AlternativeText](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/alternativetext/) 또는 [Name](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/name/) 값을 설정하고, 해당 값을 [Slide.Shapes](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslide/shapes/)에서 검색한 다음 일치하는 도형이 [ISmartArt](https://reference.aspose.com/slides/ko/net/aspose.slides.smartart/ismartart/)인지 확인합니다.