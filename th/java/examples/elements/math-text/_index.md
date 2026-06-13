---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/java/examples/elements/math-text/
keywords:
- ตัวอย่างโค้ด
- ข้อความคณิตศาสตร์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "สำรวจตัวอย่าง MathematicalText ของ Aspose.Slides for Java: สร้างและจัดรูปแบบสมการ, เศษส่วน, เมทริกซ์, และสัญลักษณ์ด้วย Java ในการนำเสนอ PPT, PPTX, และ ODP."
---
บทความนี้แสดงการทำงานกับรูปร่างข้อความคณิตศาสตร์และการจัดรูปแบบสมการโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มข้อความคณิตศาสตร์**

สร้างรูปร่างคณิตศาสตร์ที่มีเศษส่วนและสูตรพีทากอรัส.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // เพิ่มรูปร่างคณิตศาสตร์ลงในสไลด์.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // เข้าถึงย่อหน้าคณิตศาสตร์.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // เพิ่มเศษส่วนง่าย: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // เพิ่มสมการ: c² = a² + b².
        IMathBlock mathBlock = new MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงข้อความคณิตศาสตร์**

ค้นหารูปร่างที่มีย่อหน้าคณิตศาสตร์บนสไลด์.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // ค้นหารูปร่างแรกที่มีย่อหน้าคณิตศาสตร์.
        IAutoShape mathShape = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                ITextFrame textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    boolean hasMath = false;
                    for (IParagraph paragraph : textFrame.getParagraphs()) {
                        for (IPortion portion : paragraph.getPortions()) {
                            if (portion instanceof MathPortion) {
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
            IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            IPortion textPortion = paragraph.getPortions().get_Item(0);
            IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

            // ตัวอย่าง: สร้างเศษส่วน (ไม่ได้เพิ่มที่นี่).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // ใช้ mathParagraph หรือ fraction ตามต้องการ...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบข้อความคณิตศาสตร์**

ลบรูปร่างคณิตศาสตร์จากสไลด์.

```java
static void removeMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);

        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // ลบรูปร่างคณิตศาสตร์.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **จัดรูปแบบข้อความคณิตศาสตร์**

ตั้งค่าคุณสมบัติของฟอนต์สำหรับส่วนของคณิตศาสตร์.

```java
static void formatMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        textPortion.getPortionFormat().setFontHeight(20);
    } finally {
        presentation.dispose();
    }
}
```