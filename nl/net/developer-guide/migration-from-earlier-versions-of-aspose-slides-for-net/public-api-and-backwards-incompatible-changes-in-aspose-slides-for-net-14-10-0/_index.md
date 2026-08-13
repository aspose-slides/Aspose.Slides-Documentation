---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 14.10.0
linktitle: Aspose.Slides voor .NET 14.10.0
type: docs
weight: 120
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migratie
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de publieke API‑updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP presentatie‑oplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) of [verwijderde](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides voor .NET 14.10.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Aspose.Slides.FieldType.Footer veldtype is toegevoegd**
Het Footer-veldtype is toegevoegd om de mogelijkheid te bieden velden van dit type te maken en voor een geldige presentatie-serialisatie.
#### **Enum‑element ShapeElementFillSource.Own is verwijderd**
Het enum‑element ShapeElementFillSource.Own is verwijderd omdat het een duplicaat was. Gebruik ShapeElementFillSource.Shape in plaats van ShapeElementFillSource.Own.
#### **Methoden om gegevenspunten en categorieën van diagrammen te verwijderen zijn toegevoegd**
De volgende methoden, die het mogelijk maken een gegevenspunt uit een diagramgegevenspuntverzameling te verwijderen, zijn toegevoegd:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

De volgende methode, die het mogelijk maakt een diagramcategorie uit de bijbehorende verzameling te verwijderen, is toegevoegd:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //verwijderen met ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //verwijderen met ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//verwijderen met ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Obsolete Aspose.Slides.ParagraphFormat‑eigenschappen zijn verwijderd**
De eigenschappen BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith en NumberedBulletStyle zijn verwijderd. Ze waren al lang geleden gemarkeerd als verouderd.
#### **Onbruikbare en verouderde constructors zijn verwijderd**
De volgende constructors zijn verwijderd:

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