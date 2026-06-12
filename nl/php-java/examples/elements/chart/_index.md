---
title: Grafiek
type: docs
weight: 60
url: /nl/php-java/examples/elements/chart/
keywords:
- grafiek
- grafiek toevoegen
- grafiek benaderen
- grafiek verwijderen
- grafiek bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak en pas grafieken aan in PHP met Aspose.Slides: voeg gegevens toe, formatteer reeksen, assen en labels, wijzig types, en exporteer — werkt met PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektype met **Aspose.Slides for PHP via Java**. De onderstaande fragmenten tonen basisbewerkingen op grafieken.

## **Add a Chart**

Deze methode voegt een eenvoudige vlakgrafiek toe aan de eerste dia.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een eenvoudige kolomgrafiek toe aan de dia.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Chart**

Haal de grafiek op uit de vormverzameling.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot de eerste grafiek op de dia.
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

## **Remove a Chart**

De volgende code verwijdert een grafiek van een dia.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste shape op de dia de grafiek is.
        $chart = $slide->getShapes()->get_Item(0);

        // Verwijder de grafiek.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update Chart Data**

U kunt grafiek‑eigenschappen wijzigen, zoals de titel.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste shape op de dia de grafiek is.
        $chart = $slide->getShapes()->get_Item(0);

        // Wijzig de titel van de grafiek.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```