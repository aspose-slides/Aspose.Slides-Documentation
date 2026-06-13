---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.8.0
linktitle: Aspose.Slides สำหรับ .NET 15.8.0
type: docs
weight: 190
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางแบบเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}}

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.8.0 API.

{{% /alert %}}
## **การเปลี่ยนแปลง Public API**
#### **คุณสมบัติ DoughnutHoleSize ถูกเพิ่มใน IChartSeries และ ChartSeries**
ระบุขนาดของช่องว่างในแผนภูมิโดนัท.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```