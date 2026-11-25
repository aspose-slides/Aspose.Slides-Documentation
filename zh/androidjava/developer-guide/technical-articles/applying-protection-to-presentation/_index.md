---
title: 使用形状锁在 Android 上限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/androidjava/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定调整大小
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、调整大小和分组。"
---
## **概述**

Aspose.Slides for Android via Java 的常见用法是创建、更新并保存 PowerPoint（PPTX）演示文稿，以作为自动化工作流的一部分。当用户收到这些演示文稿时，限制形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可让您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件构成。在 Aspose.Slides for Android via Java 中，幻灯片上的每个元素都由实现 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) 接口是形状锁的基接口。Aspose.Slides for Android via Java 提供了以下锁接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) 用于锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 用于锁定连接线形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 用于锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) 用于锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 用于锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 中应用锁，遍历其幻灯片并在每个受支持的形状上设置相应的锁。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单独的编辑操作。文件加密和文档级写入保护是独立的 [presentation protection settings](/slides/zh/androidjava/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for Android via Java 提供了 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 接口来操作幻灯片上的形状。

示例对自动形状调用 [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) 和 [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) 并将值设为 `true`，对组合形状、连接线和图片框使用等效的锁。连接线使用 [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 控制移动；组合形状还使用 [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每张幻灯片的形状集合中的形状，并保存一个已应用这些限制的副本。未在四种受处理类型之列的形状保持不变。循环不会遍历组合内部的子形状。

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

### **移除保护**

要移除形状锁，只需将其值设为 `false`。下面的示例加载带有形状锁的演示文稿，并通过 [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 和 [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 清除选择、移动和大小调整限制。它还通过向 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 传入 `false` 来移除分组限制，并保存演示文稿的副本。其他锁设置保持不变。

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

### **保留图片裁剪**

在工作目录中放置名为 `photo.jpg` 的照片。示例将左侧裁剪 12%，右侧裁剪 8%，随后对图片框的锁调用 [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) 并传入 `true`，从而限制进一步裁剪并保留已有的裁剪效果。

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

`PictureLocked.pptx` 将裁剪锁存为 `true`。在 PowerPoint 中，选中该照片时 **Crop** 命令会被禁用。

### **保持图表分组**

示例将一个矩形和一条箭头组合，然后对组合的锁调用 [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) 以保持图表组件的整体性。其他编辑操作，如移动组合或更改组件的填充，仍然可用。

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

`DiagramLocked.pptx` 将取消分组锁存为 `true`。在 PowerPoint 中，选中整个图表时 **Ungroup** 命令会被禁用。

### **报告现有形状锁**

要审查模板，打开它并读取每个形状的锁对象。调用 [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) 方法，当该对象的所有标志均为禁用时返回 `true`，只要至少有一个标志被启用则返回 `false`。组合及其子形状拥有各自的锁对象，因此即使组合没有锁，也需要检查其子形状。

本示例检查自动形状、图片框和组合的移动锁，还检查图片的裁剪锁以及组合的取消分组锁。报告列出它识别的已启用标志，并标记未检查的形状类型。

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

假设 `Sample.pptx` 的第 1 张幻灯片包含一个名为 `Layout`、已锁定取消分组的组合，其中有一个已锁定裁剪的图片 `Photo`，以及一个未锁定的矩形 `Free`。报告会跳过 `Free` 并输出以下两行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

报告读取存储的形状级编辑标志而不对其进行更改或保存演示文稿。文档级写入保护是单独的设置，实际执行每个标志取决于编辑器。

### **结论**

Aspose.Slides for Android via Java 使您能够对单个形状限制特定编辑操作，或在整套幻灯片中应用相同限制。请选择每种形状类型支持的锁，并在需要移除限制时将其值设为 `false`。

## **常见问答**

**我可以在同一个演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而 [password protection](/slides/zh/androidjava/password-protected-presentation/) 可以限制打开或修改演示文稿。两者可以在同一个文件中共存。

**我能否只在特定幻灯片上限制编辑而不影响其他幻灯片？**

可以。仅对选定幻灯片上的形状应用锁，这不会更改其他幻灯片的锁设置。

**如何对组合内部的单个形状应用锁？**

遍历组合的 [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) 方法返回的集合，对每个子形状应用相应的锁。对任何嵌套组合重复此操作，遵循报告示例中的遍历方式。