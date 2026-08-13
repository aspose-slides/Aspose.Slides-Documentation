---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 16.2.0
linktitle: Aspose.Slides สำหรับ .NET 16.2.0
type: docs
weight: 230
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- การย้ายข้อมูล
- โค้ดแบบเดิม
- โค้ดสมัยใหม่
- แนวทางแบบดั้งเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดข้อขัดแย้งใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)หรือ[ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **คุณสมบัติ UpdateDateTimeFields และ UpdateSlideNumberFields ถูกลบออก**
คุณสมบัติ UpdateDateTimeFields และ UpdateSlideNumberFields ถูกลบออกจากคลาส Aspose.Slides.Presentation และจากอินเทอร์เฟซ Aspose.Slides.IPresentation  
คุณสมบัติ Text ของ Aspose.Slides.TextFrame, Paragraph, Portion และอินเทอร์เฟซ Aspose.Slides.ITextFrame, IParagraph, IPortion จะคืนค่าข้อความที่มีฟิลด์ “datetime” ที่อัปเดตแล้ว  
นอกจากนี้คุณสมบัติ Presentation.DocumentProperties.CreatedTime, LastSavedTime และ LastPrinted จะกลายเป็นอ่านอย่างเดียว

#### **Enum Slides.Charts.CategoryAxisType ถูกสลับให้เป็น Public**
ใช้ในคุณสมบัติ IAxis.CategoryAxisType และ Axis.CategoryAxisType เพื่อกำหนดประเภทแกนหมวดหมู่  
CategoryAxisType.Auto - ประเภทแกนหมวดหมู่จะกำหนดโดยอัตโนมัติระหว่างการทำ serialization (พฤติกรรมนี้ยังไม่ได้ implement)  
CategoryAxisType.Text - ประเภทแกนหมวดหมู่เป็น Text  
CategoryAxisType.Date - ประเภทแกนหมวดหมู่เป็น DateTime  

#### **การสกัดข้อความแบบเร็ว**
เมธอดสถิตย์ใหม่ GetPresentationText ถูกเพิ่มเข้าไปในคลาส Presentation มีการ overload สองรูปแบบสำหรับเมธอดนี้:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

อาร์กิวเมนต์ enum ExtractionMode ระบุโหมดการจัดเรียงผลลัพธ์ข้อความและสามารถตั้งเป็นค่าต่อไปนี้ได้:  
Unarranged - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์  
Arranged - ข้อความจะเรียงตามลำดับเดียวกับบนสไลด์  

โหมด Unarranged สามารถใช้เมื่อความเร็วมีความสำคัญ จะเร็วกว่าโหมด Arranged

PresentationText แทนข้อความดิบที่สกัดจากงานนำเสนอ มีคุณสมบัติ SlidesText จากเนมสเปซ Aspose.Slides.Util ที่คืนค่าอาเรย์ของอ็อบเจ็กต์ ISlideText แต่ละอ็อบเจ็กต์แทนข้อความบนสไลด์ที่สอดคล้องกัน ISlideText มีคุณสมบัติดังนี้:

ISlideText.Text - ข้อความบนรูปร่างของสไลด์  
ISlideText.MasterText - ข้อความบนรูปร่างของมาสเตอร์เพจสำหรับสไลด์นี้  
ISlideText.LayoutText - ข้อความบนรูปร่างของเลย์เอาต์เพจสำหรับสไลด์นี้  
ISlideText.NotesText - ข้อความบนรูปร่างของโน้ตเพจสำหรับสไลด์นี้  

นอกจากนี้ยังมีคลาส SlideText ที่ทำหน้าที่เป็นการนำเข้า ISlideText

API ใหม่สามารถใช้ได้ดังนี้:

``` csharp
using System;
using Aspose.Slides;

// สกัดข้อความโดยไม่คำนึงถึงตำแหน่งบนสไลด์ (โหมดที่เร็วที่สุด).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// สกัดข้อความโดยจัดตำแหน่งตามลำดับเดียวกับบนสไลด์.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 

#### **อินเทอร์เฟซ ILegacyDiagram และคลาส LegacyDiagram ถูกเพิ่ม**
อินเทอร์เฟซ Aspose.Slides.ILegacyDiagram และคลาส Aspose.Slides.LegacyDiagram ถูกเพิ่มเพื่อแทนวัตถุแผนภูมิเก่า Legacy diagram คือรูปแบบเก่าของแผนภูมิจาก PowerPoint 97-2003  
คลาสใหม่ให้เมธอดสำหรับแปลง Legacy diagram ให้เป็น SmartArt ที่แก้ไขได้สมัยใหม่หรือเป็น GroupShape ที่แก้ไขได้

#### **สมาชิกใหม่ของ Enum Aspose.Slides.TextAlignment (JustifyLow) ถูกเพิ่ม**
สมาชิกใหม่ของ enum TextAlignment ถูกเพิ่มเข้ามา:  
JustifyLow - การจัดแนวแบบ Kashida ที่ระดับต่ำ

#### **คุณสมบัติใหม่สำหรับ Aspose.Slides.IOleObjectFrame และ OleObjectFrame**
คุณสมบัติใหม่ถูกเพิ่มเข้าไปในอินเทอร์เฟซ IOleObjectFrame และคลาส OleObjectFrame ที่ implements อินเทอร์เฟซนี้ ใช้เพื่อให้ข้อมูลเกี่ยวกับอ็อบเจ็กต์ที่ฝังอยู่ในงานนำเสนอ:  
EmbeddedFileExtension - คืนค่านามสกุลไฟล์ของอ็อบเจ็กต์ฝังอยู่ปัจจุบันหรือสตริงว่างหากอ็อบเจ็กต์ไม่ได้เป็นลิงก์  
EmbeddedFileLabel - คืนชื่อไฟล์ของอ็อบเจ็กต์ OLE ที่ฝังอยู่  
EmbeddedFileName - คืนเส้นทางของอ็อบเจ็กต์ OLE ที่ฝังอยู่  

#### **คุณสมบัติ CategoryAxisType ถูกเพิ่มในคลาส IAxis และ Axis**
คุณสมบัติ CategoryAxisType กำหนดประเภทของแกนหมวดหมู่

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **คุณสมบัติ ShowLabelAsDataCallout ถูกเพิ่มในคลาส DataLabelFormat และอินเทอร์เฟซ IDataLabelFormat**
คุณสมบัติ ShowLabelAsDataCallout กำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น data callout หรือเป็น data label

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **คุณสมบัติ DrawSlidesFrame ถูกเพิ่มใน PdfOptions และ XpsOptions**
คุณสมบัติแบบ Boolean DrawSlidesFrame ถูกเพิ่มเข้าไปในอินเทอร์เฟซ Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions และในคลาสที่สอดคล้อง Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions  
กรอบสีดำรอบแต่ละสไลด์จะถูกวาดหากตั้งค่าคุณสมบัตินี้เป็น 'true'

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```