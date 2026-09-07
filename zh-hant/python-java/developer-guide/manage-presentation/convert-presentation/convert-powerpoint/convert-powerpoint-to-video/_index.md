---
title: 在 Python 中將 PowerPoint 簡報轉換為影片
linktitle: PowerPoint 轉影片
type: docs
weight: 130
url: /zh-hant/python-java/convert-powerpoint-to-video/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉影片
- 簡報轉影片
- PPT 轉影片
- PPTX 轉影片
- PowerPoint 轉 MP4
- 簡報轉 MP4
- PPT 轉 MP4
- PPTX 轉 MP4
- 將 PPT 儲存為 MP4
- 將 PPTX 儲存為 MP4
- 匯出 PPT 為 MP4
- 匯出 PPTX 為 MP4
- 影片轉換
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "在 Python（透過 Java）中將 PowerPoint 簡報轉換為 MP4 影片。使用 Aspose.Slides 產生影格，並以 FFmpeg 進行編碼，包含動畫與轉場效果。"
---
## **概觀**

將 PowerPoint 或 OpenDocument 簡報轉換為影片，讓觀眾可在影片播放器中觀看內容，而無需開啟簡報應用程式。Aspose.Slides for Python via Java 會將簡報的動畫與轉場渲染成影像幀。接著使用如 FFmpeg 等獨立編碼器，將這些幀合併為影片檔案。

{{% alert color="info" title="Note" %}}
試用線上的 [PowerPoint to Video converter](https://products.aspose.app/slides/zh-hant/video) 以了解簡報轉影片的實作。
{{% /alert %}}

## **將 PowerPoint 轉換為影片**

轉換分為兩個階段：先以選定的影格速率產生 PNG 影格，然後將影像序列編碼為 MP4。兩個階段皆使用相同的影格速率，以保留動畫時序。

執行範例之前：

1. 設定 [Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/)。
2. 下載 [FFmpeg](https://ffmpeg.org/download.html) 並確保其執行檔已加入 `PATH`。此範例使用內建 `libx264` 編碼器的版本。
3. 在可寫入的目錄中執行以下 Python 程式碼。

此範例會建立一個帶有進入與退出動畫的笑臉形狀，於 30 FPS 產生影格，並呼叫 FFmpeg 產生 `output.mp4`。使用全新的影格目錄可避免將先前執行產生的影格納入影片。

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

若要轉換現有檔案，請以其路徑建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)，並省略建立形狀與動畫的程式碼。

FFmpeg 指令會讀取編號的[影像序列](https://ffmpeg.org/ffmpeg-formats.html#image2)，將奇數尺寸填充為偶數，並以 `yuv420p` 色彩格式寫入 H.264 影片。`-n` 參數可防止覆寫已存在的輸出檔。產生的 PNG 檔案會保留在影格目錄中；完成編碼後請自行移除。

{{% alert color="info" title="Note" %}}
此範例僅編碼影像幀。它不會在輸出影片中加入旁白或內嵌的簡報音訊。
{{% /alert %}}

## **影片效果**

動畫控制投影片物件的出現、移動或消失方式。轉場則控制投影片之間的切換。請在產生影片影格之前加入這些效果。

請參閱 [PowerPoint Animation](/slides/zh-hant/python-java/powerpoint-animation/)、[Shape Animation](/slides/zh-hant/python-java/shape-animation/)、[Shape Effects](/slides/zh-hant/python-java/shape-effect/) 和 [Slide Transitions](/slides/zh-hant/python-java/slide-transition/)。

### **新增投影片轉場**

以下獨立範例會建立一個包含兩張投影片的簡報。第二張投影片使用洋紅色背景與推入轉場。先儲存簡報，然後將其作為上述影格產生範例的輸入。

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

### **動畫段落**

文字可以逐段落顯示。此範例建立三個段落，分別套用連續的淡入進場效果，且每個效果在前一個結束後延遲一秒。將已儲存的 `paragraphs.pptx` 檔案作為影片轉換範例的輸入。

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

## **影片轉換類別**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationanimationsgenerator/) 會為投影片產生動畫事件。從簡報建立它時，會使用簡報的投影片尺寸作為影格大小。使用 [setDefaultDelay](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) 可設定預設的毫秒延遲。

[PresentationPlayer](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationplayer/) 會以建構子提供的影格速率取樣產生的動畫。透過 JPype 使用 [setFrameTick](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationplayer/#setFrameTick) 註冊 Python 回呼，然後呼叫 [run](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationanimationsgenerator/#run) 產生影格。第一個範例使用自己的零基計數器，使檔名符合 FFmpeg 的輸入序列。

若需個別動畫狀態，可使用 [setNewAnimation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) 註冊回呼。回呼會收到可定位於特定時間的動畫播放器。以下範例會以唯一的檔名儲存每個產生動畫的第一與最後影格：

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

## **支援的動畫與效果**

下表彙總了 Java 轉換文章中描述的渲染支援情況。當簡報使用未受支援的效果時，請先預覽產生的影格。

**進入**:

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

**強調**:

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

**退出**:

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

**移動路徑**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **常見問題**

**Aspose.Slides 會直接產生 MP4 檔案嗎？**

不會。Aspose.Slides 只產生簡報的影格，必須使用如 FFmpeg 之類的影片編碼器將它們合併為 MP4 檔案。

**為何影片播放速度比預期快或慢？**

請在影格產生與編碼器的輸入影格速率使用相同的 FPS。速率不一致會改變影像序列的播放時長。

**我可以轉換受密碼保護的簡報嗎？**

可以。於[載入受保護的簡報](/slides/zh-hant/python-java/password-protected-presentation/) 時提供正確的密碼，然後即可從已載入的內容產生影格。

**此工作流程會保留簡報的音訊嗎？**

範例僅匯出影像幀，產生的影片是無聲的。若需加入音訊，請在影片編碼時另行提供音軌。

**如何減少暫存磁碟使用量？**

使用較小的影格尺寸或較低的 FPS，並在成功編碼後移除暫存的 PNG 檔案。調整任一設定時，請檢查產生影片的品質。