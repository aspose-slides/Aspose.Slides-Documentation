---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันทวนย้อนหลังใน Aspose.Slides สำหรับ .NET 15.7.0
linktitle: Aspose.Slides สำหรับ .NET 15.7.0
type: docs
weight: 180
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- การย้ายข้อมูล
- โค้ดแบบเก่า
- โค้ดสมัยใหม่
- วิธีการแบบเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้หยุดทำงานใน Aspose.Slides สำหรับ .NET เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่นำมาใช้ใน Aspose.Slides for .NET 15.7.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Enum ImagePixelFormat ถูกเพิ่ม**
Enum Aspose.Slides.Export.ImagePixelFormat ถูกเพิ่มเพื่อกำหนดรูปแบบพิกเซลสำหรับภาพที่สร้างขึ้น.
#### **Method IChartDataPoint.GetAutomaticDataPointColor() ถูกเพิ่ม**
คืนค่าสีอัตโนมัติของจุดข้อมูลโดยอิงจากดัชนีซีรีส์, ดัชนีจุดข้อมูล, ParentSeriesGroup, คุณสมบัติ IsColorVaried และสไตล์ของแผนภูมิ.
สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType มีค่าเท่ากับ NotDefined.
#### **Method RenderToGraphics ถูกเพิ่มใน Slide**
Method RenderToGraphics (และ overload ของมัน) ถูกเพิ่มใน Aspose.Slides.Slide เพื่อเรนเดอร์สไลด์เป็นอ็อบเจ็กต์ Graphics.
#### **Property PixelFormat ถูกเพิ่มใน ITiffOptions และ TiffOptions**
Property PixelFormat ถูกเพิ่มใน Aspose.Slides.Export.ITiffOptions และ Aspose.Slides.Export.TiffOptions เพื่อกำหนดรูปแบบพิกเซลสำหรับภาพ TIFF ที่สร้างขึ้น.