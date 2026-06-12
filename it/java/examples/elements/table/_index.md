---
title: Tabella
type: docs
weight: 120
url: /it/java/examples/elements/table/
keywords:
- esempio di codice
- tabella
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Lavorare con le tabelle in Aspose.Slides for Java: creare, formattare, unire celle, applicare stili, importare dati ed esportare con esempi Java per PPT, PPTX e ODP."
---
Esempi per aggiungere tabelle, accedervi, rimuoverle e unire le celle utilizzando **Aspose.Slides for Java**.

## **Aggiungere una tabella**
Crea una tabella semplice con due righe e due colonne.

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

## **Accedere a una tabella**
Recupera la prima forma tabella nella diapositiva.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Accedi alla prima tabella nella diapositiva.
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

## **Rimuovere una tabella**
Elimina una tabella da una diapositiva.

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

## **Unire le celle della tabella**
Unisci le celle adiacenti di una tabella in un'unica cella.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Unisci le celle.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```