---
title: गणितीय टेक्स्ट
type: docs
weight: 160
url: /hi/nodejs-java/examples/elements/math-text/
keywords:
- कोड उदाहरण
- गणितीय टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के MathematicalText उदाहरणों की खोज करें: PPT, PPTX और ODP प्रस्तुतियों में समीकरण, भिन्न, मैट्रिक्स और प्रतीकों को बनाएं और फ़ॉर्मेट करें।"
---
यह लेख **Aspose.Slides for Node.js via Java** का उपयोग करके गणितीय टेक्स्ट शेप्स के साथ काम करने और समीकरणों को फॉर्मेट करने का प्रदर्शन करता है।

## **गणितीय टेक्स्ट जोड़ें**
एक गणितीय शेप बनाएं जिसमें एक भिन्न और पायथागोरस सूत्र शामिल हो।

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड में एक गणितीय आकार जोड़ें।
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // गणितीय पैराग्राफ तक पहुँचें।
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // एक सरल भिन्न जोड़ें: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // समीकरण जोड़ें: c² = a² + b².
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

## **गणितीय टेक्स्ट तक पहुँचें**
स्लाइड पर उस शेप को खोजें जिसमें गणितीय पैराग्राफ हो।

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // पहली आकृति खोजें जिसमें गणितीय पैराग्राफ हो।
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

## **गणितीय टेक्स्ट हटाएँ**
स्लाइड से एक गणितीय शेप हटाएँ।

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहली आकृति गणितीय आकार है।
        let mathShape = slide.getShapes().get_Item(0);

        // गणितीय आकार हटाएँ।
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **गणितीय टेक्स्ट फॉर्मेट करें**
गणितीय भाग के लिए फ़ॉन्ट गुण सेट करें।

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहली आकृति गणितीय आकार है।
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