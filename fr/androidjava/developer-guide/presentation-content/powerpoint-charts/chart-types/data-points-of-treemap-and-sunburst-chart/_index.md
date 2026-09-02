---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst sur Android
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les étiquettes et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais ils utilisent des dispositions différentes. Une Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les surfaces correspondent aux valeurs des feuilles. Un Sunburst la représente sous forme d'anneaux concentriques : les groupes de niveau supérieur sont proches du centre, et les catégories de feuilles se trouvent sur l'anneau extérieur.

Dans Aspose.Slides for Android via Java, chaque valeur numérique est un [IChartDataPoint](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/). Sa méthode [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) fournit l'accès à la feuille et à ses groupes parents. Cet article explique ce mappage et montre comment créer et mettre en forme les deux types de graphiques à partir des mêmes données d'exemple.

![Un graphique Treemap avec les branches Consumer et Business](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consumer et Business](sunburst-hierarchy.png)

## **Comprendre les catégories, les points de données et les niveaux**

L'exemple utilisé ci‑dessous possède trois niveaux de catégorie et une série numérique :

| Branche | Racine | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Chaque ligne crée une catégorie feuille et un point de données. Les niveaux de regroupement de catégories décrivent le chemin de cette feuille vers ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index renvoyés par [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) partent de la feuille vers le haut :

| index `getDataPointLevels()` | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment d'anneau extérieur |
| `1` | Racine | Rectangle parent ou en‑tête | Segment d'anneau moyen |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment d'anneau interne |

Cet ordre est identique pour les deux types de graphiques même si leurs dispositions visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le mettre en forme, utilisez le niveau correspondant du premier point de données du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que la racine `Software` commence avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d'utiliser des expressions non expliquées comme `dataPoints.get_Item(0)` ou `dataPoints.get_Item(6)`.

## **Créer et personnaliser les deux types de graphiques**

L’exemple complet suivant crée une Treemap sur la première diapositive et un Sunburst sur la deuxième diapositive. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux sélectionnés, met en forme une étiquette de branche et enregistre la présentation.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Ajoutez les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence;
        // les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Afficher la catégorie et la valeur sur la feuille Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Mettre en forme la branche Consumer via la première feuille de cette branche.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Mettre en forme la racine Software via la première feuille de cette racine.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affecte les étiquettes parents du Treemap; Sunburst utilise des segments d'anneau.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions dans la collection restent alignées. Lorsque vous travaillez avec un graphique existant plutôt que d’en créer un, inspectez d’abord les lignes de catégorie et stockez des références nommées aux points de données et aux niveaux que vous souhaitez formater.

## **Comportement et considérations pratiques**

### **Différences entre Treemap et Sunburst**

- Une Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La méthode [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) contrôle la façon dont les étiquettes parents apparaissent dans ce type de graphique.
- Un Sunburst utilise l’angle pour communiquer la valeur et la profondeur de l’anneau pour communiquer la hiérarchie. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) ne contrôle pas les étiquettes de ses anneaux.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégories et le même ordre feuille‑vers‑parent renvoyé par [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), ainsi le code de construction des données et de mise en forme des niveaux peut être partagé.
- Les valeurs des parents sont calculées à partir de leurs feuilles descendantes. N’ajoutez pas de points numériques séparés pour les branches ou les racines.

### **Tri et ordre des segments**

Le moteur de disposition du graphique détermine le placement final des rectangles et des segments d’anneau. Regroupez les lignes de catégorie liées avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ spécifiques. Si la séquence a une signification, incluez‑la dans les étiquettes ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L’exemple utilise des remplissages RVB explicites pour un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez des couleurs de schéma plutôt que des valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des étiquettes après avoir modifié le remplissage d’une branche ou d’une racine.

### **Étiquettes et espace disponible**

PowerPoint peut masquer ou tronquer les étiquettes lorsqu’un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs d’étiquette produit généralement un résultat plus lisible. Une étiquette peut combiner le nom de la catégorie, le nom de la série et la valeur via [IDataLabelFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idatalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

L’enregistrement au format PPTX conserve le graphique modifiable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et les paramètres d’étiquette pris en charge sont rendus avec le graphique. La substitution de polices et les petites différences d’espace de mise en page disponible peuvent modifier le retour à la ligne ou la visibilité des étiquettes, aussi installez les polices requises et vérifiez les cibles d’exportation importantes.

## **FAQ**

**Pourquoi la modification d'un niveau parent affecte-t-elle plusieurs feuilles ?**

Une branche ou une racine est un segment visuel partagé. Son [IChartDataPointLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichartdatapointlevel/) peut être atteint via une feuille descendante, mais le formatage appartient au segment parent partagé plutôt qu’à cette seule feuille.

**Pourquoi une étiquette de données est‑elle manquante ?**

Activez d’abord les champs requis sur l’objet [IDataLabelFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idatalabelformat/) de l’étiquette. Vérifiez ensuite que le segment dispose de suffisamment d’espace. La disposition des étiquettes parents de la Treemap, les dimensions du graphique, la longueur de l’étiquette, la taille de la police et le nombre de champs activés influencent tous la possibilité d’afficher une étiquette.

**Puis‑je définir l'ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l’ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas attribuer des rectangles Treemap exacts ni des angles Sunburst précis. Le moteur de disposition du graphique les calcule à partir de la hiérarchie, des valeurs et de l’espace disponible.

**Pourquoi les couleurs changent‑elles après un changement de thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de schéma lorsque l’adaptation à un nouveau thème est souhaitée.

**Le formatage personnalisé sera‑t‑il conservé lors des exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres d’étiquette pris en charge sont inclus lors du rendu. Pour des résultats cohérents entre les systèmes, rendez les polices requises disponibles et testez la taille d’exportation finale, car l’ajustement des étiquettes dépend de la mise en page.

## **Voir aussi**

- [Créer des graphiques Treemap](/slides/fr/androidjava/create-chart/#create-tree-map-charts)
- [Créer des graphiques Sunburst](/slides/fr/androidjava/create-chart/#create-sunburst-charts)
- [Exporter les graphiques de la présentation](/slides/fr/androidjava/export-chart/)
- [Gérer les thèmes de présentation](/slides/fr/androidjava/presentation-theme/)