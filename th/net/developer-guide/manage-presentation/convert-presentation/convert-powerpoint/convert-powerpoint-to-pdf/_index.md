---
title: "แปลง PPT และ PPTX เป็น PDF ใน .NET [รวมคุณสมบัติเพิ่มเติม]"
linktitle: "PowerPoint เป็น PDF"
type: docs
weight: 40
url: /th/net/convert-powerpoint-to-pdf/
keywords:
- "แปลง PowerPoint"
- "แปลงงานนำเสนอ"
- "PowerPoint เป็น PDF"
- "งานนำเสนอเป็น PDF"
- "PPT เป็น PDF"
- "แปลง PPT เป็น PDF"
- "PPTX เป็น PDF"
- "แปลง PPTX เป็น PDF"
- "บันทึก PowerPoint เป็น PDF"
- "บันทึก PPT เป็น PDF"
- "บันทึก PPTX เป็น PDF"
- "ส่งออก PPT เป็น PDF"
- "ส่งออก PPTX เป็น PDF"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและสามารถค้นหาได้ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# อย่างรวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน C# มีประโยชน์หลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการคงรูปแบบการจัดวางและการจัดรูปแบบของงานนำเสนอ คู่มือฉบับนี้แสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF, ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ, รวมสไลด์ที่ซ่อนอยู่, รหัสผ่านป้องกันไฟล์ PDF, ตรวจจับการแทนที่แบบอักษร, เลือกสไลด์เฉพาะสำหรับการแปลง, และใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด[Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/). คลาส[Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)เปิดเผยเมธอด[Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/)ซึ่งมักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides สำหรับ .NET จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่นเมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะใส่ค่าในฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer เป็นค่าในรูปแบบ "*Aspose.Slides v XX.XX*". **หมายเหตุ** คุณไม่สามารถสั่ง Aspose.Slides ให้เปลี่ยนหรือลบข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF อย่างแม่นยำ ทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมเป็นอย่างดี รายการและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างถูกต้องในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* รายการหัวข้อสัญลักษณ์
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint ไปเป็น PDF แบบมาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้มาเป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) ไปเป็น PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
using var presentation = new Presentation("PowerPoint.ppt");

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose มีเครื่องมือออนไลน์ฟรี[**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf)ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดลองใช้เครื่องมือนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายในที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง—properties ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้, ล็อก PDF ด้วยรหัสผ่าน, หรือระบุวิธีการดำเนินกระบวนการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

ด้วยตัวเลือกการแปลงที่กำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์, ระบุวิธีการจัดการ metafiles, ตั้งค่าระดับการบีบอัดสำหรับข้อความ, กำหนด DPI สำหรับภาพ, และอื่น ๆ

โค้ดตัวอย่างด้านล่างแสดงวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น PDF พร้อมตัวเลือกกำหนดเองหลายอย่าง:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส PdfOptions.
var pdfOptions = new PdfOptions
{
    // ตั้งค่าคุณภาพสำหรับภาพ JPG.
    JpegQuality = 90,

    // ตั้งค่า DPI สำหรับภาพ.
    SufficientResolution = 300,

    // ตั้งค่าพฤติกรรมสำหรับเมตาฟายล์.
    SaveMetafilesAsPng = true,

    // ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
    TextCompression = PdfTextCompression.Flate,

    // กำหนดโหมดการปฏิบัติตาม PDF.
    Compliance = PdfCompliance.Pdf15
};

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// บันทึกงานนำเสนอเป็นเอกสาร PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้ property[ShowHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/showhiddenslides/)จากคลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ผลลัพธ์

โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น PDF โดยรวมสไลด์ที่ซ่อนอยู่ด้วย:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
var pdfOptions = new PdfOptions();

// เพิ่มสไลด์ที่ซ่อนอยู่.
pdfOptions.ShowHiddenSlides = true;

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

โค้ด C# นี้สาธิตวิธีแปลงงานนำเสนอ PowerPoint ให้เป็น PDF ที่มีการป้องกันด้วยรหัสผ่านโดยใช้พารามิเตอร์การป้องกันจากคลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
using var presentation = new Presentation("PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions
var pdfOptions = new PdfOptions();

// ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// บันทึกงานนำเสนอเป็น PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มี property[WarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/warningcallback/) ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ด C# นี้แสดงวิธีตรวจจับการแทนที่ฟอนต์:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument 
    using var presentation = new Presentation("sample.pptx");

    // ตั้งค่า callback คำเตือนในตัวเลือก PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// การทำงานของ callback คำเตือน.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับ callback สำหรับการแทนที่ฟอนต์ระหว่างการเรนเดอร์ โปรดดู[Getting Warning Callbacks for Fonts Substitution](/slides/th/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ[Font Substitution](/slides/th/net/font-substitution/)

{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ด C# นี้สาธิตวิธีแปลงเฉพาะสไลด์ที่เลือกจากงานนำเสนอ PowerPoint ไปเป็น PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PowerPoint หรือ OpenDocument
using var presentation = new Presentation("PowerPoint.pptx");

// ตั้งค่าอาเรย์ของหมายเลขสไลด์
int[] slides = { 1, 3 };

// บันทึกงานนำเสนอเป็น PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

โค้ด C# นี้สาธิตวิธีแปลงงานนำเสนอ PowerPoint ไปเป็น PDF ด้วยขนาดสไลด์ที่ระบุ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ในมุมมองบันทึกสไลด์**

โค้ด C# นี้สาธิตวิธีแปลงงานนำเสนอ PowerPoint ให้เป็น PDF ที่รวมบันทึกสไลด์ไว้ด้วย:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// โหลดงานนำเสนอ PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// กำหนดค่าตัวเลือก PDF ด้วยการจัดเค้าโครงบันทึก.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึก.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). คุณสามารถส่งออกเอกสาร PowerPoint ไปเป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ด C# นี้สาธิตกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่ต่างกัน:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides รองรับการแปลง PDF ให้เป็นรูปแบบไฟล์ยอดนิยมต่าง ๆ คุณสามารถทำการแปลง[PDF to HTML](https://products.aspose.com/slides/th/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/net/conversion/pdf-to-jpg/), และ[PDF to PNG](https://products.aspose.com/slides/th/net/conversion/pdf-to-png/)ได้ อีกทั้งยังรองรับการแปลง PDF ไปเป็นรูปแบบพิเศษเช่น[PDF to SVG](https://products.aspose.com/slides/th/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/net/conversion/pdf-to-tiff/), และ[PDF to XML](https://products.aspose.com/slides/th/net/conversion/pdf-to-xml/)ด้วย

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปทรงเดียว ไม่เก็บส่วนประกอบของเส้นทางเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น artefact; ข้อความแทนที่จะถูกจัดให้เฉพาะรูปทรงทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

### สามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF แบบกลุ่มได้หรือไม่?

ได้, Aspose.Slides รองรับการแปลงหลายไฟล์ PPT หรือ PPTX เป็น PDF ทีละหลายไฟล์ คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโปรแกรมได้

### สามารถตั้งค่าการป้องกันด้วยรหัสผ่านให้กับไฟล์ PDF ที่แปลงแล้วได้หรือไม่?

แน่นอน ใช้คลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)เพื่อกำหนดรหัสผ่านและสิทธิ์การเข้าถึงในกระบวนการแปลง

### จะใส่สไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?

ตั้งค่า property`ShowHiddenSlides`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)เป็น`true`เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่สร้างขึ้น

### Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?

ได้, คุณสามารถควบคุมคุณภาพภาพโดยตั้งค่า propertyเช่น`JpegQuality`และ`SufficientResolution`ในคลาส[PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

### Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?

ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตอบสนองต่อข้อกำหนดการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for .NET Documentation](/slides/th/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/th/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/th/conversion)