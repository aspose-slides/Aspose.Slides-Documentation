---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/php-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติซ่อน
- แผนภูมิองค์กร
- แผนภูมิองค์กรรูปภาพ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่ประกอบด้วยโหนด รูปร่างของโหนด และเค้าโครง ด้วย Aspose.Slides for PHP via Java คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเค้าโครง ตรวจสอบโหนดที่ซ่อนอยู่ ตั้งค่าเค้าโครงแผนภูมิองค์กร และสร้างแผนภูมิองค์กรแบบภาพได้

## **ดึงข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถประกอบด้วยรูปทรงหนึ่งหรือหลายรูปทรงได้ เพื่ออ่านข้อความที่มองเห็นได้ ให้วนผ่าน [SmartArt::getAllNodes](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/#getAllNodes) แล้วอ่าน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่คืนค่าจาก [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartshape/#getTextFrame)

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **เปลี่ยนประเภทเค้าโครงของวัตถุ SmartArt**

เค้าโครง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` จากนั้นบันทึกงานนำเสนอ

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/ishidden/) บ่งชี้ว่าโหนดถูกซ่อนในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถยังคงมีอยู่ในโครงสร้างได้แม้เค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **รับหรือกำหนดเค้าโครงแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) และ [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพ่อแม่ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกแขวนจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/organizationchartlayouttype/) ที่เลือก

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและตั้งค่าเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สร้างแผนภูมิองค์กรรูปภาพ**

แผนภูมิองค์กรรูปภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับชั้นที่มีโซนสำหรับรูปภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มวัตถุ SmartArt เข้าไปในสไลด์

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาขวาไปซ้ายหรือไม่?**

ใช่ วิธีการ [SmartArt::setReversed](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/setreversed/) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือตรงกันข้าม เมื่อเค้าโครง SmartArt ที่เลือกสนับสนุนการกลับด้าน

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/php-java/shape-manipulations/) ด้วย [ShapeCollection::addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/php-java/clone-slides/) ที่มี SmartArt ทั้งสองวิธีจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะแสดง SmartArt เป็นภาพเรสเตอร์เพื่อดูตัวอย่างหรือส่งออกเว็บอย่างไร?**

[เรนเดอร์สไลด์](/slides/th/php-java/convert-powerpoint-to-png/) หรือการนำเสนอตั้งแต่ต้นเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ถ้ามี SmartArt หลายรายการบนสไลด์ ฉันจะค้นหาออบเจ็กต์ SmartArt ที่ต้องการได้อย่างไร?**

กำหนดค่า [Shape::getAlternativeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getalternativetext/) หรือ [Shape::getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getname/) ที่เป็นเอกลักษณ์ให้กับรูปร่าง SmartArt ค้นหาค่าดังกล่าวใน [BaseSlide::getShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getShapes) แล้วตรวจสอบว่ารูปร่างที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/th/php-java/aspose.slides/smartart/) หรือไม่