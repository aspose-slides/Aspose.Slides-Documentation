---
title: "API publique et modifications incompatibles rétroactives dans Aspose.Slides pour .NET 14.10.0"
linktitle: "Aspose.Slides pour .NET 14.10.0"
type: docs
weight: 120
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour .NET afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 
Cette page répertorie toutes les classes, méthodes, propriétés, etc., [added](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ou [removed](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ainsi que les autres modifications introduites avec l'API Aspose.Slides for .NET 14.10.0.
{{% /alert %}} 
## **Modifications de l'API publique**
#### **Aspose.Slides.FieldType.Footer field type has been added**
Le type de champ Aspose.Slides.FieldType.Footer a été ajouté. Le type de champ Footer a été ajouté pour permettre la création de champs de ce type et pour une sérialisation valide des présentations.
#### **Enum element ShapeElementFillSource.Own has been deleted**
L'élément d'énumération ShapeElementFillSource.Own a été supprimé car dupliqué. Utilisez ShapeElementFillSource.Shape à la place de ShapeElementFillSource.Own.
#### **Methods for chart data points, categories removing have been added**
Les méthodes suivantes, qui permettent de supprimer un point de données de graphique d'une collection de points de données, ont été ajoutées :

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

La méthode suivante, qui permet de supprimer une catégorie de graphique de la collection contenant, a été ajoutée :

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Obsolete Aspose.Slides.ParagraphFormat propertyies have been removed**
Les propriétés BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle ont été supprimées. Elles étaient marquées comme obsolètes depuis longtemps.
#### **Unuseful and obsolete constructors have been removed**
Les constructeurs suivants ont été supprimés :

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)