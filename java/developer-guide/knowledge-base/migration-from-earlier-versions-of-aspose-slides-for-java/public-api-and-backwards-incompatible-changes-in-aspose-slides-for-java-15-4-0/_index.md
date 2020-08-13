---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0-html/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0-html/) introduced with the Aspose.Slides for Java 15.4.0 API.

{{% /alert %}} 
## **Public API Changes**
#### **Enum OrganizationChartLayoutType has been added**
The com.aspose.slides.OrganizationChartLayoutType enum represents formatting type the child nodes in an organization chart.
#### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() has been added**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sets default non-zero shifts for effective paragraph Indent and MarginLeft when bullets is enabled (like PowerPoint do if enable paragraph bullets/numbering in it). If bullets is disabled then just reset paragraph Indent and MarginLeft (like PowerPoint do if disable paragraph bullets/numbering in it).
#### **Method IConnector.reroute() has been added**
Method com.aspose.slides.IConnector.reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{< highlight java >}}

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Method IPresentation.getSlideById(long) has been added**
Method Aspose.Slides.IPresentation.getSlideById(int) returns a Slide, MasterSlide or LayoutSlide by slide Id.

{{< highlight java >}}

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

{{< /highlight >}}
#### **Method ISmartArt.getNodes() has been added**
Method com.aspose.slides.ISmartArt.getNodes() returns collection of root nodes in SmartArt object.

{{< highlight java >}}

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // select second root node

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Method ISmartArt.setLayout(int) has been added**
Method for property com.aspose.slides.ISmartArt.setLayout(int) has been added. It allows change layout type of an existing diagram.

{{< highlight java >}}

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Method ISmartArtNode.isHidden() has been added**
Method com.aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model.

{{< highlight java >}}

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //returns true

if(hidden) {

    //do some actions or notifications

}

pres.Save("out.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Methods ISmartArt.isReversed(), setReserved() have been added**
Property com.aspose.slides.ISmartArt.IsReversed allows get or sets the state of the SmartArt diagram with regard to (left-to-right) LTR or (right-to-left) RTL, if the diagram supports reversal.

{{< highlight java >}}

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node.

{{< highlight java >}}

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Property IShape.getConnectionSiteCount() has been added**
Property com.aspose.slides.getConnectionSiteCount() returns the number of connection sites on the shape.

{{< highlight java >}}

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

{{< /highlight >}}
#### **Minor Changes**
This is the list of minor API changes:

|Enum com.aspose.slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |deleted, unused property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |added |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |deleted as obsolete |

