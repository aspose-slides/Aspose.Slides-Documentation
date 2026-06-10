---
title: Táblázat
type: docs
weight: 120
url: /hu/java/examples/elements/table/
keywords:
- kódrészlet
- táblázat
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Táblázatok kezelése az Aspose.Slides for Java-ban: létrehozás, formázás, cellák egyesítése, stílusok alkalmazása, adatok importálása és exportálása Java példákkal PPT, PPTX és ODP formátumokhoz."
---
Példák táblák hozzáadására, lekérdezésére, eltávolítására és cellák egyesítésére a **Aspose.Slides for Java** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblázatot két sorral és két oszloppal.

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

## **Táblázat elérése**

Szerezze meg az első táblázat alakzatot a dián.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Az első táblázat elérése a dián.
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

## **Táblázat eltávolítása**

Töröljön egy táblázatot a diáról.

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

## **Táblázatcellák egyesítése**

Egyesítsen egymás melletti táblázatcellákat egyetlen cellába.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Cellák egyesítése.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```