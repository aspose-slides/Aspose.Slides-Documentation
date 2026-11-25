---
title: จำกัดการแก้ไขงานนำเสนอด้วยการล็อกรูปทรงบน Android
linktitle: จำกัดการแก้ไขงานนำเสนอ
type: docs
weight: 60
url: /th/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการล็อกและปลดล็อกรูปทรงในงานนำเสนอ PPTX ด้วย Aspose.Slides for Android via Java เพื่อจำกัดการเลือก, การเคลื่อนย้าย, การปรับขนาด, และการจัดกลุ่ม."
---
## **ภาพรวม**

การใช้ Aspose.Slides for Android via Java อย่างทั่วไปคือการสร้าง, ปรับปรุงและบันทึกงานนำเสนอ PowerPoint (PPTX) เป็นส่วนหนึ่งของเวิร์กโฟลว์อัตโนมัติ เมื่อผู้ใช้ได้รับงานนำเสนอเหล่านี้ การจำกัดการเปลี่ยนแปลงรูปทรงสามารถช่วยรักษาการจัดวางและเนื้อหาที่ตั้งใจไว้

บทความนี้อธิบายว่าแบบรูปทรงถูกจัดระเบียบบนสไลด์อย่างไรและวิธีการใช้และลบการล็อกแบบรูปในงานนำเสนอ PPTX การล็อกเหล่านี้ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอัน

## **ส่วนประกอบของสไลด์**

สไลด์งานนำเสนอประกอบด้วยส่วนต่าง ๆ เช่น autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors และองค์ประกอบอื่น ๆ ที่ใช้สร้างงานนำเสนอ ใน Aspose.Slides for Android via Java แต่ละองค์ประกอบบนสไลด์จะถูกแทนด้วยออบเจ็กต์ที่ทำงานตามอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) หรือสืบทอดจากคลาสที่ทำเช่นนั้น

ประเภทรูปทรงที่แตกต่างกันเผยตัวเลือกการล็อกที่แตกต่างกัน อินเทอร์เฟซ [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) คืออินเทอร์เฟซฐานสำหรับการล็อกรูปทรง Aspose.Slides for Android via Java มีอินเทอร์เฟซการล็อกต่อไปนี้:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) ล็อก autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) ล็อก connector shapes.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) ล็อก graphical objects.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) ล็อก group shapes.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) ล็อก picture frames.  

เพื่อใช้การล็อกทั่วทั้ง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), ทำการวนผ่านสไลด์แต่ละอันและกำหนดการล็อกที่เหมาะสมให้กับรูปทรงที่สนับสนุนแต่ละประเภท

## **การใช้และลบการป้องกัน**

โปรแกรมแก้ไขงานนำเสนอที่เข้ากันได้ใช้การล็อกรูปทรงเพื่อจำกัดการดำเนินการแก้ไขแต่ละอย่าง การเข้ารหัสไฟล์และการป้องกันการเขียนระดับเอกสารเป็นการตั้งค่า [presentation protection settings](/slides/th/androidjava/password-protected-presentation/) ที่แยกจากกัน

### **ใช้การป้องกันกับรูปทรง PPTX**

Aspose.Slides for Android via Java มีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) เพื่อทำงานกับรูปทรงบนสไลด์

ตัวอย่างเรียกใช้เมธอด [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), และ [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) ด้วยค่า `true` สำหรับ autoshapes พร้อมล็อกที่เทียบเท่าสำหรับ group shapes, connectors, และ picture frames. Connectors ใช้เมธอด [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) สำหรับการเคลื่อนที่; กลุ่มยังใช้เมธอด [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) เพื่อล็อกการจัดกลุ่ม

ตัวอย่างโหลดงานนำเสนอ PPTX ที่มีอยู่แล้ว ตรวจสอบรูปทรงในคอลเลกชันรูปทรงของแต่ละสไลด์ และบันทึกสำเนาที่มีการจำกัดเหล่านี้ถูกนำไปใช้ รูปทรงที่ไม่ได้อยู่ในสี่ประเภทที่จัดการจะถูกปล่อยให้คงสภาพเหมือนเดิม ลูปจะไม่เดินทางไปยังรูปทรงลูกภายในกลุ่ม

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

เพื่อทำการลบการล็อกรูปทรง เพียงตั้งค่าค่าเป็น `false` ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีการล็อกรูปทรงและล้างการล็อกการเลือก, การเคลื่อนที่และการปรับขนาดผ่านอินเทอร์เฟซ [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), และ [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) รวมถึงลบการล็อกการจัดกลุ่มโดยส่งค่า `false` ไปยังเมธอด [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) แล้วบันทึกสำเนาของงานนำเสนอ การตั้งค่าการล็อกอื่น ๆ จะคงไว้โดยไม่เปลี่ยนแปลง

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

วางไฟล์รูปภาพชื่อ `photo.jpg` ไว้ในไดเรกทอรีทำงาน ตัวอย่างจะตัด 12% จากด้านซ้ายและ 8% จากด้านขวา จากนั้นเรียกเมธอด [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) บนล็อกของ picture frame การส่งค่า `true` จะจำกัดการตัดต่อเพิ่มเติมและรักษาการตัดที่มีอยู่

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

`PictureLocked.pptx` เก็บค่าล็อกการตัดเป็น `true`. ใน PowerPoint คำสั่ง **Crop** จะไม่พร้อมใช้งานเมื่อเลือกภาพ

### **ทำให้ไดอะแกรมรวมเป็นกลุ่ม**

ตัวอย่างจัดกลุ่มสี่เหลี่ยมและลูกศร แล้วเรียกเมธอด [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) บนล็อกของกลุ่มเพื่อให้ส่วนประกอบของไดอะแกรมอยู่ด้วยกัน การแก้ไขอื่น ๆ เช่น การย้ายกลุ่มหรือการเปลี่ยนสีเติมของส่วนประกอบยังคงทำได้

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

`DiagramLocked.pptx` เก็บค่าล็อกการยกเลิกการจัดกลุ่มเป็น `true`. ใน PowerPoint คำสั่ง **Ungroup** จะไม่พร้อมใช้งานเมื่อเลือกไดอะแกรมทั้งหมด

### **รายงานการล็อกรูปทรงที่มีอยู่**

เพื่อรีวิวเทมเพลต ให้เปิดและอ่านอ็อบเจ็กต์ล็อกของแต่ละรูปทรง เมธอด [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) จะคืนค่า `true` เมื่อทั้งหมดของแฟล็กบนอ็อบเจ็กต์นั้นถูกปิดและคืนค่า `false` เมื่ออย่างน้อยหนึ่งแฟล็กเปิด กลุ่มและลูกของมันมีอ็อบเจ็กต์ล็อกแยกกัน ดังนั้นจึงต้องตรวจสอบลูกแม้ในขณะที่กลุ่มไม่มีล็อก

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

ตัวอย่างนี้ตรวจสอบการเคลื่อนที่สำหรับ autoshapes, picture frames, และ groups รวมถึงการตรวจสอบการตัดสำหรับภาพและการยกเลิกการจัดกลุ่มสำหรับกลุ่ม รายงานจะแสดงรายการแฟล็กที่เปิดใช้งานที่รู้จักและจะทำเครื่องหมายประเภทรูปทรงที่ไม่ได้ตรวจสอบ

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

สมมติว่าหนังสือสไลด์ที่ 1 ของ `Sample.pptx` มี group ชื่อ `Layout` ที่ล็อกการยกเลิกการจัดกลุ่ม, ภาพชื่อ `Photo` อยู่ภายในที่ล็อกการตัด, และสี่เหลี่ยมที่ไม่มีการล็อกชื่อ `Free`. รายงานจะข้าม `Free` และพิมพ์บรรทัดสองบรรทัดต่อไปนี้:

{{...}}

รายงานอ่านแฟล็กการแก้ไขระดับรูปทรงที่จัดเก็บไว้โดยไม่เปลี่ยนแปลงหรือบันทึกงานนำเสนอ การป้องกันการเขียนระดับเอกสารเป็นการตั้งค่าแยกต่างหาก และการบังคับใช้แต่ละแฟล็กขึ้นอยู่กับโปรแกรมแก้ไข

## **สรุป**

Aspose.Slides for Android via Java ช่วยให้คุณจำกัดการดำเนินการแก้ไขเฉพาะบนรูปทรงแต่ละอันหรือใช้ข้อจำกัดเดียวกันข้ามสไลด์ เลือกการล็อกที่สนับสนุนโดยแต่ละประเภทของรูปทรงและตั้งค่าตามที่ต้องการเป็น `false` เมื่อต้องการลบข้อจำกัดเหล่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถผสมการล็อกรูปทรงกับการป้องกันด้วยรหัสผ่านในงานนำเสนอเดียวกันได้หรือไม่?**

ได้ การล็อกรูปทรงจำกัดการดำเนินการแก้ไขเฉพาะบางอย่าง ขณะที่ [password protection](/slides/th/androidjava/password-protected-presentation/) สามารถจำกัดการเปิดหรือการแก้ไขงานนำเสนอได้ คุณสามารถใช้ทั้งสองอย่างในไฟล์เดียวกันได้

**ฉันสามารถจำกัดการแก้ไขบนสไลด์เฉพาะโดยไม่กระทบสไลด์อื่นได้หรือไม่?**

ได้ ใช้การล็อกเฉพาะกับรูปทรงบนสไลด์ที่เลือก การทำเช่นนี้จะไม่เปลี่ยนแปลงการตั้งค่าล็อกบนสไลด์อื่น

**ฉันจะใช้การล็อกกับรูปทรงแต่ละอันภายในกลุ่มอย่างไร?**

วนผ่านคอลเลกชันที่คืนค่าจากเมธอด [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มและกำหนดการล็อกที่เหมาะสมให้กับรูปทรงลูกแต่ละอัน ทำซ้ำสำหรับกลุ่มซ้อนกันตามการเดินทางในตัวอย่างการรายงาน