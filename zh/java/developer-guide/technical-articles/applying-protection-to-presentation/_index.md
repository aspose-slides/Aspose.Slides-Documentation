---
title: 使用形状锁防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 60
url: /zh/java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小
- 锁定分组
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，保护演示文稿的安全，同时允许受控编辑并加快交付速度。"
---

## **背景**

Aspose.Slides 的常见用法是创建、更新和保存 Microsoft PowerPoint (PPTX) 演示文稿，作为自动化工作流的一部分。以这种方式使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此保护它们不被编辑是一个常见的关注点。确保自动生成的演示文稿保留其原始格式和内容非常重要。

本文说明了演示文稿和幻灯片的结构，以及 Aspose.Slides for Java 如何对演示文稿应用保护并随后移除保护。它为开发人员提供了一种控制其应用程序生成的演示文稿使用方式的方法。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for Java 中，幻灯片上的每个元素都由实现了 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

PPTX 的结构十分复杂，因此不同于 PPT（在 PPT 中可以使用通用锁来锁定所有类型的形状），不同的形状类型需要不同的锁。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 接口是 PPTX 的通用锁定类。Aspose.Slides for Java 在 PPTX 中支持以下类型的锁：

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 锁定连接器形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 锁定图片框。  

对 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 对象中的所有形状对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的实用技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for Java 提供了 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 接口以在幻灯片上处理形状。

如前所述，每个形状类都有一个对应的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁可确保形状不能被选中（通过鼠标点击或其他选择方式），并且不能被移动或调整大小。

下面的代码示例对演示文稿中的所有形状类型应用保护。
```java
// 实例化表示 PPTX 文件的 Presentation 类。
Presentation presentation = new Presentation("Sample.pptx");

// 遍历演示文稿中的所有幻灯片。
for (ISlide slide : presentation.getSlides()) {

    // 遍历幻灯片中的所有形状。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 将形状类型转换为自动形状并获取其形状锁。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // 将形状类型转换为组合形状并获取其形状锁。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // 将形状类型转换为连接器形状并获取其形状锁。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // 将形状类型转换为图片框并获取其形状锁。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// 保存演示文稿文件。
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **移除保护**

要解锁形状，只需将已应用锁的值设为 `false`。下面的代码示例展示了如何在已锁定的演示文稿中解锁形状。
```java
// 实例化表示 PPTX 文件的 Presentation 类。
Presentation presentation = new Presentation("ProtectedSample.pptx");

// 遍历演示文稿中的所有幻灯片。
for (ISlide slide : presentation.getSlides()) {

    // 遍历幻灯片中的所有形状。
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // 将形状强制转换为自动形状并获取其形状锁。
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // 将形状强制转换为组合形状并获取其形状锁。
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // 将形状强制转换为连接器形状并获取其形状锁。
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // 将形状强制转换为图片框并获取其形状锁。
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// 保存演示文稿文件。
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **结论**

Aspose.Slides 提供了多种在演示文稿中保护形状的选项。您可以锁定单个形状，或遍历演示文稿中的所有形状并逐一锁定，以有效地保护整个文件。通过将锁的值设为 `false` 可以移除保护。

## **常见问题**

**我可以在同一个演示文稿中同时使用形状锁和密码保护吗？**

是的。锁定限制对文件内部对象的编辑，而 [密码保护](/slides/zh/java/password-protected-presentation/) 控制打开和/或保存更改的访问。这些机制相互补充并一起工作。

**我可以限制特定幻灯片的编辑而不影响其他幻灯片吗？**

是的。对选定幻灯片上的形状应用锁定；其余幻灯片仍保持可编辑。

**形状锁适用于组合对象和连接器吗？**

是的。针对组合、连接器、图形对象以及其他形状类型提供了专用的锁类型。