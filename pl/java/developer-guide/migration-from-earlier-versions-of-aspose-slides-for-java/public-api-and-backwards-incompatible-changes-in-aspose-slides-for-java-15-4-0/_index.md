---
title: Publiczne API oraz zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.4.0
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zapoznaj się z aktualizacjami publicznego API i zmianami niekompatybilnymi w Aspose.Slides for Java, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint (PPT, PPTX) oraz ODP."
---
{{% alert color="info" %}} 

Ta strona listuje wszystkie [added](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [changes](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) wprowadzone w API Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Enum OrganizationChartLayoutType został dodany**
Enum com.aspose.slides.OrganizationChartLayoutType reprezentuje typ formatowania węzłów potomnych w diagramie organizacyjnym.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() został dodany**
Metoda com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ustawia domyślne, niezerowe przesunięcia dla efektywnego wcięcia akapitu (Indent) i lewego marginesu (MarginLeft), gdy włączone są wypunktowania (tak, jak robi to PowerPoint po włączeniu wypunktowań/umerzeń w akapicie). Jeśli wypunktowania są wyłączone, metoda po prostu resetuje wcięcie akapitu i lewy margines (tak, jak robi to PowerPoint po wyłączeniu wypunktowań/umerzeń w akapicie).
### **Method IConnector.reroute() został dodany**
Metoda com.aspose.slides.IConnector.reroute() przekierowuje łącznik tak, aby przyjął najkrótszą możliwą ścieżkę pomiędzy kształtami, które łączy. W tym celu metoda reroute() może zmienić wartości StartShapeConnectionSiteIndex oraz EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


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
Metoda Aspose.Slides.IPresentation.getSlideById(long) zwraca obiekt Slide, MasterSlide lub LayoutSlide na podstawie identyfikatora slajdu.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() został dodany**
Metoda com.aspose.slides.ISmartArt.getNodes() zwraca kolekcję węzłów głównych w obiekcie SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // wybierz drugi węzeł główny

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) został dodany**
Dodano metodę dla właściwości com.aspose.slides.ISmartArt.setLayout(int). Umożliwia ona zmianę typu układu istniejącego diagramu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() został dodany**
Metoda com.aspose.slides.ISmartArtNode.isHidden() zwraca true, jeśli ten węzeł jest ukrytym węzłem w modelu danych.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //zwraca true

if(hidden) {

    //wykonaj pewne akcje lub powiadomienia

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() have been added**
Właściwość com.aspose.slides.ISmartArt.IsReversed umożliwia odczyt lub ustawienie stanu diagramu SmartArt względem orientacji (od lewej do prawej) LTR lub (od prawej do lewej) RTL, o ile diagram obsługuje odwrócenie.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
Metody com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() oraz setOrganizationChartLayout(int) umożliwiają odczyt lub ustawienie typu wykresu organizacyjnego powiązanego z bieżącym węzłem.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Property IShape.getConnectionSiteCount() został dodany**
Właściwość com.aspose.slides.getConnectionSiteCount() zwraca liczbę punktów połączeń na kształcie.

``` java
import com.aspose.slides.*;


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
### **Minor Changes**
Oto lista drobnych zmian w API:

|Enum com.aspose.slides.BevelColorMode |usunięto, nieużywany enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |usunięto, nieużywaną właściwość |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |dodano |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |usunięto |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |usunięto jako przestarzałe |