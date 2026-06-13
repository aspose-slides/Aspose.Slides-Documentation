---
title: गणितीय पाठ
type: docs
weight: 160
url: /hi/java/examples/elements/math-text/
keywords:
- कोड उदाहरण
- गणितीय पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के MathematicalText उदाहरणों की खोज करें: समीकरण, अंश, मैट्रिक्स और प्रतीकों को Java के साथ PPT, PPTX और ODP प्रस्तुतियों में बनाएं और स्वरूपित करें।"
---
यह लेख **Aspose.Slides for Java** का उपयोग करके गणितीय पाठ आकारों के साथ काम करने और समीकरणों को स्वरूपित करने का प्रदर्शन करता है।

## **गणितीय पाठ जोड़ें**

एक गणितीय आकार बनाएं जिसमें एक अंश और पायथागोरस सूत्र हो।

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // स्लाइड में एक गणितीय आकार जोड़ें।
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // गणितीय पैराग्राफ तक पहुंचें।
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // एक साधारण अंश जोड़ें: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // समीकरण जोड़ें: c² = a² + b².
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

## **गणितीय पाठ तक पहुंचें**

स्लाइड पर एक गणितीय अनुच्छेद वाले आकार को खोजें।

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // पहले आकार को खोजें जो एक गणितीय पैराग्राफ रखता हो।
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

            // उदाहरण: एक अंश बनाएं (यहाँ नहीं जोड़ा गया)।
            IMathElement fraction = new MathematicalText("x").divide("y");

            // आवश्यकतानुसार mathParagraph या fraction का उपयोग करें...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **गणितीय पाठ हटाएं**

स्लाइड से गणितीय आकार हटाएं।

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

        // गणितीय आकार हटाएँ।
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **गणितीय पाठ का स्वरूपण**

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