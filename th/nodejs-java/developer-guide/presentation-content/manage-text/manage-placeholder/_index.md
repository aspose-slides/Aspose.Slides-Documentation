---
title: จัดการ Placeholder ของงานนำเสนอใน JavaScript
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/nodejs-java/manage-placeholder/
keywords:
- ตำแหน่งวาง
- ตำแหน่งวางข้อความ
- ตำแหน่งวางรูปภาพ
- ตำแหน่งวางแผนภูมิ
- ตำแหน่งวางเนื้อหา
- ข้อความแนะนำ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, แผนภูมิและเนื้อหา รวมถึงทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่จองตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไป ได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิและ placeholder เนื้อหาทั่วไปอื่น ๆ แตกต่างจากรูปทรงธรรมดา placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape.getPlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getPlaceholder) เมธอดนี้จะคืนค่าออบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [Placeholder.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/#getType) เพื่อกำหนดว่า placeholder มีไว้เพื่อเก็บอะไร

คลาสรูปทรงยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาโดยทั่วไปมักจะแทนด้วย [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)  
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแทนด้วย [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/)  
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแทนด้วย [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/)  
- Placeholder เนื้อหาอาจมีหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/#getType) และคลาสรูปทรงในเวลารันไทม์ แทนที่จะสันนิษฐานว่า placeholder ทั้งหมดเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/#getType) บรรยายบทบาทของ placeholder แต่ไม่ได้รับประกันประเภทของรูปทรงในเวลารันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกของข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีโครงสร้างเป็นลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณีอาจมี placeholder ระดับมาสเตอร์  
2. สไลด์เลย์เอาต์กำหนดการจัดเรียงที่ใช้โดยสไลด์ธรรมดาหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้  
3. สไลด์ธรรมดามี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ได้  

เรียกใช้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) เพื่อย้ายขึ้นหนึ่งระดับในลำดับขั้น สไลด์ placeholder จะคืนค่า placeholder ของเลย์เออต์; placeholder ของเลย์เอาต์สามารถคืนค่า placeholder ของมาสเตอร์ได้ เมธอดจะคืนค่า `null` หากรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละรายการ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

การแก้ไข placeholder บนสไลด์ธรรมดาจะสร้างหรือเปลี่ยนการแทนที่เฉพาะท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลย์เออต์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคินั้น รูปทรงธรรมดาท้องถิ่นไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder ประเภทหัวเรื่อง, centered‑title, subtitle, body และข้อความทั่วไปมักรองรับข้อความ ตรวจสอบว่าเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ก่อนเรียกเมธอด [getTextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/#getTextFrame)

ตัวอย่างต่อไปนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบนี้หลีกเลี่ยงการถือว่า picture, chart, table หรือ media placeholder เป็นออบเจ็กต์ [AutoShape] และระบุตัว placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่อาจเปลี่ยนแปลงได้

## **ตั้งข้อความ Prompt บน Layout**

Prompt text คือคำแนะนำที่แสดงใน placeholder ที่ว่างเปล่า เช่น *คลิกเพื่อเพิ่มหัวเรื่อง* ตั้งข้อความ Prompt แบบกำหนดเองบน placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ธรรมดา เข้าถึงเลย์เอาต์ผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#getLayoutSlide) และวนลูปคอลเลกชันที่คืนจาก [BaseSlide.getShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getShapes)

ตัวอย่างต่อไปนี้เปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prompt text ไม่ใช่เนื้อหาของสไลด์ปกติ มันมีไว้สำหรับ placeholder ที่ว่างเปล่าในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริง Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ยังไม่ทำให้ข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เออต์นั้นถูกแทนที่

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder มีเนื้อหาแล้วและแทนด้วย [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ให้แทนที่ภาพผ่าน [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#getPicture) และ [Picture.setImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picture/#setImage)  
- หากยังเป็น placeholder ที่ว่างเปล่า ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) แล้วลบ placeholder ที่ว่างเปล่าออก  

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การแทนที่ที่สร้างสำหรับ placeholder ที่ว่างเปล่าเป็น picture frame ท้องถิ่น ไม่ได้สร้าง placeholder ใหม่ เนื่องจาก [Shape.getPlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getPlaceholder) ไม่มี setter มันยังคงจุดจองตำแหน่งแต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากต้องการรักษาความสัมพันธ์กับ placeholder อย่างสำคัญ ควรเตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วจึงอัปเดต [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับการตั้งค่าความโปร่งใสของภาพ, การครอปและเอฟเฟกต์อื่น ๆ ที่เฉพาะเจาะจงกับ picture ให้ดูที่ [Manage Picture Frames](/slides/th/nodejs-java/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของเมตาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Chart placeholder ที่เต็มข้อมูลสามารถแทนด้วย [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) ตัวอย่างนี้ค้นหา chart ดังกล่าวโดยใช้ทั้งประเภท placeholder และคลาสรันไทม์, เปลี่ยนหัวเรื่องและบันทึกไฟล์:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Content placeholder ทั่วไปมักมี [PlaceholderType.Object](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Object) ใน PowerPoint ทำหน้าที่เป็นตัวเรียกหลายประเภทของเนื้อหา รวมถึง chart, table, diagram, picture และ media หลังจากถูกเติมแล้ว ให้ตรวจสอบคลาสรูปทรงจริงเพื่อทราบว่ามีอะไรอยู่ Layout พิเศษอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Media) หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholdertype/#Diagram)

Aspose.Slides ไม่ได้แปลง [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) placeholder ที่ว่างเปล่าให้เป็น [Chart] เพียงแค่เปลี่ยน [Placeholder.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/#getType); ประเภทไม่สามารถเปลี่ยนได้ผ่านออบเจ็กต์ เพื่อเติม chart หรือพื้นที่เนื้อหาที่ว่างเปล่าโดยโปรแกรม ให้เพิ่มออบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับ chart:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Chart ที่เพิ่มเข้ามาเป็น chart ท้องถิ่นทั่วไป มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลย์เอาต์ ใช้บทความการจัดการ chart เฉพาะ ([chart management articles](/slides/th/nodejs-java/powerpoint-charts/)) เมื่อคุณต้องการแทนที่ประเภท, ชุดข้อมูล หรือข้อมูล workbook ของมัน

## **ตัวอย่างเต็ม: อัปเดตข้อความหรือเนื้อหาภาพ**

ตัวอย่างต่อไปนี้เป็นการทำงานตั้งแต่ต้นจนจบ: เปิดเทมเพลต, ค้นหา placeholder ชื่อเรื่องหรือ picture บนสไลด์แรก, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสมและบันทึกผลลัพธ์ ตัวอย่างหลีกเลี่ยงการสมมติว่ามีดัชนีรูปทรงหรือว่าทุก placeholder เป็นคลาสเดียวกัน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Base placeholder คืออะไร?**

Base placeholder คือรูปทรงที่สอดคล้องบนเลย์เออต์หรือมาสเตอร์จากซึ่ง placeholder อื่นสืบทอด ใช้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) เพื่อดึงค่ามา รูปทรงท้องถิ่นทั่วไปจะคืนค่า `null` เพราะไม่ได้เป็นส่วนหนึ่งของลำดับขั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องของสไลด์ทั้งหมดโดยแก้ไข placeholder ของเลย์เออต์ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดผ่านเลย์เอาต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จริงจะถูกเก็บไว้บนสไลด์ธรรมดา เพื่อแทนที่ข้อความหัวเรื่องจริงในทั้งการนำเสนอ ให้วนลูปสไลด์ทั้งหมดและอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ผู้จัดการส่วนหัวและส่วนท้ายในระดับสไลด์, เลย์เอาต์, มาสเตอร์,โน้ตหรือเอกสารแจกจ่าย ดูที่ [Manage Presentation Header and Footer](/slides/th/nodejs-java/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน