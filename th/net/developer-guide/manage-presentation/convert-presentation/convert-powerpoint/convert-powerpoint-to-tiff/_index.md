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
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายด้วย Aspose.Slides สำหรับ .NET ตัวอย่างโค้ด C#"
---
## **คำนำ**

TIFF (**Tagged Image File Format**) คือรูปแบบไฟล์ภาพเรสเตอร์แบบสูญเสียข้อมูลที่ใช้กันอย่างแพร่หลายซึ่งมีคุณภาพยอดเยี่ยมและการเก็บรายละเอียดกราฟิกอย่างครบถ้วน นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความเที่ยงตรงของภาพสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [Save](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/save/) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะแสดงขนาดสไลด์เริ่มต้น

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

คุณสมบัติ [BwConversionMode](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/bwconversionmode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค้านี้ใช้ได้เฉพาะเมื่อคุณสมบัติ [CompressionType](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/compressiontype/) ตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด C# นี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```cs
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

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง คุณสามารถตั้งค่าที่ต้องการโดยใช้คุณสมบัติที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/) ตัวอย่างเช่นคุณสมบัติ [ImageSize](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/imagesize/) ช่วยให้คุณกำหนดขนาดของภาพผลลัพธ์

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    ประเภทการบีบอัด:
        Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
        None - ระบุไม่มีการบีบอัด.
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

    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้คุณสมบัติ [PixelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions/pixelformat/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/tiffoptions) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ผลลัพธ์

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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

    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
ลองใช้ [ตัวแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดียวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ใช่. Aspose.Slides ให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกันได้

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี, Aspose.Slides ไม่ได้ตั้งข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ได้, TIFF เป็นรูปแบบภาพคงที่ ดังนั้นการแอนิเมชันและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บไว้; จะส่งออกเฉพาะภาพนิ่งของสไลด์เท่านั้น