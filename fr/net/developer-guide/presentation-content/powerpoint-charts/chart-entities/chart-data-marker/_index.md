---
title: Gérer les repères de données du graphique dans les présentations en .NET
linktitle: Repère de données
type: docs
url: /fr/net/chart-data-marker/
keywords:
- graphique
- point de données
- repère
- options de repère
- taille du repère
- type de remplissage
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à personnaliser les repères de données des graphiques dans Aspose.Slides pour .NET, augmentant l'impact des présentations aux formats PPT et PPTX avec des exemples de code C# clairs."
---

## **Définir les options de repère du graphique**
Les repères peuvent être définis sur les points de données du graphique dans des séries particulières. Pour définir les options de repère du graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini les options de repère du graphique au niveau des points de données.
```c#
// Créer une instance de la classe Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Supprimer la série de démonstration
chart.ChartData.Series.Clear();

// Ajouter une nouvelle série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Définir l'image
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Définir l'image
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Récupérer la première série du graphique
IChartSeries series = chart.ChartData.Series[0];

// Ajouter un nouveau point (1:3) là.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Modifier le repère de la série du graphique
series.Marker.Size = 15;

// Enregistrer la présentation sur le disque
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Quelles formes de repères sont disponibles en standard ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un repère avec un remplissage d'image pour émuler des visuels personnalisés.

**Les repères sont-ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/net/convert-powerpoint-to-png/) ou de l'enregistrement des [formes au format SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), les repères conservent leur apparence et leurs réglages, y compris la taille, le remplissage et le contour.