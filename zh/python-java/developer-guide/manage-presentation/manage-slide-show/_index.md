---
title: 在 Python via Java 中管理幻灯片放映
linktitle: 幻灯片放映
type: docs
weight: 90
url: /zh/python-java/manage-slide-show/
keywords:
- 幻灯片放映类型
- 演讲者放映
- 个人浏览
- 亭式浏览
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
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理幻灯片放映。轻松控制幻灯片切换、计时等，适用于 PPT、PPTX 和 ODP 格式。"
---
## **简介**

Microsoft PowerPoint 的 **设置放映** 选项让您可以选择演示类型、启用循环、选择幻灯片以及控制幻灯片的前进方式。使用 Aspose.Slides for Python via Java，您可以以编程方式配置这些选项并将其保存到演示文稿文件中。

The [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlideShowSettings) method returns a [SlideShowSettings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/) object that controls these options. The examples below require Aspose.Slides for Python via Java and a compatible Java runtime. Each example starts the JVM if needed and releases the presentation when finished.

## **选择演示类型**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setSlideShowType) defines the type of slide show, which can be an instance of the following classes: [PresentedBySpeaker](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/zh/python-java/aspose.slides/browsedbyindividual/), or [BrowsedAtKiosk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/browsedatkiosk/). Using this method allows you to adapt the presentation for different usage scenarios, such as automated kiosks or manual presentations.

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

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

## **启用演示选项**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setLoop) determines whether the slide show should repeat in a loop until manually stopped. This is useful for automated presentations that need to run continuously. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowNarration) determines whether voice narrations should be played during the slide show. It is useful for automated presentations that contain voice guidance for the audience. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowAnimation) determines whether animations added to slide objects should be played. This is useful for providing the full visual effect of the presentation.

The following code example creates a new presentation and loops the slide show.

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

## **选择要显示的幻灯片**

The [SlideShowSettings.setSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setSlides) method allows you to select a range of slides to be shown during the presentation. This is useful when you need to show only part of the presentation rather than all slides. The following code example creates a presentation with nine slides and selects slides 2 through 9. The range uses one-based slide numbers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # 创建九张幻灯片，以确保所选范围存在。
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

The [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setUseTimings) method allows you to enable or disable the use of preset timings for each slide. This is useful for automatically showing slides with pre-defined display durations. The code example below creates a new presentation and disables the use of timings.

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

The [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) method determines whether media controls (such as play, pause, and stop) should be displayed during the slide show when multimedia content (e.g., video or audio) is played. This is useful when you want to give the presenter control over media playback during the presentation.

The following code example creates a new presentation and enables media controls to be displayed.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以保存演示文稿，使其直接以放映模式打开吗？**

Yes. Save the file as PPSX or PPSM; these formats launch directly in slide show mode when opened in PowerPoint. In Aspose.Slides, choose the corresponding save format [during export](/slides/zh/python-java/save-presentation/).

**我可以在不从文件中删除的情况下将单个幻灯片排除在放映之外吗？**

Yes. Mark a slide as [hidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#setHidden). Hidden slides remain in the presentation but are not displayed during the slide show.

**Aspose.Slides 能够播放幻灯片放映或在屏幕上实时控制演示吗？**

No. Aspose.Slides edits, analyzes, and converts presentation files; the actual playback is handled by a viewer application such as PowerPoint.