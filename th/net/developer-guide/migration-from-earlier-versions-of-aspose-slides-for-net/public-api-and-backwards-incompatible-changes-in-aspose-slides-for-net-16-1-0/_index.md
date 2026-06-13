---
title: การเปลี่ยนแปลง Public API และความเข้ากันไม่ได้ถอยหลังใน Aspose.Slides สำหรับ .NET 16.1.0
linktitle: Aspose.Slides สำหรับ .NET 16.1.0
type: docs
weight: 220
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides สำหรับ .NET เพื่อการย้ายไปยังโซลูชัน PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้าดานนี้แสดงรายการทั้งหมดของคลาส, เมธอด, property และอื่น ๆ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) แล้ว, รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่นำมาใช้ใน Aspose.Slides for .NET 16.1.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**


#### **เพิ่ม Property RotationAngle ลงในอินเทอร์เฟซ IChartTextBlockFormat และ ITextFrameFormat**
Property RotationAngle ได้ถูกเพิ่มเข้าไปในอินเทอร์เฟซ Aspose.Slides.Charts.IChartTextBlockFormat และ Aspose.Slides.ITextFrameFormat. มันระบุการหมุนแบบกำหนดเองที่ถูกนำไปใช้กับข้อความภายในกล่องขอบเขต.

``` csharp

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