---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ใน .NET
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/net/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ .NET ตัวอย่างโค้ด C#"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพแรสเตอร์แบบไม่สูญเสียข้อมูลที่ใช้กันอย่างกว้างขวาง ซึ่งมีคุณภาพยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกอย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint ของคุณ (PPT, PPTX) และสไลด์ OpenDocument (ODP) ไปเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความละเอียดภาพสูงสุด.

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ที่ให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น.

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

คุณสมบัติ [BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ทำให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้จะใช้เฉพาะเมื่อคุณสมบัติ [CompressionType](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) คือการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละอันควรแสดงอย่างไรเมื่อโหมดแสดงผลขาว-ดำทำงาน ให้ใช้ [IShape.BlackWhiteMode](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/blackwhitemode/). ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes).
{{% /alert %}}

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C# นี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีมิติเฉพาะ คุณสามารถตั้งค่าได้โดยใช้คุณสมบัติที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/). ตัวอย่างเช่น คุณสมบัติ [ImageSize](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) ให้คุณกำหนดขนาดของภาพที่ได้.

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    ชนิดการบีบอัด:
        Default - ระบุโครงการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับชนิดการบีบอัดและไม่สามารถตั้งค่าด้วยตนเองได้.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // ตั้งค่าขนาดภาพ.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // บันทึกการนำเสนอเป็น TIFF พร้อมขนาดที่กำหนด.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้คุณสมบัติ [PixelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้.

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบจัดทำดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    // บันทึกการนำเสนอเป็น TIFF พร้อมขนาดภาพที่กำหนด.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
ตรวจสอบ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose.
{{% /alert %}}

## **FAQ**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ค่ะ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument ไปเป็นภาพ TIFF แยกกัน.

**มีข้อจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดจำนวนสไลด์ คุณสามารถแปลงการนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF.

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ได้ เนื่องจาก TIFF เป็นรูปแบบภาพคงที่ ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บไว้ มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น.