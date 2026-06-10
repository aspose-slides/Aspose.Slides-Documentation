---
title: Tintavonalak
type: docs
weight: 180
url: /hu/nodejs-java/examples/elements/ink/
keywords:
- kódpélda
- tinta
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js-ben a tinta használata: vonalak rajzolása, importálása és szerkesztése, szín és vastagság beállítása, valamint PPT, PPTX és ODP formátumba exportálás példákkal."
---
Ez a cikk példákat nyújt a meglévő tintával jelölt alakzatok elérésére és azok eltávolítására a **Aspose.Slides for Node.js via Java** használatával.

> ❗ **Megjegyzés:** A tintával jelölt alakzatok a speciális eszközök felhasználói bevitelét képviselik. Az Aspose.Slides programozottan nem tud új tintavonalakat létrehozni, de olvashatja és módosíthatja a meglévő tintát.

## **Tintához való hozzáférés**

Hozza vissza az első tintával jelölt alakzatot egy dián.

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

## **Tintát eltávolítani**

Törölje a tintával jelölt alakzatot a diáról.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy a tinta alakzat az első alakzat a dián.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```