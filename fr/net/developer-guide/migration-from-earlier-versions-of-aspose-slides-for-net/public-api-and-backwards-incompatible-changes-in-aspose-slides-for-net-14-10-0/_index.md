---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour .NET 14.10.0
type: docs
weight: 120
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ou [supprimées](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), et d'autres changements introduits avec l'API Aspose.Slides pour .NET 14.10.0.

{{% /alert %}} 
## **Changements de l'API publique**
#### **Le type de champ Aspose.Slides.FieldType.Footer a été ajouté**
Le type de champ Footer a été ajouté pour permettre la création de champs de ce type et pour une sérialisation valide des présentations.
#### **L'élément Enum ShapeElementFillSource.Own a été supprimé**
L'élément Enum ShapeElementFillSource.Own a été supprimé car il était dupliqué. Utilisez ShapeElementFillSource.Shape à la place de ShapeElementFillSource.Own.
#### **Des méthodes pour la suppression de points de données de graphique et de catégories ont été ajoutées**
Les méthodes suivantes, qui permettent de supprimer un point de données de graphique d'une collection de points de données de graphique, ont été ajoutées :

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

La méthode suivante, qui permet de supprimer une catégorie de graphique de la collection contenant, a été ajoutée :

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //supprimer avec ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //supprimer avec ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//supprimer avec ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Les propriétés obsolètes Aspose.Slides.ParagraphFormat ont été supprimées**
Les propriétés BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle ont été supprimées. Elles étaient marquées comme obsolètes depuis longtemps.
#### **Les constructeurs inutiles et obsolètes ont été supprimés**
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