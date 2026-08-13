---
title: วิธีเพิ่มส่วนหัวและส่วนท้ายในงานนำเสนอด้วย .NET
linktitle: เพิ่มส่วนหัวและส่วนท้าย
type: docs
weight: 20
url: /th/net/how-to-add-header-footer-in-a-presentation/
keywords:
- การย้าย
- เพิ่มหัวกระดาษ
- เพิ่มส่วนท้าย
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการรุ่นเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint PPT, PPTX และ ODP ด้วย .NET โดยใช้ API Aspose.Slides ทั้งรุ่นเก่าและรุ่นใหม่"
---
{{% alert color="info" %}} 

มีการปล่อย [Aspose.Slides for .NET API](/slides/th/net/) ใหม่แล้ว และตอนนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่ต้นและแก้ไขเอกสารที่มีอยู่

{{% /alert %}} 
## **การสนับสนุนโค้ดรุ่นเก่า**
เพื่อที่จะใช้โค้ดรุ่นเก่าที่พัฒนาด้วย Aspose.Slides for .NET เวอร์ชันก่อนหน้า 13.x คุณจำเป็นต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณ และโค้ดจะทำงานเช่นเดิม ทุกคลาสที่เคยอยู่ใน Aspose.Slides for .NET เวอร์ชันเก่า ภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ได้ถูกรวมเข้าในเนมสเปซเดียวคือ Aspose.Slides โปรดดูตัวอย่างโค้ดง่ายต่อการเพิ่มหัวกระดาษและส่วนท้ายในงานพรีเซนเทชันด้วย Aspose.Slides API รุ่นเก่าและทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมกันใหม่
## **วิธีการใช้ Aspose.Slides for .NET รุ่นเก่า**
```c#
PresentationEx sourcePres = new PresentationEx();

//ตั้งค่าคุณสมบัติการแสดงส่วนหัวและส่วนท้าย
//อัปเดตฟิลด์วันที่และเวลา
//แสดงตัวยึดตำแหน่งวันที่และเวลา
//แสดงตัวยึดตำแหน่งส่วนท้าย
//แสดงหมายเลขสไลด์
//ตั้งค่าการแสดงส่วนหัวและส่วนท้ายบนสไลด์หัวเรื่อง
//บันทึกการนำเสนอไปยังดิสก์
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//สร้างการพรีเซนเทชัน
Presentation pres = new Presentation();

//รับสไลด์แรก
Slide sld = pres.GetSlideByPosition(1);

//เข้าถึงส่วนหัว/ส่วนท้ายของสไลด์
HeaderFooter hf = sld.HeaderFooter;

//ตั้งค่าการแสดงหมายเลขหน้า
hf.PageNumberVisible = true;

//ตั้งค่าการแสดงส่วนท้าย
hf.FooterVisible = true;

//ตั้งค่าการแสดงส่วนหัว
hf.HeaderVisible = true;

//ตั้งค่าการแสดงวันที่และเวลา
hf.DateTimeVisible = true;

//ตั้งค่ารูปแบบวันที่และเวลา
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//ตั้งค่าข้อความส่วนหัว
hf.HeaderText = "Header Text";

//ตั้งค่าข้อความส่วนท้าย
hf.FooterText = "Footer Text";

//บันทึกการพรีเซนเทชันไปยังดิสก์
pres.Write("HeadFoot.ppt");
```



## **วิธีการใช้ Aspose.Slides for .NET 13.x รุ่นใหม่**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //ตั้งค่าคุณสมบัติการแสดงส่วนหัวและส่วนท้าย
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //อัปเดตฟิลด์วันที่และเวลา
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //แสดงตัวยึดวันที่และเวลา
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //แสดงตัวยึดส่วนท้าย
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //ตั้งค่าการแสดงส่วนหัวและส่วนท้ายบนสไลด์หัวเรื่อง
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //บันทึกการพรีเซนเทชันไปยังดิสก์
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```