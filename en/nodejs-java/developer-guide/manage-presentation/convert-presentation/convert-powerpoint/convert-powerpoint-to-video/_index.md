---
title: Convert PowerPoint Presentations to Video in JavaScript
linktitle: PowerPoint to Video
type: docs
weight: 130
url: /nodejs-java/convert-powerpoint-to-video/
keywords:
- convert PowerPoint
- convert presentation
- convert PPT
- convert PPTX
- PowerPoint to video
- presentation to video
- PPT to video
- PPTX to video
- PowerPoint to MP4
- presentation to MP4
- PPT to MP4
- PPTX to MP4
- save PPT as MP4
- save PPTX as MP4
- export PPT to MP4
- export PPTX to MP4
- video conversion
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to convert PowerPoint presentations to video in JavaScript. Discover sample code and automation techniques to streamline your workflow."
---

## **Introduction**

By converting your PowerPoint presentation to video, you get 

* **Increase in accessibility:** All devices (regardless of platform) are equipped with video players by default compared to presentation-opening applications, so users find it easier to open or play videos.
* **More reach:** Through videos, you can reach a large audience and target them with information that might otherwise seem tedious in a presentation. Most surveys and statistics suggest that people watch and consume videos more than other forms of content, and they generally prefer such content.

{{% alert color="primary" %}} 

You may want to check our [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-video) because it is a live and effective implementation of the process described here.

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

Aspose.Slides supports presentation-to-video conversion.

* Use **Aspose.Slides** to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third-party utility like **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) to create a video based on the frames. 

### **Convert PowerPoint to Video**

1. Download ffmpeg [here](https://ffmpeg.org/download.html).

2. Put the [ffmpeg-cli-wrapper](https://github.com/bramp/ffmpeg-cli-wrapper) JAR and its dependencies on the JVM classpath with `java.classpath.push(...)`. Do this **before** `aspose.slides.via.java` is required, because that call starts the JVM and the classpath is fixed from then on.

3. Run the PowerPoint to video JavaScript code.

This JavaScript code shows you how to convert a presentation (containing a figure and two animation effects) to a video:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    // Adds a smile shape and then animates it
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick(java.newProxy("com.aspose.slides.PresentationPlayer$FrameTick", {
                invoke: function (sender, args) {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    args.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                }
            }));
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Point the wrapper at your ffmpeg binaries. See https://github.com/bramp/ffmpeg-cli-wrapper
    var ffmpeg = java.newInstanceSync("net.bramp.ffmpeg.FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("net.bramp.ffmpeg.FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("net.bramp.ffmpeg.builder.FFmpegBuilder")
        .addExtraArgsSync("-start_number", "0")
        .setInputSync("frame_%04d.png")
        .addOutputSync("output.avi")
        .setVideoFrameRateSync(java.getStaticFieldValue("net.bramp.ffmpeg.FFmpeg", "FPS_24"))
        .setFormatSync("avi")
        .doneSync();
    var executor = java.newInstanceSync("net.bramp.ffmpeg.FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJobSync(builder).runSync();
} catch (e) {
    console.log(e);
}
```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/nodejs-java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/nodejs-java/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();

// Adds a smile shape and animates it
// ...
// Adds a new slide and animated transition
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    // Adds text and animations
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick(java.newProxy("com.aspose.slides.PresentationPlayer$FrameTick", {
                invoke: function (sender, args) {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    args.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                }
            }));
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Point the wrapper at your ffmpeg binaries. See https://github.com/bramp/ffmpeg-cli-wrapper
    var ffmpeg = java.newInstanceSync("net.bramp.ffmpeg.FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("net.bramp.ffmpeg.FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("net.bramp.ffmpeg.builder.FFmpegBuilder")
        .addExtraArgsSync("-start_number", "0")
        .setInputSync("frame_%04d.png")
        .addOutputSync("output.avi")
        .setVideoFrameRateSync(java.getStaticFieldValue("net.bramp.ffmpeg.FFmpeg", "FPS_24"))
        .setFormatSync("avi")
        .doneSync();
    var executor = java.newInstanceSync("net.bramp.ffmpeg.FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJobSync(builder).runSync();
} catch (e) {
    console.log(e);
}
```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation.getSlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) uses.

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the presentation animation player parameter. The latter is a class that represents a player for a separate animation.

To work with the presentation animation player, the `getDuration` (the full duration of the animation) method and `setTimePosition` method are used. Each animation position is set within the *0 to duration* range, and then the `getFrame` method will return a BufferedImage that corresponds to the animation state at that moment:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    // Adds a smile shape and animates it
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(java.newProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", {
            invoke: function (animationPlayer) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", java.newDouble(animationPlayer.getDuration())));
                animationPlayer.setTimePosition(0);// initial animation state
                // initial animation state bitmap
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
                animationPlayer.setTimePosition(animationPlayer.getDuration());// final state of the animation
                // last frame of the animation
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            }
        }));
        // Generating the animations is what raises the NewAnimation event.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick(java.newProxy("com.aspose.slides.PresentationPlayer$FrameTick", {
                invoke: function (sender, args) {
                    args.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                }
            }));
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

## **Supported Animations and Effects**

**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Is it possible to convert presentations that are password protected?

Yes, Aspose.Slides allows working with password-protected presentations. When processing such files, you need to provide the correct password so that the library can access the content of the presentation.

### Does Aspose.Slides support usage in cloud solutions?

Yes, Aspose.Slides can be integrated into cloud applications and services. The library is designed to work in server environments, ensuring high performance and scalability for batch processing of files.

### Are there any size limitations for presentations during conversion?

Aspose.Slides is capable of handling presentations of virtually any size. However, when working with very large files, additional system resources may be required, and it is sometimes recommended to optimize the presentation to improve performance.
