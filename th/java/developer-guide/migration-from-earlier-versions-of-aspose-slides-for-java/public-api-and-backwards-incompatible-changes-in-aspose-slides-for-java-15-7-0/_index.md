---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการดั้งเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ระบบขัดแย้งใน Aspose.Slides for Java เพื่อทำการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)หรือ[removed](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for Java 15.7.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Enum com.aspose.slides.ImagePixelFormat ได้รับการเพิ่ม**
Enum com.aspose.slides.ImagePixelFormat ได้รับการเพิ่มเพื่อกำหนดรูปแบบพิกเซลสำหรับภาพที่สร้างขึ้น.
#### **เมธอด com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() ได้รับการเพิ่ม**
เมธอดนี้จะคืนค่าสีอัตโนมัติของจุดข้อมูลโดยอิงจากดัชนีซีรี่ส์, ดัชนีจุดข้อมูล, parentSeriesGroup, ค่า isColorVaried และรูปแบบแผนภูมิ. สีกำหนดนี้จะถูกใช้โดยค่าเริ่มต้นหาก fillType มีค่าเท่ากับ NotDefined.
#### **เมธอด getPixelFormat(), setPixelFormat(int) ได้รับการเพิ่มใน com.aspose.slides.ITiffOptions**
ได้เพิ่มเมธอด getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) ใน com.aspose.slides.ITiffOptions และ com.aspose.slides.TiffOptions เพื่อระบุรูปแบบพิกเซลสำหรับภาพ TIFF ที่สร้างขึ้น.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```