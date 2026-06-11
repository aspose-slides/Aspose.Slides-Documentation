---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för Java 14.9.0
linktitle: Aspose.Slides för Java 14.9.0
type: docs
weight: 80
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) klasser, metoder, egenskaper och så vidare, eventuella nya restriktioner och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) som introducerats med Aspose.Slides för Java 14.9.0 API.

{{% /alert %}} 
## **Offentliga API-förändringar**
### **Tillagda metoder för att ersätta bild till PPImage, IPPImage**
Nya metoder tillagda:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Det första sättet

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Det andra sättet

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Tillagda metoder för att spara bilder med bibehållna sidnummer**
Följande metoder har lagts till:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Dessa metoder tillåter att spara angivna presentationsbilder till PDF-, XPS-, TIFF- och HTML-format. 'slides'-arrayen tillåter att ange sidnummer, med start från 1.

``` java

 save(string fname, int[] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array av bildpositioner

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Tillagt enum‑värde SmartArtLayoutType.Custom**
Denna typ av SmartArt‑layout representerar ett diagram med anpassad mall. Anpassade diagram kan endast laddas från presentationsfil och kan inte skapas via metoden ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Tillagd SmartArtShape-klass och ISmartArtShape‑gränssnitt**
Klassen Aspose.Slides.SmartArt.SmartArtShape (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShape) ger åtkomst till enskilda former i ett SmartArt‑diagram. SmartArtShape kan användas för att ändra FillFormat, LineFormat, lägga till hyperlänkar osv.

{{% alert color="primary" %}} 

SmartArtShape stöder inte IShape‑egenskaperna RawFrame, Frame, Rotation, X, Y, Width, Height och kastar System.NotSupportedException när man försöker komma åt dem.

{{% /alert %}} 

Exempel på användning:

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
### **SmartArtShapeCollection-klass, ISmartArtShapeCollection‑gränssnitt och ISmartArtNode.getShapes()-metod har lagts till**
Klassen Aspose.Slides.SmartArt.SmartArtShapeCollection (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShapeCollection) ger åtkomst till enskilda former i ett SmartArt‑diagram. Samlingen innehåller former som är associerade med en SmartArtNode. Egenskapen SmartArtNode.Shapes returnerar samlingar av alla former som är kopplade till noden.

{{% alert color="primary" %}} 

Beroende på SmartArtLayoutType kan en SmartArtShape delas mellan flera noder.

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