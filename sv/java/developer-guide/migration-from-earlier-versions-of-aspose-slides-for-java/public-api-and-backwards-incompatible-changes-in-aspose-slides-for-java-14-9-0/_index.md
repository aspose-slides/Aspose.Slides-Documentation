---
title: Offentligt API och bakåt oförenliga ändringar i Aspose.Slides för Java 14.9.0
linktitle: Aspose.Slides för Java 14.9.0
type: docs
weight: 80
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migrering
- gammalkod
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
{{% alert color="info" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) som införts med Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **Offentliga API-förändringar**
### **Tillagda metoder för att ersätta bild till PPImage, IPPImage**
Nya metoder har lagts till:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Det första sättet
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Det andra sättet
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Tillagda metoder för att spara bilder med sidnummer**
Följande metoder har lagts till:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Dessa metoder tillåter att spara angivna presentationsbilder till PDF, XPS, TIFF, HTML-format. 'slides'-arrayen gör det möjligt att ange sidnummer, med början från 1.

``` java
// Överlagringar tillagda till IPresentation (SaveFormat‑värden är int‑konstanter i Java):
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
    int[] slides = new int[] { 2, 3, 5 }; // Array av bildpositioner

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Tillagt SmartArtLayoutType.Custom enum‑värde**
Denna typ av SmartArt‑layout representerar diagram med en anpassad mall. Anpassade diagram kan endast läsas in från presentationsfil och kan inte skapas via metoden ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Tillagd SmartArtShape‑klass och ISmartArtShape‑gränssnitt**
Klassen Aspose.Slides.SmartArt.SmartArtShape (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShape) ger åtkomst till enskilda former i ett SmartArt‑diagram. SmartArtShape kan användas för att ändra FillFormat, LineFormat, lägga till hyperlänkar etc.

{{% alert color="info" %}} 

SmartArtShape stödjer inte IShape‑egenskaperna RawFrame, Frame, Rotation, X, Y, Width, Height och kastar System.NotSupportedException vid försök att komma åt dem.

{{% /alert %}} 

Exempel på användning:

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
### **SmartArtShapeCollection‑klass, ISmartArtShapeCollection‑gränssnitt och ISmartArtNode.getShapes()-metod har lagts till**
Klassen Aspose.Slides.SmartArt.SmartArtShapeCollection (och dess gränssnitt Aspose.Slides.SmartArt.ISmartArtShapeCollection) ger åtkomst till enskilda former i ett SmartArt‑diagram. Samlingen innehåller former som är associerade med SmartArtNode. Egenskapen SmartArtNode.Shapes returnerar samlingar av alla former som är kopplade till noden.

{{% alert color="info" %}} 

Beroende på SmartArtLayoutType kan en SmartArtShape delas mellan flera noder.

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