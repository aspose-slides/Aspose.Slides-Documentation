---
title: จำกัดการแก้ไขการนำเสนอด้วยการล็อครูปทรงใน Node.js
linktitle: จำกัดการแก้ไขการนำเสนอ
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
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Node.js via Java เพื่อจำกัดการเลือก, การเคลื่อนที่, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้ทั่วไปของ Aspose.Slides for Node.js via Java คือการสร้าง, ปรับปรุงและบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจได้

บทความนี้อธิบายว่ารูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใส่และลบการล็อครูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูป

## **องค์ประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for Node.js via Java แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจ็กต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)  

ประเภทของรูปทรงที่แตกต่างกันเปิดเผยตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) เป็นคลาสพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for Node.js via Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) locks picture frames.  

เพื่อใช้ล็อกบน [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), ให้วนลูปผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรึกรูปแบบที่รองรับแต่ละรูป

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขการนำเสนอที่รองรับใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [การตั้งค่าการป้องกันการนำเสนอ](/slides/th/nodejs-java/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Node.js via Java มีคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked), และ [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับ autoshapes, พร้อมล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดการนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่ไม่อยู่ในสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่วนผ่านรูปทรงลูกภายในกลุ่ม

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

### **ลบการป้องกัน**

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). นอกจากนี้ยังลบข้อจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked), แล้วบันทึกสำเนาของการนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะคงไว้โดยไม่มีการเปลี่ยนแปลง

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

วางรูปภาพชื่อ `photo.jpg` ในไดเรกทอรีทำงาน ตัวอย่างทำการครอป 12% จากด้านซ้ายและ 8% จากด้านขวา, แล้วเรียก [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) บนล็อกของกรอบรูปภาพ การส่งค่า `true` จะจำกัดการครอปเพิ่มเติมและรักษาการครอปที่มีอยู่

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

`PictureLocked.pptx` เก็บล็อกการครอปเป็นค่า `true`. ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกรูปภาพ

### **เก็บแผนภาพเป็นกลุ่ม**

ตัวอย่างทำการจัดกลุ่มสี่เหลี่ยมและลูกศร, แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) บนล็อกของกลุ่มเพื่อรักษาส่วนประกอบของแผนภาพให้คงอยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงใช้ได้

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

`DiagramLocked.pptx` เก็บล็อกการยกเลิกการจัดกลุ่มเป็นค่า `true`. ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกแผนภาพทั้งหมด

### **รายงานการล็อกรูปทรงที่มีอยู่**

เพื่อรีวิวเทมเพลต, เปิดไฟล์และอ่านอ็อบเจ็กต์ล็อกจากแต่ละรูปทรง เมธอด [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) จะคืนค่า `true` เมื่อแฟล็กทั้งหมดบนอ็อบเจ็กต์นั้นถูกปิดและคืนค่า `false` เมื่ออย่างน้อยหนึ่งแฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อคแยกกัน ดังนั้นจึงตรวจสอบลูกแม้ว่าในกลุ่มจะไม่มีล็อก

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับ autoshapes, กรอบรูปภาพ, และกลุ่ม รวมถึงตรวจสอบการครอปสำหรับรูปภาพและการยกเลิกการจัดกลุ่มสำหรับกลุ่ม รายงานจะแสดงรายการแฟล็กที่เปิดที่มันรับรู้และทำเครื่องหมายประเภทรูปทรงที่ไม่ได้ตรวจสอบ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

สมมติว่ากระดาษสไลด์ที่ 1 ของ `Sample.pptx` มีกลุ่มชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` ภายในกลุ่มที่ล็อกการครอป, และสี่เหลี่ยมปลดล็อกชื่อ `Free`. รายงานจะข้าม `Free` และพิมพ์บรรทัดสองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านแฟล็กการแก้ไขระดับรูปทรงที่เก็บไว้โดยไม่เปลี่ยนแปลงหรือบันทึกการนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าที่แยกออกจากกัน และการบังคับใช้แต่ละแฟล็กขึ้นอยู่กับโปรแกรมแก้ไข

## **สรุป**

Aspose.Slides for Node.js via Java ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถผสมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ส่วน [การป้องกันด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ใช่ ใช้ล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละรูปภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชันที่เมธอด [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) ของกลุ่มคืนมาและใส่ล็อกที่เหมาะสมกับแต่ละรูปทรงลูก ทำซ้ำสำหรับกลุ่มที่ซ้อนกันตามการเดินทางในตัวอย่างรายงาน