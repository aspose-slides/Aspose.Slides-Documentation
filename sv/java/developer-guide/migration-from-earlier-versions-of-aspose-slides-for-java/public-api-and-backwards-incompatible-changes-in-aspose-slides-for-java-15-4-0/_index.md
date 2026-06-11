---
title: Publikt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 15.4.0
linktitle: Aspose.Slides för Java 15.4.0
type: docs
weight: 120
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migration
- gammalkod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) som introducerats med Aspose.Slides för Java 15.4.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
### **Enum OrganizationChartLayoutType har lagts till**
Enumen com.aspose.slides.OrganizationChartLayoutType representerar formateringstypen för barnnoder i ett organisationsdiagram.
### **Metod IBulletFormat.applyDefaultParagraphIndentsShifts() har lagts till**
Metoden com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts anger standard‑icke‑noll‑förskjutningar för effektiv styckeindentering och vänstermarginal när punktlistor är aktiverade (som PowerPoint gör om du aktiverar punktlista/numrering i ett stycke). Om punktlistor är inaktiverade återställs bara styckeindentering och vänstermarginal (som PowerPoint gör om du inaktiverar punktlista/numrering i ett stycke).
### **Metod IConnector.reroute() har lagts till**
Metoden com.aspose.slides.IConnector.reroute() omdirigerar förbindelsen så att den tar den kortaste möjliga vägen mellan formerna den förbinder. För att göra detta kan reroute()-metoden ändra StartShapeConnectionSiteIndex och EndShapeConnectionSiteIndex.

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
### **Metod IPresentation.getSlideById(long) har lagts till**
Metoden Aspose.Slides.IPresentation.getSlideById(int) returnerar en Slide, MasterSlide eller LayoutSlide baserat på slide‑Id.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Metod ISmartArt.getNodes() har lagts till**
Metoden com.aspose.slides.ISmartArt.getNodes() returnerar en samling av rot‑noder i SmartArt‑objektet.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // välj andra rotnod

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metod ISmartArt.setLayout(int) har lagts till**
Metoden för egenskapen com.aspose.slides.ISmartArt.setLayout(int) har lagts till. Den möjliggör att ändra layout‑typ för ett befintligt diagram.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metod ISmartArtNode.isHidden() har lagts till**
Metoden com.aspose.slides.ISmartArtNode.isHidden() returnerar true om denna nod är en dold nod i datamodellen.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //returnerar true

if(hidden) {

    //utför vissa åtgärder eller aviseringar

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Metoder ISmartArt.isReversed(), setReserved() har lagts till**
Egenskapen com.aspose.slides.ISmartArt.IsReversed möjliggör att få eller ange tillståndet för SmartArt‑diagrammet med avseende på (vänster‑till‑höger) LTR eller (höger‑till‑vänster) RTL, om diagrammet stödjer omvändning.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Metoder ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) har lagts till**
Metoderna com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) möjliggör att få eller ange organisationsdiagram‑typen som är associerad med den aktuella noden.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Egenskap IShape.getConnectionSiteCount() har lagts till**
Egenskapen com.aspose.slides.getConnectionSiteCount() returnerar antalet anslutningsställen på formen.

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
### **Mindre ändringar**
Detta är listan över mindre API‑ändringar:

|Enum com.aspose.slides.BevelColorMode |borttagen, oanvänd enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |borttagen, oanvänd egenskap |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |tillagd |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |borttagen |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |borttagen som föråldrad |