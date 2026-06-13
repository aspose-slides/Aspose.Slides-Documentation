---
title: จัดการ Slide Master ของการนำเสนอใน PHP
linktitle: มาสเตอร์สไลด์
type: docs
weight: 70
url: /th/php-java/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายสไลด์มาสเตอร์
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวเติมตำแหน่ง
- คัดลอกสไลด์มาสเตอร์
- สำเนาสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ, และลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

A **slide master** กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ มันสามารถมีรูปร่างทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าฟุตเตอร์ได้ ใน PowerPoint การแก้ไข slide master เป็นวิธีปกติเพื่อทำให้การนำเสนอสอดคล้องกันโดยไม่ต้องทำซ้ำการจัดรูปแบบเดียวกันบนทุกสไลด์

Aspose.Slides for PHP via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี slide master อย่างน้อยหนึ่งหรือหลายอัน และแต่ละ slide master สามารถมี layout slide หลายอัน สไลด์ปกติโดยทั่วไปไม่ได้อ้างอิง slide master โดยตรง แต่ใช้ layout slide ซึ่ง layout slide นั้นเป็นของ slide master

ลำดับชั้นคือ:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
2. **Layout slide** - กำหนดการจัดเรียงเฉพาะของ placeholders และการจัดรูปแบบในระดับ layout
3. **Normal slide** - ประกอบด้วยเนื้อหาการนำเสนอจริงและใช้ layout slide หนึ่งอัน

![ลำดับชั้นของ slide master, layout slide, และ normal slide](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) class. All master slides in a presentation are available through the [Presentation.getMasters](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasters) method, which returns a [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) object.

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเดียวกันถูกกำหนดในระดับมากกว่าหนึ่งระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก slide master และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงตาม layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ดูที่ [ใช้หรือเปลี่ยน Layout ของสไลด์](/slides/th/php-java/slide-layout/) .
{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

In Aspose.Slides, use the `getMasters` method to access master slides:

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

You can also get the master slide used by a normal slide through its layout:

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

## **สิ่งที่ Slide Master มี**

Master slide เป็นอ็อบเจกต์คล้ายสไลด์ มันสืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout slide สมาชิกเฉพาะ master ถูกระบุในหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/)

สมาชิกที่ใช้บ่อยของ master slide รวมถึง:

| สมาชิก | จุดประสงค์ |
| --- | --- |
| `getBackground` | กำหนดพื้นหลังของสไลด์ระดับ master |
| `getShapes` | เก็บรูปร่างที่วางบน master เช่น โลโก้, กรอบรูปภาพ, และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides` | เก็บ layout slides ที่เป็นของ master |
| `getThemeManager` | ให้การเข้าถึง API ธีมของ master |
| `getHeaderFooterManager` | ควบคุมหัวกระดาษ, เท้ากระดาษ, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูก |
| `getDependingSlides` | ส่งคืนสไลด์ปกติที่ขึ้นอยู่กับ master ผ่าน layout ของมัน |

## **เพิ่มรูปภาพลงใน Slide Master**

เมื่อคุณเพิ่มรูปภาพลงใน master slide มันจะปรากฏบนสไลด์ที่ใช้ layout จาก master นั้น เป็นประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องทำซ้ำหลายครั้ง

ตัวอย่างต่อไปนี้เพิ่มโลโก้ไปยัง master slide แรก:

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูปภาพ ดูที่ [Picture Frame](/slides/th/php-java/picture-frame/) .

## **ทำงานกับ Placeholders**

Placeholders มักจะถูกกำหนดบน layout slides. master slide ให้สไตล์และธีมที่ใช้ร่วมกันซึ่ง layout สืบทอด, ส่วน layout จะตัดสินใจว่า placeholders ไหนพร้อมใช้งานและวางอยู่ที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholders ใหม่ด้วย Aspose.Slides, ทำงานกับ layout slide ที่เป็นของ master:

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

คุณยังสามารถจัดรูปแบบรูปร่าง placeholder ที่มีอยู่บน master slide ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมสีไล่แนวเส้น:

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

![Placeholder ของหัวเรื่องที่จัดรูปแบบและสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [ตั้งข้อความ Prompt ใน Placeholder](/slides/th/php-java/manage-placeholder/) และ [การจัดรูปแบบข้อความ](/slides/th/php-java/text-formatting/) .

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลังของ master จะถูกสืบทอดโดย layout และสไลด์ที่ไม่ได้เขียนทับมัน ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบของแข็งสำหรับ master slide แรก:

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

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [พื้นหลังของการนำเสนอ](/slides/th/php-java/presentation-background/) และ [ธีมของการนำเสนอ](/slides/th/php-java/presentation-theme/) .

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ `addClone` จาก [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) เพื่อคัดลอก slide master ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำเสนอปลายทางได้

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

หากต้องการคัดลอกสไลด์ปกติตามด้วย master ของมัน ให้ดูที่ [คัดลอกสไลด์](/slides/th/php-java/clone-slides/) .

## **เพิ่มหลาย Slide Masters**

การนำเสนอสามารถมีหลาย slide master ได้ นี่เป็นประโยชน์เมื่อตัวแบ่งส่วนต่าง ๆ ต้องการแบรนด์ดิ้ง, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ slide master](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ให้คัดลอกนั้นพื้นหลังที่แตกต่าง, สร้าง layout ภายใต้ master ที่คัดลอก และเพิ่มสไลด์ใหม่ตาม layout นั้น:

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

Slide master สามารถเปรียบเทียบด้วยเมธอด `equals` ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าอื่น ๆ ของสไลด์ ไม่ได้เปรียบเทียบตัวระบุที่ไม่ซ้ำกัน เช่น slide ID, หรือค่าของ placeholder ที่เปลี่ยนแปลงเช่น วันที่ปัจจุบัน

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

สำหรับข้อมูลเพิ่มเติม ดูที่ [เปรียบเทียบสไลด์ของการนำเสนอ](/slides/th/php-java/compare-slides/) .

## **ตั้งมุมมอง Slide Master ให้เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นอันดับแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [บันทึกการนำเสนอ](/slides/th/php-java/save-presentation/) .

## **ลบ Master Slides ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี master slides ที่ไม่มีสไลด์ปกติใดใช้แล้ว การลบ master ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

ใช้ `removeUnused` จาก [MasterSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslidecollection/) เพื่อลบ master ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters`:

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

**ความแตกต่างระหว่าง slide master และ layout slide คืออะไร?**

Slide master กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปร่างทั่วไป, และสไตล์ข้อความ. Layout slide เป็นส่วนหนึ่งของ slide master และกำหนดการจัดเรียงเฉพาะของ placeholders. สไลด์ปกติใช้ layout slide จึงสืบทอดจากทั้ง layout และ master.

**การนำเสนอหนึ่งสามารถมีหลาย slide master ได้หรือไม่?**

ได้ การนำเสนอสามารถมีหลาย slide master. ใช้หลาย master เมื่อส่วนต่าง ๆ ของเอกสารต้องการระบบภาพหรือแบรนด์ดิ้งที่แตกต่างกัน.

**ควรเพิ่ม placeholders ลงใน slide master หรือ layout slide?**

ส่วนใหญ่ควรเพิ่ม placeholders ลงใน layout slide. วางองค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบน slide master แล้วใส่ placeholders ของเนื้อหาไว้บน layout ที่สไลด์ปกติจะใช้.

**สามารถลบ slide master ที่ยังถูกใช้งานได้หรือไม่?**

ไม่ได้. slide master ที่มีสไลด์ขึ้นอยู่ไม่สามารถลบได้โดยตรง. ต้องย้ายสไลด์เหล่านั้นไปยัง layout ของ master อื่นก่อน, หรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้เท่านั้น.