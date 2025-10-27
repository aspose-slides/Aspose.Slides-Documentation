---
title: 使用 Python 在演示文稿中应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/python-net/shape-animation/
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义形状动画。脱颖而出！"
---

动画是可以应用于文本、图像、形状或[图表](/slides/zh/python-net/animated-charts/)的视觉效果，为演示文稿或其组成部分注入活力。

## **为什么在演示文稿中使用动画？**

使用动画，您可以：

* 控制信息的呈现顺序  
* 突出重要要点  
* 增加观众的兴趣或参与度  
* 使内容更易阅读、理解或处理  
* 吸引读者或观众的注意力到演示文稿中的关键部分  

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 四大类别中提供了大量动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) 命名空间下提供了处理动画所需的类和类型；  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/) 枚举中提供了超过 **150 种** 动画效果，这些效果本质上与 PowerPoint 中使用的效果相同（或等价）。

## **为 TextBox 应用动画**

Aspose.Slides for Python via .NET 允许您为形状中的文本应用动画。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。  
4. 向 `IAutoShape.TextFrame` 添加文本。  
5. 获取主效果序列。  
6. 为 [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) 添加动画效果。  
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。  
8. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示如何对 AutoShape 应用 `Fade` 效果并将文本动画设置为 *按第一级段落*：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # 添加带文本的 AutoShape
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # 获取幻灯片的主序列。
    sequence = sld.timeline.main_sequence

    # 为形状添加 Fade 动画效果
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # 按第一级段落为形状文本添加动画
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

除了为文本应用动画外，您还可以为单个[段落]https://reference.aspose.com/slides/python-net/aspose.slides.iparagraph/）应用动画。请参阅[**动画文本**](/slides/zh/python-net/animated-text/)。

{{% /alert %}} 

## **为 PictureFrame 应用动画**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。  
4. 获取主效果序列。  
5. 为 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 添加动画效果。  
6. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示如何为图片框应用 `Fly` 效果：

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as pres:
    # 加载要添加到演示文稿图像集合中的图片
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # 向幻灯片添加图片框
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # 获取幻灯片的主序列。
    sequence = pres.slides[0].timeline.main_sequence

    # 为图片框添加从左侧飞入的动画效果
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为 Shape 应用动画**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)。  
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/)（单击该对象时播放动画）。  
5. 为斜角形创建效果序列。  
6. 创建自定义 `UserPath`。  
7. 为 `UserPath` 添加移动指令。  
8. 将演示文稿保存为 PPTX 文件。

下面的 Python 示例演示如何为形状应用 `PathFootball`（路径足球）效果：

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 为已有形状从头创建 PathFootball 效果。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # 添加 PathFootBall 动画效果。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 创建一个类似“按钮”的形状。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # 为按钮创建交互式序列。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # 创建自定义用户路径。只有在单击按钮后对象才会移动。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 为空路径添加移动命令。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # 将 PPTX 文件写入磁盘
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **获取已应用于 Shape 的动画效果**

以下示例演示如何使用 [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) 类的 `get_effects_by_shape` 方法获取某个形状上所有已应用的动画效果。

**示例 1：获取普通幻灯片上某个形状的动画效果**

前面已经演示了如何向 PowerPoint 演示文稿中的形状添加动画效果。下面的示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状的动画效果。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # 获取幻灯片的主动画序列。
    sequence = first_slide.timeline.main_sequence

    # 获取第一张幻灯片上的第一个形状。
    shape = first_slide.shapes[0]

    # 获取已应用于该形状的动画效果。
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("形状", shape.name, "拥有", len(shape_effects), "个动画效果。")
```

**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的某个形状的占位符位于版式幻灯片或母版幻灯片上，并且这些占位符也添加了动画效果，则在放映时会播放该形状的所有动画效果，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中仅在幻灯片底部有一个文本框形状，文本为 “Made with Aspose.Slides”，并且已对该形状应用 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

同时假设在 **版式** 幻灯片的页脚占位符上已应用 **Split** 效果。

![版式形状动画效果](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上已应用 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

下面的示例代码展示了如何使用 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的 `get_base_placeholder` 方法访问占位符，并获取页脚形状的动画效果，包括从版式和母版上的占位符继承的效果。

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 获取普通幻灯片上形状的动画效果。
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # 获取版式幻灯片上占位符的动画效果。
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # 获取母版幻灯片上占位符的动画效果。
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("形状主序列的动画效果:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

输出：

```text
形状主序列的动画效果:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **更改动画效果的时序属性**

Aspose.Slides for Python via .NET 允许您更改动画效果的时序属性。

以下是 Microsoft PowerPoint 中的动画时序面板：

![example1_image](shape-animation.png)

PowerPoint 时序与 `Effect.Timing` 属性的对应关系如下：

- **开始** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) 属性。  
- **持续时间** 对应 `Effect.Timing.Duration` 属性。动画的持续时间（秒）指完成一次循环所需的总时间。  
- **延迟** 对应 `Effect.Timing.TriggerDelayTime` 属性。  

修改 Effect Timing 属性的步骤：

1. [应用](#apply-animation-to-shape) 或获取动画效果。  
2. 为需要的 `Effect.Timing` 属性设置新值。  
3. 保存修改后的 PPTX 文件。  

下面的 Python 示例演示了上述操作：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # 获取幻灯片的主序列。
    sequence = pres.slides[0].timeline.main_sequence

    # 获取主序列的第一个效果。
    effect = sequence[0]

    # 将触发类型改为单击时开始
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 将持续时间改为 3 秒
    effect.timing.duration = 3

    # 将延迟时间改为 0.5 秒
    effect.timing.trigger_delay_time = 0.5

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **动画效果的声音**

Aspose.Slides 为动画效果提供了以下属性，以便您处理声音：

- `sound`  
- `stop_previous_sound`

### **为动画效果添加声音**

下面的 Python 示例演示如何为动画效果添加声音，并在下一个效果启动时停止该声音：

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # 将音频添加到演示文稿的音频集合中
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # 获取幻灯片的主序列。
    sequence = first_slide.timeline.main_sequence

    # 获取主序列的第一个效果
    first_effect = sequence[0]

    # 检查效果是否为 “无声音”
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 为第一个效果添加声音
        first_effect.sound = effect_sound

    # 获取幻灯片的第一个交互式序列。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 设置效果的 “停止前一个声音” 标志
    interactive_sequence[0].stop_previous_sound = True

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **提取动画效果的声音**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主效果序列。  
4. 提取每个动画效果中嵌入的 `sound`。  

下面的 Python 示例展示如何提取动画效果中嵌入的声音：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # 获取幻灯片的主序列。
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # 将效果声音提取为字节数组
        audio = effect.sound.binary_data
```

## **动画结束后（After Animation）**

Aspose.Slides for .NET 允许您更改动画效果的 **After animation** 属性。

以下是 Microsoft PowerPoint 中的动画效果面板及其扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 的 **After animation** 下拉列表对应以下属性：

- `after_animation_type`：描述动画结束后的类型  
  * **More Colors** 对应 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型  
  * **Don't Dim** 对应 [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)（默认）  
  * **Hide After Animation** 对应 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
  * **Hide on Next Mouse Click** 对应 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)  
- `after_animation_color`：定义 **After animation** 的颜色格式。该属性仅在 `after_animation_type` 为 `COLOR` 时起作用；若将类型改为其他，颜色将被清除。

下面的 Python 示例演示如何更改动画结束后的效果：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 获取主序列的第一个效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 将动画结束类型改为颜色
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # 设置动画结束后的暗淡颜色
    first_effect.after_animation_color.color = Color.alice_blue

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **动画文本（Animate Text）**

Aspose.Slides 为动画效果的 *Animate text* 区块提供了以下属性：

- `animate_text_type`：描述文本动画的类型，形状文本可以按以下方式动画化：  
  - **一次性全部**（[ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)）  
  - **按单词**（[BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)）  
  - **按字母**（[BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)）  
- `delay_between_text_parts`：设置文本各部分（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示秒数。

修改 **Animate Text** 属性的步骤：

1. [应用](#apply-animation-to-shape) 或获取动画效果。  
2. 将 `build_type` 属性设置为 [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) 以关闭 *按段落* 动画模式。  
3. 为 `animate_text_type` 与 `delay_between_text_parts` 设置新值。  
4. 保存修改后的 PPTX 文件。  

下面的 Python 示例演示了上述操作：

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 获取主序列的第一个效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 将文本动画类型改为 “一次性全部”
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # 将动画文本类型改为 “按单词”
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 将单词之间的延迟设为效果持续时间的 20%
    first_effect.delay_between_text_parts = 20

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**在将演示文稿发布到 Web 时，如何确保动画得以保留？**

请使用[导出为 HTML5](/slides/zh/python-net/export-to-html5/) 并启用负责[形状](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/)和[切换](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)动画的选项。普通 HTML 不会播放幻灯片动画，而 HTML5 能够播放。

**更改形状的 Z‑order（层级顺序）会如何影响动画？**

动画顺序与绘制顺序相互独立：动画决定出现/消失的时机和方式，而 [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) 决定哪一个覆盖哪一个。最终的可视效果由两者共同决定。（这与 PowerPoint 的通用行为一致，Aspose.Slides 的模型亦遵循相同逻辑。）

**在将动画转换为视频时，某些效果是否存在限制？**

总体而言，[动画受支持](/slides/zh/python-net/convert-powerpoint-to-video/)，但极少数特殊效果可能会出现不同的渲染效果。建议使用您实际使用的效果并结合当前库版本进行测试。