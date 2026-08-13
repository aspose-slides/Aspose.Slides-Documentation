---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.7.0
linktitle: Aspose.Slides สำหรับ .NET 15.7.0
type: docs
weight: 180
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เสียหายใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for .NET 15.7.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Enum ImagePixelFormat ถูกเพิ่มเข้ามา**
Enum Aspose.Slides.Export.ImagePixelFormat ถูกเพิ่มเข้ามาเพื่อระบุรูปแบบพิกเซลสำหรับภาพที่สร้างขึ้น.
#### **เมธอด IChartDataPoint.GetAutomaticDataPointColor() ถูกเพิ่มเข้ามา**
ส่งคืนสีอัตโนมัติของจุดข้อมูลโดยอิงจากดัชนีซีรีส์, ดัชนีจุดข้อมูล, ParentSeriesGroup, IsColorVaried propery และสไตล์แผนภูมิ. สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType มีค่าเท่ากับ NotDefined.
#### **เมธอด RenderToGraphics ถูกเพิ่มเข้ามาใน Slide**
เมธอด RenderToGraphics (และ it's overloads) ถูกเพิ่มเข้ามาใน Aspose.Slides.Slide สำหรับการเรนเดอร์สไลด์ไปยังอ็อบเจกต์ Graphics.
#### **คุณสมบัติ PixelFormat ถูกเพิ่มเข้ามาใน ITiffOptions และ TiffOptions**
คุณสมบัติ PixelFormat ถูกเพิ่มเข้ามาใน Aspose.Slides.Export.ITiffOptions และ Aspose.Slides.Export.TiffOptions เพื่อระบุรูปแบบพิกเซลสำหรับภาพ TIFF ที่สร้างขึ้น.