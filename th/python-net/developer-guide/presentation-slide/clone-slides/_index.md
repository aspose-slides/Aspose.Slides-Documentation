---
title: "คัดลอกสไลด์ PowerPoint ใน Python"
linktitle: "คัดลอกสไลด์"
type: docs
weight: 40
url: /th/python-net/clone-slides/
keywords:
- "คัดลอกสไลด์"
- "ทำสำเนาสไลด์"
- "บันทึกสไลด์"
- "PowerPoint"
- "งานนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "คัดลอกหรือทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Python via .NET ตามตัวอย่างโค้ดและเคล็ดลับที่ชัดเจนของเราเพื่ออัตโนมัติกระบวนการสร้าง PPT ในไม่กี่วินาที เพิ่มผลิตภาพและขจัดการทำงานด้วยตนเอง"
---
## **คำนำ**

การทำสำเนา (Cloning) คือกระบวนการทำสำเนาตรงหรือสำเนาที่เหมือนกันของสิ่งใดสิ่งหนึ่ง Aspose.Slides ยังให้คุณคัดลอก (clone) สไลด์ใดก็ได้แล้วแทรกสไลด์ที่ถูกคัดลอกลงในงานนำเสนอปัจจุบันหรือในงานนำเสนอที่เปิดอยู่อื่น ๆ การคัดล่าสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีในการคัดล่าสไลด์:

- คัดลอกที่ส่วนท้ายของงานนำเสนอ
- คัดลอกที่ตำแหน่งอื่นภายในงานนำเสนอ
- คัดลอกที่ส่วนท้ายของงานนำเสนออื่น
- คัดลอกที่ตำแหน่งอื่นในงานนำเสนออื่น
- คัดลอกที่ตำแหน่งที่กำหนดในงานนำเสนออื่น

ใน Aspose.Slides for Python via .NET คอลเลกชัน [คอลเลกชันสไลด์](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) จะมีเมธอด `add_clone` และ `insert_clone` เพื่อทำการคัดล่าสไลด์ตามประเภทเหล่านี้

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **คัดลอกที่ส่วนท้ายในงานนำเสนอเดียวกัน**

หากคุณต้องการคัดลอกสไลด์ภายในงานนำเสนอเดียวกันและเพิ่มต่อท้ายสไลด์ที่มีอยู่แล้ว ให้ใช้เมธอด `add_clone` ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. ดึงคอลเลกชันสไลด์จากอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
3. เรียกเมธอด `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/), ส่งสไลด์ที่ต้องการคัดลอก
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์แรก (ดัชนี 0) จะถูกคัดลอกและเพิ่มต่อท้ายงานนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอ.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # คัดลอกสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน.
    presentation.slides.add_clone(presentation.slides[0])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกไปยังตำแหน่งที่ระบุในงานนำเสนอเดียวกัน**

หากคุณต้องการคัดลอกสไลด์ภายในงานนำเสนอเดียวกันและวางไว้ในตำแหน่งอื่น ให้ใช้เมธอด `insert_clone`:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. ดึงคอลเลกชันสไลด์จากอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
3. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/), ส่งสไลด์ที่ต้องการคัดลอกและดัชนีตำแหน่งเป้าหมายใหม่
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 1 (ตำแหน่ง 2) จะถูกคัดลอกไปยังดัชนี 2 (ตำแหน่ง 3) ภายในงานนำเสนอเดียวกัน

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอ.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุ (ดัชนี) ภายในงานนำเสนอเดียวกัน.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกที่ส่วนท้ายของงานนำเสนออื่น**

หากต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งแล้วเพิ่มต่อท้ายงานนำเสนออีกงานหนึ่ง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่มาซึ่งมีสไลด์ที่ต้องการคัดลอก
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่ต้องการเพิ่มสไลด์)
3. ดึงคอลเลกชันสไลด์จากงานนำเสนอปลายทาง
4. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของงานนำเสนอปลายทาง, ส่งสไลด์จากงานนำเสนอแหล่งที่มา
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกคัดลอกไปยังส่วนท้ายของงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก).
    with slides.Presentation() as target_presentation:
        # คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกไปยังตำแหน่งที่ระบุในงานนำเสนออื่น**

หากต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งและแทรกเข้าไปในงานนำเสนออีกงานหนึ่งที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่มา (ที่มีสไลด์ที่ต้องการคัดลอก)
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่ต้องการเพิ่มสไลด์)
3. ดึงคอลเลกชันสไลด์จากงานนำเสนอปลายทาง
4. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของงานนำทางปลายทาง, ส่งสไลด์จากงานนำเสนอแหล่งที่มาและดัชนีตำแหน่งเป้าหมายที่ต้องการ
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกคัดลอกไปยังดัชนี 2 (ตำแหน่ง 3) ในงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ที่สไลด์จะถูกคัดลอก).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # แทรกสำเนาของสไลด์แรกจากแหล่งที่มาที่ดัชนี 2 ในงานนำเสนอปลายทาง.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกสไลด์พร้อมมาสเตอร์สไลด์ไปยังงานนำเสนออื่น**

หากต้องการคัดลอกสไลด์ **พร้อมมาสเตอร์** จากงานนำเสนอหนึ่งแล้วใช้ในงานนำเสนออื่น ให้ทำการคัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาไว้ในงานนำเสนอปลายทางก่อน แล้วใช้มาสเตอร์ของปลายทางนั้นเมื่อคัดลอกสไลด์ เมธอด `add_clone(Slide, MasterSlide)` คาดหวัง **มาสเตอร์สไลด์จากงานนำเสนอปลายทาง** ไม่ใช่จากแหล่งที่มา

เพื่อคัดลอกสไลด์พร้อมมาสเตอร์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่มา
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง
3. เข้าถึงสไลด์แหล่งที่มาที่จะคัดลอกและมาสเตอร์สไลด์ของมัน
4. ดึง [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) จากคอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง
5. เรียก `add_clone` บน [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) ของปลายทาง, ส่งมาสเตอร์แหล่งที่มาที่ต้องการคัดลอกเข้าสู่ปลายทาง
6. ดึง [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) จากคอลเลกชันสไลด์ของงานนำเสนอปลายทาง
7. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง, ส่งสไลด์แหล่งที่มาและมาสเตอร์ปลายทางที่ได้คัดลอกไว้
8. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกคัดลอกไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่คัดลอกจากแหล่งที่มา

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทางที่สไลด์จะถูกคัดลอก.
    with slides.Presentation() as target_presentation:
        # ดึงสไลด์แรกจากการนำเสนอแหล่งที่มา
        source_slide = source_presentation.slides[0]
        # ดึงมาสเตอร์สไลด์ที่สไลด์แรกใช้.
        source_master = source_slide.layout_slide.master_slide
        # คัดลอกมาสเตอร์สไลด์เข้าสู่คอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # คัดลอกสไลด์จากงานนำเสนอแหล่งที่มาลงส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่คัดลอก.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คัดลอกที่ส่วนท้ายในส่วนที่กำหนด**

ด้วย Aspose.Slides for Python via .NET คุณสามารถคัดลอกสไลด์จากส่วนหนึ่งของงานนำเสนอและแทรกเข้าไปในส่วนอื่นภายในงานนำเสนอเดียวกันได้ เพื่อทำเช่นนี้ให้ใช้เมธอด `add_clone(Slide, Section)` ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/)

ตัวอย่าง Python ด้านล่างแสดงวิธีคัดลอกสไลด์และแทรกสำเนาเข้าในส่วนที่กำหนด:

```py
import aspose.slides as slides

# สร้างการนำเสนอใหม่เปล่า.
with slides.Presentation() as presentation:
    # เพิ่มสไลด์ว่างโดยอิงจากเลเอาต์ของสไลด์แรก.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # เพิ่มรูปร่างวงรีลงในสไลด์ใหม่; สไลด์นี้จะถูกคัดลอกในภายหลัง.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # เพิ่มสไลด์ว่างอีกหนึ่งสไลด์โดยอิงจากเลเอาต์ของสไลด์แรก.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # สร้างส่วนชื่อ "Section2" ที่เริ่มที่ slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # คัดลอกสไลด์ที่สร้างไว้ก่อนหน้านี้ไปยังส่วน "Section2".
    presentation.slides.add_clone(slide, section)
    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบขนาดสไลด์ให้ตรงกัน**

เมื่อคัดลอกสไลด์ไปยังงานนำเสนออื่น ให้ตรวจสอบว่าขนาดสไลด์ของงานนำเสนอปลายทางตรงกับงานนำเสนอแหล่งที่มา หากขนาดสไลด์ต่างกัน Aspose.Slides จะไม่ปรับขนาดรูปร่างที่คัดลอกโดยอัตโนมัติ – พิกัดและมิติเดิมจะคงอยู่ ซึ่งอาจทำให้เนื้อหาแสดงผิดตำแหน่งหรือยืดออกเกินขอบสไลด์

คุณสามารถกำหนดขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มาก่อนการคัดลอกมาสเตอร์และสไลด์:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

ทำเช่นนี้ก่อนการคัดลอกมาสเตอร์และสไลด์

## **คำถามที่พบบ่อย**

**บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกคัดลอกหรือไม่?**

ใช่ หน้าโน้ตและความคิดเห็นของผู้ตรวจสอบจะถูกรวมอยู่ในสำเนาด้วย หากคุณไม่ต้องการให้มันอยู่ ให้ [ลบออก](/slides/th/python-net/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันจะถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิถูกเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น เวิร์กบุ๊กที่ฝังเป็น OLE) การเชื่อมโยงนั้นจะถูกเก็บไว้เป็น [OLE object](/slides/th/python-net/manage-ole/) หลังจากย้ายระหว่างไฟล์ โปรดตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนต่าง ๆ สำหรับสำเนาได้หรือไม่?**

ได้ คุณสามารถแทรกสำเนาได้ที่ดัชนีสไลด์เฉพาะและวางลงใน [section](/slides/th/python-net/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วย้ายสไลด์เข้าไปในส่วนนั้น
