---
title: Tableau
type: docs
weight: 120
url: /fr/java/examples/elements/table/
keywords:
- exemple de code
- tableau
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Travaillez avec les tableaux dans Aspose.Slides for Java : créez, formatez, fusionnez des cellules, appliquez des styles, importez des données et exportez avec des exemples Java pour PPT, PPTX et ODP."
---
Exemples d'ajout de tableaux, d'accès à ceux‑ci, de suppression et de fusion de cellules à l'aide de **Aspose.Slides for Java**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Accéder au premier tableau sur la diapositive.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
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

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Fusionner les cellules du tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Fusionner les cellules.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```