---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 15.4.0
linktitle: Aspose.Slides für Java 15.4.0
type: docs
weight: 120
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderne Vorgehensweise
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und breaking changes in Aspose.Slides für Java, um Ihre PowerPoint‑PPT, PPTX und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und weitere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) auf, die mit der Aspose.Slides for Java 15.4.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Der Enum com.aspose.slides.OrganizationChartLayoutType stellt den Formatierungstyp der Kindknoten in einem Organigramm dar.
### **Methode IBulletFormat.applyDefaultParagraphIndentsShifts() wurde hinzugefügt**
Die Methode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts legt standardmäßige, von Null verschiedene Verschiebungen für den effektiven Absatz‑Einzug (Indent) und den linken Rand (MarginLeft) fest, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es macht, wenn Absatz‑Aufzählungszeichen/Nummerierung aktiviert werden). Wenn Aufzählungszeichen deaktiviert sind, werden lediglich Absatz‑Einzug und MarginLeft zurückgesetzt (wie PowerPoint es macht, wenn Absatz‑Aufzählungszeichen/Nummerierung deaktiviert werden).
### **Methode IConnector.reroute() wurde hinzugefügt**
Die Methode com.aspose.slides.IConnector.reroute() leitet den Verbinder neu, sodass er den kürzest möglichen Weg zwischen den verbundenen Formen nimmt. Dabei kann die Methode reroute() die Indizes StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

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
Die Methode Aspose.Slides.IPresentation.getSlideById(long) gibt eine Slide, MasterSlide oder LayoutSlide anhand der Folien‑Id zurück.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Methode ISmartArt.getNodes() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArt.getNodes() gibt eine Sammlung von Wurzelknoten im SmartArt‑Objekt zurück.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // zweiten Wurzelknoten auswählen

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArt.setLayout(int) wurde hinzugefügt**
Die Methode für die Eigenschaft com.aspose.slides.ISmartArt.setLayout(int) wurde hinzugefügt. Sie ermöglicht das Ändern des Layouttyps einer bestehenden Diagramm‑Darstellung.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArtNode.isHidden() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArtNode.isHidden() gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //gibt true zurück

if(hidden) {

    //einige Aktionen oder Benachrichtigungen ausführen

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methoden ISmartArt.isReversed(), setReversed() wurden hinzugefügt**
Die Eigenschaft com.aspose.slides.ISmartArt.IsReversed ermöglicht das Abrufen bzw. Festlegen des Zustands des SmartArt‑Diagramms hinsichtlich Links‑nach‑Rechts (LTR) oder Rechts‑nach‑Links (RTL), sofern das Diagramm eine Umkehrung unterstützt.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) wurden hinzugefügt**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() und setOrganizationChartLayout(int) ermöglichen das Abrufen bzw. Festlegen des Organisation‑Diagrammtyps, der dem aktuellen Knoten zugeordnet ist.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Eigenschaft IShape.getConnectionSiteCount() wurde hinzugefügt**
Die Eigenschaft com.aspose.slides.getConnectionSiteCount() gibt die Anzahl der Verbindungsstellen an der Form zurück.

``` java
import com.aspose.slides.*;


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

```
### **Kleinere Änderungen**
Dies ist die Liste der kleineren API-Änderungen:

|Enum com.aspose.slides.BevelColorMode|gelöscht, nicht verwendeter Enum|
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode()|gelöscht, nicht verwendete Eigenschaft|
|Method com.aspose.slides.ChartSeriesGroup.getChart()|hinzugefügt|
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|gelöscht|
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle()|gelöscht als veraltet|