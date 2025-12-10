---
title: 在 C++ 中管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/cpp/manage-slide-show/
keywords:
- 放映类型
- 演讲者呈现
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
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中管理幻灯片放映。轻松控制 PPT、PPTX 和 ODP 格式的幻灯片切换、计时等。"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和呈现专业演示文稿的关键工具。 本节中最重要的功能之一是**Set Up Show**，它可以让您根据特定的条件和受众定制演示文稿，确保灵活性和便利性。 通过此功能，您可以选择放映类型（例如，由演讲者呈现、由个人浏览或在自助终端浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。 此准备步骤对于使演示更有效且更专业至关重要。

`get_SlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的方法，返回类型为 [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/) 的对象，您可以使用它管理 PowerPoint 演示文稿中的放映设置。 本文将探讨如何使用此方法配置和控制放映设置的各个方面。

## **选择放映类型**

`SlideShowSettings.set_SlideShowType` 定义了放映的类型，可以是以下类的实例：[PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/)，[BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/)，或 [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/)。 使用此方法可以让您根据不同的使用场景（如自动化自助终端或手动演示）调整演示文稿。

下面的代码示例创建一个新演示文稿，并将放映类型设置为“Browsed by an individual”，且不显示滚动条。
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **启用放映选项**

`SlideShowSettings.set_Loop` 决定放映是否应循环重复，直至手动停止。这对于需要持续运行的自动化演示非常有用。`SlideShowSettings.set_ShowNarration` 决定放映期间是否播放语音旁白。这对于包含观众语音指引的自动化演示很有帮助。`SlideShowSettings.set_ShowAnimation` 决定是否播放添加到幻灯片对象的动画。这有助于提供完整的视觉效果。

下面的代码示例创建一个新演示文稿并循环放映。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **选择要放映的幻灯片**

`SlideShowSettings.set_Slides` 方法允许您选择在演示期间要放映的幻灯片范围。当只需显示演示的一部分而不是全部幻灯片时，这非常有用。下面的代码示例创建一个新演示文稿，并将要显示的幻灯片范围设置为从第 `2` 张到第 `9` 张。
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **使用计时推进幻灯片**

`SlideShowSettings.set_UseTimings` 方法允许您启用或禁用对每张幻灯片使用预设计时。这对于自动按预定义的显示时长播放幻灯片非常有用。下面的代码示例创建一个新演示文稿并禁用计时的使用。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **显示媒体控制**

`SlideShowSettings.set_ShowMediaControls` 方法决定在播放多媒体内容（例如视频或音频）时，放映期间是否显示媒体控制（如播放、暂停和停止）。当您希望在演示期间让演示者控制媒体播放时，这非常有用。

下面的代码示例创建一个新演示文稿，并启用显示媒体控制。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **常见问题**

**我可以将演示文稿保存为直接以放映模式打开吗？**

是的。将文件另存为 PPSX 或 PPSM；这些格式在 PowerPoint 中打开时会直接进入放映模式。在 Aspose.Slides 中，可在[导出期间](/slides/zh/cpp/save-presentation/)选择相应的保存格式。

**我可以在不删除文件中幻灯片的情况下，将单独的幻灯片排除在放映之外吗？**

可以。将幻灯片标记为[hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/)。隐藏的幻灯片仍保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能够播放放映或在屏幕上控制实时演示吗？**

不能。Aspose.Slides 只负责编辑、分析和转换演示文件，实际的播放由 PowerPoint 等查看器应用程序完成。