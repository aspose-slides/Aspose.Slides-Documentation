---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF ด้วย Java
titlelink: PowerPoint เป็น TIFF
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
- PowerPoint เป็น TIFF
- การนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- บันทึก PPT เป็น TIFF
- บันทึก PPTX เป็น TIFF
- ส่งออก PPT เป็น TIFF
- ส่งออก PPTX เป็น TIFF
- Java
- Aspose.Slides
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) ให้เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Java พร้อมตัวอย่างโค้ด"
---
## **บทนำ**

TIFF (**Tagged Image File Format**) คือรูปแบบภาพแรสเตอร์แบบไม่มีการสูญเสียข้อมูลที่ใช้กันอย่างแพร่หลาย ซึ่งเป็นที่รู้จักในคุณภาพยอดเยี่ยมและการรักษารายละเอียดของกราฟิกได้อย่างละเอียด นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint ของคุณ (PPT, PPTX) และสไลด์ OpenDocument (ODP) ให้เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความแม่นยำด้านภาพสูงสุด.

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น.

โค้ดนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้จะใช้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละชิ้นควรแสดงอย่างไรเมื่อโหมดแสดงผลขาว-ดำทำงาน ให้ใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes)
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

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถตั้งค่าได้โดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) ให้คุณกำหนดขนาดของภาพที่สร้างขึ้น.

โค้ดนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // ตั้งค่าชนิดการบีบอัด.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    ชนิดการบีบอัด:
        Default - ระบุโครงสร้างการบีบอัดค่าเริ่มต้น (LZW).
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

    // ตั้งค่าขนาดของภาพ.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึการนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่สร้างขึ้น.

โค้ดนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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
    
    // บันทึกการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลที่ระบุ.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ตรวจสอบตัวแปลง PowerPoint ไปเป็นโปสเตอร์ฟรีของ Aspose ที่ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ TIFF เป็นรูปภาพแบบคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนแปลงจะไม่ถูกรักษาไว้ มีเพียงภาพคงที่ของสไลด์ที่ถูกส่งออก