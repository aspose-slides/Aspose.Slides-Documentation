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
- การเติมไล่ระดับสี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- หมุนรูปทรง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน Java ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบของพวกมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงได้โดยกำหนดการตั้งค่าที่ควบคุมการเติมภายในของรูปทรง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/java/com.aspose.slides/linestyle/) ของรูปทรง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/java/com.aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปของประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยม.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนถูกวาดด้วยมือ ใช้ [IShape.getLineFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat.setSketchType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/java/com.aspose.slides/linesketchtype/)

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/java/com.aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยตรง และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/java/com.aspose.slides/linesketchtype/):

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

ค่าที่ [ISketchFormat.getSketchType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isketchformat/) คืนกลับมาจะแสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม ไมสเตอร์สไลด์ หรือเลเอาต์สไลด์ ให้ใช้ [ILineFormat.getEffective](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilineformat/), เข้าถึง [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilineformateffectivedata/), และอ่าน [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/th/java/com.aspose.slides/isketchformateffectivedata/) ค่าที่มีผลจะแสดงการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข:

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

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า **Round** เมื่อเชื่อมต่อสองเส้นที่มุม (เช่นที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter** แทน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

โค้ด Java ด้านล่างนี้แสดงวิธีที่สร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่าเชื่อมต่อ Miter, Bevel, และ Round:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสามรูปแบบประเภท Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปสี่เหลี่ยม.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // ตั้งความกว้างของเส้น.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
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

## **การเติมแบบไล่ระดับสี**

ใน PowerPoint การเติมแบบไล่ระดับสีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณนำการผสมสีต่อเนื่องมาประยุกต์ใช้กับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่าซึ่งสีหนึ่งค่อย ๆ จางลงสู่สีอื่น

วิธีการเติมแบบไล่ระดับสีให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. ใช้วิธี `add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/igradientformat/) เพื่อเพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนด
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้แสดงวิธีประยุกต์ใช้เอฟเฟกต์การเติมแบบไล่ระดับสีให้กับวงรี:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่ระดับสีกับวงรี.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งค่าทิศทางของไล่ระดับสี.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดไล่ระดับสีสองจุด.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมแบบไล่ระดับสี](gradient-fill.png)

## **การเติมแบบลวดลาย**

ใน PowerPoint การเติมแบบลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมการออกแบบสองสี—เช่น จุด, ลายเส้น, แนวตาข่าย หรือการตรวจสอบ—บนรูปทรง คุณสามารถเลือกสีสำหรับพื้นหน้าและพื้นหลังของลวดลายได้ตามต้องการ

Aspose.Slides มีสไตล์ลวดลายที่กำหนดไว้ล่วงหน้า มากกว่า 45 แบบ ที่คุณสามารถนำไปใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับงานนำเสนอของคุณ แม้ว่าคุณจะเลือกลวดลายที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่แน่นอนที่ลวดลายควรใช้ได้

วิธีการเติมแบบลวดลายให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/patternformat/#getBackColor--) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/patternformat/#getForeColor--) ของลวดลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ด้านล่างนี้แสดงวิธีเติมแบบลวดลายให้กับสี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่า FillType เป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งค่าสไตล์ลวดลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้า ของลวดลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมแบบลวดลาย](pattern-fill.png)

## **การเติมด้วยรูปภาพ**

ใน PowerPoint การเติมด้วยรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกภาพภายในรูปทรง—โดยใช้ภาพเป็นพื้นหลังของรูปทรงนั้น

วิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่คุณต้องการอื่น)
1. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) จากภาพที่ต้องการใช้
1. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่ามีไฟล์ "lotus.png" ที่มีภาพดังนี้:

![ภาพดอกบัว](lotus.png)

โค้ด Java ต่อไปนี้แสดงวิธีเติมรูปภาพลงในรูปทรง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่า FillType เป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
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

![รูปทรงที่เติมด้วยรูปภาพ](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งรูปภาพแบบต่อแถวเป็นพื้นผิวและปรับแต่งการจัดเรียงแบบต่อแถว คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุตำแหน่งการจัดเรียงของแผ่นต่อแถวภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่าภาพต่อแถวจะกลับด้านในแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าการเยื้องแนวนอนของแผ่นต่อแถว (หน่วย points) จากจุดกำเนิดของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าการเยื้องแนวตั้งของแผ่นต่อแถว (หน่วย points) จากจุดกำเนิดของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของแผ่นต่อแถวเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของแผ่นต่อแถวเป็นเปอร์เซ็นต์

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมที่มีการเติมรูปภาพแบบต่อแถวและกำหนดตัวเลือกการต่อแถว:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยม.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่า FillType ของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดโหมดการเติมรูปภาพและคุณสมบัติการต่อแถว.
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

![ตัวเลือกการต่อแถว](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปทรงด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังเรียบนี้ถูกใช้โดยไม่มีการไล่ระดับ สีเทกเจอร์ หรือลวดลายใด ๆ

วิธีการเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ด้านล่างนี้แสดงวิธีเติมสีทึบให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
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

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่ระดับสี, รูปภาพ หรือพื้นผิว คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าความโปร่งใสสูงจะทำให้รูปทรงดูโปร่งใสมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างสามารถมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ในสีที่ใช้สำหรับการเติม วิธีการทำมีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีพร้อมความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

โค้ด Java ต่อไปนี้แสดงวิธีเติมสีโปร่งใสให้กับสี่เหลี่ยม:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยมทึบ.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มออโต้เชปสี่เหลี่ยมโปร่งใสเหนือรูปทรงทึบ.
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

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือการออกแบบที่เฉพาะเจาะจง

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

โค้ด Java ด้านล่างนี้แสดงวิธีหมุนรูปทรงด้วยมุม 5 ดีกรี:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงด้วยมุม 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์ bevel 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/) ของรูปทรง

เพื่อเพิ่มเอฟเฟกต์ bevel 3 มิติให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่า bevel
1. บันทึกการนำเสนอ

โค้ด Java ด้านล่างนี้แสดงวิธีใช้เอฟเฟกต์ bevel 3 มิติบนรูปทรง:

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

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์ bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/) ของรูปทรง

เพื่อประยุกต์ใช้การหมุน 3 มิติบนรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) .
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/java/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกการนำเสนอ

โค้ด Java ด้านล่างนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรง:

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

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ด้านล่างนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/) ให้กลับไปเป็นค่าดีฟอลต์:

```java
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

**การจัดรูปแบบรูปทรงส่งผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบมีเพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์, และการไล่ระดับสีจะถูกบันทึกเป็นเมตาดาต้าและไม่เพิ่มขนาดไฟล์อย่างมีนัยสำคัญ

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้นิยามสไตล์ของพวกมันว่าเป็นแบบเดียวกันและจัดกลุ่มรูปทรงเหล่านั้นอย่างเป็นตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการไว้ในสไลด์เทมเพลตหรือไฟล์ .POTX จากนั้นเมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ต้องการ, แล้วนำการจัดรูปแบบเหล่านั้นไปใช้ที่ต้องการในงานนำเสนอใหม่.