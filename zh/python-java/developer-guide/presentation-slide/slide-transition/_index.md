---
title: 使用 Python via Java 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/python-java/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 转换
- 过渡类型
- 过渡效果
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 应用幻灯片切换、配置自动幻灯片推进，并自定义 Morph 及其他过渡效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映过程中如何出现。使用 Aspose.Slides for Python via Java，您可以为每张幻灯片选择切换效果，配置鼠标点击或计时器推进，并调整特定于效果的选项。本文使用 Python 示例演示如何应用切换、设置精确的切换持续时间、管理幻灯片计时，以及在两张幻灯片之间创建 Morph 转换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

以下示例将 Circle 切换应用于第一张幻灯片，将 Comb 切换应用于第二张幻灯片。请使用至少包含两张幻灯片的 `input.pptx` 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **轮转切换**

使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 从 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 中选择 Wheel。然后调用 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 访问 [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) 设置。其 [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) 方法控制显示目标幻灯片的径向扇区数量。

示例创建了两对相同的幻灯片。每对以黑色幻灯片开始，以完整金色矩形幻灯片结束。两个目标幻灯片均使用相同的慢速（通过 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) 设置）和相同的 8,000 毫秒显式持续时间（通过 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 设置）。仅扇区数量不同。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

打开 `wheel-transitions.pptx` 在 PowerPoint 中并启动放映。从幻灯片 1 前进到幻灯片 2，可看到一个顺时针扫过显示金色矩形。然后从幻灯片 3 前进到幻灯片 4，可看到八个径向扇区同时显示相同的矩形。

## **使用 Reveal 切换的淡入黑色**

将目标幻灯片的切换类型设为 Reveal，然后在其 [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) 设置上调用 [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack)。示例创建了一个青色源幻灯片和一个珊瑚色目标幻灯片，然后克隆两者。每对使用相同的两秒 Reveal 切换。仅第二对在切换时淡入黑色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

打开 `reveal-transitions.pptx` 在 PowerPoint 中并启动放映。从幻灯片 1 前进到幻灯片 2，可看到青色直接淡入珊瑚色。然后从幻灯片 3 前进到幻灯片 4，屏幕会短暂变暗至接近黑色后再出现珊瑚色幻灯片。两张幻灯片保持原始背景颜色。

下面的行显示了 PowerPoint 每半秒的帧。比较每行的中间帧即可看到效果。

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **添加高级幻灯片切换**

可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观众通过点击鼠标推进。
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动推进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动推进前的延迟（毫秒）。

同时启用点击和计时推进，使观众可以点击前进或等待计时器。若只使用计时器，向 [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传入 `False`。延迟决定放映何时推进；它不设置视觉切换效果的持续时间。

此示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后启用自动推进。鼠标点击同样可以推进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

要检查是否启用了计时推进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟大于两秒的幻灯片禁用自动推进。为这些幻灯片重新启用鼠标点击并保存更新后的设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **精确控制转换计时**

使用 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 以毫秒为单位指定转换效果的精确长度。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/) 暴露这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | 设置转换效果本身的持续时间，单位为毫秒。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动推进前的延迟，单位为毫秒。将 `True` 传递给 [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以激活计时器。 |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确持续时间时使用此设置。 |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) 仅控制转换效果本身；它不决定幻灯片保持可见的时长。请单独配置自动推进延迟。当未设置显式持续时间时，Aspose.Slides 会根据转换类型和 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值计算效果时长。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共享示例为每张幻灯片赋予 750 毫秒的淡入切换，并分别在 5,000 毫秒后启用自动推进。切换持续时间控制效果，推进控制离开幻灯片的时机。这些条形仅为示意设置，并非测量得到的综合时间轴。*
<!-- visual-explanation:slide-transition:end -->

### **将相同的持续时间应用于每个幻灯片**

为实现节奏一致，向每张幻灯片应用相同的效果和精确持续时间。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的持续时间。同时在 5,000 毫秒后启用自动推进，并禁用鼠标点击推进，最后将结果保存为 PPTX。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # 独立于效果持续时间配置自动推进。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **为单个幻灯片设置不同的持续时间**

不同的幻灯片可以使用不同的效果时长。例如，对标题幻灯片使用简短切换，对章节介绍使用较长切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **将转换与动画输出协同**

在准备 [animated GIF](/slides/zh/python-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/python-java/export-to-html5/) 或 [video](/slides/zh/python-java/convert-powerpoint-to-video/) 时，先设置精确的切换持续时间，以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入，并分别为每张幻灯片设置不同的推进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果时长对应：600 毫秒相当于 30 fps 下的 18 帧。对于 HTML5，在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取现有的转换持续时间**

在修改切换之前调用 [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) 以判断是否存储了显式值。`-1` 表示未设置显式持续时间；非负值表示以毫秒为单位的存储时长。未设置的值并非实际播放时长：Aspose.Slides 会依据转换类型和 [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值来决定时长。设置转换类型可能会初始化持续时间，因此请先检查原始设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Morph 转换**

Morph 转换在连续幻灯片之间对对象的变化进行动画处理。创建简单的 Morph 效果，只需克隆一张幻灯片，在克隆上移动或缩放对象，然后对第二张幻灯片应用 Morph 转换。这样对应的对象将在原始状态和修改后状态之间进行动画。

以下示例创建包含文本矩形的幻灯片，克隆该幻灯片并在克隆上更改矩形的位置和大小。随后为第二张幻灯片在 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 枚举中选择 Morph。将在支持 Morph 的演示文稿查看器中打开保存的文件，以在放映时观察效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Morph 转换类型**

[TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) 枚举决定 Morph 如何匹配和动画化内容：

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配文本进行动画。
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本进行动画。

使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 选择 Morph，然后访问 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue)。返回值将是 [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) 类的实例，可通过其 [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **设置转换效果**

某些转换暴露额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 选定的转换。先设置类型，然后通过 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) 使用相应的类。

以下示例对 `input.pptx` 的第一张幻灯片应用 Cut 转换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack)，使转换从黑屏开始。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**我可以控制幻灯片切换的播放速度吗？**

可以。当需要毫秒级的精确效果时，请优先使用 [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）已足够且未设置显式持续时间，请使用 [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动推进延迟，专门控制切换效果。

**我可以为切换附加音频并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) 分配嵌入的音频，向 [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) 传入来自 [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) 枚举的 StartSound，并将 [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) 设置为 `True`。音频将在幻灯片放映的下一次声音事件之前循环播放。

**将相同的切换应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) 集合，在循环中对每张幻灯片的切换调用 [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) 并使用相同的值。可在同一循环中设置计时和效果选项，以保持所有幻灯片行为一致。

**我如何检查幻灯片当前设置的是哪种切换？**

在幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) 结果上调用 [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType)。它返回来自 [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) 枚举的值；None_ 表示未应用任何切换效果。