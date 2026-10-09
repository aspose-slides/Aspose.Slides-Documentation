---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอด้วย Java
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/java/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides for Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในเวลาไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างเด่นขึ้นได้ แต่พวกมันจะแตกต่างจาก [การเติม](/slides/th/java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่น่าตื่นตาตื่นใจบนรูปร่าง กระจายแสงส่องของรูปร่าง ฯลฯ

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกประเภทที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างหนึ่งรูปได้

การผสมผสานเอฟเฟกต์บางแบบดูดีกว่าแบบอื่น ๆ เพื่อนำไปใช้ได้อย่างรวดเร็ว PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือหลายเอฟเฟกต์ที่ทราบว่าดูดี ด้วยวิธีนี้ การเลือก Preset จะทำให้คุณไม่ต้องเสียเวลาเสียเปรียบในการทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อค้นหาการผสมผสานที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถกำหนดสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ของเงาให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อให้การ์ดหรือพาเนลเด่นเหนือพื้นหลังสไลด์ เงานี้ขยายออกนอกขอบของรูปร่าง สร้างความรู้สึกว่ารูปร่างยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของแม่แบบของคุณ

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **ใช้เงาภายใน**

เมื่อทำสำเนาการสไตล์ภาพของแม่แบบ ให้ใช้เงาภายในเพื่อให้การ์ดหรือพาเนลดูเหมือนถูกกดลงไป เงานอกขยายออกนอกรูปร่างทำให้ดูยกขึ้น ส่วนเงาภายในทำให้ขอบด้านในมืดลง

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่คืนค่าจาก [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). ค่ารัศมีเบลอร์ที่ใหญ่ขึ้นทำให้ขอบนุ่มขึ้น

ตัวอย่าง Java นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX เงามีทิศทาง 225 องศา ระยะทาง 7 จุด และรัศมีเบลอร์ 6 จุด:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

เพื่อเอาเงาภายในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Java คุณสามารถเพิ่มการสะท้อนลักษณะกระจกให้กับรูปร่าง ปรับพารามิเตอร์ เช่น ระยะ, ความโปร่งใสและขนาด เอฟเฟกต์นี้ช่วยยกระดับความสวยงามของงานนำเสนอโดยทำให้รูปร่างดูประณีตและมีระดับง่ายต่อการนำไปใช้ด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปร่าง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปร่างใน Aspose.Slides for Java คุณสามารถเพิ่มออร่าที่นุ่มนวลและสว่างไสวรอบรูปร่าง ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยทำให้รูปร่างเด่นขึ้นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับการนำเสนอของคุณ ใช้ง่ายด้วยโค้ดจำนวนน้อย ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปร่าง:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Java คุณสามารถสร้างการเปลี่ยนแปลงที่ราบรื่นและเบลอร์รอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะสำหรับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้เอฟเฟกต์ที่ต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปร่าง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **FAQ**

**ฉันสามารถใช้เอฟเฟกต์หลายอย่างกับรูปร่างเดียวได้หรือไม่?**

ได้ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและเรืองแสงบนรูปร่างเดียวเพื่อสร้างลุคที่มีพลวัตมากขึ้น

**รูปร่างใดบ้างที่ฉันสามารถใช้เอฟเฟกต์ได้?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลายประเภท รวมถึงออโต้ชิป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มกันได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด