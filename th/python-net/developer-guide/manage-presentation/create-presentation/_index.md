---
title: สร้างงานนำเสนอใน Python
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/python-net/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "สร้างงานนำเสนอ PowerPoint ด้วย Python และ Aspose.Slides - สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

Aspose.Slides for Python ให้คุณสร้างไฟล์งานนำเสนอใหม่ทั้งหมดด้วยโค้ด บทความนี้แสดงกระบวนการหลัก—การสร้างออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) , ดึงสไลด์แรก, ใส่รูปทรงง่าย ๆ, และบันทึกผลลัพธ์—เพื่อให้คุณเห็นว่าต้องตั้งค่าสิ่งใดน้อยแค่ไหนในการสร้างงานนำเสนอโดยไม่ต้องใช้ Microsoft Office เนื่องจาก APIเดียวกันสามารถเขียนไฟล์ PPT, PPTX, และ ODP คุณจึงสามารถทำงานกับรูปแบบ PowerPoint แบบดั้งเดิมและ OpenDocument จากโค้ดเดียว Aspose.Slides เหมาะสำหรับสภาพแวดล้อมเดสก์ท็อป, เว็บ หรือเซิร์ฟเวอร์ ทำให้แอปพลิเคชัน Python ของคุณมีจุดเริ่มต้นที่มีประสิทธิภาพสำหรับการเพิ่มเนื้อหาที่หลากหลายเช่นข้อความ, รูปภาพ หรือแผนภูมิเพิ่มเมื่อชุดสไลด์เริ่มต้นพร้อมใช้งาน.

## **สร้างงานนำเสนอ**

การสร้างไฟล์ PowerPoint จากศูนย์ใน Aspose.Slides for Python ทำได้โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ตัวสร้างออบเจ็กต์โดยอัตโนมัติให้เด็คว่างที่มีสไลด์เดียว ทำให้คุณมีผนังสีทันทีสำหรับรูปทรง, ข้อความ, แผนภูมิ หรือเนื้อหาอื่น ๆ ที่แอปพลิเคชันของคุณต้องการ เมื่อตัดแก้สไลด์นั้นหรือเพิ่มสไลด์ใหม่ คุณสามารถบันทึกผลลัพธ์เป็นไฟล์ PPTX, PPT เก่า หรือแม้แต่รูปแบบ OpenDocument ตัวอย่างโค้ดสั้นด้านล่างแสดงกระบวนการนี้โดยการเพิ่มรูปทรงง่าย ๆ ลงบนสไลด์แรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มออบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ชนิด `CLOUD` ด้วยเมธอด `add_auto_shape` ที่เปิดให้ใช้จากคอลเลกชัน `shapes`  
4. เพิ่มข้อความลงในออโต้ชเปิล  
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง รูปแบบเมฆถูกเพิ่มไปยังสไลด์แรกของงานนำเสนอ

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่ม auto-shape ชนิด CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![งานนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

You can save to [PPTX, PPT และ ODP](/slides/th/python-net/save-presentation/), and export to [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-net/convert-powerpoint-to-xps/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), [SVG](/slides/th/python-net/convert-powerpoint-to-png/), and [รูปภาพ](/slides/th/python-net/convert-powerpoint-to-png/), among others.

**ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ใช่ โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบคล้ายกัน [ได้รับการสนับสนุน](/slides/th/python-net/supported-file-formats/).

**ฉันจะควบคุมขนาดสไลด์/อัตราส่วนภาพเมื่อสร้างงานนำเสนอได้อย่างไร?**

Set the [ขนาดสไลด์](/slides/th/python-net/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

**ขนาดและพิกัดวัดเป็นหน่วยอะไร?**

เป็นหน่วยพอยต์: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการกับงานนำเสนอขนาดใหญ่มาก (ที่มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำได้อย่างไร?**

Use [กลยุทธ์การจัดการ BLOB](/slides/th/python-net/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

**ฉันสามารถสร้าง/บันทึกงานนำเสนอแบบขนานได้หรือไม่?**

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) instance from [หลายเธรด](/slides/th/python-net/multithreading/). Run separate, isolated instances per thread or process.

**ฉันจะลบลายน้ำและข้อจำกัดของรุ่นทดลองได้อย่างไร?**

[ใช้ใบอนุญาต](/slides/th/python-net/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

Yes. [ลายเซ็นดิจิทัล](/slides/th/python-net/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

**การทำแมโคร (VBA) ได้รับการสนับสนุนในงานนำเสนอที่สร้างหรือไม่?**

Yes. You can [สร้าง/แก้ไขโครงการ VBA](/slides/th/python-net/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.