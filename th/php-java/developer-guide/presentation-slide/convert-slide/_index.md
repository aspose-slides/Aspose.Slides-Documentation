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
- สไลด์เป็น EMF
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงสไลด์จากการนำเสนอ PPT, PPTX, และ ODP เป็น PNG, JPEG, GIF, TIFF, EMF และรูปแบบภาพอื่น ๆ ใน PHP ด้วย Aspose.Slides."
---
## **บทนำ**

Aspose.Slides for PHP via Java สามารถแสดงผลสไลด์แต่ละสไลด์จากงานนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบ PNG, JPEG, GIF, TIFF และรูปแบบภาพอื่น ๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. เลือกสไลด์ที่คุณต้องการแสดงผล.
3. หากจำเป็น ให้กำหนดค่าการแสดงผลด้วยคลาส [RenderingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/) หรือ [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) .
4. เรียกเมธอด [Slide::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) เมธอดนี้จะคืนค่าเป็นอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) .
5. เรียกเมธอด [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save) และระบุรูปแบบการส่งออกด้วยค่า [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/) .

## **แปลงสไลด์เป็นภาพ PNG**

การแปลงที่ง่ายที่สุดใช้การตั้งค่าการแสดงผลเริ่มต้น. อ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) ที่ได้สามารถประมวลผลในหน่วยความจำหรือบันทึกลงไฟล์ได้

ตัวอย่าง PHP ด้านล่างนี้แสดงสไลด์แรกและบันทึกเป็นภาพ PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **แปลงสไลด์เป็นภาพโดยกำหนดขนาดกำหนดเอง**

ใช้เมธอดโอเวอร์โหลดของ [Slide::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) ที่รับค่าชนิด [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) เพื่อแสดงสไลด์ด้วยขนาดพิกเซลที่กำหนดอย่างแม่นยำ

ตัวอย่างต่อไปนี้สร้างภาพ JPEG ขนาด 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **แปลงสไลด์พร้อมบันทึกย่อและความคิดเห็นเป็นภาพ**

โดยค่าเริ่มต้น ภาพสไลด์จะไม่รวมบันทึกย่อหรือความคิดเห็น. ส่งอ็อบเจ็กต์ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/) ไปยังเมธอด [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) เพื่อกำหนดตำแหน่งที่บันทึกย่อและความคิดเห็นจะแสดง

ตัวอย่างต่อไปนี้วางบันทึกย่อที่ตัดเอาไว้ด้านล่างสไลด์และความคิดเห็นที่ด้านขวาของสไลด์:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
สำหรับการแปลงสไลด์เป็นภาพ อย่าใช้ [BottomFull](https://reference.aspose.com/slides/th/php-java/aspose.slides/notespositions/) กับเมธอด [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/th/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). บันทึกย่ออาจมีข้อความมากกว่าขนาดภาพที่กำหนดได้. ใช้ [BottomTruncated](https://reference.aspose.com/slides/th/php-java/aspose.slides/notespositions/) แทน
{{% /alert %}}

## **แปลงสไลด์เป็นภาพโดยใช้ตัวเลือก TIFF**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/tiffoptions/) ให้คุณควบคุมขนาด, ความละเอียด, และคุณลักษณะอื่น ๆ ของภาพ TIFF ที่แสดงผล

ตัวอย่างต่อไปนี้แสดงสไลด์แรกเป็นภาพ TIFF ขนาด 2160 × 2880 ที่ 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
การรองรับ TIFF ไม่ได้รับการรับประกันใน Java เวอร์ชันก่อน JDK 9
{{% /alert %}}

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

วนลูปผ่านคอลเลกชันสไลด์เพื่อแปลงการนำเสนอทั้งหมดเป็นชุดของภาพ. สไลด์ที่ซ่อนจะรวมอยู่ด้วยเว้นแต่ว่าคุณจะข้ามโดยเจตนาที่จะทำเช่นนั้น

ตัวอย่างต่อไปนี้แสดงสไลด์ทุกสไลด์เป็นภาพ JPEG โดยใช้ตัวคูณสเกลแนวนอนและแนวตั้งเท่ากับ 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **สร้างเอาต์พุต Enhanced Metafile**

Enhanced Metafile (EMF) มีประโยชน์เมื่อกราฟิกแบบเวกเตอร์ต้องแลกเปลี่ยนกับ Microsoft Office หรือแอปพลิเคชัน Windows อื่น ๆ ที่รองรับ Windows metafiles. แตกต่างจากภาพแบบพิกเซล, EMF สามารถคงการวาดเวกเตอร์ที่สามารถสเกลได้โดยไม่สูญเสียความคมชัด. อย่างไรก็ตาม EMF เป็นรูปแบบความเข้ากันได้สำหรับแอปพลิเคชันที่สนับสนุน Windows metafile เป็นหลัก, ไม่ใช่รูปแบบแลกเปลี่ยนสากล. นอกจากนี้ เนื้อหาสไลด์ที่ซับซ้อนเช่นภาพบิตแมปและเอฟเฟ็กต์บางอย่างอาจถูกเก็บเป็นองค์ประกอบเรสเตอร์ภายในคอนเทนเนอร์เมตาไฟล์เวกเตอร์

### **ส่งออกสไลด์เป็น EMF**

เมธอด [Slide::writeAsEmf](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#writeAsEmf) เขียนสไลด์ไปยังสตรีมเป้าหมายในรูปแบบ EMF. ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, เลือกสไลด์แรก, และเขียนลงสตรีมไฟล์ EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

ผู้เรียกใช้งานเป็นเจ้าของสตรีมที่ส่งให้กับ [Slide::writeAsEmf](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#writeAsEmf) และต้องรับผิดชอบปิดสตรีมนั้นตามที่แสดงด้านบน

### **แปลงภาพ SVG เป็น EMF แล้วเพิ่มเข้าไปในงานนำเสนอ**

ใช้ [SvgImage::writeAsEmf](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/#writeAsEmf) เพื่อแปลงเนื้อหา SVG เป็น EMF. ไบต์ที่ได้สามารถเพิ่มเข้าไปในงานนำเสนอผ่าน [ImageCollection::addImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/#addImage) และวางบนสไลด์ด้วย [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addPictureFrame)

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/th/php-java/aspose.slides/svgimage/#writeAsEmf) ไม่ได้เป็นเจ้าของสตรีมปลายทาง. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) เก็บข้อมูลที่สร้างทั้งหมดในหน่วยความจำ, ดังนั้นจึงไม่จำเป็นต้องรีเซ็ตตำแหน่งก่อนเรียก `toByteArray`. อาร์เรย์ไบต์ที่ 반환ยังคงใช้ได้หลังจากสตรีมปิด

การสร้าง EMF มีให้ใช้งานบนระบบปฏิบัติการที่สนับสนุนโดย Aspose.Slides for PHP via Java และการกำหนดค่า JDK ที่เลือก, แต่การแสดงผลอาจแตกต่างกันระหว่างแพลตฟอร์มเมื่อฟอนต์หรือกราฟิกที่จำเป็นไม่มี. ควรติดตั้งฟอนต์ที่ใช้ในเนื้อหาแหล่งหรือกำหนดการแทนที่ที่เหมาะสม, ปฏิบัติตาม [platform requirements](/slides/th/php-java/system-requirements/) สำหรับ Aspose.Slides for PHP via Java, และตรวจสอบผลลัพธ์ในแอปพลิเคชันที่ใช้ EMF เป้าหมาย. แอปพลิเคชันบน Linux และ macOS มักมีการสนับสนุนการแสดงและแก้ไข Windows metafile ที่จำกัดหรือไม่สอดคล้องกัน

## **การแสดงผลสี Emoji**

{{% alert title="Note" color="info" %}}
เพื่อแสดงสี Emoji อย่างถูกต้องเมื่อแปลงสไลด์งานนำเสนอเป็นภาพ, ฟอนต์ Emoji ที่ใช้ในงานนำเสนอจำเป็นต้องติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง. ตัวอย่างเช่น หากงานนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้หายไป, Emoji อาจปรากฏเป็นสีเดียวในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการแสดงสไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่. เมธอด [Slide::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) ให้ภาพสไลด์แบบคงที่และไม่ส่งออกแอนิเมชัน

**สไลด์ที่ซ่อนสามารถส่งออกเป็นภาพได้หรือไม่?**

ได้. สไลด์ที่ซ่อนสามารถแสดงผลได้เช่นสไลด์ทั่วไป. ให้รวมสไลด์เหล่านั้นในลูปการประมวลผลตามตัวอย่างข้างต้น

**เงาและเอฟเฟ็กต์อื่น ๆ จะถูกเก็บไว้ในภาพสไลด์หรือไม่?**

ได้. Aspose.Slides จะเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟ็กต์กราฟิกที่สนับสนุนอื่น ๆ ในภาพสไลด์