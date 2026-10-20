---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อครูปทรงใน PHP
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/php-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อครูปทรง
- ล็อคตำแหน่ง
- ล็อคการเลือก
- ล็อคการปรับขนาด
- ล็อคการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการล็อคและปลดล็อครูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้งานทั่วไปของ Aspose.Slides for PHP via Java คือการสร้าง, ปรับปรุงและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาเค้าโครงและเนื้อหาตามที่ตั้งใจไว้ได้

บทความนี้อธิบายวิธีที่รูปทรงถูกจัดเรียงบนสไลด์และวิธีการเพิ่มและลบการล็อครูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปได้

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น ออโต้เชป, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวีดีโอ, ตัวเชื่อมต่อ และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for PHP via Java แต่ละองค์ประกอบบนสไลด์จะแสดงโดยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 

ประเภทรูปทรงที่แตกต่างกันมีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อครูปทรง Aspose.Slides for PHP via Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) ล็อกออโต้เชป.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) ล็อกรูปทรงเชื่อมต่อ.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) ล็อกรูปทรงกลุ่ม.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) ล็อกกรอบภาพ.  

เพื่อเพิ่มการล็อกให้ทั่วทั้ง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), ให้วนผ่านสไลด์ทั้งหมดและกำหนดการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรูป

## **การเพิ่มและลบการปกป้อง**

การล็อครูปทรงจำกัดการดำเนินการเช่น การเลือก, การย้ายและการปรับขนาดรูปทรง พวกมันไม่ได้ทำให้ทั้งงานนำเสนอไม่สามารถแก้ไขได้

### **เพิ่มการปกป้องให้รูปทรง PPTX**

Aspose.Slides for PHP via Java มีคลาส [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked), และ [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับออโต้เชป, พร้อมล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะคงอยู่โดยไม่เปลี่ยนแปลง ลูปนี้ไม่ได้เดินทางผ่านรูปทรงลูกภายในกลุ่ม

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

เพื่อเอาการล็อครูปทรงออก, ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อครูปทรงและล้างการจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). มันยังลบข้อจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงไว้โดยไม่มีการเปลี่ยนแปลง

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

### **สรุป**

Aspose.Slides for PHP via Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้ข้อจำกัดเดียวกันทั่วสไลด์ทั้งหมด เลือกการล็อกที่รองรับโดยแต่ละประเภทรูปทรงและตั้งค่าของมันเป็น `false` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อครูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวได้หรือไม่?**

ใช่ การล็อครูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะได้โดยไม่กระทบสไลด์อื่นหรือไม่?**

ใช่ ให้เพิ่มการล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือกเท่านั้น ส่วนนี้จะไม่เปลี่ยนแปลงการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะเพิ่มการล็อกให้รูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนผ่านคอลเลกชันที่คืนค่ามาจากเมธอด [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) ของกลุ่มและเพิ่มการล็อกที่เหมาะสมให้กับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งการล็อกบนสมาชิกกลุ่มแต่ละอัน