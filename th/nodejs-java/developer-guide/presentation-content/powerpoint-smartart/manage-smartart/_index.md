---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/nodejs-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเลเอาต์
- คุณสมบัติที่ซ่อนอยู่
- แผนภูมิองค์กร
- แผนภูมิองค์กรรูปภาพ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js โดยใช้ตัวอย่างโค้ด JavaScript ที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt เป็นแผนภาพ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และเลเอาต์ ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเลเอาต์ ตรวจสอบโหนดที่ซ่อนอยู่ กำหนดค่าเลเอาต์แผนภูมิองค์กร และสร้างแผนภูมิองค์กรรูปภาพได้

## **รับข้อความจากออบเจ็กต์ SmartArt**

โหนด SmartArt สามารถประกอบด้วยรูปทรงหนึ่งหรือหลายรูปทรง เพื่ออ่านข้อความจากรูปทรงของโหนด ให้วนลูปผ่าน [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), จากนั้นอ่าน [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) ที่ส่งคืนโดย [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

ตัวอย่างต้องการงานนำเสนอที่มีสไลด์อย่างน้อยหนึ่งสไลด์และออบเจ็กต์ SmartArt เป็นรูปทรงแรกบนสไลด์นั้น จะพิมพ์แต่ละ TextFrame ที่มีอยู่ลงในคอนโซล

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **เปลี่ยนประเภทเลเอาต์ของออบเจ็กต์ SmartArt**

เลเอาต์ของ SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างออบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ ตำแหน่งและขนาดที่ส่งให้กับ [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) จะวัดเป็นจุด ใช้ [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) เพื่อเปลี่ยนเลเอาต์

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนไว้หรือไม่**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) บ่งบอกว่าโหนดถูกซ่อนไว้ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างได้ แม้ว่าเลเอาต์ที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในออบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่มเข้ามา หากโหนดถูกซ่อนจะแสดงข้อความและบันทึกแผนภาพ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับหรือกำหนดเลเอาต์แผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เลเอาต์แผนภูมิองค์กร [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) และ [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพ่อแม่ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกแขวนจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) ที่เลือก

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและกำหนดเลเอาต์สำหรับโหนดแรกให้เป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` ดัชนีเริ่มจากศูนย์ `0` เลือกโหนดระดับบนสุดแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก งานนำเสนอที่แก้ไขแล้วจะถูกบันทึก

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างแผนภูมิองค์กรรูปภาพ**

แผนภูมิองค์กรรูปภาพเป็นเลเอาต์ SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับขั้นที่มีตำแหน่งภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มออบเจ็กต์ SmartArt ลงในสไลด์ ตัวอย่างนี้บันทึกแผนภาพที่มีตำแหน่งภาพไว้ แต่ไม่ได้เติมภาพลงในตำแหน่งเหล่านั้น

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แปลงแผนภาพเก่าเป็นกลุ่มของรูปทรง**

เมื่อปรับปรุงงานนำเสนอเดิมคุณอาจต้องอัปเดตแผนภูมิองค์กรที่สร้างใน PowerPoint 97–2003 Aspose.Slides แสดงแผนภาพเก่าเหล่านี้เป็นออบเจ็กต์ [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) ใช้ [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปทรงเพื่อให้คุณแก้ไของค์ประกอบภาพแต่ละรายการ ดูรายละเอียดได้ใน [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเลกชันรูปทรงโดยไม่ลบแผนภาพเดิม หลังจากการแปลงสำเร็จ ให้ลบแผนภาพต้นฉบับด้วย [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) เพื่อหลีกเลี่ยงเนื้อหาซ้ำกัน รวบรวมแผนภาพเก่าไว้ในรายการก่อนจะแปลง เพื่อให้การเพิ่มและลบรูปทรงไม่รบกวนการวนลูป

ตัวอย่างต่อไปนี้เปิดงานนำเสนอ ค้นหาทุกสไลด์ แปลงแผนภาพเป็นกลุ่มของรูปทรง และบันทึกงานนำเสนอที่อัปเดตเป็น PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

งานนำเสนอที่บันทึกไว้จะมีกลุ่มรูปทรงที่แก้ไขได้แทนที่แผนภาพเก่าที่แปลงแล้ว โดยไม่มีแผนภาพดั้งเดิมเหลืออยู่ เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละรายการภายในกลุ่ม เช่น ข้อความ เติมสี หรือตำแหน่ง

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือกลับด้านสำหรับภาษาขวามือ-ซ้าย (RTL) หรือไม่?**

ใช่ เมธอด [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกันเมื่อเลเอาต์ SmartArt ที่เลือกรองรับการกลับด้าน

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปทรง SmartArt](/slides/th/nodejs-java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/nodejs-java/clone-slides/) ที่มี SmartArt วิธีใดก็ตามจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะเรนเดอร์ SmartArt เป็นภาพเรสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกเป็นเว็บได้อย่างไร?**

คุณสามารถ [เรนเดอร์สไลด์](/slides/th/nodejs-java/convert-powerpoint-to-png/) หรือทั้งงานนำเสนอเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะค้นหาออบเจ็กต์ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายออบเจ็กต์?**

ใช้ [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) หรือ [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) เพื่อกำหนดข้อความทางเลือกหรือชื่อที่โดดเด่นให้กับรูปทรง SmartArt ค้นหาค่าดังกล่าวใน [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) แล้วตรวจสอบว่ารูปทรงที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)