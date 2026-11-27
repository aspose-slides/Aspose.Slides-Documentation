---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย JavaScript
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/nodejs-java/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรือง
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ JavaScript และ Aspose.Slides สำหรับ Node.js—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [การเติม](/slides/th/nodejs-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่ดูสมจริงบนรูปร่าง แพร่กระจายแสงเรืองของรูปร่าง ฯลฯ

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่ทราบว่าดูดี วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดลองหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Node.js via Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับสี ทิศทาง ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นขึ้นจากพื้นหลังของสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง สร้างความรู้สึกว่ารูปร่างลอยขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทางและรัศมีเบลอร์ให้ตรงกับการจัดแสงและสไตล์ของเทมเพลตของคุณ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยมผืนผ้า:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางเงาเมื่อรูปร่างหมุน**

โดยค่าเริ่มต้น เงานอกจะหมุนตามรูปร่าง เพื่อให้รูปร่างที่หันต่างกันดูเหมือนถูกส่องแสงจากทิศทางเดียวกัน ให้เรียก [setRotateShadowWithShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setRotateShadowWithShape) ด้วยค่า `false` แล้วใช้ [setDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/outershadow/#setDirection) เพื่อกำหนดทิศทางเดียวกันให้กับเงา

ตัวอย่างสร้างลูกศรสีน้ำเงินสองลูกพร้อมเงาสีเทาที่เลื่อน 42 จุดไปทางขวา (0°) จากนั้นทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const before = presentation.getSlides().get_Item(0);
    
    const left = before.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    left.getFillFormat().getSolidFillColor().setColor(fillColor);
    left.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    left.getEffectFormat().enableOuterShadowEffect();
    const shadow = left.getEffectFormat().getOuterShadowEffect();
    const shadowColor = java.getStaticFieldValue("java.awt.Color", "GRAY");
    shadow.getShadowColor().setColor(shadowColor);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    const right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    const after = presentation.getSlides().addClone(before);
    const arrows = after.getShapes();
    for (let i = 0; i < arrows.size(); i++) {
        arrows.get_Item(i).setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

บนสไลด์ที่สอง ลูกศรด้านซ้ายทำเงาตกลงด้านล่าง ในขณะที่ลูกศรด้านขวายังคงทำเงาไปทางขวา ทิศทางที่กำหนดยังคงเป็น 0° สำหรับเงาทั้งสอง

![การเรนเดอร์ PowerPoint ก่อนและหลังการหมุน 90° ทั้งสองเงาเริ่มจากด้านขวา หลังจากหมุน เงาจะย้ายไปด้านล่างของลูกศรซ้ายและคงอยู่ทางขวาของลูกศรขวา](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อทำตามสไตล์การออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถูกฝังลงไป เงานอกจะขยายออกนอกรูปร่างทำให้ดูยกขึ้น ในขณะที่เงาภายในจะทำให้ขอบภายในของรูปร่างมืดลง

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) แล้วกำหนดค่าเงาที่ได้จาก [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่าเบลอร์ที่ใหญ่ขึ้นจะให้ขอบที่นุ่มนวลกว่า

ตัวอย่าง JavaScript นี้สร้างการ์ดสีฟ้าอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงาคือ 225 องศา ระยะทาง 7 จุด และรัศมีเบลอร์ 6 จุด:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) บนรูปแบบเอฟเฟกต์ของรูปร่าง

### **ใช้ เปลี่ยน และลบ Preset Shadow**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) แล้วใช้ [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/) หากต้องการสลับสไตล์ ให้เปลี่ยน Preset บนรูปร่างเดียวกัน แล้วเรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนเคียงข้างบนสไลด์เดียว ทั้งสองเงาเลื่อน 10 จุด ทิศทาง 225° จะทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม และ 45° จะทำให้เงาที่สองอยู่ด้านล่างขวา

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| ดั้งเดิม | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาลดลงซ้ายบน](preset_shadow_top_left.png) | ![เงาลดลงขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่างโดยปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งใส และขนาด เอฟเฟกต์นี้ช่วยเสริมความสวยงามของงานนำเสนอโดยให้รูปร่างดูเป็นมืออาชีพและหรูหรามากขึ้น ใช้ง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้อง

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปร่าง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์แสงเรือง**

เพื่อใช้เอฟเฟกต์แสงเรืองกับรูปร่างใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มออร่าอ่อน ๆ ที่ส่องแสงรอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปร่างโดดเด่นและเพิ่มความน่าสนใจให้กับการนำเสนอของคุณ ใช้ง่ายด้วยโค้ดสั้น ๆ ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์แสงเรือง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) กับรูปร่าง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์แสงเรือง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบอ่อน**

เพื่อใช้เอฟเฟกต์ขอบอ่อนใน Aspose.Slides for Node.js via Java คุณสามารถสร้างการไล่สีที่นุ่มนวลและพร่ามัวรอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มความรู้สึกที่ละเอียดอ่อนและเรียบหรู เหมาะสำหรับการออกแบบที่ต้องการลักษณะอ่อนนุ่ม คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์ขอบอ่อน](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปร่าง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์ขอบอ่อน](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอร์**

ใช้เบลอร์บนรูปร่างเพื่อทำให้การเติมและเส้นขอบของรูปร่างดูนุ่มนวลลงในขณะที่ยังคงให้แก้ไขรูปร่างได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ ค่าที่ใหญ่กว่าจะทำให้เบลอร์แรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อ `false` เบลอร์จะถูกตัดให้พอดีกับขอบที่ทานสีเดิมรวมถึงเส้นขอบ เมื่อ `true` เบลอร์สามารถขยายออกนอกขอบเหล่านั้นได้ ทั้งสองค่าจะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้การเติม เส้นขอบ และขนาดรูปร่างเดียวกันทั้งหมด แถวบนใช้ `grow = false` แถวล่างใช้ `grow = true`

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีเบลอร์ 5 และ 15 จุด โดยมี grow ปิดและเปิดใช้งาน](shape_blur_comparison.png)

ตัวอย่าง JavaScript นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้เบลอร์ 5 จุด แล้วอัปเดตเป็นเบลอร์ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกทั้งสองสถานะที่เบลอร์แล้วจึงเรียก [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปร่างโดยไม่มีเบลอร์

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เบลอร์บนรูปร่างกระทบต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบอ่อนทำให้ขอบของรูปร่างจางหาย ไปในขณะที่เบลอร์ของเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอร์โดยตรงบนรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และแสงเรือง บนรูปร่างเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปแบบต่าง ๆ เช่น รูปร่างอัตโนมัติ แผนภูมิ ตาราง รูปภาพ วัตถุ SmartArt วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด**