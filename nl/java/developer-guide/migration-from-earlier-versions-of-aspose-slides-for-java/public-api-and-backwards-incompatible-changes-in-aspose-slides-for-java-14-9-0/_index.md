---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides for Java 14.9.0
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migratie
- legacy-code
- moderne-code
- legacy-aanpak
- moderne-aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API‑updates en doorbrekende wijzigingen in Aspose.Slides for Java om uw PowerPoint‑PPT, PPTX‑ en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [Toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) klassen, methoden, eigenschappen enz., eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) geïntroduceerd met de Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
### **Toegevoegde methoden voor het vervangen van afbeelding door PPImage, IPPImage**
Nieuwe methoden toegevoegd:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//De eerste manier

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//De tweede manier

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Toegevoegde methoden voor het opslaan van dia's met paginanummers**
De volgende methoden zijn toegevoegd:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Deze methoden maken het mogelijk om opgegeven dia’s van een presentatie op te slaan naar PDF-, XPS-, TIFF- of HTML-formaten. Het array‑element **slides** stelt paginanummers in, beginnend bij 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Array van dia‑posities
presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Toegevoegde enumwaarde SmartArtLayoutType.Custom**
Dit type SmartArt‑lay‑out vertegenwoordigt een diagram met een aangepast sjabloon. Aangepaste diagrammen kunnen alleen worden geladen uit een presentatiebestand en kunnen niet worden aangemaakt via de methode `ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)`.

### **Toegevoegde SmartArtShape‑klasse en ISmartArtShape‑interface**
De `Aspose.Slides.SmartArt.SmartArtShape`‑klasse (en haar interface `Aspose.Slides.SmartArt.ISmartArtShape`) biedt toegang tot individuele vormen binnen een SmartArt‑diagram. Met `SmartArtShape` kun je onder andere `FillFormat`, `LineFormat` wijzigen en hyperlinks toevoegen.

{{% alert color="primary" %}} 

SmartArtShape ondersteunt de IShape‑eigenschappen `RawFrame`, `Frame`, `Rotation`, `X`, `Y`, `Width`, `Height` niet en werpt een `System.NotSupportedException` wanneer geprobeerd wordt ze te benaderen.

{{% /alert %}} 

Voorbeeld van gebruik:

``` java

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
### **Toegevoegde SmartArtShapeCollection‑klasse, ISmartArtShapeCollection‑interface en ISmartArtNode.getShapes()‑methode**
De `Aspose.Slides.SmartArt.SmartArtShapeCollection`‑klasse (en haar interface `Aspose.Slides.SmartArt.ISmartArtShapeCollection`) biedt toegang tot individuele vormen binnen een SmartArt‑diagram. De collectie bevat vormen die gekoppeld zijn aan een `SmartArtNode`. De eigenschap `SmartArtNode.Shapes` retourneert collecties van alle vormen die bij het knooppunt horen.

{{% alert color="primary" %}} 

Afhankelijk van `SmartArtLayoutType` kan één `SmartArtShape` gedeeld worden door meerdere knooppunten.

{{% /alert %}} 

 

``` java

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