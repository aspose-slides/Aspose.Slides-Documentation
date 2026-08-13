---
title: Publikus API és visszafelé inkompatibilis változások az Aspose.Slides for Java 14.9.0-ban
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseket és a visszafordíthatatlan változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) osztályt, metódust, tulajdonságot stb., valamint az új korlátozásokat és egyéb [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) amelyeket az Aspose.Slides for Java 14.9.0 API vezet be.

{{% /alert %}} 
## **Publikus API Változások**
### **Hozzáadott metódusok a kép PPImage‑re, IPPImage‑re cseréléséhez**
Új metódusok:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Az első mód
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // A második mód
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Hozzáadott metódusok a diák oldal számok megtartásával történő mentéséhez**
A következő metódusok lettek hozzáadva:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ezek a metódusok lehetővé teszik a megadott prezentációs diák PDF, XPS, TIFF, HTML formátumba történő mentését. A “slides” tömb segítségével oldal számokat lehet megadni, 1‑től kezdve.

``` java
// Az IPresentation-hez hozzáadott túlterhelések (a SaveFormat értékek int állandók Java-ban):
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
    int[] slides = new int[] { 2, 3, 5 }; // Diák pozícióinak tömbje

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Hozzáadott a SmartArtLayoutType.Custom enum érték**
Ez a SmartArt elrendezéstípus egy egyedi sablonnal rendelkező diagramot jelöl. Az egyedi diagramok csak prezentációs fájlból tölthetők be, és nem hozhatók létre a ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) metódussal.

### **Hozzáadott a SmartArtShape osztály és az ISmartArtShape interfész**
Az Aspose.Slides.SmartArt.SmartArtShape osztály (és annak Aspose.Slides.SmartArt.ISmartArtShape interfésze) hozzáférést biztosít a SmartArt diagram egyedi alakzataihoz. A SmartArtShape használható a FillFormat, LineFormat módosítására, hiperhivatkozások hozzáadására stb.

{{% alert color="info" %}} 

A SmartArtShape nem támogatja az IShape tulajdonságokat RawFrame, Frame, Rotation, X, Y, Width, Height, és System.NotSupportedException kivételt dob, ha ezekhez hozzáférni próbál.

{{% /alert %}} 

Használati példa:

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
### **Hozzáadott a SmartArtShapeCollection osztály, az ISmartArtShapeCollection interfész és az ISmartArtNode.getShapes() metódus**
Az Aspose.Slides.SmartArt.SmartArtShapeCollection osztály (és annak Aspose.Slides.SmartArt.ISmartArtShapeCollection interfésze) hozzáférést biztosít a SmartArt diagram egyedi alakzataihoz. A gyűjtemény a SmartArtNode‑hoz rendelt alakzatokat tartalmazza. A SmartArtNode.Shapes tulajdonság visszaadja az adott csomóponthoz tartozó összes alakzat gyűjteményét.

{{% alert color="info" %}} 

A SmartArtLayoutType‑tól függően egy SmartArtShape több csomópont között is megosztható.

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