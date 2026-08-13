---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอบน Android
linktitle: การนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/androidjava/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การยื่นออก 3 มิติ
- การไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint บน Android ด้วย Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การยื่นออก, การเติมสี, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถสร้าง, แก้ไข, รักษาและเรนเดอร์การฟอร์แมต 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดึงออก, bevels, แสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3 มิติ

{{% alert color="info" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การฟอร์แมต 3 มิติบนรูปร่างและข้อความใน PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแยกส่วน เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านี้ลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการฟอร์แมต 3 มิติ**

ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อใช้การฟอร์แมต 3 มิติบนรูปร่าง เมธอดจะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/), ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ, ใช้เมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) วิธีนี้จะใช้การฟอร์แมต 3 มิติบนกรอบข้อความแทนที่ส่วนของรูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | ควบคุมอะไร | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | มุมมอง, ประเภทกล้องตั้งต้น, การหมุน, การซูม, และการมองภาพเชิงลึก. | หมุนวัตถุในพื้นที่ 3 มิติหรือจับคู่กับการตั้งค่าการหมุน 3 มิติของ PowerPoint ที่ตั้งไว้. |
| [getLightRig](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | การตั้งค่าแสง, ทิศทาง, และการหมุนของแสง. | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ. |
| [getMaterial](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) และ [setMaterial](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุผิวหน้าต่างๆ เช่น แบน, แมตต์, พลาสติก หรือโลหะ. | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, มีความเงา, หรือเป็นโลหะ. |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยื่นออกมาจากหน้าใหม่ไปด้านหลัง. | เปลี่ยนรูปร่างแบนเป็นวัตถุ 3 มิติที่มีความหนาที่มองเห็นได้. |
| [getExtrusionColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ยื่นออกมาด้านข้าง. | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าต่าง. |
| [getDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getDepth--) และ [setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ในการฟอร์แมต 3 มิติ. | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ, โดยเฉพาะเมื่อตั้งค่า bevel และ material ร่วมกัน. |
| [getBevelTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบที่ยกขึ้นหรือโค้งมนบนหน้าหน้าและหลัง. | เพิ่มขอบที่นิ่มหรือหล่อแทนหน้าที่แบนและคม. |
| [getContourColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), และ [setContourWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นรอบรูปของวัตถุ 3 มิติ. | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์. |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างมักต้องการการตั้งค่า 4 ประเภทก่อนจะดูเหมือน 3 มิติอย่างเชื่อถือได้:

- การตั้งค่ากล้อง, เพราะมุมมองหน้าปริยายอาจซ่อนการยื่นออก.
- การตั้งค่าแสง, เพราะแสงทำให้หน้าและด้านอ่านง่าย.
- การตั้งค่าวัสดุ, เพราะพื้นผิวมีผลต่อการเรนเดอร์แสง.
- การตั้งค่าการยื่นออกหรือความลึก, เพราะรูปร่างแบนต้องการความหนา.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนหน้า, ใช้การฟอร์แมต 3 มิติ, บันทึกพรีเซนเทชันเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

ภาพที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้าพร้อมข้อความ 3 มิติสีขาวบนหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติกำหนดจากแถบ 3‑D Rotation ค่าการหมุน X, Y, และ Z สอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แถบการหมุน 3‑D ของ PowerPoint พร้อมค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides, ตั้งค่าประเภทกล้องและการหมุนผ่าน [IThreeDFormat.getCamera](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

ใช้กล้องเมื่อต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ ไม่ได้เปลี่ยนรูปทรง 2‑D ของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3‑D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการยื่นออกและความลึก**

การยื่นออกทำให้รูปร่างดูหนาโดยยืดออกจากหน้าในด้านหลัง ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint เชื่อมกับคุณสมบัติสีการยื่นออกและความสูงการยื่นออก](img_02_02.png)

ตั้งค่า [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) เพื่อกำหนดความหนาและ [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) เพื่อกำหนดสีด้าน:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

ใช้ [IThreeDFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) เมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายกรณีของรูปร่าง `setExtrusionHeight` ชัดเจนกว่าเพราะแสดงความยื่นออกที่มองเห็นโดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3 มิติ**

การฟอร์แมต 3 มิติเป็นอิสระจากการเติมสีของรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, แพทเทิร์น, หรือรูปภาพบนหน้าและยังใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการยื่นออกเดียวกันได้

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและสีด้านของการยื่นออกให้มืดกว่า:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

![สี่เหลี่ยม 3 มิติที่มีการไล่สีจากสีฟ้าไปสสีส้มและการยื่นออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน ให้เพิ่มรูปภาพลงในพรีเซนเทชันและกำหนดให้เป็นการเติมของรูปร่าง:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยม 3 มิติที่เติมรูปภาพบนหน้าและการยื่นออกสีส้ม](img_02_04.png)

## **ใช้การฟอร์แมต 3 มิติกับข้อความ**

การฟอร์แมต 3 มิติของรูปร่างส่งผลต่อส่วนของรูปร่าง ส่วนการฟอร์แมต 3 มิติของข้อความส่งผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการยื่นออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลายแพทเทิร์น, ใช้การแปลง WordArt, และตั้งค่า 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![ข้อความ 3 มิติที่แปลงเป็น WordArt โค้ง, เติมลายสีส้ม, และการยื่นออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการฟอร์แมต 3 มิติเมื่อตSavingเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบที่มีการจัดวางคงที่ ฉาก 3 มิติจะถูกแรสเตอร์หรือวาดเข้าไปในผลลัพธ์เป็น 2 มิติ นี้เกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/androidjava/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/androidjava/convert-powerpoint-to-video/)

ควรจำจุดต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่ได้เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออกได้.
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการรวมกันของกล้อง, ระบบแสง, วัสดุ, การยื่นออก, การเติมสี, และการปรับสเกลสไลด์.
- หากต้องการตรวจสอบค่าฟอร์แมตที่สืบทอดหรืออิงธีม, อ่าน [effective shape properties](/slides/th/androidjava/shape-effective-properties/).
- รูปแบบเอาต์พุตบางอย่างไม่สามารถเก็บการฟอร์แมต 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่เห็นจะถูกเรนเดอร์เป็นภาพ ไม่ได้เก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

### Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ แต่ไม่ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การฟอร์แมต 3 มิติยังคงแก้ไขได้ใน PowerPoint เมื่อตรูปแบบรองรับ

### ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกลงในพรีเซนเทชัน ส่วนเอฟเฟกต์ 3 มิติเป็นการฟอร์แมตที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การยื่นออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเฉพาะเอฟเฟกต์ 3 มิติ

### การตั้งค่าใดที่จำเป็นสำหรับรูปร่าง 3 มิติที่มองเห็นได้?

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและตั้งค่าการยื่นออกหรือความลึก ในการใช้งานจริง ควรตั้งค่าระบบแสงและวัสดุด้วยเพื่อให้หน้าเรนเดอร์มีไฮไลท์และเงาชัดเจน

### ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?

ได้ ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) สำหรับส่วนของรูปร่าง และ [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) สำหรับข้อความ

### เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, PDF, HTML หรือเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะประกอบด้วยภาพที่เรนเดอร์ ไม่ได้เป็นวัตถุ 3 มิติที่แก้ไขได้

### ฉันสามารถอ่านค่าตัวแปร 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมถูกนำไปใช้หรือไม่?

ได้ ใช้ API การฟอร์แมตที่มีประสิทธิภาพที่อธิบายใน [Shape Effective Properties](/slides/th/androidjava/shape-effective-properties/) เพื่ออ่านค่ากล้อง, ระบบแสง, bevel, และค่าที่เกี่ยวข้องกับ 3 มิติสุดท้าย