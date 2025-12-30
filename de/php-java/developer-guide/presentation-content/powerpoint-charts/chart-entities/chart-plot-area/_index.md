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
description: "Erfahren Sie, wie Sie Diagramm-Plotbereiche in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java anpassen. Verbessern Sie mühelos die Darstellung Ihrer Folien."
---

## **Breite und Höhe eines Diagramm-Plotbereichs abrufen**
Aspose.Slides für PHP via Java bietet eine einfache API für . 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) auf, bevor Sie die tatsächlichen Werte erhalten.
1. Ermittelt die tatsächliche X-Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt den tatsächlichen oberen Rand des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt die tatsächliche Breite des Diagrammelements.
1. Ermittelt die tatsächliche Höhe des Diagrammelements.
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


## **Layoutmodus eines Diagramm-Plotbereichs festlegen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Festlegen des Layoutmodus des Diagramm-Plotbereichs. Die Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur Klasse [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) und zum Interface [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea) hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich nach innen (ohne Achsen und Achsenbeschriftungen) oder nach außen (mit Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im Aufzählungstyp [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) definiert sind.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, der Tick‑Marks und der Achsenbeschriftungen bestimmt.

Beispielcode ist unten angegeben.
```php
  # Instanz der Presentation-Klasse erstellen
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

In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**

Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umliegenden Elemente (Titel, Legende usw.). In 3D‑Diagrammen enthält der Plotbereich zudem die Wände/Boden und die Achsen.

**Wie werden die x-, y‑, Breiten‑ und Höhenwerte des Plotbereichs interpretiert, wenn das Layout manuell ist?**

Sie sind Bruchteile (0‑1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plotbereich verschoben werden kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)