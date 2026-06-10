---
title: Táblázat
type: docs
weight: 120
url: /hu/nodejs-java/examples/elements/table/
keywords:
- kódpélda
- táblázat
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Táblázatok használata az Aspose.Slides for Node.js-ban: létrehozás, formázás, cellák egyesítése, stílusok alkalmazása, adatok importálása és exportálása PPT, PPTX és ODP példákkal."
---
Példák táblák hozzáadására, lekérésére, eltávolítására és a cellák egyesítésére a **Aspose.Slides for Node.js via Java** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblát két sorral és két oszloppal.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Táblázat lekérése**

Szerezze vissza az első táblázat alakzatot a diából.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Hozzáférés az első táblához a dián.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Táblázat eltávolítása**

Töröljen egy táblázatot egy diáról.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat egy táblázat.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Táblázat celláinak egyesítése**

Egyesítse a táblázat szomszédos celláit egyetlen cellává.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Feltételezzük, hogy az első alakzat egy táblázat.
        let table = slide.getShapes().get_Item(0);

        // Cellák egyesítése.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```