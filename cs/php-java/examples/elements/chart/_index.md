---
title: Graf
type: docs
weight: 60
url: /cs/php-java/examples/elements/chart/
keywords:
- graf
- přidat graf
- přístup k grafu
- odebrat graf
- aktualizovat graf
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PHP pomocí Aspose.Slides: přidávejte data, formátujte řady, osy a popisky, měňte typy a exportujte – funguje s PPT, PPTX a ODP."
---
Příklady pro přidávání, přístup, odstraňování a aktualizaci různých typů grafů s **Aspose.Slides for PHP via Java**. Níže uvedené úryvky demonstrují základní operace s grafy.

## **Přidání grafu**

Tato metoda přidá jednoduchý plošný graf na první snímek.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidejte jednoduchý sloupcový graf na snímek.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup ke grafu**

Získejte graf ze sbírky tvarů.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu grafu na snímku.
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

## **Odstranit graf**

Následující kód odstraní graf ze snímku.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je graf.
        $chart = $slide->getShapes()->get_Item(0);

        // Odebrat graf.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aktualizovat data grafu**

Můžete změnit vlastnosti grafu, například titulek.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je graf.
        $chart = $slide->getShapes()->get_Item(0);

        // Změňte titulek grafu.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```