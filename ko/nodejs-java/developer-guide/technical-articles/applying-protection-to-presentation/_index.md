---
title: Node.js에서 도형 잠금으로 프레젠테이션 편집 제한
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 60
url: /ko/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **개요**

Aspose.Slides for Node.js via Java의 일반적인 사용 사례는 자동화된 워크플로의 일부로 PowerPoint (PPTX) 프레젠테이션을 만들고, 업데이트하며, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서에서는 슬라이드에 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Node.js via Java에서 슬라이드의 각 요소는 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 클래스를 상속하는 객체로 표시됩니다.

다양한 도형 유형마다 서로 다른 잠금 옵션을 제공합니다. [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) 클래스는 도형 잠금의 기본 클래스입니다. Aspose.Slides for Node.js via Java은 다음 잠금 클래스를 제공합니다:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 자동 도형을 잠급니다.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 연결선 도형을 잠급니다.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 그룹 도형을 잠급니다.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)에 걸쳐 잠금을 적용하려면 슬라이드를 순회하면서 지원되는 각 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

도형 잠금은 도형 선택, 이동, 크기 조정과 같은 작업을 제한합니다. 전체 프레젠테이션을 편집 불가능하게 만들지는 않습니다.

### **PPTX 도형에 보호 적용**

Aspose.Slides for Node.js via Java는 슬라이드의 도형을 작업하기 위한 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 클래스를 제공합니다.

예제는 자동 도형에 대해 `true`와 함께 [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked)를 호출하고, 그룹 도형, 연결선, 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove)를 사용하고, 그룹은 [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)를 사용해 그룹화를 제한합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션을 검사한 뒤 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리 유형에 포함되지 않은 도형은 변경되지 않은 채로 둡니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **보호 제거**

도형 잠금을 제거하려면 해당 값을 `false`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고 [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/)을 통해 선택, 이동, 크기 조정 제한을 해제합니다. 또한 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)에 `false`를 전달해 그룹화 제한을 삭제하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 남습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **결론**

Aspose.Slides for Node.js via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 제한을 제거해야 할 때는 값을 `false`로 설정하십시오.

## **FAQ**

**동일한 프레젠테이션에서 도형 잠금과 암호 보호를 결합할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [암호 보호](/slides/ko/nodejs-java/password-protected-presentation/)는 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 가지를 동일한 파일에서 함께 사용할 수 있습니다.

**다른 슬라이드에 영향을 주지 않고 특정 슬라이드만 편집을 제한할 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 안의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용하십시오. 중첩된 그룹에 대해서도 동일하게 반복합니다. 위 예제들은 슬라이드의 도형 컬렉션만 처리하므로 개별 그룹 구성원에 잠금을 설정하지 않습니다.