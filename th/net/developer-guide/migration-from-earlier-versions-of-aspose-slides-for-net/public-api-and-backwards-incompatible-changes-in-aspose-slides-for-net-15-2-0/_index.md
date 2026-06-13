---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.2.0
linktitle: Aspose.Slides สำหรับ .NET 15.2.0
type: docs
weight: 140
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่เพิ่มหรือถูกลบ, รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.2.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
#### **เมธอด AddDataPointForDoughnutSeries ได้ถูกเพิ่ม**
เมธอดสองเวอร์ชันของ IChartDataPointCollection.AddDataPointForDoughnutSeries() ได้ถูกเพิ่มเพื่อเพิ่มจุดข้อมูลในซีรีส์ของประเภทแผนภูมิสานด์.
#### **คลาส Aspose.Slides.SmartArt.SmartArtShape ได้รับการสืบทอดจากคลาส Aspose.Slides.GeometryShape**
คลาส Aspose.Slides.SmartArt.SmartArtShape ได้รับการสืบทอดจากคลาส Aspose.Slides.GeometryShape. การเปลี่ยนแปลงนี้ปรับปรุงโมเดลวัตถุของ Aspose.Slides และเพิ่มฟีเจอร์ใหม่ให้กับคลาส SmartArtShape.
#### **เพิ่มเมธอดสำหรับการลบจุดข้อมูลแผนภูมิและประเภทแผนภูมิตามดัชนี**
เมธอด IChartDataPointCollection.RemoveAt(int index) ได้ถูกเพิ่มเพื่อทำการลบจุดข้อมูลแผนภูมิตามดัชนีของมัน.
เมธอด IChartCategoryCollection.RemoveAt(int index) ได้ถูกเพิ่มเพื่อทำการลบประเภทแผนภูมิตามดัชนีของมัน.
#### **เพิ่มค่า PptXPptY ใน enumeration Aspose.Slides.Animation.PropertyType**
ค่า PptXPptY ได้ถูกเพิ่มใน enumeration Aspose.Slides.Animation.PropertyType เพื่อแก้ไขปัญหาการทำ serialization.
#### **เพิ่มเมธอด System.Drawing.Color GetAutomaticSeriesColor() ใน Aspose.Slides.Charts.IChartSeries**
เมธอด GetAutomaticSeriesColor จะคืนค่าสีอัตโนมัติของซีรีส์โดยอิงจากดัชนีซีรีส์และสไตล์แผนภูมิ. สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType มีค่าเป็น NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```