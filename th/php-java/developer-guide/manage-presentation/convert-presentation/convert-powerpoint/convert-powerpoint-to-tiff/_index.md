---
title: "แปลงงานนำเสนอ PowerPoint ไปเป็น TIFF ใน PHP"
titlelink: "PowerPoint เป็น TIFF"
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
- ส่งออกรูปแบบ PPT เป็น TIFF
- ส่งออกรูปแบบ PPTX เป็น TIFF
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมตัวอย่างโค้ด."
---
## **บทนำ**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเทอร์ที่ใช้กันอย่างกว้างขวางและไม่มีการสูญเสียคุณภาพ ซึ่งเป็นที่รู้จักในเรื่องคุณภาพยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างครบถ้วน นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความถูกต้องของสี, และการตั้งค่าเดิมในภาพของพวกเขา.

ด้วย Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint ของคุณ (PPT, PPTX) และสไลด์ OpenDocument (ODP) ไปเป็นภาพ TIFF ที่มีคุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอต่างๆ ของคุณคงความสมบูรณ์ของภาพสูงสุด.

## **แปลงงานนำเสนอเป็น TIFF**

Using the [บันทึก](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) method provided by the [การนำเสนอ](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint ไปเป็น TIFF:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **แปลงงานนำเสนอเป็น TIFF สีขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) อนุญาตให้คุณระบุอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF สีขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getCompressionType) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

{{% alert color="info" title="หมายเหตุ" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setBwConversionMode) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด เพื่อกำหนดว่ารูปร่างแต่ละรายการควรแสดงอย่างไรเมื่อเปิดใช้งานโหมดแสดงผลสีขาว-ดำ ให้ใช้ [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setBlackWhiteMode) ดูตัวอย่างที่ [ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปร่าง](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes).
{{% /alert %}}

สมมติว่าเรามีไฟล์ "sample.pptx" พร้อมสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดนี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF สีขาว-ดำ:

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

![TIFF สีขาว-ดำ](TIFF_black_and_white.png)

## **แปลงงานนำเสนอเป็น TIFF ด้วยขนาดที่กำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดตามที่กำหนด คุณสามารถตั้งค่าที่ต้องการโดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/). ตัวอย่างเช่นเมธอด [setImageSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getImageSize) อนุญาตให้คุณกำหนดขนาดของภาพที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint ไปเป็นภาพ TIFF ด้วยขนาดที่กำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // ตั้งค่าประเภทการบีบอัด.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    ประเภทการบีบอัด:
        Default - ระบุโครงการบีบอัดเริ่มต้น (LZW).
        None - ระบุว่าไม่มีการบีบอัด.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // ความลึกขึ้นกับประเภทการบีบอัดและไม่สามารถตั้งค่าได้ด้วยตนเอง.

    // ตั้งค่า DPI ของภาพ.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // ตั้งขนาดภาพ.
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

## **แปลงงานนำเสนอเป็น TIFF ด้วยรูปแบบพิกเซลภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getPixelFormat) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้.

โค้ดนี้แสดงวิธีการแปลงงานนำเสนอ PowerPoint ไปเป็นภาพ TIFF ด้วยรูปแบบพิกเซลที่กำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, indexed.
        Format4bppIndexed - 4 บิตต่อพิกเซล, indexed.
        Format8bppIndexed - 8 บิตต่อพิกเซล, indexed.
        Format24bppRgb    - 24 บิตต่อพิกเซล, RGB.
        Format32bppArgb   - 32 บิตต่อพิกเซล, ARGB.
    */

    // บันทึกงานนำเสนอเป็น TIFF ด้วยขนาดภาพที่ระบุ.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="เคล็ดลับ" color="info" %}}
ลองดู [ตัวแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากงานนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF แยกกัน.

**มีขีดจำกัดจำนวนสไลด์ใด ๆ เมื่อแปลงงานนำเสนอเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่กำหนดข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงงานนำเสนอที่มีขนาดใดก็ได้เป็นรูปแบบ TIFF

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บรักษาไว้เมื่อแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ เนื่องจาก TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บรักษา มีเพียงภาพนิ่งของสไลด์ที่ถูกส่งออก.