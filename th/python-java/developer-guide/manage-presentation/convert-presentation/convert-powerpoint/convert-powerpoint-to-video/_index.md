---
title: แปลงงานนำเสนอ PowerPoint เป็นวิดีโอใน Python
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/python-java/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- งานนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- งานนำเสนอเป็น MP4
- PPT เป็น MP4
- PPTX เป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นวิดีโอ MP4 ด้วย Python ผ่าน Java สร้างเฟรมด้วย Aspose.Slides และเข้ารหัสด้วย FFmpeg รวมถึงภาพเคลื่อนไหวและการเปลี่ยนสไลด์"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint หรือ OpenDocument ให้เป็นวิดีโอทำให้ผู้ชมสามารถดูเนื้อหาในตัวเล่นวิดีโอโดยไม่ต้องเปิดโปรแกรมนำเสนอ Aspose.Slides for Python via Java แสดงภาพเคลื่อนไหวและการเปลี่ยนสไลด์เป็นเฟรมภาพ ส่วนตัวเข้ารหัสแยก เช่น FFmpeg จะรวมเฟรมเหล่านั้นเป็นไฟล์วิดีโอ

{{% alert color="info" title="Note" %}}
ลองใช้ [PowerPoint to Video converter](https://products.aspose.app/slides/th/video) ออนไลน์เพื่อดูการแปลงงานนำเสนอเป็นวิดีโอในปฏิบัติการ
{{% /alert %}}

## **แปลง PowerPoint เป็นวิดีโอ**

การแปลงมีสองขั้นตอน: สร้างเฟรม PNG ที่อัตราเฟรมที่เลือก จากนั้นเข้ารหัสลำดับภาพเป็น MP4 ใช้อัตราเฟรมเดียวกันในทั้งสองขั้นตอนเพื่อรักษาเวลาการเคลื่อนไหว

ก่อนเรียกใช้ตัวอย่าง:

1. ตั้งค่า [Aspose.Slides for Python via Java](/slides/th/python-java/installation/).
2. ดาวน์โหลด [FFmpeg](https://ffmpeg.org/download.html) และทำให้ไฟล์ปฏิบัติการของมันอยู่ใน `PATH` ตัวอย่างใช้เวอร์ชันที่มีตัวเข้ารหัส `libx264`
3. เรียกใช้โค้ด Python ด้านล่างในไดเรกทอรีที่เขียนได้

ตัวอย่างสร้างรูปทรงยิ้มพร้อมการเคลื่อนไหวเข้าและออก เรนเดอร์เฟรมที่ 30 FPS และเรียก FFmpeg เพื่อสร้าง `output.mp4` โฟลเดอร์เฟรมใหม่จะทำให้เฟรมจากการรันก่อนหน้าไม่ถูกรวมในวิดีโอ

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

เพื่อแปลงไฟล์ที่มีอยู่แล้ว ให้เริ่มต้น [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ด้วยเส้นทางของไฟล์และละเว้นคำสั่งสร้างรูปทรงและการสร้างการเคลื่อนไหว

คำสั่ง FFmpeg จะอ่าน [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) ที่มีหมายเลข, เติมค่ามิติที่เป็นคี่ให้เป็นเลขคู่, และเขียนวิดีโอ H.264 ด้วยรูปแบบพิกเซล `yuv420p` ตัวเลือก `-n` ป้องกันไม่ให้เขียนทับไฟล์ผลลัพธ์ที่มีอยู่ ไฟล์ PNG ที่สร้างขึ้นจะคงอยู่ในโฟลเดอร์เฟรม; ให้ลบเมื่อไม่ต้องการใช้ต่อ

{{% alert color="info" title="Note" %}}
ตัวอย่างนี้เข้ารหัสเฉพาะเฟรมภาพเท่านั้น ไม่ได้เพิ่มการบรรยายหรือเสียงที่ฝังอยู่ในงานนำเสนอลงในวิดีโอผลลัพธ์
{{% /alert %}}

## **เอฟเฟกต์วิดีโอ**

การเคลื่อนไหวควบคุมว่าวัตถุบนสไลด์ปรากฏ, เคลื่อนที่ หรือหายไปอย่างไร การเปลี่ยนสไลด์ควบคุมการเปลี่ยนระหว่างสไลด์ ให้เพิ่มเอฟเฟกต์เหล่านี้ก่อนสร้างเฟรมวิดีโอ

ดู [PowerPoint Animation](/slides/th/python-java/powerpoint-animation/), [Shape Animation](/slides/th/python-java/shape-animation/), [Shape Effects](/slides/th/python-java/shape-effect/), และ [Slide Transitions](/slides/th/python-java/slide-transition/)

### **เพิ่มการเปลี่ยนสไลด์**

ตัวอย่างที่เป็นอิสระต่อไปนี้สร้างงานนำเสนอที่มีสองสไลด์ สไลด์ที่สองมีพื้นหลังสีแมเจนตาและการเปลี่ยนแบบ push บันทึกงานนำเสนอแล้วใช้เป็นอินพุตให้กับตัวอย่างการสร้างเฟรมที่อธิบายข้างต้น

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

### **ทำให้ย่อหน้ามีการเคลื่อนไหว**

ข้อความสามารถปรากฏเป็นย่อหน้าทีละย่อหน้า ตัวอย่างนี้สร้างสามย่อหน้าพร้อมเอฟเฟกต์การเข้าจางลำดับต่อกัน โดยแต่ละอันล่าช้าหนึ่งวินาทีหลังจากเอฟเฟกต์ก่อนหน้า ใช้ไฟล์ `paragraphs.pptx` ที่บันทึกเป็นอินพุตให้กับตัวอย่างการแปลงวิดีโอ

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

## **คลาสการแปลงวิดีโอ**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationanimationsgenerator/) สร้างเหตุการณ์การเคลื่อนไหวสำหรับสไลด์ การสร้างจากงานนำเสนอจะใช้ขนาดสไลด์ของงานนำเสนอเป็นขนาดเฟรม ใช้ [setDefaultDelay](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) เพื่อตั้งค่าการหน่วงเวลาตั้งต้นเป็นมิลลิวินาที

[PresentationPlayer](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationplayer/) ทำการสุ่มตัวอย่างการเคลื่อนไหวที่สร้างขึ้นที่อัตราเฟรมที่กำหนดให้กับคอนสตรัคเตอร์ของมัน ลงทะเบียนคอลแบ็ก Python ผ่าน JPype ด้วย [setFrameTick](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationplayer/#setFrameTick) จากนั้นเรียก [run](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationanimationsgenerator/#run) เพื่อสร้างเฟรม ตัวอย่างแรกใช้เคาน์เตอร์เริ่มจากศูนย์ของตนเองเพื่อให้ชื่อไฟล์ตรงกับลำดับอินพุตของ FFmpeg

สำหรับสถานะการเคลื่อนไหวแบบแยกแต่ละอัน ลงทะเบียนคอลแบ็กด้วย [setNewAnimation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) คอลแบ็กจะได้รับ animation player ที่สามารถตั้งตำแหน่งในเวลาเลือกได้ ตัวอย่างต่อไปนี้บันทึกเฟรมแรกและสุดท้ายของการเคลื่อนไหวแต่ละอันด้วยชื่อไฟล์ที่ไม่ซ้ำกัน:

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

## **การสนับสนุนการเคลื่อนไหวและเอฟเฟกต์**

ตารางต่อไปนี้สรุปการรองรับการเรนเดอร์ที่อธิบายในบทความการแปลงของ Java ให้ดูตัวอย่างเฟรมที่สร้างเมื่อการนำเสนอใช้เอฟเฟกต์ที่ไม่รองรับ

**การเข้ามา**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ไม่ | ใช่ |
| **Fade** | ใช่ | ใช่ |
| **Fly In** | ใช่ | ใช่ |
| **Float In** | ใช่ | ใช่ |
| **Split** | ใช่ | ใช่ |
| **Wipe** | ใช่ | ใช่ |
| **Shape** | ใช่ | ใช่ |
| **Wheel** | ใช่ | ใช่ |
| **Random Bars** | ใช่ | ใช่ |
| **Grow & Turn** | ไม่ | ใช่ |
| **Zoom** | ใช่ | ใช่ |
| **Swivel** | ใช่ | ใช่ |
| **Bounce** | ใช่ | ใช่ |

**การเน้น**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ไม่ | ใช่ |
| **Color Pulse** | ไม่ | ใช่ |
| **Teeter** | ใช่ | ใช่ |
| **Spin** | ใช่ | ใช่ |
| **Grow/Shrink** | ไม่ | ใช่ |
| **Desaturate** | ไม่ | ใช่ |
| **Darken** | ไม่ | ใช่ |
| **Lighten** | ไม่ | ใช่ |
| **Transparency** | ไม่ | ใช่ |
| **Object Color** | ไม่ | ใช่ |
| **Complementary Color** | ไม่ | ใช่ |
| **Line Color** | ไม่ | ใช่ |
| **Fill Color** | ไม่ | ใช่ |

**การออก**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ไม่ | ใช่ |
| **Fade** | ใช่ | ใช่ |
| **Fly Out** | ใช่ | ใช่ |
| **Float Out** | ใช่ | ใช่ |
| **Split** | ใช่ | ใช่ |
| **Wipe** | ใช่ | ใช่ |
| **Shape** | ใช่ | ใช่ |
| **Random Bars** | ใช่ | ใช่ |
| **Shrink & Turn** | ไม่ | ใช่ |
| **Zoom** | ใช่ | ใช่ |
| **Swivel** | ใช่ | ใช่ |
| **Bounce** | ใช่ | ใช่ |

**เส้นทางการเคลื่อนที่**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ใช่ | ใช่ |
| **Arcs** | ใช่ | ใช่ |
| **Turns** | ใช่ | ใช่ |
| **Shapes** | ใช่ | ใช่ |
| **Loops** | ใช่ | ใช่ |
| **Custom Path** | ใช่ | ใช่ |

## **คำถามที่พบบ่อย**

**Aspose.Slides สร้างไฟล์ MP4 โดยตรงหรือไม่?**

ไม่. Aspose.Slides สร้างเฟรมของงานนำเสนอ ใช้ตัวเข้ารหัสวิดีโอ เช่น FFmpeg เพื่อรวมเป็นไฟล์ MP4

**ทำไมวิดีโอถึงเล่นเร็วหรือช้ากว่าที่คาดหวัง?**

ใช้ FPS เดียวกันสำหรับการสร้างเฟรมและอัตราเฟรมของอินพุตตัวเข้ารหัส ความไม่สอดคล้องจะทำให้ระยะเวลาการเล่นของลำดับภาพเปลี่ยนไป

**ฉันสามารถแปลงงานนำเสนอที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้. ให้ใส่รหัสผ่านที่ถูกต้องเมื่อ [loading the protected presentation](/slides/th/python-java/password-protected-presentation/), แล้วสร้างเฟรมจากเนื้อหาที่โหลด

**กระบวนการนี้รักษาเสียงของงานนำเสนอหรือไม่?**

ตัวอย่างส่งออกเฟรมภาพเท่านั้น ทำให้วิดีโอผลลัพธ์ไม่มีเสียง หากต้องการรวมเสียง ให้เพิ่มแทร็กเสียงแยกต่างหากในระหว่างการเข้ารหัสวิดีโอ

**ฉันจะลดการใช้พื้นที่ดิสก์ชั่วคราวได้อย่างไร?**

ใช้ขนาดเฟรมที่เล็กลงหรือ FPS ที่ต่ำลง และลบไฟล์ PNG ชั่วคราวหลังจากการเข้ารหัสสำเร็จ ตรวจสอบคุณภาพวิดีโอที่ได้เมื่อปรับลดการตั้งค่าใด ๆ