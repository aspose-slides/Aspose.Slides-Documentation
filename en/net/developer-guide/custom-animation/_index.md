---
title: Create and Modify Custom Animation Behaviors in .NET
linktitle: Custom Animation
type: docs
weight: 151
url: /net/custom-animation/
keywords:
- custom animation
- animation behavior
- motion path
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create, inspect, and modify custom animation behaviors and editable motion paths in PowerPoint presentations with Aspose.Slides for .NET."
---

## **Overview**

Custom animation behaviors let you control individual operations within an animation effect, such as changing a color, rotating a shape, or following an editable motion path. This guide shows how to create and combine behaviors, configure their timing, inspect and modify existing animations, and verify that their properties survive saving and reopening a presentation.

For predefined effects and click triggers, see [Shape Animation](/slides/net/shape-animation/).

## **Understand the Animation Model**

An animation is organized as **Timeline → Sequence → Effect → Behaviors**:

- The slide's [Timeline](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/timeline/) contains its main sequence and interactive sequences.
- An [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) contains effects, potentially targeting different shapes.
- An [IEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/) identifies a target shape, preset, subtype, and effect timing.
- [IEffect.Behaviors](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/behaviors/) contains the operations that implement the effect: changing color, moving, rotating, setting a property, and so on.

## **Create Individual Behaviors**

Call [ISequence.AddEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/addeffect/) to create an effect and access its [Behaviors](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/behaviors/) collection. A preset can populate this collection automatically. Keep its operations when extending the preset, or use [Clear](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/clear/) when deliberately replacing them.

[IBehaviorFactory](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/) creates the eight behavior types illustrated below. Motion is covered in [Build a Motion Path](#build-a-motion-path). Each creation example is a complete program; later editing examples state which output file they use.

### **Rotation**

Use [CreateRotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) to create a rotation. [By](https://reference.aspose.com/slides/net/aspose.slides.animation/irotationeffect/by/) specifies a relative angle in degrees; [From](https://reference.aspose.com/slides/net/aspose.slides.animation/irotationeffect/from/) and [To](https://reference.aspose.com/slides/net/aspose.slides.animation/irotationeffect/to/) specify endpoints.

The example starts with a Spin effect, replaces its preset operations with one rotation behavior, and gives that operation a two-second duration. A relative angle of 90 degrees expresses a quarter-turn from the shape's starting orientation, so no explicit starting angle is needed.

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

`rotation.pptx` contains one shape and one rotation behavior. The collection, timing, and rotation-editing examples below use this file.

### **Scale**

Use [CreateScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) with X/Y percentages: [From](https://reference.aspose.com/slides/net/aspose.slides.animation/iscaleeffect/from/) and [To](https://reference.aspose.com/slides/net/aspose.slides.animation/iscaleeffect/to/) describe the starting and ending size, while [By](https://reference.aspose.com/slides/net/aspose.slides.animation/iscaleeffect/by/) describes a relative change. Here, 100 means the original size.

The example grows both dimensions from 100% to 125% over two seconds. Using equal horizontal and vertical percentages keeps the shape's proportions; different percentages would stretch one dimension more than the other.

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

### **Color**

Use [CreateColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) to change the fill from blue to orange. [From](https://reference.aspose.com/slides/net/aspose.slides.animation/icoloreffect/from/) and [To](https://reference.aspose.com/slides/net/aspose.slides.animation/icoloreffect/to/) are colors; [By](https://reference.aspose.com/slides/net/aspose.slides.animation/icoloreffect/by/) is a color offset. [IBehavior.Properties](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehavior/properties/) identifies the attribute being animated.

The shape's solid fill is initialized to blue, matching the animation's starting color. Selecting the fill-color attribute tells the behavior which part of the shape to change; the color endpoints alone do not identify that attribute. The saved effect describes a two-second transition to orange.

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

### **Filter**

Use [CreateFilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) to select a wipe. [Type](https://reference.aspose.com/slides/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/net/aspose.slides.animation/ifiltereffect/subtype/), and [Reveal](https://reference.aspose.com/slides/net/aspose.slides.animation/ifiltereffect/reveal/) specify the filter, direction, and whether to reveal or hide the shape.

This example configures a two-second wipe that reveals the shape using the right-direction subtype. The filter settings belong to the behavior inside the effect, so they are configured after the preset's original operations have been removed.

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

### **Property**

Use [CreatePropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) to animate opacity. [From](https://reference.aspose.com/slides/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/net/aspose.slides.animation/ipropertyeffect/to/), and [By](https://reference.aspose.com/slides/net/aspose.slides.animation/ipropertyeffect/by/) are strings interpreted using [ValueType](https://reference.aspose.com/slides/net/aspose.slides.animation/ipropertyeffect/valuetype/) and [CalcMode](https://reference.aspose.com/slides/net/aspose.slides.animation/ipropertyeffect/calcmode/). Choose endpoints or a relative offset rather than setting all three indiscriminately.

Here, the selected attribute is opacity, and the numeric strings represent a change from 25% opacity to full opacity. Linear interpolation describes a gradual change between those values. When adapting this example to another attribute, choose a value type and endpoint values appropriate to that attribute.

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

### **Set**

Use [CreateSetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) to assign visibility through [To](https://reference.aspose.com/slides/net/aspose.slides.animation/iseteffect/to/). A set behavior does not interpolate between endpoints.

The example selects the visibility attribute and assigns the string `visible` when the behavior runs. The rectangle is already visible in this minimal presentation, so the assignment may not produce an obvious visual change on its own. Such an operation is useful as part of a larger effect that also controls when the shape becomes hidden or visible.

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

### **Command**

Use [CreateCommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) and configure [Type](https://reference.aspose.com/slides/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/net/aspose.slides.animation/icommandeffect/commandstring/), and [ShapeTarget](https://reference.aspose.com/slides/net/aspose.slides.animation/icommandeffect/shapetarget/). Place a WAV recording named `sample.wav` in the working directory. This example embeds it with [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) and attaches a play command to the audio frame.

The audio frame is both the effect's target and the command's target. This connects the play request to the embedded recording; a command string by itself does not identify which media object to control. The effect is configured to start on a click during the slideshow.

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

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **Manage the Behavior Collection**

[IBehaviorCollection](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/) supports [Add](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/remove/), and [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/removeat/). This example opens `rotation.pptx`, adds scaling, moves it before rotation, and removes the rotation. Removing and reinserting the same object changes its stored position without making a copy.

The sequence of edits changes the collection from rotation–scale to scale–rotation, then to scale only. Indices refer to the current collection, so the removal uses the rotation's new index after reordering. The final enumeration confirms which behavior will be saved.

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

The output is `ScaleEffect`: only scaling remains. Collection order does not, by itself, schedule behaviors one after another. Clear the collection only when replacing all its operations.

## **Configure Behavior Timing**

[IBehavior.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehavior/timing/) exposes [ITiming](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/), independently of [IEffect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/timing/). Effect timing schedules the enclosing effect; behavior timing describes an operation inside it.

### **Set Duration, Delay, Repetition, and Acceleration**

Open `rotation.pptx` and set [Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/duration/) and [TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/triggerdelaytime/) in seconds, then configure [RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/accelerate/) and [Decelerate](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/decelerate/) are fractions of the duration; keep their sum at most 1.

The input file is the one created in the rotation example, where the first behavior is known to be a rotation. This example changes only that behavior's timing; its 90-degree angle remains intact. Keeping the angle and timing separate makes it easier to adjust the pace without rebuilding the animation.

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

The behavior uses a two-second duration, a half-second delay, and a repeat count of 3. The first and last 20% of its duration are used for acceleration and deceleration.

Other repeat policies include [RepeatDuration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide/), and [RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick/); choose a policy rather than enabling them all together. [AutoReverse](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/autoreverse/) plays the animation backwards after the forward pass. Acceleration and deceleration apply to continuous changes, not discrete assignments or commands.

## **Build a Motion Path**

Use [CreateMotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) to create motion. Its [From](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/to/), and [By](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/by/) describe percentage-based coordinates or offsets. For an editable route, create a [MotionPath](https://reference.aspose.com/slides/net/aspose.slides.animation/motionpath/) and assign it to [IMotionEffect.Path](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/net/aspose.slides.animation/imotionpath/) stores the path commands.

[MotionCommandPathType](https://reference.aspose.com/slides/net/aspose.slides.animation/motioncommandpathtype/) selects the operation:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/net/aspose.slides.animation/motionpathpointstype/) describes point-editing characteristics, such as corner or smooth points. It does not replace the command type. Use a curve point type for the curve example below, and a corner point type for the straight segments.

Path coordinates are normalized to slide dimensions: an X displacement of 0.25 represents one quarter of the slide width, not 0.25 points. Positive Y runs downward. Absolute commands specify positions in the path coordinate system; relative commands specify offsets from the current position. This is separate from [Origin](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/origin/), which selects the path's reference frame, and [PathEditMode](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioneffect/patheditmode/), which controls how the path moves when the shape is moved.

### **Create a Straight Path**

Create a motion behavior with a starting point, one straight segment, and an end command. [IMotionPath.Add](https://reference.aspose.com/slides/net/aspose.slides.animation/imotionpath/add/) takes the command type, its points, the point type, and a relative-coordinate flag.

The starting command establishes (0, 0), and the line ends at (0.25, 0), giving the route a horizontal displacement of one quarter of the slide width. The ending command has no coordinate points. Once the path is assigned, adding the motion behavior to the effect connects that route to the rectangle.

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

`motion.pptx` contains one motion behavior with three path commands. The following file-editing examples use this known structure.

### **Compare Absolute and Relative Coordinates**

These two path objects describe the same route. The absolute command ends at (0.3, 0.1); the relative command adds (0.1, 0.1) to the current position, (0.2, 0).

Both paths start at the same position. For the relative line, add its X and Y offsets to the current position to obtain the endpoint; for the absolute line, read the endpoint directly. Switching the flag without converting the coordinates would describe a different route.

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

Assign either path to a motion behavior to use it in a presentation. The final Boolean argument selects relative coordinates for that command.

### **Replace a Line with a Curve**

Open `motion.pptx` and replace its line command with a cubic curve. Supply the two control points first, followed by the endpoint.

The starting position is supplied by the preceding command. The first two points shape the curve, while the third is its destination; they are not three successive destinations. Updating the command type, point-editing type, and point array together keeps the segment consistent with its new geometry.

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

The path in `curve.pptx` still has three commands; its middle command now defines a curve.

## **Inspect and Edit a Saved Path**

Each [IMotionCmdPath](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioncmdpath/) exposes [Points](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioncmdpath/pointstype/), and [IsRelative](https://reference.aspose.com/slides/net/aspose.slides.animation/imotioncmdpath/isrelative/). The following examples use the known three-command path in `motion.pptx`. For arbitrary input, locate the intended effect and check command types and point counts before editing by index.

### **Read Commands and Coordinates**

Read the path without changing it. End and close-loop commands need no points, so allow for a null point array.

The output pairs each command with its relative-coordinate flag before listing its points. This lets you distinguish an endpoint from an offset before modifying the path. A curve would list three points, whereas the straight line in this file lists only one.

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

The listing contains a starting point, an absolute line ending at (0.25, 0), and an end command.

### **Change an Endpoint**

Open `motion.pptx` and replace the line's point array to move its endpoint.

In the input file, index 0 is the starting command and index 1 is the line. Replacing the line's single point changes its destination without changing its command type, timing, or position in the collection. Because the command uses absolute coordinates, the new pair specifies a position rather than an added offset.

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

The line in `motion-endpoint.pptx` ends at (0.4, 0.1); the original file is unchanged.

### **Replace a Segment**

Use [Insert](https://reference.aspose.com/slides/net/aspose.slides.animation/imotionpath/insert/) and [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.animation/imotionpath/removeat/) to replace the line in `motion.pptx`. Inserting shifts the old line to index 2.

This demonstrates replacing a command object rather than editing its existing coordinates. After insertion, the collection temporarily contains the starting command, the new line, the old line, and the end command. Removing index 2 discards the old line and leaves the new route in place.

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

The saved path still has three commands, with the new line ending at (0.2, 0.1) and the end command last.

## **Modify and Verify an Existing Behavior**

When the behavior's index is unknown, select it by type. This example opens `rotation.pptx`, finds its [IRotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/irotationeffect/), changes the angle, and checks the saved value after reopening.

The type check allows the loop to skip behaviors that are not rotations. The second load reads the saved file into a separate presentation object, so the comparison checks persisted data rather than the value still held in memory. This example still assumes the known effect is first in the main sequence; selecting a behavior by type does not locate the correct effect in an arbitrary presentation.

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

The output is `Rotation preserved: True`. Apply the same type-checking pattern to other behaviors. For a complete preservation check, compare the target shape, effect, behavior types and order, timing, and path commands. Use a numeric tolerance for floating-point values. For a presentation with an unknown animation layout, see [Read Shape Animations](/slides/net/shape-animation/#read-shape-animations) for traversal of main and interactive sequences.

## **Behavior Order, Presets, and Playback**

The order in [IBehaviorCollection](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehaviorcollection/) is the stored order of an effect's operations. It is not a playlist in which every behavior automatically waits for the preceding one. Timing and the enclosing effect determine scheduling. Behaviors can overlap, and operations on the same property may interact through [Additive](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehavior/additive/) and [Accumulate](https://reference.aspose.com/slides/net/aspose.slides.animation/ibehavior/accumulate/). Do not use collection reordering alone to schedule “move, then rotate”; use explicit timing or separate effects as described in [Shape Animation](/slides/net/shape-animation/).

The effect's [Type](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/type/) and [Subtype](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/subtype/) describe its preset. They are not a complete description of an edited behavior tree. Choose the preset and subtype before customizing behaviors: changing the preset can rebuild the collection and discard your custom operations. For example, changing a customized Spin effect to Fade can replace its rotation behavior with set and filter behaviors. Inspect the collection again after changing a preset or subtype. Clearing preset behaviors can also remove visibility or initialization operations that the preset needs. The examples deliberately use visible shapes and replace the behaviors; they do not reconstruct every preset's implementation.

## **Format Compatibility**

A preserved behavior tree does not guarantee identical playback in every viewer or export renderer. Check the saved data and the rendered output separately.

| Format or output | What to verify |
| --- | --- |
| PPTX | Use as the primary format for these examples. Reopen it to verify the editable behavior tree, then check playback in the intended PowerPoint version. |
| PPT | Legacy binary representation can differ from PPTX. Test a separate save-and-reopen cycle and playback; do not infer support for every custom combination from successful PPTX output. |
| PDF, PNG, JPEG, and other static slide images | Contain a static slide representation, not a playable behavior timeline or a guaranteed final animation frame. |
| [HTML5](/slides/net/export-to-html5/) | Can play supported animations when shape animation is enabled in the export options. Test custom combinations in the browser. |
| [Animated GIF](/slides/net/convert-powerpoint-to-animated-gif/) | Stores rendered frames, not editable behaviors or click-triggered interaction. Check the actual rendered motion. |
| [Video](/slides/net/convert-powerpoint-to-video/) | Render animation frames and encode them as video. Support is limited to the renderer's [supported animations and effects](/slides/net/convert-powerpoint-to-video/#supported-animations-and-effects); commands and interactive events do not become an editable timeline. |

## **FAQ**

**Why does my effect contain behaviors before I add any?**

Creating a predefined effect can create its underlying operations. Inspect them before deciding whether to extend the preset or replace its behaviors.

**Does moving a behavior to the beginning make it play first?**

Not necessarily. Collection order is not a substitute for timing. Check delays, durations, and interactions between operations on the same property.

**Why does an end command have no points?**

It marks the end of the path and needs no coordinates. Check for a null point array when inspecting a path read from a file.

**Is a successful round trip sufficient to confirm playback?**

No. Reopening confirms preservation of the properties you checked. Test the slideshow player or animated export separately to confirm its visual behavior.
