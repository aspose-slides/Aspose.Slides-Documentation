---
title: จัดการการซูมของพรีเซนเทชันใน JavaScript
linktitle: จัดการซูม
type: docs
weight: 60
url: /th/nodejs-java/manage-zoom/
keywords:
- ซูม
- เฟรมซูม
- ซูมสไลด์
- ซูมส่วน
- ซูมสรุป
- เพิ่มซูม
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งซูมด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java — กระโดดระหว่างส่วนต่าง ๆ, เพิ่มภาพย่อและการเปลี่ยนภาพในพรีเซนเทชัน PowerPoint."
---
## **บทนำ**

Zoom ของ PowerPoint ช่วยให้คุณนำทางระหว่างสไลด์และส่วนต่าง ๆ ระหว่างการพรีเซนเทชัน ด้วย Aspose.Slides for Node.js ผ่าน Java คุณสามารถสร้าง slide, section, และ summary zooms และปรับแต่งการแสดงตัวอย่าง, เฟรม, และการเปลี่ยนภาพได้.

![ภาพรวมของ PowerPoint zoom](overview.png)

* เพื่อสรุปการพรีเซนเทชันทั้งหมดในสไลด์เดียว ให้ใช้ [Summary Zoom](#summary-zoom).
* เพื่อแสดงสไลด์ที่เลือกเท่านั้น ให้ใช้ [Slide Zoom](#slide-zoom).
* เพื่อแสดงส่วนเดียวเท่านั้น ให้ใช้ [Section Zoom](#section-zoom).

## **Zoom สไลด์**

Zoom สไลด์สามารถทำให้การพรีเซนเทชันของคุณมีความไดนามิกมากขึ้นโดยให้คุณนำทางอย่างอิสระระหว่างสไลด์ในลำดับใดก็ได้ตามที่คุณเลือกโดยไม่ขัดจังหวะการไหลของการพรีเซนเทชัน. Zoom สไลด์เหมาะสำหรับพรีเซนเทชันสั้น ๆ ที่ไม่มีหลายส่วน แต่คุณยังสามารถใช้มันในสถานการณ์การพรีเซนเทชันต่าง ๆ ได้.

Zoom สไลด์ช่วยให้คุณสำรวจข้อมูลที่เกี่ยวข้องจากสไลด์ภาพรวมเดียว.

![การเลือกสไลด์สำหรับ Zoom สไลด์](slidezoomsel.png)

สำหรับวัตถุ slide zoom, Aspose.Slides ให้บริการ enumeration [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomimagetype/) , class [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) , และ methods บน class [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) .

### **สร้างกรอบ Zoom**

ใช้ [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) เพื่อวางลิงก์ไปยังสไลด์แต่ละสไลด์บนสไลด์ภาพรวม ตัวอย่างนี้สร้างสไลด์เป้าหมายสองสไลด์ที่มีพื้นหลังและป้ายกำกับที่แตกต่างกัน แล้วเพิ่มการแสดงตัวอย่างของแต่ละสไลด์ไปยังสไลด์แรกและบันทึกพรีเซนเทชันเป็น PPTX ตำแหน่งและขนาดของกรอบระบุเป็น points.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สร้างกรอบ Zoom ด้วยภาพกำหนดเอง**

ส่งภาพกำหนดเองไปยัง [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) เพื่อแทนที่การแสดงตัวอย่างเริ่มต้นของสไลด์เป้าหมาย ตัวอย่างนี้ต้องใช้ภาพในเครื่อง โหลดภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) และเพิ่มภาพไปยังพรีเซนเทชันด้วย [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) กรอบที่ได้จะแสดงภาพนั้นในขณะที่ยังลิงก์ไปยังสไลด์ที่สอง.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จัดรูปแบบกรอบ Zoom**

ตัวอย่างนี้ปรับแต่งกรอบ Zoom สองกรอบ โดยกำหนดภาพในเครื่องให้กับกรอบแรกผ่าน [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) และให้กรอบที่สองมีขอบสีชมพูขนาดห้า‑point แบบ dash‑dot ผ่าน [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) การส่ง `false` ไปยัง [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) จะซ่อนพื้นหลังของกรอบที่สอง ภาพในเครื่องจำเป็นสำหรับการแสดงตัวอย่างกำหนดเอง; ทั้งสองกรอบยังคงเชื่อมกับสไลด์เป้าหมายในไฟล์ PPTX ที่บันทึกไว้.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    let firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    let secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zoom ส่วน**

Zoom ส่วนลิงก์ไปยังส่วนหนึ่งของพรีเซนเทชัน ใช้เพื่อกลับไปยังหัวข้อเดิมหรือแสดงว่าต่างส่วนเชื่อมโยงกันอย่างไร

![การเลือกส่วนสำหรับ Zoom ส่วน](seczoomsel.png)

สำหรับวัตถุ section zoom, Aspose.Slides ให้บริการ class [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) และ methods บน class [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) .

### **สร้างกรอบ Zoom ส่วน**

สร้างส่วนด้วย [SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection) แล้วส่งส่วนที่ได้ไปยัง [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) ตัวอย่างนี้วาง Zoom ส่วนบนสไลด์แรกและลิงก์ไปยังส่วนที่เริ่มต้นด้วยสไลด์สีต่าง ๆ ตำแหน่งและขนาดของกรอบระบุเป็น points และบันทึกพรีเซนเทชันเป็น PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สร้างกรอบ Zoom ส่วนด้วยภาพกำหนดเอง**

ออฟโหลดรูปของ [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) ทำให้คุณแสดงตัวอย่างกำหนดเองโดยไม่เปลี่ยนส่วนปลายทาง ตัวอย่างนี้ต้องใช้ภาพในเครื่องซึ่งโหลดด้วย [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) และเพิ่มผ่าน [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) พรีเซนเทชันที่บันทึกมี Zoom ส่วนบนสไลด์แรกที่ลิงก์ไปยังส่วนที่สร้างใหม่.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เปลี่ยนส่วนเป้าหมายของ Zoom ส่วน**

ใช้ [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/#setTargetSection) เพื่อเปลี่ยนทิศทางของ Zoom ส่วนที่มีอยู่โดยไม่ต้องสร้างใหม่ เลือกส่วนที่มีข้อมูลจากคอลเลกชัน [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) ของพรีเซนเทชันเดียวกัน การกำหนดส่วนเปล่าจะทำให้เป้าหมายปัจจุบันคงไว้ ดังนั้นให้ตรวจสอบ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection) ก่อนกำหนด ดูรายละเอียดเพิ่มเติมเกี่ยวกับส่วนใน [จัดการส่วนของสไลด์](/slides/th/nodejs-java/slide-section/).

ตัวอย่างต่อไปนี้โหลดไฟล์พรีเซนเทชันซึ่งต้องมีหลายส่วนที่มีข้อมูล, มี Zoom ส่วนที่ชื่อ `Section navigation` อยู่แล้ว, และมีส่วนที่ชื่อแบบเอกลักษณ์ `Results`. มันค้นหาทุกสไลด์เพื่อหา Zoom และหาปลายทางโดยใช้ชื่อแทนการอ้างอิงตามดัชนีที่อาจเปลี่ยนเมื่อจัดลำดับส่วนใหม่ หากชื่อไม่เป็นเอกลักษณ์ ให้ใช้ [Section.getSectionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId) เพื่อระบุปลายทางแทน.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("section-zoom.pptx");
try {
    let zoom = null;
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            const shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.ISectionZoomFrame") && shape.getName() === "Section navigation") {
                zoom = shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    let targetSection = null;
    for (let i = 0; i < presentation.getSections().size(); i++) {
        const section = presentation.getSections().get_Item(i);
        if (section.getName() === "Results") {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        console.log("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        console.log("The destination section is empty.");
    } else {
        let currentSection = zoom.getTargetSection();
        console.log("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **จัดรูปแบบกรอบ Zoom ส่วน**

ตัวอย่างนี้ย้ายและปรับขนาด Zoom ส่วนเป็น 100 x 75 points, กำหนดภาพในเครื่องผ่าน [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) และใช้ขอบสีน้ำตาล dash‑dot ขนาด 2.5‑point. เปิดใช้งาน [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) เพื่อกลับสู่สไลด์ต้นทางหลังจากส่วน, ปิด [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) และตั้งค่า [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) เป็น 1.5 วินาที. ภาพในเครื่องจำเป็นสำหรับการแสดงตัวอย่างกำหนดเอง.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);

    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    sectionZoomFrame.getLineFormat().setWidth(2.5);

    sectionZoomFrame.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zoom สรุป**

Zoom สรุปให้ภาพรวมของส่วนต่าง ๆ ของพรีเซนเทชัน ระหว่างการพรีเซนเทชันคุณสามารถใช้เพื่อกระโดดไปยังส่วน, ข้ามไปข้างหน้า, หรือกลับไปยังหัวข้อโดยไม่ต้องตามลำดับสไลด์.

![การเลือกส่วนสำหรับ Zoom สรุป](sumzoomsel.png)

สำหรับวัตถุ summary zoom, Aspose.Slides ให้บริการ class [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/), และ [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/) พร้อม methods บน class [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) .

### **สร้าง Zoom สรุป**

ใช้ [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSummaryZoomFrame) เพื่อสร้างภาพรวมของส่วนต่าง ๆ ของพรีเซนเทชัน ตัวอย่างนี้สร้างสี่ส่วนที่มีพื้นหลังสไลด์แตกต่างกันและเพิ่ม summary zoom ไปยังสไลด์แรก ตำแหน่งและขนาดของกรอบระบุเป็น points และบันทึกภาพรวมเป็นพรีเซนเทชัน PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 4", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เพิ่มและลบส่วนของ Zoom สรุป**

Zoom สรุปเก็บวัตถุ [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) ใน [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) ตัวอย่างนี้สร้างภาพรวมของสองส่วน, เพิ่มส่วนที่สามด้วย [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) และลบรายการของส่วนแรกด้วย [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) การลบรายการจะไม่กระทบต่อส่วนและสไลด์ของพรีเซนเทชัน.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จัดรูปแบบส่วนของ Zoom สรุป**

ตัวอย่างนี้จัดรูปแบบรายการแรกใน [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) โดยใช้ดัชนีศูนย์ `0`. จำเป็นต้องใช้ภาพในเครื่องสำหรับ [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage), ใช้ขอบสีดำ dash‑dot ขนาด 1.5‑point, และตั้งค่า [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) เป็น 1.5 วินาที การส่ง `false` ไปยัง [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) จะปิดการกลับอัตโนมัติไปยังสไลด์สรุปสำหรับรายการนี้.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    let summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    summarySection.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    summarySection.getLineFormat().setWidth(1.5);

    summarySection.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมการกลับไปยังสไลด์ 'แม่' หลังจากแสดงเป้าหมายได้หรือไม่?**

ใช่. เรียก [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) ด้วยค่า `true` เพื่อกลับไปยังสไลด์ต้นทางหลังจากแสดงเนื้อหาเป้าหมายแล้ว.

**ฉันสามารถปรับ 'ความเร็ว' หรือระยะเวลาในการเปลี่ยนแปลงของ Zoom ได้หรือไม่?**

ใช่. ใช้ [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) เพื่อควบคุมระยะเวลาในการเปลี่ยนภาพเป็นวินาที.

**มีข้อจำกัดจำนวนวัตถุ Zoom ที่พรีเซนเทชันสามารถมีได้หรือไม่?**

ไม่มีข้อจำกัดแบบ API ที่ระบุอย่างชัดเจน ข้อจำกัดเชิงปฏิบัติเกี่ยวข้องกับความซับซ้อนโดยรวมของพรีเซนเทชันและประสิทธิภาพของอุปกรณ์ผู้ชม คุณสามารถเพิ่มกรอบ Zoom ได้หลายอัน แต่ควรคำนึงถึงขนาดไฟล์และเวลาการเรนเดอร์.