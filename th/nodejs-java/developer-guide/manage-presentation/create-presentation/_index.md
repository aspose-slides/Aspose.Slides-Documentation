---
title: สร้างงานนำเสนอใน JavaScript
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/nodejs-java/create-presentation/
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
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างงานนำเสนอด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides เพิ่มเนื้อหาง่าย ๆ ในสไลด์ และบันทึกผลลัพธ์เป็นไฟล์

## **สร้างงานนำเสนอ PowerPoint**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส Presentation.
2. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
3. เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด addAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes.
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่างนี้ เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม autoshape ประเภทเส้น
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/nodejs-java/save-presentation/), และส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/th/nodejs-java/convert-powerpoint-to-png/), และ [images](/slides/th/nodejs-java/convert-powerpoint-to-png/), เป็นต้น

**ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ธรรมดาได้หรือไม่?**

ได้. โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [are supported](/slides/th/nodejs-java/supported-file-formats/).

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนอได้อย่างไร?**

ตั้งค่า [slide size](/slides/th/nodejs-java/slide-size/) (รวมถึงค่าตัวเลือกเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับขนาดเนื้อหา

**หน่วยที่ใช้วัดขนาดและพิกัดคืออะไร?**

เป็นหน่วยจุด: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการงานนำเสนอขนาดใหญ่มาก (ที่มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำได้อย่างไร?**

ใช้ [BLOB management strategies](/slides/th/nodejs-java/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกเวิร์กโฟลว์แบบไฟล์เป็นหลักแทนสตรีมที่อยู่ในหน่วยความจำเท่านั้น

**ฉันสามารถสร้าง/บันทึกงานนำเสนอพร้อมกันได้หรือไม่?**

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เดียวกันจาก [multiple threads](/slides/th/nodejs-java/multithreading/) ได้. ให้รันอินสแตนซ์แยกต่างหากสำหรับแต่ละเธรดหรือโปรเซส

**ฉันจะลบลายน้ำและข้อจำกัดของเวอร์ชันทดลองได้อย่างไร?**

[Apply a license](/slides/th/nodejs-java/licensing/) หนึ่งครั้งต่อโปรเซส. ไฟล์ XML ของลิขสิทธิ์ต้องไม่ถูกแก้ไข และการตั้งค่าลิขสิทธิ์ควรทำให้ประสานกันหากมีหลายเธรดเข้ามาเกี่ยวข้อง

**ฉันสามารถลงลายเซ็นดิจิทัลบน PPTX ที่สร้างได้หรือไม่?**

ได้. [Digital signatures](/slides/th/nodejs-java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ได้รับการสนับสนุนสำหรับงานนำเสนอ

**แมโคร (VBA) รองรับในงานนำเสนอที่สร้างหรือไม่?**

ได้. คุณสามารถ [create/edit VBA projects](/slides/th/nodejs-java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโครเช่น PPTM/PPSM.