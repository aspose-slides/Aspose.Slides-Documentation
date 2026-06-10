---
title: Diagram
type: docs
weight: 60
url: /hu/php-java/examples/elements/chart/
keywords:
- diagram
- diagram hozzáadása
- diagram elérése
- diagram eltávolítása
- diagram frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Diagramokat hozhat létre és testreszabhat PHP-ban az Aspose.Slides segítségével: adatokat adhat hozzá, sorozatokat, tengelyeket és címkéket formázhat, típusokat változtathat, valamint exportálhat — működik PPT, PPTX és ODP formátumokkal."
---
Példák a különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére a **Aspose.Slides for PHP via Java** segítségével. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első diára.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Egyszerű oszlopdiagram hozzáadása a diára.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Diagram elérése**

A diagramot a formagyűjteményből kérdezi le.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az első diagram elérése a dián.
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

## **Diagram eltávolítása**

Az alábbi kód egy diagramot távolít el egy diáról.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat a diagram.
        $chart = $slide->getShapes()->get_Item(0);

        // A diagram eltávolítása.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Diagramadatok frissítése**

Módosíthatja a diagram tulajdonságait, például a címet.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat a diagram.
        $chart = $slide->getShapes()->get_Item(0);

        // A diagram címének módosítása.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```