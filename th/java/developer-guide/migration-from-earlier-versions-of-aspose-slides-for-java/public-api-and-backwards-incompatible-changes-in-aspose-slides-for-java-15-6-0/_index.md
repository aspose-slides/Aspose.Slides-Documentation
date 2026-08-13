---
title: การเปลี่ยนแปลง API สาธารณะและไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.6.0
linktitle: Aspose.Slides สำหรับ Java 15.6.0
type: docs
weight: 140
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการหยุดทำงานใน Aspose.Slides สำหรับ Java เพื่อการอัปเกรดโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) , ข้อจำกัดใหม่และ [changes](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) ที่แนะนำมาพร้อมกับ Aspose.Slides for Java 15.6.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **ลายเซ็นของคอนสตรัคเตอร์ com.aspose.slides.DataLabel ถูกเปลี่ยนแปลง**
ลายเซ็นของคอนสตรัคเตอร์ได้ถูกเปลี่ยนจาก DataLabel(com.aspose.slides.IChartSeries) เป็น DataLabel(com.aspose.slides.IChartDataPoint).

#### **สมาชิก com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) ถูกทำเครื่องหมายว่า Deprecated; มีการแนะนำตัวทดแทนแทนที่**
เมธอด IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) ถูกทำเครื่องหมายว่า Deprecated. เมธอด IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) ได้ถูกแนะนำแทนที่.

#### **เมธอด com.aspose.slides.INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเข้ามา**
เมธอด com.aspose.slides.INotesSlideManager.RemoveNotesSlide() ถูกเพิ่มเพื่อใช้ในการลบโน้ตสไลด์ของสไลด์บางส่วน.

#### **เมธอด com.aspose.slides.ISlide.getNotesSlideManager() ถูกเพิ่ม. เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่า Deprecated**
เมธอด ISlide.getNotesSlide() และ ISlide.addNotesSlide() ถูกทำเครื่องหมายว่า Deprecated. ใช้เมธอดใหม่ ISlide.getNotesSlideManager() แทน.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - ล้าสมัย

    // notes = slide.getNotesSlide(); - ล้าสมัย

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **เมธอด getAppVersion() ถูกเพิ่มใน com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.getAppVersion() ถูกเพิ่มเพื่อรับคุณสมบัติเบิลท์อินของเอกสาร ซึ่งแสดงหมายเลขเวอร์ชันภายในที่ใช้โดย Microsoft PowerPoint.

#### **เมธอด remove() ถูกเพิ่มใน com.aspose.slides.IComment**
เมธอด com.aspose.slides.IComment.remove() ถูกเพิ่มเพื่อใช้ลบคอมเมนต์จากคอลเลกชัน.

#### **เมธอด remove() ถูกเพิ่มใน com.aspose.slides.ICommentAuthor**
เมธอด ICommentAuthor.Remove ถูกเพิ่มเพื่อใช้ลบผู้เขียนคอมเมนต์จากคอลเลกชัน.

#### **เมธอด clearCustomProperties() และ clearBuiltInProperties() ถูกเพิ่มใน com.aspose.slides.IDocumentProperties**
เมธอด com.aspose.slides.IDocumentProperties.clearCustomProperties() ถูกเพิ่มเพื่อใช้ลบคุณสมบัติเอกสารที่กำหนดเองทั้งหมด.  
เมธอด com.aspose.slides.IDocumentProperties.clearBuiltInProperties() ถูกเพิ่มเพื่อใช้ลบและตั้งค่าตั้งต้นให้กับคุณสมบัติเบิลท์อินของเอกสารทั้งหมด (Company, Subject, Author เป็นต้น).

#### **เมธอด getBlackWhiteMode() และ setBlackWhiteMode(byte) ถูกเพิ่มใน com.aspose.slides.IShape**
เมธอด getBlackWhiteMode() และ setBlackWhiteMode(byte) ถูกเพิ่มใน com.aspose.slides.IShape. เมธอดเหล่านี้ระบุว่ารูปร่างจะถูกเรนเดอร์อย่างไรในโหมดสีดำ‑ขาว. ค่าที่เป็นไปได้ระบุในคลาส com.aspose.slides.BlackWhiteMode.

|**ค่า** |**ความหมาย** |
| :- | :- |
|Color |คืนค่าด้วยสีปกติ |
|Automatic |คืนค่าโดยใช้สีอัตโนมัติ |
|Gray |คืนค่าเป็นสีเทา |
|LightGray |คืนค่าเป็นสีเทาอ่อน |
|InverseGray |คืนค่าเป็นสีเทาตรงกันข้าม |
|GrayWhite |คืนค่าเป็นสีเทาและสีขาว |
|BlackGray |คืนค่าเป็นสีดำและสีเทา |
|BlackWhite |คืนค่าเป็นสีดำและสีขาว |
|Black |คืนค่าเป็นสีดำเท่านั้น |
|White |คืนค่าเป็นสีขาว |
|Hidden |อ็อบเจกต์จะไม่ถูกแสดงผล |

#### **เมธอด removeAt(int), remove(ICommentAuthor) และ clear() ถูกเพิ่มใน com.aspose.slides.ICommentAuthorCollection**
เมธอด ICommentAuthorCollection.removeAt(int) ถูกเพิ่มเพื่อใช้ลบผู้เขียนตามดัชนีที่ระบุ. เมธอด ICommentAuthorCollection.remove(ICommentAuthor) ถูกเพิ่มเพื่อใช้ลบผู้เขียนที่ระบุจากคอลเลกชัน. เมธอด ICommentAuthorCollection.clear() ถูกเพิ่มเพื่อใช้ลบรายการทั้งหมดจากคอลเลกชัน.