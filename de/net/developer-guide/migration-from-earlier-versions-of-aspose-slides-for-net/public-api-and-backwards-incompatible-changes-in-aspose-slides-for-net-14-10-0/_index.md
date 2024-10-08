---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für .NET 14.10.0
type: docs
weight: 120
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) Klassen, Methoden, Eigenschaften und so weiter auf, sowie andere Änderungen, die mit der Aspose.Slides für .NET 14.10.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Der Feldtyp Aspose.Slides.FieldType.Footer wurde hinzugefügt**
Der Feldtyp Footer wurde hinzugefügt, um die Möglichkeit zu implementieren, Felder dieses Typs zu erstellen und eine gültige Präsentationsserialisierung zu ermöglichen.
#### **Enum-Element ShapeElementFillSource.Own wurde gelöscht**
Das Enum-Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie stattdessen ShapeElementFillSource.Shape.
#### **Methoden zum Entfernen von Diagrammdatapunkten und Kategorien wurden hinzugefügt**
Die folgenden Methoden, die das Entfernen von Diagrammdatapunkten aus einer Diagrammdatensammlung ermöglichen, wurden hinzugefügt:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

Die folgende Methode, die das Entfernen einer Diagrammkategorie aus der enthaltenen Sammlung ermöglicht, wurde hinzugefügt:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); // Entfernen mit ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); // Entfernen mit ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();// Entfernen mit ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);// ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Veraltete Eigenschaften Aspose.Slides.ParagraphFormat wurden entfernt**
Die Eigenschaften BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle wurden entfernt. Sie wurden vor langer Zeit als veraltet markiert.
#### **Unnütze und veraltete Konstruktoren wurden entfernt**
Die folgenden Konstruktoren wurden entfernt:

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