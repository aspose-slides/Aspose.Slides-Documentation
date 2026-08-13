---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 15.4.0
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
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro Java a hladce migrujte své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) třídy, metody, vlastnosti a podobně, případně nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) zavedené v API Aspose.Slides pro Java 15.4.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Byl přidán výčet OrganizationChartLayoutType**
Výčet com.aspose.slides.OrganizationChartLayoutType představuje typ formátování podřízených uzlů v organizačním diagramu.
### **Byla přidána metoda IBulletFormat.applyDefaultParagraphIndentsShifts()**
Metoda com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts nastavuje výchozí nenulové posuny pro efektivní odsazení odstavce a levý okraj, když jsou zapnuté odrážky (podobně jako PowerPoint při povolení odrážek/číslování odstavců). Pokud jsou odrážky vypnuté, metoda pouze resetuje odsazení odstavce a levý okraj (podobně jako PowerPoint při vypnutí odrážek/číslování).
### **Byla přidána metoda IConnector.reroute()**
Metoda com.aspose.slides.IConnector.reroute() přepočítá cestu spojnice tak, aby zvolila nejkratší možnou trajektorii mezi tvary, které spojuje. K tomu může metoda změnit hodnoty StartShapeConnectionSiteIndex a EndShapeConnectionSiteIndex.

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
### **Byla přidána metoda IPresentation.getSlideById(long)**
Metoda Aspose.Slides.IPresentation.getSlideById(long) vrací snímek, hlavní snímek nebo rozložení snímku podle identifikátoru snímku.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Byla přidána metoda ISmartArt.getNodes()**
Metoda com.aspose.slides.ISmartArt.getNodes() vrací kolekci kořenových uzlů v objektu SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // vyberte druhý kořenový uzel

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Byla přidána metoda ISmartArt.setLayout(int)**
Byla přidána metoda pro vlastnost com.aspose.slides.ISmartArt.setLayout(int). Umožňuje změnit typ rozvržení existujícího diagramu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Byla přidána metoda ISmartArtNode.isHidden()**
Metoda com.aspose.slides.ISmartArtNode.isHidden() vrací true, pokud je tento uzel skrytý v datovém modelu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //vrací true

if(hidden) {

    //proveďte nějaké akce nebo upozornění

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Byly přidány metody ISmartArt.isReversed(), setReversed()**
Vlastnost com.aspose.slides.ISmartArt.IsReversed umožňuje získat nebo nastavit stav diagramu SmartArt z hlediska (zleva doprava) LTR nebo (zprava doleva) RTL, pokud diagram podporuje reverzi.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Byly přidány metody ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Metody com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() a setOrganizationChartLayout(int) umožňují získat nebo nastavit typ organizačního diagramu přiřazeného k aktuálnímu uzlu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Byla přidána vlastnost IShape.getConnectionSiteCount()**
Vlastnost com.aspose.slides.getConnectionSiteCount() vrací počet připojovacích míst na tvaru.

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
### **Menší změny**
Toto je seznam menších změn API:

|Enum com.aspose.slides.BevelColorMode |smazáno, nepoužívaný výčet |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |smazáno, nepoužívaná vlastnost |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |přidáno |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |smazáno |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |smazáno jako zastaralé |