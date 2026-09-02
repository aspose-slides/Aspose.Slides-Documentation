---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst avec JavaScript
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/nodejs-java/data-points-of-treemap-and-sunburst-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment créer des données hiérarchiques et personnaliser les niveaux, les étiquettes et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides for Node.js via Java."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais ils utilisent des mises en page différentes. Un Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les surfaces correspondent aux valeurs des feuilles. Un Sunburst la représente sous forme d'anneaux concentriques : les groupes de niveau supérieur sont proches du centre, et les catégories feuilles se trouvent sur l'anneau externe.

Dans Aspose.Slides for Node.js via Java, chaque valeur numérique est un [ChartDataPoint](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatapoint/). Sa méthode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) donne accès à la feuille et à ses groupes parents. Cet article explique cette correspondance et montre comment créer et formater les deux types de graphiques à partir des mêmes données d'exemple.

![Un graphique Treemap avec les branches Consommateur et Entreprise](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consommateur et Entreprise](sunburst-hierarchy.png)

## **Comprendre les catégories, les points de données et les niveaux**

L'exemple utilisé ci-dessous comporte trois niveaux de catégorie et une série numérique :

| Branche | Tige | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consommateur | Ordinateurs | Portables | 12 |
| Consommateur | Ordinateurs | Bureaux | 8 |
| Consommateur | Mobile | Téléphones | 15 |
| Consommateur | Mobile | Tablettes | 6 |
| Entreprise | Services | Conseil | 10 |
| Entreprise | Services | Assistance | 7 |
| Entreprise | Logiciel | Licences | 11 |
| Entreprise | Logiciel | Abonnements | 14 |

Chaque ligne crée une catégorie feuille et un point de données. Les niveaux de regroupement de catégorie décrivent le chemin de cette feuille vers ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index renvoyés par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) s'exécutent de la feuille vers le haut :

| `getDataPointLevels()` index | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment anneau extérieur |
| `1` | Tige | Rectangle ou en‑tête parent | Segment anneau moyen |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment anneau intérieur |

Cet ordre est le même pour les deux types de graphiques même si leurs mises en page visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le formater, utilisez le niveau correspondant du premier point de données du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que la tige `Software` commence avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d'utiliser des expressions inexpliquées telles que `dataPoints.get_Item(0)` ou `dataPoints.get_Item(6)`.

## **Créer et personnaliser les deux types de graphiques**

L'exemple complet suivant crée un Treemap sur la première diapositive et un Sunburst sur la deuxième diapositive. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux sélectionnés, formate une étiquette de branche et enregistre la présentation.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Ajoutez les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence;
        // les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Afficher la catégorie et la valeur sur la feuille Tablettes.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formater la branche Consumer via la première feuille de cette branche.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formater la tige Software via la première feuille de cette tige.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affecte les étiquettes parent du Treemap ; Sunburst utilise des segments d'anneau.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions dans la collection restent alignées. Lorsque vous travaillez avec un graphique existant plutôt qu'en créant un nouveau, inspectez d'abord les lignes de catégorie et stockez des références nommées aux points de données et aux niveaux que vous prévoyez de formater.

## **Comportement et considérations pratiques**

### **Différences entre Treemap et Sunburst**

- Un Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La méthode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) contrôle l'apparence des étiquettes parents dans ce type de graphique.
- Un Sunburst utilise l’angle pour communiquer la valeur et la profondeur de l’anneau pour communiquer la hiérarchie. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) ne contrôle pas les étiquettes de ses anneaux.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégorie et le même ordre feuille‑vers‑parent renvoyé par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), de sorte que le code de création de données et de formatage des niveaux peut être partagé.
- Les valeurs des parents sont calculées à partir de leurs feuilles descendantes. N’ajoutez pas de points numériques séparés pour les branches ou les tiges.

### **Tri et ordre des segments**

Le moteur de mise en page du graphique détermine le placement final des rectangles et des segments d’anneau. Regroupez les lignes de catégorie apparentées avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ spécifiques. Si la séquence a une signification, incluez‑la dans les étiquettes ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L’exemple utilise des remplissages RVB explicites pour un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez des couleurs de schéma au lieu de valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des étiquettes après avoir modifié le remplissage d’une branche ou d’une tige.

### **Étiquettes et espace disponible**

PowerPoint peut masquer ou tronquer les étiquettes lorsqu’un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs d’étiquette produit généralement un résultat plus clair. Une étiquette peut combiner le nom de catégorie, le nom de série et la valeur via [DataLabelFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

Enregistrement au format PPTX conserve le graphique éditable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et paramètres d’étiquette pris en charge sont rendus avec le graphique. La substitution de police et de petites différences dans l’espace de mise en page disponible peuvent modifier le retour à la ligne ou la visibilité des étiquettes, alors installez les polices requises et vérifiez les cibles d’exportation importantes.

## **FAQ**

**Pourquoi la modification d’un niveau parent affecte‑t‑elle plusieurs feuilles ?**

Une branche ou une tige est un segment visuel partagé. Son [ChartDataPointLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatapointlevel/) peut être atteint via une feuille descendante, mais le formatage appartient au segment parent partagé plutôt qu’à cette seule feuille.

**Pourquoi une étiquette de données est‑elle manquante ?**

Activez d’abord les champs requis sur l’objet [DataLabelFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/datalabelformat/) de l’étiquette. Ensuite, vérifiez que le segment dispose de suffisamment d’espace. La mise en page du parent‑label Treemap, les dimensions du graphique, la longueur de l’étiquette, la taille de la police et le nombre de champs activés influent tous sur la possibilité d’afficher une étiquette.

**Puis‑je définir l’ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l’ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas attribuer des rectangles Treemap ou des angles Sunburst exacts. Le moteur de mise en page calcule ces éléments à partir de la hiérarchie, des valeurs et de l’espace disponible.

**Pourquoi les couleurs changent‑elles après la modification du thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de schéma lorsque l’adaptation à un nouveau thème est préférable.

**Le formatage personnalisé sera‑t‑il conservé dans les exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres d’étiquette pris en charge sont inclus lors du rendu. Pour des résultats cohérents entre les systèmes, assurez‑vous que les polices requises sont disponibles et testez la taille d’exportation finale, car l’ajustement des étiquettes dépend de la mise en page.

## **Voir aussi**

- [Créer des graphiques Treemap](/slides/fr/nodejs-java/create-chart/#creating-tree-map-charts)
- [Créer des graphiques Sunburst](/slides/fr/nodejs-java/create-chart/#creating-sunburst-charts)
- [Exporter les graphiques de présentation](/slides/fr/nodejs-java/export-chart/)
- [Gérer les thèmes de présentation](/slides/fr/nodejs-java/presentation-theme/)