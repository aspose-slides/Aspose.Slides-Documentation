---
title: Bläck
type: docs
weight: 180
url: /sv/nodejs-java/examples/elements/ink/
keywords:
- kodexempel
- bläck
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Arbeta med bläck i Aspose.Slides för Node.js: rita, importera och redigera penseldrag, justera färg och bredd, samt exportera till PPT, PPTX och ODP med exempel."
---
Den här artikeln ger exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for Node.js via Java**.

> ❗ **Obs:** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstift programatiskt, men du kan läsa och ändra befintligt bläck.

## **Åtkomst till bläck**

Hämta den första bläckformen på en bild.

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

## **Ta bort bläck**

Ta bort en bläckform från bilden.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Antar att bläckformen är den första formen på bilden.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```