---
title: Diagramm
type: docs
weight: 60
url: /de/php-java/examples/elements/chart/
keywords:
- Diagramm
- Diagramm hinzufügen
- Diagramm zugreifen
- Diagramm entfernen
- Diagramm aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Diagramme in PHP mit Aspose.Slides erstellen und anpassen: Daten hinzufügen, Serien, Achsen und Beschriftungen formatieren, Typen ändern und exportieren – funktioniert mit PPT, PPTX und ODP."
---
Beispiele für das Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for PHP via Java**. Die nachstehenden Code-Snippets demonstrieren grundlegende Diagrammoperationen.

## **Diagramm hinzufügen**

Diese Methode fügt der ersten Folie ein einfaches Flächendiagramm hinzu.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Fügt der Folie ein einfaches Säulendiagramm hinzu.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf ein Diagramm**

Das Diagramm wird aus der Formensammlung abgerufen.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Greift auf das erste Diagramm auf der Folie zu.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Annahme: Das erste Shape auf der Folie ist das Diagramm.
        $chart = $slide->getShapes()->get_Item(0);

        // Entfernt das Diagramm.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, das erste Shape auf der Folie ist das Diagramm.
        $chart = $slide->getShapes()->get_Item(0);

        // Ändert den Diagrammtitel.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```