---
title: Tabel
type: docs
weight: 120
url: /nl/androidjava/examples/elements/table/
keywords:
- code voorbeeld
- tabel
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werk met tabellen in Aspose.Slides voor Android: maken, opmaken, cellen samenvoegen, stijlen toepassen, gegevens importeren en exporteren met Java-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, het benaderen ervan, het verwijderen ervan en het samenvoegen van cellen met **Aspose.Slides for Android via Java**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

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

## **Tabel benaderen**

Haal de eerste tabelvorm op de dia op.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Toegang tot de eerste tabel op de dia.
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

## **Tabel verwijderen**

Verwijder een tabel van een dia.

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

## **Tabelcellen samenvoegen**

Voeg naast elkaar gelegen cellen van een tabel samen tot één enkele cel.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Cellen samenvoegen.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```