---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides สำหรับ .NET 15.11.0
type: docs
weight: 210
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "ทบทวนการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides สำหรับ .NET เพื่อการย้าย PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) ที่เพิ่มหรือที่ถูกลบ, และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำกับ Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**

#### **คุณสมบัติที่ล้าสมัยในคลาส DataLabelCollection ถูกลบ**
Obsolete properties in DataLabelCollection class have been deleted:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **คุณสมบัติใหม่ FirstSlideNumber ถูกเพิ่มเข้าในคลาส Presentation**
The new property FirstSlideNumber added to Presentation allows to get or to set the number of first slide in a presentation.

When a new FirstSlideNumber value is specified all slide numbers are recalculated.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```