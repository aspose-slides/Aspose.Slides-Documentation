---
title: Graphique 3D
type: docs
url: /fr/net/3d-chart/
keywords: "graphique 3d, rotationX, rotationY, depthpercent, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Définir rotationX, rotationY et depthpercents pour un graphique 3D dans une présentation PowerPoint en C# ou .NET"
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**
Aspose.Slides for .NET fournit une API simple pour définir ces propriétés. L'article suivant vous aidera à définir différentes propriétés telles que la rotation X,Y, **DepthPercents**, etc. Le code d'exemple applique la définition des propriétés mentionnées ci‑dessus.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();
           
// Accéder à la première diapositive
ISlide slide = presentation.Slides[0];

// Ajouter un graphique avec les données par défaut
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Définir l'index de la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtenir la feuille de calcul des données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Ajouter une série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Ajouter des catégories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Définir les propriétés Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Prendre la deuxième série du graphique
IChartSeries series = chart.ChartData.Series[1];

// Remplir maintenant les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Définir la valeur Overlap
series.ParentSeriesGroup.Overlap = 100;         

// Enregistrer la présentation sur le disque
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques en colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via l’énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). Pour obtenir une liste exacte et à jour, consultez les membres [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) dans la référence API de la version installée.

**Puis‑je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image via l’[API du graphique](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ou [rendre la diapositive entière](/slides/fr/net/convert-powerpoint-to-png/) dans des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu pixel‑parfait ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque c’est possible, et rendez la sortie à une taille appropriée (résolution et dimensions) pour correspondre à l’affichage cible ou aux exigences d’impression.