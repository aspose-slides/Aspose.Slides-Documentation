---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.10.0-ban
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 14.10.0 API‑val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API módosítások**
#### **Az Aspose.Slides.FieldType.Footer mezőtípus hozzá lett adva**
Az Footer mezőtípus hozzá lett adva annak érdekében, hogy lehetőség legyen ilyen típusú mezők létrehozására, illetve a helyes prezentáció‑szerializációra.
#### **A ShapeElementFillSource.Own enumerációs elem törölve lett**
A ShapeElementFillSource.Own enumerációs elem duplikátumként lett törölve. Használja a ShapeElementFillSource.Shape értéket a ShapeElementFillSource.Own helyett.
#### **Diagram‑adatpontok és kategóriák eltávolításához új metódusok lettek hozzáadva**
A következő metódusok, amelyek lehetővé teszik egy diagram‑adatpont eltávolítását egy diagram‑adatpontgyűjteményből, hozzá lettek adva:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

A következő metódus, amely lehetővé teszi egy diagramkategória eltávolítását a szülőgyűjteményből, hozzá lett adva:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //eltávolítás a ChartCategory.Remove() metódussal

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //eltávolítás a ChartCategoryCollection.Remove() metódussal

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//eltávolítás a ChartDataPoint.Remove() metódussal

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Az elavult Aspose.Slides.ParagraphFormat tulajdonságok eltávolításra kerültek**
A BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle tulajdonságok eltávolításra kerültek. Ezeket már régebb óta elavultként jelölték meg.
#### **Felesleges és elavult konstruktortok törölve lettek**
A következő konstruktortok törölve lettek:

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