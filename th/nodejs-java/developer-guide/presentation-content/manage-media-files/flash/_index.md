---
title: สกัดวัตถุ Flash จากงานนำเสนอใน JavaScript
linktitle: แฟลช
type: docs
weight: 10
url: /th/nodejs-java/flash/
keywords:
- สกัด flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสกัดวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ด้วย JavaScript และ Aspose.Slides พร้อมตัวอย่างโค้ดครบถ้วนและแนวปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการสกัดวัตถุ Flash จากงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีค้นหา Flash control ตามชื่อในคอลเลกชันของคอนโทรลในสไลด์และทำงานกับข้อมูลวัตถุ SWF ที่ฝังอยู่

## **สกัดวัตถุ Flash จากงานนำเสนอ**

Aspose.Slides สำหรับ Node.js ผ่าน Java มีฟีเจอร์สำหรับสกัดวัตถุ flash จากงานนำเสนอ คุณสามารถเข้าถึง flash control ตามชื่อและสกัดออกจากงานนำเสนอรวมถึงจัดเก็บข้อมูลวัตถุ SWF

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**รูปแบบงานนำเสนอใดบ้างที่รองรับเมื่อสกัดเนื้อหา Flash?**

[Aspose.Slides รองรับ](/slides/th/nodejs-java/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึงคอนโทรลของพวกมันรวมถึงองค์ประกอบ ActiveX ที่เกี่ยวกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash ไปเป็น HTML5 และรักษาการโต้ตอบของ Flash ไว้ได้หรือไม่?**

ไม่มี Aspose.Slides ไม่ทำการประมวลผลเนื้อหา SWF หรือแปลงการโต้ตอบของมัน แม้การส่งออกไปยัง [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/th/nodejs-java/export-to-html5/) จะได้รับการสนับสนุน แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากการยุติการสนับสนุน เส้นทางที่แนะนำคือการแทนที่ Flash ด้วยทางเลือกอื่น เช่น วิดีโอหรือแอนิเมชัน HTML5 ก่อนทำการส่งออก

**ในแง่มุมของความปลอดภัย Aspose.Slides ทำการประมวลผลไฟล์ SWF ขณะอ่านงานนำเสนอหรือไม่?**

ไม่มี Aspose.Slides ถือว่า Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และไม่ทำการประมวลผลเนื้อหา SWF ระหว่างการประมวลผล

**ฉันควรจัดการงานนำเสนอที่มี Flash ร่วมกับไฟล์ฝังอื่น ๆ ผ่าน OLE อย่างไร?**

Aspose.Slides รองรับการ [extracting embedded OLE objects](/slides/th/nodejs-java/manage-ole/) ดังนั้นคุณสามารถประมวลผลเนื้อหาฝังที่เกี่ยวข้องทั้งหมดในหนึ่งขั้นตอน ทำการจัดการ Flash control และเอกสาร OLE ที่ฝังอื่น ๆ ร่วมกัน