---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 14.9.0
linktitle: Aspose.Slides für Java 14.9.0
type: docs
weight: 80
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Modernes Vorgehen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über Updates der öffentlichen API und kritische Änderungen in Aspose.Slides für Java, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 

Diese Seite listet alle [Hinzugefügt](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) Klassen, Methoden, Eigenschaften usw. sowie neue Einschränkungen und weitere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) auf, die mit der Aspose.Slides for Java 14.9.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Hinzugefügte Methoden zum Ersetzen von Bild durch PPImage, IPPImage**
Neue Methoden hinzugefügt:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Der erste Weg
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Der zweite Weg
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Hinzugefügte Methoden zum Speichern von Folien unter Beibehaltung der Seitenzahlen**
Die folgenden Methoden wurden hinzugefügt:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Diese Methoden ermöglichen das Speichern ausgewählter Präsentationsfolien in den Formaten PDF, XPS, TIFF, HTML. Das Array 'slides' ermöglicht die Angabe von Seitenzahlen, beginnend bei 1.

``` java
// Überladungen zu IPresentation hinzugefügt (SaveFormat-Werte sind int-Konstanten in Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array von Folienpositionen

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Hinzugefügter Enum-Wert SmartArtLayoutType.Custom**
Dieser Typ des SmartArt-Layouts stellt ein Diagramm mit benutzerdefinierter Vorlage dar. Benutzerdefinierte Diagramme können nur aus einer Präsentationsdatei geladen werden und können nicht über die Methode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) erstellt werden.
### **Hinzugefügte Klasse SmartArtShape und Schnittstelle ISmartArtShape**
Die Klasse Aspose.Slides.SmartArt.SmartArtShape (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShape) ermöglichen den Zugriff auf einzelne Formen innerhalb eines SmartArt-Diagramms. SmartArtShape kann verwendet werden, um FillFormat, LineFormat zu ändern, Hyperlinks hinzuzufügen usw.

{{% alert color="info" %}} 

SmartArtShape unterstützt die IShape-Eigenschaften RawFrame, Frame, Rotation, X, Y, Width, Height nicht und wirft eine System.NotSupportedException, wenn versucht wird, auf sie zuzugreifen.

{{% /alert %}} 

Beispiel für die Verwendung:

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Hinzugefügte Klasse SmartArtShapeCollection, Schnittstelle ISmartArtShapeCollection und Methode ISmartArtNode.getShapes()**
Die Klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (und ihre Schnittstelle Aspose.Slides.SmartArt.ISmartArtShapeCollection) ermöglichen den Zugriff auf einzelne Formen innerhalb eines SmartArt-Diagramms. Die Sammlung enthält Formen, die mit einem SmartArtNode verbunden sind. Die Eigenschaft SmartArtNode.Shapes gibt die Sammlungen aller mit dem Knoten verbundenen Formen zurück.

{{% alert color="info" %}} 

Abhängig vom SmartArtLayoutType kann eine SmartArtShape zwischen mehreren Knoten geteilt werden.

{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```