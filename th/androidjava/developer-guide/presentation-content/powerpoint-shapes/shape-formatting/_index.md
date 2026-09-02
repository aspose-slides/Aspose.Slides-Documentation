---
title: จัดรูปแบบรูปทรง PowerPoint บน Android
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/androidjava/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปทรงสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมแบบไล่สี
- การเติมแบบลวดลาย
- การเติมแบบภาพ
- การเติมแบบพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปทรง
- หมุนรูปทรง
- เอฟเฟกต์บีเวล 3D
- เอฟเฟ็กต์การหมุน 3D
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint บน Android ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้นและเอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP อย่างแม่นยำและควบคุมเต็มที่."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยปรับเปลี่ยนหรือใช้เอฟเฟกต์กับเส้นขอบของมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมสีภายในของรูปทรงได้

![รูปแบบรูปทรงใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java มีอินเทอร์เฟซและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปทรงได้โดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถกำหนดสไตล์เส้นแบบกำหนดเองสำหรับรูปทรงได้ ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [สไตล์เส้น](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linestyle/) ของรูปทรง
5. ตั้งความกว้างของเส้น
6. ตั้งค่า [สไตล์การขีด](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linedashstyle/) ของเส้น
7. ตั้งค่าสีเส้นสำหรับรูปทรง
8. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยม:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // กำหนดสีเติมให้กับรูปร่างสี่เหลี่ยม.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // กำหนดสีให้กับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในพรีเซนเทชัน](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนเขียนด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/)

โค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดอย่างชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปร่างและรูปแบบสเก็ตช์ของมัน.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // อ่านเอฟเฟ็กต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปร่าง.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // ลบเอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่ส่งคืนโดย [ISketchFormat.getSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformat/), เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformateffectivedata/), และอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isketchformateffectivedata/). ค่าที่มีผลจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดได้รับการแก้ไข:

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

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า **Round** เมื่อต่อสองเส้นที่มุม (เช่นที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการใช้ตัวเลือก **Miter** แทน

![สไตล์การเชื่อมต่อในพรีเซนเทชัน](join-style-powerpoint.png)

โค้ด Java ด้านล่างแสดงวิธีที่สร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่า Miter, Bevel, และ Round:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape สามรูปประเภท Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมให้กับแต่ละรูปสี่เหลี่ยม.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // ตั้งค่าความกว้างของเส้น.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีให้กับเส้นของแต่ละสี่เหลี่ยม.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // เพิ่มข้อความให้กับแต่ละสี่เหลี่ยม.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมแบบไล่สี (Gradient Fill)**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณสามารถใช้การผสมสีต่อเนื่องกับรูปทรงได้ ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่าที่สีหนึ่งค่อย ๆ จางหาไปยังอีกสีหนึ่ง

วิธีการใช้การเติมแบบไล่สีกับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
5. ใช้เมธอด `add` ของคอลเลกชันจุดหยุดไล่สีที่เปิดให้บริการโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igradientformat/) เพื่อเพิ่มสีที่ต้องการสองสีพร้อมกำหนดตำแหน่ง
6. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์การเติมแบบไล่สีกับวงรี:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับวงศรี.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งค่าทิศทางของไล่สี.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่สีสองจุด.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมแบบไล่สี](gradient-fill.png)

## **การเติมแบบลวดลาย (Pattern Fill)**

ใน PowerPoint การเติมแบบลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณสามารถใช้การออกแบบสองสี—เช่น จุด, ลายเส้น, ลายตะแกรง หรือรูปสี่เหลี่ยมจัตุรัส—กับรูปทรงได้ คุณสามารถเลือกสีพื้นหน้าต่างและสีพื้นหลังของลวดลายได้ตามต้องการ

Aspose.Slides มีลายแบบที่กำหนดไว้ล่วงหน้าเกิน 45 แบบ ที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับพรีเซนเทชัน แม้จะเลือกลายแบบที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ

วิธีการใช้การเติมแบบลวดลายกับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
5. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
6. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getBackColor--) ของลวดลาย
7. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getForeColor--) ของลวดลาย
8. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Java ด้านล่างแสดงวิธีใช้การเติมแบบลวดลายกับสี่เหลี่ยม:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่า FillType เป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งค่าสไตล์ลวดลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลวดลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลวดลาย](pattern-fill.png)

## **การเติมแบบภาพ (Picture Fill)**

ใน PowerPoint การเติมแบบภาพเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณแทรกรูปภาพเข้าไปในรูปทรง—โดยใช้รูปภาพเป็นพื้นหลังของรูปทรงนั้น

วิธีการใช้ Aspose.Slides เพื่อเติมรูปทรงด้วยภาพ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
5. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)
6. สร้างวัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) จากภาพที่ต้องการใช้
7. ส่งภาพนั้นไปยังเมธอด `ISlidesPicture.setImage`
8. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

สมมติว่ามีไฟล์ “lotus.png” พร้อมภาพต่อไปนี้:

![รูปภาพ lotus](lotus.png)

โค้ด Java ด้านล่างแสดงวิธีเติมรูปทรงด้วยภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่า FillType เป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของพรีเซนเทชัน.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมภาพ](picture-fill.png)

### **เติมภาพแบบ Tile เป็นพื้นผิว (Tile Picture As Texture)**

หากต้องการตั้งค่าภาพที่ทำเป็นลายกระเบื้องเป็นพื้นผิวและกำหนดพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): กำหนดการจัดตำแหน่งของกระเบื้องภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่ากระเบื้องจะถูกพลิกแนวนอน, แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าออฟเซ็ตแนวนอนของกระเบื้อง (หน่วยจุด) จากจุดเริ่มต้นของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าออฟเซ็ตแนวตั้งของกระเบื้อง (หน่วยจุด) จากจุดเริ่มต้นของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): นิยามสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): นิยามสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมที่เติมภาพแบบกระเบื้องและกำหนดตัวเลือกกระเบื้อง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่า FillType ของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มลงในทรัพยากรของพรีเซนเทชัน.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดโหมดการเติมภาพและคุณสมบัติการกระเบื้อง.
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

ผลลัพธ์:

![ตัวเลือกกระเบื้อง](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่ทำให้รูปทรงเต็มด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังแบบเรียบนี้จะไม่มีการไล่สี, พื้นผิว หรือรูปแบบใด ๆ

เพื่อเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
5. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
6. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Java ด้านล่างแสดงวิธีเติมสีทึบให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่า FillType เป็น Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // ตั้งค่าสีเติม.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งแสง (Set Transparency)**

ใน PowerPoint เมื่อคุณเติมสีทึบ, ไล่สี, ภาพ หรือพื้นผิวลงในรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งแสงเพื่อควบคุมความหนาแน่นของการเติม สีที่มีค่าความโปร่งแสงสูงจะทำให้รูปทรงดูโปร่งใสมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ใต้รูปทรงมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งแสงโดยปรับค่าอัลฟาของสีที่ใช้เติม นี่คือวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) เป็น `Solid`
5. ใช้ `Color` เพื่อกำหนดสีพร้อมค่าความโปร่งแสง (ส่วนประกอบ `alpha` ควบคุมความโปร่งแสง)
6. บันทึกพรีเซนเทชัน

โค้ด Java ด้านล่างแสดงวิธีเติมสีโปร่งแสงให้กับสี่เหลี่ยม:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape สี่เหลี่ยมสีททึบ.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่ม AutoShape สี่เหลี่ยมโปร่งใสเหนือรูปทรงสีททึบ.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่โปร่งแสง](shape-transparency.png)

## **การหมุนรูปทรง (Rotate Shapes)**

Aspose.Slides ทำให้คุณสามารถหมุนรูปทรงในพรีเซนเทชัน PowerPoint ได้ ซึ่งอาจเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบด้วยการจัดแนวหรือการออกแบบเฉพาะ

เพื่อหมุนรูปทรงบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ
5. บันทึกพรีเซนเทชัน

โค้ด Java ด้านล่างแสดงวิธีหมุนรูปทรงที่มุม 5 องศา:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรง 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3D (Add 3D Bevel Effects)**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์บีเวล 3D กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวล 3D ให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่าบีเวล
5. บันทึกพรีเซนเทชัน

โค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์บีเวล 3D กับรูปทรง:

```java
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

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D (Add 3D Rotation Effects)**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3D กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อใช้การหมุน 3D กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
4. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3D
5. บันทึกพรีเซนเทชัน

โค้ด Java ด้านล่างแสดงวิธีใช้เอฟเฟกต์การหมุน 3D กับรูปทรง:

```java
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

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder ในเลย์เอาต์.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์พรีเซนเทชันสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างน้อย รูปภาพและสื่อที่ฝังอยู่ใช้พื้นที่มากที่สุด ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์และไล่สีจะถูกเก็บเป็นเมทาดาต้าและไม่มีขนาดเพิ่มอย่างมีนัยสำคัญ

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้นและการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปทรงเหล่านั้นในเชิงตรรกะ ซึ่งทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในพรีเซนเทชันอื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปทรงตัวอย่างพร้อมสไตล์ที่ต้องการในชุดสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างพรีเซนเทชันใหม่ ให้เปิดเทมเพลต คัดลอกรูปทรงที่มีสไตล์ที่ต้องการ แล้วนำไปใช้กับวัตถุอื่นตามต้องการ.