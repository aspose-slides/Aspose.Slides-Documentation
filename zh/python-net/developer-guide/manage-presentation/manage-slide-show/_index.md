---
title: 在 Python 中管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/python-net/manage-slide-show/
keywords:
- 放映类型
- 演讲者展示
- 个人浏览
- 自助终端浏览
- 放映选项
- 持续循环
- 无旁白放映
- 无动画放映
- 笔颜色
- 放映幻灯片
- 自定义放映
- 推进幻灯片
- 手动
- 使用计时
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何通过 .NET 在 Aspose.Slides for Python 中管理幻灯片放映。轻松控制 PPT、PPTX 和 ODP 格式的幻灯片切换、计时等功能。"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和展示专业演示文稿的关键工具。本节中最重要的功能之一是 **Set Up Show**，它允许您根据特定的情况和受众定制演示文稿，确保灵活性和便利性。使用此功能，您可以选择放映类型（例如，由演讲者展示、个人浏览或自助终端浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。这一步对于使您的演示更有效、更专业至关重要。

`slide_show_settings` 是 [演示文稿](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的属性，类型为 [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/)，用于管理 PowerPoint 演示文稿中的幻灯片放映设置。本文将介绍如何使用此属性来配置和控制幻灯片放映设置的各个方面。 

## **选择放映类型**

`SlideShowSettings.slide_show_type` 定义了幻灯片放映的类型，可为以下类的实例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/)、或 [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/)。使用此属性可以根据不同的使用场景（如自动化自助终端或手动演示）调整演示文稿。

下面的代码示例创建了一个新演示文稿，并将放映类型设置为“个人浏览”，且不显示滚动条。
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **启用放映选项**

`SlideShowSettings.loop` 决定幻灯片放映是否循环播放，直至手动停止。这对于需要持续运行的自动化演示非常有用。`SlideShowSettings.show_narration` 决定放映过程中是否播放语音旁白，适用于为观众提供语音指导的自动化演示。`SlideShowSettings.show_animation` 决定是否播放添加到幻灯片对象的动画，以呈现完整的视觉效果。

下面的代码示例创建了一个新演示文稿并循环播放幻灯片放映。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **选择要放映的幻灯片**

`SlideShowSettings.slides` 属性允许您选择在演示期间要显示的幻灯片范围。当只需展示演示文稿的部分内容而非全部幻灯片时，这非常有用。下面的代码示例创建了一个新演示文稿，并将幻灯片范围设置为显示第 `2` 张到第 `9` 张幻灯片。
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **使用预设计时**

`SlideShowSettings.use_timings` 属性允许您启用或禁用对每张幻灯片的预设计时。此功能可用于自动按预定义的显示时长切换幻灯片。下面的代码示例创建了一个新演示文稿，并禁用计时的使用。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **显示媒体控制**

`SlideShowSettings.show_media_controls` 属性决定在放映包含多媒体内容（如视频或音频）时，是否在幻灯片放映期间显示媒体控制（如播放、暂停和停止）。当您希望演示者在演示过程中能够控制媒体播放时，这非常有用。

下面的代码示例创建了一个新演示文稿，并启用媒体控制的显示。
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**我可以将演示文稿保存为直接以放映模式打开吗？**

可以。将文件保存为 PPSX 或 PPSM 格式；这些格式在 PowerPoint 中打开时会直接进入放映模式。在 Aspose.Slides 中，可在[导出期间](/slides/zh/python-net/save-presentation/)选择相应的保存格式。

**我可以在不从文件中删除幻灯片的情况下将其从放映中排除吗？**

可以。将幻灯片标记为[隐藏](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/)。隐藏的幻灯片仍保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能否播放幻灯片放映或在屏幕上控制实时演示？**

不能。Aspose.Slides 用于编辑、分析和转换演示文稿文件；实际的播放由 PowerPoint 等查看器应用程序处理。