---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en .NET
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique Treemap
- graphique Sunburst
- graphique hiérarchique
- point de données
- libellé de données
- couleur de branche
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les libellés et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais utilisent des dispositions différentes. Une Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les surfaces correspondent aux valeurs des feuilles. Un Sunburst la représente sous forme d'anneaux concentriques : les groupes de niveau supérieur sont proches du centre, et les catégories de feuille se trouvent sur l'anneau extérieur.

Dans Aspose.Slides for .NET, chaque valeur numérique est un [IChartDataPoint](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/). Sa collection [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) donne accès à la feuille et à ses groupes parents. Cet article explique ce mappage et montre comment créer et mettre en forme les deux types de graphiques à partir des mêmes données d’exemple.

![Un graphique Treemap avec les branches Consommateur et Entreprise](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consommateur et Entreprise](sunburst-hierarchy.png)

## **Comprendre les catégories, points de données et niveaux**

L’exemple ci‑dessous comporte trois niveaux de catégorie et une série numérique :

| Branche | Tronc | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consommateur | Ordinateurs | Portables | 12 |
| Consommateur | Ordinateurs | Ordinateurs de bureau | 8 |
| Consommateur | Mobile | Téléphones | 15 |
| Consommateur | Mobile | Tablettes | 6 |
| Entreprise | Services | Conseil | 10 |
| Entreprise | Services | Support | 7 |
| Entreprise | Logiciels | Licences | 11 |
| Entreprise | Logiciels | Abonnements | 14 |

Chaque ligne crée une catégorie feuille et un point de données. Les niveaux de regroupement de catégories décrivent le chemin de cette feuille vers ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index de [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) vont de la feuille vers le haut :

| Index `DataPointLevels` | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment d’anneau extérieur |
| `1` | Tronc | Rectangle parent ou en‑tête | Segment d’anneau moyen |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment d’anneau intérieur |

Cet ordre est identique pour les deux types de graphiques même si leurs mises en forme visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le mettre en forme, utilisez le niveau correspondant du premier point de données du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que le tronc `Software` commence avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d’utiliser des expressions inexpliquées telles que `dataPoints[0]` ou `dataPoints[6]`.

## **Créer et personnaliser les deux types de graphiques**

L’exemple complet suivant crée une Treemap sur la première diapositive et un Sunburst sur la deuxième. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes à certains niveaux, met en forme une étiquette de branche, puis enregistre la présentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Ajouter les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence;
    // les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Afficher la catégorie et la valeur sur la feuille Tablettes.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formater la branche Consumer via la première feuille de cette branche.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formater le tronc Software via la première feuille de ce tronc.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout affecte les libellés parents du Treemap ; Sunburst utilise des segments d'anneau.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions dans les collections restent alignées. Lorsque vous travaillez avec un graphique existant plutôt qu’en créant un nouveau, inspectez d’abord les lignes de catégorie et stockez des références nommées aux points de données et aux niveaux que vous prévoyez de formater.

## **Comportement et considérations pratiques**

### **Différences Treemap et Sunburst**

- Une Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La propriété [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/parentlabellayout/) contrôle l’apparence des libellés parents dans ce type de graphique.
- Un Sunburst utilise l’angle pour communiquer la valeur et la profondeur de l’anneau pour communiquer la hiérarchie. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartseries/parentlabellayout/) ne contrôle pas les libellés des anneaux.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégories et le même ordre feuille‑vers‑parent dans `DataPointLevels`, ce qui permet de partager le code de construction des données et de mise en forme des niveaux.
- Les valeurs parents sont calculées à partir de leurs feuilles descendantes. N’ajoutez pas de points numériques séparés pour les branches ou les troncs.

### **Tri et ordre des segments**

Le moteur de disposition du graphique détermine le placement final des rectangles et des segments d’anneau. Regroupez les lignes de catégorie apparentées avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ précis. Si la séquence a une signification, incluez‑la dans les libellés ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L’exemple utilise des remplissages RVB explicites pour un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez des couleurs de palette au lieu de valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des libellés après avoir modifié le remplissage d’une branche ou d’un tronc.

### **Libellés et espace disponible**

PowerPoint peut masquer ou tronquer les libellés lorsqu’un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs de libellé produit généralement un résultat plus lisible. Un libellé peut combiner le nom de catégorie, le nom de série et la valeur via [IDataLabelFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

Enregistrer au format PPTX garde le graphique éditable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et les paramètres de libellé pris en charge sont rendus avec le graphique. La substitution de polices et de petites différences dans l’espace de mise en page disponible peuvent modifier le retour à la ligne ou la visibilité des libellés, aussi installez les polices requises et vérifiez les cibles d’exportation importantes.

## **FAQ**

**Pourquoi la modification d’un niveau parent affecte‑t‑elle plusieurs feuilles ?**

Une branche ou un tronc est un segment visuel partagé. Son [IChartDataPointLevel](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatapointlevel/) est accessible via une feuille descendante, mais la mise en forme appartient au segment parent partagé et non uniquement à cette feuille.

**Pourquoi un libellé de données est‑il absent ?**

Activez d’abord les champs requis sur l’objet [IDataLabelFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/idatalabelformat/) du libellé. Ensuite, vérifiez que le segment dispose de suffisamment d’espace. La mise en page des libellés parents dans une Treemap, les dimensions du graphique, la longueur du libellé, la taille de police et le nombre de champs activés influencent tous la possibilité d’afficher un libellé.

**Puis‑je définir l’ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l’ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas assigner des rectangles Treemap ou des angles Sunburst précis. Le moteur de disposition calcule ces éléments à partir de la hiérarchie, des valeurs et de l’espace disponible.

**Pourquoi les couleurs changent‑elles après une modification du thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de palette lorsque l’adaptation à un nouveau thème est préférable.

**Le formatage personnalisé est‑il conservé dans les exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres de libellé pris en charge sont inclus lors du rendu. Pour des résultats cohérents entre systèmes, rendez les polices requises disponibles et testez la taille finale de l’exportation, car l’ajustement des libellés dépend de la mise en page.

## **Voir aussi**

- [Create Treemap charts](/slides/fr/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/fr/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/fr/net/export-chart/)
- [Manage presentation themes](/slides/fr/net/presentation-theme/)