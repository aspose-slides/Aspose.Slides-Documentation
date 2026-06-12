---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.4.0
linktitle: Aspose.Slides voor Java 15.4.0
type: docs
weight: 120
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina bevat een overzicht van alle [toegevoegde](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) klassen, methoden, eigenschappen enz., eventuele nieuwe beperkingen en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.4.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
### **Enum OrganizationChartLayoutType is toegevoegd**
De com.aspose.slides.OrganizationChartLayoutType enum geeft het opmaaktype van de onderliggende knooppunten in een organigram weer.
### **Methode IBulletFormat.applyDefaultParagraphIndentsShifts() is toegevoegd**
Methode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts stelt standaard niet-nul verschuivingen in voor de effectieve alinea‑inspringing en marge‑links wanneer opsommingstekens zijn ingeschakeld (zoals PowerPoint doet wanneer alinea‑opsomming/nummering wordt ingeschakeld). Als opsommingstekens zijn uitgeschakeld, worden alleen alinea‑inspringing en marge‑links gereset (zoals PowerPoint doet wanneer alinea‑opsomming/nummering wordt uitgeschakeld).
### **Methode IConnector.reroute() is toegevoegd**
Methode com.aspose.slides.IConnector.reroute() herschakelt de connector zodat deze de kortst mogelijke route neemt tussen de vormen die hij verbindt. Hiervoor kan de reroute()-methode de StartShapeConnectionSiteIndex en EndShapeConnectionSiteIndex aanpassen.

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
### **Methode IPresentation.getSlideById(long) is toegevoegd**
Methode Aspose.Slides.IPresentation.getSlideById(int) retourneert een Slide, MasterSlide of LayoutSlide op basis van de slide‑Id.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Methode ISmartArt.getNodes() is toegevoegd**
Methode com.aspose.slides.ISmartArt.getNodes() retourneert een collectie van knooppunten op het hoogste niveau in een SmartArt‑object.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // selecteer tweede rootknooppunt

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArt.setLayout(int) is toegevoegd**
Methode voor eigenschap com.aspose.slides.ISmartArt.setLayout(int) is toegevoegd. Deze maakt het mogelijk om het layouttype van een bestaand diagram te wijzigen.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArtNode.isHidden() is toegevoegd**
Methode com.aspose.slides.ISmartArtNode.isHidden() geeft true terug als dit knooppunt een verborgen knooppunt is in het datamodel.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //geeft true terug

if(hidden) {

    //voer enkele acties of meldingen uit

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArt.isReversed(), setReserved() zijn toegevoegd**
Eigenschap com.aspose.slides.ISmartArt.IsReversed maakt het mogelijk om de status van het SmartArt‑diagram te verkrijgen of in te stellen ten opzichte van (van links naar rechts) LTR of (van rechts naar links) RTL, indien het diagram omkering ondersteunt.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) zijn toegevoegd**
Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) maken het mogelijk om het organigramtype dat aan het huidige knooppunt is gekoppeld te verkrijgen of in te stellen.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Eigenschap IShape.getConnectionSiteCount() is toegevoegd**
Eigenschap com.aspose.slides.getConnectionSiteCount() retourneert het aantal verbindingpunten op de vorm.

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
### **Kleine wijzigingen**
Dit is de lijst met kleine API‑wijzigingen:

|Enum com.aspose.slides.BevelColorMode |verwijderd, ongebruikte enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |verwijderd, ongebruikte eigenschap |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |toegevoegd |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |verwijderd |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |verwijderd als verouderd |