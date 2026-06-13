---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/nodejs-java/examples/elements/math-text/
keywords:
- ตัวอย่างโค้ด
- ข้อความคณิตศาสตร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจตัวอย่าง MathematicalText ของ Aspose.Slides for Node.js: สร้างและจัดรูปสมการ, เศษส่วน, เมทริกซ์, และสัญลักษณ์ในงานนำเสนอ PPT, PPTX และ ODP"
---
บทความนี้แสดงวิธีการทำงานกับรูปแบบข้อความคณิตศาสตร์และการจัดรูปสมการโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปคณิตศาสตร์ที่มีเศษส่วนและสูตรพีทากอรัส

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เพิ่มรูปคณิตศาสตร์ลงในสไลด์.
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // เข้าถึงย่อหน้าคณิตศาสตร์.
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // เพิ่มเศษส่วนง่าย: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // เพิ่มสมการ: c² = a² + b².
        let mathBlock = new aspose.slides.MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);

        presentation.save("math_text.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปร่างที่มีย่อหน้าคณิตศาสตร์บนสไลด์

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ค้นหา shape แรกที่มีย่อหน้าคณิตศาสตร์.
        let mathShape = null;
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            let shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                let textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    let hasMath = false;
                    for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                        let paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                        for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                            let portion = paragraph.getPortions().get_Item(portionIndex);
                            if (java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                                hasMath = true;
                                break;
                            }
                        }
                        if (hasMath) break;
                    }
                    if (hasMath) {
                        mathShape = autoShape;
                        break;
                    }
                }
            }
        }

        if (mathShape != null) {
            let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            let textPortion = paragraph.getPortions().get_Item(0);
            let mathParagraph = textPortion.getMathParagraph();

            // ...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปคณิตศาสตร์จากสไลด์

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกเป็น shape คณิตศาสตร์.
        let mathShape = slide.getShapes().get_Item(0);

        // ลบ shape คณิตศาสตร์.
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

ตั้งค่าคุณสมบัติแบบอักษรสำหรับส่วนคณิตศาสตร์

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่า shape แรกเป็น shape คณิตศาสตร์.
        let mathShape = slide.getShapes().get_Item(0);

        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setFontHeight(20);

        presentation.save("math_text_formatted.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```