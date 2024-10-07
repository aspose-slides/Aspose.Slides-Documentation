---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für .NET 15.4.0
type: docs
weight: 150
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) Klassen, Methoden, Eigenschaften usw. und andere Änderungen, die mit der API von Aspose.Slides für .NET 15.4.0 eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Das Aspose.Slides.SmartArt.OrganizationChartLayoutType-Enum stellt den Formatierungstyp der untergeordneten Knoten in einem Organigramm dar.
#### **Methode IBulletFormat.ApplyDefaultParagraphIndentsShifts wurde hinzugefügt**
Die Methode Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts setzt standardmäßige, von null verschiedene Verschiebungen für die effektive Absatz-Indentation und MarginLeft, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es tut, wenn Aufzählungszeichen/Nummerierung aktiviert sind). Wenn Aufzählungszeichen deaktiviert sind, wird nur die Absatz-Indentation und MarginLeft zurückgesetzt (wie PowerPoint es tut, wenn Aufzählungszeichen/Nummerierung deaktiviert sind).

Siehe Beispiele [hier](/slides/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Methode IConnector.Reroute wurde hinzugefügt**
Die Methode Aspose.Slides.IConnector.Reroute leitet den Connector so um, dass er den kürzesten möglichen Weg zwischen den verbundenen Formen nimmt. Dazu kann die Methode Reroute() die StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

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
Die Methode Aspose.Slides.IPresentation.GetSlideById(System.UInt32) gibt eine Slide, MasterSlide oder LayoutSlide nach der Folien-ID zurück.

``` csharp

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
#### **Eigenschaft ISmartArt.IsReversed wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.IsReversed ermöglicht das Abrufen oder Setzen des Status des SmartArt-Diagramms in Bezug auf (von links nach rechts) LTR oder (von rechts nach links) RTL, wenn das Diagramm eine Umkehrung unterstützt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschaft ISmartArt.Nodes wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.Nodes gibt die Sammlung der Wurzelknoten im SmartArt-Objekt zurück.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // wählt den zweiten Wurzelknoten aus

  node.TextFrame.Text = "Zweiter Wurzelknoten";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschaft ISmartArtNode.IsHidden wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.IsHidden gibt true zurück, wenn dieser Knoten ein ausgeblendeter Knoten im Datenmodell ist.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // gibt true zurück

  if(hidden)

  {

    // führen Sie einige Aktionen oder Benachrichtigungen durch

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Eigenschaft ISmartArtNode.OrganizationChartLayout wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout ermöglicht das Abrufen oder Setzen des mit dem aktuellen Knoten verbundenen Organigrammtyps.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Setzmethode für die Eigenschaft ISmartArt.Layout wurde hinzugefügt**
Die Setzmethode für die Eigenschaft Aspose.Slides.SmartArt.ISmartArt.Layout wurde hinzugefügt. Sie ermöglicht das Ändern des Layouttyps eines vorhandenen Diagramms.

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

|Enum Aspose.Slides.BevelColorMode | gelöscht, ungenutztes Enum |
| :- | :- |
|Eigenschaft ThreeDFormatEffectiveData.BevelColorMode | gelöscht, ungenutzte Eigenschaft |
|Eigenschaft Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Eigenschaft Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent | hinzugefügt |
|Eigenschaft Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Vererbung von IParagraphFormatEffectiveData von ISlideComponent <br>Eigenschaft Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Vererbung von IThreeDFormat von ISlideComponent | gelöscht |
|Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Eigenschaft Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle | gelöscht, da veraltet |