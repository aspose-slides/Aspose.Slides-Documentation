---
title: 在 .NET 中创建和修改自定义动画行为
linktitle: 自定义动画
type: docs
weight: 151
url: /zh/net/custom-animation/
keywords:
- 自定义动画
- 动画行为
- 运动路径
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建、检查和修改自定义动画行为以及可编辑的运动路径。"
---
## **概述**

自定义动画行为允许您控制动画效果中的各个操作，例如更改颜色、旋转形状或沿可编辑的运动路径移动。本文档展示了如何创建和组合行为、配置其时间、检查和修改现有动画，以及验证其属性在保存并重新打开演示文稿后是否能够保留。

有关预定义效果和单击触发器，请参阅[Shape Animation](/slides/zh/net/shape-animation/)。

## **了解动画模型**

动画的组织结构为 **Timeline → Sequence → Effect → Behaviors**：

- 幻灯片的[Timeline](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/timeline/)包含其主序列和交互序列。
- [ISequence](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/)包含可能针对不同形状的效果。
- [IEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/)标识目标形状、预设、子类型以及效果的时间安排。
- [IEffect.Behaviors](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/behaviors/)包含实现该效果的操作：更改颜色、移动、旋转、设置属性等。

## **创建单个行为**

调用[ISequence.AddEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/addeffect/)以创建效果并访问其[Behaviors](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/behaviors/)集合。预设可以自动填充此集合。扩展预设时保留其操作，或在有意替换时使用[Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/clear/)。

[IBehaviorFactory](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/)可创建下面示例中的八种行为类型。运动相关内容请参见[Build a Motion Path](#build-a-motion-path)。每个创建示例都是完整程序；后续编辑示例会说明使用的输出文件。

### **旋转**

使用[CreateRotationEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/)创建旋转。[By](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/irotationeffect/by/)指定相对角度（度），[From](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/irotationeffect/from/)和[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/irotationeffect/to/)指定端点。

示例以 Spin 效果开始，用一个旋转行为替换其预设操作，并将该操作的持续时间设为两秒。90 度的相对角度表示相对于形状起始方向的四分之一次转，因此无需显式指定起始角度。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` 包含一个形状和一个旋转行为。下面的集合、时间安排和旋转编辑示例均使用此文件。

### **缩放**

使用[CreateScaleEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/)并提供 X/Y 百分比：[From](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/iscaleeffect/from/)和[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/iscaleeffect/to/)描述起始和结束尺寸，而[By](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/iscaleeffect/by/)描述相对变化。这里的 100 表示原始大小。

示例在两秒内将两个维度从 100% 增长到 125%。使用相同的水平和垂直百分比可保持形状比例；不同的百分比会导致一个维度拉伸得更多。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **颜色**

使用[CreateColorEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/)将填充从蓝色更改为橙色。[From](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icoloreffect/from/)和[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icoloreffect/to/)是颜色；[By](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icoloreffect/by/)是颜色偏移。[IBehavior.Properties](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehavior/properties/)标识被动画化的属性。

形状的实心填充被初始化为蓝色，匹配动画的起始颜色。选择填充颜色属性告诉行为要更改形状的哪一部分；仅有颜色端点并不能确定该属性。保存的效果描述了两秒的过渡至橙色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **滤镜**

使用[CreateFilterEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/)选择擦除。[Type](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ifiltereffect/type/)、[Subtype](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ifiltereffect/subtype/)和[Reveal](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ifiltereffect/reveal/)分别指定滤镜、方向以及是显示还是隐藏形状。

本示例配置了一个两秒的擦除，使用向右方向的子类型显示形状。滤镜设置属于效果内部的行为，所以在删除预设的原始操作后再进行配置。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **属性**

使用[CreatePropertyEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/)对不透明度进行动画化。[From](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ipropertyeffect/from/)、[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ipropertyeffect/to/)和[By](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ipropertyeffect/by/)是字符串，会根据[ValueType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ipropertyeffect/valuetype/)和[CalcMode](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ipropertyeffect/calcmode/)进行解释。请在端点或相对偏移之间进行选择，而不是同时设置全部三个。

这里选择的属性是不透明度，数值字符串表示从 25% 不透明度变化到全透明。线性插值描述了这两个值之间的渐变。当将本示例应用到其他属性时，请为该属性选择合适的值类型和端点值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **设置**

使用[CreateSetEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createseteffect/)通过[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/iseteffect/to/)赋予可见性。设置行为不会在端点之间进行插值。

示例选择“可见性”属性，并在行为运行时将字符串 `visible` 赋给它。矩形在此最小示例中已经是可见的，因此单独的赋值可能看不出明显的视觉变化。此类操作在更大的效果中用于控制形状何时隐藏或显示。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **命令**

使用[CreateCommandEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/)并配置[Type](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icommandeffect/type/)、[CommandString](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icommandeffect/commandstring/)和[ShapeTarget](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/icommandeffect/shapetarget/)。将名为 `sample.wav` 的 WAV 录音放在工作目录中。本示例使用[AddAudioFrameEmbedded](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addaudioframeembedded/)将其嵌入，并将播放命令附加到音频帧。

音频帧同时是效果的目标也是命令的目标。这将播放请求关联到嵌入的录音；单独的命令字符串并不能指明要控制的媒体对象。该效果被配置为在放映期间单击时启动。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

保存后将命令存储在 `command.pptx` 中；它不会播放录音。要实际播放，需要支持该命令及其媒体目标的放映播放器。

## **管理行为集合**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/)支持[Add](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/add/)、[Insert](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/insert/)、[Remove](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/removeat/)。本示例打开 `rotation.pptx`，添加缩放，将其移动到旋转之前，然后删除旋转。删除并重新插入同一对象会改变其在集合中的存储位置，而不产生副本。

编辑顺序将集合从 rotation–scale 变为 scale–rotation，最后仅保留 scale。索引始终指向当前集合，因此删除时使用的是重新排序后旋转的索引。最终枚举确认了将被保存的行为。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

输出为 `ScaleEffect`：仅保留缩放。集合顺序本身并不会安排行为依次执行。仅在全部替换操作时才使用 Clear。

## **配置行为时间安排**

[IBehavior.Timing](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehavior/timing/)公开[ITiming](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/)，独立于[IEffect.Timing](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/timing/)。效果时间安排调度整个效果；行为时间安排描述其内部的单个操作。

### **设置持续时间、延迟、重复和加速**

打开 `rotation.pptx`，以秒为单位设置[Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/duration/)和[TriggerDelayTime](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/triggerdelaytime/)，然后配置[RepeatCount](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatcount/)。[Accelerate](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/accelerate/)和[Decelerate](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/decelerate/)是持续时间的分数，二者之和最多为 1。

输入文件即前面旋转示例创建的文件，其中第一个行为已知为旋转。本示例仅更改该行为的时间安排，90 度角保持不变。将角度与时间分离，可在不重新构建动画的情况下更容易地调节节奏。

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

该行为使用两秒持续时间、半秒延迟，重复计数为 3。其前后各 20% 的持续时间用于加速和减速。

其他重复策略包括[RepeatDuration](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatduration/)、[RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilendslide/)、[RepeatUntilNextClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilnextclick/)，请一次只选择一种策略，而不是全部同时启用。[AutoReverse](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/autoreverse/)会在正向播放后逆向播放。加速和减速仅适用于连续变化，而不适用于离散赋值或命令。

## **构建运动路径**

使用[CreateMotionEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/)创建运动。其[From](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/from/)、[To](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/to/)、[By](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/by/)描述基于百分比的坐标或偏移。要创建可编辑的路线，请生成一个[MotionPath](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/motionpath/)，并将其分配给[IMotionEffect.Path](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/path/)。[IMotionPath](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotionpath/)存储路径命令。

[MotionCommandPathType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/motioncommandpathtype/) 选择操作：

| 命令 | 点数 | 含义 |
| --- | --- | --- |
| MoveTo | One | 设置起始位置。 |
| LineTo | One | 沿直线段移动到其端点。 |
| CurveTo | Three | 按两控制点和端点定义的三次曲线进行跟随。 |
| CloseLoop | None | 返回起始位置。 |
| End | None | 结束路径。 |

[MotionPathPointsType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/motionpathpointstype/) 描述点的编辑特性，如拐点或平滑点。它并不替代命令类型。曲线示例使用曲线点类型，直线段使用拐点类型。

路径坐标相对于幻灯片尺寸归一化：X 位移 0.25 表示幻灯片宽度的四分之一，而不是 0.25 点。Y 向下为正。绝对命令使用路径坐标系中的位置；相对命令使用相对于当前位置信息的偏移。这与[Origin](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/origin/)（选择路径参考框架）以及[PathEditMode](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioneffect/patheditmode/)（控制形状移动时路径如何跟随）分开。

### **创建直线路径**

创建一个运动行为，包含起始点、一个直线段和结束命令。[IMotionPath.Add](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotionpath/add/)接受命令类型、点数组、点类型以及相对坐标标志。

起始命令建立 (0, 0)，直线以 (0.25, 0) 结束，使路径在水平方向上位移幻灯片宽度的四分之一。结束命令没有坐标点。路径分配后，将运动行为添加到效果中即可把该路线连接到矩形。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` 包含一个含三条路径命令的运动行为。下面的文件编辑示例均基于此结构。

### **比较绝对坐标与相对坐标**

下面两个路径对象描述相同的路线。绝对命令以 (0.3, 0.1) 结束；相对命令在当前位置信息上加上 (0.1, 0.1)，得到 (0.2, 0)。

两条路径的起点相同。对于相对直线，将其 X、Y 偏移量加到当前位置信息即可得到终点；而绝对直线则直接读取终点坐标。仅切换标志而不转换坐标会得到不同的路径。

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

将任意路径分配给运动行为即可在演示中使用。最后的布尔参数用于为该命令选择相对坐标。

### **用曲线替换直线**

打开 `motion.pptx`，将其中的直线命令替换为三次曲线。先提供两个控制点，然后提供端点。

起始位置由前一条命令提供。前两个点定义曲线形状，第三个点为终点；它们并非三个连续的目的地。同步更新命令类型、点编辑类型和点数组，可保持该段与新几何形状的一致性。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx` 中的路径仍然有三条命令，只是中间的命令改为了曲线。

## **检查并编辑已保存的路径**

每个[IMotionCmdPath](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioncmdpath/)都公开[Points](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioncmdpath/points/)、[CommandType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioncmdpath/commandtype/)、[PointsType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioncmdpath/pointstype/)、[IsRelative](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotioncmdpath/isrelative/)。以下示例使用 `motion.pptx` 中已知的三条命令路径。对于任意输入，请先定位目标效果并在按索引编辑前检查命令类型和点数。

### **读取命令和坐标**

在不修改路径的情况下读取。结束和闭合循环命令不需要点，因此需要能够处理空点数组。

输出在列出各点之前，先把每个命令与其相对坐标标志配对，便于在修改路径前区分是端点还是偏移。曲线会列出三个点，而本文件中的直线仅列出一个点。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

列出包含起始点、绝对直线 (0.25, 0) 以及结束命令。

### **更改端点**

打开 `motion.pptx`，替换直线的点数组以移动其端点。

在输入文件中，索引 0 为起始命令，索引 1 为直线。替换直线的单一点会改变其目的地，而不影响命令类型、时间安排或在集合中的位置。因为该命令使用绝对坐标，新点直接指定位置，而不是额外的偏移。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx` 中的直线终点为 (0.4, 0.1)；原文件保持不变。

### **替换段落**

使用[Insert](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotionpath/insert/)和[RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/imotionpath/removeat/)在 `motion.pptx` 中替换直线。插入会把旧直线移到索引 2。

此示例演示了替换命令对象而不是编辑其已有坐标。插入后，集合暂时包含起始命令、新直线、旧直线和结束命令。删除索引 2 后，旧直线被丢弃，新的路线保留下来。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

保存后的路径仍有三条命令，新的直线终点为 (0.2, 0.1)，结束命令仍在最后。

## **修改并验证现有行为**

当行为索引未知时，可按类型选择。本示例打开 `rotation.pptx`，查找其[IRotationEffect](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/irotationeffect/)，更改角度，并在重新打开后检查保存的值。

类型检查使循环能够跳过非旋转行为。第二次加载将已保存的文件读取到独立的演示对象中，从而比较的是持久化数据而非仍在内存中的值。本示例仍假设已知效果是主序列中的第一个；按类型选择行为并不能在任意演示中定位正确的效果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

输出为 `Rotation preserved: True`。对其他行为请同样使用类型检查模式。要进行完整的保留检查，请比较目标形状、效果、行为类型及顺序、时间安排以及路径命令。对浮点数使用数值容差。对于动画布局未知的演示，请参阅[Read Shape Animations](/slides/zh/net/shape-animation/#read-shape-animations)了解主序列和交互序列的遍历方法。

## **行为顺序、预设与播放**

[IBehaviorCollection](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehaviorcollection/) 中的顺序是效果操作的存储顺序。它并不是播放列表，不能保证每个行为自动等待前一个。时间安排和所属效果决定调度。行为可以重叠，同一属性的操作可能通过[Additive](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehavior/additive/)和[Accumulate](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ibehavior/accumulate/)相互影响。不要仅靠集合重新排序来实现“先移动后旋转”，请使用显式时间安排或如[Shape Animation](/slides/zh/net/shape-animation/)中描述的独立效果。

效果的[Type](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/type/)和[Subtype](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/subtype/)描述其预设，但并不能完整描述已编辑的行为树。请在定制行为之前先选择预设和子类型：更改预设可能会重新构建集合并丢弃自定义操作。例如，将自定义 Spin 效果改为 Fade 可能会用设置和滤镜行为替换其旋转行为。更改预设或子类型后请重新检查集合。清除预设行为也可能删除预设所需的可见性或初始化操作。示例使用可见形状并替换行为，而不是重新构建每个预设的实现。

## **格式兼容性**

保留的行为树并不保证在每个查看器或导出渲染器中拥有完全相同的播放效果。请分别检查保存的数据和渲染输出。

| 格式或输出 | 需要验证的内容 |
| --- | --- |
| PPTX | 作为这些示例的主要格式。重新打开以验证可编辑的行为树，然后在目标 PowerPoint 版本中检查播放。 |
| PPT | 传统二进制表示可能与 PPTX 不同。请单独执行保存‑重新打开‑播放的循环，不要仅凭 PPTX 成功就推断对所有自定义组合的支持。 |
| PDF、PNG、JPEG 等静态幻灯片图像 | 仅包含静态幻灯片表示，不包含可播放的行为时间线或保证的最终动画帧。 |
| [HTML5](/slides/zh/net/export-to-html5/) | 在导出选项中启用形状动画时，可播放受支持的动画。请在浏览器中测试自定义组合。 |
| [Animated GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/) | 存储渲染后的帧，而非可编辑行为或点击触发的交互。请检查实际渲染的运动。 |
| [Video](/slides/zh/net/convert-powerpoint-to-video/) | 渲染动画帧并编码为视频。支持范围受渲染器的[支持的动画和效果](/slides/zh/net/convert-powerpoint-to-video/#supported-animations-and-effects)限制；命令和交互事件不会成为可编辑的时间线。 |

## **FAQ**

**为什么我的效果在未添加任何行为之前就已经包含行为？**

创建预定义效果时可能会生成其底层操作。请先检查这些操作，然后决定是扩展预设还是替换其行为。

**将行为移动到集合开头会让它先播放吗？**

不一定。集合顺序并不能替代时间安排。请检查延迟、持续时间以及同一属性上操作之间的相互作用。

**为什么结束命令没有点？**

它标记路径的结束，无需坐标。读取文件中的路径时，请为可能的空点数组做好检查。

**仅完成一次保存‑重新打开就足以确认播放吗？**

不能。重新打开只能确认您检查的属性是否被保留。仍需在幻灯片放映器或动画导出中单独测试，以确认其视觉行为。