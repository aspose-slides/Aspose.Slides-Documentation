---
title: गणितीय टेक्स्ट
type: docs
weight: 160
url: /hi/androidjava/examples/elements/math-text/
keywords:
- कोड उदाहरण
- गणितीय टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के MathematicalText उदाहरणों का अन्वेषण करें: Java के साथ PPT, PPTX, और ODP प्रस्तुतियों में समीकरण, भिन्न, मैट्रिक्स और प्रतीकों को बनाएं और स्वरूपित करें।"
---
यह लेख **Aspose.Slides for Android via Java** का उपयोग करके गणितीय टेक्स्ट आकृतियों पर काम करने और समीकरणों को स्वरूपित करने का प्रदर्शन करता है।

## **गणितीय टेक्स्ट जोड़ें**

एक गणितीय आकृति बनाएं जिसमें एक भिन्न और पायथागोरस सूत्र हो।

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // स्लाइड में एक गणितीय आकृति जोड़ें।
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // गणितीय पैराग्राफ तक पहुँचें।
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // एक सरल भिन्न जोड़ें: x / y।
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // समिकरण जोड़ें: c² = a² + b²।
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

## **गणितीय टेक्स्ट तक पहुँचें**

स्लाइड पर एक गणितीय पैराग्राफ वाली आकृति खोजें।

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // पहले आकृति को खोजें जिसमें गणितीय पैराग्राफ हो।
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

            // उदाहरण: एक भिन्न बनाएं (यहाँ नहीं जोड़ा गया)।
            IMathElement fraction = new MathematicalText("x").divide("y");

            // Use mathParagraph or fraction as needed...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **गणितीय टेक्स्ट हटाएँ**

स्लाइड से एक गणितीय आकृति हटाएँ।

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

        // गणितीय आकृति को हटाएँ।
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **गणितीय टेक्स्ट को स्वरूपित करें**

गणितीय भाग के लिए फ़ॉन्ट गुण सेट करें।

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