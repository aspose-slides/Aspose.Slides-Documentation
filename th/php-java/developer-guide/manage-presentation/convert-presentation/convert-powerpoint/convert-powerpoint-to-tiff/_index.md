---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ใน PHP
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/php-java/convert-powerpoint-to-tiff/
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
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมตัวอย่างโค้ด."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) คือรูปแบบภาพเรสเตอร์ที่ไม่มีการสูญเสียซึ่งได้รับความนิยมอย่างกว้างขวางและเป็นที่รู้จักด้วยคุณภาพที่ยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ, ช่างภาพ, และผู้ทำสื่อบนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงคุณภาพภาพสูงสุด.

## **แปลงงานนำเสนอเป็น TIFF**

โดยใช้วิธีการ [save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) ที่จัดเตรียมโดยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) คุณสามารถแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็น TIFF:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ให้คุณกำหนดอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getCompressionType) ถูกตั้งเป็น `CCITT4` หรือ `CCITT3`.

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ดังต่อไปนี้:

![สไลด์งานนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถตั้งค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getImageSize) ให้คุณกำหนดขนาดของภาพที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยขนาดกำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // ตั้งค่าประเภทการบีบอัด.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุแผนการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นอยู่กับประเภทการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

    // ตั้งค่า DPI ของภาพ.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // ตั้งค่าขนาดของภาพ.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดที่ระบุ.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลของภาพกำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getPixelFormat) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) คุณสามารถกำหนดรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint เป็นภาพ TIFF ด้วยรูปแบบพิกเซลกำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ (PPT, PPTX, ODP, ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบกำกับดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบกำกับดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบกำกับดัชนี.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
ลองดู [เครื่องแปลง PowerPoint เป็นโปสเตอร์ฟรี](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online) ของ Aspose.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ ทั้งนี้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดขีดจำกัดใดๆ สำหรับจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกคงไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ เพราะ TIFF เป็นรูปแบบภาพคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่ถูกคงไว้ มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออกเท่านั้น