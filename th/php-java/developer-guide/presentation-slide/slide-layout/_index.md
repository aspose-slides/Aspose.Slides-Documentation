---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน PHP
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/php-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ส่วนพื้นที่สำรอง
- ออกแบบงานนำเสนอ
- ออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการและปรับแต่งเค้าโครงสไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java. ศึกษาประเภทเค้าโครง, การควบคุมส่วนพื้นที่สำรอง, และการแสดงผลส่วนท้ายด้วยตัวอย่างโค้ด."
---
## **บทนำ**

เค้าโครงสไลด์กำหนดการจัดเรียงของกล่องส่วนพื้นที่สำรองและการจัดรูปแบบสำหรับเนื้อหาบนสไลด์ มันควบคุมว่ามีส่วนพื้นที่สำรองใดบ้างที่พร้อมใช้งานและปรากฏที่ตำแหน่งใด เค้าโครงสไลด์ช่วยให้คุณออกแบบงานนำเสนอได้อย่างรวดเร็วและสม่ำเสมอ — ไม่ว่าจะเป็นการสร้างสิ่งที่ง่ายหรือซับซ้อนมากขึ้น บางส่วนของเค้าโครงสไลด์ที่พบบ่อยที่สุดใน PowerPoint ได้แก่:

**เค้าโครงสไลด์หัวเรื่อง** – มีส่วนพื้นที่สำรองข้อความสองส่วน: หนึ่งสำหรับหัวเรื่องและหนึ่งสำหรับหัวเรื่องย่อย.

**เค้าโครงหัวเรื่องและเนื้อหา** – มีส่วนพื้นที่สำรองหัวเรื่องขนาดเล็กที่ด้านบนและส่วนที่ใหญ่กว่าใต้เพื่อเนื้อหาหลัก (เช่น ข้อความ, รายการหัวข้อ, แผนภูมิ, รูปภาพ, และอื่น ๆ).

**เค้าโครงเปล่า** – ไม่มีส่วนพื้นที่สำรองใด ๆ ให้คุณควบคุมเต็มที่ในการออกแบบสไลด์ตั้งแต่ต้น.

เค้าโครงสไลด์เป็นส่วนหนึ่งของมาสเตอร์สไลด์ ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดสไตล์เค้าโครงสำหรับงานนำเสนอ คุณสามารถเข้าถึงและแก้ไขเค้าโครงสไลด์ผ่านมาสเตอร์สไลด์ — ไม่ว่าจะโดยประเภท, ชื่อ, หรือรหัสประจำตัวที่ไม่ซ้ำกัน อีกทางหนึ่งคุณสามารถแก้ไขเค้าโครงสไลด์เฉพาะโดยตรงภายในงานนำเสนอได้.

เพื่อทำงานกับเค้าโครงสไลด์ใน Aspose.Slides for PHP คุณสามารถใช้:

- วิธีการเช่น [getLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getLayoutSlides) และ [getMasters](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasters) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
- ประเภทเช่น [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/), และ [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
หากต้องการเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับมาสเตอร์สไลด์ โปรดดูบทความ [Slide Master](/slides/th/php-java/slide-master/).
{{% /alert %}}

## **เพิ่มเค้าโครงสไลด์ในงานนำเสนอ**

เพื่อปรับแต่งรูปลักษณ์และโครงสร้างของสไลด์ของคุณ คุณอาจต้องเพิ่มเค้าโครงสไลด์ใหม่ลงในงานนำเสนอ Aspose.Slides for PHP ช่วยให้คุณตรวจสอบว่าเค้าโครงเฉพาะมีอยู่แล้วหรือไม่, เพิ่มเค้าโครงใหม่หากจำเป็น, และใช้มันในการแทรกสไลด์ตามเค้าโครงนั้น.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึง [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterlayoutslidecollection/).
3. ตรวจสอบว่าเค้าโครงสไลด์ที่ต้องการมีอยู่แล้วในคอลเลกชันหรือไม่ หากไม่มี ให้เพิ่มเค้าโครงสไลด์ที่ต้องการ.
4. เพิ่มสไลด์เปล่าตามเค้าโครงสไลด์ใหม่.
5. บันทึกงานนำเสนอ.

โค้ด PHP ด้านล่างนี้แสดงวิธีเพิ่มเค้าโครงสไลด์ในงานนำเสนอ PowerPoint:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // ดำเนินการผ่านประเภทเค้าโครงสไลด์เพื่อเลือกเค้าโครงสไลด์.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // สถานการณ์ที่งานนำเสนอไม่มีเค้าโครงประเภททั้งหมด.
        // ไฟล์งานนำเสนอมีเฉพาะเค้าโครงประเภท Blank และ Custom เท่านั้น.
        // อย่างไรก็ตาม เค้าโครงสไลด์ที่เป็นประเภท custom อาจมีชื่อที่จดจำได้,
        // เช่น "Title", "Title and Content" เป็นต้น ซึ่งสามารถใช้สำหรับการเลือกเค้าโครงสไลด์.
        // คุณยังสามารถอาศัยชุดประเภทรูปแบบส่วนพื้นที่สำรองได้.
        // ตัวอย่างเช่น สไลด์ Title ควรมีเฉพาะประเภทส่วนพื้นที่สำรอง Title เท่านั้น เป็นต้น.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // เพิ่มสไลด์เปล่าโดยใช้เค้าโครงสไลด์ที่เพิ่มเข้ามา.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // บันทึกงานนำเสนอลงดิสก์.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ลบเค้าโครงสไลด์ที่ไม่ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) จากคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) เพื่อให้คุณสามารถลบเค้าโครงสไลด์ที่ไม่ต้องการและไม่ได้ใช้ได้.

โค้ด PHP ด้านล่างนี้แสดงวิธีลบเค้าโครงสไลด์จากงานนำเสนอ PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เพิ่มส่วนพื้นที่สำรองในเค้าโครงสไลด์**

Aspose.Slides มีเมธอด [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getPlaceholderManager) ซึ่งช่วยให้คุณสามารถเพิ่มส่วนพื้นที่สำรองใหม่ลงในเค้าโครงสไลด์ได้.

ผู้จัดการนี้มีเมธอดสำหรับประเภทส่วนพื้นที่สำรองต่อไปนี้:

| PowerPoint Placeholder | เมธอดของ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------ |
| ![เนื้อหา](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ (แนวตั้ง)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพ](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![แผนภูมิ](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![ตาราง](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![สื่อ](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพออนไลน์](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

โค้ด PHP ด้านล่างนี้แสดงวิธีเพิ่มรูปร่างส่วนพื้นที่สำรองใหม่ไปยังเค้าโครงสไลด์เปล่า:

```php
$presentation = new Presentation();
try {
    // รับเค้าโครงสไลด์ Blank.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // รับผู้จัดการส่วนพื้นที่สำรองของเค้าโครงสไลด์.
    $placeholderManager = $layout->getPlaceholderManager();

    // เพิ่มส่วนพื้นที่สำรองต่าง ๆ ไปยังเค้าโครงสไลด์ Blank.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // เพิ่มสไลด์ใหม่โดยใช้เค้าโครง Blank.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ส่วนพื้นที่สำรองบนสไลด์เค้าโครง](add_placeholders.png)

## **ตั้งค่าการแสดงผลส่วนท้ายสำหรับเค้าโครงสไลด์**

ในการนำเสนอ PowerPoint ส่วนของส่วนท้าย เช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเอง สามารถแสดงหรือซ่อนได้ตามเค้าโครงสไลด์ Aspose.Slides for PHP ช่วยให้คุณควบคุมการมองเห็นของส่วนพื้นที่สำรองส่วนท้ายเหล่านี้ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้เค้าโครงบางอย่างแสดงข้อมูลส่วนท้ายในขณะที่อื่นๆ คงความเรียบง่ายและน้อยที่สุด.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. รับอ้างอิงเค้าโครงสไลด์โดยใช้ดัชนีของมัน.
3. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองส่วนท้ายของสไลด์ให้เป็นที่มองเห็น.
4. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองหมายเลขสไลด์ให้เป็นที่มองเห็น.
5. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองวันที่-เวลาให้เป็นที่มองเห็น.
6. บันทึกงานนำเสนอ.

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าการแสดงผลส่วนท้ายของสไลด์ลูก**

ในการนำเสนอ PowerPoint ส่วนของส่วนท้าย เช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเอง สามารถควบคุมได้ระดับมาสเตอร์สไลด์เพื่อให้แน่ใจว่ามีความสอดคล้องกันในทุกเค้าโครงสไลด์ Aspose.Slides for PHP ให้คุณตั้งค่าการมองเห็นและเนื้อหาของส่วนพื้นที่สำรองส่วนท้ายเหล่านี้บนมาสเตอร์สไลด์และกระจายการตั้งค่าเหล่านั้นไปยังเค้าโครงสไลด์ลูกทั้งหมด วิธีนี้ทำให้ข้อมูลส่วนท้ายสอดคล้องกันทั่วงานนำเสนอของคุณ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. รับอ้างอิงมาสเตอร์สไลด์โดยใช้ดัชนีของมัน.
3. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองส่วนท้ายของมาสเตอร์และเค้าโครงสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.
4. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองหมายเลขสไลด์ของมาสเตอร์และเค้าโครงสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.
5. ตั้งค่าการแสดงผลส่วนพื้นที่สำรองวันที่-เวลาของมาสเตอร์และเค้าโครงสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.
6. บันทึกงานนำเสนอ.

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเค้าโครงสไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้น ขณะที่เค้าโครงสไลด์กำหนดการจัดเรียงส่วนพื้นที่สำรองเฉพาะสำหรับประเภทเนื้อหาต่าง ๆ

**ฉันสามารถคัดลอกเค้าโครงสไลด์จากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งได้หรือไม่?**

ได้ คุณสามารถโคลนเค้าโครงสไลด์จากคอลเลกชันเค้าโครงสไลด์ของงานนำเสนอหนึ่ง (เข้าถึงได้ผ่านเมธอด [getLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getLayoutSlides)) และแทรกลงในงานนำเสนออื่นโดยใช้เมธอด `addClone`.

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงสไลด์ที่ยังคงถูกสไลด์อื่นใช้งานอยู่?**

หากคุณพยายามลบเค้าโครงสไลด์ที่ยังถูกอ้างอิงโดยสไลด์อย่างน้อยหนึ่งสไลด์ในงานนำเสนอ Aspose.Slides จะทำให้เกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/). เพื่อหลีกเลี่ยงนี้ ให้ใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) ซึ่งจะลบเค้าโครงสไลด์ที่ไม่ได้ใช้โดยปลอดภัยเท่านั้น.