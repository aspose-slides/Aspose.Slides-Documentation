---
title: Öffentliche API- und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 14.10.0
linktitle: Aspose.Slides für .NET 14.10.0
type: docs
weight: 120
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 14.10.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Aspose.Slides.FieldType.Footer Feldtyp wurde hinzugefügt**
Der Footer‑Feldtyp wurde hinzugefügt, um die Möglichkeit zu implementieren, Felder dieses Typs zu erstellen und eine gültige Präsentationsserialisierung zu gewährleisten.
#### **Enum‑Element ShapeElementFillSource.Own wurde gelöscht**
Das Enum‑Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie stattdessen ShapeElementFillSource.Shape anstelle von ShapeElementFillSource.Own.
#### **Methoden zum Entfernen von Diagrammdatenpunkten und -kategorien wurden hinzugefügt**
Die folgenden Methoden, die das Entfernen eines Diagrammdatenpunkts aus einer Diagrammdatenpunktsammlung ermöglichen, wurden hinzugefügt:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

Die folgende Methode, die das Entfernen einer Diagrammkategorie aus der zugehörigen Sammlung ermöglicht, wurde hinzugefügt:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Veraltete Aspose.Slides.ParagraphFormat‑Eigenschaften wurden entfernt**
Die Eigenschaften BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle wurden entfernt. Sie waren bereits vor langer Zeit als veraltet markiert.
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