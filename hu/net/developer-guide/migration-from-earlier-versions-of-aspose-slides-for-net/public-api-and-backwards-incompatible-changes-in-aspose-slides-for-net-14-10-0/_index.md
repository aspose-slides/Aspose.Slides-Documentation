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
description: "Tekintse át a publikus API frissítéseket és a töréspont változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 14.10.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Publikus API változások**
#### **Az Aspose.Slides.FieldType.Footer mezőtípus hozzá lett adva**
A Footer mezőtípus hozzá lett adva a lehetőség megvalósításához, hogy ilyen típusú mezőket lehessen létrehozni, és a prezentációk érvényes sorosítása érdekében.
#### **A ShapeElementFillSource.Own enum elem törölve lett**
A ShapeElementFillSource.Own enum elemet duplikációnak tekintve törölték. Használja a ShapeElementFillSource.Shape elemet a ShapeElementFillSource.Own helyett.
#### **A diagram adatszámok és kategóriák eltávolítására szolgáló metódusok hozzá lettek adva**
A következő metódusok, amelyek lehetővé teszik egy diagram adatpont eltávolítását a diagram adatpontgyűjtből, hozzá lettek adva:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

A következő metódus, amely lehetővé teszi egy diagram kategória eltávolítását a tartalmazó gyűjtből, hozzá lett adva:

IChartCategory.Remove()

``` csharp

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
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Az elavult Aspose.Slides.ParagraphFormat tulajdonságok eltávolításra kerültek**
A BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith és NumberedBulletStyle tulajdonságok eltávolításra kerültek. Ezeket már korábban elavultként jelölték meg.
#### **Használhatatlan és elavult konstruktőrök eltávolításra kerültek**
A következő konstruktőrök eltávolításra kerültek:

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