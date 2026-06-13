---
title: สร้างและใช้เอฟเฟกต์ WordArt ใน PHP
linktitle: WordArt
type: docs
weight: 110
url: /th/php-java/wordart/
keywords:
- WordArt
- สร้าง WordArt
- แม่แบบ WordArt
- เอฟเฟ็กต์ WordArt
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การแสดงผล
- เอฟเฟ็กต์แสงวาบ
- การแปลง WordArt
- เอฟเฟ็กต์ 3 มิติ
- เอฟเฟ็กต์เงานอก
- เอฟเฟ็กต์เงาภายใน
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งเอฟเฟ็กต์ WordArt ใน Aspose.Slides สำหรับ PHP ผ่าน Java คู่มือขั้นตอนนี้ช่วยนักพัฒนาปรับปรุงการนำเสนอด้วยข้อความระดับมืออาชีพ"
---
## **Overview**

เอฟเฟกต์ WordArt ช่วยให้คุณเพิ่มข้อความที่สวยงามและมีสไตล์ให้กับงานนำเสนอ PowerPoint ของคุณได้อย่างน่าสนใจ ด้วย Aspose.Slides นักพัฒนาสามารถสร้าง ปรับแต่ง และจัดการ WordArt แบบโปรแกรมเมติกได้เช่นเดียวกับใน Microsoft PowerPoint — โดยไม่ต้องติดตั้ง Office บทความนี้ให้ภาพรวมของการทำงานกับ WordArt รวมถึงวิธีใช้การแปลงข้อความ, สไตล์การเติม, เส้นขอบ, เงา และตัวเลือกการจัดรูปแบบอื่น ๆ เพื่อทำให้เนื้อหาการนำเสนอของคุณมีความแสดงออกและดึงดูดมากยิ่งขึ้น WordArt อนุญาตให้คุณพิจารณาข้อความเป็นวัตถุกราฟิก มันประกอบด้วยเอฟเฟกต์หรือการแก้ไขพิเศษที่นำไปใช้กับข้อความเพื่อทำให้มันดูน่าสนใจหรือโดดเด่นยิ่งขึ้น

## **สร้างเทมเพลต WordArt อย่างง่ายและนำไปใช้กับข้อความ**

**ใช้ Aspose.Slides**

อันดับแรก เราสร้างข้อความง่าย ๆ โดยใช้โค้ด PHP นี้:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
จากนั้น เรากำหนดความสูงของฟอนต์ของข้อความให้ใหญ่ขึ้นเพื่อให้เอฟเฟกต์ชัดเจนยิ่งขึ้นโดยใช้โค้ดนี้:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**ใช้ Microsoft PowerPoint**

ไปที่เมนูเอฟเฟกต์ WordArtใน Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

จากเมนูด้านขวา คุณสามารถเลือกเอฟเฟกต์ WordArt ที่กำหนดล่วงหน้าได้ จากเมนูด้านซ้าย คุณสามารถกำหนดการตั้งค่าสำหรับ WordArt ใหม่ได้

ต่อไปนี้เป็นพารามิเตอร์หรือ 옵션ที่มีให้เลือกบางส่วน:

![todo:image_alt_text](image-20200930114015-3.png)

**ใช้ Aspose.Slides**

ที่นี่ เรานำสีลายเส้น [SmallGrid](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternstyle/#SmallGrid) ไปใช้กับข้อความและเพิ่มเส้นขอบสีดำความกว้าง 1 จุดโดยใช้โค้ดนี้:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```
ข้อความที่ได้:

![todo:image_alt_text](image-20200930114108-4.png)

## **ใช้เอฟเฟกต์ WordArt อื่น ๆ**

**ใช้ Microsoft PowerPoint**

จากอินเทอร์เฟซของโปรแกรม คุณสามารถใช้เอฟเฟกต์เหล่านี้กับข้อความ, ข้อความบล็อก, รูปร่าง หรือองค์ประกอบที่คล้ายกันได้:

![todo:image_alt_text](image-20200930114129-5.png)

ตัวอย่างเช่น เอฟเฟกต์เงา, การสะท้อน, และแสงวาบสามารถนำไปใช้กับข้อความ; เอฟเฟกต์รูปแบบ 3 มิติและการหมุน 3 มิติสามารถนำไปใช้กับข้อความบล็อก; คุณสมบัติขอบมน (Soft Edges) สามารถนำไปใช้กับวัตถุรูปทรง (ยังคงมีผลแม้ไม่ได้ตั้งค่า 3D Format).

### **ใช้เอฟเฟกต์เงา**

ที่นี่ เราตั้งค่าคุณสมบัติที่เกี่ยวกับข้อความเท่านั้น เรานำเอฟเฟกต์เงาไปใช้กับข้อความโดยใช้โค้ดนี้ :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

API ของ Aspose.Slides รองรับเงา 3 ประเภท: OuterShadow, InnerShadow, และ PresetShadow.

ด้วย PresetShadow คุณสามารถนำเงาไปใช้กับข้อความ (โดยใช้ค่าที่กำหนดไว้ล่วงหน้า).

**ใช้ Microsoft PowerPoint**

ใน PowerPoint คุณสามารถใช้เงาประเภทเดียว ตัวอย่างมีดังนี้:

![todo:image_alt_text](image-20200930114225-6.png)

**ใช้ Aspose.Slides**

Aspose.Slides จริง ๆ แล้วอนุญาตให้คุณใช้เงาสองประเภทพร้อมกัน: InnerShadow และ PresetShadow.

**หมายเหตุ:**

- เมื่อใช้ OuterShadow และ PresetShadow ร่วมกัน จะมีเพียงเอฟเฟกต์ OuterShadow เท่านั้นที่ถูกนำไปใช้.
- หากใช้ OuterShadow และ InnerShadow พร้อมกัน ผลลัพธ์หรือเอฟเฟกต์ที่ใช้จะขึ้นอยู่กับเวอร์ชันของ PowerPoint ตัวอย่างเช่น ใน PowerPoint 2013 เอฟเฟกต์จะถูกเพิ่มเป็นสองเท่า แต่ใน PowerPoint 2007 จะใช้เอฟเฟกต์ OuterShadow.

### **ใช้เอฟเฟกต์การสะท้อนกับข้อความ**

เราเพิ่มการแสดงผลให้ข้อความโดยใช้ตัวอย่างโค้ดนี้ :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **ใช้เอฟเฟกต์แสงวาบกับข้อความ**

เรานำเอฟเฟกต์แสงวาบไปใช้กับข้อความเพื่อทำให้มันสว่างหรือโดดเด่นโดยใช้โค้ดนี้:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);

```

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
คุณสามารถเปลี่ยนพารามิเตอร์สำหรับเงา, การแสดงผล, และแสงวาบได้ คุณสมบัติของเอฟเฟกต์จะถูกตั้งค่าต่างกันในแต่ละส่วนของข้อความ 
{{% /alert %}} 

### **ใช้การแปลงใน WordArt**

เราจะใช้คุณสมบัติ Transform (ซึ่งเป็นส่วนหนึ่งของบล็อกข้อความทั้งหมด) ผ่านโค้ดนี้:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```
ผลลัพธ์:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint และ Aspose.Slides for PHP via Java ทั้งสองให้ประเภทการแปลงที่กำหนดล่วงหน้าจำนวนหนึ่ง 
{{% /alert %}} 

**ใช้ PowerPoint**

เพื่อเข้าถึงประเภทการแปลงที่กำหนดล่วงหน้า ให้ไปที่: **Format** -> **TextEffect** -> **Transform**

**ใช้ Aspose.Slides**

เพื่อเลือกประเภทการแปลง ใช้ enum ชื่อ TextShapeType.

### **ใช้เอฟเฟกต์ 3D กับข้อความและรูปร่าง**

เราตั้งค่าเอฟเฟกต์ 3D ให้กับรูปร่างข้อความโดยใช้ตัวอย่างโค้ดนี้:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

ข้อความและรูปร่างที่ได้:

![todo:image_alt_text](image-20200930114816-9.png)

เรานำเอฟเฟกต์ 3D ไปใช้กับข้อความโดยใช้โค้ด PHP นี้:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

ผลลัพธ์ของการทำงาน:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
การนำเอฟเฟกต์ 3D ไปใช้กับข้อความหรือรูปร่างของมันและการโต้ตอบระหว่างเอฟเฟกต์ต่าง ๆ จะพิจารณาตามกฎบางประการ.

ให้พิจารณาฉาก (scene) สำหรับข้อความและรูปร่างที่บรรจุข้อความนั้น เอฟเฟกต์ 3D จะประกอบด้วยการแสดงวัตถุ 3D และฉากที่วัตถุถูกวางไว้.

- เมื่อฉากถูกตั้งค่าสำหรับรูปและข้อความพร้อมกัน ฉากของรูปจะมีความสำคัญสูงกว่า — ฉากของข้อความจะถูกละเลย.
- เมื่อรูปไม่มีฉากของตัวเองแต่มีการแสดงผล 3D จะใช้ฉากของข้อความ.
- ในกรณีอื่น — เมื่อรูปร่างเดิมไม่มีเอฟเฟกต์ 3D — รูปร่างจะเป็นแบนและเอฟเฟกต์ 3D จะถูกนำไปใช้เฉพาะกับข้อความ.

คำอธิบายเหล่านี้เกี่ยวข้องกับเมธอด ThreeDFormat.getLightRig() และ ThreeDFormat.getCamera().
{{% /alert %}} 

## **ใช้เอฟเฟกต์เงานอกกับข้อความ**
Aspose.Slides for PHP via Java มีคลาส [OuterShadow](https://reference.aspose.com/slides/th/php-java/aspose.slides/outershadow/) [InnerShadow](https://reference.aspose.com/slides/th/php-java/aspose.slides/innershadow/) ที่ให้คุณนำเอฟเฟกต์เงาไปใช้กับข้อความที่อยู่ใน [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/). ดำเนินตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้าไปยังสไลด์.
4. เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape.
5. ตั้งค่า FillType ของ AutoShape เป็น NoFill.
6. สร้างอินสแตนซ์ของคลาส OuterShadow
7. ตั้งค่า BlurRadius ของเงา.
8. ตั้งค่า Direction ของเงา
9. ตั้งค่า Distance ของเงา.
10. ตั้งค่า RectanglelAlign เป็น TopLeft.
11. ตั้งค่า PresetColor ของเงาเป็น Black.
12. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .

โค้ดตัวอย่างนี้ — การทำตามขั้นตอนข้างต้น — แสดงวิธีนำเอฟเฟกต์เงานอกไปใช้กับข้อความ:

```php
  $pres = new Presentation();
  try {
    # รับอ้างอิงของสไลด์
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # เพิ่ม TextFrame ไปยังสี่เหลี่ยมผืนผ้า
    $ashp->addTextFrame("Aspose TextBox");
    # ปิดการเติมสีของรูปร่างในกรณีที่ต้องการเงาของข้อความ
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # เพิ่มเงานอกและตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้เอฟเฟกต์เงาภายในกับรูปร่าง**
ดำเนินตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) .
2. รับอ้างอิงของสไลด์.
3. เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า.
4. เปิดใช้ InnerShadowEffect.
5. ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด.
6. ตั้งค่า ColorType เป็น Scheme.
7. ตั้งค่า Scheme Color.
8. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/) .

โค้ดตัวอย่างนี้ (ตามขั้นตอนข้างต้น) แสดงวิธีเพิ่มตัวเชื่อมต่อระหว่างรูปร่างสองรูป :

```php
  $pres = new Presentation();
  try {
    # รับอ้างอิงของสไลด์
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # เพิ่ม TextFrame ไปยังสี่เหลี่ยมผืนผ้า
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # เปิดใช้งาน InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # ตั้งค่าพารามิเตอร์ที่จำเป็นทั้งหมด
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # ตั้งค่า ColorType เป็น Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # ตั้งค่า Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # บันทึกการนำเสนอ
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับฟอนต์หรือสคริปต์ที่แตกต่างกัน (เช่น ภาษาอาหรับ, จีน) ได้หรือไม่?**

ใช่, Aspose.Slides รองรับ Unicode และทำงานกับฟอนต์และสคริปต์หลักทั้งหมด เอฟเฟกต์ WordArt เช่น เงา, การเติม, และเส้นขอบ สามารถใช้ได้กับทุกภาษา แม้ว่าความพร้อมของฟอนต์และการเรนเดอร์อาจขึ้นอยู่กับฟอนต์ของระบบ.

**ฉันสามารถใช้เอฟเฟกต์ WordArt กับองค์ประกอบของสไลด์มาสเตอร์ได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์ WordArt กับรูปร่างบนสไลด์มาสเตอร์ได้ รวมถึงตัวยึดตำแหน่งหัวเรื่อง, ส่วนท้าย, หรือข้อความพื้นหลัง การเปลี่ยนแปลงในเลย์เอาต์มาสเตอร์จะส่งผลต่อสไลด์ที่เชื่อมโยงทั้งหมด.

**เอฟเฟกต์ WordArt มีผลต่อขนาดไฟล์การนำเสนอหรือไม่?**

เล็กน้อย. เอฟเฟกต์ WordArt เช่น เงา, แสงวาบ, และการเติมแบบไล่สีอาจทำให้ขนาดไฟล์เพิ่มขึ้นเล็กน้อยเนื่องจากเมตาดาต้าการจัดรูปแบบที่เพิ่มเข้ามา แต่ความแตกต่างมักน้อยมาก.

**ฉันสามารถพรีวิวผลของเอฟเฟกต์ WordArt ได้โดยไม่ต้องบันทึกการนำเสนอหรือไม่?**

ได้, คุณสามารถเรนเดอร์สไลด์ที่มี WordArt ไปเป็นภาพ (เช่น PNG, JPEG) โดยใช้เมธอด `getImage` จากคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) หรือ [Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/) วิธีนี้ทำให้คุณพรีวิวผลได้ในหน่วยความจำหรือบนหน้าจอก่อนบันทึกหรือส่งออกการนำเสนอเต็มรูปแบบ.