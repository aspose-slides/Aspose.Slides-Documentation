---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ใน Java
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
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่มีการสูญเสียข้อมูลซึ่งได้รับความนิยมอย่างกว้างขวางและขึ้นชื่อเรื่องคุณภาพยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกอย่างละเอียด นักออกแบบ ช่างภาพ และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้นภาพ ความแม่นยำของสี และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ซึ่งทำให้การนำเสนอของคุณคงความชัดเจนของภาพสูงสุด

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มอบให้โดยคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

This code demonstrates how to convert a PowerPoint presentation to TIFF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF สีขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF สีขาว-ดำ โปรดทราบว่าการตั้งค่านี้จะมีผลเฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF สีขาว-ดำ:

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

![TIFF สีขาว-ดำ](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเจาะจง คุณสามารถกำหนดค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) ช่วยให้คุณกำหนดขนาดของภาพที่ได้

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดที่กำหนดเอง:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    ชนิดการบีบอัด:
        Default - ระบุโหมดการบีบอัดเริ่มต้น (LZW).
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
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดที่กำหนด.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดนี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าเหล่านี้ (ตามเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล แบบอินเดกซ์.
        Format4bppIndexed - 4 บิตต่อพิกเซล แบบอินเดกซ์.
        Format8bppIndexed - 8 บิตต่อพิกเซล แบบอินเดกซ์.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */
    
    // บันทึกงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลที่กำหนด.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ลองใช้ [เครื่องแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?

ใช่ Aspose.Slides ให้คุณแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกันได้

### มีขีดจำกัดจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?

ไม่ Aspose.Slides ไม่กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอขนาดใดก็ได้เป็นรูปแบบ TIFF

### การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะคงอยู่เมื่อนำสไลด์แปลงเป็น TIFF หรือไม่?

ไม่ TIFF เป็นรูปภาพแบบคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ได้รับการเก็บรักษา มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออก