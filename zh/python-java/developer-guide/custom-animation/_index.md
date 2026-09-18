---
title: 在 Python（通过 Java）中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/python-java/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建、检查和修改自定义动画行为以及可编辑的运动路径。"
---
## **概述**

自定义动画行为允许您控制动画效果中的单个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本指南展示了如何创建和组合行为、配置它们的时间、检查和修改现有动画，以及验证它们的属性在保存并重新打开演示文稿后是否仍然保留。

有关预定义效果和点击触发器，请参阅[形状动画](/slides/zh/python-java/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **Timeline → Sequence → Effect → Behaviors**：

- [getTimeline](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getTimeline) 方法返回幻灯片时间轴，其中包含主序列和交互序列。
- [Sequence](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/) 包含效果，可能针对不同的形状。
- [Effect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/) 标识目标形状、预设、子类型以及效果时间。
- [Effect.getBehaviors](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getBehaviors) 返回的集合包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用 [Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect) 创建效果并访问 [getBehaviors](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getBehaviors) 集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用 [clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/#clear)。

[BehaviorFactory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/) 创建下文示例中说明的八种行为类型。运动行为在[构建运动路径](#build-a-motion-path)中介绍。每个片段均包含其导入并在必要时启动 JVM。Java 点对象和数组通过 JPype 创建，以满足 API 要求。后续编辑示例会说明使用的输出文件。

### **旋转**

使用 [createRotationEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createRotationEffect) 创建旋转。[getBy](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotationeffect/#getBy) 指定相对角度（度）；[getFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotationeffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotationeffect/#getTo) 指定端点。

示例从 Spin 效果开始，用一个旋转行为替换其预设操作，并为该操作设置两秒持续时间。90 度的相对角度表示形状起始方向的四分之一转弯，因此不需要显式的起始角度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均使用此文件。

### **缩放**

使用 [createScaleEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createScaleEffect) 并提供 X/Y 百分比：[getFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/scaleeffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/scaleeffect/#getTo) 描述起始和结束尺寸，而 [getBy](https://reference.aspose.com/slides/zh/python-java/aspose.slides/scaleeffect/#getBy) 描述相对变化。这里 100 表示原始尺寸。

示例在两秒内将两个维度从 100% 增长到 125%。使用相等的水平和垂直百分比可保持形状比例；不同的百分比会使某一维度拉伸得更多。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **颜色**

使用 [createColorEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createColorEffect) 将填充从蓝色更改为橙色。[getFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/coloreffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/coloreffect/#getTo) 是颜色；[getBy](https://reference.aspose.com/slides/zh/python-java/aspose.slides/coloreffect/#getBy) 是颜色偏移。[Behavior.getProperties](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behavior/#getProperties) 标识被动画化的属性。

形状的实心填充初始化为蓝色，匹配动画的起始颜色。选择填充颜色属性告诉行为要更改形状的哪一部分；仅有颜色端点并不能确定该属性。已保存的效果描述了两秒到橙色的过渡。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **滤镜**

使用 [createFilterEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createFilterEffect) 选择擦除效果。[getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filtereffect/#getType)、[getSubtype](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filtereffect/#getSubtype) 和 [getReveal](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filtereffect/#getReveal) 分别指定滤镜、方向以及是显示还是隐藏形状。

本例配置了一个两秒的擦除，使用右方向子类型显示形状。滤镜设置属于效果内部的行为，因此在移除预设的原始操作后进行配置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **属性**

使用 [createPropertyEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) 为不透明度设置动画。[getFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/propertyeffect/#getFrom)、[getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/propertyeffect/#getTo) 和 [getBy](https://reference.aspose.com/slides/zh/python-java/aspose.slides/propertyeffect/#getBy) 为字符串，需通过 [getValueType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/propertyeffect/#getValueType) 和 [getCalcMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/propertyeffect/#getCalcMode) 进行解释。请选择端点或相对偏移，而非不加区分地同时设置三者。

此处选择的属性是不透明度，数值字符串表示从 25% 不透明度变为完全不透明。线性插值描述了这些值之间的渐变。当将示例应用到其他属性时，请为该属性选择合适的值类型和端点值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **设置**

使用 [createSetEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createSetEffect) 通过 [getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/seteffect/#getTo) 赋值可见性。设置行为不在端点之间插值。

示例选择可见性属性，并在行为运行时将字符串 `visible` 赋给它。矩形在此最小演示文稿中已经可见，因此单独的赋值可能不会产生明显的视觉变化。此类操作在更大效果中有用，例如配合控制形状何时隐藏或显示。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **命令**

使用 [createCommandEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createCommandEffect) 并配置 [getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commandeffect/#getType)、[getCommandString](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commandeffect/#getCommandString) 与 [getShapeTarget](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commandeffect/#getShapeTarget)。将名为 `sample.wav` 的 WAV 录音放在工作目录中。示例使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 将其嵌入，并将播放命令附加到音频帧上。

音频帧既是效果的目标也是命令的目标。这将播放请求连接到嵌入的录音；仅有命令字符串并不能指明要控制的媒体对象。效果配置为在幻灯片放映期间点击时启动。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存后将命令存储在 `command.pptx` 中；它不会播放录音。播放需要支持该命令及其媒体目标的幻灯片放映程序。

## **管理行为集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/) 支持 [add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/#add)、[insert](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/#insert)、[remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/#remove) 与 [removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/#removeAt)。本示例打开 `rotation.pptx`，添加缩放行为，在旋转前插入它，并移除旋转。移除后重新插入相同对象会更改其存储位置而不会产生副本。

编辑顺序将集合从 rotation–scale 变为 scale–rotation，随后仅剩缩放。索引指向当前集合，因此移除时使用旋转在重新排序后的新索引。最终枚举确认了将被保存的行为。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

输出为 `ScaleEffect`：仅保留缩放。集合顺序本身并不安排行为逐个执行。仅在全部替换其操作时才清空集合。

## **配置行为时间**

[Behavior.getTiming](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behavior/#getTiming) 暴露 [Timing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/)，独立于 [Effect.getTiming](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getTiming)。Effect 时间安排整体效果；行为时间描述其内部的操作。

### **设置持续时间、延迟、重复和加速**

打开 `rotation.pptx`，使用秒为单位设置持续时间 ([getDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getDuration)) 与触发延迟 ([getTriggerDelayTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getTriggerDelayTime))，然后通过 [setRepeatCount](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#setRepeatCount) 配置重复次数。[getAccelerate](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getAccelerate) 和 [getDecelerate](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getDecelerate) 为持续时间的分数；保持它们之和不超过 1。

输入文件为旋转示例中创建的文件，其中第一个行为已知是旋转。此示例仅更改该行为的时间；其 90 度角保持不变。将角度和时间分离，可在不重新构建动画的情况下更容易调整节奏。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

该行为使用两秒持续时间、半秒延迟和 3 次重复。其持续时间的前后 20% 用于加速和减速。

其他重复策略包括 [getRepeatDuration](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatDuration)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) 与 [getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getRepeatUntilNextClick)；请选择一种策略，而不是全部同时启用。[getAutoReverse](https://reference.aspose.com/slides/zh/python-java/aspose.slides/timing/#getAutoReverse) 会在正向播放后反向播放。加速和减速适用于连续变化，而非离散赋值或命令。

## **构建运动路径**

使用 [createMotionEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorfactory/#createMotionEffect) 创建运动。其 [getFrom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#getFrom)、[getTo](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#getTo) 与 [getBy](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#getBy) 描述基于百分比的坐标或偏移。若需可编辑路线，请创建 [MotionPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpath/) 并通过 [MotionEffect.setPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#setPath) 赋予它。[MotionPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpath/) 保存路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncommandpathtype/) 选择操作：

| 命令 | 点数 | 含义 |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动到其终点。 |
| CurveTo | Three | 按两控制点和终点的三次曲线进行跟随。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 完成路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpathpointstype/) 描述点的编辑特性，如拐角点或平滑点。它不取代命令类型。曲线示例使用曲线点类型，直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正 Y 向下。绝对命令在路径坐标系中指定位置；相对命令指定相对于当前位置信息的偏移。这与 [getOrigin](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#getOrigin)（选择路径参考框架）以及 [getPathEditMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioneffect/#getPathEditMode)（控制形状移动时路径的移动方式）分离。

### **创建直线路径**

创建一个运动行为，包含起始点、一个直线段和结束命令。[MotionPath.add](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpath/#add) 接受命令类型、点集合、点类型以及相对坐标标志。

起始命令建立 (0, 0)，直线结束于 (0.25, 0)，使路径在水平方向上位移宽度的四分之一。结束命令没有坐标点。路径分配后，将运动行为添加到效果中即可将该路线关联到矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` 包含一个具有三个路径命令的运动行为。以下文件编辑示例基于此已知结构。

### **比较绝对坐标和相对坐标**

这两个路径对象描述了相同的路线。绝对命令以 (0.3, 0.1) 结束；相对命令在当前位置信息上加上 (0.1, 0.1)，得到 (0.2, 0)。

两条路径起点相同。对相对直线，将其 X、Y 偏移量加到当前位置信息上得到终点；对绝对直线，直接读取终点坐标。若在不转换坐标的情况下切换标志，会描述不同的路线。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

将任意路径分配给运动行为即可在演示文稿中使用。最终的布尔参数为该命令选择相对坐标。

### **将直线替换为曲线**

打开 `motion.pptx`，将其直线命令替换为三次曲线。先提供两个控制点，随后提供终点。

起始位置由前一命令提供。前两个点定义曲线的形状，第三个点为其终点；它们不是三个连续的目的地。一起更新命令类型、点编辑类型和点数组，可使段落与新几何保持一致。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` 中的路径仍然有三个命令，只是其中的中间命令现在定义了曲线。

## **检查并编辑已保存的路径**

每个 [MotionCmdPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncmdpath/) 都提供 [getPoints](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncmdpath/#getPoints)、[getCommandType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncmdpath/#getCommandType)、[getPointsType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncmdpath/#getPointsType) 与 [isRelative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motioncmdpath/#isRelative)。以下示例使用 `motion.pptx` 中已知的三命令路径。对于任意输入，请先定位目标效果并在按索引编辑前检查命令类型和点数。

### **读取命令和坐标**

在不修改路径的情况下读取它。结束和闭合循环命令不需要点，因此需为可能的空点数组做好准备。

输出在列出点之前，将每个数值化的命令类型与其相对坐标标志配对。这使您在修改路径前能够区分终点和偏移。曲线会列出三个点，而此文件中的直线仅列出一个点。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

列表包含起始点、一个绝对直线结束于 (0.25, 0) 的命令以及结束命令。

### **更改端点**

打开 `motion.pptx`，替换直线的点数组以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单个点会改变其目的地，而不改变命令类型、时间或在集合中的位置。因为该命令使用绝对坐标，新坐标对指定的是位置而非偏移。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` 中的直线结束于 (0.4, 0.1)；原始文件保持不变。

### **替换段落**

使用 [insert](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpath/#insert) 与 [removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/motionpath/#removeAt) 替换 `motion.pptx` 中的直线。插入后原直线会移至索引 2。

这演示了替换命令对象而非编辑其已有坐标。插入后，集合暂时包含起始命令、新直线、旧直线和结束命令。删除索引 2 后，旧直线被丢弃，新的路线得以保留。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存的路径仍有三条命令，新的直线结束于 (0.2, 0.1)，结束命令仍在最后。

## **修改并验证现有行为**

当不知道行为的索引时，可按类型选择。本示例打开 `rotation.pptx`，找到其 [RotationEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/rotationeffect/)，更改角度，并在重新打开后检查保存的数值。

类型检查使循环能够跳过非旋转的行为。第二次加载将已保存的文件读取到单独的演示对象中，从而比较的是持久化数据而非仍在内存中的值。此示例仍假设已知的效果位于主序列的首位；按类型选择行为并不一定能在任意演示文稿中定位正确的效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

输出为 `Rotation preserved: True`。对其他行为同样使用类型检查模式。若要进行完整的保留检查，请比较目标形状、效果、行为类型及顺序、时间和路径命令。对浮点值使用数值容差。对于动画布局未知的演示文稿，请参阅[读取形状动画](/slides/zh/python-java/shape-animation/#read-shape-animations)以遍历主序列和交互序列。

## **行为顺序、预设与播放**

[BehaviorCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behaviorcollection/) 中的顺序是效果操作的存储顺序。它不是一个播放列表，行为并不会自动等待前一个行为完成。时间和封闭的效果决定调度。行为可以重叠，对同一属性的操作可能通过 [getAdditive](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behavior/#getAdditive) 与 [getAccumulate](https://reference.aspose.com/slides/zh/python-java/aspose.slides/behavior/#getAccumulate) 产生交互。不要仅凭集合重新排序来安排“先移动后旋转”；请使用显式时间或如[形状动画](/slides/zh/python-java/shape-animation/)中描述的分离效果。

效果的 [getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getType) 与 [getSubtype](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effect/#getSubtype) 描述其预设。它们并不是已编辑行为树的完整描述。在自定义行为之前先选择预设和子类型：更改预设会重建集合并丢弃自定义操作。例如，将自定义 Spin 效果改为 Fade 可能会用 set 和 filter 行为替换其旋转行为。更改预设或子类型后请重新检查集合。清除预设行为同样可能移除预设所需的可见性或初始化操作。示例故意使用可见形状并替换行为，而不重新构建每个预设的实现。

## **格式兼容性**

已保留的行为树并不保证在每个查看器或导出渲染器中实现完全相同的播放。请分别检查保存的数据和渲染输出。

| 格式或输出 | 需验证的内容 |
| --- | --- |
| PPTX | 作为这些示例的主要格式。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放。 |
| PPT | 传统二进制表示可能与 PPTX 不同。请单独进行保存‑重新打开循环并测试播放；不要仅凭 PPTX 成功输出推断对所有自定义组合的支持。 |
| PDF、PNG、JPEG 等静态幻灯片图像 | 包含静态幻灯片表示，不包含可播放的行为时间线或保证的最终动画帧。 |
| [HTML5](/slides/zh/python-java/export-to-html5/) | 当在导出选项中启用形状动画时，可播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/python-java/convert-powerpoint-to-animated-gif/) | 存储渲染帧，而非可编辑行为或点击触发的交互。检查实际渲染的运动。 |
| [Video](/slides/zh/python-java/convert-powerpoint-to-video/) | 渲染动画帧并编码为视频。支持受渲染器的[支持的动画与效果](/slides/zh/python-java/convert-powerpoint-to-video/#supported-animations-and-effects)限制；命令和交互事件不会成为可编辑时间线。 |

## **常见问题**

**为什么我的效果在未添加任何行为前就已经包含行为？**

创建预定义效果时会生成其底层操作。检查它们后再决定是扩展预设还是替换其行为。

**将行为移动到开头就会先播放吗？**

未必。集合顺序并不能替代时间。请检查延迟、持续时间以及同一属性上操作之间的交互。

**为什么结束命令没有点？**

它标记路径的结束，不需要坐标。检查从文件读取的路径时，请留意可能的空点数组。

**一次成功的往返保存是否足以确认播放？**

否。重新打开仅确认您检查的属性已被保留。请另行测试幻灯片放映器或动画导出，以确认其视觉行为。