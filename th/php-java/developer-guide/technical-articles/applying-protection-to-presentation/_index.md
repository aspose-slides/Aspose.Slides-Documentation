---
title: "จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน PHP"
linktitle: "จำกัดการแก้ไขงานนำเสนอ"
type: docs
weight: 60
url: /th/php-java/applying-protection-to-presentation/
keywords:
- "ป้องกันการแก้ไข"
- "ปกป้องจากการแก้ไข"
- "ล็อกรูปทรง"
- "ล็อกตำแหน่ง"
- "ล็อกการเลือก"
- "ล็อกการปรับขนาด"
- "ล็อกการจัดกลุ่ม"
- "PowerPoint"
- "PPTX"
- "งานนำเสนอ"
- "PHP"
- "Aspose.Slides"
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for PHP via Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาดและการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้ทั่วไปสำหรับ Aspose.Slides for PHP via Java คือการสร้าง, อัปเดต, และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่า รูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์ของงานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปร่างที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อม, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for PHP via Java แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 

รูปทรงประเภทต่าง ๆ แสดงตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) คือคลาสพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for PHP via Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ล็อก autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) ล็อก connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ล็อก graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) ล็อก group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) ล็อก picture frames.  

เพื่อทำการล็อกทั่ว [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), ให้วนซ้ำสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรูปทรง

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [การตั้งค่าการป้องกันงานนำเสนอ](/slides/th/php-java/password-protected-presentation/) ที่แยกต่างหาก

### **นำการป้องกันไปใช้กับรูปทรง PPTX**

Aspose.Slides for PHP via Java มีคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับ autoshapes, พร้อมด้วยล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames ตัวเชื่อมใช้ [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) สำหรับการเคลื่อนย้าย; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, แล้วบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่อยู่นอกสี่ประเภทที่รองรับจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่วนผ่านรูปทรงลูกภายในกลุ่ม

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ลบการป้องกัน**

เพื่อทำการลบการล็อกรูปทรง, ตั้งค่าค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) นอกจากนี้ยังลบการจำกัดการจัดกลุ่มโดยส่ง `false` ไปยัง [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่โดยไม่มีการเปลี่ยนแปลง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **รักษาการครอบรูปภาพ**

วางรูปภาพชื่อ `photo.jpg` ในไดเรกทอรีทำงาน ตัวอย่างครอบ 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วเรียก [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) บนล็อกของกรอบรูปภาพ การส่ง `true` จะจำกัดการครอบต่อไปและรักษาการครอบที่มีอยู่

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` เก็บล็อกการครอบเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดการใช้งานเมื่อรูปภาพถูกเลือก

### **รักษาแผนภาพให้เป็นกลุ่ม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) บนล็อกของกลุ่มเพื่อรักษาองค์ประกอบของแผนภาพให้คงอยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมขององค์ประกอบยังคงใช้ได้

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` เก็บล็อกการแยกกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดการใช้งานเมื่อแผนภาพทั้งหมดถูกเลือก

### **รายงานการล็อกรูปทรงที่มีอยู่**

เพื่อทบทวนเทมเพลต, เปิดมันและอ่านอ็อบเจกต์ล็อกของแต่ละรูปทรง วิธี [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) จะคืนค่า `true` เมื่อฟล็กทั้งหมดบนอ็อบเจกต์นั้นถูกปิดและคืนค่า `false` เมื่อมีอย่างน้อยหนึ่งฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจกต์ล็อกแยกกัน ดังนั้นให้ตรวจสอบลูกแม้ว่าในกลุ่มจะไม่มีล็อกใด ๆ

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับ autoshapes, picture frames, และ groups รวมทั้งตรวจสอบการครอบสำหรับรูปภาพและการแยกกลุ่มสำหรับ groups รายงานจะแสดงฟล็กที่เปิดอยู่ที่มันรู้จักและทำเครื่องหมายประเภทรูปทรงที่ไม่ได้ตรวจสอบ

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

สมมติว่า สไลด์ 1 ของ `Sample.pptx` มีกลุ่มชื่อ `Layout` ที่ล็อกการแยกกลุ่ม, รูปภาพชื่อ `Photo` ภายในที่ล็อกการครอบ, และสี่เหลี่ยมที่ไม่ได้ล็อกชื่อ `Free` รายงานจะข้าม `Free` และพิมพ์บรรทัดสองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านฟล็กการแก้ไขระดับรูปทรงที่จัดเก็บไว้โดยไม่เปลี่ยนแปลงหรือบันทึกงานนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหาก และการบังคับใช้แต่ละฟล็กขึ้นอยู่กับโปรแกรมแก้ไข

### **สรุป**

Aspose.Slides for PHP via Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้การจำกัดเดียวกันทั่วสไลด์ เลือกล็อกที่รองรับโดยแต่ละประเภทรูปทรงและตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบการจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

Yes. Shape locks restrict specific editing operations, while [การป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/) can restrict opening or modifying the presentation. You can use both in the same file.

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่น ๆ ได้หรือไม่?**

Yes. Apply locks only to shapes on the selected slides. This does not change the lock settings on other slides.

**ฉันจะนำการล็อกไปใช้กับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

Iterate through the collection returned by the group's [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) method and apply the appropriate locks to each child shape. Repeat this for any nested groups, following the traversal in the reporting example.