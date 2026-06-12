---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.4.0
linktitle: Aspose.Slides pro Java 15.4.0
type: docs
weight: 120
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Prozkoumejte aktualizace veřejného API a rozbíjející změny v Aspose.Slides pro Java, abyste hladce migrovali vaše řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) třídy, metody, vlastnosti a podobně, všechny nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) zavedené v API Aspose.Slides pro Java 15.4.0.

{{% /alert %}} 
## **Veřejné změny API**
### **Enum OrganizationChartLayoutType byl přidán**
Enum com.aspose.slides.OrganizationChartLayoutType představuje typ formátování podřízených uzlů v organizačním diagramu.
### **Metoda IBulletFormat.applyDefaultParagraphIndentsShifts() byla přidána**
Metoda com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts nastavuje výchozí nenulové posuny pro efektivní odsazení odstavce a levý okraj, když jsou zapnuty odrážky (jako to dělá PowerPoint, pokud jsou v odstavci povoleny odrážky/číslování). Pokud jsou odrážky vypnuty, pouze resetuje odsazení odstavce a levý okraj (jako to dělá PowerPoint, pokud jsou odrážky/číslování v odstavci zakázány).
### **Metoda IConnector.reroute() byla přidána**
Metoda com.aspose.slides.IConnector.reroute() přepočítá cestu spojky tak, aby zaujala nejkratší možnou trasu mezi tvary, které spojuje. K tomu může metoda reroute() změnit hodnoty StartShapeConnectionSiteIndex a EndShapeConnectionSiteIndex.

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
### **Metoda IPresentation.getSlideById(long) byla přidána**
Metoda Aspose.Slides.IPresentation.getSlideById(int) vrací Slide, MasterSlide nebo LayoutSlide podle ID snímku.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Metoda ISmartArt.getNodes() byla přidána**
Metoda com.aspose.slides.ISmartArt.getNodes() vrací kolekci kořenových uzlů v objektu SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // vyberte druhý kořenový uzel

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metoda ISmartArt.setLayout(int) byla přidána**
Metoda pro vlastnost com.aspose.slides.ISmartArt.setLayout(int) byla přidána. Umožňuje změnit typ rozvržení existujícího diagramu.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metoda ISmartArtNode.isHidden() byla přidána**
Metoda com.aspose.slides.ISmartArtNode.isHidden() vrací true, pokud je tento uzel skrytý v datovém modelu.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //vrací true

if(hidden) {

    //proveďte nějaké akce nebo upozornění

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Metody ISmartArt.isReversed(), setReserved() byly přidány**
Vlastnost com.aspose.slides.ISmartArt.IsReversed umožňuje získat nebo nastavit stav diagramu SmartArt z hlediska (zleva doprava) LTR nebo (zprava doleva) RTL, pokud diagram podporuje obrácení.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Metody ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) byly přidány**
Metody com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() a setOrganizationChartLayout(int) umožňují získat nebo nastavit typ organizačního diagramu přiřazeného k aktuálnímu uzlu.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Vlastnost IShape.getConnectionSiteCount() byla přidána**
Vlastnost com.aspose.slides.getConnectionSiteCount() vrací počet míst pro připojení na tvaru.

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
### **Menší změny**
Toto je seznam menších změn API:

|Enum com.aspose.slides.BevelColorMode |odstraněn, nepoužívaný enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |odstraněna, nepoužívaná vlastnost |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |přidáno |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |odstraněno |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |odstraněno jako zastaralé |