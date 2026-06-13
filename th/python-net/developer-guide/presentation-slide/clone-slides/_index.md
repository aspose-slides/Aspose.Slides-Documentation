---
title: "โคลนสไลด์ PowerPoint ใน Python"
linktitle: "โคลนสไลด์"
type: docs
weight: 40
url: /th/python-net/clone-slides/
keywords:
- "โคลนสไลด์"
- "คัดลอกสไลด์"
- "บันทึกสไลด์"
- "PowerPoint"
- "งานนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "โคลนหรือทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Python via .NET. ตามตัวอย่างโค้ดและเคล็ดลับของเราเพื่อทำการสร้าง PPT อัตโนมัติในไม่กี่วินาที เพิ่มผลิตภาพและขจัดงานที่ทำด้วยมือ."
---
## **บทนำ**

การโคลนคือกระบวนการทำสำเนาแบบตรงหรือจำลองของบางอย่าง Aspose.Slides ยังอนุญาตให้คุณคัดลอก (โคลน) สไลด์ใดก็ได้แล้วแทรกสไลด์ที่โคลนแล้วเข้าไปในงานนำเสนอปัจจุบันหรือในงานนำเสนออื่นที่เปิดอยู่ การโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบกับสไลด์ต้นฉบับ มีหลายวิธีในการโคลนสไลด์:

- โคลนที่ส่วนท้ายของงานนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในงานนำเสนอ
- โคลนที่ส่วนท้ายของงานนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides for Python via .NET, the [คอลเลกชันสไลด์](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ให้เมธอด `add_clone` และ `insert_clone` เพื่อทำการโคลนสไลด์ประเภทเหล่านี้

## **โคลนที่ส่วนท้ายภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและแทรกต่อที่ส่วนท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด `add_clone` ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. ดึงคอลเลกชันสไลด์จากอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
3. เรียกเมธอด `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) โดยส่งสไลด์ที่ต้องการโคลน
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์แรก (ดัชนี 0) จะถูกโคลนและแทรกต่อที่ส่วนท้ายของงานนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอ
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    presentation.slides.add_clone(presentation.slides[0])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและวางไว้ที่ตำแหน่งอื่น ให้ใช้เมธอด `insert_clone`:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. ดึงคอลเลกชันสไลด์จากอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
3. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) โดยส่งสไลด์ที่ต้องการโคลนและดัชนีเป้าหมายสำหรับตำแหน่งใหม่
4. บันทึกงานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 (ตำแหน่ง 1) จะถูกโคลนไปยังดัชนี 1 (ตำแหน่ง 2) ภายในงานนำเสนอเดียวกัน

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอ
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุ (ดัชนี) ภายในงานนำเสนอเดียวกัน
    presentation.slides.insert_clone(2, presentation.slides[1])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่ส่วนท้ายของงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและแทรกต่อที่ส่วนท้ายของงานนำเสนออีกอันหนึ่ง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ที่มีสไลด์ที่จะโคลน)
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม)
3. ดึงคอลเลกชันสไลด์จากงานนำเสนอปลายทาง
4. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทางโดยส่งสไลด์จากงานนำเสนอแหล่งที่มา
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังส่วนท้ายของงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอแหล่งที่มา.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน).
    with slides.Presentation() as target_presentation:
        # โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและแทรกเข้าไปในงานนำเสนออีกอันที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ที่มีสไลด์ที่จะโคลน)
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม)
3. ดึงคอลเลกชันสไลด์จากงานนำเสนอปลายทาง
4. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทางโดยส่งสไลด์จากแหล่งที่มาและดัชนีเป้าหมายที่ต้องการ
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังดัชนี 1 (ตำแหน่ง 2) ในงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอแหล่งที่มา.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # แทรกสำเนาของสไลด์แรกจากแหล่งที่มาไปยังดัชนี 2 ในงานนำเสนอปลายทาง.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนสไลด์พร้อมมาสเตอร์สไลด์เข้าไปในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์ **พร้อมมาสเตอร์** จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น ให้โคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มานำเข้ามาในงานนำเสนอปลายทางก่อน จากนั้นใช้มาสเตอร์ปลายทางเมื่อโคลนสไลด์ เมธอด `add_clone(Slide, MasterSlide)` คาดหวัง **มาสเตอร์สไลด์จากงานนำเสนอปลายทาง** ไม่ใช่จากแหล่งที่มา

ขั้นตอนการโคลนสไลด์พร้อมมาสเตอร์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ที่มีสไลด์ที่จะโคลน)
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง
3. เข้าถึงสไลด์ต้นฉบับที่ต้องการโคลนและมาสเตอร์สไลด์ของมัน
4. ดึง [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) จากคอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง
5. เรียก `add_clone` บน [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) ของปลายทางโดยส่งมาสเตอร์ต้นฉบับเพื่อโคลนเข้าสู่ปลายทาง
6. ดึง [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) จากคอลเลกชันสไลด์ของงานนำเสนอปลายทาง
7. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทางโดยส่งสไลด์ต้นฉบับและมาสเตอร์ปลายทางที่โคลนแล้ว
8. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลนจากแหล่งที่มา

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์งานนำเสนอแหล่งที่มา.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทางที่สไลด์จะถูกโคลน.
    with slides.Presentation() as target_presentation:
        # ดึงสไลด์แรกจากงานนำเสนอแหล่งที่มา.
        source_slide = source_presentation.slides[0]
        # ดึงมาสเตอร์สไลด์ที่ใช้โดยสไลด์แรก.
        source_master = source_slide.layout_slide.master_slide
        # โคลนมาสเตอร์สไลด์เข้าสู่คอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # โคลนสไลด์จากงานนำเสนอแหล่งที่มาไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลน.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่ส่วนท้ายในส่วนที่ระบุ**

ด้วย Aspose.Slides for Python via .NET คุณสามารถโคลนสไลด์จากส่วนหนึ่งของงานนำเสนอและแทรกเข้าไปยังส่วนอื่นภายในงานนำเสนอเดียวกันได้ ใช้วิธี `add_clone(Slide, Section)` ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) เพื่อทำเช่นนั้น

ตัวอย่าง Python ด้านล่างแสดงวิธีโคลนสไลด์และแทรกคลอนเข้าไปในส่วนที่ระบุ:

```py
import aspose.slides as slides

# สร้างงานนำเสนอเปล่าใหม่.
with slides.Presentation() as presentation:
    # เพิ่มสไลด์เปล่าตามเค้าโครงของสไลด์แรก.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # เพิ่มรูปทรงวงรีลงในสไลด์ใหม่; สไลด์นี้จะถูกโคลนในภายหลัง.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # เพิ่มสไลด์เปล่าอีกหนึ่งตามเค้าโครงของสไลด์แรก.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # สร้างส่วนชื่อ "Section2" ที่เริ่มต้นที่ slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # โคลนสไลด์ที่สร้างก่อนหน้านี้เข้าไปในส่วน "Section2".
    presentation.slides.add_clone(slide, section)
    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?**

ใช่. หน้าโน้ตและความคิดเห็นการตรวจสอบจะรวมอยู่ในคลอน หากคุณไม่ต้องการให้มันอยู่ ให้ [ลบออก](/slides/th/python-net/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

วัตถุแผนภูมิ การจัดรูปแบบและข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิมีการเชื่อมโยงกับแหล่งภายนอก (เช่น สมุดงานที่ฝังด้วย OLE) การเชื่อมโยงนั้นจะถูกเก็บไว้เป็น [OLE object](/slides/th/python-net/manage-ole/) หลังจากย้ายระหว่างไฟล์ ให้ตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนสำหรับคลอนได้หรือไม่?**

ได้. คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและวางเข้าไปใน [section](/slides/th/python-net/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ให้สร้างก่อนแล้วค่อยย้ายสไลด์เข้าไปในส่วนนั้น