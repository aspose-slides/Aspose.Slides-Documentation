---
title: Diagramm
type: docs
weight: 60
url: /de/androidjava/examples/elements/chart/
keywords:
- Codebeispiel
- Diagramm
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Meistern Sie Diagramme mit Aspose.Slides für Android: Erstellen, formatieren, Daten binden und Diagramme in PPT, PPTX und ODP mit Java-Beispielen exportieren."
---
Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for Android via Java**. Die nachfolgenden Codebeispiele demonstrieren grundlegende Diagrammoperationen.

## **Diagramm hinzufügen**

Diese Methode fügt der ersten Folie ein einfaches Flächendiagramm hinzu.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ein einfaches Flächendiagramm zur ersten Folie hinzufügen.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagramm abrufen**

Nachdem Sie ein Diagramm erstellt haben, können Sie es über die Shape-Sammlung abrufen.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Greife auf das erste Diagramm auf der Folie zu.
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

## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Diagramm entfernen.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Diagrammtitel ändern.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```