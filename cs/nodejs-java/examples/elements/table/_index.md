---
title: Tabulka
type: docs
weight: 120
url: /cs/nodejs-java/examples/elements/table/
keywords:
- příklad kódu
- tabulka
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Pracujte s tabulkami v Aspose.Slides pro Node.js: vytvářejte, formátujte, slučujte buňky, aplikujte styly, importujte data a exportujte s příklady pro PPT, PPTX a ODP."
---
Příklady přidávání tabulek, přístupu k nim, odstraňování a slučování buněk pomocí **Aspose.Slides for Node.js via Java**.

## **Přidat tabulku**

Vytvořte jednoduchou tabulku se dvěma řádky a dvěma sloupci.

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

## **Přístup k tabulce**

Získejte první tvar tabulky ze snímku.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Přístup k první tabulce na snímku.
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

## **Odstranit tabulku**

Odstraňte tabulku ze snímku.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je tabulka.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sloučit buňky tabulky**

Sloučte sousední buňky tabulky do jedné buňky.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Předpokládejte, že první tvar je tabulka.
        let table = slide.getShapes().get_Item(0);

        // Sloučit buňky.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```