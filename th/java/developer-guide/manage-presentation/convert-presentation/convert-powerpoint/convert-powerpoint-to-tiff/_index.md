---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย Java
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) ไปเป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายโดยใช้ Aspose.Slides for Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียที่ได้รับความนิยมอย่างกว้างขวาง เนื่องจากคุณภาพยอดเยี่ยมและการรักษากราฟิกอย่างละเอียด นักออกแบบ ช่างภาพ และผู้จัดทำสื่อบนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงระดับชั้น สีที่แม่นยำ และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความละเอียดภาพสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มอบให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะตรงกับขนาดสไลด์เริ่มต้น

โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode] เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดวิธีการแสดงรูปทรงเดี่ยวเมื่อโหมดแสดงผลขาว-ดำเปิดอยู่ ให้ใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). ดูตัวอย่างใน [Control Black-and-White Rendering for Shapes](/slides/th/java/shape-formatting/#control-black-and-white-rendering-for-shapes) สำหรับตัวอย่างเพิ่มเติม.
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

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถตั้งค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) ช่วยให้คุณกำหนดขนาดของภาพที่ได้

โค้ดตัวอย่างนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint ไปเป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าประเภทการบีบอัด.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุโหมดการบีบอัดเริ่มต้น (LZW).
        None - ระบุไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับประเภทการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

    // ตั้งค่า DPI ของภาพ.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // ตั้งค่าขนาดภาพ.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลภาพกำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) คุณสามารถกำหนดรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint ไปเป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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
    
    // บันทึกงานนำเสนอเป็น TIFF พร้อมรูปแบบพิกเซลที่กำหนด.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ดูตัวแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose ที่นี่: [ตัวแปลง PowerPoint เป็นโปสเตอร์ฟรี](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดียวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้เลย Aspose.Slides ให้คุณแปลงสไลด์แต่ละอันจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกันได้

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้จำกัดจำนวนสไลด์ใด ๆ คุณสามารถแปลงงานนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะถูกรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ เนื่องจาก TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกรักษาไว้ มีเพียงภาพถ่ายนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น