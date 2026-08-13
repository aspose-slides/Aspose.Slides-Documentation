---
title: แปลงการนำเสนอ PowerPoint เป็น TIFF บน Android
titlelink: PowerPoint ไปเป็น TIFF
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
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ Android พร้อมตัวอย่างโค้ด Java."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพราสเตอร์แบบไม่สูญเสียคุณภาพที่ใช้กันอย่างกว้างขวางและเป็นที่รู้จักในด้านคุณภาพที่ยอดเยี่ยมและการเก็บรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ ช่างภาพ และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงสภาพชั้น สีที่แม่นยำ และการตั้งค่าเดิมของภาพ

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ไปเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงความละเอียดภาพสูงสุด

## **แปลงการนำเสนอเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ดต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็น TIFF:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
Presentation presentation = new Presentation("presentation.pptx");
try {
    // บันทึกการนำเสนอเป็น TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **แปลงการนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ให้คุณระบุอัลกอริทึมที่ใช้ในการแปลงสไลด์หรือรูปภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดต่อไปนี้แสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

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

หากคุณต้องการภาพ TIFF ที่มีมิติเฉพาะ คุณสามารถกำหนดค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) ให้คุณกำหนดขนาดของภาพที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ที่มีขนาดกำหนดเอง:

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
        Default - ระบุโครงสร้างการบีบอัดเริ่มต้น (LZW).
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

    // ตั้งค่าขนาดของภาพ.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // บันทึกการนำเสนอเป็น TIFF ด้วยขนาดที่กำหนด.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **แปลงการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

โค้ดต่อไปนี้แสดงวิธีแปลงการนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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
    
    // บันทึกการนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลที่กำหนด.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
ลองใช้ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?

ได้ Aspose.Slides รองรับให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

### มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

### การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์ของ PowerPoint จะถูกรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?

ไม่ได้ เนื่องจาก TIFF เป็นรูปแบบภาพคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนสไลด์จะไม่ถูกรักษาไว้ มีเพียงภาพนิ่งของสไลด์เท่านั้นที่ถูกส่งออก