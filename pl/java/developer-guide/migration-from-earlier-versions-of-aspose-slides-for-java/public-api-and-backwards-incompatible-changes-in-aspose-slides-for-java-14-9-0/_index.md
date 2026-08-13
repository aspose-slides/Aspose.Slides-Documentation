---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 14.9.0
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- dziedziczny sposób
- nowoczesny sposób
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}}

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) klasy, metody, właściwości i tak dalej, wszystkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) wprowadzone w API Aspose.Slides for Java 14.9.0.

{{% /alert %}}

## **Zmiany publicznego API**
### **Dodane metody do zastąpienia obrazu PPImage, IPPImage**
Dodano nowe metody:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Pierwszy sposób
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Drugi sposób
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Dodane metody zapisywania slajdów z zachowaniem numerów stron**
Dodano następujące metody:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Te metody pozwalają zapisać wybrane slajdy prezentacji w formatach PDF, XPS, TIFF, HTML. Tablica 'slides' umożliwia określenie numerów stron, począwszy od 1.

``` java
// Przeciążenia dodane do IPresentation (wartości SaveFormat są stałymi typu int w Javie):
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
    int[] slides = new int[] { 2, 3, 5 }; // Tablica pozycji slajdów

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Dodano wartość wyliczenia SmartArtLayoutType.Custom**
Ten typ układu SmartArt reprezentuje diagram z własnym szablonem. Niestandardowe diagramy mogą być wczytywane tylko z pliku prezentacji i nie mogą być tworzone metodą ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Dodano klasę SmartArtShape i interfejs ISmartArtShape**
Klasa Aspose.Slides.SmartArt.SmartArtShape (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShape) zapewnia dostęp do poszczególnych kształtów wewnątrz diagramu SmartArt. SmartArtShape może być używana do zmiany FillFormat, LineFormat, dodawania hiperłączy itp.

{{% alert color="info" %}}

SmartArtShape nie obsługuje właściwości IShape: RawFrame, Frame, Rotation, X, Y, Width, Height i rzuca System.NotSupportedException przy próbie ich użycia.

{{% /alert %}}

Przykład użycia:

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
### **Dodano klasę SmartArtShapeCollection, interfejs ISmartArtShapeCollection oraz metodę ISmartArtNode.getShapes()**
Klasa Aspose.Slides.SmartArt.SmartArtShapeCollection (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShapeCollection) zapewnia dostęp do poszczególnych kształtów w diagramie SmartArt. Kolekcja zawiera kształty powiązane z SmartArtNode. Właściwość SmartArtNode.Shapes zwraca kolekcję wszystkich kształtów powiązanych z węzłem.

{{% alert color="info" %}}

W zależności od SmartArtLayoutType jeden SmartArtShape może być współdzielony przez kilka węzłów.

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