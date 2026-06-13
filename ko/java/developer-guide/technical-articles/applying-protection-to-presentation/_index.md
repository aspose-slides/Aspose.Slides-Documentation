---
title: 도형 잠금을 사용하여 프레젠테이션 편집 방지
linktitle: 프레젠테이션 편집 방지
type: docs
weight: 60
url: /ko/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 PPT, PPTX 및 ODP 파일에서 도형을 잠그거나 잠금 해제하는 방법을 알아보고, 프레젠테이션을 보호하면서 제어된 편집 및 빠른 제공을 가능하게 합니다."
---
## **배경**

Aspose.Slides의 일반적인 사용 사례는 자동화된 워크플로의 일부로 Microsoft PowerPoint(PPTX) 프레젠테이션을 생성, 업데이트 및 저장하는 것입니다. 이러한 방식으로 Aspose.Slides를 사용하는 애플리케이션의 사용자는 생성된 프레젠테이션에 접근할 수 있으므로, 편집으로부터 보호하는 것이 일반적인 우려 사항입니다. 자동 생성된 프레젠테이션이 원래 서식과 내용을 유지하는 것이 중요합니다.

이 문서는 프레젠테이션과 슬라이드의 구조를 설명하고 Aspose.Slides for Java가 프레젠테이션에 보호를 적용한 다음 제거하는 방법을 안내합니다. 개발자가 애플리케이션이 생성하는 프레젠테이션의 사용 방식을 제어할 수 있는 방법을 제공합니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹형 도형, 그림 프레임, 비디오 프레임, 커넥터 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Java에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표시됩니다.

PPTX의 구조는 복잡하기 때문에 PPT와 달리 모든 종류의 도형에 대해 일반적인 잠금만 사용할 수 없으며, 도형 유형마다 다른 잠금이 필요합니다. [IBaseShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseshapelock/) 인터페이스는 PPTX용 일반 잠금 클래스입니다. Aspose.Slides for Java는 PPTX에서 다음 유형의 잠금을 지원합니다.

- [IAutoShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshapelock/) 은 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnectorlock/) 은 커넥터 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igraphicalobjectlock/) 은 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igroupshapelock/) 은 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframelock/) 은 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 객체의 모든 도형 객체에 수행되는 작업은 전체 프레젠테이션에 적용됩니다.

## **보호 적용 및 제거**

보호를 적용하면 프레젠테이션을 편집할 수 없게 됩니다. 이는 프레젠테이션 내용 보호에 유용한 기술입니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Java는 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인터페이스를 제공합니다.

앞서 언급했듯이 각 도형 클래스에는 보호를 위한 도형‑잠금 클래스가 연결되어 있습니다. 이 문서에서는 NoSelect, NoMove 및 NoResize 잠금에 초점을 맞춥니다. 이러한 잠금은 도형을 선택(마우스 클릭 또는 기타 선택 방법)하거나 이동·크기 조정할 수 없도록 합니다.

다음 코드 샘플은 프레젠테이션의 모든 도형 유형에 보호를 적용합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("Sample.pptx");

// 프레젠테이션의 모든 슬라이드를 순회합니다.
for (ISlide slide : presentation.getSlides()) {

    // 슬라이드의 모든 도형을 순회합니다.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 도형을 자동 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // 도형을 그룹 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // 도형을 커넥터 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // 도형을 그림 프레임으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// 프레젠테이션 파일을 저장합니다.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **보호 제거**

도형의 잠금을 해제하려면 적용된 잠금의 값을 `false` 로 설정합니다. 다음 코드 샘플은 잠긴 프레젠테이션에서 도형의 잠금을 해제하는 방법을 보여줍니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// 프레젠테이션의 모든 슬라이드를 순회합니다.
for (ISlide slide : presentation.getSlides()) {

    // 슬라이드의 모든 도형을 순회합니다.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 도형을 자동 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // 도형을 그룹 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // 도형을 커넥터 도형으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // 도형을 그림 프레임으로 형변환하고 해당 도형 잠금을 가져옵니다.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// 프레젠테이션 파일을 저장합니다.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **결론**

Aspose.Slides는 프레젠테이션 내 도형을 보호하는 여러 옵션을 제공합니다. 개별 도형을 잠그거나 프레젠테이션의 모든 도형을 순회하면서 각각을 잠가 파일 전체를 효과적으로 보호할 수 있습니다. 잠금 값을 `false` 로 설정하면 보호를 제거할 수 있습니다.

## **FAQ**

**같은 프레젠테이션에서 도형 잠금과 비밀번호 보호를 함께 사용할 수 있나요?**

예. 잠금은 파일 내부 객체의 편집을 제한하고, [password protection](/slides/ko/java/password-protected-presentation/)은 열기 및/또는 저장 시 변경을 제어합니다. 이 두 메커니즘은 상호 보완적으로 작동합니다.

**특정 슬라이드만 편집을 제한하고 다른 슬라이드는 그대로 두고 싶나요?**

예. 선택된 슬라이드의 도형에만 잠금을 적용하면 나머지 슬라이드는 계속 편집할 수 있습니다.

**도형 잠금이 그룹 객체와 커넥터에도 적용되나요?**

예. 그룹, 커넥터, 그래픽 객체 및 기타 도형 종류에 대해 전용 잠금 유형이 지원됩니다.