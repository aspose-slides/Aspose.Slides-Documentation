---
title: 在 JavaScript 中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/nodejs-java/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中创建、检查和修改自定义动画行为及可编辑的运动路径。"
---
## **概述**

自定义动画行为让您能够控制动画效果中的单个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本指南展示了如何创建和组合行为、配置其时间、检查和修改现有动画，以及验证其属性在保存并重新打开演示文稿后仍能保留。

有关预定义效果和点击触发器，请参阅[形状动画](/slides/zh/nodejs-java/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **时间轴 → 序列 → 效果 → 行为**：

- [getTimeline](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getTimeline) 方法返回幻灯片时间轴，其中包含主序列和交互序列。
- [Sequence](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/) 包含效果，可能针对不同的形状。
- [Effect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/) 标识目标形状、预设、子类型以及效果时间。
- 通过 [Effect.getBehaviors](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getBehaviors) 返回的集合包含实现效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用 [Sequence.addEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sequence/#addEffect) 创建效果并访问 [getBehaviors](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getBehaviors) 集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用[clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/#clear)。

[BehaviorFactory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/) 创建下面所示的八种行为类型。运动行为在[构建运动路径](#build-a-motion-path)中介绍。每个代码片段都包含其模块导入，并可在安装了 `aspose.slides.via.java` 和 `java` 包的 Node.js 环境中直接运行。先运行文件创建示例，再运行读取其输出的示例。后续编辑示例会说明使用的输出文件。

### **旋转**

使用 [createRotationEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) 创建旋转。[getBy](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/rotationeffect/#getBy) 指定相对角度（度）；[getFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/rotationeffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/rotationeffect/#getTo) 指定端点。

示例从 Spin 效果开始，将其预设操作替换为一个旋转行为，并为该操作设置两秒持续时间。90 度的相对角度表示相对于形状起始方向的四分之一转角，因此无需显式指定起始角度。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均基于此文件。

### **缩放**

使用 [createScaleEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) 并提供 X/Y 百分比： [getFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/scaleeffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/scaleeffect/#getTo) 描述起始和结束尺寸，而 [getBy](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/scaleeffect/#getBy) 描述相对变化。这里的 100 表示原始大小。

示例在两秒内将两个维度从 100% 增长到 125%。使用相同的水平和垂直百分比可保持形状比例，不同的百分比会导致一个维度比另一个更拉伸。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **颜色**

使用 [createColorEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) 将填充从蓝色更改为橙色。[getFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/coloreffect/#getFrom) 和 [getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/coloreffect/#getTo) 为颜色；[getBy](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/coloreffect/#getBy) 为颜色偏移。[Behavior.getProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behavior/#getProperties) 标识被动画化的属性。

形状的实心填充初始化为蓝色，与动画的起始颜色一致。选择填充颜色属性告诉行为要更改形状的哪一部分；仅有颜色端点并不能指明属性。保存的效果描述了两秒到橙色的过渡。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **过滤器**

使用 [createFilterEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) 选择擦除。[getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filtereffect/#getType)、[getSubtype](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filtereffect/#getSubtype) 和 [getReveal](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/filtereffect/#getReveal) 分别指定过滤器、方向以及是显示还是隐藏形状。

本例配置了一个两秒的擦除，使用右方向子类型显示形状。过滤器设置属于效果内部的行为，因此在移除预设原始操作后进行配置。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **属性**

使用 [createPropertyEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) 为不透明度添加动画。[getFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/propertyeffect/#getFrom)、[getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/propertyeffect/#getTo) 和 [getBy](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/propertyeffect/#getBy) 为字符串，需通过 [getValueType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/propertyeffect/#getValueType) 和 [getCalcMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) 解释。请根据需要选择端点或相对偏移，而不是同时设置全部三个。

这里选择的属性是不透明度，数值字符串表示从 25% 不透明度变为完全不透明。线性插值描述了这些值之间的逐渐变化。将此示例应用于其他属性时，请为该属性选择合适的值类型和端点值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **设置**

使用 [createSetEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) 通过 [getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/seteffect/#getTo) 设定可见性。设置行为不在端点之间进行插值。

示例选择可见性属性，并在行为运行时将字符串 `visible` 赋给它。矩形在此最小演示文稿中已经可见，因此单独的赋值可能不会产生明显的视觉变化。此类操作在更大效果中用于控制形状何时隐藏或显示。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **命令**

使用 [createCommandEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) 并配置 [getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commandeffect/#getType)、[getCommandString](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commandeffect/#getCommandString) 和 [getShapeTarget](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/commandeffect/#getShapeTarget)。在工作目录放置名为 `sample.wav` 的 WAV 录音。本例使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 将其嵌入，并将播放命令附加到音频帧上。

音频帧既是效果的目标，也是命令的目标。这将播放请求连接到嵌入的录音；仅有命令字符串并不能指明控制哪个媒体对象。该效果配置为在幻灯片放映期间点击时启动。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

保存后在 `command.pptx` 中存储命令；不会自动播放录音。播放需要支持该命令及其媒体目标的幻灯片播放器。

## **管理行为集合**

[BehaviorCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/) 支持 [add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/#add)、[insert](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/#insert)、[remove](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/#remove) 和 [removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/#removeAt)。本例打开 `rotation.pptx`，添加缩放行为，将其插入到旋转之前，然后移除旋转。移除后再插入同一对象会改变其存储位置而不产生副本。

编辑顺序将集合从 rotation–scale 变为 scale–rotation，随后仅剩 scale。索引始终指向当前集合，因此在重新排序后使用旋转的新索引进行移除。最终枚举确认了将被保存的行为。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

输出为 `ScaleEffect`：仅保留缩放。集合顺序本身并不会让行为依次执行。仅在全部替换时才使用 clear 清空集合。

## **配置行为时间**

[Behavior.getTiming](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behavior/#getTiming) 暴露 [Timing](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/)，独立于 [Effect.getTiming](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getTiming)。效果时间调度整个效果；行为时间描述其中的单个操作。

### **设置持续时间、延迟、重复和加速**

打开 `rotation.pptx`，使用秒为单位设置持续时间（[getDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getDuration)）和触发延迟（[getTriggerDelayTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)），然后通过 [setRepeatCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#setRepeatCount) 配置重复次数。[getAccelerate](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getAccelerate) 和 [getDecelerate](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getDecelerate) 为持续时间的比例，保持两者之和不超过 1。

输入文件为旋转示例创建的文件，已知第一个行为是旋转。本例仅修改该行为的时间；其 90 度角度保持不变。把角度与时间分离，可在不重新构建动画的情况下调节节奏。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

该行为使用两秒持续时间、半秒延迟，重复次数为 3。其持续时间的前后各 20% 用于加速和减速。

其他重复策略包括 [getRepeatDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatDuration)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) 和 [getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)；请任选其一，而非同时启用。 [getAutoReverse](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/timing/#getAutoReverse) 在正向播放后逆向播放。加速和减速适用于连续变化，不适用于离散赋值或命令。

## **构建运动路径**

使用 [createMotionEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) 创建运动。其 [getFrom](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#getFrom)、[getTo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#getTo) 和 [getBy](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#getBy) 描述基于百分比的坐标或偏移。若需可编辑的路线，请创建 [MotionPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpath/) 并通过 [MotionEffect.setPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#setPath) 赋予。 [MotionPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpath/) 用于存储路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncommandpathtype/) 用于选择操作：

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动到其端点。 |
| CurveTo | Three | 按两个控制点和一个端点定义的三次曲线运动。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 完成路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpathpointstype/) 描述点的编辑特性，例如拐角点或平滑点。它不取代命令类型。曲线示例使用曲线点类型，直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正向 Y 向下。绝对命令在路径坐标系中指定位置，相对命令指定相对于当前位置信息的偏移。这与 [getOrigin](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#getOrigin)（选择路径参考框架）以及 [getPathEditMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioneffect/#getPathEditMode)（控制形状移动时路径如何移动）是分开的概念。

### **创建直线路径**

创建包含起始点、一个直线段和结束命令的运动行为。[MotionPath.add](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpath/#add) 接受命令类型、点集合、点类型以及相对坐标标志。

起始命令设为 (0, 0)，直线结束于 (0.25, 0)，使路径在水平方向上位移幻灯片宽度的四分之一。结束命令没有坐标点。路径分配后，将运动行为添加到效果中即可将该路线绑定到矩形。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 包含一个包含三条路径命令的运动行为。下面的文件编辑示例均基于此已知结构。

### **比较绝对坐标与相对坐标**

以下两个路径对象描述相同的路线。绝对命令终点为 (0.3, 0.1)；相对命令在当前位姿上加上 (0.1, 0.1)，得到 (0.2, 0)。

两条路径的起点相同。对于相对直线，将其 X、Y 偏移加到当前位姿即可得到终点；而绝对直线直接读取终点坐标。若不转换坐标而直接切换标志，则会得到不同的路线。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

将任意路径分配给运动行为即可在演示文稿中使用。最后的布尔参数用于为该命令选择相对坐标。

### **用曲线替换直线**

打开 `motion.pptx`，将其直线命令替换为三次曲线。先提供两个控制点，再提供端点。

起始位置由前一命令提供。前两个点定义曲线形状，第三个点为终点；它们不是三个连续的目的地。同步更新命令类型、点编辑类型以及点数组，可确保段落与新几何保持一致。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 中的路径仍保持三条命令，只是中间命令现在定义了曲线。

## **检查并编辑已保存的路径**

每个 [MotionCmdPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncmdpath/) 都提供 [getPoints](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncmdpath/#getPoints)、[getCommandType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncmdpath/#getCommandType)、[getPointsType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) 与 [isRelative](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motioncmdpath/#isRelative)。以下示例使用 `motion.pptx` 中已知的三命令路径。对任意输入文件，请先定位目标效果并在按索引编辑前检查命令类型和点数量。

### **读取命令和坐标**

读取路径而不做修改。结束和闭合循环命令不需要点，因此需要处理可能为 null 的点数组。

输出在列出点之前，先将每个数值型命令类型与其相对坐标标志配对。这使您在修改路径前能够区分是端点还是偏移。曲线会列出三个点，而此文件中的直线仅列出一个点。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

列表包含起始点、一个绝对直线终点 (0.25, 0) 和结束命令。

### **更改端点**

打开 `motion.pptx`，替换直线的点数组以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单一点会改变其目的地，而不影响命令类型、时间或在集合中的位置。因为该命令使用绝对坐标，新坐标对指定的是位置而非增量偏移。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 中的直线结束于 (0.4, 0.1)；原始文件保持不变。

### **替换段落**

使用 [insert](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpath/#insert) 和 [removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/motionpath/#removeAt) 替换 `motion.pptx` 中的直线。插入会将旧直线移至索引 2。

此示例演示了替换命令对象而不是编辑其已有坐标。插入后，集合暂时包含起始命令、新直线、旧直线和结束命令。移除索引 2 后，旧直线被丢弃，新的路径保持在位。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存的路径仍然拥有三条命令，新的直线终点为 (0.2, 0.1)，结束命令仍在最后。

## **修改并验证已有行为**

当行为索引未知时，可按类型选择。本例打开 `rotation.pptx`，找到其 [RotationEffect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/rotationeffect/)，更改角度，并在重新打开后检查保存的值。

类型检查使循环能够跳过非旋转行为。第二次加载将已保存的文件读取到另一个演示对象中，因此比较的是持久化数据，而不是仍在内存中的值。本例仍假设已知效果位于主序列的首位；按类型选择行为并不能在任意演示文稿中定位正确的效果。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

输出为 `Rotation preserved: true`。对其他行为也可采用相同的类型检查模式。若要进行完整的保留性检查，请比较目标形状、效果、行为类型及顺序、时间以及路径命令。对浮点值使用数值容差。对于动画布局未知的演示文稿，请参阅[读取形状动画](/slides/zh/nodejs-java/shape-animation/#read-shape-animations) 以遍历主序列和交互序列。

## **行为顺序、预设与播放**

[BehaviorCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behaviorcollection/) 中的顺序是效果操作的存储顺序。它并不是一个播放列表，不能保证每个行为自动等待前一个行为完成。调度由时间和所属效果决定。行为可以重叠，同一属性的操作可能通过 [getAdditive](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behavior/#getAdditive) 和 [getAccumulate](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/behavior/#getAccumulate) 产生交互。不应仅通过重新排序集合来实现“先移动后旋转”；请使用显式时间或如[形状动画](/slides/zh/nodejs-java/shape-animation/) 中描述的独立效果。

效果的 [getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getType) 和 [getSubtype](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/effect/#getSubtype) 描述其预设。它们并不能完整描述已编辑的行为树。请先选择预设和子类型，再自定义行为：更改预设可能会重建集合并丢弃您的自定义操作。例如，将自定义 Spin 效果改为 Fade 可能会用 set 和 filter 行为替代其旋转行为。更改预设或子类型后请再次检查集合。清除预设行为也可能会删除预设所需的可见性或初始化操作。示例中使用可见形状并替换行为，而不重新构建每个预设的实现。

## **格式兼容性**

行为树的保留并不保证在所有查看器或导出渲染器中拥有完全相同的播放效果。请分别检查保存的数据和渲染输出。

| Format or output | What to verify |
| --- | --- |
| PPTX | 作为本示例的主要格式使用。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放效果。 |
| PPT | 传统二进制表示可能与 PPTX 不同。请单独进行保存‑重新打开循环并测试播放；不要仅凭 PPTX 成功就推断对所有自定义组合的支持。 |
| PDF、PNG、JPEG 等静态幻灯片图像 | 只包含静态幻灯片表示，不包含可播放的行为时间线或保证的最终动画帧。 |
| [HTML5](/slides/zh/nodejs-java/export-to-html5/) | 在导出选项中启用形状动画后可以播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/) | 存储渲染后的帧，而非可编辑行为或点击触发的交互。请检查实际渲染的运动。 |
| [Video](/slides/zh/nodejs-java/convert-powerpoint-to-video/) | 渲染动画帧并编码为视频。支持范围受渲染器的[支持的动画和效果](/slides/zh/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects)限制；命令和交互事件不会转换为可编辑时间线。 |

## **常见问题**

**为什么我的效果在未添加任何行为前就已经包含行为？**

创建预定义效果时可能会自动生成其底层操作。请先检查这些操作，再决定是扩展预设还是替换其行为。

**将行为移动到开头会让它先播放吗？**

未必。集合顺序并不能代替时间设置。请检查延迟、持续时间以及同一属性上操作之间的交互。

**为什么结束命令没有点？**

结束命令标记路径的结束，无需坐标。读取文件中的路径时请检查点数组是否为 null。

**成功的往返保存足以确认播放吗？**

不够。重新打开只能确认您检查的属性是否被保留。仍需在幻灯片放映播放器或动画导出中单独测试其视觉表现。