---
title: .NET에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 70
url: /ko/net/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 조정 잠금
- 그룹화 잠금
- PowerPoint
- PPTX
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배워 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **배경**

Aspose.Slides for .NET의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 콘텐츠를 보존하는 데 도움이 됩니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한할 수 있게 합니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어져 있습니다. Aspose.Slides for .NET에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표현됩니다. 다양한 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 인터페이스는 도형 잠금의 기본 인터페이스입니다. Aspose.Slides for .NET은 다음 잠금 인터페이스를 제공합니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 연결선 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.  

전체 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)에 잠금을 적용하려면 슬라이드를 순회하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

호환되는 프레젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화 및 문서 수준 쓰기 보호는 별개의 [프레젠테이션 보호 설정](/slides/ko/net/password-protected-presentation/)입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for .NET은 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 인터페이스를 제공합니다.

예제는 자동 도형에 대해 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/), [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/)를 `true`로 설정하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 위해 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/)을 사용하고; 그룹은 그룹화를 제한하기 위해 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)을 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션에서 도형을 확인한 뒤 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리된 유형 외의 도형은 변경되지 않은 채로 남겨집니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `false`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)을 해제하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 남겨집니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **그림 자르기 보존**

작업 디렉터리에 `photo.jpg`라는 사진을 배치합니다. 예제는 왼쪽에서 12%, 오른쪽에서 8%를 잘라낸 후 그림 프레임에 [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)을 설정합니다. 이 플래그는 추가 자르기를 제한하고 기존 자르기를 보존합니다.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx`는 자르기 잠금을 `true`로 저장합니다. PowerPoint에서 사진을 선택하면 **Crop** 명령이 비활성화됩니다.

### **다이어그램을 그룹화된 상태 유지**

예제는 사각형과 화살표를 그룹화한 뒤 그룹 자체에 [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)을 설정하여 다이어그램의 구성 요소가 함께 유지되도록 합니다. 그룹을 이동하거나 구성 요소의 채우기를 변경하는 등 다른 편집은 계속 사용할 수 있습니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx`는 그룹 해제 잠금을 `true`로 저장합니다. 전체 다이어그램을 선택하면 PowerPoint에서 **Ungroup** 명령이 비활성화됩니다.

### **기존 도형 잠금 보고**

템플릿을 검토하려면 열어서 각 도형의 잠금 객체를 읽습니다. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/)는 해당 객체의 모든 플래그가 비활성화되어 있으면 `true`이고, 하나라도 활성화되어 있으면 `false`입니다. 그룹과 그 자식은 별개의 잠금 객체를 가지므로, 그룹에 잠금이 없어도 자식을 검사해야 합니다.

이 예제는 자동 도형, 그림 프레임 및 그룹의 이동, 그림의 자르기, 그룹의 해제 여부를 확인합니다. 인식된 플래그를 보고하고 검사하지 않은 도형 유형을 표시합니다.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

`Sample.pptx`의 슬라이드 1에 `Layout`이라는 그룹이 있고 그룹 해제가 잠겨 있으며, 그 안에 있는 `Photo`라는 그림은 자르기가 잠겨 있고, 잠금이 해제된 사각형 `Free`가 있다고 가정합니다. 보고서는 `Free`를 건너뛰고 다음 두 줄을 출력합니다:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

보고서는 저장된 도형 수준 편집 플래그를 읽을 뿐이며, 이를 변경하거나 프레젠테이션을 저장하지 않습니다. 문서 수준 쓰기 보호는 별도의 설정이며, 각 플래그의 적용 여부는 편집기에 따라 다릅니다.

### **결론**

Aspose.Slides for .NET을 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원되는 잠금을 선택하고, 제한을 해제하려면 값을 `false`로 설정하세요.

## **FAQ**

**프레젠테이션에서 도형 잠금과 비밀번호 보호를 동시에 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/net/password-protected-presentation/)은 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일한 파일에서 동시에 사용할 수 있습니다.

**특정 슬라이드만 편집 제한을 적용하고 다른 슬라이드에는 영향을 주지 않나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용합니다. 이는 다른 슬라이드의 잠금 설정을 변경하지 않습니다.

**그룹 내부의 개별 도형에 잠금을 어떻게 적용할 수 있나요?**

그룹의 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 보고서 예제에서와 같이 중첩된 그룹이 있으면 동일하게 반복합니다.