---
title: Öffentliche API und Abwärtsinkompatible Änderungen in Aspose.Slides für PHP über Java 15.4.0
type: docs
weight: 120
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) Klassen, Methoden, Eigenschaften und so weiter, sowie neue Einschränkungen und andere [Änderungen](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) auf, die mit der Aspose.Slides für PHP über Java 15.4.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Enum OrganizationChartLayoutType wurde hinzugefügt**
Das com.aspose.slides.OrganizationChartLayoutType Enum stellt den Formatierungstyp der Kindknoten in einem Organigramm dar.
### **Methode IBulletFormat.applyDefaultParagraphIndentsShifts() wurde hinzugefügt**
Die Methode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts setzt Standardverschiebungen ungleich Null für den effektiven Absatzeinzug und MarginLeft, wenn Aufzählungszeichen aktiviert sind (wie PowerPoint es tut, wenn Aufzählungszeichen/Nummerierung aktiviert sind). Wenn Aufzählungszeichen deaktiviert sind, setzt sie einfach den Absatzeinzug und MarginLeft zurück (wie PowerPoint es tut, wenn Aufzählungszeichen/Nummerierung deaktiviert sind).
### **Methode IConnector.reroute() wurde hinzugefügt**
Die Methode com.aspose.slides.IConnector.reroute() leitet den Connector so um, dass er den kürzest möglichen Weg zwischen den verbundenen Formen nimmt. Um dies zu tun, kann die reroute()-Methode den StartShapeConnectionSiteIndex und EndShapeConnectionSiteIndex ändern.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **Methode IPresentation.getSlideById(long) wurde hinzugefügt**
Die Methode Aspose.Slides.IPresentation.getSlideById(int) gibt einen Slide, MasterSlide oder LayoutSlide anhand der Slide-ID zurück.

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);

```
### **Methode ISmartArt.getNodes() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArt.getNodes() gibt eine Sammlung von Wurzknoten im SmartArt-Objekt zurück.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// wähle den zweiten Wurzknoten

  $node->getTextFrame()->setText("Zweiter Wurzknoten");
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Methode ISmartArt.setLayout(int) wurde hinzugefügt**
Die Methode für die Eigenschaft com.aspose.slides.ISmartArt.setLayout(int) wurde hinzugefügt. Sie erlaubt das Ändern des Layouttyps eines bestehenden Diagramms.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Methode ISmartArtNode.isHidden() wurde hinzugefügt**
Die Methode com.aspose.slides.ISmartArtNode.isHidden() gibt true zurück, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// gibt true zurück

  if ($hidden) {
    # führe einige Aktionen oder Benachrichtigungen aus
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);

```
### **Methoden ISmartArt.isReversed(), setReserved() wurden hinzugefügt**
Die Eigenschaft com.aspose.slides.ISmartArt.IsReversed erlaubt das Abrufen oder Setzen des Zustands des SmartArt-Diagramms in Bezug auf (von links nach rechts) LTR oder (von rechts nach links) RTL, falls das Diagramm eine Umkehrung unterstützt.

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);

```
### **Methoden ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) wurden hinzugefügt**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) erlauben das Abrufen oder Setzen des mit dem aktuellen Knoten verbundenen Organigrammtyps.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Eigenschaft IShape.getConnectionSiteCount() wurde hinzugefügt**
Die Eigenschaft com.aspose.slides.getConnectionSiteCount() gibt die Anzahl der Verbindungspunkte an der Form zurück.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **Kleinere Änderungen**
Dies ist die Liste der kleineren API-Änderungen:

|Enum com.aspose.slides.BevelColorMode |gelöscht, ungenutztes enum |
| :- | :- |
|Methode ThreeDFormatEffectiveData.getBevelColorMode() |gelöscht, ungenutzte Eigenschaft |
|Methode com.aspose.slides.ChartSeriesGroup.getChart() |hinzugefügt |
|Vererbung von IParagraphFormatEffectiveData von ISlideComponent <br>Vererbung von IThreeDFormat von ISlideComponent |gelöscht |
|Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Methode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |als veraltet gelöscht |