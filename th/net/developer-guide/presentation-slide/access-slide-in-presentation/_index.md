---
title: การเข้าถึงสไลด์ของงานนำเสนอใน .NET
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/net/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ไอดีสไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการดึงสไลด์ตามดัชนีที่เริ่มจากศูนย์จากคอลเลกชัน `Slides` และวิธีการเข้าถึงสไลด์ตาม ID ที่ไม่ซ้ำกันโดยใช้เมธอด `GetSlideById`  

คุณยังจะได้เรียนรู้วิธีการเปลี่ยนตำแหน่งของสไลด์โดยตั้งค่า property `SlideNumber` และวิธีการกำหนดหมายเลขสไลด์เริ่มต้นของงานนำเสนอด้วย property `FirstSlideNumber` ตัวอย่างจะแสดงการโหลดงานนำเสนอ, การรับอ้างอิงสไลด์, การอัปเดตลำดับหรือหมายเลขสไลด์, และการบันทึกงานนำเสนอที่แก้ไขแล้ว  

## **เข้าถึงสไลด์โดยดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจะถูกจัดเรียงเป็นตัวเลขตามตำแหน่งสไลด์โดยเริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองผ่านดัชนี 1; เป็นต้น  

คลาส Presentation ซึ่งเป็นตัวแทนไฟล์งานนำเสนอ จะเปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [ISlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection) (คอลเลกชันของอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ) โค้ด C# นี้แสดงวิธีการเข้าถึงสไลด์ผ่านดัชนีของมัน:

```c#
 // สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
 Presentation presentation = new Presentation("AccessSlides.pptx");

 // ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
 ISlide slide = presentation.Slides[0];
```

## **เข้าถึงสไลด์โดย ID**

แต่ละสไลด์ในงานนำเสนอมี ID ที่ไม่ซ้ำกันเชื่อมโยงกับมัน คุณสามารถใช้เมธอด [GetSlideById](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/getslidebyid) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)) เพื่อระบุ ID นั้น โค้ด C# นี้แสดงวิธีการให้ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [GetSlideById](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/methods/getslidebyid):

```c#
 // สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
 Presentation presentation = new Presentation("AccessSlides.pptx");

 // รับค่า ID ของสไลด์
 uint id = presentation.Slides[0].SlideId;

 // เข้าถึงสไลด์ผ่าน ID ของมัน
 IBaseSlide slide = presentation.GetSlideById(id);
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides ให้คุณเปลี่ยนตำแหน่งของสไลด์ ตัวอย่างเช่น คุณสามารถกำหนดให้สไลด์แรกกลายเป็นสไลด์ที่สองได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์ (ตำแหน่งที่คุณต้องการเปลี่ยน) ผ่านดัชนีของมัน  
1. ตั้งค่าตำแหน่งใหม่ให้สไลด์ผ่าน property [SlideNumber](https://reference.aspose.com/slides/th/net/aspose.slides/islide/slidenumber/)  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงการดำเนินการที่สไลด์ที่ตำแหน่ง 1 ถูกย้ายไปยังตำแหน่ง 2:

```c#
 // สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
 using (Presentation pres = new Presentation("ChangePosition.pptx"))
 {
     // ดึงสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
     ISlide sld = pres.Slides[0];

     // ตั้งค่าตำแหน่งใหม่สำหรับสไลด์
     sld.SlideNumber = 2;

     // บันทึกงานนำเสนอที่แก้ไขแล้ว
     pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
 }
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่นๆ จะถูกปรับอัตโนมัติ  

## **กำหนดหมายเลขสไลด์**

โดยใช้ property [FirstSlideNumber](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/firstslidenumber/) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)) คุณสามารถกำหนดหมายเลขใหม่ให้สไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่นๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. รับหมายเลขสไลด์  
1. ตั้งค่าหมายเลขสไลด์  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C# นี้แสดงการดำเนินการที่กำหนดหมายเลขสไลด์แรกเป็น 10:

```c#
 // สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์งานนำเสนอ
 using (Presentation presentation = new Presentation("HelloWorld.pptx"))
 {
     // ดึงหมายเลขสไลด์
     int firstSlideNumber = presentation.FirstSlideNumber;

     // ตั้งค่าหมายเลขสไลด์
     presentation.FirstSlideNumber=10;
     
     // บันทึกงานนำเสนอที่แก้ไขแล้ว
     presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
 }
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับหมายเลขจากสไลด์ที่สอง (และซ่อนการนับเลขสำหรับสไลด์แรก) ได้ดังนี้:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // กำหนดหมายเลขสำหรับสไลด์แรกของงานนำเสนอ
    presentation.FirstSlideNumber = 0;

    // แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีที่เริ่มจากศูนย์ของคอลเลกชันหรือไม่?**  

หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าที่กำหนดเอง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี; ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/firstslidenumber/) ของงานนำเสนอ  

**สไลด์ที่ซ่อนอยู่มีผลต่อการจัดดัชนีหรือไม่?**  

ใช่ สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและถูกนับในการจัดดัชนี; “hidden” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์เปลี่ยนแปลงเมื่อมีการเพิ่มหรือลบสไลด์อื่นหรือไม่?**  

ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะถูกคำนวณใหม่เมื่อทำการแทรก, ลบ, หรือย้ายสไลด์