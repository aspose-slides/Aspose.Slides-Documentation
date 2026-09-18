---
title: 在 Python 中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/python-net/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中创建、检查并修改自定义动画行为和可编辑的运动路径。"
---
## **概述**

自定义动画行为让您能够控制动画效果中的各个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本指南展示了如何创建和组合行为、配置其时间、检查和修改现有动画，以及验证其属性在保存并重新打开演示文稿后是否仍然存在。

有关预定义效果和点击触发器，请参阅[形状动画](/slides/zh/python-net/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **时间轴 → 序列 → 效果 → 行为**：

- 幻灯片的[时间轴](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseslide/timeline/)包含其主序列和交互序列。
- 一个[序列](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/)包含效果，可能针对不同的形状。
- 一个[Effect]标识目标形状、预设、子类型以及效果时间。
- [Effect.behaviors](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/behaviors/)包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用[Sequence.add_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/sequence/add_effect/)来创建效果并访问其[behaviors](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/behaviors/)集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用[clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/clear/)。

[BehaviorFactory](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/)创建下面示例中展示的八种行为类型。运动行为详见[构建运动路径](#build-a-motion-path)。每个创建示例都是完整程序；后面的编辑示例会说明使用的输出文件。

### **旋转**

使用[create_rotation_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/)创建旋转。[by](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/rotationeffect/by/)指定相对角度（度）；[from_address](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/rotationeffect/from_address/)和[to](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/rotationeffect/to/)指定端点。

示例从 Spin 效果开始，用一个旋转行为替换其预设操作，并将该操作的持续时间设为两秒。90 度的相对角度表示相对于形状起始方向的四分之一次转，因此无需显式指定起始角度。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均使用此文件。

### **缩放**

使用[create_scale_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/)并提供 X/Y 百分比：`from_address` 和 `to` 描述起始和结束大小，`by` 描述相对变化。这里的 100 表示原始大小。

示例在两秒内将两个维度从 100% 放大到 125%。使用相等的水平和垂直百分比可保持形状的比例；不同的百分比会使某一维度拉伸得更多。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **颜色**

使用[create_color_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/)将填充颜色从蓝色更改为橙色。`from_address` 和 `to` 是颜色；`by` 是颜色偏移量。[Behavior.properties](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/properties/)标识被动画化的属性。

形状的实色填充初始化为蓝色，与动画的起始颜色匹配。选择填充颜色属性告诉行为要更改形状的哪个部分；仅仅提供颜色端点并不能确定该属性。保存的效果描述了两秒内过渡到橙色的过程。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **滤镜**

使用[create_filter_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/)选择一个擦除效果。[type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/filtereffect/type/)、[subtype](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/filtereffect/subtype/)和[reveal](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/filtereffect/reveal/)分别指定滤镜、方向以及是显示还是隐藏形状。

本例配置了一个两秒的擦除效果，使用右向子类型显示形状。滤镜设置属于效果内部的行为，因此在删除预设的原始操作后进行配置。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **属性**

使用[create_property_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/)对不透明度进行动画化。[from_address](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/from_address/)、[to](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/to/)和[by](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/by/)是字符串，需结合[value_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/value_type/)和[calc_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/propertyeffect/calc_mode/)进行解释。请根据需要选择端点或相对偏移，而不是同时设置三个值。

这里选择的属性是不透明度，数值字符串表示从 25% 不透明度变化到完全不透明。线性插值描述了这些值之间的渐变。当将本示例改用于其他属性时，请为该属性选择合适的值类型和端点值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **设置**

使用[create_set_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/)通过[to](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/seteffect/to/)赋值可见性。设置行为不会在端点之间进行插值。

示例选择可见性属性，并在行为运行时将字符串`visible`赋给它。矩形在此最小演示文稿中已经是可见的，因此单独进行赋值可能看不出明显的视觉变化。此类操作在更大的效果中很有用，例如同时控制形状何时隐藏或显示。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **命令**

使用[create_command_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/)并配置[type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/commandeffect/type/)、[command_string](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/commandeffect/command_string/)和[shape_target](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/commandeffect/shape_target/)。在工作目录中放置名为`sample.wav`的 WAV 录音。本例通过[add_audio_frame_embedded](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/)将其嵌入，并为音频帧附加播放命令。

音频帧既是效果的目标也是命令的目标。这样将播放请求关联到嵌入的录音；单独的命令字符串并不能指明要控制的媒体对象。该效果配置为在幻灯片放映期间点击时启动。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

保存后将命令存储在`command.pptx`中；不会自动播放录音。播放需要支持该命令及其媒体目标的幻灯片播放器。

## **管理行为集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/)支持[add](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/add/)、[insert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/insert/)、[remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/remove/)、[remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorcollection/remove_at/)。本例打开`rotation.pptx`，添加缩放行为，将其插入到旋转之前，然后移除旋转。删除后再次插入同一对象会改变其存储位置而不产生副本。

编辑顺序先把集合从 旋转–缩放 变为 缩放–旋转，最后只剩缩放。索引始终指向当前集合，因此在重新排序后移除时使用旋转的新索引。最终枚举确认了将被保存的行为。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

输出为`ScaleEffect`：仅保留缩放。仅靠集合顺序并不能安排行为依次执行。仅在替换所有操作时才清空集合。

## **配置行为时间**

[Behavior.timing](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/timing/)公开[Timing](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/)，独立于[Effect.timing](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/timing/)。效果时间调度整个效果；行为时间描述其内部的单个操作。

### **设置持续时间、延迟、重复和加速**

打开`rotation.pptx`并以秒为单位设置[duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/duration/)和[trigger_delay_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/trigger_delay_time/)，然后配置[repeat_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_count/)。[accelerate](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/accelerate/)和[decelerate](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/decelerate/)是持续时间的分数，二者之和最多为 1。

输入文件为旋转示例中创建的文件，已知第一个行为是旋转。本例仅修改该行为的时间，90 度角保持不变。将角度与时间分离，可在不重新构建动画的情况下轻松调整节奏。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

该行为使用两秒持续时间、半秒延迟以及 3 次重复。其持续时间的前后各 20% 用于加速和减速。

其他重复策略包括[repeat_duration](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_duration/)、[repeat_until_end_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_end_slide/)、[repeat_until_next_click](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/repeat_until_next_click/)；请从中选择一种，而不是同时启用全部。[auto_reverse](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/timing/auto_reverse/)会在正向播放后逆向播放。加速和减速仅适用于连续变化，不适用于离散赋值或命令。

## **构建运动路径**

使用[create_motion_effect](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/)创建运动。其[from_address](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/from_address/)、[to](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/to/)和[by](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/by/)描述基于百分比的坐标或偏移。若需可编辑路线，请创建[MotionPath](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motionpath/)并将其分配给[MotionEffect.path](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/path/)。[MotionPath]存储路径命令。

[MotionCommandPathType]选择操作：

| 命令 | 点数 | 含义 |
| --- | --- | --- |
| MOVE_TO | One | 设置起始位置。 |
| LINE_TO | One | 沿直线段移动到终点。 |
| CURVE_TO | Three | 按两个控制点和终点定义的三次曲线进行跟随。 |
| CLOSE_LOOP | None | 返回起始位置。 |
| END | None | 完成路径。 |

[MotionPathPointsType]描述点的编辑特性，例如拐角点或平滑点。它并不替代命令类型。曲线示例使用曲线点类型，直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸进行归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正 Y 向下。绝对命令在路径坐标系中指定位置，相对命令指定相对于当前位移的偏移。这与[origin](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/origin/)（选择路径参考框架）以及[path_edit_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioneffect/path_edit_mode/)（控制形状移动时路径如何跟随）是分开的。

### **创建直线路径**

创建一个运动行为，包含起始点、一个直线段和结束命令。[MotionPath.add](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motionpath/add/)接受命令类型、其点、点类型以及相对坐标标志。

起始命令设为 (0, 0)，直线结束于 (0.25, 0)，使路径在水平方向上位移了幻灯片宽度的四分之一。结束命令没有坐标点。路径分配完成后，将运动行为添加到效果，即可将该路线关联到矩形。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` 包含一个包含三条路径命令的运动行为。下面的文件编辑示例基于此已知结构。

### **比较绝对坐标和相对坐标**

以下两个路径对象描述相同的路线。绝对命令以 (0.3, 0.1) 为终点；相对命令在当前位姿 (0.2, 0) 上加上 (0.1, 0.1)。

两条路径均从相同位置开始。对于相对直线，将其 X、Y 偏移量加到当前位姿得到终点；对于绝对直线，则直接读取终点坐标。若未转换坐标而仅切换标志，将得到不同的路线。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

将任意路径分配给运动行为即可在演示文稿中使用。最后的布尔参数用于为该命令选择相对坐标。

### **用曲线替换直线**

打开`motion.pptx`并将其直线命令替换为三次曲线。先提供两个控制点，再提供终点。

起始位置由前一命令提供。前两个点决定曲线形状，第三个点为曲线的终点；它们不是三个连续的目标点。同步更新命令类型、点编辑类型和点数组，可保证段落与新几何保持一致。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx` 中的路径仍有三条命令，只是其中的中间命令现在定义为曲线。

## **检查并编辑已保存的路径**

每个[MotionCmdPath](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioncmdpath/)公开[points](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioncmdpath/points/)、[command_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioncmdpath/command_type/)、[points_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioncmdpath/points_type/)和[is_relative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motioncmdpath/is_relative/)。以下示例使用 `motion.pptx` 中已知的三条命令路径。对任意输入文件，请在按索引编辑之前定位目标效果并检查命令类型及点数。

### **读取命令和坐标**

在不修改路径的情况下读取。结束和闭环命令不需要点，因此需要允许 `None` 点数组。

输出在列出点之前，将每个命令与其相对坐标标志配对。这让您在修改路径前能够区分是端点还是偏移。曲线会列出三个点，而本文件中的直线仅列出一个点。

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

列表包含起始点、一个绝对直线结束于 (0.25, 0) 的命令以及结束命令。

### **更改端点**

打开`motion.pptx`并替换直线的点数组，以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单个点会改变其目标位置，而不会改变命令类型、时间或在集合中的位置。由于该命令使用绝对坐标，新坐标对指定的是位置而非增量偏移。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx` 中的直线结束于 (0.4, 0.1)；原文件保持不变。

### **替换段落**

使用[insert](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motionpath/insert/)和[remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/motionpath/remove_at/)替换 `motion.pptx` 中的直线。插入操作会将旧的直线移至索引 2。

此示例演示了替换命令对象而不是编辑其已有坐标。插入后，集合暂时包含起始命令、新直线、旧直线和结束命令。删除索引 2 即可丢弃旧直线，保留新的路线。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

保存的路径仍有三条命令，新的直线结束于 (0.2, 0.1)，结束命令仍在最后。

## **修改并验证现有行为**

当行为索引未知时，可按类型选择。本例打开`rotation.pptx`，查找其[RotationEffect]，更改角度，并在重新打开后检查保存的值。

类型检查使循环能够跳过非旋转行为。第二次加载将已保存的文件读取到独立的演示对象中，从而比较的是持久化数据而不是仍在内存中的值。该示例仍假设已知效果是主序列中的第一个；仅按类型选择行为并不能在任意演示文稿中定位正确的效果。

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

输出为`Rotation preserved: True`。对其他行为同样使用类型检查模式。若要进行完整的保留检查，请比较目标形状、效果、行为类型和顺序、时间以及路径命令。对浮点值使用数值容差。对于动画布局未知的演示文稿，请参阅[读取形状动画](/slides/zh/python-net/shape-animation/#read-shape-animations)以遍历主序列和交互序列。

## **行为顺序、预设和播放**

[BehaviorCollection]中的顺序是效果操作的存储顺序。它并非一个播放列表，不能保证每个行为自动等候前一个完成。调度由时间和封闭的效果决定。行为可以重叠，对同一属性的操作可能通过[additive](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/additive/)和[accumulate](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/behavior/accumulate/)产生交互。不要仅通过重新排序集合来实现“先移动后旋转”；请使用显式时间或如[形状动画](/slides/zh/python-net/shape-animation/)中描述的分离效果。

效果的[type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/type/)和[subtype](https://reference.aspose.com/slides/zh/python-net/aspose.slides.animation/effect/subtype/)描述其预设。它们并未完整描述已编辑的行为树。请选择预设和子类型后再自定义行为：更改预设会重新构建集合并丢弃自定义操作。例如，将自定义的 Spin 效果改为 Fade 可能会用设置和滤镜行为替换其旋转行为。更改预设或子类型后请再次检查集合。清除预设行为也可能删除预设所需的可见性或初始化操作。示例刻意使用可见形状并替换行为，而不重新构建每个预设的实现。

## **格式兼容性**

已保留的行为树并不能保证在所有查看器或导出渲染器中完全相同的播放效果。请分别检查保存的数据和渲染输出。

| 格式或输出 | 需要验证的内容 |
| --- | --- |
| PPTX | 本示例的主要格式。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放效果。 |
| PPT | 传统二进制表示可能与 PPTX 不同。请单独进行保存‑重新打开‑播放的循环测试；不要仅凭 PPTX 成功就推断所有自定义组合均受支持。 |
| PDF、PNG、JPEG 以及其他静态幻灯片图像 | 只包含静态幻灯片表示，未包含可播放的行为时间线或保证的最终动画帧。 |
| [HTML5](/slides/zh/python-net/export-to-html5/) | 在导出选项中启用形状动画后可播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/python-net/convert-powerpoint-to-animated-gif/) | 存储渲染的帧，而非可编辑行为或点击触发的交互。请检查实际渲染的运动。 |
| [Video](/slides/zh/python-net/convert-powerpoint-to-video/) | 渲染动画帧并编码为视频。支持受渲染器的[受支持动画和效果](/slides/zh/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)限制；命令和交互事件不会成为可编辑的时间线。 |

## **常见问题**

**为什么我的效果在未添加任何行为前就已经包含行为？**

创建预定义效果时可能已经生成了其底层操作。请先检查这些操作，然后决定是扩展预设还是替换其行为。

**把行为移动到集合开头会使它先播放吗？**

不一定。集合顺序并不能替代时间设置。请检查延迟、持续时间以及同一属性上操作之间的交互。

**为什么结束命令没有点？**

结束命令标记路径的结束，不需要坐标。检查从文件读取的路径时，需要对 `None` 点数组进行判断。

**一次成功的往返保存足以确认播放吗？**

不能。重新打开只能确认您检查的属性是否被保留。仍需在幻灯片播放器或动画导出中单独测试，以确认其视觉行为。