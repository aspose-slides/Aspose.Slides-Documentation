---
title: จัดการ Drawing Guides ในงานนำเสนอด้วย PHP
linktitle: แนวนำทางการวาด
type: docs
weight: 85
url: /th/php-java/drawing-guides/
keywords:
- แนวนำทางการวาด
- แนวนำทางแนวนอน
- แนวนำทางแนวตั้ง
- แนวนำทางการจัดตำแหน่ง
- มุมมองสไลด์
- มาสเตอร์สไลด์
- สไลด์เลเอาต์
- มาสเตอร์โน้ต
- มาสเตอร์เอกสารแจก
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่ม, เข้าถึงและลบแนวนำทางการวาดแนวนอนและแนวตั้งในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Guides การวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยให้ผู้ใช้จัดแนวรูปร่างอย่างสม่ำเสมอขณะแก้ไขการนำเสนอใน PowerPoint. มันมีประโยชน์เป็นพิเศษเมื่อแอปพลิเคชันสร้างการนำเสนอแล้วจะต้องทำการปรับแต่งด้วยมือต่อไป: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดแนวเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา.

Guides การวาดเป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาของสไลด์. มันไม่ปรากฏในการนำเสนอสไลด์โชว์หรือผลลัพธ์ที่เรนเดอร์. Aspose.Slides for PHP via Java เปิดเผยพวกมันผ่านคลาส [DrawingGuidesCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/) . ไกด์หนึ่งตัวแทนโดย [DrawingGuide](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguide/) และมีการกำหนดทิศทาง, ตำแหน่ง, และสี.

ตำแหน่งวัดเป็นจุดจากมุมซ้าย‑บนของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง. ไกด์แนวตั้งใช้พิกัดแนวนอน, โดยปกติมีค่าระหว่างศูนย์และความกว้างของสไลด์. ไกด์แนวนอนใช้พิกัดแนวตั้ง, โดยปกติมีค่าระหว่างศูนย์และความสูงของสไลด์.

## **เพิ่ม Guides ให้กับมุมมองสไลด์**

ใช้ [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/th/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) เพื่อจัดการ guides ที่แสดงขณะแก้ไขสไลด์ปกติ. เรียก [DrawingGuidesCollection::add](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/#add) พร้อมค่าที่เป็น [Orientation](https://reference.aspose.com/slides/th/php-java/aspose.slides/orientation/) และตำแหน่งเป็นจุด.

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวตั้งหนึ่งเส้นทางด้านขวากลางสไลด์และไกด์แนวนอนหนึ่งเส้นด้านล่างมัน:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เข้าถึง Drawing Guides**

เมธอด [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/#getCount) และ [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/#get_Item) ให้เข้าถึง guides ที่มีอยู่. เมธอด [DrawingGuide::getOrientation](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguide/#getPosition), และ [DrawingGuide::getColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguide/#getColor) คืนค่าที่สามารถเปลี่ยนได้ผ่านเมธอด setter ที่สอดคล้องกัน.

ตัวอย่างต่อไปนี้อ่าน guides ของมุมมองสไลด์จากพรีเซนเทชันที่สร้างด้านบน:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **เพิ่ม Guides ให้กับ Master และ Layout Slides**

มาสเตอร์สไลด์และสไลด์เลเอาต์แต่ละอันสามารถมีคอลเลกชัน Drawing‑Guide ของตนเอง. ใช้ [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslide/#getDrawingGuides) สำหรับมาสเตอร์สไลด์และ [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/#getDrawingGuides) สำหรับสไลด์เลเอาต์.

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวตั้งหนึ่งเส้นให้กับมาสเตอร์สไลด์แรกและไกด์แนวนอนหนึ่งเส้นให้กับสไลด์เลเอาต์แรก:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เพิ่ม Guides ให้กับ Notes และ Handout Masters**

มาสเตอร์ของโน้ตและมาสเตอร์ของเอกสารแจกก็รองรับ Drawing Guides ด้วย. ใช้ [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslide/#getDrawingGuides) และ [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) เพื่อเข้าถึงคอลเลกชันของพวกเขา. หากพรีเซนเทชันไม่มีมาสเตอร์ประเภทใดประเภทหนึ่งหนึ่ง ให้ดึงผู้จัดการที่เหมาะสมด้วย [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) หรือ [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), แล้วสร้างมาสเตอร์ค่าเริ่มต้นด้วย `setDefaultMasterNotesSlide` หรือ `setDefaultMasterHandoutSlide`.

ตัวอย่างต่อไปนี้เพิ่มไกด์แนวนอนหนึ่งเส้นให้กับมาสเตอร์โน้ตและไกด์แนวตั้งหนึ่งเส้นให้กับมาสเตอร์เอกสารแจก:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ลบ Drawing Guides**

เรียก [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/#clear) เพื่อเอาไกด์ทุกเส้นออกจากคอลเลกชันที่ระบุ. การลบคอลเลกชันหนึ่งไม่ได้กระทบต่อไกด์ที่เก็บไว้ในขอบเขตอื่น.

ตัวอย่างต่อไปนี้ลบ guides ของมุมมองสไลด์และทุกไกด์บนมาสเตอร์สไลด์, สไลด์เลเอาต์, มาสเตอร์โน้ต, และมาสเตอร์เอกสารแจกโดยไม่ต้องสร้างมาสเตอร์ที่หายไป:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Guides การวาดปรากฏในสไลด์โชว์หรือภาพที่ส่งออกหรือไม่?**

ไม่. Guides การวาดเป็นเครื่องมือจัดแนวสำหรับการแก้ไขและไม่ได้แสดงเป็นเนื้อหาการนำเสนอ.

**สามารถเพิ่ม Drawing Guide ลงในสไลด์ปกติแต่ละสไลด์โดยตรงได้หรือไม่?**

Guides สำหรับการแก้ไขสไลด์ปกติจะถูกเก็บไว้ในคุณสมบัติของมุมมองสไลด์ของพรีเซนเทชัน. มีคอลเลกชัน Guides แยกต่างหากสำหรับมาสเตอร์สไลด์, สไลด์เลเอาต์, มาสเตอร์โน้ต, และมาสเตอร์เอกสารแจก.

**หน่วยใดใช้สำหรับตำแหน่งของ Guide?**

ตำแหน่งระบุเป็นจุด, โดยที่ 72 จุดเท่ากับหนึ่งนิ้ว. ตำแหน่งแนวตั้งวัดจากขอบซ้าย, และตำแหน่งแนวนอนวัดจากขอบบน.

**การลบ Drawing Guides จะลบรูปทรงหรือเปลี่ยนเนื้อหาสไลด์หรือไม่?**

ไม่. เมธอด [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/drawingguidescollection/#clear) จะลบเฉพาะ Guides ในคอลเลกชันที่เลือก. รูปทรงและเนื้อหาอื่น ๆ ของสไลด์จะคงอยู่โดยไม่มีการเปลี่ยนแปลง.