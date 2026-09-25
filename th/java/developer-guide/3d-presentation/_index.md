---
title: สร้างเอฟเฟกต์ 3 มิติในการพรีเซนต์โดยใช้ Java
linktitle: การพรีเซนต์ 3 มิติ
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
description: "ใช้และแสดงผลเอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความใน PowerPoint ด้วย Java และ Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถสร้าง แก้ไข รักษา และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน การดันออก (extrusion) การทำบีเวล การจัดแสง วัสดุ การเติมไล่สีหรือภาพ และข้อความ 3 มิติ

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความใน PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นรูปภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นเข้าสู่ผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปร่าง เมธอดนี้จะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) การทำเช่นนี้จะใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนส่วนของรูปร่าง

สมาชิก API ที่สำคัญที่สุด ได้แก่:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อใช้งาน |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getCamera--) | มุมมอง, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และเพอร์สเปคทีฟ | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่าการหมุน 3 มิติที่ตั้งไว้ของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getLightRig--) | การตั้งค่าไฟ, ทิศทาง, และการหมุนแสง | เปลี่ยนการแสดงไฮไลท์และเงาบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุพื้นผิว เช่น แบน, แมต, พลาสติก หรือโลหะ | ทำให้รูปร่างเดียวกันดูแบนขึ้น, นุ่มขึ้น, มีเงางาม หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปทรงยื่นออกไปด้านหลังจากหน้า | เปลี่ยนรูปทรงแบนให้เป็นวัตถุ 3 มิติที่เห็นความหนา |
| [getExtrusionColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ถูกยืดออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับสีเติมหน้า |
| [getDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3 มิติของ PowerPoint | ปรับความลึกให้เหมาะสมสำหรับรูปร่างหรือข้อความ โดยเฉพาะเมื่อใช้พร้อมกับการตั้งค่าบีเวลและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบที่ยกขึ้นหรือโค้งบนหน้าและด้านหลัง | เพิ่มขอบที่นุ่มหรือขึ้นรูปแทนที่จะเป็นพื้นแบนแบบคม |
| [getContourColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นขอบเขตของวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปทรง 3 มิติ**

รูปทรงมักต้องการการตั้งค่าสี่ประเภทก่อนที่มันจะดูเป็น 3 มิติอย่างเชื่อถือได้:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตั้งต้นอาจทำให้การดันออกไม่เห็น
- การตั้งค่าแสง เนื่องจากแสงทำให้หน้าและด้านของรูปมองเห็นได้ชัดเจน
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการแสดงแสง
- การตั้งค่าการดันออกหรือความลึก เนื่องจากรูปแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า เพิ่มข้อความบนหน้าและใช้การจัดรูปแบบ 3 มิติ ค่า การหมุนกล้องเป็นองศา และความสูงการดันออกเป็น 100 จุด ตัวอย่างนี้เรนเดอร์สไลด์เป็นรูป PNG ที่ขนาดสองเท่าของค่าเริ่มต้นและบันทึกการนำเสนอเป็น PPTX

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

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้ารับการเรนเดอร์พร้อมข้อความ 3 มิติสีขาวบนหน้า](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติจะตั้งค่าจากแผง 3-D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง 3-D Rotation ของ PowerPoint ที่ไฮไลต์ค่า X, Y, และ Z ของการหมุน](img_02_01.png)

ใน Aspose.Slides ให้เข้าถึงกล้องผ่าน [IThreeDFormat.getCamera](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getCamera--) ตัวอย่างนี้สร้างสี่เหลี่ยม เลือกมุมมองหน้ามุมมองแบบออร์โธกราฟิก และตั้งค่าการหมุน X, Y, Z ที่ 20, 30, และ 40 องศาตามลำดับ มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ มันไม่ได้เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่จะเปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อตีความ

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปทรงดูหนาโดยขยายออกไปด้านหลังของหน้าใน PowerPoint การควบคุมความลึกตั้งความหนาที่มองเห็นได้และการควบคุมสีตั้งค่าสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint เชื่อมโยงกับคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ใช้เมธอด [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) เพื่อกำหนดความหนาและ [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมมีการดันออก 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อแสดงความหนา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

เมธอด [IThreeDFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setDepth-double-) กำหนดความลึกของรูปทรง 3 มิติ เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ควบคุมความสูงของเอฟเฟกต์การดันออกตามที่แสดงในตัวอย่างนี้

## **ใช้การเติมแบบไล่สีหรือภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติไม่ขึ้นกับการเติมรูปทรง คุณสามารถใช้สีทึบ, การไล่สี, แพทเทิร์น หรือการเติมภาพลงบนหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันออกเดียวกัน

ตัวอย่างนี้ใช้การเติมไล่สีจากสีฟ้าเป็นสีส้มบนหน้าและสีส้มสำหรับการดันออก 150 จุด การหยุดไล่สีที่ 0 และ 100 เป็นจุดเริ่มและจบของการไล่สี ค่าการหมุนกล้องเป็นองศา สไลด์ถูกเรนเดอร์เป็นรูป PNG ที่ขนาดสองเท่าของค่าเริ่มต้น:

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

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมไล่สีจากสีฟ้าเป็นสีส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมภาพแทน ให้เพิ่มรูปภาพเข้าไปในงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง ตัวอย่างนี้ต้องมีไฟล์ชื่อ “image.jpg” อยู่ในไดเรกทอรีทำงาน มันขยายภาพให้เต็มสี่เหลี่ยม ใช้การดันออก 150 จุด และตั้งค่าการหมุนกล้องเป็นองศา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมภาพบนหน้าและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างมีผลต่อส่วนของรูปร่าง ส่วนการจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, แสงสว่างและการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยแพทเทิร์นกริดสีส้มและสีขาว ใช้โค้งขึ้นและกำหนดค่าการตั้งค่า 3 มิติผ่าน [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) ความสูงการดันออกและความลึกเป็นจุด และการหมุนแสงเป็นองศา การเติมและเส้นขอบของรูปร่างถูกซ่อนไว้เพื่อให้เห็นเฉพาะข้อความ ตัวอย่างนี้เรนเดอร์เป็นรูป PNG ที่สองเท่าของขนาดสไลด์เริ่มต้นและบันทึกการนำเสนอเป็น PPTX:

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

![ข้อความ 3 มิติที่เรนเดอร์พร้อมการแปลง WordArt โค้ง, การเติมแพทเทิร์นสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **ทำให้ข้อความแบนบนรูปทรง 3 มิติ**

เพื่อให้ข้อความอ่านง่ายขณะยังคงรูปลักษณ์ 3 มิติของรูปร่าง ให้เรียก [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) ผ่าน [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getTextFrameFormat--) เมื่อค่าเป็น `true` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อค่าเป็น `false` ข้อความจะเข้าร่วมฉากและตามแนว 3 มิติของมัน

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3 มิติของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงถูกกำหนดผ่าน [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getThreeDFormat--) นอกจากนี้ยังแตกต่างจากการหมุนปกติ [IShape.setRotation](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#setRotation-float-) จะหมุนรูปร่างในระนาบสไลด์ ในขณะที่ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกรอบของมัน การทำให้ข้อความอยู่นอกฉาก 3 มิติไม่ทำให้มุมใด ๆ ถูกรีเซ็ต

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและโคลนไว้ข้างๆ รูปต้นฉบับ ทั้งสองรูปร่างมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงค่าในการตั้งค่าข้อความที่ต่างกัน: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 จุด ตัวอย่างนี้บันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ที่สองเท่าของขนาดเริ่มต้น

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

![สี่เหลี่ยม 3 มิติข้างเคียง: ข้อความตามแนว 3 มิติทางซ้ายและคงแบนทางขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบที่มีการจัดวางคงที่ ฉาก 3 มิติจะถูกเรสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2 มิติ ซึ่งใช้ได้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/java/convert-powerpoint-to-video/)

- ภาพและ PDF ที่ส่งออกไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, แสง, วัสดุ, การดันออก, การเติม, และการย่อขยายสไลด์
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม ให้อ่าน [effective shape properties](/slides/th/java/shape-effective-properties/)
- รูปแบบผลลัพธ์บางรูปแบบไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ภาพจะถูกเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **FAQ**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML เป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint เมื่อรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติกับเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติเป็นออบเจ็กต์ 3 มิติแยกที่แทรกเข้ามาในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความใน PowerPoint เช่น การหมุน, การดันออก, บีเวล, แสงและวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติเท่านั้น

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3 มิติเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและตั้งค่าการดันออกหรือความลึก ในทางปฏิบัติควรตั้งค่า Light Rig และ Material ด้วยเพื่อให้หน้าตาแสงและเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getThreeDFormat--) สำหรับส่วนของรูปร่างและ [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, PDF, HTML หรือเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะการเรนเดอร์นี้ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและธีมถูกนำไปใช้หรือไม่?**

ใช่ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, Light Rig, Bevel และค่าการจัดรูปแบบ 3 มิติอื่น ๆ ที่ได้จากการสืบทอดและธีม