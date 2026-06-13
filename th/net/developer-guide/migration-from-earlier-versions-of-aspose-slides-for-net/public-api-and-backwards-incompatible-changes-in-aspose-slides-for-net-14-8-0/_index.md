---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 14.8.0
linktitle: Aspose.Slides สำหรับ .NET 14.8.0
type: docs
weight: 100
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดความไม่เข้ากันใน Aspose.Slides for .NET เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 
หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติและอื่น ๆ ที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) พร้อมกับการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 14.8.0 API.
{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เพิ่มอินเทอร์เฟซ IVbaProject, เปลี่ยนคุณสมบัติ Presentation.VbaProject**
คุณสมบัติ VbaProject ของคลาส Presentation ถูกแทนที่ โดยแทนที่การเป็นไบต์ดิบของโครงการ VBA, มีการเพิ่มการนำเข้าอินเทอร์เฟซ IVbaProject ใหม่

ใช้คุณสมบัติ IVbaProject เพื่อจัดการโครงการ VBA ที่ฝังอยู่ในงานนำเสนอ คุณสามารถเพิ่มอ้างอิงโครงการใหม่, แก้ไขโมดูลที่มีอยู่และสร้างโมดูลใหม่ได้

นอกจากนี้ คุณสามารถสร้างโครงการ VBA ใหม่โดยใช้คลาส VbaProject ที่ทำงานร่วมกับอินเทอร์เฟซ IVbaProject

ตัวอย่างต่อไปนี้แสดงการสร้างโครงการ VBA ง่ายที่มีหนึ่งโมดูลและเพิ่มอ้างอิงที่จำเป็นสองรายการไปยังไลบรารี

``` csharp

 using (Presentation pres = new Presentation())

{

    // สร้าง VBA Project ใหม่

    pres.VbaProject = new VbaProject();

    // เพิ่มโมดูลเปล่าไปยัง VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // ตั้งค่าโค้ดต้นทางของโมดูล

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

    // เพิ่มการอ้างอิงไปยัง VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 
ตัวอย่างนี้แสดงวิธีคัดลอกโครงการ VBA จากงานนำเสนอที่มีอยู่ไปยังงานนำเสนอใหม่

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **เพิ่มอินเทอร์เฟซ, คุณสมบัติและค่าตัวเลือกของ Enumeration**
#### **เพิ่มคุณสมบัติ Aspose.Slides.Charts.IChartSeries.Overlap**
คุณสมบัติ Aspose.Slides.Charts.IChartSeries.Overlap ระบุว่าคอลัมน์และแถบควรทับกันเท่าใดในแผนภูมิ 2D (ค่าระหว่าง -100 ถึง 100)

นี่เป็นคุณสมบัติไม่เพียงของชุดข้อมูลนี้เท่านั้น แต่ของชุดข้อมูลทั้งหมดในกลุ่มชุดข้อมูลแม่ - เป็นการฉายคุณสมบัติของกลุ่มที่เกี่ยวข้อง ดังนั้นคุณสมบัตินี้เป็นแบบอ่านอย่างเดียว

- ใช้คุณสมบัติ ParentSeriesGroup เพื่อเข้าถึงกลุ่มชุดข้อมูลแม่
- ใช้คุณสมบัติ ParentSeriesGroup.Overlap แบบอ่าน/เขียนเพื่อเปลี่ยนค่า

``` csharp

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
คุณสมบัติ Aspose.Slides.Charts.IChartSeriesGroup.Overlap ระบุว่าคอลัมน์และแถบควรทับกันเท่าใดในแผนภูมิ 2D (ค่าระหว่าง -100 ถึง 100)

``` csharp



using (Presentation pres = new Presentation())

{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
   IChartSeriesCollection series = chart.ChartData.Series;
   series[0].ParentSeriesGroup.Overlap = -30;
}
``` 
#### **เพิ่มค่า Enum ShapeThumbnailBounds.Appearance**
วิธีการสร้างรูปย่อของรูปร่างนี้ทำให้คุณสามารถสร้างรูปย่อของรูปร่างภายในขอบเขตของการปรากฏของมันได้ คิดรวมเอาเอฟเฟกต์ของรูปร่างทั้งหมดไว้ด้วย รูปย่อที่สร้างขึ้นจะถูกจำกัดโดยขอบเขตของสไลด์

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```