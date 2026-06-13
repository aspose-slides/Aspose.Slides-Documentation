---
title: ป้องกันการแก้ไขการนำเสนอด้วยการล็อกรูปร่าง
linktitle: ป้องกันการแก้ไขการนำเสนอ
type: docs
weight: 60
url: /th/java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันไม่ให้แก้ไข
- ล็อกรูป
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ Java ล็อกหรือปลดล็อกรูปในไฟล์ PPT, PPTX และ ODP เพื่อรักษาความปลอดภัยของการนำเสนอพร้อมให้การแก้ไขที่ควบคุมได้และการส่งมอบที่เร็วขึ้น"
---
## **พื้นหลัง**

การใช้ Aspose.Slides อย่างทั่วไปคือการสร้าง, ปรับปรุง, และบันทึกการนำเสนอ Microsoft PowerPoint (PPTX) ภายใน workflow อัตโนมัติ ผู้ใช้แอปพลิเคชันที่ใช้ Aspose.Slides แบบนี้จะเข้าถึงการนำเสนอที่สร้างขึ้นได้ ดังนั้นการป้องกันไม่ให้แก้ไขเป็นเรื่องที่ต้องคำนึงถึงอย่างมาก จำเป็นที่การนำเสนอที่สร้างอัตโนมัติจะต้องคงรูปแบบและเนื้อหาต้นฉบับไว้

บทความนี้อธิบายโครงสร้างของการนำเสนอและสไลด์ รวมถึงวิธีที่ Aspose.Slides for Java สามารถใส่การป้องกันให้กับการนำเสนอและถอดออกในภายหลัง ให้ผู้พัฒนามีวิธีควบคุมการใช้การนำเสนอที่แอปพลิเคชันของตนสร้างขึ้น

## **องค์ประกอบของสไลด์**

สไลด์การนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, และองค์ประกอบอื่น ๆ ที่ใช้สร้างการนำเสนอ ใน Aspose.Slides for Java แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจกต์ที่ทำตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำตามอินเทอร์เฟซนั้น

โครงสร้างของ PPTX มีความซับซ้อน จึงแตกต่างจาก PPT ที่สามารถใช้ lock สากลสำหรับทุกประเภทของ shape ได้ โดยประเภท shape ต่าง ๆ ต้องใช้ lock ที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseshapelock/) คือคลาส lock สากลสำหรับ PPTX ชนิดของ lock ที่รองรับใน Aspose.Slides for Java สำหรับ PPTX มีดังนี้

- [IAutoShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshapelock/) lock autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/iconnectorlock/) lock connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/igraphicalobjectlock/) lock graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/igroupshapelock/) lock group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipictureframelock/) lock picture frames.  

การกระทำใด ๆ ที่ทำกับอ็อบเจกต์ shape ทั้งหมดในอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) จะถูกนำไปใช้กับการนำเสนอทั้งหมด

## **การใส่และถอดการป้องกัน**

การใส่การป้องกันทำให้การนำเสนอไม่สามารถแก้ไขได้ เป็นเทคนิคที่มีประโยชน์สำหรับการปกป้องเนื้อหาของการนำเสนอ

### **ใส่การป้องกันให้กับ Shape ใน PPTX**

Aspose.Slides for Java มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อทำงานกับ shape บนสไลด์

อย่างที่กล่าวไปแล้ว แต่ละคลาส shape จะมีคลาส shape‑lock ที่สอดคล้องกันสำหรับการป้องกัน บทความนี้เน้นที่ lock ประเภท NoSelect, NoMove, และ NoResize ซึ่ง lock เหล่านี้ทำให้ shape ไม่สามารถเลือก (โดยการคลิกเมาส์หรือวิธีเลือกอื่น) และไม่สามารถย้ายหรือปรับขนาดได้

ตัวอย่างโค้ดต่อไปนี้ใส่การป้องกันให้กับทุกประเภทของ shape ในการนำเสนอ

```java
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์ PPTX
Presentation presentation = new Presentation("Sample.pptx");

// วนลูปทุกสไลด์ในการนำเสนอ
for (ISlide slide : presentation.getSlides()) {

    // วนลูปทุกรูปร่างในสไลด์
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // แปลงชนิดรูปร่างเป็น autoshape และดึง shape lock ของมัน
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // แปลงชนิดรูปร่างเป็น group shape และดึง shape lock ของมัน
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // แปลงชนิดรูปร่างเป็น connector shape และดึง shape lock ของมัน
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // แปลงชนิดรูปร่างเป็น picture frame และดึง shape lock ของมัน
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// บันทึกไฟล์การนำเสนอ
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **ถอดการป้องกัน**

เพื่อปลดล็อก shape ให้ตั้งค่าของ lock ที่ได้ใส่ไว้เป็น `false` ตัวอย่างโค้ดต่อไปนี้แสดงวิธีปลดล็อก shape ในการนำเสนอที่ถูกล็อก

```java
// สร้างอ็อบเจกต์ Presentation ที่แทนไฟล์ PPTX
Presentation presentation = new Presentation("ProtectedSample.pptx");

// วนลูปทุกรายการสไลด์ในการนำเสนอ
for (ISlide slide : presentation.getSlides()) {

    // วนลูปทุกรูปร่างในสไลด์
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // แปลงชนิดรูปร่างเป็น autoshape และดึง shape lock ของมัน
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // แปลงชนิดรูปร่างเป็น group shape และดึง shape lock ของมัน
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // แปลงชนิดรูปร่างเป็น connector shape และดึง shape lock ของมัน
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // แปลงชนิดรูปร่างเป็น picture frame และดึง shape lock ของมัน
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// บันทึกไฟล์การนำเสนอ
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **สรุป**

Aspose.Slides มีตัวเลือกรับหลายแบบสำหรับการป้องกัน shape ในการนำเสนอ คุณสามารถล็อก shape เดียว หรือวนลูปผ่านทุก shape ในการนำเสนอและล็อกแต่ละอันเพื่อให้ไฟล์ทั้งหมดได้รับการคุ้มครองอย่างมีประสิทธิภาพ คุณสามารถถอดการป้องกันได้โดยตั้งค่าของ lock เป็น `false`

## **คำถามที่พบบ่อย**

**ฉันสามารถรวม lock ของ shape กับการป้องกันด้วยรหัสผ่านในการนำเสนอเดียวกันได้หรือไม่?**

ได้ครับ Lock จะจำกัดการแก้ไขอ็อบเจกต์ภายในไฟล์ ส่วน [password protection](/slides/th/java/password-protected-presentation/) จะควบคุมการเปิดและ/หรือการบันทึกการเปลี่ยนแปลง ทั้งสองกลไกทำงานเสริมกัน

**ฉันสามารถจำกัดการแก้ไขบนสไลด์บางสไลด์โดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ครับ ใส่ lock ให้กับ shape บนสไลด์ที่เลือก ส่วนสไลด์ที่เหลือจะยังคงสามารถแก้ไขได้

**Lock ของ shape ใช้กับอ็อบเจกต์กลุ่มและ connector หรือไม่?**

ได้ครับ มีประเภท lock เฉพาะสำหรับกลุ่ม, connector, graphic objects, และชนิด shape อื่น ๆ