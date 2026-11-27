---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย PHP
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/php-java/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรือง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะใช้ทำให้รูปทรงโดดเด่นได้ แต่พวกมันแตกต่างจาก [fills](/slides/th/php-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง, กระจายแสงเรืองของรูปทรง ฯลฯ

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายแบบกับรูปทรงหนึ่งรูป

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมผสานอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้ว่าดูดี ดังนั้นโดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่เหมาะ

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) ที่ทำให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for PHP via Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะห่าง และรัศมีเบลิร์เพื่อให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้บัตรหรือแผงเด่นขึ้นจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทรงลอยอยู่เหนือสไลด์ ปรับสี, ทิศทาง, ระยะห่าง และรัศมีเบลิร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยมผืนผ้า:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **ควบคุมทิศทางเงาเมื่อรูปทรงหมุน**

ตามค่าเริ่มต้น เงานอกจะหมุนตามรูปทรง เพื่อให้รูปทรงที่มีการหมุนต่างกันดูเหมือนได้รับแสงจากทิศทางเดียวกัน ให้เรียก [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) ด้วย `false` และใช้ [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) เพื่อกำหนดทิศทางเงาเดียวกัน

ตัวอย่างสร้างลูกศรสีน้ำเงินสองลูกที่มีเงาสีเทาเลื่อน 42 จุดไปทางขวา (0°) จากนั้นทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ในสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงด้านล่าง ขณะที่ลูกศรขวายังคงทำเงาไปทางขวา ทิศทางที่กำหนดยังคงเป็น 0° สำหรับเงาทั้งสอง

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อทำสำเนาการออกแบบของเทมเพลตให้ใช้เงาภายในเพื่อให้บัตรหรือแผงดูร่นลงไป ด้านในเงาภายในจะทำให้ขอบของรูปทรงมืดลง ในขณะที่เงานอกจะขยายออกนอกรูปทรงทำให้ดูเหมือนยกขึ้น

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) จากนั้นกำหนดค่าเงาที่ส่งกลับโดย [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลิร์ที่ใหญ่จะทำให้ขอบนุ่มขึ้น

ตัวอย่าง PHP นี้สร้างบัตรสีฟ้าอ่อนที่มีเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงา 225°, ระยะห่าง 7 จุด, รัศมีเบลิร์ 6 จุด:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) บนรูปทรงที่กำหนดรูปแบบเอฟเฟกต์

### **ใช้, เปลี่ยนแปลง, และลบ Preset Shadow**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) เพื่อเปิดใช้งาน Preset Shadow ใช้ [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) หรือสลับเป็นสไตล์อื่นบนรูปทรงเดียวกัน เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่าง PHP นี้ทำสำเนาสี่เหลี่ยมหลังจากแต่ละขั้นตอนสามแรกเพื่อให้คุณเปรียบเทียบสี่ขั้นตอนแบบข้างกันบนสไลด์เดียว ทั้งสองเงาเลื่อน 10 จุด ทิศทาง 225° ทำให้เงาแรกอยู่เหนือและซ้ายของสี่เหลี่ยม, 45° ทำให้เงาที่สองอยู่ล่างและขวา

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for PHP via Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรง ปรับพารามิเตอร์เช่น ระยะห่าง, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้กับงานนำเสนอของคุณโดยทำให้รูปทรงดูเรียบหรูและทันสมัย ใช้ง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สามารถใช้ได้เร็วบนหลายองค์ประกอบเพื่อการออกแบบที่สม่ำเสมอ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Reflection effect](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรือง**

เพื่อใช้เอฟเฟกต์แสงเรืองกับรูปทรงใน Aspose.Slides for PHP via Java คุณสามารถเพิ่มออร่ารอบรูปทรงที่อ่อนนุ่มและสว่างไสว ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดตาให้กับการนำเสนอของคุณ ใช้ง่ายด้วยโค้ดขั้นต่ำ ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟกต์แสงเรือง](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Glow effect](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบอ่อน**

เพื่อใช้เอฟเฟกต์ขอบอ่อนใน Aspose.Slides for PHP via Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอร์รอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะสำหรับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟกต์ขอบอ่อน](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้เบลอรูปทรงเพื่อทำให้สีเติมและเส้นขอบของรูปทรงนุ่มขึ้นในขณะเดียวกันยังคงรูปทรงเป็นแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) บนรูปทรงที่กำหนดรูปแบบเอฟเฟกต์ รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะให้เบลอแรงขึ้น รัศมีศูนย์จะไม่มีการเปลี่ยนแปลงลักษณะ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ควบคุมขอบที่มองเห็นได้ของเอฟเฟกต์ เมื่อ `false` เบลอจะถูกตัดให้เหลือในขอบที่ทาดั้งเดิมรวมถึงเส้นขอบ เมื่อ `true` เบลออาจขยายออกนอกขอบเหล่านั้น ทั้งสองการตั้งค่าไม่ได้เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบ, และขนาดรูปทรงเดียวกันทั้งหมด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

ตัวอย่าง PHP นี้สร้างสี่เหลี่ยมสีส้มที่มีเส้นขอบสีฟ้าเข้ม ใช้เบลอ 5 จุด จากนั้นอัปเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสภาพที่เบลอทั้งสอง จากนั้นเรียก [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มีเบลอ

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเบลอรูปทรงส่งผลต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบอ่อนทำให้ขอบรูปทรงจางลง ในขณะที่เบลอเงาแค่เงาเท่านั้น เอฟเฟกต์การแปลงรูปภาพทำงานบนเนื้อหารูปภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงบนรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมผสานเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และแสงเรือง บนรูปทรงเดียวเพื่อสร้างรูปลักษณ์ที่มีพลวัตมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึงออโต้เชป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE, และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด