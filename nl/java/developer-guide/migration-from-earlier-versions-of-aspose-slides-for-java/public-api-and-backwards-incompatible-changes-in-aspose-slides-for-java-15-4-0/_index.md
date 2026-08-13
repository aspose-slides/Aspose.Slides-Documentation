---
title: Openbare API en achterwaartse incompatibele wijzigingen in Aspose.Slides voor Java 15.4.0
linktitle: Aspose.Slides voor Java 15.4.0
type: docs
weight: 120
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migratie
- legacycode
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe beperkingen en andere [changes](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 15.4.0 API.
{{% /alert %}} 
## **Public API Changes**
### **Enum OrganizationChartLayoutType is toegevoegd**
De com.aspose.slides.OrganizationChartLayoutType enum vertegenwoordigt het opmaaktype van de kindknopen in een organisatieschema.
### **Methode IBulletFormat.applyDefaultParagraphIndentsShifts() is toegevoegd**
Methode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts stelt de standaard niet‑nul verschuivingen in voor de effectieve alinea‑inspringing (Indent) en de linkermarge (MarginLeft) wanneer opsommingstekens zijn ingeschakeld (net als PowerPoint doet wanneer alinea‑opsomming/nummering wordt ingeschakeld). Als opsommingstekens zijn uitgeschakeld, wordt de alinea‑inspringing en de linkermarge gewoon gereset (net als PowerPoint doet wanneer alinea‑opsomming/nummering wordt uitgeschakeld).
### **Methode IConnector.reroute() is toegevoegd**
Methode com.aspose.slides.IConnector.reroute() leidt de connector opnieuw zodat deze de kortst mogelijke route tussen de verbonden vormen neemt. Om dit te doen kan de reroute()‑methode de StartShapeConnectionSiteIndex en EndShapeConnectionSiteIndex aanpassen.
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
### **Methode IPresentation.getSlideById(long) is toegevoegd**
Methode Aspose.Slides.IPresentation.getSlideById(long) retourneert een Slide, MasterSlide of LayoutSlide op basis van de slide‑Id.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Methode ISmartArt.getNodes() is toegevoegd**
Methode com.aspose.slides.ISmartArt.getNodes() retourneert een collectie van wortelknooppunten in een SmartArt‑object.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // selecteer tweede wortelknooppunt

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArt.setLayout(int) is toegevoegd**
Methode voor eigenschap com.aspose.slides.ISmartArt.setLayout(int) is toegevoegd. Hiermee kan het lay‑outtype van een bestaand diagram worden gewijzigd.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Methode ISmartArtNode.isHidden() is toegevoegd**
Methode com.aspose.slides.ISmartArtNode.isHidden() retourneert true als dit knooppunt een verborgen knooppunt is in het datamodel.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //geeft true terug

if(hidden) {

    //voer enkele acties of meldingen uit

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methoden ISmartArt.isReversed(), setReversed() zijn toegevoegd**
Eigenschap com.aspose.slides.ISmartArt.IsReversed maakt het mogelijk om de status van het SmartArt‑diagram op te halen of in te stellen met betrekking tot (van links naar rechts) LTR of (van rechts naar links) RTL, indien het diagram omkering ondersteunt.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methoden ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) zijn toegevoegd**
Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() en setOrganizationChartLayout(int) maken het mogelijk om het type organisatieschema op te halen of in te stellen dat aan de huidige knoop is gekoppeld.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Eigenschap IShape.getConnectionSiteCount() is toegevoegd**
Eigenschap com.aspose.slides.getConnectionSiteCount() retourneert het aantal aansluitpunten op de vorm.
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
Dit is de lijst met kleine API-wijzigingen:

|Enum com.aspose.slides.BevelColorMode |verwijderd, ongebruikte enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |verwijderd, ongebruikte property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |added |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |verwijderd |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |verwijderd als verouderd |