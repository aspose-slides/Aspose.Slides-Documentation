---
title: 在 .NET 中管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/net/manage-slide-show/
keywords:
- 放映类型
- 演讲者主持
- 个人浏览
- 展台浏览
- 放映选项
- 持续循环
- 无旁白放映
- 无动画放映
- 笔颜色
- 放映幻灯片
- 自定义放映
- 前进幻灯片
- 手动
- 使用计时
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中管理幻灯片放映。轻松控制幻灯片切换、计时等功能，适用于 PPT、PPTX 和 ODP 格式。"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和呈现专业演示文稿的关键工具。此部分最重要的功能之一是 **Set Up Show**，它允许您根据特定的条件和观众定制演示文稿，确保灵活性和便利性。使用此功能，您可以选择放映类型（例如，由演讲者主持、个人浏览或在展台浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。此准备步骤对于使您的演示更加有效和专业至关重要。

`SlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的属性，类型为 [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)，可用于管理 PowerPoint 演示文稿中的幻灯片放映设置。本文将探讨如何使用此属性来配置和控制幻灯片放映设置的各个方面。 

## **选择放映类型**

`SlideShowSettings.SlideShowType` 定义了幻灯片放映的类型，可以是以下类的实例：[PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/)或[BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/)。使用此属性可以使演示文稿适应不同的使用场景，例如自动化展台或手动演示。

以下代码示例创建一个新演示文稿，并将放映类型设置为 “Browsed by an individual”，且不显示滚动条。
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **启用放映选项**

`SlideShowSettings.Loop` 决定幻灯片放映是否应循环重复，直至手动停止。这对于需要连续运行的自动化演示非常有用。`SlideShowSettings.ShowNarration` 决定在放映期间是否播放语音旁白。它对于包含面向观众的语音指导的自动化演示很有用。`SlideShowSettings.ShowAnimation` 决定是否播放添加到幻灯片对象的动画。这对于提供完整的视觉效果很有用。

以下代码示例创建一个新演示文稿并循环放映。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **选择要显示的幻灯片**

`SlideShowSettings.Slides` 属性允许您选择在演示期间要显示的幻灯片范围。当您只需要展示演示文稿的某一部分而非全部幻灯片时，这非常有用。以下代码示例创建一个新演示文稿，并将幻灯片范围设置为显示第 `2` 到 `9` 张幻灯片。
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **使用计时**

`SlideShowSettings.UseTimings` 属性允许您启用或禁用对每张幻灯片的预设计时的使用。这对于使用预定义显示持续时间自动播放幻灯片非常有用。以下代码示例创建一个新演示文稿并禁用计时的使用。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **显示媒体控制**

`SlideShowSettings.ShowMediaControls` 属性决定在播放多媒体内容（例如视频或音频）时，幻灯片放映期间是否显示媒体控制（如播放、暂停和停止）。当您希望在演示期间为演示者提供媒体播放控制时，这非常有用。

以下代码示例创建一个新演示文稿并启用媒体控制的显示。
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **常见问题**

**我可以将演示文稿保存为直接以放映模式打开吗？**

是的。将文件保存为 PPSX 或 PPSM；这些格式在 PowerPoint 中打开时会直接进入幻灯片放映模式。在 Aspose.Slides 中，选择相应的保存格式[在导出时](/slides/zh/net/save-presentation/)。

**我可以在不从文件中删除的情况下将单个幻灯片排除在放映之外吗？**

是的。将幻灯片标记为[Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/)。隐藏的幻灯片仍然保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能够播放幻灯片放映或在屏幕上控制实时演示吗？**

不能。Aspose.Slides 仅用于编辑、分析和转换演示文稿文件，实际播放由 PowerPoint 等查看器应用程序负责。