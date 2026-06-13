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
- การดึงออก 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint บน Android ด้วย Aspose.Slides กำหนดค่ากล้อง แสง วัสดุ การดึงออก การเติมสี และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถสร้าง แก้ไข รักษาและเรนเดอร์รูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน การดึงออก (extrusion) การเบเวล (bevel) แสง วัสดุ การไล่สีหรือการเติมภาพ และข้อความ 3 มิติ

{{% alert color="primary" %}}

บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบสแตนด์อโลน เมื่อคุณส่งออกสไลด์เป็นภาพ PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิตินี้ลงในผลลัพธ์ 2 มิติที่ส่งออก

{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้เมธอด [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปร่าง เมธอดจะคืนค่า [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/) ซึ่งควบคุมฉาก 3 มิติของรูปร่างนั้น

สำหรับข้อความ ให้ใช้เมธอด [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) ซึ่งจะนำการจัดรูปแบบ 3 มิติมาใช้กับกรอบข้อความแทนส่วนตัวของรูปร่าง

สมาชิก API ที่สำคัญที่สุดมีดังนี้

| สมาชิก API | ควบคุมอะไร | ควรใช้เมื่อใด |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | จุดมอง, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่ามาตรฐานการหมุน 3 มิติของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | การตั้งค่าแสง, ทิศทาง, การหมุนแสง | เปลี่ยนวิธีการแสดงไฮไลท์และเงาบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) และ [setMaterial](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | วัสดุผิว เช่น แบน, แมต, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบนกว่า, นุ่มกว่า, เงางามหรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | ระยะที่รูปร่างยืดออกจากผิวหน้าตรง | แปลงรูปร่างแบนให้เป็นวัตถุ 3 มิติที่มีความหนาเห็นได้ |
| [getExtrusionColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | สีของด้านที่ถูกดึงออก | ทำให้มิติของความลึกเห็นชัดหรือให้สีด้านสอดคล้องกับสีเติมหน้ากระดาษ |
| [getDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getDepth--) และ [setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกของรูปร่างหรือข้อความ โดยมักใช้ร่วมกับการตั้งค่าเบเวลและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) และ [getBevelBottom](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | ขอบยกหรือโค้งบนผิวหน้าหน้าและหลัง | เพิ่มขอบแบบนุ่มหรือแบบหล่อแทนการมีผิวแบนคม |
| [getContourColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), และ [setContourWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | เส้นรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างโดยทั่วไปต้องการการตั้งค่า 4 ประเภทก่อนจะดูเหมือน 3 มิติอย่างสมจริง

- ตั้งค่าแคเมร่า เนื่องจากมุมมองเริ่มต้นจากด้านหน้าอาจซ่อนการดึงออก
- ตั้งค่าแสง เพราะแสงทำให้ด้านและด้านข้างสามารถมองเห็นได้
- ตั้งค่าวัสดุ เพราะผิววัสดีส่งผลต่อการแสดงแสง
- ตั้งค่าการดึงออกหรือความลึก เพราะรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม เพิ่มข้อความบนผิวหน้า ตั้งค่าการจัดรูปแบบ 3 มิติ บันทึกพรีเซนเทชันเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

```java
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

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **หมุนรูปร่างด้วยแคเมร่า**

ใน PowerPoint การหมุน 3 มิติจะตั้งค่าจากแผง 3‑D Rotation ค่าการหมุน X, Y, Z สอดคล้องกับการตั้งค่าที่ทำผ่าน API ของแคเมร่า

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

ใน Aspose.Slides ตั้งค่าประเภทแคเมร่าและการหมุนผ่าน [IThreeDFormat.getCamera](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getCamera--) :

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

ใช้แคเมร่าเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ ไม่ได้เปลี่ยนรูปทรง 2 มิติของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการดึงออกและความลึก**

การดึงออกทำให้รูปร่างดูหนาโดยขยายไปด้านหลังผิวหน้า ใน PowerPoint การควบคุมความลึกกำหนดความหนาที่มองเห็นได้ ส่วนการควบคุมสีกำหนดสีของด้านข้าง

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

ตั้งค่า [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) เพื่อกำหนดความหนาและ [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) เพื่อกำหนดสีด้านข้าง :

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

ใช้ [IThreeDFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) เมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรง หรือผสานความลึกกับเบเวล, วัสดุ, และเอฟเฟกต์ข้อความ ในหลายกรณี `setExtrusionHeight` ให้ความชัดเจนมากกว่าเพราะบ่งบอกการดึงออกที่มองเห็นได้โดยตรง

## **ใช้การเติมไล่สีหรือภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติทำงานแยกจากการเติมรูปทรง คุณสามารถเติมสีทึบ, ไล่สี, แพทเทิร์น หรือภาพบนผิวหน้าและยังคงใช้แคเมร่า, แสง, วัสดุและการดึงออกได้เหมือนเดิม

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและตั้งค่าสีดึงออกที่เข้มกว่าแก่ด้านข้าง :

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนผิวหน้าและเรนเดอร์การดึงออกแยกจากกัน :

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

หากต้องการใช้การเติมภาพ ให้เพิ่มรูปภาพลงในพรีเซนเทชันและกำหนดให้เป็นการเติมรูปร่าง :

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

ภาพจะถูกเรนเดอร์บนผิวหน้า ส่วนการดึงออกจะถูกเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ :

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างจะมีผลต่อส่วนตัวของรูปร่าง ส่วนการจัดรูปแบบ 3 มิติของข้อความจะมีผลต่อกรอบข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์คล้าย WordArt ที่ต้องการให้ตัวอักษรเองมีการดึงออก, วัสดุ, แสง และการตั้งค่าแคเมร่า

ตัวอย่างต่อไปนี้สร้างข้อความที่เติมแพทเทิร์น, ใช้การแปลง WordArt, และตั้งค่า 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/) :

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

ข้อความจะถูกเรนเดอร์เป็นตัวอักษร 3 มิติแบบโค้ง, ดึงออก :

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3 มิติไว้เมื่บันทึกเป็นฟอร์แมต PowerPoint อย่าง PPTX เมื่อตรวจเรนเดอร์หรือส่งออกเป็นฟอร์แมตแบบคงที่ ฉาก 3 มิติจะถูกแรสเตอร์ไลซ์หรือวาดลงในผลลัพธ์เป็น 2 มิติ ซึ่งใช้ได้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/androidjava/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/androidjava/convert-powerpoint-to-video/)

ควรจำไว้ว่า:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นกับการรวมกันของแคเมร่า, light rig, วัสดุ, การดึงออก, การเติมและการย่อสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [effective shape properties](/slides/th/androidjava/shape-effective-properties/)
- ฟอร์แมตผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3 มิติแบบแก้ไขได้ ในฟอร์แมตเหล่านั้นผลลัพธ์จะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติแบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติจะคงอยู่ใน PowerPoint หากฟอร์แมตนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิตคืออะไร?**

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกเข้ามาในพรีเซนเทชัน ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความของ PowerPoint ปกติ เช่น การหมุน, ดึงออก, เบเวล, แสงและวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติเท่านั้น

**การตั้งค่าใดที่จำเป็นสำหรับรูปร่าง 3 มิติที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของแคเมร่าและตั้งค่าการดึงออกหรือความลึก ในทางปฏิบัติยังควรตั้งค่า light rig และวัสดุเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?**

ใช้ได้ ใช้ [IShape.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) สำหรับส่วนของรูปร่างและ [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ออกเป็น PDF, HTML หรือเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์แล้ว ไม่ใช่วัตถุ 3 มิติแบบแก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายใน [Shape Effective Properties](/slides/th/androidjava/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, เบเวลและค่าการจัดรูปแบบ 3 มิติที่เกี่ยวข้องสุดท้าย  