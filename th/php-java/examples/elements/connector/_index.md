---
title: ตัวเชื่อม
type: docs
weight: 190
url: /th/php-java/examples/elements/connector/
keywords:
- ตัวเชื่อม
- เพิ่มตัวเชื่อม
- เข้าถึงตัวเชื่อม
- ลบตัวเชื่อม
- เชื่อมต่อรูปร่างใหม่
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "วาดและควบคุมตัวเชื่อมใน PHP ด้วย Aspose.Slides: เพิ่ม, กำหนดเส้นทาง, กำหนดเส้นทางใหม่, ตั้งจุดเชื่อมต่อ, ลูกศรและสไตล์เพื่อเชื่อมโยงรูปร่างใน PPT, PPTX และ ODP."
---
แสดงวิธีเชื่อมต่อรูปร่างด้วยตัวเชื่อมและเปลี่ยนเป้าหมายโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มตัวเชื่อม**

แทรกรูปร่างตัวเชื่อมระหว่างสองจุดบนสไลด์.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงตัวเชื่อม**

ดึงรูปแบบตัวเชื่อมแรกที่เพิ่มลงในสไลด์.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงตัวเชื่อมแรกบนสไลด์.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบตัวเชื่อม**

ลบตัวเชื่อมออกจากสไลด์.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่ารูปร่างแรกบนสไลด์เป็นตัวเชื่อม.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เชื่อมต่อรูปร่างใหม่**

แนบตัวเชื่อมกับสองรูปร่างโดยกำหนดเป้าหมายจุดเริ่มต้นและจุดสิ้นสุด.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```