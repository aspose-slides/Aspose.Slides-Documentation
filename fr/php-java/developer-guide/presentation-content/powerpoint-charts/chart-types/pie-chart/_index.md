---
title: Personnaliser les graphiques circulaires dans les présentations avec PHP
linktitle: Graphique circulaire
type: docs
url: /fr/php-java/pie-chart/
keywords:
- diagramme circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de tranche
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires en PHP avec Aspose.Slides. Configurer les tracés secondaires, afficher les étiquettes de données et appliquer des couleurs automatiques aux tranches dans PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec des graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples se concentrent sur les tâches de personnalisation de graphiques telles que l’ajout d’un graphique à une diapositive, le réglage des séries et des paramètres d’étiquettes, le remplacement des données du graphique par défaut par des catégories et des valeurs personnalisées, et l’enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for PHP via Java prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la façon dont les points de données sont répartis entre les deux tracés.

L’exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données comme étiquettes. La méthode [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) définit la taille du tracé secondaire à 149 % du tracé principal. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) sélectionne le fractionnement basé sur le pourcentage, et [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) fixe le seuil à 53 %.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Afficher les valeurs et configurer le tracé secondaire.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Sélectionner des catégories pour le tracé secondaire**

Utilisez le fractionnement personnalisé lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, indépendamment de leurs valeurs de pourcentage. Par exemple, un rapport de ventes pourrait afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35 % et 10 % des ventes totales.

Appelez [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) avec [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) et sélectionnez les points via [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). La méthode [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) de la collection accepte un indice basé sur zéro dans la série ; utilisez [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) pour ajouter un objet point de données. Dans cet exemple, l’indice 1 sélectionne Online, et le point à l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Remplacer les données par défaut par les ventes par canal.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Sélectionner Online par son index zéro et Events par son objet point de données.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Exclure Partners de la sélection sans supprimer ses données source.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) et Events (10) apparaissent comme des tranches séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une tranche combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). La suppression de Partners de la sélection personnalisée le maintient dans le tracé principal ; cela ne supprime pas la catégorie ni sa valeur des données source du graphique.

L’image suivante montre la présentation enregistrée dans PowerPoint :

![Diagramme Pie of Pie avec Online et Events dans le tracé secondaire et leur valeur combinée de 45 dans le tracé principal](pie_of_pie_custom.png)

## **Définir des couleurs de tranches automatiques pour les graphiques circulaires**

Aspose.Slides for PHP via Java peut attribuer automatiquement des couleurs différentes aux tranches d’un graphique circulaire. L’exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La méthode [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) affiche les valeurs 20, 50 et 30 comme étiquettes, tandis que [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) active une couleur distincte pour chaque tranche.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Ajouter un titre de graphique centré.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Remplacer les données par défaut en utilisant la première feuille de calcul.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Afficher les valeurs et attribuer des couleurs différentes aux tranches.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis‑je exporter uniquement le graphique sous forme d'image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même sous forme d'image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (tel que PNG) sans exporter l’ensemble de la présentation.