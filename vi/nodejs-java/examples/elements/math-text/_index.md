---
title: Văn Bản Toán Học
type: docs
weight: 160
url: /vi/nodejs-java/examples/elements/math-text/
keywords:
- ví dụ mã
- văn bản toán học
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các ví dụ MathematicalText của Aspose.Slides cho Node.js: tạo và định dạng phương trình, phân số, ma trận và ký hiệu trong các bản trình bày PPT, PPTX và ODP."
---
Bài viết này minh họa cách làm việc với các hình dạng văn bản toán học và định dạng các phương trình bằng **Aspose.Slides for Node.js via Java**.

## **Thêm Văn Bản Toán Học**

Tạo một hình dạng toán học chứa một phân số và công thức Pythagore.

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Thêm một hình dạng Toán học vào slide.
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Truy cập đoạn văn toán học.
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // Thêm một phân số đơn giản: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // Thêm phương trình: c² = a² + b².
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

## **Truy cập Văn Bản Toán Học**

Xác định một hình dạng chứa đoạn văn toán học trên slide.

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tìm hình dạng đầu tiên chứa một đoạn văn toán học.
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

## **Xóa Văn Bản Toán Học**

Xóa một hình dạng toán học khỏi slide.

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là hình dạng toán học.
        let mathShape = slide.getShapes().get_Item(0);

        // Xóa hình dạng toán học.
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Định dạng Văn Bản Toán Học**

Đặt các thuộc tính phông chữ cho một phần toán học.

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là hình dạng toán học.
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