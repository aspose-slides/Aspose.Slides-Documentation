---
title: 在 Python 中为演示文稿应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/python-net/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 添加、检查和自定义形状动画、时间设置、声音、动画后行为以及动画文本。"
---
## **概述**

Aspose.Slides for Python via .NET 将幻灯片动画表示为幻灯片时间轴中的效果。一个效果具有目标形状、动画类型和子类型、触发器、时间设置以及诸如声音或动画结束后的行为等可选属性。

时间轴包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被点击时开始。

由于文本框、图片、图表、表格以及其他幻灯片对象实现了[IShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ishape/)，您可以对大多数幻灯片内容使用相同的[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)方法。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttype/)枚举中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)，传入目标形状、效果类型、子类型和触发器。对于在点击其他形状时启动的效果，创建一个触发器为该其他形状的交互序列。

下面的示例创建两种类型的动画并将结果保存为`shape-animations.pptx`。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

触发器控制效果何时开始：

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttriggertype/) 在主序列中等待点击，或在交互序列中等待对触发形状的点击。
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttriggertype/) 与前一个效果一起开始。
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effecttriggertype/) 在前一个效果完成后开始。

要对图片、图表或其他形状类型进行动画，请将该对象传递给[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)而不是`target_shape`。有关图表特定的分组选项，请参见[动画图表](/slides/zh/python-net/animated-charts/)。

## **读取形状动画**

当您已知目标形状时，请使用[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/get_effects_by_shape/)。要检查每个效果，请遍历主序列和所有交互序列。迭代可避免假设序列在索引`0`处包含效果。

下面的示例创建一个具有主序列和交互效果的形状，获取针对该形状的效果，然后遍历幻灯片上的每个序列。

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

如果您只需要一个形状的效果，请首先通过名称、占位符类型或其他稳定属性识别该形状；然后调用[Sequence.get_effects_by_shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/get_effects_by_shape/)。不要假设索引`0`处的形状始终是目标对象。

## **使用继承的占位符效果**

普通幻灯片上的占位符可以继承其布局幻灯片和母版幻灯片上对应占位符的动画行为。[Shape.get_base_placeholder](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_base_placeholder/)返回该父占位符，若不存在父占位符则返回`None`。

在以下示例演示文稿中，页脚在普通幻灯片上的动画为**Random Bars**，在布局幻灯片上为**Split**，在母版幻灯片上为**Fly In**。

![普通幻灯片上页脚动画效果](slide-shape-animation.png)

![布局幻灯片上页脚占位符动画效果](layout-shape-animation.png)

![母版幻灯片上页脚占位符动画效果](master-shape-animation.png)

下面的示例自行构建占位符层次结构。它向母版占位符、布局占位符以及普通幻灯片上的相应占位符添加效果。在使用返回的形状之前，都会检查对[Shape.get_base_placeholder](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_base_placeholder/)的每一次调用。

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **更改动画时间**

PowerPoint **Timing** 对话框映射到[Timing](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/)的属性。

![动画效果的 PowerPoint Timing 对话框](shape-animation.png)

- **Start** 映射到[Timing.trigger_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/trigger_type/)。
- **Duration** 映射到[Timing.duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/duration/)，单位为秒。
- **Delay** 映射到[Timing.trigger_delay_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/trigger_delay_time/)，单位为秒。
- **Repeat** 映射到[Timing.repeat_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_count/)、[Timing.repeat_until_next_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_next_click/)或[Timing.repeat_until_end_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)。
- **Rewind when done playing** 映射到[Timing.rewind](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/rewind/)。

此独立示例添加一个效果，通过[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)返回的对象更改其时间，并保存结果。保留返回的[Effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/)引用可避免不必要的集合索引。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

请有意使用单一的重复模式。将重复计数与“until”标志组合可能在不同的观看器中产生混乱的结果。更改重复模式时，请先设置[Timing.repeat_until_next_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_next_click/)和[Timing.repeat_until_end_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)，再设置[Timing.repeat_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_count/)，因为设置任一标志都会更改当前的重复模式。

## **添加和提取动画声音**

动画效果可以通过[Effect.sound](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/sound/)引用嵌入的音频。[Effect.stop_previous_sound](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/stop_previous_sound/)指示效果停止之前效果启动的音频。

### **向效果添加声音**

下面的示例需要本地音频文件`animation-sound.wav`。它创建两个效果，将该文件嵌入为第一个效果的声音，并配置第二个效果停止该声音。它使用[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)返回的对象，因此不需要序列索引。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **提取嵌入的效果声音**

下面的示例需要本地演示文稿`presentation-with-animation-sounds.pptx`。它扫描主序列和交互序列，并将所有嵌入的效果声音写入`extracted-animation-sounds`目录。扩展名根据[Audio.content_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audio/content_type/)暴露的音频 MIME 类型选择。

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

对于大型音频对象，请使用[Audio.get_stream](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audio/get_stream/)并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画后行为**

**After animation** 选项控制形状在其效果完成后会发生什么。

![显示 After animation 设置的 PowerPoint 效果选项对话框](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/afteranimationtype/) 枚举支持保持形状不变、更改其颜色、在动画后隐藏它，或在下一次点击时隐藏它。当类型为[AfterAnimationType.COLOR](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/afteranimationtype/)时，还需设置[Effect.after_animation_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/after_animation_color/)。

此独立示例创建一个效果，通过返回的 effect 对象设置其动画后行为，并保存结果。

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

将类型从[AfterAnimationType.COLOR](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/afteranimationtype/)更改会清除动画后颜色设置。

## **动画文本**

文本动画有两个相关控制：

- [TextAnimation.build_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/textanimation/build_type/) 控制段落是一起出现还是按段落级别出现。
- [Effect.animate_text_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/animate_text_type/) 控制文本是一次性出现、按单词还是按字母出现。[Effect.delay_between_text_parts](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/delay_between_text_parts/) 设置单词或字母之间的延迟。正值表示效果持续时间的百分比；负值表示秒数延迟。

下面的独立示例为文本框中的单词添加动画。[BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/buildtype/) 禁用按段落构建，使单词设置适用于整个文本框。

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

若要按段落构建文本框，请设置[BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/buildtype/)（或其他段落级别）。若要为单个段落单独设置效果，请使用接受[IParagraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iparagraph/)的[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)重载。参见[动画文本](/slides/zh/python-net/animated-text/)获取段落级示例。

## **导出和兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不播放动画。当输出必须显示运动时，请使用[HTML5 导出](/slides/zh/python-net/export-to-html5/)、动画 GIF 或[视频转换](/slides/zh/python-net/convert-powerpoint-to-video/)。
- 对于 HTML5，请启用[Html5Options.animate_shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/html5options/animate_shapes/)，并在需要时启用[Html5Options.animate_transitions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/html5options/animate_transitions/)。
- 视频渲染支持许多常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请查看当前的[支持的动画和效果](/slides/zh/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)并使用目标 Aspose.Slides 版本测试关键演示文稿。
- 高级自定义效果以及从其他演示格式导入的效果可能在文件中得到保留，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不是仅依赖效果名称。

## **常见问题**

**为什么动画在 PowerPoint 中出现，但在 PDF 中没有？**

PDF 是静态格式，动画和幻灯片切换不播放。当必须保留运动时，请导出为 HTML5、动画 GIF 或视频。

**为什么效果在视频中播放不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。一些高级效果不受支持或被近似。请查看支持的效果表，并在正式使用前测试实际演示文稿。

**移动形状的前后顺序会改变其动画顺序吗？**

不会。形状的 Z 顺序控制叠放，而序列顺序和触发器控制动画播放。如需不同的播放顺序，请更改时间轴。