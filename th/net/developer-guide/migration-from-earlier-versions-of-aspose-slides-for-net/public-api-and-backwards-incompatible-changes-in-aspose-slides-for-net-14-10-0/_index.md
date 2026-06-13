---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.10.0
linktitle: Aspose.Slides สำหรับ .NET 14.10.0
type: docs
weight: 120
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดใหม่
- วิธีการเก่า
- วิธีการใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการพับใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, พร็อพเพอร์ตี ฯลฯ ที่ถูก[added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)หรือ[removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน API ของ Aspose.Slides for .NET 14.10.0
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **ประเภทฟิลด์ Footer ของ Aspose.Slides.FieldType ถูกเพิ่ม**
ประเภทฟิลด์ Footer ถูกเพิ่มเพื่อให้สามารถสร้างฟิลด์ประเภทนี้ได้และเพื่อการซีเรียลไลเซชันของพรีเซนเทชันที่ถูกต้อง
#### **อิลิเมนต์ enum ShapeElementFillSource.Own ถูกลบ**
อิลิเมนต์ enum ShapeElementFillSource.Own ถูกลบเนื่องจากซ้ำกัน ให้ใช้ ShapeElementFillSource.Shape แทน ShapeElementFillSource.Own
#### **เมธอดสำหรับการลบจุดข้อมูลแผนภูมิและหมวดหมู่ได้ถูกเพิ่ม**
เมธอดต่อไปนี้ซึ่งอนุญาตให้ลบจุดข้อมูลแผนภูมิจากคอลเลกชันของจุดข้อมูลแผนภูมิได้ถูกเพิ่ม:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

เมธอดต่อไปนี้ซึ่งอนุญาตให้ลบหมวดหมู่แผนภูมิจากคอลเลกชันที่บรรจุได้ถูกเพิ่ม:

IChartCategory.Remove()

``` csharp

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

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **คุณสมบัติ Aspose.Slides.ParagraphFormat ที่ล้าสมัยถูกลบ**
คุณสมบัติ BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle ถูกลบออกแล้ว เนื่องจากได้ถูกทำเครื่องหมายว่า obsolete มานานแล้ว
#### **คอนสตรัคเตอร์ที่ไม่มีประโยชน์และล้าสมัยถูกลบ**
คอนสตรัคเตอร์ต่อไปนี้ถูกลบ:

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