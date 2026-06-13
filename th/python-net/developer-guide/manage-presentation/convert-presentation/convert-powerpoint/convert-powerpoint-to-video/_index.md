---
title: แปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Python
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint เป็นวิดีโอ
- แปลง PowerPoint เป็นวิดีโอ
- การนำเสนอเป็นวิดีโอ
- แปลงการนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- แปลง PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- แปลง PPTX เป็นวิดีโอ
- ODP เป็นวิดีโอ
- แปลง ODP เป็นวิดีโอ
- PowerPoint เป็น MP4
- แปลง PowerPoint เป็น MP4
- การนำเสนอเป็น MP4
- แปลงการนำเสนอเป็น MP4
- PPT เป็น MP4
- แปลง PPT เป็น MP4
- PPTX เป็น MP4
- แปลง PPTX เป็น MP4
- การแปลง PowerPoint เป็นวิดีโอ
- การแปลงการนำเสนอเป็นวิดีโอ
- การแปลง PPT เป็นวิดีโอ
- การแปลง PPTX เป็นวิดีโอ
- การแปลง ODP เป็นวิดีโอ
- การแปลงวิดีโอด้วย Python
- PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint และ OpenDocument เป็นวิดีโอด้วย Python ค้นหาโค้ดตัวอย่างและเทคนิคการทำงานอัตโนมัติเพื่อปรับปรุงกระบวนการทำงานของคุณ"
---
## **บทนำ**

โดยการแปลงไฟล์นำเสนอ PowerPoint หรือ OpenDocument ของคุณเป็นวิดีโอ คุณจะได้รับ:

**การเข้าถึงที่เพิ่มขึ้น:** ทุกอุปกรณ์ไม่ว่าจะเป็นแพลตฟอร์มใดก็ตาม มาพร้อมกับตัวเล่นวิดีโอโดยค่าเริ่มต้น ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอได้ง่ายกว่าการใช้แอปพลิเคชันนำเสนอแบบดั้งเดิม

**การเข้าถึงที่กว้างขึ้น:** วิดีโอช่วยให้คุณเข้าถึงผู้ชมจำนวนมากขึ้นและนำเสนอข้อมูลในรูปแบบที่น่าสนใจมากขึ้น งานสำรวจและสถิติบ่งชี้ว่าผู้คนชอบดูและบริโภคเนื้อหาวิดีโอมากกว่ารูปแบบอื่น ๆ ทำให้ข้อความของคุณมีผลกระทบมากขึ้น

{{% alert color="primary" %}} 
ตรวจสอบ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/video) ของเรา เพราะมันให้การดำเนินการแบบเรียลไทม์และมีประสิทธิภาพตามที่อธิบายไว้ที่นี่
{{% /alert %}} 

ใน [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/th/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) เราได้เพิ่มการสนับสนุนการแปลงการนำเสนอเป็นวิดีโอ

* ใช้ Aspose.Slides for Python เพื่อสร้างเฟรมจากสไลด์นำเสนอที่อัตราเฟรมที่กำหนด (FPS)
* จากนั้นใช้เครื่องมือของบุคคลที่สามอย่าง ffmpeg เพื่อนำเฟรมเหล่านี้ประกอบเป็นวิดีโอ

## **แปลงการนำเสนอ PowerPoint เป็นวิดีโอ**

1. ใช้คำสั่ง pip install เพื่อนำ Aspose.Slides for Python เข้ามาในโปรเจกต์ของคุณ: `pip install aspose-slides==24.4.0`
2. ดาวน์โหลด ffmpeg จาก [here](https://ffmpeg.org/download.html) หรือทำการติดตั้งผ่านตัวจัดการแพ็กเกจ
3. ตรวจสอบให้แน่ใจว่า ffmpeg อยู่ใน `PATH` มิฉะนั้น ให้เรียกใช้ ffmpeg ด้วยพาธเต็มของไฟล์ไบนารี (เช่น `C:\ffmpeg\ffmpeg.exe` บน Windows หรือ `/opt/ffmpeg/ffmpeg` บน Linux)
4. รันโค้ดการแปลง PowerPoint เป็นวิดีโอ

โค้ด Python ด้านล่างนี้แสดงวิธีแปลงการนำเสนอ (ซึ่งมีรูปทรงและสองเอฟเฟกต์แอนิเมชัน) เป็นวิดีโอ:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **เอฟเฟกต์วิดีโอ**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Aspose.Slides for Python คุณสามารถใช้เอฟเฟกต์วิดีโอต่าง ๆ เพื่อปรับปรุงคุณภาพภาพของผลลัพธ์ เอฟเฟกต์เหล่านี้ช่วยให้คุณควบคุมการแสดงผลของสไลด์ในวิดีโอขั้นสุดท้ายโดยการเพิ่มการเปลี่ยนฉากแบบราบรื่น, แอนิเมชันและองค์ประกอบภาพอื่น ๆ ส่วนนี้อธิบายตัวเลือกเอฟเฟกต์วิดีโอที่มีและวิธีการนำไปใช้

{{% alert color="primary" %}} 
ดูที่ [PowerPoint Animation](https://docs.aspose.com/slides/th/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/th/python-net/shape-animation/) และ [Shape Effect](https://docs.aspose.com/slides/th/python-net/shape-effect/)
{{% /alert %}} 

แอนิเมชันและการเปลี่ยนฉากทำให้สไลด์โชว์น่าสนใจและดึงดูด—และก็ทำเช่นเดียวกันกับวิดีโอ เรามาเพิ่มสไลด์และการเปลี่ยนฉากอีกอันในโค้ดของการนำเสนอก่อนหน้า:

```python
import aspose.pydrawing as drawing

# เพิ่มรูปหัวเราะและทำให้เคลื่อนไหว.
# ...

# เพิ่มสไลด์ใหม่พร้อมการเปลี่ยนภาพเคลื่อนไหว.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python ยังรองรับแอนิเมชันข้อความ ในตัวอย่างนี้ เราจะทำแอนิเมชันย่อหน้าบนวัตถุให้ออกมาตามลำดับ โดยมีการหน่วงเวลา 1 วินาทีระหว่างแต่ละย่อหน้า:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มข้อความและแอนิเมชัน.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # แปลงเฟรมเป็นวิดีโอ.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **คลาสการแปลงวิดีโอ**

เพื่อเปิดใช้งานงานแปลง PowerPoint เป็นวิดีโอ Aspose.Slides for Python มี [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/presentationenumerableframesgenerator/)

`PresentationEnumerableFramesGenerator` ให้คุณกำหนดขนาดเฟรมสำหรับวิดีโอ (ซึ่งจะถูกสร้างในภายหลัง) และค่าตรง FPS (เฟรมต่อวินาที) ผ่านคอนสตรัคเตอร์ หากคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` ของมันจะถูกใช้

เพื่อให้แอนิเมชันทั้งหมดในการนำเสนอเล่นพร้อมกัน ใช้วิธี `PresentationEnumerableFramesGenerator.enumerate_frames` วิธีนี้รับคอลเลกชันของสไลด์และส่งกลับ [EnumerableFrameArgs](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/enumerableframeargs/) อย่างต่อเนื่อง จากนั้นใช้ `EnumerableFrameArgs.get_frame()` เพื่อรับแต่ละเฟรมของวิดีโอ

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

จากนั้นเฟรมที่สร้างขึ้นสามารถนำมาประกอบเป็นวิดีโอ สำหรับรายละเอียดเพิ่มเติมดูส่วน [Convert PowerPoint to Video](https://docs.aspose.com/slides/th/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video)

## **แอนิเมชันและเอฟเฟกต์ที่รองรับ**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Aspose.Slides for Python สิ่งสำคัญคือการเข้าใจว่าแอนิเมชันและเอฟเฟกต์ใดบ้างที่ได้รับการสนับสนุนในผลลัพธ์ Aspose.Slides รองรับเอฟเฟกต์การเข้ามา, การออกและการเน้นทั่วไปหลายประเภท เช่น เฟด, แฟลกอิน, ซูม และสปิน อย่างไรก็ตาม แอนิเมชันขั้นสูงหรือแบบกำหนดเองบางอย่างอาจไม่สามารถเก็บไว้ได้อย่างสมบูรณ์หรืออาจแสดงผลแตกต่างกันในวิดีโอขั้นสุดท้าย ส่วนนี้สรุปแอนิเมชันและเอฟเฟกต์ที่รองรับ

**การเข้ามา (Entrance):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**การเน้น (Emphasis):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**การออก (Exit):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**เส้นทางการเคลื่อนที่ (Motion Paths):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **เอฟเฟกต์การเปลี่ยนสไลด์ที่รองรับ**

เอฟเฟกต์การเปลี่ยนสไลด์มีบทบาทสำคัญในการสร้างการเปลี่ยนแปลงที่ราบรื่นและสวยงามระหว่างสไลด์ในวิดีโอ Aspose.Slides for Python รองรับเอฟเฟกต์การเปลี่ยนที่ใช้บ่อยหลายประเภทเพื่อช่วยรักษาการไหลและสไตล์ของการนำเสนอเดิมของคุณ ส่วนนี้เน้นเอฟเฟกต์การเปลี่ยนที่ได้รับการสนับสนุนในกระบวนการแปลง

**แบบละเอียด (Subtle):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**แบบน่าตื่นเต้น (Exciting):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
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

**เนื้อหาแบบไดนามิก (Dynamic Content):**

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย (FAQ)**

**สามารถแปลงการนำเสนอที่มีการตั้งรหัสผ่านได้หรือไม่?**

ได้, Aspose.Slides for Python รองรับการทำงานกับการนำเสนอที่มีการตั้งรหัสผ่าน เมื่อประมวลผลไฟล์แบบนี้คุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้

**Aspose.Slides for Python รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**

ได้, Aspose.Slides for Python สามารถผสานรวมกับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีถูกออกแบบให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ ทำให้มีประสิทธิภาพสูงและขยายตัวได้ดีสำหรับการประมวลผลไฟล์เป็นชุด

**มีข้อจำกัดเรื่องขนาดของการนำเสนอระหว่างการแปลงหรือไม่?**

Aspose.Slides for Python สามารถจัดการกับการนำเสนอที่มีขนาดใกล้เคียงกับทุกขนาดได้ อย่างไรก็ตาม เมื่อทำงานกับไฟล์ขนาดใหญ่มากอาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ปรับปรุงการนำเสนอเพื่อเพิ่มประสิทธิภาพการทำงาน