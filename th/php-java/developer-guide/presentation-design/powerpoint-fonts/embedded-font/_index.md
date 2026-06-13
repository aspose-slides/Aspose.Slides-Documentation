---
title: ฝังฟอนต์ในงานนำเสนอโดยใช้ PHP
linktitle: การฝังฟอนต์
type: docs
weight: 40
url: /th/php-java/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- รับฟอนต์ที่ฝัง
- เพิ่มฟอนต์ที่ฝัง
- ลบฟอนต์ที่ฝัง
- บีบอัดฟอนต์ที่ฝัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**ฟอนต์ฝังใน PowerPoint** มีประโยชน์เมื่อต้องการให้การนำเสนอของคุณแสดงผลอย่างถูกต้องบนระบบหรืออุปกรณ์ใดก็ได้ หากคุณใช้ฟอนต์จากบุคคลที่สามหรือฟอนต์ที่ไม่เป็นมาตรฐานเพราะต้องการสร้างสรรค์ผลงานของคุณเอง คุณจะมีเหตุผลเพิ่มเติมในการฝังฟอนต์ของคุณ หากไม่มีการฝังฟอนต์ (โดยไม่ฝังฟอนต์) ข้อความหรือหมายเลขบนสไลด์, การจัดวาง, การสไตล์ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมที่ทำให้สับสนได้

คลาส [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager) , คลาส [FontData](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontdata/) และคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) มีเมธอดส่วนใหญ่ที่คุณต้องการสำหรับทำงานกับฟอนต์ฝังในงานนำเสนอ PowerPoint

## **รับและลบฟอนต์ฝัง**

Aspose.Slides มีเมธอด [getEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (เปิดเผยโดยคลาส [FontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontsManager)) เพื่อให้คุณสามารถรับ (หรือค้นหา) ฟอนต์ที่ฝังอยู่ในงานนำเสนอได้ เมื่อต้องการลบฟอนต์ จะใช้เมธอด [removeEmbeddedFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (เปิดเผยโดยคลาสเดียวกัน)

โค้ด PHP นี้แสดงวิธีรับและลบฟอนต์ฝังจากงานนำเสนอ:

```php
  # สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # เรนเดอร์สไลด์ที่มีกรอบข้อความที่ใช้ฟอนต์ฝัง "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # บันทึกรูปภาพไปยังดิสก์ในรูปแบบ JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # รับฟอนต์ที่ฝังทั้งหมด
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # ค้นหาฟอนต์ "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # ลบฟอนต์ "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # เรนเดอร์งานนำเสนอ; ฟอนต์ "Calibri" จะถูกแทนที่ด้วยฟอนต์ที่มีอยู่
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # บันทึกรูปภาพไปยังดิสก์ในรูปแบบ JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # บันทึกงานนำเสนอโดยไม่มีฟอนต์ "Calibri" ที่ฝังลงดิสก์
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เพิ่มฟอนต์ฝัง**

โดยใช้คลาส [EmbedFontCharacters](https://reference.aspose.com/slides/th/php-java/aspose.slides/embedfontcharacters/) และอ็อพโหลดสองแบบของเมธอด [addEmbeddedFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) คุณสามารถเลือกกฎการฝังที่ต้องการเพื่อฝังฟอนต์ในงานนำเสนอ โค้ด PHP นี้แสดงวิธีฝังและเพิ่มฟอนต์ลงในงานนำเสนอ:

```php
  # โหลดงานนำเสนอ
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **บีบอัดฟอนต์ฝัง**

เพื่อให้คุณสามารถบีบอัดฟอนต์ที่ฝังอยู่ในงานนำเสนอและลดขนาดไฟล์ Aspose.Slides มีเมธอด [compressEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#compressEmbeddedFonts) (เปิดเผยโดยคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/))

โค้ด PHP นี้แสดงวิธีบีบอัดฟอนต์ PowerPoint ที่ฝังอยู่:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังแล้ว?**

ตรวจสอบข้อมูล [substitution information](/slides/th/php-java/font-substitution/) ในตัวจัดการฟอนต์และกฎ [fallback/substitution](/slides/th/php-java/fallback-font/): หากฟอนต์ไม่มีหรือถูกจำกัด จะใช้ฟอนต์สำรองแทน

**การฝังฟอนต์ “ระบบ” เช่น Arial/Calibri มีคุณค่าหรือไม่?**

โดยทั่วไปไม่มี—ฟอนต์เหล่านี้มักมีให้ใช้งานเสมอ แต่หากต้องการพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (เช่น Docker หรือเซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ที่ติดตั้งล่วงหน้า) การฝังฟอนต์ระบบสามารถกำจัดความเสี่ยงจากการแทนที่ที่ไม่คาดคิดได้