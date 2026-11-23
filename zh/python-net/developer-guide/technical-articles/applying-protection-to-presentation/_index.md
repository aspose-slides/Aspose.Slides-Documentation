---
title: 使用形状锁在 Python 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 70
url: /zh/python-net/applying-protection-to-presentation/
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
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

Aspose.Slides for Python via .NET 的一个常见用法是在自动化工作流中创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户收到这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可以限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素组成。在 Aspose.Slides for Python via .NET 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 类是形状锁的基类。Aspose.Slides for Python via .NET 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 锁定图片框。  

要跨整个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 应用锁定，遍历其幻灯片并在每个受支持的形状上设置相应的锁。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单个编辑操作。文件加密和文档级写保护是独立的[演示文稿保护设置](/slides/zh/python-net/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python via .NET 提供 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类以在幻灯片上处理形状。

示例将 [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)、[position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) 和 [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) 设置为 `True` 用于自动形状，并对组合形状、连接线和图片框使用等效的锁定。连接线使用 [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) 控制移动；组合形状还使用 [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 限制组合。

示例加载现有 PPTX 演示文稿，检查每张幻灯片的形状集合，并保存一个已应用这些限制的副本。未被上述四种类型处理的形状保持不变。循环不会遍历组内的子形状。

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

要移除形状锁，只需将其值设为 `False`。下面的示例加载一个带有形状锁的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 清除选择、移动和大小调整限制。它还清除 [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) 并保存演示文稿的副本。其他锁定设置保持不变。

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

### **保留图片裁剪**

在工作目录中放置名为 `photo.jpg` 的照片。示例将左侧裁剪 12%，右侧裁剪 8%，然后在图片框上设置 [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) 以保留裁剪。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` 将裁剪锁存为 `True`。在 PowerPoint 中，选中照片时 **Crop** 命令被禁用。

### **保持图表分组**

示例将矩形和箭头组合，然后在该组合本身上设置 [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) 以保持图表组件在一起。其他编辑操作，如移动组合或更改组件填充，仍然可用。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` 将取消分组锁存为 `True`。在 PowerPoint 中，选中整个图表时 **Ungroup** 命令被禁用。

### **结论**

Aspose.Slides for Python via .NET 让您可以限制单个形状的特定编辑操作，或在整个幻灯片中应用相同的限制。请选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `False`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而[密码保护](/slides/zh/python-net/password-protected-presentation/)可以限制打开或修改演示文稿。两者可在同一文件中同时使用。

**我能否仅在特定幻灯片上限制编辑，而不影响其他幻灯片？**

可以。只对选定幻灯片上的形状应用锁定，这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的[形状](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)集合，对每个子形状应用相应的锁定。对任何嵌套的组重复此操作。上述示例仅处理幻灯片的形状集合，因此未对组成员单独设置锁定。