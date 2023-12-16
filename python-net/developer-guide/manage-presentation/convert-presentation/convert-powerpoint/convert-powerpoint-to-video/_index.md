---
title: Convert PowerPoint to Video
type: docs
weight: 130
url: /python-net/convert-powerpoint-to-video/
keywords: "Convert PowerPoint, PPT, PPTX, Presentation, Video, MP4, PPT to video, PPT to MP4, Python, Aspose.Slides"
description: "Convert PowerPoint to Video in Python"
---

By converting your PowerPoint presentation to video, you get 

* **Increase in accessibility:** All devices (regardless of platform) are equipped with video players by default compared to presentation-opening applications, so users find it easier to open or play videos.
* **More reach:** Through videos, you can reach a large audience and target them with information that might otherwise seem tedious in a presentation. Most surveys and statistics suggest that people watch and consume videos more than other forms of content, and they generally prefer such content.

{{% alert color="primary" %}} 

You may want to check our [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/conversion/ppt-to-word) because it is a live and effective implementation of the process described here.

{{% /alert %}} 

## **PowerPoint to Video Conversion in Aspose.Slides**

* Use Aspose.Slides to generate a set of frames (from the presentation slides) that correspond to a certain FPS (frames per second)
* Use a third-party utility like XXX to create a video based on the frames. 

### **Convert PowerPoint to Video**

1. XXX Use the dotnet add package command to add Aspose.Slides and the FFMpegCore library to your project:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. XXX Dowload ffmpeg [here](https://ffmpeg.org/download.html).
3. XXX FFMpegCore requires you to specify the path to the downloaded ffmpeg (e.g. extracted to "C:\tools\ffmpeg"):  `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Run the PowerPoint to video code.

This Python code shows you how to convert a presentation (containing a figure and two animation effects) to a video: xxx

```python

```

## **Video Effects**

You can apply animations to objects on slides and use transitions between slides. 

{{% alert color="primary" %}} 

You may want to see these articles: [PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

Animations and transitions make slideshows more engaging and interesting—and they do the same thing for videos. Let's add another slide and transition to the code for the previous presentation: xxx

```python

```

Aspose.Slides also supports animation for texts. So we animate paragraphs on objects, which will appear one after the other (with the delay set to a second): xxx

```python

```

## **Video Conversion Classes**

To allow you to perform PowerPoint to video conversion tasks, Aspose.Slides provides the [PresentationAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationanimationsgenerator/) and [PresentationPlayer](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationplayer/) classes.

`PresentationAnimationsGenerator` allows you to set the frame size for the video (that will be created later) through its constructor. If you pass an instance of the presentation, `Presentation.SlideSize` will be used and it generates animations that [PresentationPlayer](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationplayer/) uses. 

When animations are generated, a `NewAnimation` event is generated for each subsequent animation, which has the [IPresentationAnimationPlayer](https://reference.aspose.com/slides/python-net/aspose.slides.export/ipresentationanimationplayer/) parameter. The latter is a class that represents a player for a separate animation.

To work with [IPresentationAnimationPlayer](https://reference.aspose.com/slides/python-net/aspose.slides.export/ipresentationanimationplayer/), the `Duration` (the full duration of the animation) property and `SetTimePosition` method are used. Each animation position is set within the *0 to duration* range, and then the `GetFrame` method will return a Bitmap that corresponds to the animation state at that moment.

Xxx

```python

```

To make all animations in a presentation play at once, the [PresentationPlayer](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationplayer/) class is used. This class  takes a [PresentationAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationanimationsgenerator/) instance and FPS for effects in its constructor and then calls the `FrameTick` event for all the animations to get them played:

```python

```

Then the generated frames can be compiled to produce a video. See the [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) section.

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

## **Supported Slide Transition Effects**

**Subtle**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Exciting**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamic Content**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |
