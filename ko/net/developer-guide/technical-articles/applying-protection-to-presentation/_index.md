---
title: 형상 잠금을 사용한 .NET 프레젠테이션 편집 방지
linktitle: 프레젠테이션 편집 방지
type: docs
weight: 70
url: /ko/net/applying-protection-to-presentation/
keywords:
- 편집 방지
- 편집으로부터 보호
- 도형 잠금
- 위치 잠금
- 선택 잠금
- 크기 잠금
- 그룹화 잠금
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 PPT, PPTX 및 ODP 파일에서 도형을 잠그거나 잠금 해제하는 방법을 알아보고, 프레젠테이션을 보호하면서도 제어된 편집을 허용합니다."
---
## **배경**

Aspose.Slides의 일반적인 사용 사례는 자동화된 워크플로의 일부로 Microsoft PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 이러한 방식으로 Aspose.Slides를 사용하는 애플리케이션의 사용자는 생성된 프젠테이션에 접근할 수 있으므로, 편집으로부터 보호하는 것이 일반적인 관심사입니다. 자동으로 생성된 프젠테이션이 원래의 서식과 내용을 유지하는 것이 중요합니다.

이 문서는 프젠테이션과 슬라이드가 어떻게 구성되는지, 그리고 Aspose.Slides for .NET이 프젠테이션에 보호를 적용하고 나중에 제거할 수 있는 방법을 설명합니다. 개발자가 애플리케이션이 생성한 프젠테이션이 어떻게 사용되는지를 제어할 수 있는 방법을 제공합니다.

## **슬라이드 구성**

프젠테이션 슬라이드는 자동 도형, 표, OLE 객체, 그룹 도형, 그림 프레임, 비디오 프레임, 커넥터 및 프젠테이션을 구성하는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for .NET에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표현됩니다.

PPTX 구조는 복잡하기 때문에, 모든 유형의 도형에 대해 일반 잠금을 사용할 수 있는 PPT와 달리, 도형 유형마다 다른 잠금이 필요합니다. [IBaseShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseshapelock/) 인터페이스는 PPTX용 일반 잠금 클래스입니다. Aspose.Slides for .NET에서 PPTX에 지원되는 잠금 유형은 다음과 같습니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshapelock/) 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/ko/net/aspose.slides/iconnectorlock/) 커넥터 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/ko/net/aspose.slides/igraphicalobjectlock/) 그래픽 객체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 객체에 있는 모든 도형 객체에 수행된 작업은 전체 프젠테이션에 적용됩니다.

## **보호 적용 및 제거**

보호를 적용하면 프젠테이션을 편집할 수 없게 됩니다. 이는 프젠테이션 내용 보호에 유용한 기술입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for .NET은 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 인터페이스를 제공합니다.

앞서 언급한 바와 같이 각 도형 클래스에는 보호를 위한 관련 도형‑잠금 클래스가 있습니다. 이 문서에서는 NoSelect, NoMove, NoResize 잠금에 집중합니다. 이러한 잠금은 도형을 선택(마우스 클릭 등)할 수 없게 하며, 이동 및 크기 조정도 할 수 없게 합니다.

다음 코드 샘플은 프젠테이션의 모든 도형 유형에 보호를 적용합니다.

```cs
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("Sample.pptx");

// Traversing all the slides in the presentation.
foreach (ISlide slide in presentation.Slides)
{
    // 프레젠테이션의 모든 슬라이드를 순회합니다.
    foreach (IShape shape in slide.Shapes)
    {
        // 슬라이드의 모든 도형을 순회합니다.
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

// Saving the presentation file.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **보호 제거**

도형의 잠금을 해제하려면 적용된 잠금의 값을 `false`로 설정합니다. 다음 코드 샘플은 잠긴 프젠테이션에서 도형 잠금을 해제하는 방법을 보여줍니다.

```cs
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Traversing all the slides in the presentation.
foreach (ISlide slide in presentation.Slides)
{
    // 슬라이드의 모든 도형을 순회합니다.
    foreach (IShape shape in slide.Shapes)
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

// 프레젠테이션 파일을 저장합니다.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **결론**

Aspose.Slides는 프젠테이션에서 도형을 보호하기 위한 여러 옵션을 제공합니다. 개별 도형을 잠그거나 프젠테이션의 모든 도형을 순회하면서 각각을 잠가 전체 파일을 효과적으로 보호할 수 있습니다. 잠금 값을 `false`로 설정하면 보호를 제거할 수 있습니다.

## **FAQ**

**같은 프젠테이션에서 도형 잠금과 비밀번호 보호를 결합할 수 있나요?**

예. 잠금은 파일 내부 개체의 편집을 제한하고, [비밀번호 보호](/slides/ko/net/password-protected-presentation/)은 열기 및/또는 변경 사항 저장에 대한 접근을 제어합니다. 이러한 메커니즘은 서로를 보완하며 함께 작동합니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에 잠금을 적용하면 나머지 슬라이드는 계속 편집 가능하게 유지됩니다.

**도형 잠금은 그룹 객체와 커넥터에도 적용되나요?**

예. 그룹, 커넥터, 그래픽 객체 및 기타 도형 종류에 대해 전용 잠금 유형이 지원됩니다.