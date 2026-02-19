---
title: Table
type: docs
weight: 120
url: /fr/nodejs-java/examples/elements/table/
keywords:
- exemple de code
- table
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Travaillez avec les tableaux dans Aspose.Slides pour Node.js : créez, formatez, fusionnez des cellules, appliquez des styles, importez des données et exportez avec des exemples pour PPT, PPTX et ODP."
---
Exemples d'ajout de tableaux, d'accès à ceux-ci, de suppression et de fusion de cellules en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

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

## **Accéder à un tableau**

Récupérez la première forme de tableau de la diapositive.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accédez à la première table de la diapositive.
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

## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suppose que la première forme est un tableau.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Fusionner les cellules du tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suppose que la première forme est un tableau.
        let table = slide.getShapes().get_Item(0);

        // Fusionner les cellules.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```