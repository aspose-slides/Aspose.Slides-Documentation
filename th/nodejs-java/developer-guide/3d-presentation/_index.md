---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอด้วย Node.js
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความของ PowerPoint ใน Node.js ด้วย Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D."
---
## **ภาพรวม**

Aspose.Slides for Node.js ผ่าน Java สามารถสร้าง, แก้ไข, รักษาและแสดงผลการจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน, การดันออก, การบีฟ, การจัดแสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3D.

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้เมธอด [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) เพื่อใช้การจัดรูปแบบ 3D กับรูปร่าง เมธอดนี้จะคืนค่า [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), ซึ่งควบคุมฉาก 3D สำหรับรูปร่างนั้น

สำหรับข้อความ ใช้เมธอด [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) วิธีนี้จะใช้การจัดรูปแบบ 3D กับเฟรมข้อความแทนที่จะเป็นเนื้อหารูปร่าง

สมาชิก API ที่สำคัญที่สุดคือ:

| สมาชิก API | ควบคุมอะไร | เมื่อใดที่จะใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | มุมมอง, ประเภทกล้องตั้งค่า, การหมุน, การซูม, และการมองเชิงลึก | หมุนวัตถุในพื้นที่ 3D หรือให้สอดคล้องกับการตั้งค่าสะเทศการหมุน 3D ของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | การตั้งค่าแสง, ทิศทาง, และการหมุนแสง | เปลี่ยนวิธีการแสดงไฮไลท์และเงาบนพื้นผิว 3D |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | วัสดุผิวหน้า เช่น แบน, แมต, พลาสติก หรือ โลหะ | ทำให้รูปร่างเดียวกันดูแบนขึ้น, นุ่มขึ้น, มันวาว หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปร่างยืดออกไปข้างหลังจากหน้าผาก | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3D ที่มีความหนาที่มองเห็นได้ |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ถูกดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าผาก |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | ความลึก 3D เพิ่มเติมที่ใช้โดยการจัดรูปแบบ 3D ของ PowerPoint | ปรับความลึกให้ละเอียดสำหรับรูปร่างหรือข้อความ, โดยเฉพาะร่วมกับการตั้งค่าบีฟและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | ขอบที่ยกสูงหรือโค้งบนหน้าผากและด้านหลัง | เพิ่มขอบที่นุ่มหรือหล่อรูปแทนหน้าผากแบนคม |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | เส้นขอบรอบวัตถุ 3D | เน้นเส้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3D**

โดยทั่วไปรูปร่างต้องการการตั้งค่า 4 ประเภทก่อนที่จะดูเหมือน 3D อย่างเชื่อถือได้:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าตรงค่าเริ่มต้นอาจซ่อนการดันออก.
- การตั้งค่าแสง, เนื่องจากแสงทำให้หน้าและด้านอ่านได้.
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง.
- การตั้งค่าการดันออกหรือความลึก, เนื่องจากรูปร่างแบนต้องการความหนา.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนหน้าผาก, และใช้การจัดรูปแบบ 3D ค่าในการหมุนกล้องเป็นองศาและความสูงการดันออกเป็น 100 พอยต์ ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ที่สองเท่าของขนาดค่าเริ่มต้นและบันทึกการนำเสนอเป็น PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3D หนาขึ้น:

![สี่เหลี่ยม 3D สีน้ำเงินที่เรนเดอร์พร้อมข้อความ 3D สีขาวบนหน้าผาก](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดจากแผง 3-D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง.

![แผง 3-D Rotation ของ PowerPoint แสดงค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides ให้เข้าถึงกล้องผ่าน [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้าแบบออร์โธกราฟิก, และกำหนดการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ ตัวอย่างนี้กำหนดค่าให้รูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมเห็นวัตถุ มันไม่เปลี่ยนรูปทรง 2D ของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

### **คัดลอกการวางแนวกล้องจากรูปร่างแม่แบบ**

เพื่อให้ตรงกับการวางแนวของรูปร่างแม่แบบ ให้อ่านการตั้งค่ากล้องของมันด้วย [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) และมุมการหมุนด้วย [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) ตัวอย่างนี้เปิด `template.pptx` แล้วคัดลอกการวางแนวกล้องจากรูปร่างแรกบนสไลด์แรกไปยังรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3D อยู่แล้ว และรูปร่างที่สองไม่มีการหมุนกล้องที่ชัดเจน

มุมเป็นองศา. ดัชนี `0` คือ latitude, ดัชนี `1` คือ longitude, ดัชนี `2` คือ revolution. ส่งค่าตามลำดับนี้ไปยัง [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation). หากแหล่งคืนค่า `null` แปลว่าไม่มีการหมุนที่ชัดเจน จึงปล่อยให้มุมของรูปร่างที่สองไม่มีการตั้งค่า การหมุนที่ชัดเจนของ `(0, 0, 0)` จะคืนค่าเป็นศูนย์สามค่าและควรคัดลอก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมื่อคุณเปิด `camera-copy.pptx` ใน PowerPoint อีกครั้ง ลูกศรทางขวาจะมีการตั้งค่ากล้องและการหมุนเดียวกับสี่เหลี่ยมทางซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดันออกเดียวกัน

![สี่เหลี่ยม 3D สีน้ำเงินและลูกศรด้านขวาที่มีการวางแนวกล้องตรงกัน, มองจากด้านบนและด้านขวา](camera-orientation.png)

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาด้วยการขยายไปด้านหลังจากหน้าผาก ใน PowerPoint ควบคุมความลึกกำหนดความหนาที่มองเห็นได้และควบคุมสีกำหนดสีของด้านข้าง

![การควบคุมความลึกของ PowerPoint แสดงการแมปสีการดันออกและคุณสมบัติความสูงการดันออก](img_02_02.png)

ใช้ [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) เพื่อตั้งค่าความหนาและ [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) เพื่อเข้าถึงสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมมีการดันออก 100 พอยต์พร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา ตัวอย่างนี้กำหนดค่าให้รูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

เมธอด [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) ตั้งค่าความลึกของรูปร่าง 3D เมธอด [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) ควบคุมความสูงของเอฟเฟกต์การดันออกตามตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D ไม่ได้ขึ้นกับการเติมของรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลายแพทเทิร์น หรือรูปภาพลงบนหน้าผากและยังคงใช้กล้อง, แสง, วัสดุ, และการตั้งค่าการดันออกเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีจากน้ำเงินไปส้มบนหน้าผากและสีส้มเข้มสำหรับการดันออก 150 พอยต์ การไล่สีที่จุด 0 และ 100 แสดงจุดเริ่มและสิ้นสุดของการไล่สี ค่าในการหมุนกล้องเป็นองศา สไลด์ถูกเรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของค่าเริ่มต้น:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

ภาพผลลัพธ์ที่เรนเดอร์คงการไล่สีบนหน้าผากและเรนเดอร์การดันออกแยกกัน:

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการไล่สีจากน้ำเงินไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน ให้เพิ่มรูปภาพลงในการนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง ตัวอย่างนี้ต้องมีไฟล์ชื่อ "image.jpg" อยู่ในไดเรกทอรีทำงาน มันจะขยายรูปเพื่อเติมสี่เหลี่ยม, ใช้การดันออก 150 พอยต์, และตั้งค่าการหมุนกล้องเป็นองศา ตัวอย่างนี้กำหนดค่าให้รูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

รูปภาพจะถูกเรนเดอร์บนหน้าผาก, ส่วนการดันออกจะถูกเรนเดอร์เป็นพื้นผิวด้าน 3D:

![สี่เหลี่ยม 3D ที่เรนเดอร์พร้อมการเติมรูปภาพบนหน้าผากและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อเนื้อหารูปร่าง การจัดรูปแบบ 3D ของข้อความส่งผลต่อเฟรมข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยลายกริดสีส้มและสีขาว, ใช้โค้งด้านบน, และกำหนดค่าการตั้งค่า 3D ผ่าน [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) ความสูงการดันออกและความลึกเป็นพอยต์, การหมุนแสงเป็นองศา การเติมและเส้นขอบของรูปร่างถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างนี้เรนเดอร์ภาพ PNG ขนาดสองเท่าของสไลด์และบันทึกการนำเสนอเป็น PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ข้อความถูกเรนเดอร์เป็นตัวอักษรโค้ง 3D ที่ดันออก:

![ข้อความ 3D ที่เรนเดอร์เป็นเส้นโค้ง, การดันออกแบบ WordArt, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **เก็บข้อความให้แบนบนรูปร่าง 3D**

เพื่อให้ข้อความอ่านง่ายในขณะที่รักษารูปร่าง 3D อยู่ ให้เรียก [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) ผ่าน [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) เมื่อค่เป็น `true` ข้อความจะอยู่นอกฉาก 3D เมื่อเป็น `false` ข้อความจะเข้าร่วมในฉากและตามการวางแนว 3D

การตั้งค่านี้ไม่ลบการจัดรูปแบบ 3D ของรูปร่าง: กล้อง, แสง, วัสดุ, และการดันออกยังคงกำหนดผ่าน [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) อีกทั้งแตกต่างจากการหมุนทั่วไป [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) หมุนรูปร่างในระนาบสไลด์, ในขณะ [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) ควบคุมการหมุนที่กำหนดของข้อความภายในกรอบ ไม่ว่าให้ข้อความอยู่นอกหรือในฉาก 3D จะไม่รีเซ็ตมุมเหล่านั้น

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาไว้ข้างๆ ทั้งสองรูปร่างมีการจัดรูปแบบ 3D เดียวกัน; เพียงการตั้งค่าข้อความแตกต่าง: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการดันออกเป็น 40 พอยต์ ตัวอย่างนี้บันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่าของค่าเริ่มต้น:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

ทางซ้ายข้อความตามการวางแนว 3D; ทางขวาข้อความคงแบนและอ่านง่าย ทั้งสองสี่เหลี่ยมคงการดันออกและการวางแนว 3D เหมือนกัน:

![สี่เหลี่ยม 3D คู่ขนาน: ข้อความตามการวางแนว 3D ทางด้านซ้ายและคงแบนด้านขวา](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ ฉาก 3D จะถูกแปลงเป็นเรสเตอร์หรือวาดลงในผลลัพธ์เป็น 2D นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/nodejs-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/nodejs-java/convert-powerpoint-to-video/)

จำไว้ว่าเรื่องต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่ใช่แบบโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังจากส่งออกได้.
- ลักษณะสุดท้ายขึ้นอยู่กับการรวมกันของกล้อง, แสง, วัสดุ, การดันออก, การเติม, และการปรับขนาดสไลด์.
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม, ให้อ่าน [คุณสมบัติรูปร่างที่มีผล](/slides/th/nodejs-java/shape-effective-properties/).
- รูแบบเอาต์พุตบางอย่างไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่สามารถแก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ที่แสดงจะถูกเรนเดอร์แทนที่จะถูกเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้.

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D แบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF หรือหน้า HTML กลายเป็นฉาก 3D แบบโต้ตอบที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงแก้ไขได้ใน PowerPoint เมื่อรูปแบบรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่แทรกเข้าไปในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความ PowerPoint ปกติ เช่น การหมุน, การดันออก, การบีฟ, การจัดแสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างสำหรับรูปร่าง 3D ที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดันออกหรือความลึก ในทางปฏิบัติควรตั้งค่าแสงและวัสดุด้วยเพื่อให้พื้นผิวที่เรนเดอร์มีไฮไลท์และเงาที่ชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความได้หรือไม่?**

ใช่. ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) กับเนื้อหารูปร่างและ [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) กับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่. Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับแปลงเป็นวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์, ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่า 3D สุดท้ายหลังการสืบทอดและตั้งค่าธีมได้หรือไม่?**

ใช่. ใช้ API การจัดรูปแบบที่มีผลที่อธิบายใน [คุณสมบัติรูปร่างที่มีผล](/slides/th/nodejs-java/shape-effective-properties/) เพื่ออ่านกล้อง, แสง, บีฟ, และค่า 3D ที่เกี่ยวข้องอื่นๆ ที่สุดท้าย.