---
title: โคลนสไลด์ PowerPoint ด้วย Python
linktitle: โคลนสไลด์
type: docs
weight: 40
url: /th/python-net/clone-slides/
keywords:
- โคลนสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "โคลนหรือทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Python via .NET ตามตัวอย่างโค้ดและเคล็ดลับที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาที เพิ่มประสิทธิภาพการทำงานและขจัดงานแบบมือได้"
---
## **คำนำ**

การโคลนคือกระบวนการทำสำเนาที่เหมือนกันหรือจำลองของบางอย่าง Aspose.Slides ยังอนุญาตให้คุณคัดลอก (โคลน) สไลด์ใดๆ แล้วแทรกสไลด์ที่โคลนไว้เข้าสู่การนำเสนอปัจจุบันหรือการนำเสนอเปิดอื่น สไลด์ที่โคลนจะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีในการโคลนสไลด์:

- โคลนที่จุดสิ้นสุดของการนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในการนำเสนอ
- โคลนที่จุดสิ้นสุดของการนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในการนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในการนำเสนออื่น

ใน Aspose.Slides for Python via .NET, [คอลเล็กชันสไลด์](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ที่เปิดเผยโดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) มีเมธอด `add_clone` และ `insert_clone` เพื่อทำการโคลนสไลด์ตามประเภทต่างๆ

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **โคลนที่จุดสิ้นสุดภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและเพิ่มต่อท้ายสไลด์ที่มีอยู่แล้ว ให้ใช้เมธอด `add_clone` ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับคอลเล็กชันสไลด์จากวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกเมธอด `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) โดยส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์
1. บันทึกการนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์แรก (ดัชนี 0) จะถูกโคลนและเพิ่มต่อท้ายการนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอ
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังจุดสิ้นสุดของคอลเล็กชันสไลด์ในงานนำเสนอเดียวกัน
    presentation.slides.add_clone(presentation.slides[0])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและวางไว้ในตำแหน่งอื่น ให้ใช้เมธอด `insert_clone`:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับคอลเล็กชันสไลด์จากวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) โดยส่งสไลด์ที่ต้องการโคลนและดัชนีเป้าหมายสำหรับตำแหน่งใหม่ของมัน
1. บันทึกการนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่มีดัชนี 1 (ตำแหน่ง 2) จะถูกโคลนไปยังดัชนี 2 (ตำแหน่ง 3) ภายในงานนำเสนอเดียวกัน

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอ
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งที่กำหนด (ดัชนี) ภายในงานนำเสนอเดียวกัน
    presentation.slides.insert_clone(2, presentation.slides[1])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่จุดสิ้นสุดของงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและเพิ่มต่อท้ายของงานนำเสนออื่น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ที่มีสไลด์ให้โคลน)
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม)
1. รับคอลเล็กชันสไลด์จากงานนำเสนอปลายทาง
1. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง โดยส่งสไลด์จากงานนำเสนอแหล่งที่มา
1. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกโคลนไปยังจุดสิ้นสุดของงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ตำแหน่งที่สไลด์จะถูกโคลน)
    with slides.Presentation() as target_presentation:
        # โคลนสไลด์ที่ต้องการจากการนำเสนอแหล่งที่มายังจุดสิ้นสุดของคอลเล็กชันสไลด์ในการนำเสนอปลายทาง
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและแทรกเข้าไปในงานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ที่มีสไลด์ให้โคลน)
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม)
1. รับคอลเล็กชันสไลด์จากงานนำเสนอปลายทาง
1. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง โดยส่งสไลด์จากงานนำเสนอแหล่งที่มาและดัชนีเป้าหมายที่ต้องการ
1. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกโคลนไปยังดัชนี 2 (ตำแหน่ง 3) ในงานนำเสนอปลายทาง

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ตำแหน่งที่สไลด์จะถูกโคลน)
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # แทรกสำเนาของสไลด์แรกจากแหล่งที่มายังดัชนี 2 ในการนำเสนอปลายทาง
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนสไลด์พร้อมมาสเตอร์สไลด์ไปยังงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์ **พร้อมมาสเตอร์** จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น ให้โคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาไว้ในงานนำเสนอปลายทางก่อน จากนั้นใช้มาสเตอร์ปลายทางนั้นเมื่อต้องการโคลนสไลด์ เมธอด `add_clone(Slide, MasterSlide)` คาดหวัง **มาสเตอร์สไลด์จากงานนำเสนอปลายทาง** ไม่ใช่จากแหล่งที่มา

เพื่อโคลนสไลด์พร้อมมาสเตอร์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง
1. เข้าถึงสไลด์แหล่งที่มาที่จะโคลนและมาสเตอร์สไลด์ของมัน
1. รับ [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) จากคอลเล็กชันมาสเตอร์ของงานนำเสนอปลายทาง
1. เรียก `add_clone` บน [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) ของปลายทาง โดยส่งมาสเตอร์แหล่งที่มามาโคลนเข้าไปในปลายทาง
1. รับ [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) จากคอลเล็กชันสไลด์ของงานนำเสนอปลายทาง
1. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง โดยส่งสไลด์แหล่งที่มาและมาสเตอร์ปลายทางที่โคลนแล้ว
1. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังจุดสิ้นสุดของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลนจากแหล่งที่มา

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับการนำเสนอปลายทางที่สไลด์จะถูกโคลน
    with slides.Presentation() as target_presentation:
        # ดึงสไลด์แรกจากการนำเสนอแหล่งที่มา
        source_slide = source_presentation.slides[0]
        # ดึงมาสเตอร์สไลด์ที่ใช้โดยสไลด์แรก
        source_master = source_slide.layout_slide.master_slide
        # โคลนมาสเตอร์สไลด์เข้าสู่คอลเล็กชันมาสเตอร์ของการนำเสนอปลายทาง
        cloned_master = target_presentation.masters.add_clone(source_master)
        # โคลนสไลด์จากการนำเสนอแหล่งที่ไปยังจุดสิ้นสุดของการนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลนแล้ว
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # บันทึกการนำเสนอปลายทางลงดิสก์
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่จุดสิ้นสุดในส่วนที่กำหนด**

ด้วย Aspose.Slides for Python via .NET คุณสามารถโคลนสไลด์จากส่วนหนึ่งของงานนำเสนอและแทรกเข้าสู่ส่วนอื่นภายในงานนำเสนอเดียวกันได้ ใช้เมธอด `add_clone(Slide, Section)` ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/)

ตัวอย่าง Python ด้านล่างแสดงวิธีโคลนสไลด์และแทรกสำเนาไปยังส่วนที่กำหนด

```py
import aspose.slides as slides

# สร้างการนำเสนอใหม่เปล่า.
with slides.Presentation() as presentation:
    # เพิ่มสไลด์เปล่าตามเลเอาต์ของสไลด์แรก.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # เพิ่มรูปวงรีลงบนสไลด์ใหม่; สไลด์นี้จะถูกโคลนภายหลัง.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # เพิ่มสไลด์เปล่าอีกหนึ่งสไลด์ตามเลเอาต์ของสไลด์แรก.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # สร้างส่วนที่ชื่อ "Section2" เริ่มที่ slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # โคลนสไลด์ที่สร้างไว้ก่อนหน้านี้เข้าสู่ส่วน "Section2".
    presentation.slides.add_clone(slide, section)
    # บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

### บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?

ใช่ หน้าโน้ตและความคิดเห็นการตรวจสอบจะรวมอยู่ในสำเนา หากคุณไม่ต้องการให้มีอยู่ ให้ [ลบออก](/slides/th/python-net/presentation-notes/) หลังจากการแทรก

### แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?

ออบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น เวิร์กบุ๊กที่ฝังเป็น OLE) การเชื่อมโยงนั้นจะคงไว้เป็น [OLE object](/slides/th/python-net/manage-ole/) หลังจากย้ายระหว่างไฟล์ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

### ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของการโคลนได้หรือไม่?

ได้ คุณสามารถแทรกสำเนาที่ตำแหน่งสไลด์เฉพาะและวางลงใน [section](/slides/th/python-net/slide-section/) ที่ต้องการ หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วจึงย้ายสไลด์ไปยังส่วนนั้น