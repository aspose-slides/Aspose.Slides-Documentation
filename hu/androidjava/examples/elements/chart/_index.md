---
title: Diagram
type: docs
weight: 60
url: /hu/androidjava/examples/elements/chart/
keywords:
- kód példa
- diagram
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mesteri diagramok az Aspose.Slides for Android segítségével: diagramok létrehozása, formázása, adatok kötése és diagramok exportálása PPT, PPTX és ODP formátumba Java példákkal."
---
Példák különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére a **Aspose.Slides for Android via Java** használatával. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első diára.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Egyszerű területdiagram hozzáadása az első diára.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram elérése**

A diagram létrehozása után a formai gyűjteményen keresztül kérdezhető le.

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

Az alábbi kód egy diagramot távolít el egy diáról.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // A diagram eltávolítása.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagram adatainak frissítése**

Megváltoztathatja a diagram tulajdonságait, például a címet.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // A diagram címének megváltoztatása.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```