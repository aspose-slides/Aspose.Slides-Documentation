---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 14.9.0
type: docs
weight: 80
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) Klassen, Methoden, Eigenschaften usw. sowie alle neuen Einschränkungen und andere [Änderungen](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) auf, die mit der Aspose.Slides für Java 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Hinzugefügte Methoden zum Ersetzen von Bild zu PPImage, IPPImage**
Neue Methoden hinzugefügt:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Präsentation presentation = new Präsentation("presentation.pptx");

//Die erste Methode

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Die zweite Methode

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Hinzugefügte Methoden zum Speichern von Folien unter Beibehaltung der Seitenzahlen**
Die folgenden Methoden wurden hinzugefügt:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen das Speichern der angegebenen Präsentationsfolien in den Formaten PDF, XPS, TIFF, HTML. Das 'slides'-Array ermöglicht die Angabe von Seitenzahlen, beginnend bei 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Präsentation presentation = new Präsentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array von Folienpositionen

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Hinzugefügt der SmartArtLayoutType.Custom Enum-Wert**
Dieser Typ des SmartArt-Layouts repräsentiert ein Diagramm mit einer benutzerdefinierten Vorlage. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen und können nicht über die Methode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
### **Hinzugefügt die SmartArtShape-Klasse und das ISmartArtShape-Interface**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShape) ermöglicht den Zugriff auf individuelle Formen innerhalb des SmartArt-Diagramms. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen usw.

{{% alert color="primary" %}} 

SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und wirft System.NotSupportedException, wenn versucht wird, darauf zuzugreifen.

{{% /alert %}} 

Beispiel für die Verwendung:

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Die SmartArtShapeCollection-Klasse, das ISmartArtShapeCollection-Interface und die ISmartArtNode.getShapes()-Methode wurden hinzugefügt**
Die Klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (und ihr Interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglicht den Zugriff auf individuelle Formen innerhalb des SmartArt-Diagramms. Die Sammlung enthält Formen, die mit SmartArtNode verbunden sind. Die Eigenschaft SmartArtNode.Shapes gibt Sammlungen aller mit dem Knoten verbundenen Formen zurück.

{{% alert color="primary" %}} 

Abhängig von SmartArtLayoutType kann eine SmartArtShape zwischen mehreren Knoten geteilt werden.

{{% /alert %}} 

﻿

``` java

 Präsentation pres = new Präsentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```