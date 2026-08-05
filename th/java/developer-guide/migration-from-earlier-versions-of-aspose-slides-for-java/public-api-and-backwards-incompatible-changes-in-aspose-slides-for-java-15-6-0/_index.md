---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.6.0
linktitle: Aspose.Slides สำหรับ Java 15.6.0
type: docs
weight: 140
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เสียหายใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, วิธีการ, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) , ข้อจำกัดใหม่ใด ๆ และ [changes](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) อื่น ๆ ที่แนะนำใน API ของ Aspose.Slides for Java 15.6.0  

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **ลายเซ็นของคอนสตรัคเตอร์ com.aspose.slides.DataLabel ถูกเปลี่ยนแปลง**
ลายเซ็นของคอนสตรัคเตอร์ถูกเปลี่ยนแปลงจาก DataLabel(com.aspose.slides.IChartSeries) เป็น DataLabel(com.aspose.slides.IChartDataPoint).
#### **สมาชิก com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) ถูกทำเครื่องหมายว่าเลิกใช้; มีการแนะนำตัวทดแทนแทนที่**
เมธอด IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) ถูกทำเครื่องหมายว่าเลิกใช้. เมธอด IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ถูกแนะนำแทนที่.
#### **เมธอด com.aspose.slides.INotesSlideManager.removeNotesSlide() ถูกเพิ่ม**
เมธอด com.aspose.slides.INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเพื่อการลบสไลด์บันทึกของสไลด์บางอัน.
#### **เมธอด com.aspose.slides.ISlide.getNotesSlideManager() ถูกเพิ่ม. เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้**
เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่าเลิกใช้. ใช้เมธอดใหม่ ISlide.getNotesSlideManager() แทน  

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - เลิกใช้

// notes = slide.getNotesSlide(); - เลิกใช้

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **เมธอด getAppVersion() ถูกเพิ่มให้กับ com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.getAppVersion() ถูกเพิ่มขึ้นเพื่อดึงคุณสมบัติลายสาร builtin ของเอกสาร ซึ่งแสดงหมายเลขเวอร์ชันภายในที่ใช้โดย Microsoft PowerPoint.
#### **เมธอด remove() ถูกเพิ่มให้กับ com.aspose.slides.IComment**
เมธอด com.aspose.slides.IComment.remove() ถูกเพิ่มเพื่อการลบความคิดเห็นจากคอลเลกชัน.
#### **เมธอด remove() ถูกเพิ่มให้กับ com.aspose.slides.ICommentAuthor**
เมธอด ICommentAuthor.Remove ถูกเพิ่มเพื่อการลบผู้เขียนความคิดเห็นจากคอลเลกชัน.
#### **เมธอด clearCustomProperties() และ clearBuiltInProperties() ถูกเพิ่มให้กับ com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.clearCustomProperties() ถูกเพิ่มเพื่อการลบคุณสมบัติเซกเมนต์ทั้งหมดของเอกสาร.
เมธอด com.aspose.slides.IDocumentProperties.clearBuiltInProperties() ถูกเพิ่มเพื่อการลบและตั้งค่าค่าเริ่มต้นให้กับคุณสมบัติลำลองทั้งหมด (Company, Subject, Author เป็นต้น).
#### **เมธอด getBlackWhiteMode(), setBlackWhiteMode(byte) ถูกเพิ่มให้กับ com.aspose.slides.IShape**
เมธอด getBlackWhiteMode(), setBlackWhiteMode(byte) ถูกเพิ่มให้กับ com.aspose.slides.IShape. เมธอดเหล่านี้ระบุวิธีการแสดงรูปร่างในโหมดสีขาว-ดำ ค่าได้ระบุในคลาส com.aspose.slides.BlackWhiteMode  

|**ค่า**|**ความหมาย**|
| :- | :- |
|Color|คืนค่าแบบสีปกติ|
|Automatic|คืนค่าแบบสีอัตโนมัติ|
|Gray|คืนค่าเป็นสีเทา|
|LightGray|คืนค่าเป็นสีเทาอ่อน|
|InverseGray|คืนค่าเป็นสีเทากลับด้าน|
|GrayWhite|คืนค่าเป็นสีเทาและสีขาว|
|BlackGray|คืนค่าเป็นสีดำและสีเทา|
|BlackWhite|คืนค่าเป็นสีดำและสีขาว|
|Black|คืนค่าเป็นสีดำเท่านั้น|
|White|คืนค่าเป็นสีขาว|
|Hidden|วัตถุจะไม่แสดงผล|
#### **เมธอด removeAt(int), remove(ICommentAuthor) และ clear() ถูกเพิ่มให้กับ com.aspose.slides.ICommentAuthorCollection**
เมธอด ICommentAuthorCollection.removeAt(int) ถูกเพิ่มเพื่อการลบผู้เขียนตามดัชนีที่ระบุ. เมธอด ICommentAuthorCollection.remove(ICommentAuthor) ถูกเพิ่มเพื่อการลบผู้เขียนที่ระบุจากคอลเลกชัน. เมธอด ICommentAuthorCollection.clear() ถูกเพิ่มเพื่อการลบรายการทั้งหมดจากคอลเลกชัน.