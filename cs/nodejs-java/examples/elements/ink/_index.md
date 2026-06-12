---
title: Inkoust
type: docs
weight: 180
url: /cs/nodejs-java/examples/elements/ink/
keywords:
- příklad kódu
- inkoust
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracujte s inkoustem v Aspose.Slides pro Node.js: kreslete, importujte a upravujte tahy, upravujte barvu a šířku a exportujte do PPT, PPTX a ODP pomocí příkladů."
---
Tento článek poskytuje příklady přístupu k existujícím inkoustovým tvarům a jejich odstraňování pomocí **Aspose.Slides for Node.js via Java**.

> ❗ **Poznámka:** Inkoustové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové tahy inkoustu, ale můžete číst a upravovat existující inkoust.

## **Přístup k inkoustu**

Získejte první inkoustový tvar na snímku.

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

## **Odstranit inkoust**

Odstraňte inkoustový tvar ze snímku.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládáme, že inkoustový tvar je první tvar na snímku.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```