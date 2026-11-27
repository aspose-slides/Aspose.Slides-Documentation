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
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides for Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปทรงโดดเด่นได้ แต่พวกมันแตกต่างจาก [เติม](/slides/th/java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงอู้งของรูปทรง เป็นต้น

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์หกแบบที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งได้

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่รู้ว่าดูดีด้วยกัน วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาแนวผสมที่ดี

Aspose.Slides ให้คุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Java รองรับเงานอกและเงาในสำหรับรูปทรง คุณสามารถปรับสี, ทิศทาง, ระยะห่างและรัศมีเบลอร์เพื่อให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงโครงสร้างโดดเด่นจากพื้นหลังสไลด์ เงาขยายออกไปนอกขอบของรูปทรง สร้างความรู้สึกว่ารูปทรงถูกยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะห่างและรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

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

![เอฟเฟกต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางเงาเมื่อรูปทรงหมุน**

โดยค่าเริ่มต้น เงานอกจะหมุนพร้อมกับรูปทรง เพื่อทำให้รูปทรงที่มีการหมุนต่างกันดูเหมือนได้รับแสงจากทิศทางเดียวกัน ให้เรียก [setRotateShadowWithShape](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) ด้วยค่า `false` และใช้ [setDirection](https://reference.aspose.com/slides/java/com.aspose.slides/ioutershadow/#setDirection-float-) เพื่อกำหนดทิศทางเงาให้เหมือนกัน

ตัวอย่างสร้างลูกศรกึ่งสีน้ำเงินสองลูกพร้อมเงาสีเทาที่ชิดขวา 42 จุด (0°) จากนั้นทำสำเนาสไลด์และหมุนลูกศรทั้งสอง 90° ตามเข็มนาฬิกา

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.GRAY);
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

บนสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงด้านล่าง ขณะที่ลูกศรขวายังคงทำเงาตกข้างขวา ทิศทางที่ตั้งค่ายังคงเป็น 0° สำหรับเงาทั้งสอง

![การแสดงผล PowerPoint ก่อนและหลังการหมุน 90° ทั้งสองเงาเริ่มจากด้านขวา หลังการหมุน เงาจะย้ายลงด้านล่างของลูกศรซ้ายและคงอยู่ด้านขวาของลูกศรขวา](arrow-shadow-rotation.png)

### **ใช้เงาใน**

เมื่อต้องทำสำเนารูปแบบภาพของเทมเพลต ให้ใช้เงาในเพื่อให้การ์ดหรือแผงโครงสร้างดูเหมือนถูกฝังลึกลงไป เงานอกขยายออกนอกรูปทรงทำให้ดูยกขึ้น ในขณะที่เงาในทำให้ขอบด้านในมืดลง

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่คืนค่าจาก [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Java นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงาเป็น 225° ระยะห่าง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

![สี่เหลี่ยมสีน้ำเงินอ่อนพร้อมเงาใน](inner_shadow_effect.png)

เพื่อเอาเงาในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปทรง

### **ใช้, เปลี่ยน, และลบ Preset Shadow**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) และใช้ [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) หากต้องการสลับสไตล์ ให้เปลี่ยน preset บนรูปทรงเดียวกัน เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) เพื่อลบเงาโดยคงฟิลและขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนเคียงข้างกันในสไลด์เดียว ทั้งสองเงาชิดด้วยระยะ 10 จุด ทิศทาง 225° จะวางเงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม และ 45° จะวางเงาที่สองอยู่ด้านล่างขวา

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

| ต้นฉบับ | Preset แรก | Preset ที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกซ้ายบน](preset_shadow_top_left.png) | ![เงาตกขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Java คุณสามารถเพิ่มการสะท้อนแบบกระจกบนรูปทรง ปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใสและขนาด เอฟเฟกต์นี้ทำให้การนำเสนอของคุณดูสวยงามและเป็นมืออาชีพมากขึ้น ใช้ง่ายด้วยโค้ดไม่กี่บรรทัด สามารถใช้ได้อย่างรวดเร็วกับหลายองค์ประกอบเพื่อให้การออกแบบสอดคล้องกัน

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปทรง:

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

![เอฟเฟกต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟกต์เรืองแสง**

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปทรงใน Aspose.Slides for Java คุณสามารถเพิ่มออร่าอ่อนแสงรอบรูปทรง ปรับสีและขนาด เอฟเฟกต์นี้ช่วยให้รูปทรงเด่นขึ้นและเพิ่มความน่าสนใจให้กับการนำเสนอของคุณ ใช้ง่ายด้วยโค้ดสั้น ๆ ทำให้สไลด์ของคุณดูโดดเด่นยิ่งขึ้น

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปทรง:

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

![เอฟเฟกต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides for Java คุณสามารถสร้างการเปลี่ยนแปลงขอบแบบเบลอร์รอบรูปทรง เอฟเฟกต์นี้ให้รูปลักษณ์ที่ละเอียดอ่อนและเรียบหรู เหมาะกับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ที่ต้องการบนหลายรูปทรงในงานนำเสนอของคุณ

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปทรง:

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

![เอฟเฟกต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟกต์เบลอร์**

ใช้การเบลอร์รูปทรงเพื่อทำให้ฟิลและขอบของรูปทรงนุ่มขึ้นในขณะที่ยังคงให้รูปทรงแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว) ใช้ค่าที่ไม่เป็นลบ ค่ารัศมีที่สูงกว่าจะทำให้เบลอร์แรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะใด ๆ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบมองเห็นของเอฟเฟกต์ หากตั้งค่าเป็น `false` การเบลอร์จะถูกตัดให้เข้ากับขอบที่วาดไว้รวมถึงขอบเส้น หากเป็น `true` การเบลอร์อาจขยายออกนอกขอบเหล่านั้น ค่าใด ๆ จะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้ฟิล, ขอบและขนาดรูปทรงเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอร์ 5 และ 15 จุด โดยมีการ grow ปิดและเปิดใช้งาน](shape_blur_comparison.png)

โค้ด Java นี้สร้างสี่เหลี่ยมส้มพร้อมขอบสีน้ำเงินเข้ม ใช้เบลอร์ 5 จุด แล้วอัปเดตเป็นเบลอร์ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะเบลอร์ทั้งสอง จากนั้นเรียก [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) และบันทึกรูปทรงโดยไม่มีเบลอร์

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

การเบลอร์รูปทรงส่งผลต่อฟิลและขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบรูปทรงจางหายไปขณะที่การเบลอร์เงานุ่มทำให้เงาเบลอร์เท่านั้น เอฟเฟกต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอร์โดยตรงบนรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**  
ได้ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน และเรืองแสง บนรูปทรงเดียวได้เพื่อสร้างลักษณะที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**  
คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลายประเภท รวมถึงออโต้ช็อป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE เป็นต้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**  
ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.