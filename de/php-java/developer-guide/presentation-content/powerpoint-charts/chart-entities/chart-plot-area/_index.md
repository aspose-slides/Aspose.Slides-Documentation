---
title: Diagramm-Plotbereiche von Präsentationsdiagrammen in PHP anpassen
linktitle: Plotbereich
type: docs
url: /de/php-java/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereichsbreite
- Plotbereichshöhe
- Plotbereichsgröße
- Layoutmodus
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe eines Diagramm‑Plotsbereichs abrufen**
Aspose.Slides für PHP über Java bietet eine einfache API für . 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.
4. Rufen Sie die Methode [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) auf, um tatsächliche Werte zu erhalten.
5. Ermittelt die tatsächliche X‑Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
6. Ermittelt den tatsächlichen oberen Rand des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
7. Ermittelt die tatsächliche Breite des Diagrammelements.
8. Ermittelt die tatsächliche Höhe des Diagrammelements.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Layoutmodus eines Diagramm‑Plotsbereichs festlegen**
Aspose.Slides für PHP über Java bietet eine einfache API zum Festlegen des Layoutmodus des Diagramm‑Plotsbereichs. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden der Klasse [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) hinzugefügt. Wenn das Layout des Plotsbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotsbereich anhand seines Inneren (ohne Achsen und Achsenbeschriftungen) oder Außen (mit Achsen und Achsenbeschriftungen) angeordnet wird. Es gibt zwei mögliche Werte, die im Enumerations‑Typ [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) definiert sind.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) – gibt an, dass die Größe des Plot‑Bereichs die Größe des Plot‑Bereichs bestimmt, ohne die Tick‑Markierungen und Achsenbeschriftungen.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) – gibt an, dass die Größe des Plot‑Bereichs die Größe des Plot‑Bereichs, die Tick‑Markierungen und die Achsenbeschriftungen bestimmt.

Beispielcode wird unten angezeigt.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**In welchen Einheiten werden tatsächliches x, tatsächliches y, tatsächliche Breite und tatsächliche Höhe zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Das sind Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plot‑Bereich vom Diagramm‑Bereich hinsichtlich des Inhalts?**

Der Plot‑Bereich ist das Datenzeichnungs‑Region (Serien, Gitternetzlinien, Trendlinien usw.); der Diagramm‑Bereich umfasst die umgebenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen beinhaltet der Plot‑Bereich außerdem die Wände/Boden und die Achsen.

**Wie werden die x‑, y‑, Breiten‑ und Höhenwerte des Plot‑Bereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0–1) der Gesamtgröße des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plot‑Bereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plot‑Bereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass sich der Plot‑Bereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das standardmäßige Verhalten von PowerPoint‑Diagrammen.)