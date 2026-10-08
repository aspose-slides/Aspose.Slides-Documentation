---
title: แปลง PPT และ PPTX เป็น PDF ใน .NET [รวมคุณลักษณะขั้นสูง]
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่สามารถค้นหาได้ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ที่รวดเร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) ไปเป็นรูปแบบ PDF ด้วย C# มีข้อได้เปรียบหลายอย่าง รวมถึงความเข้ากันได้บนอุปกรณ์ต่าง ๆ และการรักษาการจัดเรียงและการจัดรูปแบบของงานนำเสนอ ไกด์นี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการรวมสไลด์ที่ซ่อนไว้ ป้องกันไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารที่ออกมา

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เปิดให้ใช้เมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ซึ่งโดยทั่วไปใช้สำหรับแปลงงานนำเสนอเป็น PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET ใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่นเมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่อยู่ในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** คุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเดิมอย่างใกล้เคียง องค์ประกอบและแอททริบิวต์จะถูกแสดงอย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* สัญลักษณ์รายการ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF ตามมาตรฐานใช้งานตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF โดยใช้การตั้งค่าที่เหมาะที่สุดและคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกเริ่มต้น.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose มีตัวแปลงออนไลน์ฟรี [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติต่าง ๆ ใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่ได้ ล็อค PDF ด้วยรหัสผ่าน หรือระบุวิธีการดำเนินการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์ ระบุวิธีการจัดการ metafiles ตั้งค่าระดับการบีบอัดสำหรับข้อความ ปรับค่า DPI สำหรับภาพ และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG เป็น 90 ความละเอียดภาพเป็น 300 DPI ไฟล์ metafile จะบันทึกเป็น PNG และใช้การบีบอัดข้อความแบบ Flate.

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

### **รักษาไฟล์ OLE ฝังไว้เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีการฝังเวิร์กบุ๊ก Excel คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กและดูสไลด์ได้ ตั้งค่า [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) เป็น `true` เพื่อรักษาไฟล์ OLE ที่ฝังไว้เป็นไฟล์แนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกแสดงบนหน้า PDF แต่ไฟล์ที่ฝังไว้จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มไฟล์ข้อมูลเข้าไป ตัวอย่างยังคงเป็นการแสดงผลภาพเท่านั้น; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกออกได้ อ็อบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

เพื่อเช็คผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมแสดงผลที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader.
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่.
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต การแสดงตัวอย่างบนหน้า PDF จะแยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 จะห้ามไฟล์ฝัง, PDF/A-2 อนุญาตให้มีไฟล์แนบเฉพาะ PDF/A เท่านั้น, และ PDF/A-3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel เหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้คุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่างใน PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF รวมถึงสไลด์ที่ซ่อนทั้งหมด.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตเข้าถึงจะอนุญาตการพิมพ์รวมถึงการพิมพ์คุณภาพสูง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีคุณสมบัติ [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ซึ่งช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะปรากฏเฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ในระหว่างการส่งออก

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [การแทนที่ฟอนต์](/slides/th/net/font-substitution/)
{{% /alert %}}

### **จัดการฟอนต์ที่ไม่มีตัวหนาแบบเฉพาะ**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนากับข้อความแม้ฟอนต์นั้นจะไม่มีรูปแบบตัวหนาเฉพาะ ตัวอักษรอาจดูเป็นตัวหนาได้โดยการทำตัวหนาสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น หากข้อความนั้นดูหนามากเกินไปหรือแสดงผลแตกต่างจากที่ต้องการใน PDF ให้ลองตั้งค่า [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) เป็น `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจทำให้การแสดงผลดีขึ้นสำหรับฟอนต์บางประเภท ค่าเริ่มต้นคือ `false`

งานนำชมตัวอย่างมีสองกล่องข้อความ: หนึ่งมีข้อความปกติและหนึ่งมีการจัดรูปแบบตัวหนาที่ใช้ฟอนต์เดียวกันที่ไม่มีรูปแบบตัวหนาเฉพาะ ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดการเรสเตอร์ไลซ์ฟอนต์ที่ไม่รองรับรูปแบบตัวหนา และส่งออกเป็น PDF:

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

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์เมื่อปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความตัวหนาจะมีเส้นหนากว่าเมื่อปิดตัวเลือก เมื่อเปิดตัวเลือกเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนเลือกการตั้งสสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF ที่ปิดการเรสเตอร์ไลซ์สไตล์ฟอนต์ที่ไม่รองรับ](unsupported-bold-disabled.png) | ![PDF ที่เปิดการเรสเตอร์ไลซ์สไตล์ฟอนต์ที่ไม่รองรับ](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้ข้อความตัวหนาแปลงเป็นบิตแมพเท่านั้น: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้หากไม่มี OCR และขอบข้อความดูนุ่มขึ้นที่การขยาย 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองข้อความจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำการเรสเตอร์ไลซ์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบตัวหนาเฉพาะ [การแทนที่ฟอนต์](/slides/th/net/font-substitution/) จะเลือกฟอนต์อื่นแทนเมื่อฟอนต์เดิมไม่มีอยู่

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่โดยกำหนดขนาดสไลด์เป็น 612 × 792 พอยต์ (8.5 × 11 นิ้ว) จากนั้นปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดี่ยวเป็น PDF

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

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกของผู้พูดของแต่ละสไลด์ไว้ใต้สไลด์ ใช้งานนำเสนอที่มีบันทึกผู้พูดเพื่อดูผลลัพธ์

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

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามใด ๆ ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ด C# นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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
Aspose.Slides รองรับการทำงานแปลง PDF ช่วยให้คุณแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ที่ได้รับความนิยมได้ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) ได้ นอกจากนี้ยังสนับสนุนการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) ด้วย
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปเดียว ส่วนองค์ประกอบเส้นทางแยกต่างหากจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็นศิลปวัตถุ; ข้อความแทนที่จะมีเพียงสำหรับรูปทั้งหมด

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงเป็นกลุ่มของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและทำกระบวนการแปลงโดยโปรแกรม

**สามารถป้องกันไฟล์ PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**

ตั้งค่าคุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เป็น `true` เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยตั้งค่าคุณสมบัติเช่น [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) และ [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ ได้แก่ PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดการเข้าถึงและการเก็บถาวร

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ .NET](/slides/th/net/)
- [อ้างอิง API Aspose.Slides สำหรับ .NET](https://reference.aspose.com/slides/net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)