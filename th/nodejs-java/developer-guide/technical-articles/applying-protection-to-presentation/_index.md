---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน Node.js
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/nodejs-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีล็อคและปลดล็อครูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Node.js via Java เพื่อจำกัดการเลือก, การย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้ Aspose.Slides for Node.js via Java อย่างทั่วไปคือการสร้าง, ปรับปรุง, และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอนี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาโครงร่างและเนื้อหาเดิมได้

บทความนี้อธิบายว่ารูปทรงถูกจัดเรียงบนสไลด์อย่างไร และวิธีการใส่และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น รูปทรงอัตโนมัติ, ตาราง, วัตถุ OLE, กลุ่มรูปทรง, กรอบภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Node.js via Java แต่ละองค์ประกอบบนสไลด์จะแทนด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)

ประเภทรูปทรงต่าง ๆ มีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) เป็นคลาสพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for Node.js via Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) ล็อกรูปทรงอัตโนมัติ  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) ล็อกรูปทรงเชื่อมต่อ  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) ล็อกกลุ่มรูปทรง  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) ล็อกกรอบภาพ  

เพื่อใส่การล็อกทั่วทั้งหมดใน [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละประเภท

## **ใส่และลบการปกป้อง**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละอย่าง การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/nodejs-java/password-protected-presentation/) ที่แยกออกจากกัน

### **ใส่การปกป้องให้กับรูปทรง PPTX**

Aspose.Slides for Node.js via Java มีคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), และ [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับรูปทรงอัตโนมัติ พร้อมด้วยการล็อกที่เทียบเท่าสำหรับกลุ่มรูปทรง, ตัวเชื่อมต่อ, และกรอบภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) เพื่อจำกัดการย้าย; กลุ่มรูปทรงยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่ ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์ และบันทึกสำเนาพร้อมกับการจำกัดเหล่านี้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่ได้วนผ่านรูปทรงย่อยภายในกลุ่ม

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ลบการปกป้อง**

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าที่ `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การย้าย, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) อีกทั้งยังลบการจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงไว้ตามเดิม

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **รักษาการครอปรูปภาพ**

วางไฟล์รูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการครอป 12 % จากด้านซ้ายและ 8 % จากด้านขวา แล้วเรียก [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) บนล็อกของกรอบภาพ การส่งค่า `true` จะจำกัดการครอปเพิ่มเติมและคงการครอปเดิมไว้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` จะบันทึกล็อกการครอปเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกรูปภาพ

### **รักษาการจัดกลุ่มของแผนผัง**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) บนล็อกของกลุ่มเพื่อให้แผนผังไม่สามารถถอดกลุ่มได้ รูปแบบการแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงทำได้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` จะบันทึกล็อกการถอดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกแผนผังทั้งหมด

### **สรุป**

Aspose.Slides for Node.js via Java ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันทั่วสไลด์ทั้งหมด เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปทรง และตั้งค่าเป็น `false` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงกับการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ในขณะที่ [password protection](/slides/th/nodejs-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างพร้อมกันในไฟล์เดียว

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ ให้ใส่ล็อกเพียงบนรูปทรงในสไลด์ที่เลือก การกระทำนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใส่ล็อกบนรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชันที่ได้จากเมธอด [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) ของกลุ่ม แล้วใส่ล็อกที่เหมาะสมให้กับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มซ้อนกัน ตัวอย่างด้านบนจะประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์ จึงไม่ได้ตั้งค่าล็อกบนสมาชิกของกลุ่มแต่ละอัน