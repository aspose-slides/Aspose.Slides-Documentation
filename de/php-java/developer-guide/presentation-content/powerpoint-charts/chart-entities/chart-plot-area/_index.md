---
title: Diagramm-Plotbereich
type: docs
url: /de/php-java/chart-plot-area/
---


## **Breite und Höhe des Diagramm-Plotbereichs erhalten**
Aspose.Slides für PHP über Java bietet eine einfache API dafür.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) auf, um die tatsächlichen Werte zu erhalten.
1. Erhält die tatsächliche X-Position (links) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Oberkante des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Breite des Diagrammelements.
1. Erhält die tatsächliche Höhe des Diagrammelements.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
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

## **Layout-Modus des Diagramm-Plotbereichs festlegen**
Aspose.Slides für PHP über Java bietet eine einfache API, um den Layout-Modus des Diagramm-Plotbereichs festzulegen. Methoden [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) und [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) wurden zur [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) Klasse und zum [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea) Interface hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich innerhalb (ohne Achsen und Achsenbeschriftungen) oder außerhalb (einschließlich Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die in der [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) Enum definiert sind.

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick-Marken und Achsenbeschriftungen.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick-Marken und die Achsenbeschriftungen bestimmt.

Beispielcode ist unten angegeben.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
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