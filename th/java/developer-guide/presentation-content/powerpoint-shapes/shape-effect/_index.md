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
- เอฟเฟกต์แสงเรืองรัศมี
- เอฟเฟกต์ขอบนุ่มนวล
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

ขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้เพื่อทำให้รูปร่างโดดเด่นขึ้น พวกมันจะแตกต่างจาก [fills](/slides/th/java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่เชื่อถือได้บนรูปร่าง, กระจายแสงเงาของรูปร่าง, ฯลฯ  

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถนำไปใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีมากกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่ทราบว่าดูดี วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ที่ให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถกำหนดสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบของงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นเหนือพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง ทำให้ดูเหมือนรูปร่างลอยอยู่เหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของแม่แบบ

โค้ด Java นี้แสดงวิธีใช้ [outer shadow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

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

เมื่อต้องทำสำเนาการออกแบบของแม่แบบ ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนถูกฝังเข้าไป เงานอกจะขยายออกนอกรูปร่างและทำให้ดูเป็นยกขึ้น ในขณะที่เงาภายในจะทำให้ขอบภายในของรูปร่างมีเงา

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่ได้จาก [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนิ่มขึ้น

ตัวอย่าง Java นี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงา 225 องศา ระยะทาง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

เพื่อลบเงาภายใน ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปร่าง

### **ใช้, เปลี่ยนและลบ Preset Shadow**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) และใช้ [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). เพื่อสลับสไตล์ ให้เปลี่ยน Preset บนรูปร่างเดียวกัน เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) เพื่อลบเงาโดยยังคงรักษาการเติมสีและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนเคียงข้างกันบนสไลด์เดียว ทั้งสองเงาถูกเลื่อน 10 จุด ทิศทาง 225° จะวางเงาแรกไว้ด้านบนซ้ายของสี่เหลี่ยมผืนผ้า ส่วน 45° จะวางเงาที่สองไว้ด้านล่างขวา

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| ดั้งเดิม | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Java คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปร่าง ปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสงและขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้กับงานนำเสนอของคุณโดยทำให้รูปร่างดูขัดเกลาและหรูหรามากขึ้น ใช้งานง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Java นี้แสดงวิธีใช้ [reflection effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปแบบ:

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

## **ใช้เอฟเฟกต์แสงเรืองรัศมี**

เพื่อใช้เอฟเฟกต์แสงเรืองรัศมีกับรูปร่างใน Aspose.Slides for Java คุณสามารถเพิ่มออร่าที่นุ่มนวลและสว่างไสวรอบรูปร่าง ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบที่ดึงดูดสายตาให้กับการนำเสนอของคุณ ง่ายต่อการใช้งานด้วยโค้ดขั้นต่ำ ส่งผลให้สไลด์ดูสวยงามขึ้นโดยรวม

โค้ด Java นี้แสดงวิธีใช้ [glow effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปร่าง:

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

## **ใช้เอฟเฟกต์ขอบนุ่มนวล**

เพื่อใช้เอฟเฟกต์ขอบนุ่มนวลใน Aspose.Slides for Java คุณสามารถสร้างการเปลี่ยนผ่านที่นุ่มและเบลอร์รอบขอบของรูปร่าง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและประณีต เหมาะกับการออกแบบที่ต้องการลุคอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีย่อยให้ได้ผลลัพธ์ตามต้องการบนรูปร่างต่าง ๆ ในการนำเสนอของคุณ

โค้ด Java นี้แสดงวิธีใช้ [soft edges effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปร่าง:

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

## **ใช้เอฟเฟกต์เบลอร์**

ใช้ Blur ของรูปร่างเพื่อทำให้สีเติมและเส้นขอบของรูปร่างนุ่มลงในขณะที่รูปร่างยังสามารถแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่ารัศมีที่ใหญ่กว่าจะทำให้เบลอร์แรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบที่มองเห็นของเอฟเฟกต์ ด้วย `false` เบลอร์จะถูกตัดให้พอดีกับขอบที่วาดเดิมรวมเส้นขอบด้วย ด้วย `true` เบลอร์สามารถขยายออกนอกขอบเหล่านั้นได้ ทั้งสองค่าจะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบและขนาดรูปร่างเดียวกันทั้งหมด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

ตัวอย่าง Java นี้สร้างสี่เหลี่ยมส้มที่มีเส้นขอบสีน้ำเงินเข้ม ใช้เบลอร์ 5 จุด จากนั้นอัปเดตเป็นเบลอร์ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะที่เบลอร์ทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) เพื่อบันทึกรูปร่างโดยไม่มีเบลอร์

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Blur ของรูปร่างส่งผลต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มนวลทำให้ขอบของรูปร่างจาง หัวเงาเบลอร์ทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟกต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอร์โดยตรงกับรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่ต้องแปลงรูปร่างเป็นภาพ

## **FAQ**

**สามารถใช้หลายเอฟเฟกต์กับรูปร่างเดียวกันได้หรือไม่?**

ได้, คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และแสงเรืองรัศมี บนรูปร่างเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น

**สามารถใช้เอฟเฟกต์กับรูปร่างประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลายประเภท รวมถึงออโต้ช่าง, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**สามารถใช้เอฟเฟกต์กับรูปร่างที่จัดเป็นกลุ่มได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่กลุ่มไว้ เอฟเฟกต์จะนำไปใช้กับทั้งกลุ่ม