---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint บน Android
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/androidjava/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทการจัดวาง
- คุณสมบัติซ่อน
- แผนผังองค์กร
- แผนผังองค์กรแบบภาพ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Android โดยใช้ตัวอย่างโค้ด Java ที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด, รูปร่างของโหนด, และการจัดวาง. ด้วย Aspose.Slides for Android via Java, คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนการจัดวาง, ตรวจสอบโหนดที่ซ่อน, กำหนดค่าการจัดวางแผนผังองค์กร, และสร้างแผนผังองค์กรแบบภาพได้.

## **รับข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถมีหนึ่งหรือหลายรูปทรงได้. เพื่้ออ่านข้อความจากรูปทรงของโหนด, ให้วนผ่าน [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), จากนั้นอ่าน [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) ที่คืนค่าโดย [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งสไลด์และวัตถุ SmartArt เป็นรูปทรงแรกบนสไลด์นั้น. มันพิมพ์แต่ละเฟรมข้อความที่มีให้บนคอนโซล.

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

## **เปลี่ยนประเภทการจัดวางของวัตถุ SmartArt**

การจัดวาง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด. ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, แล้วเปลี่ยนเป็นค่า `BasicProcess`, และบันทึกงานนำเสนอ. ตำแหน่งและขนาดที่ส่งให้ [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) จะวัดเป็นจุด. ใช้ [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) เพื่อเปลี่ยนการจัดวาง.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) ระบุว่าโหนดถูกซ่อนในโมเดลข้อมูลของ SmartArt หรือไม่. โหนดที่ซ่อนอยู่สามารถอยู่ในโครงสร้างได้แม้การจัดวางที่เลือกจะไม่ได้แสดงเป็นองค์ประกอบแผนภาพที่มองเห็น.

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่ม. มันพิมพ์ข้อความหากโหนดถูกซ่อนและบันทึกแผนภาพ.

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

## **รับหรือกำหนดการจัดวางแผนผังองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้การจัดวางแผนผังองค์กร, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) และ [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดหลัก. ตัวอย่างเช่น, คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย, ด้านขวา, หรือทั้งสองด้าน, ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและกำหนดการจัดวางสำหรับโหนดแรกให้เป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. ดัชนีศูนย์ฐาน `0` เลือกโหนดระดับบนแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก. งานนำเสนอที่แก้ไขแล้วจึงถูกบันทึก.

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

## **สร้างแผนผังองค์กรแบบภาพ**

แผนผังองค์กรแบบภาพเป็นการจัดวาง SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับชั้นที่มีตำแหน่งภาพ. ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มวัตถุ SmartArt ไปยังสไลด์. ตัวอย่างนี้บันทึกแผนภาพที่มีตำแหน่งภาพ; แต่ไม่ได้ใส่ภาพลงในตำแหน่งเหล่านั้น.

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

## **แปลงแผนภาพรุ่นเก่าเป็นกลุ่มของรูปทรง**

เมื่อทำการอัปเดตงานนำเสนอที่มีอยู่, คุณอาจต้องปรับแผนผังองค์กรที่สร้างขึ้นใน PowerPoint 97–2003. Aspose.Slides แสดงแผนภาพรุ่นเก่าเหล่านี้เป็นอ็อบเจ็กต์ [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). ใช้ [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปทรง เพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแต่ละส่วนได้. ดู [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) เพื่อดูรายละเอียด.

การแปลงจะเพิ่มกลุ่มใหม่เข้าไปในคอลเลกชันรูปทรงโดยไม่ลบแผนภาพเดิม. หลังจากการแปลงสำเร็จ, ให้ลบแผนภาพเดิมด้วย [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) เพื่อหลีกเลี่ยงเนื้อหาซ้ำซ้อน. รวบรวมแผนภาพรุ่นเก่าไว้ในรายการก่อนแปลงเพื่อให้การเพิ่มและลบรูปทรงไม่ทำให้การวนลูปสะดุด.

ตัวอย่างต่อไปนี้เปิดงานนำเสนอ, ค้นหาทุกสไลด์, แปลงแผนภาพเป็นกลุ่มของรูปทรง, และบันทึกงานนำเสนอที่อัปเดตเป็น PPTX.

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

งานนำเสนอที่บันทึกไว้จะมีกลุ่มรูปทรงที่แก้ไขได้แทนที่แผนภาพรุ่นเก่าที่ถูกแปลง, โดยไม่มีแผนภาพเดิมเหลืออยู่ข้างเคียง. เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละส่วนภายในแต่ละกลุ่ม, เช่น ข้อความ, การเติมสี หรือ ตำแหน่ง.

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือกลับด้านสำหรับภาษาที่อ่านจากขวาไปซ้ายหรือไม่?**

ใช่. เมธอด [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) จะเปลี่ยนทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย, หรือกลับกัน, เมื่อการจัดวาง SmartArt ที่เลือกสนับสนุนการย้อนกลับ.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปทรง SmartArt](/slides/th/androidjava/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/androidjava/clone-slides/) ที่มี SmartArt อยู่. ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบ.

**ฉันจะเรนเดอร์ SmartArt เป็นภาพแรสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกเว็บได้อย่างไร?**

[แปลงสไลด์](/slides/th/androidjava/convert-powerpoint-to-png/) หรือทั้งงานนำเสนอเป็น PNG หรือ JPEG. SmartArt จะถูกแปลงเป็นส่วนหนึ่งของสไลด์.

**ฉันจะหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอัน?**

ใช้ [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) หรือ [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) เพื่อกำหนดข้อความแทนหรือชื่อที่แตกต่างให้กับรูปทรง SmartArt, ค้นหาค่าดังกล่าวใน [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) แล้วตรวจสอบว่ารูปทรงที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).