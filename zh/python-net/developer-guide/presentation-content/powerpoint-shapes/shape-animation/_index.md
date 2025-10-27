---
title: Apply Shape Animations in Presentations with Python
linktitle: Shape Animation
type: docs
weight: 60
url: /zh/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
keywords:
- shape
- animation
- effect
- animated shape
- animated text
- add animation
- get animation
- extract animation
- add effect
- get effect
- extract effect
- effect sound
- apply animation
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Discover how to create and customize shape animations in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Stand out!"
---

动画是可以应用于文本、图像、形状或[图表](/slides/zh/python-net/animated-charts/)的视觉效果。它们为演示文稿或其组成部分注入活力。

## **为何在演示文稿中使用动画？**

使用动画，您可以

* 控制信息流动
* 强调重要要点
* 提高受众兴趣或参与度
* 使内容更易阅读、理解或处理
* 吸引读者或观众注意演示文稿中的关键部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 四大类别中提供了大量动画及动画效果选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 命名空间下提供了操作动画所需的类和类型，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 枚举中提供超过 **150 种** 动画效果。这些效果本质上与 PowerPoint 中使用的效果相同（或等价）。

## **为 TextBox 应用动画**

Aspose.Slides for Python via .NET 允许您为形状中的文本应用动画。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。  
4. 向 `IAutoShape.TextFrame` 添加文本。  
5. 获取主动画序列。  
6. 为 [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) 添加动画效果。  
7. 将 `TextAnimation.BuildType` 属性设为 `BuildType` 枚举中的值。  
8. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示了如何为 AutoShape 应用 `Fade` 效果并将文本动画设置为 *按第一级段落*：

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

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

除了为文本应用动画外，您还可以为单个[段落](/slides/zh/python-net/aspose.slides/iparagraph/)应用动画。请参阅[**动画文本**](/slides/zh/python-net/animated-text/)。

{{% /alert %}} 

## **为 PictureFrame 应用动画**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
4. 获取主动画序列。  
5. 为 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 添加动画效果。  
6. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示了如何为图片框应用 `Fly` 效果：

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

## **为 Shape 应用动画**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。  
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)（单击该对象时播放动画）。  
5. 为斜角形创建动画序列。  
6. 创建自定义 `UserPath`。  
7. 为 `UserPath` 添加移动指令。  
8. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示了如何为形状应用 `PathFootball`（路径足球）效果：

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

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

## **获取已应用于 Shape 的动画效果**

以下示例演示如何使用 [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) 类的 `get_effects_by_shape` 方法获取应用于某个形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

前面已经学习了如何在 PowerPoint 演示文稿中为形状添加动画效果。下面的示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状的动画效果。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**示例 2：获取包括占位符继承的所有动画效果**

如果普通幻灯片上的形状有来自版式幻灯片和/或母版幻灯片的占位符，并且这些占位符已经添加了动画效果，则在放映时会播放该形状的所有效果，包括从占位符继承的效果。

假设我们有一个 PowerPoint 文件 `sample.pptx`，其中唯一的幻灯片只包含一个页脚形状，文本为 “Made with Aspose.Slides”，并且该形状已应用 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假设在 **版式** 幻灯片的页脚占位符上应用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

下面的示例代码演示了如何使用 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的 `get_base_placeholder` 方法访问占位符，并获取页脚形状的动画效果，包括来自版式和母版占位符的继承效果。

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

输出：
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **更改动画效果的时间属性**

Aspose.Slides for Python via .NET 允许您修改动画效果的 Timing（时间）属性。

下面是 Microsoft PowerPoint 中的“动画计时”面板：

![example1_image](shape-animation.png)

PowerPoint 计时与 `Effect.Timing` 属性的对应关系：

- PowerPoint 计时中的 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) 属性。  
- PowerPoint 计时中的 **Duration** 对应 `Effect.Timing.Duration` 属性。动画的持续时间（秒）是动画完成一次循环所需的总时间。  
- PowerPoint 计时中的 **Delay** 对应 `Effect.Timing.TriggerDelayTime` 属性。

修改 Effect Timing 属性的步骤：

1. [应用](#apply-animation-to-shape)或获取动画效果。  
2. 为需要的 `Effect.Timing` 属性设置新值。  
3. 保存修改后的 PPTX 文件。

下面的 Python 示例演示了该操作：

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

Aspose.Slides 提供以下属性以便在动画效果中使用声音：

- `sound`
- `stop_previous_sound`

### **添加动画效果声音**

下面的 Python 示例展示了如何为动画效果添加声音，并在下一个效果开始时停止该声音：

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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主动画序列。  
4. 提取每个动画效果中嵌入的 `sound`。

下面的 Python 示例展示了如何提取动画效果中嵌入的声音：

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

## **动画结束后**

Aspose.Slides for .NET 允许您更改动画效果的 “After animation” 属性。

下面是 Microsoft PowerPoint 中的“动画效果”面板及其扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 中 **After animation** 下拉列表对应以下属性：

- `after_animation_type` 属性描述结束动画类型：
  * PowerPoint **More Colors** 对应 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Don't Dim** 对应 [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型（默认）；
  * PowerPoint **Hide After Animation** 对应 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Hide on Next Mouse Click** 对应 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；
- `after_animation_color` 属性定义结束动画的颜色格式。该属性仅在 `after_animation_type` 为 `COLOR` 时有效；若将类型改为其他，颜色会被清除。

下面的 Python 示例演示了如何更改结束动画效果：

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

Aspose.Slides 提供以下属性以便操作动画效果的 **Animate text** 部分：

- `animate_text_type` 描述文本动画类型。形状文本可以按以下方式动画化：
  - 全部一次显示 ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型)；
  - 按单词 ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型)；
  - 按字母 ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) 类型)；
- `delay_between_text_parts` 设置文本块（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

更改 Effect Animate text 属性的步骤：

1. [应用](#apply-animation-to-shape)或获取动画效果。  
2. 将 `build_type` 属性设为 [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) 以关闭 *按段落* 动画模式。  
3. 为 `animate_text_type` 和 `delay_between_text_parts` 设置新值。  
4. 保存修改后的 PPTX 文件。

下面的 Python 示例演示了该操作：

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

## **常见问题**

**在将演示文稿发布到网页时，如何确保动画得以保留？**

请使用[导出为 HTML5](/slides/zh/python-net/export-to-html5/) 并启用负责[形状](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/)和[切换](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)动画的选项。普通 HTML 不会播放幻灯片动画，而 HTML5 会。

**更改形状的 Z 顺序（层次顺序）会如何影响动画？**

动画顺序与绘制顺序相互独立：动画控制出现/消失的时机和方式，而 [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) 决定遮挡关系。二者组合决定最终可见效果。（这是一致的 PowerPoint 行为，Aspose.Slides 的动画与形状模型遵循相同逻辑。）

**在将动画转换为视频时，某些效果是否存在限制？**

总体上[动画受支持](/slides/zh/python-net/convert-powerpoint-to-video/)，但极少数或特定效果在渲染时可能有所不同。建议使用目标效果并结合所使用的库版本进行测试。