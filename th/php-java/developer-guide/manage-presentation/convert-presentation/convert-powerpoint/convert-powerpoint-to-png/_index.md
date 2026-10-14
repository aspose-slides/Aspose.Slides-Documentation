---
title: แปลงสไลด์ PowerPoint เป็น PNG ใน PHP
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/php-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- PHP
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงอย่างรวดเร็วด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงสไลด์นำเสนอเป็นภาพ PNG โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถโหลดไฟล์นำเสนอในรูปแบบเช่น PPT, PPTX และ ODP, แสดงผลแต่ละสไลด์และบันทึกเป็นภาพ PNG แยกใบได้

ตัวอย่างด้านล่างแสดงการเรนเดอร์ที่อัตราส่วนเริ่มต้น การเพิ่มอัตราส่วน การระบุขนาดผลลัพธ์เป็นพิกเซล และการเลือกสไตล์การเรนเดอร์แบบไล่สี

## **แปลง PowerPoint เป็น PNG**

โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเข้าถึงสไลด์ผ่านคอลเลกชัน [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) ตัวอย่างนี้เรนเดอร์ทุกสไลด์โดยใช้ [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) โดยไม่ระบุพารามิเตอร์เพื่อสร้างรูปย่อ จากนั้นเรียก [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) พร้อมกับ [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) เพื่อบันทึกแต่ละสไลด์ที่เรนเดอร์เป็นภาพ PNG

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
การเรียกใช้ [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) โดยไม่มีพารามิเตอร์จะเรนเดอร์ที่สเกล 0.2 ตัวอย่างเช่น สไลด์ที่มีขนาด 720 × 540 พอยต์ จะสร้างรูปย่อขนาด 144 × 108 พิกเซล เพื่อควบคุมขนาดผลลัพธ์ ให้ใช้การเรียกที่รับสเกลหรือขนาดภาพที่ระบุอย่างชัดเจนตามตัวอย่างด้านล่าง
{{% /alert %}}

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

ส่งค่าอัตราส่วนแนวนอนและแนวตั้งไปยัง [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) เพื่อควบคุมขนาดที่เรนเดอร์ ในตัวอย่างนี้ค่าอัตราส่วนทั้งสองเท่ากับ 2 ดังนั้นสไลด์ที่มีขนาด 720 Г— 540 พอยต์ จะสร้างภาพขนาด 1440 Г— 1080 พิกเซล ค่าอัตราส่วนเท่าเดิมจะรักษาอัตราส่วนของสไลด์ไว้ ภาพแต่ละภาพจะถูกบันทึกในรูปแบบ PNG ด้วย [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PNG ด้วยขนาดที่กำหนดเอง**

เพื่อระบุขนาดผลลัพธ์เป็นพิกเซล ให้ส่งขนาดไปยัง [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) แทนการใช้สเกล ตัวอย่างนี้เรนเดอร์ทุกสไลด์ที่ 960 Г— 720 พิกเซลและบันทึกผลลัพธ์ด้วย [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) เลือกขนาดที่ตรงกับอัตราส่วนของสไลด์เพื่อป้องกันการยืดภาพ

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **เลือกสไตล์การเรนเดอร์แบบไล่สี**

สมมติว่าหนึ่งสไลด์มีการเติมสีไล่สี แต่การเปลี่ยนแปลงในไฟล์ PNG ที่ส่งออกดูอ่อนกว่าหรือแตกต่างจากที่คุณเห็นใน PowerPoint คุณสามารถใช้เมธอด [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) ที่สืบทอดจาก [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) เพื่อกำหนดวิธีการเรนเดอร์ไล่สีได้

ดาวน์โหลดไฟล์ [gradient-styles.pptx](gradient-styles.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์มีไล่สีเชิงเส้นสองแบบ: สีไซอานไปสีส้มที่ด้านบนและสีน้ำเงินไปสีเหลืองที่ด้านล่าง แต่ละไล่สีมีจุดหยุดสองจุดที่ 0% และ 100%

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและเรนเดอร์สไลด์แรกเดียวกันในทั้งสองโหมดโดยใช้ [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

รูปภาพด้านล่างแสดงผลลัพธ์จากสไลด์เดียวกัน โดยมีไล่สีทั้งสองแบบในแต่ละภาพ:

| Default | PowerPointUI |
| --- | --- |
| ![ไล่สีจากสีไซอานไปสีส้มและจากสีน้ำเงินไปสีเหลืองที่เรนเดอร์ด้วย Default](gradient-Default.png) | ![ไล่สีเดียวกันที่เรนเดอร์ด้วย PowerPointUI](gradient-PowerPointUI.png) |

ในตัวอย่างนี้ `Default` ให้สีกลางที่อ่อนกว่า ในขณะที่ `PowerPointUI` ให้สีกลางที่เข้มกว่า ความแตกต่างขึ้นอยู่กับสีและจุดหยุดในไล่สี

เลือก `Default` เมื่อผลลัพธ์มาตรฐานของ Aspose.Slides พอใจคุณ ลองใช้ `PowerPointUI` เมื่อคุณต้องการให้ผลลัพธ์ตรงกับการแสดงผลใน PowerPoint เปรียบเทียบผลลัพธ์ทั้งสองกับผลลัพธ์ที่คุณต้องการ; ไม่มีโหมดใดที่ดีกันเสมอ

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกรูปร่างเฉพาะ เช่น แผนภูมิหรือรูปภาพ แทนการส่งออกสไลด์ทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับการ [สร้างภาพย่อสำหรับรูปร่างแต่ละอัน](/slides/th/php-java/create-shape-thumbnails/) ซึ่งทำให้คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ ใช้อินสแตนซ์การนำเสนอแยกกันสำหรับแต่ละเธรดหรือแต่ละกระบวนการ; [ไม่แชร์อินสแตนซ์เดียวกันข้ามเธรด](/slides/th/php-java/multithreading/).

**ข้อจำกัดของโหมดประเมินเมื่อส่งออกเป็น PNG มีอะไรบ้าง?**

โหมดประเมิน จะเพิ่มลายน้ำไปยังภาพผลลัพธ์และใช้ [ข้อจำกัดอื่น](/slides/th/php-java/licensing/) จนกว่าจะมีการใช้ใบอนุญาต.