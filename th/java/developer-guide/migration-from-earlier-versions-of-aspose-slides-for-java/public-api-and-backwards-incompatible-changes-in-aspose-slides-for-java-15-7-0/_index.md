---
title: API สาธารณะและการเปลี่ยนแปลงที่เข้ากันไม่ได้ย้อนหลังใน Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides สำหรับ Java 15.7.0
type: docs
weight: 150
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดข้อขัดแย้งใน Aspose.Slides for Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่ [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) หรือ [removed](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) ทั้งหมด, รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่นำมาใช้ใน Aspose.Slides for Java 15.7.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **ได้เพิ่ม Enum com.aspose.slides.ImagePixelFormat**
Enum com.aspose.slides.ImagePixelFormat ได้เพิ่มเพื่อระบุรูปแบบพิกเซลสำหรับภาพที่สร้างขึ้น.
#### **ได้เพิ่มเมธอด com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor()**
เมธอดนี้คืนค่าสีอัตโนมัติของจุดข้อมูลโดยอิงจากดัชนีซีรีส์, ดัชนีจุดข้อมูล, parentSeriesGroup, ค่าของ isColorVaried และสไตล์ของแผนภูมิ. สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก fillType เท่ากับ NotDefined.
#### **ได้เพิ่มเมธอด getPixelFormat(), setPixelFormat(int) ไปยัง com.aspose.slides.ITiffOptions**
เมธอด getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) ได้เพิ่มไปยัง com.aspose.slides.ITiffOptions และ com.aspose.slides.TiffOptions เพื่อระบุรูปแบบพิกเซลสำหรับภาพ TIFF ที่สร้างขึ้น.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```