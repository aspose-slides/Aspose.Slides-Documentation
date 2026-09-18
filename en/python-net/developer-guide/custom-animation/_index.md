---
title: Create and Modify Custom Animation Behaviors in Python
linktitle: Custom Animation
type: docs
weight: 151
url: /python-net/custom-animation/
keywords:
- custom animation
- animation behavior
- motion path
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create, inspect, and modify custom animation behaviors and editable motion paths in PowerPoint presentations with Aspose.Slides for Python via .NET."
---

## **Overview**

Custom animation behaviors let you control individual operations within an animation effect, such as changing a color, rotating a shape, or following an editable motion path. This guide shows how to create and combine behaviors, configure their timing, inspect and modify existing animations, and verify that their properties survive saving and reopening a presentation.

For predefined effects and click triggers, see [Shape Animation](/slides/python-net/shape-animation/).

## **Understand the Animation Model**

An animation is organized as **Timeline → Sequence → Effect → Behaviors**:

- The slide's [timeline](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/timeline/) contains its main sequence and interactive sequences.
- A [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) contains effects, potentially targeting different shapes.
- An [Effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/) identifies a target shape, preset, subtype, and effect timing.
- [Effect.behaviors](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/behaviors/) contains the operations that implement the effect: changing color, moving, rotating, setting a property, and so on.

## **Create Individual Behaviors**

Call [Sequence.add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) to create an effect and access its [behaviors](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/behaviors/) collection. A preset can populate this collection automatically. Keep its operations when extending the preset, or use [clear](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/clear/) when deliberately replacing them.

[BehaviorFactory](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/) creates the eight behavior types illustrated below. Motion is covered in [Build a Motion Path](#build-a-motion-path). Each creation example is a complete program; later editing examples state which output file they use.

### **Rotation**

Use [create_rotation_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) to create a rotation. [by](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect/by/) specifies a relative angle in degrees; [from_address](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect/from_address/) and [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect/to/) specify endpoints.

The example starts with a Spin effect, replaces its preset operations with one rotation behavior, and gives that operation a two-second duration. A relative angle of 90 degrees expresses a quarter-turn from the shape's starting orientation, so no explicit starting angle is needed.

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

`rotation.pptx` contains one shape and one rotation behavior. The collection, timing, and rotation-editing examples below use this file.

### **Scale**

Use [create_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) with X/Y percentages: [from_address](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/from_address/) and [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/to/) describe the starting and ending size, while [by](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/by/) describes a relative change. Here, 100 means the original size.

The example grows both dimensions from 100% to 125% over two seconds. Using equal horizontal and vertical percentages keeps the shape's proportions; different percentages would stretch one dimension more than the other.

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

### **Color**

Use [create_color_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) to change the fill from blue to orange. [from_address](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/from_address/) and [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/to/) are colors; [by](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/by/) is a color offset. [Behavior.properties](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/properties/) identifies the attribute being animated.

The shape's solid fill is initialized to blue, matching the animation's starting color. Selecting the fill-color attribute tells the behavior which part of the shape to change; the color endpoints alone do not identify that attribute. The saved effect describes a two-second transition to orange.

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

### **Filter**

Use [create_filter_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) to select a wipe. [type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/subtype/), and [reveal](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/reveal/) specify the filter, direction, and whether to reveal or hide the shape.

This example configures a two-second wipe that reveals the shape using the right-direction subtype. The filter settings belong to the behavior inside the effect, so they are configured after the preset's original operations have been removed.

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

### **Property**

Use [create_property_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) to animate opacity. [from_address](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/to/), and [by](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/by/) are strings interpreted using [value_type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/value_type/) and [calc_mode](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Choose endpoints or a relative offset rather than setting all three indiscriminately.

Here, the selected attribute is opacity, and the numeric strings represent a change from 25% opacity to full opacity. Linear interpolation describes a gradual change between those values. When adapting this example to another attribute, choose a value type and endpoint values appropriate to that attribute.

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

### **Set**

Use [create_set_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) to assign visibility through [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/to/). A set behavior does not interpolate between endpoints.

The example selects the visibility attribute and assigns the string `visible` when the behavior runs. The rectangle is already visible in this minimal presentation, so the assignment may not produce an obvious visual change on its own. Such an operation is useful as part of a larger effect that also controls when the shape becomes hidden or visible.

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

### **Command**

Use [create_command_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) and configure [type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/command_string/), and [shape_target](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/shape_target/). Place a WAV recording named `sample.wav` in the working directory. This example embeds it with [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) and attaches a play command to the audio frame.

The audio frame is both the effect's target and the command's target. This connects the play request to the embedded recording; a command string by itself does not identify which media object to control. The effect is configured to start on a click during the slideshow.

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

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **Manage the Behavior Collection**

[BehaviorCollection](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/) supports [add](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/remove/), and [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/remove_at/). This example opens `rotation.pptx`, adds scaling, moves it before rotation, and removes the rotation. Removing and reinserting the same object changes its stored position without making a copy.

The sequence of edits changes the collection from rotation–scale to scale–rotation, then to scale only. Indices refer to the current collection, so the removal uses the rotation's new index after reordering. The final enumeration confirms which behavior will be saved.

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

The output is `ScaleEffect`: only scaling remains. Collection order does not, by itself, schedule behaviors one after another. Clear the collection only when replacing all its operations.

## **Configure Behavior Timing**

[Behavior.timing](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/timing/) exposes [Timing](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/), independently of [Effect.timing](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/timing/). Effect timing schedules the enclosing effect; behavior timing describes an operation inside it.

### **Set Duration, Delay, Repetition, and Acceleration**

Open `rotation.pptx` and set [duration](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/duration/) and [trigger_delay_time](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/trigger_delay_time/) in seconds, then configure [repeat_count](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/accelerate/) and [decelerate](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/decelerate/) are fractions of the duration; keep their sum at most 1.

The input file is the one created in the rotation example, where the first behavior is known to be a rotation. This example changes only that behavior's timing; its 90-degree angle remains intact. Keeping the angle and timing separate makes it easier to adjust the pace without rebuilding the animation.

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

The behavior uses a two-second duration, a half-second delay, and a repeat count of 3. The first and last 20% of its duration are used for acceleration and deceleration.

Other repeat policies include [repeat_duration](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), and [repeat_until_next_click](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/repeat_until_next_click/); choose a policy rather than enabling them all together. [auto_reverse](https://reference.aspose.com/slides/python-net/aspose.slides.animation/timing/auto_reverse/) plays the animation backwards after the forward pass. Acceleration and deceleration apply to continuous changes, not discrete assignments or commands.

## **Build a Motion Path**

Use [create_motion_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) to create motion. Its [from_address](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/to/), and [by](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/by/) describe percentage-based coordinates or offsets. For an editable route, create a [MotionPath](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpath/) and assign it to [MotionEffect.path](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpath/) stores the path commands.

[MotionCommandPathType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncommandpathtype/) selects the operation:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | Set the starting position. |
| LINE_TO | One | Move along a straight segment to its endpoint. |
| CURVE_TO | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CLOSE_LOOP | None | Return to the starting position. |
| END | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpathpointstype/) describes point-editing characteristics, such as corner or smooth points. It does not replace the command type. Use a curve point type for the curve example below, and a corner point type for the straight segments.

Path coordinates are normalized to slide dimensions: an X displacement of 0.25 represents one quarter of the slide width, not 0.25 points. Positive Y runs downward. Absolute commands specify positions in the path coordinate system; relative commands specify offsets from the current position. This is separate from [origin](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/origin/), which selects the path's reference frame, and [path_edit_mode](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), which controls how the path moves when the shape is moved.

### **Create a Straight Path**

Create a motion behavior with a starting point, one straight segment, and an end command. [MotionPath.add](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpath/add/) takes the command type, its points, the point type, and a relative-coordinate flag.

The starting command establishes (0, 0), and the line ends at (0.25, 0), giving the route a horizontal displacement of one quarter of the slide width. The ending command has no coordinate points. Once the path is assigned, adding the motion behavior to the effect connects that route to the rectangle.

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

`motion.pptx` contains one motion behavior with three path commands. The following file-editing examples use this known structure.

### **Compare Absolute and Relative Coordinates**

These two path objects describe the same route. The absolute command ends at (0.3, 0.1); the relative command adds (0.1, 0.1) to the current position, (0.2, 0).

Both paths start at the same position. For the relative line, add its X and Y offsets to the current position to obtain the endpoint; for the absolute line, read the endpoint directly. Switching the flag without converting the coordinates would describe a different route.

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

Assign either path to a motion behavior to use it in a presentation. The final Boolean argument selects relative coordinates for that command.

### **Replace a Line with a Curve**

Open `motion.pptx` and replace its line command with a cubic curve. Supply the two control points first, followed by the endpoint.

The starting position is supplied by the preceding command. The first two points shape the curve, while the third is its destination; they are not three successive destinations. Updating the command type, point-editing type, and point array together keeps the segment consistent with its new geometry.

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

The path in `curve.pptx` still has three commands; its middle command now defines a curve.

## **Inspect and Edit a Saved Path**

Each [MotionCmdPath](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncmdpath/) exposes [points](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncmdpath/points_type/), and [is_relative](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioncmdpath/is_relative/). The following examples use the known three-command path in `motion.pptx`. For arbitrary input, locate the intended effect and check command types and point counts before editing by index.

### **Read Commands and Coordinates**

Read the path without changing it. End and close-loop commands need no points, so allow for a `None` point array.

The output pairs each command with its relative-coordinate flag before listing its points. This lets you distinguish an endpoint from an offset before modifying the path. A curve would list three points, whereas the straight line in this file lists only one.

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

The listing contains a starting point, an absolute line ending at (0.25, 0), and an end command.

### **Change an Endpoint**

Open `motion.pptx` and replace the line's point array to move its endpoint.

In the input file, index 0 is the starting command and index 1 is the line. Replacing the line's single point changes its destination without changing its command type, timing, or position in the collection. Because the command uses absolute coordinates, the new pair specifies a position rather than an added offset.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

The line in `motion-endpoint.pptx` ends at (0.4, 0.1); the original file is unchanged.

### **Replace a Segment**

Use [insert](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpath/insert/) and [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motionpath/remove_at/) to replace the line in `motion.pptx`. Inserting shifts the old line to index 2.

This demonstrates replacing a command object rather than editing its existing coordinates. After insertion, the collection temporarily contains the starting command, the new line, the old line, and the end command. Removing index 2 discards the old line and leaves the new route in place.

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

The saved path still has three commands, with the new line ending at (0.2, 0.1) and the end command last.

## **Modify and Verify an Existing Behavior**

When the behavior's index is unknown, select it by type. This example opens `rotation.pptx`, finds its [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect/), changes the angle, and checks the saved value after reopening.

The type check allows the loop to skip behaviors that are not rotations. The second load reads the saved file into a separate presentation object, so the comparison checks persisted data rather than the value still held in memory. This example still assumes the known effect is first in the main sequence; selecting a behavior by type does not locate the correct effect in an arbitrary presentation.

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

The output is `Rotation preserved: True`. Apply the same type-checking pattern to other behaviors. For a complete preservation check, compare the target shape, effect, behavior types and order, timing, and path commands. Use a numeric tolerance for floating-point values. For a presentation with an unknown animation layout, see [Read Shape Animations](/slides/python-net/shape-animation/#read-shape-animations) for traversal of main and interactive sequences.

## **Behavior Order, Presets, and Playback**

The order in [BehaviorCollection](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behaviorcollection/) is the stored order of an effect's operations. It is not a playlist in which every behavior automatically waits for the preceding one. Timing and the enclosing effect determine scheduling. Behaviors can overlap, and operations on the same property may interact through [additive](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/additive/) and [accumulate](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/accumulate/). Do not use collection reordering alone to schedule “move, then rotate”; use explicit timing or separate effects as described in [Shape Animation](/slides/python-net/shape-animation/).

The effect's [type](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/type/) and [subtype](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effect/subtype/) describe its preset. They are not a complete description of an edited behavior tree. Choose the preset and subtype before customizing behaviors: changing the preset can rebuild the collection and discard your custom operations. For example, changing a customized Spin effect to Fade can replace its rotation behavior with set and filter behaviors. Inspect the collection again after changing a preset or subtype. Clearing preset behaviors can also remove visibility or initialization operations that the preset needs. The examples deliberately use visible shapes and replace the behaviors; they do not reconstruct every preset's implementation.

## **Format Compatibility**

A preserved behavior tree does not guarantee identical playback in every viewer or export renderer. Check the saved data and the rendered output separately.

| Format or output | What to verify |
| --- | --- |
| PPTX | Use as the primary format for these examples. Reopen it to verify the editable behavior tree, then check playback in the intended PowerPoint version. |
| PPT | Legacy binary representation can differ from PPTX. Test a separate save-and-reopen cycle and playback; do not infer support for every custom combination from successful PPTX output. |
| PDF, PNG, JPEG, and other static slide images | Contain a static slide representation, not a playable behavior timeline or a guaranteed final animation frame. |
| [HTML5](/slides/python-net/export-to-html5/) | Can play supported animations when shape animation is enabled in the export options. Test custom combinations in the browser. |
| [Animated GIF](/slides/python-net/convert-powerpoint-to-animated-gif/) | Stores rendered frames, not editable behaviors or click-triggered interaction. Check the actual rendered motion. |
| [Video](/slides/python-net/convert-powerpoint-to-video/) | Render animation frames and encode them as video. Support is limited to the renderer's [supported animations and effects](/slides/python-net/convert-powerpoint-to-video/#supported-animations-and-effects); commands and interactive events do not become an editable timeline. |

## **FAQ**

**Why does my effect contain behaviors before I add any?**

Creating a predefined effect can create its underlying operations. Inspect them before deciding whether to extend the preset or replace its behaviors.

**Does moving a behavior to the beginning make it play first?**

Not necessarily. Collection order is not a substitute for timing. Check delays, durations, and interactions between operations on the same property.

**Why does an end command have no points?**

It marks the end of the path and needs no coordinates. Check for a `None` point array when inspecting a path read from a file.

**Is a successful round trip sufficient to confirm playback?**

No. Reopening confirms preservation of the properties you checked. Test the slideshow player or animated export separately to confirm its visual behavior.
