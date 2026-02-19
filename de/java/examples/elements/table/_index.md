---
title: Tabelle
type: docs
weight: 120
url: /de/java/examples/elements/table/
keywords:
- Codebeispiel
- Tabelle
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Tabellen in Aspose.Slides für Java: Erstellen, Formatieren, Zellen zusammenführen, Stile anwenden, Daten importieren und exportieren - mit Java-Beispielen für PPT, PPTX und ODP."
---
Beispiele zum Hinzufügen von Tabellen, zum Zugreifen auf sie, zum Entfernen und zum Zusammenführen von Zellen mit **Aspose.Slides for Java**.

## **Tabelle hinzufügen**

Erstellen Sie eine einfache Tabelle mit zwei Zeilen und zwei Spalten.

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

## **Auf eine Tabelle zugreifen**

Rufen Sie die erste Tabellengrafik auf der Folie ab.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Zugriff auf die erste Tabelle auf der Folie.
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

## **Tabelle entfernen**

Löschen Sie eine Tabelle von einer Folie.

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

## **Tabellenzellen zusammenführen**

Führen Sie benachbarte Zellen einer Tabelle zu einer einzigen Zelle zusammen.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Zellen zusammenführen.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```