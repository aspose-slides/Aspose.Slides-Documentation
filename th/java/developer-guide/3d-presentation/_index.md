---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอด้วย Java
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/java/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดันออก 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ใช้และแสดงผลเอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความใน PowerPoint ด้วย Java และ Aspose.Slides กำหนดค่ากล้อง, การส่องแสง, วัสดุ, การดันออก, การเติม, และข้อความ 3 มิติ"
---
## **ภาพรวม**

Aspose.Slides for Java สามารถสร้าง, แก้ไข, รักษา และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดันออก, การเบฟ, การส่องแสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3 มิติ

{{% alert color="info" title="หมายเหตุ" %}}

บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบสแตนด์อโลน เมื่อคุณส่งออกสไลด์เป็นรูปภาพ, PDF, หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นเข้าสู่ผลลัพธ์ 2 มิติที่ส่งออก

{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปร่าง เมธอดจะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), ซึ่งควบคุมฉาก 3 มิติของรูปร่างนั้น

สำหรับข้อความ, ใช้เมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) ซึ่งจะใช้การจัดรูปแบบ 3 มิติกับกรอบข้อความแทนส่วนเนื้อหาของรูปร่าง

สมาชิก API ที่สำคัญที่สุดมีดังนี้

| สมาชิก API | สิ่งที่ควบคุม | เวลาที่ใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | จุดมอง, ประเภทกล้องสำเร็จรูป, การหมุน, ซูม, และมุมมองเชิงลึก | หมุนอ็อบเจ็กต์ในพื้นที่ 3 มิติหรือใช้ค่าพรีเซ็ตการหมุน 3 มิติของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | พรีเซ็ตแสง, ทิศทาง, และการหมุนของแสง | เปลี่ยนวิธีที่แสงสว่างและเงาปรากฏบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) และ [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุปื้นผิว เช่น แบน, แมต, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, เงางามกว่า, หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) และ [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยืดออกจากหน้าตัดหน้า | แปลงรูปร่างแบนให้เป็นอ็อบเจ็กต์ 3 มิติที่เห็นหนา |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ดันออก | ทำให้ความลึกเห็นได้ชัดหรือประสานสีด้านข้างกับสีเติมหน้า |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) และ [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกสำหรับรูปร่างหรือข้อความ, โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่าเบฟและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | ปรับขอบที่ยกหรือโค้งบนหน้าตัดหน้าและหลัง | เพิ่มขอบที่นุ่มหรือรูปร่างที่ขึ้นรูปแทนที่จะเป็นพื้นแบนเฉียง |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) และ [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) และ [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นขอบรอบอ็อบเจ็กต์ 3 มิติ | เน้นขอบอ็อบเจ็กต์ในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างมักต้องการการตั้งค่าสี่ประเภทก่อนจะแสดงเป็น 3 มิติที่เชื่อถือได้:

- การตั้งค่ากล้อง, เพราะมุมมองหน้าเริ่มต้นอาจซ่อนการดันออก
- การตั้งค่าแสง, เพราะการส่องแสงทำให้ด้านและข้างมองเห็นได้ชัด
- การตั้งค่าวัสดุ, เพราะพื้นผิวมีผลต่อการแสดงผลของแสง
- การตั้งค่าการดันออกหรือความลึก, เพราะรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, ใส่ข้อความบนหน้าตัดหน้า, และใช้การจัดรูปแบบ 3 มิติ ค่าการหมุนของกล้องเป็นองศา, ความสูงการดันออกเป็น 100 จุด ตัวอย่างเรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้นและบันทึกงานนำเสนอเป็น PPTX

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

![สี่เหลี่ยม 3 มิติสีฟ้าพร้อมข้อความ 3 มิติสีขาวบนหน้าตัดหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint, การหมุน 3 มิติกำหนดจากช่อง **3‑D Rotation** ค่าการหมุน X, Y, และ Z สอดคล้องกับการตั้งค่าที่คุณทำผ่าน API ของกล้อง

![ช่อง 3‑D Rotation ของ PowerPoint ที่แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides, เข้าถึงกล้องผ่านเมธอด [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้าแบบออร์โธกราฟิก, และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองอ็อบเจ็กต์ การตั้งค่านี้ไม่เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

### **คัดลอกการกำหนดทิศทางกล้องจากรูปร่างแม่แบบ**

เพื่อให้ตรงกับการกำหนดทิศทางของรูปร่างแม่แบบ, อ่านพรีเซ็ตกล้องด้วย [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) และมุมการหมุนด้วย [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) ตัวอย่างเปิดไฟล์ `template.pptx` และคัดลอกการกำหนดทิศทางกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3 มิติแล้ว, และรูปร่างที่สองไม่มีการหมุนกล้องโดยตรง

มุมอยู่เป็นองศา ดัชนี `0` คือละติจูด, ดัชนี `1` คือลองจิจูด, ดัชนี `2` คือการปริศนาตามลำดับ ส่งค่าเหล่านี้ไปยัง [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) หากแหล่งข้อมูลคืนค่า `null` แสดงว่าไม่มีการหมุนโดยตรง จึงไม่ต้องตั้งมุมของรูปร่างที่สอง การหมุนแบบชัดเจนของ `(0, 0, 0)` จะคืนค่าเป็นศูนย์สามค่าและควรคัดลอก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อคุณเปิดไฟล์ `camera-copy.pptx` ใน PowerPoint, ลูกศรด้านขวาจะมีพรีเซ็ตกล้องและการหมุนเดียวกับสี่เหลี่ยมด้านซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดันออกเดียวกัน

![สี่เหลี่ยม 3 มิติสีน้ำเงินและลูกศรขวาที่มีการกำหนดทิศทางกล้องตรงกัน, มองจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยยืดออกจากหน้าตัดหน้า ใน PowerPoint, ควบคุมความลึกจะกำหนดความหนาที่มองเห็น, และค่าสีจะกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่แมพกับคุณสมบัติสีการดันออกและความสูงการดันออก](img_02_02.png)

ใช้เมธอด [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) เพื่อตั้งค่าความหนาและ [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) เพื่อเข้าถึงสีด้านข้าง ตัวอย่างนี้ให้สี่เหลี่ยมดันออก 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อแสดงความหนา ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์

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

เมธอด [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) ตั้งค่าความลึกของรูปร่าง 3 มิติ เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ควบคุมความสูงของเอฟเฟกต์การดันออกตามที่แสดงในตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเสรีจากการเติมของรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, แพทเทิร์น, หรือรูปภาพบนหน้าตัดหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันออกเดียวกัน

ตัวอย่างนี้ใช้ไล่สีจากสีฟ้าไปสีส้มบนหน้าตัดหน้าและสีส้มโทนอันเข้มบนการดันออก 150 จุด จุดหยุดไล่สีที่ 0 และ 100 เป็นจุดเริ่มและสิ้นสุดของไล่สี ค่าการหมุนของกล้องเป็นองศา สไลด์เรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้น:

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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนหน้าตัดหน้าและเรนเดอร์การดันออกแยกต่างหาก:

![สี่เหลี่ยม 3 มิติที่ไล่สีจากฟ้าเป็นส้มและการดันออกสีส้มที่เรนเดอร์แล้ว](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, เพิ่มรูปภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องการไฟล์ที่มีชื่อ “image.jpg” อยู่ในไดเรกทอรีทำงาน มันขยายรูปภาพให้เต็มสี่เหลี่ยม, ตั้งค่าการดันออก 150 จุด, และตั้งค่าการหมุนของกล้องเป็นองศา ตัวอย่างกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์

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

รูปภาพจะถูกเรนเดอร์บนหน้าตัดหน้า, ส่วนการดันออกจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ:

![สี่เหลี่ยม 3 มิติที่เติมรูปถ่ายบนหน้าตัดหน้าและการดันออกสีส้มที่เรนเดอร์แล้ว](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติบนข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างส่งผลต่อเนื้อหารูปร่าง, ส่วนการจัดรูปแบบ 3 มิติของข้อความส่งผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยแพทเทิร์นตารางส้ม‑ขาว, ใช้โค้งยกขึ้น, และกำหนดค่า 3 มิติผ่านเมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) ความสูงการดันออกและความลึกเป็นหน่วยจุด, การหมุนแสงเป็นองศา การเติมและขอบของรูปร่างถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างเรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของสไลด์เริ่มต้นและบันทึกงานนำเสนอเป็น PPTX

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

ข้อความถูกเรนเดอร์เป็นอักษร 3 มิติที่โค้ง, ดันออก, มีการเติมแพทเทิร์นส้ม, และการดันออกสีเข้ม:

![ข้อความ 3 มิติที่มีการแปลง WordArt โค้ง, เติมแพทเทิร์นสีส้ม, และการดันออกสีเข้มที่เรนเดอร์แล้ว](img_02_05.png)

## **คงข้อความให้แบนบนรูปร่าง 3 มิติ**

เพื่อให้ข้อความอ่านได้ง่ายขณะยังคงรูปร่างเป็น 3 มิติ, เรียกเมธอด [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) ผ่าน [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) เมื่อค่าเป็น `true` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อเป็น `false` ข้อความจะอยู่ในฉากและตามการกำหนดทิศทาง 3 มิติ

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3 มิติของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงตั้งค่าผ่าน [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) นอกจากนี้ยังแตกต่างจากการหมุนทั่วไป [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) จะหมุนรูปร่างในระนาบสไลด์, ส่วน [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ควบคุมการหมุนแบบกำหนดเองของข้อความภายในกล่องของมัน การเก็บข้อความให้นอกฉาก 3 มิติไม่ได้รีเซ็ตมุมใด ๆ

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินที่มีข้อความและทำสำเนาไว้ข้าง ๆ รูปต้นฉบับ ทั้งสองรูปร่างมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงแค่การตั้งค่าข้อความแตกต่าง: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 จุด ตัวอย่างบันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของขนาดเริ่มต้น

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

ทางซ้ายข้อความตามการกำหนดทิศทาง 3 มิติ ทางขวามันคงแบนและอ่านง่ายขึ้น สี่เหลี่ยมทั้งสองยังคงมีการดันออกและการกำหนดทิศทาง 3 มิติที่มองเห็นได้เหมือนกัน

![สี่เหลี่ยม 3 มิติข้างกัน: ข้อความตามการกำหนดทิศทาง 3 มิติทางซ้ายและคงแบนทางขวา](keep_text_flat.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นฟอร์แมต PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นฟอร์แมตแบบคงที่, ฉาก 3 มิติจะถูกแปลงเป็นภาพเรสเตอร์หรือวาดลงบนผลลัพธ์เป็น 2 มิติ สิ่งนี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [การแปลงวิดีโอ](/slides/th/java/convert-powerpoint-to-video/)

ควรจำไว้ว่า:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ อ็อบเจ็กต์ไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ชุดแสง, วัสดุ, การดันออก, การเติม, และการปรับสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม, อ่าน [effective shape properties](/slides/th/java/shape-effective-properties/)
- ฟอร์แมตผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในฟอร์แมตเหล่านั้นผลลัพธ์จะเป็นการเรนเดอร์ภาพแทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติแบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากฟอร์แมตรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติคืออ็อบเจ็กต์ 3 มิติเสริมที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติคือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การดันออก, เบฟ, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3 มิติปรากฏ?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและหรือการดันออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่าชุดแสงและวัสดุด้วยเพื่อให้พื้นผิวที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) กับส่วนเนื้อหารูปร่างและเมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) กับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ ไม่ใช่อ็อบเจ็กต์ 3 มิติที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติขั้นสุดท้ายหลังการสืบทอดและตั้งค่าธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, ชุดแสง, เบฟ, และค่าการจัดรูปแบบ 3 มิติที่เกี่ยวข้องขั้นสุดท้าย