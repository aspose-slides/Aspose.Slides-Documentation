---
title: จัดการ Drawing Guides ในงานนำเสนอด้วย JavaScript
linktitle: แนวทางการวาด
type: docs
weight: 85
url: /th/nodejs-java/drawing-guides/
keywords:
- แนววาด
- แนวแนวนอน
- แนวตั้ง
- แนวจัดตำแหน่ง
- มุมมองสไลด์
- สไลด์มาสเตอร์
- สไลด์เค้าโครง
- มาสเตอร์โน้ต
- มาสเตอร์เอกสารแจก
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่ม, เข้าถึงและลบแนวแนวนอนและแนวตั้งของ Drawing Guides ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Guides การวาดเป็นเส้นแนวนอนและแนวตั้งที่กำหนดค่าได้ ซึ่งช่วยให้ผู้ใช้จัดตำแหน่งรูปทรงอย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint มันมีประโยชน์เป็นพิเศษเมื่อแอปพลิเคชันสร้างงานนำเสนอซึ่งต่อมาจะได้รับการปรับแต่งด้วยตนเอง: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา

Guides การวาดเป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาสไลด์ พวกมันจะไม่ปรากฏในการแสดงสไลด์หรือผลลัพธ์ที่เรนเดอร์ Aspose.Slides สำหรับ Node.js ผ่าน Java ทำให้เข้าถึงได้ผ่านคลาส [DrawingGuidesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/) Guide หนึ่งแสดงโดย [DrawingGuide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguide/) และมีทิศทาง ตำแหน่ง และสี

ตำแหน่งวัดเป็นพอยต์จากมุมบนซ้ายของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง แนวนำแนวตั้งใช้พิกัดแนวนอนซึ่งมักอยู่ระหว่างศูนย์กับความกว้างของสไลด์ แนวนำแนวนอนใช้พิกัดแนวตั้งซึ่งมักอยู่ระหว่างศูนย์กับความสูงของสไลด์

## **เพิ่ม Guides ลงในมุมมองสไลด์**

ใช้ [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) เพื่อจัดการ Guides ที่แสดงขณะแก้ไขสไลด์ปกติ เรียก [DrawingGuidesCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/#add) พร้อมค่าของ [Orientation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/orientation/) และตำแหน่งเป็นพอยต์

ตัวอย่างต่อไปนี้เพิ่มแนวนำแนวตั้งหนึ่งเส้นทางขวาของศูนย์กลางสไลด์และแนวนำแนวนอนหนึ่งเส้นทางด้านล่างของมัน:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึง Drawing Guides**

เมธอด [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/#getCount) และ [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) ให้การเข้าถึง Guides ที่มีอยู่ เมธอด [DrawingGuide.getOrientation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguide/#getOrientation) , [DrawingGuide.getPosition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguide/#getPosition) และ [DrawingGuide.getColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguide/#getColor) คืนค่าเหล่านี้ซึ่งสามารถเปลี่ยนแปลงได้ผ่านเมธอดตั้งค่า (setter) ที่สอดคล้องกัน

ตัวอย่างต่อไปนี้อ่าน Guides ของมุมมองสไลด์จากงานนำเสนอที่สร้างไว้ข้างต้น:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **เพิ่ม Guides ลงใน Master และ Layout Slides**

Master สไลด์และ Layout Slides แต่ละอันสามารถมีคอลเลกชัน Drawing Guides ของตนเอง ใช้ [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) สำหรับ Master สไลด์และ [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) สำหรับ Layout สไลด์

ตัวอย่างต่อไปนี้เพิ่มแนวนำแนวตั้งหนึ่งเส้นใน Master สไลด์แรกและแนวนำแนวนอนหนึ่งเส้นใน Layout สไลด์แรก:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่ม Guides ลงใน Notes และ Handout Masters**

Notes Masters และ Handout Masters ก็รองรับ Drawing Guides ด้วย ใช้ [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) และ [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) เพื่อเข้าถึงคอลเลกชันของพวกมัน หากงานนำเสนอไม่มี Master ใด ๆ เหล่านี้ `MasterNotesSlideManager.setDefaultMasterNotesSlide` หรือ `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` จะสร้าง Master เริ่มต้นและคืนค่าให้

ตัวอย่างต่อไปนี้เพิ่มแนวนำแนวนอนหนึ่งเส้นใน Notes Master และแนวนำแนวตั้งหนึ่งเส้นใน Handout Master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบ Drawing Guides**

เรียก [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/#clear) เพื่อเอา Guides ทั้งหมดออกจากคอลเลกชันที่ระบุ การลบคอลเลกชันหนึ่งจะไม่กระทบกับ Guides ที่เก็บอยู่ในขอบเขตอื่น

ตัวอย่างต่อไปนี้ลบ Guides ของมุมมองสไลด์และ Guides ทั้งหมดบน Master สไลด์, Layout Slides, Notes Master, และ Handout Master โดยไม่สร้าง Master ที่ขาดหาย:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Guides การวาดปรากฏในการแสดงสไลด์หรือภาพที่ส่งออกหรือไม่?**

ไม่มี Guides การวาดเป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ถูกเรนเดอร์เป็นเนื้อหาของงานนำเสนอ

**สามารถเพิ่ม Guides การวาดลงในสไลด์ปกติแต่ละสไลด์ได้โดยตรงหรือไม่?**

Guides การแก้ไขของสไลด์ปกติจะถูกเก็บไว้ในคุณสมบัติการมองเห็นสไลด์ของงานนำเสนอ คอลเลกชัน Guides แยกต่างหากพร้อมใช้งานสำหรับ Master สไลด์, Layout Slides, Notes Masters และ Handout Masters

**ใช้หน่วยใดสำหรับตำแหน่งของ Guides?**

ตำแหน่งกำหนดเป็นพอยต์ โดย 72 พอยต์เท่ากับหนึ่งนิ้ว ตำแหน่งแนวตั้งวัดจากขอบซ้าย และตำแหน่งแนวนอนวัดจากขอบบน

**การลบ Drawing Guides จะลบรูปทรงหรือเปลี่ยนแปลงเนื้อหาสไลด์หรือไม่?**

ไม่มี เมธอด [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/drawingguidescollection/#clear) จะลบเฉพาะ Guides ในคอลเลกชันที่เลือกเท่านั้น รูปร่างและเนื้อหาอื่น ๆ ของสไลด์จะคงไว้โดยไม่เปลี่ยนแปลง