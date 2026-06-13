---
title: แปลง PPT และ PPTX เป็น JPG ใน PHP
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/php-java/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- PHP
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน PHP ด้วย Aspose.Slides for PHP โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้"
---
## **บทนำ**

การแปลงการนำเสนอ PowerPoint และ OpenDocument ไปเป็นภาพ JPG ช่วยให้การแชร์สไลด์ การเพิ่มประสิทธิภาพการทำงาน และการฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชันง่ายขึ้น Aspose.Slides ช่วยให้คุณแปลงไฟล์ PPTX, PPT และ ODP เป็นภาพ JPEG คุณภาพสูงได้ คู่มือนี้อธิบายวิธีการแปลงที่แตกต่างกัน

ด้วยคุณลักษณะเหล่านี้ การสร้างตัวชมรมการนำเสนอของคุณเองและสร้างภาพย่อสำหรับแต่ละสไลด์ก็ทำได้ง่ายขึ้น ซึ่งอาจเป็นประโยชน์หากคุณต้องการปกป้องสไลด์จากการคัดลอกหรือแสดงการนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides ช่วยให้คุณแปลงทั้งการนำเสนอหรือสไลด์เฉพาะเป็นรูปแบบภาพได้

## **แปลง PowerPoint PPT/PPTX เป็น JPG**

1. สร้างอินสแตนซ์ของประเภท [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ็อบเจ็กต์สไลด์ของประเภท [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) จากคอลเลกชัน [Presentation::getSlides()](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation#getSlides--)  
3. สร้างภาพย่อของแต่ละสไลด์แล้วแปลงเป็น JPG วิธีการ [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) ใช้เพื่อดึงภาพย่อของสไลด์ วิธีการ [getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) ต้องถูกเรียกจากสไลด์ที่ต้องการของประเภท [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) โดยส่งสเกลของภาพย่อที่ต้องการเข้าไปในเมธอด  
4. หลังจากได้ภาพย่อของสไลด์แล้ว เรียกใช้เมธอด [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) จากอ็อบเจ็กต์ภาพย่อ ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเข้าไปในเมธอด

{{% alert color="primary" %}}
**หมายเหตุ**: การแปลง PPT/PPTX เป็น JPG แตกต่างจากการแปลงเป็นประเภทอื่นใน Aspose.Slides API สำหรับประเภทอื่นมักใช้เมธอด [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/save/) แต่ที่นี่ต้องใช้เมธอด [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))
{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # สร้างภาพเต็มสเกล
      $slideImage = $sld->getImage(1.0, 1.0);
      # บันทึกภาพลงดิสก์ในรูปแบบ JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แปลง PowerPoint PPT/PPTX เป็น JPG พร้อมกำหนดขนาดเอง**

หากต้องการเปลี่ยนขนาดของภาพย่อและภาพ JPG ที่ได้ สามารถตั้งค่าตัวแปร *ScaleX* และ *ScaleY* โดยส่งค่าเหล่านั้นเข้าไปในเมธอด [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage) ได้ดังนี้:

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # กำหนดมิติ
    $desiredX = 1200;
    $desiredY = 800;
    # รับค่ามาตราส่วนของ X และ Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # สร้างภาพเต็มสเกล
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # บันทึกภาพลงดิสก์ในรูปแบบ JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เรนเดอร์คอมเมนต์เมื่อบันทึกสไลด์เป็นภาพ**

Aspose.Slides for PHP via Java มีฟีเจอร์ที่ช่วยให้คุณเรนเดอร์คอมเมนต์ในสไลด์ของการนำเสนอเมื่อทำการแปลงสไลด์เป็นภาพ โค้ด PHP ตัวอย่างต่อไปนี้แสดงการทำงาน:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose มีแอปเว็บ **Collage** ฟรีที่คุณสามารถใช้รวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG เป็น PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) ฯลฯ

โดยใช้หลักการเดียวกันที่อธิบายในบทความนี้ คุณสามารถแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่งได้ สำหรับข้อมูลเพิ่มเติมดูหน้าต่อไปนี้: แปลง [image to JPG](https://products.aspose.com/slides/th/php-java/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/php-java/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/php-java/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/php-java/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/php-java/conversion/svg-to-png/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงหลายสไลด์เป็น JPG ในการดำเนินการเดียว

**การแปลงรองรับ SmartArt, แผนภูมิ และออบเจ็กต์ซับซ้อนอื่นๆ หรือไม่?**  
ใช่, Aspose.Slides เรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่นๆ อย่างไรก็ตามความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป

**มีข้อจำกัดเรื่องจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**  
Aspose.Slides เองไม่ได้กำหนดขีดจำกัดที่เข้มงวดเกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้ อย่างไรก็ตามคุณอาจเจอข้อผิดพลาดหน่วยความจำไม่เพียงพอเมื่อทำงานกับการนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่นๆ สำหรับการแปลง PPT/PPTX เป็นภาพ เช่น:

- [การแปลง PPT/PPTX เป็น SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/)