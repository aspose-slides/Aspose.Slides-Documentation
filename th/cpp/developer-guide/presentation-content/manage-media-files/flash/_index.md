---
title: การดึงวัตถุ Flash จากงานนำเสนอใน C++
linktitle: แฟลช
type: docs
weight: 10
url: /th/cpp/flash/
keywords:
- ดึง flash
- วัตถุ flash
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีการดึงวัตถุ Flash จากสไลด์ PowerPoint และ OpenDocument ใน C++ ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดเต็มและแนวปฏิบัติที่ดีที่สุด."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการดึงวัตถุ Flash จากงานนำเสนอด้วยการใช้ Aspose.Slides โดยแสดงวิธีการค้นหา control ของ Flash ตามชื่อในคอลเลกชัน controls ของสไลด์และทำงานกับข้อมูลออบเจ็กต์ SWF ที่ฝังอยู่

## **ดึงวัตถุ Flash จากงานนำเสนอ**
Aspose.Slides for C++ มีฟังก์ชันสำหรับดึงวัตถุ flash จากงานนำเสนอ คุณสามารถเข้าถึง control ของ flash ตามชื่อและดึงออกจากงานนำเสนอรวมถึงจัดเก็บข้อมูลออบเจ็กต์ SWF

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **คำถามที่พบบ่อย**

**รูปแบบไฟล์งานนำเสนอที่รองรับการดึงเนื้อหา Flash คืออะไร?**

[Aspose.Slides supports](/slides/th/cpp/supported-file-formats/) รูปแบบ PowerPoint หลักเช่น PPT และ PPTX เนื่องจากสามารถโหลดคอนเทนเนอร์เหล่านี้และเข้าถึง controls ของพวกมัน รวมถึงองค์ประกอบ ActiveX ที่เกี่ยวข้องกับ Flash

**ฉันสามารถแปลงงานนำเสนอที่มี Flash ไปเป็น HTML5 และคงการโต้ตอบของ Flash ไว้ได้หรือไม่?**

ไม่ครับ Aspose.Slides ไม่ทำการเรียกใช้เนื้อหา SWF หรือแปลงการโต้ตอบของมัน แม้ว่าการส่งออกไปยัง [HTML](/slides/th/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/th/cpp/export-to-html5/) จะได้รับการสนับสนุน แต่ Flash จะไม่ทำงานในเบราว์เซอร์สมัยใหม่เนื่องจากไม่มีการสนับสนุนแล้ว ทางเลือกที่แนะนำคือการแทนที่ Flash ด้วยสื่ออื่นเช่นวิดีโอหรือแอนิเมชัน HTML5 ก่อนทำการส่งออก

**จากมุมมองด้านความปลอดภัย Aspose.Slides จะเรียกใช้ไฟล์ SWF ขณะอ่านงานนำเสนอหรือไม่?**

ไม่ครับ Aspose.Slides ถือว่า Flash เป็นข้อมูลไบนารีที่ฝังอยู่ในไฟล์และไม่ทำการเรียกใช้เนื้อหา SWF ระหว่างการประมวลผล

**ฉันควรจัดการงานนำเสนอที่มี Flash ร่วมกับไฟล์ฝังอื่น ๆ ผ่าน OLE อย่างไร?**

Aspose.Slides รองรับการ [การดึงออบเจ็กต์ OLE ที่ฝังอยู่](/slides/th/cpp/manage-ole/) ดังนั้นคุณจึงสามารถประมวลผลเนื้อหาฝังทั้งหมดในหนึ่งขั้นตอนได้ โดยจัดการ control ของ Flash และเอกสารที่ฝังด้วย OLE อื่น ๆ พร้อมกัน