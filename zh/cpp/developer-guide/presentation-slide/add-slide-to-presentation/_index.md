---
title: 在 C++ 中向演示文稿添加幻灯片
linktitle: 添加幻灯片
type: docs
weight: 10
url: /zh/cpp/add-slide-to-presentation/
keywords:
- 添加幻灯片
- 创建幻灯片
- 空白幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松向 PowerPoint 和 OpenDocument 演示文稿添加幻灯片——实现无缝、高效的秒级幻灯片插入。"
---

## **向演示文稿添加幻灯片**
在讨论向演示文稿文件添加幻灯片之前，让我们先了解一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件都包含母版/布局幻灯片以及其他普通幻灯片。这意味着一个演示文稿文件至少包含一个或多个幻灯片。需要注意的是，Aspose.Slides for C++ 不支持没有幻灯片的演示文稿文件。每个幻灯片都有唯一的 Id，所有普通幻灯片按照从零开始的索引顺序排列。Aspose.Slides for C++ 允许开发者向演示文稿中添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
- 通过设置对 Presentation 对象公开的 Slides（内容幻灯片对象集合）属性的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) 类。
- 调用 ISlideCollection 对象公开的 AddEmptySlide 方法，将空幻灯片添加到内容幻灯片集合的末尾。
- 对新添加的空幻灯片进行相应操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象写入演示文稿文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **常见问题**

**我可以在特定位置插入新幻灯片，而不是仅在末尾吗？**

可以。库支持幻灯片集合以及 [insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) 操作，您可以在所需索引处添加幻灯片，而不仅限于末尾。

**基于布局添加幻灯片时，主题/样式会被保留吗？**

会。布局会继承其母版的格式，新幻灯片会继承所选布局及其关联母版的格式。

**在添加幻灯片之前，新“空”演示文稿中存在什么幻灯片？**

新创建的演示文稿已经包含一个索引为零的空白幻灯片。这一点在计算插入索引时需要考虑。

**如果母版提供了多种选项，我该如何为新幻灯片选择“合适”的布局？**

通常选择与所需结构匹配的 [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/)（例如 [标题和内容、两个内容等](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)）。如果缺少此类布局，您可以先 [将其添加到母版](/slides/zh/cpp/slide-layout/)，然后使用它。