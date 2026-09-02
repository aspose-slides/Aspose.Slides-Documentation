---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย PHP
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/php-java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ส่วน
- ประมวลผลสไลด์ส่วน
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java: สร้าง, ตั้งชื่อใหม่, เรียงลำดับใหม่, ดึง, และประมวลผลสไลด์ส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

Sections จัดสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนแปลงเนื้อหาสไลด์. ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้าง, เรียงลำดับใหม่, ตั้งชื่อใหม่, ตรวจสอบและลบส่วนได้ผ่านเมธอด [Presentation::getSections](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSections) 

Sections มีประโยชน์โดยเฉพาะเมื่อ:

- การนำเสนอขนาดใหญ่ต้องถูกแบ่งเป็นหัวข้อหรือบทที่เป็นเหตุเป็นผล;
- กลุ่มสไลด์ที่ต่างกันถูกมอบหมายให้ผู้ร่วมงานคนต่างๆ;
- สไลด์จำเป็นต้องถูกประมวลผล, ย้าย หรือรวมเป็นกลุ่ม.

เลือกชื่อส่วนที่กระชับซึ่งอธิบายวัตถุประสงค์ของสไลด์ที่จัดกลุ่มไว้. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างการนำเสนอ ให้ใช้ API ส่วนเพื่อกำหนดสมาชิกแทนการคำนวณจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [SectionCollection::addSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#addSection) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides กำหนดสไลด์ที่เป็นของส่วนจากโครงสร้างส่วนปัจจุบันของการนำเสนอ.

The same [SectionCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/) also lets you:

- ย้ายส่วนพร้อมกับสไลด์โดยใช้ [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- ลบเพียงคำนิยามส่วนโดยใช้ [SectionCollection::removeSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#removeSection), ซึ่งจะคงสไลด์ไว้;
- ลบส่วนและสไลด์ของมันด้วย [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- เพิ่มส่วนว่างที่ท้ายด้วย [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#appendEmptySection).

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

หลังจากการดำเนินการเหล่านี้ การนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วน `Appendix` ว่าง. ส่วน `Results` และสไลด์ของมันได้ถูกลบออก.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน ให้เรียกเมธอด [Section::setName](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#setName). สไลด์และตำแหน่งของส่วนยังคงไม่เปลี่ยนแปลง.

The following example creates a section and changes its name:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **ดึงสไลด์จากส่วน**

เมธอด [Presentation::getSections](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSections) คืนค่า [SectionCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/) ที่คุณสามารถประมวลผลตามดัชนีได้. สำหรับแต่ละ [Section](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/) ให้เรียก [Section::getSlidesListOfSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSlidesListOfSection) เพื่อรับสไลด์ที่ปัจจุบันเป็นของมัน. เมธอดนี้คืนค่า [SectionSlideCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionSlideCollection/) ซึ่งให้จำนวนและการเข้าถึงตามดัชนี.

ตัวอย่างต่อไปนี้สร้างสองส่วนที่มีสไลด์และส่วนว่างหนึ่งส่วน, จากนั้นพิมพ์ [name](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSectionId), [starting slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getStartedFromSlide), จำนวนสไลด์และหมายเลขสไลด์ของแต่ละส่วน. ใช้ [SectionCollection::get_Item](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionCollection/#get_Item) และ [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/th/php-java/aspose.slides/SectionSlideCollection/#get_Item) สำหรับการเข้าถึงตามดัชนี. สำหรับส่วนว่าง, คอลเลกชันที่คืนค่ามีขนาดเป็นศูนย์และไม่เรียก `get_Item`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

การเป็นสมาชิกของส่วนกำหนดโดยโครงสร้างส่วนของการนำเสนอ. อย่าคำนวณช่วงของส่วนด้วยตนเองจาก [Section::getStartedFromSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getStartedFromSlide), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป.

การแก้ไขโครงสร้างอาจทำให้สไลด์ที่คืนค่าให้กับส่วนและหมายเลขสไลด์เปลี่ยนแปลงได้. สิ่งนี้รวมถึงการเรียงลำดับสไลด์ใหม่, การโคลนสไลด์เข้าไปในส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างต่อไปนี้เรียก [Section::getSlidesListOfSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSlidesListOfSection) หลังจากการเปลี่ยนแปลงแต่ละครั้งแทนการคาดเดาขอบเขตเดิมของส่วน.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

เรียก [Section::getSlidesListOfSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSlidesListOfSection) อีกครั้งเมื่อใดก็ตามที่สไลด์หรือส่วนถูกเรียงลำดับใหม่, โคลน, ย้าย หรือ ลบ. สิ่งนี้ทำให้การประมวลผลต่อเนื่องสอดคล้องกับโครงสร้างการนำเสนอปัจจุบัน.

รูปแบบ PPT (PowerPoint 97–2003) ไม่เก็บข้อมูลเมตาดาต้าของส่วน. ใช้ขั้นตอนทำงานนี้กับรูปแบบที่รองรับส่วน เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนซ้ำในภายหลัง.

## **คำถามที่พบบ่อย**

**ส่วนจะถูกเก็บไว้หรือไม่เมื่อตอนบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003)?**

ไม่. PPT ไม่รองรับเมตาดาต้าของส่วน, ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt.

**สามารถทำให้ส่วนทั้งหมด "ซ่อน" ได้หรือไม่?**

ไม่. ส่วนไม่มีสถานะการมองเห็น. เพื่อซ่อนเนื้อหา ให้เรียก [Slide::setHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/Slide/#setHidden) สำหรับแต่ละสไลด์ในส่วน.

**ทำอย่างไรจึงจะหาส่วนที่ประกอบด้วยสไลด์ได้?**

วนรอบคอลเลกชันที่คืนค่าจาก [Presentation::getSections](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation/#getSections), เรียก [Section::getSlidesListOfSection](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getSlidesListOfSection) สำหรับแต่ละส่วน, แล้วเปรียบเทียบสไลด์ที่คืนค่ากับสไลด์เป้าหมาย. สำหรับส่วนที่ไม่ว่าง, [Section::getStartedFromSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/Section/#getStartedFromSlide) จะคืนสไลด์แรก; สำหรับส่วนว่าง, จะคืนค่า `null`.