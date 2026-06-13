---
title: ตาราง
type: docs
weight: 120
url: /th/php-java/examples/elements/table/
keywords:
- ตาราง
- เพิ่มตาราง
- เข้าถึงตาราง
- ลบตาราง
- ผสานเซลล์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและจัดรูปแบบตารางใน PHP ด้วย Aspose.Slides: แทรกข้อมูล, ผสานเซลล์, กำหนดสไตล์เส้นขอบ, จัดแนวเนื้อหา, และนำเข้า/ส่งออกสำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตารางและการผสานเซลล์โดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มตาราง**

สร้างตารางง่าย ๆ ที่มีสองแถวและสองคอลัมน์.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงตาราง**

ดึงรูปแบบตารางแรกบนสไลด์.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงตารางแรกบนสไลด์.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบตาราง**

ลบตารางออกจากสไลด์.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่าตารางเป็นรูปทรงแรกบนสไลด์.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ผสานเซลล์ของตาราง**

ผสานเซลล์ที่อยู่ติดกันของตารางเป็นเซลล์เดียว.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่าตารางเป็นรูปทรงแรกบนสไลด์.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```