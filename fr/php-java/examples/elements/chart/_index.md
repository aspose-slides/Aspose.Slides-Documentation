---
title: Graphique
type: docs
weight: 60
url: /fr/php-java/examples/elements/chart/
keywords:
- graphique
- ajouter un graphique
- accéder au graphique
- supprimer le graphique
- mettre à jour le graphique
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des graphiques en PHP avec Aspose.Slides : ajouter des données, formater les séries, les axes et les libellés, changer de type et exporter—fonctionne avec PPT, PPTX et ODP."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for PHP via Java**. Les extraits ci‑dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter un graphique en colonnes simple à la diapositive.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un graphique**

Récupérez le graphique depuis la collection de formes.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier graphique sur la diapositive.
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

## **Supprimer un graphique**

Le code suivant supprime un graphique d'une diapositive.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposons que la première forme sur la diapositive soit le graphique.
        $chart = $slide->getShapes()->get_Item(0);

        // Supprimer le graphique.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique, comme le titre.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposons que la première forme sur la diapositive soit le graphique.
        $chart = $slide->getShapes()->get_Item(0);

        // Modifier le titre du graphique.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```