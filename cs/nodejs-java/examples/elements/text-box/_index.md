---
title: Textové pole
type: docs
weight: 40
url: /cs/nodejs-java/examples/elements/text-box/
keywords:
- ukázka kódu
- textové pole
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracujte s textovými poli v Aspose.Slides pro Node.js: přidávejte, formátujte, zarovnávejte, zalamujte, automaticky přizpůsobujte a stylizujte text pomocí JavaScriptu pro prezentace PPT, PPTX a ODP."
---
V Aspose.Slides je **textové pole** reprezentováno pomocí `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani okraj a zobrazuje pouze text.

Tento průvodce vysvětluje, jak programově přidávat, přistupovat k a odstraňovat textová pole.

## **Přidat textové pole**

Textové pole je prostě `AutoShape` bez výplně ani okraje a s určitým formátovaným textem. Následuje, jak jej vytvořit:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Vytvořte obdélníkový tvar (standardně vyplněný okrajem a bez textu).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Odstraňte výplň a okraj, aby vypadal jako typické textové pole.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Nastavte formátování textu.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Přiřaďte skutečný textový obsah.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Poznámka:** Každý `AutoShape`, který obsahuje neprázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovému poli**

Získejte první textové pole ze snímku.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Pouze AutoShape mohou obsahovat editovatelný text.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit textová pole podle obsahu**

Tento příklad najde a smaže všechna textová pole na první snímku, která obsahují konkrétní klíčové slovo:

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

> 💡 **Tip:** Vždy vytvořte kopii kolekce tvarů před jejím upravením během iterace, abyste se vyhnuli chybám při modifikaci kolekce.