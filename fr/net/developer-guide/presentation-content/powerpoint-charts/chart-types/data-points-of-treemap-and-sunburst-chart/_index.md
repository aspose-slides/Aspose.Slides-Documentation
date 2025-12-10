---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst sous .NET
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique treemap
- graphique sunburst
- point de données
- couleur d'étiquette
- couleur de branche
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les points de données dans les graphiques treemap et sunburst avec Aspose.Slides pour .NET, compatible avec les formats PowerPoint."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » – **Treemap** et **Sunburst** (chart également connu sous les noms de Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ou Multi Level Pie Chart). Ces graphiques affichent des données hiérarchiques organisées sous forme d'arbre – des feuilles jusqu'au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides for .NET permet de formater les points de données du graphique Sunburst et du Treemap en C#.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuille, tandis que les autres colonnes définissent des points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="Voir aussi" %}} 
- [**Création d'un graphique Sunburst**](/slides/fr/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

S'il est nécessaire de formater les points de données du graphique, nous devons utiliser les éléments suivants :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) classes et [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property offrent un accès pour formater les points de données des graphiques Treemap et Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) est utilisé pour accéder aux catégories à plusieurs niveaux – il représente le conteneur de [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) avec des propriétés ajoutées spécifiques aux points de données. La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) possède deux propriétés : [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) et [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) qui offrent un accès aux paramètres correspondants.

## **Afficher la valeur d'un point de données**
Afficher la valeur du point de données « Leaf 4 » :
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir l'étiquette et la couleur d'un point de données**
Définir l'étiquette du point de données « Branch 1 » pour afficher le nom de la série (« Series1 ») au lieu du nom de la catégorie. Puis définir la couleur du texte en jaune :
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur de branche d'un point de données**
Modifier la couleur de la branche « Stem 4 » :
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Puis-je changer l'ordre (tri) des segments dans Sunburst/Treemap ?**

Non. PowerPoint trie les segments automatiquement (généralement par valeurs décroissantes, dans le sens des aiguilles d’une montre). Aspose.Slides reflète ce comportement : vous ne pouvez pas modifier l’ordre directement ; vous devez le faire en prétraitant les données.

**Comment le thème de la présentation affecte-t-il les couleurs des segments et des étiquettes ?**

Les couleurs du graphique héritent du [thème/palette](/slides/fr/net/presentation-theme/) de la présentation, sauf si vous définissez explicitement les remplissages ou les polices. Pour des résultats cohérents, fixez des remplissages unis et le formatage du texte aux niveaux requis.

**L'exportation en PDF/PNG conservera-t-elle les couleurs de branche personnalisées et les paramètres d’étiquette ?**

Oui. Lors de l’exportation de la présentation, les paramètres du graphique (remplissages, étiquettes) sont conservés dans les formats de sortie car Aspose.Slides rend le graphique avec le format appliqué.

**Puis-je calculer les coordonnées réelles d’une étiquette/élément pour placer une superposition personnalisée au-dessus du graphique ?**

Oui. Après la validation de la disposition du graphique, `ActualX`/`ActualY` sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), ce qui facilite le positionnement précis des superpositions.