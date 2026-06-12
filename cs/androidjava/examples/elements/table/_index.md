---
title: Tabulka
type: docs
weight: 120
url: /cs/androidjava/examples/elements/table/
keywords:
- příklad kódu
- tabulka
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Práce s tabulkami v Aspose.Slides pro Android: vytváření, formátování, slučování buněk, použití stylů, import dat a export s příklady v Java pro PPT, PPTX a ODP."
---
Příklady pro přidávání tabulek, přístup k nim, odstraňování a sloučení buněk pomocí **Aspose.Slides for Android via Java**.

## **Přidat tabulku**

Vytvořte jednoduchou tabulku se dvěma řádky a dvěma sloupci.

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

## **Přístup k tabulce**

Získejte první tvar tabulky na snímku.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Přístup k první tabulce na snímku.
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

## **Odstranit tabulku**

Odstraňte tabulku ze snímku.

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

## **Sloučit buňky tabulky**

Sloučte sousední buňky tabulky do jedné buňky.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Sloučit buňky.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```