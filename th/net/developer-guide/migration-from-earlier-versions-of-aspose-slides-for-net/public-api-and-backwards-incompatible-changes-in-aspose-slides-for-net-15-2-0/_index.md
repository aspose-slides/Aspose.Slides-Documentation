---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 15.2.0
linktitle: Aspose.Slides สำหรับ .NET 15.2.0
type: docs
weight: 140
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- การย้าย
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการแบบเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้ใช้งานไม่ได้ใน Aspose.Slides for .NET เพื่อย้ายโซลูชั่นงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติและอื่น ๆ ที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **เพิ่มเมธอด AddDataPointForDoughnutSeries**
เมธอด IChartDataPointCollection.AddDataPointForDoughnutSeries() สองรูปแบบได้ถูกเพิ่มเพื่อเพิ่มข้อมูลจุดลงในซีรีส์ของแผนภูมิดอนัท
#### **คลาส Aspose.Slides.SmartArt.SmartArtShape ได้รับการสืบทอดจากคลาส Aspose.Slides.GeometryShape**
คลาส Aspose.Slides.SmartArt.SmartArtShape ได้รับการสืบทอดจากคลาส Aspose.Slides.GeometryShape การเปลี่ยนแปลงนี้ทำให้โมเดลวัตถุของ Aspose.Slides ปรับปรุงและเพิ่มคุณลักษณะใหม่ให้กับคลาส SmartArtShape
#### **เพิ่มเมธอดสำหรับการลบจุดข้อมูลและหมวดหมู่ของแผนภูมิตามดัชนี**
เมธอด IChartDataPointCollection.RemoveAt(int index) ถูกเพิ่มเพื่อทำการลบจุดข้อมูลของแผนภูมิตามดัชนีของมัน  
เมธอด IChartCategoryCollection.RemoveAt(int index) ถูกเพิ่มเพื่อทำการลบหมวดหมู่ของแผนภูมิตามดัชนีของมัน
#### **เพิ่มค่า PptXPptY ไปยังการนับประเภท PropertyType ของ Aspose.Slides.Animation**
ค่า PptXPptY ได้ถูกเพิ่มไปยังการนับประเภท PropertyType ของ Aspose.Slides.Animation เพื่อแก้ไขปัญหาการทำซีเรียลไลซ์
#### **เพิ่มเมธอด GetAutomaticSeriesColor() ของ System.Drawing.Color ไปยัง Aspose.Slides.Charts.IChartSeries**
เมธอด GetAutomaticSeriesColor() จะคืนค่าสีอัตโนมัติของซีรีส์ตามดัชนีของซีรีส์และสไตล์ของแผนภูมิ สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType เท่ากับ NotDefined

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```