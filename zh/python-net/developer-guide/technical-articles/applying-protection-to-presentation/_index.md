---
title: 使用形状锁在 Python 中防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 70
url: /zh/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，从而在确保演示文稿安全的同时，允许受控编辑并加快交付速度。"
---

## **背景**

Aspose.Slides 的常见用途是作为自动化工作流的一部分，创建、更新并保存 Microsoft PowerPoint (PPTX) 演示文稿。使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此保护这些文稿不被编辑是一个常见的关注点。确保自动生成的演示文稿保持其原始格式和内容非常重要。

本文说明了演示文稿和幻灯片的结构，以及 Aspose.Slides for Python 如何对演示文稿应用保护并随后移除保护。它为开发者提供了一种控制其应用程序生成的演示文稿使用方式的方法。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及其他用于构建演示文稿的元素组成。在 Aspose.Slides for Python 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的对象表示。

PPTX 的结构很复杂，因此不同于 PPT（在 PPT 中可以使用通用锁来锁定所有类型的形状），不同的形状类型需要不同的锁。[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) 类是 PPTX 的通用锁定类。Aspose.Slides for Python 在 PPTX 中支持以下类型的锁：

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) 锁定自动形状。  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) 锁定连接线形状。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) 锁定图形对象。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) 锁定组合形状。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) 锁定图片框。  

对 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象中所有形状对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有用技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python 提供了用于在幻灯片上操作形状的 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类。

如前所述，每个形状类都有对应的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状不能被选中（通过鼠标点击或其他选取方式），且不能被移动或调整大小。

以下代码示例对演示文稿中的所有形状类型应用保护。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("Sample.pptx") as presentation:
    # 遍历演示文稿中的所有幻灯片。
    for slide in presentation.slides:
        # 遍历幻灯片中的所有形状。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # 保存演示文稿文件。
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **移除保护**

要解锁形状，请将已应用锁的值设为 `False`。以下代码示例展示了如何在受锁定的演示文稿中解锁形状。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # 遍历演示文稿中的所有幻灯片。
    for slide in presentation.slides:
        # 遍历幻灯片中的所有形状。
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # 保存演示文稿文件。
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```


### **结论**

Aspose.Slides 提供了多种保护演示文稿中形状的选项。您可以锁定单个形状，或遍历演示文稿中的所有形状并逐一锁定，以有效保护整个文件。通过将锁的值设为 `False` 可以移除保护。

## **常见问题**

**我能在同一演示文稿中同时使用形状锁和密码保护吗？**

是的。锁定限制对文件内部对象的编辑，而 [password protection](/slides/zh/python-net/password-protected-presentation/) 控制对打开和/或保存更改的访问。这两种机制相互补充并协同工作。

**我能在不影响其他幻灯片的情况下，仅限制特定幻灯片的编辑吗？**

是的。对选定幻灯片上的形状应用锁定；其余幻灯片仍保持可编辑。

**形状锁是否适用于组合对象和连接线？**

是的。支持针对组合、连接线、图形对象以及其他形状类型的专用锁定。