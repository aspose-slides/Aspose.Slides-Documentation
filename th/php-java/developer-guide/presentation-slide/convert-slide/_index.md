---
title: แปลงสไลด์การนำเสนอเป็นรูปภาพใน PHP
linktitle: สไลด์เป็นรูปภาพ
type: docs
weight: 35
url: /th/php-java/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นรูปภาพ
- บันทึกสไลด์เป็นรูปภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็น bitmap
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงสไลด์จากไฟล์ PPT, PPTX และ ODP เป็นรูปภาพโดยใช้ Aspose.Slides for PHP via Java — การเรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for PHP via Java ช่วยให้คุณสามารถแปลงสไลด์งานนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปภาพหลายรูปแบบได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ

ในการแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/)
2. สร้างรูปภาพของสไลด์โดยเรียกเมธอด [getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage)

ใน Aspose.Slides for PHP via Java, คลาส [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) เป็นคลาสที่ให้คุณทำงานกับรูปภาพที่กำหนดด้วยข้อมูลพิกเซล คุณสามารถใช้คลาสนี้เพื่อบันทึกรูปภาพในรูปแบบที่หลากหลาย (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็น Bitmap แล้วบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจ็กต์ bitmap แล้วนำไปใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็น bitmap แล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ดนี้แสดงวิธีการแปลงสไลด์แรกของงานนำเสนอเป็นอ็อบเจ็กต์ bitmap แล้วบันทึกรูปภาพเป็นรูปแบบ PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็น bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // บันทึกรูปภาพในรูปแบบ PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **แปลงสไลด์เป็นรูปภาพด้วยขนาดกำหนดเอง**

คุณอาจต้องการรับรูปภาพที่มีขนาดเฉพาะ ใช้การโอเวอร์โหลดจากเมธอด [getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) เพื่อแปลงสไลด์เป็นรูปภาพที่มีความกว้างและความสูงตามที่กำหนด

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำเช่นนั้น:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกในงานนำเสนอเป็น bitmap ด้วยขนาดที่ระบุ.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // บันทึกรูปภาพในรูปแบบ JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **แปลงสไลด์ที่มีโน้ตและคอมเมนต์เป็นรูปภาพ**

สไลด์บางสไลด์อาจมีโน้ตและคอมเมนต์

Aspose.Slides มีคลาสสองตัวคือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/) ที่ช่วยให้คุณควบคุมการเรนเดอร์สไลด์เป็นรูปภาพ ทั้งสองคลาสมีเมธอด `setSlidesLayoutOptions` ซึ่งให้คุณกำหนดการเรนเดอร์ของโน้ตและคอมเมนต์บนสไลด์เมื่อแปลงเป็นรูปภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับโน้ตและคอมเมนต์ในรูปภาพที่ได้

โค้ดนี้แสดงวิธีการแปลงสไลด์ที่มีโน้ตและคอมเมนต์:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // ตั้งค่าตำแหน่งของโน้ต.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // ตั้งค่าตำแหน่งของคอมเมนต์.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // ตั้งค่าความกว้างของพื้นที่คอมเมนต์.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // ตั้งค่าสีสำหรับพื้นที่คอมเมนต์.

    // สร้างตัวเลือกการเรนเดอร์.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // บันทึกรูปภาพในรูปแบบ GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นรูปภาพใด ๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ไม่สามารถใช้ `BottomFull` (เพื่อระบุตำแหน่งสำหรับโน้ต) ได้ เนื่องจากข้อความโน้ตอาจใหญ่เกินไป ทำให้ไม่สามารถใส่ในขนาดรูปภาพที่กำหนดได้
{{% /alert %}} 

## **แปลงสไลด์เป็นรูปภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ให้การควบคุมที่ละเอียดขึ้นสำหรับภาพ TIFF ที่ได้ โดยคุณสามารถกำหนดพารามิเตอร์ต่าง ๆ เช่น ขนาด, ความละเอียด, พาเลตสี ฯลฯ

โค้ดนี้แสดงกระบวนการแปลงที่ใช้ TIFF Options เพื่อสร้างภาพขาว‑ดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```php
// โหลดไฟล์งานนำเสนอ.
$presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากงานนำเสนอ.
    $slide = $presentation->getSlides()->get_Item(0);

    // กำหนดค่าการตั้งค่าของภาพ TIFF ผลลัพธ์.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // ตั้งค่าขนาดภาพ.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // ตั้งค่ารูปแบบพิกเซล (ขาว‑ดำ).
    $options->setDpiX(300);                                              // ตั้งค่าความละเอียดแนวนอน.
    $options->setDpiY(300);                                              // ตั้งค่าความละเอียดแนวตั้ง.
    
    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    $image = $slide->getImage($options);
    try {
        // บันทึกภาพในรูปแบบ TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
การสนับสนุน TIFF ไม่รับประกันในเวอร์ชันก่อน JDK 9
{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นรูปภาพ**

Aspose.Slides ช่วยให้คุณสามารถแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นรูปภาพได้อย่างง่ายดาย ทำให้การแปลงงานนำเสนอทั้งหมดเป็นชุดของรูปภาพเป็นไปได้

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นรูปภาพใน PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // แปลงสไลด์เป็นภาพ.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // บันทึกภาพในรูปแบบ JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **การเรนเดอร์สี Emoji**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การแสดงสีอีโมจิอย่างถูกต้องเมื่อแปลงสไลด์งานนำเสนอเป็นรูปภาพ ฟอนต์อีโมจิที่ใช้ในงานนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ อีโมจิอาจถูกแสดงเป็นขาว‑ดำในรูปภาพที่ส่งออก
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการแสดงภาพสไลด์พร้อมแอนิเมชันหรือไม่?**  
ไม่, เมธอด `getImage` จะบันทึกเฉพาะภาพคงที่ของสไลด์โดยไม่มีแอนิเมชัน

**สไลด์ที่ถูกซ่อนได้สามารถส่งออกเป็นรูปภาพได้หรือไม่?**  
ได้, สไลด์ที่ถูกซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ทั่วไป เพียงตรวจสอบให้แน่ใจว่าถูกรวมอยู่ในลูปการประมวลผล

**สามารถบันทึกรูปภาพพร้อมเงาและเอฟเฟ็กต์ได้หรือไม่?**  
ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟ็กต์กราฟิกอื่น ๆ เมื่อตั้งค่าบันทึกสไลด์เป็นรูปภาพ