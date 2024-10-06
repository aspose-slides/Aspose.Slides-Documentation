---
title: Options de Marqueur de Graphique
type: docs
url: /net/chart-data-marker/
keywords:
- options de marqueur de graphique
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Définir les options de marqueur de graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Définir les Options de Marqueur de Graphique**
Les marqueurs peuvent être définis sur des points de données de graphique à l'intérieur de séries particulières. Pour définir les options de marqueur de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.

```c#
// Créer une instance de la classe Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Créer le graphique par défaut
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Obtenir l'index de la feuille de données graphique par défaut
int defaultWorksheetIndex = 0;

// Obtenir la feuille de données graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Supprimer la série de démonstration
chart.ChartData.Series.Clear();

// Ajouter une nouvelle série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.Type);

// Définir l'image
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Définir l'image
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Prendre la première série de graphique
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

// Changer le marqueur de la série de graphique
series.Marker.Size = 15;

// Écrire la présentation sur le disque
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```