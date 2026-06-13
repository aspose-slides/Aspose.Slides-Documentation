---
title: รูปภาพ
type: docs
weight: 50
url: /th/php-java/examples/elements/picture/
keywords:
- รูปภาพ
- กรอบรูปภาพ
- เพิ่มรูปภาพ
- เข้าถึงรูปภาพ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ทำงานกับรูปภาพใน PHP ด้วย Aspose.Slides: แทรก, แทนที่, ครอบตัด, บีบอัด, ปรับความโปร่งใสและเอฟเฟกต์, เติมรูปร่าง, และส่งออกเป็น PPT, PPTX และ ODP."
---
แสดงวิธีการแทรกและเข้าถึงรูปภาพโดยใช้ **Aspose.Slides for PHP via Java** ตัวอย่างด้านล่างจะวางรูปภาพบนสไลด์และจากนั้นดึงคืนมัน

## **เพิ่มรูปภาพ**

โค้ดนี้แทรกรูปภาพเป็นเฟรมรูปภาพบนสไลด์แรก

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // เพิ่มรูปภาพไปยังทรัพยากรของงานนำเสนอ.
        $ppImage = $presentation->getImages()->addImage($image);

        // แทรกเฟรมรูปภาพที่แสดงรูปบนสไลด์แรก.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้สไลด์มีเฟรมรูปภาพและจากนั้นเข้าถึงเฟรมแรกที่พบ

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึง PictureFrame แรกบนสไลด์.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```