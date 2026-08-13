---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.5.0
linktitle: Aspose.Slides สำหรับ .NET 15.5.0
type: docs
weight: 160
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการชะงักใน Aspose.Slides สำหรับ .NET เพื่อการย้าย PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.5.0 API

{{% /alert %}} 
## **Public API Changes**
#### **CommonSlideViewProperties Class and ICommonSlideViewProperties Interface Have Been Added**
คลาส Aspose.Slides.CommonSlideViewProperties และอินเทอร์เฟซ Aspose.Slides.ICommonSlideViewProperties ถูกเพิ่มขึ้นเพื่อแสดงคุณสมบัติการมองเห็นสไลด์โดยรวม (ในปัจจุบันคือตัวเลือกการปรับสเกลการมองเห็น)
#### **IAxis.LabelOffset Property Has Been Added**
คุณสมบัติ IAxis.LabelOffset ระบุระยะห่างของป้ายกำกับจากแกน สามารถใช้กับแกนประเภทหมวดหมู่หรือวันที่
#### **IChartTextBlockFormat.AutofitType Property Has Been Added**
การเปลี่ยนแปลงคุณสมบัตินี้จะส่งผลเฉพาะกับส่วนของแผนภูมิ: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 จะไม่มีผลต่อการเรนเดอร์)
#### **IChartTextBlockFormat.WrapText Property Has Been Added**
การเปลี่ยนแปลงคุณสมบัตินี้จะส่งผลเฉพาะกับส่วนของแผนภูมิ: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2007/2013)
#### **Margin Properties Have Been Added to IChartTextBlockFormat**
การเปลี่ยนแปลงคุณสมบัตินี้จะส่งผลเฉพาะกับส่วนของแผนภูมิ: DataLabel และ DataLabelFormat (รองรับเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 จะไม่มีผลต่อการเรนเดอร์)
#### **ViewProperties.NotesViewProperties Property Has Been Added**
คุณสมบัติ Aspose.Slides.ViewProperties.NotesViewProperties ถูกเพิ่มขึ้น ซึ่งระบุคุณสมบัติการมองเห็นโดยรวมที่เกี่ยวข้องกับโหมดมุมมองบันทึกย่อ
#### **ViewProperties.SlideViewProperties Property Has Been Added**
คุณสมบัติ Aspose.Slides.ViewProperties.SlideViewProperties ถูกเพิ่มขึ้น ซึ่งระบุคุณสมบัติการมองเห็นโดยรวมที่เกี่ยวข้องกับโหมดมุมมองสไลด์