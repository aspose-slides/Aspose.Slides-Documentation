---
title: 管理 Android 上的幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/androidjava/manage-slide-show/
keywords:
- 放映类型
- 演讲者演示
- 个人浏览
- 信息亭浏览
- 放映选项
- 连续循环
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
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "学习如何在 Aspose.Slides for Android via Java 中管理幻灯片放映。轻松控制幻灯片切换、计时等，支持 PPT、PPTX 和 ODP 格式。"
---

在 Microsoft PowerPoint 中，**幻灯片放映** 设置是准备和呈现专业演示文稿的关键工具。此部分最重要的功能之一是 **设置放映**，它允许您根据特定条件和受众调整演示文稿，从而确保灵活性和便利性。使用此功能，您可以选择放映类型（例如，由演讲者演示、个人浏览或在信息亭中浏览），启用或禁用循环，选择特定幻灯片进行显示，并使用计时。此准备步骤对于提升演示的效果和专业性至关重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的一个方法，返回类型为 [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/) 的对象，您可以使用它管理 PowerPoint 演示文稿的幻灯片放映设置。本文将介绍如何使用此方法配置和控制幻灯片放映设置的各个方面。

## **选择放映类型**

`SlideShowSettings.setSlideShowType` 定义放映类型，可使用以下类的实例：[PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/)。使用此方法可以根据不同使用场景（如自动信息亭或手动演示）调整演示文稿。

下面的代码示例创建一个新的演示文稿，并将放映类型设置为“个人浏览”，且不显示滚动条。
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **启用放映选项**

`SlideShowSettings.setLoop` 决定幻灯片放映是否循环播放，直至手动停止。这对于需要持续运行的自动化演示非常有用。`SlideShowSettings.setShowNarration` 决定放映时是否播放语音解说，适用于包含语音引导的自动化演示。`SlideShowSettings.setShowAnimation` 决定是否播放添加到幻灯片对象的动画，以提供完整的视觉效果。

以下代码示例创建一个新的演示文稿并循环放映。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **选择要放映的幻灯片**

`SlideShowSettings.setSlides` 方法允许您选择在演示过程中显示的幻灯片范围。当只需要展示演示文稿的部分内容而非全部幻灯片时，这非常有用。下面的代码示例创建一个新的演示文稿，并将显示范围设置为第 `2` 张至第 `9` 张幻灯片。
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

`SlideShowSettings.setUseTimings` 方法允许您启用或禁用对每张幻灯片的预设计时。这对于按照预定义显示时长自动切换幻灯片非常有用。以下代码示例创建一个新的演示文稿并禁用计时功能。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **显示媒体控制**

`SlideShowSettings.setShowMediaControls` 方法决定在播放多媒体内容（例如视频或音频）时，幻灯片放映期间是否显示媒体控制（如播放、暂停和停止）。当您希望在演示过程中让演讲者能够控制媒体播放时，这非常实用。

以下代码示例创建一个新的演示文稿并启用媒体控制的显示。
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **常见问题**

**我可以将演示文稿保存为直接以放映模式打开吗？**

可以。将文件另存为 PPSX 或 PPSM 格式；这些格式在 PowerPoint 中打开时会直接启动放映模式。在 Aspose.Slides 中，选择相应的保存格式[在导出期间](/slides/zh/androidjava/save-presentation/)。

**我可以在不从文件中删除的情况下将单个幻灯片排除在放映之外吗？**

可以。将幻灯片标记为[隐藏](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-)。隐藏的幻灯片仍保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能否播放放映或在屏幕上控制实时演示？**

不能。Aspose.Slides 用于编辑、分析和转换演示文稿文件，实际的播放由 PowerPoint 等查看器应用程序处理。