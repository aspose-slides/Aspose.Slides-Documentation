---
title: Public API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.10.0
linktitle: Aspose.Slides für .NET 14.10.0
type: docs
weight: 120
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- Migration
- Legacy-Code
- moderner Code
- veralteter Ansatz
- moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die öffentlichen API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 14.10.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Der Feldtyp Aspose.Slides.FieldType.Footer wurde hinzugefügt**
#### **Das Enum-Element ShapeElementFillSource.Own wurde gelöscht**
Das Enum-Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie ShapeElementFillSource.Shape anstelle von ShapeElementFillSource.Own.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und -kategorien wurden hinzugefügt**
Die folgenden Methoden, mit denen ein Diagrammdatenpunkt aus einer Diagrammdatenpunktsammlung entfernt werden kann, wurden hinzugefügt:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Die folgende Methode, mit der eine Diagrammkategorie aus der beinhaltenden Sammlung entfernt werden kann, wurde hinzugefügt:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //Entfernen mit ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //Entfernen mit ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//Entfernen mit ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Veraltete Aspose.Slides.ParagraphFormat-Eigenschaften wurden entfernt**
Die Eigenschaften BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle wurden entfernt. Sie wurden bereits vor langer Zeit als veraltet markiert.
#### **Unnötige und veraltete Konstruktoren wurden entfernt**
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