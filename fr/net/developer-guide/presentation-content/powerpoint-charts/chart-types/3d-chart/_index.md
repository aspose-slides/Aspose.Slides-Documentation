---
title: Personnaliser les graphiques 3D dans les présentations en .NET
linktitle: Graphique 3D
type: docs
url: /fr/net/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides pour .NET. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples C#."
---
## **Vue d'ensemble**

Aspose.Slides for .NET permet de personnaliser la vue d'un graphique 3D via la propriété [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes perpendiculaires et l'espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d'un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et utilise [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) pour ajouter un graphique à colonnes empilées 3D à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant chacune trois valeurs. L’indice de feuille de calcul `0` désigne la première feuille de données du graphique ; la ligne `0` contient les noms des séries et la colonne `0` contient les libellés des catégories.

Les propriétés [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) et [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) définissent respectivement la rotation du graphique à 40 et 270 degrés. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) fixe sa profondeur à 150 % de sa largeur, tandis que [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) active des axes perpendiculaires au lieu d’une perspective. La présentation résultante contient le graphique ainsi configuré.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Appliquer un remplissage image à la surface d'un graphique 3D**

Un graphique 3D possède trois surfaces que vous pouvez remplir indépendamment : le [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), le [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) et le [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). Définissez le [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) de la surface sélectionnée sur `Picture` et affectez une image. Réglez à la fois le [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) et le [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) de la surface sur `Stretch` pour adapter une copie de l’image à toute la surface.

Enregistrez [arrow.png](arrow.png) dans le répertoire de travail. L’exemple fait pivoter le graphique et augmente la valeur maximale de l’axe vertical afin que le sol soit visible entre les colonnes. Il duplique ensuite la diapositive deux fois avant d’appliquer la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, angle de vue et arrière‑plan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Paroi latérale | Paroi arrière | Sol |
| --- | --- | --- |
| ![Flèche pointant vers l'intérieur du graphique le long de la paroi latérale](side-wall.png) | ![Flèche pointant vers la droite à travers la paroi arrière](back-wall.png) | ![Flèche pointant vers la droite sur le sol entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d'un graphique 3D**

Utilisez [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seul le pourcentage de hauteur varie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Les images suivantes ont été exportées des présentations générées à l’aide de Microsoft PowerPoint. Un pourcentage plus faible produit une scène plus plate, tandis qu’un pourcentage plus élevé produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations d’axe et le placement des libellés pour adapter la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Diagramme à colonnes 3D avec une hauteur fixée à 50 % de sa largeur](height_percent_50.png) | ![Diagramme à colonnes 3D avec une hauteur fixée à 100 % de sa largeur](height_percent_100.png) | ![Diagramme à colonnes 3D avec une hauteur fixée à 200 % de sa largeur](height_percent_200.png) |

Ces propriétés contrôlent différents aspects du graphique :

| Propriété | Effet |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |

Le réglage de la hauteur affecte les graphiques à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne, en surface, en secteur et en zone. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Ce réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un `BubbleWith3D` ; ces noms sont des membres de l’énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pour d’autres paramètres d’apparence, consultez [Chart Formatting](/slides/fr/net/chart-formatting/).

## **Ajuster l'écart entre les séries**

Utilisez [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du marqueur. Utilisez des valeurs comprises entre **0 et 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus grandes augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les marqueurs plus fins sur l’axe de profondeur.

Accédez au groupe via [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Le réglage s’applique à chaque série du groupe, pas seulement à celle utilisée pour y accéder. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) est en lecture seule et reflète le paramètre du groupe parent.

Ce réglage affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en ligne et en zone. L’apparence dépend du fait que les séries soient disposées en profondeur, groupées ou empilées. Pour une comparaison claire des écarts entre séries distinctes, utilisez `ChartType.Column3D` de l’énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

Ces propriétés contrôlent différents aspects du graphique :

| Propriété | Effet |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du marqueur. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Espacement entre les clusters de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données par défaut du graphique, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seul l’écart de profondeur varie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Les images suivantes ont été exportées des présentations générées à l’aide de Microsoft PowerPoint.

| Profondeur d'écart : 0 % | Profondeur d'écart : 500 % |
| --- | --- |
| ![Diagramme à colonnes 3D sans espace entre les séries le long de l'axe de profondeur](gap_depth_0.png) | ![Diagramme à colonnes 3D avec un écart de 500 % entre les séries le long de l'axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme de la barre**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L’exemple lit [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) et [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) avant et après chaque modification.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| Modification de la première série | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set `Type` to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set `Bar3DShape` to `Box` | `ClusteredColumn3D` | `Box` |

Définir la forme sur `Box` modifie également le type de série en `ClusteredColumn3D`. Si votre code effectue des branches selon le type de série, lisez `series.Type` après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait encore la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, de cônes et de colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés par l’énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d'un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image avec [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou [render the entire slide](/slides/fr/net/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu raster ou d’intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez à une résolution et des dimensions appropriées à la destination d’affichage ou d’impression.