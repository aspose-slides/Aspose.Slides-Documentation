---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ใน .NET
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/net/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น TIFF
- งานนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT ไปเป็น TIFF
- ส่งออก PPTX ไปเป็น TIFF
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ .NET ตัวอย่างโค้ด C#"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) คือรูปแบบไฟล์ภาพแรสเตอร์แบบไม่มีการสูญเสียข้อมูลที่ใช้กันอย่างกว้างขวาง ซึ่งเป็นที่รู้จักในคุณภาพยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ ช่างภาพ และผู้จัดพิมพ์บนเดสก์ทอปมักเลือกใช้ TIFF เพื่อคงไว้ซึ่งเลเยอร์ ความแม่นยำของสี และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความละเอียดภาพสูงสุด

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้วิธีการ [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ที่จัดให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่สร้างขึ้นสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **แปลงงานนำเสนอเป็น TIFF แบบขาว-ดำ**

คุณสมบัติ [BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ให้คุณระบุอัลกอริธึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF แบบขาว-ดำ โปรดทราบว่าการตั้งค่านี้ทำงานเฉพาะเมื่อคุณสมบัติ [CompressionType](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่ามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![A presentation slide](slide_black_and_white.png)

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเจาะจง คุณสามารถกำหนดค่าดังกล่าวได้โดยใช้คุณสมบัติใน [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ตัวอย่างเช่น คุณสมบัติ [ImageSize](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) ช่วยให้คุณกำหนดขนาดของภาพที่สร้างขึ้น

โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ที่มีขนาดกำหนดเอง:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    ประเภทการบีบอัด:
        Default - ระบุโค้ดการบีบอัดเริ่มต้น (LZW).
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

    // บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดที่ระบุ.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลกำหนดเอง**

โดยใช้คุณสมบัติ [PixelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่สร้างขึ้นได้

โค้ด C# นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดรรชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดรรชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดรรชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    // บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดภาพที่ระบุ.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
ตรวจสอบเครื่องมือแปลง PowerPoint ไปเป็นโปสเตอร์ของ Aspose ที่ให้ใช้ฟรี [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันสามารถแปลงสไลด์เดียวแทนการแปลงงานนำเสนอทั้งหมดเป็น TIFF ได้หรือไม่?

ได้. Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint หรือ OpenDocument ไปเป็นภาพ TIFF ได้อย่างแยกส่วน

### มีขีดจำกัดจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?

ไม่มี, Aspose.Slides ไม่ได้กำหนดข้อจำกัดเรื่องจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

### แอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์ใน PowerPoint จะถูกเก็บไว้เมื่อนำไปแปลงเป็น TIFF หรือไม่?

ไม่, TIFF เป็นรูปแบบภาพคงที่ ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกเก็บไว้; จะมีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น