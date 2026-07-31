---
title: เพิ่มรูปทรงเส้นในงานนำเสนอด้วย .NET
linktitle: เส้น
type: docs
weight: 50
url: /th/net/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การจัดการการฟอร์แมตเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint ผ่านโปรแกรมคอมพิวเตอร์ บทความนี้แสดงวิธีสร้างเส้นง่าย ๆ และวิธีปรับแต่งเส้นให้ปรากฏเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างเน้นการตั้งค่าการจัดรูปแบบเส้นเช่น สไตล์ ความกว้าง รูปแบบเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**
หากต้องการเพิ่มเส้นธรรมดาง่าย ๆ ลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)คลาส
- รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/methods/addautoshape/index) ที่เผยโดยอ็อบเจ็กต์ Shapes
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```c#
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // เพิ่ม AutoShape ชนิดเส้น
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **สร้างเส้นรูปแบบลูกศร**
Aspose.Slides สำหรับ .NET ยังอนุญาตให้ผู้พัฒนากำหนดคุณสมบัติบางอย่างของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น เรามาลองกำหนดคุณสมบัติบางอย่างของเส้นเพื่อให้ดูเหมือนลูกศรกัน โปรดทำตามขั้นตอนด้านล่างเพื่อทำเช่นนั้น:

- สร้างอินสแตนซ์ของ [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)คลาส[](http://www.aspose.com/api/net/slides/th/aspose.slides/)[](http://www.aspose.com/api/net/slides/th/aspose.slides/).
- รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เผยโดยอ็อบเจ็กต์ Shapes
- ตั้งค่า Line Style ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides สำหรับ .NET มีให้
- ตั้งค่า Width ของเส้น
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/net/aspose.slides/linedashstyle) ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides สำหรับ .NET มีให้
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/net/aspose.slides/linearrowheadstyle) และ Length ของจุดเริ่มต้นของเส้น
- ตั้งค่า Arrow Head Style และ Length ของจุดสิ้นสุดของเส้น
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แสดงไฟล์ PPTX
using (Presentation pres = new Presentation())
{

    // ดึงสไลด์แรก
    ISlide sld = pres.Slides[0];

    // เพิ่ม AutoShape ชนิดเส้น
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ใช้การจัดรูปแบบบางส่วนบนเส้น
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Write the PPTX to Disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นธรรมดาให้เป็นคอนเนคเตอร์เพื่อให้มัน "snaps" กับรูปร่างได้หรือไม่?**  
ไม่ เส้นธรรมดา (เป็น [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ชนิด [Line](https://reference.aspose.com/slides/th/net/aspose.slides/shapetype/)) จะไม่กลายเป็นคอนเนคเตอร์โดยอัตโนมัติ เพื่อให้มันติดกับรูปร่าง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/net/aspose.slides/connector/) เฉพาะและ [corresponding APIs](/slides/th/net/connector/) สำหรับการเชื่อมต่อ

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากจะกำหนดค่าที่สุดท้าย?**  
[อ่านคุณสมบัติที่มีผล](/slides/th/net/shape-effective-properties/) ผ่านอินเทอร์เฟซ [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilinefillformateffectivedata/) — อินเทอร์เฟซเหล่านี้ได้คำนวณการสืบทอดและสไตล์ธีมมาแล้ว

**ฉันสามารถล็อกเส้นไม่ให้แก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่?**  
ได้ Shapes มี [lock objects](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/autoshapelock/) ที่ทำให้คุณ [disallow editing operations](/slides/th/net/applying-protection-to-presentation/).