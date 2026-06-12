---
title: Grafico
type: docs
weight: 60
url: /it/php-java/examples/elements/chart/
keywords:
- grafico
- aggiungi grafico
- accedi al grafico
- rimuovi grafico
- aggiorna grafico
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea e personalizza grafici in PHP con Aspose.Slides: aggiungi dati, formatta serie, assi ed etichette, cambia tipi e esporta — funziona con PPT, PPTX e ODP."
---
Esempi di aggiunta, accesso, rimozione e aggiornamento di diversi tipi di grafico con **Aspose.Slides for PHP via Java**. I frammenti seguenti dimostrano le operazioni di base sui grafici.

## **Aggiungere un grafico**

Questo metodo aggiunge un semplice grafico a area alla prima diapositiva.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un semplice grafico a colonne alla diapositiva.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedere a un grafico**

Recupera il grafico dalla raccolta di forme.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo grafico nella diapositiva.
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

## **Rimuovere un grafico**

Il codice seguente rimuove un grafico da una diapositiva.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma nella diapositiva sia il grafico.
        $chart = $slide->getShapes()->get_Item(0);

        // Rimuovi il grafico.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aggiornare i dati del grafico**

È possibile modificare le proprietà del grafico, come il titolo.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumendo che la prima forma nella diapositiva sia il grafico.
        $chart = $slide->getShapes()->get_Item(0);

        // Cambia il titolo del grafico.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```