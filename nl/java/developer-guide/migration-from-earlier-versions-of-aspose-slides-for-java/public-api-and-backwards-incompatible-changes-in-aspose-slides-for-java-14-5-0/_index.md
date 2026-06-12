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
description: "Bekijk de updates van de openbare API en de brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentaties oplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) klassen, methoden, eigenschappen enzovoort, eventuele nieuwe [beperkingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) en andere [wijzigingen](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) die geïntroduceerd zijn met de Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **Openbare API en achterwaarts incompatibele wijzigingen**
### **Toegevoegde klassen en methoden**
#### **Toegevoegd de Aspose.Slides.IPresentationInfo interface en PresentationInfo klassen**
Geeft informatie over een presentatie weer.

Methode Boolean isEncrypted() geeft True terug als een presentatie versleuteld is, anders geeft het False terug.

Methode LoadFormat getLoadFormat() geeft het type presentatie terug.
#### **Toegevoegd de Aspose.Slides.IShape.isGrouped() methode**
De methode Aspose.Slides.IShape.isGrouped() bepaalt of de vorm gegroepeerd is.
#### **Toegevoegd de Aspose.Slides.IShape.getParentGroup() methode**
De methode Aspose.Slides.IShape.getParentGroup() retourneert het bovenliggende GroupShape-object als de vorm gegroepeerd is. Anders retourneert het null.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.addGroupShape() methode**
De methode Aspose.Slides.IShapeCollection.addGroupShape() maakt een nieuw GroupShape aan en voegt het toe aan het einde van de collectie.

De framegrootte en -positie van het GroupShape worden aangepast aan de inhoud wanneer er een nieuwe vorm aan het GroupShape wordt toegevoegd.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.clear() methode**
De methode Aspose.Slides.IShapeCollection.clear() verwijdert alle vormen uit de collectie.
#### **Toegevoegd de Aspose.Slides.IShapeCollection.insertGroupShape(int) methode**
De methode Aspose.Slides.IShapeCollection.insertGroupShape(int) maakt een nieuw GroupShape aan en insert het in de collectie op de opgegeven index.
De framegrootte en -positie van het GroupShape worden aangepast aan de inhoud wanneer er een nieuwe vorm aan het GroupShape wordt toegevoegd.
#### **Toegevoegd de IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) Methods**
Deze methoden stellen ontwikkelaars in staat informatie over een presentat­‑bestand/stream te ontvangen zonder de volledige presentatie te laden.
#### **Toegevoegd de IPresentationFactory PresentationFactory.getInstance() methode**
Staat het gebruik van de fabriekfunctionaliteit toe zonder instantie te maken.
### **Beperkingen**
#### **Beperkingen zijn toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.getFrame()**
Code die probeert een ongedefinieerd frame toe te wijzen aan IShape.setFrame(IShapeFrame) heeft in algemene gevallen geen zin (bijvoorbeeld wanneer de bovenliggende GroupShape meerdere keren genest is in andere {{GroupShape}}s). Bijvoorbeeld:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

of

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Deze code kan leiden tot onduidelijke situaties. Daarom zijn er beperkingen toegevoegd voor het gebruik van ongedefinieerde waarden voor IShape.Frame. De waarden van x, y, width, height, flipH, flipV en rotationAngle moeten gedefinieerd zijn (niet Float.NaN of NullableBool.NotDefined). De voorbeeldcode hierboven werpt nu een ArgumentException.

Dit is van toepassing op de volgende gebruikssituaties:

``` java

 IShape shape = ...;

shape.setFrame(...); // mag niet ongedefinieerd zijn

IShapeCollection shapes = ...;

// x, y, breedte, hoogte parameters mogen niet Float.NaN zijn:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Maar het frame van IShape.getRawFrame() kan ongedefinieerd zijn. Dit is logisch wanneer een vorm gekoppeld is aan een placeholder. Dan worden ongedefinieerde frame‑waarden van de vorm overschreven door de bovenliggende placeholder‑vorm. Als er geen bovenliggende placeholder‑vorm voor die vorm bestaat, gebruikt het standaardwaarden bij het berekenen van het effectieve frame op basis van IShape.getRawFrame(). Standaardwaarden zijn 0 en NullableBool.False voor x, y, width, height, flipH, flipV en rotationAngle. Bijvoorbeeld:

``` java

 IShape shape = ...; // shape is gekoppeld aan placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// nu shape erft x, y, hoogte, flipH, flipV waarden van placeholder en overschrijft breedte=100 en rotationAngle=0.

```
### **Gewijzigde eigenschappen**
#### **Gewijzigd het type en de naam van de Aspose.Slides.IShapeCollection.getParent() methode**
Het type van de Aspose.Slides.IShapeCollection.Parent‑eigenschap is gewijzigd van ISlideComponent naar de nieuwe IGroupShape‑interface. De IGroupShape‑interface is een afstammeling van ISlideComponent, dus bestaande code hoeft niet aangepast te worden.

De naam van de Aspose.Slides.IShapeCollection.getParent() methode is gewijzigd van getParent naar getParentGroup().
#### **Wijzig het type van de Aspose.Slides.IShapeFrame.getFlipH() en .getFlipV() methoden**
Het type van de Aspose.Slides.IShapeFrame.getFlipH() methode is gewijzigd van bool naar NullableBool.

De IShape.getFrame() methode retourneert de effectieve instantie van IShapeFrame (waarbij alle eigenschappen gedefinieerde effectieve waarden hebben).

De IShape.getRawFrame() methode retourneert een IShapeFrame‑instantie waarvan elke eigenschap een ongedefinieerde waarde kan hebben (met name FlipH of FlipV kan de waarde NullableBool.NotDefined hebben).