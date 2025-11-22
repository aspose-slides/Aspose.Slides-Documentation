---
title: Marqueur de données de graphique
type: docs
url: /fr/net/chart-data-marker/
keywords:
- options de marqueur de graphique
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Définir les options de marqueur de graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Définir les options des marqueurs de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique au sein de séries particulières. Pour définir les options des marqueurs de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini les options des marqueurs de graphique au niveau des points de données.
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

// Prendre la première série du graphique
IChartSeries series = chart.ChartData.Series[0];

// Ajouter un nouveau point (1:3) ici.
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

// Modification du marqueur de la série du graphique
series.Marker.Size = 15;

// Enregistrer la présentation sur le disque
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Quelles formes de marqueurs sont disponibles prêtes à l'emploi ?**

Des formes standard sont disponibles (cercle, carré, diamant, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un marqueur avec un remplissage d'image pour émuler des visuels personnalisés.

**Les marqueurs sont-ils conservés lors de l'exportation d'un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers les [formats raster](/slides/fr/net/convert-powerpoint-to-png/) ou lors de l'enregistrement des [formes au format SVG](/slides/fr/net/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.