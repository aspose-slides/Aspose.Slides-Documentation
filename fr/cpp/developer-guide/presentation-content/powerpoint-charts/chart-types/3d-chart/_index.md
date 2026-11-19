---
title: Personnaliser les graphiques 3D dans les présentations avec C++
linktitle: Graphique 3D
type: docs
url: /fr/cpp/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créer des graphiques 3D dans des présentations PowerPoint avec Aspose.Slides for C++. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ vous permet de personnaliser la vue d’un graphique 3D via [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et utilise [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) pour ajouter un graphique à colonnes 3D empilées à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’indice de feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries et la colonne `0` contient les libellés des catégories.

Les méthodes [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) et [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) définissent respectivement la rotation du graphique à 40 ° et 270 °. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) fixe sa profondeur à 150 % de sa largeur, tandis que [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique rempli avec ces paramètres de vue 3D.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ajuster les proportions de hauteur d’un graphique 3D**

Utilisez [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cette opération modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seul le pourcentage de hauteur varie.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Les images suivantes, provenant de l’exemple .NET équivalent, ont été exportées avec Microsoft PowerPoint et illustrent les mêmes réglages de hauteur. Un pourcentage plus faible produit une scène plus plate, tandis qu’un pourcentage plus élevé produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations des axes et le placement des libellés pour adapter la scène.

| Hauteur : 50% | Hauteur : 100% | Hauteur : 200% |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec hauteur fixée à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec hauteur fixée à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec hauteur fixée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Hauteur de la scène 3D exprimée en pourcentage de sa largeur. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondeur de la scène 3D exprimée en pourcentage de sa largeur. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de hauteur affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne, en aires, en secteurs et de surface. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Le réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pour d’autres paramètres d’apparence des graphiques, voir [Chart Formatting](/slides/fr/cpp/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs comprises entre **0 et 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les marqueurs plus fins le long de l’axe de profondeur.

Accédez au groupe via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Le paramètre s’applique à chaque série du groupe, pas uniquement à celle utilisée pour y accéder. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) renvoie le paramètre du groupe parent.

Ce paramètre affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne et en aires. L’apparence dépend de la façon dont les séries sont disposées en profondeur, en grappes ou empilées. Pour une comparaison claire des écarts entre séries distinctes, utilisez `ChartType::Column3D` de l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Espacement entre les grappes de barres ou de colonnes adjacentes, en pourcentage de la largeur de la barre ou de la colonne. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données de graphique par défaut, contenant trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seul l’écart en profondeur varie.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

Les images suivantes, provenant de l’exemple .NET équivalent, ont été exportées avec Microsoft PowerPoint et illustrent les mêmes réglages d’écart en profondeur.

| Profondeur de l’écart : 0% | Profondeur de l’écart : 500% |
| --- | --- |
| ![Graphique à colonnes 3D sans aucun écart entre les séries le long de l’axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l’axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme des barres**

Dans un graphique à cylindres groupés, la première série commence avec des barres cylindriques. L’exemple lit [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) et [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) avant et après chaque modification.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| Modification de la première série | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| Créer le graphique | `ClusteredCylinder` | `Cylinder` |
| Appeler [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) avec `ClusteredCone` | `ClusteredCone` | `Cone` |
| Appeler [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) avec `Box` | `ClusteredColumn3D` | `Box` |

Le fait de définir la forme sur `Box` modifie également le type de série en `ClusteredColumn3D`. Si votre code effectue un branchement selon le type de série, appelez `series->get_Type()` après avoir changé la forme. Une valeur mise en cache avant la modification sélectionnerait encore la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, y compris Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés par l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pour une liste précise et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis‑je obtenir une image raster d’un graphique 3D pour un rapport ou le Web ?**

Oui. Vous pouvez exporter un graphique sous forme d’image avec [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou [rendre la diapositive entière](/slides/fr/cpp/convert-powerpoint-to-png/) vers des formats comme PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu raster ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages Web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de graphiques 3D volumineux ?**

Les performances dépendent du volume des données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une résolution et des dimensions adaptées à l’affichage ou à l’impression cible.