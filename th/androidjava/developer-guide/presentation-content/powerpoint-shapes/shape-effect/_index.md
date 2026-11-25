---
title: ใช้เอฟเฟครูปทรงในงานนำเสนอบน Android
linktitle: เอฟเฟครูปทรง
type: docs
weight: 30
url: /th/androidjava/shape-effect/
keywords:
- เอฟเฟครูปทรง
- เอฟเฟคเงา
- เอฟเฟคการสะท้อน
- เอฟเฟคแสงเรืองแสง
- เอฟเฟคขอบนุ่ม
- รูปแบบเอฟเฟค
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟครูปทรงขั้นสูงโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพภายในไม่กี่วินาที."
---
## **บทนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปทรงโดดเด่นได้ แต่จะแตกต่างจาก [การเติม](/slides/th/androidjava/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปทรง กระจายแสงรัศมีของรูปทรง ฯลฯ

![เอฟเฟครูปทรง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกประเภทที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงได้

บางการผสมของเอฟเฟกต์ดูดี hơn các
เหตุผลนี้ PowerPoint มีตัวเลือกภายใต้ **ค่าที่กำหนดล่วงหน้า** ตัวเลือกค่าที่กำหนดล่วงหน้าคือการผสมของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้ว่าดูดี วิธีนี้โดยการเลือกค่าที่กำหนดล่วงหน้า คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณลักษณะและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในพรีเซนเทชัน PowerPoint

## **ใช้เอฟเฟคเงา**

Aspose.Slides สำหรับ Android ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะห่างและรัศมีเบลอให้ตรงกับการออกแบบของพรีเซนเทชันของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้บัตรหรือแผงเด่นจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทรงลอยขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะห่างและรัศมีเบลอให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟคเงานอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

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

![เอฟเฟคเงา](shadow_effect.png)

### **ใช้เงาภายใน**

เมื่อทำสำเนาการออกแบบของเทมเพลต ให้ใช้เงาภายในเพื่อให้บัตรหรือแผงดูเหมือนถูกฝังลงในพื้นผิว เงานอกจะขยายออกนอกรูปทรงและทำให้ดูลอยขึ้น ในขณะที่เงาภายในจะทำให้ขอบภายในมีเงา

เรียกใช้ [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่คืนโดย [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). ค่ารัศมีเบลอที่มากขึ้นจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Java นี้สร้างบัตรสีน้ำฟ้อ่면서เงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงาคือ 225°, ระยะห่าง 7 จุด, รัศมีเบลอ 6 จุด:

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

![สี่เหลี่ยมสีฟ้าอ่อนที่มีเงาภายใน](inner_shadow_effect.png)

เพื่อลบเงาภายใน เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปทรงที่มีรูปแบบเอฟเฟกต์

### **ใช้ เปลี่ยน และลบเงาที่กำหนดล่วงหน้า**

เรียก [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) และใช้ [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) เพื่อเลือก [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/). เพื่อสลับสไตล์ ให้เปลี่ยนค่าที่กำหนดล่วงหน้าในรูปทรงเดียวกัน เรียก [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) เพื่อลบเงาโดยคงการเติมและเส้นขอบไว้

ตัวอย่างนี้แสดงสี่ขั้นตอนเคียงข้างกันในสไลด์เดียว ทั้งสองเงาถูกเลื่อน 10 จุด ทิศทาง 225° จะทำให้เงาแรกอยู่ด้านบนซ้ายของสี่เหลี่ยม และ 45° จะทำให้เงาที่สองอยู่ด้านล่างขวา

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

| ต้นฉบับ | ค่าที่กำหนดล่วงหน้าแรก | ค่าที่กำหนดล่วงหน้าที่สอง | หลังการลบ |
| :---: | :---: | :---: | :---: |
| ![ไม่มีเงา](preset_shadow_original.png) | ![เงาตกซ้ายบน](preset_shadow_top_left.png) | ![เงาตกขวาล่าง](preset_shadow_bottom_right.png) | ![ไม่มีเงาหลังการลบ](preset_shadow_removed.png) |

## **ใช้เอฟเฟคการสะท้อน**

เพื่อใช้เอฟเฟคการสะท้อนใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะห่าง, ความโปร่งใสและขนาด เอฟเฟคนี้ทำให้พรีเซนเทชันของคุณดูหรูหรามากขึ้นและง่ายต่อการนำไปใช้กับหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟคการสะท้อน](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปทรง:

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

![เอฟเฟคการสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟคแสงเรืองแสง**

เพื่อใช้เอฟเฟคแสงเรืองแสงกับรูปทรงใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถเพิ่มแสงรัศมีอ่อน ๆ รอบรูปทรงโดยปรับสีและขนาด เอฟเฟคนี้ช่วยให้รูปทรงโดดเด่นและเพิ่มความสวยงามให้กับพรีเซนเทชันของคุณ การใช้งานง่ายด้วยโค้ดไม่กี่บรรทัด

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟคเรืองแสง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปทรง:

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

![เอฟเฟคเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟคขอบนุ่ม**

เพื่อใช้เอฟเฟคขอบนุ่มใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงรัศมีที่เบลอรอบขอบของรูปทรง เอฟเฟคนี้ให้ลุคที่ละเอียดอ่อนและเป็นมืออาชีพ เหมาะกับการออกแบบที่ต้องการความอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมี เพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปทรงต่าง ๆ

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟคขอบนุ่ม](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปทรง:

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

![เอฟเฟคขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟคเบลอ**

ใช้การเบลอรูปทรงเพื่อทำให้เติมและเส้นขอบของรูปทรงนุ่มขึ้นในขณะที่ยังคงให้รูปทรงแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ โดยค่าที่มากขึ้นจะทำให้เบลอแรงขึ้น รัศมีเป็นศูนย์จะไม่เปลี่ยนลักษณะ

การตั้งค่า [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ ด้วย `false` เบลอจะถูกตัดให้ตรงกับขอบที่วาดไว้รวมถึงเส้นขอบ ด้วย `true` เบลอสามารถขยายออกนอกขอบเหล่านั้นได้ การตั้งค่าใด ๆ จะไม่เปลี่ยนตำแหน่งหรือขนาดของรูปทรง

การเปรียบเทียบด้านล่างใช้การเติม, เส้นขอบและขนาดรูปทรงเดียวกัน ทั้งแถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด โดยมีการเปิด/ปิด grow](shape_blur_comparison.png)

โค้ด Java นี้สร้างสี่เหลี่ยมส้มที่มีเส้นขอบสีน้ำเงินเข้ม ใช้เบลอ 5 จุด แล้วอัพเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะที่เบลอทั้งสอง จากนั้นเรียก [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) และบันทึกรูปทรงโดยไม่มีเบลอ

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

การเบลอรูปทรงกระทบต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟคขอบนุ่มทำให้ขอบของรูปทรงจางลง ในขณะที่การเบลอเงาจะทำให้เงานุ่มขึ้นเท่านั้น เอฟเฟคการแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงกับรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟคกับรูปทรงเดียวกันได้หรือไม่?**

ใช่ คุณสามารถผสานเอฟเฟคต่าง ๆ เช่น เงา, การสะท้อนและแสงเรืองแสง บนรูปทรงเดียวกันเพื่อให้ได้ลุคที่ไดนามิกมากขึ้น

**ฉันสามารถใช้เอฟเฟคกับรูปทรงประเภทใดได้บ้าง?**

คุณสามารถใช้เอฟเฟคกับรูปทรงต่าง ๆ ได้แก่ รูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟคกับรูปทรงที่จัดเป็นกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟคกับรูปทรงที่จัดเป็นกลุ่มได้ เอฟเฟคจะถูกนำไปใช้กับกลุ่มทั้งหมด**