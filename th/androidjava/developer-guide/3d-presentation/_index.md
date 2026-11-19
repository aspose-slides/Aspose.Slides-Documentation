---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอบน Android
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดันออก 3D
- ไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความ PowerPoint บน Android ด้วย Aspose.Slides ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติมสี, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถสร้าง แก้ไข รักษา และแสดงผลการจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน การดันออก (extrusion) การทำ bevels การให้แสง วัสดุ การไล่สีหรือการเติมรูปภาพ และข้อความ 3D.

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อประยุกต์การจัดรูปแบบ 3D ให้กับรูปร่าง เมธอดนี้จะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), ซึ่งควบคุมฉาก 3D สำหรับรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) วิธีนี้จะประยุกต์การจัดรูปแบบ 3D ให้กับกรอบข้อความแทนเนื้อหารูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อใดควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | จุดมองเห็น, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองแบบ perspective. | หมุนวัตถุในพื้นที่ 3D หรือให้ตรงกับการหมุน 3D ที่ตั้งล่วงหน้าของ PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | แสงตั้งล่วงหน้า, ทิศทาง, และการหมุนของแสง. | เปลี่ยนวิธีที่ไฮไลต์และเงาปรากฏบนพื้นผิว 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุผิวหน้า เช่น แบน, แมตต์, พลาสติก หรือ โลหะ. | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, มีเงางามหรือเป็นโลหะ. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างขยายออกไปจากหน้าหน้า. | แปลงรูปร่างแบนให้เป็นวัตถุ 3D ที่มองเห็นความหนา. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ดันออก. | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมสีหน้า. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ 3D. | ปรับความลึกให้เหมาะสมสำหรับรูปร่างหรือข้อความ โดยเฉพาะร่วมกับการตั้งค่า bevel และ material. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบยกหรือโค้งบนหน้าหน้าและด้านหลัง. | เพิ่มขอบที่นุ่มหรือขึ้นรูปแทนหน้าที่แบนและคม. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นขอบรอบวัตถุ 3D. | เน้นขอบเขตของวัตถุในผลลัพธ์ที่เรนเดอร์. |

## **สร้างรูปร่าง 3D**

- การตั้งค่ากล้อง เพราะมุมมองหน้าตั้งต้นอาจทำให้การดันออกไม่เห็น
- การตั้งค่าแสง เพราะแสงทำให้หน้าตาและด้านต่าง ๆ อ่านได้
- การตั้งค่าเนื้อวัสดุ เพราะพื้นผิวมีผลต่อการเรนเดอร์แสง
- การตั้งค่าการดันออกหรือความลึก เพราะรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า เพิ่มข้อความไปยังหน้าผาก และประยุกต์การจัดรูปแบบ 3D ค่าการหมุนของกล้องอยู่เป็นหน่วยองศา และความสูงของการดันออกคือ 100 จุด ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่ของขนาดเริ่มต้นและบันทึกการนำเสนอเป็น PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

ภาพสไลด์ที่เรนเดรแสดงสี่เหลี่ยมเป็นบล๊อก 3D หนา:

![สี่เหลี่ยม 3D สีน้ำเงินพร้อมข้อความ 3D สีขาวบนหน้าผาก](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดค่าจากแผง 3-D Rotation ค่า X, Y, และ Z ของการหมุนตรงกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง.

![แผง 3-D Rotation ของ PowerPoint แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลต์](img_02_01.png)

ใน Aspose.Slides ให้เข้าถึงกล้องผ่าน [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). ตัวอย่างนี้สร้างสี่เหลี่ยม เลือกมุมมองหน้าตรงเชิงมุมมอง และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, 40 องศาตามลำดับ โดยกำหนดรูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

ใช้กล้องเมื่อคุณต้องการเปลี่ยนมุมมองของผู้ชมต่อวัตถุ ไม่ได้เปลี่ยนรูปทรง 2D ของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์.

### **คัดลอกการวางตำแหน่งกล้องจากรูปร่างเทมเพลต**

เพื่อให้ตรงกับการวางตำแหน่งของรูปร่างเทมเพลต ให้อ่านการตั้งค่ากล้องล่วงหน้าของมันด้วย [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) และมุมการหมุนด้วย [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). ตัวอย่างเปิด `template.pptx` และคัดลอกการวางตำแหน่งกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3D อยู่แล้วและรูปร่างที่สองไม่มีการหมุนกล้องที่กำหนดไว้

มุมอยู่เป็นหน่วยองศา ดัชนี `0` คือละติจูด ดัชนี `1` คือลองจิจูด และดัชนี `2` คือการหมุน ส่งค่าตามลำดับไปยัง [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-)... หากแหล่งที่มาส่งคืน `null` หมายความไม่มีการหมุนที่กำหนดไว้ ดังนั้นให้ปล่อยมุมของรูปร่างที่สองไม่ตั้งค่า การหมุนที่กำหนดเป็น `(0, 0, 0)` จะคืนค่าเป็นศูนย์สามค่าและควรคัดลอก

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

เมื่อคุณเปิดไฟล์ `camera-copy.pptx` ใหม่ใน PowerPoint ลูกศรที่ด้านขวาจะมีการตั้งค่ากล้องและการหมุนเดียวกับสี่เหลี่ยมที่ด้านซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดันออกเดียวกัน

![สี่เหลี่ยม 3D สีน้ำเงินและลูกศรด้านขวาที่มีการวางตำแหน่งกล้องตรงกัน มองจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยขยายส่วนหลังของหน้าผาก ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และการควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint แสดงไปยังคุณสมบัติสีการดันออกและความสูงของการดันออก](img_02_02.png)

ใช้ [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) เพื่อกำหนดความหนาและ [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมมีการดันออก 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา รูปร่างถูกกำหนดในหน่วยความจำโดยไม่บันทึกไฟล์:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

เมธอด [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) ตั้งค่าความลึกของรูปร่าง 3D เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) ควบคุมความสูงของเอฟเฟกต์การดันออก ตามที่แสดงในตัวอย่างนี้.

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D ทำงานแยกจากการเติมสีของรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลาย, หรือรูปภาพไปยังหน้าผากและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันออกเหมือนเดิม

ตัวอย่างนี้ประยุกต์ไล่สีจากสีฟ้าไปสีส้มบนหน้าผากและสีส้มเข้มให้กับการดันออก 150 จุด ไล่สีหยุดที่ 0 และ 100 เป็นจุดเริ่มและสิ้นสุดของไล่สี ค่าการหมุนของกล้องอยู่เป็นหน่วยองศา สไลด์ถูกเรนเดอร์เป็นภาพ PNG ขนาดสองเท่ของขนาดเริ่มต้น:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนหน้าผากและเรนเดอร์การดันออกแยกจากกัน:

![สี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมไล่สีจากฟ้าส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพ ให้เพิ่มภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปร่าง ตัวอย่างนี้ต้องมีไฟล์ที่มีชื่อ "image.jpg" อยู่ในไดเรกทอรีทำงาน มันขยายรูปภาพให้เต็มสี่เหลี่ยม ประยุกต์การดันออก 150 จุด และตั้งค่าการหมุนกล้องเป็นองศา รูปร่างถูกกำหนดในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

![สี่เหลี่ยม 3D ที่เรนเดอร์ด้วยการเติมภาพบนหน้าผากและการดันออกสีส้ม](img_02_04.png)

## **ประยุกต์การจัดรูปแบบ 3D ให้กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อเนื้อหารูปร่าง การจัดรูปแบบ 3D ของข้อความส่งผลต่อกรอบข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์คล้าย WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยลายกริดสีส้มและสีขาว ประยุกต์โค้งขึ้นและกำหนดค่าการตั้งค่า 3D ผ่าน [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). ความสูงและความลึกของการดันออกอยู่เป็นหน่วยจุด และการหมุนของแสงเป็นองศา การเติมสีและเส้นขอบของรูปร่างถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างนี้เรนเดอร์ภาพ PNG ที่ขนาดสองเท่าของสไลด์เริ่มต้นและบันทึกการนำเสนอเป็น PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![ข้อความ 3D ที่เรนเดอร์ด้วยการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **รักษาข้อความให้แบนบนรูปร่าง 3D**

เพื่อให้ข้อความอ่านได้ขณะคงรูปร่าง 3D ให้เรียก [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) ผ่าน [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). เมื่อค่าที่ตั้งเป็น `true` ข้อความจะอยู่นอกฉาก 3D เมื่อเป็น `false` ข้อความจะเข้าร่วมในฉากและตามการวางตำแหน่ง 3D ของมัน

การตั้งค่านี้ไม่ลบการจัดรูปแบบ 3D ของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงถูกกำหนดผ่าน [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). นอกจากนี้ยังแตกต่างจากการหมุนทั่วไป [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) จะหมุนรูปร่างในระนาบสไลด์ ในขณะที่ [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) ควบคุมการหมุนแบบกำหนดของข้อความภายในกล่องของมัน การทำให้ข้อความอยู่นอกฉาก 3D จะไม่รีเซตมุมใด ๆ เหล่านั้น

ตัวอย่างต่อไปนี้ที่เป็นอิสระสร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาไว้ข้างๆ ด้านซ้ายและด้านขวา ทั้งสองรูปร่างมีการจัดรูปแบบ 3D เหมือนกัน; เพียงการตั้งค่าข้อความต่างกัน: `false` ด้านซ้ายและ `true` ด้านขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 จุด ตัวอย่างบันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของขนาดเริ่มต้น

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

ด้านซ้ายข้อความตามการวางตำแหน่ง 3D ด้านขวาข้อความคงแบนและอ่านง่ายขึ้น สี่เหลี่ยมทั้งสองคงการดันออกและการวางตำแหน่ง 3D ที่มองเห็นได้เหมือนกัน

![สี่เหลี่ยม 3D ข้างกัน: ข้อความตามการวางตำแหน่ง 3D ด้านซ้ายและคงแบนด้านขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3D ไว้เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ ฉาก 3D จะถูกแปลงเป็นภาพพิกเซลหรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2D ซึ่งใช้ได้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/androidjava/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/androidjava/convert-powerpoint-to-video/).

- ภาพและ PDF ที่ส่งออกไม่ได้เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก.
- ลักษณะสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ชุดแสง, วัสดุ, การดันออก, การเติมสี, และการปรับสเกลสไลด์.
- หากคุณต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงตามธีม ให้อ่าน [effective shape properties](/slides/th/androidjava/shape-effective-properties/).
- รูปแบบผลลัพธ์บางรูปแบบไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้.

## **FAQ**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D แบบโต้ตอบได้ไหม?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ แต่ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3D แบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงสามารถแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ประยุกต์กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3D มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและการดันออกหรือความลึก ในการปฏิบัติ ควรตั้งค่าชุดแสงและวัสดุด้วยเพื่อให้หน้าที่เรนเดอร์มีไฮไลต์และเงาชัดเจน

**ฉันสามารถประยุกต์เอฟเฟกต์ 3D ให้กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) สำหรับเนื้อหารูปร่างและ [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อตัวส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวีดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, PDF, HTML และเฟรมที่ใช้ในการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าที่สุดของ 3D หลังจากการสืบทอดและการตั้งค่าธีมถูกนำไปใช้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีผลจริงที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/androidjava/shape-effective-properties/) เพื่ออ่านค่ากล้อง, ชุดแสง, bevel, และค่าที่เกี่ยวข้องกับ 3D สุดท้าย