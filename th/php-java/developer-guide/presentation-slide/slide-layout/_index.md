---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน PHP
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/php-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแสดงตำแหน่งชั่วคราว
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัว
- สองเนื้อหา
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
description: "ใช้, สร้าง และปรับแก้เค้าโครงสไลด์ใน Aspose.Slides สำหรับ PHP ผ่าน Java, เพิ่มตัวแสดงตำแหน่งชั่วคราว, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการแสดงส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวแสดงตำแหน่งชั่วคราว เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิและตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างสม่ำเสมอในขณะที่แต่ละสไลด์สามารถมีเนื้อหาของตนเองได้.

เค้าโครงที่พบมากที่สุดได้แก่:

- **สไลด์หัวเรื่อง**: มีตัวแสดงตำแหน่งหัวเรื่องและหัวข้อย่อย.
- **หัวเรื่องและเนื้อหา**: มีตัวแสดงตำแหน่งหัวเรื่องและตัวแสดงตำแหน่งเนื้อหาทั่วไป.
- **เปล่า**: ไม่มีตัวแสดงตำแหน่งเนื้อหาและเป็นประโยชน์เมื่อรูปร่างทั้งหมดจะถูกจัดตำแหน่งด้วยตนเอง.

## **เข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [สไลด์หลัก](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [Slide Master](/slides/th/php-java/slide-master/).

## **เลือกและใช้เค้าโครงสไลด์**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#setLayoutSlide) method.

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

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **เพิ่มสไลด์เค้าโครง**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterlayoutslidecollection/#add) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

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

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **เพิ่มตัวแสดงตำแหน่งชั่วคราวในสไลด์เค้าโครง**

The [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getPlaceholderManager) method provides a [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/) for adding placeholder shapes to a layout.

| ตัวแสดงตำแหน่ง PowerPoint | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![เนื้อหา](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![ข้อความ](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![รูปภาพ](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![แผนภูมิ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![ตาราง](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![สื่อ](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ภาพออนไลน์](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

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

![ตัวแสดงตำแหน่งบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของตัวแสดงตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่ขึ้นกับมันได้ ตัวแสดงตำแหน่งเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าสู่สไลด์ปกติที่มีอยู่แล้ว ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของงานนำเสนอและตรวจสอบสไลด์ที่ขึ้นกับทุกอัน.
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

Use the [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

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

To remove one specific layout, first use its [hasDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#hasDependingSlides) or [getDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getDependingSlides) method. Reassign any dependent slides before calling [LayoutSlide.remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#remove). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/).

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์เค้าโครง**

A layout has its own footer, slide-number, and date-time placeholders. Use the [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) method to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

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

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์มาสเตอร์และเค้าโครงลูกของมัน**

To apply consistent footer settings across a master hierarchy, use the [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/#getHeaderFooterManager) method. The propagation methods of [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

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

**ความแตกต่างระหว่างสไลด์มาสเตอร์และสไลด์เค้าโครงคืออะไร?**

สไลด์มาสเตอร์กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของงานนำเสนอ ส่วนสไลด์เค้าโครงเป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดวางตัวแสดงตำแหน่งชั่วคราวที่สามารถนำไปใช้ซ้ำได้ สไลด์ปกติจะใช้เค้าโครงเหล่านี้และบันทึกเนื้อหาของสไลด์แต่ละอัน

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้. ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/globallayoutslidecollection/#addClone) เพื่อเพิ่มสำเนาไปยังคอลเลกชันปลายทาง เมื่อคัดลอกระหว่างงานนำเสนอควรตรวจสอบฟอนต์, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่เค้าโครงต้นแบบอ้างอิง

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่ขึ้นกับเค้าโครงจะสืบทอดการเปลี่ยนแปลงเว้นแต่จะมีการกำหนดรูปแบบหรือวัตถุทับระดับสไลด์เอง รูปร่างของตัวแสดงตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงในหลายสไลด์พร้อมกัน ใช้ [getDependingSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังค้างใช้งาน?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxeditexception/). ควรโอนย้ายสไลด์ที่ขึ้นกับเค้าโครงนั้นไปยังเค้าโครงอื่นก่อน หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเฉพาะเค้าโครงที่ไม่มีสไลด์อ้างอิง.