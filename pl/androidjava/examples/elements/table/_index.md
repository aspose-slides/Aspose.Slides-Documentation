---
title: Tabela
type: docs
weight: 120
url: /pl/androidjava/examples/elements/table/
keywords:
- przykład kodu
- tabela
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Pracuj z tabelami w Aspose.Slides for Android: twórz, formatuj, scalaj komórki, stosuj style, importuj dane i eksportuj, korzystając z przykładów w języku Java dla formatów PPT, PPTX i ODP."
---
Przykłady dodawania tabel, uzyskiwania do nich dostępu, usuwania ich oraz scalania komórek przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj tabelę**

Utwórz prostą tabelę z dwoma wierszami i dwiema kolumnami.

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

## **Uzyskaj dostęp do tabeli**

Pobierz pierwszy kształt tabeli na slajdzie.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Uzyskaj dostęp do pierwszej tabeli na slajdzie.
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

## **Usuń tabelę**

Usuń tabelę ze slajdu.

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

## **Scal komórki tabeli**

Scal przyległe komórki tabeli w jedną komórkę.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Scal komórki.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```