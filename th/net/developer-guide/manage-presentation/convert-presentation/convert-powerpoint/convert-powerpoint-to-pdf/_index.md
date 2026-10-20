---
title: แปลง PPT และ PPTX เป็น PDF ใน .NET [รวมคุณสมบัติขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/net/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและค้นหาได้ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย C# มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของรูปภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การป้องกันไฟล์ PDF ด้วยรหัสผ่าน การตรวจจับการทดแทนฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เปิดเผยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ที่โดยปกติใช้ในการแปลงงานนำเสนอเป็น PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ .NET จะใส่ข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือลบข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ให้คุณแปลง:
* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ถูกเรนเดอร์อย่างแม่นยำในกระบวนการแปลง รวมถึง:
* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์แสดงหัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose มีเครื่องมือแปลง PowerPoint เป็น PDF ฟรี [**เครื่องมือแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง — คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — ที่ทำให้คุณปรับแต่ง PDF ที่ได้, ล็อก PDF ด้วยรหัสผ่าน, หรือระบุวิธีที่กระบวนการแปลงจะดำเนินต่อ

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกกำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์, ระบุวิธีการจัดการเมตาฟายล์, ตั้งค่าระดับการบีบอัดสำหรับข้อความ, กำหนด DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งคุณภาพ JPEG เป็น 90, ความละเอียดภาพเป็น 300 DPI, เมตาฟายล์บันทึกเป็น PNG, และบีบอัดข้อความแบบ Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่องานนำเสนอมีรูปถ่ายหรือภาพหน้าจอจำนวนมาก การลดขนาดของ PDF ที่ส่งออกจะทำให้สะดวกต่อการส่งอีเมลหรือดาวน์โหลด ตั้งค่า [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) เป็น `true` เพื่อให้ระบบเลือกอัลกอริทึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างการส่งออก PDF.

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่แล้ว, เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ, และบันทึกเป็นเอกสาร PDF การตั้งค่าการส่งออก PDF อื่น ๆ จะคงค่าตั้งต้นไว้

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

ตัวเลือกนี้เลือกอัลกอริธึมการบีบอัดสำหรับแต่ละภาพ การลดค่า [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) จะทำให้คุณภาพภาพ JPEG ลดลง, ในขณะที่การลดค่า [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) จะทำให้ภาพถูกลดความละเอียดลง ซึ่งอาจทำให้รายละเอียดลดน้อยลง การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติไม่ได้ทำให้ค่าทั้งสองนี้ลดลงโดยอัตโนมัติ

การเลือกอัลกอริธึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพและการตั้งค่าการส่งออกของงานนำเสนอ; การลดขนาดที่คงที่ไม่สามารถรับประกันได้สำหรับทุกงานนำเสนอ

### **รักษาไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กนั้นรวมถึงดูสไลด์ได้ ตั้งค่า [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) เป็น `true` เพื่อรักษาไฟล์ OLE ที่ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มไฟล์ข้อมูลเข้าไปด้วย ตัวอย่างยังคงเป็นภาพแสดงผล; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกจากกันได้ อ็อบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมไฟล์แนบของเวิร์กบุ๊ก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

เพื่อตรวจสอบผลลัพธ์:
1. เปิด PDF ที่ส่งออกในโปรแกรมที่สนับสนุนไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูลของมัน หรือเปิดโดยตรงหากโปรแกรมอนุญาต ตัวอย่างบนหน้า PDF เป็นส่วนแยกจากไฟล์แนบ.

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ไม่อนุญาตไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่น รวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF ค่าเริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A.
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้คุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยรวมสไลด์ที่ซ่อนอยู่ทั้งหมด.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงอนุญาตให้พิมพ์ รวมถึงการพิมพ์คุณภาพสูง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **ตรวจจับการทดแทนฟอนต์**

Aspose.Slides มีคุณสมบัติ [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ภายในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ที่ทำให้คุณสามารถตรวจจับการทดแทนฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการทดแทนฟอนต์ไปยังคอนโซล คำเตือนจะแสดงเฉพาะเมื่อฟอนต์ที่ไม่พร้อมใช้งานถูกทดแทนในระหว่างการส่งออก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการทดแทนฟอนต์ ดูบทความ [Font Substitution](/slides/th/net/font-substitution/)
{{% /alert %}}

### **จัดการฟอนต์ที่ไม่มีรูปแบบตัวหนาเฉพาะ**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนาสำหรับข้อความแม้ฟอนต์นั้นไม่มีรูปแบบตัวหนาเฉพาะ ข้อความยังคงแสดงเป็นตัวหนาด้วยการทำให้ตัวอักษรหนาขึ้นแบบสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น หากข้อความนั้นดูหนาเกินไปหรือแตกต่างจากที่ต้องการใน PDF ให้ลองตั้งค่า [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) เป็น `true` ตัวเลือกนี้เรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจทำให้ลักษณะของฟอนต์บางตัวดีขึ้น ค่าเริ่มต้นคือ `false`.

งานนำเสนอทดลองมีสองกล่องข้อความ: หนึ่งเป็นข้อความปกติและหนึ่งมีการจัดรูปแบบตัวหนาที่ใช้ฟอนต์เดียวกัน ซึ่งไม่มีรูปแบบตัวหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการราสเตอร์รูปแบบฟอนต์ที่ไม่รองรับ, และส่งออกเป็น PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

ตัวอย่างแสดงผลลัพธ์ที่ปิดใช้งานและที่เปิดใช้งาน ตัวอย่างนี้ข้อความตัวหนาจะมีเส้นหนากว่าตอนที่ปิดตัวเลือก เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนาเป็นบิทแมพเท่านั้น: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความโดยไม่มี OCR, และขอบของมันดูนุ่มขึ้นที่การซูม 800% ข้อความปกติยังคงสามารถค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะเป็นข้อความ

ตัวเลือกนี้ทำให้ข้อความที่จัดรูปแบบเป็นตัวหนาถูกราสเตอร์เมื่อฟอนต์ไม่มีรูปแบบตัวหนาเฉพาะ [Font substitution](/slides/th/net/font-substitution/) จะเลือกฟอนต์อื่นแทนเมื่อฟอนต์เดิมไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้เริ่มนับจากหนึ่ง และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 พอยต์ (8.5 × 11 นิ้ว) มันปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน้ตของผู้พูดสำหรับแต่ละสไลด์ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C# นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่ผลิต PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides รองรับการดำเนินการแปลง PDF ต่าง ๆ ทำให้คุณสามารถแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ที่นิยมได้ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) และ [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) ได้ การแปลง PDF ไปเป็นรูปแบบเฉพาะอื่น ๆ — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — ก็ได้รับการสนับสนุนเช่นกัน.
{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อน เช่น SmartArt, แผนภูมิ, และสูตรว่าเป็นรูปเดียว ส่วนองค์ประกอบของเส้นทางแต่ละอันจะไม่ถูกเก็บเป็นเนื้อหาแยกต่างหากและอาจถูกทำเครื่องหมายเป็นสิ่งแปลกปลอม; ข้อความแทนที่จะให้เฉพาะกับรูปทั้งหมด

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นกลุ่มได้หรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX จำนวนหลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและดำเนินการแปลงโดยใช้โปรแกรม

**สามารถตั้งรหัสผ่านป้องกัน PDF ที่แปลงแล้วได้หรือไม่?**  
ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**  
ตั้งคุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เป็น `true` เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ใช่, คุณสามารถควบคุมคุณภาพของภาพโดยตั้งค่าคุณสมบัติเช่น [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) และ [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับหลายมาตรฐาน รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA ทำให้เอกสารของคุณตอบสนองความต้องการด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ .NET](/slides/th/net/)
- [อ้างอิง API Aspose.Slides สำหรับ .NET](https://reference.aspose.com/slides/net/)
- [เครื่องแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)