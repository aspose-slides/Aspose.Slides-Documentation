---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 14.9.0
linktitle: Aspose.Slides pro Java 14.9.0
type: docs
weight: 80
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro Java a snadno migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) třídy, metody, vlastnosti a podobně, jakékoli nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) zavedené v API Aspose.Slides pro Java 14.9.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Přidané metody pro nahrazení obrázku na PPImage, IPPImage**
Nové metody byly přidány:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // První způsob
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Druhý způsob
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Přidané metody pro ukládání snímků se zachováním čísel stránek**
Byly přidány následující metody:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Tyto metody umožňují uložit určené snímky prezentace do formátů PDF, XPS, TIFF, HTML. Pole 'slides' umožňuje specifikovat čísla stránek, počínaje 1.

``` java
// Přetížení přidána do IPresentation (hodnoty SaveFormat jsou v Javě celočíselné konstanty):
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
    int[] slides = new int[] { 2, 3, 5 }; // Pole pozic snímků

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Přidána hodnota výčtu SmartArtLayoutType.Custom**
Tento typ uspořádání SmartArt představuje diagram s vlastní šablonou. Vlastní diagramy lze načíst pouze ze souboru prezentace a nelze je vytvořit metodou ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Přidána třída SmartArtShape a rozhraní ISmartArtShape**
Třída Aspose.Slides.SmartArt.SmartArtShape (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShape) poskytuje přístup k jednotlivým tvarům uvnitř diagramu SmartArt. SmartArtShape lze použít ke změně FillFormat, LineFormat, přidávání Hyperlinků apod.

{{% alert color="info" %}} 

SmartArtShape nepodporuje vlastnosti IShape RawFrame, Frame, Rotation, X, Y, Width, Height a při pokusu o jejich přístup vyhodí System.NotSupportedException.

{{% /alert %}} 

Příklad použití:

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
### **Přidána třída SmartArtShapeCollection, rozhraní ISmartArtShapeCollection a metoda ISmartArtNode.getShapes()**
Třída Aspose.Slides.SmartArt.SmartArtShapeCollection (a její rozhraní Aspose.Slides.SmartArt.ISmartArtShapeCollection) poskytuje přístup k jednotlivým tvarům uvnitř diagramu SmartArt. Kolekce obsahuje tvary přiřazené k SmartArtNode. Vlastnost SmartArtNode.Shapes vrací kolekce všech tvarů přiřazených k uzlu.

{{% alert color="info" %}} 

V závislosti na SmartArtLayoutType může být jeden SmartArtShape sdílen mezi několika uzly.

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