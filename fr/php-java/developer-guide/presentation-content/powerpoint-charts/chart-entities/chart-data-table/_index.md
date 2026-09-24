---
title: Personnaliser les tableaux de données de graphiques dans les présentations avec PHP
linktitle: Table de données
type: docs
url: /fr/php-java/chart-data-table/
keywords:
- données de graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les repères de légende du tableau de données d'un graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java permet d'afficher le tableau des données d'un graphique et de personnaliser le formatage du texte, les bordures et les repères de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure, et afficher ou masquer les repères de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau des données d'un graphique, passez `true` à [setDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setdatatable/). Utilisez [getChartDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/getchartdatatable/) pour accéder au tableau et configurer son formatage de texte.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau des données du graphique.
1. Activez le texte en gras avec [setFontBold](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setFontBold) et passez `20` à [setFontHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseportionformat/#setFontHeight) pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

Exemple suivant nécessite `test.pptx` dans le répertoire de travail contenant au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le fichier `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [Chart::setDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setdatatable/) et accédez‑y via [Chart::getChartDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/getchartdatatable/). Vous pouvez contrôler trois types de bordures indépendamment :

- [setBorderHorizontal](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setborderhorizontal/) contrôle les bordures horizontales des cellules.
- [setBorderVertical](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setbordervertical/) contrôle les bordures verticales des cellules.
- [setBorderOutline](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setborderoutline/) contrôle la bordure extérieure du tableau.

Passez `true` à chaque méthode pour afficher ses bordures ou `false` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d'entrée n'est requis. La position et la taille du graphique sont spécifiées en points.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparaison ci‑dessous utilise les mêmes données de graphique et le même paramètre de repère de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante restante désactive un seul paramètre de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l'exemple.

![Tableaux de données de graphique avec toutes les bordures activées, aucune bordure horizontale, aucune bordure verticale et aucune bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les repères de légende**

Les repères de légende sont de petits marqueurs colorés à côté des noms des séries dans le tableau de données. Ils aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Passez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setshowlegendkey/) pour afficher ces marqueurs ou `false` pour les masquer.

La légende distincte du graphique est contrôlée par [Chart::setLegend](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setlegend/). Ces paramètres sont indépendants : masquer la légende distincte ne masque pas les repères dans le tableau de données, et masquer les repères du tableau ne masque pas la légende distincte.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les repères de légende à l'intérieur tout en masquant la légende distincte. Toutes les bordures du tableau sont explicitement activées. Aucun fichier de présentation d'entrée n'est requis. Pour masquer uniquement les repères du tableau, passez `false` à [setShowLegendKey](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La comparaison ci‑dessous montre le même tableau avec les repères de légende affichés à gauche et masqués à droite. Toutes les bordures restent activées, et la légende distincte du graphique est masquée dans les deux cas.

![Tableaux de données de graphique avec les repères de légende affichés à gauche et masqués à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les repères de légende dans le tableau de données d'un graphique ?**

Oui. Passez `true` à [setShowLegendKey](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datatable/setshowlegendkey/) pour afficher les repères de légende ou `false` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), ou [images](/slides/fr/php-java/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans les graphiques chargés depuis un modèle ?**

Oui. Pour un graphique chargé depuis une présentation ou un modèle existant, utilisez [hasDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/hasdatatable/) et [setDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setdatatable/) pour vérifier ou modifier si son tableau de données est affiché.

**Comment puis‑je trouver les graphiques dont le tableau de données est activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques et appelez leur méthode [hasDataTable](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/hasdatatable/). Une valeur `true` indique que le tableau de données est activé.