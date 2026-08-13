---
title: Öffentliche API- und abwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.4.0
linktitle: Aspose.Slides für .NET 15.4.0
type: docs
weight: 150
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
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
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT-, PPTX- und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.4.0 API eingeführt wurden.
{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Der Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType repräsentiert den Formatierungstyp der Kindknoten in einem Organigramm.
#### **Methode IBulletFormat.ApplyDefaultParagraphIndentsShifts wurde hinzugefügt**
Die Methode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts setzt standardmäßige nicht‑null Verschiebungen für den effektiven Absatz‑Einzug und MarginLeft, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es tut, wenn Absatz‑Aufzählungen/Nummerierungen aktiviert werden). Ist die Aufzählungsfunktion deaktiviert, werden lediglich Absatz‑Einzug und MarginLeft zurückgesetzt (wie PowerPoint es tut, wenn Absatz‑Aufzählungen/Nummerierungen deaktiviert werden).

Siehe Beispiele [hier](/slides/de/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Methode IConnector.Reroute wurde hinzugefügt**
Die Methode Aspose.Slides.IConnector.Reroute leitet den Verbinder neu, sodass er den kürzest möglichen Weg zwischen den verbundenen Formen nimmt. Hierzu kann die Reroute()-Methode den StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Methode IPresentation.GetSlideById wurde hinzugefügt**
Die Methode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) gibt eine Folie, Masterfolie oder Layoutfolie anhand der Folien‑ID zurück.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Eigenschaft IShape.ConnectionSiteCount wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.IShape.ConnectionSiteCount gibt die Anzahl der Verbindungspunkte auf der Form zurück.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschaft ISmartArt.IsReversed wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.IsReversed ermöglicht das Abrufen oder Festlegen des Zustands des SmartArt-Diagramms hinsichtlich (links‑zu‑rechts) LTR oder (rechts‑zu‑links) RTL, sofern das Diagramm eine Umkehr unterstützt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschaft ISmartArt.Nodes wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.Nodes gibt eine Sammlung von Wurzelknoten im SmartArt‑Objekt zurück.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // zweiten Wurzelknoten auswählen

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschaft ISmartArtNode.IsHidden wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.IsHidden gibt true zurück, wenn dieser Knoten im Datenmodell ein versteckter Knoten ist.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //gibt true zurück

  if(hidden)

  {

    //einige Aktionen oder Benachrichtigungen ausführen

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Eigenschaft ISmartArtNode.OrganizationChartLayout wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout ermöglicht das Abrufen oder Festlegen des mit dem aktuellen Knoten verbundenen Organisation‑Diagrammtyps.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Set‑Methode für Eigenschaft ISmartArt.Layout wurde hinzugefügt**
Die Set‑Methode für die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.Layout wurde hinzugefügt. Sie ermöglicht das Ändern des Layout‑Typs eines bestehenden Diagramms.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Kleinere API-Änderungen**
**Dies ist die Liste der kleineren API-Änderungen:**

|Enum Aspose.Slides.BevelColorMode |gelöscht, ungenutzter Enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |gelöscht, ungenutzte Eigenschaft |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |hinzugefügt |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |gelöscht |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |gelöscht als veraltet |