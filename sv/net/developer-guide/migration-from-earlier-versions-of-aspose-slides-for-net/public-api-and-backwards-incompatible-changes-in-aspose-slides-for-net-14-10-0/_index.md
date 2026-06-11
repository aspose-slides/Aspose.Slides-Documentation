---
title: Offentliga API och bakåtinkompatibla ändringar i Aspose.Slides för .NET 14.10.0
linktitle: Aspose.Slides för .NET 14.10.0
type: docs
weight: 120
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migrering
- äldre kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationlösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) klasser, metoder, egenskaper med mera, samt andra förändringar som införts med Aspose.Slides för .NET 14.10.0 API.

{{% /alert %}} 
## **Publika API‑ändringar**
#### **Aspose.Slides.FieldType.Footer‑fälttyp har lagts till**
Footer‑fälttypen har lagts till för att möjliggöra skapandet av fält av denna typ och för korrekt presentationserialisering.
#### **Enum‑elementet ShapeElementFillSource.Own har tagits bort**
Enum‑elementet ShapeElementFillSource.Own har tagits bort eftersom det var duplicerat. Använd ShapeElementFillSource.Shape istället för ShapeElementFillSource.Own.
#### **Metoder för att ta bort diagramdatapunkter och -kategorier har lagts till**
Följande metoder, som möjliggör att ta bort en diagramdatapunkt från en samling av diagramdatapunkter, har lagts till:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Följande metod, som möjliggör att ta bort en diagramkategori från den innehållande samlingen, har lagts till:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ta bort med ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ta bort med ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//ta bort med ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Föråldrade Aspose.Slides.ParagraphFormat‑egenskaper har tagits bort**
Egenskaperna BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith och NumberedBulletStyle har tagits bort. De markerades som föråldrade för länge sedan.
#### **Onyttiga och föråldrade konstruktörer har tagits bort**
Följande konstruktörer har tagits bort:

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