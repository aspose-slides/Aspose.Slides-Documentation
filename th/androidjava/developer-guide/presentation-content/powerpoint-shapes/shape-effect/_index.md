---
title: ใช้เอฟเฟกต์รูปร่างในงานนำเสนอบน Android
linktitle: เอฟเฟกต์รูปร่าง
type: docs
weight: 30
url: /th/androidjava/shape-effect/
keywords:
- เอฟเฟกต์รูปร่าง
- เอฟเฟกต์เงา
- เอฟเฟกต์การสะท้อน
- เอฟเฟกต์เรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java — สร้างสไลด์ที่น่าตกใจและเป็นมืออาชีพในไม่กี่วินาที."
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถทำให้รูปร่างโดดเด่นได้ แต่ก็แตกต่างจาก [การเติมสี](/slides/th/androidjava/shape-formatting/#gradient-fill) หรือเส้นขอบ. โดยใช้เอฟเฟกต์ของ PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง, กระจายแสงเรืองแสงของรูปร่าง, เป็นต้น.

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกประเภทที่สามารถนำไปใช้กับรูปทรงได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปทรงหนึ่งรูปได้.

บางการผสมผสานของเอฟเฟกต์ดูดีกว่าการผสมอื่น ๆ ด้วยเหตุนี้ PowerPoint มีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานของสองหรือมากกว่าเอฟเฟกต์ที่รู้ว่าจะดูดี ด้วยวิธีนี้เมื่อเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่ดี

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ที่ช่วยให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปทรงในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides สำหรับ Android ผ่าน Java รองรับเงานอกและเงาภายในสำหรับรูปทรง คุณสามารถปรับแต่งสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงโดดเด่นเหนือพื้นหลังของสไลด์ เงาจะขยายออกนอกขอบของรูปทรง ทำให้ดูเหมือนรูปทร่างถูกยกขึ้นเหนือสไลด์ ปรับสี, ทิศทาง, ระยะทางและรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์เงานอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

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

### **ใช้เงาภายใน**

เมื่อทำสำเนาสไตล์ภาพของเทมเพลต ให้ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเหมือนหลุดลึกลง เงานอกขยายออกนอกรูปทรงและทำให้ดูยกขึ้น ส่วนเงาภายในจะทำให้ขอบด้านในมีเงา

เรียกใช้ [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) แล้วกำหนดค่าเงาที่ส่งกลับโดย [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะทำให้ขอบอ่อนลง.

ตัวอย่าง Java นี้สร้างการ์ดสีฟ้าอ่อนที่มีเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงาคือ 225 องศา ระยะห่างคือ 7 จุด และรัศมีเบลอร์คือ 6 จุด:

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

เพื่อลบเงาภายใน ให้เรียกใช้ [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปทรง

## **ใช้เอฟเฟกต์การสะท้อน**

เพื่อใช้เอฟเฟกต์การสะท้อนใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปทรงโดยปรับพารามิเตอร์เช่น ระยะ, ความโปร่งใสและขนาด เอฟเฟกต์นี้ช่วยเพิ่มความสวยงามให้กับงานนำเสนอของคุณโดยทำให้รูปทรงดูเรียบหรูและเป็นมืออาชีพ ง่ายต่อการใช้งานด้วยโค้ดที่เรียบง่าย ทำให้สามารถประยุกต์ใช้ได้อย่างรวดเร็วบนหลายองค์ประกอบเพื่อการออกแบบที่สอดคล้องกัน

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปทรง:

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

เพื่อใช้เอฟเฟกต์เรืองแสงบนรูปทรงใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถเพิ่มออร่านุ่มนวลและสว่างไสวรอบรูปทรงโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟกต์นี้ช่วยให้รูปทรงโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดและน่าสนใจให้กับงานนำเสนอของคุณ ง่ายต่อการใช้งานด้วยโค้ดเพียงเล็กน้อย ทำให้รูปลักษณ์ของสไลด์โดยรวมดีขึ้น

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์เรืองแสง](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปทรง:

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

## **ใช้เอฟเฟกต์ขอบนุ่ม**

เพื่อใช้เอฟเฟกต์ขอบนุ่มใน Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถสร้างการเปลี่ยนแปลงที่เรียบและเบลอร์รอบขอบของรูปทรง เอฟเฟกต์นี้เพิ่มลุคที่ละเอียดอ่อนและสง่างาม เหมาะสำหรับการออกแบบที่ต้องการลุคอ่อนโยนและนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีได้ง่ายเพื่อให้ได้เอฟเฟกต์ที่ต้องการบนรูปทรงต่าง ๆ ในงานนำเสนอของคุณ

โค้ด Java นี้แสดงวิธีการใช้ [เอฟเฟกต์ขอบนุ่ม](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปทรง:

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

ใช้การเบลอรูปทรงเพื่อทำให้การเติมและเส้นขอบของรูปทรงนุ่มนวลขึ้นขณะยังคงให้รูปทรงสามารถแก้ไขได้ เรียกใช้ [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปทรง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าไม่เป็นลบโดยค่าที่ใหญ่กว่าจะทำให้เบลอมากขึ้น รัศมีศูนย์จะไม่เปลี่ยนลักษณะของรูป

การตั้งค่า [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบเขตที่มองเห็นของเอฟเฟกต์ เมื่อเป็น `false` การเบลอจะถูกตัดให้อยู่ในขอบเขตที่วาดอยู่เดิมรวมถึงเส้นขอบ เมื่อเป็น `true` การเบลอสามารถขยายออกเหนือขอบเขตเหล่านั้นได้ การตั้งค่าใด ๆ ไม่ทำให้ตำแหน่งหรือขนาดของรูปทรงเปลี่ยนแปลง

การเปรียบเทียบด้านล่างใช้การเติม, เส้นขอบและขนาดของรูปทรงเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`.

![สี่เหลี่ยมดั้งเดิมเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด เมื่อ grow ปิดและเปิด](shape_blur_comparison.png)

ตัวอย่าง Java นี้สร้างสี่เหลี่ยมสีส้มที่มีเส้นขอบสีฟ้าเข้ม ใช้การเบลอ 5 จุด แล้วอัปเดตเป็นการเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะเบลอทั้งสอง แล้วเรียก [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) และบันทึกรูปทรงโดยไม่มีเบลอ

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

การเบลอรูปทรงจะส่งผลต่อการเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มจะทำให้ขอบของรูปทรงจางลง ในขณะที่การเบลอเงาจะทำให้เงานุ่มนวลเท่านั้น เอฟเฟกต์การแปลงรูปภาพทำงานกับเนื้อหาภาพ; ตัวอย่างนี้ใช้การเบลอโดยตรงกับรูปแบบเอฟเฟกต์ของรูปทรงโดยไม่แปลงรูปทรงเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟกต์กับรูปทรงเดียวกันได้หรือไม่?**

ได้ คุณสามารถผสมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อนและเรืองแสง บนรูปทรงเดียวเพื่อสร้างลุคที่ไดนามิกมากขึ้น.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงใดบ้าง?**

คุณสามารถใช้เอฟเฟกต์กับรูปทรงหลากหลายรวมถึงอัตรูป, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ.

**ฉันสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปทรงที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมด.