---
title: จัดรูปแบบรูปร่าง PowerPoint ใน Java
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
- การเติมไล่สี
- การเติมลวดลาย
- การเติมด้วยรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- การหมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน Java ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสี และเอฟเฟกต์ต่าง ๆ Aspose.Slides for Java ให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งแสง การหมุน และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java มีอินเตอร์เฟซและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าที่ไม่มีการเติมสีด้วยเส้นขอบสีน้ำเงินแบบประตูกั้น [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) เลือกเส้นแบบหนา‑บางแบบรวม, ในขณะที่ [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ตั้งความกว้างเป็น 7 จุดและ [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) เลือกรูปแบบจุดประทัด

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

### **กำหนดรูปแบบจุดประทัดของเส้นที่กำหนดเอง**

ใช้ [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่สามารถให้ความยาวจุดและช่องว่างที่ต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนภาพเทคนิค การกำหนดรูปแบบจะทำให้สไตล์จุดประทัดเปลี่ยนเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)

รายการอาร์เรย์สลับระหว่างความยาวจุดและช่องว่าง โดยเริ่มจากจุด ทุกค่าเป็นหลายของความกว้างเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดจะสร้างจุด 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ค่าเป็นจำนวนเต็มที่ไม่เป็นลบเพื่อกำหนดส่วนจุด‑ช่องว่างที่สมบูรณ์ ตัวอย่างใช้ค่าบวกเพื่อให้ทุกจุดและช่องว่างมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวเท่ากันและหัวเส้นแบบแบน สามเส้นแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกที่สองเท่าของความกว้าง ทำให้จุดและช่องว่างเพิ่มเป็นสองเท่า เส้นที่ห้าเปลี่ยนจากรูปแบบกำหนดเองเป็นเส้นทึบ

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

    // เปลี่ยนเส้นสุดท้ายให้เป็นสไตล์ทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการกลับไปใช้สไตล์ประตูกั้นที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) ไปยัง [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามรูปแบบจุดประทัดกำหนดเอง เส้นกว้างกว่าด้วยรูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **กำหนดหัวเส้น**

ใช้ [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) เพื่อกำหนดจุดสิ้นสุดของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) มีสไตล์หัวเส้นสามแบบชัดเจน:

- `Flat`: เส้นหยุดที่จุดปลาย
- `Round`: หัวเส้นรูปครึ่งวงกลมต่อออกจากจุดปลีดโดยกว้างครึ่งหนึ่งของเส้น
- `Square`: หัวเส้นสี่เหลี่ยมต่อออกจากจุดปลีดโดยกว้างครึ่งหนึ่งของเส้น

คลาสยังมี `NotDefined` ซึ่งหมายถึงไม่มีการกำหนดสไตล์หัวเส้นอย่างชัดเจน

หัวเส้นต่างจากหัวลูกศรที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมที่ควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดการแสดงหัวลูกศรโดยใช้ [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) และ [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) เพื่อให้เปรียบเทียบเฉพาะรูปหัวเส้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่มีลักษณะเท่าเดิม ความกว้าง 20 จุด จากบนลงล่างใช้หัวเส้น Flat, Round, และ Square ตามลำดับ จุดปลายของเส้นทั้งสามมีพิกัดแนวนอนเดียวกัน; หัว Round และ Square ยืดออก 10 จุดเหนือจุดปลีด

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

![หัวเส้นแบน, โค้ง, และสี่เหลี่ยมบนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)

โค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสืบทอดจากธีม, สไลด์มาสเตอร์, หรือสไลด์เลเอาต์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) แล้วอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--) ค่าที่มีผลจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข ตัวอย่างนี้ต้องมีงานนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

สไตล์การเชื่อมต่อควบคุมว่าส่วนโครงร่างสองส่วนจะมาบรรจบกันที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมตัด

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำ 3 รูปที่มีเส้นขอบสีน้ำเงินกว้าง 15 จุด ใช้ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) เพื่อกำหนดค่ามิตเทอร์, เบเวล, และราวด์ของ [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) ตามลำดับเพื่อเปรียบเทียบการวาดมุม

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

### **จำกัดการเชื่อมต่อมิตเทอร์ที่มุมแหลม**

ใช้ [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) ร่วมกับ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ที่กำหนดเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) เพื่อตั้งค่าขีดจำกัดว่ามุมแหลมจะยืดออกได้ไกลเท่าใด

ขีดจำกัดเป็นอัตราส่วนของระยะระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตเทอร์สูงสุดเป็นแปดเท่าของความกว้างเส้น; ไม่ได้เป็นหน่วยพ้อยต์ หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบเบเวลที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นทำให้จุดแหลมคมขึ้น การตั้งค่านี้ส่งผลต่อการเชื่อมต่อมิตเทอร์เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลที่มองเห็นได้เมื่อมุมยังอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีที่มีเส้นขอบกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และสามเหลี่ยมขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้สัดส่วนความยาวมิตเทอร์ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำเบเวลที่ยอดซ้ายและรักษามุมแหลมขวาไว้

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

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ที่ซ้ายและ **miter limit 8** ที่ขวา

![ยอดที่เบเวลด้วยขีดจำกัดมิตเทอร์ 2 และยอดที่แหลมด้วยขีดจำกัดมิตเทอร์ 8 ใน PowerPoint](miter-limits.png)

## **เติมแบบไล่สี**

การเติมแบบไล่สีผสมสีทั่วทั้งรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) วิธี [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) จะวางสีที่ตำแหน่ง 0 และ 1 ซึ่งเป็นจุดเริ่มต้นและสิ้นสุดของไล่สี การลบสต็อปที่มีอยู่ก่อนหน้านี้ทำให้ใช้สองสีนี้เท่านั้น

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

![วงรีที่มีการเติมไล่สี](gradient-fill.png)

หากไล่สีแสดงแตกต่างในภาพที่ส่งออกเมื่อเทียบกับ PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์ได้โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บอยู่ในงานนำเสนอ

### **กำหนดมุมไล่สีเชิงเส้น**

ใช้ [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) เพื่อควบคุมทิศทางของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน สามารถใช้มุมเศษส่วนได้ มุมที่อยู่นอกช่วง `[0, 360)` จะถูกทำให้เป็นมุมภายในหนึ่งรอบ; ตัวอย่างเช่น `-45` จะเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีสต็อปรสีแดง, เขียว, น้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน การสเกลถูกปิดเพื่อให้มุมเปรียบเทียบได้โดยไม่คำนึงถึงสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาเป็น `0`, `45`, `90` ในแถวแรก, และ `135`, `180`, `270` ในแถวที่สอง

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

![ไล่สีเชิงเส้นที่ 0°, 45°, 90° ในแถวบน, และ 135°, 180°, 270° ในแถวล่าง](linear-gradient-angles.png)

### **ปรับสเกลไล่สีเชิงเส้นตามรูปร่าง**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) รับค่า [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) ตั้งเป็น `False` เพื่อคงมุมไล่สีเชิงเรขาคณิตเมื่อรูปเปลี่ยนสัดส่วน, หรือ `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกล มุมที่มองเห็นอาจแตกต่างจากมุมที่กำหนดเมื่อรูปร่างไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและสต็อปสีเดียวกันกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False`; คอลัมน์ขวาใช้ `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างอยู่เหนือสี่เหลี่ยมสูง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนแปลงความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่สี

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

ผลลัพธ์ใน PowerPoint, โดยสเกลปิดที่ซ้ายและเปิดที่ขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่สี 45°, เปรียบเทียบ LinearGradientScaled False ที่ซ้ายกับ True ที่ขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด แถบสีทแยงมุมคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อสเกลเปิด แถบสีจะยืดตามสัดส่วนของรูปร่าง นี้ช่วยจำลองไล่สีของแม่แบบเมื่อปรับขนาดรูปร่างให้ต่างกัน บนสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่ทำให้ไล่สี 45° เปลี่ยนแปลง

ทั้งมุมและการตั้งค่าสเกลใช้กับไล่สีเชิงเส้นเท่านั้น ไม่ได้ควบคุมการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/)

### **รวมมุมกับทิศทางไล่สี**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) เลือกสไตล์ไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) ซึ่งไม่ใช่ตัวทดแทนของมุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดโดย [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) ให้คงทิศทางไว้เมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่สั่งลำดับกันตรงกันข้าม สี่เหลี่ยมสองรูปแสดงผลเหมือนกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

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

## **เติมแบบลวดลาย**

การเติมแบบลวดลายใช้การออกแบบสองสี เช่น จุด, เส้น, หรือสแครม ตัวอย่างนี้ใช้ [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) เพื่อเลือกลวดลาย trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) ให้พื้นหลังสีเทาอ่อน, และ [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) ให้สีเหลืองสำหรับลวดลาย

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

![สี่เหลี่ยมที่มีการเติมลวดลาย](pattern-fill.png)

## **เติมด้วยรูปภาพ**

การเติมด้วยรูปภาพใช้รูปภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพภายในเครื่องและใช้ [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) เพื่อโหลดเข้าคอลเล็กชันรูปภาพของงานนำเสนอ ตั้งค่า [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) เป็นโหมดซ้ำเพื่อทำซ้ำรูปภาพภายในสี่เหลี่ยม รูปภาพต้นแบบที่ใช้แสดงด้านล่าง:

![รูปภาพบัว lotus](lotus.png)

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

![รูปร่างที่มีการเติมด้วยรูปภาพ](picture-fill.png)

### **ทำรูปภาพเป็นลายเท็กซ์เจอร์แบบต่อภาพ**

หากต้องการตั้งค่ารูปภาพซ้ำเป็นเท็กซ์เจอร์และปรับพฤติกรรมการต่อภาพ สามารถใช้เมธอดต่อไปนี้ของอินเตอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งโหมดเติมรูปภาพ — `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): กำหนดการจัดตำแหน่งของไทล์ภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่าไทล์จะพลิกแนวนอน แนวตั้ง หรือทั้งสองด้าน
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าการเยื้องแนวนอนของไทล์ (เป็นจุด) จากจุดกำเนิดของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าการเยื้องแนวตั้งของไทล์ (เป็นจุด) จากจุดกำเนิดของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการรูปภาพในเครื่องและกำหนดให้ [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) ทำซ้ำที่ขนาด 50% ของขนาดต้นฉบับ การเยื้อง –32 จุดทำให้ไทล์เลื่อนแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกทั้งสองทิศกำหนดวิธีจัดเรียงเท็กซ์เจอร์ที่ทำซ้ำ

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

การเติมสีทึบให้รูปร่างสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อตั้งโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) แล้วบันทึกสี่เหลี่ยมลงในงานนำเสนอ

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

### **คัดลอสีพร้อมรักษาการอ้างอิงธีม**

ใช้ [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) เพื่อคัดลอกคำนิยามสี รวมถึงประเภทสี, การอ้างอิงธีม, และการแปลงค่า นี่เป็นประโยชน์เมื่อย้ายสีเติมระหว่างรูปร่างที่ควรยังคงอ้างอิงธีมของงานนำเสนอ เมธอดจะคัดลอกเฉพาะสี ไม่ได้คัดลอกประเภทการเติม, เส้นขอบ, หรือการจัดรูปแบบรูปร่างอื่น ๆ กำหนดประเภทการเติมของเป้าหมายโดยชัดเจนด้วย [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-)

ตัวอย่างนี้สร้างสี่เหลี่ยมสามรูปจากซ้ายไปขวา: แหล่งต้น, คัดลอกที่รักษาโครงสร้างธีม, และคัดลอกแบบ RGB คงที่ แหล่งต้นใช้ [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) เพื่ออ้างอิงสีแอคเซนต์แรกและเพิ่มการปรับสีผ่าน [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-) คัดลอกแบบ RGB ใช้สีเติมที่มีผลของแหล่งต้นจึงทั้งสามดูเหมือนเดิม การเรียกใช้ [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) จะตั้งค่า RGB คงที่และลบการแปลงสีที่มีอยู่

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

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

    // การอ้างอิงธีมจะตามสีแอคเซนต์ใหม่; ค่ RGB คงที่จะไม่เปลี่ยน.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

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

ก่อนการเปลี่ยนธีม ทั้งสามการเติมตรงกัน:

![แหล่งต้น, copyFrom ปลายทาง, และ RGB คงที่ที่มีการเติมสีน้ำเงินเดียวกัน](color-copy-before.png)

หลังการเปลี่ยนธีม แหล่งต้นและคัดลอกที่รักษาโครงสร้างธีมจะตามสีแอคเซนต์ใหม่และรักษาการปรับสีไว้ ส่วนคัดลอก RGB คงที่ยังคงเป็นสีน้ำเงิน:

![แหล่งต้นและ copyFrom ปลายทางที่มีการเติมสีส้ม, ในขณะที่ RGB คงที่ยังคงสีน้ำเงิน](color-copy-after.png)

คำนิยามที่คัดลอกเป็นอิสระจากแหล่งต้น การเปลี่ยนแปลงอ้างอิงธีมของแหล่งต้น, การกำหนดสีอื่น, หรือการเพิ่ม/ลบการแปลงจะไม่ส่งผลต่อปลายทาง การเปลี่ยนธีมยังคงมีผลต่อรูปร่างทั้งสองเพราะแต่ละรูปร่างอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX อีกครั้งจะคงประเภทสีที่คัดลอกจาก [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--), การอ้างอิงธีม, และคอลเล็กชันการแปลงจาก [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--) ไว้; ไม่ได้ทำให้คำนิยามแปรเป็น RGB

เมื่อคัดลอกจากบริบทธีมที่แตกต่าง เช่น งานนำเสนอที่มีพาเลตสีแอคเซนต์ต่างกัน การอ้างอิงที่คัดลอกจะถูกแก้ไขตามธีมของปลายทาง ดังนั้นการอ้างอิงและการแปลงเดียวกันอาจให้สีที่มองเห็นต่างกัน ดูที่ [Presentation Theme](/slides/th/java/presentation-theme/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการกำหนดสีธีม

## **ใช้พื้นหลังสไลด์เป็นการเติมสีของรูปร่าง**

ใช้ [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) เมื่อรูปร่างควรสอดคล้องกับพื้นหลังสไลด์ เช่น ในแม่แบบงานนำเสนอ ตั้งค่าประเภทการเติมด้วย [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) ไปเป็น [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ก่อนเพื่อทำให้การเติมที่กำหนดโดยชัดเจนหายไป ด้วยการผสมนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมจากสไตล์ของตัวเอง การเปิดค่าสถานะเพียงอย่างเดียวไม่ทำให้การเติมที่กำหนดโดยชัดหายไป

ซึ่งต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): การเติมพื้นหลังจะปิดบังวัตถุที่อยู่ด้านหลังรูปร่างด้วยพื้นที่ของพื้นหลังสไลด์, ส่วน NoFill จะทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่สีจะคงสัมพันธ์กับสไลด์แทนที่จะเริ่มใหม่ในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สืบทอดโดยสไลด์และวางแถบสีชมพูด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, และสี่เหลี่ยมขวาเปลี่ยนจากการเติมพื้นหลังเป็นการเติมสีส้มโดยกำหนดเอง

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // สืบทอดไล่สีจากมาสเตอร์.
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

    // เพิ่มอ็อบเจกต์นี้ก่อนเพื่อให้แสดงอยู่ด้านหลังสี่เหลี่ยม.
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
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมสีกำหนดเอง** แถบสีชมพูถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มกำหนดเองบนแถบสีชมพู](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลเอาต์ รูปร่างจะใช้พื้นหลังที่สไลด์แก้ไขแล้ว; ตัวอย่างนี้ปล่อยให้พื้นหลังของสไลด์และเลเอาต์เป็นไม่ได้กำหนดเพื่อให้มาสเตอร์จ่ายให้

## **กำหนดความโปร่งแสง**

สำหรับการเติมสีทึบ ค่าคอมโพเนนท์อัลฟาของสีควบคุมความทึบ: 0 คือโปร่งแสงเต็มที่และ 255 คือทึบเต็มที่ ตัวอย่างนี้ใช้ค่าระดับอัลฟา 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งแสงประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--)

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

![รูปร่างที่โปร่งแสง](shape-transparency.png)

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

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อให้รูปร่างมีความลึกและขอบบีเวล ตัวอย่างนี้สร้างวงรีสีเขียวที่มีเส้นขอบสีส้ม, ใช้ [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) ตั้งความลึกเป็น 4 จุด, แล้วใช้ [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) สร้างบีเวลบนรูปวงกลมที่มีความกว้างและความสูง 6 จุด กล้องออร์โธกราฟิกที่หันหน้าและแสงสามจุดทำให้บีเวลมองเห็น

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

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) ตั้งค่า latitude, longitude, และ revolution ตามลำดับที่ 40°, 35°, และ 20° เลือกกล้องแบบอิสเมตริกผ่าน [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) และแสงแบบสมดุลผ่าน [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

## **ควบคุมการเรนเดอร์สีขาว‑ดำสำหรับรูปร่าง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) กำหนดว่ารูปร่างแต่ละอันจะถูกเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ มันไม่ได้เปิดใช้งานการแสดงสีขาว‑ดำโดยอัตโนมัติและไม่ได้เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ เช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` รักษาสีปกติ, และ `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว‑ดำ `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ตั้งค่าเป็น `Gray` สี่เหลี่ยมที่บันทึกยังคงสีส้มสำหรับการแสดงสีปกติและร้องขอให้แอปพลิเคชันที่เคารพการตั้งค่าสีขาว‑ดำใช้สีเทา:

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

ในโหมดสีปกติ สี่เหลี่ยมยังคงสีส้ม ในกระบวนการแสดงผลสีขาว‑ดำ มันใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray` ทำให้คุณสามารถคงสไลด์สีเต็มได้ขณะกำหนดลักษณะเฉพาะสำหรับการพิมพ์, การดูตัวอย่าง, หรือกระบวนการอื่นที่เคารพการตั้งค่าสีขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) เพื่อคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวรหัสตำแหน่งในสไลด์จากตัวรหัสตำแหน่งในเลเอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีตัวรหัสตำแหน่งเชื่อมโยงกับเลเอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตัวรหัสตำแหน่งที่สอดคล้องกันในเลเอาต์จะไม่ถูกรีเซ็ต

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

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์ทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพจะถูกเก็บไว้ในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างในสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง — การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปร่างเหล่านั้นเชิงตรรกะ ซึ่งช่วยให้งานจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเก็บไว้ในไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่ต้องการ, แล้วนำการจัดรูปแบบไปใช้ใหม่ตามต้องการ.