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
- การเติมสีไล่สี
- การเติมลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- การหมุนรูปร่าง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint บน Android ด้วย Aspose.Slides—ตั้งค่าเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มรูปแบบ."
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นกรอบ, การเติมสี, และเอฟเฟกต์ต่าง ๆ Aspose.Slides for Android via Java ให้คุณควบคุมการตั้งค่าเหล่านี้โดยโปรแกรม รวมถึงความโปร่งแสง, การหมุน, และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java มีอินเทอร์เฟซและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกันกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) เพื่อควบคุมเส้นกรอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมไม่มีการเติมสีที่มีเส้นสีฟ้าขึ้นจุดประสาน ใช้ [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) เพื่อเลือกเส้นแบบ compound หนา-บาง, ในขณะที่ [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ตั้งความกว้างเป็น 7 จุด และ [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) เลือกรูปแบบจุดประสาน

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

### **กำหนดรูปแบบจุดประสานเส้นแบบกำหนดเอง**

ใช้ [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) เมื่อรูปแบบเส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างที่คุณต้องการ เช่น สำหรับเส้นขอบที่เป็นแบรนด์หรือแผนภาพเทคนิค การกำหนดลวดลายจะเปลี่ยนสไตล์จุดประสานอัตโนมัติเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/)

อาเรย์ในลำดับจะสลับระหว่างความยาวของเส้นและช่องว่างโดยเริ่มจากเส้น ความค่าแต่ละค่าคือหลายเท่าของความกว้างเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดจะให้เส้นยาว 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ค่าที่เป็นจำนวนจริง ไม่เป็นลบเพื่อกำหนดส่วนจุด-ช่องว่างที่สมบูรณ์ ตัวอย่างใช้ค่าบวกเพื่อให้ทุกจุดและช่องว่างมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีฟ้า 5 เส้นที่มีความยาวเท่ากันและปลายเส้นแบนสามเส้นแรกเปรียบเทียบลวดลายที่ความกว้าง 3 จุด เส้นที่สี่ทำสำเนาลวดลายแรกโดยความกว้างเท่ากับสองเท่า ทำให้ทั้งเส้นและช่องว่างยาวขึ้นสองเท่า เส้นที่ห้าสลับจากลวดลายกำหนดเองเป็นเส้นทึบ

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

    // คืนค่าเส้นสุดท้ายเป็นสไตล์ทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการกลับไปใช้สไตล์จุดประสานที่กำหนดไว้ล่วงหน้า ให้ส่ง [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) ไปยัง [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![สามรูปแบบจุดประสานกำหนดเอง, เส้นกว้างใช้รูปแบบแรก, และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **กำหนดปลายเส้น**

ใช้ [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) เพื่อกำหนดปลายของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) ให้สามสไตล์ปลายที่ชัดเจน:

- `Flat`: เส้นหยุดที่จุดปลาย
- `Round`: ปลายเส้นกึ่งวงกลมขยายออกนอกจุดปลายครึ่งความกว้างของเส้น
- `Square`: ปลายเส้นสี่เหลี่ยมขยายออกนอกจุดปลายครึ่งความกว้างของเส้น

คลาสยังมี `NotDefined` ซึ่งหมายความว่าไม่มีการกำหนดสไตล์ปลายอย่างชัดเจน

ปลายเส้นแตกต่างจากหัวศรที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดหัวศรด้วย [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) และ [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลาย

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกัน ความกว้าง 20 จุด จากบนลงล่างใช้ปลายแบน, กลม, และสี่เหลี่ยม ปลายของเส้นทั้งสามอยู่ที่พิกัดแนวนอนเดียวกัน; ปลายกลมและสี่เหลี่ยมขยายออกไป 10 จุดเหนือแต่ละปลาย

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

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**

![ปลายแบน, กลม, และสี่เหลี่ยมบนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นรูปร่างดูเหมือนวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดไว้โดยชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปร่าง หากการจัดรูปแบบเส้นได้รับการสืบทอดจากธีม, มาสเตอร์สไลด์, หรือเลเยาต์สไลด์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), และอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--) ค่าที่มีผลจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากที่การสืบทอดได้รับการแก้ไข ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

สไตล์การเชื่อมต่อกำหนดว่าจุดเชื่อมของเส้นสองส่วนมาพบกันอย่างไรที่มุม ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมคม, หรือ **Bevel** สำหรับมุมตัดเรียบ

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามแผ่นที่มีเส้นขอบสีน้ำเงินกว้าง 15 จุด ใช้ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) เพื่อกำหนดค่าของ [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) เป็น miter, bevel, และ round ตามลำดับ เพื่อตรวจสอบการวาดมุม

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

### **จำกัดมุม Miter ที่มุมคม**

ใช้ [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) ร่วมกับ [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ที่ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมคมสามารถยืดออกได้

ขีดจำกัดเป็นอัตราส่วนของระยะทางระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตรเท่ากับแปดเท่าของความกว้างเส้น; ไม่ได้เป็นการวัดเป็นจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่กว่าจะทำให้จุดคมยิ่งขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลต่อการแสดงผลเมื่อมุมยังคงอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองอันที่มีเส้นขอบกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2`, ด้านขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตรต่อความกว้างเส้นประมาณ `4.12` ผลลัพธ์ PowerPoint จะ bevel ด้านซ้ายและคงมุมด้านขวาเดิม

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

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา

![มุม bevel ที่ขีดจำกัด 2 และมุมคมที่ขีดจำกัด 8 ใน PowerPoint](miter-limits.png)

## **การเติมสีไล่สี (Gradient Fill)**

การเติมสีไล่สีผสานสีต่าง ๆ บนอีลิปส์ ตัวอย่างนี้เติมอีลิปส์ด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--) วิธี [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) จะวางจุดหยุดสีที่ 0 และ 1 ซึ่งเป็นจุดเริ่มและสิ้นสุดของไล่สี การลบจุดหยุดที่มีอยู่เดิมทำให้ใช้สีสองสีนี้เท่านั้น

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

![อีลิปส์ที่มีการเติมไล่สี](gradient-fill.png)

หากไล่สีแสดงแตกต่างในภาพที่ส่งออกเมื่อเทียบกับ PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บไว้ในงานนำเสนอ

### **กำหนดมุมไล่สีเชิงเส้น**

ใช้ [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) เพื่อควบคุมทิศทางของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` วิ่งจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, และ `270` จากล่างขึ้นบน มุมที่เป็นเศษส่วนก็รองรับ มุมที่อยู่นอกช่วง `[0, 360)` จะทำให้เป็นหนึ่งรอบใหม่; ตัวอย่างเช่น `-45` จะกลายเป็น `315` และ `360` จะกลายเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกอันที่มีจุดหยุดสีแดง, เขียว, และน้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน ปิดการสเกลเพื่อให้มุมเปรียบเทียบได้โดยไม่พิจารณาอัตราส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, และ `90`; ในแถวที่สองคือ `135`, `180`, และ `270`

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

![ไล่สีเชิงเส้นที่ 0, 45, และ 90 องศาในแถวบน, และ 135, 180, และ 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่สีเชิงเส้นตามรูปร่าง**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) รับค่า [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) ตั้งค่าเป็น `False` อย่างชัดเจนเพื่อให้มุมไล่สีเชิงเรขาคณิตคงที่เมื่อรูปร่างเปลี่ยนสัดส่วน, หรือเป็น `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกล มุมที่มองเห็นอาจแตกต่างจากมุมที่กำหนดบนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดหยุดสีเดียวกันกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งค่าเป็น `False`; คอลัมน์ขวาตั้งค่าเป็น `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมยาวด้านล่าง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดอย่างไรโดยไม่ต้องเปลี่ยนการตั้งค่าไล่สี

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

ผลลัพธ์ใน PowerPoint, โดยปิดสเกลทางซ้ายและเปิดสเกลทางขวา:

![สี่เหลี่ยมกว้างและยาวที่มีไล่สี 45 องศา, เปรียบเทียบ LinearGradientScaled False ทางซ้ายกับ True ทางขวา](linear-gradient-scaling.png)

เมื่อปิดสเกล แถบสีทแยงมุมจะคงทิศทางเดิมในสี่เหลี่ยมทั้งสอง เมื่อเปิดสเกล แถบสีจะยืดตามสัดส่วนของรูปร่าง นี้ช่วยให้คัดลอกไล่สีของแม่แบบเมื่อนำรูปร่างไปใช้กับขนาดอื่น ๆ บนสี่เหลี่ยมจัตุรัส การเปิดสเกลบนสี่เหลี่ยมจัตุรัสจะไม่เปลี่ยนลักษณะของไล่สี `45` องศานี้

ทั้งมุมและการตั้งค่าสเกลใช้กับไล่สีเชิงเส้นเท่านั้น ไม่ได้ควบคุมการเติมสี [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)

### **ผสานมุมกับทิศทางไล่สี**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) เลือกสไตล์ไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/) ไม่ใช่การทดแทนมุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดด้วย [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) ให้คงทิศทางเดิมเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่สั่งลำดับกันสลับกัน สี่เหลี่ยมสองอันจะแสดงผลเหมือนกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

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

## **การเติมลาย (Pattern Fill)**

การเติมลายใช้การออกแบบสองสี เช่น จุด, แถบ, หรือหมากกระดาน ตัวอย่างนี้ใช้ [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) เพื่อเลือกลายแบบ trellis. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) ให้พื้นหลังสีเทาอ่อน, และ [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) ให้สีเหลืองสำหรับลาย

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

![สี่เหลี่ยมที่เติมลาย](pattern-fill.png)

## **การเติมภาพ (Picture Fill)**

การเติมภาพใช้รูปภาพภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพท้องถิ่นและใช้ [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) เพื่อโหลดเข้าสู่คอลเล็กชันภาพของงานนำเสนอ ตั้งค่า [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) เป็นโหมดต่อภาพทำให้ภาพซ้ำภายในสี่เหลี่ยม รูปภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปโลตัส](lotus.png)

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

![รูปร่างที่เติมภาพ](picture-fill.png)

### **ทำภาพต่อเป็นพื้นผิว (Tile Picture As Texture)**

หากต้องการตั้งค่าภาพต่อเป็นพื้นผิวและปรับพฤติกรรมการต่อ คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): กำหนดการจัดตำแหน่งของภาพต่อภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่าภาพต่อจะพลิกแนวนอน, แนวตั้ง, หรือทั้งสองทิศ
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งตำแหน่งชิดแนวนอนของภาพต่อ (เป็นจุด) จากจุดกำเนิดของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งตำแหน่งชิดแนวตั้งของภาพต่อ (เป็นจุด) จากจุดกำเนิดของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของภาพต่อเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของภาพต่อเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการรูปภาพท้องถิ่นและกำหนดค่า [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) ให้ทำซ้ำที่ขนาด 50 % ของขนาดต้นค่า การชิดตำแหน่ง `−32` จุดทำให้ภาพต่อชิดแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกทั้งสองทิศกำหนดวิธีจัดเรียงเท็กซ์เจอร์ที่ทำซ้ำ

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

![ตัวเลือกการต่อภาพ](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบให้รูปร่างสีเดียวเดียว ตัวอย่างนี้ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) เพื่อเลือกโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) แล้วบันทึกสี่เหลี่ยมในงานนำเสนอ

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

## **ใช้พื้นหลังสไลด์เป็นการเติมสีรูปร่าง**

ใช้ [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ เช่น ในแม่แบบงานนำเสนอ ใช้ [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) ร่วมกับ [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) ก่อนเพื่อถอนการกำหนดการเติมแบบชัดเจน ด้วยการผสมนี้ รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมแบบสไตล์ของมันเอง การเปิดค่าสถานะนี้เพียงอย่างเดียวไม่ทำให้การเติมแบบชัดเจนที่มีอยู่ถูกลบ

สิ่งนี้แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): การเติมพื้นหลังจะปกคลุมวัตถุที่อยู่ด้านหลังรูปร่างด้วยพื้นที่พื้นหลังสไลด์ที่สอดคล้องกัน, ส่วน NoFill จะทำให้วัตถุเหล่านั้นยังคงมองเห็นได้ การไล่สีจะยังคงจัดแนวกับสไลด์แทนการเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สไลด์สืบทอดและวางแถบสีมะสีแดงด้านหลังสี่เหลี่ยมสามอัน สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, สี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มแบบชัดเจน

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // เพิ่มวัตถุนี้ก่อนเพื่อให้มันอยู่ด้านหลังสี่เหลี่ยม.
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

    // ปิดการเติมพื้นหลังก่อนที่จะกำหนดการเติมที่ชัดเจน.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมแบบชัดเจน** แถบมะสีแดงถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มแบบชัดเจนเหนือแถบมะสีแดง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างจะใช้พื้นหลังที่สไลด์กำหนดแล้ว; ตัวอย่างนี้ปล่อยให้พื้นหลังของสไลด์และเลย์เอาต์ไม่กำหนดเพื่อให้มาสเตอร์จัดหาให้

## **ตั้งค่าความโปร่งแสง**

สำหรับการเติมสีทึบ, ค่าอัลฟาของสีควบคุมความทึบ: 0 คือโปร่งแสงเต็ม, 255 คือทึบเต็ม ตัวอย่างนี้ใช้ค่าอัลฟา 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งแสงประมาณ 50 % เพื่อให้สี่เหลี่ยมด้านล่างยังคงมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)

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

![รูปร่างที่โปร่งแสง](shape-transparency.png)

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

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อให้รูปร่างมีความลึกและขอบ bevel ตัวอย่างนี้สร้างอีลิปส์สีเขียวด้วยเส้นขอบส้ม, ใช้ [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ตั้งความลึกเป็น 4 จุด, และใช้ [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) เพื่อสร้าง bevel ด้านบนเป็นวงกลมที่กว้างและสูง 6 จุด กล้องออร์โธกราฟิกที่หันหน้าและแสงสามจุดทำให้ bevel ปรากฏ

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

![เอฟเฟกต์ Bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

การมองเห็น 3 มิติของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) ด้วยมุมละติจูด, ลองจิจูด, และการหมุนรอบ 40°, 35°, และ 20° ตามลำดับ เลือกกล้องแบบอิซอเมตริกผ่าน [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) และแสงสมดุลผ่าน [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

## **ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปร่าง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ระบุว่ารูปร่างแต่ละอันจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงสีขาว-ดำโดยอัตโนมัติและไม่ได้เปลี่ยนการเติมสี, เส้น, หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับเป็นสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) เพื่อเลือกสีเทา รูปร่างที่บันทึกจะคงสีส้มสำหรับการแสดงสีปกติและขอสีเทาจากแอปพลิเคชันที่เคารพการตั้งค่าแสดงสีขาว-ดำ

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

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในขั้นตอนการทำงานที่แสดงผลสีขาว-ดำ มันจะใช้สีเทาเพราะโหมดถูกตั้งเป็น `Gray` นี้ช่วยให้คุณเก็บสไลด์สีเต็มไว้ขณะกำหนดลักษณะเฉพาะสำหรับการพิมพ์, การดูตัวอย่าง, หรืองานอื่น ๆ ที่เคารพการตั้งค่าแสดงสีขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) เพื่อกู้คืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตารางตำแหน่งของสไลด์จากตารางตำแหน่งของเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องการงานนำเสนอที่มีตารางตำแหน่งเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตารางตำแหน่งของเลย์เอาต์ที่สอดคล้องกันจะไม่ได้รับการรีเซ็ต

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

**การจัดรูปแบบรูปร่างส่งผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์มักเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังไว้ การเติมภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกจัดเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่ารูปร่างมีสไตล์เดียวกันและจัดกลุ่มตามตรรกะ ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างพร้อมสไตล์ที่ต้องการในสไลด์แม่แบบหรือไฟล์ .POTX จากนั้นเมื่อสร้างงานนำเสนอใหม่ ให้เปิดแม่แบบ, คัดลองรูปร่างที่สไตล์ต้องการ, และนำการจัดรูปแบบไปใช้ใหม่ตามต้องการ.