---
title: ฟอร์แมตรูปทรง PowerPoint บน Android
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/androidjava/shape-formatting/
keywords:
- จัดรูปทรง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปทรงสเก็ตช์
- จัดสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลาย
- การเติมรูปภาพ
- การเติมเท็กซ์เจอร์
- การเติมสีทึบ
- ความโปร่งแสงของรูปทรง
- การแสดงผลรูปทรงขาวดำ
- การแสดงผลรูปทรงระดับสีเทา
- หมุนรูปทรง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการจัดรูปแบบรูปทรง PowerPoint บน Android ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้นและเอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบโดยการแก้ไขหรือใช้เอฟเฟ็กต์กับโครงร่างของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมภายในของรูปทรง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linestyle/) ของรูปทรง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปทรง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // ลบการเติมจากรูปทรงสี่เหลี่ยมเพื่อให้เห็นเฉพาะเส้นของมัน
    shape.getFillFormat().setFillType(FillType.NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นรูปทรงดูเหมือนถูกวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/)

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยเจตนา และลบเอฟเฟกต์โดยใช้ [LineSketchType.None](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงฟอร์แมตเส้นของรูปทรงและฟอร์แมตสเก็ตช์ของมัน.
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

ค่าที่คืนจาก [ISketchFormat.getSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformat/), เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformateffectivedata/), และอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformateffectivedata/). ค่าที่มีผลสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดได้รับการแก้ไขแล้ว:

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

## **กำหนดสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกของประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

โดยค่าเริ่มต้นเมื่อ PowerPoint เชื่อมต่อสองเส้นที่มุม (เช่นที่มุมของรูปทรง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter** 

![The join style in the presentation](join-style-powerpoint.png)

โค้ด Java ต่อไปนี้แสดงวิธีที่สามสี่เหลี่ยมผืนผ้า (ตามภาพด้านบน) ถูกสร้างโดยใช้การตั้งค่าเชื่อมต่อ Miter, Bevel, และ Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติสามรูปประเภท Rectangle
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปสี่เหลี่ยมแต่ละรูป
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // ตั้งค่าความกว้างของเส้น
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของรูปสี่เหลี่ยมแต่ละรูป
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

    // เพิ่มข้อความให้กับรูปสี่เหลี่ยมแต่ละรูป
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมสีไล่ระดับ**

ใน PowerPoint การเติมสีไล่ระดับเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การผสมสีต่อเนื่องบนรูปทรง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยให้สีหนึ่งค่อยๆ จางลงสู่สีอื่น

วิธีการเติมสีไล่ระดับให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. ใช้วิธี `add` ของคอลเลคชัน gradient stop ที่โด้นโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igradientformat/) เพื่อเพิ่มสีที่ต้องการสองสีพร้อมตำแหน่งที่กำหนด
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การเติมสีไล่ระดับบนรูปรี:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Ellipse
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบแบบไล่ระดับสีกับรูปรี
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งค่าทิศทางของการไล่ระดับสี
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่ระดับสีสองจุด
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

## **การเติมลาย**

ใน PowerPoint การเติมลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, ลายขั้น, ขีดไขว้ หรือเช็ก—บนรูปทรง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าลายและพื้นหลัง

Aspose.Slides มีรูปแบบลายที่กำหนดล่วงหน้าเกิน 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับงานนำเสนอ แม้หลังจากเลือกลายที่กำหนดล่วงหน้าแล้ว คุณยังสามารถระบุสีที่ต้องการให้ใช้ได้

วิธีการเติมลายให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกรูปแบบลายจากตัวเลือกที่กำหนดล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getBackColor--) ของลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getForeColor--) ของลาย
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้แสดงวิธีใช้การเติมลายบนสี่เหลี่ยมผืนผ้า:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าแบบเติมเป็น Pattern
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งค่าสไตล์ลาย
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าสีพื้นหลังและพื้นหน้าของลาย
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกภาพภายในรูปทรง—โดยใช้ภาพเป็นพื้นหลังของรูปทรง

วิธีใช้ Aspose.Slides เพื่อเติมรูปภาพลงในรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)
1. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) จากภาพที่ต้องการใช้
1. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติเรามีไฟล์ "lotus.png" ที่มีรูปภาพดังนี้:

![The lotus picture](lotus.png)

โค้ด Java ต่อไปนี้แสดงวิธีเติมรูปภาพลงในรูปทรง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าแบบเติมเป็น Picture
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพ
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **วางภาพแบบเรียงเป็นลายพื้นฐาน**

หากต้องการตั้งค่าภาพแบบเรียงเป็นเท็กซ์เจอร์และปรับพฤติกรรมการเรียง สามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุตำแหน่งการจัดแนวของไทล์ภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมการพลิกไทล์แนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าออฟเซ็ตแนวนอนของไทล์ (หน่วยจุด) จากจุดกำเนิดของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าออฟเซ็ตแนวตั้งของไทล์ (หน่วยจุด) จากจุดกำเนิดของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมพร้อมการเติมรูปภาพแบบเรียงและกำหนดตัวเลือกไทล์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติรูปสี่เหลี่ยมผืนผ้า
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // ตั้งค่าโหมดการเติมรูปภาพและคุณสมบัติการทำลายรูปแบบไทล์
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The tile options](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่ทำให้รูปทรงเต็มด้วยสีเดียว สีพื้นหลังที่เรียบนี้จะไม่มีการไล่สี, เท็กซ์เจอร์ หรือรูปแบบลายใดๆ

เพื่อเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้แสดงวิธีเติมสีทึบบนสี่เหลี่ยมในสไลด์ PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid
    shape.getFillFormat().setFillType(FillType.Solid);

    // ตั้งค่าสีเติม
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งแสง**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่ระดับ, รูปภาพ หรือเท็กซ์เจอร์ลงในรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งแสงเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งแสงที่สูงทำให้รูปทรงดูโปร่งแสงมากขึ้นและให้พื้นหลังหรือวัตถุด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณกำหนดระดับความโปร่งแสงโดยปรับค่า alpha ในสีที่ใช้เติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีพร้อมความโปร่งแสง (ส่วน `alpha` ควบคุมความโปร่งแสง)
1. บันทึกงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีเติมสีโปร่งแสงให้กับสี่เหลี่ยม:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติสี่เหลี่ยมผืนผ้าแบบทึบ
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปทรงอัตโนมัติสี่เหลี่ยมผืนผ้าทรงใสเหนือรูปทรงที่ทึบ
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพตามการจัดวางหรือความต้องการออกแบบเฉพาะ

เพื่อหมุนรูปทรงบนสไลด์ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีหมุนรูปทรงโดย 5 องศา:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงโดย 5 องศา
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์บีเวล 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวล 3 มิติบนรูปทรงทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/) ของรูปทรงเพื่อกำหนดการตั้งค่าบีเวล
1. บันทึกงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์บีเวล 3 มิติบนรูปทรง:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงลงในสไลด์
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติบนรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกงานนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรง:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาวดำสำหรับรูปทรง**

เมธอด [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) ระบุว่ารูปทรงแต่ละรูปควรถูกเรนเดอร์อย่างไรเมื่อทำการดูหรือประมวลผลงานนำเสนอในโหมดขาวดำ มันไม่ได้เปิดใช้งานการแสดงผลขาวดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่นของรูปทรงในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันที่ทำการเรนเดอร์ตัดสินใจแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปทรงในโหมดขาวดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปทรง

โค้ด Java ต่อไปนี้สร้างรูปทรงสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลขาวดำ:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // คงการเติมสีส้มในโหมดสี แต่แสดงรูปทรงด้วยสีเทาในโหมดขาวดำ.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงมีสีส้ม แต่ในกระบวนการแสดงผลขาวดำ มันจะใช้สีเทาเนื่องจากโหมดถูกตั้งเป็น `Gray` ทำให้คุณสามารถเก็บสไลด์สีเต็มไว้ในขณะกำหนดลักษณะการแสดงผลที่แตกต่างสำหรับการพิมพ์, ตัวอย่างก่อน, หรือกระบวนการอื่นที่เคารพการตั้งค่าการแสดงผลขาวดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

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

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบเล็กน้อยเท่านั้น รูปภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์และไล่ระดับจะถูกเก็บเป็นเมตาดาต้าและแทบไม่เพิ่มขนาดไฟล์เลย

**ฉันจะตรวจหารูปทรงบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้นและการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่ารูปแบบเหมือนกันและจัดกลุ่มรูปทรงเหล่านั้น ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปแบบตัวอย่างพร้อมสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลตนั้น, คัดลอกรูปทรงที่มีสไตล์ที่ต้องการ แล้วนำการจัดรูปแบบไปใช้ใหม่ตามที่ต้องการ