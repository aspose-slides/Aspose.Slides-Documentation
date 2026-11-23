---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงใน Java
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/java/applying-protection-to-presentation/
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides สำหรับ Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้งานทั่วไปของ Aspose.Slides for Java คือการสร้าง, ปรับปรุง และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้ได้

บทความนี้อธิบายว่า รูปร่างต่าง ๆ ถูกจัดระเบียบบนสไลด์อย่างไร และวิธีการใช้และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Java แต่ละองค์ประกอบบนสไลด์แสดงเป็นออบเจกต์ที่ทำหน้าที่เป็น [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

รูปทรงแต่ละประเภทให้ตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) คืออินเทอร์เฟซพื้นฐานสำหรับการล็อกรูปทรง Aspose.Slides for Java มีอินเทอร์เฟซการล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) ล็อก connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ล็อก graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) ล็อก group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) ล็อก picture frames.  

เพื่อใช้การล็อกบน [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละประเภท

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่รองรับจะใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขเฉพาะ ส่วนการเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/java/password-protected-presentation/) ที่แตกต่างออกไป

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Java มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) สำหรับทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), และ [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) ด้วยค่า `true` สำหรับ autoshapes, พร้อมล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames. Connectors ใช้ [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) เพื่อจำกัดการเคลื่อนย้าย; groups ยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในคอลเลคชันรูปทรงของแต่ละสไลด์, แล้วบันทึกสำเนาที่มีการจำกัดเหล่านี้ รูปทรงที่ไม่ใช่สี่ประเภทที่จัดการจะถูกทิ้งไว้โดยไม่เปลี่ยนแปลง ลูปจะไม่วนลูปผ่านรูปทรงลูกภายในกลุ่ม

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

เพื่อยกเลิกการล็อกรูปทรง ให้ตั้งค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างข้อจำกัดการเลือก, การเคลื่อนย้าย, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). นอกจากนี้ยังยกเลิกการจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปที่ [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงอยู่โดยไม่เปลี่ยนแปลง

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

### **คงการตัดภาพ**

วางไฟล์รูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างตัดภาพ 12% จากด้านซ้ายและ 8% จากด้านขวา แล้วเรียก [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) บนล็อกของ picture frame การตั้งค่า `true` จะจำกัดการตัดต่อเพิ่มเติมและคงการตัดภาพที่มีอยู่

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` จะบันทึกการล็อกการตัดเป็น `true`. ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ

### **คงการจัดกลุ่มของไดอะแกรม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) บนล็อกของกลุ่มเพื่อคงส่วนประกอบของไดอะแกรมไว้ด้วยกัน การแก้อื่น ๆ เช่น การเคลื่อนย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงทำได้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` จะบันทึกการล็อกการยกเลิกการจัดกลุ่มเป็น `true`. ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกไดอะแกรมทั้งหมด

### **สรุป**

Aspose.Slides for Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันบนสไลด์หลาย ๆ สไลด์ เลือกล็อกที่รองรับตามประเภทของรูปทรงแต่ละประเภท และตั้งค่าเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงกับการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ ส่วน [password protection](/slides/th/java/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองอย่างร่วมกันในไฟล์เดียวได้

**ฉันสามารถจำกัดการแก้ไขเฉพาะบนสไลด์บางสไลด์โดยไม่กระทบสไลด์อื่น ๆ ได้หรือไม่?**

ได้ ให้ใช้การล็อกเฉพาะบนรูปทรงของสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละอันภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลคชันที่คืนค่ามาจากเมธอด [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่ม แล้วใช้การล็อกที่เหมาะสมกับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นจะดำเนินการเฉพาะคอลเลคชันรูปทรงของสไลด์จึงไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละอัน