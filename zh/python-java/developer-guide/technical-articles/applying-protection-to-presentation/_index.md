---
title: 使用形状锁在 Python 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/python-java/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止修改
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定调整大小
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、调整大小和分组。"
---
## **背景**

在使用 Aspose.Slides for Python via Java 时，一个常见的用途是创建、更新并保存 PowerPoint (PPTX) 演示文稿，以实现自动化工作流。当用户收到这些演示文稿时，限制对形状的更改可以帮助保持预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁定。这些锁定允许您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素组成。在 Aspose.Slides for Python via Java 中，幻灯片上的每个元素都由继承自[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/)类是形状锁定的基类。Aspose.Slides for Python via Java 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 用于锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 用于锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 用于锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 用于锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 用于锁定图片框。  

要在整个[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)中应用锁定，遍历其每张幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

形状锁定限制诸如选择、移动和调整大小等操作。它们并不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python via Java 提供[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)类以操作幻灯片上的形状。

示例调用[setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked)和[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked)，对自动形状传入`True`，对组合形状、连接线和图片框使用等效的锁定。连接线使用[setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove)来限制移动；组合形状还使用[setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)来限制分组。

示例加载现有的 PPTX 演示文稿，检查每张幻灯片的形状集合，并保存一个已应用这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组合内部的子形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **移除保护**

要移除形状锁定，只需将其值设为`False`。以下示例加载一个带有形状锁定的演示文稿，并通过[AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)和[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/)清除选择、移动和调整大小的限制。它还通过将`False`传递给[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked)来移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **结论**

Aspose.Slides for Python via Java 让您能够对单个形状限制特定的编辑操作，或在整张幻灯片上应用相同的限制。选择每种形状类型支持的锁定，并在需要移除这些限制时将其值设为`False`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁定和密码保护吗？**

可以。形状锁定限制特定的编辑操作，而[password protection](/slides/zh/python-java/password-protected-presentation/)可以限制打开或修改演示文稿。两者可以在同一个文件中共存。

**我能否仅对特定幻灯片进行编辑限制而不影响其他幻灯片？**

可以。仅对选定幻灯片上的形状应用锁定，这不会更改其他幻灯片的锁定设置。

**如何对组合内部的单个形状应用锁定？**

遍历组合的[getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)方法返回的集合，并对每个子形状应用相应的锁定。对任何嵌套的组合重复此操作。上述示例仅处理幻灯片的形状集合，因此未对组合成员单独设置锁定。