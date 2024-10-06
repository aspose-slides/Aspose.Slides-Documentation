---
title: Points de données du graphique Treemap et Sunburst
type: docs
url: /python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "Graphique Sunburst, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter un graphique Sunburst dans une présentation PowerPoint en Python"
---

Parmi les autres types de graphiques PowerPoint, il existe deux types "hiérarchiques" - **Treemap** et **Sunburst** (également connus sous le nom de Graphique Sunburst, Diagramme Sunburst, Graphique Radial ou Graphique à Secteurs Multi Niveaux). Ces graphiques affichent des données hiérarchiques organisées sous forme d'arbre - des feuilles jusqu'au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides pour Python via .NET permet de formater les points de données des graphiques Sunburst et Treemap en Python.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que d'autres colonnes définissent des points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :

```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer un graphique Sunburst**](/slides/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

S'il est nécessaire de formater les points de données du graphique, nous devrions utiliser ce qui suit :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/), 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) classes 
et [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) propriété 
fournissent un accès pour formater les points de données des graphiques Treemap et Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
est utilisé pour accéder à des catégories multi-niveaux - il représente le conteneur des 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) objets. 
C'est essentiellement un wrapper pour 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) avec 
les propriétés ajoutées spécifiques aux points de données. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) a 
deux propriétés : [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) et 
[**DataLabel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) qui 
fournissent un accès aux paramètres correspondants.
## **Afficher la valeur du point de donnée**
Afficher la valeur du point de donnée "Feuille 4" :

```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Définir l'étiquette et la couleur du point de donnée**
Définir l'étiquette du point de donnée "Branche 1" pour montrer le nom de la série ("Series1") au lieu du nom de la catégorie. Ensuite, définir la couleur du texte sur jaune :

```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Définir la couleur de la branche du point de donnée**

Changer la couleur de la branche "Tige 4" :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)