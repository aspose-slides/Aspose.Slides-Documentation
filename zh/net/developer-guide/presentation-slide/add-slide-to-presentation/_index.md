---
title: 添加幻灯片到演示文稿
type: docs
weight: 10
url: /zh/net/add-slide-to-presentation/
keywords: "添加幻灯片到演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中添加幻灯片到演示文稿"
---

## **添加幻灯片到演示文稿**
在谈论如何向演示文稿文件中添加幻灯片之前，让我们先讨论一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件都包含母版/布局幻灯片和其他普通幻灯片。这意味着一个演示文稿文件至少包含一张或多张幻灯片。需要知道的是，Aspose.Slides for .NET 不支持没有幻灯片的演示文稿文件。每张幻灯片都有一个唯一的 Id，所有普通幻灯片按零基索引指定的顺序排列。Aspose.Slides for .NET 允许开发人员向他们的演示文稿中添加空幻灯片。要在演示文稿中添加空幻灯片，请遵循以下步骤：

- 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 通过设置对 Presentation 对象所公开的 Slides（内容幻灯片对象集合）属性的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) 类。
- 通过调用 ISlideCollection 对象所公开的 AddEmptySlide 方法，将空幻灯片添加到内容幻灯片集合的末尾。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 对象写入演示文稿文件。

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}