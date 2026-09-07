---
title: Convert PowerPoint Presentations to Video in Python
linktitle: PowerPoint to Video
type: docs
weight: 130
url: /python-java/convert-powerpoint-to-video/
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
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to MP4 video in Python via Java. Generate frames with Aspose.Slides and encode them with FFmpeg, including animations and transitions."
---

## **Overview**

Converting a PowerPoint or OpenDocument presentation to video lets viewers watch its content in a video player without opening a presentation application. Aspose.Slides for Python via Java renders presentation animations and transitions into image frames. A separate encoder, such as FFmpeg, combines those frames into a video file.

{{% alert color="info" title="Note" %}}

Try the online [PowerPoint to Video converter](https://products.aspose.app/slides/video) to see presentation-to-video conversion in action.

{{% /alert %}}

## **Convert PowerPoint to Video**

The conversion has two stages: generate PNG frames at a chosen frame rate, then encode the image sequence as MP4. Use the same frame rate in both stages to preserve animation timing.

Before running the example:

1. Set up [Aspose.Slides for Python via Java](/slides/python-java/installation/).
2. Download [FFmpeg](https://ffmpeg.org/download.html) and make its executable available on `PATH`. The example uses a build with the `libx264` encoder.
3. Run the following Python code in a writable directory.

The example creates a smiling shape with entrance and exit animations, renders frames at 30 FPS, and calls FFmpeg to create `output.mp4`. A fresh frame directory prevents frames from earlier runs from being included in the video.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

To convert an existing file, initialize [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) with its path and omit the shape-creation and animation-creation statements.

The FFmpeg command reads a numbered [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2), pads odd dimensions to even values, and writes H.264 video with the `yuv420p` pixel format. The `-n` option prevents overwriting an existing output file. Generated PNG files remain in the frame directory; remove them when they are no longer needed.

{{% alert color="info" title="Note" %}}

This example encodes image frames only. It does not add narration or embedded presentation audio to the output video.

{{% /alert %}}

## **Video Effects**

Animations control how slide objects appear, move, or disappear. Transitions control the change between slides. Add these effects before generating video frames.

See [PowerPoint Animation](/slides/python-java/powerpoint-animation/), [Shape Animation](/slides/python-java/shape-animation/), [Shape Effects](/slides/python-java/shape-effect/), and [Slide Transitions](/slides/python-java/slide-transition/).

### **Add a Slide Transition**

The following self-contained example creates a presentation with two slides. The second slide has a magenta background and a push transition. Save the presentation, then use it as the input to the frame-generation example above.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animate Paragraphs**

Text can appear paragraph by paragraph. This example creates three paragraphs with sequential fade entrance effects, each delayed by one second after the previous effect. Use the saved `paragraphs.pptx` file as the input to the video-conversion example.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Video Conversion Classes**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/python-java/aspose.slides/presentationanimationsgenerator/) generates animation events for the slides. Constructing it from a presentation uses the presentation's slide size for the frames. Use [setDefaultDelay](https://reference.aspose.com/slides/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) to configure the default delay in milliseconds.

[PresentationPlayer](https://reference.aspose.com/slides/python-java/aspose.slides/presentationplayer/) samples the generated animations at the frame rate supplied to its constructor. Register a Python callback through JPype with [setFrameTick](https://reference.aspose.com/slides/python-java/aspose.slides/presentationplayer/#setFrameTick), then call [run](https://reference.aspose.com/slides/python-java/aspose.slides/presentationanimationsgenerator/#run) to generate the frames. The first example uses its own zero-based counter so the filenames match FFmpeg's input sequence.

For individual animation states, register a callback with [setNewAnimation](https://reference.aspose.com/slides/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). The callback receives an animation player that can be positioned at a selected time. The following example saves the first and last frames of each generated animation with unique filenames:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Supported Animations and Effects**

The following tables summarize the rendering support described in the Java conversion article. Preview the generated frames when a presentation uses effects that are not supported.


**Entrance**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Emphasis**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Exit**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Motion Paths:**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **FAQ**

**Does Aspose.Slides create an MP4 file directly?**

No. Aspose.Slides generates presentation frames. Use a video encoder such as FFmpeg to combine them into an MP4 file.

**Why does the video play faster or slower than expected?**

Use the same FPS for frame generation and the encoder's input frame rate. A mismatch changes the playback duration of the image sequence.

**Can I convert a password-protected presentation?**

Yes. Supply the correct password when [loading the protected presentation](/slides/python-java/password-protected-presentation/), then generate frames from the loaded content.

**Does this workflow preserve presentation audio?**

The examples export image frames, so the resulting video is silent. To include audio, provide an audio track separately during video encoding.

**How can I reduce temporary disk usage?**

Use a smaller frame size or a lower FPS, and remove temporary PNG files after successful encoding. Check the resulting video quality when reducing either setting.
