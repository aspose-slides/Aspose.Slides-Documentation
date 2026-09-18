---
title: 在 Android 上创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/androidjava/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（通过 Java），在 PowerPoint 演示文稿中创建、检查和修改自定义动画行为及可编辑的运动路径。"
---
## **概述**

自定义动画行为让您能够控制动画效果中的各个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本指南展示了如何创建和组合行为、配置它们的时间、检查和修改现有动画，以及验证它们的属性在保存并重新打开演示文稿后能够保留。

有关预定义效果和单击触发器，请参阅 [Shape Animation](/slides/zh/androidjava/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **Timeline → Sequence → Effect → Behaviors**：

- [getTimeline](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) 方法返回幻灯片时间线，时间线包含其主序列和交互式序列。
- [ISequence](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/) 包含效果，可能针对不同的形状。
- [IEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/) 确定目标形状、预设、子类型以及效果时间。
- [IEffect.getBehaviors](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 返回的集合包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用 [ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 创建效果并访问 [getBehaviors](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getBehaviors--) 集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用 [clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/#clear--)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/) 创建下文示例中演示的八种行为类型。运动相关内容请参阅 [Build a Motion Path](#build-a-motion-path)。每个代码片段都包含其 import；将可执行语句放入方法内部。后续编辑示例会说明使用的输出文件。 在 Android 上，将示例文件名替换为应用可访问目录中的完整路径，例如应用的 files 目录。

### **Rotation**

使用 [createRotationEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) 创建旋转。 [getBy](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/irotationeffect/#getBy--) 指定相对角度（度）；[getFrom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/irotationeffect/#getFrom--) 和 [getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/irotationeffect/#getTo--) 指定端点。

示例从 Spin 效果开始，用一个旋转行为替换其预设操作，并将该操作的持续时间设为两秒。相对角度 90 度表示相对于形状起始方向的四分之一转弯，因此不需要显式的起始角度。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间和旋转编辑示例均使用此文件。

### **Scale**

使用 [createScaleEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) 并提供 X/Y 百分比： [getFrom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) 与 [getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iscaleeffect/#getTo--) 描述起始和结束大小，而 [getBy](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iscaleeffect/#getBy--) 描述相对变化。这里的 100 代表原始大小。

示例在两秒内将两个维度从 100% 放大到 125%。使用相同的水平和垂直百分比可保持形状比例；不同的百分比会导致某一维度拉伸。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Color**

使用 [createColorEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) 将填充颜色从蓝色改为橙色。 [getFrom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icoloreffect/#getFrom--) 与 [getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icoloreffect/#getTo--) 为颜色；[getBy](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icoloreffect/#getBy--) 为颜色偏移。 [IBehavior.getProperties](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehavior/#getProperties--) 确定被动画化的属性。

形状的实心填充初始化为蓝色，与动画的起始颜色一致。选择填充颜色属性告诉行为应更改形状的哪一部分；仅有颜色端点并不能确定该属性。保存的效果描述了两秒的过渡到橙色。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

使用 [createFilterEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) 选择擦除效果。 [getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifiltereffect/#getType--)、[getSubtype](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--) 和 [getReveal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) 指定滤镜、方向以及是显示还是隐藏形状。

本例配置了一个两秒的擦除效果，以右向子类型显示形状。滤镜设置属于效果内部的行为，因此在移除预设的原始操作后再进行配置。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Property**

使用 [createPropertyEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) 为不透明度添加动画。 [getFrom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--) 、[getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipropertyeffect/#getTo--) 与 [getBy](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) 为字符串，需通过 [getValueType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) 和 [getCalcMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) 进行解释。请根据需要选择端点或相对偏移，而不是同时设置三者。

这里选择的属性是不透明度，数值字符串表示从 25% 不透明度变化到完全不透明。线性插值描述了这两个值之间的平滑过渡。将此示例改用于其他属性时，请为该属性选择合适的值类型和端点值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Set**

使用 [createSetEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) 通过 [getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iseteffect/#getTo--) 赋值可见性。Set 行为不会在端点之间进行插值。

示例选择了可见性属性，并在行为运行时将字符串 `visible` 赋给它。该矩形在此最小演示中本已可见，因此该赋值本身可能看不出明显的视觉变化。此类操作在配合控制形状何时隐藏或显示的更大效果时非常有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Command**

使用 [createCommandEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) 并配置 [getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icommandeffect/#getType--)、[getCommandString](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icommandeffect/#getCommandString--) 与 [getShapeTarget](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--)。将名为 `sample.wav` 的 WAV 录音放在工作目录中。示例使用 [addAudioFrameEmbedded](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) 将其嵌入，并将播放命令附加到音频帧。

音频帧既是效果的目标也是命令的目标。这将播放请求关联到嵌入的录音；单独的命令字符串并不指明要控制哪个媒体对象。该效果配置为在放映期间单击时启动。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

保存后命令被存储在 `command.pptx` 中；它不会自动播放录音。播放需要支持该命令及其媒体目标的放映播放器。

## **管理行为集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/) 支持 [add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-)、[insert](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-)、[remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-) 与 [removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-)。本示例打开 `rotation.pptx`，添加缩放行为，将其插入到旋转之前，然后删除旋转。移除后重新插入同一对象会改变其存储位置而不会产生副本。

编辑顺序把集合从 rotation–scale 变为 scale–rotation，随后仅剩 scale。索引始终指向当前集合，所以在重新排序后移除时使用旋转的新索引。最终枚举确认了哪些行为会被保存。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

输出为 `ScaleEffect`：仅保留缩放。集合顺序本身并不决定行为依次执行。仅在全部替换时才清空集合。

## **配置行为时间**

[IBehavior.getTiming](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehavior/#getTiming--) 暴露 [ITiming](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/)，独立于 [IEffect.getTiming](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getTiming--)。效果时间安排整个效果的播放，行为时间描述其中的具体操作。

### **设置持续时间、延迟、重复和加速**

打开 `rotation.pptx` 并使用 [getDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getDuration--) 设置持续时间，使用 [getTriggerDelayTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) 设置触发延迟（秒），然后通过 [setRepeatCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) 配置重复次数。 [getAccelerate](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getAccelerate--) 与 [getDecelerate](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getDecelerate--) 为持续时间的分数，二者之和最多为 1。

输入文件为旋转示例创建的文件，已知第一个行为是旋转。本例仅修改该行为的时间，保持 90 度角不变。将角度与时间分离，便于在不重新构建动画的前提下调整节奏。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

该行为使用两秒持续时间、半秒延迟，重复计数为 3。前后各 20% 的持续时间用于加速和减速。

其它重复策略包括 [getRepeatDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatDuration--)、[getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) 与 [getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)；请仅选择一种策略，而不是全部同时启用。 [getAutoReverse](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getAutoReverse--) 可在正向播放后反向播放。加速和减速仅适用于连续变化，不适用于离散赋值或命令。

## **构建运动路径**

使用 [createMotionEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) 创建运动。其 [getFrom](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#getFrom--) 、[getTo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#getTo--) 与 [getBy](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#getBy--) 描述基于百分比的坐标或偏移。要创建可编辑的路线，请实例化 [MotionPath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/motionpath/) 并使用 [IMotionEffect.setPath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) 进行赋值。 [IMotionPath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotionpath/) 保存路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/motioncommandpathtype/) 用于选择操作：

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动到其端点。 |
| CurveTo | Three | 按两控制点和一个端点的三次曲线移动。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 结束路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/motionpathpointstype/) 描述点的编辑特性，例如拐角点或平滑点。它不取代命令类型。曲线示例使用曲线点类型，直线段使用拐角点类型。

路径坐标相对于幻灯片尺寸归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。正 Y 向下。绝对命令使用路径坐标系中的实际位置，相对命令使用相对当前位置信息的偏移。这与 [getOrigin](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#getOrigin--)（选择路径参考框架）和 [getPathEditMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--)（控制形状移动时路径如何随动）是分开的概念。

### **创建直线路径**

创建一个运动行为，包含起始点、一个直线段和结束命令。 [IMotionPath.add](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) 接受命令类型、其点、点类型以及相对坐标标志。

起始命令设为 (0, 0)，直线结束于 (0.25, 0)，产生横向位移为幻灯片宽度的四分之一。结束命令没有坐标点。路径分配后，将运动行为加入效果即可将该路线链接到矩形。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` 包含一个具有三个路径命令的运动行为。以下文件编辑示例基于此已知结构。

### **比较绝对坐标与相对坐标**

这两个路径对象描述相同的路线。绝对命令的终点为 (0.3, 0.1)；相对命令在当前坐标 (0.2, 0) 的基础上加上 (0.1, 0.1)。

两个路径均从相同位置开始。对相对直线而言，需要将其 X、Y 偏移加到当前坐标才能得到终点；对绝对直线而言，可直接读取终点坐标。若仅改变标志而不转换坐标，将得到不同的路线。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

将任意路径分配给运动行为即可在演示中使用。最后的布尔参数决定该命令使用相对坐标。

### **用曲线替换直线**

打开 `motion.pptx` 并将其直线命令替换为三次曲线。先提供两个控制点，再提供终点。

起始位置由前一个命令提供。前两个点决定曲线形状，第三个点为目的地；它们不是三个连续的目的地。同步更新命令类型、点编辑类型以及点数组，可保持段落与新几何形状的一致性。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` 中的路径仍然有三个命令，只是其中的中间命令已改为曲线。

## **检查并编辑已保存的路径**

每个 [IMotionCmdPath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioncmdpath/) 都暴露 [getPoints](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--)、[getCommandType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--)、[getPointsType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--) 与 [isRelative](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--)。下面的示例使用 `motion.pptx` 中已知的三命令路径。对任意输入，请先定位目标效果并在按索引编辑前检查命令类型与点数。

### **读取命令和坐标**

读取路径而不进行修改。结束和闭环命令不需要点，因此需要为点数组预留 null。

输出先列出每个数值型命令类型及其相对坐标标志，然后列出其点。这样可以在修改路径前区分端点与偏移。曲线会列出三个点，而此文件中的直线只列出一个点。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

列表包含起始点、一个绝对直线结束于 (0.25, 0) 与一个结束命令。

### **更改端点**

打开 `motion.pptx` 并替换直线的点数组以移动其终点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单个点会改变其目的地，同时保持命令类型、时间及在集合中的位置不变。由于该命令使用绝对坐标，新坐标对表示位置而非偏移。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` 中的直线终点为 (0.4, 0.1)；原文件保持不变。

### **替换段落**

使用 [insert](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) 与 [removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) 替换 `motion.pptx` 中的直线。插入后原直线会被移到索引 2。

此示例演示了替换命令对象而不是编辑其现有坐标。插入后，集合暂时包含起始命令、新直线、旧直线和结束命令。删除索引 2 后，旧直线被丢弃，新的路线保留下来。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存的路径仍有三个命令，新直线结束于 (0.2, 0.1)，结束命令依旧在最后。

## **修改并验证现有行为**

当行为索引未知时，可按类型进行选择。本例打开 `rotation.pptx`，查找其 [IRotationEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/irotationeffect/)，更改角度，并在重新打开后检查保存的值。

类型检查使循环能够跳过非旋转行为。第二次加载将文件读取到单独的演示对象中，从而比较的是持久化的数据而非仍在内存中的值。示例仍假设已知的效果位于主序列的首位；仅按类型选择行为并不能在任意演示中定位正确的效果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

输出为 `Rotation preserved: true`。对其他行为使用相同的类型检查模式即可。完整的保留检查应比较目标形状、效果、行为类型及顺序、时间以及路径命令。对浮点数使用数值容差。若演示的动画布局未知，请参阅 [Read Shape Animations](/slides/zh/androidjava/shape-animation/#read-shape-animations) 以遍历主序列和交互序列。

## **行为顺序、预设与播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehaviorcollection/) 中的顺序是效果操作的存储顺序。它并非播放列表，行为不会自动等候前一个完成。时间和封闭的效果决定调度。行为可以重叠，同一属性的操作可能通过 [getAdditive](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehavior/#getAdditive--) 与 [getAccumulate](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) 产生交互。不要仅靠重新排序集合来实现 “先移动再旋转”；请使用显式时间或如 [Shape Animation](/slides/zh/androidjava/shape-animation/) 中描述的分离效果。

效果的 [getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getType--) 与 [getSubtype](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getSubtype--) 描述其预设。它们并不能完整描述编辑后的行为树。在自定义行为之前先选择预设和子类型：更改预设会重建集合并丢弃自定义操作。例如，将自定义的 Spin 效果改为 Fade 会用 set 与 filter 行为替代其旋转行为。更改预设或子类型后请再次检查集合。清除预设行为也可能删除预设所需的可见性或初始化操作。示例刻意使用可见形状并替换行为，而不是重新构建每个预设的实现。

## **格式兼容性**

行为树的保留并不保证在所有查看器或导出渲染器中完全相同的播放效果。请分别检查保存的数据和渲染输出。

| 格式或输出 | 验证内容 |
| --- | --- |
| PPTX | 本示例的主要格式。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放效果。 |
| PPT | 传统的二进制表示可能与 PPTX 不同。请进行单独的保存‑重新打开循环并测试播放；不要仅凭 PPTX 成功就推断对所有自定义组合的支持。 |
| PDF、PNG、JPEG 以及其他静态幻灯片图像 | 仅包含静态幻灯片表示，不包含可播放的行为时间线或保证的最终动画帧。 |
| [HTML5](/slides/zh/androidjava/export-to-html5/) | 在导出选项中启用形状动画后，可播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/androidjava/convert-powerpoint-to-animated-gif/) | 存储渲染帧，而非可编辑的行为或点击触发交互。请检查实际渲染的运动。 |
| [Video](/slides/zh/androidjava/convert-powerpoint-to-video/) | 渲染动画帧并编码为视频。仅限渲染器的 [supported animations and effects](/slides/zh/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects)；命令和交互事件不会成为可编辑的时间线。 |

## **常见问答**

**为什么我的效果在未添加任何行为前就已经包含行为？**

创建预定义效果时可能会生成其底层操作。检查它们后再决定是扩展预设还是替换其行为。

**将行为移动到开头会使它先播放吗？**

不一定。集合顺序并不能代替时间设置。请检查延迟、持续时间以及同属性操作之间的交互。

**为什么结束命令没有点？**

结束命令标记路径结束，不需要坐标。检查从文件读取的路径时，需要处理可能为 null 的点数组。

**一次成功的往返保存足以确认播放吗？**

不行。重新打开仅确认属性已保存。仍需在放映播放器或动画导出中单独测试其视觉表现。