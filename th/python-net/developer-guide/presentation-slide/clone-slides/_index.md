---
title: "คัดลอกสไลด์ PowerPoint ด้วย Python"
linktitle: "คัดลอกสไลด์"
type: docs
weight: 40
url: /th/python-net/clone-slides/
keywords:
- คัดลอกสไลด์
- ทำสำเนาสไลด์
- บันทึกสไลด์
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "คัดลอกหรือทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ปฏิบัติตามตัวอย่างโค้ดและเคล็ดลับที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาที, เพิ่มประสิทธิภาพการทำงาน, และขจัดงานที่ต้องทำด้วยมือ."
---
## **บทนำ**

การโคลนคือกระบวนการทำสำเนาที่เหมือนกันอย่างสมบูรณ์หรือจำลองของบางสิ่ง Aspose.Slides ยังอนุญาตให้คุณคัดลอก (โคลน) สไลด์ใด ๆ แล้วแทรกสไลด์ที่ถูกโคลนเข้าไปในงานนำเสนอปัจจุบันหรือในงานนำเสนอที่เปิดอยู่อื่น ๆ การโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบสไลด์ต้นฉบับ มีหลายวิธีในการโคลนสไลด์:

- โคลนที่ส่วนท้ายของงานนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในงานนำเสนอ
- โคลนที่ส่วนท้ายของงานนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides for Python via .NET, [slide collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ที่เปิดให้โดยวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) มีเมธอด `add_clone` และ `insert_clone` เพื่อทำการโคลนสไลด์ประเภทต่าง ๆ เหล่านี้.

## **การติดตั้ง**

```bash
pip install aspose.slides
```

## **โคลนที่ส่วนท้ายภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและเพิ่มต่อท้ายสไลด์ที่มีอยู่, ให้ใช้เมธอด `add_clone`. ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. รับคอลเลกชันสไลด์จากวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
3. เรียกเมธอด `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/), ส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์.
4. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ในตัวอย่างด้านล่าง, สไลด์แรก (ดัชนี 0) จะถูกโคลนและเพิ่มต่อท้ายของงานนำเสนอ.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอ.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน.
    presentation.slides.add_clone(presentation.slides[0])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะภายในงานนำเสนอเดียวกัน**

หากคุณต้องการโคลนสไลด์ภายในงานนำเสนอเดียวกันและวางไว้ที่ตำแหน่งอื่น, ให้ใช้เมธอด `insert_clone`:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
2. รับคอลเลกชันสไลด์จากวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
3. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/), ส่งสไลด์ที่ต้องการโคลนและดัชนีเป้าหมายสำหรับตำแหน่งใหม่ของมัน.
4. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ในตัวอย่างด้านล่าง, สไลด์ที่ดัชนี 1 (ตำแหน่ง 2) จะถูกโคลนไปยังดัชนี 2 (ตำแหน่ง 3) ภายในงานนำเสนอเดียวกัน.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอ.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # โคลนสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุตรง (ดัชนี) ภายในงานนำเสนอเดียวกัน.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่ส่วนท้ายของงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและเพิ่มต่อท้ายของงานนำเสนออื่น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ซึ่งมีสไลด์ที่จะโคลน).
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม).
3. รับคอลเลกชันสไลด์จากงานนำเสนอปลายทาง.
4. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง, ส่งสไลด์จากงานนำเสนอแหล่งที่มา.
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว.

ในตัวอย่างด้านล่าง, สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาจะถูกโคลนไปยังส่วนท้ายของงานนำเสนอปลายทาง.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน).
    with slides.Presentation() as target_presentation:
        # โคลนสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาที่ส่วนท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนไปยังตำแหน่งเฉพาะในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและแทรกเข้าไปในงานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ซึ่งมีสไลด์ที่จะโคลน).
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง (ที่สไลด์จะถูกเพิ่ม).
3. รับคอลเลกชันสไลด์จากงานนำเสนอปลายทาง.
4. เรียกเมธอด `insert_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง, ส่งสไลด์จากงานนำเสนอแหล่งที่มาและดัชนีเป้าหมายที่ต้องการ.
5. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว.

ในตัวอย่างด้านล่าง, สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังดัชนี 2 (ตำแหน่ง 3) ในงานนำเสนอปลายทาง.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # แทรกสำเนาของสไลด์แรกจากแหล่งที่มาที่ตำแหน่งดัชนี 2 ในงานนำเสนอปลายทาง.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนสไลด์พร้อมมาสเตอร์สไลด์เข้าไปในงานนำเสนออื่น**

หากคุณต้องการโคลนสไลด์ **พร้อมมาสเตอร์** จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น, ก่อนอื่นให้โคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาใส่ในงานนำเสนอปลายทาง. จากนั้นใช้มาสเตอร์ปลายทางนั้นเมื่อโคลนสไลด์. เมธอด `add_clone(Slide, MasterSlide)` คาดหวัง **มาสเตอร์สไลด์จากงานนำเสนอปลายทาง**, ไม่ใช่จากแหล่งที่มา.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอแหล่งที่ม (ซึ่งมีสไลด์ที่จะโคลน).
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) สำหรับงานนำเสนอปลายทาง.
3. เข้าถึงสไลด์แหล่งที่มาที่จะโคลนและมาสเตอร์สไลด์ของมัน.
4. รับ [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) จากคอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง.
5. เรียก `add_clone` บน [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) ของปลายทาง, ส่งมาสเตอร์จากแหล่งที่มามาโคลนเข้าสู่ปลายทาง.
6. รับ [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) จากคอลเลกชันสไลด์ของงานนำเสนอปลายทาง.
7. เรียก `add_clone` บน [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) ของปลายทาง, ส่งสไลด์แหล่งที่มาและมาสเตอร์ปลายทางที่โคลนแล้ว.
8. บันทึกงานนำเสนอปลายทางที่แก้ไขแล้ว.

ในตัวอย่างด้านล่าง, สไลด์ที่ดัชนี 0 ในงานนำเสนอแหล่งที่มาถูกโคลนไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลนจากแหล่งที่มา.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อแทนไฟล์การนำเสนอแหล่งที่มา.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทางที่สไลด์จะถูกโคลน.
    with slides.Presentation() as target_presentation:
        # ดึงสไลด์แรกจากงานนำเสนอแหล่งที่มา.
        source_slide = source_presentation.slides[0]
        # ดึงมาสเตอร์สไลด์ที่สไลด์แรกใช้.
        source_master = source_slide.layout_slide.master_slide
        # โคลนมาสเตอร์สไลด์ไปยังคอลเลกชันมาสเตอร์ของงานนำเสนอปลายทาง.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # โคลนสไลด์จากงานนำเสนอแหล่งที่มาไปยังส่วนท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์ที่โคลน.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # บันทึกงานนำเสนอปลายทางลงดิสก์.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **โคลนที่ส่วนท้ายในส่วนที่กำหนด**

ด้วย Aspose.Slides for Python via .NET, คุณสามารถโคลนสไลด์จากส่วนหนึ่งของงานนำเสนอและแทรกเข้าไปในส่วนอื่นภายในงานนำเสนอเดียวกันได้. เพื่อทำเช่นนี้, ใช้เมธอด `add_clone(Slide, Section)` ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/).

ตัวอย่าง Python ด้านล่างแสดงวิธีโคลนสไลด์และแทรกคลอนได้ในส่วนที่กำหนด:

```py
import aspose.slides as slides

# สร้างงานนำเสนอเปล่าใหม่.
with slides.Presentation() as presentation:
    # เพิ่มสไลด์เปล่าที่อิงจากเค้าโครงของสไลด์แรก.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # เพิ่มรูปวงรีลงในสไลด์ใหม่; สไลด์นี้จะถูกโคลนภายหลัง.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # เพิ่มสไลด์เปล่าอีกอันที่อิงจากเค้าโครงของสไลด์แรก.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # สร้างส่วนที่ชื่อ "Section2" ซึ่งเริ่มที่ slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # โคลนสไลด์ที่สร้างไว้ก่อนหน้านี้เข้าไปในส่วน "Section2".
    presentation.slides.add_clone(slide, section)
    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบขนาดสไลด์ให้ตรงกัน**

เมื่อโคลนสไลด์ไปยังงานนำเสนออื่น, ควรตรวจให้แน่ใจว่างานนำเสนอปลายทางมีขนาดสไลด์เท่ากับงานนำเสนอแหล่งที่มา. หากขนาดสไลด์ต่างกัน, Aspose.Slides จะไม่ปรับขนาดรูปร่างที่โคลนโดยอัตโนมัติ – พิกัดและขนาดเดิมจะคงไว้ซึ่งอาจทำให้เนื้อหาแสดงออกมาไม่ตรงหรือเกินขอบสไลด์.

คุณสามารถตั้งค่าขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มาก่อนการโคลนมาสเตอร์และสไลด์ได้:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

ทำสิ่งนี้ก่อนการโคลนมาสเตอร์และสไลด์.

## **FAQ**

### โน้ตผู้บรรยายและความคิดเห็นของผู้ตรวจสอบถูกโคลนหรือไม่?

ใช่. หน้าโน้ตและความคิดเห็นการตรวจสอบจะรวมอยู่ในคลอน. หากคุณไม่ต้องการ, [ลบออก](/slides/th/python-net/presentation-notes/) หลังจากแทรก.

### แผนภูมิและแหล่งข้อมูลของมันจัดการอย่างไร?

อ็อบเจกต์แผนภูมิ, การจัดรูปแบบ, และข้อมูลที่ฝังอยู่จะถูกคัดลอก. หากแผนภูมิเชื่อมโยงกับแหล่งภายนอก (เช่นเวิร์กบุ๊กที่ฝัง OLE), การเชื่อมโยงนั้นจะถูกเก็บไว้เป็น [วัตถุ OLE](/slides/th/python-net/manage-ole/). หลังจากย้ายไฟล์, ตรวจสอบว่าข้อมูลพร้อมใช้งานและพฤติกรรมการรีเฟรชเป็นไปตามที่คาด.

### ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนสำหรับคลอนได้หรือไม่?

ใช่. คุณสามารถแทรกคลอนที่ดัชนีสไลด์เฉพาะและวางลงใน [ส่วน](/slides/th/python-net/slide-section/) ที่เลือก. หากส่วนเป้าหมายยังไม่มี, สร้างมันก่อนแล้วค่อยย้ายสไลด์เข้าไป.