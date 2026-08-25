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

TIFF (**Tagged Image File Format**) คือรูปแบบไฟล์ภาพเรสเตอร์แบบไม่สูญเสียคุณภาพที่ได้รับความนิยมอย่างกว้างขวาง เนื่องจากคุณภาพยอดเยี่ยมและการเก็บรายละเอียดของกราฟิกได้อย่างสมบูรณ์ นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อคงหลายชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมของภาพ

โดยใช้ Aspose.Slides คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย ทำให้การนำเสนอของคุณคงความละเอียดสูงสุดของภาพ

## **แปลงงานพรีเซนเทชันเป็น TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) คุณสามารถแปลงงานพรีเซนเทชัน PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่ได้จะสอดคล้องกับขนาดสไลด์เริ่มต้น

โค้ดตัวอย่างแสดงวิธีแปลงงานพรีเซนเทชัน PowerPoint เป็น TIFF:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    // บันทึกงานนำเสนอเป็น TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **แปลงงานพรีเซนเทชันเป็น TIFF ขาว-ดำ**

เมธอด [setBwConversionMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ให้คุณกำหนดอัลกอริทึมที่ใช้เมื่อแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค่านี้ใช้ได้เฉพาะเมื่อเมธอด [setCompressionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getCompressionType) ถูกตั้งค่าเป็น `CCITT4` หรือ `CCITT3`

{{% alert color="info" title="หมายเหตุ" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#setBwConversionMode) เป็นการตั้งค่าระดับการส่งออกที่เลือกอัลกอริทึมการแปลงพิกเซลสำหรับภาพ TIFF ทั้งหมด หากต้องการกำหนดวิธีการแสดงผลของรูปร่างแต่ละรูปเมื่อเปิดโหมดแสดงผลขาว-ดำ ให้ใช้เมธอด [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setBlackWhiteMode) ดูตัวอย่างได้ที่ [Control Black-and-White Rendering for Shapes](/slides/th/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes)
{{% /alert %}}

สมมติว่าเรามีไฟล์ “sample.pptx” ที่มีสไลด์ดังต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ดตัวอย่างแสดงวิธีแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

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

## **แปลงงานพรีเซนเทชันเป็น TIFF ด้วยขนาดกำหนดเอง**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถตั้งค่าตามที่ต้องการได้โดยใช้เมธอดที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ตัวอย่างเช่น เมธอด [setImageSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getImageSize) ให้คุณระบุขนาดของภาพผลลัพธ์

โค้ดตัวอย่างแสดงวิธีแปลงงานพรีเซนเทชัน PowerPoint เป็นภาพ TIFF ที่มีขนาดกำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
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

    // ตั้งค่าขนาดภาพ.
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

## **แปลงงานพรีเซนเทชันเป็น TIFF ด้วยรูปแบบพิกเซลของภาพที่กำหนดเอง**

โดยใช้เมธอด [setPixelFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/#getPixelFormat) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) คุณสามารถกำหนดรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ผลลัพธ์ได้

โค้ดตัวอย่างแสดงวิธีแปลงงานพรีเซนเทชัน PowerPoint เป็นภาพ TIFF ที่มีรูปแบบพิกเซลกำหนดเอง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat มีค่าต่อไปนี้ (ตามที่ระบุในเอกสาร):
        Format1bppIndexed - 1 บิตต่อพิกเซล, แบบดัชนี.
        Format4bppIndexed - 4 บิตต่อพิกเซล, แบบดัชนี.
        Format8bppIndexed - 8 บิตต่อพิกเซล, แบบดัชนี.
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
ลองดูเครื่องมือแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose ที่ [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online)
{{% /alert %}}

## **FAQ**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงงานพรีเซนเทชันทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้เลย Aspose.Slides รองรับการแปลงสไลด์เดี่ยวจากงานพรีเซนเทชัน PowerPoint หรือ OpenDocument เป็นภาพ TIFF แยกกัน

**มีขีดจำกัดจำนวนสไลด์เมื่อแปลงงานพรีเซนเทชันเป็น TIFF หรือไม่?**

ไม่มี Aspose.Slides ไม่ได้กำหนดข้อจำกัดใด ๆ สำหรับจำนวนสไลด์ คุณสามารถแปลงงานพรีเซนเทชันขนาดใดก็ได้เป็นรูปแบบ TIFF

**ภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะถูกเก็บไว้เมื่อตอนแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่เช่นนั้น TIFF เป็นรูปแบบภาพนิ่ง ดังนั้นภาพเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่ถูกเก็บไว้ มีเพียงภาพนิ่งของสไลด์เท่านั้นที่ถูกส่งออก