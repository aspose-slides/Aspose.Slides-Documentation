---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.10.0
linktitle: Aspose.Slides dla .NET 14.10.0
type: docs
weight: 120
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zapoznaj się z aktualizacjami publicznego API oraz zmianami niekompatybilnymi w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint (PPT, PPTX) i ODP."
---
{{% alert color="info" %}} 

Ta strona zawiera wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) klasy, metody, właściwości i inne zmiany wprowadzone w API Aspose.Slides for .NET 14.10.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Dodano typ pola Footer w Aspose.Slides.FieldType**
Typ pola Footer został dodany, aby umożliwić tworzenie pól tego typu oraz prawidłową serializację prezentacji.
#### **Element wyliczenia ShapeElementFillSource.Own został usunięty**
Element wyliczenia ShapeElementFillSource.Own został usunięty jako duplikat. Zamiast ShapeElementFillSource.Own użyj ShapeElementFillSource.Shape.
#### **Dodano metody usuwania punktów danych i kategorii wykresu**
Dodano następujące metody, które pozwalają usuwać punkt danych wykresu z kolekcji punktów danych:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Dodano następującą metodę, która pozwala usuwać kategorię wykresu z kolekcji zawierającej ją:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //usuń za pomocą ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //usuń za pomocą ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//usuń za pomocą ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Usunięto przestarzałe właściwości Aspose.Slides.ParagraphFormat**
Usunięto właściwości BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle. Zostały oznaczone jako przestarzałe już dawno temu.
#### **Usunięto niepotrzebne i przestarzałe konstruktory**
Usunięto następujące konstruktory:

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