---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน Java
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/java/applying-protection-to-presentation/
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาดและการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Java คือการสร้าง, อัปเดตและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดเลย์เอาต์และเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปทรงจัดระเบียบบนสไลด์อย่างไรและวิธีการใส่และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **องค์ประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปทรงที่รวมกลุ่ม, กรอบภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Java แต่ละองค์ประกอบบนสไลด์จะแสดงเป็นอ็อบเจกต์ที่ทำการ implement อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปทรงที่แตกต่างกันมีตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for Java มีอินเทอร์เฟซการล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) ล็อกรูปทรงตัวเชื่อมต่อ.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) ล็อกรูปทรงกลุ่ม.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) ล็อกกรอบภาพ.  

เพื่อใส่การล็อกบน [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ทั้งหมด ให้วนผ่านสไลด์ของมันและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละรูปทรง

## **ใส่และลบการปกป้อง**

การล็อกรูปทรงจำกัดการดำเนินการเช่น การเลือก, การย้ายและการปรับขนาดรูปทรง พวกมันไม่ได้ทำให้ทั้งงานนำเสนอไม่สามารถแก้ไขได้

### **ใส่การปกป้องให้กับรูปทรง PPTX**

Aspose.Slides for Java มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) และ [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) ด้วยค่า `true` สำหรับ autoshapes, พร้อมการล็อกที่เทียบเท่าสำหรับรูปทรงกลุ่ม, ตัวเชื่อมต่อและกรอบภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) สำหรับการเคลื่อนที่; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว, ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่ไม่อยู่ในสี่ประเภทที่จัดการจะถูกปล่อยไว้โดยไม่เปลี่ยนแปลง ลูปนี้ไม่ได้วนผ่านรูปทรงลูกภายในกลุ่ม

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

### **ลบการปกป้อง**

เพื่ออีลบการล็อกรูปทรง, ตั้งค่าเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก, การเคลื่อนที่และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) และ [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). มันยังลบข้อจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะถูกปล่อยไว้โดยไม่เปลี่ยนแปลง

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

Aspose.Slides for Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใส่ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถผสานการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ ใส่การล็อกเฉพาะบนรูปทรงในสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใส่การล็อกให้กับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนผ่านคอลเลกชันที่คืนค่าจากเมธอด [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มและใส่การล็อกที่เหมาะสมกับแต่ละรูปทรงลูก ทำซ้ำขั้นตอนนี้สำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นจะประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นจึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละตัว.