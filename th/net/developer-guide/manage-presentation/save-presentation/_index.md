---
title: บันทึกงานนำเสนอใน .NET
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/net/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดไว้ล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- ความคืบหน้าการบันทึก
- .NET
- C#
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน C# ด้วย Aspose.Slides สำหรับ .NET พร้อมกำหนดการส่งออก PPTX และการรายงานความคืบหน้า."
---
## **ภาพรวม**

หลังจากคุณสร้างงานนำเสนอหรือ [เปิดงานนำเสนอที่มีอยู่](/slides/th/net/open-presentation/), ให้ใช้เมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อเขียนผลลัพธ์ Aspose.Slides for .NET สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้ครอบคลุมการดำเนินการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับการส่งออก PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์ ให้ส่งเส้นทางผลลัพธ์และค่า [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ค่ารูปแบบกำหนดประเภทของไฟล์ที่ Aspose.Slides สร้างขึ้น

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **บันทึกงานนำเสนอในรูปแบบเดิมของมัน**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นทางและรูปแบบผลลัพธ์, โปรดดู [Determine the Original Presentation Format](/slides/th/net/detect-presentation-source-format/)

ในแอปพลิเคชันการประมวลผลแบบกลุ่ม, รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์, อ่านรูปแบบดั้งเดิมจากคุณสมบัติ [IPresentation.SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/sourceformat/) ส่งค่าที่ได้ของ [SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/sourceformat/) ไปยัง [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/tosaveformat/) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ที่สอดคล้องกัน, แล้วใช้ [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) เพื่อเขียนงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้ประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, ปรับปรุงชื่อเรื่อง, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil/tosaveformat/) จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบบันทึกงานนำเสนอที่สอดคล้องกัน มันแมปเฉพาะรูปแบบต้นทางของงานนำเสนอ; ไม่ได้ออกแบบให้เลือกรูปแบบส่งออกเช่น PDF, HTML, TIFF หรือภาพ การส่งค่าที่ไม่รองรับหรือไม่ถูกต้องของ [SourceFormat](https://reference.aspose.com/slides/th/net/aspose.slides/sourceformat/) จะทำให้เกิด [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception)

ไฟล์ PPT, PPS, และ POT รุ่นเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอประเภทนี้จากสตรีมโดยไม่มีส่วนขยายไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการรักษาชนิดย่อยรุ่นเก่าเหล่านี้ไว้, ให้เก็บชื่อไฟล์หรือเมตาดาต้ารูปแบบต้นฉบับแยกจากกันและใช้เมื่อตั้งชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอไปยังสตรีม**

เพื่อเขียนงานนำเสนอโดยไม่ต้องอ้างอิงถึงเส้นทางไฟล์สุดท้าย, ให้ส่ง [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) ที่สามารถเขียนได้และค่า [SaveFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) วิธีนี้มีประโยชน์เมื่อผลลัพธ์ต้องส่งคืนจากบริการเว็บ, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอใหม่ไปยังสตรีมไฟล์:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **บันทึกงานนำเสนอด้วยประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint เปิดงานนำเสนอที่บันทึกไว้โดยอัตโนมัติ ตั้งคุณสมบัติ [ViewProperties.LastView](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/lastview/) ให้เป็นค่าของ [ViewType](https://reference.aspose.com/slides/th/net/aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดมุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML, สร้างอินสแตนซ์ของ [PptxOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/) แล้วตั้งคุณสมบัติ [Conformance](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/conformance/) ให้เป็น `Conformance.Iso29500_2008_Strict` จากนั้นส่งตัวเลือกไปยังเมธอด [Presentation.Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/)

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและไม่บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP, งานนำเสนอขนาดใหญ่มากอาจเกินขีดจำกัดเหล่านั้น การขยาย Zip64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้คุณสมบัติ [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/zip64mode/) เพื่อควบคุมว่า Aspose.Slides จะเขียนส่วนขยาย Zip64 หรือไม่:

- `IfNecessary` ใช้ Zip64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน (เป็นค่าเริ่มต้น)
- `Never` ปิดการใช้งานส่วนขยาย Zip64
- `Always` เขียนส่วนขยาย Zip64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย Zip64 เสมอสำหรับงานนำเสนอเอาต์พุต:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
หาก `Zip64Mode` ถูกตั้งค่าเป็น `Never` และงานนำเสนอไม่สามารถพอดีกับขีดจำกัด ZIP มาตรฐาน, การบันทึกจะโยนข้อผิดพลาด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออก PPTX, คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยตั้งคุณสมบัติ [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/compressionlevel/) รายการค่าใน enumeration [CompressionLevel](https://reference.aspose.com/slides/th/net/aspose.slides.export/compressionlevel/) มีดังนี้:

- `None` เก็บข้อมูลโดยไม่มีการบีบอัด
- `Level1` ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดมากที่สุด
- `Level2` ถึง `Level5` ให้ความสำคัญกับขนาดผลลัพธ์ที่เล็กลงมากขึ้นเรื่อย ๆ แทนความเร็วในการบันทึก
- `Level6` สมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์ (เป็นระดับเริ่มต้น)
- `Level7` และ `Level8` ให้ความสำคัญกับขนาดผลลัพธ์ที่เล็กลงต่อไป
- `Level9` ให้การบีบอัดที่แรงที่สุดและต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่มีการบีบอัด:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX, คุณสมบัติ [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/th/net/aspose.slides.export/pptxoptions/refreshthumbnail/) จะควบคุมภาพย่อของเอกสาร:

- `true` สร้างภาพย่อใหม่ระหว่างการบันทึก (ค่าเริ่มต้น)
- `false` รักษาภาพย่อที่มีอยู่ หากงานนำเสนอไม่มีภาพย่อ Aspose.Slides จะไม่สร้างภาพย่อใหม่

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการบันทึก, ให้ทำการติดตั้งอินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/) และกำหนดการทำงานนั้นให้กับคุณสมบัติ [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/th/net/aspose.slides.export/isaveoptions/progresscallback/) Aspose.Slides จะเรียกเมธอด [IProgressCallback.Reporting](https://reference.aspose.com/slides/th/net/aspose.slides/iprogresscallback/reporting/) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าการส่งออก PDF ไปยังคอนโซล:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose มีเครื่องมือ **PowerPoint Splitter** ฟรี ([PowerPoint Splitter](https://products.aspose.app/slides/th/splitter)) สร้างด้วย API ของ Aspose.Slides โดยสามารถบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **FAQ**

**Aspose.Slides รองรับการบันทึกเชิงเพิ่มหรือตาม “fast save” หรือไม่?**

ไม่ใช่ การบันทึกแต่ละครั้งจะเขียนไฟล์ผลลัพธ์เต็มรูปแบบแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่ได้ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) **ไม่เป็น thread‑safe** (/slides/th/net/multithreading/) ควรเข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่ลิงก์ภายนอกจะเกิดอะไรขึ้นเมื่อบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/net/manage-hyperlinks/) จะยังคงอยู่ในงานนำเสนอ Aspose.Slides จะไม่คัดลอกไฟล์ที่ลิงก์ภายนอก ดังนั้นงานนำเสนอที่บันทึกแล้วต้องยังคงสามารถเข้าถึงตำแหน่งไฟล์เหล่านั้นได้

**สามารถบันทึกเมตาดาต้าเอกสารเช่น ผู้เขียน, ชื่อเรื่อง, บริษัท, และวันที่สร้างได้หรือไม่?**

ได้ ให้ตั้ง [document properties](/slides/th/net/presentation-properties/) ที่เหมาะสมก่อนบันทึก และ Aspose.Slides จะทำการบันทึกลงไฟล์เอาต์พุต