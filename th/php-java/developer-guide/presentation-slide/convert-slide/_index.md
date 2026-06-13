---
title: แปลงสไลด์การนำเสนอเป็นภาพใน PHP
linktitle: สไลด์เป็นภาพ
type: docs
weight: 35
url: /th/php-java/convert-slide/
keywords: 
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพโดยใช้ Aspose.Slides for PHP via Java — การเรนเดอร์ที่รวดเร็วและคุณภาพสูง พร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for PHP via Java ช่วยให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปภาพหลายรูปแบบได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่นๆ

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/) 
2. สร้างรูปภาพสไลด์โดยเรียกใช้เมธอด [getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage)

ใน Aspose.Slides for PHP via Java, [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) คือคลาสที่ช่วยให้คุณทำงานกับรูปภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้คลาสนี้เพื่อบันทึกรูปภาพในหลากหลายรูปแบบ (BMP, JPG, PNG ฯลฯ).

## **แปลงสไลด์เป็นบิตแมพและบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจ็กต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือแปลงสไลด์เป็นบิตแมพแล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบอื่นตามที่ต้องการได้

โค้ดนี้แสดงวิธีแปลงสไลด์แรกของงานนำเสนอเป็นอ็อบเจ็กต์บิตแมพและจากนั้นบันทึกรูปภาพในรูปแบบ PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกของการนำเสนอเป็นบิตแมพ.
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

## **แปลงสไลด์เป็นรูปภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการรูปภาพที่มีขนาดเฉพาะ ใช้ overload ของเมธอด [getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) เพื่อแปลงสไลด์เป็นรูปภาพที่มีความกว้างและความสูงตามที่กำหนด

ตัวอย่างโค้ดนี้แสดงวิธีทำเช่นนั้น:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // แปลงสไลด์แรกของการนำเสนอเป็นบิตแมพด้วยขนาดที่กำหนด.
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

## **แปลงสไลด์ที่มีบันทึกและความคิดเห็นเป็นรูปภาพ**

บางสไลด์อาจมีบันทึกและความคิดเห็น

Aspose.Slides มีคลาสสองคลาสคือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นรูปภาพ ทั้งสองคลาสมีเมธอน `setSlidesLayoutOptions` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์บันทึกและความคิดเห็นบนสไลด์เมื่อแปลงเป็นรูปภาพ

โดยใช้คลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกและความคิดเห็นในภาพที่ได้

โค้ดนี้แสดงวิธีแปลงสไลด์ที่มีบันทึกและความคิดเห็น:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // ตั้งค่าตำแหน่งของบันทึก.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // ตั้งค่าตำแหน่งของความคิดเห็น.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // ตั้งค่าความกว้างของพื้นที่ความคิดเห็น.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // ตั้งค่าสีสำหรับพื้นที่ความคิดเห็น.

    // สร้างตัวเลือกการเรนเดอร์.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // แปลงสไลด์แรกของการนำเสนอเป็นภาพ.
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
ในกระบวนการแปลงสไลด์เป็นรูปภาพใดๆ เมธอด [setNotesPosition](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) ไม่สามารถใช้ค่า `BottomFull` (เพื่อระบุตำแหน่งของบันทึก) ได้ เนื่องจากข้อความของบันทึกอาจยาวเกินไป ทำให้ไม่สามารถใส่ในขนาดภาพที่กำหนด
{{% /alert %}} 

## **แปลงสไลด์เป็นรูปภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ให้การควบคุมภาพ TIFF ที่ได้อย่างละเอียดโดยให้คุณระบุพารามิเตอร์ต่างๆ เช่น ขนาด, ความละเอียด, พาเลตสี, และอื่น ๆ

โค้ดนี้แสดงกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อสร้างภาพขาว-ดำที่ความละเอียด 300 DPI และขนาด 2160 × 2800:

```php
// โหลดไฟล์การนำเสนอ.
$presentation = new Presentation("sample.pptx");
try {
    // ดึงสไลด์แรกจากการนำเสนอ.
    $slide = $presentation->getSlides()->get_Item(0);

    // ตั้งค่าการกำหนดของภาพ TIFF ที่จะส่งออก.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // ตั้งค่าขนาดภาพ.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // ตั้งค่ารูปแบบพิกเซล (ขาวดำ).
    $options->setDpiX(300);                                              // ตั้งค่าความละเอียดแนวนอน.
    $options->setDpiY(300);                                              // ตั้งค่าความละเอียดแนวตั้ง.
    
    // แปลงสไลด์เป็นภาพด้วยการตั้งค่าที่ระบุ.
    $image = $slide->getImage($options);
    try {
        // บันทึกรูปภาพในรูปแบบ TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
การสนับสนุน TIFF ไม่ได้รับการรับประกันในเวอร์ชันก่อน JDK 9.
{{% /alert %}} 

## **แปลงสไลด์ทั้งหมดเป็นรูปภาพ**

Aspose.Slides ให้คุณแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นรูปภาพ ทำให้สามารถแปลงงานนำเสนอทั้งหมดเป็นลำดับของรูปภาพได้

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์ทั้งหมดในงานนำเสนอเป็นรูปภาพด้วย PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // เรนเดอร์การนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // ควบคุมสไลด์ที่ซ่อน (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // แปลงสไลด์เป็นภาพ.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // บันทึกรูปภาพในรูปแบบ JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `getImage` จะบันทึกเฉพาะภาพนิ่งของสไลด์ โดยไม่มีแอนิเมชัน

**สไลด์ที่ซ่อนสามารถส่งออกเป็นรูปภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่าได้รวมสไลด์เหล่านั้นในลูปการประมวลผล

**รูปภาพสามารถบันทึกพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อต้องบันทึกสไลด์เป็นรูปภาพ