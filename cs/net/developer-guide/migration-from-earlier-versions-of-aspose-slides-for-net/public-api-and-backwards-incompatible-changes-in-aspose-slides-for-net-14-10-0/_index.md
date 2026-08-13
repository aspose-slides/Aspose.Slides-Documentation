---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.10.0
linktitle: Aspose.Slides pro .NET 14.10.0
type: docs
weight: 120
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro .NET a hladce migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) nebo [odebrané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v API Aspose.Slides pro .NET 14.10.0.

{{% /alert %}} 
## **Veřejné API změny**
#### **Typ pole Aspose.Slides.FieldType.Footer byl přidán**
Typ pole Footer byl přidán pro umožnění vytváření polí tohoto typu a pro platnou serializaci prezentace.
#### **Enum prvek ShapeElementFillSource.Own byl smazán**
Enum prvek ShapeElementFillSource.Own byl smazán jako duplicitní. Použijte ShapeElementFillSource.Shape místo ShapeElementFillSource.Own.
#### **Metody pro odstraňování datových bodů a kategorií grafu byly přidány**
Byly přidány následující metody, které umožňují odstranit datový bod grafu ze sbírky datových bodů grafu:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Byla přidána následující metoda, která umožňuje odstranit kategorii grafu ze zahrnující sbírky:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //odstranit pomocí ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //odstranit pomocí ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//odstranit pomocí ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Zastaralé vlastnosti Aspose.Slides.ParagraphFormat byly odebrány**
Vlastnosti BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle byly odebrány. Byly označeny jako zastaralé již dlouho.
#### **Neužitečné a zastaralé konstruktory byly odebrány**
Byly odebrány následující konstruktory:

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