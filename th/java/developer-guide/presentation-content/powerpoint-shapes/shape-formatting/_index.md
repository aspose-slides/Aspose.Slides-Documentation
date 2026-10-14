---
title: จัดรูปแบบรูปทรง PowerPoint ใน Java
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/java/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปทรงสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- การเรนเดอร์รูปทรงสีขาวดำ
- การเรนเดอร์รูปทรงสีเทา
- การหมุนรูปทรง
- เอฟเฟกต์บีเวิล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน Java ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมอย่างเต็มที่."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณสามารถจัดรูปแบบโดยแก้ไขหรือใช้เอฟเฟ็กต์กับโครงร่างของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมภายในของรูปทรงได้

![รูปแบบรูปทรง PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Java มีอินเทอร์เฟซและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [สไตล์เส้น](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) ของรูปทรง  
5. ตั้งค่าความหนาเส้น  
6. ตั้งค่า [สไตล์เส้นประ](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) ของเส้น  
7. ตั้งค่าสีเส้นสำหรับรูปทรง  
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ดต่อไปนี้แสดงวิธีการจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์จากคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปของประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยม
    shape.getFillFormat().setFillType(FillType.NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟ็กต์สเก็ตช์กับเส้นของรูปทรง**

เอฟเฟ็กต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนถูกวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) เพื่อเลือกค่าจากการนับจำนวนของ [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)  

โค้ด Java ต่อไปนี้แสดงวิธีการใช้เอฟเฟ็กต์ [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) , อ่านค่าที่กำหนดโดยชัดเจน, และลบเอฟเฟ็กต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปทรงและรูปแบบสเก็ตช์ของมัน.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปทรง.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // ลบเอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์หลัก, หรือสไลด์เค้าโครงได้ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), และอ่านค่า [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/) ค่าที่มีผลสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากสืบทอดเสร็จสิ้น:

```java
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

ต่อไปนี้คือตัวเลือกประเภทการเชื่อมต่อสามประเภท:

* กลม  
* มิตเตอร์  
* บีเวล  

โดยค่าเริ่มต้น PowerPoint จะเชื่อมเส้นสองเส้นที่มุม (เช่นที่มุมของรูปทรง) ด้วยการตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter**  

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

โค้ด Java ต่อไปนี้แสดงวิธีการสร้างสี่เหลี่ยมผืนผ้าสามรูป (ตามภาพด้านบน) ด้วยการตั้งค่า Miter, Bevel, และ Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสามอันของประเภท Rectangle
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละสี่เหลี่ยม
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // ตั้งค่าความกว้างเส้น
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // ตั้งค่าสไตล์การเชื่อมต่อ
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // เพิ่มข้อความลงในแต่ละสี่เหลี่ยม
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมสีอย่างต่อเนื่องลงในรูปทรง ตัวอย่างเช่น คุณสามารถเติมสีสองสีหรือมากกว่าซึ่งสีหนึ่งค่อย ๆ จางไปเป็นอีกสีหนึ่ง

ต่อไปนี้เป็นวิธีการเติมแบบไล่สีให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`  
5. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้โดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/)  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Ellipse
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีให้กับรูปวงรี
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งค่าทิศทางของไล่สี
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่สีสองจุด
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![วงรีที่มีการเติมไล่สี](gradient-fill.png)

หากไล่สีปรากฏแตกต่างในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [เลือกสไตล์การเรนเดอร์ไล่สี](/slides/th/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บไว้ในงานนำเสนอ

## **การเติมลาย**

ใน PowerPoint การเติมลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมแบบออกแบบสองสี เช่น จุด, เส้นกรี๊ด, ขีดทแยง, หรือ ตาราง ลงในรูปทรง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าและพื้นหลังของลาย  

Aspose.Slides มีรูปแบบลายที่เตรียมไว้มากกว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับงานนำเสนอ แม้เลือกลายที่เตรียมไว้แล้วคุณยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ  

ต่อไปนี้เป็นวิธีการเติมลายให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`  
5. เลือกสไตล์ลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า  
6. ตั้งค่า [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) ของลาย  
7. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) ของลาย  
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งค่าสไตล์ลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **การเติมภาพ**

ใน PowerPoint การเติมภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปทรง—โดยใช้ภาพเป็นพื้นหลังของรูปทรง  

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`  
5. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)  
6. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) จากภาพที่คุณต้องการใช้  
7. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`  
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีภาพดังนี้:

![รูปภาพดอกบัว](lotus.png)

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มไปยังทรัพยากรของงานนำเสนอ.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่าภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![รูปทรงที่เติมภาพ](picture-fill.png)

### **ตั้งค่าภาพแบบต่อกระเบื้องเป็นพื้นผิว**

หากคุณต้องการตั้งค่าภาพแบบต่อกระเบื้องเป็นพื้นผิวและปรับแต่งพฤติกรรมการต่อกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): กำหนดโหมดการเติมภาพ — either `Tile` หรือ `Stretch`  
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุตำแหน่งจัดแนวของกระเบื้องภายในรูปทรง  
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่างหรือไม่  
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าการออฟเซ็ตแนวนอนของกระเบื้อง (เป็นจุด) จากจุดกำเนิดของรูปทรง  
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าการออฟเซ็ตแนวตั้งของกระเบื้อง (เป็นจุด) จากจุดกำเนิดของรูปทรง  
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยม.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มไปยังทรัพยากรของงานนำเสนอ.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดค่าโหมดการเติมภาพและคุณสมบัติการต่อกระเบื้อง.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ตัวเลือกการต่อกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปทรงด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังแบบนี้จะถูกนำไปใช้โดยไม่มีไล่สี, พื้นผิว, หรือรูปแบบใด ๆ  

เพื่อเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`  
5. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // ตั้งค่าสีเติม.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่สี, รูปภาพ หรือพื้นผิวให้กับรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าโปร่งใสที่สูงทำให้รูปทรงดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน  

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าแอลฟ่าของสีที่ใช้สำหรับการเติม วิธีทำคือ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) เป็น `Solid`  
5. ใช้ `Color` เพื่อกำหนดสีที่มีค่าความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)  
6. บันทึกงานนำเสนอ  

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยมสีทึบ.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มออโต้เชปสี่เหลี่ยมใสเหนือรูปทรงสีทึบ.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งมีประโยชน์เมื่อคุณต้องการจัดตำแหน่งองค์ประกอบด้วยการหมุนเฉพาะ

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ  
5. บันทึกงานนำเสนอ  

```java
import com.aspose.slides.*;

// สร้างอ็อบเจกต์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงโดย 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวิล 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์บีเวิล 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)  

เพื่อเพิ่มเอฟเฟกต์บีเวิล 3 มิติให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. กำหนดค่าของ [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) เพื่อระบุการตั้งค่าบีเวิล  
5. บันทึกงานนำเสนอ  

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงลงในสไลด์.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์บีเวิล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์การหมุน 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)  

เพื่อใช้การหมุน 3 มิติให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ไปยังสไลด์  
4. ใช้ [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3 มิติ  
5. บันทึกงานนำเสนอ  

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์สีขาวดำสำหรับรูปทรง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ระบุว่ารูปทรงแต่ละอันจะแสดงผลอย่างไรเมื่อดูหรือประมวลผลในโหมดสีขาวดำ ไม่ได้เปิดโหมดสีขาวดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่น ๆ ในโหมดสีปกติ  

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับสีเดียว, `Color` คงสีปกติ, `Hidden` ไม่แสดงรูปทรงในโหมดสีขาวดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปทรง  

โค้ด Java ต่อไปนี้สร้างรูปทรงสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลสีขาวดำ:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // คงการเติมสีส้มในโหมดสี, แต่เรนเดอร์รูปทรงด้วยสีเทาในโหมดขาวดำ.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงสีส้มอยู่ ในขั้นตอนการแสดงผลสีขาวดำ จะใช้สีเทาเนื่องจากโหมดถูกตั้งเป็น `Gray` ซึ่งช่วยให้คุณคงสไลด์สีเต็มรูปแบบไว้ขณะกำหนดลักษณะต่าง ๆ สำหรับการพิมพ์, การลองดู, หรือขั้นตอนที่เคารพการตั้งค่าโหมดสีขาวดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ต่อไปนี้แสดงวิธีการรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) ให้กลับไปเป็นการตั้งค่าเริ่มต้น:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder บนเลเอาต์.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**  
มีผลเพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่เป็นส่วนนำเข้าที่ใช้พื้นที่มากที่สุด ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟ็กต์, และการไล่สีถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดอย่างน้อย

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจะจัดกลุ่มได้อย่างไร?**  
เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟ็กต์ ถ้าค่าทั้งหมดตรงกันให้ถือว่ามีสไตล์เดียวกันและจัดกลุ่มรูปทรงเหล่านั้น ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองไปยังไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**  
ได้ จัดเก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์ .POTX เมื่อสร้างงานนำเสนอใหม่เปิดเทมเพลตแล้วคัดลอกรูปทรงที่ต้องการและนำการจัดรูปแบบไปใช้ใหม่ที่จุดที่ต้องการ