---
title: วิธีเพิ่มส่วนหัวและส่วนท้ายในงานนำเสนอด้วย .NET
linktitle: เพิ่มส่วนหัวและส่วนท้าย
type: docs
weight: 20
url: /th/net/how-to-add-header-footer-in-a-presentation/
keywords:
- การย้าย
- เพิ่มส่วนหัว
- เพิ่มส่วนท้าย
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการรุ่นเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint PPT, PPTX และ ODP ด้วย .NET โดยใช้ API ของ Aspose.Slides ทั้งรุ่นเก่าและรุ่นใหม่."
---
{{% alert color="primary" %}} 
มีการเปิดตัว [API Aspose.Slides สำหรับ .NET](/slides/th/net/) ใหม่และตอนนี้ผลิตภัณฑ์เดียวนี้รองรับการสร้างเอกสาร PowerPoint ตั้งแต่ต้นและการแก้ไขเอกสารที่มีอยู่
{{% /alert %}} 
## **การสนับสนุนโค้ดเก่า**
เพื่อใช้โค้ด legacy ที่พัฒนาขึ้นด้วย Aspose.Slides for .NET รุ่นก่อนหน้า 13.x คุณจำเป็นต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเช่นเดิม ทุกคลาสที่เคยอยู่ใน Aspose.Slides for .NET ภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ถูกรวมเป็นเนมสเปซเดียวคือ Aspose.Slides โปรดดูตัวอย่างโค้ดง่าย ๆ ด้านล่างสำหรับการเพิ่มส่วนหัวและส่วนท้ายในพรีเซนเทชันโดยใช้ Legacy Aspose.Slides API และทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **วิธีการใช้ Legacy Aspose.Slides สำหรับ .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//ตั้งค่าคุณสมบัติการแสดงส่วนหัวและส่วนท้าย
sourcePres.UpdateSlideNumberFields = true;

//อัปเดตฟิลด์วันที่และเวลา
sourcePres.UpdateDateTimeFields = true;

//แสดงตัวแทนวันที่และเวลา
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//แสดงตัวแทนส่วนท้าย
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//แสดงหมายเลขสไลด์
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//ตั้งค่าการแสดงส่วนหัวและส่วนท้ายบนสไลด์หัวเรื่อง
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//บันทึกงานนำเสนอไปยังดิสก์
sourcePres.Write("NewSource.pptx");
```

```c#
//สร้างงานนำเสนอ
Presentation pres = new Presentation();

//รับสไลด์แรก
Slide sld = pres.GetSlideByPosition(1);

//เข้าถึงส่วนหัว / ส่วนท้ายของสไลด์
HeaderFooter hf = sld.HeaderFooter;

//ตั้งค่าการมองเห็นหมายเลขหน้า
hf.PageNumberVisible = true;

//ตั้งค่าการมองเห็นส่วนท้าย
hf.FooterVisible = true;

//ตั้งค่าการมองเห็นส่วนหัว
hf.HeaderVisible = true;

//ตั้งค่าการมองเห็นวันที่และเวลา
hf.DateTimeVisible = true;

//ตั้งค่ารูปแบบวันที่และเวลา
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ตั้งค่าข้อความส่วนหัว
hf.HeaderText = "Header Text";

//ตั้งค่าข้อความส่วนท้าย
hf.FooterText = "Footer Text";

//เขียนงานนำเสนอลงดิสก์
pres.Write("HeadFoot.ppt");
```

## **แนวทางใหม่ของ Aspose.Slides สำหรับ .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //ตั้งค่าคุณสมบัติการแสดงส่วนหัวและส่วนท้าย
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //อัปเดตฟิลด์วันที่และเวลา
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //แสดงตัวแทนวันที่และเวลา
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //แสดงตัวแทนส่วนท้าย
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //ตั้งค่าการแสดงส่วนหัวและส่วนท้ายบนสไลด์หัวเรื่อง
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //บันทึกงานนำเสนอลงดิสก์
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```