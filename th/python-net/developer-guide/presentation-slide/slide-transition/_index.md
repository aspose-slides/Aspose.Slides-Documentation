---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย Python
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 90
url: /th/python-net/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- นำการเปลี่ยนสไลด์ไปใช้
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยนแบบ Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- Python
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET พร้อมคู่มือขั้นตอนสำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides สำหรับ Python ให้การควบคุมเต็มรูปแบบต่อการเปลี่ยนภาพสไลด์ ตั้งแต่การเลือกประเภทการเปลี่ยน ไปจนถึงการกำหนดค่าเวลาและทริกเกอร์เป็นส่วนหนึ่งของกระบวนการนำเสนออัตโนมัติ คุณสามารถตั้งค่าให้สไลด์เปลี่ยนเมื่อคลิกและ/หรือหลังจากหน่วงเวลาที่กำหนด และปรับพฤติกรรมภาพให้ละเอียดด้วยเอฟเฟกต์ เช่น การตัดจากสีดำหรือการเข้าสู่จากทิศทางต่าง ๆ ไลบรารียังสนับสนุนการเปลี่ยนแบบ Morph ที่แนะนำใน PowerPoint 2019 รวมถึงโหมดที่ Morph ตามวัตถุ คำ หรืออักขระ เพื่อสร้างการเคลื่อนที่ที่ราบรื่นและต่อเนื่องระหว่างสไลด์

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อทำให้เข้าใจง่ายขึ้น ตัวอย่างนี้สาธิตวิธีใช้ Aspose.Slides สำหรับ Python เพื่อจัดการการเปลี่ยนสไลด์อย่างง่าย ผู้พัฒนาสามารถใช้เอฟเฟกต์การเปลี่ยนสไลด์ต่าง ๆ กับสไลด์และปรับพฤติกรรมตามต้องการ เพื่อสร้างการเปลี่ยนสไลด์อย่างง่าย ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ใช้การเปลี่ยนสไลด์โดยอ้างอิงหนึ่งในเอฟเฟกต์จาก enum [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/)
1. บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # ใช้การเปลี่ยนแบบวงกลมกับสไลด์ที่ 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # ใช้การเปลี่ยนแบบคอมบกับสไลด์ที่ 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

ในส่วนนี้ เราได้ใช้เอฟเฟกต์การเปลี่ยนแบบง่ายบนสไลด์ เพื่อทำให้เอฟเฟกต์นั้นมีการควบคุมและมีความประณีตมากขึ้น ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ใช้การเปลี่ยนสไลด์โดยอ้างอิงหนึ่งในเอฟเฟกต์จาก enum [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/)
1. กำหนดการเปลี่ยนให้เลื่อนไปเมื่อคลิก (Advance On Click) หลังจากช่วงเวลาที่กำหนด หรือทั้งสองอย่าง
1. บันทึกไฟล์งานนำเสนอที่แก้ไขแล้ว

หาก **Advance On Click** ถูกเปิดใช้งาน สไลด์จะเลื่อนต่อเมื่อผู้ใช้คลิกเท่านั้น หากกำหนดคุณสมบัติ **Advance After Time** สไลด์จะเลื่อนอัตโนมัติหลังจากช่วงเวลาที่กำหนด

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # ใช้การเปลี่ยนแบบวงกลมกับสไลด์ที่ 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # เปิดใช้งานการเลื่อนไปเมื่อคลิกและตั้งค่าการเลื่อนอัตโนมัติ 3 วินาที.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # ใช้การเปลี่ยนแบบคอมบกับสไลด์ที่ 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # เปิดใช้งานการเลื่อนไปเมื่อคลิกและตั้งค่าการเลื่อนอัตโนมัติ 5 วินาที.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # ใช้การเปลี่ยนแบบซูมกับสไลด์ที่ 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # เปิดใช้งานการเลื่อนไปเมื่อคลิกและตั้งค่าการเลื่อนอัตโนมัติ 7 วินาที.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **การเปลี่ยนแบบ Morph**

Aspose.Slides สำหรับ Python รองรับ [Morph transition](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/morphtransition/), ซึ่งทำให้การเคลื่อนที่อย่างราบรื่นจากสไลด์หนึ่งไปยังสไลด์ถัดไป การสาธิตนี้อธิบายวิธีใช้การเปลี่ยนแบบ Morph เพื่อใช้ได้อย่างมีประสิทธิภาพ คุณต้องมีสไลด์สองใบที่มีวัตถุร่วมกันอย่างน้อยหนึ่งชิ้น วิธีที่ง่ายที่สุดคือทำสไลด์ซ้ำแล้วย้ายวัตถุไปยังตำแหน่งอื่นในสไลด์ที่สอง

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคัดลอกสไลด์ที่มีข้อความและนำการเปลี่ยนแบบ Morph ไปใช้กับสไลด์ที่สอง

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # คัดลอกสไลด์แรกเพื่อสร้างสไลด์ที่สองด้วยรูปร่างเดียวกันสำหรับความต่อเนื่องของ Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # เลือกสี่เหลี่ยมเดียวกันบนสไลด์ที่สองและปรับตำแหน่งและขนาดของมัน.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # เปิดใช้งานการเปลี่ยนแบบ Morph บนสไลด์ที่สองเพื่อทำให้การเปลี่ยนแปลงของรูปร่างเป็นการเคลื่อนไหวอย่างราบรื่น.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ประเภทการเปลี่ยนแบบ Morph**

enum [TransitionMorphType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionmorphtype/) แสดงประเภทต่าง ๆ ของการเปลี่ยนสไลด์แบบ Morph

โค้ดตัวอย่างต่อไปนี้แสดงวิธีนำการเปลี่ยนแบบ Morph ไปใช้กับสไลด์และเปลี่ยนประเภท morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดเอฟเฟกต์การเปลี่ยน**

Aspose.Slides สำหรับ Python ให้คุณตั้งค่าเอฟเฟกต์การเปลี่ยนเช่น **From Black**, **From Left**, **From Right** เป็นต้น เพื่อกำหนดค่าเอฟเฟกต์การเปลี่ยน ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ดึงอ้างอิงไปยังสไลด์
1. ตั้งค่าเอฟเฟกต์การเปลี่ยนที่ต้องการ
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าเอฟเฟกต์การเปลี่ยนหลายแบบ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # ใช้การเปลี่ยนแบบ Cut และเปิดใช้งาน From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. ตั้งค่า [speed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ของการเปลี่ยนโดยใช้การตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionspeed/) (เช่น slow/medium/fast).

**ฉันสามารถแนบไฟล์เสียงกับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ใช่. คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่า เช่น โหมดเสียงและการวนซ้ำ (เช่น [sound](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus metadata such as [sound_is_built_in](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) and [sound_name](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**วิธีที่เร็วที่สุดสำหรับการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนถูกเก็บแยกตามสไลด์ ดังนั้นการตั้งค่าชนิดเดียวกันบนทุกสไลด์จะให้ผลลัพธ์ที่สอดคล้องกัน.

**ฉันจะตรวจสอบได้อย่างไรว่าการเปลี่ยนใดถูกตั้งค่าบนสไลด์ปัจจุบัน?**

ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/); ค่าดังกล่าวจะแจ้งให้คุณทราบว่ามีเอฟเฟกต์ใดถูกใช้อยู่.