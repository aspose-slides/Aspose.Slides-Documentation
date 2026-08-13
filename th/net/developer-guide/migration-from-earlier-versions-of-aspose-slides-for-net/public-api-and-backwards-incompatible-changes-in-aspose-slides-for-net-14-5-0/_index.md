---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.5.0
linktitle: Aspose.Slides สำหรับ .NET 14.5.0
type: docs
weight: 70
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดใหม่
- แนวทางเก่า
- แนวทางใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการทำงานไม่เข้ากันใน Aspose.Slides สำหรับ .NET เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ทั้งหมด, ข้อจำกัดใหม่ [ข้อจำกัด](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) และการเปลี่ยนแปลงอื่น ๆ [การเปลี่ยนแปลง](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) ที่แนะนำใน Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลัง**
### **อินเทอร์เฟซ, คลาส, คุณสมบัติและเมธอดที่เพิ่ม**
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.IPresentationInfo และคลาส PresentationInfo**
แสดงข้อมูลเกี่ยวกับการพรีเซนเทชัน.

- คุณสมบัติ Boolean IsEncrypted คืนค่า True หากการพรีเซนเทชันถูกเข้ารหัส, มิฉะนั้นคืนค่า False.
- คุณสมบัติ LoadFormat คืนค่าประเภทของการพรีเซนเทชัน.
#### **เพิ่มคุณสมบัติ Aspose.Slides.IShape.IsGrouped**
คุณสมบัติ Aspose.Slides.IShape.IsGrouped กำหนดว่ารูปทรงถูกจัดกลุ่มหรือไม่.
#### **เพิ่มคุณสมบัติ Aspose.Slides.IShape.ParentGroup**
คุณสมบัติ Aspose.Slides.IShape.ParentGroup คืนค่าออบเจ็กต์ GroupShape พ่อแม่หากรูปทรงถูกจัดกลุ่ม. มิฉะนั้นคืนค่า null.
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.AddGroupShape()**
เมธอด Aspose.Slides.IShapeCollection.AddGroupShape() สร้าง GroupShape ใหม่และเพิ่มลงในตำแหน่งสุดท้ายของคอลเลกชัน.
ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อเพิ่มรูปทรงใหม่.
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.Clear()**
เมธอด Aspose.Slides.IShapeCollection.Clear() ลบรูปทรงทั้งหมดจากคอลเลกชัน.
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
เมธอด Aspose.Slides.IShapeCollection.InsertGroupShape(int) สร้าง GroupShape ใหม่และแทรกลงในคอลเลกชันที่ตำแหน่งดัชนีที่ระบุ.
ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อเพิ่มรูปทรงใหม่.
#### **เพิ่มเมธอด IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
เมธอดเหล่านี้อนุญาตให้รับข้อมูลเกี่ยวกับไฟล์หรือสตรีมของการพรีเซนเทชันโดยไม่ต้องโหลดการพรีเซนเทชันทั้งหมด.
#### **เพิ่มคุณสมบัติ IPresentationFactory PresentationFactory.Instance**
คุณสมบัตินี้ทำให้นักพัฒนาสามารถใช้ฟังก์ชันการทำงานของแฟกทอรีได้โดยไม่ต้องสร้างอินสแตนซ์.
### **ข้อจำกัด**
#### **ข้อจำกัดต่อ IShape.Frame**
ได้เพิ่มข้อจำกัดสำหรับการใช้ค่าที่กำหนดไม่ได้ใน IShape.Frame. โค้ดที่พยายามกำหนดเฟรมที่ไม่ได้กำหนดให้กับ IShape.Frame ไม่มีเหตุผลในกรณีส่วนใหญ่ (โดยเฉพาะเมื่อ GroupShape พ่อแม่ถูกซ้อนหลายชั้นใน {{GroupShape}} อื่น ๆ). ตัวอย่างเช่น:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// เกิดข้อยกเว้น ArgumentException: ค่ากรอบต้องถูกกำหนด.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

หรือ

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// เกิดข้อยกเว้น ArgumentException: x, y, width และ height ต้องถูกกำหนด.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

โค้ดเช่นนั้นอาจนำไปสู่สถานการณ์ที่ไม่ชัดเจน ดังนั้นจึงได้เพิ่มข้อจำกัดสำหรับการใช้ค่าที่กำหนดไม่ได้ใน IShape.Frame. ค่าของ x, y, width, height, flipH, flipV และ rotationAngle ต้องถูกกำหนด (และไม่ตั้งเป็น float.NaN หรือ NullableBool.NotDefined). โค้ดตัวอย่างข้างต้นขณะนี้จะโยนข้อยกเว้น ArgumentException.
นี่ใช้กับกรณีการใช้งานต่อไปนี้:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// พารามิเตอร์ x, y, width และ height ไม่สามารถเป็น float.NaN, และ flipH, flipV
// ไม่สามารถเป็น NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// ข้อจำกัดเดียวกันนี้ใช้กับทุกเมธอดที่สร้างรูปทรง:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

แต่คุณสมบัติเฟรมของ IShape.RawFrame สามารถเป็นค่าที่ไม่ได้กำหนดได้ ซึ่งมีเหตุผลเมื่อรูปทรงถูกเชื่อมโยงกับพื้นที่จองไว้ (placeholder). จากนั้นค่าที่ไม่ได้กำหนดของเฟรมรูปทรงจะถูกแทนที่จากรูปทรง placeholder พ่อแม่ หากไม่มี placeholder พ่อแม่รูปทรงนั้นจะใช้ค่าเริ่มต้นเมื่อประเมินเฟรมที่มีประสิทธิภาพบนพื้นฐานของ IShape.RawFrame ของมัน ค่าเริ่มต้นคือ 0 และ NullableBool.False สำหรับ x, y, width, height, flipH, flipV และ rotationAngle. ตัวอย่างเช่น:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // รูปทรงเชื่อมโยงกับ placeholder
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // ตอนนี้รูปทรงสืบทอดค่า x, y, height, flipH, flipV จาก placeholder และแทนที่ค่า width=100 และ rotationAngle=0.
}
``` 
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เปลี่ยนชื่อและชนิดของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent**
- ชนิดของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent ได้เปลี่ยนจาก ISlideComponent ไปเป็นอินเทอร์เฟซ IGroupShape ใหม่. อินเทอร์เฟซ IGroupShape เป็นลูกของ ISlideComponent ดังนั้นโค้ดเดิมไม่ต้องปรับแก้ใด ๆ.
- ชื่อของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent ถูกเปลี่ยนจาก Parent เป็น ParentGroup.
#### **เปลี่ยนชนิดของคุณสมบัติ Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- ชนิดของคุณสมบัติ Aspose.Slides.IShapeFrame.FlipH ได้เปลี่ยนจาก bool เป็น NullableBool.
- คุณสมบัติ IShape.Frame คืนค่าอินสแตนซ์ที่มีประสิทธิภาพของ IShapeFrame (ซึ่งทุกคุณสมบัติมีค่าที่กำหนดไว้แล้ว).
- คุณสมบัติ IShape.RawFrame คืนค่าอินสแตนซ์ของ IShapeFrame ที่แต่ละคุณสมบัติอาจเป็นค่ายังไม่ได้กำหนด (โดยเฉพาะ FlipH หรือ FlipV อาจมีค่า NullableBool.NotDefined).