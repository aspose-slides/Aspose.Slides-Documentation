---
title: 添加幻灯片到演示文稿
type: docs
weight: 10
url: /cpp/add-slide-to-presentation/
---

## **添加幻灯片到演示文稿**
在讨论如何将幻灯片添加到演示文稿文件之前，我们先讨论一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件包含主幻灯片 / 布局幻灯片和其他普通幻灯片。这意味着一个演示文稿文件包含至少一个或多个幻灯片。重要的是要知道，Aspose.Slides for C++ 不支持没有幻灯片的演示文稿文件。每个幻灯片都有唯一的 Id，所有普通幻灯片按零基索引指定的顺序排列。Aspose.Slides for C++ 允许开发者向他们的演示文稿添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过设置对演示文稿对象暴露的幻灯片（内容幻灯片对象集合）属性的引用来实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
- 通过调用 ISlideCollection 对象暴露的 AddEmptySlide 方法，将空幻灯片添加到内容幻灯片集合的末尾。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象写入演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}