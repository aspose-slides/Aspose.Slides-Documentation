---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.9.0
type: docs
weight: 80
url: /de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) Klassen, Methoden, Eigenschaften usw. auf, sowie alle neuen Einschränkungen und andere [Änderungen](/slides/de/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) die mit der API von Aspose.Slides für PHP über Java 14.9.0 eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Hinzugefügte Methoden zum Ersetzen von Bildern in PPImage, IPPImage**
Neue Methoden hinzugefügt:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # Die erste Methode
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # Die zweite Methode
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **Hinzugefügte Methoden zum Speichern von Folien unter Beibehaltung der Seitennummern**
Die folgenden Methoden wurden hinzugefügt:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen es, die angegebenen Präsentationsfolien in PDF-, XPS-, TIFF- und HTML-Formate zu speichern. Das Array 'slides' ermöglicht es, Seitennummern anzugeben, beginnend mit 1.

```php
  save($string, $slides, SaveFormat);

```

```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// Array der Folienpositionen

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **Enum-Wert SmartArtLayoutType::Custom hinzugefügt**
Dieser Typ von SmartArt-Layout stellt ein Diagramm mit benutzerdefiniertem Template dar. Benutzerdefinierte Diagramme können nur aus der Präsentationsdatei geladen und nicht über die Methode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom) erstellt werden.
### **Die Klasse SmartArtShape und die Schnittstelle ISmartArtShape hinzugefügt**
Die Aspose.Slides.SmartArt.SmartArtShape-Klasse (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShape) ermöglichen den Zugriff auf einzelne Formen innerhalb des SmartArt-Diagramms. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen usw.

{{% alert color="primary" %}} 

SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und löst eine System.NotSupportedException aus, wenn versucht wird, auf sie zuzugreifen.

{{% /alert %}} 

Beispiel für die Verwendung:

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Die SmartArtShapeCollection-Klasse, die ISmartArtShapeCollection-Schnittstelle und die Methode ISmartArtNode.getShapes() wurden hinzugefügt**
Die Aspose.Slides.SmartArt.SmartArtShapeCollection-Klasse (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglicht den Zugriff auf einzelne Formen innerhalb des SmartArt-Diagramms. Die Sammlung enthält Formen, die mit SmartArtNode verknüpft sind. Die Eigenschaft SmartArtNode.Shapes gibt Sammlungen aller mit dem Knoten verknüpften Formen zurück.

{{% alert color="primary" %}} 

Je nach SmartArtLayoutType kann ein SmartArtShape zwischen mehreren Knoten geteilt werden.

{{% /alert %}} 

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```