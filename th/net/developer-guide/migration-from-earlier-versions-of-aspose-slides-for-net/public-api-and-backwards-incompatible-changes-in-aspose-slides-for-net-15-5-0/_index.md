---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 15.5.0
linktitle: Aspose.Slides for .NET 15.5.0
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
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เสียหายใน Aspose.Slides for .NET เพื่อช่วยให้คุณย้ายโซลูชั่นการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณได้อย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติและอื่น ๆ ทั้งหมดที่ถูก [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.5.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **คลาส CommonSlideViewProperties และอินเทอร์เฟซ ICommonSlideViewProperties ถูกเพิ่ม**
คลาส Aspose.Slides.CommonSlideViewProperties และอินเทอร์เฟซ Aspose.Slides.ICommonSlideViewProperties แสดงคุณสมบัติวิวสไลด์ทั่วไป (ขณะนี้เป็นตัวเลือกการสเกลวิว)

#### **คุณสมบัติ IAxis.LabelOffset ถูกเพิ่ม**
คุณสมบัติ IAxis.LabelOffset ระบุระยะห่างของป้ายกำกับจากแกน ใช้กับแกนประเภทหรือแกนวันที่

#### **คุณสมบัติ IChartTextBlockFormat.AutofitType ถูกเพิ่ม**
การเปลี่ยนแปลงคุณสมบัตินี้อาจมีผลเฉพาะกับส่วนของแผนภูมิดังต่อไปนี้: DataLabel และ DataLabelFormat (สนับสนุนเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 ไม่มีผลต่อการเรนเดอร์)

#### **คุณสมบัติ IChartTextBlockFormat.WrapText ถูกเพิ่ม**
การเปลี่ยนแปลงคุณสมบัตินี้อาจมีผลเฉพาะกับส่วนของแผนภูมิดังต่อไปนี้: DataLabel และ DataLabelFormat (สนับสนุนเต็มรูปแบบใน PowerPoint 2007/2013)

#### **คุณสมบัติ Margin ถูกเพิ่มให้กับ IChartTextBlockFormat**
การเปลี่ยนแปลงคุณสมบัตินี้อาจมีผลเฉพาะกับส่วนของแผนภูมิดังต่อไปนี้: DataLabel และ DataLabelFormat (สนับสนุนเต็มรูปแบบใน PowerPoint 2013; ใน PowerPoint 2007 ไม่มีผลต่อการเรนเดอร์)

#### **คุณสมบัติ ViewProperties.NotesViewProperties ถูกเพิ่ม**
คุณสมบัติ Aspose.Slides.ViewProperties.NotesViewProperties ถูกเพิ่ม มีการระบุคุณสมบัติวิวทั่วไปที่เกี่ยวข้องกับโหมดการแสดงหมายเหตุ

#### **คุณสมบัติ ViewProperties.SlideViewProperties ถูกเพิ่ม**
คุณสมบัติ Aspose.Slides.ViewProperties.SlideViewProperties ถูกเพิ่ม มีการระบุคุณสมบัติวิวทั่วไปที่เกี่ยวข้องกับโหมดการแสดงสไลด์