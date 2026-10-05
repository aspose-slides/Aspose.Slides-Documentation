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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและค้นหาได้ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย C# มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้บนอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การป้องกันไฟล์ PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ไปยัง [การนำเสนอ](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class แล้วบันทึกงานนำเสนอเป็น PDF ด้วยวิธีการ[บันทึก](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) class [การนำเสนอ](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เปิดเผยวิธีการ[บันทึก](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ .NET แทรกข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะใส่ค่าฟิลด์ Application เป็น "*Aspose.Slides*" และฟิลด์ PDF Producer จะมีค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **หมายเหตุ** ว่าคุณไม่สามารถบอก Aspose.Slides ให้เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวท์ต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* รายการหัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose มี[**เครื่องแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ออนไลน์ฟรีที่จะแสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบกับเครื่องแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่ได้, ล็อก PDF ด้วยรหัสผ่าน, หรือระบุว่ากระบวนการแปลงควรทำงานอย่างไร

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์, ระบุวิธีการจัดการ metafile, กำหนดระดับการบีบอัดสำหรับข้อความ, ตั้งค่า DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG เป็น 90, ความละเอียดภาพเป็น 300 DPI, metafile ถูกบันทึกเป็น PNG, และการบีบอัดข้อความแบบ Flate

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

### **คงไฟล์ OLE ที่ฝังอยู่เป็นเอกสารแนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ที่ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กรวมถึงดูสไลด์ด้วย ตั้งค่า [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) เป็น `true` เพื่อคงไฟล์ OLE ที่ฝังเป็นเอกสารแนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของออบเจ็กต์ OLE จะถูกแสดงบนหน้า PDF แต่ไฟล์ที่ฝังจะไม่รวมเป็นเอกสารแนบ การตั้งค่าตัวเลือกเป็น `true` จะรวมข้อมูลไฟล์ด้วย ภาพตัวอย่างยังคงเป็นการแสดงผลภาพ; เอกสารแนบทำให้ผู้รับเปิดหรือบันทึกไฟล์ที่ฝังแยกต่างหาก ออบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel เชิงโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงผลบนหน้า PDF จะแยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A‑1 ห้ามมีไฟล์ฝัง, PDF/A‑2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A‑3 อนุญาตไฟล์ประเภทอื่น ๆ รวมถึงเวิร์กบุ๊ก Excel. สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้แสดงการส่งออก PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้คุณสมบัติ[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)จากคลาส[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนอยู่ทั้งหมด

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การกำหนดสิทธิ์การเข้าถึงอนุญาตการพิมพ์รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides ให้คุณสมบัติ[WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)ภายใต้คลาส[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ลงคอนโซล คำเตือนจะปรากฎเฉพาะเมื่อมีฟอนต์ที่ไม่พร้อมใช้งานถูกแทนที่ระหว่างการส่งออก

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ[การแทนที่ฟอนต์](/slides/th/net/font-substitution/)
{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ 1 และ 3 จากงานนำเสนอเป็น PDF หมายเลขสไลด์ในอาร์เรย์นี้เริ่มนับจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) แล้วปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดี่ยวเป็น PDF

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

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อของผู้พูดแต่ละสไลด์ด้านล่างสไลด์ ใช้งานนำเสนอที่มีบันทึกย่อเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ[แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใดก็ได้ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ด C# นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติต่าง ๆ

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
Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), และ[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) การแปลง PDF ไปยังรูปแบบพิเศษอื่น ๆ เช่น[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), และ[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะจัดการกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปหนึ่งรูปเดียว ส่วนประกอบเส้นทางแต่ละเส้นจะไม่คงไว้เป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็นศิลปวัตถุ; ข้อความแทนที่จะมีเฉพาะสำหรับรูปทั้งหมด

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF เป็นชุดได้หรือไม่?**

ใช่, Aspose.Slides รองรับการแปลงชุดของไฟล์ PPT หรือ PPTX เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและใช้กระบวนการแปลงโดยโปรแกรม

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้ สามารถใช้คลาส[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**จะใส่สไลด์ที่ซ่อนอยู่ใน PDF อย่างไร?**

ตั้งค่า[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)ในคลาส[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)เป็น `true` เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ใช่, คุณสามารถควบคุมคุณภาพภาพโดยตั้งค่าคุณสมบัติเช่น[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/)และ[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/)ในคลาส[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)เพื่อให้แน่ใจว่าภาพใน PDF มีคุณภาพสูง

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA, ทำให้เอกสารของคุณตอบสนองต่อความต้องการด้านการเข้าถึงและการจัดเก็บระยะยาว

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for .NET](/slides/th/net/)
- [อ้างอิง API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/conversion)