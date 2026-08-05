---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en PHP
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graphique treemap
- graphique sunburst
- graphique hiérarchique
- point de données
- étiquette de données
- couleur de branche
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les étiquettes et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides for PHP via Java."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hierarchiques, mais ils utilisent des mises en page differentes. Un Treemap dessine la hierarchie sous forme de rectangles imbriques dont les surfaces représentent les valeurs des feuilles. Un Sunburst la dessine sous forme d'anneaux concentriques: les groupes de niveau superieur sont proches du centre, et les categories de feuilles se trouvent sur l'anneau externe.

Dans Aspose.Slides for PHP via Java, chaque valeur numérique est un [ChartDataPoint](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/). Sa méthode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) fournit l'accès à la feuille et à ses groupes parents. Cet article explique ce mapping et montre comment créer et formater les deux types de graphiques à partir des mêmes données d'exemple.

![Graphique Treemap avec les branches Consumer et Business](treemap-hierarchy.png)

![Graphique Sunburst avec la même hierarchie Consumer et Business](sunburst-hierarchy.png)

## **Comprendre les categories, les points de donnees et les niveaux**

Le tableau d'exemple utilise trois niveaux de categories et une serie numerique :

| Branche | Tige | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Chaque ligne crée une categorie feuille et un point de donnée. Les niveaux de groupe de categories describent le chemin de cette feuille vers ses parents. Pour la premiere ligne, le chemin est `Consumer > Computers > Laptops`.

Les index retournes par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) s'executent de la feuille vers le haut :

| `getDataPointLevels()` index | Niveau logique | Representation Treemap | Representation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment d'anneau externe |
| `1` | Tige | Rectangle parent ou entete | Segment d'anneau moyen |
| `2` | Branche | Rectangle ou entete de niveau superieur | Segment d'anneau interne |

Cette ordre est le meme pour les deux types de graphiques meme si leurs mises en page visuelles differents. Un segment parent est partage par plusieurs feuilles. Pour le formater, utilisez le niveau correspondant du premier point de donnees du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que la tige `Software` commence avec le point `Licenses`. Conserver des references vers ces points est plus clair et plus securise que d'utiliser des expressions inexpliques telles que `$dataPoints->get_Item(0)` ou `$dataPoints->get_Item(6)`.

## **Creer et personnaliser les deux types de graphiques**

L'exemple complet suivant cree un Treemap sur la premiere diapositive et un Sunburst sur la deuxieme diapositive. Il construit la hierarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux selects, formate une etiquette de branche, et enregistre la presentation.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Ajouter les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence;
        // les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Afficher la catégorie et la valeur sur la feuille Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formater la branche Consumer via la première feuille de cette branche.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formater la tige Software via la première feuille de cette tige.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout affecte les étiquettes parent du Treemap ; Sunburst utilise des segments d'anneau.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les cellules de categorie et les cellules de valeur utilisent la meme ligne de feuille de calcul, de sorte que leurs positions de collection restent alignees. Lorsque vous travaillez avec un graphique existant au lieu d'en creer un, inspectez d'abord les lignes de categories et stockez des references nommees aux points de donnees et aux niveaux que vous envisagez de formater.

## **Comportement et considerations pratiques**

### **Differences entre Treemap et Sunburst**

- Un Treemap utilise la surface pour communiquer la valeur et les rectangles imbriques pour communiquer la hierarchie. La methode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#setParentLabelLayout) controle l'apparition des etiquettes parent dans ce type de graphique.
- Un Sunburst utilise l'angle pour communiquer la valeur et la profondeur d'anneau pour communiquer la hierarchie. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#setParentLabelLayout) ne controle pas les etiquettes d'anneau.
- Les deux types de graphiques utilisent les memes niveaux de regroupement de categories et le meme ordre feuille-vers-parent retourne par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), de sorte que le code de construction des donnees et de formatage des niveaux peut etre partage.
- Les valeurs parentales sont calculees a partir de leurs feuilles descendantes. N'ajoutez pas de points numeriques distincts pour les branches ou les tiges.

### **Tri et ordre des segments**

Le moteur de mise en page du graphique determine le placement final des rectangles et des segments d'anneau. Regroupez les lignes de categories liees avant de les ajouter, mais ne comptez pas sur une position exacte du rectangle ou un angle de depart precise. Si la sequence porte un sens, incluez-la dans les etiquettes ou utilisez un type de graphique avec un axe de categories explicite.

### **Theme et couleurs fixes**

Les niveaux de graphiques non formates heritent les couleurs du theme de la presentation. L'exemple utilise des remplissages RGB explicites pour un resultat previsible. Si le graphique doit suivre les changements de theme, utilisez des couleurs de schema au lieu de valeurs RGB fixes et evitez de remplacer chaque niveau. Verifiez egalement le contraste des etiquettes apres avoir modifie le remplissage d'une branche ou d'une tige.

### **Etiquettes et espace disponible**

PowerPoint peut cacher ou tronquer les etiquettes lorsqu'un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de categories, ou afficher moins de champs d'etiquette produit habituellement un resultat plus clair. Une etiquette peut combiner le nom de la categorie, le nom de la serie et la valeur via [DataLabelFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datalabelformat/), mais activer chaque champ rend souvent les graphiques hierarchiques difficiles a lire.

### **Exportation et rendu**

Enregistrer au format PPTX conserve le graphique modifiable. Lorsque Aspose.Slides rend la presentation en PDF ou en image, les remplissages supports et les parametres d'etiquette sont rendus avec le graphique. La substitution de police et de petites differences dans l'espace de mise en page disponible peuvent changer le retour a la ligne ou la visibilite des etiquettes, alors installez les polices requises et verifiez les cibles d'exportation importantes.

## **FAQ**

**Pourquoi la modification d'un niveau parent affecte-t-elle plusieurs feuilles ?**

Une branche ou une tige est un segment visuel partage. Son [ChartDataPointLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapointlevel/) peut etre atteint via une feuille descendante, mais le formatage appartient au segment parent partage et non uniquement a cette feuille.

**Pourquoi une etiquette de donnees est-elle manquante ?**

Activez d'abord les champs requis sur l'objet [DataLabelFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datalabelformat/) de l'etiquette. Puis verifiez si le segment dispose de suffisamment d'espace. Le layout de l'etiquette parent du Treemap, les dimensions du graphique, la longueur de l'etiquette, la taille de police et le nombre de champs actifs influencent tous la possibilite d'afficher une etiquette.

**Puis-je definir l'ordre exact ou les coordonnees des segments ?**

Vous pouvez controler l'ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas assigner des rectangles Treemap exacts ou des angles Sunburst precis. Le moteur de mise en page du graphique les calcule a partir de la hierarchie, des valeurs et de l'espace disponible.

**Pourquoi les couleurs changent-elles après le changement de theme de la presentation ?**

Les remplissages basees sur le theme sont concus pour suivre la palette de la presentation. Appliquez des couleurs RGB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de schema lorsque l'adaptation a un nouveau theme est preferee.

**Le formatage personnalise sera-t-il conserve lors des exportations PDF et image ?**

Oui, les remplissages de graphiques supports et les parametres d'etiquette sont inclus lors du rendu. Pour des resultats coherents entre systemes, rendez les polices requises disponibles et testez la taille d'exportation finale car l'ajustement des etiquettes depend de la mise en page.

## **Voir aussi**

- [Creer des graphiques Treemap](/slides/fr/php-java/create-chart/#create-tree-map-charts)
- [Creer des graphiques Sunburst](/slides/fr/php-java/create-chart/#create-sunburst-charts)
- [Exporter les graphiques de la presentation](/slides/fr/php-java/export-chart/)
- [Gerer les themes de presentation](/slides/fr/php-java/presentation-theme/)