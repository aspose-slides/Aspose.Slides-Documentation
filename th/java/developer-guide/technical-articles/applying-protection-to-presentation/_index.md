---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปร่างใน Java
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/java/applying-protection-to-presentation/
keywords:
- ป้องกันการแก้ไข
- ปกป้องจากการแก้ไข
- ล็อกรูปร่าง
- ล็อกตำแหน่ง
- ล็อกการเลือก
- ล็อกการปรับขนาด
- ล็อกการจัดกลุ่ม
- PowerPoint
- PPTX
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปร่างในงานนำเสนอ PPTX ด้วย Aspose.Slides for Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **พื้นหลัง**

การใช้ที่พบบ่อยของ Aspose.Slides for Java คือการสร้าง, ปรับปรุง, และบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของกระบวนการทำงานอัตโนมัติ เมื่อผู้ใช้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาตามที่ตั้งใจไว้ได้

บทความนี้อธิบายว่ารูปร่างถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกรูปร่างในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละรูปได้

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น รูปร่างอัตโนมัติ, ตาราง, วัตถุ OLE, กลุ่มรูปร่าง, กรอบรูปภาพ, กรอบวิดีโอ, ตัวเชื่อมต่อ, และส่วนประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Java, แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยอ็อบเจ็กต์ที่ทำการ implements อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทของรูปร่างต่าง ๆ จะเปิดเผยตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) เป็นอินเทอร์เฟซฐานสำหรับการล็อกรูปร่าง Aspose.Slides for Java มีอินเทอร์เฟซล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) ล็อกรูปร่างอัตโนมัติ.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) ล็อกตัวเชื่อมต่อ.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) ล็อกวัตถุกราฟิก.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) ล็อกกลุ่มรูปร่าง.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) ล็อกกรอบรูปภาพ.  

ในการใช้ล็อกบน [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ให้วนลูปผ่านสไลด์ทั้งหมดและตั้งค่าล็อกที่เหมาะสมบนแต่ละรูปร่างที่รองรับ

## **ใช้และลบการป้องกัน**

เครื่องมือแก้ไขงานนำเสนอที่รองรับใช้การล็อกรูปร่างเพื่อจำกัดการดำเนินการแก้ไขแต่ละรายการ การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [การตั้งค่าการป้องกันงานนำเสนอ](/slides/th/java/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Java ให้อินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) เพื่อทำงานกับรูปร่างบนสไลด์

ตัวอย่างเรียกใช้ [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), และ [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) ด้วย `true` สำหรับรูปร่างอัตโนมัติ, พร้อมด้วยล็อกที่เทียบเท่าสำหรับกลุ่มรูปร่าง, ตัวเชื่อมต่อ, และกรอบรูปภาพ ตัวเชื่อมต่อใช้ [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) เพื่อการเคลื่อนที่; กลุ่มใช้ [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อจำกัดการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่, ตรวจสอบรูปร่างในคอลเลกชันรูปร่างของแต่ละสไลด์, แล้วบันทึกสำเนาที่มีการใช้ข้อจำกัดเหล่านี้ รูปร่างที่อยู่นอกสี่ประเภทที่จัดการจะไม่ถูกเปลี่ยนแปลง ลูปจะไม่เดินทางผ่านรูปร่างย่อยภายในกลุ่ม

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

เพื่อยกเลิกการล็อกรูปร่าง, ตั้งค่าค่าของมันเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปร่างและล้างการจำกัดการเลือก, การเคลื่อนที่, และการปรับขนาดผ่าน [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) นอกจากนี้ยังยกเลิกการจำกัดการจัดกลุ่มโดยส่ง `false` ไปยัง [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) และบันทึกสำเนาของงานนำเสนอ การตั้งค่าล็อกอื่น ๆ จะคงไว้โดยไม่เปลี่ยนแปลง

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

### **รักษาการตัดรูปภาพ**

วางไฟล์รูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างตัดส่วนที่เหลือ 12% จากด้านซ้ายและ 8% จากด้านขวา, จากนั้นเรียก [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) บนล็อกของกรอบรูปภาพ การส่ง `true` จะจำกัดการตัดต่อในอนาคตและรักษาการตัดที่มีอยู่

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

`PictureLocked.pptx` จะเก็บสถานะล็อกการตัดเป็น `true` ใน PowerPoint คำสั่ง **Crop** จะถูกปิดใช้งานเมื่อเลือกภาพ

### **รักษาแผนภาพเป็นกลุ่ม**

ตัวอย่างสร้างกลุ่มของสี่เหลี่ยมและลูกศร, แล้วเรียก [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) บนล็อกของกลุ่มเพื่อรักษาส่วนประกอบของแผนภาพไว้ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงใช้ได้

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

`DiagramLocked.pptx` จะเก็บสถานะล็อกการยกเลิกการจัดกลุ่มเป็น `true` ใน PowerPoint คำสั่ง **Ungroup** จะถูกปิดใช้งานเมื่อเลือกแผนภาพทั้งหมด

### **รายงานการล็อกรูปร่างที่มีอยู่**

เพื่อรีวิวเทมเพลต, เปิดไฟล์และอ่านอ็อบเจ็กต์ล็อกของแต่ละรูปร่าง วิธี [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) จะคืนค่า `true` เมื่อแฟล็กทั้งหมดบนอ็อบเจ็กต์นั้นถูกปิดและ `false` เมื่อมีอย่างน้อยหนึ่งแฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน ดังนั้นต้องตรวจสอบลูกของกลุ่มแม้ในขณะที่กลุ่มไม่มีล็อก

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับรูปร่างอัตโนมัติ, กรอบรูปภาพ, และกลุ่ม รวมถึงตรวจสอบการตัดรูปสำหรับรูปภาพและการยกเลิกการจัดกลุ่มสำหรับกลุ่ม รายงานจะแสดงแฟล็กที่เปิดที่มันรู้จักและทำเครื่องหมายประเภทรูปร่างที่ไม่ได้ตรวจสอบ

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

สมมติว่าสไลด์ที่ 1 ของ `Sample.pptx` มีกลุ่มชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` ภายในที่ล็อกการตัด, และสี่เหลี่ยมที่ไม่มีการล็อกชื่อ `Free` รายงานจะข้าม `Free` และพิมพ์สองบรรทัดต่อไปนี้:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

รายงานอ่านแฟล็กการแก้ไขระดับรูปร่างที่เก็บไว้โดยไม่เปลี่ยนแปลงหรือบันทึกงานนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหากและการบังคับใช้แต่ละแฟล็กขึ้นอยู่กับเครื่องมือแก้ไข

## **สรุป**

Aspose.Slides for Java ให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปร่างแต่ละรูปหรือใช้ข้อจำกัดเดียวกันบนสไลด์ทั้งหมด เลือกล็อกที่รองรับโดยแต่ละประเภทของรูปร่าง และตั้งค่าของมันเป็น `false` เมื่อคุณต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถรวมการล็อกรูปทรงและการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ใช่. การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะ, ในขณะที่ [การป้องกันด้วยรหัสผ่าน](/slides/th/java/password-protected-presentation/) สามารถจำกัดการเปิดหรือแก้ไขงานนำเสนอ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่ส่งผลต่อสไลด์อื่นได้หรือไม่?**

ใช่. ใช้ล็อกเฉพาะกับรูปร่างบนสไลด์ที่เลือก วิธีนี้จะไม่เปลี่ยนการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใช้ล็อกกับรูปร่างแต่ละรูปภายในกลุ่มได้อย่างไร?**

วนลูปผ่านคอลเลกชันที่คืนค่าจากเมธอด [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มและกำหนดล็อกที่เหมาะสมให้กับแต่ละรูปร่างลูก ทำซ้ำสำหรับกลุ่มซ้อนกันตามการเดินทางในตัวอย่างรายงาน**