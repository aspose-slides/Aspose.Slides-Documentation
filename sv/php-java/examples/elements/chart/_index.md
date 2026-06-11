---
title: Diagram
type: docs
weight: 60
url: /sv/php-java/examples/elements/chart/
keywords:
- diagram
- lägg till diagram
- komma åt diagram
- ta bort diagram
- uppdatera diagram
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa diagram i PHP med Aspose.Slides: lägg till data, formatera serier, axlar och etiketter, ändra typer och exportera—fungerar med PPT, PPTX och ODP."
---
Exempel på att lägga till, komma åt, ta bort och uppdatera olika diagramtyper med **Aspose.Slides for PHP via Java**. Nedanstående kodsnuttar demonstrerar grundläggande diagramoperationer.

## **Lägg till diagram**

Den här metoden lägger till ett enkelt area-diagram på den första bilden.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till ett enkelt kolumndiagram på bilden.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kom åt diagram**

Hämta diagrammet från formssamlingen.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kom åt det första diagrammet på bilden.
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

## **Ta bort diagram**

Följande kod tar bort ett diagram från en bild.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen på bilden är diagrammet.
        $chart = $slide->getShapes()->get_Item(0);

        // Ta bort diagrammet.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uppdatera diagramdata**

Du kan ändra diagramegenskaper som titel.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen på bilden är diagrammet.
        $chart = $slide->getShapes()->get_Item(0);

        // Ändra diagramtitel.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```