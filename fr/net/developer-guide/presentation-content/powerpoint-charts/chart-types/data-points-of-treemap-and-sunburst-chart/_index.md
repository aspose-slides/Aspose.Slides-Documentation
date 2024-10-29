---
title: Points de données du diagramme Treemap et Sunburst
type: docs
url: /fr/net/data-points-of-treemap-and-sunburst-chart/
keywords: "Diagramme Sunburst, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter un diagramme Sunburst dans une présentation PowerPoint en C# ou .NET"
---

Parmi les autres types de graphiques PowerPoint, il existe deux types "hiérarchiques" - **Treemap** et **Sunburst** (également connus sous le nom de Graphique Sunburst, Diagramme Sunburst, Graphique Radial ou Graphique à secteurs multi-niveaux). Ces graphiques affichent des données hiérarchiques organisées sous forme d'arbre - des feuilles au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué subséquent est défini par la catégorie correspondante. Aspose.Slides pour .NET permet de formater les points de données des diagrammes Sunburst et Treemap en C#.

Voici un diagramme Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent les points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau diagramme Sunburst à la présentation :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer un diagramme Sunburst**](/slides/fr/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

S'il est nécessaire de formater les points de données du diagramme, nous devrions utiliser ce qui suit :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) classes 
et [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) propriété 
fournissent l'accès pour formater les points de données des diagrammes Treemap et Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
est utilisé pour accéder aux catégories multi-niveaux - il représente le conteneur des objets 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel). 
Essentiellement, c'est un wrapper pour 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) avec 
les propriétés ajoutées spécifiques aux points de données. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) possède 
deux propriétés : [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) et 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) qui 
fournissent l'accès aux paramètres correspondants.
## **Afficher la valeur du point de données**
Afficher la valeur du point de données "Feuille 4" :

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Définir l'étiquette de point de données et la couleur**
Définir l'étiquette de point de données "Branche 1" pour afficher le nom de la série ("Series1") au lieu du nom de la catégorie. Puis définir la couleur du texte en jaune :

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Définir la couleur de la branche du point de données**
Changer la couleur de la branche "Tige 4" :

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