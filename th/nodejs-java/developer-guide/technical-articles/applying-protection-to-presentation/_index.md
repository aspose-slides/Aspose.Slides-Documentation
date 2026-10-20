---
title: จำกัดการแก้ไขการนำเสนอด้วยการล็อกรูปทรงใน Node.js
linktitle: จำกัดการแก้ไขการนำเสนอ
type: docs
weight: 60
url: /th/nodejs-java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันจากการแก้ไข
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
description: "เรียนรู้วิธีการล็อคและปลดล็อกรูปทรงในไฟล์ PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อจำกัดการเลือก การเคลื่อนย้าย การปรับขนาด และการจัดกลุ่ม"
---
## **ภาพรวม**

การใช้ Aspose.Slides for Node.js ผ่าน Java อย่างทั่วไปคือการสร้าง, ปรับปรุง, และบันทึกการนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการอัตโนมัติ เมื่อผู้ใช้ได้รับการนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายถึงวิธีการจัดระเบียบรูปทรงบนสไลด์และวิธีการใช้และลบการล็อกรูปทรงในไฟล์ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละชิ้น

## **ส่วนประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, เฟรมภาพ, เฟรมวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for Node.js ผ่าน Java แต่ละองค์ประกอบบนสไลด์จะแสดงด้วยอ็อบเจกต์ที่สืบทอดจากคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 

ประเภทรูปทรงที่แตกต่างกันจะมีตัวเลือกการล็อกที่แตกต่างกัน คลาส [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) เป็นคลาสฐานสำหรับการล็อกรูปทรง Aspose.Slides for Node.js ผ่าน Java มีคลาสล็อกต่อไปนี้:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) ล็อก autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) ล็อกรูปแบบตัวเชื่อมต่อ.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) ล็อกรูปทรงที่จัดกลุ่ม.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) ล็อกจากเฟรมภาพ.  

เพื่อใช้การล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), ให้วนซ้ำผ่านสไลด์ของมันและกำหนดล็อกที่เหมาะสมกับรูปทรงที่รองรับแต่ละอัน

## **ใช้และลบการป้องกัน**

การล็อกรูปทรงจำกัดการดำเนินการเช่น การเลือก, การย้าย, และการปรับขนาดรูปทรง พวกมันไม่ได้ทำให้การนำเสนอทั้งหมดเป็นแบบไม่แก้ไขได้

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Node.js ผ่าน Java มีคลาส [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) และ [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) ด้วยค่า `true` สำหรับ autoshapes, พร้อมล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และเฟรมภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) เพื่อการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดการนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะถูกทิ้งไว้โดยไม่เปลี่ยนแปลง การวนลูปจะไม่เดินทางผ่านรูปทรงลูกภายในกลุ่ม

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

เพื่อเอาการล็อกรูปทรงออก, ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดการนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), และ [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) นอกจากนี้ยังลบข้อจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) และบันทึกสำเนาของการนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงไว้โดยไม่มีการเปลี่ยนแปลง

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

### **สรุป**

Aspose.Slides for Node.js ผ่าน Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละชิ้นหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปทรง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในการนำเสนอเดียวกันได้หรือไม่?**

ใช่ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ, ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขการนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะได้โดยไม่กระทบต่อสไลด์อื่นหรือไม่?**

ใช่ ให้ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือกเท่านั้น สิ่งนี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละชิ้นภายในกลุ่มได้อย่างไร?**

วนซ้ำผ่านคอลเลกชันที่คืนค่าจากเมธอด [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) ของกลุ่มและใช้การล็อกที่เหมาะสมกับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์ จึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละตัว