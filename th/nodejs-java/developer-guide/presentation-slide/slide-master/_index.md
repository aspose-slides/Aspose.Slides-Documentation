---
title: จัดการ Slide Master ของการนำเสนอใน JavaScript
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/nodejs-java/slide-master/
keywords:
- สไลด์มาสเตอร์
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์ PPT
- หลายมาสเตอร์สไลด์
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวจัดตำแหน่ง
- ทำสำเนามาสเตอร์สไลด์
- คัดลอกมาสเตอร์สไลด์
- ทำซ้ำมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการ slide master ใน Aspose.Slides สำหรับ Node.js ผ่าน Java: เข้าถึง, แก้ไข, ทำสำเนา, เปรียบเทียบ และลบมาสเตอร์สไลด์ในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

A **slide master** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถมีรูปทรงทั่วไป โลโก้ พื้นหลัง สไตล์ข้อความ การตั้งค่าธีม และการตั้งค่าฟุตเตอร์ ใน PowerPoint การแก้ไข slide master เป็นวิธีทั่วไปเพื่อให้การนำเสนอสอดคล้องโดยไม่ต้องทำฟอร์แมตเดียวกันซ้ำในทุกสไลด์.

Aspose.Slides for Node.js via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี master slide หนึ่งหรือหลายอัน และแต่ละ master slide สามารถมี layout slide หลายอัน สไลด์ปกติมักไม่อ้างอิง master slide โดยตรง แต่สไลด์ปกติจะใช้ layout slide และ layout slide นั้นเป็นส่วนหนึ่งของ master slide.

The hierarchy is:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน.
1. **Layout slide** - กำหนดการจัดเรียงเฉพาะของ placeholder และการฟอร์แมตระดับ layout.
1. **Normal slide** - มีเนื้อหาการนำเสนอจริงและใช้ layout slide หนึ่งอัน.

![โครงสร้างของ master slide, layout slide, และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides slide master จะถูกแทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) ทั้งหมดของ master slide ในการนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเดียวกันถูกกำหนดในหลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก master slide และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่ใช้ layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ดูที่ [ใช้หรือเปลี่ยนการจัดเรียงสไลด์](/nodejs-java/slide-layout/).
{{% /alert %}}

## **เข้าถึง Slide Master**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึง master slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

คุณสามารถรับ master slide ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้ด้วย:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **เนื้อหาของ Slide Master**

master slide เป็นวัตถุที่คล้ายสไลด์ มันสืบทอดพฤติกรรมสไลด์ทั่วไปจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout slide สมาชิกที่เฉพาะเจาะจงกับ master จะถูกระบุในหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/)

Commonly used master slide members include:

| Member | Purpose |
| --- | --- |
| `getBackground()` | ตั้งค่าพื้นหลังของสไลด์ระดับ master. |
| `getShapes()` | เก็บรูปทรงที่วางบน master เช่น โลโก้, กรอบรูป, และข้อความที่ใช้ร่วมกัน. |
| `getLayoutSlides()` | เก็บ layout slide ที่เป็นส่วนของ master. |
| `getThemeManager()` | ให้การเข้าถึง API ธีมของ master. |
| `getHeaderFooterManager()` | ควบคุมหัวกระดาษ, ท้ายกระดาษ, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูกของมัน. |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่พึ่งพา master ผ่าน layout ของพวกมัน. |

## **เพิ่มรูปภาพไปยัง Slide Master**

เมื่อคุณเพิ่มรูปภาพไปยัง master slide มันจะปรากฏบนสไลด์ที่ใช้ layout จาก master นั้น ซึ่งเป็นประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ไปยัง master slide แรก:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูป ดูที่ [กรอบรูป](/nodejs-java/picture-frame/).

## **ควบคุมการมองเห็นของกราฟิก Master**

ใช้ [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) เพื่อลบการแสดงกราฟิก master ที่สืบทอดมา เช่น โลโก้หรือรูปทรงตกแต่ง โดยไม่ต้องลบออกจาก master ส่งค่า `false` ไปยัง [Slide.setShowMasterShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#setShowMasterShapes) บนสไลด์ที่ต้องการละเว้นกราฟิกเหล่านั้น และให้ค่า `true` บนสไลด์ที่ต้องการแสดงกราฟิก

ตัวอย่างต่อไปนี้สร้างแถบตกแต่งสีน้ำเงินบน master และสไลด์สองอันที่ใช้ layout ว่างเดียวกัน แถบจะมองเห็นได้บนสไลด์แรกแต่ถูกซ่อนบนสไลด์ที่สอง ไม่ต้องมีการนำเสนอหรือรูปภาพเข้า

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตัวอย่างใช้ layout **Blank** ที่มาพร้อมกับการนำเสนอใหม่และลบ placeholder ของสไลด์เริ่มต้นออก

### **เลือกขอบเขตของการตั้งค่า**

A normal slide uses its master through [Slide.getLayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getLayoutSlide) and [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). การตั้งค่าคุณสมบัติบนสไลด์เดี่ยวจะส่งผลเฉพาะสไลด์นั้นเท่านั้น การส่งค่า `false` ไปยัง [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) จะซ่อนกราฟิก master สำหรับสไลด์ที่ใช้ layout ร่วมกัน แม้การตั้งค่าของสไลด์เองจะเป็น `true` ก็ตาม หากต้องการซ่อนกราฟิกบนสไลด์เดียว ให้เปลี่ยนคุณสมบัติของสไลด์นั้นและไม่แก้ไข layout ร่วม

การตั้งค่านี้ไม่รองรับเป็นการควบคุมการมองเห็นบน master slide เอง บน master, [getShowMasterShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) จะคืนค่า `false` เสมอ และการส่งค่า `true` ไปยัง [setShowMasterShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) จะทำให้เกิดข้อยกเว้น ให้ใช้กับสไลด์ปกติหรือ layout แทน

### **แยกกราฟิกจากพื้นหลัง**

| Operation | Effect |
| --- | --- |
| Hide master graphics | ควบคุมการมองเห็นของรูปทรง master ที่สืบทอดโดยไม่ลบหรือเปลี่ยนแปลงรูปทรงของสไลด์เอง. |
| Change the slide background fill | เปลี่ยนการเติมพื้นหลังของสไลด์ เช่น สี, การไล่สี หรือรูปภาพ. กราฟิก master เป็นรูปทรงแยกกันและสามารถมองเห็นอยู่เหนือพื้นหลังนั้นได้ ดูที่ [พื้นหลังการนำเสนอ](/slides/th/nodejs-java/presentation-background/). |
| Delete a shape from the master | ลบรูปทรงจาก master ซึ่งทำให้รูปทรงที่ใช้ร่วมกันไม่สามารถใช้ได้กับสไลด์ใด ๆ ที่ใช้ master นั้น. |

## **ทำงานกับ Placeholder**

Placeholder มักถูกกำหนดบน layout slide. master slide ให้สไตล์และธีมที่ใช้ร่วมกันซึ่ง layout สืบทอดมา ในขณะเดียวกันแต่ละ layout ตัดสินใจว่า placeholder ใดจะพร้อมใช้งานและวางไว้ที่ตำแหน่งใด

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ทำงานกับ layout slide ที่เป็นส่วนของ master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่แล้วบน master slide ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมไล่สีเชิงเส้น:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder ชื่อเรื่องที่จัดรูปแบบแล้วสืบทอดมาจากสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [ตั้งค่าข้อความเชิญใน Placeholder](/nodejs-java/manage-placeholder/) และ [การจัดรูปแบบข้อความ](/nodejs-java/text-formatting/).

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลัง master จะถูกสืบทอดโดย layout และสไลด์ที่ไม่ทำการทับค่า ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับ master slide แรก:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [พื้นหลังการนำเสนอ](/nodejs-java/presentation-background/) และ [ธีมการนำเสนอ](/nodejs-java/presentation-theme/).

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ `MasterSlideCollection.addClone` เพื่อคัดลอก master slide ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำหมายปลายได้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

หากต้องการคัดลอกสไลด์ปกติกับ master ของมันด้วย ดูที่ [คัดลอกสไลด์](/nodejs-java/clone-slides/).

## **เพิ่มหลาย Slide Master**

การนำเสนอสามารถมีหลาย master slide ซึ่งมีประโยชน์เมื่อส่วนต่าง ๆ ต้องการแบรนด์, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ master slide](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ตั้งค่าพื้นหลังที่แตกต่างให้กับคัดลอก, สร้าง layout ใต้ master ที่คัดลอกนั้น, และเพิ่มสไลด์ใหม่ที่อิงจาก layout นั้น:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เปรียบเทียบ Slide Master**

Master slide สามารถเปรียบเทียบได้ด้วยเมธอด `equals` ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง, ข้อความ, การฟอร์แมต, แอนิเมชัน, และการตั้งค่าอื่น ๆ ของสไลด์ ไม่ได้เปรียบเทียบรหัสประจำตัวเฉพาะ เช่น slide ID หรือค่าที่เป็น dynamic ของ placeholder เช่น วันที่ปัจจุบัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

สำหรับข้อมูลเพิ่มเติม ดูที่ [เปรียบเทียบสไลด์การนำเสนอ](/slides/th/nodejs-java/compare-slides/).

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นอันดับแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [บันทึกการนำเสนอ](/slides/th/nodejs-java/save-presentation/).

## **ลบ Master Slide ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี master slide ที่ไม่มีสไลด์ปกติใดใช้แล้ว การลบ master ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

ใช้ `removeUnused` เพื่อลบ master ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถใช้เมธอด low-code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ความแตกต่างระหว่าง slide master กับ layout slide คืออะไร?**

slide master กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และสไตล์ข้อความ. layout slide เป็นส่วนหนึ่งของ master slide และกำหนดการจัดเรียงเฉพาะของ placeholder. สไลด์ปกติใช้ layout slide ดังนั้นจึงสืบทอดจากทั้ง layout และ master.

**การนำเสนอหนึ่งสามารถมีหลาย slide master ได้หรือไม่?**

ได้. การนำเสนอสามารถมีหลาย slide master. ใช้หลาย master เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน.

**ควรเพิ่ม placeholder ลงใน master slide หรือ layout slide?**

ในกรณีส่วนใหญ่ให้เพิ่ม placeholder ลงใน layout slide. ใส่องค์ประกอบภาพที่ใช้ร่วมกันและการฟอร์แมตที่ใช้ร่วมกันบน master slide แล้วใส่ placeholder ของเนื้อหาใน layout ที่สไลด์ปกติจะใช้.

**ฉันสามารถลบ master slide ที่ยังถูกใช้งานอยู่ได้หรือไม่?**

ไม่ได้. master slide ที่มีสไลด์พึ่งพาไม่สามารถลบได้โดยตรง. ควรย้ายสไลด์เหล่านั้นไปยัง layout ภายใต้ master อื่นก่อน หรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้ซึ่งจะลบเฉพาะ master ที่ไม่มีการใช้งาน.