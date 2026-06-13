---
title: ดึงวัตถุ Flash จากงานนำเสนอบน Android
linktitle: แฟลช
type: docs
weight: 10
url: /th/androidjava/flash/
keywords:
- ดึง flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีดึงวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ใน Java ด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ดเต็มรูปแบบและแนวปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีดึงวัตถุ Flash ออกจากงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีค้นหา control ของ Flash ตามชื่อในคอลเลกชัน controls ของสไลด์และทำงานกับข้อมูลออบเจกต์ SWF ที่ฝังไว้

## **ดึงวัตถุ Flash จากงานนำเสนอ**

Aspose.Slides for Android via Java มีฟีเจอร์สำหรับการดึงวัตถุ flash ออกจากงานนำเสนอ คุณสามารถเข้าถึง control ของ flash ตามชื่อและดึงออกจากงานนำเสนอรวมถึงจัดเก็บข้อมูลออบเจกต์ SWF

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รูปแบบงานนำเสนอใดที่รองรับเมื่อดึงเนื้อหา Flash?**

[Aspose.Slides supports](/slides/th/androidjava/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึง controls ของพวกมัน รวมถึงองค์ประกอบ ActiveX ที่เกี่ยวกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash ไปเป็น HTML5 และรักษาปฏิสัมพันธ์ของ Flash ไว้ได้หรือไม่?**

ไม่. Aspose.Slides ไม่ดำเนินการเนื้อหา SWF หรือแปลงปฏิสัมพันธ์ของมัน ในขณะที่การส่งออกเป็น [HTML](/slides/th/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/th/androidjava/export-to-html5/) ได้รับการสนับสนุน Flash จะไม่ทำงานในเว็บเบราว์เซอร์สมัยใหม่เนื่องจากสิ้นสุดการสนับสนุน เส้นทางที่แนะนำคือการแทนที่ Flash ด้วยทางเลือกเช่นวิดีโอหรือแอนิเมชัน HTML5 ก่อนการส่งออก

**จากมุมมองด้านความปลอดภัย Aspose.Slides ดำเนินการไฟล์ SWF ขณะอ่านงานนำเสนอหรือไม่?**

ไม่. Aspose.Slides ปฏิบัติด้วย Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และไม่ดำเนินการเนื้อหา SWF ในระหว่างการประมวลผล

**ฉันควรจัดการงานนำเสนอที่รวม Flash ไว้พร้อมไฟล์ฝังผ่าน OLE อื่นอย่างไร?**

Aspose.Slides รองรับการ [extracting embedded OLE objects](/slides/th/androidjava/manage-ole/) ดังนั้นคุณสามารถประมวลผลเนื้อหา embedded ทั้งหมดที่เกี่ยวข้องในหนึ่งครั้ง โดยจัดการกับ control ของ Flash และเอกสารที่ฝังผ่าน OLE อื่นๆ ร่วมกัน