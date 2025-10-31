---
title: 使用 Python 在演示文稿中应用形状动画
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义形状动画。脱颖而出！"
---

动画是可以应用于文本、图像、形状或[图表](/slides/zh/python-net/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予活力。 

## **为什么在演示文稿中使用动画？**

使用动画，您可以 

* 控制信息的流动
* 强调重要要点
* 提高观众的兴趣或参与度
* 使内容更易于阅读、吸收或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在**进入**、**退出**、**强调**和**运动路径**类别中提供了许多动画和动画效果的选项和工具。 

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 Aspose.Slides.Animation 命名空间下提供了处理动画所需的类和类型，  
* Aspose.Slides 在 EffectType 枚举中提供了超过 150 种动画效果。这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。  

## **将动画应用于 TextBox**

Aspose.Slides for Python via .NET 允许您对形状中的文本应用动画。 

1. 创建 Presentation 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` 类型的 IAutoShape。  
4. 向 IAutoShape.TextFrame 添加文本。  
5. 获取主效果序列。  
6. 向 IAutoShape 添加动画效果。  
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。  
8. 将演示文稿保存为 PPTX 文件到磁盘。  

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 类。
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # 添加带文本的新 AutoShape
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # 获取幻灯片的主序列。
    sequence = sld.timeline.main_sequence

    # 为形状添加淡入淡出动画效果
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # 按一级段落对形状文本进行动画处理
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 
除了对文本应用动画之外，您还可以对单个[段落](/slides/zh/python-net/animated-text/)应用动画。请参阅[**动画文本**](/slides/zh/python-net/animated-text/)。 
{{% /alert %}} 

## **将动画应用于 PictureFrame**

1. 创建 Presentation 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 PictureFrame。  
4. 获取主效果序列。  
5. 向 PictureFrame 添加动画效果。  
6. 将演示文稿保存为 PPTX 文件到磁盘。  

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# 实例化一个表示演示文稿文件的 Presentation 类。
with slides.Presentation() as pres:
    # 加载要添加到演示文稿图像集合中的图像
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

## **将动画应用于 Shape**

1. 创建 Presentation 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` 类型的 IAutoShape。  
4. 添加一个 `Bevel` IAutoShape（点击此对象时播放动画）。  
5. 为 bevel 形状创建效果序列。  
6. 创建自定义 `UserPath`。  
7. 为 `UserPath` 添加移动命令。  
8. 将演示文稿保存为 PPTX 文件到磁盘。  

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 为现有形状从头创建 PathFootball 效果。
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # 添加 PathFootBall 动画效果。
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 创建一种“按钮”。
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # 为按钮创建效果序列。
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # 创建自定义用户路径。我们的对象仅在按钮被点击后移动。
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 添加移动命令，因为创建的路径为空。
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # 将 PPTX 文件写入磁盘
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **获取形状的动画效果**

以下示例展示如何使用 Sequence 类的 `get_effects_by_shape` 方法获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

以前，您已经学习了如何向 PowerPoint 演示文稿中的形状添加动画效果。下面的示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # 获取幻灯片的主动画序列。
    sequence = first_slide.timeline.main_sequence

    # 获取第一张幻灯片上的第一个形状。
    shape = first_slide.shapes[0]

    # 获取应用于该形状的动画效果。
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状有来自版式幻灯片和/或母版幻灯片的占位符，并且这些占位符已添加动画效果，则在幻灯片放映期间该形状将播放包括从占位符继承的所有效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中仅有一个页脚形状，文本为 “Made with Aspose.Slides”，并对该形状应用了 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

再假设在 **布局** 幻灯片的页脚占位符上应用了 **Split** 效果。

![布局形状动画效果](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

以下示例代码展示了如何使用 Shape 类的 `get_base_placeholder` 方法访问形状占位符，并获取页脚形状的动画效果，包括从布局和母版幻灯片的占位符继承的效果。

```python
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```python
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 获取普通幻灯片上形状的动画效果。
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # 获取布局幻灯片上占位符的动画效果。
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # 获取母版幻灯片上占位符的动画效果。
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

输出:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **更改动画效果的时间属性**

Aspose.Slides for Python via .NET 允许您更改动画效果的 Timing（计时）属性。

这是 Microsoft PowerPoint 中的 Animation Timing 面板：

![示例1_图片](shape-animation.png)

以下是 PowerPoint Timing 与 `Effect.Timing` 属性之间的对应关系：

- PowerPoint 时间 **开始** 下拉列表对应 `Effect.Timing.TriggerType` 属性。  
- PowerPoint 时间 **持续时间** 对应 `Effect.Timing.Duration` 属性。动画的持续时间（以秒为单位）是动画完成一个循环所需的总时间。  
- PowerPoint 时间 **延迟** 对应 `Effect.Timing.TriggerDelayTime` 属性。  

更改 Effect Timing 属性的步骤：

1. [将动画应用于形状](#apply-animation-to-shape)或获取已存在的动画效果。  
2. 为需要的 `Effect.Timing` 属性设置新值。  
3. 保存已修改的 PPTX 文件。  

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 类。
with slides.Presentation("AnimExample_out.pptx") as pres:
    # 获取幻灯片的主序列。
    sequence = pres.slides[0].timeline.main_sequence

    # 获取主序列的第一个效果。
    effect = sequence[0]

    # 将效果的 TriggerType 更改为点击开始
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 更改效果的 Duration
    effect.timing.duration = 3

    # 更改效果的 TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **动画效果声音**

Aspose.Slides 提供以下属性，以便在动画效果中使用声音：

- `sound`  
- `stop_previous_sound`  

### **添加动画效果声音**

下面的 Python 代码演示了如何为动画效果添加声音，并在下一个效果开始时停止它：

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

    # 检查该效果是否为“无声音”
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 为第一个效果添加声音
        first_effect.sound = effect_sound

    # 获取幻灯片的第一个交互序列。
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 设置效果的 “Stop previous sound” 标志
    interactive_sequence[0].stop_previous_sound = True

    # 将 PPTX 文件写入磁盘
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **提取动画效果声音**

1. 创建 Presentation 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主效果序列。  
4. 提取每个动画效果中嵌入的 `sound`。  

下面的 Python 代码演示了如何提取动画效果中嵌入的声音：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 类。
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

## **后动画（After Animation）**

Aspose.Slides for .NET 允许您更改动画效果的 After animation（后动画）属性。

这是 Microsoft PowerPoint 中的 Animation Effect 面板及其扩展菜单：

![示例1_图片](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉列表对应以下属性：

- `after_animation_type` 属性描述 After animation 类型：  
  * PowerPoint **更多颜色** 对应 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **不暗淡** 对应 [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型（默认）；  
  * PowerPoint **动画后隐藏** 对应 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **下次点击隐藏** 对应 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型。  
- `after_animation_color` 属性定义 After animation 的颜色格式。该属性与 [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) 类型配合使用。若将类型更改为其他，After animation 颜色将被清除。

下面的 Python 代码演示了如何更改后动画效果：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 类
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 获取主序列的第一个效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 将 after animation 类型更改为 Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # 设置 after animation 的暗淡颜色
    first_effect.after_animation_color.color = Color.alice_blue

    # 将 PPTX 文件写入磁盘
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **动画文本（Animate Text）**

Aspose.Slides 提供以下属性，以便使用动画效果的 *Animate text* 块：

- `animate_text_type`：描述效果的动画文本类型。形状文本可以按以下方式动画：
  - 一次性全部显示（ALL_AT_ONCE）
  - 按单词（BY_WORD）
  - 按字母（BY_LETTER）
- `delay_between_text_parts` 设置动画文本部分（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

更改 Animate text 属性的步骤：

1. [将动画应用于形状](#apply-animation-to-shape)或获取已存在的动画效果。  
2. 将 `build_type` 属性设置为 `AS_ONE_OBJECT` 值，以关闭 *By Paragraphs* 动画模式。  
3. 为 `animate_text_type` 和 `delay_between_text_parts` 属性设置新值。  
4. 保存已修改的 PPTX 文件。  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 获取主序列的第一个效果
    first_effect = first_slide.timeline.main_sequence[0]

    # 将效果的文本动画类型更改为 “As One Object”
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # 将效果的 Animate text 类型更改为 “By word”
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 将单词之间的延迟设置为效果持续时间的 20%
    first_effect.delay_between_text_parts = 20

    # 将 PPTX 文件写入磁盘
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**如何确保在将演示文稿发布到 Web 时动画能够保留？**

使用 [Export to HTML5](/slides/zh/python-net/export-to-html5/) 并启用负责形状和过渡动画的选项。普通 HTML 不会播放幻灯片动画，而 HTML5 会。

**更改形状的 z‑order（层次顺序）会如何影响动画？**

动画和绘制顺序是独立的：效果控制出现/消失的时间和类型，而 z‑order 决定覆盖关系。两者的组合决定可见效果。（这是 PowerPoint 的一般行为，Aspose.Slides 的效果与形状模型遵循相同逻辑。）

**在将动画转换为视频时某些效果是否存在限制？**

总体而言，动画是受支持的，但在少数情况下或特定效果可能渲染不同。建议使用您使用的效果和库版本进行测试。