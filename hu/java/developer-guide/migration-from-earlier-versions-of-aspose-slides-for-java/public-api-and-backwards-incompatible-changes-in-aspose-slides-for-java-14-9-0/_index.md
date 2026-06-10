---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.9.0-ban
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) , amelyeket az Aspose.Slides for Java 14.9.0 API vezet be.

{{% /alert %}} 
## **Publikus API változások**
### **PPImage-re, IPPImage-re kép cseréjéhez hozzáadott metódusok**
Új hozzáadott metódusok:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Az első mód

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//A második mód

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Diák oldalszám megtartásával mentéséhez hozzáadott metódusok**
A következő metódusok lettek hozzáadva:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ezek a metódusok lehetővé teszik a megadott prezentációs dia PDF, XPS, TIFF, HTML formátumban történő mentését. A ‘slides’ tömb a diák oldalszámának megadását teszi lehetővé, 1‑től kezdve.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Dia pozíciók tömbje

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **A SmartArtLayoutType.Custom enum érték hozzáadva**
Ez a SmartArt elrendezéstípus egy egyedi sablonú diagramot képvisel. Az egyedi diagramok csak prezentációs fájlból tölthetők be, és nem hozhatók létre a ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) metódussal.
### **A SmartArtShape osztály és az ISmartArtShape interfész hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShape osztály (és annak Aspose.Slides.SmartArt.ISmartArtShape interfésze) hozzáférést biztosít a SmartArt diagram egyes alakzataihoz. A SmartArtShape használható a FillFormat, LineFormat módosítására, hiperhivatkozások hozzáadására stb.

{{% alert color="primary" %}} 

A SmartArtShape nem támogatja az IShape tulajdonságokat RawFrame, Frame, Rotation, X, Y, Width, Height, és System.NotSupportedException kivételt dob, ha megkísérlik elérni őket.

{{% /alert %}} 

Használati példa:

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
### **A SmartArtShapeCollection osztály, az ISmartArtShapeCollection interfész és az ISmartArtNode.getShapes() metódus hozzáadva**
Az Aspose.Slides.SmartArt.SmartArtShapeCollection osztály (és annak Aspose.Slides.SmartArt.ISmartArtShapeCollection interfésze) hozzáférést biztosít a SmartArt diagram egyes alakzataihoz. A gyűjtemény a SmartArtNode-hoz kapcsolódó alakzatokat tartalmazza. A SmartArtNode.Shapes tulajdonság visszaadja a csomóponthoz tartozó összes alakzat gyűjteményét.

{{% alert color="primary" %}} 

A SmartArtLayoutType-tól függően egy SmartArtShape több csomópont között is megosztható.

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