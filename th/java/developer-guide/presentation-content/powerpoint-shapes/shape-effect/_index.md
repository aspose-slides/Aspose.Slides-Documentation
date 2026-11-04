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
- เอฟเฟกต์แสงเรืองแสง
- เอฟเฟกต์ขอบนุ่ม
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides for Java — สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที."
---
## **คำนำ**

ในขณะที่เอฟเฟกต์ใน PowerPoint สามารถใช้ทำให้รูปร่างโดดเด่นได้ แต่แตกต่างจาก [การเติม](/slides/th/java/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่น่าเชื่อถือบนรูปร่าง แพร่กระจายแสงเงาของรูปร่าง ฯลฯ

![Shape effect](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

บางการผสมผสานของเอฟเฟกต์ดูดีขึ้นกว่ากัน ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset คือการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่ทราบว่าดูดี วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมผสานที่ดี

Aspose.Slides ให้คุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) ซึ่งทำให้คุณสามารถใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint ได้

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับสี, ทิศทาง, ระยะทาง และรัศมีเบลอร์ให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด่นออกมาจากพื้นหลังสไลด์ เงาจะขยายออกนอกขอบของรูปร่าง ทำให้รูปร่างดูเหมือนลอยอยู่เหนือสไลด์ ปรับสี, ทิศทาง, ระยะทาง และรัศมีเบลอร์ให้สอดคล้องกับแสงและสไตล์ของเทมเพลตของคุณ

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

### **ใช้เงาภายใน**

เมื่อทำสำเนาการออกแบบที่เป็นภาพของเทมเพลต ใช้เงาภายในเพื่อให้การ์ดหรือแผงดูเป็นบรรทัดลึก เงานอกขยายออกนอกรูปร่างทำให้ดูยกขึ้น ในขณะที่เงาภายในทำให้ด้านในของขอบมีเงา

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) จากนั้นกำหนดค่าเงาที่ส่งคืนโดย [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) ค่ารัศมีเบลอร์ที่ใหญ่กว่าจะให้ขอบที่นุ่มนวลขึ้น

ตัวอย่าง Java นี้สร้างการ์ดสีน้ำเงินอ่อนพร้อมเงาภายในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางเงาคือ 225 องศา ระยะทาง 7 จุด และรัศมีเบลอร์ 6 จุด:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาภายใน](inner_shadow_effect.png)

หากต้องการลบเงาภายใน ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟ็กต์การสะท้อน**

เพื่อใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides for Java คุณสามารถเพิ่มการสะท้อนเหมือนกระจกให้กับรูปร่าง โดยปรับพารามิเตอร์เช่น ระยะทาง, ความโปร่งใส, และขนาด เอฟเฟกต์นี้ช่วยให้การนำเสนอของคุณดูเป็นมืออาชีพและหรูหรามากขึ้น ใช้งานง่ายด้วยโค้ดที่เรียบง่าย ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อให้ได้การออกแบบที่สอดคล้องกัน

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์การสะท้อน](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปร่าง:

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

## **ใช้เอฟเฟ็กต์แสงเรืองแสง**

เพื่อใช้เอฟเฟ็กต์แสงเรืองแสงกับรูปร่างใน Aspose.Slides for Java คุณสามารถเพิ่มออร่าอ่อน ๆ รอบรูปร่างโดยปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปร่างเด่นชัดและเพิ่มความน่าสนใจให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดเพียงเล็กน้อย ทำให้ภาพรวมของสไลด์ดูสวยงามขึ้น

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟกต์แสงเรืองแสง](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปร่าง:

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

![เอฟเฟกต์แสงเรืองแสง](glow_effect.png)

## **ใช้เอฟเฟ็กต์ขอบนุ่ม**

เพื่อใช้เอฟเฟ็กต์ขอบนุ่มใน Aspose.Slides for Java คุณสามารถสร้างการเปลี่ยนแปลงที่นุ่มและเบลอรอบขอบของรูปร่าง เอฟเฟ็กต์นี้เพิ่มลุคที่ละเอียดอ่อนและเรียบหรู เหมาะกับการออกแบบที่ต้องการลุคอ่อนโยน คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ที่ต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณได้อย่างง่ายดาย

โค้ด Java นี้แสดงวิธีใช้ [เอฟเฟ็กต์ขอบนุ่ม](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปร่าง:

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

![เอฟเฟ็กต์ขอบนุ่ม](soft_edges_effect.png)

## **ใช้เอฟเฟ็กต์เบลอ**

ใช้การเบลอรูปร่างเพื่อทำให้สีเติมและเส้นขอบของรูปร่างนุ่มลง ในขณะที่ยังคงให้รูปแบบของรูปร่างแก้ไขได้ เรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) บนรูปแบบเอฟเฟกต์ของรูปร่าง รัศมีวัดเป็นจุด (1/72 นิ้ว): ใช้ค่าที่ไม่เป็นลบ ค่าใหญ่กว่าจะทำให้เบลอแรงขึ้น รัศมีศูนย์จะไม่เปลี่ยนแปลงลักษณะของรูปร่าง

การตั้งค่า [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) ควบคุมขอบมองเห็นของเอฟเฟกต์ เมื่อ `false` เบลอจะถูกตัดให้อยู่ในขอบที่วาดไว้เดิมรวมถึงเส้นขอบ เมื่อ `true` เบลอสามารถขยายออกนอกขอบเหล่านั้นได้ การตั้งค่าใด ๆ ก็ไม่ได้เปลี่ยนตำแหน่งหรือขนาดของรูปร่าง

การเปรียบเทียบด้านล่างใช้สีเติม, เส้นขอบ, และขนาดรูปร่างเดียวกันตลอด แถวบนใช้ `grow = false`; แถวล่างใช้ `grow = true`

![สี่เหลี่ยมต้นฉบับเปรียบเทียบกับรัศมีเบลอ 5 และ 15 จุด พร้อมการเปิด/ปิด grow](shape_blur_comparison.png)

ตัวอย่าง Java นี้สร้างสี่เหลี่ยมสีส้มพร้อมเส้นขอบสีน้ำเงินเข้ม ใช้เบลอ 5 จุดแล้วอัปเดตเป็นเบลอ 15 จุดโดยเรียก [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) อีกครั้ง บันทึกสถานะที่เบลอทั้งสอง จากนั้นเรียก [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) และบันทึกรูปร่างโดยไม่มีเบลอ

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

การเบลอรูปร่างกระทบต่อสีเติมและเส้นขอบพร้อมกัน เอฟเฟกต์ขอบนุ่มทำให้ขอบรูปร่างจางลง ในขณะที่การเบลอเงาทำให้เงาเท่านั้นนุ่มลง เอฟเฟกต์การแปลงภาพทำงานบนเนื้อหาภาพ; ตัวอย่างนี้ใช้เบลอโดยตรงกับรูปแบบเอฟเฟกต์ของรูปร่างโดยไม่แปลงรูปร่างเป็นภาพ

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้เอฟเฟกต์หลายอย่างกับรูปร่างเดียวกันได้หรือไม่?**

ใช่ คุณสามารถรวมเอฟเฟกต์ต่าง ๆ เช่น เงา, การสะท้อน, และแสงเรืองแสง บนรูปร่างเดียวเพื่อให้ได้ลุคที่ไดนามิกมากขึ้น

**รูปร่างใดบ้างที่ฉันสามารถใช้เอฟเฟกต์ได้?**

คุณสามารถใช้เอฟเฟกต์กับรูปร่างหลากหลาย รวมถึงรูปอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟกต์กับรูปร่างที่จัดกลุ่มได้ เอฟเฟกต์จะถูกนำไปใช้กับกลุ่มทั้งหมดตัวนั้น