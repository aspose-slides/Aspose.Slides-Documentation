---
title: 在 Android 上管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/androidjava/manage-slide-show/
keywords:
- 放映类型
- 演讲者主持
- 个人浏览
- 信息亭浏览
- 放映选项
- 循环放映
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
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 的 Aspose.Slides 中通过 Java 管理幻灯片放映。轻松控制 PPT、PPTX 和 ODP 格式的幻灯片切换、计时等。"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和呈现专业演示文稿的关键工具。此部分最重要的功能之一是 **Set Up Show**，它允许您根据特定条件和受众定制演示文稿，确保灵活性和便利性。通过此功能，您可以选择演示类型（例如，由演讲者主持、由个人浏览或在信息亭中浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。这一步骤对于提升演示的效果和专业度至关重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的一个方法，返回类型为 [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) 的对象，您可以通过它管理 PowerPoint 演示文稿的幻灯片放映设置。本文将探讨如何使用此方法配置和控制幻灯片放映设置的各个方面。

## **选择放映类型**

`SlideShowSettings.setSlideShowType` 定义了幻灯片放映的类型，可以是以下类的实例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/)。使用此方法可以根据不同的使用场景（如自动化信息亭或手动演示）调整演示文稿。

下面的代码示例创建了一个新演示文稿，并将放映类型设置为“Browsed by an individual”，且不显示滚动条。
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **启用放映选项**

`SlideShowSettings.setLoop` 决定幻灯片放映是否应循环播放，直到手动停止。这对于需要持续运行的自动化演示非常有用。`SlideShowSettings.setShowNarration` 决定在放映过程中是否播放语音旁白，适用于包含语音指导的自动化演示。`SlideShowSettings.setShowAnimation` 决定是否播放添加到幻灯片对象的动画，以提供完整的视觉效果。

以下代码示例创建了一个新演示文稿，并使幻灯片放映循环。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **选择要放映的幻灯片**

`SlideShowSettings.setSlides` 方法允许您选择在演示期间显示的幻灯片范围。这样可以在只需要展示演示文稿的一部分时使用，而不是全部幻灯片。下面的代码示例创建了一个新演示文稿，并将显示范围设置为第 `2` 张到第 `9` 张幻灯片。
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **使用预设计时**

`SlideShowSettings.setUseTimings` 方法允许您启用或禁用对每张幻灯片预设计时的使用。这对于按照预定义的显示时长自动播放幻灯片非常有用。下面的代码示例创建了一个新演示文稿，并关闭了计时功能。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **显示媒体控制**

`SlideShowSettings.setShowMediaControls` 方法决定在放映期间播放多媒体内容（如视频或音频）时，是否显示媒体控制（例如播放、暂停和停止）。当您希望在演示过程中为演讲者提供媒体播放控制时，这非常有用。

下面的代码示例创建了一个新演示文稿，并启用媒体控制的显示。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**我可以将演示文稿保存为直接以幻灯片放映模式打开吗？**

可以。将文件另存为 PPSX 或 PPSM；这两种格式在 PowerPoint 中打开时会直接进入幻灯片放映模式。在 Aspose.Slides 中，可在[导出期间](/slides/zh/androidjava/save-presentation/)选择相应的保存格式。

**我可以在不删除幻灯片的情况下将其从放映中排除吗？**

可以。将幻灯片标记为[hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-)。隐藏的幻灯片仍然保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能否播放幻灯片放映或在屏幕上控制实时演示？**

不能。Aspose.Slides 用于编辑、分析和转换演示文稿文件，实际的播放由 PowerPoint 等查看器应用程序处理。