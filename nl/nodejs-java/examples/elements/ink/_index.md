---
title: Inkt
type: docs
weight: 180
url: /nl/nodejs-java/examples/elements/ink/
keywords:
- codevoorbeeld
- inkt
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Werk met Inkt in Aspose.Slides for Node.js: teken, importeer en bewerk streken, pas kleur en breedte aan, en exporteer naar PPT, PPTX en ODP met voorbeelden."
---
Dit artikel geeft voorbeelden van het benaderen van bestaande inktvormen en het verwijderen ervan met **Aspose.Slides for Node.js via Java**.

> ❗ **Opmerking:** Inktvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatisch aanmaken, maar u kunt bestaande inkt lezen en aanpassen.

## **Ink benaderen**

Haal de eerste inktvorm op een dia op.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ink verwijderen**

Verwijder een inktvorm van de dia.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Aannemende dat de inktvorm de eerste vorm op de dia is.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```