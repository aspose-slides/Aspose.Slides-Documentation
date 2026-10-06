---
title: PowerPoint 프레젠테이션에서 .NET으로 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/net/manage-smartart/
keywords:
- 스마트아트
- 스마트아트 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- 파워포인트
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "명확한 C# 코드 샘플을 사용하여 .NET용 Aspose.Slides로 PowerPoint SmartArt를 만들고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 빠르게 진행할 수 있습니다."
---
## **개요**

SmartArt는 노드, 노드 모양 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for .NET을 사용하면 SmartArt를 만들고, 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 객체에서 텍스트 가져오기**

SmartArt 노드는 하나 이상의 모양을 포함할 수 있습니다. 노드 모양에서 텍스트를 읽으려면 [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/)를 반복하고, 그 다음 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/)에서 반환되는 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)을 읽으세요.

이 예제는 최소 하나의 슬라이드와 해당 슬라이드의 첫 번째 모양으로 SmartArt 객체가 있는 프레젠테이션이 필요합니다. 사용 가능한 각 텍스트 프레임을 콘솔에 출력합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **SmartArt 객체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 값으로 SmartArt 객체를 만들고, 이를 `BasicProcess` 값으로 변경한 후 프레젠테이션을 저장합니다. [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/)에 전달되는 위치와 크기는 포인트 단위로 측정됩니다. 레이아웃을 변경하려면 [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/)을 설정하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **SmartArt 노드가 숨겨졌는지 확인**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) 은 노드가 SmartArt 데이터 모델에서 숨겨져 있는지를 나타냅니다. 선택한 레이아웃이 해당 노드를 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 값을 사용하는 SmartArt 객체에 노드를 추가하고, 추가된 노드의 숨김 상태를 확인합니다. 노드가 숨겨져 있으면 메시지를 출력하고 다이어그램을 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/)은 자식 노드가 부모 노드 아래에서 어떻게 배치되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에 매달리게 설정할 수 있습니다.

다음 예제는 조직도를 만들고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 값으로 설정합니다. 0 기반 인덱스 `0`은 첫 번째 최상위 노드를 선택하며, 해당 자식 노드들은 선택된 배치를 사용합니다. 수정된 프레젠테이션은 이후 저장됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리표시자가 포함된 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 객체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 값을 사용하십시오. 이 예제는 이미지 자리표시자를 포함한 다이어그램을 저장하지만, 자리표시자에 이미지를 채우지는 않습니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **레거시 다이어그램을 모양 그룹으로 변환**

기존 프레젠테이션을 현대화할 때, PowerPoint 97–2003에서 만든 조직도를 업데이트해야 할 수 있습니다. Aspose.Slides는 이러한 레거시 다이어그램을 [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) 객체로 나타냅니다. 다이어그램을 모양 그룹으로 변환하려면 [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/)를 사용하여 개별 시각 요소를 편집할 수 있게 합니다. 자세한 내용은 [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/)를 참조하십시오.

변환은 원본 다이어그램을 제거하지 않고 모양 컬렉션에 새 그룹을 추가합니다. 변환이 성공하면 [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/)를 사용하여 원본을 제거해 중복 콘텐츠를 방지하십시오. 변환하기 전에 레거시 다이어그램을 배열에 수집하면 모양을 추가하거나 제거해도 반복이 방해되지 않습니다.

다음 예제는 프레젠테이션을 열고, 모든 슬라이드를 검색하여 다이어그램을 모양 그룹으로 변환한 뒤, 업데이트된 프레젠테이션을 PPTX로 저장합니다.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

저장된 프레젠테이션은 변환된 레거시 다이어그램 대신 편집 가능한 모양 그룹을 포함하며, 원본 다이어그램은 남아 있지 않습니다. PPTX를 PowerPoint에서 열어 각 그룹 내 개별 요소(텍스트, 채우기 또는 위치 등)를 편집할 수 있습니다.

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링 또는 반전을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 반전을 지원하는 경우, [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) 속성이 다이어그램 방향을 왼쪽‑오른쪽에서 오른쪽‑왼쪽으로, 또는 그 반대로 전환합니다.

**SmartArt를 동일한 슬라이드 또는 다른 프레젠테이션에 복사하면서 형식을 유지하려면 어떻게 해야 하나요?**

[SmartArt 모양 복제](/slides/ko/net/shape-manipulations/)를 [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)으로 하거나, SmartArt가 포함된 전체 슬라이드를 [전체 슬라이드 복제](/slides/ko/net/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 형식을 유지합니다.

**SmartArt를 미리 보기 또는 웹 내보내기를 위해 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

[슬라이드 렌더링](/slides/ko/net/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 렌더링하십시오. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**여러 개가 있는 경우 슬라이드에서 특정 SmartArt 객체를 어떻게 찾을 수 있나요?**

SmartArt 모양에 구별되는 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) 또는 [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) 값을 설정하고, [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)에서 해당 값을 검색한 다음, 일치하는 모양이 [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/)인지 확인하십시오.