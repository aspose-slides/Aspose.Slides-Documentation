---
title: Diagramm-Plotbereich
type: docs
url: /de/nodejs-java/chart-plot-area/
---

## **Breite und Höhe des Diagramm-Plotbereichs abrufen**

Aspose.Slides für Node.js über Java bietet eine einfache API für .  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit den Standarddaten hinzu.  
1. Rufen Sie die Methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) auf, um die tatsächlichen Werte zu erhalten.  
1. Ermittelt die tatsächliche X-Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt den tatsächlichen oberen Rand des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt die tatsächliche Breite des Diagrammelements.  
1. Ermittelt die tatsächliche Höhe des Diagrammelements.  
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Layout-Modus des Diagramm-Plotbereichs festlegen**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Festlegen des Layout-Modus des Diagramm-Plotbereichs. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur Klasse [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich nach seinem Inneren (ohne Achsen und Achsenbeschriftungen) oder nach außen (einschließlich Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im Aufzählungstyp [**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType) definiert sind.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick-Markierungen und Achsenbeschriftungen.  
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick-Markierungen und die Achsenbeschriftungen bestimmt.  

Beispielcode ist unten angegeben.  
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**In welchen Einheiten werden tatsächliches X, tatsächliches Y, tatsächliche Breite und tatsächliche Höhe zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**

Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3D-Diagrammen beinhaltet der Plotbereich außerdem die Wände/Boden und die Achsen.

**Wie werden X, Y, Breite und Höhe des Plotbereichs interpretiert, wenn das Layout manuell erfolgt?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plotbereich verschoben werden kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten bei PowerPoint-Diagrammen.)