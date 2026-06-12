---
title: Teks Matematika
type: docs
weight: 160
url: /id/java/examples/elements/math-text/
keywords:
- contoh kode
- teks matematika
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jelajahi contoh MathematicalText Aspose.Slides for Java: buat dan format persamaan, pecahan, matriks, dan simbol dengan Java dalam presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan bentuk teks matematika dan memformat persamaan menggunakan **Aspose.Slides for Java**.

## **Tambah Teks Matematika**

Buat bentuk matematika yang berisi pecahan dan rumus Pythagoras.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tambahkan bentuk Math ke slide.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Akses paragraf matematika.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // Tambahkan pecahan sederhana: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // Tambahkan persamaan: c² = a² + b².
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

## **Akses Teks Matematika**

Temukan bentuk yang berisi paragraf matematika pada slide.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Temukan bentuk pertama yang berisi paragraf matematika.
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

            // Contoh: buat sebuah pecahan (tidak ditambahkan di sini).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Gunakan mathParagraph atau fraction sesuai kebutuhan...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Hapus Teks Matematika**

Hapus bentuk matematika dari slide.

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

        // Hapus bentuk matematika.
    } finally {
        presentation.dispose();
    }
}
```

## **Format Teks Matematika**

Atur properti font untuk bagian matematika.

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