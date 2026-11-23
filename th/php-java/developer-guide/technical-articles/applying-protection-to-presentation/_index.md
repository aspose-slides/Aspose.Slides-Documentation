---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน PHP
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/php-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for PHP via Java เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้ Aspose.Slides for PHP via Java อย่างทั่วไปคือการสร้าง, ปรับปรุง และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจได้

บทความนี้อธิบายว่า รูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการเพิ่มและลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ทำให้คุณสามารถจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรายการได้

## **โครงสร้างของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบเช่น autoshapes, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบภาพ, กรอบวีดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่นๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for PHP via Java แต่ละองค์ประกอบบนสไลด์จะแทนด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 

รูปทรงประเภทต่างๆ มีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อกรูปทรง Aspose.Slides for PHP via Java มีคลาสการล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ล็อก autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) ล็อก connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ล็อก graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) ล็อก group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) ล็อก picture frames.  

เพื่อใช้การล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรายการ

## **เพิ่มและลบการปกป้อง**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [การตั้งค่าการปกป้องงานนำเสนอ](/slides/th/php-java/password-protected-presentation/) ที่แยกจากกัน

### **เพิ่มการปกป้องให้กับรูปทรง PPTX**

Aspose.Slides for PHP via Java มีคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับ autoshapes, พร้อมการล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, แล้วบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะไม่ได้รับการเปลี่ยนแปลง ลูปจะไม่เดินทางผ่านรูปทรงย่อยภายในกลุ่ม

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

### **ลบการปกป้อง**

เพื่อทำการลบการล็อกรูปทรง ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) นอกจากนี้ยังลบข้อจำกัดการจัดกลุ่มโดยส่ง `false` ไปยัง [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าการล็อกอื่นๆ จะคงเดิม

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

### **รักษาการครอบภาพ**

วางภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างจะครอบ 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วเรียกใช้ [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) บนล็อกของกรอบภาพ การส่งค่ `true` จะจำกัดการครอบเพิ่มเติมและรักษาการครอบที่มีอยู่

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

`PictureLocked.pptx` จัดเก็บการล็อกการครอบเป็น `true`. ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกรูปภาพ

### **คงการจัดกลุ่มไดอะแกรม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วเรียกใช้ [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) บนล็อกของกลุ่มเพื่อคงส่วนประกอบของไดอะแกรมไว้ด้วยกัน การแก้ไขอื่นๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงใช้ได้

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

`DiagramLocked.pptx` จัดเก็บการล็อกการยกเลิกการจัดกลุ่มเป็น `true`. ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกไดอะแกรมทั้งหมด

### **สรุป**

Aspose.Slides for PHP via Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรายการหรือใช้ข้อจำกัดเดียวกันข้ามหลายสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทรูปทรง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้. การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ส่วน [การป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างพร้อมกันในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่นได้หรือไม่?**

ได้. เพียงทำการล็อกบนรูปทรงในสไลด์ที่เลือกเท่านั้น การทำเช่นนี้จะไม่เปลี่ยนแปลงการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะทำอย่างไรเพื่อใส่การล็อกให้กับรูปทรงแต่ละรูปภายในกลุ่ม?**

วนลูปผ่านคอลเลกชันที่คืนค่ามาจากเมธอด [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) ของกลุ่มและใส่การล็อกที่เหมาะสมกับแต่ละรูปทรงลูก ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์ ดังนั้นจึงไม่ได้ตั้งค่าล็อกบนสมาชิกกลุ่มแต่ละราย.