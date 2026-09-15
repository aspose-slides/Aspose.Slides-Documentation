---
title: 使用形状锁防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 60
url: /zh/python-java/applying-protection-to-presentation/
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
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，保障演示文稿安全，同时实现受控编辑和更快交付。"
---
## **背景**

Aspose.Slides 的一个常见用法是作为自动化工作流的一部分创建、更新并保存 Microsoft PowerPoint (PPTX) 演示文稿。以这种方式使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此保护它们不被编辑是一个常见的关注点。确保自动生成的演示文稿保留其原始格式和内容非常重要。

本文阐述了演示文稿和幻灯片的结构，以及 Aspose.Slides for Python via Java 如何对演示文稿应用保护并随后移除保护。它为开发人员提供了一种方式，来控制其应用程序生成的演示文稿的使用方式。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for Python via Java 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 类的对象表示。

PPTX 的结构很复杂，因此不同于 PPT（可以对所有类型的形状使用通用锁），不同的形状类型需要不同的锁。[BaseShapeLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseshapelock/) 类是 PPTX 的通用锁定类。Aspose.Slides for Python via Java 在 PPTX 中支持以下类型的锁：

- [AutoShapeLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframelock/) 锁定图片框。  

对 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 对象中所有形状对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python via Java 提供了用于在幻灯片上操作形状的 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 类。

如前所述，每个形状类都有对应的形状锁定类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁可确保形状无法被选中（通过鼠标点击或其他选择方式），并且不能被移动或调整大小。

下面的代码示例对演示文稿中的所有形状类型应用保护。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation("Sample.pptx")
try:
    # 遍历演示文稿中的所有幻灯片。
    for slide in presentation.getSlides():
        # 遍历幻灯片中的所有形状。
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

    # 保存演示文稿文件。
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **移除保护**

要解锁形状，需要将已应用的锁的值设为 `False`。以下代码示例展示了如何在已锁定的演示文稿中解锁形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation("ProtectedSample.pptx")
try:
    # 遍历演示文稿中的所有幻灯片。
    for slide in presentation.getSlides():
        # 遍历幻灯片中的所有形状。
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

    # 保存演示文稿文件。
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **结论**

Aspose.Slides 提供了多种方式来保护演示文稿中的形状。您可以锁定单个形状，或遍历演示文稿中的所有形状并逐一锁定，从而有效地保护整个文件。通过将锁的值设为 `False`，即可移除保护。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。锁定限制文件内部对象的编辑，而 [password protection](/slides/zh/python-java/password-protected-presentation/) 控制打开和/或保存更改的访问权限。这两种机制相互补充并协同工作。

**我可以仅限制特定幻灯片的编辑，而不影响其他幻灯片吗？**

可以。对选定幻灯片上的形状应用锁定，其余幻灯片仍保持可编辑。

**形状锁是否适用于组合对象和连接线？**

可以。针对组合、连接线、图形对象以及其他形状类型提供了专用的锁定类型。