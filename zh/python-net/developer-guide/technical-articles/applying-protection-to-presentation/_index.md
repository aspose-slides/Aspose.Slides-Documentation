---
title: 为演示文稿应用保护
type: docs
weight: 70
url: /zh/python-net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slides 的一个常见用途是在自动化工作流中创建、更新和保存 Microsoft PowerPoint 2007（PPTX）演示文稿。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出演示文稿。保护这些演示文稿不被编辑是一个常见问题。自动生成的演示文稿保持其原始格式和内容是很重要的。

本文解释了[演示文稿和幻灯片是如何构建的](/slides/zh/python-net/applying-protection-to-presentation/)，以及 Aspose.Slides for Python via .NET 如何[对演示文稿应用保护](/slides/zh/python-net/applying-protection-to-presentation/)，然后[从演示文稿中移除保护](/slides/zh/python-net/applying-protection-to-presentation/)。此功能是 Aspose.Slides 独有的，并且在撰写本文时，尚不在 Microsoft PowerPoint 中提供。它为开发人员提供了一种控制其应用程序创建的演示文稿如何使用的方法。

{{% /alert %}} 
## **幻灯片的组成**
PPTX 幻灯片由多个组件组成，例如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器和用于构建演示文稿的各种其他元素。

在 Aspose.Slides for Python via .NET 中，幻灯片上的每个元素都被转换为 Shape 对象。换句话说，幻灯片上的每个元素要么是一个 Shape 对象，要么是从 Shape 对象派生的对象。

PPTX 的结构很复杂，因此与 PPT 不同，在 PPT 中可以对所有类型的形状使用通用锁，PPTX 中的不同形状类型有不同类型的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for Python via .NET 支持以下类型的锁：

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。

对演示文稿对象中的所有 Shape 对象执行的任何操作都将应用于整个演示文稿。
## **应用和移除保护**
应用保护确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。
### **对 PPTX 形状应用保护**
Aspose.Slides for Python via .NET 提供了 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个相关的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状不能被选择（通过鼠标单击或其他选择方法），也不能被移动或调整大小。

以下代码示例将保护应用于演示文稿中的所有形状类型。

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    # ISlide 对象用于访问演示文稿中的幻灯片
    slide = pres.slides[0]

    # 遍历演示文稿中的所有幻灯片
    for slide in pres.slides:
        for shape in slide.shapes:
            # 如果形状是自动形状
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                # 应用形状锁
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            # 如果形状是组合形状
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                # 应用形状锁
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            # 如果形状是连接器
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                # 应用形状锁
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            # 如果形状是图片框
            elif type(shape) is slides.PictureFrame:
                # 类型转换为图片框形状并获取图片框形状锁
                picture_lock = shape.shape_lock

                # 应用形状锁
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    # 保存演示文稿文件
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **移除保护**
使用 Aspose.Slides for Python via .NET 应用的保护只能通过 Aspose.Slides for Python via .NET 移除。要解锁形状，请将应用的锁的值设置为 false。以下代码示例演示了如何在已锁定的演示文稿中解锁形状。

```py
import aspose.slides as slides

# 打开所需的演示文稿
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                # 应用形状锁
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                # 应用形状锁
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                # 应用形状锁
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                # 应用形状锁
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    # 保存演示文稿文件
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **总结**
{{% alert color="primary" %}} 

Aspose.Slides 提供了多种选项用于为演示文稿中的形状应用保护。可以锁定特定形状，或遍历演示文稿中的所有形状并有效地锁定所有形状，以锁定演示文稿。

只有 Aspose.Slides for Python via .NET 可以从之前受保护的演示文稿中移除保护。通过将锁的值设置为 false 来移除保护。

{{% /alert %}} 