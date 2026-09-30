---
title: Personnaliser les légendes de graphiques dans les présentations avec PHP
linktitle: Légende de graphique
type: docs
url: /fr/php-java/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides for PHP via Java afin d'optimiser les présentations PowerPoint avec un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java offre des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l'ensemble de la légende, formater une entrée de légende individuelle, et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, notamment la réservation d'espace pour la légende, l'affichage d'étiquettes multilignes et l'héritage du formatage du thème de la présentation.

## **Positionnement de la légende**

Utilisez les méthodes [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), et [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) de la légende pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. En divisant les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique, on les convertit en valeurs relatives : la légende est décalée de 50 points du coin supérieur gauche du graphique et dimensionnée à 100 par 100 points. L'exemple utilise java_values pour convertir les dimensions du graphique renvoyées par le pont PHP/Java en nombres PHP avant la division.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Exprimez la position et la taille de la légende par rapport au graphique.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la taille de police d’une légende**

Utilisez la méthode [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) de la légende pour accéder à son formatage de texte et utilisez [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) pour définir la taille de police en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l'axe vertical et fixe son intervalle de -5 à 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la taille de police d’une entrée de légende individuelle**

Utilisez la collection renvoyée par la méthode [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) de la légende pour accéder au formatage d'une entrée spécifique. Les indices des entrées sont basés sur zéro, ainsi l'indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il formate la deuxième entrée de légende avec du texte gras, italique et bleu de 20 points.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Masquer les entrées de légende individuelles**

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, appelez [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) avec `true` via [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Cela masque uniquement l'entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. En revanche, appeler [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) avec `false` masque la légende entière.

L'exemple ci‑dessous crée un graphique à colonnes groupées avec plusieurs séries en utilisant des données par défaut. Il masque l'entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l'entrée en appelant [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) avec `false` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Restaurer la même entrée sans modifier les données du graphique.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparaison ci‑dessous montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparaison d'un graphique avec toutes les entrées de légende visibles et avec la série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les graphiques à colonnes, à barres et en courbes, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient les points de données individuels (tranches), il faut donc utiliser [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) sur la tranche sélectionnée. L'API documente cette méthode de point de données pour les types de graphiques `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu'elle s'applique aux graphiques en anneau, qui ne sont pas inclus dans cette liste.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Oui. Appelez [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) avec `false` pour réserver de l'espace à la légende au lieu de lui permettre de recouvrir la zone du graphique.

**Can I make multiline legend labels?**

Oui. Les étiquettes longues peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également utiliser des caractères de nouvelle ligne dans les noms de séries pour demander des retours à la ligne.

**How do I make the legend follow the presentation theme's color scheme?**

Laissez les couleurs, remplissages et polices de la légende non définis afin qu'elle puisse hériter du formatage du thème. Un formatage explicite écrase les paramètres du thème correspondants.