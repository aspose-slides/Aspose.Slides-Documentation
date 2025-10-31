---
title: 使用形状锁在 Python 中防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 70
url: /zh/python-net/applying-protection-to-presentation/
keywords:
- 防止编辑
- 保护免受编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定尺寸
- 锁定分组
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，保护演示文稿安全的同时实现受控编辑并加速交付。"
---

## **背景**

Aspose.Slides 的常见用法是创建、更新并保存 Microsoft PowerPoint (PPTX) 演示文稿，以实现自动化工作流。使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此如何防止它们被编辑是一个常见关注点。确保自动生成的演示文稿保留原始的格式和内容非常重要。

本文阐述了演示文稿和幻灯片的结构以及 Aspose.Slides for Python 如何对演示文稿应用保护并随后移除保护。它为开发人员提供了一种控制其应用程序生成的演示文稿使用方式的方法。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及其他用于构建演示文稿的元素组成。在 Aspose.Slides for Python 中，幻灯片上的每个元素都由继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的对象表示。

PPTX 的结构较为复杂，所以不像 PPT 那样可以对所有类型的形状使用通用锁，不同形状类型需要不同的锁。`[BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/)` 类是 PPTX 的通用锁定类。Aspose.Slides for Python 在 PPTX 中支持以下类型的锁：

- `[AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)` 锁定自动形状。  
- `[ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/)` 锁定连接线形状。  
- `[GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/)` 锁定图形对象。  
- `[GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)` 锁定组合形状。  
- `[PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/)` 锁定图片框。  

对 `[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)` 对象中所有形状对象执行的任何操作，都会应用到整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for Python 提供了 `[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)` 类来处理幻灯片上的形状。

正如前文所述，每个形状类都有对应的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状不能被选中（通过鼠标点击或其他选择方式），并且不能被移动或调整大小。

下面的代码示例对演示文稿中的所有形状类型应用保护。

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

要解锁形状，只需将已应用锁的值设为 `False`。下面的代码示例展示了如何在已锁定的演示文稿中解锁形状。

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

Aspose.Slides 为演示文稿中的形状提供了多种保护选项。您可以锁定单个形状，或遍历演示文稿中的所有形状并逐一锁定，从而有效地保护整个文件。通过将锁的值设为 `False` 可以移除保护。

## **常见问题解答**

**我可以在同一个演示文稿中同时使用形状锁和密码保护吗？**

可以。锁定限制文件内部对象的编辑，而[密码保护](/slides/zh/python-net/password-protected-presentation/) 控制打开和/或保存更改的权限。这两种机制相辅相成，共同工作。

**我可以仅对特定幻灯片限制编辑而不影响其他幻灯片吗？**

可以。只需对选定幻灯片上的形状应用锁，其他幻灯片仍保持可编辑状态。

**形状锁是否适用于组合对象和连接线？**

是的。针对组合、连接线、图形对象以及其他形状类别，均提供了专用的锁类型。