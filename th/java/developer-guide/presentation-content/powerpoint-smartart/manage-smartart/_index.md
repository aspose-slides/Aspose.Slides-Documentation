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
- แผนภูมิโครงสร้างองค์กร
- แผนภูมิโครงสร้างองค์กรแบบรูปภาพ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides for Java ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และเค้าโครง ด้วย Aspose.Slides for Java คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเค้าโครง ตรวจสอบโหนดที่ซ่อนอยู่ กำหนดค่าเค้าโครงแผนภูมิโครงสร้างองค์กร และสร้างแผนภูมิองค์กรแบบรูปภาพได้

## **ดึงข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถมีรูปร่างหนึ่งรูปหรือหลายรูปได้ เพื่ออ่านข้อความจากรูปร่างของโหนด ให้ทำการวนผ่าน [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) แล้วอ่าน [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) ที่ส่งกลับโดย [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

ตัวอย่างนี้ต้องการงานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์และวัตถุ SmartArt เป็นรูปแบบแรกบนสไลด์นั้น จะพิมพ์แต่ละกรอบข้อความที่มีอยู่ไปยังคอนโซล.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **เปลี่ยนประเภทเค้าโครงของวัตถุ SmartArt**

เค้าโครง SmartArt ควบคุมว่าการจัดเรียงและเชื่อมต่อโหนดเป็นอย่างไร ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ พิกัดและขนาดที่ส่งให้กับ [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) จะวัดเป็นหน่วยจุด ใช้ [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) เพื่อเปลี่ยนเค้าโครง.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) ระบุว่าโหนดถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างได้แม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่มเข้ามา หากโหนดถูกซ่อนจะพิมพ์ข้อความและบันทึกแผนภาพ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับหรือกำหนดเค้าโครงแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) และ [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพARENT ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกแขวนจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) ที่เลือก

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและตั้งค่าเค้าโครงให้กับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` ดัชนีเริ่มต้นที่ `0` เลือกโหนดระดับบนแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก งานนำเสนอที่แก้ไขแล้วจึงถูกบันทึก

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างแผนภูมิองค์กรแบบรูปภาพ**

แผนภูมิองค์กรแบบรูปภาพเป็นเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภูมิลำดับขั้นที่มีตำแหน่งสำหรับภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มวัตถุ SmartArt ลงในสไลด์ ตัวอย่างนี้บันทึกแผนภาพที่มีตำแหน่งภาพ; จะไม่ใส่ภาพลงในตำแหน่งเหล่านั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แปลงแผนภาพเก่าเป็นกลุ่มของรูปร่าง**

เมื่อทำการปรับปรุงงานนำเสนอที่มีอยู่ คุณอาจต้องอัปเดตแผนภูมิองค์กรที่สร้างใน PowerPoint 97–2003 ดั้งเดิม Aspose.Slides แสดงแผนภาพเหล่านี้เป็นวัตถุ [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) ใช้ [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปร่างเพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแต่ละส่วน รายละเอียดเพิ่มเติมดูที่ [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/)

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเลกชันของรูปร่างโดยไม่ลบแผนภาพต้นฉบับ หลังจากแปลงสำเร็จ ให้ลบต้นฉบับด้วย [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) เพื่อหลีกเลี่ยงเนื้อหาซ้ำกัน เก็บแผนภาพเก่าไว้ในรายการก่อนทำการแปลงเพื่อให้การเพิ่มและลบรูปร่างไม่กระทบต่อการวนลูป

ตัวอย่างต่อไปนี้เปิดงานนำเสนอ ค้นหาทุกสไลด์ แปลงแผนภาพเป็นกลุ่มของรูปร่าง และบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

งานนำเสนอที่บันทึกไว้จะมีกลุ่มของรูปร่างที่แก้ไขได้แทนที่แผนภาพเก่าที่แปลงแล้ว โดยไม่มีแผนภาพดั้งเดิมเหลืออยู่ เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละส่วนภายในกลุ่ม เช่น ข้อความ การเติมสี หรือตำแหน่ง

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับทิศสำหรับภาษาขวาไปซ้ายหรือไม่?**

ใช่ วิธีการ [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) จะสลับทิศทางของแผนภาพจากซ้ายเป็นขวาเป็นขวาเป็นซ้าย หรือกลับกันเมื่อเค้าโครง SmartArt ที่เลือกสนับสนุนการกลับทิศ

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดิมหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/java/clone-slides/) ที่มี SmartArt อยู่ ทั้งสองวิธีจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะแสดงผล SmartArt เป็นภาพแรสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกเว็บอย่างไร?**

คุณสามารถ [เรนเดอร์สไลด์](/slides/th/java/convert-powerpoint-to-png/) หรือแปลงงานนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะค้นหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอัน?**

ใช้ [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) หรือ [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) เพื่อกำหนดข้อความแทนหรือชื่อที่เป็นเอกลักษณ์ให้กับรูปร่าง SmartArt ค้นหาค่าดังกล่าวใน [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) แล้วตรวจสอบว่ารูปร่างที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) หรือไม่