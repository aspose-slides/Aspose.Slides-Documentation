---
title: जावास्क्रिप्ट में कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/nodejs-java/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- मोशन पाथ
- पावरपॉइंट
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के माध्यम से जावास्क्रिप्ट में पावरपॉइंट प्रेजेंटेशन में कस्टम एनीमेशन व्यवहार और संपादन योग्य मोशन पाथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनीमेशन व्यवहार आपको एनीमेशन इफ़ेक्ट के भीतर व्यक्तिगत संचालन को नियंत्रित करने देते हैं, जैसे रंग बदलना, आकार को घुमाना, या संपादनीय मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि व्यवहारों को कैसे बनाया और संयोजित किया जाए, उनके समय को कैसे कॉन्फ़िगर किया जाए, मौजूदा एनीमेशन को कैसे निरीक्षण और संशोधित किया जाए, और यह सुनिश्चित किया जाए कि उनके गुण प्रस्तुति को सेव और फिर से खोलने पर भी बरकरार रहें।

For predefined effects and click triggers, see [आकार एनीमेशन](/slides/hi/nodejs-java/shape-animation/).

## **एनीमेशन मॉडल को समझें**

एक एनीमेशन को **Timeline → Sequence → Effect → Behaviors** के रूप में व्यवस्थित किया जाता है:

- The [getTimeline](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getTimeline) method returns the slide timeline, which contains its main sequence and interactive sequences.  
  **विधि** स्लाइड टाइमलाइन लौटाता है, जिसमें इसका मुख्य अनुक्रम और इंटरैक्टिव अनुक्रम शामिल हैं।
- A [Sequence](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/) contains effects, potentially targeting different shapes.  
  **एक अनुक्रम** इफ़ेक्ट्स रखता है, जो संभावित रूप से विभिन्न आकारों को लक्ष्य बना सकते हैं।
- An [Effect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/) identifies a target shape, preset, subtype, and effect timing.  
  **एक इफ़ेक्ट** लक्ष्य आकार, प्रीसेट, सबटाइप, और इफ़ेक्ट समय को पहचानता है।
- The collection returned by [Effect.getBehaviors](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getBehaviors) contains the operations that implement the effect: changing color, moving, rotating, setting a property, and so on.  
  **कलेक्शन** जो [Effect.getBehaviors] द्वारा लौटाया जाता है, उन ऑपरेशनों को शामिल करता है जो इफ़ेक्ट को लागू करते हैं: रंग बदलना, स्थानांतरित होना, घुमाना, प्रॉपर्टी सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

Call [Sequence.addEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sequence/#addEffect) to create an effect and access the [getBehaviors](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getBehaviors) collection. A preset can populate this collection automatically. Keep its operations when extending the preset, or use [clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/#clear) when deliberately replacing them.

[BehaviorFactory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/) creates the eight behavior types illustrated below. Motion is covered in [Build a Motion Path](#build-a-motion-path). Each snippet includes its module imports and can run as a Node.js script with the `aspose.slides.via.java` and `java` packages installed. Run the file-creation examples before the examples that read their output. Later editing examples state which output file they use.

### **घूर्णन**

Use [createRotationEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) to create a rotation. [getBy](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/rotationeffect/#getBy) specifies a relative angle in degrees; [getFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/rotationeffect/#getFrom) and [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/rotationeffect/#getTo) specify endpoints.

The example starts with a Spin effect, replaces its preset operations with one rotation behavior, and gives that operation a two-second duration. A relative angle of 90 degrees expresses a quarter-turn from the shape's starting orientation, so no explicit starting angle is needed.

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

`rotation.pptx` contains one shape and one rotation behavior. The collection, timing, and rotation-editing examples below use this file.

### **स्केल**

Use [createScaleEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) with X/Y percentages: [getFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/scaleeffect/#getFrom) and [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/scaleeffect/#getTo) describe the starting and ending size, while [getBy](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/scaleeffect/#getBy) describes a relative change. Here, 100 means the original size.

The example grows both dimensions from 100% to 125% over two seconds. Using equal horizontal and vertical percentages keeps the shape's proportions; different percentages would stretch one dimension more than the other.

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

### **रंग**

Use [createColorEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) to change the fill from blue to orange. [getFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/coloreffect/#getFrom) and [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/coloreffect/#getTo) are colors; [getBy](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/coloreffect/#getBy) is a color offset. [Behavior.getProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behavior/#getProperties) identifies the attribute being animated.

The shape's solid fill is initialized to blue, matching the animation's starting color. Selecting the fill-color attribute tells the behavior which part of the shape to change; the color endpoints alone do not identify that attribute. The saved effect describes a two-second transition to orange.

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

### **फ़िल्टर**

Use [createFilterEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) to select a wipe. [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filtereffect/#getSubtype), and [getReveal](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filtereffect/#getReveal) specify the filter, direction, and whether to reveal or hide the shape.

This example configures a two-second wipe that reveals the shape using the right-direction subtype. The filter settings belong to the behavior inside the effect, so they are configured after the preset's original operations have been removed.

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

### **गुण**

Use [createPropertyEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) to animate opacity. [getFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/propertyeffect/#getTo), and [getBy](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/propertyeffect/#getBy) are strings interpreted using [getValueType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/propertyeffect/#getValueType) and [getCalcMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Choose endpoints or a relative offset rather than setting all three indiscriminately.

Here, the selected attribute is opacity, and the numeric strings represent a change from 25% opacity to full opacity. Linear interpolation describes a gradual change between those values. When adapting this example to another attribute, choose a value type and endpoint values appropriate to that attribute.

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

### **सेट**

Use [createSetEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) to assign visibility through [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/seteffect/#getTo). A set behavior does not interpolate between endpoints.

The example selects the visibility attribute and assigns the string `visible` when the behavior runs. The rectangle is already visible in this minimal presentation, so the assignment may not produce an obvious visual change on its own. Such an operation is useful as part of a larger effect that also controls when the shape becomes hidden or visible.

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

### **कमांड**

Use [createCommandEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) and configure [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commandeffect/#getCommandString), and [getShapeTarget](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Place a WAV recording named `sample.wav` in the working directory. This example embeds it with [addAudioFrameEmbedded](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) and attaches a play command to the audio frame.

The audio frame is both the effect's target and the command's target. This connects the play request to the embedded recording; a command string by itself does not identify which media object to control. The effect is configured to start on a click during the slideshow.

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

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **व्यहार संग्रह को प्रबंधित करें**

[BehaviorCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/) supports [add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/#remove), and [removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/#removeAt). This example opens `rotation.pptx`, adds scaling, moves it before rotation, and removes the rotation. Removing and reinserting the same object changes its stored position without making a copy.

The sequence of edits changes the collection from rotation–scale to scale–rotation, then to scale only. Indices refer to the current collection, so the removal uses the rotation's new index after reordering. The final enumeration confirms which behavior will be saved.

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

The output is `ScaleEffect`: only scaling remains. Collection order does not, by itself, schedule behaviors one after another. Clear the collection only when replacing all its operations.

## **व्यवहार का समय कॉन्फ़िगर करें**

[Behavior.getTiming](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behavior/#getTiming) exposes [Timing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/), independently of [Effect.getTiming](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getTiming). Effect timing schedules the enclosing effect; behavior timing describes an operation inside it.

### **अवधि, विलंब, पुनरावृति, और त्वरण सेट करें**

Open `rotation.pptx` and set the duration ([getDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getDuration)) and trigger delay ([getTriggerDelayTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) in seconds, then configure the repeat count through [setRepeatCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getAccelerate) and [getDecelerate](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getDecelerate) are fractions of the duration; keep their sum at most 1.

The input file is the one created in the rotation example, where the first behavior is known to be a rotation. This example changes only that behavior's timing; its 90-degree angle remains intact. Keeping the angle and timing separate makes it easier to adjust the pace without rebuilding the animation.

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

The behavior uses a two-second duration, a half-second delay, and a repeat count of 3. The first and last 20% of its duration are used for acceleration and deceleration.

Other repeat policies include [getRepeatDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide), and [getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); choose a policy rather than enabling them all together. [getAutoReverse](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/timing/#getAutoReverse) plays the animation backwards after the forward pass. Acceleration and deceleration apply to continuous changes, not discrete assignments or commands.

## **मोशन पाथ बनाएं**

Use [createMotionEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) to create motion. Its [getFrom](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#getTo), and [getBy](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#getBy) describe percentage-based coordinates or offsets. For an editable route, create a [MotionPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpath/) and assign it with [MotionEffect.setPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpath/) stores the path commands.

[MotionCommandPathType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncommandpathtype/) selects the operation:

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | One | प्रारंभिक स्थिति सेट करता है। |
| LineTo | One | सीधा खंड के साथ उसके अंत बिंदु तक जाएँ। |
| CurveTo | Three | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित घनवक्र का अनुसरण करें। |
| CloseLoop | None | प्रारम्भिक स्थिति पर लौटें। |
| End | None | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpathpointstype/) describes point-editing characteristics, such as corner or smooth points. It does not replace the command type. Use a curve point type for the curve example below, and a corner point type for the straight segments.

Path coordinates are normalized to slide dimensions: an X displacement of 0.25 represents one quarter of the slide width, not 0.25 points. Positive Y runs downward. Absolute commands specify positions in the path coordinate system; relative commands specify offsets from the current position. This is separate from [getOrigin](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#getOrigin), which selects the path's reference frame, and [getPathEditMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), which controls how the path moves when the shape is moved.

### **सीधा पाथ बनाएं**

Create a motion behavior with a starting point, one straight segment, and an end command. [MotionPath.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpath/#add) takes the command type, its points, the point type, and a relative-coordinate flag.

The starting command establishes (0, 0), and the line ends at (0.25, 0), giving the route a horizontal displacement of one quarter of the slide width. The ending command has no coordinate points. Once the path is assigned, adding the motion behavior to the effect connects that route to the rectangle.

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

`motion.pptx` contains one motion behavior with three path commands. The following file-editing examples use this known structure.

### **एब्सोल्यूट और रिलेटिव कॉर्डिनेट्स की तुलना करें**

These two path objects describe the same route. The absolute command ends at (0.3, 0.1); the relative command adds (0.1, 0.1) to the current position, (0.2, 0).

Both paths start at the same position. For the relative line, add its X and Y offsets to the current position to obtain the endpoint; for the absolute line, read the endpoint directly. Switching the flag without converting the coordinates would describe a different route.

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

Assign either path to a motion behavior to use it in a presentation. The final Boolean argument selects relative coordinates for that command.

### **लाइन को कर्व से बदलें**

Open `motion.pptx` and replace its line command with a cubic curve. Supply the two control points first, followed by the endpoint.

The starting position is supplied by the preceding command. The first two points shape the curve, while the third is its destination; they are not three successive destinations. Updating the command type, point-editing type, and point array together keeps the segment consistent with its new geometry.

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

The path in `curve.pptx` still has three commands; its middle command now defines a curve.

## **सेव्ड पाथ को निरीक्षण और संपादित करें**

Each [MotionCmdPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncmdpath/) exposes [getPoints](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncmdpath/#getPointsType), and [isRelative](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motioncmdpath/#isRelative). The following examples use the known three-command path in `motion.pptx`. For arbitrary input, locate the intended effect and check command types and point counts before editing by index.

### **कमांड्स और कॉर्डिनेट्स पढ़ें**

Read the path without changing it. End and close-loop commands need no points, so allow for a null point array.

The output pairs each numeric command type with its relative-coordinate flag before listing its points. This lets you distinguish an endpoint from an offset before modifying the path. A curve would list three points, whereas the straight line in this file lists only one.

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

The listing contains a starting point, an absolute line ending at (0.25, 0), and an end command.

### **एक अंत बिंदु बदलें**

Open `motion.pptx` and replace the line's point array to move its endpoint.

In the input file, index 0 is the starting command and index 1 is the line. Replacing the line's single point changes its destination without changing its command type, timing, or position in the collection. Because the command uses absolute coordinates, the new pair specifies a position rather than an added offset.

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

The line in `motion-endpoint.pptx` ends at (0.4, 0.1); the original file is unchanged.

### **सेगमेंट बदलें**

Use [insert](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpath/#insert) and [removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/motionpath/#removeAt) to replace the line in `motion.pptx`. Inserting shifts the old line to index 2.

This demonstrates replacing a command object rather than editing its existing coordinates. After insertion, the collection temporarily contains the starting command, the new line, the old line, and the end command. Removing index 2 discards the old line and leaves the new route in place.

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

The saved path still has three commands, with the new line ending at (0.2, 0.1) and the end command last.

## **मौजूदा व्यवहार को संशोधित और सत्यापित करें**

When the behavior's index is unknown, select it by type. This example opens `rotation.pptx`, finds its [RotationEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/rotationeffect/), changes the angle, and checks the saved value after reopening.

The type check allows the loop to skip behaviors that are not rotations. The second load reads the saved file into a separate presentation object, so the comparison checks persisted data rather than the value still held in memory. This example still assumes the known effect is first in the main sequence; selecting a behavior by type does not locate the correct effect in an arbitrary presentation.

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

The output is `Rotation preserved: true`. Apply the same type-checking pattern to other behaviors. For a complete preservation check, compare the target shape, effect, behavior types and order, timing, and path commands. Use a numeric tolerance for floating-point values. For a presentation with an unknown animation layout, see [Read Shape Animations](/slides/hi/nodejs-java/shape-animation/#read-shape-animations) for traversal of main and interactive sequences.

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

The order in [BehaviorCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behaviorcollection/) is the stored order of an effect's operations. It is not a playlist in which every behavior automatically waits for the preceding one. Timing and the enclosing effect determine scheduling. Behaviors can overlap, and operations on the same property may interact through [getAdditive](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behavior/#getAdditive) and [getAccumulate](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/behavior/#getAccumulate). Do not use collection reordering alone to schedule “move, then rotate”; use explicit timing or separate effects as described in [आकार एनीमेशन](/slides/hi/nodejs-java/shape-animation/).

The effect's [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getType) and [getSubtype](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/effect/#getSubtype) describe its preset. They are not a complete description of an edited behavior tree. Choose the preset and subtype before customizing behaviors: changing the preset can rebuild the collection and discard your custom operations. For example, changing a customized Spin effect to Fade can replace its rotation behavior with set and filter behaviors. Inspect the collection again after changing a preset or subtype. Clearing preset behaviors can also remove visibility or initialization operations that the preset needs. The examples deliberately use visible shapes and replace the behaviors; they do not reconstruct every preset's implementation.

## **फ़ॉर्मैट संगतता**

A preserved behavior tree does not guarantee identical playback in every viewer or export renderer. Check the saved data and the rendered output separately.

| फ़ॉर्मैट या आउटपुट | क्या सत्यापित करें |
| --- | --- |
| PPTX | इन उदाहरणों के लिए प्राथमिक फ़ॉर्मैट के रूप में उपयोग करें। इसे पुनः खोलें ताकि संपादन योग्य व्यवहार ट्री की पुष्टि हो सके, फिर इच्छित PowerPoint संस्करण में प्लेबैक की जांच करें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। एक अलग सेव‑और‑पुनः‑खोल चक्र और प्लेबैक का परीक्षण करें; सफल PPTX आउटपुट से यह निष्कर्ष न निकालें कि सभी कस्टम संयोजन समर्थित हैं। |
| PDF, PNG, JPEG, और अन्य स्थिर स्लाइड इमेज | स्थिर स्लाइड प्रतिनिधित्व होते हैं, न कि चलने योग्य व्यवहार टाइमलाइन या गारंटीकृत अंतिम एनीमेशन फ्रेम। |
| [HTML5](/slides/hi/nodejs-java/export-to-html5/) | निर्यात विकल्पों में आकार एनीमेशन सक्षम होने पर समर्थित एनीमेशन चलाए जा सकते हैं। ब्राउज़र में कस्टम संयोजन का परीक्षण करें। |
| [Animated GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ्रेम संग्रहीत होते हैं, न कि संपादन योग्य व्यवहार या क्लिक‑ट्रिगर इंटरैक्शन। वास्तविक रेंडर की गई गति की जाँच करें। |
| [Video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) | एनीमेशन फ्रेम रेंडर करके वीडियो के रूप में एन्कोड करता है। समर्थन सीमित है रेंडरर के [supported animations and effects](/slides/hi/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड और इंटरऐक्टिव इवेंट्स संपादन योग्य टाइमलाइन नहीं बनते। |

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे इफ़ेक्ट में व्यवहार क्यों हैं जबकि मैंने कुछ नहीं जोड़ा?**  
प्रीडिफाइंड इफ़ेक्ट बनाते समय उसके अंतर्निहित ऑपरेशन्स बन सकते हैं। उन्हें विस्तार करने या व्यवहारों को बदलने का निर्णय लेने से पहले निरीक्षण करें।

**क्या व्यवहार को शुरुआत में ले जाने से वह पहले चलता है?**  
ज़रूरी नहीं। कलेक्शन क्रम समय का विकल्प नहीं है। देरी, अवधि, और समान प्रॉपर्टी पर ऑपरेशनों के बीच इंटरैक्शन की जाँच करें।

**एक End कमांड के पास बिंदु क्यों नहीं होते?**  
यह पाथ के अंत को दर्शाता है और इसके लिए कोई कॉर्डिनेट की आवश्यकता नहीं होती। फ़ाइल से पाथ पढ़ते समय null पॉइंट एरे की जाँच करें।

**क्या सफल राउंड‑ट्रिप पर्याप्त है प्लेबैक की पुष्टि के लिए?**  
नहीं। पुनः खोलना केवल आपने जिन प्रॉपर्टीज़ की जाँच की थी, उनकी रक्षा की पुष्टि करता है। दृश्य व्यवहार की पुष्टि के लिए स्लाइडशो प्लेयर या एनीमेटेड निर्यात को अलग से टेस्ट करें।