---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงบน Android
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/androidjava/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ป้องกันไม่ให้แก้ไข
- ล็อกรูปทรง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Android ผ่าน Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้งานทั่วไปของ Aspose.Slides for Android via Java คือการสร้าง, อัปเดต และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจได้

บทความนี้อธิบายวิธีการจัดรูปทรงบนสไลด์และวิธีการใช้และลบการล็อกรูปทรงในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการแก้ไขบางอย่างบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนประกอบต่าง ๆ เช่น autoshapes, ตาราง, วัตถุ OLE, รูปทรงที่จัดกลุ่ม, กรอบภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Android via Java แต่ละองค์ประกอบบนสไลด์จะเป็นอ็อบเจ็กต์ที่ดำเนินการตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปทรงที่แตกต่างกันมีตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) คืออินเทอร์เฟซฐานสำหรับการล็อกรูปทรง Aspose.Slides for Android via Java มีอินเทอร์เฟซการล็อกต่อไปนี้:
- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) ล็อกรูปทรงตัวเชื่อมต่อ.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) ล็อกรูปทรงที่จัดกลุ่ม.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) ล็อกกรอบภาพ.  

เพื่อใช้การล็อกบน [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ให้วนซ้ำผ่านสไลด์ทั้งหมดและตั้งค่าการล็อกที่เหมาะสมบนรูปทรงที่รองรับแต่ละอัน

## **ใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละอย่าง การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นส่วนของ [การตั้งค่าการป้องกันการนำเสนอ](/slides/th/androidjava/password-protected-presentation/) ที่แยกต่างหาก

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Android via Java มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) และ [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) พร้อมค่า `true` สำหรับ autoshapes, พร้อมการล็อกที่เทียบเท่าสำหรับรูปทรงที่จัดกลุ่ม, ตัวเชื่อมต่อ, และกรอบภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) สำหรับการเคลื่อนย้าย; กลุ่มยังใช้ [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปทรงในชุดรูปทรงของแต่ละสไลด์, และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่นอกสี่ประเภทที่จัดการจะไม่ได้รับการเปลี่ยนแปลง ลูปไม่เดินทางผ่านรูปทรงย่อยภายในกลุ่ม

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

เพื่อเอาการล็อกรูปทรงออก ให้ตั้งค่าเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการจำกัดการเลือก, การเคลื่อนย้าย, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) นอกจากนี้ยังลบการจำกัดการจัดกลุ่มโดยส่งค่า `false` ไปยัง [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะคงไว้โดยไม่เปลี่ยนแปลง

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

### **รักษาการครอปภาพ**

วางภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างทำการครอป 12% จากด้านซ้ายและ 8% จากด้านขวา แล้วเรียก [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) บนการล็อกของกรอบภาพ การส่งค่า `true` จะจำกัดการครอปเพิ่มเติมและรักษาการครอปที่มีอยู่

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` เก็บค่าการล็อกการครอปเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ

### **รักษาแผนภาพเป็นกลุ่ม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) บนการล็อกของกลุ่มเพื่อรักษาองค์ประกอบของแผนภาพให้คงอยู่ การแก้ไขอื่น ๆ เช่นการย้ายกลุ่มหรือการเปลี่ยนสีเติมขององค์ประกอบยังคงทำได้

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

`DiagramLocked.pptx` เก็บค่าการล็อกการยกเลิกการจัดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกแผนภาพทั้งหมด

### **สรุป**

Aspose.Slides for Android via Java ให้คุณจำกัดการดำเนินการแก้ไขบางอย่างบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันบนหลายสไลด์ เลือกการล็อกที่รองรับโดยแต่ละประเภทของรูปทรงและตั้งค่าของพวกมันเป็น `false` เมื่อคุณต้องการเอาข้อจำกัดเหล่านั้นออก

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขบางอย่าง ในขณะที่ [password protection](/slides/th/androidjava/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ ให้ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก นี้จะไม่เปลี่ยนการตั้งค่าการล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละอันภายในกลุ่มอย่างไร?**

วนซ้ำผ่านคอลเลกชันที่เมธอด [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มส่งกลับและใช้การล็อกที่เหมาะสมกับรูปทรงย่อยแต่ละอัน ทำซ้ำสำหรับกลุ่มที่ซ้อนกัน ตัวอย่างข้างต้นประมวลผลเฉพาะคอลเลกชันรูปทรงของสไลด์เท่านั้น ดังนั้นไม่ได้ตั้งค่าการล็อกบนสมาชิกกลุ่มแต่ละอัน