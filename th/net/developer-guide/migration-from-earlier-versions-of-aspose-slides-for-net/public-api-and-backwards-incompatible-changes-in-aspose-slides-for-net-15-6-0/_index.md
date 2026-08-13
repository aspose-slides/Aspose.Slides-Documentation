---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.6.0
linktitle: Aspose.Slides สำหรับ .NET 15.6.0
type: docs
weight: 170
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการขัดแย้งใน Aspose.Slides สำหรับ .NET เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ถูกเพิ่มหรือเอาออกทั้งหมด, รวมถึงการเปลี่ยนแปลงอื่นๆ ที่นำเข้ามาพร้อมกับ API ของ Aspose.Slides for .NET เวอร์ชัน 15.6.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **ลายเซ็นท์คอนสตรักเตอร์ของ DataLabel ถูกเปลี่ยนแปลง**
ลายเซ็นท์คอนสตรักเตอร์ของ DataLabel ถูกเปลี่ยนแปลง:
เดิม: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ใหม่: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **สมาชิก IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) ถูกทำเครื่องหมายว่าเลิกใช้และได้แนะนำการแทนที่แทนที่**
คุณสมบัติ IDocumentProperties.Count และเมธอด IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) ถูกทำเครื่องหมายว่าเลิกใช้. คุณสมบัติ IDocumentProperties.CountOfCustomProperties และเมธอด IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) ถูกเพิ่มเข้ามาแทนที่
#### **เมธอด INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเข้ามา**
เมธอด INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเข้ามาเพื่อการลบโน้ตสไลด์ของสไลด์บางอัน
#### **เมธอด Remove ถูกเพิ่มเข้ามาที่ IComment**
เมธอด IComment.Remove ถูกเพิ่มเข้ามาเพื่อการลบความคิดเห็นจากคอลเลคชัน
#### **เมธอด Remove ถูกเพิ่มเข้ามาที่ ICommentAuthor**
เมธอด ICommentAuthor.Remove ถูกเพิ่มเข้ามาเพื่อการลบผู้เขียนของความคิดเห็นจากคอลเลคชัน
#### **เมธอด ClearCustomProperties และ ClearBuiltInProperties ถูกเพิ่มเข้ามาที่ IDocumentProperties**
เมธอด IDocumentProperties.ClearCustomProperties ถูกเพิ่มเข้ามาเพื่อการลบคุณสมบัติเอกสารที่กำหนดเองทั้งหมด
เมธอด IDocumentProperties.ClearBuiltInProperties ถูกเพิ่มเข้ามาเพื่อการลบและตั้งค่าค่าดีฟอลต์สำหรับคุณสมบัติเอกสารที่มีมาในตัวทั้งหมด (Company, Subject, Author เป็นต้น)
#### **เมธอด RemoveAt, Remove และ Clear ถูกเพิ่มเข้ามาที่ ICommentAuthorCollection**
เมธอด ICommentAuthorCollection.RemoveAt ถูกเพิ่มเข้ามาเพื่อการลบผู้เขียนโดยใช้ดัชนีที่ระบุ
เมธอด ICommentAuthorCollection.Remove ถูกเพิ่มเข้ามาเพื่อการลบผู้เขียนที่ระบุจากคอลเลคชัน
เมธอด ICommentAuthorCollection.Clear ถูกเพิ่มเข้ามาเพื่อการลบรายการทั้งหมดจากคอลเลคชัน
#### **คุณสมบัติ AppVersion ถูกเพิ่มเข้ามาที่ IDocumentProperties**
คุณสมบัติ IDocumentProperties.AppVersion ถูกเพิ่มเข้ามาเพื่อดึงคุณสมบัติเอกสารที่มีมาในตัวซึ่งเป็นหมายเลขเวอร์ชันภายในที่ Microsoft ใช้ในระหว่างการพัฒนา
#### **คุณสมบัติ BlackWhiteMode ถูกเพิ่มเข้ามาที่ IShape และ Shape**
คุณสมบัติ BlackWhiteMode ถูกเพิ่มเข้ามาที่ IShape และ Shape

คุณสมบัตินี้ระบุว่ารูปร่างจะเรนเดอร์อย่างไรในโหมดการแสดงผลสีขาว-ดำ

|**ค่า** |**ความหมาย** |
| :- | :- |
|Color |แสดงด้วยสีปกติ |
|Automatic |แสดงด้วยสีอัตโนมัติ |
|Gray |แสดงด้วยสีเทา |
|LightGray |แสดงด้วยสีเทาอ่อน |
|InverseGray |แสดงด้วยสีเทาแบบอินเวอร์ส |
|GrayWhite |แสดงด้วยสีเทาและสีขาว |
|BlackGray |แสดงด้วยสีดำและสีเทา |
|BlackWhite |แสดงด้วยสีดำและสีขาว |
|Black |แสดงด้วยสีดำเท่านั้น |
|White |แสดงด้วยสีขาว |
|Hidden |ไม่แสดง |
|NotDefined|หมายความว่าคุณสมบัติโม่ได้ตั้งค่า|
#### **คุณสมบัติ ISlide.NotesSlideManager ถูกเพิ่มเข้ามา. คุณสมบัติ ISlide.NotesSlide และเมธอด ISlide.AddNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้**
สมาชิก ISlide.NotesSlide, ISlide.AddNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้. ใช้คุณสมบัติใหม่ ISlide.NotesSlideManager แทน

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - เลิกใช้
    // notes = slide.NotesSlide; - เลิกใช้

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```