---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint โดยใช้ PHP
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/php-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติที่ซ่อน
- แผนภูมิองค์กร
- แผนภูมิองค์กรแบบภาพ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides for PHP via Java โดยใช้ตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ."
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่ประกอบด้วยโหนด รูปร่างของโหนด และเค้าโครง ด้วย Aspose.Slides for PHP via Java คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเค้าโครง ตรวจสอบโหนดที่ซ่อนอยู่ กำหนดค่าเค้าโครงแผนภูมิองค์กร และสร้างแผนภูมิองค์กรแบบภาพ

## **รับข้อความจากอ็อบเจกต์ SmartArt**

โหนด SmartArt สามารถมีหนึ่งหรือหลายรูปทรงได้ เพื่ออ่านข้อความจากรูปทรงของโหนด ให้ทำการวนรอบผ่าน [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/) แล้วอ่าน [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ที่ส่งกลับโดย [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/)  

ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์และอ็อบเจกต์ SmartArt เป็นรูปทรงแรกบนสไลด์นั้น จะพิมพ์แต่ละ TextFrame ที่มีอยู่ไปยังคอนโซล

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
## **เปลี่ยนประเภทเค้าโครงของอ็อบเจกต์ SmartArt**

เค้าโครง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างอ็อบเจกต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` จากนั้นเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ ตำแหน่งและขนาดที่ส่งให้กับ [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) มีหน่วยเป็นพอยท์ ใช้ [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) เพื่อเปลี่ยนเค้าโครง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนไว้หรือไม่**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) ระบุว่าโหนดถูกซ่อนไว้ในโมเดลข้อมูลของ SmartArt หรือไม่ โหนดที่ซ่อนอาจยังคงอยู่ในโครงสร้างแม้เค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในอ็อบเจกต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` แล้วตรวจสอบสถานะการซ่อนของโหนดที่เพิ่ม หากโหนดถูกซ่อนจะแสดงข้อความและบันทึกแผนภาพ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **รับหรือกำหนดเค้าโครงแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) และ [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนท์ ตัวอย่างเช่น คุณสามารถกำหนดให้โหนดลูกห้อยจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) ที่เลือก  

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและกำหนดเค้าโครงให้โหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` อินดексเริ่มจากศูนย์ `0` เลือกโหนดระดับบนแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก งานนำเสนอที่แก้ไขแล้วจะถูกบันทึก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **สร้างแผนภูมิองค์กรแบบภาพ**

แผนภูมิองค์กรแบบภาพเป็นเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนผังลำดับชั้นที่มีตัวแทนภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อต้องการเพิ่มอ็อบเจกต์ SmartArt ลงในสไลด์ ตัวอย่างนี้บันทึกแผนภาพที่มีตัวแทนภาพไว้ แต่ไม่ได้เติมภาพลงในตัวแทนเหล่านั้น

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **แปลงแผนภาพเก่าเป็นกลุ่มของรูปทรง**

เมื่อปรับปรุงงานนำเสนอที่มีอยู่ คุณอาจจำเป็นต้องอัปเดตแผนภูมิองค์กรที่สร้างใน PowerPoint 97–2003 Aspose.Slides แทนที่แผนภาพเหล่านี้ด้วยอ็อบเจกต์ [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) ใช้ [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปทรงเพื่อให้สามารถแก้ไขแต่ละองค์ประกอบได้ ดูรายละเอียดเพิ่มเติมใน [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/)  

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเลกชันรูปทรงโดยไม่ลบแผนภาพต้นฉบับ หลังจากแปลงสำเร็จ ให้ลบแผนภาพเดิมด้วย [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) เพื่อหลีกเลี่ยงเนื้อหาซ้ำ เก็บแผนภาพเก่าไว้ในรายการก่อนการแปลง เพื่อให้การเพิ่มและลบรูปทรงไม่ทำให้การวนรอบขัดจังหวะ  

ตัวอย่างต่อไปนี้เปิดงานนำเสนอ ค้นหาทุกสไลด์ แปลงแผนภาพเป็นกลุ่มของรูปทรง และบันทึกงานนำเสนอที่อัปเดตเป็น PPTX

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

งานนำเสนอที่บันทึกแล้วจะมีกลุ่มรูปทรงที่แก้ไขได้แทนแผนภาพเก่าที่แปลงแล้ว โดยไม่มีแผนภาพเดิมเหลืออยู่ เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละรายการภายในกลุ่ม เช่น ข้อความ การเติมสี หรือตำแหน่ง

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับหลังสำหรับภาษาขวามือหรือไม่?**

ใช่ เมธอด [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกันเมื่อเค้าโครง SmartArt ที่เลือกสนับสนุนการกลับทิศ

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [clone the SmartArt shape](/slides/th/php-java/shape-manipulations/) ด้วย [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) หรือ [clone the whole slide](/slides/th/php-java/clone-slides/) ที่มี SmartArt ทั้งสองวิธีจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะเรนเดอร์ SmartArt เป็นภาพ raster เพื่อดูตัวอย่างหรือส่งออกเว็บได้อย่างไร?**

[Render the slide](/slides/th/php-java/convert-powerpoint-to-png/) หรือเรนเดอร์งานนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะค้นหาอ็อบเจกต์ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจกต์?**

ใช้ [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) หรือ [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) เพื่อกำหนดข้อความแทนหรือชื่อเฉพาะให้กับรูปทร่าง SmartArt จากนั้นค้นหาค่าดังกล่าวใน [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) และตรวจสอบว่ารูปทรงที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)