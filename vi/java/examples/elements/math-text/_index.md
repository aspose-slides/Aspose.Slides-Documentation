---
title: Văn Bản Toán Học
type: docs
weight: 160
url: /vi/java/examples/elements/math-text/
keywords:
- ví dụ mã
- văn bản toán học
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá các ví dụ MathematicalText của Aspose.Slides for Java: tạo và định dạng các phương trình, phân số, ma trận và ký hiệu với Java trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với các hình dạng văn bản toán học và định dạng phương trình bằng **Aspose.Slides for Java**.

## **Thêm Văn Bản Toán Học**

Tạo một hình dạng toán học chứa một phân số và công thức Pythagoras.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Thêm một hình dạng Toán học vào slide.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Truy cập đoạn văn Toán học.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Thêm một phân số đơn giản: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Thêm phương trình: c² = a² + b².
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

## **Truy Cập Văn Bản Toán Học**

Xác định một hình dạng có chứa đoạn văn toán học trên slide.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tìm hình dạng đầu tiên chứa đoạn văn toán học.
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

            // Ví dụ: tạo một phân số (không được thêm ở đây).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Use mathParagraph or fraction as needed...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Văn Bản Toán Học**

Xóa một hình dạng toán học ra khỏi slide.

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

        // Xóa hình dạng toán học.
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **Định Dạng Văn Bản Toán Học**

Đặt các thuộc tính phông chữ cho một phần toán học.

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