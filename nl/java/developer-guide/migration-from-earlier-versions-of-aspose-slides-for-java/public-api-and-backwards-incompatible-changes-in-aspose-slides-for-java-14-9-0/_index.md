---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 14.9.0
linktitle: Aspose.Slides voor Java 14.9.0
type: docs
weight: 80
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en breaking changes in Aspose.Slides for Java om uw PowerPoint PPT, PPTX en ODP presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle toegevoegde klassen, methoden, eigenschappen en dergelijke, eventuele nieuwe beperkingen en andere [changes](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) geïntroduceerd met de Aspose.Slides for Java 14.9.0 API.
{{% /alert %}} 
## **Openbare API-wijzigingen**
### **Toegevoegde methoden voor het vervangen van afbeelding naar PPImage, IPPImage**
Nieuwe methoden toegevoegd:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // De eerste manier
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // De tweede manier
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Toegevoegde methoden voor het opslaan van dia's met behoud van paginanummers**
De volgende methoden zijn toegevoegd:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Deze methoden maken het mogelijk om opgegeven presentatie‑dia's op te slaan naar PDF, XPS, TIFF en HTML‑formaten. Het ‘slides’-array maakt het mogelijk om paginanummers op te geven, beginnend bij 1.

``` java
// Overloads toegevoegd aan IPresentation (SaveFormat-waarden zijn int-constanten in Java):
//
void save(String fname, int[] slides, int format);
void save(String fname, int[] slides, int format, ISaveOptions options);
void save(OutputStream stream, int[] slides, int format);
void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array van dia posities

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Toegevoegde enumwaarde SmartArtLayoutType.Custom**
Dit type SmartArt‑indeling representeert een diagram met een aangepast sjabloon. Aangepaste diagrammen kunnen alleen geladen worden uit een presentatiebestand en kunnen niet worden aangemaakt via de methode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Toegevoegde SmartArtShape‑klasse en ISmartArtShape‑interface**
De klasse Aspose.Slides.SmartArt.SmartArtShape (en de bijbehorende interface Aspose.Slides.SmartArt.ISmartArtShape) biedt toegang tot individuele vormen binnen een SmartArt‑diagram. SmartArtShape kan gebruikt worden om FillFormat, LineFormat, hyperlinks toe te voegen, enz.

{{% alert color="info" %}} 
SmartArtShape ondersteunt de IShape‑eigenschappen RawFrame, Frame, Rotation, X, Y, Width, Height niet en gooit een System.NotSupportedException wanneer geprobeerd wordt deze te benaderen.
{{% /alert %}} 

Voorbeeld van gebruik:

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
### **SmartArtShapeCollection‑klasse, ISmartArtShapeCollection‑interface en ISmartArtNode.getShapes‑methode zijn toegevoegd**
De klasse Aspose.Slides.SmartArt.SmartArtShapeCollection (en de bijbehorende interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) biedt toegang tot individuele vormen binnen een SmartArt‑diagram. De collectie bevat vormen die gekoppeld zijn aan een SmartArtNode. De eigenschap SmartArtNode.Shapes retourneert collecties van alle vormen die aan het node zijn gekoppeld.

{{% alert color="info" %}} 
Afhankelijk van SmartArtLayoutType kan één SmartArtShape gedeeld worden tussen meerdere nodes.
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