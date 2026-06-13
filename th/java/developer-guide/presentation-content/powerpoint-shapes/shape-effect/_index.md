---
title: ใช้เอฟเฟกต์รูปทรงในงานนำเสนอด้วย Java
linktitle: เอฟเฟกต์รูปทรง
type: docs
weight: 30
url: /th/java/shape-effect/
keywords:
- เอฟเฟกต์รูปทรง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์แสงเรืองรอบ
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Java—สร้างสไลด์ที่น่าประทับใจและมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปทรงโดดเด่น แต่เอฟเฟกต์จะแตกต่างจาก [การเติม](/slides/th/java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่เชื่อถือได้บนรูปทรง แพร่กระจายแสงเรืองรอบรูปทรง ฯลฯ

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint มีเอฟเฟกต์ทั้งหมดหกประเภทที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้เอฟเฟกต์หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูป

* การผสมผสานเอฟเฟกต์บางแบบดูดีขึ้นกว่าตัวอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset โดยพื้นฐานแล้วคือการผสมผสานที่ดูดีของสองหรือมากกว่าเอฟเฟกต์ วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือรวมเอฟเฟกต์ต่าง ๆ เพื่อหาแบบที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายในคลาส [EffectFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectFormat) ที่ให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในไฟล์งานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์เงานอก ([OuterShadowEffect](https://reference.aspose.com/slides/th/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) กับสี่เหลี่ยมผืนผ้า:

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

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์การสะท้อนกับรูปทรง:

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

## **ใช้เอฟเฟกต์แสงเรืองรอบ**

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์แสงเรืองรอบกับรูปทรง:

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

โค้ด Java นี้แสดงวิธีการใช้ขอบนุ่มกับรูปทรง:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์หลาย ๆ อย่างกับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา การสะท้อน และแสงเรืองรอบ บนรูปทรงเดียวเพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงต่าง ๆ รวมถึงอัตรูป (autoshapes) แผนภูมิ ตาราง รูปภาพ วัตถุ SmartArt วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด