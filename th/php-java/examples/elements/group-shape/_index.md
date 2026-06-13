---
title: รูปทรงกลุ่ม
type: docs
weight: 170
url: /th/php-java/examples/elements/group-shape/
keywords:
- กลุ่ม
- เพิ่มรูปทรงกลุ่ม
- เข้าถึงรูปทรงกลุ่ม
- ลบรูปทรงกลุ่ม
- ยกเลิกการจัดกลุ่มรูปทรง
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับรูปทรงกลุ่มใน PHP โดยใช้ Aspose.Slides: สร้างและยกเลิกการจัดกลุ่ม, จัดเรียงลำดับรูปทรงย่อยใหม่, ตั้งค่าการแปลงและขอบเขตข้าม PowerPoint และ OpenDocument."
---
ตัวอย่างการสร้างกลุ่มของรูปทรง การเข้าถึงรูปทรง การยกเลิกการจัดกลุ่ม และการลบโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มรูปทรงกลุ่ม**

สร้างกลุ่มที่ประกอบด้วยรูปทรงพื้นฐานสองรูป.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงรูปทรงกลุ่ม**

ดึงรูปทรงกลุ่มแรกจากสไลด์.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงรูปทรงกลุ่มแรกบนสไลด์.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบรูปทรงกลุ่ม**

ลบรูปทรงกลุ่มออกจากสไลด์.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // สมมติว่ารูปทรงแรกบนสไลด์เป็นรูปทรงกลุ่ม.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ยกเลิกการจัดกลุ่มรูปทรง**

ย้ายรูปทรงออกจากคอนเทนเนอร์กลุ่ม.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปทรงแรกบนสไลด์เป็นรูปทรงกลุ่ม.
        $group = $slide->getShapes()->get_Item(0);

        // คัดลอกรูปทรงแต่ละอันจากกลุ่มและเพิ่มลงในสไลด์.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```