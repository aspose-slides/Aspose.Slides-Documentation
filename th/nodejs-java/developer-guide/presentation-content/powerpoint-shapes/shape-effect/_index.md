---
title: ประยุกต์ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย JavaScript
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/nodejs-java/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ JavaScript และ Aspose.Slides สำหรับ Node.js—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างเด่นขึ้น พวกมันต่างจาก [การเติม](/slides/th/nodejs-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงออร่าของรูปร่าง ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมของเอฟเฟกต์ดูดีขึ้นกว่าการผสมอื่น ๆ ด้วยเหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมของสองหรือมากกว่าเอฟเฟกต์ที่รู้ว่าดูดี ด้วยวิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Node.js via Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับแต่งสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือพาเนลเด่นขึ้นเหนือพื้นหลังของสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง สร้างความรู้สึกว่ารูปร่างลอยขึ้นเหนือสไลด์ ปรับสี ทิศทาง ระยะทาง และรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

This JavaScript code shows how to apply the [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) to a rectangle:

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

### **ใช้เงาภายใน**

เมื่อทำซ้ำสไตล์การออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือพาเนลดูดิ่งลง เงานอกขยายออกนอกรูปร่างและทำให้ดูลอยขึ้น ในขณะที่เงาภายในทำให้ขอบด้านในของรูปร่างดูมืดลง

Call [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), then configure the shadow returned by [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Larger blur radius values produce softer edges.

This JavaScript example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file. The shadow direction is 225 degrees, its distance is 7 points, and its blur radius is 6 points:

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

![สี่เหลี่ยมสีน้ำเงินอ่อนกับเงาภายใน](inner_shadow_effect.png)

To remove the inner shadow, call [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) on the shape's effect format.

### **ใช้, เปลี่ยนและลบเงา Preset**

Call [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) and use [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) to select a [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/). To switch styles, change the preset on the same shape. Call [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) to remove the shadow while preserving the fill and outline.

This example shows four stages side by side on one slide. Both shadows are offset by 10 points. A direction of 225° places the first shadow above and to the left of the rectangle, and 45° places the second below and to the right.

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

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกซ้ายบน](preset_shadow_top_left.png) | ![เงาตกขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปร่าง ปรับพารามิเตอร์เช่น ระยะทาง ความโปร่งแสง และขนาด เอฟเฟกต์นี้ช่วยยกระดับความสวยงามของงานนำเสนอโดยทำให้รูปร่างดูขัดเกลาและเป็นมืออาชีพยิ่งขึ้น ใช้งานง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อให้การออกแบบสอดคล้องกัน

This JavaScript code shows how to apply the [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) to a shape:

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

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปร่างใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มออร่าที่นุ่มนวลรอบรูปร่าง ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้สไลด์ดูสวยงามยิ่งขึ้น

This JavaScript code shows how to apply the [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) to a shape:

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

![เอฟเฟกต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Node.js via Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปร่าง เอฟเฟกต์นี้ให้ลุคที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะกับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ตามต้องการในรูปร่างต่าง ๆ ของงานนำเสนอ

This JavaScript code shows how to apply the [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) to a shape:

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

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอ**

ใช้การเบลอรูปร่างเพื่อทำให้สีเติมและเส้นขอบของรูปร่างดูนุ่มนวลขณะยังคงให้รูปทรงสามารถแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ ค่าระดับใหญ่ให้ผลเบลอแรงกว่า รัศมีศูนย์จะคงลักษณะเดิมไว้

การตั้งค่า [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อเป็น `false` การเบลอจะถูกคลิปตามขอบเขตที่วาดเดิมรวมถึงเส้นขอบ เมื่อเป็น `true` การเบลอสามารถขยายเกินขอบเขตนั้นได้ การตั้งค่าใด ๆ ก็ไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้สีเติม เส้นขอบ และขนาดรูปร่างเดียวกันทั้งหมด แถวบนใช้ `grow = false` แถวล่างใช้ `grow = true`

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด โดยมีการเปิด/ปิดการขยาย](shape_blur_comparison.png)

This JavaScript example creates an orange rectangle with a dark blue outline, applies a 5-point blur, and then updates it to a 15-point blur by calling [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) again. It saves both blurred states, then calls [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) and saves the shape without blur.

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

การเบลอรูปร่างส่งผลต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบของรูปร่างจางลง ในขณะที่การเบลอเงาจะทำให้เงาเพียงอย่างเดียวนุ่มนวล เอฟเฟกต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอโดยตรงบนรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างใดบ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลายประเภท รวมถึง autoshapes, charts, tables, pictures, SmartArt objects, OLE objects และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรัพย์ที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรัพย์ที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด