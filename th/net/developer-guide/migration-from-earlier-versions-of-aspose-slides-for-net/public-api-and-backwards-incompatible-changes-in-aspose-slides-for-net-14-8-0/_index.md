---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.8.0
linktitle: Aspose.Slides สำหรับ .NET 14.8.0
type: docs
weight: 100
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- การย้ายข้อมูล
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
description: "รีวิวการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ .NET เพื่อช่วยให้คุณย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณได้อย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ทั้งที่ [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่เปิดตัวใน API ของ Aspose.Slides for .NET 14.8.0

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เพิ่มอินเทอร์เฟซ IVbaProject, เปลี่ยนแปลงคุณสมบัติ Presentation.VbaProject**
คุณสมบัติ VbaProject ของคลาส Presentation ได้รับการแทนที่ โดยแทนที่การเป็นการแสดงผลไบต์ดิบของโครงการ VBA ด้วยการนำเสนอการใช้งานอินเทอร์เฟซใหม่ IVbaProject

ใช้คุณสมบัติ IVbaProject เพื่อจัดการโครงการ VBA ที่ฝังอยู่ในงานนำเสนอ คุณสามารถเพิ่มอ้างอิงโครงการใหม่ แก้ไขโมดูลที่มีอยู่และสร้างโมดูลใหม่ได้

นอกจากนี้คุณยังสามารถสร้างโครงการ VBA ใหม่โดยใช้คลาส VbaProject ซึ่งทำการนำอินเทอร์เฟซ IVbaProject ไปใช้

ตัวอย่างต่อไปนี้แสดงการสร้างโครงการ VBA อย่างง่ายที่มีโมดูลหนึ่งและเพิ่มอ้างอิงสองรายการที่จำเป็นต่อไลบรารี

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // สร้าง VBA Project ใหม่
    pres.VbaProject = new VbaProject();
    // เพิ่มโมดูลว่างลงใน VBA project
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");
    // กำหนดโค้ดต้นฉบับของโมดูล
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";
    // สร้างการอ้างอิงถึง <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // สร้างการอ้างอิงถึง Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // เพิ่มการอ้างอิงลงใน VBA project
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

ตัวอย่างนี้แสดงวิธีคัดลอกโครงการ VBA จากงานนำเสนอที่มีอยู่ไปยังงานนำเสนอใหม่

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **เพิ่มอินเทอร์เฟซ, คุณสมบัติและตัวเลือกการนับ**
#### **เพิ่มคุณสมบัติ Aspose.Slides.Charts.IChartSeries.Overlap**
คุณสมบัติ Aspose.Slides.Charts.IChartSeries.Overlap ระบุระดับการทับซ้อนของแท่งและคอลัมน์ในแผนภูมิ 2 มิติ (ช่วงตั้งแต่ -100 ถึง 100)

นี่เป็นคุณสมบัติไม่เพียงของซีรีส์นี้ แต่ของทุกซีรีส์ในกลุ่มซีรีส์แม่ ซึ่งเป็นการฉายคุณสมบัติของกลุ่มที่เกี่ยวข้อง ดังนั้นคุณสมบัตินี้เป็นอ่านอย่างเดียว

- ใช้คุณสมบัติ ParentSeriesGroup เพื่อเข้าถึงกลุ่มซีรีส์แม่
- ใช้คุณสมบัติ ParentSeriesGroup.Overlap แบบอ่าน/เขียนเพื่อเปลี่ยนค่า

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **เพิ่มคุณสมบัติ Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
คุณสมบัติ Aspose.Slides.Charts.IChartSeriesGroup.Overlap ระบุระดับการทับซ้อนของแท่งและคอลัมน์ในแผนภูมิ 2 มิติ (ตั้งแต่ -100 ถึง 100)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **เพิ่มค่า Enum ShapeThumbnailBounds.Appearance**
เมธอดการสร้างภาพย่อของรูปร่างนี้อนุญาตให้คุณสร้างภาพย่อของรูปร่างภายในขอบเขตของการแสดงผลของมัน โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```