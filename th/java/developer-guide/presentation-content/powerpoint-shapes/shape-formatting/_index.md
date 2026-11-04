---
title: จัดรูปแบบรูปร่าง PowerPoint ด้วย Java
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างขาว‑ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์ขอบระดับ 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย Java โดยใช้ Aspose.Slides—ตั้งค่าการเติมสี, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่."
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสี และเอฟเฟกต์ต่าง ๆ Aspose.Slides for Java ให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งแสง การหมุน และการจัดรูปแบบ 3 มิติ.

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java ให้อินเทอร์เฟซและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint.

## **จัดรูปแบบเส้น**

ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมที่ไม่มีการเติมสีโดยมีเส้นขอบสีน้ำเงินขีดเป็นจังหวะ [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) เลือกเส้นคอมพาวนด์หนา-บาง ในขณะที่ [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ตั้งความกว้างเป็น 7 จุดและ [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) เลือกรูปแบบขีด.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **ตั้งค่ารูปแบบจังหวะเส้นแบบกำหนดเอง**

ใช้ [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวจังหวะและช่องว่างที่คุณต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนภาพเทคนิค การกำหนดรูปแบบจะเปลี่ยนสไตล์จังหวะเส้นโดยอัตโนมัติเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

รายการอาเรย์สลับระหว่างความยาวจังหวะและช่องว่าง โดยเริ่มจากจังหวะ แต่ละค่าคือหลายเท่าของความกว้างเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดให้จังหวะ 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ค่าที่จำกัด ไม่เป็นลบเพื่อกำหนดส่วนจังหวะและช่องว่างที่สมบูรณ์ ตัวอย่างใช้ค่าบวกเพื่อให้ทุกจังหวะและช่องว่างมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นด้วยความยาวและขอบแบบ flat เดียวกัน สามเส้นแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกที่สองเท่าของความกว้าง เพิ่มความยาวของจังหวะและช่องว่างเป็นสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // เปลี่ยนเส้นสุดท้ายให้เป็นสไตล์เส้นทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อกลับไปใช้สไตล์จังหวะที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) ไปที่ [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). สไตล์ที่เลือกจะควบคุมการแสดงของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![รูปแบบจังหวะเส้นแบบกำหนดเองสามแบบ เส้นกว้างที่ใช้รูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าขอบเส้น**

ใช้ [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) เพื่อกำหนดปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) มีสไตล์ขอบชัดเจนสามแบบ:

- `Flat`: เส้นหยุดที่จุดสิ้นสุด.
- `Round`: ส่วนปลายรูปครึ่งวงกลมขยายออกไปข้างนอกจุดสิ้นสุดด้วยระยะครึ่งความกว้างของเส้น.
- `Square`: ส่วนปลายรูปสี่เหลี่ยมขยายออกไปข้างนอกจุดสิ้นสุดด้วยระยะครึ่งความกว้างของเส้น.

คลาสยังมี `NotDefined` ซึ่งหมายความว่าไม่ได้กำหนดสไตล์ขอบอย่างชัดเจน

ขอบแตกต่างจากหัวศรที่เพิ่มสัญลักษณ์ที่ปลายเส้น และการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดหัวศรด้วย [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) และ [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) เพื่อให้เปรียบเทียบเฉพาะรูปแบบขอบเท่านั้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกันโดยมีความกว้าง 20 จุด จากบนลงล่าง ใช้ขอบ flat, round, และ square ตามลำดับ จุดปลายมีพิกัดแนวนอนเดียวกัน; ขอบ round และ square ขยายออกไป 10 จุดเหนือแต่ละจุดปลาย

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

![ขอบเส้นแบบ Flat, Round, และ Square บนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)

ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดอย่างชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์มาสเตอร์, หรือสไลด์เลย์เอาต์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) และอ่านค่า [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). ค่าที่มีประสิทธิผลสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข ตัวอย่างนี้ต้องมีงานนำเสนอที่มีอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมว่าส่วนขอบสองส่วนมาบรรจบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำ 3 คิวบ์ที่มีเส้นขอบสีน้ำเงินกว้าง 15 จุด ใช้ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ตั้งค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) ตามลำดับ เพื่อตรวจสอบการวาดมุม

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **จำกัดการเชื่อมต่อ Miter ที่มุมคม**

ใช้ [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) ร่วมกับ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ตั้งค่าเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมคมสามารถยืดออกได้

ค่าจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาว miter สูงสุดถึงแปดเท่าของความกว้างเส้น; ค่านี้ไม่ได้เป็นหน่วยจุด หากมุมเกินค่าจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ค่าใหญ่ขึ้นทำให้จุดแหลมมากขึ้น การตั้งค่านี้ส่งผลเฉพาะการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงไม่มีผลที่มองเห็นได้เมื่อมุมยังอยู่ภายในข้อจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองรูปที่เหมือนกันโดยมีเส้นขอบกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ค่าจำกัด `2` ส่วนขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาว miter ต่อความกว้างเส้นประมาณ `4.12` ส่งผลให้ PowerPoint ทำ bevel ที่ยอดซ้ายและรักษายอดขวาไว้

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา.

![ยอดที่ถูกตัดเป็นแบนด้วยมิตเตอร์ลิมิต 2 และยอดแหลมด้วยมิตเตอร์ลิมิต 8 ใน PowerPoint](miter-limits.png)

## **เติมสีแบบไล่ระดับ**

การเติมสีแบบไล่ระดับผสมสีทั่วทั้งรูปร่าง ตัวอย่างนี้เติมสีเอลิปส์ด้วยไล่ระดับเชิงเส้นที่มุม 45 องศาจากสีแดงถึงสีม่วงโดยใช้ [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). เมธอด [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) วางจุดหยุดสีที่ 0 และ 1 คือจุดเริ่มและจุดสิ้นสุดของไล่ระดับ การลบจุดหยุดที่มีอยู่ทำให้ใช้เฉพาะสองสีนี้เท่านั้น

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

![วงรีที่มีการเติมสีไล่ระดับ](gradient-fill.png)

หากไล่ระดับแสดงผลต่างกันในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนไล่ระดับที่เก็บในงานนำเสนอ

### **ตั้งค่ามุมไล่ระดับเชิงเส้น**

ใช้ [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) ควบคุมการวางแนวของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` ไปจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, และ `270` จากล่างขึ้นบน รองรับมุมแบบเศษส่วน มุมที่อยู่นอกช่วง `[0, 360)` จะปรับเป็นรอบหนึ่ง เช่น `-45` กลายเป็น `315` และ `360` กลายเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีจุดหยุดสีแดง, เขียว, และน้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน การขนาดแบบสเกลปิดเพื่อให้เปรียบเทียบมุมโดยไม่พิจารณาสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **สเกลไล่ระดับเชิงเส้นตามรูปร่าง**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) รับค่า [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). ตั้งค่าเป็น `False` ชัดเจนเพื่อคงมุมไล่ระดับเชิงเรขาคณิตเมื่อตัวรูปเปลี่ยนสัดส่วน, หรือเป็น `True` เพื่อสเกลไล่ระดับตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกล มุมที่มองเห็นอาจต่างจากมุมที่กำหนดบนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดหยุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False`; คอลัมน์ขวาใช้ `True`. แต่ละคอลัมน์มีสี่เหลี่ยมกว้างเหนือสี่เหลี่ยมสูง ทั้งสองเริ่มด้วยขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่ระดับ

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ผลลัพธ์ใน PowerPoint, โดยปิดการสเกลทางซ้ายและเปิดการสเกลทางขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่ระดับ 45 องศา, เปรียบเทียบ LinearGradientScaled False ทางซ้ายกับ True ทางขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด แถบสีแนวทแยงมุมคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อสเกลเปิด แถบสียืดตามสัดส่วนของรูปร่าง นี้ช่วยทำซ้ำไล่ระดับของเทมเพลตเมื่อต้องปรับรูปร่างให้มีขนาดต่างกัน หากเป็นสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่ระดับ `45` องศานี้

ทั้งมุมและการตั้งค่าสเกลใช้กับไล่ระดับเชิงเส้นเท่านั้น ไม่ควบคุมการเติม [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/)

### **รวมมุมกับทิศทางไล่ระดับ**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) เลือกสไตล์ไล่ระดับจากคลาส [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); ไม่ใช่ตัวแทนของมุมเชิงตัวเลข สำหรับไล่ระดับเชิงเส้น สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). คงทิศทางไว้เมื่อตรวจเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันในลำดับตรงกันข้าม สี่เหลี่ยมทั้งสองมีลักษณะเดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่เปลี่ยนผลลัพธ์

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **เติมแบบลาย**

การเติมแบบลายใช้การออกแบบสองสี เช่น จุด, ลายทาง, หรือช่องตาราง ตัวอย่างนี้ใช้ [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) เพื่อเลือกลาย trellis [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) ให้พื้นหลังสีเทาอ่อน, และ [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) ให้สีเหลืองสำหรับลาย

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **เติมรูปภาพ**

การเติมรูปภาพใช้รูปภาพภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพในเครื่องและใช้ [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) โหลดเข้าสู่คอลเลกชันรูปภาพของงานนำเสนอ การตั้งค่า [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) เป็นโหมดต่อ (tiled) จะทำซ้ำรูปภาพภายในสี่เหลี่ยม รูปภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปดอกบัว](lotus.png)

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

![รูปร่างที่มีการเติมรูปภาพ](picture-fill.png)

### **ทำภาพเป็นเทกเจอร์แบบต่อ**

หากต้องการตั้งค่าภาพต่อเป็นเทกเจอร์และปรับพฤติกรรมการต่อ สามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมรูปภาพ — `Tile` หรือ `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุตำแหน่งการจัดวางของไทล์ภายในรูปร่าง.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่ามีการกลับด้านไทล์ในแนวนอน แนวตั้ง หรือทั้งสองแบบ.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าการชิดแนวนอนของไทล์ (เป็นจุด) จากจุดกำเนิดของรูปร่าง.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าการชิดแนวตั้งของไทล์ (เป็นจุด) จากจุดกำเนิดของรูปร่าง.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์.

ตัวอย่างนี้ต้องการรูปภาพในเครื่องและกำหนดค่า [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) ให้ทำซ้ำที่ขนาด 50% ของขนาดต้นค่า การชิด `‑32` จุดทำให้ไทล์เลื่อนแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการกลับด้านในสองทิศทางกำหนดวิธีจัดเรียงเทกเจอร์ซ้ำ

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

![ตัวเลือกการต่อไทล์](tile-options.png)

## **เติมสีทึบ**

การเติมสีทึบให้รูปร่างสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ตั้งค่าโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) จากนั้นบันทึกสี่เหลี่ยมในงานนำเสนอ

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังสไลด์เป็นการเติมสีของรูปร่าง**

ใช้ [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) เมื่อรูปร่างต้องการตรงกับพื้นหลังสไลด์ เช่น ในเทมเพลตการนำเสนอ ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อกำหนดเป็น [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ก่อนเพื่อลบการเติมสีที่กำหนดอย่างชัดเจน ด้วยการผสมนี้ รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมสีของสไตล์ การเปิดใช้งานแฟล็กนี้อย่างเดียวไม่ลบการเติมสีที่กำหนดไว้ก่อนหน้า

นี่ต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): การเติมพื้นหลังจะปกคลุมวัตถุที่อยู่เบื้องหลังรูปร่างด้วยพื้นที่พื้นหลังของสไลด์ที่สอดคล้องกัน, ในขณะที่ no fill ทำให้วัตถุเหล่านั้นมองเห็นได้ ไล่ระดับจะยังคงจัดแนวกับสไลด์โดยไม่เริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สไลด์สืบทอดและวางแถบสีชมพูอมแดงไว้ด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, สี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มอย่างชัดเจน

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // เพิ่มอ็อบเจกต์นี้ก่อนเพื่อให้ปรากฏอยู่ด้านหลังสี่เหลี่ยม.
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

    // ปิดการเติมพื้นหลังก่อนนำการเติมแบบกำหนดเองมาใช้.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **พื้นหลังเติม**, **ไม่มีการเติม**, และ **เติมแบบเฉพาะ**. แถบสีชมพูอมแดงถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![พื้นหลังเติม, ไม่มีการเติม, และเติมสีส้มเฉพาะเหนือแถบสีชมพูอมแดง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ปล่อยให้พื้นหลังของสไลด์และเลย์เอาต์ไม่มีการกำหนดเพื่อให้มาสเตอร์จัดให้

## **ตั้งค่าความโปร่งใส**

สำหรับการเติมสีทึบ ส่วน alpha ของสีควบคุมความทึบ: 0 คือโปร่งใสเต็มที่และ 255 คือทึบเต็มที่ ตัวอย่างนี้ใช้ค่า alpha 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมที่อยู่ด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

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

## **เพิ่มเอฟเฟกต์ขอบระดับ 3 มิติ**

ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) ให้รูปร่างมีความลึกและขอบแบบ bevel ตัวอย่างนี้สร้างเอลิปส์สีเขียวที่มีเส้นขอบสีส้ม ใช้ [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) ตั้งความลึกเป็น 4 จุด และใช้ bevel บนแบบวงกลมที่กว้างและสูง 6 จุดผ่าน [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). กล้องแบบออร์โธกราฟิกที่หันหน้าและแสงส่องสามจุดทำให้ bevel มองเห็นได้

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
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

![เอฟเฟกต์ขอบ 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างควบคุมด้วยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) กับมุมละติจูด, ลองจิจูด, และการหมุนรอบ 40°, 35°, และ 20° ตามลำดับ เลือกกล้องแบบ isometric ผ่าน [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) และแสงแบบสมดุลผ่าน [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์ขาวดำสำหรับรูปร่าง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ระบุว่ารูปร่างแต่ละรายการจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว‑ดำ ไม่ได้ทำให้โหมดขาว‑ดำเปิดโดยอัตโนมัติ และไม่ได้เปลี่ยนการเติมสี, เส้น, หรือการจัดรูปแบบอื่นของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ เช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีสีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับสีเดียว, `Color` คงสีปกติ, และ `Hidden` ไม่แสดงรูปร่างในโหมดขาว‑ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ตั้งค่าเป็น `Gray`. รูปร่างที่บันทึกคงการเติมสีส้มสำหรับการแสดงสีปกติและขอให้แอปพลิเคชันที่รองรับการแสดงขาว‑ดำใช้สีเทา:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติสี่เหลี่ยมคงการเติมสีส้มไว้ ในกระบวนการแสดงผลขาว‑ดำ มันใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray`. วิธีนี้ช่วยให้คุณคงสไลด์สีเต็มไว้ในขณะกำหนดลักษณะการแสดงผลที่แตกต่างสำหรับการพิมพ์, การดูตัวอย่าง, หรือกระบวนการอื่นที่เคารพการตั้งค่าแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) เพื่อคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวแทนสไลด์จากตัวแทนเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีตัวแทนเชื่อมต่อกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตัวแทนเลย์เอาต์ที่สอดคล้องจะไม่ถูกรีเซ็ต

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

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เพราะรูปภาพถูกจัดเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อให้สามารถจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง — การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่าสไตล์เป็นแบบเดียวกันและจัดกลุ่มรูปลักษณ์เหล่านั้นเชิงตรรกะ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่น ๆ ได้หรือไม่?**

ทำได้ การเก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์ .POTX เทมเพลต เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการ, แล้วนำการจัดรูปแบบกลับไปใช้ตามต้องการ.