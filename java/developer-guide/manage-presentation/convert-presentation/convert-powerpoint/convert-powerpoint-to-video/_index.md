---
title: Convert PowerPoint to Video
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Video, MP4, PPT to video, PPT to MP4, Java, Aspose.Slides"
description: "Convert PowerPoint to Video in Java"
---

By converting your PowerPoint presentation to video, you get 

* **Increase in accessibility:** All devices (regardless of platform) are equipped with video players by default compared to presentation-opening applications, so users find it easier to open or play videos.
* **More reach:** Through videos, you can reach a large audience and target them with information that might otherwise seem tedious in a presentation. Most surveys and statistics suggest that people watch and consume videos more than other forms of content, and they generally prefer such content.

{{% alert color="primary" %}} 

You may want to check our [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) because it is a live and effective implementation of the process described here.

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/), we implemented support for presentation to video conversion. 

* Use **Aspose.Slides** to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third-party utility like **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) to create a video based on the frames. 

### **Convert PowerPoint to Video**

1. Add this to your POM file:

   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>

2. Download ffmpeg [here](https://ffmpeg.org/download.html).

4. Run the PowerPoint to video Java code.

This Java code shows you how to convert a presentation (containing a figure and two animation effects) to a video:  xxx

```java




FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
FFprobe ffprobe = new FFprobe("path/to/ffprobe");

FFmpegBuilder builder = new FFmpegBuilder()
        .addExtraArgs("-start_number", "1")
        .setInput("%03d.png")
        .addOutput("output.avi")
        .setVideoFrameRate(FFmpeg.FPS_24)
        .setFormat("avi")
        .done();

FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
executor.createJob(builder).run();
```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/java/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation: xxx

```java

```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second): xxx

```java

```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) classes.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation.SlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) uses. 

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/) parameter. The latter is a class that represents a player for a separate animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/), the [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (the full duration of the animation) property and [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) method are used. Each animation position is set within the *0 to duration* range, and then the `GetFrame` method will return a Bitmap that corresponds to the animation state at that moment. xxx **bitmap**?

```java

```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played: xxx

```java

```

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

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

