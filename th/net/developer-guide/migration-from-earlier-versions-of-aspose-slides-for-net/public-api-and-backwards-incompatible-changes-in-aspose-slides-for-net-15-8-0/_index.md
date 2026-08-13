---
title: การเปลี่ยนแปลง API สาธารณะและไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.8.0
linktitle: Aspose.Slides สำหรับ .NET 15.8.0
type: docs
weight: 190
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้แตกต่างใน Aspose.Slides สำหรับ .NET เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ถูก[added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)หรือ[removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)ทั้งหมด รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.8.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **คุณสมบัติ DoughnutHoleSize ได้รับการเพิ่มไปยัง IChartSeries และ ChartSeries**
ระบุขนาดของรูในแผนภูมโดนัท.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```