---
title: สร้างเอฟเฟ็กต์ 3 มิติในงานนำเสนอด้วย PHP
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดันออก 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟ็กต์ 3 มิติสำหรับรูปร่างและข้อความใน PowerPoint ด้วย PHP และ Aspose.Slides ตั้งค่ากล้อง, การจัดแสง, วัสดุ, การดันออก, การเติม, และข้อความ 3 มิติ"
---
## **ภาพรวม**

Aspose.Slides สำหรับ PHP ผ่าน Java สามารถสร้าง, แก้ไข, คงไว้ และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดัน, bevels, การจัดแสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3 มิติ

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความใน PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF, หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้คลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) และเมธอด [Shape::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติให้กับรูปร่าง เมธอดนี้จะคืนค่า [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ใช้คลาส [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/) และเมธอด [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนเนื้อหารูปร่าง

การตั้งค่าที่สำคัญที่สุดมีดังนี้

| เมธอดหรือการตั้งค่า | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getCamera--) | จุดมุมมอง, ประเภทกล้องตั้งต้น, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่าตั้งต้นการหมุน 3 มิติของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getLightRig--) | แสงตั้งต้น, ทิศทาง, และการหมุนแสง | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ |
| [setMaterial](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setMaterial-byte-) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, เงาวับ, หรือเป็นโลหะ |
| [setExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยื่นออกมาจากหน้าเดิม | แปลงรูปร่างแบนให้เป็นวัตถุ 3 มิติที่มองเห็นความหนา |
| [getExtrusionColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getExtrusionColor--) | สีของด้านที่ยื่นออกมา | ทำให้ความลึกเห็นชัดหรือประสานสีด้านกับสีเติมหน้า |
| [setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกสำหรับรูปร่างหรือข้อความโดยเฉพาะเมื่อนำไปใช้ร่วมกับ bevel และ material |
| [getBevelTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getBevelBottom--) | ขอบยกหรือโค้งบนหน้าและด้านหลัง | เพิ่มขอบที่อ่อนหรือหล่อรูปแทนที่ขอบแบนและคม |
| [getContourColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getContourColor--) และ [setContourWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setContourWidth-double-) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างส่วนใหญ่ต้องการการตั้งค่าสี่ประเภทก่อนที่จะแสดงเป็น 3 มิติอย่างสมจริง:

- การตั้งค่ากล้อง, เนื่องจากมุมมองด้านหน้าตั้งต้นอาจซ่อนการดันออก
- การตั้งค่าแสง, เพราะแสงทำให้ด้านและด้านข้างอ่านได้
- การตั้งค่าวัสดุ, เพราะพื้นผิวมีผลต่อการแสดงแสง
- การตั้งค่าการดันหรือความลึก, เพราะรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เติมข้อความลงบนหน้า, ใช้การจัดรูปแบบ 3 มิติ, บันทึกงานนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

```php
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

![ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมสีฟ้า 3 มิติพร้อมข้อความ 3 มิติสีขาวบนหน้าตรง](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติกำหนดจากแผง 3‑D Rotation ค่า X, Y, และ Z correspond กับการหมุนที่กำหนดผ่าน API ของกล้อง

![แผง 3‑D Rotation ของ PowerPoint แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides ตั้งค่าประเภทกล้องและการหมุนผ่าน [ThreeDFormat::getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getCamera--) :

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ มันไม่เปลี่ยนเรขาคณิต 2 มิติของรูปร่างบนสไลด์ แต่จะเปลี่ยนจุดมองเห็น 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อนำไปเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันทำให้รูปร่างดูหนาด้วยการขยายออกจากหน้าใน PowerPoint ตัวควบคุมความลึกตั้งค่าความหนาที่มองเห็นได้และตัวควบคุมสีตั้งค่าสีของด้านข้าง

![ตัวควบคุมความลึกของ PowerPoint ที่แมปกับสีการดันและคุณสมบัติความสูงการดัน](img_02_02.png)

ตั้งค่า [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) เพื่อความหนาและ [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getExtrusionColor--) เพื่อสีด้านข้าง:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

ใช้ [ThreeDFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#setDepth-double-) เมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือผสานความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายกรณีของรูปร่าง `setExtrusionHeight` เป็นการตั้งค่าที่ชัดเจนกว่าเพราะแสดงความหนาที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติทำงานแยกจากการเติมรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลวดลาย, หรือภาพลงบนหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันได้เช่นกัน

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและตั้งค่าสีการดันที่เข้มกว่าบนด้านข้าง:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนหน้าและเรนเดอร์การดันแยกต่างหาก:

![ภาพสไลด์ที่เรนเดอร์ 3 มิติของสี่เหลี่ยมที่มีไล่สีฟ้าถึงส้มและการดันสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ, เพิ่มภาพไปยังงานนำเสนอและกำหนดให้เป็นการเติมรูปร่าง:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

ภาพจะถูกเรนเดอร์บนหน้า ในขณะที่การดันจะถูกเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ:

![ภาพสไลด์ที่เรนเดอร์ 3 มิติของสี่เหลี่ยมที่มีการเติมภาพบนหน้าและการดันสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างส่งผลต่อเนื้อหารูปร่าง การจัดรูปแบบ 3 มิติของข้อความส่งผลต่อกรอบข้อความ นี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการดัน, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลวดลาย, ใช้การแปลง WordArt, และกำหนดค่าการตั้งค่า 3 มิติบน [TextFrameFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

ข้อความที่เรนเดอร์เป็นตัวอักษร 3 มิติที่โค้ง, ดันออก, มีลวดลายสีส้ม, และการดันสีเข้ม:

![ภาพสไลด์ที่เรนเดอร์ข้อความ 3 มิติที่โค้งด้วยการแปลง WordArt, เติมลวดลายสีส้ม, และการดันสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบเลย์เอาต์คงที่ ฉาก 3 มิติจะถูกเรสเตอร์หรือวาดลงในผลลัพธ์เป็น 2 มิติ นี้เกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/php-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/php-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/php-java/convert-powerpoint-to-video/)

ควรจำไว้ว่า:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการผสานของกล้อง, light rig, material, extrusion, fill, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้เรียกดู [effective shape properties](/slides/th/php-java/shape-effective-properties/)
- รูปแบบบางประเภทไม่สามารถเก็บการจัดรูปแบบ 3 มิติที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติจะยังคงสามารถแก้ไขได้ใน PowerPoint เมื่อรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติคือวัตถุ 3 มิติแยกที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติคือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดัน, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**การตั้งค่าใดที่จำเป็นสำหรับรูปร่าง 3 มิติที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและตั้งค่าการดันหรือความลึก ในการปฏิบัติยังควรตั้งค่า light rig และ material เพื่อให้หน้าที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [Shape::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getThreeDFormat--) สำหรับเนื้อหารูปร่างและ [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML, หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะการแสดงผลที่เรนเดอร์ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/php-java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, bevel, และค่าการจัดรูปแบบ 3 มิติที่เกี่ยวข้องสุดท้าย