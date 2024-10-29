---
title: Diagramm Plotbereich
type: docs
url: /de/androidjava/chart-plot-area/
---


## **Breite, Höhe des Diagramm Plotbereichs abrufen**
Aspose.Slides für Android über Java bietet eine einfache API für. 

1. Erstelle eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Greife auf die erste Folie zu.
1. Füge ein Diagramm mit standardmäßigen Daten hinzu.
1. Rufe die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) auf, um die tatsächlichen Werte zu erhalten.
1. Erhalte die tatsächliche X-Position (links) des Diagramm-Elements relativ zur oberen linken Ecke des Diagramms.
1. Erhalte den tatsächlichen oberen Rand des Diagramm-Elements relativ zur oberen linken Ecke des Diagramms.
1. Erhalte die tatsächliche Breite des Diagramm-Elements.
1. Erhalte die tatsächliche Höhe des Diagramm-Elements.

```java
// Erstelle eine Instanz der Presentation-Klasse
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

## **Layoutmodus des Diagramm Plotbereichs festlegen**
Aspose.Slides für Android über Java bietet eine einfache API, um den Layoutmodus des Diagramm Plotbereichs festzulegen. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) Klasse und zur [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea) Schnittstelle hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich innerhalt (ohne Achsen und Achsenbeschriftungen) oder außerhalb (einschließlich Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType) Enum definiert sind.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmen soll, ohne die Markierungen und Achsenbeschriftungen.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Markierungen und die Achsenbeschriftungen bestimmen soll.

Beispielcode ist unten angegeben.

```java
// Erstelle eine Instanz der Presentation-Klasse
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