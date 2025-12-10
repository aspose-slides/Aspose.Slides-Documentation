---
title: Anpassen von Plotbereichen von Präsentationsdiagrammen in Java
linktitle: Plotbereich
type: docs
url: /de/java/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereichsbreite
- Plotbereichshöhe
- Plotbereichsgröße
- Layoutmodus
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für Java anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe eines Diagramm-Plotbereichs ermitteln**
Aspose.Slides for Java bietet eine einfache API für .

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Rufen Sie die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) auf, um die tatsächlichen Werte zu erhalten.
5. Ermittelt die tatsächliche X-Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
6. Ermittelt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
7. Ermittelt die tatsächliche Breite des Diagrammelements.
8. Ermittelt die tatsächliche Höhe des Diagrammelements.
```java
// Instanz der Presentation-Klasse erstellen
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


## **Layoutmodus eines Diagramm-Plotbereichs festlegen**
Aspose.Slides for Java bietet eine einfache API zum Festlegen des Layoutmodus des Diagramm-Plotbereichs. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur Klasse [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) und zum Interface [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich anhand seines Innenbereichs (ohne Achsen und Achsenbeschriftungen) oder seines Außenbereichs (einschließlich Achsen und Achsenbeschriftungen) angeordnet wird. Es gibt zwei mögliche Werte, die im Aufzählungstyp [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) definiert sind.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Markierungen und Achsenbeschriftungen.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick‑Markierungen und die Achsenbeschriftungen bestimmt.

Beispielcode ist unten angegeben.
```java
// Instanz der Presentation-Klasse erstellen
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

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich in Bezug auf den Inhalt?**

Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen schließt der Plotbereich außerdem die Wände/Boden und die Achsen ein.

**Wie werden die x‑, y‑, Breiten‑ und Höhenwerte des Plotbereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum hat sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende geändert?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, wirkt sich jedoch auf das Layout und den verfügbaren Platz aus, sodass sich der Plotbereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)