---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.10.0
linktitle: Aspose.Slides dla .NET 14.10.0
type: docs
weight: 120
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- dziedziczony podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) klasy, metody, właściwości i tak dalej, a także inne zmiany wprowadzone w API Aspose.Slides for .NET 14.10.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Dodano typ pola Footer w Aspose.Slides.FieldType**
Typ pola Footer został dodany w celu umożliwienia tworzenia pól tego typu oraz prawidłowej serializacji prezentacji.
#### **Usunięto element wyliczeniowy ShapeElementFillSource.Own**
Element wyliczeniowy ShapeElementFillSource.Own został usunięty jako duplikat. Zamiast ShapeElementFillSource.Own należy używać ShapeElementFillSource.Shape.
#### **Dodano metody usuwania punktów danych wykresu i kategorii**
Dodano następujące metody, które umożliwiają usuwanie punktu danych wykresu z kolekcji punktów danych wykresu:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Dodano następującą metodę, która umożliwia usunięcie kategorii wykresu z zawierającej ją kolekcji:

IChartCategory.Remove()

``` csharp

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

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Usunięto przestarzałe właściwości Aspose.Slides.ParagraphFormat**
Właściwości BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle zostały usunięte. Były oznaczone jako przestarzałe już dawno temu.
#### **Usunięto nieużyteczne i przestarzałe konstruktory**
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