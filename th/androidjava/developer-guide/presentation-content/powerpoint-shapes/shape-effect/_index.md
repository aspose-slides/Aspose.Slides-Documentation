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
- เอฟเฟกต์ขอบอ่อน
- รูปแบบเอฟเฟกต์
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "แปลงไฟล์ PPT และ PPTX ของคุณด้วยเอฟเฟกต์รูปร่างขั้นสูงโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java—สร้างสไลด์ที่โดดเด่นและเป็นมืออาชีพในไม่กี่วินาที"
---
## **บทนำ**

แม้ว่าเอฟเฟกต์ใน PowerPoint จะสามารถใช้ทำให้รูปร่างเด่นขึ้นได้ แต่ก็แตกต่างจาก [fills](/slides/th/androidjava/shape-formatting/#gradient-fill) หรือเส้นขอบ การใช้เอฟเฟกต์ใน PowerPoint คุณสามารถสร้างการสะท้อนที่เชื่อถือได้บนรูปร่าง กระจายแสงเรืองรอบรูปร่าง ฯลฯ

![เอฟเฟกต์รูปร่าง](shape-effect.png)

PowerPoint มีเอฟเฟกต์ทั้งหมดหกแบบที่สามารถใช้กับรูปร่างได้ คุณสามารถใช้หนึ่งหรือหลายเอฟเฟกต์กับรูปร่างได้

การผสมผสานเอฟเฟกต์บางแบบดูดีกว่าที่อื่น ด้วยเหตุนี้ PowerPoint จึงมีตัวเลือกภายใต้ **Preset** ตัวเลือก Preset เป็นการผสมผสานของสองหรือมากกว่าหนึ่งเอฟเฟกต์ที่รู้กันว่าดูดี วิธีนี้โดยการเลือก Preset คุณจะไม่ต้องเสียเวลาในการทดสอบหรือผสมผสานเอฟเฟกต์ต่าง ๆ เพื่อหาการผสมที่เหมาะสม

Aspose.Slides มีคุณสมบัติและเมธอดภายใต้คลาส [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) ที่ช่วยให้คุณใช้เอฟเฟกต์เดียวกันกับรูปร่างในงานนำเสนอ PowerPoint

## **ใช้เอฟเฟกต์เงา**

Aspose.Slides for Android via Java รองรับเงานอกและเงาภายในสำหรับรูปร่าง คุณสามารถปรับสี ทิศทาง ระยะห่าง และรัศมีเบลอร์เพื่อให้ตรงกับการออกแบบงานนำเสนอของคุณ

### **ใช้เงานอก**

ใช้เงานอกเพื่อทำให้การ์ดหรือแผงเด้งออกจากพื้นหลังสไลด์ เงาจะยืดออกนอกขอบของรูปร่างสร้างความรู้สึกว่ารูปร่างลอยอยู่เหนือสไลด์ ปรับสี ทิศทาง ระยะห่าง และรัศมีเบลอร์ให้ตรงกับแสงและสไตล์ของเทมเพลตของคุณ

โค้ด Java นี้แสดงวิธีใช้ [outer shadow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) กับสี่เหลี่ยมผืนผ้า:

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

### **ใช้เงาใน**

เมื่อทำซ้ำลักษณะภาพของเทมเพลต ให้ใช้เงาในเพื่อให้การ์ดหรือแผงดูดิ่งลงด้านใน เงานอกจะยืดออกนอกขอบและทำให้ดูลอยขึ้น ส่วนเงาในจะทำให้ขอบภายในมืดลง

เรียก [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) จากนั้นกำหนดค่าเงาที่ส่งกลับโดย [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) ค่ารัศมีเบลอร์ที่ใหญ่ขึ้นจะทำให้ขอบนุ่มขึ้น

ตัวอย่าง Java นี้สร้างการ์ดสีฟ้าอ่อนกับเงาในสีเทาเข้มและบันทึกเป็นไฟล์ PPTX ทิศทางของเงาคือ 225 องศา ระยะห่าง 7 พอยท์ และรัศมีเบลอร์ 6 พอยท์:

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

![สี่เหลี่ยมสีฟ้าอ่อนพร้อมเงาใน](inner_shadow_effect.png)

เพื่อเอาเงาในออก ให้เรียก [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) บนรูปแบบเอฟเฟกต์ของรูปร่าง

## **ใช้เอฟเฟ็กต์การสะท้อน**

เพื่อใช้เอฟเฟ็กต์การสะท้อนใน Aspose.Slides for Android via Java คุณสามารถเพิ่มการสะท้อนคล้ายกระจกให้กับรูปร่าง ปรับพารามิเตอร์เช่น ระยะห่าง ความโปร่งแสง และขนาด เอฟเฟ็กต์นี้ช่วยเพิ่มความสวยงามของงานนำเสนอโดยทำให้รูปร่างดูเป็นมืออาชีพและหรูหรามากขึ้น ใช้งานได้ง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สามารถนำไปใช้กับหลายองค์ประกอบได้อย่างรวดเร็วเพื่อให้การออกแบบสอดคล้องกัน

โค้ด Java นี้แสดงวิธีใช้ [reflection effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) กับรูปร่าง:

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

![เอฟเฟ็กต์การสะท้อน](reflection_effect.png)

## **ใช้เอฟเฟ็กต์เรืองแสง**

เพื่อใช้เอฟเฟ็กต์เรืองแสงกับรูปร่างใน Aspose.Slides for Android via Java คุณสามารถเพิ่มออร่านุ่มนวลรอบรูปร่าง ปรับคุณสมบัติเช่น สีและขนาด เอฟเฟ็กต์นี้ช่วยให้รูปร่างโดดเด่นและเพิ่มองค์ประกอบภาพที่ดึงดูดสายตาให้กับงานนำเสนอของคุณ ใช้งานง่ายด้วยโค้ดไม่กี่บรรทัด ทำให้สไลด์ของคุณดูสวยงามยิ่งขึ้น

โค้ด Java นี้แสดงวิธีใช้ [glow effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) กับรูปร่าง:

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

![เอฟเฟ็กต์เรืองแสง](glow_effect.png)

## **ใช้เอฟเฟ็กต์ขอบอ่อน**

เพื่อใช้เอฟเฟ็กต์ขอบอ่อนใน Aspose.Slides for Android via Java คุณสามารถสร้างการเปลี่ยนแปลงรอบขอบของรูปร่างที่เรียบเนียนและเบลอ เอฟเฟ็กต์นี้เพิ่มลุคที่ละเอียดอ่อนและสบายตา เหมาะสำหรับการออกแบบที่ต้องการความนุ่มนวล คุณสามารถปรับพารามิเตอร์เช่น รัศมีเพื่อให้ได้ผลลัพธ์ตามต้องการบนรูปร่างต่าง ๆ ในงานนำเสนอของคุณ

โค้ด Java นี้แสดงวิธีใช้ [soft edges effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) กับรูปร่าง:

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

![เอฟเฟ็กต์ขอบอ่อน](soft_edges_effect.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้หลายเอฟเฟ็กต์บนรูปร่างเดียวกันได้หรือไม่?**

ได้ คุณสามารถรวมเอฟเฟ็กต์ต่าง ๆ เช่น เงา การสะท้อน และเรืองแสง บนรูปร่างเดียวเพื่อสร้างลุคที่พลวัตมากขึ้น

**ฉันสามารถใช้เอฟเฟ็กต์กับรูปแบบใดบ้าง?**

คุณสามารถใช้เอฟเฟ็กต์กับรูปแบบต่าง ๆ ได้แก่ รูปร่างอัตโนมัติ, แผนภูมิ, ตาราง, รูปภาพ, วัตถุ SmartArt, วัตถุ OLE และอื่น ๆ

**ฉันสามารถใช้เอฟเฟ็กต์กับกลุ่มรูปร่างได้หรือไม่?**

ได้ คุณสามารถใช้เอฟเฟ็กต์กับกลุ่มรูปร่างได้ เอฟเฟ็กต์จะถูกนำไปใช้กับกลุ่มทั้งหมดอย่างเดียวกัน