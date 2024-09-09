---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Node.js via Java 15.4.0
type: docs
weight: 120
url: /nodejs-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introduced with the Aspose.Slides for Node.js via Java 15.4.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Enum OrganizationChartLayoutType has been added**
The aspose.slides.OrganizationChartLayoutType enum represents formatting type the child nodes in an organization chart.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() has been added**
Method aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts sets default non-zero shifts for effective paragraph Indent and MarginLeft when bullets is enabled (like PowerPoint do if enable paragraph bullets/numbering in it). If bullets is disabled then just reset paragraph Indent and MarginLeft (like PowerPoint do if disable paragraph bullets/numbering in it).
### **Method IConnector.reroute() has been added**
Method aspose.slides.IConnector.reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

```javascript
    var input = new  aspose.slides.Presentation();
    var shapes = input.getSlides().get_Item(0).getShapes();
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();
    input.save("output.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Method IPresentation.getSlideById(long) has been added**
Method Aspose.Slides.IPresentation.getSlideById(int) returns a Slide, MasterSlide or LayoutSlide by slide Id.

```javascript
    var presentation = new  aspose.slides.Presentation();
    var id = presentation.getSlides().get_Item(0).getSlideId();
    var slide = presentation.getSlideById(id);
```
### **Method ISmartArt.getNodes() has been added**
Method aspose.slides.ISmartArt.getNodes() returns collection of root nodes in SmartArt object.

```javascript
    var pres = new  aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.VerticalBulletList);
    var node = smart.getNodes().get_Item(1);// select second root node
    node.getTextFrame().setText("Second root node");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Method ISmartArt.setLayout(int) has been added**
Method for property aspose.slides.ISmartArt.setLayout(int) has been added. It allows change layout type of an existing diagram.

```javascript
    var pres = new  aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Method ISmartArtNode.isHidden() has been added**
Method aspose.slides.ISmartArtNode.isHidden() returns true if this node is a hidden node in the data model.

```javascript
    var pres = new  aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    var node = smart.getAllNodes().addNode();
    var hidden = node.isHidden();// returns true
    if (hidden) {
        // do some actions or notifications
    }
    pres.Save("out.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReserved() have been added**
Property aspose.slides.ISmartArt.IsReversed allows get or sets the state of the SmartArt diagram with regard to (left-to-right) LTR or (right-to-left) RTL, if the diagram supports reversal.

```javascript
    var presentation = new  aspose.slides.Presentation();
    var smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    smart.setReversed(true);
    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Methods aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) allow get or sets organization chart type associated with current node.

```javascript
    var pres = new  aspose.slides.Presentation();
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Property IShape.getConnectionSiteCount() has been added**
Property aspose.slides.getConnectionSiteCount() returns the number of connection sites on the shape.

```javascript
    var input = new  aspose.slides.Presentation();
    var shapes = input.getSlides().get_Item(0).getShapes();
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 100, 100);
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    var wantedIndex = 6;
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    input.save("output.pptx", aspose.slides.SaveFormat.Pptx);
```
### **Minor Changes**
This is the list of minor API changes:

|Enum aspose.slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |deleted, unused property |
|Method aspose.slides.ChartSeriesGroup.getChart() |added |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Method aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |deleted as obsolete |

