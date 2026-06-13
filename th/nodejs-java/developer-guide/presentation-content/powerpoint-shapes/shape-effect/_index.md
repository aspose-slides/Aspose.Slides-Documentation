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
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ JavaScript และ Aspose.Slides สำหรับ Node.js—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างโดดเด่นได้ แต่ต่างจาก [fills](/slides/th/nodejs-java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง กระจายแสงเรืองแสงของรูปร่าง ฯลฯ

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างหนึ่งรูปได้  

* การผสมผสานเอฟเฟกต์บางแบบดูดีขึ้นกว่าบางแบบ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset นั้นเป็นการผสมผสานที่ดูดีแล้วของสองหรือมากกว่าเอฟเฟกต์ ดังนั้น การเลือก Preset จะช่วยให้คุณไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมผสานที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/EffectFormat) ที่อนุญาตให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

โค้ด JavaScript นี้แสดงวิธีการใช้เอฟเฟกต์เงานอก ([getOuterShadowEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) กับสี่เหลี่ยมผืนผ้า:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด JavaScript นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปร่าง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ใช้เอฟเฟกต์เรืองแสง**

โค้ด JavaScript นี้แสดงวิธีการใช้เอฟเฟกต์เรืองแสงกับรูปร่าง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ใช้เอฟเฟกต์ขอบนุ่ม**

โค้ด JavaScript นี้แสดงวิธีการใช้ขอบนุ่มกับรูปร่าง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**สามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมผสานเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และเรืองแสงบนรูปร่างเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**สามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงออทชาพณ์, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**สามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับกลุ่มรูปร่างได้ เอฟเฟกต์จะถูกนำไปใช้กับทั้งกลุ่มโดยรวม.