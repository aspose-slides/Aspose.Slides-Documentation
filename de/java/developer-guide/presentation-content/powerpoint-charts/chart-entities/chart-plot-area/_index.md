---
title: Diagramm Plot Bereich
type: docs
url: /java/chart-plot-area/
---


## **Breite, Höhe des Diagramm Plot Bereichs abrufen**
Aspose.Slides für Java bietet eine einfache API für. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) auf, um die aktuellen Werte zu erhalten.
1. Erhalten Sie die tatsächliche X-Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Erhalten Sie die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Erhalten Sie die tatsächliche Breite des Diagrammelements.
1. Erhalten Sie die tatsächliche Höhe des Diagrammelements.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Layout-Modus des Diagramm Plot Bereichs festlegen**
Aspose.Slides für Java bietet eine einfache API, um den Layout-Modus des Diagramm Plot Bereichs festzulegen. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) Klasse und zur [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) Schnittstelle hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich durch sein Inneres (ohne Achse und Achsenbeschriftungen) oder durch sein Äußeres (einschließlich Achse und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) Enum definiert sind.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmen soll, ohne die Tick-Marken und Achsenbeschriftungen.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick-Marken und die Achsenbeschriftungen bestimmen soll.

Beispielcode ist unten angegeben.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```