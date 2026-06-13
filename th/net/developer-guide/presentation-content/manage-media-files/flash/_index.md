---
title: ดึงวัตถุ Flash จากงานนำเสนอใน .NET
linktitle: Flash
type: docs
weight: 10
url: /th/net/flash/
keywords:
- ดึง flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการดึงวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# อย่างสมบูรณ์และแนวทางปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการดึงวัตถุ Flash ออกจากงานนำเสนอโดยใช้ Aspose.Slides. มันแสดงวิธีการค้นหาควบคุม Flash ตามชื่อในคอลเลกชันของสไลด์และทำงานกับข้อมูลวัตถุ SWF ที่ฝังอยู่.

## **ดึงวัตถุ Flash จากงานนำเสนอ**
Aspose.Slides for .NET มีฟังก์ชันสำหรับดึงวัตถุ flash ออกจากงานนำเสนอ คุณสามารถเข้าถึงควบคุม flash โดยใช้ชื่อและดึงออกจากงานนำเสนอพร้อมกับเก็บข้อมูลวัตถุ SWF

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```

## **FAQ**

**รูปแบบไฟล์งานนำเสนอใดบ้างที่สนับสนุนการดึงเนื้อหา Flash?**

[Aspose.Slides รองรับ](/slides/th/net/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึงคอนโทรลของพวกมัน รวมถึงส่วนประกอบ ActiveX ที่เกี่ยวข้องกับ Flash.

**ฉันสามารถแปลงงานนำเสนอที่มี Flash เป็น HTML5 และคงไว้ซึ่งการโต้ตอบของ Flash ได้หรือไม่?**

ไม่ Aspose.Slides ไม่ทำการเรียกใช้เนื้อหา SWF หรือแปลงการโต้ตอบของมัน แม้ว่าการส่งออกเป็น [HTML](/slides/th/net/convert-powerpoint-to-html/)/[HTML5](/slides/th/net/export-to-html5/) จะได้รับการสนับสนุน แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากการยุติการสนับสนุน เส้นทางที่แนะนำคือการแทนที่ Flash ด้วยทางเลือกเช่นวิดีโอหรือแอนิเมชัน HTML5 ก่อนการส่งออก.

**จากมุมมองด้านความปลอดภัย Aspose.Slides จะเรียกใช้ไฟล์ SWF ขณะอ่านงานนำเสนอหรือไม่?**

ไม่ Aspose.Slides พิจารณา Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และไม่เรียกใช้เนื้อหา SWF ระหว่างการประมวลผล.

**ฉันควรจัดการงานนำเสนอที่มี Flash พร้อมกับไฟล์ฝังอื่นผ่าน OLE อย่างไร?**

Aspose.Slides รองรับการ [ดึงวัตถุ OLE ที่ฝังอยู่](/slides/th/net/manage-ole/) ดังนั้นคุณสามารถประมวลผลเนื้อหาที่ฝังทั้งหมดในหนึ่งรอบโดยจัดการกับคอนโทรล Flash และเอกสารอื่นที่ฝังผ่าน OLE ร่วมกัน.