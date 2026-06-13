---
title: SmartArt
type: docs
weight: 140
url: /th/php-java/examples/elements/smartart/
keywords:
- SmartArt
- เพิ่ม SmartArt
- เข้าถึง SmartArt
- ลบ SmartArt
- เลย์เอาต์ SmartArt
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและแก้ไข SmartArt ใน PHP ด้วย Aspose.Slides: เพิ่มโหนด, เปลี่ยนเลย์เอาต์และสไตล์, แปลงเป็นรูปทรงด้วยความแม่นยำ, และส่งออกเป็น PPT, PPTX และ ODP."
---
แสดงวิธีการเพิ่มกราฟิก SmartArt, เข้าถึง, ลบและเปลี่ยนเลย์เอาต์โดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่ม SmartArt**
แทรกกราฟิก SmartArt โดยใช้หนึ่งในเลย์เอาท์ที่มีมาให้

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึง SmartArt**
ดึงอ็อบเจ็กต์ SmartArt ตัวแรกบนสไลด์

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึง SmartArt ตัวแรกบนสไลด์.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบ SmartArt**
ลบรูปแบบ SmartArt ออกจากสไลด์

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็น SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เปลี่ยนเลย์เอาต์ SmartArt**
อัปเดตประเภทเลย์เอาต์ของกราฟิก SmartArt ที่มีอยู่

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็น SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // เปลี่ยนเลย์เอาต์ของ SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```