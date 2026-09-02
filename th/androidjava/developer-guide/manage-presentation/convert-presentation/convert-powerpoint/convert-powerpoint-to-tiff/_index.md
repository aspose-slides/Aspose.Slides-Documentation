---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF บน Android
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) ให้เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด Java."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียข้อมูลที่ได้รับความนิยมอย่างกว้างขวางโดยมีคุณภาพยอดเยี่ยมและการรักษากราฟิกอย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณโดยตรงเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความชัดเจนของภาพสูงสุด.

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ดต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ทำให้คุณกำหนดอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพที่เป็นสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="หมายเหตุ" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างเดี่ยวควรแสดงอย่างไรเมื่อโหมดแสดงผลขาว-ดำเปิดใช้งาน ให้ใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ดูตัวอย่างใน [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```java
import com.aspose.slides.*;

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

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดที่กำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง คุณสามารถตั้งค่าที่ต้องการได้โดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/). ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) ช่วยให้คุณกำหนดขนาดของภาพที่ได้

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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

    // ตั้งค่าความละเอียด DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งค่าขนาดภาพ.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) คุณสามารถกำหนดรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, indexed.
        Format4bppIndexed - 4 บิตต่อพิกเซล, indexed.
        Format8bppIndexed - 8 บิตต่อพิกเซล, indexed.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */
    
    // บันทึกการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="เคล็ดลับ" color="info" %}}
ตรวจสอบตัวแปลง PowerPoint เป็นโปสเตอร์ ฟรี ของ Aspose ที่ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ใช่. Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน.

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่, Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

**การแอนิเมชันและเอฟเฟ็กต์การเปลี่ยนสไลด์ของ PowerPoint ถูกเก็บรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่, TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นการแอนิเมชันและเอฟเฟ็กต์การเปลี่ยนสไลด์จะไม่ถูกเก็บไว้; มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออก.