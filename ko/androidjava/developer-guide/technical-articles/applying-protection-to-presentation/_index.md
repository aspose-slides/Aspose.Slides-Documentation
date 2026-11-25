---
title: Android에서 도형 잠금으로 프레젠테이션 편집 제한하기
linktitle: 프레젠테이션 편집 제한
type: docs
weight: 60
url: /ko/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PPTX 프레젠테이션에서 도형을 잠그고 잠금 해제하는 방법을 배우고, 선택, 이동, 크기 조정 및 그룹화를 제한합니다."
---
## **개요**

Aspose.Slides for Android via Java의 일반적인 사용 사례는 자동화된 워크플로우의 일부로 PowerPoint (PPTX) 프레젠테이션을 생성, 업데이트 및 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 내용을 보존하는 데 도움이 됩니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금은 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **슬라이드 구성**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 연결선 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Android via Java에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속받는 객체로 표현됩니다.

도형 유형마다 서로 다른 잠금 옵션을 제공합니다. [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) 인터페이스는 도형 잠금에 대한 기본 인터페이스입니다. Aspose.Slides for Android via Java는 다음과 같은 잠금 인터페이스를 제공합니다:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 연결 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 전체에 잠금을 적용하려면 슬라이드를 순회하면서 각 지원되는 도형에 적절한 잠금을 설정합니다.

## **보호 적용 및 제거**

호환되는 프레젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화 및 문서 수준 쓰기 보호는 별도의 [presentation protection settings](/slides/ko/androidjava/password-protected-presentation/)입니다.

### **PPTX 도형에 대한 보호 적용**

Aspose.Slides for Android via Java는 슬라이드의 도형을 다루기 위해 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 인터페이스를 제공합니다.

예제에서는 자동 도형에 대해 `true`와 함께 [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-)를 호출하고, 그룹 도형, 연결선 및 그림 프레임에 대해 동등한 잠금을 적용합니다. 연결선은 이동을 제한하기 위해 [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-)을 사용하고, 그룹은 [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)을 사용해 그룹화를 제한합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션을 확인한 뒤, 이러한 제한이 적용된 복사본을 저장합니다. 네 가지 처리된 유형 외의 도형은 변경되지 않은 채로 남습니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

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

도형 잠금을 제거하려면 값을 `false`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고, [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)에 `false`를 전달하여 그룹화 제한을 제거하고 프레젠테이션 복사본을 저장합니다. 다른 잠금 설정은 변경되지 않은 채로 남습니다.

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

### **그림 자르기 보존**

작업 디렉터리에 `photo.jpg`라는 사진을 배치합니다. 예제는 왼쪽에서 12%, 오른쪽에서 8%를 자른 뒤, 그림 프레임의 잠금에 대한 [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-)을 호출합니다. `true`를 전달하면 추가 자르기가 제한되고 기존 자르기가 보존됩니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx`는 자르기 잠금을 `true`로 저장합니다. PowerPoint에서 사진을 선택하면 **Crop** 명령이 비활성화됩니다.

### **다이어그램 그룹 유지**

예제는 사각형과 화살표를 그룹화한 뒤, 그룹의 잠금에 대해 [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-)을 호출해 다이어그램 구성 요소가 함께 유지되도록 합니다. 그룹을 이동하거나 구성 요소의 채우기를 변경하는 등 다른 편집은 여전히 가능합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx`는 그룹 해제 잠금을 `true`로 저장합니다. PowerPoint에서 전체 다이어그램을 선택하면 **Ungroup** 명령이 비활성화됩니다.

### **기존 도형 잠금 보고**

템플릿을 검토하려면 파일을 열고 각 도형에 대한 잠금 객체를 읽습니다. [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) 메서드는 해당 객체의 모든 플래그가 비활성화된 경우 `true`를, 하나라도 활성화된 경우 `false`를 반환합니다. 그룹과 그 자식은 별도의 잠금 객체를 가지므로, 그룹에 잠금이 없더라도 자식을 검사해야 합니다.

이 예제는 자동 도형, 그림 프레임 및 그룹의 이동을 검사하고, 그림에 대한 자르기와 그룹에 대한 그룹 해제를 검사합니다. 보고서는 인식된 활성 플래그를 나열하고 검사하지 않은 도형 유형을 표시합니다.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

예를 들어 `Sample.pptx`의 슬라이드 1에 `Layout`이라는 그룹이 있고 그 그룹은 그룹 해제가 잠겨 있으며, 내부에 있는 `Photo`라는 그림은 자르기가 잠겨 있고, 잠겨 있지 않은 `Free`라는 사각형이 있다고 가정합니다. 보고서는 `Free`를 건너뛰고 다음 두 줄을 출력합니다:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

보고서는 프레젠테이션을 저장하거나 변경하지 않고 저장된 도형 수준 편집 플래그를 읽습니다. 문서 수준 쓰기 보호는 별도의 설정이며, 각 플래그의 적용 여부는 편집기에 따라 달라집니다.

## **결론**

Aspose.Slides for Android via Java를 사용하면 개별 도형에 대한 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 제한을 제거해야 할 때는 값을 `false`로 설정하십시오.

## **FAQ**

**도형 잠금과 암호 보호를 같은 프레젠테이션에서 함께 사용할 수 있나요?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [password protection](/slides/ko/androidjava/password-protected-presentation/)은 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 기능을 동일 파일에서 동시에 사용할 수 있습니다.

**특정 슬라이드만 편집 제한을 적용하고 다른 슬라이드에는 영향을 주지 않을 수 있나요?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**그룹 내부의 개별 도형에 잠금을 적용하려면 어떻게 해야 하나요?**

그룹의 [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 보고서 예제에서 사용한 순회 방식을 따라 동일하게 적용하십시오.