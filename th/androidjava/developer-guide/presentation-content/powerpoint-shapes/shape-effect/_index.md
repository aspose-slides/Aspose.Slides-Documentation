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
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

แม้เอฟเฟกต์ใน PowerPoint จะใช้เพื่อทำให้รูปทรงโดดเด่น, แต่พวกมันแตกต่างจาก [การเติม](/slides/th/androidjava/shape-formatting/#gradient-fill) หรือเส้นขอบ. การใช้เอฟเฟกต์ PowerPoint, คุณสามารถสร้างการสะท้อนที่ดูสมจริงบนรูปทรง, กระจายแสงเรืองแสงของรูปทรง, เป็นต้น.

![เอฟเฟกต์รูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟ็กต์กับรูปทรงหนึ่งรูปได้

การผสมผสานของเอฟเฟกต์บางแบบดูดีกว่าแบบอื่น ๆ ดังนั้น PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่รู้ว่าดูดี วิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Android via Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถกำหนดสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ของเงาให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงแสดงเด่นเหนือพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทรงลอยขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะและรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลต

This Java code shows how to apply the [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) to a rectangle:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์เงา](shadow_effect.png)

#### **ควบคุมทิศทางของเงาเมื่อรูปทรงหมุน**

ตามค่าเริ่มต้น, เงานอกจะหมุนตามรูปทรง. เพื่อทำให้รูปทรงที่มีการหมุนต่างกันดูเหมือนถูกส่องแสงจากทิศทางเดียวกัน, เรียก [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) ด้วยค่า `false` และใช้ [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) เพื่อให้เงาของพวกเขามีทิศทางเดียวกัน

ตัวอย่างสร้างลูกศรสีน้ำเงินสองลูกพร้อมเงาสีเทาที่เลื่อน 42 จุดไปทางขวา (0°) จากนั้นคัดลอกสไลด์และหมุนลูกศรทั้งสอง 90° ไปตามเข็มนาฬิกา

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
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

บนสไลด์ที่สอง ลูกศรซ้ายทำเงาตกลงด้านล่างขณะที่ลูกศรขวายังคงทำเงาไปทางขวา ทิศทางที่กำหนดยังคงเป็น 0° สำหรับเงาทั้งสอง

![การเรนเดอร์ PowerPoint ก่อนและหลังการหมุน 90°. เงาทั้งสองเริ่มที่ด้านขวา. หลังจากหมุน, เงาจะย้ายไปด้านล่างของลูกศรซ้ายและคงอยู่ที่ด้านขวาของลูกศรขวา.](arrow-shadow-rotation.png)

### **ใช้เงาภายใน**

เมื่อทำซ้ำสไตล์ภาพของเทมเพลต, ใช้เงาภายในเพื่อให้การ์ดหรือแผงมีลักษณะฝังลงไป เงานอกจะขยายออกนอกรูปทรงและทำให้ดูเหมือนยกขึ้น ส่วนเงาภายในจะทำให้ขอบภายในสีเข้มขึ้น

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่ได้จาก [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบนุ่มขึ้น

This Java example creates a light blue card with a dark gray inner shadow and saves it as a PPTX file. The shadow direction is 225 degrees, its distance is 7 points, and its blur radius is 6 points:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

หากต้องการลบเงาภายใน, เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปทรง

### **ใช้, เปลี่ยน, และลบเงาแบบตั้งล่วงหน้า**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) และใช้ [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) หากต้องการสลับสไตล์, เปลี่ยน Preset บนรูปทรงเดียวกัน. เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) เพื่อเอาเงาออกโดยคงการเติมและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนเคียงกันบนสไลด์เดียว ทั้งสองเงาเลื่อน 10 จุด ทิศทาง 225° จะทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม, ส่วน 45° จะทำให้เงาที่สองอยู่ด้านล่างขวา

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

| ต้นฉบับ | พรีเซ็ตแรก | พรีเซ็ตที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides for Android via Java, คุณสามารถเพิ่มการสะท้อนแบบกระจกให้กับรูปทรง, ปรับพารามิเตอร์เช่น ระยะ, ความโปร่งแสงและขนาด. เอฟเฟกต์นี้ช่วยให้การนำเสนอของคุณดูเรียบหรูและเป็นมืออาชีพยิ่งขึ้น ใช้ง่ายด้วยโค้ดง่าย ๆ ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อการออกแบบที่สอดคล้องกัน

This Java code shows how to apply the [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) to a shape:

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

เพื่อใช้เอฟเฟกต์เรืองแสงกับรูปทรงใน Aspose.Slides for Android via Java, คุณสามารถเพิ่มออร่าอ่อนแสงรอบรูปทรง, ปรับคุณสมบัติเช่น สีและขนาด. เอฟเฟกต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มความน่าสนใจให้กับการนำเสนอ ใช้ง่ายด้วยโค้ดเพียงเล็กน้อยทำให้สไลด์ดูสวยงามยิ่งขึ้น

This Java code shows how to apply the [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) to a shape:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **ใช้เอฟเฟกต์ขอบเบา**

เพื่อใช้เอฟเฟกต์ขอบเบาใน Aspose.Slides for Android via Java, คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอรอบขอบของรูปทรง เอฟเฟกต์นี้ให้ลุคที่ละเอียดอ่อนและพรีเมี่ยม เหมาะกับการออกแบบที่ต้องการความนุ่มนวล สามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ

This Java code shows how to apply the [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) to a shape:

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

## **ใช้เอฟเฟกต์เบลอ**

ใช้ Blur ของรูปทรงเพื่อทำให้การเติมและเส้นขอบของรูปทรงนุ่มลงขณะยังคงรักษารูปแบบที่แก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ, ค่าที่ใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมี 0 จะไม่เปลี่ยนรูปลักษณ์

การตั้งค่า [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อ `false`, เบลอจะถูกตัดตามขอบที่วาดไว้รวมถึงเส้นขอบ; เมื่อ `true`, เบลอสามารถขยายออกนอกขอบเหล่านั้นได้ ทั้งสองการตั้งค่าไม่ทำให้ตำแหน่งหรือขนาดของรูปทรงเปลี่ยนไป

การเปรียบเทียบด้านล่างใช้การเติม, เส้นขอบและขนาดรูปทรงเดียวกันทั้งหมด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด, โดยที่ grow ปิดและเปิดใช้งาน](shape_blur_comparison.png)

ตัวอย่าง Java นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม, ใช้เบลอ 5 จุด, แล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะเบลอทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) และบันทึกรูปทรงโดยไม่มีเบลอ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Blur ของรูปทรงมีผลต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบเบานุ่มทำให้ขอบรูปทรงจางลง, ในขณะที่ Blur ของเงาจะทำให้เงานุ่มลงเท่านั้น เอฟเฟกต์การแปลงภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้ Blur โดยตรงบนรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่ต้องแปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์หลายรายการกับรูปทรงเดียวกันได้หรือไม่?**

ได้, คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและเรืองแสงบนรูปทรงเดียวกันเพื่อให้ได้ลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดได้บ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลายรวมถึงรูปออโตชป์, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้, คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด