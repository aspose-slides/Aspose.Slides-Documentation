---
title: จัดการ Slide Master ของการนำเสนอใน PHP
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/php-java/slide-master/
keywords:
- สไลด์มาสเตอร์
- มาสเตอร์สไลด์
- มาสเตอร์สไลด์ PPT
- มาสเตอร์สไลด์หลายหน้า
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวกำหนดตำแหน่ง
- สร้างสำเนามาสเตอร์สไลด์
- คัดลอกมาสเตอร์สไลด์
- ทำสำเนามาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้งาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ PHP ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบและลบมาสเตอร์สไลด์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

A **slide master** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถมีรูปทรงทั่วไป โลโก้ พื้นหลัง รูปแบบข้อความ การตั้งค่าธีม และการตั้งค่าฝั่งล่าง ใน PowerPoint การแก้ไข slide master เป็นวิธีปกติในการรักษาความสอดคล้องของการนำเสนอโดยไม่ต้องทำรูปแบบเดียวกันซ้ำในทุกสไลด์

Aspose.Slides for PHP via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี master slide หนึ่งหรือหลายหน้าสไลด์ และแต่ละ master slide สามารถมี layout slide หลายหน้า สไลด์ปกติส่วนใหญ่จะไม่อ้างอิง master slide โดยตรง แต่สไลด์ปกติจะใช้ layout slide ซึ่ง layout slide นั้นเป็นส่วนหนึ่งของ master slide

ลำดับชั้นคือ:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน  
1. **Layout slide** - กำหนดการจัดวางเฉพาะของ placeholders และการจัดรูปแบบระดับ layout  
1. **Normal slide** - มีเนื้อหาจริงของการนำเสนอและใช้ layout slide หนึ่งหน้า

![ลำดับชั้นของ master slide, layout slide, และ normal slide](slide-master_2.jpg)

ใน Aspose.Slides slide master ถูกแทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) ทั้งหมดของ master slide ในการนำเสนอสามารถเข้าถึงได้ผ่านเมธอด [Presentation.getMasters](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasters) ซึ่งจะคืนค่าออบเจกต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/)

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเดียวกันถูกกำหนดในระดับมากกว่าหนึ่งระดับ ระดับที่เฉพาะเจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก master slide และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงจาก layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ดูที่ [Apply or Change Slide Layouts](/slides/th/php-java/slide-layout/)
{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ใช้เมธอด `getMasters` เพื่อเข้าถึง master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

คุณยังสามารถรับ master slide ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **สิ่งที่ Slide Master มีอยู่**

master slide เป็นอ็อบเจกต์ที่คล้ายสไลด์ มันสืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout สมาชิกเฉพาะของ master สามารถดูได้บนหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/)

สมาชิกของ master slide ที่มักใช้บ่อย ได้แก่:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `getBackground` | กำหนดพื้นหลังของสไลด์ระดับมาสเตอร์ |
| `getShapes` | เก็บรูปทรงที่วางบนมาสเตอร์ เช่น โลโก้, เฟรมรูปภาพ, และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides` | เก็บ layout slide ที่เป็นส่วนหนึ่งของมาสเตอร์ |
| `getThemeManager` | ให้การเข้าถึง API ธีมของมาสเตอร์ |
| `getHeaderFooterManager` | ควบคุมส่วนหัว, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับมาสเตอร์และเลเอาต์ลูกของมัน |
| `getDependingSlides` | คืนค่าสไลด์ปกติที่ขึ้นอยู่กับมาสเตอร์ผ่านเลเอาต์ของพวกมัน |

## **เพิ่มรูปภาพลงใน Slide Master**

เมื่อคุณเพิ่มรูปภาพลงใน master slide มันจะปรากฏบนสไลด์ที่ใช้เลเอาต์จากมาสเตอร์นั้น ซึ่งเป็นประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงใน master slide ตัวแรก:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ picture frame ดูที่ [Picture Frame](/slides/th/php-java/picture-frame/).

## **ควบคุมการมองเห็นของกราฟิกมาสเตอร์**

ใช้ [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#setShowMasterShapes) เพื่อซ่อนกราฟิกมาสเตอร์ที่สืบทอดมา เช่น โลโก้หรือรูปร่างตกแต่ง โดยไม่ต้องลบออกจากมาสเตอร์ ส่งค่า `false` ไปยัง [Slide::setShowMasterShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#setShowMasterShapes) บนสไลด์ที่ต้องการไม่แสดงกราฟิกเหล่านั้นและตั้งค่าเป็น `true` บนสไลด์ที่ต้องการแสดง

ตัวอย่างต่อไปนี้สร้างแถบตกแต่งสีฟ้าบนมาสเตอร์และสไลด์สองหน้าใช้เลเอาต์ว่างเดียวกัน แถบจะมองเห็นบนสไลด์แรกแต่ซ่อนบนสไลด์ที่สอง ไม่ต้องมีการนำเสนอหรือรูปภาพเข้าใส่

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ตัวอย่างใช้เลเอาต์ **Blank** ที่มาพร้อมกับการนำเสนอใหม่และลบ placeholders ของสไลด์เริ่มต้นออก

### **เลือกขอบเขตของการตั้งค่า**

สไลด์ปกติใช้มาสเตอร์ผ่าน [Slide::getLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getLayoutSlide) และ [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getMasterSlide) การตั้งค่าคุณสมบัติบนบนสไลด์เดี่ยวจะมีผลเฉพาะสไลด์นั้น การส่งค่า `false` ไปยัง [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#setShowMasterShapes) จะซ่อนกราฟิกมาสเตอร์สำหรับสไลด์ทั้งหมดที่ใช้เลเอาต์ร่วมกัน แม้ว่าการตั้งค่าบนสไลด์ของตนเองจะเป็น `true` เพื่อซ่อนกราฟิกเพียงสไลด์เดียวให้เปลี่ยนคุณสมบัติบนบนสไลด์และไม่เปลี่ยนเลเอต์ที่แชร์

การตั้งค่านี้ไม่รองรับเป็นการควบคุมการมองเห็นบน master slide เอง บนมาสเตอร์ [getShowMasterShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/#getShowMasterShapes) จะคืนค่า `false` เสมอและการส่งค่า `true` ไปยัง [setShowMasterShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/#setShowMasterShapes) จะทำให้เกิดข้อยกเว้น ให้ใช้บนสไลด์ปกติหรือ layout แทน

### **แยกกราฟิกจากพื้นหลัง**

| การดำเนินการ | ผล |
| --- | --- |
| ซ่อนกราฟิกมาสเตอร์ | ควบคุมการมองเห็นของรูปทรงมาสเตอร์ที่สืบทอดมาโดยไม่ลบหรือเปลี่ยนรูปทรงของสไลด์เอง |
| เปลี่ยนการเติมพื้นหลังของสไลด์ | เปลี่ยนสี, การไล่สี, หรือรูปภาพพื้นหลัง รูปทรงมาสเตอร์เป็นรูปทรงแยกต่างหากและสามารถมองเห็นเหนือพื้นหลังนั้น ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/) |
| ลบรูปทรงจากมาสเตอร์ | ลบรูปทรงต้นฉบับที่ใช้ร่วมกัน ทำให้ไม่สามารถใช้ได้กับสไลด์ใดที่อิงมาสเตอร์นั้น |

## **ทำงานกับ Placeholders**

Placeholders ส่วนใหญ่จะถูกกำหนดบน layout slide มาสเตอร์ให้สไตล์และธีมที่แชร์ให้กับเลเอต์เหล่านั้น และแต่ละ layout จะตัดสินใจว่า placeholders ใดพร้อมใช้งานและวางไว้ที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ใช้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholders ใหม่ด้วย Aspose.Slides ทำงานกับ layout slide ที่เป็นส่วนหนึ่งของมาสเตอร์:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่บน master slide ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใส่การเติมไล่สีเชิงเส้น:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![หัวเรื่อง placeholder ที่จัดรูปแบบแล้วซึ่งสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/slides/th/php-java/manage-placeholder/) และ [Text Formatting](/slides/th/php-java/text-formatting/).

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลังมาสเตอร์จะสืบทอดไปยัง layout และสไลด์ที่ไม่ได้กำหนดทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับ master slide ตัวแรก:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/slides/th/php-java/presentation-background/) และ [Presentation Theme](/slides/th/php-java/presentation-theme/).

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ `addClone` จาก [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) เพื่อคัดลอก master slide ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำเสนอปลายทาง

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

หากต้องการคัดลอกสไลด์ปกติกับมาสเตอร์ของมันด้วย ดูที่ [Clone Slides](/slides/th/php-java/clone-slides/).

## **เพิ่มหลาย Slide Masters**

การนำเสนอสามารถมี master slide หลายหน้าได้ ซึ่งมีประโยชน์เมื่อส่วนต่าง ๆ ต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่ต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ master slide](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น ให้คัดลอกมีพื้นหลังต่างกัน สร้าง layout ใต้ master ที่คัดลอกแล้วและเพิ่มสไลด์ใหม่ที่อิงจาก layout นั้น:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เปรียบเทียบ Slide Masters**

สามารถเปรียบเทียบ master slide ด้วยเมธอด `equals` ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) การเปรียบเทียบจะตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าอื่น ๆ ของสไลด์ ไม่ได้เปรียบเทียบตัวระบุเฉพาะ เช่น slide ID หรือค่าที่เป็น placeholder แบบไดนามิก เช่น วันที่ปัจจุบัน

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

สำหรับข้อมูลเพิ่มเติม ดูที่ [Compare Presentation Slides](/slides/th/php-java/compare-slides/).

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/) เพื่อกำหนดมุมมองที่ PowerPoint เปิดเมื่อแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [Save Presentation](/slides/th/php-java/save-presentation/).

## **ลบ Master Slides ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี master slide ที่ไม่มีสไลด์ปกติใช้งาน การลบมาสเตอร์ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การบำรุงรักษาแม่แบบง่ายขึ้น

ใช้ `removeUnused` จาก [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

คุณยังสามารถใช้เมธอด low-code `removeUnusedMasterSlides` จากคลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) :

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ความแตกต่างระหว่าง slide master กับ layout slide คืออะไร?**

slide master กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และรูปแบบข้อความ layout slide เป็นส่วนหนึ่งของ master slide และกำหนดการจัดวางเฉพาะของ placeholders สไลด์ปกติใช้ layout slide ดังนั้นจึงสืบทอดจากทั้ง layout และ master

**การนำเสนอหนึ่งสามารถมี slide master ได้หลายหน้าใช่หรือไม่?**

ใช่ การนำเสนอสามารถมี slide master หลายหน้าได้ ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่ต่างกัน

**ควรเพิ่ม placeholders ลงใน master slide หรือ layout slide?**

ในกรณีส่วนใหญ่ควรเพิ่ม placeholders ลงใน layout slide ใส่องค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบน master slide แล้วใส่ placeholders ของเนื้อหาไว้บน layout ที่สไลด์ปกติจะใช้

**ฉันสามารถลบ master slide ที่ยังถูกใช้งานอยู่ได้หรือไม่?**

ไม่ได้ master slide ที่มีสไลด์ขึ้นอยู่ไม่สามารถลบได้โดยตรง ให้ย้ายสไลด์เหล่านั้นไปยัง layout ภายใต้มาสเตอร์อื่นหรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้เท่านั้น.