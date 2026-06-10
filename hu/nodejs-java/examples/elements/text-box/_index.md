---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/nodejs-java/examples/elements/text-box/
keywords:
- kódpélda
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js-ben a szövegdobozok kezelése: szöveg hozzáadása, formázása, igazítása, tördelése, automatikus méretezése és stílusozása JavaScript használatával PPT, PPTX és ODP prezentációkhoz."
---
Az Aspose.Slides-ban egy **szövegdoboz** egy `AutoShape`-ként jelenik meg. Gyakorlatilag bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy kerettel, és csak a szöveget jeleníti meg.

Ez az útmutató elmagyarázza, hogyan adhatunk hozzá, érhetünk el és távolíthatunk el szövegdobozokat programozottan.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amely nem rendelkezik kitöltéssel vagy kerettel, és tartalmaz formázott szöveget. Íme, hogyan hozhatunk létre egyet:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hozzon létre egy téglalap alakzatot (alapértelmezés szerint kitöltött kerettel és szöveg nélkül).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Távolítsa el a kitöltést és a keretet, hogy egy tipikus szövegdoboznak tűnjön.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Állítsa be a szöveg formázását.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Rendelje hozzá a tényleges szövegtartalmat.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`-et tartalmaz, funkcionálhat szövegdobozként.

## **Szövegdoboz elérése**

A diáról lekérdezhető az első szövegdoboz.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Csak az AutoShape-ek tartalmazhatnak szerkeszthető szöveget.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megtalálja és törli az első dián található összes szövegdobozt, amely egy adott kulcsszót tartalmaz:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tipp:** Mindig készítsünk másolatot az alakzatgyűjteményről, mielőtt módosítanánk azt iteráció közben, hogy elkerüljük a gyűjtemény módosításával kapcsolatos hibákat.