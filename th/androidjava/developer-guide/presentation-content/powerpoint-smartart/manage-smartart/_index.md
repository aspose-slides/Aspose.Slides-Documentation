---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint บน Android
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/androidjava/manage-smartart/
keywords:
  - SmartArt
  - ข้อความ SmartArt
  - ชนิดเค้าโครง
  - คุณสมบัติซ่อน
  - แผนภูมิองค์กร
  - แผนภูมิองค์กรแบบรูปภาพ
  - PowerPoint
  - งานนำเสนอ
  - Android
  - Java
  - Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข PowerPoint SmartArt ด้วย Aspose.Slides สำหรับ Android ด้วยตัวอย่างโค้ด Java ที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำอัตโนมัติ."
---
## **ภาพรวม**

SmartArt คือแผนภูมิ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และเค้าโครง ด้วย Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเค้าโครง, ตรวจสอบโหนดที่ซ่อนอยู่, กำหนดค่าเค้าโครงแผนภูมิโครงสร้างองค์กร, และสร้างแผนภูมิองค์กรแบบรูปภาพได้.

## **รับข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถมีรูปร่างหนึ่งหรือหลายรูปได้ เพื่ออ่านข้อความที่มองเห็นได้ ให้วนซ้ำผ่าน [ISmartArt.getAllNodes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartart/#getAllNodes--) แล้วอ่าน [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ที่ส่งคืนโดย [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **เปลี่ยนประเภทเค้าโครงของวัตถุ SmartArt**

เค้าโครง SmartArt ควบคุมการจัดเรียงและการเชื่อมต่อของโหนด ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` จากนั้นเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartartnode/#isHidden--) ระบุว่าโหนดนั้นถูกซ่อนในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างแม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด.

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

สำหรับแผนภูมิ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) และ [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) กำหนดวิธีการจัดเรียงโหนดลูกใต้โหนดแม่ ตัวอย่างเช่น คุณสามารถกำหนดให้โหนดลูกแขวนจากด้านซ้าย, ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OrganizationChartLayoutType) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและกำหนดเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **สร้างแผนภูมิองค์กรแบบรูปภาพ**

แผนภูมิองค์กรแบบรูปภาพเป็นเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภูมิลำดับชั้นที่มีการวางตำแหน่งภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` เมื่อต้องการเพิ่มวัตถุ SmartArt ลงในสไลด์.

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

**SmartArt รองรับการสะท้อนหรือการย้อนกลับสำหรับภาษา RTL หรือไม่?**

ใช่ วิธีการ [ISmartArt.setReversed](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกันเมื่อเค้าโครง SmartArt ที่เลือกรองรับการย้อนกลับ.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/androidjava/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/androidjava/clone-slides/) ที่มี SmartArt ทั้งหมด ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**ฉันจะเรนเดอร์ SmartArt ไปยังภาพเรสเตอร์เพื่อการแสดงตัวอย่างหรือการส่งออกเว็บได้อย่างไร?**

คุณสามารถ [เรนเดอร์สไลด์](/slides/th/androidjava/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG ได้ SmartArt จะถูกรเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะค้นหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายชิ้น?**

กำหนดค่า [Shape.getAlternativeText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getAlternativeText--) หรือ [Shape.getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getName--) ที่มีลักษณะเฉพาะบนรูปร่าง SmartArt จากนั้นค้นหาค่านั้นใน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslide/#getShapes--) และตรวจสอบว่ารูปร่างที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartart/).