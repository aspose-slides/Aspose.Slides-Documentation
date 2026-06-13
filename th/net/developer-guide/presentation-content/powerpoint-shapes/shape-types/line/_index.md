---
title: เพิ่มรูปทรงเส้นไปยังงานนำเสนอใน .NET
linktitle: เส้น
type: docs
weight: 50
url: /th/net/Line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นขีด
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มรูปทรงเส้นในสไลด์ PowerPoint ได้โดยโปรแกรมมิง บทความนี้แสดงวิธีสร้างเส้นธรรมดาและวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีการเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างให้ความสำคัญกับการตั้งค่าการจัดรูปแบบเส้นเชิงปฏิบัติ เช่น รูปแบบ, ความกว้าง, รูปแบบเส้นจุดประทัด, ตัวเลือกหัวลูกศร, และสีเติม

## **สร้างเส้นธรรมดา**
เพื่อเพิ่มเส้นธรรมดาไปยังสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [AddAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/methods/addautoshape/index) ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes.
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นไปยังสไลด์แรกของงานนำเสนอ

```c#
 // สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX
 using (Presentation pres = new Presentation())
 {
     // ดึงสไลด์แรก
     ISlide sld = pres.Slides[0];
 
     // เพิ่ม autoshape ประเภทเส้น
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     // เขียนไฟล์ PPTX ไปยังดิสก์
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```

## **สร้างเส้นรูปแบบลูกศร**
Aspose.Slides for .NET ยังช่วยให้นักพัฒนาตั้งค่าบางคุณสมบัติของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อให้ดูเหมือนลูกศรตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/th/aspose.slides/)[](http://www.aspose.com/api/net/slides/th/aspose.slides/).
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากอ็อบเจกต์ Shapes.
- ตั้งค่า Line Style เป็นหนึ่งในสไตล์ที่ Aspose.Slides for .NET เสนอ.
- ตั้งค่าความกว้างของเส้น.
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/net/aspose.slides/linedashstyle) ของเส้นเป็นหนึ่งในสไตล์ที่ Aspose.Slides for .NET มีให้.
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/net/aspose.slides/linearrowheadstyle) และความยาวของจุดเริ่มต้นของเส้น.
- ตั้งค่า Arrow Head Style และความยาวของจุดสิ้นสุดของเส้น.
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```c#
 // สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX
 using (Presentation pres = new Presentation())
 {
 
     // ดึงสไลด์แรก
     ISlide sld = pres.Slides[0];
 
     // เพิ่ม autoshape ประเภทเส้น
     IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     // กำหนดการจัดรูปแบบบางอย่างบนเส้น
     shp.LineFormat.Style = LineStyle.ThickBetweenThin;
     shp.LineFormat.Width = 10;
 
     shp.LineFormat.DashStyle = LineDashStyle.DashDot;
 
     shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
     shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
 
     shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
     shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
 
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;
 
     //เขียนไฟล์ PPTX ไปยังดิสก์
     pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
 }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นธรรมดาให้เป็นคอนเนคเตอร์เพื่อให้มัน "จะแนบ" กับรูปทรงได้หรือไม่?**

ไม่. เส้นธรรมดา (AutoShape ของประเภท Line) จะไม่กลายเป็นคอนเนคเตอร์โดยอัตโนมัติ เพื่อให้มันแนบกับรูปทรง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/net/aspose.slides/connector/) ที่กำหนดไว้และใช้ [corresponding APIs](/slides/th/net/connector/) สำหรับการเชื่อมต่อ

**ควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากต่อการกำหนดค่าที่สุด?**

[อ่านคุณสมบัติที่มีผล](/slides/th/net/shape-effective-properties/) ผ่านอินเทอร์เฟซ [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ilinefillformateffectivedata/) — อินเทอร์เฟซเหล่านี้พิจารณาการสืบทอดและสไตล์ของธีมไว้แล้ว

**ฉันสามารถล็อกเส้นไม่ให้แก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่?**

ได้ Shapes มี [lock objects](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/autoshapelock/) ที่ให้คุณ [disallow editing operations](/slides/th/net/applying-protection-to-presentation/).