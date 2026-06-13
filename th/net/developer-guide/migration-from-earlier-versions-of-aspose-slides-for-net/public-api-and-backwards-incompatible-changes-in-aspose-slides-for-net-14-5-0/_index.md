---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันแบบย้อนกลับใน Aspose.Slides สำหรับ .NET 14.5.0
linktitle: Aspose.Slides สำหรับ .NET 14.5.0
type: docs
weight: 70
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการขัดแย้งใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่[เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ทั้งหมด, ข้อ[จำกัด](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)ใหม่และ[การเปลี่ยนแปลง](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)อื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Public API และการเปลี่ยนแปลงที่ไม่เข้ากันแบบย้อนกลับ**
### **ส่วนต่อประสาน, คลาส, คุณสมบัติ และเมธอดที่เพิ่มเข้ามา**
#### **เพิ่มส่วนต่อประสาน Aspose.Slides.IPresentationInfo และคลาส PresentationInfo**
แสดงข้อมูลเกี่ยวกับงานนำเสนอ

- คุณสมบัติ Boolean IsEncrypted จะคืนค่า True หากงานนำเสนอถูกเข้ารหัส, มิฉะนั้นจะคืนค่า False
- คุณสมบัติ LoadFormat จะให้ประเภทของงานนำเสนอ
#### **เพิ่มคุณสมบัติ Aspose.Slides.IShape.IsGrouped**
คุณสมบัติ Aspose.Slides.IShape.IsGrouped กำหนดว่ารูปร่างนั้นถูกจัดกลุ่มหรือไม่
#### **เพิ่มคุณสมบัติ Aspose.Slides.IShape.ParentGroup**
คุณสมบัติ Aspose.Slides.IShape.ParentGroup จะคืนค่าออบเจกต์ GroupShape พ่อยถ้ารูปร่างถูกจัดกลุ่ม มิฉะนั้นจะคืนค่า null
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.AddGroupShape()**
เมธอด Aspose.Slides.IShapeCollection.AddGroupShape() สร้าง GroupShape ใหม่และเพิ่มลงในตำแหน่งสุดท้ายของคอลเลกชัน
ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อมีการเพิ่มรูปร่างใหม่
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.Clear()**
เมธอด Aspose.Slides.IShapeCollection.Clear() ลบรูปร่างทั้งหมดออกจากคอลเลกชัน
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
เมธอด Aspose.Slides.IShapeCollection.InsertGroupShape(int) สร้าง GroupShape ใหม่และแทรกลงในคอลเลกชันที่ตำแหน่งดัชนีที่ระบุ
ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อมีการเพิ่มรูปร่างใหม่
#### **เพิ่มเมธอด IPresentationFactory.GetPresentationInfo(string file), IPresentationFactory.GetPresentationInfo(Stream stream)**
เมธอดเหล่านี้ช่วยให้รับข้อมูลเกี่ยวกับไฟล์หรือสตรีมของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบ
#### **เพิ่มคุณสมบัติ IPresentationFactory PresentationFactory.Instance**
คุณสมบัตินี้ทำให้ผู้พัฒนาสามารถใช้ฟังก์ชันการทำงานของแฟคทอรีได้โดยไม่ต้องสร้างอินสแตนซ์
### **ข้อจำกัด**
#### **ข้อจำกัดต่อ IShape.Frame**
ได้เพิ่มข้อจำกัดสำหรับการใช้ค่าที่ไม่กำหนดสำหรับ IShape.Frame โค้ดที่พยายามกำหนดเฟรมที่ไม่กำหนดให้กับ IShape.Frame มิได้หมายความในหลายกรณี (โดยเฉพาะเมื่อ GroupShape พ่อแม่ถูกซ้อนหลายชั้นใน {{GroupShape}} อื่น ๆ) ตัวอย่างเช่น:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

หรือ

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

โค้ดดังกล่าวอาจนำไปสู่สถานการณ์ที่ไม่ชัดเจน ดังนั้นจึงได้เพิ่มข้อจำกัดสำหรับการใช้ค่าที่ไม่กำหนดสำหรับ IShape.Frame ค่าของ x, y, width, height, flipH, flipV และ rotationAngle ต้องถูกกำหนด (และต้องไม่ตั้งเป็น float.NaN หรือ NullableBool.NotDefined) โค้ดตัวอย่างข้างต้นขณะนี้จะทำให้เกิดข้อยกเว้น ArgumentException
นี่ใช้ได้กับกรณีการใช้งานเหล่านี้:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // ไม่สามารถเป็นค่า undefined ได้

IShapeCollection shapes = ...;

// พารามิเตอร์ x, y, width, height ไม่สามารถเป็น float.NaN ได้:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

แต่คุณสมบัติ IShape.RawFrame ของเฟรมสามารถเป็นค่าที่ไม่กำหนดได้ สิ่งนี้สมเหตุสมผลเมื่อรูปร่างถูกเชื่อมโยงกับตัวแทนที่วางไว้ (placeholder) จากนั้นค่าของเฟรมรูปร่างที่ไม่กำหนดจะถูกแทนที่จากรูปร่าง placeholder พ่อแม่ หากไม่มี placeholder พ่อแม่ รูปร่างนั้นจะใช้ค่าปริยายเมื่อประเมินเฟรมที่มีประสิทธิผลบนพื้นฐานของ IShape.RawFrame ค่าปริยายคือ 0 และ NullableBool.False สำหรับ x, y, width, height, flipH, flipV และ rotationAngle ตัวอย่าง:

``` csharp

 IShape shape = ...; // shape เชื่อมโยงกับ placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// ตอนนี้ shape สืบทอดค่า x, y, height, flipH, flipV จาก placeholder และแทนที่ค่า width=100 และ rotationAngle=0.

``` 
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เปลี่ยนชื่อและประเภทของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent**
- ประเภทของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent ถูกเปลี่ยนจาก ISlideComponent เป็นอินเทอร์เฟซ IGroupShape ใหม่ อินเทอร์เฟซ IGroupShape สืบทอดจาก ISlideComponent ดังนั้นโค้ดที่มีอยู่เดิมไม่ต้องปรับเปลี่ยน
- ชื่อของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent ถูกเปลี่ยนจาก Parent เป็น ParentGroup
#### **เปลี่ยนประเภทของคุณสมบัติ Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- ประเภทของคุณสมบัติ Aspose.Slides.IShapeFrame.FlipH ถูกเปลี่ยนจาก bool เป็น NullableBool
- คุณสมบัติ IShape.Frame คืนค่าอินสแตนซ์ที่มีผลของ IShapeFrame (ซึ่งทุกคุณสมบัติมีค่าที่กำหนดแล้ว)
- คุณสมบัติ IShape.RawFrame คืนค่าอินสแตนซ์ของ IShapeFrame ที่แต่ละคุณสมบัติอาจมีค่าไม่กำหนด (โดยเฉพาะ FlipH หรือ FlipV สามารถมีค่า NullableBool.NotDefined)