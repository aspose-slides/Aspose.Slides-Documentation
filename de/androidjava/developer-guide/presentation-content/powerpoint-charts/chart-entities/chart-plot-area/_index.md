---
title: Anpassen von Plotbereichen von Präsentationsdiagrammen auf Android
linktitle: Plotbereich
type: docs
url: /de/androidjava/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Breite des Plotbereichs
- Hoehe des Plotbereichs
- Groesse des Plotbereichs
- Layoutmodus
- PowerPoint
- Praesentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java anpassen. Verbessern Sie muhelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe des Plotbereichs eines Diagramms abrufen**
Aspose.Slides für Android über Java stellt eine einfache API zur Verfügung.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
1. Greifen Sie auf die erste Folie zu.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
1. Rufen Sie die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) auf, um die tatsächlichen Werte zu erhalten.  
1. Ermittelt die tatsächliche X‑Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
1. Ermittelt die tatsächliche Breite des Diagrammelements.  
1. Ermittelt die tatsächliche Höhe des Diagrammelements.  
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


## **Layoutmodus eines Diagramm‑Plotbereichs festlegen**
Aspose.Slides für Android über Java bietet eine einfache API zum Festlegen des Layoutmodus des Diagramm‑Plotbereichs. Die Methoden **setLayoutTargetType** und **getLayoutTargetType** wurden zur Klasse **ChartPlotArea** und zum Interface **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich nach seinem Inneren (ohne Achsen und Achsenbeschriftungen) oder nach außen (mit Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im Aufzählungstyp **LayoutTargetType** definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen.  
- **LayoutTargetType.Outer** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick‑Marks und die Achsenbeschriftungen bestimmt.  

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


## **FAQ**

**In welchen Einheiten werden tatsächliches x, tatsächliches y, tatsächliche Breite und tatsächliche Höhe zurückgegeben?**  
In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**  
Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3‑D‑Diagrammen beinhaltet der Plotbereich zudem die Wände/Boden und die Achsen.

**Wie werden x, y, Breite und Höhe des Plotbereichs interpretiert, wenn das Layout manuell ist?**  
Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen angegebenen Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende?**  
Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass sich der Plotbereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)