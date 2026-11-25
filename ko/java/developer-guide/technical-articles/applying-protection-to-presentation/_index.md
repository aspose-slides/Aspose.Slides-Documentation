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
description: "Aspose.Slides for Java를 사용해 PPTX 프레젠테이션에서 도형을 잠그고 해제하여 선택, 이동, 크기 조정 및 그룹화를 제한하는 방법을 배웁니다."
---
## **Background**

Aspose.Slides for Java의 일반적인 사용 사례는 자동 워크플로의 일부로 PowerPoint(PPTX) 프레젠테이션을 만들고, 업데이트하고, 저장하는 것입니다. 사용자가 이러한 프레젠테이션을 받을 때, 도형에 대한 변경을 제한하면 의도된 레이아웃과 콘텐츠를 보존하는 데 도움이 될 수 있습니다.

이 문서는 슬라이드에서 도형이 어떻게 구성되는지와 PPTX 프레젠테이션에서 도형 잠금을 적용하고 제거하는 방법을 설명합니다. 이러한 잠금을 사용하면 개별 도형에 대한 특정 편집 작업을 제한할 수 있습니다.

## **Composition of a Slide**

프레젠테이션 슬라이드는 자동 도형, 표, OLE 개체, 그룹 도형, 그림 프레임, 비디오 프레임, 연결자 및 프레젠테이션을 구성하는 데 사용되는 기타 요소와 같은 구성 요소로 이루어집니다. Aspose.Slides for Java에서는 슬라이드의 각 요소가 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 인터페이스를 구현하거나 해당 클래스를 상속하는 객체로 표시됩니다.

도형 유형에 따라 제공되는 잠금 옵션이 다릅니다. [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 인터페이스는 도형 잠금의 기본 인터페이스입니다. Aspose.Slides for Java는 다음 잠금 인터페이스를 제공합니다.

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)은 자동 도형을 잠급니다.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/)은 연결자 도형을 잠급니다.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/)은 그래픽 개체를 잠급니다.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)은 그룹 도형을 잠급니다.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/)은 그림 프레임을 잠급니다.  

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)의 슬라이드를 순회하면서 지원되는 각 도형에 적절한 잠금을 설정하면 전체 프레젠테이션에 잠금을 적용할 수 있습니다.

## **Apply and Remove Protection**

호환되는 프레젠테이션 편집기는 도형 잠금을 사용하여 개별 편집 작업을 제한합니다. 파일 암호화와 문서 수준 쓰기 보호는 별도의 [프레젠테이션 보호 설정](/slides/ko/java/password-protected-presentation/)입니다.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Java는 슬라이드에서 도형을 작업하기 위한 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 인터페이스를 제공합니다.

예제에서는 자동 도형에 대해 `true`와 함께 [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-)을 호출하고, 그룹 도형, 연결자 및 그림 프레임에 대해 동일한 잠금을 적용합니다. 연결자는 이동을 위해 [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-)을 사용하고, 그룹은 그룹화를 제한하기 위해 [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)도 사용합니다.

예제는 기존 PPTX 프레젠테이션을 로드하고, 각 슬라이드의 도형 컬렉션을 확인한 다음, 이러한 제한이 적용된 사본을 저장합니다. 네 가지 처리 유형 이외의 도형은 변경되지 않습니다. 루프는 그룹 내부의 자식 도형을 순회하지 않습니다.

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

### **Remove Protection**

도형 잠금을 제거하려면 해당 값을 `false`로 설정합니다. 다음 예제는 도형 잠금이 적용된 프레젠테이션을 로드하고, [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/)을 통해 선택, 이동 및 크기 조정 제한을 해제합니다. 또한 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-)에 `false`를 전달하여 그룹화 제한을 제거하고 프레젠테이션 사본을 저장합니다. 다른 잠금 설정은 그대로 유지됩니다.

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

### **Preserve a Picture Crop**

작업 디렉터리에 `photo.jpg`라는 사진을 배치합니다. 예제는 왼쪽에서 12%와 오른쪽에서 8%를 잘라낸 다음, 그림 프레임 잠금의 [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-)을 호출합니다. `true`를 전달하면 추가 크롭이 제한되고 기존 크롭이 보존됩니다.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

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

`PictureLocked.pptx`는 크롭 잠금을 `true`로 저장합니다. PowerPoint에서 사진을 선택하면 **Crop** 명령이 비활성화됩니다.

### **Keep a Diagram Grouped**

예제는 사각형과 화살표를 그룹화한 다음, 그룹 잠금에 대해 [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-)을 호출하여 다이어그램 구성 요소가 함께 유지되도록 합니다. 그룹 이동이나 구성 요소 채우기 변경과 같은 다른 편집은 계속 사용할 수 있습니다.

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

`DiagramLocked.pptx`는 언그룹 잠금을 `true`로 저장합니다. PowerPoint에서 전체 다이어그램을 선택하면 **Ungroup** 명령이 비활성화됩니다.

### **Report Existing Shape Locks**

템플릿을 검토하려면 열어 각 도형의 잠금 객체를 읽습니다. [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) 메서드는 해당 객체의 모든 플래그가 비활성화된 경우 `true`를, 하나라도 활성화된 경우 `false`를 반환합니다. 그룹과 그 자식은 별도의 잠금 객체를 가지므로, 그룹에 잠금이 없더라도 자식을 검사해야 합니다.

이 예제는 자동 도형, 그림 프레임 및 그룹에 대한 이동을 확인하고, 그림에 대한 크롭 및 그룹에 대한 언그룹을 확인합니다. 보고서는 인식된 활성 플래그를 나열하고 검사하지 않은 도형 유형에는 표시하지 않습니다.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
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
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
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

예를 들어 `Sample.pptx`의 슬라이드 1에 언그룹 잠금이 설정된 `Layout`이라는 그룹이 있고, 그 안에 크롭 잠금이 설정된 `Photo` 그림이 있으며, 잠금이 없는 `Free` 사각형이 있다고 가정합니다. 보고서는 `Free`를 건너뛰고 다음 두 줄을 출력합니다:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

보고서는 저장된 도형 수준 편집 플래그를 읽을 뿐이며 프레젠테이션을 저장하거나 변경하지 않습니다. 문서 수준 쓰기 보호는 별도 설정이며, 각 플래그의 적용 여부는 편집기에 따라 달라집니다.

### **Conclusion**

Aspose.Slides for Java를 사용하면 개별 도형에 대해 특정 편집 작업을 제한하거나 슬라이드 전체에 동일한 제한을 적용할 수 있습니다. 각 도형 유형이 지원하는 잠금을 선택하고, 제한을 제거해야 할 경우 값을 `false`로 설정하십시오.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

예. 도형 잠금은 특정 편집 작업을 제한하고, [password protection](/slides/ko/java/password-protected-presentation/)은 프레젠테이션을 열거나 수정하는 것을 제한할 수 있습니다. 두 기능을 동일 파일에서 동시에 사용할 수 있습니다.

**Can I restrict editing on specific slides without affecting others?**

예. 선택한 슬라이드의 도형에만 잠금을 적용하면 다른 슬라이드의 잠금 설정은 변경되지 않습니다.

**How can I apply locks to individual shapes inside a group?**

그룹의 [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) 메서드가 반환하는 컬렉션을 순회하면서 각 자식 도형에 적절한 잠금을 적용합니다. 중첩된 그룹이 있는 경우에도 보고 예제와 같은 순회를 반복합니다.