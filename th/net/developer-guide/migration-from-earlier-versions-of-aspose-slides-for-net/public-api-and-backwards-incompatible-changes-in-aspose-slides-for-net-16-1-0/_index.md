---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 16.1.0
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางแบบดั้งเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้การทำงานเสียหายใน Aspose.Slides for .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ถูก [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**


#### **คุณสมบัติ RotationAngle ถูกเพิ่มเข้ามาในอินเทอร์เฟซ IChartTextBlockFormat และ ITextFrameFormat**
คุณสมบัติ RotationAngle ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ Aspose.Slides.Charts.IChartTextBlockFormat และ Aspose.Slides.ITextFrameFormat.
มันระบุการหมุนแบบกำหนดเองที่ถูกนำไปใช้กับข้อความภายในกล่องขอบเขต.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **OdpException ถูกย้ายจาก Aspose.Slides.Odp ไปยัง Namespace Aspose.Slides**