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
description: "เรียนรู้วิธีการแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET ตัวอย่างโค้ด C#"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่สูญเสียคุณภาพที่ใช้กันอย่างแพร่หลาย เนื่องจากคุณภาพยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ ช่างภาพ และผู้จัดทำสื่อบนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงเลเยอร์ ความแม่นยำของสี และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความคมชัดสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

คุณสมบัติ [BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ให้คุณระบุอัลกอริธึมที่ใช้เมื่อต้องแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อคุณสมบัติ [CompressionType](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริธึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด หากต้องการกำหนดวิธีการแสดงผลของรูปร่างแต่ละอันเมื่ออยู่ในโหมดแสดงผลขาว-ดำ ให้ใช้ [IShape.BlackWhiteMode](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/blackwhitemode/) ดูตัวอย่างใน [Control Black-and-White Rendering for Shapes](/slides/th/net/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่ามีไฟล์ "sample.pptx" พร้อมสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

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

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถกำหนดค่าเหล่านั้นโดยใช้คุณสมบัติใน [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) เช่น คุณสมบัติ [ImageSize](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) ที่อนุญาตให้กำหนดขนาดของภาพผลลัพธ์

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดที่กำหนดเอง:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP เป็นต้น).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    ชนิดการบีบอัด:
        Default - ระบุโครงสร้างการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับชนิดการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

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

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้คุณสมบัติ [PixelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ผลลัพธ์ได้

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP เป็นต้น).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    // บันทึกการนำเสนอเป็น TIFF พร้อมขนาดภาพที่กำหนด.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
ลองใช้ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

**อนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint ถูกเก็บรักษาไว้เมื่อแปลงเป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปแบบภาพคงที่ ดังนั้นอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกเก็บรักษา; จะมีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น