---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอโดยใช้ Node.js
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "นำไปใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความของ PowerPoint ใน Node.js ด้วย Aspose.Slides. ตั้งค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Node.js ผ่าน Java สามารถสร้าง, แก้ไข, คงไว้ และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้จะอธิบายเกี่ยวกับเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดันออก, การตัดมุม, การให้แสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3 มิติ

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบอิสระ เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF, หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` เพื่อใช้การจัดรูปแบบ 3 มิติกับรูปร่าง วัตถุที่คืนค่ามาเป็น [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) จะควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ใช้ [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` การจัดรูปแบบ 3 มิติจะถูกนำไปใช้กับกรอบข้อความแทนส่วนเนื้อหาของรูปร่าง

สมาชิก API ที่สำคัญที่สุดมีดังนี้:

| สมาชิก API | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getCamera) | มุมมอง, ประเภทกล้องที่ตั้งไว้, การหมุน, การซูม, และมุมมองเชิงลึก | หมุนวัตถุในพื้นที่ 3 มิติหรือใช้ค่าพรีเซ็ตการหมุน 3 มิติของ PowerPoint |
| [getLightRig](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getLightRig) | พรีเซ็ตแสง, ทิศทาง, และการหมุนแสง | ปรับการแสดงไฮไลต์และเงาบนพื้นผิว 3 มิติ |
| [getMaterial](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getMaterial) และ [setMaterial](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#setMaterial) | วัสดุผิวหน้า เช่น แบน, ฐาน, พลาสติก, หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบน, นุ่ม, แววเงา หรือเป็นโลหะ |
| [getExtrusionHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) และ [setExtrusionHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | ระยะที่รูปร่างยืดออกจากหน้าหน้า | แปลงรูปร่างแบนให้เป็นวัตถุ 3 มิติที่มีความหนาเห็นได้ชัด |
| [getExtrusionColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | สีของด้านที่ดันออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านข้างกับการเติมหน้าหน้า |
| [getDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getDepth) และ [setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#setDepth) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกสำหรับรูปร่างหรือข้อความ โดยเฉพาะร่วมกับการตั้งค่าตัดมุมและวัสดุ |
| [getBevelTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getBevelTop) และ [getBevelBottom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | ขอบที่ยกหรือโค้งบนหน้าหน้าและหลัง | เพิ่มขอบที่นุ่มนวลหรือขึ้นรูปแทนการทำให้เป็นแผ่นแหลมคม |
| [getContourColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getContourWidth), และ [setContourWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#setContourWidth) | เส้นรอบวัตถุ 3 มิติ | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

โดยทั่วไปรูปร่างต้องการการตั้งค่าสี่ประเภทก่อนที่มันจะดูเหมือน 3 มิติอย่างน่าเชื่อถือ:

- การตั้งค่ากล้อง เนื่องจากมุมมองเริ่มต้นอาจทำให้การดันออกไม่เห็น
- การตั้งค่าแสง เนื่องจากแสงทำให้ด้านและข้างสามารถมองเห็นได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวมีผลต่อการเรนเดอร์แสง
- การตั้งค่าดันออกหรือความลึก เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนหน้าหน้า, ใช้การจัดรูปแบบ 3 มิติ, บันทึกการนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

ภาพสไลด์ที่เรนเดอร์จะแสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีน้ำเงินที่เรนเดอร์พร้อมข้อความ 3 มิติสีขาวบนหน้าหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติกำหนดจากแผง 3‑D Rotation ค่าการหมุน X, Y, และ Z ตรงกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง 3‑D Rotation ของ PowerPoint พร้อมค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าประเภทกล้องและการหมุนผ่าน 3 D format ที่คืนค่ามาโดย `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ ไม่ได้เปลี่ยนรูปทรง 2 D ของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3 D ที่ PowerPoint และ Aspose.Slides ใช้ขณะเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปร่างดูหนาโดยการขยายออกจากหน้าหน้า ใน PowerPoint ตัวควบคุมความลึกกำหนดความหนาที่มองเห็นได้และตัวควบคุมสีกำหนดสีของด้านข้าง

![ตัวควบคุมความลึกของ PowerPoint เชื่อมกับคุณสมบัติสีดันออกและความสูงการดันออก](img_02_02.png)

ตั้งค่าความสูงการดันออกเพื่อกำหนดความหนาและสีการดันออกเพื่อกำหนดสีด้านข้าง:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

ใช้การตั้งค่าความลึกเมื่อคุณต้องทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับการตัดมุม, วัสดุ, และเอฟเฟกต์ข้อความ ในหลายกรณีของรูปร่าง ความสูงการดันออกเป็นการตั้งค่าที่ชัดเจนกว่าเพราะแสดงความหนาที่มองเห็นได้โดยตรง

## **ใช้การเติมไล่สีหรือรูปภาพร่วมกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติทำงานแยกจากการเติมรูปทรง คุณสามารถเติมสีเริ่มต้น, ไล่สี, ลวดลาย, หรือรูปภาพบนหน้าหน้าและยังคงใช้กล้อง, แสง, วัสดุ, และการดันออกเดียวกันได้

ตัวอย่างนี้เติมไล่สีให้กับรูปร่างและใช้สีดันออกที่เข้มกว่าในด้านข้าง:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

ผลลัพธ์ที่เรนเดอร์คงไล่สีบนหน้าหน้าและเรนเดอร์การดันออกแยกต่างหาก:

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมไล่สีจากสีน้ำเงินไปส้มและการดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน ให้เพิ่มรูปภาพลงในการนำเสนอและกำหนดให้เป็นการเติมของรูปร่าง:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

รูปภาพจะเรนเดอร์บนหน้าหน้า ขณะเดียวกันการดันออกจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ:

![สี่เหลี่ยม 3 มิติที่เรนเดอร์พร้อมการเติมรูปภาพบนหน้าหน้าและการดันออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างมีผลต่อเนื้อหาของรูปร่าง ส่วนการจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ตัวอักษรต้องการการดันออก, วัสดุ, การให้แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลวดลาย, ใช้การแปลง WordArt, และกำหนดค่าการตั้งค่า 3 มิติบน [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/):

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

ข้อความจะแสดงเป็นตัวอักษร 3 มิติที่โค้ง, ดันออก:

![ข้อความ 3 มิติที่เรนเดอร์พร้อมการแปลง WordArt แบบโค้ง, การเติมลวดลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบเลย์เอาต์คงที่ ฉาก 3 มิติจะถูกแปลงเป็นรูปแบบเรสเตอร์หรือวาดลงในผลลัพธ์เป็นผลลัพธ์ 2 มิติ ซึ่งใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/nodejs-java/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/nodejs-java/convert-powerpoint-to-video/)

ควรจำจุดต่อไปนี้:

- ภาพและ PDF ที่ส่งออกไม่สามารถโต้ตอบได้ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- ลุคสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, แสง, วัสดุ, การดันออก, การเติม, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือมาจากธีม ให้อ่าน [effective shape properties](/slides/th/nodejs-java/shape-effective-properties/)
- รูปแบบผลลัพธ์บางประเภทไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนที่จะคงเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติที่โต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

**ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?**

โมเดล 3 มิติเป็นวัตถุ 3 มิติแยกที่แทรกเข้ามาในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, การดันออก, การตัดมุม, การให้แสง, และวัสดุ บทความนี้อธิบายเฉพาะเอฟเฟกต์ 3 มิติ

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปร่าง 3 มิติปรากฏเห็น?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและตั้งค่าการดันออกหรือความลึก จริง ๆ แล้วควรตั้งค่าแสงและวัสดุด้วยเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาที่ชัดเจน

**สามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความพร้อมกันได้หรือไม่?**

ทำได้ ใช้ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` สำหรับส่วนเนื้อหารูปร่างและ [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` สำหรับข้อความ

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, ผลลัพธ์ HTML, และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลุคที่เรนเดอร์แล้ว ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

**สามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมได้หรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่เป็นผลลัพธ์ที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/nodejs-java/shape-effective-properties/) เพื่ออ่านค่ากล้อง, แสง, การตัดมุม, และค่า 3 มิติอื่น ๆ ที่สุดท้ายได้