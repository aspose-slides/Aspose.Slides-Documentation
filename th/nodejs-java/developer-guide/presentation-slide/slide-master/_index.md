---
title: จัดการ Slide Master ของการนำเสนอใน JavaScript
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/nodejs-java/slide-master/
keywords:
- สไลด์มาสเตอร์
- มาสเตอร์สไลด์
- มาสเตอร์สไลด์ PPT
- หลายมาสเตอร์สไลด์
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวแทนตำแหน่ง
- คัดลอกมาสเตอร์สไลด์
- สำเนามาสเตอร์สไลด์
- ทำซ้ำมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบและลบสไลด์มาสเตอร์ในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

A **slide master** กำหนดค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์หนึ่ง สามารถมีรูปทรงทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าฟุตเตอร์ ใน PowerPoint การแก้ไข slide master เป็นวิธีปกติที่จะทำให้การนำเสนอสอดคล้องกันโดยไม่ต้องทำฟอร์แมตเดียวกันในแต่ละสไลด์

Aspose.Slides for Node.js via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี slide master หนึ่งหรือหลายอัน และแต่ละ slide master สามารถมี layout slide หลายอัน สไลด์ปกติส่วนใหญ่จะไม่อ้างอิง slide master โดยตรง แต่จะใช้ layout slide ซึ่ง layout slide นั้นเป็นของ slide master

โครงสร้างเป็นดังนี้:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
1. **Layout slide** - กำหนดการจัดวางเฉพาะของ placeholders และการฟอร์แมตระดับ layout
1. **Normal slide** - ประกอบด้วยเนื้อหาในการนำเสนอจริงและใช้ layout slide หนึ่งอัน

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

ใน Aspose.Slides, slide master แทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) ทั้งหมดของ slide master ในไฟล์นำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน `Presentation.getMasters()`

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเช่นเดียวกันถูกกำหนดในหลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก slide master และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิง layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ดูที่ [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)
{{% /alert %}}

## **การเข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master จาก **View** > **Slide Master**

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึง slide master:

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

คุณยังสามารถรับ slide master ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้:

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

## **สิ่งที่ Slide Master มีอยู่**

slide master เป็นวัตถุที่คล้ายสไลด์ มันสืบทอดพฤติกรรมสไลด์ทั่วไปจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout slide สมาชิกที่เกี่ยวกับ master ระบุไว้ในหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/)

สมาชิกของ slide master ที่ใช้งานบ่อยรวมถึง:

| Member | Purpose |
| --- | --- |
| `getBackground()` | ตั้งค่าพื้นหลังระดับ master ของสไลด์ |
| `getShapes()` | เก็บรูปทรงที่วางบน master เช่น โลโก้, กรอบรูปภาพ, และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides()` | เก็บ layout slide ที่เป็นของ master |
| `getThemeManager()` | ให้การเข้าถึง API ธีมของ master |
| `getHeaderFooterManager()` | ควบคุมส่วนหัว, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูก |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่ขึ้นอยู่กับ master ผ่าน layout ของมัน |

## **เพิ่มรูปภาพลงใน Slide Master**

เมื่อคุณเพิ่มรูปภาพลงใน slide master รูปภาพนั้นจะปรากฏบนสไลด์ที่ใช้ layout จาก master นั้น ซึ่งเป็นประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องการใช้ซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงใน slide master แรก:

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูปภาพ ดูที่ [Picture Frame](/nodejs-java/picture-frame/)

## **ทำงานกับ Placeholders**

Placeholders โดยทั่วไปถูกกำหนดบน layout slide slide master จะให้สไตล์และธีมที่ใช้ร่วมกันซึ่ง layout สืบทอดมา ส่วนแต่ละ layout จะตัดสินใจว่า placeholders ใดพร้อมใช้งานและวางไว้ที่ตำแหน่งไหน

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

เพื่อเพิ่ม placeholders ใหม่ด้วย Aspose.Slides ให้ทำงานกับ layout slide ที่เป็นของ master:

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

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่บน master slide ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใส่การไล่สีเชิงเส้น:

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) และ [Text Formatting](/nodejs-java/text-formatting/)

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลังของ master จะถูกสืบทอดโดย layout และสไลด์ที่ไม่ได้ทำการเขียนทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังเป็นสีทึบสำหรับ slide master แรก:

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

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/nodejs-java/presentation-background/) และ [Presentation Theme](/nodejs-java/presentation-theme/)

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ `MasterSlideCollection.addClone` เพื่อคัดลอก slide master ไปยังการนำเสนออื่น ๆ master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในไฟล์เป้าหมายได้

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

หากต้องการคัดลอกสไลด์ปกติโดยรวมกับ master ของมัน ดูที่ [Clone Slides](/nodejs-java/clone-slides/)

## **เพิ่มหลาย Slide Masters**

การนำเสนอสามารถมี slide master ได้หลายอัน ซึ่งมีประโยชน์เมื่อแต่ละส่วนต้องการแบรนด์ดิ้ง, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ให้พื้นหลังที่ต่างกันแก่การคัดลอก, สร้าง layout ใต้ master ที่คัดลอกแล้ว, และเพิ่มสไลด์ใหม่ที่อิงจาก layout นั้น:

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

## **เปรียบเทียบ Slide Masters**

Slide master สามารถเปรียบเทียบได้ด้วยเมธอด `equals` ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง, ข้อความ, การฟอร์แมต, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุที่เป็นเอกลักษณ์ เช่น slide ID หรือค่าตัวแปร placeholder ที่เปลี่ยนแปลงตามเวลา

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

สำหรับข้อมูลเพิ่มเติม ดูที่ [Compare Presentation Slides](/slides/th/nodejs-java/compare-slides/)

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/) เพื่อกำหนดมุมมองที่ PowerPoint เปิดครั้งแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

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

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [Save Presentation](/slides/th/nodejs-java/save-presentation/)

## **ลบ Slide Masters ที่ไม่ได้ใช้**

บางครั้งการนำเสนออาจมี slide master ที่ไม่ได้ถูกสไลด์ปกติใดใช้งาน การลบ master ที่ไม่ได้ใช้จะช่วยลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

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

### ความแตกต่างระหว่าง slide master กับ layout slide คืออะไร?

slide master กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงร่วม, และสไตล์ข้อความ layout slide เป็นส่วนของ slide master และกำหนดการจัดวางเฉพาะของ placeholders สไลด์ปกติใช้ layout slide ดังนั้นจึงสืบทอดจากทั้ง layout และ master

### การนำเสนอหนึ่งสามารถมี slide master หลายอันได้หรือไม่?

ได้ การนำเสนอสามารถมี slide master หลายอัน ใช้ master หลายอันเมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือตราสินค้าที่แตกต่างกัน

### ควรเพิ่ม placeholders ที่ slide master หรือ layout slide?

ในกรณีส่วนใหญ่ให้เพิ่ม placeholders ที่ layout slide วางองค์ประกอบภาพและการฟอร์แมตที่ใช้ร่วมกันบน slide master แล้วใส่ placeholders สำหรับเนื้อหาบน layout ที่สไลด์ปกติจะใช้

### สามารถลบ slide master ที่ยังถูกใช้งานอยู่ได้หรือไม่?

ไม่ สามารถลบ slide master ที่มีสไลด์ขึ้นอยู่ได้โดยตรงต้องย้ายสไลด์เหล่านั้นไปยัง layout ของ master อื่นหรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้เท่านั้น.