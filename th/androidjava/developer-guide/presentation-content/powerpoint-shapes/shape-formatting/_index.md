---
title: จัดรูปแบบรูปร่าง PowerPoint บน Android
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/androidjava/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลายแบบ
- การเติมรูปภาพ
- การเติมเทกเจอร์
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การแสดงผลรูปร่างสีขาว‑ดำ
- การแสดงผลรูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3D
- เอฟเฟกต์การหมุน 3D
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint บน Android ด้วย Aspose.Slides—ตั้งสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับโครงร่าง การเติมสี และเอฟเฟกต์ต่างๆ Aspose.Slides for Android via Java ให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งใส การหมุน และการจัดรูปแบบ 3D

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java ให้ส่วนติดต่อและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) เพื่อควบคุมโค้งของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีที่มีโค้งสีน้ำเงินและเป็นเส้นประ [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) เลือกเส้นคอมพาวด์หนา‑บาง ในขณะที่ [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ตั้งค่าความกว้างเป็น 7 จุดและ [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) เลือกแบบลายเส้นประ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **ตั้งค่าแบบลายเส้นแบบกำหนดเอง**

ใช้ [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวของเส้นประและช่องว่างที่คุณต้องการ เช่น สำหรับโครงร่างที่มีแบรนด์หรือแผนภาพเชิงเทคนิค การกำหนดรูปแบบโดยอัตโนมัติจะเปลี่ยนสไตล์เส้นประเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/)

รายการในอาเรย์สลับระหว่างความยาวของเส้นประและช่องว่าง เริ่มด้วยเส้นประ แต่ละค่าจะเป็นหลายเท่าของความกว้างของเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดจะผลิตเส้นประ 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าที่จำกัดและไม่เป็นลบเพื่อกำหนดส่วนเต็มของเส้นประ‑ช่องว่าง ตัวอย่างใช้ค่าบวกเพื่อให้เส้นประและช่องว่างทุกส่วนมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงินห้าเส้นที่มีความยาวเท่าเดิมและปลายเส้นแบน สามเส้นแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกที่สองเท่าของความกว้าง ทำให้ความยาวของเส้นประและช่องว่างเพิ่มเป็นสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // คืนเส้นสุดท้ายเป็นสไตล์เส้นทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) ไปยัง [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) สไตล์ที่เลือกจะกำหนดลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามรูปแบบเส้นประแบบกำหนดเอง เส้นกว้างขึ้นโดยใช้รูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าปลายเส้น**

ใช้ [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) เพื่อกำหนดปลายของเส้นที่เปิดอยู่ คลาส [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) มีสามสไตล์ที่ระบุอย่างชัดเจน:

- `Flat`: เส้นหยุดที่จุดสิ้นสุด
- `Round`: ปลายเส้นกึ่งวงกลมยืดออกไปข้างนอกจากจุดสิ้นสุดครึ่งความกว้างของเส้น
- `Square`: ปลายเส้นสี่เหลี่ยมยืดออกไปข้างนอกจากจุดสิ้นสุดครึ่งความกว้างของเส้น

คลาสนี้ยังรวม `NotDefined` ซึ่งหมายความว่าไม่มีการกำหนดสไตล์ปลายอย่างชัดเจน

ปลายเส้นต่างจากหัวศรซึ่งเพิ่มสัญลักษณ์ที่ปลายเส้น และการเชื่อมต่อซึ่งควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดการใช้หัวศรผ่าน [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) และ [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลายเท่านั้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกันทั้งหมด ความกว้าง 20 จุด จากบนลงล่าง ใช้ปลาย Flat, Round, และ Square ตามลำดับ จุดสิ้นสุดของพวกมันมีพิกัดแนวนอนเดียวกัน; ปลาย Round และ Square ยืดออกไปข้างนอก 10 จุดจากแต่ละจุดสิ้นสุด

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**.

![ปลาย Flat, round, และ square บนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นรูปร่างดูเหมือนถูกวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนมาจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) และอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) ค่าที่ได้จะแสดงการจัดรูปแบบที่ใช้งานจริงหลังจากการสืบทอดถูกประมวลผล ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

ต่อไปนี้คือสามตัวเลือกสไตล์การเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าส่วนโค้งสองส่วนมาพบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมคม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างรูปสี่เหลี่ยมสีดำสามรูปที่มีโค้งสีน้ำเงินกว้าง 15 จุด ใช้ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) เพื่อใช้ค่า miter, bevel และ round ของคลาส [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) ตามลำดับเพื่อเปรียบเทียบการวาดมุม

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จำกัดการเชื่อมต่อแบบ Miter ที่มุมคม**

ใช้ [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) ร่วมกับ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) เพื่อจำกัดความยาวของมุมคม

ค่าที่จำกัดคืออัตราส่วนระหว่างระยะห่างของมุมด้านในและด้านนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวของ miter มีได้สูงสุดถึงแปดเท่าของความกว้างของเส้น; ค่านี้ไม่ใช่หน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขอบเขตที่ใหญ่ขึ้นทำให้จุดคมขึ้น การตั้งค่านี้ส่งผลต่อการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลต่อการแสดงผลเมื่อมุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองรูปที่มีโค้งกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และขวาใช้ `8` แต่ละรูปกว้าง 80 จุดและสูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาว miter ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำ bevel ที่ยอดซ้ายและคงยอดขวาให้อยู่ในรูปแบบจุดคม

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ด้านซ้ายและ **miter limit 8** ด้านขวา

![ยอดที่ bevel ด้วยขีดจำกัด miter 2 และยอดจุดคมด้วยขีดจำกัด miter 8 ใน PowerPoint](miter-limits.png)

## **การเติมสีไล่ระดับ**

การเติมสีไล่ระดับผสมสีทั่วทั้งรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่ระดับเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) เมธอด [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) วางสีหยุดที่ 0 และ 1 ซึ่งเป็นจุดเริ่มต้นและสิ้นสุดของไล่ระดับ การล้างสีหยุดที่มีอยู่เดิมทำให้ใช้เพียงสีสองนี้เท่านั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมสีไล่ระดับ](gradient-fill.png)

หากไล่ระดับดูต่างในภาพที่ส่งออกเทียบกับ PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่ระดับที่จัดเก็บในงานนำเสนอ

### **ตั้งมุมไล่ระดับเชิงเส้น**

ใช้ [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) เพื่อควบคุมการวางแนวของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, และ `270` จากล่างขึ้นบน มุมเศษส่วนก็รองรับได้ มุมที่อยู่นอกช่วง `[0, 360)` จะถูกทำให้เป็นรอบหนึ่ง เช่น `-45` จะเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีสีหยุดแดง, เขียว, น้ำเงินเดียวกันที่ตำแหน่ง `0`, `0.5`, และ `1` ปิดการสเกลเพื่อให้มุมสามารถเปรียบเทียบได้โดยอิสระจากสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint:

![ไล่ระดับเชิงเส้นที่ 0, 45, และ 90 องศาในแถวบน, และ 135, 180, และ 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **ปรับขนาดไล่ระดับเชิงเส้นตามรูปร่าง**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) รับค่า [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) ตั้งเป็น `False` เพื่อคงมุมไล่ระดับเชิงเรขาคณิตแม้รูปร่างเปลี่ยนสัดส่วน หรือเป็น `True` เพื่อสเกลไล่ระดับตามความกว้างและความสูงของรูปร่าง เมื่อเปิดการสเกล มุมที่เห็นอาจแตกต่างจากมุมที่กำหนดบนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและสีหยุดเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งเป็น `False`; คอลัมน์ขวาตั้งเป็น `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมสูงด้านล่าง ทั้งสองเริ่มด้วยขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่ระดับ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint, ปิดการสเกลที่ซ้ายและเปิดที่ขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่ระดับ 45‑องศา, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อปิดการสเกล แถบสีทแยงมุมจะคงทิศทางเดิมในสี่เหลี่ยมทั้งสอง เมื่อเปิดการสเกล แถบสีจะยืดตามสัดส่วนของรูปร่าง ช่วยทำสำเนาไล่ระดับของเทมเพลตเมื่อนำรูปร่างไปปรับขนาดต่างๆ ในสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่ระดับ `45` องศานี้

การตั้งมุมและการสเกลใช้ได้กับไล่ระดับเชิงเส้นเท่านั้น ไม่ได้ควบคุมการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)

### **รวมมุมกับแนวไล่ระดับ**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) เลือกสไตล์ไล่ระดับจากคลาส [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) ซึ่งไม่ใช่การแทนที่มุมเชิงตัวเลข สำหรับไล่ระดับเชิงเส้น แนวอาจเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) ให้รักษาแนวคงที่เมื่อต้องการเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่ลำดับต่างกัน สี่เหลี่ยมสองรูปมีลักษณะเดียวกัน: การกำหนดแนวก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เติมลายแบบ**

การเติมลายแบบใช้การออกแบบสองสี เช่น จุด, เส้น, หรือตาราง ตัวอย่างนี้ใช้ [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) เพื่อเลือกลายแบบ trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) ให้พื้นหลังสีเทาอ่อน, และ [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) ให้สีเหลืองสำหรับลาย

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลายแบบ](pattern-fill.png)

## **เติมรูปภาพ**

การเติมรูปภาพใช้ภาพภายในรูปร่าง ตัวอย่างนี้ต้องการภาพในเครื่องและใช้ [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) โหลดภาพเข้าสู่คอลเลกชันภาพของงานนำเสนอ ตั้งค่า [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) เป็นโหมดต่อกระเบื้องเพื่อทำซ้ำภาพภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปบัว](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **ทำภาพต่อกระเบื้องเป็นเทกเจอร์**

หากต้องการตั้งภาพต่อกระเบื้องเป็นเทกเจอร์และปรับพฤติกรรมการต่อกระเบื้อง สามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งโหมดเติมรูปภาพ—either `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุการจัดตำแหน่งของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าการเยื้องแนวนอนของกระเบื้อง (หน่วยจุด) จากจุดกำเนิดของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าการเยื้องแนวตั้งของกระเบื้อง (หน่วยจุด) จากจุดกำเนิดของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการภาพในเครื่องและกำหนด [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) ให้ทำซ้ำที่ขนาด 50% ของขนาดต้นฉบับ การเยื้อง −32 จุดทำให้กระเบื้องเลื่อนแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกทั้งสองทิศกำหนดการจัดเรียงเทกเจอร์ที่ทำซ้ำ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการต่อกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

การเติมสีทึบให้รูปร่างสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือกโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) จากนั้นบันทึกสี่เหลี่ยมในงานนำเสนอ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

### **คัดลอกสีโดยคงการอ้างอิงธีม**

ใช้ [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) เพื่อคัดลอกคำนิยามสี รวมถึงประเภทสี การอ้างอิงธีม และการแปลงต่างๆ นี้มีประโยชน์เมื่อต้องย้ายสีเติมระหว่างรูปร่างที่ควรยังคงตามธีมของงานนำเสนอ เมธอดจะคัดลอกเฉพาะสีเท่านั้น ไม่ได้คัดลอกประเภทการเติม, โค้ง, หรือการจัดรูปแบบอื่นของรูปร่าง ตั้งค่าประเภทการเติมของเป้าหมายโดยใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-)

ตัวอย่างนี้สร้างสี่เหลี่ยมสามรูปจากซ้ายไปขวา: แหล่งที่มา, คัดลอกที่คำนึงถึงธีม, และคัดลอกที่กำหนดเป็น RGB คงที่ แหล่งที่มาใช้ [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) เพื่ออ้างอิงสีแอคเซนต์แรกและเพิ่ม tint ด้วย [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-) คัดลอกแบบ RGB ใช้สีเติมที่มีผลของแหล่งที่มา ทำให้ทั้งสามดูเหมือนกันในตอนแรก การเรียก [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) ตั้งค่าเป็นค่า RGB คงที่และล้างการแปลงสีใดๆ ที่มีอยู่

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // การอ้างอิงธีมจะตามสีแอคเซนต์ใหม่; ค่ารหัสสี RGB คงที่จะไม่ตาม
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ก่อนการเปลี่ยนธีม, การเติมทั้งสามตรงกัน:

![แหล่งที่มา, คัดลอกเป้าหมาย, และคัดลอกแบบ RGB คงที่ที่มีการเติมสีน้ำเงินเดียวกัน](color-copy-before.png)

หลังการเปลี่ยนธีม, แหล่งที่มาและคัดลอกที่คำนึงถึงธีมจะตามสีแอคเซนต์ใหม่และคง tint ไว้ ส่วนคัดลอกแบบ RGB คงที่ยังคงเป็นสีฟ้า:

![แหล่งที่มาและคัดลอกเป้าหมายที่มีการเติมสีส้ม, ในขณะที่คัดลอกแบบ RGB คงที่ยังคงเป็นสีน้ำเงิน](color-copy-after.png)

คำนิยามที่คัดลอกเป็นอิสระจากแหล่งที่มา การเปลี่ยนแปลงธีมของแหล่งที่มา, การกำหนดสีใหม่, หรือการเพิ่ม/ลบการแปลงจะไม่ส่งผลต่อเป้าหมาย แต่อย่างไรก็ตาม การเปลี่ยนธีมจะยังคงมีผลต่อทั้งสองรูปร่าง เพราะแต่ละรูปอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX อีกครั้งจะคงประเภทสีที่คัดลอกโดย [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--), การอ้างอิงธีม, และคอลเลกชันการแปลงที่คืนโดย [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--) ไม่ได้แปลงเป็น RGB

เมื่อคัดลอกระหว่างบริบทธีมที่แตกต่างกัน เช่น งานนำเสนอที่มีพาเล็ตแอคเซนต์ต่างกัน การอ้างอิงที่คัดลอกจะถูกตีความตามธีมของเป้าหมาย ดังนั้นคำนิยามเดียวกันและการแปลงเดียวกันอาจให้สีที่มองเห็นต่างกัน ดูเพิ่มเติมที่ [Presentation Theme](/slides/th/androidjava/presentation-theme/) เพื่อเรียนรู้การกำหนดสีธีม

## **ใช้พื้นหลังสไลด์เป็นการเติมรูปแบบ**

ใช้ [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ เช่น ในเทมเพลตงานนำเสนอ ตั้งค่าประเภทการเติมด้วย [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เป็น [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) ก่อนเพื่อลบการเติมที่กำหนดไว้ การผสมนี้ทำให้รูปลักษณ์ใช้พื้นหลังสไลด์แทนการเติมแบบที่กำหนดไว้ การเปิดค่าสถานะนี้เพียงอย่างเดียวไม่ลบการเติมที่กำหนดไว้ก่อนหน้า

นี่ต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) : การเติมพื้นหลังจะครอบออบเจกต์ที่อยู่ด้านหลังรูปร่างด้วยพื้นที่พื้นหลังสไลด์ที่สอดคล้องกัน ส่วน NoFill จะทำให้ออบเจกต์เหล่านั้นมองเห็นได้ การไล่ระดับจะยังคงจัดตำแหน่งกับสไลด์แทนการเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สืบทอดโดยสไลด์และวางแถบสีมะนาวไว้ด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, กลางไม่มีการเติม, และขวาสลับจากพื้นหลังเป็นการเติมสีส้มที่กำหนดเอง

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // สืบทอดไล่ระดับจากมาสเตอร์.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // เพิ่มวัตถุนี้เป็นอันดับแรกเพื่อให้แสดงอยู่ด้านหลังสี่เหลี่ยม.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // ปิดการเติมพื้นหลังก่อนที่จะกำหนดการเติมแบบกำหนดเอง.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **พื้นหลัง**, **ไม่มีการเติม**, และ **เติมกำหนดเอง** แถบสีมะนาวถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังคงมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มกำหนดเองบนแถบสีมะนาว](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างจะใช้พื้นหลังที่ได้จากการแก้ไขของสไลด์; ตัวอย่างนี้ไม่ได้กำหนดพื้นหลังของสไลด์และเลย์เอาต์เพื่อให้มาสเตอร์ให้ค่า

## **ตั้งค่าความโปร่งใส**

สำหรับการเติมสีทึบ ส่วนประกอบ alpha ของสีควบคุมความทึบ: 0 หมายถึงโปร่งใสเต็มที่และ 255 หมายถึงทึบเต็ม ตัวอย่างนี้ใช้ค่า alpha 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3D**

ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อให้รูปร่างมีมิติลึกและขอบบีเวล ตัวอย่างนี้สร้างวงรีสีเขียวที่มีโค้งสีส้ม, ตั้งความลึกเป็น 4 จุดด้วย [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) และใช้บีเวลด้านบนเป็นวงกลมโดยตั้งความกว้างและความสูงเป็น 6 จุดผ่าน [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) กล้องแบบออร์โธกราฟิกหน้าตรงและแสงสามจุดทำให้บีเวลมองเห็นได้

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

มุมมอง 3D ของรูปรShape ควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) พร้อมมุมละติจูด, ลองจิจูด, และการหมุนรัศมีที่ 40, 35, และ 20 องศาตามลำดับ เลือกกล้องแบบ isometric ผ่าน [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) และแสงแบบสมดุลผ่าน [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาว‑ดำสำหรับรูปร่าง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ระบุว่ารูปรShape ใดจะเรนเดอร์อย่างไรเมื่อการนำเสนอถูกดูหรือประมวลผลในโหมดขาว‑ดำ มันไม่ได้เปิดใช้งานโหมดขาว‑ดำเองและไม่ได้เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่นในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันแปลงโดยอัตโนมัติ, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` คงสีปกติ, `Hidden` ลบรูปรShape ในโหมดขาว‑ดำ, `NotDefined` หมายความว่าไม่ได้กำหนดโหมดระดับรูปรShape

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) เพื่อเลือกการแสดงผลสีเทา การบันทึกรูปรShape จะคงสีส้มสำหรับการแสดงผลสีปกติและขอให้แอปพลิเคชันที่เคารพการตั้งค่าโหมดขาว‑ดำแสดงสีเทา

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในกระบวนการแสดงผลขาว‑ดำ มันใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray` ทำให้คุณสามารถคงสไลด์สีเต็มไว้ขณะกำหนดลักษณะเฉพาะสำหรับการพิมพ์, ดูตัวอย่าง, หรือกระบวนการอื่นที่เคารพการตั้งค่าแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) เพื่อคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวแทนสไลด์จากตัวแทนเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องการงานนำเสนอที่มีตัวแทนเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปรShape ที่ไม่มีตัวแทนเลย์เอาต์ที่สอดคล้องจะไม่ถูกรีเซ็ต

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปรShape มีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปรShape บนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อรวมกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติกุญแจการจัดรูปแบบของแต่ละรูปรShape — การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทุกค่าแม่นยำตรงกัน ให้ถือสไตล์ว่าเหมือนกันและจัดกลุ่มรูปรShape เหล่านั้นแบบตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปรShape แบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปรShape ตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์ .POTX เทมเพลต เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปรShapeที่ต้องการ, แล้วนำสไตล์ไปใช้ใหม่ตามต้องการ