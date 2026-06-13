---
title: วัตถุ OLE
type: docs
weight: 210
url: /th/php-java/examples/elements/ole-object/
keywords:
- วัตถุ OLE
- เพิ่มวัตถุ OLE
- เข้าถึงวัตถุ OLE
- ลบวัตถุ OLE
- อัปเดตวัตถุ OLE
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับวัตถุ OLE ใน PHP ด้วย Aspose.Slides: แทรกหรืออัปเดตไฟล์ที่ฝังไว้, ตั้งค่าไอคอนหรือลิงก์, ดึงเนื้อหา, ควบคุมพฤติกรรมสำหรับ PPT, PPTX และ ODP."
---
แสดงการฝังไฟล์เป็นวัตถุ OLE และการอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มวัตถุ OLE**
ฝังไฟล์ PDF ลงในงานนำเสนอ.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงวัตถุ OLE**
ดึงเฟรมวัตถุ OLE ตัวแรกบนสไลด์.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงเฟรม OLE ตัวแรกบนสไลด์.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบวัตถุ OLE**
ลบวัตถุ OLE ที่ฝังไว้จากสไลด์.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็น OLE frame.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **อัปเดตข้อมูลวัตถุ OLE**
แทนที่ข้อมูลที่ฝังอยู่ในวัตถุ OLE ที่มีอยู่.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกบนสไลด์เป็น OLE frame.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```