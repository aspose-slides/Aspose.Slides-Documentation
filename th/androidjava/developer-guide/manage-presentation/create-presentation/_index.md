---
title: สร้างการนำเสนอบน Android
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/androidjava/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "สร้างการนำเสนอใน Java ด้วย Aspose.Slides สำหรับ Android—ผลิตไฟล์ PPT, PPTX, และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมสำหรับผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างการนำเสนอใน Aspose.Slides, เพิ่มเนื้อหาแบบง่ายลงในสไลด์, และบันทึกผลลัพธ์เป็นไฟล์ นอกจากนี้ยังสาธิตวิธีสร้างและบันทึกการนำเสนอใหม่, เปิดการนำเสนอที่มีอยู่ในรูปแบบที่สนับสนุน, และบันทึกไปยังรูปแบบอื่น

## **สร้างการนำเสนอ PowerPoint**
เพื่อเพิ่มเส้นธรรมดาแบบเรียบง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส Presentation.
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
1. เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด addAutoShape ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ Shapes.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้เพิ่มเส้นลงในสไลด์ที่หนึ่งของการนำเสนอ

```java
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม autoshape ประเภทเส้น
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/androidjava/save-presentation/), และส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/th/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), [SVG](/slides/th/androidjava/convert-powerpoint-to-png/), และ [images](/slides/th/androidjava/convert-powerpoint-to-png/), เป็นต้น

**ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ได้. โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [ได้รับการสนับสนุน](/slides/th/androidjava/supported-file-formats/).

**ฉันจะควบคุมขนาดสไลด์/อัตราส่วนภาพเมื่อสร้างการนำเสนอได้อย่างไร?**

ตั้งค่า [slide size](/slides/th/androidjava/slide-size/) (รวมถึงค่าพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับสเกลของเนื้อหา.

**หน่วยที่ใช้วัดขนาดและพิกัดคืออะไร?**

เป็นจุด: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการการนำเสนอที่ใหญ่มาก (มีไฟล์สื่อจำนวนมาก) เพื่อ ลดการใช้หน่วยความจำได้อย่างไร?**

ใช้ [BLOB management strategies](/slides/th/androidjava/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกกระบวนการทำงานแบบไฟล์เป็นหลักแทนการสตรีมเฉพาะในหน่วยความจำ.

**ฉันสามารถสร้าง/บันทึกการนำเสนอพร้อมกันได้หรือไม่?**

คุณไม่สามารถดำเนินการกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) เดียวกันจาก [หลายเธรด](/slides/th/androidjava/multithreading/) ได้. ให้เรียกใช้อินสแตนซ์แยกกันและแยกจากกันต่อแต่ละเธรดหรือกระบวนการ.

**ฉันจะลบลายน้ำทดลองและข้อจำกัดได้อย่างไร?**

[Apply a license](/slides/th/androidjava/licensing/) หนึ่งครั้งต่อกระบวนการ. XML ของไลเซนส์ต้องไม่มีการแก้ไข, และการตั้งค่าไลเซนส์ควรทำให้สอดคล้องกันหากมีหลายเธรดเข้ามาเกี่ยวข้อง.

**ฉันสามารถลงลายเซ็นดิจิทัลบน PPTX ที่สร้างได้หรือไม่?**

ได้. [Digital signatures](/slides/th/androidjava/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับการนำเสนอ.

**Macro (VBA) ถูกสนับสนุนในการนำเสนอที่สร้างหรือไม่?**

ได้. คุณสามารถ [create/edit VBA projects](/slides/th/androidjava/presentation-via-vba/) และบันทึกไฟล์ที่มีแมโครเช่น PPTM/PPSM.