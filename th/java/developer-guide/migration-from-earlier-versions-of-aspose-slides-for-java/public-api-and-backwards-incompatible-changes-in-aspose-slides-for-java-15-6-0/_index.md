---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนกลับใน Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดข้อแตกต่างใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่มใหม่](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) รวมถึงข้อจำกัดใหม่และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) ที่นำมาใช้กับ Aspose.Slides for Java 15.6.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **คอนสตรัคเตอร์ของ com.aspose.slides.DataLabel ถูกเปลี่ยนแปลง**
ลายเซ็นของคอนสตรัคเตอร์ได้ถูกเปลี่ยนจาก DataLabel(com.aspose.slides.IChartSeries) เป็น DataLabel(com.aspose.slides.IChartDataPoint).
#### **สมาชิก com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) ถูกทำเครื่องหมายว่า Deprecated; มีการแนะนำการทดแทนแทน**
เมธอด IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) ถูกทำเครื่องหมายว่า Deprecated. เมธอด IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ถูกเพิ่มเข้ามาแทน.
#### **เมธอด com.aspose.slides.INotesSlideManager.removeNotesSlide() ถูกเพิ่ม**
เมธอด com.aspose.slides.INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเพื่อใช้ลบสไลด์บันทึกของสไลด์บางอัน.
#### **เมธอด com.aspose.slides.ISlide.getNotesSlideManager() ถูกเพิ่ม. เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่า Deprecated**
เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่า Deprecated. ใช้เมธอดใหม่ ISlide.getNotesSlideManager() แทน.
``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - ถูกยกเลิก

// notes = slide.getNotesSlide(); - ถูกยกเลิก

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **เมธอด getAppVersion() ถูกเพิ่มใน com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.getAppVersion() ถูกเพิ่มเพื่อดึงคุณสมบัติเอกสารในตัว ซึ่งแสดงหมายเลขเวอร์ชันภายในที่ใช้โดย Microsoft PowerPoint.
#### **เมธอด remove() ถูกเพิ่มใน com.aspose.slides.IComment**
เมธอด com.aspose.slides.IComment.remove() ถูกเพิ่มเพื่อใช้ลบคอมเมนต์จากคอลเลกชัน.
#### **เมธอด remove() ถูกเพิ่มใน com.aspose.slides.ICommentAuthor**
เมธอด ICommentAuthor.Remove ถูกเพิ่มเพื่อใช้ลบผู้เขียนคอมเมนต์จากคอลเลกชัน.
#### **เมธอด clearCustomProperties() และ clearBuiltInProperties() ถูกเพิ่มใน com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.clearCustomProperties() ถูกเพิ่มเพื่อใช้ลบคุณสมบัติเอกสารที่กำหนดเองทั้งหมด. เมธอด com.aspose.slides.IDocumentProperties.clearBuiltInProperties() ถูกเพิ่มเพื่อใช้ลบและตั้งค่าเริ่มต้นสำหรับคุณสมบัติเอกสารในตัวทั้งหมด (Company, Subject, Author เป็นต้น).
#### **เมธอด getBlackWhiteMode() และ setBlackWhiteMode(byte) ถูกเพิ่มใน com.aspose.slides.IShape**
เมธอด getBlackWhiteMode() และ setBlackWhiteMode(byte) ถูกเพิ่มใน com.aspose.slides.IShape. เมธอดเหล่านี้ระบุว่ารูปร่างจะถูกแสดงผลในโหมดสีขาว-ดำอย่างไร. ค่าที่เป็นไปได้ถูกกำหนดในคลาส com.aspose.slides.BlackWhiteMode.

|**Value** |**ความหมาย** |
| :- | :- |
|Color |คืนค่าโดยใช้สีปกติ |
|Automatic |คืนค่าโดยใช้สีอัตโนมัติ |
|Gray |คืนค่าโดยใช้สีเทา |
|LightGray |คืนค่าโดยใช้สีเทาอ่อน |
|InverseGray |คืนค่าโดยใช้สีเทาแบบย้อนกลับ |
|GrayWhite |คืนค่าโดยใช้สีเทาและสีขาว |
|BlackGray |คืนค่าโดยใช้สีดำและสีเทา |
|BlackWhite |คืนค่าโดยใช้สีดำและสีขาว |
|Black |คืนค่าโดยใช้สีดำเท่านั้น |
|White |คืนค่าโดยใช้สีขาว |
|Hidden |วัตถุจะไม่ถูกแสดงผล |
#### **เมธอด removeAt(int), remove(ICommentAuthor) และ clear() ถูกเพิ่มใน com.aspose.slides.ICommentAuthorCollection**
เมธอด ICommentAuthorCollection.removeAt(int) ถูกเพิ่มเพื่อใช้ลบผู้เขียนตามดัชนีที่ระบุ. เมธอด ICommentAuthorCollection.remove(ICommentAuthor) ถูกเพิ่มเพื่อใช้ลบผู้เขียนที่ระบุจากคอลเลกชัน. เมธอด ICommentAuthorCollection.clear() ถูกเพิ่มเพื่อใช้ลบรายการทั้งหมดจากคอลเลกชัน.