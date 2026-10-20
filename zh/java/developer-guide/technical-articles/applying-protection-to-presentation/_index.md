---
title: 使用 Java 中的形状锁定限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止修改
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小调整
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

Aspose.Slides for Java 的常见用途是在自动化工作流中创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户收到这些演示文稿时，限制对形状的更改可以帮助保持预期的布局和内容。

本文解释了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁定。这些锁定允许您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件构成。在 Aspose.Slides for Java 中，幻灯片上的每个元素都由实现 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 接口是形状锁定的基础接口。Aspose.Slides for Java 提供以下锁定接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 锁定连接线形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 中应用锁定，需要遍历其幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

形状锁定限制选择、移动和调整大小等操作。它们不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for Java 提供了用于操作幻灯片上形状的 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 接口。

示例对自动形状调用 [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) 和 [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) 并传入 `true`，对组合形状、连接线和图片框使用等效的锁定。连接线使用 [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 进行移动；组合形状还使用 [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合中的形状，并保存一个已应用这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组合内部的子形状。

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

要移除形状锁定，只需将其值设为 `false`。下面的示例加载一个带有形状锁定的演示文稿，并通过 [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 和 [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 清除选择、移动和缩放限制。它还通过将 `false` 传递给 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 来移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **结论**

Aspose.Slides for Java 允许您限制对单个形状的特定编辑操作，或在整篇幻灯片中应用相同的限制。请选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一个演示文稿中同时使用形状锁定和密码保护吗？**

可以。形状锁定限制特定的编辑操作，而 [密码保护](/slides/zh/java/password-protected-presentation/) 可以限制演示文稿的打开或修改。您可以在同一个文件中同时使用两者。

**我可以在不影响其他幻灯片的情况下限制对特定幻灯片的编辑吗？**

可以。仅对所选幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**我如何对组内的单个形状应用锁定？**

遍历组的 [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) 方法返回的集合，并对每个子形状应用相应的锁。对任何嵌套的组重复此操作。上述示例仅处理幻灯片的形状集合，因此未对组内的单个成员设置锁定。