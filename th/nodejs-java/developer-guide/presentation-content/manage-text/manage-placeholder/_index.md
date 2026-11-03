---
title: จัดการตัวเก็บตำแหน่งการนำเสนอใน JavaScript
linktitle: จัดการตัวเก็บตำแหน่ง
type: docs
weight: 10
url: /th/nodejs-java/manage-placeholder/
keywords:
- ตัวเก็บตำแหน่ง
- ตัวเก็บตำแหน่งข้อความ
- ตัวเก็บตำแหน่งรูปภาพ
- ตัวเก็บตำแหน่งแผนภูมิ
- ตัวเก็บตำแหน่งเนื้อหา
- ข้อความเชิญ
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไขตัวเก็บตำแหน่งข้อความ, รูปภาพ, แผนภูมิและเนื้อหา และทำความเข้าใจการสืบทอดตัวเก็บตำแหน่งด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปร่างที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ ชื่อสไลด์, เนื้อหา, รูปภาพ, แผนภูมิ และตำแหน่งตัวเก็บเนื้อหาทั่วไป ต่างจากรูปร่างธรรมดา placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เค้าโครงหรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) เมธอดนี้จะคืนค่าออบเจกต์ [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) หรือ `null` สำหรับรูปร่างปกติ ใช้เมธอด [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) เพื่อกำหนดว่าตำแหน่งตัวเก็บนั้นมีจุดประสงค์เพื่อเก็บอะไร

คลาสรูปร่างยังคงมีความสำคัญหลังจากรู้ประเภทของ placeholder แล้ว:

- Placeholder ของข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาเปล่าโดยทั่วไปจะแสดงด้วย [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Placeholder ของรูปภาพที่มีข้อมูลแล้วสามารถแสดงด้วย [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Placeholder ของแผนภูมิที่มีข้อมูลแล้วสามารถแสดงด้วย [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Placeholder เนื้อหาสามารถบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) และคลาสรูปร่างขณะทำงานจริง แทนที่จะสันนิษฐานว่า placeholder ทุกตัวเป็น [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) อธิบายบทบาทของ placeholder; แต่มันไม่ได้รับประกันประเภทของรูปร่างขณะทำงานจริง ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอดตำแหน่งตัวเก็บ**

Placeholder สร้างเป็นโครงสร้างลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณี placeholder ระดับมาสเตอร์
2. สไลด์เค้าโครงกำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์
3. สไลด์ปกติบรรจุตำแหน่งตัวเก็บสำหรับสไลด์นั้นและสามารถสืบทอดจากเค้าโครงของมันได้

เรียกเมธอด [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) เพื่อย้ายหนึ่งระดับขึ้นในลำดับขั้นนี้ Placeholder ของสไลด์ปกติโดยทั่วไปจะคืนค่า placeholder ของเค้าโครง; placeholder ของเค้าโครงอาจคืนค่า placeholder ของมาสเตอร์ เมธอดจะคืนค่า `null` เมื่อรูปร่างไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละตัว:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการโอเวอร์ไรด์ระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเค้าโครงหรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งค่านั้น รูปร่างปกติระดับท้องถิ่นไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อปรับเทมเพลต ใช้เมธอด [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) เพื่อรักษาออบเจกต์ที่มีอยู่ให้เป็นรูปร่างปกติ เมธอด [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) ของมันจะคืนค่า `null` แต่รูปร่างยังคงอยู่ในคอลเลกชันของสไลด์ตรงกันข้ามเมธอด [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) จะลบรูปร่างออกจากคอลเลกชันนั้น

ตัวอย่างต่อไปนี้ต้องการไฟล์ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความไม่ว่างเปล่าบนสไลด์แรก ใช้ placeholder ที่มาจากการสืบทอดรูปแบบจากเค้าโครงหรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์ ตัวอย่างจะตรวจสอบว่ารูปร่างยังคงอยู่เรียกเมธอดอีกครั้งบนรูปร่างที่เป็นปกติแล้วและบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้ทำให้การตั้งค่าการปรากฏที่สืบทอดโดยอัตโนมัติคงอยู่ ตัวอย่างด้านล่างจึงตั้งค่าเหล่านั้นไว้โดยไม่เปลี่ยนแปลง ดังนั้นผลลัพธ์อาจดูแตกต่างกัน รูปร่างที่สืบทอดตำแหน่งและขนาดอย่างเต็มที่อาจมีพิกัดและมิติเป็นศูนย์หลังการเรียกและกลายเป็นไม่มองเห็นได้แม้ว่ายังอยู่ในคอลเลกชัน
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // การเรียกเมธอดบนรูปร่างปกติจะไม่มีผล.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับ placeholder ที่ตรงกัน ทั้งสามการตรวจสอบจะพิมพ์ `true` ข้อความยังคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนท์, การจัดย่อหน้า, ระยะขอบข้อความ, การตรึงแนวตั้ง, การเติมและการเส้นขอบที่สืบทอดอาจเปลี่ยนเมื่อความสัมพันธ์ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวเรื่องที่สืบทอดอาจย้อนกลับไปเป็นการจัดรูปแบบข้อความปกติ ดู [Slide Layout](/slides/th/nodejs-java/slide-layout/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับเค้าโครง

เพื่อรักษาการปรากฏตามที่ต้องการ ให้จับค่าตำแหน่ง, ขนาดและการหมุนที่ได้แล้วก่อนการเรียกและคัดลอกค่าการจัดรูปแบบที่มีผลจริงลงในตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่านเมธอด [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) และ [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) อย่าพึ่งพาแค่วัตถุ effective‑format เพราะค่าการจัดรูปแบบข้อความของมันอาจเปลี่ยนหลังจากลบความสัมพันธ์ ปรับใช้ค่าที่จับได้กับรูปร่างปกติหลังจากนั้นอย่างชัดเจน รวมถึงฟอนท์, ขนาด, สไตล์, สี, การตั้งค่าข้อความย่อหน้า, การตั้งค่ากรอบข้อความ, การเติมและการเส้นที่ใช้ในเทมเพลตของคุณ

เรายังอาจต้องกำหนดรูปทรงที่สืบทอดอย่างชัดเจนผ่านเมธอด [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) สำหรับ placeholder ข้อความสี่เหลี่ยมจะต้องกำหนดค่า [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) การกู้คืนเพียงการเติมและการเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นกลับมาได้ เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบที่ซับซ้อนต้องจัดการค่าเหล่านั้นด้วยเช่นกัน

## **เปลี่ยนข้อความในตำแหน่งตัวเก็บ**

หัวเรื่อง, centered‑title, subtitle, body และ placeholder ข้อความโดยทั่วไปรองรับข้อความ ตรวจสอบว่ารูปร่างเป็น [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame)

ตัวอย่างนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

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

รูปแบบนี้หลีกเลี่ยงการพิจารณา placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็นออบเจกต์ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) นอกจากนี้ยังระบุตำแหน่งตัวเก็บตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปร่างที่เปราะบาง

## **ตั้งข้อความเชิญบน Layout**

ข้อความเชิญคือคำแนะนำที่แสดงใน placeholder ว่าง เช่น *Click to add title* ตั้งข้อความเชิญแบบกำหนดเองบน placeholder ของเค้าโครงแทนที่จะพยายามเข้าถึงจากคอลเลกชันรูปร่างของสไลด์ปกติ เข้าถึงเค้าโครงผ่านเมธอด [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) และวนลูปคอลเลกชันที่ส่งคืนโดยเมธอด [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)

ตัวอย่างต่อไปนี้เปลี่ยนข้อความเชิญของหัวเรื่องและหัวเรื่องย่อยบนเค้าโครงที่ใช้โดยสไลด์แรก:

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

ข้อความเชิญไม่ได้เป็นเนื้อหาของสไลด์ปกติ มันมีจุดประสงค์สำหรับ placeholder ว่างในแอปพลิเคชันแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้วข้อความเชิญจะไม่แสดงอีก การเปลี่ยนข้อความเชิญยังไม่ทำให้ข้อความที่มีอยู่บนสไลด์ที่ใช้เค้าโครงนั้นถูกแทนที่

## **อัพเดตตำแหน่งตัวเก็บรูปภาพ**

มีสองกรณีที่ต้องจัดการ:

- หาก placeholder รูปภาพมีข้อมูลแล้วและแสดงด้วย [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), ให้แทนที่รูปภาพผ่านเมธอด [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) และ [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage)
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วยเมธอด [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) แล้วลบ placeholder ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกงานนำเสนอ:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame ระดับท้องถิ่น ไม่ได้เป็น placeholder ใหม่ เพราะเมธอด [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) ไม่ให้ setter มันรักษาตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากการรักษาความสัมพันธ์ placeholder มีความสำคัญ ให้เตรียมและเติมข้อมูล placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับการทำให้รูปโปร่งแสง, การครอปและเอฟเฟกต์ที่เจาะจงต่อรูปภาพ ดู [Manage Picture Frames](/slides/th/nodejs-java/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาต้า placeholder

## **ทำงานกับตำแหน่งตัวเก็บแผนภูมิและเนื้อหา**

Placeholder ของแผนภูมิที่มีข้อมูลแล้วสามารถแสดงด้วย [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยอิงประเภท placeholder และคลาสขณะทำงาน เปลี่ยนหัวเรื่องของมันและบันทึกไฟล์:

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

Placeholder เนื้อหาทั่วไปมักมีค่า [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) ใน PowerPoint มันทำหน้าที่เป็นตัวเปิดสำหรับหลายประเภทของเนื้อหา เช่น แผนภูมิ, ตาราง, แผนภาพ, รูปภาพและสื่อ หลังจากที่ถูกเติมแล้ว ให้ตรวจสอบคลาสรูปร่างที่แท้จริงเพื่อทราบว่ามีอะไรอยู่ เค้าโครงพิเศษอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram)

Aspose.Slides ไม่ได้แปลง placeholder [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ว่างให้เป็น [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) เพียงเปลี่ยนค่า [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); ประเภทไม่สามารถเปลี่ยนได้ผ่านออบเจกต์ เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาว่างโดยโปรแกรม ให้เพิ่มออบเจกต์ที่จำเป็นที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

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

แผนภูมิที่เพิ่มขึ้นเป็นแผนภูมิระดับท้องถิ่นทั่วไป มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเค้าโครง ใช้บทความการจัดการแผนภูมิที่อุทิศเฉพาะ ([chart management articles](/slides/th/nodejs-java/powerpoint-charts/)) เมื่อคุณต้องการแทนที่ประเภท, ซีรีส์ หรือข้อมูลในเวิร์กบุ๊กของมัน

## **ตัวอย่างครบ: อัพเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างต่อไปนี้เป็นแบบครบวงจร เปิดเทมเพลต ค้นหาสไลด์แรกเพื่อหา placeholder ของหัวเรื่องหรือรูปภาพ ตรวจสอบประเภท placeholder และรูปร่าง ปรับปรุงเนื้อหาที่เหมาะสม แล้วบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานว่ามีดัชนีรูปร่างหรือการถือว่า placeholder ทุกตัวเป็นคลาสเดียวกัน

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

## **FAQ**

**ตำแหน่งตัวเก็บพื้นฐานคืออะไร?**

ตำแหน่งตัวเก็บพื้นฐานคือรูปร่างที่สอดคล้องกันในเค้าโครงหรือมาสเตอร์ ซึ่งตำแหน่งตัวเก็บอื่นสืบทอดมาจากมัน ใช้เมธอด [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) เพื่อดึงค่า รูปร่างท้องถิ่นปกติจะคืนค่า `null` เนื่องจากไม่ได้เป็นส่วนหนึ่งของโครงสร้างลำดับขั้นของ placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข placeholder ของเค้าโครงได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความเชิญที่สืบทอดผ่านเค้าโครงได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จัดเก็บไว้บนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริง ๆ ในการนำเสนอทั้งหมด จำเป็นต้องวนลูปสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันควรจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายที่ระดับสไลด์, เค้าโครง, มาสเตอร์, โน้ต หรือเอกสารแจกจ่ายตามที่เหมาะสม ดูบทความ [Manage Presentation Header and Footer](/slides/th/nodejs-java/presentation-header-and-footer/) เพื่อดูตัวอย่างครบถ้วน