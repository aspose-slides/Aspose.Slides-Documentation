---
title: 使用形状锁在 Python 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 70
url: /zh/python-net/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小调整
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

在 Aspose.Slides for Python via .NET 中，一个常见的用法是创建、更新和保存 PowerPoint (PPTX) 演示文稿，作为自动化工作流的一部分。当用户收到这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文档说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可以限制对单个形状的特定编辑操作。

## **幻灯片的组成**

幻灯片由诸如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素组成。在 Aspose.Slides for Python via .NET 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 类是形状锁的基类。Aspose.Slides for Python via .NET 提供了以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 上应用锁定，遍历其幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

形状锁限制诸如选择、移动和调整大小等操作。它们不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python via .NET 提供了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类来处理幻灯片上的形状。

示例为自动形状设置 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) 和 [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) 为 `True`，并对组合形状、连接线和图片框使用等效的锁定。连接线使用 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) 控制移动；组合形状还使用 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 限制分组。

该示例加载已有的 PPTX 演示文稿，检查每个幻灯片的形状集合，并保存一个应用了这些限制的副本。未在上述四种类型中的形状保持不变。循环不会遍历组合内部的子形状。

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **移除保护**

要移除形状锁，只需将其值设为 `False`。下面的示例加载带有形状锁的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 清除选择、移动和调整大小的限制。它还会清除 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 并保存演示文稿的副本。其他锁定设置保持不变。

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **结论**

Aspose.Slides for Python via .NET 让您能够限制对单个形状的特定编辑操作，或在多个幻灯片上应用相同的限制。选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `False`。

## **FAQ**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而 [password protection](/slides/zh/python-net/password-protected-presentation/) 可以限制打开或修改演示文稿。两者可以在同一个文件中共存。

**我能否仅对特定幻灯片进行编辑限制，而不影响其他幻灯片？**

可以。仅在选定的幻灯片上的形状上应用锁定，这不会改变其他幻灯片的锁定设置。

**如何对组合内部的单个形状应用锁定？**

遍历该组合的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) 集合，对每个子形状应用相应的锁定。对任何嵌套的组合重复此操作。上面的示例仅处理幻灯片的形状集合，因此未对组合成员单独设置锁定。