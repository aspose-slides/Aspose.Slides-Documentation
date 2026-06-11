---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.4.0
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- podejście dziedziczone
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany niekompatybilne wstecz w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) wprowadzone w API Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Enum OrganizationChartLayoutType został dodany**
Enum com.aspose.slides.OrganizationChartLayoutType reprezentuje typ formatowania węzłów podrzędnych w wykresie organizacyjnym.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() został dodany**
Metoda com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ustawia domyślne, niezerowe przesunięcia dla efektywnego wcięcia akapitu i MarginLeft, gdy wypunktowanie jest włączone (tak jak robi to PowerPoint po włączeniu wypunktowania/ numeracji w akapicie). Jeśli wypunktowanie jest wyłączone, metoda resetuje wcięcie akapitu i MarginLeft (tak jak robi to PowerPoint po wyłączeniu wypunktowania/ numeracji).
### **Method IConnector.reroute() został dodany**
Metoda com.aspose.slides.IConnector.reroute() przekierowuje łącznik tak, aby wybrał najkrótszą możliwą ścieżkę pomiędzy połączonymi kształtami. W tym celu metoda reroute() może zmienić właściwości StartShapeConnectionSiteIndex i EndShapeConnectionSiteIndex.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Method IPresentation.getSlideById(long) został dodany**
Metoda Aspose.Slides.IPresentation.getSlideById(int) zwraca obiekt Slide, MasterSlide lub LayoutSlide na podstawie identyfikatora slajdu.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() został dodany**
Metoda com.aspose.slides.ISmartArt.getNodes() zwraca kolekcję węzłów głównych w obiekcie SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // wybierz drugi węzeł główny

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) został dodany**
Metoda dla właściwości com.aspose.slides.ISmartArt.setLayout(int) została dodana. Umożliwia zmianę typu układu istniejącego diagramu.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() został dodany**
Metoda com.aspose.slides.ISmartArtNode.isHidden() zwraca true, jeśli ten węzeł jest ukryty w modelu danych.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //zwraca true

if(hidden) {

    //wykonaj pewne akcje lub powiadomienia

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() zostały dodane**
Właściwość com.aspose.slides.ISmartArt.IsReversed umożliwia odczyt lub ustawienie stanu diagramu SmartArt względem (od lewej do prawej) LTR lub (od prawej do lewej) RTL, jeśli diagram obsługuje odwrócenie.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) zostały dodane**
Metody com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() i setOrganizationChartLayout(int) umożliwiają odczyt lub ustawienie typu wykresu organizacyjnego powiązanego z bieżącym węzłem.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() został dodany**
Właściwość com.aspose.slides.getConnectionSiteCount() zwraca liczbę miejsc połączeń na kształcie.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Mniejsze zmiany**
Poniżej znajduje się lista drobnych zmian API:

|Enum com.aspose.slides.BevelColorMode |usunięty, nieużywany enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |usunięta, nieużywana właściwość |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |dodano |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |usunięto |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |usunięto jako przestarzałe |