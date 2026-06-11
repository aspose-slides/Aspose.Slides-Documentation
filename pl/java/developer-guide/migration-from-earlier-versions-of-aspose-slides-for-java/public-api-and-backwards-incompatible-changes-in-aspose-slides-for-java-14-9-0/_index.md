---
title: Publiczny interfejs API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 14.9.0
linktitle: Aspose.Slides dla Java 14.9.0
type: docs
weight: 80
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migracja
- kod starego systemu
- nowoczesny kod
- stare podejście
- nowe podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: Przegląd aktualizacji publicznego API oraz zmian łamiących kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint (PPT, PPTX) i ODP.
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) wprowadzone w API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Zmiany publicznego API**
### **Dodane metody do zastępowania obrazu na PPImage, IPPImage**
Dodano nowe metody:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Pierwszy sposób

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Drugi sposób

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Dodane metody zapisywania slajdów z zachowaniem numerów stron**
Dodano następujące metody:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Te metody umożliwiają zapisanie wybranych slajdów prezentacji w formatach PDF, XPS, TIFF, HTML. Tablica 'slides' pozwala określić numery stron, począwszy od 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Tablica pozycji slajdów

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Dodano wartość enum SmartArtLayoutType.Custom**
Ten typ układu SmartArt reprezentuje diagram z niestandardowym szablonem. Niestandardowe diagramy mogą być ładowane wyłącznie z pliku prezentacji i nie mogą być tworzone za pomocą metody ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)

### **Dodano klasę SmartArtShape i interfejs ISmartArtShape**
Klasa Aspose.Slides.SmartArt.SmartArtShape (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShape) zapewnia dostęp do poszczególnych kształtów w diagramie SmartArt. SmartArtShape może być używany do zmiany FillFormat, LineFormat, dodawania hiperłączy itp.

{{% alert color="primary" %}} 

SmartArtShape nie obsługuje właściwości IShape: RawFrame, Frame, Rotation, X, Y, Width, Height i zgłasza System.NotSupportedException przy próbie ich użycia.

{{% /alert %}} 

Przykład użycia:

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
### **Dodano klasę SmartArtShapeCollection, interfejs ISmartArtShapeCollection oraz metodę ISmartArtNode.getShapes()**
Klasa Aspose.Slides.SmartArt.SmartArtShapeCollection (oraz jej interfejs Aspose.Slides.SmartArt.ISmartArtShapeCollection) zapewnia dostęp do poszczególnych kształtów w diagramie SmartArt. Kolekcja zawiera kształty powiązane z SmartArtNode. Właściwość SmartArtNode.Shapes zwraca kolekcję wszystkich kształtów powiązanych z węzłem.

{{% alert color="primary" %}} 

W zależności od SmartArtLayoutType jeden SmartArtShape może być współdzielony przez kilka węzłów.

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