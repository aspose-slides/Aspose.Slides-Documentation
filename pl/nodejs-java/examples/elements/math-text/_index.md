---
title: Tekst matematyczny
type: docs
weight: 160
url: /pl/nodejs-java/examples/elements/math-text/
keywords:
- przykład kodu
- tekst matematyczny
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj przykłady MathematicalText w Aspose.Slides for Node.js: twórz i formatuj równania, ułamki, macierze oraz symbole w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł demonstruje pracę z kształtami tekstu matematycznego oraz formatowanie równań przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj tekst matematyczny**

Utwórz kształt matematyczny zawierający ułamek i wzór Pitagorasa.

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Dodaj kształt matematyczny do slajdu.
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Uzyskaj dostęp do akapitu matematycznego.
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // Dodaj prosty ułamek: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // Dodaj równanie: c² = a² + b².
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

## **Dostęp do tekstu matematycznego**

Zlokalizuj kształt zawierający akapit matematyczny na slajdzie.

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Znajdź pierwszy kształt, który zawiera akapit matematyczny.
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

## **Usuń tekst matematyczny**

Usuń kształt matematyczny ze slajdu.

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakłada się, że pierwszy kształt jest kształtem matematycznym.
        let mathShape = slide.getShapes().get_Item(0);

        // Usuń kształt matematyczny.
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Formatuj tekst matematyczny**

Ustaw właściwości czcionki dla fragmentu matematycznego.

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zakłada się, że pierwszy kształt jest kształtem matematycznym.
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