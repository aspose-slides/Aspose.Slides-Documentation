---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für Java 15.4.0
type: docs
weight: 120
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) auf, die mit der Aspose.Slides für Java 15.4.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen des öffentlichen API**
### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Das Enum com.aspose.slides.OrganizationChartLayoutType repräsentiert den Formatierungstyp der Kindknoten in einem Organigramm.
### **Methode IBulletFormat.applyDefaultParagraphIndentsShifts() wurde hinzugefügt**
Die Methode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts setzt Standardverschiebungen ungleich null für den effektiven Absatz-Indent und MarginLeft, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es macht, wenn Aufzählungszeichen/-nummerierung aktiviert sind). Wenn Aufzählungszeichen deaktiviert sind, wird nur der Absatz-Indent und MarginLeft zurückgesetzt (wie PowerPoint es macht, wenn Aufzählungszeichen/-nummerierung deaktiviert sind).
### **Methode IConnector.reroute() wurde hinzugefügt**
Die Methode com.aspose.slides.IConnector.reroute() leitet den Verbinder so um, dass er den kürzest möglichen Weg zwischen den verbundenen Formen nimmt. Dazu kann die reroute()-Methode den StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

``` java

 Präsentation input = new Präsentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Methode IPresentation.getSlideById(long) wurde hinzugefügt**
Die Methode Aspose.Slides.IPresentation.getSlideById(int) gibt eine Folie, MasterSlide oder LayoutSlide anhand der Folien-ID zurück.

``` java

 Präsentation presentation = new Präsentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Methode ISmartArt.getNodes() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArt.getNodes() gibt eine Sammlung von Wurzknoten im SmartArt-Objekt zurück.

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // wähle den zweiten Wurzknoten aus

node.getTextFrame().setText("Zweiter Wurzknoten");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArt.setLayout(int) wurde hinzugefügt**
Die Methode für die Eigenschaft com.aspose.slides.ISmartArt.setLayout(int) wurde hinzugefügt. Sie ermöglicht das Ändern des Layouttyps eines bestehenden Diagramms.

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArtNode.isHidden() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArtNode.isHidden() gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist.

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // gibt true zurück

if(hidden) {

    // führe einige Aktionen oder Benachrichtigungen durch

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArt.isReversed(), setReserved() wurden hinzugefügt**
Die Eigenschaft com.aspose.slides.ISmartArt.IsReversed ermöglicht es, den Zustand des SmartArt-Diagramms in Bezug auf (von links nach rechts) LTR oder (von rechts nach links) RTL abzurufen oder festzulegen, wenn das Diagramm eine Umkehrung unterstützt.

``` java

 Präsentation presentation = new Präsentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) wurden hinzugefügt**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ermöglichen es, den mit dem aktuellen Knoten verbundenen Organigrammtyp abzurufen oder festzulegen.

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Eigenschaft IShape.getConnectionSiteCount() wurde hinzugefügt**
Die Eigenschaft com.aspose.slides.getConnectionSiteCount() gibt die Anzahl der Verbindungsstellen an der Form zurück.

``` java

 Präsentation input = new Präsentation();

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

```
### **Kleine Änderungen**
Dies ist die Liste kleiner API-Änderungen:

|Enum com.aspose.slides.BevelColorMode | gelöscht, unbenutztes Enum |
| :- | :- |
|Methode ThreeDFormatEffectiveData.getBevelColorMode() | gelöscht, unbenutzte Eigenschaft |
|Methode com.aspose.slides.ChartSeriesGroup.getChart() | hinzugefügt |
|Vererbung von IParagraphFormatEffectiveData von ISlideComponent <br>Vererbung von IThreeDFormat von ISlideComponent | gelöscht |
|Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | gelöscht, da veraltet |