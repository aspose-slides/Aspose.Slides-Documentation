---
title: 在 Node.js 中使用形状锁限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/nodejs-java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 保护免受编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定缩放
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、缩放和分组。"
---
## **概述**

在 Aspose.Slides for Node.js via Java 中的常见用法是创建、更新并保存 PowerPoint (PPTX) 演示文稿，以实现自动化工作流的一部分。当用户收到这些演示文稿时，限制对形状的更改有助于保留预期的布局和内容。

本文说明了形状在 PPTX 演示文稿中是如何组织的以及如何应用和移除形状锁定。这些锁定可以让您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for Node.js via Java 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) 类是形状锁的基类。Aspose.Slides for Node.js via Java 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 中应用锁定，需要遍历其幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

形状锁限制诸如选择、移动和调整大小等操作。它们并不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for Node.js via Java 提供了用于在幻灯片上操作形状的 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 类。

示例对自动形状调用 [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) 和 [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) 并传入 `true`，对组合形状、连接线和图片框使用等效的锁定。连接线使用 [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) 来控制移动；组合形状还使用 [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合中的形状，并将这些限制应用后保存为副本。超出上述四种类型的形状保持不变。循环不会遍历组合内的子形状。

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

### **移除保护**

要移除形状锁，只需将其值设为 `false`。以下示例加载带有形状锁的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 清除选择、移动和调整大小的限制。它还通过向 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 传入 `false` 来移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **结论**

Aspose.Slides for Node.js via Java 允许您限制对单个形状的特定编辑操作，或在所有幻灯片上应用相同的限制。请选择每种形状类型支持的锁定，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而 [密码保护](/slides/zh/nodejs-java/password-protected-presentation/) 可以限制打开或修改演示文稿。您可以在同一文件中同时使用两者。

**我可以仅在特定幻灯片上限制编辑而不影响其他幻灯片吗？**

可以。只对所选幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的 [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，并对每个子形状应用相应的锁定。对任何嵌套的组重复此操作。上面的示例仅处理幻灯片的形状集合，因此未对组内的单个成员设置锁定。