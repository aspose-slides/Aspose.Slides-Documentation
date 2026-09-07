---
title: 在 Python 中将 PowerPoint 演示文稿转换为视频
linktitle: PowerPoint 转视频
type: docs
weight: 130
url: /zh/python-java/convert-powerpoint-to-video/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转视频
- 演示文稿转视频
- PPT 转视频
- PPTX 转视频
- PowerPoint 转 MP4
- 演示文稿转 MP4
- PPT 转 MP4
- PPTX 转 MP4
- 将 PPT 保存为 MP4
- 将 PPTX 保存为 MP4
- 导出 PPT 为 MP4
- 导出 PPTX 为 MP4
- 视频转换
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "在 Python（通过 Java）中将 PowerPoint 演示文稿转换为 MP4 视频。使用 Aspose.Slides 生成帧，并使用 FFmpeg 对其进行编码，支持动画和切换效果。"
---
## **概述**

将 PowerPoint 或 OpenDocument 演示文稿转换为视频，可让观众在视频播放器中观看内容，而无需打开演示文稿应用程序。Aspose.Slides for Python via Java 将演示文稿的动画和切换渲染为图像帧。随后使用独立的编码器（如 FFmpeg）将这些帧合成为视频文件。

{{% alert color="info" title="Note" %}}
尝试在线[PowerPoint 转视频转换器](https://products.aspose.app/slides/zh/video)以查看演示文稿转视频的实际效果。
{{% /alert %}}

## **将 PowerPoint 转换为视频**

转换分为两个阶段：在选定的帧率下生成 PNG 帧，然后将图像序列编码为 MP4。两阶段使用相同的帧率可保持动画时间的准确性。

在运行示例之前：

1. 设置 [Aspose.Slides for Python via Java](/slides/zh/python-java/installation/)。
2. 下载 [FFmpeg](https://ffmpeg.org/download.html) 并将其可执行文件加入 `PATH`。示例使用带有 `libx264` 编码器的构建。
3. 在可写目录中运行以下 Python 代码。

示例创建了一个带有进入和退出动画的笑脸形状，以 30 FPS 渲染帧，并调用 FFmpeg 生成 `output.mp4`。全新的帧目录可防止将之前运行产生的帧包含在视频中。

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

要转换已有文件，使用其路径初始化 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 并省略形状创建和动画创建语句。

FFmpeg 命令读取编号的[图像序列](https://ffmpeg.org/ffmpeg-formats.html#image2)，将奇数维度填充为偶数值，并使用 `yuv420p` 像素格式写入 H.264 视频。`-n` 选项可防止覆盖已存在的输出文件。生成的 PNG 文件保留在帧目录中；不再需要时请将其删除。

{{% alert color="info" title="Note" %}}
此示例仅编码图像帧。它不向输出视频添加旁白或嵌入的演示文稿音频。
{{% /alert %}}

## **视频效果**

动画控制幻灯片对象的出现、移动或消失。切换控制幻灯片之间的变化。在生成视频帧之前添加这些效果。

请参阅 [PowerPoint Animation](/slides/zh/python-java/powerpoint-animation/)、[Shape Animation](/slides/zh/python-java/shape-animation/)、[Shape Effects](/slides/zh/python-java/shape-effect/) 和 [Slide Transitions](/slides/zh/python-java/slide-transition/)。

### **添加幻灯片切换**

以下独立示例创建了一个包含两张幻灯片的演示文稿。第二张幻灯片使用品红色背景和推入切换。保存演示文稿后，将其作为上述帧生成示例的输入。

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

### **动画段落**

文本可以逐段出现。此示例创建了三个段落，并为每个段落设置顺序淡入进入效果，每个效果在前一个效果后延迟一秒。将保存的 `paragraphs.pptx` 文件用作视频转换示例的输入。

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

## **视频转换类**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationanimationsgenerator/) 为幻灯片生成动画事件。使用演示文稿的幻灯片尺寸来构造帧。通过 [setDefaultDelay](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) 可配置默认延迟（毫秒）。

[PresentationPlayer](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationplayer/) 按构造函数提供的帧率采样生成的动画。通过 JPype 使用 [setFrameTick](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationplayer/#setFrameTick) 注册 Python 回调，然后调用 [run](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationanimationsgenerator/#run) 生成帧。第一个示例使用自身的零基计数器，以使文件名与 FFmpeg 的输入序列匹配。

如需单独的动画状态，可使用 [setNewAnimation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) 注册回调。回调接收一个可定位到选定时间的动画播放器。以下示例将每个生成动画的首帧和末帧保存为唯一文件名：

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

## **支持的动画和效果**

下表概述了 Java 转换文章中描述的渲染支持情况。当演示文稿使用不受支持的效果时，请预览生成的帧。

**进入**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **出现** | No | Yes |
| **淡入** | Yes | Yes |
| **飞入** | Yes | Yes |
| **漂入** | Yes | Yes |
| **拆分** | Yes | Yes |
| **擦除** | Yes | Yes |
| **形状** | Yes | Yes |
| **轮子** | Yes | Yes |
| **随机条形** | Yes | Yes |
| **成长并旋转** | No | Yes |
| **缩放** | Yes | Yes |
| **摆动** | Yes | Yes |
| **弹跳** | Yes | Yes |

**强调**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **脉冲** | No | Yes |
| **颜色脉冲** | No | Yes |
| **摇摆** | Yes | Yes |
| **旋转** | Yes | Yes |
| **放大/缩小** | No | Yes |
| **去饱和** | No | Yes |
| **变暗** | No | Yes |
| **变亮** | No | Yes |
| **透明度** | No | Yes |
| **对象颜色** | No | Yes |
| **互补颜色** | No | Yes |
| **线条颜色** | No | Yes |
| **填充颜色** | No | Yes |

**退出**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **消失** | No | Yes |
| **淡出** | Yes | Yes |
| **飞出** | Yes | Yes |
| **漂出** | Yes | Yes |
| **拆分** | Yes | Yes |
| **擦除** | Yes | Yes |
| **形状** | Yes | Yes |
| **随机条形** | Yes | Yes |
| **收缩并旋转** | No | Yes |
| **缩放** | Yes | Yes |
| **摆动** | Yes | Yes |
| **弹跳** | Yes | Yes |

**运动路径**:

| 动画类型 | Aspose.Slides | PowerPoint |
|---|---|---|
| **线条** | Yes | Yes |
| **弧线** | Yes | Yes |
| **转弯** | Yes | Yes |
| **形状** | Yes | Yes |
| **循环** | Yes | Yes |
| **自定义路径** | Yes | Yes |

## **常见问题**

**Aspose.Slides 能直接创建 MP4 文件吗？**

不能。Aspose.Slides 生成演示文稿帧。需要使用 FFmpeg 等视频编码器将它们合成为 MP4 文件。

**为什么视频播放速度比预期快或慢？**

确保帧生成的 FPS 与编码器输入的帧率相同。不匹配会导致图像序列的播放时长发生变化。

**能转换受密码保护的演示文稿吗？**

可以。在[加载受保护的演示文稿](/slides/zh/python-java/password-protected-presentation/)时提供正确的密码，然后从加载的内容生成帧。

**此工作流会保留演示文稿的音频吗？**

示例仅导出图像帧，生成的视频是静音的。若需包含音频，请在视频编码期间单独提供音轨。

**如何减少临时磁盘使用量？**

使用更小的帧尺寸或更低的 FPS，并在成功编码后删除临时 PNG 文件。降低任一设置时，请检查生成视频的质量。