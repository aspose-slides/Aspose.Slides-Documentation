---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.6.0
linktitle: Aspose.Slides สำหรับ .NET 15.6.0
type: docs
weight: 170
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดใหม่
- แนวทางเดิม
- แนวทางใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เสียหายใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) และการเปลี่ยนแปลงอื่นๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **ลายเซ็นของคอนสตรัคเตอร์ DataLabel ได้เปลี่ยนแปลง**
ลายเซ็นของคอนสตรัคเตอร์ DataLabel ได้เปลี่ยนแปลง:
ก่อน: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
ตอนนี้: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **สมาชิก IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) ถูกทำเครื่องหมายว่าเลิกใช้และมีการนำตัวทดแทนเข้ามาแทนที่**
Property IDocumentProperties.Count และเมธอด IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) ถูกทำเครื่องหมายว่าเลิกใช้. Property IDocumentProperties.CountOfCustomProperties และเมธอด IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) ถูกเพิ่มเข้ามาแทนที่.
#### **เมธอด INotesSlideManager.RemoveNotesSlide() ได้เพิ่มเข้ามา**
เมธอด INotesSlideManager.RemoveNotesSlide() ได้เพิ่มเข้ามาเพื่อใช้ในการลบสไลด์หมายเหตุของบางสไลด์.
#### **เมธอด Remove ได้เพิ่มเข้ามาใน IComment**
เมธอด IComment.Remove ได้เพิ่มเข้ามาเพื่อใช้ในการลบคอมเมนต์จากคอลเลกชัน.
#### **เมธอด Remove ได้เพิ่มเข้ามาใน ICommentAuthor**
เมธอด ICommentAuthor.Remove ได้เพิ่มเข้ามาเพื่อใช้ในการลบผู้เขียนคอมเมนต์จากคอลเลกชัน.
#### **เมธอด ClearCustomProperties และ ClearBuiltInProperties ได้เพิ่มเข้ามาใน IDocumentProperties**
เมธอด IDocumentProperties.ClearCustomProperties ได้เพิ่มเข้ามาเพื่อใช้ในการลบคุณสมบัติเข้าเอกสารแบบกำหนดเองทั้งหมด.
เมธอด IDocumentProperties.ClearBuiltInProperties ได้เพิ่มเข้ามาเพื่อใช้ในการลบและตั้งค่าตั้งต้นสำหรับคุณสมบัติเข้าเอกสารที่มีอยู่แล้ว (Company, Subject, Author ฯลฯ).
#### **เมธอด RemoveAt, Remove และ Clear ได้เพิ่มเข้ามาใน ICommentAuthorCollection**
เมธอด ICommentAuthorCollection.RemoveAt ได้เพิ่มเข้ามาเพื่อใช้ในการลบผู้เขียนตามตำแหน่งที่ระบุ.
เมธอด ICommentAuthorCollection.Remove ได้เพิ่มเข้ามาเพื่อใช้ในการลบผู้เขียนที่ระบุจากคอลเลกชัน.
เมธอด ICommentAuthorCollection.Clear ได้เพิ่มเข้ามาเพื่อใช้ในการลบรายการทั้งหมดจากคอลเลกชัน.
#### **คุณสมบัติ AppVersion ได้เพิ่มเข้ามาใน IDocumentProperties**
คุณสมบัติ IDocumentProperties.AppVersion ได้เพิ่มเข้ามาเพื่อใช้ในการรับคุณสมบัติเอกสารที่เป็นค่าในตัวซึ่งแสดงเวอร์ชันภายในที่ Microsoft ใช้ระหว่างการพัฒนา.
#### **คุณสมบัติ BlackWhiteMode ได้เพิ่มเข้ามาใน IShape และ Shape**
คุณสมบัติ BlackWhiteMode ได้เพิ่มเข้ามาใน IShape และ Shape.

คุณสมบัตินี้ระบุว่ารูปทรงจะถูกเรนเดอร์ในโหมดสีขาว-ดำอย่างไร

|**ค่า**|**ความหมาย**|
| :- | :- |
|Color|Render with normal coloring|
|Automatic|Render with automatic coloring|
|Gray|Render with gray coloring|
|LightGray|Render with light gray coloring|
|InverseGray|Render with inverse gray coloring|
|GrayWhite|Render with gray and white coloring|
|BlackGray|Render with black and gray coloring|
|BlackWhite|Render with black and white coloring|
|Black|Render only with black coloring|
|White|Render with white coloring|
|Hidden|Not render|
|NotDefined|means that property isn't set|
#### **คุณสมบัติ ISlide.NotesSlideManager ได้เพิ่มเข้ามา. คุณสมบัติ ISlide.NotesSlide และเมธอด ISlide.AddNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้**
สมาชิก ISlide.NotesSlide และ ISlide.AddNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้. ใช้คุณสมบัติใหม่ ISlide.NotesSlideManager แทน

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - เลิกใช้

// notes = slide.NotesSlide; - เลิกใช้

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```