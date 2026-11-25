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
description: "Créer des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides pour C++. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples C++."
---
## **Aperçu**

Aspose.Slides for C++ vous permet de personnaliser la vue d’un graphique 3D via [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et utilise [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) pour ajouter un graphique à colonnes 3D empilées à la première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’index de feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries et la colonne `0` les libellés des catégories.

Les méthodes [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) et [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) définissent la rotation du graphique à 40 et 270 degrés respectivement. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) fixe sa profondeur à 150 % de sa largeur, tandis que [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) active les axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique rempli avec ces paramètres de vue 3D.

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

## **Appliquer un remplissage d’image à la surface d’un graphique 3D**

Vous pouvez remplir indépendamment le [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), le [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) et le [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) d’un graphique 3D. Définissez le [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) de la surface sur `Picture` et affectez une image. Pour ajuster une copie de l’image sur toute la surface, définissez à la fois le [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) et le [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) de la surface sur `Stretch`.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L’exemple fait pivoter le graphique et augmente la valeur maximale de l’axe vertical afin que le plancher soit visible entre les colonnes. Il duplique ensuite la diapositive deux fois et applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, le même angle de vue et le même arrière‑plan.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Paroi latérale | Paroi arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant vers le graphique le long de la paroi latérale](side-wall.png) | ![Flèche pointant vers la droite à travers la paroi arrière](back-wall.png) | ![Flèche pointant vers la droite à travers le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d’un graphique 3D**

Utilisez [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la hauteur en pourcentage change.

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

Les images suivantes, extraites de l’exemple .NET équivalent, ont été exportées avec Microsoft PowerPoint et illustrent les mêmes réglages de hauteur. Un pourcentage plus faible donne une scène plus plate, tandis qu’un pourcentage plus élevé donne une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations des axes et le placement des libellés pour adapter la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Graphique en colonnes 3D avec une hauteur réglée à 50 % de sa largeur](height_percent_50.png) | ![Graphique en colonnes 3D avec une hauteur réglée à 100 % de sa largeur](height_percent_100.png) | ![Graphique en colonnes 3D avec une hauteur réglée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de hauteur affecte les graphiques en colonnes et barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques en lignes, aires, secteurs et surfaces 3D. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Le réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pour d’autres paramètres d’apparence du graphique, voir [Chart Formatting](/slides/fr/cpp/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs de **0 à 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus grandes augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les marqueurs plus fins sur l’axe de profondeur.

Accédez au groupe via [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). Le paramètre s’applique à chaque série du groupe, pas uniquement à la série utilisée pour y accéder. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) renvoie le réglage du groupe parent.

Ce paramètre affecte les graphiques en colonnes et barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques en lignes et en aires 3D. L’aspect dépend de la façon dont les séries sont disposées en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries distinctes, utilisez `ChartType::Column3D` de l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | Espacement entre les groupes de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données de graphique par défaut, contenant trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seul l’écart de profondeur varie.

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

Les images suivantes, extraites de l’exemple .NET équivalent, ont été exportées avec Microsoft PowerPoint et illustrent les mêmes réglages d’écart de profondeur.

| Écart de profondeur : 0 % | Écart de profondeur : 500 % |
| --- | --- |
| ![Graphique en colonnes 3D sans aucun écart entre les séries le long de l’axe de profondeur](gap_depth_0.png) | ![Graphique en colonnes 3D avec un écart de 500 % entre les séries le long de l’axe de profondeur](gap_depth_500.png) |

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

Définir la forme sur `Box` modifie également le type de série en `ClusteredColumn3D`. Si votre code comporte des branches selon le type de série, appelez `series->get_Type()` après avoir changé la forme. Une valeur mise en cache avant la modification sélectionnerait toujours la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, cônes et colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques en colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D connexes exposés par l’énumération [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique en image avec [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) ou [rendre la diapositive entière](/slides/fr/cpp/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est pratique lorsque vous avez besoin d’un aperçu raster ou souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de gros graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une résolution et des dimensions appropriées à l’affichage ou à l’impression cible.