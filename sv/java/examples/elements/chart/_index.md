---
title: Diagram
type: docs
weight: 60
url: /sv/java/examples/elements/chart/
keywords:
- kodexempel
- diagram
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska diagram med Aspose.Slides for Java: skapa, formatera, binda data och exportera diagram i PPT, PPTX och ODP med Java-exempel."
---
Exempel på att lägga till, komma åt, ta bort och uppdatera olika diagramtyper med **Aspose.Slides for Java**. Kodsnuttarna nedan demonstrerar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Denna metod lägger till ett enkelt area-diagram på den första bilden.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Lägg till ett enkelt area-diagram på den första bilden.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt ett diagram**

Efter att ha skapat ett diagram kan du hämta det via formssamlingen.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Kom åt det första diagrammet på bilden.
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

Du kan ändra diagramegenskaper som titeln.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Ändra diagramtiteln.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```