---
title: การสกัดข้อความขั้นสูงจากงานนำเสนอใน PHP
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/php-java/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากงานนำเสนอ
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากงานนำเสนอ
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สกัดข้อความจากงานนำเสนอ PowerPoint และ OpenDocument อย่างรวดเร็วโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java. ปฏิบัติตามคู่มือขั้นตอนง่ายๆ ของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การดึงข้อความจากงานนำเสนอเป็นงานที่พบทั่วไปแต่ก็สำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือการนำเสนอรูปแบบ OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความสามารถเป็นสิ่งสำคัญสำหรับการวิเคราะห์, การทำอัตโนมัติ, การทำดัชนี, หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการดึงข้อความจากรูปแบบงานนำเสนอหลายประเภทอย่างมีประสิทธิภาพ รวมถึง PPT, PPTX, และ ODP โดยใช้ Aspose.Slides for PHP via Java คุณจะได้เรียนรู้วิธีการวนลูปผ่านองค์ประกอบของงานนำเสนออย่างเป็นระบบเพื่อดึงข้อความที่ต้องการอย่างแม่นยำ

## **ดึงข้อความจากสไลด์**

Aspose.Slides for PHP via Java มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/) ซึ่งคลาสนี้เปิดเผยเมธอดสแตติกที่มีการโอเวอร์โหลดหลายตัวสำหรับการดึงข้อความทั้งหมดจากงานนำเสนอหรือสไลด์

เพื่อดึงข้อความจากสไลด์ในงานนำเสนอ ให้ใช้เมธอด [getAllTextBoxes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#getAllTextBoxes) เมธอดนี้รับออบเจกต์ประเภท [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าเป็นอาร์เรย์ของออบเจกต์ประเภท [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/), คงรูปแบบข้อความไว้

โค้ดตัวอย่างต่อไปนี้ดึงข้อความทั้งหมดจากสไลด์แรกของงานนำเสนอ:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ดึงข้อความจากงานนำเสนอ**

เพื่อสแกนข้อความจากงานนำเสนอทั้งหมด ให้ใช้เมธอดสแตติก [getAllTextFrames](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#getAllTextFrames) ที่เปิดเผยโดยคลาส [SlideUtil](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. แรก คือออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่แทนงานนำเสนอ PowerPoint หรือ OpenDocument ซึ่งจะดึงข้อความจากมัน
1. สอง คือค่าชนิด `boolean` ที่ระบุว่าควรรวมสไลด์แม่ไว้เมื่อสแกนข้อความจากงานนำเสนอหรือไม่

เมธอดจะคืนค่าเป็นอาร์เรย์ของออบเจกต์ประเภท [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/), รวมถึงข้อมูลการจัดรูปแบบข้อความ โค้ดด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากงานนำเสนอรวมถึงสไลด์แม่ด้วย

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **การดึงข้อความแบบจัดหมวดหมู่และรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับดึงข้อความทั้งหมดจากงานนำเสนอ:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดผลลัพธ์การดึงข้อความและสามารถตั้งค่าเป็นค่าเหล่านี้ได้:
- `Unarranged` - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- `Arranged` - ข้อความจะถูกจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้ได้เมื่อความเร็วเป็นสิ่งสำคัญ; มันเร็วกว่าโหมด Arranged

[PresentationText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationtext/) แทนข้อความดิบที่ดึงจากงานนำเสนอ เมธอด `getSlidesText` ของมันคืนค่าเป็นอาร์เรย์ของออบเจกต์ที่แต่ละออบเจกต์แทนข้อความบนสไลด์ที่สอดคล้องแต่ละสไลด์ ออบเจกต์ที่คืนมามีเมธอดต่อไปนี้:

- `getText` - ข้อความภายในรูปร่างของสไลด์
- `getMasterText` - ข้อความภายในรูปร่างของสไลด์แม่ที่เชื่อมโยงกับสไลด์นี้
- `getLayoutText` - ข้อความภายในรูปร่างของสไลด์เลย์เอาต์ที่เชื่อมโยงกับสไลด์นี้
- `getNotesText` - ข้อความภายในรูปร่างของสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์นี้
- `getCommentsText` - ข้อความภายในความคิดเห็นที่เชื่อมโยงกับสไลด์นี้

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ประมวลผลงานนำเสนอขนาดใหญ่ในการดึงข้อความเร็วแค่ไหน?**

Aspose.Slides ได้รับการปรับให้ทำงานด้วยประสิทธิภาพสูงและสามารถประมวลผลแม้ [งานนำเสนอขนาดใหญ่](/slides/th/php-java/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์การประมวลผลแบบเรียลไทม์หรือแบบเป็นกลุ่ม

**Aspose.Slides สามารถดึงข้อความจากตารางและแผนภูมิภายในงานนำเสนอได้หรือไม่?**

ได้ Aspose.Slides สามารถดึงข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและวัตถุที่เกี่ยวข้องกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างการนำเสนอทั่วไปได้

**ฉันต้องมีไลเซนซ์ Aspose.Slides พิเศษเพื่อดึงข้อความจากงานนำเสนอหรือไม่?**

คุณสามารถดึงข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/php-java/licensing/), เช่น การประมวลผลจำนวนสไลด์ที่จำกัด สำหรับการใช้งานโดยไม่มีข้อจำกัดและเพื่อจัดการงานนำเสนอขนาดใหญ่ การซื้อไลเซนซ์เต็มรุ่นจึงเป็นที่แนะนำ