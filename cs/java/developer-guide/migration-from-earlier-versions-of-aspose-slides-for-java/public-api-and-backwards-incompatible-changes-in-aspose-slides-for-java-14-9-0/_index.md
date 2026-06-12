---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 14.9.0
linktitle: Aspose.Slides pro Java 14.9.0
type: docs
weight: 80
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro Java a snadno migrujte svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Na této stránce jsou uvedeny všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) třídy, metody, vlastnosti a podobně, jakékoli nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) zavedené s API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Veřejné změny API**
### **Přidané metody pro nahrazení obrázku na PPImage, IPPImage**
Nové metody byly přidány:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//První způsob

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Druhý způsob

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Přidané metody pro ukládání snímků s zachováním čísel stránek**
Byly přidány následující metody:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Tyto metody umožňují uložit určené snímky prezentace do formátů PDF, XPS, TIFF, HTML. Pole 'slides' umožňuje zadat čísla stránek, počínaje od 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Pole pozic snímků

presentation.save(outFileName, slides, SaveFormat.Pdf);
```
### **Přidána hodnota enum SmartArtLayoutType.Custom**
Tento typ rozvržení SmartArt představuje diagram s vlastním šablonou. Vlastní diagramy lze načíst pouze ze souboru prezentace a nelze je vytvořit pomocí metody ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)

### **Přidána třída SmartArtShape a rozhraní ISmartArtShape**
Třída Aspose.Slides.SmartArt.SmartArtShape (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShape) poskytuje přístup k jednotlivým tvarům uvnitř diagramu SmartArt. SmartArtShape lze použít ke změně FillFormat, LineFormat, přidávání hypertextových odkazů apod.

{{% alert color="primary" %}} 

SmartArtShape nepodporuje vlastnosti IShape RawFrame, Frame, Rotation, X, Y, Width, Height a při pokusu o jejich přístup vyhodí System.NotSupportedException.

{{% /alert %}} 

Příklad použití:

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
### **Přidána třída SmartArtShapeCollection, rozhraní ISmartArtShapeCollection a metoda ISmartArtNode.getShapes()**
Třída Aspose.Slides.SmartArt.SmartArtShapeCollection (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShapeCollection) poskytuje přístup k jednotlivým tvarům uvnitř diagramu SmartArt. Kolekce obsahuje tvary spojené s objektem SmartArtNode. Vlastnost SmartArtNode.Shapes vrací kolekce všech tvarů spojených s uzlem.

{{% alert color="primary" %}} 

V závislosti na SmartArtLayoutType může být jeden SmartArtShape sdílen mezi několika uzly.

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