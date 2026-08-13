---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันของเวอร์ชันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.10.0
linktitle: Aspose.Slides สำหรับ .NET 14.10.0
type: docs
weight: 120
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้ระบบพังใน Aspose.Slides สำหรับ .NET เพื่อช่วยให้คุณย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ได้อย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 14.10.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **เพิ่มประเภทฟิลด์ Aspose.Slides.FieldType.Footer**
ประเภทฟิลด์ Footer ได้ถูกเพิ่มเพื่อการนำไปใช้ในการสร้างฟิลด์ประเภทนี้และสำหรับการทำ serialization พรีเซนเทชันที่ถูกต้อง
#### **ลบรายการ Enum ShapeElementFillSource.Own**
รายการ Enum ShapeElementFillSource.Own ถูกลบเนื่องจากเป็นข้อมูลซ้ำ ใช้ ShapeElementFillSource.Shape แทน ShapeElementFillSource.Own
#### **เพิ่มเมธอดสำหรับการลบจุดข้อมูลกราฟและประเภท**
เมธอดต่อไปนี้ที่อนุญาตให้ลบจุดข้อมูลกราฟจากคอลเลกชันได้ถูกเพิ่มเข้ามา:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

เมธอดต่อไปนี้ที่อนุญาตให้ลบประเภทกราฟจากคอลเลกชันที่บรรจุอยู่ได้ถูกเพิ่มเข้ามา:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ลบด้วย ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ลบด้วย ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//ลบด้วย ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **ลบคุณสมบัติที่ล้าสมัยของ Aspose.Slides.ParagraphFormat**
คุณสมบัติ BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle ถูกลบออก เนื่องจากถูกทำเครื่องหมายว่าเลิกใช้มานานแล้ว
#### **ลบคอนสตรัคเตอร์ที่ไม่ใช้และล้าสมัย**
คอนสตรัคเตอร์ต่อไปนี้ถูกลบออก:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)