---
title: Java에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 60
url: /ko/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한할 수 있습니다."
---
## **배경**

Aspose.Slides for Java의 일반적인 사용은 자동화된 워크플로의 일부로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서에서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹화된 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 구성됩니다. Aspose.Slides for Java에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표현됩니다.

서로 다른 도형 유형은 서로 다른 잠금 옵션을 제공합니다. [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 인터페이스는 도형 잠금의 기본 인터페이스입니다. Aspose.Slides for Java는 다음과 같은 잠금 인터페이스를 제공합니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 연결선 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.  

전체 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)에서 잠금을 적용하려면 슬라이드를 반복하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동 및 크기 조정과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집할 수 없게 만들지는 않습니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Java는 슬라이드의 도형을 작업하기 위해 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 인터페이스를 제공합니다.

예제에서는 자동 도형에 대해 `true`와 함께 [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-)를 호출하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-)를 사용하고; 그룹은 또한 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)를 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션에 있는 도형을 확인한 후 이러한 제한이 적용된 사본을 저장합니다. 처리된 네 가지 유형 외의 도형은 변경되지 않은 채로 둡니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `false`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고 [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)에 `false`를 전달하여 그룹화 제한을 제거하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 유지됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **결론**

Aspose.Slides for Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형에서 지원하는 잠금을 선택하고, 제한을 제거해야 할 때는 값을 `false`로 설정하십시오.

## **FAQ**

**도형 잠금과 비밀번호 보호를 동일한 프레젠테이션에 함께 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [비밀번호 보호](/slides/ko/java/password-protected-presentation/)은 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일 파일에서 함께 사용할 수 있습니다.

**특정 슬라이드에만 편집을 제한하고 다른 슬라이드는 영향을 주지 않나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 됩니다. 이렇게 하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹에 대해서도 이 과정을 반복합니다. 위의 예제는 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 대한 잠금을 설정하지 않습니다.