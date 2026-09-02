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
description: "Dupliceer PowerPoint-dia's snel met Aspose.Slides voor Node.js. Volg onze code-voorbeelden om PPT-creatie binnen enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Introductie**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for Node.js via Java maakt het ook mogelijk om een kopie of kloon van een willekeurige dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for Node.js via Java, (een collectie van [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide) objecten) die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) object, biedt de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) en [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methoden om de bovenstaande types van dia‑klonen uit te voeren

## **Kloon aan het einde binnen een presentatie**
Als u een dia wilt klonen en vervolgens gebruiken binnen hetzelfde presentatiedocument aan het einde van de bestaande dia's, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Instantieser de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door te refereren naar de Slides-collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) object.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object en geef de te klonen dia door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde presentatiebestand.

In het onderstaande voorbeeld hebben we een dia gekloond (die zich op de eerste positie – nul‑index – van de presentatie bevindt) naar het einde van de presentatie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieser de Presentation-klasse die een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon op een andere positie binnen een presentatie**
Als u een dia wilt klonen en vervolgens gebruiken binnen hetzelfde presentatiedocument maar op een andere positie, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Instantieser de klasse door te refereren naar de [**Slides**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) object.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object en geef de te klonen dia samen met de index voor de nieuwe positie door als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (die zich op index 1 – positie 2 – van de presentatie bevindt) naar index 2 – positie 3 – van de presentatie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieser de Presentation-klasse die een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
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
Als u een dia wilt klonen vanuit één presentatie en gebruiken in een andere presentatiedocument aan het einde van de bestaande dia's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de presentatie bevat waaruit de dia gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de doelpresentatie bevat waaraan de dia zal worden toegevoegd.
1. Instantieser de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection) klasse door te refereren naar de [**Slides**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doelpresentatie‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (van de eerste index van de bronpresentatie) naar het einde van de doelpresentatie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieser de Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieser de Presentation-klasse voor de doel-PPTX (waar de dia gekloond moet worden)
    var destPres = new aspose.slides.Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de dia-collectie in de doelpresentatie
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
Als u een dia wilt klonen vanuit één presentatie en gebruiken in een andere presentatiedocument op een specifieke positie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de presentatie bevat waaraan de dia zal worden toegevoegd.
1. Instantieser de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door te refereren naar de Slides‑collectie die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie samen met de gewenste positie door als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doelpresentatie‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (van de nul‑index van de bronpresentatie) naar index 1 (positie 2) van de doelpresentatie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieser de Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieser de Presentation-klasse voor de doel-PPTX (waar de dia gekloond moet worden)
    var destPres = new aspose.slides.Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de dia-collectie in de doelpresentatie
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Schrijf de doelpresentatie naar schijf
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon op een specifieke positie in een andere presentatie**
Als u een dia met een masterslide wilt klonen vanuit één presentatie en gebruiken in een andere presentatie, moet u eerst de gewenste masterslide uit de bronpresentatie naar de doelpresentatie klonen. Vervolgens gebruikt u die masterslide om de dia met masterslide te klonen. De [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) verwacht een masterslide uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond zal worden.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse die de doelpresentatie bevat waarnaar de dia gekloond zal worden.
1. Toegang tot de te klonen dia samen met de masterslide.
1. Instantieser de [MasterSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterSlideCollection) klasse door te refereren naar de Masters‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) object van de doelpresentatie.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [MasterSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/MasterSlideCollection) object en geef de master uit de bron‑PPTX door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Instantieser de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) klasse door de referentie naar de Slides‑collectie van het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) object van de doelpresentatie in te stellen.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie die gekloond moet worden en de masterslide door als parameters aan de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode.
1. Schrijf het gewijzigde doelpresentatie‑bestand.

In het onderstaande voorbeeld hebben we een dia met een master (die zich op de nul‑index van de bronpresentatie bevindt) naar het einde van de doelpresentatie gekloond met een master uit de bron‑dia.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieser de Presentation-klasse om het bronpresentatiebestand te laden
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantieser de Presentation-klasse voor de doelpresentatie (waar de dia gekloond moet worden)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instantieser ISlide uit de collectie dia's in de bronpresentatie samen met
        // Masterdia
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Kloon de gewenste masterslide van de bronpresentatie naar de collectie masters in de
        // Doelpresentatie
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // Collectie dia's in de doelpresentatie
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Sla de doelpresentatie op schijf
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon aan het einde in een opgegeven sectie**
Als u een dia wilt klonen en vervolgens gebruiken binnen hetzelfde presentatiedocument maar in een andere sectie, gebruik dan de [**addClone**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) methode die wordt blootgesteld door de [**SlideCollection**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection) klasse. Aspose.Slides for Node.js via Java maakt het mogelijk om een dia te klonen vanuit de eerste sectie en die gekloonde dia vervolgens in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment toont hoe u een dia kunt klonen en de gekloonde dia in een opgegeven sectie kunt invoegen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Sla de doelpresentatie op schijf
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Zorg voor overeenkomende dia‑grootte**

Wanneer u dia’s kloont naar een andere presentatie, zorg er dan voor dat de doelpresentatie dezelfde dia‑grootte heeft als de bron. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde vormen niet automatisch – hun oorspronkelijke coördinaten en afmetingen blijven behouden, waardoor de inhoud mogelijk verkeerd uitgelijnd raakt of buiten de dia‑grenzen uitsteekt.

U kunt de dia‑grootte van de doelpresentatie instellen zodat deze overeenkomt met die van de bron vóór het klonen van de master en de dia:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Doe dit vóór het klonen van de master en de dia.

## **FAQ**

**Worden presentatorenotities en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren worden opgenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/nodejs-java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE object](/slides/nl/nodejs-java/manage-ole/). Na verplaatsing tussen bestanden dient u de beschikbaarheid van gegevens en het verversingsgedrag te verifiëren.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [section](/slides/nl/nodejs-java/slide-section/). Als de doelsectie niet bestaat, maakt u deze eerst aan en verplaatst u vervolgens de dia ernaar.