---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides สำหรับ .NET 15.11.0
type: docs
weight: 210
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ .NET เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณได้อย่างราบรื่น"
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)หรือ[ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) และการเปลี่ยนแปลงอื่น ๆ ที่นำมาใช้กับ Aspose.Slides for .NET 15.11.0 API
{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**

#### **คุณสมบัติที่ล้าสมัยในคลาส DataLabelCollection ถูกลบ**
คุณสมบัติที่ล้าสมัยในคลาส DataLabelCollection ถูกลบ:
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

#### **คุณสมบัติใหม่ FirstSlideNumber ถูกเพิ่มในคลาส Presentation**
คุณสมบัติใหม่ FirstSlideNumber ที่เพิ่มใน Presentation ทำให้สามารถรับหรือกำหนดหมายเลขสไลด์แรกของงานนำเสนอได้

เมื่อกำหนดค่าของ FirstSlideNumber ใหม่ หมายเลขสไลด์ทั้งหมดจะถูกคำนวณใหม่

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```