---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอบน Android
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/androidjava/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปทรงโดดเด่นได้ แต่พวกมันจะแตกต่างจาก [การเติม](/slides/th/androidjava/shape-formatting/#gradient-fill) หรือ outlines. โดยใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงเรืองรอบรูปทรง ฯลฯ

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้. 

* การผสมเอฟเฟกต์บางอย่างดูดีกว่าอื่น ๆ ด้วยเหตุนี้ ตัวเลือกของ PowerPoint ภายใต้ **Preset** ตัวเลือก Preset นั้นโดยพื้นฐานคือการผสมที่ดูดีของสองหรือมากกว่าหนึ่งเอฟเฟกต์ ด้วยวิธีนี้ การเลือก Preset จะทำให้คุณไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมที่ดี.

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectFormat) ที่อนุญาตให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint.

## **ใช้เอฟเฟกต์เงา**

โค้ด Java นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์เงานอก ([OuterShadowEffect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) กับสี่เหลี่ยมผืนผ้า:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้เอฟเฟกต์การสะท้อน**

โค้ด Java นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปทรง:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้เอฟเฟกต์เรืองแสง**

โค้ด Java นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์เรืองแสงกับรูปทรง:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้เอฟเฟกต์ขอบนุ่ม**

โค้ด Java นี้แสดงให้คุณเห็นวิธีการใช้ขอบนุ่มกับรูปทรง:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ใช่ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และเรืองแสงบนรูปทรงเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงอะไรได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลาย รวมถึง autoshapes, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.