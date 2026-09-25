---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอโดยใช้ PHP
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/php-java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การยืด 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint ใน PHP ด้วย Aspose.Slides. ตั้งค่ากล้อง, การให้แสง, วัสดุ, การยืด, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides สำหรับ PHP ผ่าน Java สามารถสร้าง, แก้ไข, คงไว้และแสดงผลการจัดรูปแบบ 3 มิติสไตล์ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การยืด, การบีเวิล, การให้แสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3 มิติ.

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบแยกส่วน เมื่อคุณส่งออกสไลด์เป็นรูปภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [Shape::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปร่าง เมธอดนี้ส่งคืน [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/), ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ, ใช้เมธอด [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนส่วนของรูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getCamera--) | มุมมอง, ประเภทกล้องแบบตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือให้ตรงกับการตั้งค่าการหมุน 3 มิติของ PowerPoint ที่กำหนดไว้ล่วงหน้า |
| [getLightRig](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getLightRig--) | การตั้งค่าแสง, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีการแสดงไฮไลท์และเงาบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setMaterial-byte-) | วัสดุพื้นผิว เช่น แบน, แมท, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, มันวาว, หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยืดออกไปด้านหลังจากผิวหน้า | แปลงรูปร่างแบนให้เป็นวัตถุ 3 มิติที่เห็นความหนา |
| [getExtrusionColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getExtrusionColor--) | สีของด้านที่ยืดออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับสีเติมหน้าที่ |
| [getDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3 มิติของ PowerPoint | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่า bevel และวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getBevelBottom--) | ขอบที่ยกขึ้นหรือโค้งบนผิวหน้าและผิวหลัง | เพิ่มขอบที่นุ่มหรือหล่อรูปแทนผิวแบนที่คม |
| [getContourColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setContourWidth-double-) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบเขตของวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าตามค่าเริ่มต้นอาจทำให้การยืดไม่เห็น
- การตั้งค่าแสง, เนื่องจากแสงทำให้ผิวหน้าและด้านอ่านได้ง่าย
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง
- การตั้งค่าการยืดหรือความลึก, เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนผิวหน้าของมัน, และใช้การจัดรูปแบบ 3 มิติ ค่าการหมุนของกล้องอยู่เป็นองศา, และความสูงการยืดคือ 100 พอยต์ ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ที่มีขนาดสองเท่าของขนาดเริ่มต้นและบันทึกงานนำเสนอเป็น PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้าแสดงผลพร้อมข้อความ 3 มิติสีขาวบนผิวหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint, การหมุน 3 มิติจะกำหนดจากแผง 3-D Rotation ค่าการหมุน X, Y, และ Z ตรงกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง 3-D Rotation ของ PowerPoint ที่ไฮไลท์ค่าการหมุน X, Y, และ Z](img_02_01.png)

ใน Aspose.Slides, เข้าถึงกล้องผ่าน [ThreeDFormat::getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getCamera--). ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้าตามแบบออร์โธกราฟิก, และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ มันไม่เปลี่ยนรูปทรง 2 มิติของรูปร่างบนสไลด์ แต่จะเปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการยืดและความลึก**

การยืดทำให้รูปร่างดูหนาขึ้นโดยขยายออกไปด้านหลังของผิวหน้า ใน PowerPoint, การควบคุมความลึกกำหนดความหนาที่มองเห็นได้, และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่เชื่อมกับคุณสมบัติสีการยืดและความสูงการยืด](img_02_02.png)

ใช้ [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) เพื่อตั้งค่าความหนาและ [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getExtrusionColor--) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมยืด 100 พอยต์พร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

เมธอด [ThreeDFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setDepth-double-) ตั้งค่าความลึกของรูปร่าง 3 มิติ เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) ควบคุมความสูงของเอฟเฟกต์การยืด ตามที่แสดงในตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติไม่ขึ้นอยู่กับการเติมรูปของรูปร่าง คุณสามารถใช้สีทึบ, การไล่สี, แพทเทิร์น, หรือการเติมรูปภาพบนผิวหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการยืดเดียวกัน

ตัวอย่างนี้ใช้การไล่สีจากสีน้ำเงินไปส้มบนผิวหน้าและสีส้มเข้มบนการยืด 150 พอยต์ จุดหยุดของการไล่สีที่ 0 และ 100 แสดงจุดเริ่มต้นและสิ้นสุดของการไล่ สีการหมุนของกล้องเป็นองศา สไลด์ถูกเรนเดอร์เป็นภาพ PNG ที่มีขนาดสองเท่าของขนาดเริ่มต้น:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการไล่สีจากสีน้ำเงินไปส้มและการยืดสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องการไฟล์ที่มีชื่อ "image.jpg" อยู่ในไดเรกทอรีทำงาน มันขยายรูปให้เต็มสี่เหลี่ยม, ใช้การยืด 150 พอยต์, และตั้งค่าการหมุนของกล้องเป็นองศา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมรูปภาพบนผิวหน้าและการยืดสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างส่งผลต่อส่วนของรูปร่าง การจัดรูปแบบ 3 มิติของข้อความส่งผลต่อกรอบข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการยืด, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยแพทเทิร์นตารางสีส้มและสีขาว, ใช้การโค้งขึ้นด้านบน, และกำหนดการตั้งค่า 3 มิติผ่าน [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--). ความสูงการยืดและความลึกเป็นพอยต์, การหมุนของแสงเป็นองศา, การเติมและเส้นขอบของรูปร่างถูกซ่อนเพื่อให้เห็นข้อความเท่านั้น ตัวอย่างนี้เรนเดอร์ภาพ PNG ที่มีขนาดสองเท่าของสไลด์เริ่มต้นและบันทึกงานนำเสนอเป็น PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ข้อความ 3 มิติที่เรนเดอร์พร้อมการแปลง WordArt แบบโค้ง, การเติมแพทเทิร์นสีส้ม, และการยืดสีเข้ม](img_02_05.png)

## **คงข้อความให้แบนบนรูปร่าง 3 มิติ**

เพื่อคงข้อความให้อ่านง่ายขณะรักษารูปร่าง 3 มิติไว้, เรียกใช้ [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) ผ่าน [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getTextFrameFormat--). เมื่อค่าที่ตั้งเป็น `true` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อเป็น `false` ข้อความจะเข้าร่วมในฉากและตามทิศทาง 3 มิติของมัน

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3 มิติของรูปร่าง: กล้อง, แสง, วัสดุ, และการยืดยังคงตั้งค่าไว้ผ่าน [Shape::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getThreeDFormat--). มันต่างจากการหมุนทั่วไป [Shape::setRotation](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setRotation-float-) จะหมุนรูปร่างในระนาบสไลด์, ขณะที่ [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกล่องขอบเขตของมัน การคงข้อความให้อยู่นอกฉาก 3 มิติไม่ได้รีเซ็ตมุมเหล่านั้น

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนามาวางข้างต้นแบบเดิม ทั้งสองรูปร่างมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงการตั้งค่าข้อความที่แตกต่าง: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศา, ความสูงการยืดเป็น 40 พอยต์ ตัวอย่างบันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ที่มีขนาดสองเท่าของขนาดเริ่มต้น

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![สี่เหลี่ยม 3 มิติข้างเคียง: ข้อความตามแนว 3 มิติทางซ้ายและคงแบนทางขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบจัดตำแหน่งคงที่, ฉาก 3 มิติจะถูกแปลงเป็นราสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2 มิติ ซึ่งจะเกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/php-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/php-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/php-java/convert-powerpoint-to-video/).

- ภาพและ PDF ที่ส่งออกไม่ได้เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการรวมกันของกล้อง, แสง, วัสดุ, การยืด, การเติม, และการสเกลสไลด์
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม ให้อ่าน [คุณสมบัติรูปร่างที่มีผล](/slides/th/php-java/shape-effective-properties/)
- บางรูปแบบเอาต์พุตไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **FAQ**

**Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติแบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**โมเดล 3 มิติ กับเอฟเฟกต์ 3 มิติแตกต่างกันอย่างไร?**

โมเดล 3 มิติคือวัตถุ 3 มิติแยกที่แทรกเข้าสู่การนำเสนอ ส่วนเอฟเฟกต์ 3 มิติคือการจัดรูปแบบที่นำไปใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การยืด, การบีเวิล, การให้แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**การตั้งค่าใดจำเป็นสำหรับรูปร่าง 3 มิติที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการยืดหรือความลึก ในการปฏิบัติ ควรตั้งค่าแสงและวัสดุเพื่อให้พื้นผิวที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้. ใช้ [Shape::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getThreeDFormat--) สำหรับส่วนของรูปร่างและ [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่. Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์, ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าของ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ใช่. ใช้ API การจัดรูปแบบที่มีผลอธิบายไว้ใน [คุณสมบัติรูปร่างที่มีผล](/slides/th/php-java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, แสง, bevel, และค่า 3 มิติอื่นๆ ที่สุดท้าย