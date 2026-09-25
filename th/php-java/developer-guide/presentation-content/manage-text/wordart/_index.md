---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน PHP
linktitle: WordArt
type: docs
weight: 110
url: /th/php-java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- เทมเพลต WordArt
- เอฟเฟกต์ WordArt
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์การเรืองแสง
- การแปลงรูป WordArt
- เอฟเฟกต์ 3D
- เอฟเฟกต์เงานอก
- เอฟเฟกต์เงาภายใน
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟกต์ WordArt ใน Aspose.Slides for PHP via Java คำแนะนำทีละขั้นตอนนี้ช่วยนักพัฒนาเพิ่มประสิทธิภาพการนำเสนอด้วยข้อความระดับมืออาชีพใน PHP."
---
## **ภาพรวม**

เอฟเฟกต์ WordArt ช่วยให้คุณจัดรูปแบบข้อความด้วยการเติมสี, ขอบ, เงา, การสะท้อน, การเรืองแสง, การแปลงรูป, และการจัดรูปแบบ 3D บทความนี้อธิบายวิธีสร้างและปรับแต่งเอฟเฟกต์เหล่านี้ในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for PHP via Java โดยไม่ต้องติดตั้ง Microsoft Office

## **สร้างเทมเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความ**

ตัวอย่างต่อไปนี้สร้างสไตล์ WordArt อย่างง่ายโดยตั้งค่าข้อความ, แบบอักษร, การเติมแบบลาย, และขอบ

แต่ละตัวอย่างจะสร้างงานนำเสนอใหม่และเพิ่มสี่เหลี่ยมผืนผ้าไปยังสไลด์แรก; ไม่ต้องใช้ไฟล์อินพุต ตัวอย่างแรกตั้งค่าข้อความเป็น “Aspose.Slides” ตำแหน่งและขนาดของรูปทรงวัดเป็นพอยต์:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

ตั้งค่าแบบอักษรเป็น Arial Black ขนาด 36 พอยต์เพื่อให้การจัดรูปแบบโดดเด่นขึ้น:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

ใช้ลาย [SmallGrid](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternstyle/#SmallGrid) ที่มีสีพื้นหน้าส้มเข้มและพื้นหลังสีขาว แล้วเพิ่มขอบข้อความสีดำความกว้าง 1 พอยต์:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![เทมเพลต WordArt อย่างง่าย](WordArt_template.png)

## **นำเอฟเฟกต์ WordArt อื่น ๆ ไปใช้**

ตัวอย่างต่อไปนี้แสดงวิธีนำเงา, การสะท้อน, การเรืองแสง, การแปลงรูป และเอฟเฟกต์ 3D ไปใช้กับข้อความ

### **นำเอฟเฟกต์เงานอก (Outer Shadow) ไปใช้**

เงานอกเพิ่มความลึกโดยวางเงาอยู่อยู่ด้านหลังข้อความ คุณสามารถปรับสี, ทิศทาง, ระยะ, รัศมีเบลอ, สเกล, และการเอียงได้

ตัวอย่างนี้เรียกใช้ [enableOuterShadowEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) และตั้งค่าเงาสีดำด้วยรัศมีเบลอ 4 พอยต์, ทิศทาง 230°, ระยะ 30 พอยต์ สเกล 100 คงขนาดเงาไว้ ขณะเอียงแนวนอน 20° การแปลงอัลฟากำหนดความทึบเป็น 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![เอฟเฟกต์เงานอก](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- เมื่อใช้เงานอกและเงาที่กำหนดไว้พร้อมกัน จะใช้เฉพาะเงานอกเท่านั้น
- หากใช้เงานอกและเงาภายในพร้อมกัน ผลลัพธ์ขึ้นอยู่กับรุ่น PowerPoint ตัวอย่างเช่น PowerPoint 2013 จะทำให้เอฟเฟกต์เป็นสองเท่า ในขณะที่ PowerPoint 2007 จะใช้เฉพาะเงานอก
{{% /alert %}}

### **นำเอฟเฟกต์การสะท้อน (Reflection) ไปใช้**

การสะท้อนสร้างสำเนาแบบกระจกของข้อความ ปรับตำแหน่ง, สเกล, เบลอ, และความทึบเพื่อควบคุมลักษณะของการสะท้อน

ตัวอย่างนี้เรียกใช้ [enableReflectionEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effectformat/#enableReflectionEffect--) และพลิกการสะท้อนในแนวตั้งด้วยสเกล -100% ใช้รัศมีเบลอ 0.5 พอยต์และระยะ 4.72 พอยต์ ความทึบลดจาก 60% เหลือ 0.9% ระหว่างตำแหน่ง 0% ถึง 60% ตามการสะท้อน:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

### **นำเอฟเฟกต์เรืองแสง (Glow) ไปใช้**

การเรืองแสงเพิ่มขอบสีอ่อนรอบข้อความ ปรับสี, ความทึบ, และรัศมีเพื่อควบคุมเอฟเฟกต์

ตัวอย่างนี้เรียกใช้ [enableGlowEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effectformat/#enableGlowEffect--) และใส่เรืองแสงสีแดงความทึบ 54% รัศมี 7 พอยต์:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![เอฟเฟกต์เรืองแสง](glow_effect.png)

### **นำการแปลงรูป WordArt ไปใช้**

การแปลงรูป WordArt ทำให้ข้อความโค้ง, ยืด หรือบิด

ตั้งค่า [setTransform](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setTransform-int-) เป็น [ArchUpPour](https://reference.aspose.com/slides/th/php-java/aspose.slides/textshapetype/#ArchUpPour) เพื่อโค้งกรอบข้อความทั้งหมดขึ้นด้านบน:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![การแปลงรูป WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java มีชุดประเภทการแปลงรูปที่กำหนดไว้ล่วงหน้าไว้ที่ [transformation types](https://reference.aspose.com/slides/th/php-java/aspose.slides/textshapetype/)
{{% /alert %}}

### **นำเอฟเฟกต์ 3D ไปใช้กับรูปร่างและข้อความ**

คุณสามารถใช้เอฟเฟกต์ 3D กับรูปร่างหรือข้อความของมัน เบเวล, การดันออก, การจัดแสง, และการตั้งค่ากล้องจะกำหนดลักษณะสุดท้าย

ตัวอย่างต่อไปนี้ใช้ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) เพื่อเพิ่มเบเวลวงกลม, การดันออกสีส้ม, และขอบสีแดงเข้มให้กับสี่เหลี่ยม ผมิติของเบเวล, ความสูงของการดันออก, ความกว้างของขอบ, และความลึกทั้งหมดวัดเป็นพอยต์ วัสดุพลาสติก, การจัดแสงสมดุลที่หมุน 40° รอบแกน Z, และกล้องแบบมุมมองกำหนดลักษณะของรูปร่าง:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

รูปร่างที่ได้:

![เอฟเฟกต์ 3D ของรูปร่าง](shape_3D_effect.png)

ตัวอย่างนี้ใช้การจัดรูปแบบ 3D แบบเดียวกันกับข้อความผ่าน [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#getThreeDFormat--) เบเวลที่เล็กกว่าจะทำให้ขอบตัวอักษรเรียบเรียง ขณะการดันออกและการจัดแสงให้ความลึกกับข้อความ:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

ข้อความที่ได้:

![เอฟเฟกต์ 3D ของข้อความ](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
การใช้เอฟเฟกต์ 3D กับข้อความหรือรูปร่างของมัน—และการโต้ตอบระหว่างเอฟเฟกต์เหล่านี้—ถูกกำหนดด้วยกฎเฉพาะ พิจารณาฉากที่ประกอบด้วยข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D จะรวมถึงการแสดงผล 3D ของวัตถุและฉากที่วัตถุถูกวางอยู่

- หากกำหนดฉากให้กับทั้งรูปร่างและข้อความ ฉากของรูปร่างจะมีลำดับความสำคัญและฉากของข้อความจะถูกละเลย
- หากรูปร่างไม่มีฉากของตนเองแต่มีการแสดงผล 3D ข้อความจะใช้ฉากของมันเอง
- หากรูปร่างไม่มีเอฟเฟกต์ 3D เลย จะถือว่าเป็นแผ_flat_ และเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความเท่านั้น

พฤติกรรมเหล่านี้เกี่ยวข้องกับเมธอด [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getLightRig--) และ [ThreeDFormat::getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/#getCamera--)
{{% /alert %}}

สำหรับตัวอย่างเพิ่มเติมของการจัดรูปแบบ 3D โปรดดู [Create 3D Effects in Presentations Using PHP](/slides/th/php-java/3d-presentation/)

## **FAQ**

**สามารถใช้เอฟเฟกต์ WordArt กับแบบอักษรหรือสคริปต์ที่แตกต่างกัน (เช่น Arabic, Chinese) ได้หรือไม่?**

ได้, Aspose.Slides for PHP via Java รองรับ Unicode และทำงานกับแบบอักษรและสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, เติมสี, และขอบสามารถใช้ได้ regardless of language แม้ว่าการมีอยู่ของแบบอักษรและการเรนเดอร์อาจขึ้นอยู่กับแบบอักษรระบบ

**สามารถนำเอฟเฟกต์ WordArt ไปใช้กับองค์ประกอบของ Slide Master ได้หรือไม่?**

ได้, คุณสามารถนำเอฟเฟกต์ WordArt ไปใช้กับรูปร่างบนสไลด์มาสเตอร์ รวมถึงตัวอักษรตำแหน่ง, พายม่า, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะสะท้อนไปยังสไลด์ที่เชื่อมโยงทั้งหมด

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์งานนำเสนอหรือไม่?**

มีผลเล็กน้อย เอฟเฟกต์ WordArt เช่น เงา, เรืองแสง, และการเติมแบบไล่สีอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาต้าเพิ่มเติม แต่ส่วนต่างมักไม่มีนัยสำคัญ

**สามารถดูตัวอย่างผลลัพธ์ของเอฟเฟกต์ WordArt ได้โดยไม่ต้องบันทึกงานนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt เป็นภาพ (เช่น PNG, JPEG) โดยใช้ [Slide::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getImage--) หรือเรนเดอร์รูปร่างแต่ละอันโดยใช้ [Shape::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage--) ซึ่งช่วยให้คุณดูตัวอย่างผลลัพธ์ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกงานนำเสนอเต็มรูปแบบ