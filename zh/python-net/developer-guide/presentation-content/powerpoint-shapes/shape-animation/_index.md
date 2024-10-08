---
title: 形状动画
type: docs
weight: 60
url: /zh/python-net/shape-animation/
keywords: "PowerPoint 动画, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中创建 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或 [图表](/slides/zh/python-net/animated-charts/) 的视觉效果。它们为演示文稿或其组成部分带来了生命。

### **为什么在演示文稿中使用动画？**

使用动画，您可以

* 控制信息的流动
* 强调重要点
* 增加观众的兴趣或参与度
* 使内容更易于阅读、吸收或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 提供了许多选项和工具，用于在 **入场**、**退场**、**强调** 和 **运动路径** 类别中应用动画和动画效果。

### **Aspose.Slides 中的动画**

* Aspose.Slides 提供您需要的类和类型，以在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 命名空间下处理动画，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 枚举中提供超过 **150 种动画效果**。这些效果实际上与 PowerPoint 中使用的效果基本相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for Python via .NET 允许您将动画应用于形状中的文本。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 向 `IAutoShape.TextFrame` 添加文本。
5. 获取效果的主序列。
6. 向 [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) 添加动画效果。
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。
8. 将演示文稿写入磁盘作为 PPTX 文件。

此 Python 代码向您展示如何将 `Fade` 效果应用于 AutoShape，并将文本动画设置为 *按第 1 层段落* 的值：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "第一段 \n第二段 \n第三段"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

除了将动画应用于文本之外，您还可以将动画应用于单个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/)。请参阅 [**动画文本**](/slides/zh/python-net/animated-text/)。

{{% /alert %}} 

## **将动画应用于图像框**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。
4. 获取效果的主序列。
5. 向 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 添加动画效果。
6. 将演示文稿写入磁盘作为 PPTX 文件。

此 Python 代码向您展示如何将 `Fly` 效果应用于图像框：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **将动画应用于形状**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)（当单击此对象时，播放动画）。
5. 在斜面形状上创建一个效果序列。
6. 创建一个自定义的 `UserPath`。
7. 添加移动到 `UserPath` 的命令。
8. 将演示文稿写入磁盘作为 PPTX 文件。

此 Python 代码向您展示如何将 `PathFootball`（路径足球）效果应用于形状：

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("动画文本框")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **获取应用于形状的动画效果**

您可能会决定查找应用于单个形状的所有动画效果。

此 Python 代码向您展示如何获取应用于特定形状的所有效果：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = firstSlide.timeline.main_sequence

    # Gets the first shape on slide.
    shape = firstSlide.shapes[0]

    # Gets all animation effects applied to the shape.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("形状 " + shape.name + " 有 " + str(len(shapeEffects)) + " 个动画效果。")
```

## **更改动画效果的时间属性**

Aspose.Slides for Python via .NET 允许您更改动画效果的时间属性。

这是 Microsoft PowerPoint 中的动画时间窗格：

![example1_image](shape-animation.png)

这些是 PowerPoint 时间与 `Effect.Timing` 属性之间的对应关系：

- PowerPoint 时间 **开始** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) 属性。
- PowerPoint 时间 **持续时间** 对应 `Effect.Timing.Duration` 属性。动画的持续时间（以秒为单位）是动画完成一个周期所需的总时间。
- PowerPoint 时间 **延迟** 对应 `Effect.Timing.TriggerDelayTime` 属性。

这就是如何更改效果时间属性的方法：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 为所需的 `Effect.Timing` 属性设置新值。
3. 保存修改后的 PPTX 文件。

此 Python 代码演示了操作：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **动画效果声音**

Aspose.Slides 提供这些属性来允许您处理动画效果中的声音：

- `sound`
- `stop_previous_sound`

### **添加动画效果声音**

此 Python 代码向您展示如何添加动画效果声音，并在下一个效果开始时停止它：

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **提取动画效果声音**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 获取效果的主序列。
4. 提取嵌入到每个动画效果中的 `sound`。

此 Python 代码向您展示如何提取嵌入在动画效果中的声音：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **动画后**

Aspose.Slides for .NET 允许您更改动画效果的动画后属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **动画后** 下拉列表对应以下属性：

- `after_animation_type` 属性描述动画后的类型：
  * PowerPoint **更多颜色** 对应 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **不减淡** 列表项对应 [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型（默认动画后类型）；
  * PowerPoint **在动画后隐藏** 项对应 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **在下一个鼠标单击时隐藏** 项对应 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
- `after_animation_color` 属性定义动画后的颜色格式。此属性与 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型一起工作。如果您将类型更改为其他类型，则将清除动画后的颜色。

此 Python 代码向您展示如何更改动画后的效果：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **动画文本**

Aspose.Slides 提供这些属性，以允许您处理动画效果的 *动画文本* 块：

- `animate_text_type` 描述效果的动画文本类型。形状文本可以动画：
  - 一次性全部（[ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型）
  - 按单词（[BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型）
  - 按字母（[BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型）
- `delay_between_text_parts` 设置动画文本部分（单词或字母）之间的延迟。正值指定效果持续时间的百分比。负值指定以秒为单位的延迟。

这就是您可以更改效果动画文本属性的方法：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 将 `build_type` 属性设置为 [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) 值，以关闭 *按段落* 动画模式。
3. 设置 `animate_text_type` 和 `delay_between_text_parts` 属性的新值。
4. 保存修改后的 PPTX 文件。

此 Python 代码演示了操作：

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```