---
title: 使用 Python 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 90
url: /zh/python-net/slide-transition/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 应用幻灯片切换，配置自动幻灯片推进，并自定义 Morph 及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片放映期间幻灯片的出现方式。使用 Aspose.Slides for Python via .NET，您可以为每张幻灯片选择切换效果、配置鼠标点击或计时器推进方式，并调整特定于效果的选项。本文使用 Python 示例演示如何应用切换、设置精确的切换时长、管理幻灯片计时以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation 类](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 加载演示文稿并访问幻灯片的 [slide_show_transition](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/slide_show_transition/) 属性。将其 [type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/type/) 设置为 [TransitionType 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitiontype/) 中的值，然后保存演示文稿。

下面的示例为第一张幻灯片应用 Circle 切换，为第二张幻灯片应用 Comb 切换。使用至少包含两张幻灯片的 `input.pptx` 文件。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进放映。以下属性控制此行为：

- [advance_on_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 允许观看者点击鼠标推进。
- [advance_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 启用自动推进。
- [advance_after_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) 指定自动推进前的延迟（毫秒）。

同时启用点击和计时推进，使观看者可以点击继续或等待计时器。仅使用计时器时，将 [advance_on_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) 设为 `False`。延迟决定放映何时推进；它并不设定可视切换效果的时长。

此示例为前三张幻灯片分别分配不同效果，并在 3、5、7 秒后自动推进。鼠标点击同样可以推进这些幻灯片。使用至少包含三张幻灯片的 `input.pptx` 文件。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

要检查是否启用了计时推进，请读取 [advance_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟大于两秒的幻灯片禁用自动推进。为这些幻灯片启用鼠标点击并保存更新后的设置。

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **精确控制切换时长**

使用 [duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 可以以毫秒为单位指定切换效果的精确时长。幻灯片的 [slide_show_transition](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/slide_show_transition/) 属性通过 [SlideShowTransition](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/) 暴露这些设置：

| 属性 | 作用 |
| --- | --- |
| [duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | 设置切换效果本身的时长（毫秒）。 |
| [advance_after_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | 设置幻灯片自动推进前的延迟（毫秒）。启用 [advance_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) 可激活此计时器。 |
| [speed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | 从 [TransitionSpeed 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionspeed/) 中选择预定义的速度类别：SLOW、MEDIUM 或 FAST。仅在未指定精确时长时使用。 |

[duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 仅控制切换效果；它不决定幻灯片的可见时长。自动推进的延迟需单独配置。当未设置显式时长时，Aspose.Slides 会根据切换类型和 [speed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 值计算效果时长。

### **为所有幻灯片统一时长**

为保持节奏一致，可为每张幻灯片应用相同的效果和精确时长。此示例加载 `input.pptx`，从 [TransitionType 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的时长。它单独将自动推进延迟设为 5,000 毫秒，并禁用鼠标点击推进，随后将结果保存为 PPTX。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # 配置自动推进，与效果时长独立。
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **为单个幻灯片设置不同的时长**

不同幻灯片可使用不同的效果时长。例如，为标题幻灯片使用较短的切换，为章节介绍使用较长的切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。使用至少包含两张幻灯片的 `input.pptx` 文件。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **与动画输出协同切换**

在准备 [animated GIF](/slides/zh/python-net/convert-powerpoint-to-animated-gif/)、[HTML5 演示](/slides/zh/python-net/export-to-html5/) 或 [视频](/slides/zh/python-net/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换时长，以匹配预期节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的推进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果时长对齐：600 毫秒对应 30 帧每秒时的 18 帧。HTML5 导出时，在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取已有切换时长**

在修改切换之前读取 [duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/duration/)，以判断是否已存储显式值。`-1` 表示未设置显式时长；非负值表示以毫秒为单位的已存储时长。未设置的值不是计算后的播放时长：Aspose.Slides 会根据切换类型和 [speed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/speed/) 确定该时长。设置切换类型可能会初始化时长，因此请先检查原始设置。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph 切换**

Morph 切换在连续幻灯片之间对对象的变化进行动画。创建简单的 Morph 效果的步骤是：克隆一张幻灯片，在克隆上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样会让对应的对象在原始状态和修改后状态之间进行动画。

下面的示例创建一个包含文本矩形的幻灯片，克隆该幻灯片，并在克隆上改变矩形的位置和大小。随后为第二张幻灯片从 [TransitionType 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitiontype/) 中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件即可在放映时看到效果。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph 切换类型**

[TransitionMorphType 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionmorphtype/) 控制 Morph 如何匹配并动画内容：

- [BY_OBJECT](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionmorphtype/) 将每个形状视为整体对象。
- [BY_WORD](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按单词匹配文本进行动画。
- [BY_CHAR](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionmorphtype/) 在可能的情况下按字符匹配文本进行动画。

在访问其 [value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/value/) 之前，将切换 [type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/type/) 设置为 Morph。随后获取的值提供 [MorphTransition 对象](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/morphtransition/)，其 [morph_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/morphtransition/morph_type/) 属性选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **设置切换效果**

某些切换会暴露额外选项，例如方向或是否从黑屏开始。可用选项取决于所选切换的 [type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/type/)。先设置类型，然后通过其 [value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/value/) 获取相应的切换对象并设置选项。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/optionalblacktransition/) 的 [from_black](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) 属性，使切换从黑屏开始。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **常见问题**

**我可以控制幻灯片切换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时长时，请优先使用 [duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/duration/)。如果预定义的 [TransitionSpeed 类别](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionspeed/)（SLOW、MEDIUM、FAST）已足够且未设置显式时长，则使用 [speed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/speed/)。这些设置独立于自动推进延迟，专门控制切换效果。

**我可以为切换附加音频并让其循环吗？**

可以。将嵌入的音频分配给 [sound](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/sound/)，将 [sound_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) 设置为 [TransitionSoundMode 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitionsoundmode/) 中的 START_SOUND，并启用 [sound_loop](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/)。音频将在放映的下一个声音事件出现前循环播放。

**将相同切换应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [slides 集合](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slides/zh/)，在循环中将每张幻灯片的切换 [type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/type/) 设置为相同的值。可在同一循环中设置计时和效果选项，以在所有幻灯片之间保持行为一致。

**我如何检查幻灯片当前设置了哪个切换？**

读取幻灯片的 [slide_show_transition](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/slide_show_transition/) 中的 [type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/slideshowtransition/type/) 属性。它返回来自 [TransitionType 枚举](https://reference.aspose.com/slides/zh/python-net/aspose.slides.slideshow/transitiontype/) 的值；NONE 表示没有应用切换效果。