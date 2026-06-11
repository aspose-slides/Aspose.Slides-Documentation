---
title: Diagram
type: docs
weight: 60
url: /sv/androidjava/examples/elements/chart/
keywords:
- kodexempel
- diagram
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska diagram med Aspose.Slides för Android: skapa, formatera, binda data och exportera diagram i PPT, PPTX och ODP med Java-exempel."
---
Exempel på hur man lägger till, får åtkomst till, tar bort och uppdaterar olika diagramtyper med **Aspose.Slides for Android via Java**. Snuttarna nedan demonstrerar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Denna metod lägger till ett enkelt ytdiagram på den första bilden.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till ett enkelt ytdiagram på den första bilden.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Få åtkomst till ett diagram**

Efter att ha skapat ett diagram kan du hämta det via shape-samlingen.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Få åtkomst till det första diagrammet på bilden.
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

## **Ta bort ett diagram**

Följande kod tar bort ett diagram från en bild.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Ta bort diagrammet.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Uppdatera diagramdata**

Du kan ändra diagramegenskaper som t.ex. titeln.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Ändra diagramrubriken.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```