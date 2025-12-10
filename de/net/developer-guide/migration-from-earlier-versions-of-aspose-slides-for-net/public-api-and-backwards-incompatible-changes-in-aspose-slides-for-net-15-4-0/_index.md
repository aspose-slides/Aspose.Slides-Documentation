---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für .NET 15.4.0
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
description: "Überprüfen Sie die öffentlichen API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) Klassen, Methoden, Eigenschaften usw. und weitere Änderungen, die mit der Aspose.Slides für .NET 15.4.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Das Aspose.Slides.SmartArt.OrganizationChartLayoutType‑Enum stellt den Formatierungstyp der untergeordneten Knoten in einem Organigramm dar.
#### **Methode IBulletFormat.ApplyDefaultParagraphIndentsShifts wurde hinzugefügt**
Methode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts legt standardmäßige von Null verschiedene Verschiebungen für den effektiven Absatz‑Einzug und den linken Rand fest, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es tut, wenn Absatz‑Aufzählungszeichen/Nummerierung aktiviert werden). Wenn Aufzählungszeichen deaktiviert sind, werden Absatz‑Einzug und linker Rand einfach zurückgesetzt (wie PowerPoint es tut, wenn Absatz‑Aufzählungszeichen/Nummerierung deaktiviert werden).

Siehe Beispiele [hier](/slides/de/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Methode IConnector.Reroute wurde hinzugefügt**
Methode Aspose.Slides.IConnector.Reroute leitet den Verbinder neu, sodass er den kürzest möglichen Pfad zwischen den verbundenen Formen nimmt. Dabei kann die Reroute()‑Methode die Eigenschaften StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

``` csharp

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
Methode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) gibt eine Folie, Master‑Folie oder Layout‑Folie anhand der Folien‑ID zurück.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount wurde hinzugefügt**
Property Aspose.Slides.IShape.ConnectionSiteCount gibt die Anzahl der Verbindungspunkte auf der Form zurück.

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.IsReversed wurde hinzugefügt**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed ermöglicht das Abrufen oder Festlegen des Zustands des SmartArt‑Diagramms hinsichtlich Links‑nach‑Rechts (LTR) oder Rechts‑nach‑Links (RTL), sofern das Diagramm eine Umkehrung unterstützt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes wurde hinzugefügt**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes gibt die Sammlung von Wurzelknoten im SmartArt‑Objekt zurück.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // zweiten Wurzelknoten auswählen

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden wurde hinzugefügt**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // gibt true zurück

  if(hidden)

  {

    // einige Aktionen oder Benachrichtigungen ausführen

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout wurde hinzugefügt**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout ermöglicht das Abrufen oder Festlegen des Organigramm‑Typs, der dem aktuellen Knoten zugeordnet ist.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set-Methode für Property ISmartArt.Layout wurde hinzugefügt**
Die Set‑Methode für die Property Aspose.Slides.SmartArt.ISmartArt.Layout wurde hinzugefügt. Sie ermöglicht das Ändern des Layout‑Typs eines bestehenden Diagramms.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Kleinere API-Änderungen**
**Dies ist die Liste der kleineren API-Änderungen:**

|Enum Aspose.Slides.BevelColorMode|gelöscht, ungenutztes Enum|
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode|gelöscht, ungenutzte Eigenschaft|
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent|hinzugefügt|
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|gelöscht|
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle|gelöscht als veraltet|