---
title: ใช้เอฟเฟ็กต์รูปทรงในงานนำเสนอด้วย PHP
linktitle: เอฟเฟ็กต์รูปทรง
type: docs
weight: 30
url: /th/php-java/shape-effect/
keywords:
- เอฟเฟ็กต์รูปทรง
- เอฟเฟ็กต์เงา
- เอฟเฟ็กต์การสะท้อน
- เอฟเฟ็กต์การเรืองแสง
- เอฟเฟ็กต์ขอบนุ่ม
- รูปแบบเอฟเฟ็กต์
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟ็กต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟ็กต์ใน PowerPoint สามารถใช้ทำให้รูปทรงเด่นขึ้นได้ พวกมันจะแตกต่างจาก [การเติม](/slides/th/php-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟ็กต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อบนรูปทรง กระจายแสงเรืองรัศมีของรูปทรง ฯลฯ

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟ็กต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟ็กต์กับรูปทรงหนึ่งรูป

บางการผสมของเอฟเฟ็กต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมของสองหรือมากกว่าที่รู้ว่าดูดี วิธีนี้การเลือก Preset จะทำให้คุณไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟ็กต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) ที่ทำให้คุณสามารถใช้เอฟเฟ็กต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟ็กต์เงา**

Aspose.Slides สำหรับ PHP ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี ทิศทาง ระยะทาง และรัศมีเบลอร์เพื่อให้เข้ากับการออกแบบของงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นเมื่อเทียบกับพื้นหลังของสไลด์ เงาจะขยายออกนอกขอบของรูปทรง สร้างความรู้สึกว่ารูปทรงยกขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของแม่แบบของคุณ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟ็กต์เงานอก](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยม:

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

### **ใช้เงาภายใน**

เมื่อต้องทำสำเนาการออกแบบกราฟิกของแม่แบบ ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถมขึ้น เงานอกจะขยายออกนอกรูปทรงและทำให้ดูยกขึ้น ในขณะที่เงาภายในทำให้ด้านในของขอบมีเงา

เรียกใช้ [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) แล้วกำหนดค่าเงาที่คืนมาจาก [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลอร์ที่ใหญ่กว่าให้ขอบที่นุ่มนวลขึ้น

ตัวอย่าง PHP นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาดำและบันทึกเป็นไฟล์ PPTX ทิศทางของเงาคือ 225 องศา ระยะห่าง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

เพื่อลบเงาภายใน ให้เรียกใช้ [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) บนฟอร์แมตเอฟเฟ็กต์ของรูปทรง

### **ใช้, เปลี่ยนและลบ Preset Shadow**

เรียกใช้ [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) เพื่อเปิดใช้งาน Preset Shadow ใช้ [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) หรือสลับไปยังสไตล์อื่นบนรูปทรงเดียวกัน เรียกใช้ [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่าง PHP นี้ทำสำเนาสี่เหลี่ยมหลังจากแต่ละขั้นตอนในสามขั้นแรกเพื่อให้คุณเปรียบเทียบสี่ขั้นตอนทั้งหมดเคียงข้างกันบนสไลด์เดียว เงาทั้งสองถูกย้ายตำแหน่งด้วยระยะ 10 จุด ทิศทาง 225° จะวางเงาแรกเหนือและซ้ายของสี่เหลี่ยม และ 45° จะวางเงาที่สองใต้และขวา

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

## **ใช้เอฟเฟ็กต์การสะท้อน**

ในการใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งแสง และขนาด เอฟเฟ็กต์นี้ช่วยยกระดับความสวยงามของงานนำเสนอของคุณโดยทำให้รูปทรงดูเรียบหรูและทันสมัย ง่ายต่อการทำด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สอดคล้องกัน

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

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

## **ใช้เอฟเฟ็กต์การเรืองแสง**

ในการใช้เอฟเฟ็กต์การเรืองแสงกับรูปทรงใน Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถเพิ่มแสงออร่าที่นุ่มนวลรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่น่าสนใจให้กับงานนำเสนอของคุณ ง่ายต่อการทำด้วยโค้ดจำนวนน้อย ช่วยปรับปรุงภาพรวมของสไลด์ของคุณ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟ็กต์การเรืองแสง](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

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

## **ใช้เอฟเฟ็กต์ขอบนุ่ม**

ในการใช้เอฟเฟ็กต์ขอบนุ่มใน Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟ็กต์นี้เพิ่มลุคที่ละเอียดอ่อนและหรูหรา เหมาะกับการออกแบบที่ต้องการรูปลักษณ์อ่อนนุ่ม คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้เอฟเฟ็กต์ที่ต้องการบนรูปทรงหลากหลายในงานนำเสนอของคุณ

โค้ด PHP นี้แสดงวิธีใช้ [เอฟเฟ็กต์ขอบนุ่ม](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

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

## **ใช้เอฟเฟ็กต์เบลอ**

ใช้ Blur ของรูปทรงเพื่อทำให้การเติมและเส้นขอบของรูปทรงนุ่มนวลขึ้นพร้อมยังคงให้รูปทรงแก้ไขได้ เรียกใช้ [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) บนฟอร์แมตเอฟเฟ็กต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่ามากกว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะแสดงผลเหมือนเดิม

การตั้งค่า [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟ็กต์ เมื่อ `false` เบลอร์จะถูกคลิปให้อยู่ในขอบเขตที่วาดเดิมรวมถึงเส้นขอบ เมื่อ `true` เบลอร์สามารถขยายออกนอกขอบเขตนั้นได้ การตั้งค่าใดๆ จะไม่เปลี่ยนตำแหน่งหรือมิติของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติม เส้นขอบ และขนาดรูปทรงเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

ตัวอย่าง PHP นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้ Blur 5 จุดแล้วอัปเดตเป็น Blur 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง จะบันทึกสถานะ Blur ทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มี Blur

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

Blur ของรูปทรงจะส่งผลต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟ็กต์ขอบนุ่มจะทำให้ขอบของรูปทรงจางลงในขณะที่ Blur ของเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟ็กต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้ Blur โดยตรงกับฟอร์แมตเอฟเฟ็กต์ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟ็กต์กับรูปทรงเดียวกันได้หรือไม่?**

ใช่ คุณสามารถรวมเอฟเฟ็กต์ต่าง ๆ เช่น เงา การสะท้อน และการเรืองแสง บนรูปทรงเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงอะไรได้บ้าง?**

คุณสามารถใช้เอฟเฟ็กต์กับรูปทรงต่าง ๆ รวมถึงออโตช์เอป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ใช่ คุณสามารถใช้เอฟเฟ็กต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟ็กต์จะถูกนำไปใช้กับทั้งกลุ่ม