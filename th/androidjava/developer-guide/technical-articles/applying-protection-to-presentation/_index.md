---
title: "จำกัดการแก้ไขงานนำเสนอด้วยล็อกรูปทรงบน Android"
linktitle: "จำกัดการแก้ไขงานนำเสนอ"
type: docs
weight: 60
url: /th/androidjava/applying-protection-to-presentation/
keywords:
- "ป้องกันการแก้ไข"
- "ปกป้องจากการแก้ไข"
- "ล็อกรูปทรง"
- "ล็อกตำแหน่ง"
- "ล็อกการเลือก"
- "ล็อกการปรับขนาด"
- "ล็อกการจัดกลุ่ม"
- "PowerPoint"
- "PPTX"
- "งานนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Android via Java เพื่อจำกัดการเลือก, การย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้งานทั่วไปของ Aspose.Slides for Android via Java คือการสร้าง, ปรับปรุง, และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาเลย์เอาต์และเนื้อหาที่ตั้งใจไว้

บทความนี้อธิบายวิธีการจัดระเบียบรูปทรงบนสไลด์และวิธีการใช้และลบล็อกรูปทรงในงานนำเสนอ PPTX ล็อกเหล่านี้จะช่วยจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูป

## **โครงสร้างของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น รูปทรงอัตโนมัติ, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Android via Java แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจ็กต์ที่ทำงานตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปทรงที่ต่างกันจะแสดงตัวเลือกล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซพื้นฐานสำหรับล็อกรูปทรง Aspose.Slides for Android via Java มีอินเทอร์เฟซล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ล็อกรูปทรงอัตโนมัติ.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) ล็อกรูปทรงตัวเชื่อมต่อ.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) ล็อกรูปทรงกลุ่ม.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) ล็อกกรอบรูปภาพ.  

เพื่อใช้ล็อกกับ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ทั้งหมด ให้วนรอบสไลด์ของมันและตั้งค่าล็อกที่เหมาะสมบนแต่ละรูปทรงที่รองรับ

## **ใช้และลบการป้องกัน**

ล็อกรูปทรงจำกัดการดำเนินการเช่น การเลือก, การย้าย, และการปรับขนาดรูปทรง พวกมันไม่ได้ทำให้ทั้งงานนำเสนอไม่สามารถแก้ไขได้

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Android via Java ให้บริการอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) สำหรับทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้เมธอด [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), และ [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) ด้วยค่า `true` สำหรับรูปทรงอัตโนมัติ และใช้ล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้เมธอด [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) เพื่อย้าย; กลุ่มก็ใช้เมธอด [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้กำหนดไว้ รูปทรงที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปนี้จะไม่ไล่เรียกรูปทรงลูกภายในกลุ่ม

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ลบการป้องกัน**

เพื่อเอาล็อกรูปทรงออก ให้ตั้งค่าเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีล็อกรูปทรงและล้างข้อจำกัดการเลือก, การย้าย, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) อีกทั้งยังเอาข้อจำกัดการจัดกลุ่มออกโดยส่งค่า `false` ไปยังเมธอด [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่เช่นเดิม

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สรุป**

Aspose.Slides for Android via Java ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละรูปหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกใช้ล็อกที่รองรับโดยแต่ละประเภทรูปทรง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่. ล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะส่วน ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/androidjava/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ใช่. ให้ใช้ล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนแปลงการตั้งค่าล็อกบนสไลด์อื่น ๆ

**ฉันจะใช้ล็อกกับรูปทรงเดี่ยวภายในกลุ่มอย่างไร?**

ให้วนรอบคอลเลกชันที่ส่งกลับโดยเมธอด [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่ม แล้วใช้ล็อกที่เหมาะสมกับรูปทรงลูกแต่ละรูป ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าล็อกบนสมาชิกกลุ่มเดี่ยวแต่ละรายการ