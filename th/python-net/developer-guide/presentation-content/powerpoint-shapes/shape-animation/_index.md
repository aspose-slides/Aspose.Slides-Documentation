---
title: ใช้ภาพเคลื่อนไหวของรูปร่างในงานนำเสนอด้วย Python
linktitle: ภาพเคลื่อนไหวของรูปร่าง
type: docs
weight: 60
url: /th/python-net/shape-animation/
keywords:
- รูปร่าง
- ภาพเคลื่อนไหว
- เอฟเฟกต์
- รูปร่างที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- เพิ่มภาพเคลื่อนไหว
- รับภาพเคลื่อนไหว
- ดึงภาพเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- ดึงเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ใช้ภาพเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งภาพเคลื่อนไหวของรูปร่างในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET ให้โดดเด่น!"
---
## **บทนำ**

ภาพเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ, รูปภาพ, รูปร่าง, หรือ [แผนภูมิ](/slides/th/python-net/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา. 

## **ทำไมต้องใช้ภาพเคลื่อนไหวในงานนำเสนอ?**

การใช้ภาพเคลื่อนไหวคุณสามารถ 

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ฟัง
* ทำให้เนื้อหาง่ายต่อการอ่านหรือทำความเข้าใจหรือประมวลผล
* ดึงความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับภาพเคลื่อนไหวและเอฟเฟกต์ภาพเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **ภาพเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่จำเป็นสำหรับทำงานกับภาพเคลื่อนไหวภายใต้เนมสเปซ [Aspose.Slides.Animation](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/) 
* Aspose.Slides มีเอฟเฟกต์ภาพเคลื่อนไหวกว่า **150** ภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttype/). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือนกับ (หรือเทียบเท่า) กับเอฟเฟกต์ที่ใช้ใน PowerPoint.

## **ใช้ภาพเคลื่อนไหวกับ TextBox**

Aspose.Slides for Python via .NET ให้คุณใช้ภาพเคลื่อนไหวกับข้อความในรูปร่าง. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/). 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/iautoshape/). 
4. เพิ่มข้อความไปยัง `IAutoShape.TextFrame`. 
5. รับลำดับหลักของเอฟเฟกต์. 
6. เพิ่มเอฟเฟกต์ภาพเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/iautoshape/). 
7. ตั้งค่าคุณสมบัติ `TextAnimation.BuildType` ให้เป็นค่าจาก enumeration `BuildType`. 
8. บันทึกการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX. 

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าการเคลื่อนไหวของข้อความเป็นค่า *By 1st Level Paragraphs* :

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # เพิ่ม AutoShape ใหม่พร้อมข้อความ
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # รับลำดับหลักของสไลด์.
    sequence = sld.timeline.main_sequence

    # เพิ่มเอฟเฟกต์ภาพเคลื่อนไหว Fade ให้กับรูปร่าง
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # ทำให้ข้อความของรูปร่างเคลื่อนไหวตามย่อหน้าอันดับแรก
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

นอกจากนี้ยังสามารถใช้ภาพเคลื่อนไหวกับ [Paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides/iparagraph/) เดียวได้ ดูที่ [**Animated Text**](/slides/th/python-net/animated-text/).

{{% /alert %}} 

## **ใช้ภาพเคลื่อนไหวกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/). 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) บนสไลด์. 
4. รับลำดับหลักของเอฟเฟกต์. 
5. เพิ่มเอฟเฟกต์ภาพเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/). 
6. บันทึกการนำเสนอเป็นไฟล์ PPTX. 

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์ `Fly` กับ picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ.
with slides.Presentation() as pres:
    # โหลดรูปภาพเพื่อเพิ่มในคอลเลกชันรูปภาพของการนำเสนอ
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # เพิ่ม picture frame ไปยังสไลด์
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # รับลำดับหลักของสไลด์.
    sequence = pres.slides[0].timeline.main_sequence

    # เพิ่มเอฟเฟกต์ภาพเคลื่อนไหว Fly จากด้านซ้ายให้กับ picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้ภาพเคลื่อนไหวกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/). 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/iautoshape/). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/iautoshape/) (เมื่อคลิกอ็อบเจกต์นี้ ภาพเคลื่อนไหวก็จะเล่น). 
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel. 
6. สร้าง `UserPath` แบบกำหนดเอง. 
7. เพิ่มคำสั่งเพื่อเคลื่อนที่ไปยัง `UserPath`. 
8. บันทึกการนำเสนอเป็นไฟล์ PPTX. 

โค้ด Python นี้แสดงวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับ shape:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # สร้างเอฟเฟกต์ PathFootball สำหรับรูปร่างที่มีอยู่จากศูนย์.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # เพิ่มเอฟเฟกต์ภาพเคลื่อนไหว PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # สร้างบางประเภทของ "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # สร้างลำดับของเอฟเฟกต์สำหรับปุ่ม.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # สร้าง user path แบบกำหนดเอง วัตถุของเราจะเคลื่อนที่หลังจากคลิกปุ่มเท่านั้น.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # เพิ่มคำสั่งการเคลื่อนที่เนื่องจาก path ที่สร้างว่างเปล่า.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **รับเอฟเฟ็กต์ภาพเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `get_effects_by_shape` จากคลาส [Sequence](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/) เพื่อรับเอฟเฟ็กต์ภาพเคลื่อนไหวทั้งหมดที่ใช้กับรูปร่าง.

**ตัวอย่างที่ 1: รับเอฟเฟ็กต์ภาพเคลื่อนไหวที่ใช้กับรูปร่างบนสไลด์ปกติ**

ก่อนหน้านี้คุณได้เรียนรู้วิธีการเพิ่มเอฟเฟ็กต์ภาพเคลื่อนไหวให้กับรูปร่างในงานนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับเอฟเฟ็กต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติแรกในงานนำเสนอ `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # รับลำดับภาพเคลื่อนไหวหลักของสไลด์.
    sequence = first_slide.timeline.main_sequence

    # รับรูปร่างแรกบนสไลด์แรก.
    shape = first_slide.shapes[0]

    # รับเอฟเฟกต์ภาพเคลื่อนไหวที่ใช้กับรูปร่าง.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**ตัวอย่างที่ 2: รับเอฟเฟ็กต์ภาพเคลื่อนไหวทั้งหมด รวมถึงที่สืบทอดจาก placeholder**

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บน layout slide หรือ master slide และมีการเพิ่มเอฟเฟ็กต์ภาพเคลื่อนไหวให้กับ placeholder เหล่านั้น เมื่อทำการแสดงสไลด์ เอฟเฟ็กต์ทั้งหมดของรูปร่างจะเล่นรวมถึงที่สืบทอดจาก placeholder

สมมติว่าเรามีไฟล์การนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งที่มีเพียงรูปร่างส่วนท้ายที่มีข้อความ "Made with Aspose.Slides" และมีเอฟเฟ็กต์ **Random Bars** ถูกใช้กับรูปร่างนั้น.

![Slide shape animation effect](slide-shape-animation.png)

ให้ถือว่ามีเอฟเฟ็กต์ **Split** ถูกใช้กับ placeholder ของส่วนท้ายบน **layout** slide.

![Layout shape animation effect](layout-shape-animation.png)

และสุดท้ายมีเอฟเฟ็กต์ **Fly In** ถูกใช้กับ placeholder ของส่วนท้ายบน **master** slide.

![Master shape animation effect](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้เมธอด `get_base_placeholder` จากคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) เพื่อเข้าถึง placeholder ของรูปร่างและรับเอฟเฟ็กต์ภาพเคลื่อนไหวที่ใช้กับรูปร่างส่วนท้าย รวมถึงที่สืบทอดจาก placeholder ที่อยู่บน layout และ master slide.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # รับเอฟเฟกต์ภาพเคลื่อนไหวของรูปร่างบนสไลด์ปกติ.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # รับเอฟเฟกต์ภาพเคลื่อนไหวของ placeholder บนสไลด์ layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # รับเอฟเฟกต์ภาพเคลื่อนไหวของ placeholder บนสไลด์ master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **เปลี่ยนคุณสมบัติ Timing ของเอฟเฟ็กต์ภาพเคลื่อนไหว**

Aspose.Slides for Python via .NET ให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟ็กต์ภาพเคลื่อนไหว.

นี่คือแผง Animation Timing ใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

นี่คือความสัมพันธ์ระหว่าง PowerPoint Timing และคุณสมบัติ `Effect.Timing`:

- ตัวเลือกดรอปดาวน์ **Start** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effecttriggertype/). 
- ตัวเลือกดรอปดาวน์ **Duration** ของ PowerPoint ตรงกับคุณสมบัติ `Effect.Timing.Duration`. ระยะเวลาของภาพเคลื่อนไหว (เป็นวินาที) คือเวลารวมที่ภาพเคลื่อนไหวใช้ในการทำรอบหนึ่ง. 
- ตัวเลือกดรอปดาวน์ **Delay** ของ PowerPoint ตรงกับคุณสมบัติ `Effect.Timing.TriggerDelayTime`. 

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Timing:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟ็กต์ภาพเคลื่อนไหว. 
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติ `Effect.Timing` ที่ต้องการ. 
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # รับลำดับหลักของสไลด์.
    sequence = pres.slides[0].timeline.main_sequence

    # รับเอฟเฟกต์แรกของลำดับหลัก.
    effect = sequence[0]

    # เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # เปลี่ยน Duration ของเอฟเฟกต์
    effect.timing.duration = 3

    # เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    effect.timing.trigger_delay_time = 0.5

    # บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **เสียงของเอฟเฟ็กต์ภาพเคลื่อนไหว**

Aspose.Slides ให้คุณสมบัติเหล่านี้เพื่อทำงานกับเสียงในเอฟเฟ็กต์ภาพเคลื่อนไหว: 

- `sound`
- `stop_previous_sound`

### **เพิ่มเสียงให้กับเอฟเฟ็กต์ภาพเคลื่อนไหว**

โค้ด Python นี้แสดงวิธีการเพิ่มเสียงให้กับเอฟเฟ็กต์ภาพเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟ็กต์ถัดไปเริ่มทำงาน:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # เพิ่มเสียงไปยังคอลเลกชันเสียงของการนำเสนอ
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # รับลำดับหลักของสไลด์.
    sequence = first_slide.timeline.main_sequence

    # รับเอฟเฟกต์แรกของลำดับหลัก
    first_effect = sequence[0]

    # ตรวจสอบว่าเอฟเฟกต์ไม่มีเสียง
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # เพิ่มเสียงให้กับเอฟเฟกต์แรก
        first_effect.sound = effect_sound

    # รับลำดับเชิงโต้ตอบแรกของสไลด์.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # ตั้งค่าสถานะ "Stop previous sound" ของเอฟเฟกต์
    interactive_sequence[0].stop_previous_sound = True

    # เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **ดึงเสียงของเอฟเฟ็กต์ภาพเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/). 
2. รับอ้างอิงของสไลด์ผ่านดัชนี. 
3. รับลำดับหลักของเอฟเฟ็กต์. 
4. ดึง `sound` ที่ฝังอยู่ในแต่ละเอฟเฟ็กต์ภาพเคลื่อนไหว. 

โค้ด Python นี้แสดงวิธีการดึงเสียงที่ฝังอยู่ในเอฟเฟ็กต์ภาพเคลื่อนไหว:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # รับลำดับหลักของสไลด์.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # ดึงเสียงของเอฟเฟกต์เป็นอาร์เรย์ไบต์
        audio = effect.sound.binary_data
```

## **หลังการเคลื่อนไหว**

Aspose.Slides for .NET ให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟ็กต์ภาพเคลื่อนไหว.

นี่คือแผง Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

ตัวเลือกดรอปดาวน์ **After animation** ของ PowerPoint ตรงกับคุณสมบัติดังนี้: 

- คุณสมบัติ `after_animation_type` ที่อธิบายประเภทของ After animation :
  * **More Colors** ของ PowerPoint ตรงกับประเภท [COLOR](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** ของ PowerPoint ตรงกับประเภท [DO_NOT_DIM](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/afteranimationtype/) (ประเภท After animation เริ่มต้น);
  * **Hide After Animation** ของ PowerPoint ตรงกับประเภท [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** ของ PowerPoint ตรงกับประเภท [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/afteranimationtype/);
- คุณสมบัติ `after_animation_color` ที่กำหนดรูปแบบสีของ After animation. คุณสมบัตินี้ทำงานร่วมกับประเภท [COLOR](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/afteranimationtype/). หากเปลี่ยนประเภทเป็นค่าอื่น สีของ After animation จะถูกล้าง.

โค้ด Python นี้แสดงวิธีการเปลี่ยนเอฟเฟ็กต์ After animation:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # รับเอฟเฟกต์แรกของลำดับหลัก
    first_effect = first_slide.timeline.main_sequence[0]

    # เปลี่ยนประเภท After animation เป็น Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # ตั้งค่าสีของ After animation dim
    first_effect.after_animation_color.color = Color.alice_blue

    # เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **เคลื่อนไหวข้อความ**

Aspose.Slides ให้คุณสมบัติเหล่านี้เพื่อทำงานกับบล็อก *Animate text* ของเอฟเฟ็กต์ภาพเคลื่อนไหว:

- `animate_text_type` ที่อธิบายประเภทการเคลื่อนไหวข้อความของเอฟเฟ็กต์. ข้อความในรูปร่างสามารถเคลื่อนไหวได้:
  - ทั้งหมดพร้อมกัน ([ALL_AT_ONCE](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/animatetexttype/) type)
  - ตามคำ ([BY_WORD](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/animatetexttype/) type)
  - ตามตัวอักษร ([BY_LETTER](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/animatetexttype/) type)
- `delay_between_text_parts` ตั้งค่าการหน่วงเวลาระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าเป็นบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟ็กต์, ค่าเป็นลบระบุหน่วงเวลาเป็นวินาที.

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Animate text:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟ็กต์ภาพเคลื่อนไหว. 
2. ตั้งค่าคุณสมบัติ `build_type` เป็นค่า [AS_ONE_OBJECT](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/buildtype/) เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*. 
3. ตั้งค่าที่ใหม่สำหรับคุณสมบัติ `animate_text_type` และ `delay_between_text_parts`. 
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # รับเอฟเฟกต์แรกของลำดับหลัก
    first_effect = first_slide.timeline.main_sequence[0]

    # เปลี่ยนประเภทการเคลื่อนไหวของข้อความของเอฟเฟกต์เป็น "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์เป็น "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # ตั้งค่าการหน่วงระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
    first_effect.delay_between_text_parts = 20

    # เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **คำถามที่พบบ่อย**

**ทำอย่างไรจึงจะทำให้ภาพเคลื่อนไหวคงอยู่เมื่อนำเสนอไปยังเว็บ?**

[Export to HTML5](/slides/th/python-net/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/) ที่รับผิดชอบการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/animate_shapes/) และ [transition](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/html5options/animate_transitions/). HTML ธรรมดาไม่เล่นภาพเคลื่อนไหวของสไลด์, แต่ HTML5 ทำได้.

**การเปลี่ยนลำดับชั้น (z-order) ของรูปร่างส่งผลต่อการเคลื่อนไหวอย่างไร?**

ลำดับการเคลื่อนไหวและลำดับการวาดเป็นเรื่องอิสระ: เอฟเฟกต์จะควบคุมเวลาและประเภทของการปรากฏ/หายไป, ส่วน [z-order](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/z_order_position/) จะกำหนดว่าอะไรบังอะไร ผลลัพธ์ที่มองเห็นได้ถูกกำหนดโดยการผสมผสานของทั้งสอง (นี่คือพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟ็กต์และรูปร่างของ Aspose.Slides ทำตามตรรกะเดียวกัน).

**มีข้อจำกัดใดบ้างเมื่อแปลงภาพเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟ็กต์บางอย่าง?**

โดยทั่วไป [animations are supported](/slides/th/python-net/convert-powerpoint-to-video/), แต่ในบางกรณีหรือเอฟเฟ็กต์ที่เฉพาะเจาะจงอาจถูกเรนเดอร์ต่างกัน แนะนำให้ทดสอบกับเอฟเฟ็กต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.