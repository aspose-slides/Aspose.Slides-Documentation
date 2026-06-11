---
title: Tabell
type: docs
weight: 120
url: /sv/androidjava/examples/elements/table/
keywords:
- kodexempel
- tabell
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Arbeta med tabeller i Aspose.Slides för Android: skapa, formatera, slå ihop celler, tillämpa stilar, importera data och exportera med Java-exempel för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå ihop celler med **Aspose.Slides for Android via Java**.

## **Lägg till en tabell**
Skapa en enkel tabell med två rader och två kolumner.

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

## **Komma åt en tabell**
Hämta den första tabellformen på bilden.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Åtkomst till den första tabellen på bilden.
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

## **Ta bort en tabell**
Ta bort en tabell från en bild.

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

## **Slå ihop tabellceller**
Slå ihop intilliggande celler i en tabell till en enda cell.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Slå ihop celler.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```