---
title: 在 Python via Java 中管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/python-java/manage-slide-show/
keywords:
- 放映类型
- 演讲者展示
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
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理幻灯片放映。轻松控制 PPT、PPTX 和 ODP 格式的幻灯片切换、计时等功能。"
---
## **介绍**

Microsoft PowerPoint 的 **Set Up Show** 选项让您可以选择放映类型、启用循环、选择幻灯片以及控制幻灯片的前进方式。使用 Aspose.Slides for Python via Java，您可以以编程方式配置这些选项并将其保存在演示文稿文件中。

[Presentation.getSlideShowSettings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlideShowSettings) 方法返回一个控制这些选项的 [SlideShowSettings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/) 对象。下面的示例需要 Aspose.Slides for Python via Java 以及兼容的 Java 运行时。每个示例在需要时启动 JVM，完成后释放演示文稿。

## **选择放映类型**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setSlideShowType) 定义放映的类型，可为以下类的实例之一：[PresentedBySpeaker](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh/python-java/aspose.slides/browsedbyindividual/) 或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/browsedatkiosk/)。使用此方法可以针对不同使用场景（例如自动化信息亭或手动演示）调整演示文稿。

下面的代码示例创建一个新演示文稿，并将放映类型设置为“Browsed by an individual”（个人浏览），且不显示滚动条。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **启用放映选项**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setLoop) 决定放映是否应循环重复，直至手动停止。这对于需要持续运行的自动化演示非常有用。[SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowNarration) 决定是否在放映期间播放语音旁白，适用于包含语音指导的自动化演示。[SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowAnimation) 决定是否播放添加到幻灯片对象的动画，以完整呈现演示的视觉效果。

下面的代码示例创建一个新演示文稿并循环放映。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **选择要放映的幻灯片**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setSlides) 方法允许您选择在演示期间要显示的幻灯片范围。这在只需展示演示文稿的一部分而非全部幻灯片时非常有用。下面的代码示例创建一个包含九张幻灯片的演示文稿，并选择第 2 张到第 9 张幻灯片。范围使用基于 1 的幻灯片编号。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 创建九张幻灯片，以便选定的范围存在。
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制幻灯片前进**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setUseTimings) 方法允许您启用或禁用对每张幻灯片预设计时的使用。这对于使用预定义显示时长自动播放幻灯片非常有用。下面的代码示例创建一个新演示文稿并禁用计时使用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **显示媒体控制**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) 方法决定在播放多媒体内容（例如视频或音频）时，放映期间是否显示媒体控制（如播放、暂停、停止）。当您希望演示者能够控制媒体播放时，这非常有用。

下面的代码示例创建一个新演示文稿并启用媒体控制的显示。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我能将演示文稿保存为直接以放映模式打开吗？**

可以。将文件另存为 PPSX 或 PPSM；这些格式在 PowerPoint 中打开时会直接启动放映模式。在 Aspose.Slides 中，选择相应的保存格式【在导出时】(/slides/zh/python-java/save-presentation/)。

**我可以在不从文件中删除幻灯片的情况下将其排除在放映之外吗？**

可以。将幻灯片标记为[hidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#setHidden)。隐藏的幻灯片仍保留在演示文稿中，但在放映时不会显示。

**Aspose.Slides 能播放放映或在屏幕上实时控制演示吗？**

不能。Aspose.Slides 负责编辑、分析和转换演示文稿文件，实际的播放由 PowerPoint 等查看器应用程序完成。