---
title: 管理 PHP 中的幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/php-java/manage-slide-show/
keywords:
- 放映类型
- 演讲者展示
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
- PHP
- Aspose.Slides
description: "学习如何在 Aspose.Slides for PHP via Java 中管理幻灯片放映。轻松控制 PPT、PPTX 和 ODP 格式的幻灯片切换、计时等。"
---

在 Microsoft PowerPoint 中，**Slide Show** 设置是准备和呈现专业演示文稿的关键工具。本节中最重要的功能之一是 **Set Up Show**，它允许您根据特定的条件和受众定制演示文稿，确保灵活性和便利性。使用此功能，您可以选择放映类型（例如，由演讲者呈现、供个人浏览或在信息亭浏览），启用或禁用循环，选择要显示的特定幻灯片，并使用计时。此准备步骤对于使您的演示更有效、更专业至关重要。

`getSlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的方法，返回类型为 [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/) 的对象，您可以使用它管理 PowerPoint 演示文稿中的幻灯片放映设置。本文将探讨如何使用此方法配置和控制幻灯片放映设置的各个方面。 

## **选择放映类型**

`SlideShowSettings->setSlideShowType` 定义了放映的类型，可为以下类的实例之一： [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/)，[BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/)，或 [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/)。使用此方法可使演示文稿适应不同的使用场景，例如自动化信息亭或手动演示。

下面的代码示例创建了一个新演示文稿，并将放映类型设置为“Browsed by an individual”（个人浏览），且不显示滚动条。
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **启用放映选项**

`SlideShowSettings->setLoop` 决定幻灯片放映是否应循环重复，直至手动停止。这对于需要持续运行的自动化演示非常有用。`SlideShowSettings->setShowNarration` 决定是否在放映期间播放语音解说。这对于包含面向观众的语音指导的自动化演示很有用。`SlideShowSettings->setShowAnimation` 决定是否播放添加到幻灯片对象的动画。这有助于呈现演示的完整视觉效果。

以下代码示例创建一个新演示文稿，并循环放映。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **选择要放映的幻灯片**

`SlideShowSettings->setSlides` 方法允许您选择在演示期间要显示的幻灯片范围。当您只需展示演示的一部分而非全部幻灯片时，这非常有用。下面的代码示例创建了一个新演示文稿，并将要显示的幻灯片范围设置为第 `2` 张到第 `9` 张。
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **使用计时**

`SlideShowSettings->setUseTimings` 方法允许您启用或禁用对每张幻灯片的预设计时。这对于自动按预定义显示时长放映幻灯片很有用。下面的代码示例创建了一个新演示文稿，并禁用计时的使用。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **显示媒体控件**

`SlideShowSettings->setShowMediaControls` 方法决定在播放多媒体内容（例如视频或音频）时，放映期间是否显示媒体控件（如播放、暂停和停止）。当您希望在演示过程中为演讲者提供媒体播放控制时，这很有用。

以下代码示例创建了一个新演示文稿，并启用显示媒体控件。
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **常见问题**

**我可以将演示文稿保存为直接以放映模式打开吗？**

可以。将文件另存为 PPSX 或 PPSM；这些格式在 PowerPoint 中打开时会直接以放映模式启动。在 Aspose.Slides 中，请在[导出期间](/slides/zh/php-java/save-presentation/)选择相应的保存格式。

**我可以在不从文件中删除幻灯片的情况下将单个幻灯片排除在放映之外吗？**

可以。将幻灯片标记为[隐藏](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/)。隐藏的幻灯片仍然保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能播放幻灯片放映或在屏幕上控制实时演示吗？**

不能。Aspose.Slides 负责编辑、分析和转换演示文件；实际的播放由 PowerPoint 等查看器应用程序处理。