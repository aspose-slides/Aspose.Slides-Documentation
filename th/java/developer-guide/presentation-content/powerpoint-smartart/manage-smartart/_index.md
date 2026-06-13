---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย Java
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติซ่อน
- แผนภูมิองค์กร
- แผนภูมิองค์กรแบบภาพ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Java โดยใช้ตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด, รูปร่างโหนด, และเค้าโครง ด้วย Aspose.Slides for Java คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเค้าโครง, ตรวจสอบโหนดที่ซ่อนอยู่, กำหนดค่าเค้าโครงแผนภูมิองค์กร, และสร้างแผนภูมิองค์กรแบบภาพได้.

## **รับข้อความจากอ็อบเจ็กต์ SmartArt**

โหนด SmartArt สามารถมีรูปทรงหนึ่งหรือหลายรูป เพื่ออ่านข้อความที่มองเห็นได้ ให้วนลูปผ่าน [ISmartArt.getAllNodes](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartart/#getAllNodes--) แล้วอ่าน [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ที่ส่งกลับโดย [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **เปลี่ยนประเภทเค้าโครงของอ็อบเจ็กต์ SmartArt**

เค้าโครง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างอ็อบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartartnode/#isHidden--) บ่งชี้ว่าโหนดถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถอยู่ในโครงสร้างได้แม้เค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในอ็อบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับหรือกำหนดเค้าโครงแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) และ [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) กำหนดวิธีการจัดเรียงโหนดย่อยใต้โหนดพาเรนต์ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดย่อยแขวนจากด้านซ้าย, ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/OrganizationChartLayoutType) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและตั้งค่าเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างแผนภูมิองค์กรแบบภาพ**

แผนภูมิองค์กรแบบภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับชั้นที่มีตำแหน่งภาพใช้ [SmartArtLayoutType](https://reference.aspose.com/slides/th/java/com.aspose.slides/SmartArtLayoutType) ค่า `PictureOrganizationChart` เมื่อเพิ่มอ็อบเจ็กต์ SmartArt ลงในสไลด์.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษา RTL หรือไม่?**

ใช่ วิธีการ [ISmartArt.setReversed](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartart/#setReversed-boolean-) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อเค้าโครง SmartArt ที่เลือกรองรับการกลับด้าน.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นพร้อมรักษาการจัดรูปแบบได้อย่างไร?**

คุณสามารถ [คัดลอกรูปแบบ SmartArt](/slides/th/java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/java/clone-slides/) ที่มี SmartArt ทั้งหมด ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และการจัดรูปแบบไว้.

**ฉันจะเรนเดอร์ SmartArt เป็นภาพเรสเตอร์เพื่อการแสดงตัวอย่างหรือการส่งออกเว็บได้อย่างไร?**

[เรนเดอร์สไลด์](/slides/th/java/convert-powerpoint-to-png/) หรือทั้งงานนำเสนอเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะค้นหาอ็อบเจ็กต์ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจ็กต์?**

ตั้งค่า [Shape.getAlternativeText](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getAlternativeText--) หรือ [Shape.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getName--) ที่เป็นเอกลักษณ์บนรูปทรง SmartArt แล้วค้นหาค่านั้นใน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslide/#getShapes--) จากนั้นตรวจสอบว่ารูปทรงที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/ismartart/).