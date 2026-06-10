---
title: Diagram
type: docs
weight: 60
url: /hu/java/examples/elements/chart/
keywords:
- kódpélda
- diagram
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mesteri diagramok az Aspose.Slides for Java segítségével: diagramok létrehozása, formázása, adatkapcsolása és exportálása PPT, PPTX és ODP formátumban Java példákkal."
---
Példák különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére az **Aspose.Slides for Java** segítségével. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első diára.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adj hozzá egy egyszerű területdiagramot az első diára.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram elérése**

Diagram létrehozása után a alakzatgyűjteményen keresztül érhető el.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Az első diagram elérése a dián.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram eltávolítása**

Az alábbi kód eltávolít egy diagramot egy diáról.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Távolítsa el a diagramot.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram adatok frissítése**

Megváltoztathatja a diagram tulajdonságait, például a címet.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // A diagram címének módosítása.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```