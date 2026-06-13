---
title: จัดรูปแบบรูปทรง PowerPoint ใน Java
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/java/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลายเส้น
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- หมุนรูปทรง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟ็กต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปทรง PowerPoint ใน Java ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณสามารถจัดรูปแบบโดยการปรับหรือนำเอฟเฟกต์ไปใช้กับเส้นรอบรูป นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปทรงโดยกำหนดการตั้งค่าที่ควบคุมวิธีการเติมภายในของรูปทรงได้

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุรูปแบบเส้นที่กำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/java/com.aspose.slides/linestyle/) ของรูปทรง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/java/com.aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีของเส้นสำหรับรูปทรง
1. บันทึกพรีเซนเทชั่นที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้สาธิตวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปของประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมให้กับรูปทรงสี่เหลี่ยม.
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

![เส้นที่จัดรูปแบบในพรีเซนเทชั่น](formatted-lines.png)

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

ต่อไปนี้เป็นตัวเลือกของประเภทการเชื่อมต่อสามแบบ:

* โค้ง
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมเส้นสองเส้นที่มุม (เช่น ที่มุมของรูปทรง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter**

![The join style in the presentation](join-style-powerpoint.png)

โค้ด Java ต่อไปนี้สาธิตว่าสามสี่เหลี่ยมผืนผ้า (ตามที่แสดงในรูปด้านบน) ถูกสร้างขึ้นโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสามรูปประเภท Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมให้กับรูปสี่เหลี่ยมแต่ละรูป.
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

    // เพิ่มข้อความให้กับสี่เหลี่ยมแต่ละรูป.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถใช้การผสมสีต่อเนื่องกับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่านั้นโดยสีหนึ่งค่อย ๆ ทำให้จางลงสู่สีอีกสีหนึ่ง

นี่คือวิธีการใช้ Aspose.Slides เพื่อเติมแบบไล่สีให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/igradientformat/) 
1. บันทึกพรีเซนเทชั่นที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้สาธิตวิธีใช้เอฟเฟกต์การเติมแบบไล่สีกับวงรี:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับวงรี.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // ตั้งค่าทิศทางของไล่สี.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่สีสองจุด.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

## **การเติมแบบลายเส้น**

ใน PowerPoint การเติมแบบลายเส้นเป็นตัวเลือกการจัดรูปแบบที่ให้คุณเติมรูปทรงด้วยการออกแบบสองสี เช่น จุด, เส้นประ, กากบาท หรือ ตาราง คุณสามารถกำหนดสีพื้นหน้าและพื้นหลังของลายเส้นได้ตามต้องการ

Aspose.Slides มีลายเส้นสำเร็จรูปมากกว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับพรีเซนเทชั่นของคุณ แม้จะเลือกลายเส้นสำเร็จรูปแล้ว คุณก็ยังสามารถกำหนดสีที่แน่นอนได้

วิธีการใช้ Aspose.Slides เพื่อเติมแบบลายเส้นให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกสไตล์ลายเส้นจากตัวเลือกสำเร็จรูป
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/patternformat/#getBackColor--) ของลายเส้น
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/patternformat/#getForeColor--) ของลายเส้น
1. บันทึกพรีเซนเทชั่นที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้สาธิตวิธีเติมลายเส้นให้กับสี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // ตั้งค่าสไตล์ลายเส้น.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // ตั้งค่าพื้นหลังและสีพื้นหน้าของลายเส้น.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมผืนผ้าที่มีการเติมลายเส้น](pattern-fill.png)

## **การเติมแบบรูปภาพ**

ใน PowerPoint การเติมแบบรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพเข้าไปในรูปทรง—ใช้รูปภาพเป็นพื้นหลังของรูปทรง

วิธีใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดที่ต้องการอื่น)
1. สร้างออปเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) จากรูปภาพที่ต้องการใช้
1. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกพรีเซนเทชั่นที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" พร้อมรูปภาพดังต่อไปนี้:

![ภาพดอกบัว](lotus.png)

โค้ด Java ต่อไปนี้สาธิตวิธีเติมรูปภาพให้กับรูปทรง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชั่น.
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

![รูปทรงที่มีการเติมรูปภาพ](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งค่ารูปภาพแบบต่อกระเบื้องเป็นเทกซ์เจอร์และปรับพฤติกรรมการต่อกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): ตั้งค่าโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): ระบุการจัดตำแหน่งของกระเบื้องภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองแบบ
- [setTileOffsetX](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): ตั้งค่าออฟเซ็ตแนวนอนของกระเบื้อง (เป็นพ้อยท์) จากตำแหน่งเริ่มต้นของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): ตั้งค่าออฟเซ็ตแนวตั้งของกระเบื้อง (เป็นพ้อยท์) จากตำแหน่งเริ่มต้นของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมพร้อมการเติมรูปภาพแบบต่อกระเบื้องและกำหนดตัวเลือกกระเบื้อง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยมผืนผ้า.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชั่น.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อกระเบื้อง.
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

![ตัวเลือกการต่อกระเบื้อง](tile-options.png)

## **การเติมสีเดียว**

ใน PowerPoint การเติมสีเดียวเป็นตัวเลือกการจัดรูปแบบที่เติมรูปทรงด้วยสีเดียวที่สม่ำเสมอ ไม่ใช้ไล่สี เทกซ์เจอร์ หรือลายเส้นใด ๆ

เพื่อใช้การเติมสีเดียวให้กับรูปทรงด้วย Aspose.Slides ให้ทำตามขั้นตอนเหล่านี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง
1. บันทึกพรีเซนเทชั่นที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java ต่อไปนี้สาธิตวิธีเติมสีเดียวให้กับสี่เหลี่ยมผืนผ้าในสไลด์ PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
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

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปทรงที่มีการเติมสีเดียว](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีเดียว, การเติมไล่สี, การเติมรูปภาพ หรือการเติมเทกซ์เจอร์กับรูปทรง คุณยังสามารถกำหนดระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าโปร่งใสที่สูงทำให้รูปทรงดูโปร่งแสงมากขึ้น ซึ่งทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณกำหนดระดับความโปร่งใสโดยปรับค่าอัลฟาในสีที่ใช้สำหรับการเติม วิธีทำคือ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกพรีเซนเทชั่น

โค้ด Java ต่อไปนี้สาธิตวิธีใช้สีเติมที่โปร่งใสกับสี่เหลี่ยมผืนผ้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปสี่เหลี่ยมผืนผ้าแบบทึบ.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มออโต้เชปสี่เหลี่ยมผืนผ้าระดับโปร่งใสเหนือรูปแบบทึบ.
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

Aspose.Slides ให้คุณหมุนรูปทรงในพรีเซนเทชั่น PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการวางตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือการออกแบบที่ต้องการ

เพื่อหมุนรูปทรงบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกพรีเซนเทชั่น

โค้ด Java ต่อไปนี้สาธิตการหมุนรูปทรงด้วยมุม 5 องศา:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชั่น.
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภท Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรงตามมุม 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์บีเวล 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวล 3 มิติให้กับรูปทรง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่าบีเวล
1. บันทึกพรีเซนเทชั่น

โค้ด Java ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์บีเวล 3 มิติบนรูปทรง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงลงสไลด์.
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

    // บันทึกพรีเซนเทชั่นเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติบนรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) 
1. รับออปเจ็กต์อ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/java/com.aspose.slides/icamera/#setCameraType-int-) และ [setLightType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilightrig/#setLightType-int-) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกพรีเซนเทชั่น

โค้ด Java ต่อไปนี้สาธิตการใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรง:

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

    // บันทึกพรีเซนเทชั่นเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และทำให้ตำแหน่ง, ขนาด และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/) กลับไปเป็นค่าปริยาย:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // รีเซ็ตรูปทรงแต่ละรูปบนสไลด์ที่มี placeholder บน layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์พรีเซนเทชั่นสุดท้ายหรือไม่?**

ผลกระทบน้อยมาก รูปภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์และไล่สีถูกเก็บเป็นเมทาดาต้าและเพิ่มขนาดไฟล์โดยแทบไม่มี

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ถือว่าสไตล์เดียวกันและสามารถจัดกลุ่มรูปทรงเหล่านั้นเชิงตรรกะ ซึ่งทำให้ง่ายต่อการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้งานในพรีเซนเทชั่นอื่นได้หรือไม่?**

ได้ บันทึกรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์ .POTX เมื่อสร้างพรีเซนเทชั่นใหม่ ให้เปิดเทมเพลตนั้น โคลนรูปทรงที่สไตล์ต้องการและนำการจัดรูปแบบไปใช้ใหม่ตามความจำเป็น