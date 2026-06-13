---
title: จัดการพื้นหลังการนำเสนอใน PHP
linktitle: พื้นหลังสไลด์
type: docs
weight: 20
url: /th/php-java/presentation-background/
keywords:
- พื้นหลังการนำเสนอ
- พื้นหลังสไลด์
- สีทึบ
- สีไล่สี
- พื้นหลังภาพ
- ความโปร่งแสงของพื้นหลัง
- คุณสมบัติของพื้นหลัง
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java พร้อมเคล็ดลับโค้ดเพื่อยกระดับการนำเสนอของคุณ."
---
## **บทนำ**

สีทึบ, การไล่สี, และรูปภาพมักใช้เป็นพื้นหลังของสไลด์ คุณสามารถตั้งค่าพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์มาสเตอร์** (ใช้กับหลายสไลด์พร้อมกัน)

![PowerPoint background](powerpoint-background.png)

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์ปกติ**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังสำหรับสไลด์เฉพาะในงานนำเสนอ — แม้ว่างานนำเสนอจะใช้สไลด์มาสเตอร์ การเปลี่ยนแปลงนี้จะใช้กับสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/php-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Solid`.
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#getSolidFillColor) บน [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังแบบทึบ.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง PHP ด้านล่างแสดงวิธีตั้งค่าสีทึบสีฟ้าเป็นพื้นหลังสำหรับสไลด์ปกติ:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีน้ำเงิน.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // บันทึกงานนำเสนอไปยังดิสก์.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์มาสเตอร์**

Aspose.Slides ให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์มาสเตอร์ในงานนำเสนอ สไลด์มาสเตอร์ทำหน้าที่เป็นเทมเพลตที่ควบคุมการจัดรูปแบบของสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบเป็นพื้นหลังของสไลด์มาสเตอร์ มันจะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/php-java/aspose.slides/backgroundtype/) ของสไลด์มาสเตอร์ (ผ่าน `getMasters`) เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของพื้นหลังสไลด์มาสเตอร์เป็น `Solid`.
4. ใช้เมธอด [getSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#getSolidFillColor) เพื่อระบุสีพื้นหลังแบบทึบ.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง PHP ด้านล่างแสดงวิธีตั้งค่าสีทึบ (สีเขียว) เป็นพื้นหลังสำหรับสไลด์มาสเตอร์:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // ตั้งค่าสีพื้นหลังของสไลด์มาสเตอร์เป็นสีเขียวป่า.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // บันทึกงานนำเสนอไปยังดิสก์.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าพื้นหลังแบบไล่สีสำหรับสไลด์**

การไล่สีเป็นเอฟเฟกต์กราฟิกที่สร้างโดยการเปลี่ยนสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังของสไลด์ การไล่สีสามารถทำให้การนำเสนอดูศิลป์และเป็นมืออาชีพมากขึ้น Aspose.Slides ให้คุณตั้งค่าสีไล่สีเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/php-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Gradient`.
4. ใช้เมธอด [getGradientFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#getGradientFormat) บน [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าการไล่สีตามที่ต้องการ.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง PHP ด้านล่างแสดงวิธีตั้งค่าสีไล่สีเป็นพื้นหลังสำหรับสไลด์:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // ใช้เอฟเฟกต์ไล่สีกับพื้นหลัง.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // บันทึกงานนำเสนอไปยังดิสก์.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งรูปภาพเป็นพื้นหลังของสไลด์**

นอกจากการเติมสีทึบและการไล่สีแล้ว Aspose.Slides ยังให้คุณใช้รูปภาพเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. ตั้งค่า [BackgroundType](https://reference.aspose.com/slides/th/php-java/aspose.slides/backgroundtype/) ของสไลด์เป็น `OwnBackground`.
3. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของพื้นหลังสไลด์เป็น `Picture`.
4. โหลดรูปภาพที่ต้องการใช้เป็นพื้นหลังของสไลด์.
5. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ.
6. ใช้เมธอด [getPictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/#getPictureFillFormat) บน [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) เพื่อกำหนดรูปภาพเป็นพื้นหลัง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่าง PHP ด้านล่างแสดงวิธีตั้งรูปภาพเป็นพื้นหลังของสไลด์:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // ตั้งค่าคุณสมบัติของภาพพื้นหลัง.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // โหลดภาพ.
    $image = Images::fromFile("Tulips.jpg");
    // เพิ่มภาพเข้าไปในคอลเลกชันภาพของงานนำเสนอ.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // บันทึกงานนำเสนอไปยังดิสก์.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นรูปภาพแบบต่อภาพ (tiled picture) และปรับคุณสมบัติการต่อภาพ:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // ตั้งค่าภาพที่ใช้สำหรับเติมพื้นหลัง.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // ตั้งค่าโหมดการเติมภาพเป็นแบบต่อภาพ (Tile) และปรับคุณสมบัติของการต่อ.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
อ่านเพิ่มเติม: [**Tile Picture As Texture**](/slides/th/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **เปลี่ยนความโปร่งแสงของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งแสงของภาพพื้นหลังสไลด์เพื่อให้เนื้อหาของสไลด์โดดเด่นขึ้น ตัวอย่างโค้ด PHP ด้านล่างแสดงวิธีการเปลี่ยนความโปร่งแสงของภาพพื้นหลังสไลด์:

```php
$transparencyValue = 30; // เช่น ตัวอย่าง.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **รับค่าพื้นหลังของสไลด์**

Aspose.Slides มีคลาส `BackgroundEffectiveData` สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ คลาสนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) และ [EffectFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/effectformat/) ที่มีผล

โดยใช้เมธอด `getBackground` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง PHP ด้านล่างแสดงวิธีรับค่าพื้นหลังที่มีผลของสไลด์:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // ดึงพื้นหลังที่มีผลโดยคำนึงถึงมาสเตอร์, เลย์เอาต์และธีม.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและกู้คืนพื้นหลังของธีม/เลย์เอาต์ได้หรือไม่?**

ใช่. ลบการเติมสีที่กำหนดเองของสไลด์ และพื้นหลังจะถูกสืบทอดอีกครั้งจากสไลด์ [layout](/slides/th/php-java/slide-layout/)/[master](/slides/th/php-java/slide-master/) ที่เกี่ยวข้อง (เช่น [theme background](/slides/th/php-java/presentation-theme/)).

**จะเกิดอะไรขึ้นกับพื้นหลังเมื่อฉันเปลี่ยนธีมของงานนำเสนอในภายหลัง?**

หากสไลด์มีการเติมสีของตนเอง จะไม่เปลี่ยนแปลง หากพื้นหลังสืบทอดมาจาก [layout](/slides/th/php-java/slide-layout/)/[master](/slides/th/php-java/slide-master/) มันจะอัปเดตให้ตรงกับ [new theme](/slides/th/php-java/presentation-theme/).