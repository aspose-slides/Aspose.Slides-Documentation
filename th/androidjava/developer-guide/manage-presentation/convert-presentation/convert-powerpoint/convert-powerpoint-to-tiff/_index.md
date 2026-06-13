---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF บน Android
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/androidjava/convert-powerpoint-to-tiff/
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
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงงานนำเสนอ PowerPoint (PPT, PPTX) ให้เป็นภาพ TIFF คุณภาพสูงอย่างง่ายโดยใช้ Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด Java"
---
## **Introduction**

TIFF (**Tagged Image File Format**) คือรูปแบบไฟล์ภาพเรสเตอร์แบบไม่มีการสูญเสียที่ใช้กันอย่างกว้างขวาง ซึ่งเป็นที่รู้จักด้วยคุณภาพเหนือระดับและการรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์เดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเริ่มต้นของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย โดยทำให้งานนำเสนอของคุณคงความแม่นยำของภาพสูงสุด

## **Convert a Presentation to TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่ให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์ค่าเริ่มต้น

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convert a Presentation to Black-and-White TIFF**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ช่วยให้คุณระบุอัลกอริทึมที่ใช้เมื่อต้องการแปลงสไลด์หรือภาพสีเป็น TIFF สีขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่าเรามีไฟล์ "sample.pptx" พร้อมสไลด์ดังต่อไปนี้:

![สไลด์งานนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF สีขาว-ดำ:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![TIFF สีขาว-ดำ](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง คุณสามารถตั้งค่าที่ต้องการได้โดยใช้เมธอดที่มีในคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) ช่วยให้คุณกำหนดขนาดของภาพที่ได้

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    ชนิดการบีบอัด:
        Default - ระบุโครงการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับชนิดการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งค่าขนาดภาพ.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */
    
    // บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดภาพที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="เคล็ดลับ" color="primary" %}}
ลองใช้โปรแกรมแปลง PowerPoint ไปเป็นโปสเตอร์ฟรีของ Aspose ผ่านลิงก์นี้ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้เลย Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีข้อจำกัดจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่จำกัดจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอทุกขนาดเป็นรูปแบบ TIFF ได้

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนภาพของ PowerPoint จะถูกเก็บรักษาไว้เมื่แปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปแบบภาพคงที่ ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนภาพจะไม่ถูกเก็บไว้; จะส่งออกเฉพาะภาพนิ่งของสไลด์เท่านั้น