---
title: 添加幻灯片到演示文稿
type: docs
weight: 10
url: /python-net/add-slide-to-presentation/
keywords: "添加幻灯片到演示文稿, Python, Aspose.Slides"
description: "在 Python 中添加幻灯片到演示文稿"
---

## **添加幻灯片到演示文稿**
在讨论如何将幻灯片添加到演示文稿文件之前，让我们先讨论一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件都包含母版/版式幻灯片和其他普通幻灯片。这意味着演示文稿文件至少包含一个或多个幻灯片。重要的是要知道，没有幻灯片的演示文稿文件不被 Aspose.Slides for Python via .NET 支持。每个幻灯片都有一个唯一的 Id，所有普通幻灯片按零基索引指定的顺序排列。Aspose.Slides for Python via .NET 允许开发者向他们的演示文稿中添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过设置对演示文稿对象公开的 Slides（内容幻灯片对象的集合）属性的引用来实例化 [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 类。
- 通过调用 ISlideCollection 对象公开的 AddEmptySlide 方法，在内容幻灯片集合的末尾添加一个空幻灯片。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象写入演示文稿文件。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation() as pres:
    # 实例化 SlideCollection 类
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # 向幻灯片集合添加空幻灯片
        slds.add_empty_slide(pres.layout_slides[i])
        
    # 对新添加的幻灯片进行一些操作

    # 将 PPTX 文件保存到磁盘
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```