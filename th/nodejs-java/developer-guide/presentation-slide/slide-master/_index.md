---
title: จัดการ Slide Master ของการนำเสนอใน JavaScript
linktitle: มาสเตอร์สไลด์
type: docs
weight: 70
url: /th/nodejs-java/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายสไลด์มาสเตอร์
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวกำหนดตำแหน่ง
- คัดลอกสไลด์มาสเตอร์
- สำเนาสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ และลบสไลด์มาสเตอร์ในการนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**slide master** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ มันสามารถประกอบด้วยรูปทรงทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าฝั่งล่าง (footer) ใน PowerPoint การแก้ไข slide master เป็นวิธีปกติในการทำให้การนำเสนอสอดคล้องกันโดยไม่ต้องทำการจัดรูปแบบซ้ำบนแต่ละสไลด์

Aspose.Slides for Node.js via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมี master slide หนึ่งหรือหลาย slide และแต่ละ master slide สามารถมี layout slide หลายอัน สไลด์ปกติทั่วไปจะไม่อ้างอิงไปยัง master slide โดยตรง แต่สไลด์ปกติจะใช้ layout slide และ layout slide นั้นเป็นส่วนหนึ่งของ master slide

ลำดับขั้นตอนคือ:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
1. **Layout slide** - กำหนดการจัดวางเฉพาะของ placeholder และการจัดรูปแบบระดับ layout
1. **Normal slide** - มีเนื้อหาการนำเสนอจริงและใช้ layout slide หนึ่งอัน

![ลำดับขั้นของ master slide, layout slide, และ normal slide](slide-master_2.jpg)

ใน Aspose.Slides, slide master จะถูกแทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) ทุก master slide ในการนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน `Presentation.getMasters()`

{{% alert color="info" title="การสืบทอด" %}}
เมื่อคุณสมบัติเดียวกันถูกกำหนดในหลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก master slide และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อ้างอิง layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slide ดูที่ [ใช้หรือเปลี่ยนแปลง Layout สไลด์](/nodejs-java/slide-layout/).
{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จากเมนู **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ให้ใช้คอลเลกชัน `getMasters()` เพื่อเข้าถึง master slide:

```javascript
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

คุณยังสามารถรับ master slide ที่ใช้โดยสไลด์ปกติผ่าน layout ของมันได้:

```javascript
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

master slide เป็นวัตถุที่คล้ายสไลด์ มันสืบทอดพฤติกรรมสไลด์ทั่วไปจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและ layout slide สมาชิกเฉพาะของ master ถูกรายการไว้ในหน้า API [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/)

สมาชิก master slide ที่ใช้บ่อยรวมถึง:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `getBackground()` | กำหนดพื้นหลังของสไลด์ระดับ master |
| `getShapes()` | เก็บรูปทรงที่วางบน master เช่น โลโก้, กรอบรูปภาพ, และข้อความที่ใช้ร่วมกัน |
| `getLayoutSlides()` | เก็บ layout slide ที่เป็นส่วนของ master |
| `getThemeManager()` | ให้เข้าถึง API ธีมของ master |
| `getHeaderFooterManager()` | ควบคุมส่วนหัว, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับ master และ layout ลูกของมัน |
| `getDependingSlides()` | คืนค่าสไลด์ปกติที่ขึ้นกับ master ผ่าน layout ของมัน |

## **เพิ่มรูปภาพลงใน Slide Master**

เมื่อคุณเพิ่มรูปภาพลงใน master slide รูปภาพจะปรากฏบนสไลด์ที่ใช้ layout จาก master นั้น สิ่งนี้เป็นประโยชน์สำหรับโลโก้, ลายน้ำ, แถบประดับ, และองค์ประกอบภาพอื่นที่ต้องการทำซ้ำ

```javascript
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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูปภาพ ดูที่ [กรอบรูปภาพ](/nodejs-java/picture-frame/).

## **ทำงานกับ Placeholder**

Placeholder มักจะถูกกำหนดบน layout slide master slide ให้สไตล์และธีมที่ใช้ร่วมกันที่ layout เหล่านั้นสืบทอด ส่วนแต่ละ layout จะตัดสินใจว่า placeholder ไหนพร้อมใช้งานและจะวางไว้ที่ไหน

ใน PowerPoint คำสั่ง placeholder มีให้ในมุมมอง Slide Master

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ให้ทำงานกับ layout slide ที่เป็นส่วนของ master:

```javascript
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

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่แล้วบน master slide ตัวอย่างต่อไปนี้ค้นหา placeholder ชื่อเรื่องและใส่การเติมสีไลเนียร์กราเดียนต์:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder ชื่อเรื่องที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [กำหนดข้อความ Prompt ใน Placeholder](/nodejs-java/manage-placeholder/) และ [การจัดรูปแบบข้อความ](/nodejs-java/text-formatting/).

## **เปลี่ยนพื้นหลังของ Slide Master**

พื้นหลังของ master จะถูกสืบทอดโดย layout และสไลด์ที่ไม่ได้ทำการแทนที่ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับ master slide แรก:

```javascript
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

สำหรับหัวข้อที่เกี่ยวข้อง ดูที่ [พื้นหลังของการนำเสนอ](/nodejs-java/presentation-background/) และ [ธีมของการนำเสนอ](/nodejs-java/presentation-theme/).

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

ใช้ `MasterSlideCollection.addClone` เพื่อคัดลอก master slide ไปยังการนำเสนออื่น master ที่คัดลอกแล้วสามารถใช้โดย layout และสไลด์ในการนำเสนอเป้าหมายได้

```javascript
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

หากต้องการคัดลอกสไลด์ปกติพร้อมกับ master ของมัน ดูที่ [คัดลอกสไลด์](/nodejs-java/clone-slides/).

## **เพิ่มหลาย Slide Master**

การนำเสนอสามารถมีหลาย master slide ได้ ซึ่งเป็นประโยชน์เมื่อส่วนต่าง ๆ ต้องการแบรนด์ดิ้ง, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ master slide](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอก master เริ่มต้น, ให้พื้นหลังที่แตกต่าง, สร้าง layout ใต้ master ที่คัดลอกนั้น, และเพิ่มสไลด์ใหม่ที่อิงตาม layout นั้น:

```javascript
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

master slide สามารถเปรียบเทียบด้วยเมธอด `equals` ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่เปรียบเทียบตัวระบุเฉพาะ เช่น slide ID หรือค่าของ placeholder ที่เปลี่ยนแปลงตามวันที่

```javascript
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

สำหรับข้อมูลเพิ่มเติม ดูที่ [เปรียบเทียบสไลด์การนำเสนอ](/nodejs-java/compare-slides/).

## **ตั้งค่ามุมมอง Slide Master เป็นมุมมองเริ่มต้น**

ใช้เมธอด `setLastView` บน [ViewProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นครั้งแรก ตัวอย่างต่อไปนี้เปิดการนำเสนอในมุมมอง Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [บันทึกการนำเสนอ](/nodejs-java/save-presentation/).

## **ลบ Master Slides ที่ไม่ได้ใช้**

การนำเสนอบางครั้งอาจมี master slide ที่ไม่ถูกสไลด์ปกติใดใช้แล้ว การลบ master ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น

ใช้ `removeUnused` เพื่อลบ master ที่ไม่ได้ใช้จากคอลเลกชัน `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถใช้เมธอด low-code `Compress.removeUnusedMasterSlides` ได้:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง slide master กับ layout slide คืออะไร?**

slide master กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกันเช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และสไตล์ข้อความ layout slide เป็นส่วนหนึ่งของ master slide และกำหนดการจัดวางเฉพาะของ placeholder สไลด์ปกติใช้ layout slide จึงสืบทอดจากทั้ง layout และ master

**การนำเสนอหนึ่งสามารถมีหลาย slide master ได้หรือไม่?**

ได้ การนำเสนอสามารถมีหลาย slide master ได้ ใช้หลาย master เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ดิ้งที่แตกต่างกัน

**ควรเพิ่ม placeholder ลงใน master slide หรือ layout slide?**

ในส่วนใหญ่ให้เพิ่ม placeholder ลงใน layout slide ใส่องค์ประกอบภาพที่ใช้ร่วมกันและการจัดรูปแบบร่วมบน master slide แล้วใส่ placeholder สำหรับเนื้อหาบน layout ที่สไลด์ปกติจะใช้

**ฉันสามารถลบ master slide ที่ยังถูกใช้งานอยู่ได้หรือไม่?**

ไม่ได้ master slide ที่มีสไลด์ขึ้นกับมันไม่สามารถลบได้โดยตรง ก่อนอื่นให้ย้ายสไลด์เหล่านั้นไปยัง layout ภายใต้ master อื่น หรือใช้วิธีทำความสะอาด master ที่ไม่ได้ใช้เพื่อเอาเฉพาะ master ที่ไม่ถูกใช้งานออก.