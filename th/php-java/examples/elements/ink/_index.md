---
title: หมึก
type: docs
weight: 180
url: /th/php-java/examples/elements/ink/
keywords:
- หมึก
- เข้าถึงหมึก
- ลบหมึก
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการหมึกดิจิทัลบนสไลด์ใน PHP ด้วย Aspose.Slides: เพิ่มเส้นพู่กัน, แก้ไขเส้นทาง, ตั้งค่าสีและความกว้าง, และส่งออกผลลัพธ์สำหรับ PowerPoint และ OpenDocument."
---
ให้ตัวอย่างการเข้าถึงรูปร่างหมึกที่มีอยู่และการลบโดยใช้ **Aspose.Slides for PHP via Java**.

> ❗ **หมายเหตุ:** รูปร่างหมึกแสดงถึงอินพุตของผู้ใช้จากอุปกรณ์พิเศษ. Aspose.Slides ไม่สามารถสร้างเส้นหมึกใหม่โดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่.

## **เข้าถึงหมึก**

ดึงรูปร่างหมึกแรกบนสไลด์.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงรูปร่างหมึกแรกบนสไลด์.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบหมึก**

ลบรูปร่างหมึกจากสไลด์.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็นรูปร่างหมึก.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```