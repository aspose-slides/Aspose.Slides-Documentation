---
title: จัดการ SmartArt ในการนำเสนอ PowerPoint ด้วย JavaScript
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/nodejs-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทการจัดวาง
- คุณสมบัติซ่อน
- แผนผังองค์กร
- แผนผังองค์กรแบบภาพ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js โดยใช้ตัวอย่างโค้ด JavaScript ที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และเคาน์เตอร์จัดวาง (layout). ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเคาน์เตอร์จัดวาง, ตรวจสอบโหนดที่ซ่อนอยู่, กำหนดค่าการจัดวางแผนผังองค์กร, และสร้างแผนผังองค์กรแบบรูปภาพได้.

## **ดึงข้อความจากอ็อบเจกต์ SmartArt**

โหนด SmartArt สามารถมีรูปร่างหนึ่งหรือหลายรูปได้ เพื่ออ่านข้อความที่มองเห็น ให้วนลูปผ่าน [SmartArt.getAllNodes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/#getAllNodes--) แล้วอ่าน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ที่คืนค่าจาก [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **เปลี่ยนประเภทการจัดวางของอ็อบเจกต์ SmartArt**

เคาน์เตอร์จัดวาง SmartArt ควบคุมการจัดเรียงและการเชื่อมต่อของโหนด ตัวอย่างต่อไปนี้สร้างอ็อบเจกต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกการนำเสนอ.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartnode/ishidden/) ระบุว่าโหนดถูกซ่อนในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถอยู่ในโครงสร้างได้แม้ว่าเคาน์เตอร์จัดวางที่เลือกจะไม่ได้แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในอ็อบเจกต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับหรือกำหนดการจัดวางแผนผังองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้การจัดวางแผนผังองค์กร, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) และ [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนท์ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย, ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/organizationchartlayouttype/).

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและตั้งค่าการจัดวางสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างแผนผังองค์กรแบบภาพ**

แผนผังองค์กรแบบภาพเป็นการจัดวาง SmartArt ที่ออกแบบมาสำหรับแผนผังลำดับชั้นที่มีตัวเก็บภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มอ็อบเจกต์ SmartArt ลงในสไลด์.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาขวามาซ้าย (RTL) หรือไม่?**

ใช่ เมธอด [SmartArt.setReversed](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/setreversed/) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อการจัดวาง SmartArt ที่เลือกรองรับการกลับด้าน.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังการนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/nodejs-java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/nodejs-java/clone-slides/) ที่มี SmartArt ทั้งหมด วิธีทั้งสองจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**วิธีเรนเดอร์ SmartArt เป็นภาพราสเตอร์เพื่อการพรีวิวหรือส่งออกเว็บทำอย่างไร?**

คุณสามารถ [เรนเดอร์สไลด์](/slides/th/nodejs-java/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะหารูป SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจกต์?**

กำหนดค่า [Shape.setAlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/setalternativetext/) หรือ [Shape.setName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/setname/) ที่แตกต่างบนรูปร่าง SmartArt, แล้วค้นหาค่าดังกล่าวใน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getShapes), จากนั้นตรวจสอบว่ารูปร่างที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/).