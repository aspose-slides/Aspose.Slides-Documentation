---
title: จัดรูปแบบรูปทรง PowerPoint บน Android
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/androidjava/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีเดียว
- ความโปร่งใสของรูปทรง
- หมุนรูปทรง
- เอฟเฟกต์ Bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint บน Android ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับโครงร่างของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปทรงได้

![รูปแบบรูปทรงใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ Android ผ่าน Java มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint.

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้แสดงขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [line style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linestyle/) ของรูปทรง
1. กำหนดความกว้างของเส้น
1. กำหนด [dash style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/linedashstyle/) ของเส้น
1. กำหนดสีเส้นสำหรับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีการจัดรูปแบบ `AutoShape` แบบสี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Rectangle.
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

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในการนำเสนอ](formatted-lines.png)

## **จัดรูปแบบลักษณะการเชื่อมต่อ**

ต่อไปนี้เป็นตัวเลือกประเภทการเชื่อมต่อสามประเภท:

* โค้ง
* มิตเตอร์
* เบเวล

โดยค่าเริ่มต้นเมื่อ PowerPoint เชื่อมเส้นสองเส้นที่มุม (เช่น ที่มุมของรูปทรง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมแหลม คุณอาจต้องการตัวเลือก **Miter**.

![ลักษณะการเชื่อมต่อในการนำเสนอ](join-style-powerpoint.png)

โค้ด Java ต่อไปนี้แสดงว่ากสี่เหลี่ยมสามรูป (ตามรูปข้างบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel และ Round:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape จำนวนสามรูปแบบ Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยมแต่ละรูป.
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

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละรูป.
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

    // เพิ่มข้อความให้สี่เหลี่ยมแต่ละรูป.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมสีไล่ระดับ**

ใน PowerPoint, Gradient Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใส่การผสมสีต่อเนื่องลงในรูปทรง ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่านั้นโดยสีหนึ่งค่อยๆ จางลงเป็นสีอีกสีหนึ่ง

ต่อไปนี้คือวิธีการใช้ Gradient Fill กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. เพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้โดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igradientformat/)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบกรเดียนท์กับวงรี.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งทิศทางของกรเดียนท์.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดกรเดียนท์สองจุด.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมสีไล่ระดับ](gradient-fill.png)

## **การเติมลาย**

ใน PowerPoint, Pattern Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใส่ลายสองสี เช่น จุด, ลายเส้น, ลายเส้นตัดกัน หรือรูปสี่เหลี่ยมจัตุรัส ให้กับรูปทรง คุณสามารถเลือกสีที่กำหนดเองสำหรับสีพื้นหน้าและพื้นหลังของลายได้

Aspose.Slides มีลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปทรงเพื่อเพิ่มความสวยงามของการนำเสนอ แม้หลังจากเลือกลายที่กำหนดไว้แล้ว คุณยังคงสามารถระบุสีที่ต้องการให้ลายนั้นใช้ได้

ต่อไปนี้เป็นวิธีการใช้ Pattern Fill กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกสไตล์ลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
1. กำหนด [Background Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getBackColor--) ของลาย
1. กำหนด [Foreground Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/patternformat/#getForeColor--) ของลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งสไตล์ลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลาย](pattern-fill.png)

## **การเติมภาพ**

ใน PowerPoint, Picture Fill คือตัวเลือกการจัดรูปแบบที่อนุญาตให้คุณแทรกรูปภาพภายในรูปทรง โดยใช้รูปภาพเป็นพื้นหลังของรูปทรง

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมภาพในรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. กำหนดโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่คุณต้องการอื่น)
1. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) จากรูปภาพที่คุณต้องการใช้
1. ส่งรูปภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีรูปภาพต่อไปนี้:

![รูปภาพของดอกบัว](lotus.png)

โค้ด Java ต่อไปนี้แสดงวิธีเติมรูปทรงด้วยรูปภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรการนำเสนอ.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมภาพ](picture-fill.png)

### **การใช้รูปภาพเป็นพื้นผิวแบบต่อกัน**

หากคุณต้องการตั้งค่ารูปภาพแบบต่อต่อเป็นพื้นผิวและปรับแต่งการจัดเรียงแบบต่อ คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): กำหนดการจัดแนวของภาพต่อภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่าภาพต่อจะถูกพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): กำหนดค่าออฟเซ็ตแนวนอนของภาพต่อ (หน่วย points) จากจุดกำเนิดของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): กำหนดค่าออฟเซ็ตแนวตั้งของภาพต่อ (หน่วย points) จากจุดกำเนิดของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของภาพต่อเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของภาพต่อเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปสี่เหลี่ยมที่เติมรูปภาพแบบต่อและกำหนดตัวเลือกการต่อ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภทสี่เหลี่ยม.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มลงในทรัพยากรของการนำเสนอ.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // ตั้งค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อภาพ.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการต่อ](tile-options.png)

## **การเติมสีเดียว**

ใน PowerPoint, Solid Color Fill คือตัวเลือกการจัดรูปแบบที่เติมสีเดียวแบบสม่ำเสมอให้กับรูปทรง สีพื้นหลังเรียบนี้จะถูกใช้โดยไม่มีการไล่สี, พื้นผิว, หรือ ลายใดๆ

เพื่อเติมสีเดียวให้กับรูปทรงโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // ตั้งค่าสีเติม.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมสีเดียว](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีแบบสีเดียว, ไล่ระดับ, รูปภาพ หรือพื้นผิวกับรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่า ความโปร่งใสสูงจะทำให้รูปทรงดูโปร่งแสงมากขึ้นและให้พื้นหลังหรือวัตถุด้านหลังมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งใสโดยการปรับค่าอัลฟาในสีที่ใช้เติม นี่คือวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนด [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape สี่เหลี่ยมทึบ.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่ม auto shape สี่เหลี่ยมโปร่งใสเหนือรูปทรงทึบ.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint สิ่งนี้เป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการด้านดีไซน์เฉพาะ

เพื่อหมุนรูปทรงบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนดค่าคุณสมบัติกระจกหมุนของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่ม auto shape ประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรง 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์ Bevel 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์ Bevel 3 มิติให้กับรูปทรง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอ็อบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. กำหนดคุณสมบัติของรูปทรงใน [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/) เพื่อระบุการตั้งค่า bevel
1. บันทึกการนำเสนอ

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

![เอฟเฟกต์ Bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณเพิ่มเอฟเฟกต์การหมุน 3 มิติให้กับรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติบนรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกการนำเสนอ

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

โค้ด Java ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ไปยังการตั้งค่าเริ่มต้น:

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

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์การนำเสนอสุดท้ายหรือไม่?**  

เพียงเล็กน้อยเท่านั้น เนื่องจากรูปภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์, และการไล่สีถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์เกือบไม่มี

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อทำการจัดกลุ่มได้อย่างไร?**  

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทุกค่าตรงกันให้ถือว่าสไตล์เท่ากันและจัดกลุ่มรูปทรงเหล่านั้นในเชิงตรรกะ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในขั้นตอนต่อไป

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**  

ได้ คุณสามารถเก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการไว้ในสไลด์เทมเพลตหรือไฟล์ .POTX แล้วเมื่อสร้างงานนำเสนอใหม่ เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ต้องการ, และนำการจัดรูปแบบนั้นไปใช้ใหม่ตามที่ต้องการ