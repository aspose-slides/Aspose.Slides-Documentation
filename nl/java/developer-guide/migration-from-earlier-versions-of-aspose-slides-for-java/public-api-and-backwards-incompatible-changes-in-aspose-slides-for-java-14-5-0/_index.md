---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 14.5.0
linktitle: Aspose.Slides voor Java 14.5.0
type: docs
weight: 40
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klassen, methoden, eigenschappen enz., eventuele nieuwe [beperkingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Toegevoegde klassen en methoden**
#### **Toegevoegde Aspose.Slides.IPresentationInfo interface en PresentationInfo klassen**
Geeft informatie over de presentatie weer.

Methode Boolean isEncrypted() retourneert True als een presentatie versleuteld is, anders False.

Methode LoadFormat getLoadFormat() retourneert het type van de presentatie.
#### **Toegevoegde Aspose.Slides.IShape.isGrouped() methode**
De methode Aspose.Slides.IShape.isGrouped() bepaalt of de vorm gegroepeerd is.
#### **Toegevoegde Aspose.Slides.IShape.getParentGroup() methode**
De methode Aspose.Slides.IShape.getParentGroup() retourneert het bovenliggende GroupShape‑object als de vorm gegroepeerd is. Anders retourneert het null.
#### **Toegevoegde Aspose.Slides.IShapeCollection.addGroupShape() methode**
De methode Aspose.Slides.IShapeCollection.addGroupShape() maakt een nieuw GroupShape aan en voegt het toe aan het einde van de collectie.

De frame‑grootte en positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm aan het GroupShape wordt toegevoegd.
#### **Toegevoegde Aspose.Slides.IShapeCollection.clear() methode**
De methode Aspose.Slides.IShapeCollection.clear() verwijdert alle vormen uit de collectie.
#### **Toegevoegde Aspose.Slides.IShapeCollection.insertGroupShape(int) methode**
De methode Aspose.Slides.IShapeCollection.insertGroupShape(int) maakt een nieuw GroupShape aan en voegt het in de collectie in op de opgegeven index.

De frame‑grootte en positie van het GroupShape worden aangepast aan de inhoud wanneer een nieuwe vorm aan het GroupShape wordt toegevoegd.
#### **Toegevoegde IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) methoden**
Deze methoden stellen ontwikkelaars in staat om informatie over een presentatie‑bestand/stream te ontvangen zonder de volledige presentatie te laden.
#### **Toegevoegde IPresentationFactory PresentationFactory.getInstance() methode**
Staat het gebruik van de fabrieksfunctionaliteit toe zonder instantiering.
### **Beperkingen**
#### **Beperkingen zijn toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.getFrame()**
Code die probeert een ongedefinieerde frame toe te wijzen aan IShape.setFrame(IShapeFrame) is in algemene gevallen niet logisch (vooral wanneer het bovenliggende GroupShape meerdere keren genest is in andere {{GroupShape}}s). Bijvoorbeeld:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Gooit een ArgumentException: de framewaarden moeten gedefinieerd zijn.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

of

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Gooit een ArgumentException: de x-, y-, breedte- en hoogtewaarden moeten gedefinieerd zijn.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Dergelijke code kan leiden tot onduidelijke situaties. Daarom zijn er beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. De waarden van x, y, width, height, flipH, flipV en rotationAngle moeten gedefinieerd zijn (niet Float.NaN of NullableBool.NotDefined). De voorbeeldcode hierboven werpt nu een ArgumentException.

Dit geldt voor de volgende use‑cases:

``` java
// De frame die wordt doorgegeven aan IShape.setFrame(IShapeFrame) mag geen ongedefinieerde waarden bevatten.

// De x-, y-, breedte- en hoogte‑parameters van de volgende IShapeCollection‑methoden
// kunnen ook niet Float.NaN zijn:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Maar het frame van IShape.getRawFrame() kan ongedefinieerd zijn. Dit is logisch wanneer een vorm gekoppeld is aan een placeholder. Dan worden ongedefinieerde frame‑waarden van de vorm overschreven door de bovenliggende placeholder‑vorm. Als er geen bovenliggende placeholder‑vorm voor die vorm bestaat, worden standaardwaarden gebruikt bij het bepalen van het effectieve frame op basis van haar IShape.getRawFrame(). Standaardwaarden zijn 0 en NullableBool.False voor x, y, width, height, flipH, flipV en rotationAngle. Bijvoorbeeld:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // De vorm is gekoppeld aan een placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Nu erft de vorm de x-, y-, hoogte-, flipH- en flipV-waarden van de placeholder
    // en overschrijft width = 100 en rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Gewijzigde eigenschappen**
#### **Gewijzigd type en naam van de Aspose.Slides.IShapeCollection.getParent() methode**
Het type van de Aspose.Slides.IShapeCollection.Parent‑eigenschap is gewijzigd van ISlideComponent naar de nieuwe IGroupShape‑interface. De IGroupShape‑interface is een afstammeling van ISlideComponent, dus bestaande code behoeft geen aanpassing.

De naam van de Aspose.Slides.IShapeCollection.getParent() methode is gewijzigd van getParent naar getParentGroup().
#### **Wijzig het type van de Aspose.Slides.IShapeFrame.getFlipH() en .getFlipV() methoden**
Het type van de Aspose.Slides.IShapeFrame.getFlipH() methode is gewijzigd van bool naar NullableBool.

De IShape.getFrame() methode retourneert de effectieve instantie van IShapeFrame (waarvan alle eigenschappen gedefinieerde effectieve waarden hebben).

De IShape.getRawFrame() methode retourneert een IShapeFrame‑instantie waarvan elke eigenschap een ongedefinieerde waarde kan hebben (met name FlipH of FlipV kan de waarde NullableBool.NotDefined hebben).