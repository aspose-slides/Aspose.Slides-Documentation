---
title: Dia's van een presentatie klonen in JavaScript
linktitle: Dia's klonen
type: docs
weight: 35
url: /nl/nodejs-java/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Dupliceer snel PowerPoint-dia's met Aspose.Slides voor Node.js. Volg onze code‑voorbeelden om PPT‑creatie binnen enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Introductie**

Klonen is het proces van het maken van een exacte kopie of replica van iets. Aspose.Slides voor Node.js via Java maakt het ook mogelijk om een kopie of kloon van elke dia te maken en vervolgens die gekloonde dia in te voegen in de huidige of een andere geopende presentatie. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de originele dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides voor Node.js via Java, (een collectie van [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide)-objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-object wordt blootgesteld, biedt de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) en [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode om de hierboven genoemde kloningsscenario's uit te voeren.

## **Kloon aan het einde binnen een presentatie**
Als u een dia wilt klonen en vervolgens in dezelfde presentatiebestanden aan het einde van de bestaande dia’s wilt gebruiken, gebruikt u de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse.
1. Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door te refereren aan de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-object wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object wordt blootgesteld en geef de te klonen dia als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (op de eerste positie – index nul – van de presentatie) gekloond naar het einde van de presentatie.

```javascript
// Instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon op een andere positie binnen presentatie**
Als u een dia wilt klonen en vervolgens in dezelfde presentatiebestanden maar op een andere positie wilt gebruiken, gebruikt u de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse.
1. Instantieer de klasse door te refereren aan de [**Slides**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) collectie die door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-object wordt blootgesteld.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object wordt blootgesteld en geef de te klonen dia samen met de index voor de nieuwe positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (op index nul – positie 1 – van de presentatie) gekloond naar index 1 – Positie 2 – van de presentatie.

```javascript
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    var slds = pres.getSlides();
    // Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon aan het einde in een andere presentatie**
Als u een dia uit één presentatie wilt klonen en in een andere presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de doelpresentatie bevat waaraan de dia wordt toegevoegd.
1. Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection) klasse door te refereren aan de [**Slides**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object wordt blootgesteld en geef de dia uit de bronpresentatie als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) gekloond naar het einde van de doelpresentatie.

```javascript
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia naartoe wordt gekloond)
    var destPres = new aspose.slides.Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de verzameling dia's in de doelpresentatie
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Schrijf de doelpresentatie naar schijf
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon op een andere positie in een andere presentatie**
Als u een dia uit één presentatie wilt klonen en in een andere presentatiedocument op een specifieke positie wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de presentatie bevat waaraan de dia wordt toegevoegd.
1. Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door te refereren aan de Slides‑collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object wordt blootgesteld en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van index nul van de bronpresentatie) gekloond naar index 1 (positie 2) van de doelpresentatie.

```javascript
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia gekloond moet worden)
    var destPres = new aspose.slides.Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de verzameling dia's in de doelpresentatie
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Schrijf de doelpresentatie naar schijf
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon op specifieke positie in een andere presentatie**
Als u een dia met een masterslide wilt klonen uit één presentatie en in een andere presentatie wilt gebruiken, moet u eerst de gewenste masterslide uit de bronpresentatie naar de doelpresentatie klonen. Vervolgens moet u die masterslide gebruiken voor het klonen van de dia met masterslide. De [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) verwacht een masterslide uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-klasse die de doelpresentatie bevat waarnaar de dia wordt gekloond.
1. Open de te klonen dia samen met de masterslide.
1. Instantieer de [MasterSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterSlideCollection) klasse door te refereren aan de Masters‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-object van de doelpresentatie wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die door het [MasterSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterSlideCollection) object wordt blootgesteld en geef de masterslide uit de bron‑PPTX als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door een referentie naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)-object van de doelpresentatie wordt blootgesteld in te stellen.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object wordt blootgesteld en geef de dia uit de bronpresentatie die moet worden gekloond en de masterslide als parameters aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doel‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met een master (op index nul van de bronpresentatie) gekloond naar het einde van de doelpresentatie met behulp van een master uit de bron‑dia.

```javascript
// Instantieer Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantieer Presentation-klasse voor de doelpresentatie (waar de dia gekloond moet worden)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instantieer ISlide uit de collectie dia's in de bronpresentatie samen met
        // Masterdia
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Kloon de gewenste masterslide van de bronpresentatie naar de collectie masters in de
        // Doelpresentatie
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Kloon de gewenste masterslide van de bronpresentatie naar de collectie masters in de
        // Doelpresentatie
        var iSlide = masters.addClone(SourceMaster);
        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // Collectie dia's in de doelpresentatie
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Sla de doelpresentatie op naar schijf
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon aan het einde in opgegeven sectie**
Als u een dia wilt klonen en vervolgens in dezelfde presentatiedocument maar in een andere sectie wilt gebruiken, gebruikt u de [**addClone**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) methode die wordt blootgesteld door de [**SlideCollection**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection)-klasse. Aspose.Slides voor Node.js via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en vervolgens die gekloonde dia in te voegen in de tweede sectie van dezelfde presentatie.

De volgende code‑fragment toont hoe u een dia kloont en de gekloonde dia in een opgegeven sectie invoegt.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Sla de doelpresentatie op naar schijf
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Worden spreker­notities en beoordelings­commentaren gekloond?**

Ja. De notitie‑pagina en beoordelings­commentaren worden meegenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/nodejs-java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek was gekoppeld aan een externe bron (bijv. een OLE‑ingesloten werkboek), blijft die koppeling behouden als een [OLE‑object](/slides/nl/nodejs-java/manage-ole/). Na verplaatsing tussen bestanden dient u de beschikbaarheid van de gegevens en het vernieuwingsgedrag te controleren.

**Kan ik de invoeg‑positie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/nodejs-java/slide-section/). Als de doel‑sectie nog niet bestaat, maakt u die eerst aan en verplaatst u vervolgens de dia ernaartoe.