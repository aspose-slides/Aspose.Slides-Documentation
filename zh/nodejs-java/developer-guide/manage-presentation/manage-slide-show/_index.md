---
title: 管理幻灯片放映
type: docs
weight: 90
url: /zh/nodejs-java/manage-slide-show/
keywords:
- 放映类型
- 由演讲者呈现
- 个人浏览
- 信息亭浏览
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
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "使用 JavaScript 在 PowerPoint 演示文稿中管理幻灯片放映设置"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和呈现专业演示文稿的重要工具。本节最重要的功能之一是**Set Up Show**，它允许您根据特定情境和受众定制演示文稿，确保灵活性和便利性。使用此功能，您可以选择放映类型（例如，由演讲者呈现、个人浏览或在信息亭浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。此准备步骤对提升演示文稿的效果和专业性至关重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的一个方法，返回类型为 [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/) 的对象，您可以使用它来管理 PowerPoint 演示文稿中的幻灯片放映设置。本文将探讨如何使用此方法配置和控制幻灯片放映设置的各个方面。

## **选择放映类型**

`SlideShowSettings.setSlideShowType` 定义幻灯片放映的类型，可以是以下类的实例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/)。使用此方法可以使演示文稿适应不同的使用场景，例如自动信息亭或手动演示。

下面的代码示例创建一个新演示文稿，并将放映类型设置为“Browsed by an individual”，且不显示滚动条。
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **启用放映选项**

`SlideShowSettings.setLoop` 决定幻灯片放映是否应循环重复，直至手动停止。这对需要连续运行的自动化演示文稿很有用。`SlideShowSettings.setShowNarration` 决定是否在放映期间播放声音旁白。这对包含面向观众的语音指导的自动化演示文稿很有用。`SlideShowSettings.setShowAnimation` 决定是否播放添加到幻灯片对象的动画。这有助于呈现演示文稿的完整视觉效果。

下面的代码示例创建一个新演示文稿并循环放映。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **选择要放映的幻灯片**

`SlideShowSettings.setSlides` 方法允许您选择在演示期间要显示的幻灯片范围。当只需展示演示文稿的部分内容而非全部幻灯片时，这非常有用。以下代码示例创建一个新演示文稿，并将幻灯片范围设置为显示第 `2` 至 `9` 张幻灯片。
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **使用计时推进幻灯片**

`SlideShowSettings.setUseTimings` 方法允许您启用或禁用对每张幻灯片使用预设计时。这对于自动按预定义显示时长播放幻灯片非常有用。下面的代码示例创建一个新演示文稿并禁用计时的使用。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **显示媒体控制**

`SlideShowSettings.setShowMediaControls` 方法决定在播放多媒体内容（例如视频或音频）时，是否在放映期间显示媒体控制（如播放、暂停和停止）。当您希望在演示过程中让演示者能够控制媒体播放时，这非常有用。

以下代码示例创建一个新演示文稿并启用显示媒体控制。
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **常见问题**

**我能将演示文稿保存为直接在放映模式下打开吗？**

可以。将文件另存为 PPSX 或 PPSM；这些格式在 PowerPoint 中打开时会直接进入放映模式。在 Aspose.Slides 中，可在[导出期间](/slides/zh/nodejs-java/save-presentation/)选择相应的保存格式。

**我可以在不删除文件中幻灯片的情况下将单个幻灯片排除在放映之外吗？**

可以。将幻灯片标记为[隐藏](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/)。隐藏的幻灯片仍保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能否在屏幕上播放幻灯片放映或控制实时演示？**

不能。Aspose.Slides 负责编辑、分析和转换演示文稿文件；实际的播放由如 PowerPoint 等查看器应用程序完成。