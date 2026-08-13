---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอโดยใช้ Java
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดัน 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปทรงและข้อความของ PowerPoint ใน Java ด้วย Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดัน, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถสร้าง, แก้ไข, รักษา และเรนเดอร์การจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดันพื้นผิว, การทำบีเวล, การให้แสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3 มิติ

{{% alert color="info" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นเข้าสู่ผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/).`getThreeDFormat()` เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปทรง วัตถุรูปแบบที่คืนค่าจะควบคุมฉาก 3 มิติสำหรับรูปทรงนั้น

สำหรับข้อความ, ใช้ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` ซึ่งจะใช้การจัดรูปแบบ 3 มิติกับเฟรมข้อความแทนส่วนตัวของรูปทรง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getCamera--) | มุมมอง, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงมิติ | หมุนวัตถุในพื้นที่ 3 มิติหรือให้ตรงกับการตั้งค่าการหมุน 3 มิติของ PowerPoint ที่กำหนดล่วงหน้า |
| [getLightRig](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getLightRig--) | การตั้งค่าแสง, ทิศทาง, และการหมุนแสง | ปรับวิธีการแสดงไฮไลท์และเงาบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getMaterial--) และ [setMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, มันวาวกว่า, หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปทรงยืดออกมาจากหน้าแนวหน้า | เปลี่ยนรูปทรงแบนให้เป็นวัตถุ 3 มิติที่มีความหนาเห็นได้ |
| [getExtrusionColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ถูกดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมด้านหน้า |
| [getDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getDepth--) และ [setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกของรูปทรงหรือข้อความโดยเฉพาะร่วมกับการตั้งค่า bevel และ material |
| [getBevelTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบยกหรือโค้งบนหน้าและหลัง | เพิ่มขอบที่อ่อนหรือหล่อรูปแทนการเป็นผิวแบนคม |
| [getContourColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourWidth--), และ [setContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นรอบวัตถุ 3 มิติ | ใส่ลักษณะขอบของวัตถุให้เด่นชัดในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปทรง 3 มิติ**

รูปทรงมักต้องการการตั้งค่าทั้งสี่ประเภทก่อนที่มันจะดูเหมือน 3 มิติอย่างสมจริง:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดันพื้นผิว
- การตั้งค่าแสง, เพราะแสงทำให้ด้านและข้างอ่านได้
- การตั้งค่าวัสดุ, เพราะพื้นผิวมีผลต่อการแสดงแสง
- การตั้งค่าการดันหรือความลึก, เพราะรูปทรงแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า, เพิ่มข้อความบนหน้าแนวหน้า, ใช้การจัดรูปแบบ 3 มิติ, บันทึกงานนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติหนา:

![สี่เหลี่ยม 3 มิติสีฟ้าพร้อมข้อความ 3 มิติสีขาวบนหน้าแนวหน้า](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint, การหมุน 3 มิติกำหนดจากแผง 3‑D Rotation ค่า X, Y, Z ที่กำหนดสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง 3‑D Rotation ของ PowerPoint ที่มีค่าการหมุน X, Y, Z ไฮไลท์](img_02_01.png)

ใน Aspose.Slides, ตั้งค่าชนิดกล้องและการหมุนผ่านรูปแบบ 3 มิติที่คืนค่าจาก `shape.getThreeDFormat()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีการที่ผู้ชมมองวัตถุ ไม่ได้เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการดันและความลึก**

การดันทำให้รูปทรงดูหนาโดยยืดออกมาจากหน้าแนวหน้า ใน PowerPoint, ตัวควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และตัวควบคุมสีกำหนดสีของด้านข้าง

![ตัวควบคุมความลึกของ PowerPoint ที่เชื่อมโยงกับคุณสมบัติสีการดันและความสูงการดัน](img_02_02.png)

ตั้งค่าความสูงการดันสำหรับความหนาและสีการดันสำหรับสีด้านข้าง:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

ใช้การตั้งค่าความลึกเมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายกรณีรูปทรง การตั้งค่าความสูงการดันจะชัดเจนกว่าเพราะสื่อความหมายของการดันที่มองเห็นได้โดยตรง

## **ใช้การเติมไล่สีหรือภาพพร้อมเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติทำงานแยกจากการเติมรูปทรง คุณสามารถเติมสีทึบ, ไล่สี, ลายพิมพ์, หรือภาพบนหน้าแนวหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันได้เหมือนเดิม

ตัวอย่างนี้เติมไล่สีให้รูปทรงและตั้งค่าสีการดันด้านให้เข้มกว่า:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนหน้าแนวหน้าและเรนเดอร์การดันแยกต่างหาก:

![สี่เหลี่ยม 3 มิติที่มีการไล่สีจากสีฟ้าไปสีส้มและการดันสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพ, ให้เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

ภาพจะถูกเรนเดอร์บนหน้าแนวหน้า ในขณะที่การดันจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ:

![สี่เหลี่ยม 3 มิติที่มีการเติมรูปบนหน้าแนวหน้าและการดันสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปทรงส่งผลต่อส่วนของรูปทรง ส่วนการจัดรูปแบบ 3 มิติของข้อความส่งผลต่อเฟรมข้อความ นี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดัน, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความที่มีการเติมลายพิมพ์, ใช้การแปลง WordArt, และตั้งค่าการจัดรูปแบบ 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/):

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ข้อความจะถูกเรนเดอร์เป็นอักษรโค้ง, ดันเป็น 3 มิติ:

![ข้อความ 3 มิติที่มีการแปลง WordArt โค้ง, การเติมลายพิมพ์สีส้ม, และการดันสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นฟอร์แมต PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นฟอร์แมตที่มีการจัดวางคงที่, ฉาก 3 มิติจะถูกแรสเตอร์หรือวาดลงในผลลัพธ์เป็น 2 มิติ ซึ่งเกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/java/convert-powerpoint-to-video/)

ควรจำไว้:

- ภาพและ PDF ที่ส่งออกเป็นไฟล์ที่ไม่โต้ตอบได้ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังจากส่งออก
- ลักษณะที่สุดท้ายขึ้นกับการผสมผสานของกล้อง, Light Rig, material, extrusion, การเติม, และการปรับสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงจากธีม, ให้อ่าน [effective shape properties](/slides/th/java/shape-effective-properties/)
- ฟอร์แมตผลลัพธ์บางประเภทไม่สามารถจัดเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในฟอร์แมตเหล่านั้น ผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

### Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติแบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ในไฟล์ PPTX การจัดรูปแบบ 3 มิกยังคงแก้ไขได้ใน PowerPoint เมื่อฟอร์แมตรองรับ

### ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกต่างหากที่แทรกเข้ามาในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปทรงหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การดัน, การทำบีเวล, การให้แสง, และวัสดุ บทความนี้ครอบคลุมเฉพาะเอฟเฟกต์ 3 มิติ

### ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3 มิติดูเห็นได้?

อย่างน้อยต้องตั้งค่าการหมุนกล้องและตั้งค่าการดันหรือความลึก ในการใช้งานจริงยังควรตั้งค่า Light Rig และ Material เพื่อให้หน้าตาแสงเงาชัดเจน

### สามารถใช้เอฟเฟกต์ 3 มิติได้ทั้งกับรูปทรงและข้อความหรือไม่?

ได้ ใช้ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/).`getThreeDFormat()` สำหรับส่วนของรูปทรงและ [ITextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` สำหรับข้อความ

### เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?

ปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ไว้ ไม่ได้เป็นวัตถุ 3 มิติที่แก้ไขได้

### สามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมได้หรือไม่?

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, Light Rig, Bevel, และค่าการจัดรูปแบบ 3 มิติอื่น ๆ ที่สุดท้าย