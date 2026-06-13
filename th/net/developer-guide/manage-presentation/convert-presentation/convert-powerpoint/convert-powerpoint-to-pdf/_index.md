---
title: แปลง PPT และ PPTX เป็น PDF ใน .NET [รวมฟีเจอร์ขั้นสูง]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและค้นหาได้ใน .NET ด้วย Aspose.Slides โดยมีตัวอย่างโค้ด C# ที่เร็วและตัวเลือกการแปลงขั้นสูง"
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย C# มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการคงรักษาเลย์เอาต์และการจัดรูปแบบของงานนำเสนอของคุณ คู่มือนี้จะแสดงวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ รวมถึงการใส่สไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการแทนที่แบบอักษร การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามในเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอากิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/). คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) เปิดให้ใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ซึ่งโดยทั่วไปใช้สำหรับแปลงงานนำเสนอเป็น PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for .NET จะใส่ข้อมูล API และหมายเลขเวอร์ชันของมันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมค่าในฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*". **หมายเหตุ** คุณไม่สามารถบังคับให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้.
{{% /alert %}}

Aspose.Slides ช่วยให้คุณสามารถแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF เพื่อให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์จะถูกแสดงอย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดรายการ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ (PPT, PPTX, ODP ฯลฯ) เป็น PDF:
```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 
Aspose มีตัวแปลง [**PowerPoint to PDF converter**](https://products.aspose.app/slides/th/conversion/ppt-to-pdf) ออนไลน์ฟรีที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่.
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF ด้วยตัวเลือก**

Aspose.Slides มีตัวเลือกกำหนดเอง—พรอพर्टีภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/)—ที่ช่วยให้คุณปรับแต่ง PDF ที่ได้, ตั้งรหัสผ่านให้ PDF, หรือระบุวิธีการดำเนินการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกที่กำหนดเอง**

โดยใช้ตัวเลือกการแปลงที่กำหนดเอง คุณสามารถตั้งค่าคุณภาพที่ต้องการสำหรับภาพแรสเตอร์, ระบุวิธีการจัดการเมตาไฟล์, ตั้งระดับการบีบอัดสำหรับข้อความ, กำหนด DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างโค้ดด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมตัวเลือกกำหนดเองหลายตัว
```c#
// สร้างอินสแตนซ์ของคลาส PdfOptions.
var pdfOptions = new PdfOptions
{
    // ตั้งค่าคุณภาพสำหรับรูปภาพ JPG.
    JpegQuality = 90,

    // ตั้งค่า DPI สำหรับรูปภาพ.
    SufficientResolution = 300,

    // ตั้งค่าการทำงานสำหรับเมตาไฟล์.
    SaveMetafilesAsPng = true,

    // ตั้งค่าระดับการบีบอัดข้อความสำหรับเนื้อหาข้อความ.
    TextCompression = PdfTextCompression.Flate,

    // กำหนดโหมดการปฏิบัติตาม PDF.
    Compliance = PdfCompliance.Pdf15
};

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint หรือ OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// บันทึกงานนำเสนอเป็นเอกสาร PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้คุณสมบัติ [ShowHiddenSlides](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/showhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าใน PDF ที่ได้

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนรวมอยู่:
```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
var pdfOptions = new PdfOptions();

// เพิ่มสไลด์ที่ซ่อนอยู่.
pdfOptions.ShowHiddenSlides = true;

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **แปลง PowerPoint เป็น PDF ป้องกันด้วยรหัสผ่าน**

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint ให้เป็น PDF ที่มีการตั้งรหัสผ่านโดยใช้พารามิเตอร์การปกป้องจากคลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/):
```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument
using var presentation = new Presentation("PowerPoint.pptx");

// สร้างอินสแตนซ์ของคลาส PdfOptions.
var pdfOptions = new PdfOptions();

// ตั้งรหัสผ่าน PDF และสิทธิ์การเข้าถึง.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **ตรวจจับการแทนที่แบบอักษร**

Aspose.Slides มีคุณสมบัติ [WarningCallback](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveoptions/warningcallback/) ใต้คลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่แบบอักษรในระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

โค้ด C# นี้แสดงวิธีตรวจจับการแทนที่แบบอักษร:
```c#
public static void Main()
{
    // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // ตั้งค่าคอลแบ็คการเตือนในตัวเลือก PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // บันทึกงานนำเสนอเป็น PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// การทำงานของคอลแบ็คการเตือน.
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

{{%  alert color="primary"  %}} 
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการรับคอลแบ็คสำหรับการแทนที่แบบอักษรในกระบวนการเรนเดอร์ ดูที่ [Getting Warning Callbacks for Fonts Substitution](/slides/th/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่แบบอักษร ดูบทความ [Font Substitution](/slides/th/net/font-substitution/)
{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

โค้ด C# นี้แสดงวิธีการแปลงสไลด์เฉพาะจากงานนำเสนอ PowerPoint เป็น PDF:
```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PowerPoint หรือ OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// กำหนดอาร์เรย์ของหมายเลขสไลด์.
int[] slides = { 1, 3 };

// บันทึกงานนำเสนอเป็น PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF พร้อมขนาดสไลด์ที่กำหนด:
```c#
var slideWidth = 612;
var slideHeight = 792;

// โหลดงานนำเสนอ PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// สร้างงานนำเสนอใหม่ด้วยขนาดสไลด์ที่ปรับแล้ว.
using var resizedPresentation = new Presentation();

// ตั้งค่าขนาดสไลด์ที่กำหนดเอง.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// คัดลอกสไลด์แรกจากงานนำเสนอเดิม.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// บันทึกงานนำเสนอที่ปรับขนาดเป็น PDF พร้อมบันทึกย่อ.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

โค้ด C# นี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น PDF ที่รวมบันทึกย่อ:
```c#
// โหลดงานนำเสนอ PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// กำหนดค่าตัวเลือก PDF ด้วยการจัดหน้าบันทึกย่อ.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// บันทึกงานนำเสนอเป็น PDF พร้อมบันทึกย่อ.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides ให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**.

โค้ด C# นี้แสดงกระบวนการแปลง PowerPoint เป็น PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:
```c#
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
Aspose.Slides รองรับการแปลง PDF, ช่วยให้คุณแปลงไฟล์ PDF ไปเป็นรูปแบบไฟล์ยอดนิยมต่าง ๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/th/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/th/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/th/net/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/th/net/conversion/pdf-to-png/) ได้ อีกทั้งยังรองรับการแปลง PDF ไปเป็นรูปแบบเฉพาะทางอื่น ๆ ได้แก่ [PDF to SVG](https://products.aspose.com/slides/th/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/th/net/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/th/net/conversion/pdf-to-xml/) 
{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรว่าเป็นรูปภาพเดียว ส่วนองค์ประกอบเส้นทางแยกแต่ละส่วนจะไม่ถูกเก็บไว้เป็นเนื้อหาแยกและอาจถูกระบุเป็นสิ่งที่เหลืออยู่; ข้อความแทนที่ให้เฉพาะกับรูปภาพทั้งหมดเท่านั้น.

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF แบบกลุ่มได้หรือไม่?**  
ได้, Aspose.Slides รองรับการแปลงเป็นกลุ่มของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนซ้ำไฟล์ของคุณและดำเนินการแปลงโดยใช้โปรแกรมได้.

**สามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**  
แน่นอน. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง.

**ฉันจะรวมสไลด์ที่ซ่อนใน PDF อย่างไร?**  
ตั้งค่า `ShowHiddenSlides` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) เป็น `true` เพื่อรวมสไลด์ที่ซ่อนใน PDF ที่ได้.

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**  
ได้, คุณสามารถควบคุมคุณภาพภาพโดยตั้งค่าพรอพต์เช่น `JpegQuality` และ `SufficientResolution` ในคลาส [PdfOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ.

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**  
ได้, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับมาตรฐานต่าง ๆ รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา.

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for .NET](/slides/th/net/)
- [อ้างอิง API Aspose.Slides for .NET](https://reference.aspose.com/slides/th/net/)
- [ตัวแปลงออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion)