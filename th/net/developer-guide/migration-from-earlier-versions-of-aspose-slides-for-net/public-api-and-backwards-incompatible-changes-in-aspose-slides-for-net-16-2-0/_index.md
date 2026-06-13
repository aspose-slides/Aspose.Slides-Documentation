---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 16.2.0
linktitle: Aspose.Slides สำหรับ .NET 16.2.0
type: docs
weight: 230
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำลายใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ถูก [added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) หรือ [removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่นำเข้ามาใน API ของ Aspose.Slides for .NET 16.2.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **คุณสมบัติ UpdateDateTimeFields และ UpdateSlideNumberFields ถูกลบออกแล้ว**
คุณสมบัติ UpdateDateTimeFields และ UpdateSlideNumberFields ถูกลบออกจากคลาส Aspose.Slides.Presentation และจากอินเทอร์เฟซ Aspose.Slides.IPresentation  
คุณสมบัติ Text ของคลาส Aspose.Slides.TextFrame, Paragraph, Portion และอินเทอร์เฟซ Aspose.Slides.ITextFrame, IParagraph, IPortion จะคืนค่าข้อความที่มีฟิลด์ “datetime” ที่อัปเดตแล้ว  
นอกจากนี้คุณสมบัติ Presentation.DocumentProperties.CreatedTime, LastSavedTime และ LastPrinted ก็กลายเป็นอ่านอย่างเดียวแล้ว  

#### **Enum Slides.Charts.CategoryAxisType ถูกเปลี่ยนเป็น Public**
ใช้ในคุณสมบัติ IAxis.CategoryAxisType และ Axis.CategoryAxisType เพื่อกำหนดประเภทของแกนประเภท  
- CategoryAxisType.Auto – ประเภทแกนประเภทจะถูกกำหนดอัตโนมัติในระหว่างการซีเรียลไลซ์ (พฤติกรรมนี้ยังไม่ได้ทำ)  
- CategoryAxisType.Text – ประเภทแกนประเภทคือ Text  
- CategoryAxisType.Date – ประเภทแกนประเภทคือ DateTime  

#### **การสกัดข้อความอย่างรวดเร็ว**
เมธอดสแตติกใหม่ GetPresentationText ถูกเพิ่มเข้าไปในคลาส Presentation มีการโอเวอร์โหลดสองแบบสำหรับเมธอดนี้:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

อาร์กิวเมนต์ enum ExtractionMode ระบุโหมดในการจัดระเบียบผลลัพธ์ของข้อความและสามารถตั้งค่าเป็นค่าต่อไปนี้:  
- Unarranged – ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์  
- Arranged – ข้อความจะจัดตำแหน่งตามลำดับเดียวกับบนสไลด์  

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ เนื่องจากเร็วกว่าโหมด Arranged  

PresentationText แสดงข้อความดิบที่สกัดจากพรีเซนเทชัน มีคุณสมบัติ SlidesText จากเนมสเปซ Aspose.Slides.Util ซึ่งคืนค่าอาร์เรย์ของอ็อบเจ็กต์ ISlideText ทุกอ็อบเจ็กต์แสดงข้อความบนสไลด์ที่สอดคล้องกัน อ็อบเจ็กต์ ISlideText มีคุณสมบัติดังต่อไปนี้:  

- ISlideText.Text – ข้อความบนรูปร่างของสไลด์  
- ISlideText.MasterText – ข้อความบนรูปร่างของมาสเตอร์เพจสำหรับสไลด์นี้  
- ISlideText.LayoutText – ข้อความบนรูปร่างของเลย์เอาท์เพจสำหรับสไลด์นี้  
- ISlideText.NotesText – ข้อความบนรูปร่างของโน๊ตเพจสำหรับสไลด์นี้  

นอกจากนี้ยังมีคลาส SlideText ที่ทำการ 구현อินเทอร์เฟซ ISlideText

ตัวอย่างการใช้ API ใหม่:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **อินเทอร์เฟซ ILegacyDiagram และคลาส LegacyDiagram ถูกเพิ่มเข้ามา**
อินเทอร์เฟซ Aspose.Slides.ILegacyDiagram และคลาส Aspose.Slides.LegacyDiagram ถูกเพิ่มเพื่อเป็นตัวแทนของอ็อบเจ็กต์ไดอะแกรมแบบเก่า ไดอะแกรมแบบเก่าเป็นรูปแบบของไดอะแกรมจาก PowerPoint 97‑2003  
คลาสใหม่ให้เมธอดสำหรับแปลงไดอะแกรมแบบเก่าเป็นอ็อบเจ็กต์ SmartArt ที่แก้ไขได้ทันสมัยหรือเป็น GroupShape ที่แก้ไขได้  

#### **เพิ่มสมาชิกใหม่ให้กับ Enum Aspose.Slides.TextAlignment (JustifyLow)**
สมาชิกใหม่ของ enum TextAlignment ถูกเพิ่มเข้ามา:  
JustifyLow – การจัดแนวแบบ Kashida ต่ำ  

#### **เพิ่มคุณสมบัติใหม่สำหรับ Aspose.Slides.IOleObjectFrame และ OleObjectFrame**
คุณสมบัติใหม่ถูกเพิ่มไปยังอินเทอร์เฟซ IOleObjectFrame และคลาส OleObjectFrame ที่ทำการอิมพลีเมนต์อินเทอร์เฟซนี้ คุณสมบัติเหล่านี้ใช้เพื่อให้ข้อมูลเกี่ยวกับอ็อบเจ็กต์ที่ฝังอยู่ในพรีเซนเทชัน:  
- EmbeddedFileExtension – คืนค่านามสกุลไฟล์ของอ็อบเจ็กต์ฝังอยู่ปัจจุบันหรือสตริงว่างถ้าอ็อบเจ็กต์ไม่ได้เป็นลิงก์  
- EmbeddedFileLabel – คืนค่าชื่อไฟล์ของอ็อบเจ็กต์ OLE ที่ฝังอยู่  
- EmbeddedFileName – คืนค่าพาธของอ็อบเจ็กต์ OLE ที่ฝังอยู่  

#### **เพิ่มคุณสมบัติ CategoryAxisType ให้กับคลาส IAxis และ Axis**
คุณสมบัติ CategoryAxisType ระบุประเภทของแกนประเภท  

``` csharp

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
#### **เพิ่มคุณสมบัติ ShowLabelAsDataCallout ให้กับคลาส DataLabelFormat และอินเทอร์เฟซ IDataLabelFormat**
คุณสมบัติ ShowLabelAsDataCallout กำหนดว่าป้ายข้อมูลของแผนภูมิกำหนดจะถูกแสดงเป็นข้อมูลคอลาว์เอาต์หรือเป็นป้ายข้อมูล  

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **เพิ่มคุณสมบัติ DrawSlidesFrame ให้กับ PdfOptions และ XpsOptions**
คุณสมบัติ Boolean DrawSlidesFrame ถูกเพิ่มไปยังอินเทอร์เฟซ Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions และคลาสที่เกี่ยวข้อง Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions  
กรอบสีดำรอบแต่ละสไลด์จะถูกวาดหากคุณสมบัตินี้ตั้งค่าเป็น ‘true’

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```