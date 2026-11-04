---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย JavaScript
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
  - การนำเสนอ
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ JavaScript และ Aspose.Slides สำหรับ Node.js—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในเวลาเพียงไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถทำให้รูปทรงโดดเด่นได้ แต่มันจะแตกต่างจาก [การเติม](/slides/th/nodejs-java/shape-formatting/#gradient-fill) หรือโครงร่าง การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง เพิ่มความสว่างของรูปทรง ฯลฯ

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานของสองหรือมากกว่เอฟเฟกต์ที่ทราบว่าดูดี ด้วยวิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) ที่ให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Node.js via Java รองรับเงานอกและเงาในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ของเงาให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นชัดจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง สร้างความรู้สึกว่ารูปทรงยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ของเงาให้ตรงกับแสงและสไตล์ของแม่แบบของคุณ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) กับสี่เหลี่ยม:

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

### **ใช้เงาใน**

เมื่อทำสำเนาสไตล์ภาพของแม่แบบ ให้ใช้เงาในเพื่อให้การ์ดหรือแผงดูเหมือนคั่นลงไป เงานอกขยายออกนอกรูปทรงทำให้ดูยกขึ้น ในขณะที่เงาในจะทำให้ด้านในของขอบเงามืดลง

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect) จากนั้นกำหนดค่าเงาที่คืนจาก [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง JavaScript นี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงาคือ 225 องศา ระยะห่างคือ 7 จุด และรัศมีเบลอร์คือ 6 จุด:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาใน](inner_shadow_effect.png)

เพื่อเอาเงาในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) บน EffectFormat ของรูปทรง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามของงานนำเสนอของคุณโดยทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพง่ายต่อการใช้งานด้วยโค้ดที่ง่ายทำให้สามารถนำไปใช้กับหลายองค์ประกอบอย่างรวดเร็วเพื่อการออกแบบที่สม่ำเสมอ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) กับรูปทรง:

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

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปทรงใน Aspose.Slides for Node.js via Java คุณสามารถเพิ่มออร่านุ่มนวลและเปล่งแสงรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ง่ายต่อการใช้งานด้วยโค้ดขั้นต่ำช่วยปรับปรุงรูปลักษณ์โดยรวมของสไลด์ของคุณ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) กับรูปทรง:

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

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Node.js via Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะกับการออกแบบที่ต้องการลุคอ่อนโยนและนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมี ได้อย่างง่ายดายเพื่อให้ได้เอฟเฟกต์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ

โค้ด JavaScript นี้แสดงวิธีการใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) กับรูปทรง:

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

ใช้การเบลอรูปทรงเพื่อทำให้สีเติมและโครงร่างของรูปทรงนุ่มขึ้นในขณะเดียวกันยังคงให้รูปทรงแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) บน EffectFormat ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนรูปลักษณ์

การตั้งค่า [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อใช้ `false` เบลอจะถูกตัดให้อยู่ภายในขอบเขตที่วาดเดิมรวมถึงโครงร่าง เมื่อใช้ `true` เบลอสามารถขยายนอกขอบเขตเหล่านั้น การตั้งค่าใด ๆ ไม่ทำให้ตำแหน่งหรือขนาดของรูปทรงเปลี่ยนแปลง

การเปรียบเทียบด้านล่างใช้สีเติม, โครงร่างและขนาดรูปทรงเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อมการปิดและเปิด grow](shape_blur_comparison.png)

ตัวอย่าง JavaScript นี้สร้างสี่เหลี่ยมสีส้มที่มีโครงร่างสีน้ำเงินเข้ม ใช้เบลอ 5 จุด แล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) อีกครั้ง บันทึกสถานะเบลอทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) และบันทึกรูปทรงโดยไม่มีเบลอ

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

การเบลอรูปทรงส่งผลต่อสีเติมและโครงร่างพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบของรูปทรงจางหายไปขณะที่การเบลอเงานั้นทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงกับ EffectFormat ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมผสานเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และเรืองแสง บนรูปทรงเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึงออโต้เชป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับกลุ่มรูปทรงได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปทรงได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด