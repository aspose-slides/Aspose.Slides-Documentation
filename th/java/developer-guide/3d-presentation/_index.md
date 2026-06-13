---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอโดยใช้ Java
linktitle: การนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดันออก 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint ใน Java ด้วย Aspose.Slides กำหนดค่ากล้อง แสง วัสดุ การดันออก การเติมสี และข้อความ 3 มิติ"
---
## **ภาพรวม**

Aspose.Slides for Java สามารถสร้าง แก้ไข เก็บรักษาและแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน การดันออก (extrusion) การขัดขอบ (bevel) การจัดแสง วัสดุ การไล่สีหรือการเติมภาพ และข้อความ 3 มิติ

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบอิสระ เมื่อคุณส่งออกรายการสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/).`getThreeDFormat()` เพื่อใช้การจัดรูปแบบ 3 มิติบนรูปร่าง วัตถุที่คืนค่าจะควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ให้ใช้ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` ซึ่งจะใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนส่วนของรูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เวลาใช้งาน |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getCamera--) | มุมมอง, ชนิดกล้องตั้งค่า, การหมุน, การซูม, และการมองภาพเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่าการหมุน 3 มิติของ PowerPoint ที่กำหนดไว้ |
| [getLightRig](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getLightRig--) | การตั้งค่าแสง, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getMaterial--) และ [setMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, มีความเงา หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยืดออกไปด้านหลังจากหน้าผาก | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3 มิติที่มีความหนาชัดเจน |
| [getExtrusionColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ยืดออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าผาก |
| [getDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getDepth--) และ [setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3 มิติของ PowerPoint | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ โดยเฉพาะร่วมกับการตั้งค่า bevel และวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบที่ยกขึ้นหรือโค้งมนบนหน้าผากและด้านหลัง | เพิ่มขอบที่นิ่มหรือหล่อรูปแทนหน้าผากแบนคม |
| [getContourColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourWidth--), และ [setContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบเขตของวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

โดยปกติรูปร่างต้องการการตั้งค่า 4 ประเภท ก่อนที่จะดูเป็น 3 มิติอย่างน่าเชื่อถือ:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตั้งต้นอาจซ่อนการดันออก
- การตั้งค่าแสง เนื่องจากการจัดแสงทำให้ด้านและข้างมองเห็นได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการแสดงแสง
- การตั้งค่าการดันออกหรือความลึก เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า, เพิ่มข้อความบนหน้าผาก, ใช้การจัดรูปแบบ 3 มิติ, บันทึกพรีเซนเทชันเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้าระบายพร้อมข้อความ 3 มิติสีขาวบนหน้าผาก](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติถูกกำหนดจากพาเนล 3‑D Rotation ค่า X, Y, และ Z ที่หมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![พาเนลการหมุน 3 มิติของ PowerPoint ที่ไฮไลท์ค่าการหมุน X, Y, และ Z](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าชนิดกล้องและการหมุนผ่าน 3D format ที่คืนค่าจาก `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมเห็นวัตถุ มันไม่เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยขยายไปด้านหลังจากหน้าผาก ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่เชื่อมกับคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ตั้งค่าความสูงการดันออกสำหรับความหนาและสีการดันออกสำหรับสีด้านข้าง:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

ใช้การตั้งค่าความลึกเมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับ bevel, material และเอฟเฟกต์ข้อความ ในหลายกรณีการตั้งค่าความสูงการดันออกจะชัดเจนกว่าเพราะแสดงการดันออกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติแยกจากการเติมรูปแบบของรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลายหรือภาพบนหน้าผากและยังคงใช้กล้อง, แสง, วัสดุและการดันออกเดียวกันได้

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและสีการดันออกที่เข้มกว่าให้กับด้านข้าง:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการไล่สีจากฟ้าไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ ให้เพิ่มรูปภาพลงในพรีเซนเทชันและกำหนดให้เป็นการเติมของรูปร่าง:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์ด้วยการเติมภาพบนหน้าผากและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างมีผลต่อส่วนของรูปร่างเอง ส่วนการจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่อักษรต้องการการดันออก, วัสดุ, แสงและการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความที่เติมลาย, ใช้การแปลง WordArt โค้งและกำหนดค่า 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/):

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ข้อความ 3 มิติที่เรนเดอร์ด้วยการแปลง WordArt โค้ง, การเติมลายส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides เก็บการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบเลเอาต์คงที่ ฉาก 3 มิติจะถูกแรสเตอร์หรือวาดลงในผลลัพธ์เป็น 2 มิติ ซึ่งเกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/java/convert-powerpoint-to-video/)

ควรจำไว้:

- ภาพและ PDF ที่ส่งออกไม่สามารถโต้ตอบได้ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, light rig, material, extrusion, fill, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [effective shape properties](/slides/th/java/shape-effective-properties/)
- บางรูปแบบผลลัพธ์ไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์เป็นการเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติที่โต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ แต่ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากรูปแบบรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกลงในพรีเซนเทชัน ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, bevel, แสงและวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3 มิติปรากฏ?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและตั้งค่าการดันออกหรือความลึก ในการใช้งานจริงควรตั้งค่า light rig และ material เพื่อให้หน้าผากมีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/).`getThreeDFormat()` สำหรับส่วนของรูปร่างและ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อผลิตภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML และเฟรมที่ใช้สำหรับการแปลงวิดีโอ เอาต์พุตที่ส่งออกจะมีลักษณะที่เรนเดอร์ไว้ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, bevel และค่าต่าง ๆ ของ 3 มิติที่สรุปแล้ว