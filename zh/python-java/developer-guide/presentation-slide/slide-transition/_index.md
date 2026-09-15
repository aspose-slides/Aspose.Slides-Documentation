---
title: 使用 Python via Java 在演示文稿中管理幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/python-java/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- Morph 切换
- 切换类型
- 切换效果
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 应用幻灯片切换，配置自动幻灯片推进，并自定义 Morph 以及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映过程中呈现的方式。使用 Aspose.Slides for Python via Java，您可以为每张幻灯片选择切换效果、配置通过鼠标点击或计时器推进的方式，并调整针对特定效果的选项。本文使用 Python 示例演示如何应用切换、设置精确的切换时长、管理幻灯片计时以及在两张幻灯片之间创建 Morph（变形）切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，请使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

下面的示例对第一张幻灯片应用 Circle 切换，对第二张幻灯片应用 Comb 切换。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观众通过点击鼠标推进。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动推进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动推进前的延迟，单位为毫秒。

同时启用点击和计时推进，可让观众点击前进或等待计时器。若只使用计时器，请将 `False` 传给 [setAdvanceOnClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)。延迟仅控制放映何时推进；它不设置视觉切换效果的时长。

此示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后自动推进。鼠标点击也可以推进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

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

要检查是否启用了计时推进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟大于两秒的幻灯片禁用自动推进。它为这些幻灯片启用鼠标点击并保存更新后的设置。

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

## **精确控制切换时间**

使用 [setDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setDuration) 可以指定切换效果的精确时长（毫秒）。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/) 暴露这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setDuration) | 设置切换效果本身的时长，单位为毫秒。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动推进前的延迟，单位为毫秒。将 `True` 传给 [setAdvanceAfter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 以激活此计时器。 |
| [setSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确时长时使用该设置。 |

[setDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setDuration) 仅控制切换效果本身；它不决定幻灯片可见的时长。请单独配置自动推进的延迟。当未设置显式时长时，Aspose.Slides 将根据切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值来决定效果时长。

### **为每张幻灯片应用相同的时长**

为保持一致的节奏，可为每张幻灯片应用相同的效果和精确时长。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的时长。它还分别在 5,000 毫秒后启用自动推进，并禁用鼠标点击，然后将结果保存为 PPTX。

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

        # 独立于效果时长配置自动推进。
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **为单独幻灯片设置不同的时长**

不同的幻灯片可以使用不同的效果时长。例如，对标题幻灯片使用短暂的切换，对章节引入使用较长的切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **与动画输出同步切换**

在准备 [animated GIF](/slides/zh/python-java/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/python-java/export-to-html5/) 或 [video](/slides/zh/python-java/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换时长以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并单独调整每张幻灯片的推进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，请将输出帧率与效果时长对应：600 毫秒相当于 30 帧/秒下的 18 帧。对于 HTML5，在导出设置中启用动画切换。检查所选导出格式支持的效果和时间选项，并预览输出以确认同步。

### **读取已存在的切换时长**

在修改切换之前调用 [getDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getDuration) 以确定是否存储了显式值。`-1` 表示未设置显式时长；非负值表示已存储的毫秒时长。未设置的值并非计算出的播放时长：Aspose.Slides 使用切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getSpeed) 的值来决定该时长。设置切换类型可以初始化时长，因此请先检查原始设置。

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

## **Morph 切换**

Morph 切换在连续幻灯片之间对对象的变化进行动画。要创建简单的 Morph 效果，可克隆一张幻灯片，在克隆上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样会让对应的对象在原始状态和修改后状态之间进行动画。

以下示例创建包含文本矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitiontype/) 枚举中选择 Morph。请在支持 Morph 的演示文稿查看器中打开保存的文件，以在放映时看到效果。

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

## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionmorphtype/) 枚举控制 Morph 如何匹配并动画化内容：

- [ByObject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为完整对象。
- [ByWord](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配文本并进行动画。
- [ByChar](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本并进行动画。

使用 [setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setType) 选择 Morph，然后访问 [getValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getValue)。返回值是 [MorphTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/morphtransition/) 类的实例，可通过其 [setMorphType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

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

## **设置切换效果**

某些切换会公开额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setType) 所选择的切换。先设置类型，然后使用 [getValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getValue) 返回的相应类。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/optionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/zh/python-java/aspose.slides/optionalblacktransition/#setFromBlack)，使切换从黑屏开始。

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

## **常见问题**

**我能控制幻灯片切换的播放速度吗？**

可以。当需要毫秒级的精确时长时，请优先使用 [setDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）足够且未设置显式时长，则使用 [setSpeed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动推进的延迟，控制切换效果本身。

**我可以为切换附加音频并让它循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setSound) 分配嵌入音频，将 [TransitionSoundMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitionsoundmode/) 中的 `StartSound` 传给 [setSoundMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setSoundMode)，并将 [setSoundLoop](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setSoundLoop) 设为 `True`。音频将在幻灯片放映的下一个声音事件之前循环播放。

**将相同切换应用于每张幻灯片的最快方式是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getSlides) 集合，对每张幻灯片的切换调用 [setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#setType) 并使用相同的值。可在同一循环中设置计时和效果选项，以保持所有幻灯片的行为一致。

**如何检查幻灯片当前使用的切换类型？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getSlideShowTransition) 结果调用 [getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideshowtransition/#getType)。它返回 [TransitionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/transitiontype/) 枚举中的一个值；`None_` 表示未应用任何切换效果。