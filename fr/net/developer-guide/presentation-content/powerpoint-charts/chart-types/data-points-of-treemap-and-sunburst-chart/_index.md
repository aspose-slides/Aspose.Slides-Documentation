---
title: Points de données des graphiques Treemap et Sunburst
type: docs
url: /fr/net/data-points-of-treemap-and-sunburst-chart/
keywords: "graphique Sunburst, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter un graphique Sunburst dans une présentation PowerPoint en C# ou .NET"
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » – le graphique **Treemap** et le graphique **Sunburst** (également appelé Graphique Sunburst, Diagramme Sunburst, Graphique radial, Graphe radial ou Diagramme circulaire à plusieurs niveaux). Ces graphiques affichent des données hiérarchiques organisées sous forme d’arbre – des feuilles jusqu’au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau d’agrégation imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides pour .NET permet de formater les points de données des graphiques Sunburst et Treemap en C#.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent les points de données hiérarchiques :

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
- [**Création du graphique Sunburst**](/slides/fr/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Si vous devez formater les points de données du graphique, vous devez utiliser les éléments suivants :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) classes et [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) propriété fournissent l’accès pour formater les points de données des graphiques Treemap et Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) est utilisé pour accéder aux catégories à plusieurs niveaux – il représente le conteneur des objets [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel). En gros, c’est un wrapper pour [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) avec les propriétés ajoutées spécifiques aux points de données. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) possède deux propriétés : [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) et [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) qui fournissent l’accès aux paramètres correspondants.

## **Afficher la valeur du point de données**
Afficher la valeur du point de données "Leaf 4" :
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir le libellé et la couleur du point de données**
Définir le libellé du point de données "Branch 1" pour afficher le nom de la série ("Series1") au lieu du nom de la catégorie. Puis définir la couleur du texte en jaune :
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur de la branche du point de données**
Modifier la couleur de la branche "Stem 4" :
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

Non. PowerPoint trie les segments automatiquement (généralement par valeurs décroissantes, dans le sens des aiguilles d’une montre). Aspose.Slides reproduit ce comportement : vous ne pouvez pas modifier l’ordre directement ; vous devez le faire en prétraitant les données.

**Comment le thème de la présentation influence-t-il les couleurs des segments et des libellés ?**

Les couleurs du graphique héritent du [thème/palette](/slides/fr/net/presentation-theme/) de la présentation sauf si vous définissez explicitement des remplissages/polices. Pour des résultats cohérents, verrouillez les remplissages solides et le formatage du texte aux niveaux requis.

**L'exportation en PDF/PNG préservera-t-elle les couleurs de branche personnalisées et les paramètres de libellé ?**

Oui. Lors de l'exportation de la présentation, les paramètres du graphique (remplissages, libellés) sont conservés dans les formats de sortie car Aspose.Slides rend le graphique avec le formatage appliqué.

**Puis-je calculer les coordonnées réelles d'un libellé/élément pour placer une superposition personnalisée au‑dessus du graphique ?**

Oui. Après validation de la mise en page du graphique, `ActualX`/`ActualY` sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), ce qui facilite le positionnement précis des superpositions.