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
- เอฟเฟ็กต์เรืองแสง
- เอฟเฟ็กต์ขอบอ่อน
- รูปแบบเอฟเฟ็กต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟ็กต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides for PHP ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **แนะนำ**

แม้ว่าเอฟเฟ็กต์ใน PowerPoint จะสามารถใช้ทำให้รูปทรงโดดเด่นได้ แต่พวกมันแตกต่างจาก [การเติมสี](/slides/th/php-java/shape-formatting/#gradient-fill) หรือขอบเส้น. การใช้เอฟเฟ็กต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่ดูสมจริงบนรูปทรง, กระจายแสงอำพรางของรูปทรง ฯลฯ

![เอฟเฟ็กต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟ็กต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟ็กต์กับรูปทรงหนึ่งรูปได้.

บางการผสมผสานของเอฟเฟ็กต์ดูดีกว่าการผสมผสานอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าเอฟเฟ็กต์ที่ทราบว่าดูดี วิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟ็กต์ต่าง ๆ เพื่อหาแบบผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟ็กต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟ็กต์เงา**

Aspose.Slides for PHP ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถกำหนดสี, ทิศทาง, ระยะห่างและรัศมีการเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นเหนือพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทรงยกขึ้นจากสไลด์ ปรับสี, ทิศทาง, ระยะห่างและรัศมีการเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด PHP นี้แสดงวิธีการใช้ [เอฟเฟ็กต์เงานอก](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยม:

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

![เอฟเฟ็กต์เงา](shadow_effect.png)

### **ใช้เงาภายใน**

เมื่อทำสำเนาสไตล์การออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อทำให้การ์ดหรือแผงดูมีลักษณะห้อยลง เงานอกขยายออกนอกรูปทรงทำให้ดูเป็นยกขึ้น ส่วนเงาภายในจะสร้างความเงาให้กับด้านในของขอบ

เรียกใช้ [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) จากนั้นกำหนดค่าของเงาที่คืนค่ามาจาก [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีการเบลอร์ที่ใหญ่กว่าให้ขอบที่นุ่มขึ้น

ตัวอย่าง PHP นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาดำและบันทึกเป็นไฟล์ PPTX ทิศทางเงาคือ 225 องศา ระยะห่าง 7 จุด และรัศมีการเบลอร์ 6 จุด:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

หากต้องการลบเงาภายใน ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) บน EffectFormat ของรูปทรง

## **ใช้เอฟเฟ็กต์การสะท้อน**

เพื่อใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides for PHP ผ่าน Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะห่าง, ความโปร่งแสง และขนาด เอฟเฟ็กต์นี้ช่วยเพิ่มความสวยงามของงานนำเสนอโดยทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพ การทำงานง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถใช้ได้อย่างรวดเร็วกับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด PHP นี้แสดงวิธีการใช้ [เอฟเฟ็กต์การสะท้อน](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

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

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟ็กต์เรืองแสง**

เพื่อใช้เอฟเฟ็กต์เรืองแสงกับรูปทรงใน Aspose.Slides for PHP ผ่าน Java คุณสามารถเพิ่มออร่าที่อ่อนโยนและสว่างไสวรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดตาในงานนำเสนอของคุณ การทำงานง่ายด้วยโค้ดเพียงเล็กน้อยช่วยยกระดับลุคโดยรวมของสไลด์ของคุณ

โค้ด PHP นี้แสดงวิธีการใช้ [เอฟเฟ็กต์เรืองแสง](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

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

![เอฟเฟ็กต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟ็กต์ขอบอ่อน**

เพื่อใช้เอฟเฟ็กต์ขอบอ่อนใน Aspose.Slides for PHP ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงราบรื่นและเบลอร์รอบขอบของรูปทรง เอฟเฟ็กต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะสำหรับการออกแบบที่ต้องการลุคอ่อนโยนและเนียนนุ่ม คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้เอฟเฟ็กต์ที่ต้องการกับรูปทรงหลายรูปในงานนำเสนอของคุณได้ง่าย

โค้ด PHP นี้แสดงวิธีการใช้ [เอฟเฟ็กต์ขอบอ่อน](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

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

![เอฟเฟ็กต์ขอบอ่อน](soft_edges_effect.png)

## **ใช้เอฟเฟ็กต์เบลอ**

ใช้ Blur รูปทรงเพื่อทำให้สีเติมและเส้นขอบของรูปทรงนุ่มขึ้นพร้อมยังคงให้แก้ไขรูปทรงได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) บน EffectFormat ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใดๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟ็กต์ เมื่อใช้ `false` เบลอร์จะถูกตัดตามขอบเขตที่วาดเดิมรวมถึงเส้นขอบ เมื่อใช้ `true` เบลอร์สามารถขยายออกนอกขอบเขตเหล่านั้น การตั้งค่าใด ๆ ก็ไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบและขนาดรูปทรงเดียวกัน ตลอดทั้งสองแถว แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีการเบลอร์ 5 และ 15 จุด พร้อม grow ปิดและเปิด](shape_blur_comparison.png)

ตัวอย่าง PHP นี้สร้างสี่เหลี่ยมส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้เบลอร์ 5 จุด แล้วอัปเดตเป็นเบลอร์ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสถานะที่เบลอทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มีเบลอร์

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

การเบลอร์รูปทรงทำให้สีเติมและเส้นขอบเปลี่ยนแปลงพร้อมกัน เอฟเฟ็กต์ขอบอ่อนจะทำให้ขอบรูปทรงจางหายไป ในขณะที่เบลอร์เงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟ็กต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอร์โดยตรงกับ EffectFormat ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟ็กต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมเอฟเฟ็กต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสงบนรูปทรงเดียวเพื่อสร้างลุคที่มีความไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟ็กต์กับรูปทรงหลายประเภท ได้แก่ autoshapes, ชาร์ต, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟ็กต์กับกลุ่มรูปทรงได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟ็กต์กับกลุ่มรูปทรงได้ เอฟเฟ็กต์จะถูกนำไปใช้กับกลุ่มทั้งหมด