---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en utilisant С++
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique treemap
- graphique sunburst
- point de données
- couleur d'étiquette
- couleur de branche
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Apprenez à gérer les points de données dans les graphiques treemap et sunburst avec Aspose.Slides pour С++, compatible avec les formats PowerPoint."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » – **Treemap** et **Sunburst** (également appelés Graphique Sunburst, Diagramme Sunburst, Graphique radial, Graphique radial ou Diagramme circulaire à niveaux multiples). Ces graphiques affichent des données hiérarchiques organisées sous forme d'arbre – des feuilles jusqu’au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides for C++ permet de formater les points de données du graphique Sunburst et du Treemap en C++.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuilles, tandis que les autres colonnes définissent des points de données hiérarchiques :
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```


{{% alert color="primary" title="Voir aussi" %}} 
- [**Créer un graphique Sunburst**](/slides/fr/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

S’il y a besoin de formater les points de données du graphique, nous devons utiliser ce qui suit :
les classes [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) et la méthode [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) fournissent un accès au formatage des points de données des graphiques Treemap et Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) est utilisé pour accéder aux catégories à plusieurs niveaux – il représente le conteneur des objets [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/).  
En fait c’est un wrapper pour [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) avec des propriétés ajoutées spécifiques aux points de données.  
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) possède deux méthodes : [**get_Format()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) et [**get_Label()**](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/), qui donnent accès aux paramètres correspondants.

## **Afficher la valeur d’un point de données**
Afficher la valeur du point de données "Leaf 4" :
``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir une étiquette de point de données et une couleur**
Définir l’étiquette de données "Branch 1" pour afficher le nom de la série ("Series1") au lieu du nom de la catégorie. Ensuite, définir la couleur du texte en jaune :
``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur de branche du point de données**
Changer la couleur de la branche "Stem 4" :
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

## **FAQ**

**Puis-je modifier l’ordre (tri) des segments dans Sunburst/Treemap ?**

Non. PowerPoint trie les segments automatiquement (généralement par valeurs décroissantes, dans le sens des aiguilles d’une montre). Aspose.Slides reproduit ce comportement : vous ne pouvez pas modifier directement l’ordre ; vous devez le faire en prétraitant les données.

**Comment le thème de la présentation affecte-t-il les couleurs des segments et des étiquettes ?**

Les couleurs du graphique héritent du [thème/palette](/slides/fr/cpp/presentation-theme/) de la présentation sauf si vous définissez explicitement les remplissages ou les polices. Pour obtenir des résultats cohérents, fixez des remplissages unis et un formatage du texte aux niveaux requis.

**L’exportation en PDF/PNG conservera-t-elle les couleurs de branche personnalisées et les paramètres d’étiquette ?**

Oui. Lors de l’exportation de la présentation, les paramètres du graphique (remplissages, étiquettes) sont conservés dans les formats de sortie car Aspose.Slides rend le graphique avec le formatage appliqué.

**Puis-je calculer les coordonnées réelles d’une étiquette/élément pour placer une superposition personnalisée au-dessus du graphique ?**

Oui. Après validation de la disposition du graphique, les coordonnées X réelles et Y réelles sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datalabel/)), ce qui aide à positionner précisément les superpositions.