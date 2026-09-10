---
title: Plotbereiche von Präsentationsdiagrammen in Python anpassen
linktitle: Plotbereich
type: docs
url: /de/python-java/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereich Breite
- Plotbereich Höhe
- Plotbereich Größe
- Layoutmodus
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für Python über Java anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit dem Plotbereich eines Diagramms in Aspose.Slides arbeitet. Er erklärt, wie man die tatsächliche Position und Größe des Plotbereichs ermittelt, indem man das Diagrammlayout validiert und anschließend die X-, Y-, Breiten- und Höhenwerte ausliest.

Er demonstriert außerdem, wie man den Layout‑Modus des Plotbereichs konfiguriert, wenn das Layout manuell festgelegt wird, wobei LayoutTargetType verwendet wird, um zu bestimmen, ob der Plotbereich anhand seines inneren Bereichs oder seines äußeren Bereichs zusammen mit Achsen und Achsenbeschriftungen berechnet wird.

## **Breite und Höhe des Plotbereichs eines Diagramms ermitteln**

Aspose.Slides für Python über Java bietet eine einfache API zum Auslesen der tatsächlichen Position und Größe des Plotbereichs eines Diagramms.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Rufen Sie die Methode Chart.validateChartLayout auf, bevor Sie die tatsächlichen Werte abrufen.
5. Ermitteln Sie die tatsächliche X‑Position (links) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
6. Ermitteln Sie die tatsächliche Y‑Position (oben) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
7. Ermitteln Sie die tatsächliche Breite des Diagrammelements.
8. Ermitteln Sie die tatsächliche Höhe des Diagrammelements.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Layout‑Modus des Plotbereichs eines Diagramms festlegen**

Aspose.Slides für Python über Java bietet eine einfache API zum Festlegen des Layout‑Modus des Plotbereichs eines Diagramms. Die Methoden setLayoutTargetType und getLayoutTargetType sind in der ChartPlotArea‑Klasse verfügbar. Wenn das Layout des Plotbereichs manuell definiert wird, legt diese Einstellung fest, ob der Plotbereich anhand seines Inneren (ohne Achsen und Achsenbeschriftungen) oder seines Äußeren (mit Achsen und Achsenbeschriftungen) angeordnet wird. In der Aufzählung LayoutTargetType sind zwei mögliche Werte definiert.

- Inner gibt an, dass die Größe des Plotbereichs die Tick‑Markierungen und Achsenbeschriftungen ausschließt.
- Outer gibt an, dass die Größe des Plotbereichs die Tick‑Markierungen und Achsenbeschriftungen einschließt.

Beispielcode ist unten angegeben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In welchen Einheiten werden tatsächliche X, tatsächliche Y, tatsächliche Breite und tatsächliche Höhe zurückgegeben?**  
In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**  
Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen schließt der Plotbereich auch die Wände/Boden und die Achsen ein.

**Wie werden X, Y, Breite und Höhe des Plotbereichs interpretiert, wenn das Layout manuell ist?**  
Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen oder Verschieben der Legende?**  
Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plotbereich verschoben werden kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)