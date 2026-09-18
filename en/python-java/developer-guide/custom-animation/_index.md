---
title: Create and Modify Custom Animation Behaviors in Python via Java
linktitle: Custom Animation
type: docs
weight: 151
url: /python-java/custom-animation/
keywords:
- custom animation
- animation behavior
- motion path
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Create, inspect, and modify custom animation behaviors and editable motion paths in PowerPoint presentations with Aspose.Slides for Python via Java."
---

## **Overview**

Custom animation behaviors let you control individual operations within an animation effect, such as changing a color, rotating a shape, or following an editable motion path. This guide shows how to create and combine behaviors, configure their timing, inspect and modify existing animations, and verify that their properties survive saving and reopening a presentation.

For predefined effects and click triggers, see [Shape Animation](/slides/python-java/shape-animation/).

## **Understand the Animation Model**

An animation is organized as **Timeline → Sequence → Effect → Behaviors**:

- The [getTimeline](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getTimeline) method returns the slide timeline, which contains its main sequence and interactive sequences.
- A [Sequence](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/) contains effects, potentially targeting different shapes.
- An [Effect](https://reference.aspose.com/slides/python-java/aspose.slides/effect/) identifies a target shape, preset, subtype, and effect timing.
- The collection returned by [Effect.getBehaviors](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getBehaviors) contains the operations that implement the effect: changing color, moving, rotating, setting a property, and so on.

## **Create Individual Behaviors**

Call [Sequence.addEffect](https://reference.aspose.com/slides/python-java/aspose.slides/sequence/#addEffect) to create an effect and access the [getBehaviors](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getBehaviors) collection. A preset can populate this collection automatically. Keep its operations when extending the preset, or use [clear](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/#clear) when deliberately replacing them.

[BehaviorFactory](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/) creates the eight behavior types illustrated below. Motion is covered in [Build a Motion Path](#build-a-motion-path). Each snippet includes its imports and starts the JVM if necessary. Java point objects and arrays are created through JPype where the API requires them. Later editing examples state which output file they use.

### **Rotation**

Use [createRotationEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createRotationEffect) to create a rotation. [getBy](https://reference.aspose.com/slides/python-java/aspose.slides/rotationeffect/#getBy) specifies a relative angle in degrees; [getFrom](https://reference.aspose.com/slides/python-java/aspose.slides/rotationeffect/#getFrom) and [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/rotationeffect/#getTo) specify endpoints.

The example starts with a Spin effect, replaces its preset operations with one rotation behavior, and gives that operation a two-second duration. A relative angle of 90 degrees expresses a quarter-turn from the shape's starting orientation, so no explicit starting angle is needed.

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

`rotation.pptx` contains one shape and one rotation behavior. The collection, timing, and rotation-editing examples below use this file.

### **Scale**

Use [createScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createScaleEffect) with X/Y percentages: [getFrom](https://reference.aspose.com/slides/python-java/aspose.slides/scaleeffect/#getFrom) and [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/scaleeffect/#getTo) describe the starting and ending size, while [getBy](https://reference.aspose.com/slides/python-java/aspose.slides/scaleeffect/#getBy) describes a relative change. Here, 100 means the original size.

The example grows both dimensions from 100% to 125% over two seconds. Using equal horizontal and vertical percentages keeps the shape's proportions; different percentages would stretch one dimension more than the other.

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

### **Color**

Use [createColorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createColorEffect) to change the fill from blue to orange. [getFrom](https://reference.aspose.com/slides/python-java/aspose.slides/coloreffect/#getFrom) and [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/coloreffect/#getTo) are colors; [getBy](https://reference.aspose.com/slides/python-java/aspose.slides/coloreffect/#getBy) is a color offset. [Behavior.getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/behavior/#getProperties) identifies the attribute being animated.

The shape's solid fill is initialized to blue, matching the animation's starting color. Selecting the fill-color attribute tells the behavior which part of the shape to change; the color endpoints alone do not identify that attribute. The saved effect describes a two-second transition to orange.

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

### **Filter**

Use [createFilterEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createFilterEffect) to select a wipe. [getType](https://reference.aspose.com/slides/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/python-java/aspose.slides/filtereffect/#getSubtype), and [getReveal](https://reference.aspose.com/slides/python-java/aspose.slides/filtereffect/#getReveal) specify the filter, direction, and whether to reveal or hide the shape.

This example configures a two-second wipe that reveals the shape using the right-direction subtype. The filter settings belong to the behavior inside the effect, so they are configured after the preset's original operations have been removed.

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

### **Property**

Use [createPropertyEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) to animate opacity. [getFrom](https://reference.aspose.com/slides/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/propertyeffect/#getTo), and [getBy](https://reference.aspose.com/slides/python-java/aspose.slides/propertyeffect/#getBy) are strings interpreted using [getValueType](https://reference.aspose.com/slides/python-java/aspose.slides/propertyeffect/#getValueType) and [getCalcMode](https://reference.aspose.com/slides/python-java/aspose.slides/propertyeffect/#getCalcMode). Choose endpoints or a relative offset rather than setting all three indiscriminately.

Here, the selected attribute is opacity, and the numeric strings represent a change from 25% opacity to full opacity. Linear interpolation describes a gradual change between those values. When adapting this example to another attribute, choose a value type and endpoint values appropriate to that attribute.

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

### **Set**

Use [createSetEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createSetEffect) to assign visibility through [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/seteffect/#getTo). A set behavior does not interpolate between endpoints.

The example selects the visibility attribute and assigns the string `visible` when the behavior runs. The rectangle is already visible in this minimal presentation, so the assignment may not produce an obvious visual change on its own. Such an operation is useful as part of a larger effect that also controls when the shape becomes hidden or visible.

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

### **Command**

Use [createCommandEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createCommandEffect) and configure [getType](https://reference.aspose.com/slides/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/python-java/aspose.slides/commandeffect/#getCommandString), and [getShapeTarget](https://reference.aspose.com/slides/python-java/aspose.slides/commandeffect/#getShapeTarget). Place a WAV recording named `sample.wav` in the working directory. This example embeds it with [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) and attaches a play command to the audio frame.

The audio frame is both the effect's target and the command's target. This connects the play request to the embedded recording; a command string by itself does not identify which media object to control. The effect is configured to start on a click during the slideshow.

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

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **Manage the Behavior Collection**

[BehaviorCollection](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/) supports [add](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/#remove), and [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/#removeAt). This example opens `rotation.pptx`, adds scaling, moves it before rotation, and removes the rotation. Removing and reinserting the same object changes its stored position without making a copy.

The sequence of edits changes the collection from rotation–scale to scale–rotation, then to scale only. Indices refer to the current collection, so the removal uses the rotation's new index after reordering. The final enumeration confirms which behavior will be saved.

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

The output is `ScaleEffect`: only scaling remains. Collection order does not, by itself, schedule behaviors one after another. Clear the collection only when replacing all its operations.

## **Configure Behavior Timing**

[Behavior.getTiming](https://reference.aspose.com/slides/python-java/aspose.slides/behavior/#getTiming) exposes [Timing](https://reference.aspose.com/slides/python-java/aspose.slides/timing/), independently of [Effect.getTiming](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getTiming). Effect timing schedules the enclosing effect; behavior timing describes an operation inside it.

### **Set Duration, Delay, Repetition, and Acceleration**

Open `rotation.pptx` and set the duration ([getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getDuration)) and trigger delay ([getTriggerDelayTime](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getTriggerDelayTime)) in seconds, then configure the repeat count through [setRepeatCount](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getAccelerate) and [getDecelerate](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getDecelerate) are fractions of the duration; keep their sum at most 1.

The input file is the one created in the rotation example, where the first behavior is known to be a rotation. This example changes only that behavior's timing; its 90-degree angle remains intact. Keeping the angle and timing separate makes it easier to adjust the pace without rebuilding the animation.

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

The behavior uses a two-second duration, a half-second delay, and a repeat count of 3. The first and last 20% of its duration are used for acceleration and deceleration.

Other repeat policies include [getRepeatDuration](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatUntilEndSlide), and [getRepeatUntilNextClick](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getRepeatUntilNextClick); choose a policy rather than enabling them all together. [getAutoReverse](https://reference.aspose.com/slides/python-java/aspose.slides/timing/#getAutoReverse) plays the animation backwards after the forward pass. Acceleration and deceleration apply to continuous changes, not discrete assignments or commands.

## **Build a Motion Path**

Use [createMotionEffect](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorfactory/#createMotionEffect) to create motion. Its [getFrom](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#getTo), and [getBy](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#getBy) describe percentage-based coordinates or offsets. For an editable route, create a [MotionPath](https://reference.aspose.com/slides/python-java/aspose.slides/motionpath/) and assign it with [MotionEffect.setPath](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/python-java/aspose.slides/motionpath/) stores the path commands.

[MotionCommandPathType](https://reference.aspose.com/slides/python-java/aspose.slides/motioncommandpathtype/) selects the operation:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/python-java/aspose.slides/motionpathpointstype/) describes point-editing characteristics, such as corner or smooth points. It does not replace the command type. Use a curve point type for the curve example below, and a corner point type for the straight segments.

Path coordinates are normalized to slide dimensions: an X displacement of 0.25 represents one quarter of the slide width, not 0.25 points. Positive Y runs downward. Absolute commands specify positions in the path coordinate system; relative commands specify offsets from the current position. This is separate from [getOrigin](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#getOrigin), which selects the path's reference frame, and [getPathEditMode](https://reference.aspose.com/slides/python-java/aspose.slides/motioneffect/#getPathEditMode), which controls how the path moves when the shape is moved.

### **Create a Straight Path**

Create a motion behavior with a starting point, one straight segment, and an end command. [MotionPath.add](https://reference.aspose.com/slides/python-java/aspose.slides/motionpath/#add) takes the command type, its points, the point type, and a relative-coordinate flag.

The starting command establishes (0, 0), and the line ends at (0.25, 0), giving the route a horizontal displacement of one quarter of the slide width. The ending command has no coordinate points. Once the path is assigned, adding the motion behavior to the effect connects that route to the rectangle.

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

`motion.pptx` contains one motion behavior with three path commands. The following file-editing examples use this known structure.

### **Compare Absolute and Relative Coordinates**

These two path objects describe the same route. The absolute command ends at (0.3, 0.1); the relative command adds (0.1, 0.1) to the current position, (0.2, 0).

Both paths start at the same position. For the relative line, add its X and Y offsets to the current position to obtain the endpoint; for the absolute line, read the endpoint directly. Switching the flag without converting the coordinates would describe a different route.

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

Assign either path to a motion behavior to use it in a presentation. The final Boolean argument selects relative coordinates for that command.

### **Replace a Line with a Curve**

Open `motion.pptx` and replace its line command with a cubic curve. Supply the two control points first, followed by the endpoint.

The starting position is supplied by the preceding command. The first two points shape the curve, while the third is its destination; they are not three successive destinations. Updating the command type, point-editing type, and point array together keeps the segment consistent with its new geometry.

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

The path in `curve.pptx` still has three commands; its middle command now defines a curve.

## **Inspect and Edit a Saved Path**

Each [MotionCmdPath](https://reference.aspose.com/slides/python-java/aspose.slides/motioncmdpath/) exposes [getPoints](https://reference.aspose.com/slides/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/python-java/aspose.slides/motioncmdpath/#getPointsType), and [isRelative](https://reference.aspose.com/slides/python-java/aspose.slides/motioncmdpath/#isRelative). The following examples use the known three-command path in `motion.pptx`. For arbitrary input, locate the intended effect and check command types and point counts before editing by index.

### **Read Commands and Coordinates**

Read the path without changing it. End and close-loop commands need no points, so allow for a null point array.

The output pairs each numeric command type with its relative-coordinate flag before listing its points. This lets you distinguish an endpoint from an offset before modifying the path. A curve would list three points, whereas the straight line in this file lists only one.

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

The listing contains a starting point, an absolute line ending at (0.25, 0), and an end command.

### **Change an Endpoint**

Open `motion.pptx` and replace the line's point array to move its endpoint.

In the input file, index 0 is the starting command and index 1 is the line. Replacing the line's single point changes its destination without changing its command type, timing, or position in the collection. Because the command uses absolute coordinates, the new pair specifies a position rather than an added offset.

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

The line in `motion-endpoint.pptx` ends at (0.4, 0.1); the original file is unchanged.

### **Replace a Segment**

Use [insert](https://reference.aspose.com/slides/python-java/aspose.slides/motionpath/#insert) and [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/motionpath/#removeAt) to replace the line in `motion.pptx`. Inserting shifts the old line to index 2.

This demonstrates replacing a command object rather than editing its existing coordinates. After insertion, the collection temporarily contains the starting command, the new line, the old line, and the end command. Removing index 2 discards the old line and leaves the new route in place.

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

The saved path still has three commands, with the new line ending at (0.2, 0.1) and the end command last.

## **Modify and Verify an Existing Behavior**

When the behavior's index is unknown, select it by type. This example opens `rotation.pptx`, finds its [RotationEffect](https://reference.aspose.com/slides/python-java/aspose.slides/rotationeffect/), changes the angle, and checks the saved value after reopening.

The type check allows the loop to skip behaviors that are not rotations. The second load reads the saved file into a separate presentation object, so the comparison checks persisted data rather than the value still held in memory. This example still assumes the known effect is first in the main sequence; selecting a behavior by type does not locate the correct effect in an arbitrary presentation.

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

The output is `Rotation preserved: True`. Apply the same type-checking pattern to other behaviors. For a complete preservation check, compare the target shape, effect, behavior types and order, timing, and path commands. Use a numeric tolerance for floating-point values. For a presentation with an unknown animation layout, see [Read Shape Animations](/slides/python-java/shape-animation/#read-shape-animations) for traversal of main and interactive sequences.

## **Behavior Order, Presets, and Playback**

The order in [BehaviorCollection](https://reference.aspose.com/slides/python-java/aspose.slides/behaviorcollection/) is the stored order of an effect's operations. It is not a playlist in which every behavior automatically waits for the preceding one. Timing and the enclosing effect determine scheduling. Behaviors can overlap, and operations on the same property may interact through [getAdditive](https://reference.aspose.com/slides/python-java/aspose.slides/behavior/#getAdditive) and [getAccumulate](https://reference.aspose.com/slides/python-java/aspose.slides/behavior/#getAccumulate). Do not use collection reordering alone to schedule “move, then rotate”; use explicit timing or separate effects as described in [Shape Animation](/slides/python-java/shape-animation/).

The effect's [getType](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getType) and [getSubtype](https://reference.aspose.com/slides/python-java/aspose.slides/effect/#getSubtype) describe its preset. They are not a complete description of an edited behavior tree. Choose the preset and subtype before customizing behaviors: changing the preset can rebuild the collection and discard your custom operations. For example, changing a customized Spin effect to Fade can replace its rotation behavior with set and filter behaviors. Inspect the collection again after changing a preset or subtype. Clearing preset behaviors can also remove visibility or initialization operations that the preset needs. The examples deliberately use visible shapes and replace the behaviors; they do not reconstruct every preset's implementation.

## **Format Compatibility**

A preserved behavior tree does not guarantee identical playback in every viewer or export renderer. Check the saved data and the rendered output separately.

| Format or output | What to verify |
| --- | --- |
| PPTX | Use as the primary format for these examples. Reopen it to verify the editable behavior tree, then check playback in the intended PowerPoint version. |
| PPT | Legacy binary representation can differ from PPTX. Test a separate save-and-reopen cycle and playback; do not infer support for every custom combination from successful PPTX output. |
| PDF, PNG, JPEG, and other static slide images | Contain a static slide representation, not a playable behavior timeline or a guaranteed final animation frame. |
| [HTML5](/slides/python-java/export-to-html5/) | Can play supported animations when shape animation is enabled in the export options. Test custom combinations in the browser. |
| [Animated GIF](/slides/python-java/convert-powerpoint-to-animated-gif/) | Stores rendered frames, not editable behaviors or click-triggered interaction. Check the actual rendered motion. |
| [Video](/slides/python-java/convert-powerpoint-to-video/) | Render animation frames and encode them as video. Support is limited to the renderer's [supported animations and effects](/slides/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); commands and interactive events do not become an editable timeline. |

## **FAQ**

**Why does my effect contain behaviors before I add any?**

Creating a predefined effect can create its underlying operations. Inspect them before deciding whether to extend the preset or replace its behaviors.

**Does moving a behavior to the beginning make it play first?**

Not necessarily. Collection order is not a substitute for timing. Check delays, durations, and interactions between operations on the same property.

**Why does an end command have no points?**

It marks the end of the path and needs no coordinates. Check for a null point array when inspecting a path read from a file.

**Is a successful round trip sufficient to confirm playback?**

No. Reopening confirms preservation of the properties you checked. Test the slideshow player or animated export separately to confirm its visual behavior.
