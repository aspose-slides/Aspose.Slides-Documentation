---
title: แปลงการนำเสนอ PowerPoint ไปเป็น TIFF ด้วย Java
titlelink: PowerPoint ไปเป็น TIFF
type: docs
weight: 90
url: /th/java/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint ไปเป็น TIFF
- การนำเสนอไปเป็น TIFF
- สไลด์ไปเป็น TIFF
- PPT ไปเป็น TIFF
- PPTX ไปเป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงการนำเสนอ PowerPoint (PPT, PPTX) ไปเป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพราสเตอร์แบบไม่มีการสูญเสียข้อมูลที่ใช้กันอย่างแพร่หลาย ซึ่งเป็นที่รู้จักด้วยคุณภาพยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกอย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์แบบเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมของภาพ

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความชัดเจนของภาพสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มอบให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ดนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็น TIFF:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ (PPT, PPTX, ODP เป็นต้น).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ช่วยให้คุณระบุอัลกอริธึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่ามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

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

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงการนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดกำหนดเอง คุณสามารถตั้งค่าที่ต้องการโดยใช้เมธอดที่มีในคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) ช่วยให้คุณกำหนดขนาดของภาพที่ได้

โค้ดนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ (PPT, PPTX, ODP เป็นต้น).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    ชนิดการบีบอัด:
        Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
        None - ระบุไม่มีการบีบอัด.
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
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลภาพกำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดนี้แสดงวิธีการแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ (PPT, PPTX, ODP เป็นต้น).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, indexed.
        Format4bppIndexed - 4 บิตต่อพิกเซล, indexed.
        Format8bppIndexed - 8 บิตต่อพิกเซล, indexed.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */
    
    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
ตรวจสอบ [ตัวแปลง PowerPoint ไปเป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอใด ๆ ขนาดใดก็ได้เป็นรูปแบบ TIFF

**การแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะคงอยู่เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่มี TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นการแอนิเมชันและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่คงอยู่ มีเพียงภาพนิ่งของสไลด์ที่ส่งออก