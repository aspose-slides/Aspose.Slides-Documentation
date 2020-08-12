---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) or [removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Enum OrganizationChartLayoutType has been added**
The Aspose.Slides.SmartArt.OrganizationChartLayoutType enum represents formatting type the child nodes in an organization chart.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts has been added**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sets default non-zero shifts for effective paragraph Indent and MarginLeft when bullets is enabled (like PowerPoint do if enable paragraph bullets/numbering in it). If bullets is disabled then just reset paragraph Indent and MarginLeft (like PowerPoint do if disable paragraph bullets/numbering in it).

See examples here: <http://www.aspose.com/docs/display/slidesnet/Managing+Paragraph+Bullets+in+PPTX>
#### **Method IConnector.Reroute has been added**
Method Aspose.Slides.IConnector.Reroute reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the Reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

```

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
#### **Method IPresentation.GetSlideById has been added**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) returns a Slide, MasterSlide or LayoutSlide by slide Id.

```

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

```
#### **Property IShape.ConnectionSiteCount has been added**
Property Aspose.Slides.IShape.ConnectionSiteCount returns the number of connection sites on the shape.

```

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
#### **Property ISmartArt.IsReversed has been added**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed allows get or sets the state of the SmartArt diagram with regard to (left-to-right) LTR or (right-to-left) RTL, if the diagram supports reversal.

```

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArt.Nodes has been added**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes returns collection of root nodes in SmartArt object.

```

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // select second root node

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArtNode.IsHidden has been added**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden returns true if this node is a hidden node in the data model.

```

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArtNode.OrganizationChartLayout has been added**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout allows get or sets organization chart type associated with current node.

```

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Set method for property ISmartArt.Layout has been added**
The set method for property Aspose.Slides.SmartArt.ISmartArt.Layout has been added.It allows change layout type of an existing diagram.

```

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Minor API changes**
**This is the list of minor API changes:**

|Enum Aspose.Slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |deleted, unused property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |added |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |deleted as obsolete |

