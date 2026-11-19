---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอด้วย PHP
linktitle: การนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/php-java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การหนีบ 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint ใน PHP ด้วย Aspose.Slides ตั้งค่ากล้อง, แสง, วัสดุ, การหนีบ, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides สำหรับ PHP ผ่าน Java สามารถสร้าง, แก้ไข, รักษา, และเรนเดอร์การจัดรูปแบบ 3 มิติสไตล์ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การหนีบ, การบีเวิล, การให้แสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3 มิติ

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบแยกส่วน เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3 มิติให้กับรูปร่าง เมธอดนี้จะคืนค่า [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ, ใช้เมธอด [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) เมธอดนี้จะนำการจัดรูปแบบ 3 มิติไปใช้กับกรอบข้อความแทนส่วนร่างกายของรูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อใดควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | จุดมองเห็น, ประเภทกล้องที่ตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือจับคู่กับค่าการหมุน 3 มิติที่ตั้งล่วงหน้าของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | การตั้งค่าแสงล่วงหน้า, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | วัสดุผิวหน้า เช่น แบน, แมตต์, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, มีความเงา, หรือมีลักษณะโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปร่างยืดออกจากหน้าตรง | เปลี่ยนรูปร่างแบนให้กลายเป็นอ็อบเจกต์ 3 มิติที่หนาเห็นชัด |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ถูกหนีบ | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าตรง |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | ความลึก 3 มิติเพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3 มิติของ PowerPoint | ปรับความลึกสำหรับรูปร่างหรือข้อความโดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่า bevel และ material |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | ขอบยกหรือโค้งบนหน้าและด้านหลัง | เพิ่มขอบที่นุ่มหรือหล่อรูปแทนการเป็นแผ่นเรียบแหลม |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างทั่วไปต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูสมจริงเป็น 3 มิติ:

- การตั้งค่ากล้อง, เนื่องจากมุมมองด้านหน้าเริ่มต้นอาจซ่อนการหนีบ
- การตั้งค่าแสง, เนื่องจากแสงทำให้หน้าและด้านของรูปร่างอ่านได้
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวส่งผลต่อการแสดงแสง
- การตั้งค่าการหนีบหรือความลึก, เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนหน้าตรง, และใช้การจัดรูปแบบ 3 มิติ ค่าการหมุนกล้องเป็นองศา และความสูงการหนีบ 100 จุด ตัวอย่างเรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้นและบันทึกงานนำเสนอเป็น PPTX

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

ภาพเรนเดอร์สไลด์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติหนา:

![เรนเดอร์สี่เหลี่ยม 3 มิติสีฟ้าพร้อมข้อความ 3 มิติสีขาวบนหน้าตรง](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติกำหนดจากแผง 3-D Rotation ค่าการหมุน X, Y, และ Z ตรงกับการหมุนที่ตั้งค่าผ่าน API ของกล้อง

![แผง PowerPoint 3-D Rotation ที่ไฮไลท์ค่าการหมุน X, Y, และ Z](img_02_01.png)

ใน Aspose.Slides เข้าถึงกล้องผ่าน [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้ารูปแบบออร์โธกราฟิก, และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, 40 องศา ตามลำดับ ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมเห็นวัตถุ มันไม่ได้เปลี่ยนรูปทรง 2 มิติของรูปร่างบนสไลด์ แต่เปลี่ยนจุดมองเห็น 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อตัวเรนเดอร์

### **คัดลอกการวางตำแหน่งกล้องจากรูปร่างแม่แบบ**

เพื่อให้ตรงกับการวางตำแหน่งของรูปร่างแม่แบบ, อ่านค่ากล้องที่ตั้งล่วงหน้าด้วย [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) และองศาการหมุนด้วย [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) ตัวอย่างเปิด `template.pptx` และคัดลอกตำแหน่งกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีการส่องแสง 3 มิติอยู่แล้วและรูปร่างที่สองไม่มีการหมุนกล้องที่ระบุ

องศาเป็นหน่วยองศา ดัชนี `0` คือละติจูด, ดัชนี `1` คือลองจิจูด, ดัชนี `2` คือการหมุนเต็มรอบ ส่งค่าต่อไปยัง [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) ตามลำดับ หากแหล่งให้ค่า `null` แสดงว่าไม่มีการหมุนที่ระบุไว้ จึงเว้นให้รูปร่างที่สองไม่มีการตั้งค่าองศา การหมุนที่ระบุเป็น `(0, 0, 0)` จะคืนค่าเป็นศูนย์สามค่าและควรคัดลอก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เมื่อคุณเปิด `camera-copy.pptx` ใหม่ใน PowerPoint ลูกศรด้านขวาจะมีการตั้งค่ากล้องและการหมุนเดียวกับสี่เหลี่ยมด้านซ้าย ทั้งสองรูปร่างใช้การส่องแสงและความลึกการหนีบเดียวกัน

![สี่เหลี่ยม 3 มิติสีฟ้าและลูกศรชี้ขวาที่มีตำแหน่งกล้องตรงกัน, ดูจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการหนีบและความลึก**

การหนีบทำให้รูปร่างดูหนาขึ้นโดยขยายออกไปข้างหลังหน้าตรง ใน PowerPoint ตัวควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และตัวควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint แมปกับคุณสมบัติสีâการหนีบและความสูงการหนีบ](img_02_02.png)

ใช้ [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) เพื่อกำหนดความหนาและ [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมหนีบ 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อเผยความหนา ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

เมธอด [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) ตั้งค่าความลึกของรูปร่าง 3 มิติ เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) ควบคุมความสูงของเอฟเฟกต์การหนีบ ตามที่แสดงในตัวอย่าง

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเป็นอิสระจากการเติมของรูปร่าง คุณสามารถใช้สีที่, การไล่สี, ลวดลาย, หรือการเติมภาพบนหน้าตรงและยังคงใช้กล้อง, แสง, วัสดุ, และการหนีบเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีจากสีฟ้าไปสีส้มบนหน้าตรงและสีส้มเข้มบนการหนีบ 150 จุด การหยุดไล่สีที่ 0 และ 100 คือจุดเริ่มและสิ้นสุดของการไล่สี ค่าการหมุนกล้องเป็นองศา สไลด์เรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้น:

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

ผลลัพธ์ที่เรนเดอร์ยังคงการไล่สีบนหน้าตรงและเรนเดอร์การหนีบแยกออกจากกัน:

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการไล่สีจากสีฟ้าไปสีส้มและการหนีบสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพแทน, เพิ่มภาพเข้าไปในงานนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องการไฟล์ที่มีอยู่ชื่อ "image.jpg" ในโฟลเดอร์ทำงาน มันขยายภาพให้เต็มสี่เหลี่ยม, ประยุกต์การหนีบ 150 จุด, และตั้งค่าการหมุนกล้องเป็นองศา ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

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

ภาพที่เติมบนหน้าตรงจะถูกเรนเดอร์ในขณะที่การหนีบแสดงเป็นพื้นผิวด้านข้าง 3 มิติ:

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการเติมรูปภาพบนหน้าตรงและการหนีบสีส้ม](img_02_04.png)

## **นำการจัดรูปแบบ 3 มิติไปใช้กับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างส่งผลต่อส่วนร่างกายของรูปร่าง การจัดรูปแบบ 3 มิติของข้อความส่งผลต่อกรอบข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการหนีบ, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยลวดลายตะแกรงสีส้มและขาว, ประยุกต์โค้งโค้งขึ้น, และตั้งค่าการจัดรูปแบบ 3 มิติผ่าน [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) ความสูงการหนีบและความลึกเป็นจุด, การหมุนแสงเป็นองศา การเติมและขอบของรูปร่างถูกซ่อนไว้เพื่อให้เห็นเฉพาะข้อความ ตัวอย่างเรนเดอร์เป็น PNG ขนาดสองเท่าของสไลด์และบันทึกงานนำเสนอเป็น PPTX:

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

ข้อความถูกเรนเดอร์เป็นอักษร 3 มิติที่โค้งและหนีบ:

![ข้อความ 3 มิติที่เรนเดอร์ด้วยการแปลงโค้งแบบ WordArt, เติมลวดลายสีส้ม, และการหนีบสีเข้ม](img_02_05.png)

## **ทำให้ข้อความแบนบนรูปร่าง 3 มิติ**

เพื่อให้ข้อความอ่านง่ายขณะคงลักษณะ 3 มิติของรูปร่าง, เรียก [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) ผ่าน [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) เมื่อค่าภายในเป็น `true` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อเป็น `false` ข้อความจะเข้าร่วมฉากและตามแนวทาง 3 มิติ

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3 มิติของรูปร่าง: กล้อง, แสง, วัสดุ, และการหนีบยังคงถูกกำหนดผ่าน [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) ซึ่งแตกต่างจากการหมุนปกติ [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) จะหมุนรูปร่างในระนาบสไลด์, ส่วน [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกรอบ การทำให้ข้อความอยู่นอกฉาก 3 มิติไม่ได้รีเซ็ตมุมเหล่านั้น

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีฟ้าพร้อมข้อความและสำเนาไว้ข้าง ๆ รูปร่างต้นแบบ ทั้งสองรูปร่างมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงการตั้งค่าข้อความต่างกัน: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการหนีบ 40 จุด ตัวอย่างบันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของขนาดเริ่มต้น

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

ทางซ้ายข้อความตามแนวทาง 3 มิติ ทางขวาข้อความแบนและอ่านง่ายกว่า ทั้งสองสี่เหลี่ยมยังคงการหนีบและแนวทาง 3 มิติที่มองเห็นได้เหมือนกัน

![สี่เหลี่ยม 3 มิติข้างกัน: ข้อความตามแนวทาง 3 มิติทางซ้ายและแบนทางขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบที่มีการจัดหน้าแบบคงที่ ฉาก 3 มิติจะถูกแปลงเป็นภาพพิกเซลหรือวาดลงในผลลัพธ์เป็น 2 มิติ ซึ่งใช้ได้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/php-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/php-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/php-java/convert-powerpoint-to-video/)

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังจากส่งออกได้
- ลักษณะสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ระบบแสง, วัสดุ, การหนีบ, การเติม, และสเกลสไลด์
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [effective shape properties](/slides/th/php-java/shape-effective-properties/)
- ฟอร์แมตผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในฟอร์แมตเหล่านั้น ผลลัพธ์ที่เห็นจะถูกเรนเดอร์แทนที่การเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพ, PDF, หรือหน้า HTML กลายเป็นฉาก 3 มิติแบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint เมื่อฟอร์แมตรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติเป็นออบเจกต์ 3 มิติเสริมที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การหนีบ, การบีเวิล, การให้แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างจึงจะเห็นรูปร่าง 3 มิติ?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและการหนีบหรือความลึก ในการปฏิบัติจริงควรตั้งค่าระบบแสงและวัสดุด้วยเพื่อให้พื้นผิวมีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) สำหรับส่วนร่างกายของรูปร่างและ [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช้ออบเจกต์ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/php-java/shape-effective-properties/) เพื่ออ่านกล้อง, ระบบแสง, เบเวล, และค่าต่าง ๆ ของ 3 มิติที่ได้จากการสืบทอดและธีม