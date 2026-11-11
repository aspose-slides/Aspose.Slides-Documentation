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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและสามารถค้นหาได้ใน .NET ด้วย Aspose.Slides พร้อมตัวอย่างโค้ด C# ที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP เป็นต้น) ให้เป็นรูปแบบ PDF ใน C# มีประโยชน์หลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษารูปแบบและการจัดวางของงานนำเสนอไว้ คู่มือเล่านี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพรูปภาพ รวมสไลด์ที่ซ่อนอยู่ ปกป้องไฟล์ PDF ด้วยรหัสผ่าน ตรวจจับการทดแทนฟอนต์ เลือกสไลด์ที่ต้องการแปลง และนำมาตรฐานการปฏิบัติตามไปใช้กับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

ด้วย Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) เปิดเผยเมธอด [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET จะใส่ข้อมูล API และหมายเลขเวอร์ชันของตนลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะกรอกฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถบอก Aspose.Slides ให้เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนต่าง ๆ และแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* bullet
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกค่าเริ่มต้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose มี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ออนไลน์ให้ใช้งานฟรี ซึ่งแสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานแบบสดของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides ให้ตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ผลลัพธ์ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีที่กระบวนการแปลงควรดำเนินการ

### **แปลง PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเอง**

ด้วยตัวเลือกการแปลงที่กำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเราสเตอร์ ระบุวิธีการจัดการเมต้าไฟล์ กำหนดระดับการบีบอัดสำหรับข้อความ ตั้งค่า DPI สำหรับภาพ และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 พร้อมคุณภาพ JPEG ตั้งเป็น 90 ความละเอียดภาพตั้งเป็น 300 DPI เมต้าไฟล์บันทึกเป็น PNG และบีบอัดข้อความด้วย Flate

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

> **Note:** คุณสามารถปรับปรุงคุณภาพการเรนเดอร์ของเงาและเอฟเฟ็กต์การสะท้อนของข้อความเมื่อแปลงเป็น PDF โดยตั้งค่า `PdfOptions.SufficientResolution` เป็นค่าที่สูงกว่า (เช่น `300`) ซึ่งจะทำให้ผลลัพธ์ PDF เข้ากับลักษณะที่แสดงใน Microsoft PowerPoint มากขึ้น

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่องานนำเสนอมีรูปถ่ายหรือภาพหน้าจอจำนวนมาก การลดขนาด PDF ที่ส่งออกสามารถทำให้การส่งอีเมลหรือการดาวน์โหลดเป็นเรื่องง่ายขึ้น ตั้งค่า [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) เป็น `true` เพื่อให้ระบบเลือกอัลกอริทึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างส่งออก PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่ เปิดใช้งานการเลือกการบีบอัดภาพอัตโนมัติ และบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF จะคงค่าเริ่มต้นทั้งหมด

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

ตัวเลือกนี้เลือกอัลกอริทึมการบีบอัดสำหรับแต่ละภาพ การลดค่า [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) จะทำให้คุณภาพภาพ JPEG ลดลง ในขณะที่การลดค่า [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) จะทำให้ภาพถูกย่อความละเอียดลง ซึ่งอาจลดรายละเอียดได้ การเปิดใช้งานการเลือกการบีบอัดอัตโนมัติเองไม่ได้ทำให้ค่าทั้งสองนี้ลดลง

การเลือกอัลกอริทึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพและการตั้งค่าการส่งออกของงานนำเสนอ; การลดขนาดแบบคงที่ไม่ได้รับประกันสำหรับทุกงานนำเสนอ

### **เก็บไฟล์ OLE ฝังเป็นเอกสารแนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF เข้าถึงข้อมูลของเวิร์กบุ๊กพร้อมกับดูสไลด์ ตั้งค่า [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) เป็น `true` เพื่อเก็บไฟล์ OLE ฝังเป็นไฟล์แนบใน PDF ผลลัพธ์

ค่าเริ่มต้นคือ `false`: ภาพพรีวิวหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์ด้วย ภาพพรีวิวยังคงเป็นการแสดงผลภาพเท่านั้น; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ฝังแยกต่างหากได้ วัตถุ OLE ไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

เพื่อตรวจสอบผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมอนุญาต การพรีวิวบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ไม่อนุญาตไฟล์ฝัง, PDF/A-2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A-3 อนุญาตประเภทไฟล์อื่น ๆ รวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้คุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนไว้เป็นหน้าใน PDF ผลลัพธ์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF รวมสไลด์ที่ซ่อนทั้งหมดด้วย

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ที่ป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตเข้าถึงอนุญาตการพิมพ์รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides มีคุณสมบัติ [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อให้คุณสามารถตรวจจับการทดแทนฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการทดแทนฟอนต์ไปยังคอนโซล คำเตือนจะถูกพิมพ์เฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกทดแทนในระหว่างการส่งออก

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

### **จัดการฟอนต์ที่ไม่มีรูปแบบตัวหนาแยกเฉพาะ**

งานนำเสนออาจทำให้ข้อความดูหนาได้แม้ฟอนต์ไม่มีรูปแบบตัวหนาแยกเฉพาะ ข้อความนั้นอาจดูหนาด้วยการทำ synthetic bolding ซึ่งทำให้ glyph ปกติหนาขึ้น เมื่อข้อความดูหนักเกินหรือแตกต่างจากที่คาดหวังใน PDF ให้ลองตั้งค่า [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) เป็น `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจทำให้ลักษณะของฟอนต์บางตัวดีขึ้น ค่าเริ่มต้นคือ `false`

งานนำเสนอตัวอย่างมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความปกติและอีกกล่องหนึ่งใช้การจัดรูปแบบตัวหนาในฟอนต์เดียวกันที่ไม่มีรูปแบบตัวหนาแยกเฉพาะ ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดใช้งานการแรสเตอร์ฟอนต์ที่ไม่รองรับรูปแบบตัวหนา และส่งออกเป็น PDF:

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

ภาพตัวอย่างด้านล่างแสดงผลลัพธ์เมื่อปิดและเปิดตัวเลือก ในตัวอย่างนี้ข้อความตัวหนามีเส้นหนาขึ้นเมื่อปิดตัวเลือก เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนตัดสินใจเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนาเท่านั้นกลายเป็นบิตแมพ: ไม่สามารถเลือก, คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบของข้อความจะดูนุ่มขึ้นที่การซูม 800% ส่วนข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองข้อความจะยังคงเป็นข้อความ

ตัวเลือกนี้แรสเตอร์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบตัวหนาแยกเฉพาะ การ [Font substitution](/slides/th/net/font-substitution/) จะเลือกฟอนต์อื่นเมื่อฟอนต์เดิมใช้ไม่ได้

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF หมายเลขสไลด์ในอาเรย์นี้ใช้การนับจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่โดยกำหนดขนาดสไลด์เป็น 612 × 792 จุด (8.5 × 11 นิ้ว) ปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกโน้ต**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน้ตของผู้พูดของแต่ละสไลด์ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน้ตของผู้พูดเพื่อดูผลลัพธ์

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

## **ความสามารถในการเข้าถึงและมาตรฐานการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF โดยใช้มาตรฐานการปฏิบัติตามใด ๆ เหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

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

Aspose.Slides รองรับการแปลง PDF ให้เป็นรูปแบบไฟล์ยอดนิยมอื่น ๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) นอกจากนี้ยังรองรับการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปภาพเดียว รายการเส้นทางแยกต่างหากจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น artefact; ข้อความแทนที่ (alternative text) จะมีเฉพาะรูปภาพทั้งหมดเท่านั้น

## **FAQ**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงแบบแบตช์ของหลายไฟล์ PPT หรือ PPTX เป็น PDF คุณสามารถวนซ้ำไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยโปรแกรม

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อตั้งค่ารหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนไว้ใน PDF ได้อย่างไร?**

ตั้งค่า [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เป็น `true` เพื่อรวมสไลด์ที่ซ่อนไว้ใน PDF ผลลัพธ์

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยตั้งค่าคุณสมบัติเช่น [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) และ [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่ปฏิบัติตามมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA ซึ่งช่วยให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการจัดเก็บระยะยาว

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for .NET Documentation](/slides/th/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)

Related feature: [Export presentations to PDF](/slides/th/features/pdf-export/).