---
title: ใช้หรือเปลี่ยนเลย์เอาต์สไลด์ใน PHP
linktitle: เลย์เอาต์สไลด์
type: docs
weight: 60
url: /th/php-java/slide-layout/
keywords:
- เลย์เอาต์สไลด์
- เลย์เอาต์เนื้อหา
- ตัวแบบอัตโนมัติ
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เลย์เอาต์ที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- เนื้อหาแบบสองส่วน
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เลย์เอาต์เปล่า
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้, สร้าง และแก้ไขเลย์เอาต์สไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java, เพิ่มตัวแบบอัตโนมัติ, ลบเลย์เอาต์ที่ไม่ได้ใช้, และควบคุมการแสดงผลส่วนท้าย."
---
## **ภาพรวม**

เลย์เอาต์สไลด์กำหนดตำแหน่งและรูปแบบของตัวแบบอัตโนมัติ เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิและตาราง การใช้เลย์เอาต์ทำให้สไลด์มีโครงสร้างสม่ำเสมอในขณะที่แต่ละสไลด์ยังสามารถมีเนื้อหาเป็นของตัวเองได้

เลย์เอาต์ที่ใช้บ่อยที่สุดได้แก่:

- **Title Slide**: มีตัวแบบอัตโนมัติสำหรับชื่อเรื่องและชื่อเรื่องย่อย
- **Title and Content**: มีตัวแบบอัตโนมัติสำหรับชื่อเรื่องและพื้นที่เนื้อหาทั่วไป
- **Blank**: ไม่มีตัวแบบอัตโนมัติใด ๆ เหมาะเมื่อทุกรูปทรงจะถูกวางตำแหน่งด้วยมือ

## **ทำความเข้าใจการสืบทอดเลย์เอาต์**

การนำเสนอมีระดับที่เชื่อมโยงกันสามระดับ:

1. [master slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วมกัน, พื้นหลังและวัตถุทั่วไป
1. [layout slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงตัวแบบอัตโนมัติเฉพาะ
1. [normal slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) ใช้เลย์เอาต์หนึ่งเลย์เอาต์และเก็บเนื้อหาที่ผู้ใช้ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเลย์เอาต์ของมัน และเลย์เอาต์สืบทอดจากมาสเตอร์ ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดจากระดับบน เมื่อตั้งสไลด์ปกติใหม่ รูปร่างของตัวแบบอัตโนมัติจะถูกสร้างจากเลย์เอาต์ที่เลือกไว้ พร้อมกับเนื้อหาที่ป้อนเข้าไปในตัวแบบอัตโนมัติจะเป็นของสไลด์ปกตินั้น

เพิ่มตัวแบบอัตโนมัติที่จำเป็นลงในเลย์เอาต์ก่อนสร้างสไลด์จากเลย์เอาต์นั้น การเพิ่มตัวแบบอัตโนมัติใหม่ในภายหลังจะไม่เพิ่มรูปร่างตัวแบบอัตโนมัติที่สอดคล้องในสไลด์ปกติที่มีอยู่แล้วโดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแบบอัตโนมัติที่มีอยู่ในเลย์เอาต์อาจอัปเดตสไลด์ทุกสไลด์ที่พึ่งพาเลย์เอาต์นั้น ก่อนแก้ไขเลย์เอาต์ที่ใช้งานอยู่แล้วให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจทานผลลัพธ์ของการนำเสนอ
- เลย์เอาต์ที่ยังคงถูกสไลด์ใช้ไม่สามารถลบได้ ให้ยกเลิกการเชื่อมโยงสไลด์ที่พึ่งพาไปยังเลย์เอาต์อื่นก่อน หรือทำการลบเฉพาะเลย์เอาต์ที่ไม่ได้ใช้

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้ ดูที่ [Slide Master](/slides/th/php-java/slide-master/)

หากต้องการซ่อนโลโก้หรือรูปกราฟิกมาสเตอร์ที่สืบทอดบนสไลด์เดียวหรือผ่านเลย์เอาต์ที่ใช้ร่วมกัน ให้ดูที่ [Control the Visibility of Master Graphics](/slides/th/php-java/slide-master/) ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้มาสเตอร์เดียวกัน

## **เลือกและใช้เลย์เอาต์สไลด์**

ใช้ประเภทเลย์เอาต์เมื่อการนำเสนอปฏิบัติตามคำนิยามเลย์เอาต์ของ PowerPoint มาตรฐาน ชื่อเลย์เอาต์สามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาต่าง ๆ ดังนั้นการเลือกโดยอิงชื่อจึงน้อยความน่าเชื่อถือ เว้นแต่คุณควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** บนมาสเตอร์แรก หากเลย์เอาต์นั้นไม่มีอยู่ จะกลับไปใช้ **Blank** อย่างเจตนา การตรวจสอบค่า null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเพียงเลย์เอาต์ที่กำหนดเองเท่านั้น เลย์เอาต์ที่เลือกแล้วจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#setLayoutSlide)

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเปลี่ยนเลย์เอาต์ของสไลด์จะไม่ลบรูปร่างปกติที่เพิ่มโดยตรงลงในสไลด์ อย่างไรก็ตามตำแหน่งของตัวแบบอัตโนมัติ, การจัดรูปแบบที่สืบทอดและความสอดคล้องระหว่างตัวแบบอัตโนมัติที่มีอยู่กับเลย์เอาต์ใหม่อาจเปลี่ยนแปลงได้ ดังนั้นให้ตรวจสอบผลลัพธ์เมื่อสลับระหว่างเลย์เอาต์ที่แตกต่างกันมาก

## **เพิ่มเลย์เอาต์สไลด์**

การเลือกและการสร้างเป็นขั้นตอนแยกกัน ตัวอย่างก่อนหน้านี้เลือกเลย์เอาต์ที่มีอยู่แล้ว; ไม่ได้สร้างใหม่ หากต้องการสร้างเลย์เอาต์ ให้เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterlayoutslidecollection/#add) บนคอลเลกชันเลย์เอาต์ของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปนี้เพิ่มเลย์เอาต์ **Title and Content** ใหม่ชื่อ `Report Title and Content` เสมอ แล้วเพิ่มสไลด์ปกติอ้างอิงจากเลย์เอาต์นั้น ชื่อเลย์เอาต์ต้องไม่ซ้ำกันภายในคอลเลกชัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เพิ่มเลย์เอาต์เฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง หากมีเลย์เอาต์ที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่

## **เพิ่มตัวแบบอัตโนมัติลงในเลย์เอาต์สไลด์**

เมธอด [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getPlaceholderManager) ให้ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/) สำหรับเพิ่มรูปร่างตัวแบบอัตโนมัติลงในเลย์เอาต์

| PowerPoint Placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเลย์เอาต์ **Blank** มีอยู่แล้ว, เพิ่มตัวแบบอัตโนมัติสี่ประเภทลงในเลย์เอาต์นั้น, แล้วสร้างสไลด์ปกติที่ใช้เลย์เอาต์ที่แก้ไขแล้ว ลำดับการทำงานตั้งใจไว้: เพิ่มตัวแบบอัตโนมัติก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตัวแบบอัตโนมัติที่สอดคล้องบนสไลด์นั้น

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแบบอัตโนมัติในเลย์เอาต์ที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวแบบอัตโนมัติที่เพิ่มใหม่จะไม่ถูกใส่ให้กับสไลด์ปกติที่มีอยู่แล้ว ทดสอบการเปลี่ยนแปลงเลย์เอาต์บนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะคงเลย์เอาต์ที่ยังคงใช้งานอยู่ไว้ไม่ถูกลบ

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการลบเลย์เอาต์เฉพาะหนึ่งรายการ ให้เรียกใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#hasDependingSlides) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getDependingSlides) ของเลย์เอาต์นั้นก่อน ย้ายสไลด์ที่พึ่งพาไปยังเลย์เอาต์อื่นก่อนเรียกเมธอด [LayoutSlide.remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#remove) การพยายามลบเลย์เอาต์ที่กำลังใช้จะทำให้เกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/)

## **ควบคุมการแสดงผลส่วนท้ายบนเลย์เอาต์สไลด์**

เลย์เอาต์มีส่วนท้าย, ตัวเลขสไลด์และตัวแบบอัตโนมัติวันที่/เวลาเป็นของตนเอง ใช้เมธอด [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) เพื่อจัดการตัวแบบอัตโนมัติเหล่านี้สำหรับเลย์เอาต์หนึ่ง นี่เป็นประโยชน์เมื่อเช่น เลย์เอาต์เนื้อหาต้องแสดงส่วนท้ายแต่เลย์เอาต์ชื่อเรื่องไม่ต้องการ

ตัวอย่างต่อไปนี้เลือกเลย์เอาต์อย่างปลอดภัยและทำให้ส่วนท้ายของมันมองเห็นได้:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ควบคุมการแสดงผลส่วนท้ายบนมาสเตอร์และเลย์เออต์ย่อยของมัน**

เพื่อให้การตั้งค่าส่วนท้ายสอดคล้องกันทั่วทั้งลำดับชั้นมาสเตอร์ ให้ใช้เมธอด [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/#getHeaderFooterManager) วิธีการกระจายของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslideheaderfootermanager/) ทำงานบนมาสเตอร์และเลย์เออต์สไลด์และสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าเพียงสไลด์ปกติเดียว

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง Master Slide กับ Layout Slide คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ เลย์เอาต์สไลด์เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงตัวแบบอัตโนมัติที่นำกลับมาใช้ได้หนึ่งชุด สไลด์ปกติใช้เลย์เอาต์เหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**สามารถคัดลอก Layout Slide จากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งได้หรือไม่?**

ทำได้ โดยเพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/globallayoutslidecollection/#addClone) เมื่อคัดลอกจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง ให้ตรวจสอบฟอนต์, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่เลย์เอาต์ต้นฉบับใช้ด้วย

**ถ้าฉันแก้ไขเลย์เอาต์ที่กำลังใช้อยู่จะเกิดอะไรขึ้น?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเลย์เอาต์ เว้นแต่พวกมันจะทับค่าการจัดรูปแบบหรือวัตถุที่ได้รับผลกระทบไว้ในระดับท้องถิ่น รูปร่างของตัวแบบอัตโนมัติและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้เมธอด [getDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อระบิสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเลย์เอาต์

**ถ้าฉันพยายามลบเลย์เอาต์ที่ยังคงถูกใช้งานจะเกิดอะไรขึ้น?**

Aspose.Slides จะขว้างข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/) ให้ย้ายสไลด์ที่พึ่งพาไปยังเลย์เอาต์อื่นก่อน หรือใช้เมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเฉพาะเลย์เอาต์ที่ไม่มีการอ้างอิงOnly.