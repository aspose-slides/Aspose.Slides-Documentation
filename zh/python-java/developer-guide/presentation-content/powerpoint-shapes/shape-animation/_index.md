---
title: 在演示文稿中使用 Python via Java 应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/python-java/shape-animation/
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
- Java
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via Java 添加、检查和自定义形状动画、时间设置、声音、动画结束后行为以及动画文本。"
---
## **概述**

Aspose.Slides for Python via Java 将幻灯片动画表示为幻灯片时间轴中的效果。每个效果具有目标形状、动画类型和子类型、触发器、时间设置以及可选属性，例如声音或动画结束后的行为。

时间轴包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互序列** 在其触发形状被点击时启动。

因为文本框、图片、图表、表格以及其他幻灯片对象均派生自[Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/)，所以对大多数幻灯片内容使用相同的[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)方法。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effecttype/)类中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)，传入目标形状、效果类型、子类型和触发器。对于在另一形状被点击时启动的效果，创建其触发器为该形状的交互序列。

下面的示例创建了两种类型的动画并将结果保存为`shape-animations.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

触发器控制效果何时开始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effecttriggertype/#OnClick) 在主序列中等待点击，或在交互序列中等待对触发形状的点击。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effecttriggertype/#WithPrevious) 与前一个效果同时开始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effecttriggertype/#AfterPrevious) 在前一个效果结束后开始。

要为图片、图表或其他形状类型添加动画，向[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)传入相应对象，而不是`target_shape`。有关图表特定的分组选项，请参阅[Animated Charts](/slides/zh/python-java/animated-charts/)。

## **读取形状动画**

当已知目标形状时，使用[Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#getEffectsByShape)。若要检查每个效果，请遍历主序列以及所有交互序列。遍历可以避免假设序列在索引`0`处一定有效果。

下面的示例创建了一个具有主序列和交互效果的形状，获取针对该形状的效果，然后遍历幻灯片上的每个序列。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

如果只需要某个形状的效果，首先通过名称、占位符类型或其他稳定属性识别该形状；然后调用[Sequence.getEffectsByShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#getEffectsByShape)。不要假设[ShapeCollection.get_Item](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#get_Item)在索引`0`处始终是目标对象。

## **处理继承占位符效果**

普通幻灯片上的占位符可以继承其布局幻灯片和母版幻灯片对应占位符的动画行为。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getBasePlaceholder)返回父占位符，若不存在则返回`None`。

在下面的示例演示文稿中，页脚在普通幻灯片上使用**Random Bars**，在布局幻灯片上使用**Split**，在母版幻灯片上使用**Fly In**。

![普通幻灯片上的页脚动画效果](slide-shape-animation.png)

![布局幻灯片上页脚占位符动画效果](layout-shape-animation.png)

![母版幻灯片上页脚占位符动画效果](master-shape-animation.png)

接下来的示例使用新演示文稿中的占位符层次结构。它为母版占位符、布局占位符以及普通幻灯片上的相应占位符添加效果。在使用返回的形状之前，都会检查[Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getBasePlaceholder)的返回值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更改动画时间设置**

PowerPoint 的**Timing**对话框映射到[Timing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/)的属性。

![动画效果的 PowerPoint Timing 对话框](shape-animation.png)

- **Start** 映射到[Timing.getTriggerType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getTriggerType)。
- **Duration** 映射到[Timing.getDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getDuration)，单位为秒。
- **Delay** 映射到[Timing.getTriggerDelayTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getTriggerDelayTime)，单位为秒。
- **Repeat** 映射到[Timing.getRepeatCount](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatCount)、[Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatUntilNextClick)或[Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatUntilEndSlide)。
- **Rewind when done playing** 映射到[Timing.getRewind](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRewind)。

此独立示例添加一个效果，通过[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)返回的对象更改其时间设置，并保存结果。保留返回的[Effect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/)引用可避免不必要的集合索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

有意识地只使用一种重复模式。将重复计数与“直到”标志组合可能在不同查看器中产生混乱的结果。更改重复模式时，请先调用[Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#setRepeatUntilNextClick)和[Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#setRepeatUntilEndSlide)，再调用[Timing.setRepeatCount](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#setRepeatCount)，因为设置任一标志都会更改活动的重复模式。

## **添加和提取动画声音**

动画效果可以通过[Effect.getSound](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getSound)引用嵌入的音频。[Effect.setStopPreviousSound](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#setStopPreviousSound)指示效果停止之前效果启动的音频。

### **为效果添加声音**

下面的示例需要本地音频文件`animation-sound.wav`。它创建两个效果，将该文件嵌入为第一个效果的声音，并配置第二个效果停止该声音。它使用[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)返回的对象，因此无需序列索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **提取嵌入的效果声音**

下面的示例需要本地演示文稿`presentation-with-animation-sounds.pptx`。它扫描主序列和交互序列，并将每个嵌入的效果声音写入`extracted-animation-sounds`目录。扩展名根据[Audio.getContentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audio/#getContentType)返回的音频 MIME 类型选择。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

对于大型音频对象，请使用[Audio.getStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audio/#getStream)并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画结束后行为**

**After animation**选项控制形状在其效果结束后会发生什么。

![PowerPoint 效果选项对话框显示“After animation”设置](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/afteranimationtype/)类支持保持形状不变、改变其颜色、在动画后隐藏，或在下一次点击时隐藏。当类型为[AfterAnimationType.Color](https://reference.aspose.com/slides/zh/python-java/aspose.slides/afteranimationtype/#Color)时，还需设置[Effect.getAfterAnimationColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getAfterAnimationColor)。

此独立示例创建一个效果，通过返回的效果对象设置其动画结束后行为，并保存结果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

将类型从[AfterAnimationType.Color](https://reference.aspose.com/slides/zh/python-java/aspose.slides/afteranimationtype/#Color)更改会清除动画结束后颜色的设置。

## **动画文字**

文字动画有两个相关控制：

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textanimation/#getBuildType) 控制段落是一次性出现还是按段落层级出现。
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getAnimateTextType) 控制文字是一次性出现、按单词还是按字母出现。[Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getDelayBetweenTextParts) 设置单词或字母之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

下面的独立示例为文本框中的单词添加动画。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/buildtype/#AsOneObject) 禁用按段落构建，使单词设置适用于整个文本框。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

要按段落构建文本框，请设置[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh/python-java/aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落层级）。要为单个段落单独设置效果，请使用接受[Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)的[Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect)重载。参见[Animated Text](/slides/zh/python-java/animated-text/)获取段落级别示例。

## **导出和兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不会播放动画。需要显示运动时请使用[HTML5 export](/slides/zh/python-java/export-to-html5/)、动画 GIF 或[video conversion](/slides/zh/python-java/convert-powerpoint-to-video/)。
- 对于 HTML5，请启用[Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateShapes)，必要时再启用[Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateTransitions)。
- 视频渲染支持许多常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请查看当前的[Supported animations and effects](/slides/zh/python-java/convert-powerpoint-to-video/#supported-animations-and-effects)并使用目标 Aspose.Slides 版本对关键演示文稿进行测试。
- 高级自定义效果以及从其他演示文稿格式导入的效果可能会在文件中保留，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不要仅凭效果名称判断。

## **常见问答**

**为什么动画在 PowerPoint 中出现，但在 PDF 中没有？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保留运动时请导出为 HTML5、动画 GIF 或视频。

**为什么同一效果在视频中播放方式不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或会被近似处理。请查看受支持的效果表，并在生产使用前对实际演示文稿进行测试。

**移动形状的前置或后置会改变其动画顺序吗？**

不会。形状的 Z 顺序控制重叠，序列顺序和触发器控制动画播放。如果需要不同的播放顺序，请更改时间轴。