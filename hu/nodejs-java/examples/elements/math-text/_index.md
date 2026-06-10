---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/nodejs-java/examples/elements/math-text/
keywords:
- kód példa
- matematikai szöveg
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js MathematicalText példákat: egyenletek, törtök, mátrixok és szimbólumok létrehozása és formázása PPT, PPTX és ODP bemutatókban."
---
Ez a cikk bemutatja a matematikai szöveges alakzatok használatát és egyenletek formázását az **Aspose.Slides for Node.js via Java** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy matematikai alakzatot, amely tartalmaz egy törtet és a Pitagorasz képletet.

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Adjon hozzá egy Math alakzatot a diához.
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // Hozzáférés a matematikai bekezdéshez.
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // Adjon hozzá egy egyszerű törtet: x / y.
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // Adjon hozzá egy egyenletet: c² = a² + b².
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

## **Matematikai szöveg elérése**

Keressen egy olyan alakzatot, amely a dián egy matematikai bekezdést tartalmaz.

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Keresse meg az első alakzatot, amely matematikai bekezdést tartalmaz.
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

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tegyük fel, hogy az első alakzat a matematikai alakzat.
        let mathShape = slide.getShapes().get_Item(0);

        // Távolítsa el a matematikai alakzatot.
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Matematikai szöveg formázása**

Állítsa be a betűtípus tulajdonságait egy matematikai részhez.

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tegyük fel, hogy az első alakzat a matematikai alakzat.
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