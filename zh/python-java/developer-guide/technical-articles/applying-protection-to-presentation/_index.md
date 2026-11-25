---
title: 使用形状锁在 Python 中限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 60
url: /zh/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

Aspose.Slides for Python via Java 的常见用途是创建、更新并保存 PowerPoint (PPTX) 演示文稿，作为自动化工作流的一部分。当用户接收这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可以让您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for Python via Java 中，幻灯片上的每个元素都由一个继承自 [形状](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 类的对象表示。

不同的形状类型提供不同的锁定选项。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) 类是形状锁的基类。Aspose.Slides for Python via Java 提供以下锁定类：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 应用锁定，请遍历其幻灯片并在每个受支持的形状上设置相应的锁定。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单个编辑操作。文件加密和文档级写入保护是单独的 [演示文稿保护设置](/slides/zh/python-java/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python via Java 提供了用于处理幻灯片上形状的 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 类。

示例对自动形状调用 [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) 和 [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) 并传入 `True`，对组合形状、连接线和图片框使用等效的锁定。连接线使用 [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) 来控制移动；组合形状还使用 [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合中的形状，并保存一个应用了这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组内部的子形状。

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

要移除形状锁，将其值设为 `False`。下面的示例加载一个带有形状锁的演示文稿，并通过 [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 和 [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 清除选择、移动和大小调整的限制。它还通过将 `False` 传递给 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 来移除分组限制，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **保留图片裁剪**

在工作目录中放置一张名为 `photo.jpg` 的照片。示例从左侧裁剪 12%，右侧裁剪 8%，然后调用 [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) 并传入 `True` 以保留裁剪。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在 `PictureLocked.pptx` 中，PowerPoint 在选中照片时会禁用 **Crop** 命令。

### **保持图表分组**

示例将矩形和箭头组合，然后调用 [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) 并传入 `True` 以保持这两个形状在一起。您仍然可以移动该组或更改组件的填充。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在 `DiagramLocked.pptx` 中，PowerPoint 在选中整个图表时会禁用 **Ungroup** 命令。

### **报告已存在的形状锁**

要审查模板，打开它并读取每个形状的锁对象。[getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) 方法在该对象的所有标志均被禁用时返回 `True`，在至少有一个标志被启用时返回 `False`。组合形状及其子形状拥有独立的锁对象，因此即使组合没有锁，也要检查子形状。

此示例检查自动形状、图片框和组合的移动。它还检查图片的裁剪以及组合的取消分组。报告列出它识别的已启用标志，并标记未检查的形状类型。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

假设 `Sample.pptx` 的第 1 张幻灯片包含一个名为 `Layout`、已锁定取消分组的组合，其中有一个名为 `Photo`、已锁定裁剪的图片，以及一个未锁定的矩形名为 `Free`。报告会跳过 `Free` 并打印以下两行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

报告读取存储的形状级编辑标志，而不更改它们或保存演示文稿。文档级写入保护是单独的设置，每个标志的强制执行取决于编辑器。

### **结论**

Aspose.Slides for Python via Java 允许您限制单个形状的特定编辑操作，或在整套幻灯片中应用相同的限制。请选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `False`。

## **常见问题**

**我可以在同一个演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁会限制特定的编辑操作，而 [密码保护](/slides/zh/python-java/password-protected-presentation/) 可以限制演示文稿的打开或修改。您可以在同一文件中同时使用两者。

**我可以仅对特定幻灯片限制编辑而不影响其他幻灯片吗？**

可以。仅对选定幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**我如何对组内的单个形状应用锁定？**

遍历组的 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，并对每个子形状应用相应的锁定。对任何嵌套的组合重复此操作，遵循报告示例中的遍历方式。