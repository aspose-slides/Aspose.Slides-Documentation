---
title: Points de données du diagramme Treemap et du diagramme Sunburst
type: docs
url: /cpp/data-points-of-treemap-and-sunburst-chart/
keywords: "Graphique Sunburst"
description: "Graphique Sunburst, Diagramme Sunburst, Chart Sunburst, Diagramme Radial, Graphique Radial ou Graphique à Secteurs Multi-niveaux avec Aspose.Slides."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types "hiérarchiques" - **Treemap** et **Sunburst** (également connu sous le nom de Graphique Sunburst, Diagramme Sunburst, Diagramme Radial, Graphique Radial ou Graphique à Secteurs Multi-niveaux). Ces graphiques affichent des données hiérarchiques organisées en tant qu'arbre - des feuilles au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides pour C++ permet de formater les points de données du graphique Sunburst et du Treemap en C++.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent les points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer un graphique Sunburst**](/slides/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

S'il est nécessaire de formater les points de données du graphique, nous devrions utiliser les éléments suivants :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager), 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) classes 
et [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point#ac619638c85f84a6127a7ce62523e0931) méthode 
fournissent un accès au formatage des points de données des Treemap et des graphiques Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) 
est utilisé pour accéder aux catégories multi-niveaux - il représente le conteneur des 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) objets. 
Il s'agit essentiellement d'un wrapper pour 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_category_levels_manager) avec 
les propriétés ajoutées spécifiques aux points de données. 
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level) a 
deux méthodes : [**get_Format()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a00caa6a048ad98a66ab56a5ddb196697) et 
[**get_Label()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level#a5ab377b372199eb561792e9ba18acf25)qui 
fournissent un accès aux paramètres correspondants.
## **Afficher la valeur du point de données**
Afficher la valeur du point de données "Feuille 4" :

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Définir l'étiquette et la couleur du point de données**
Définir l'étiquette de données "Branche 1" pour afficher le nom de la série ("Series1") au lieu du nom de la catégorie. Ensuite, définir la couleur du texte sur jaune :

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Définir la couleur de la branche du point de données**

Changer la couleur de la branche "Tige 4" :

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)