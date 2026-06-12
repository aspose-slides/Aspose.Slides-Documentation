---
title: Dia's van een presentatie klonen in Java
linktitle: Dia's klonen
type: docs
weight: 35
url: /nl/java/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Dupliceer snel PowerPoint-dia's met Aspose.Slides for Java. Volg onze heldere code-voorbeelden om in enkele seconden PPT-creatie te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for Java maakt het ook mogelijk om een kopie of kloon van elke dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for Java biedt (een collectie van [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide) objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object wordt blootgesteld de methoden [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) en [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) om de bovenstaande soorten dia‑klonen uit te voeren

## **Kloon een dia aan het einde van een presentatie**
Als u een dia wilt klonen en vervolgens in hetzelfde presentatiebestand aan het einde van de bestaande dia's wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) klasse door te refereren aan de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia als parameter aan de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode.
1. Schrijf het gewijzigde presentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (gelegen op de eerste positie – index nul – van de presentatie) naar het einde van de presentatie.

```java
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon een dia naar een andere positie binnen een presentatie**
Als u een dia wilt klonen en vervolgens in hetzelfde presentatiebestand, maar op een andere positie, wilt gebruiken, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Instantieer de klasse door te refereren aan de [**Slides**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) collectie die door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object wordt blootgesteld.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia samen met de index voor de nieuwe positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑methode.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (gelegen op index nul – positie 1 – van de presentatie) naar index 1 – positie 2 – van de presentatie.

```java
// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.getSlides();

    // Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schrijf de gewijzigde presentatie naar schijf
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon een dia aan het einde van een andere presentatie**
Als u een dia uit een presentatie moet klonen en deze in een ander presentatiebestand aan het einde van de bestaande dia's wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de presentatie bevat waarvan de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de doelpresentatie bevat waaraan de dia zal worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection) klasse door te refereren aan de [**Slides**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie als parameter aan de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode.
1. Schrijf het gewijzigde doelpresentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van de eerste index van de bronpresentatie) naar het einde van de doelpresentatie.

```java
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia naartoe wordt gekloond)
    Presentation destPres = new Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de verzameling dia's in de doelpresentatie
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Schrijf de doelpresentatie naar schijf
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia naar een andere positie in een andere presentatie**
Als u een dia uit een presentatie moet klonen en deze in een ander presentatiebestand op een specifieke positie wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de bronpresentatie bevat waarvan de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de presentatie bevat waaraan de dia zal worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) klasse door te refereren aan de Slides‑collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑methode.
1. Schrijf het gewijzigde doelpresentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van index nul van de bronpresentatie) naar index 1 (positie 2) van de doelpresentatie.

```java
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de doel-PPTX (waar de dia naartoe wordt gekloond)
    Presentation destPres = new Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de verzameling dia's in de doelpresentatie
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Schrijf de doelpresentatie naar schijf
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia op een specifieke positie in een andere presentatie**
Als u een dia met een masterslide wilt klonen van de ene presentatie naar een andere presentatie, moet u eerst de gewenste masterslide van de bronpresentatie naar de doelpresentatie klonen. Vervolgens moet u die masterslide gebruiken om de dia met masterslide te klonen. De [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) verwacht een masterslide uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om de dia met een master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de bronpresentatie bevat waarvan de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan die de doelpresentatie bevat waaraan de dia zal worden gekloond.
1. Toegang tot de te klonen dia samen met de masterslide.
1. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterSlideCollection) klasse door te refereren aan de Masters‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object van de doelpresentatie wordt blootgesteld.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IMasterSlideCollection) object en geef de masterslide uit de bron‑PPTX die gekloond moet worden als parameter aan de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) klasse door de referentie naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) object van de doelpresentatie wordt blootgesteld, in te stellen.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia uit de bronpresentatie en de masterslide als parameters aan de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode.
1. Schrijf het gewijzigde doelpresentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia met een master gekloond (gelegen op index nul van de bronpresentatie) naar het einde van de doelpresentatie met gebruik van een master van de bron‑dia.

```java
// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantieer de Presentation-klasse voor de doelpresentatie (waar de dia naartoe wordt gekloond)
    Presentation destPres = new Presentation();
    try {
        // Instantieer ISlide uit de verzameling dia's in de bronpresentatie samen met
        // Masterslide
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kloon de gewenste masterslide van de bronpresentatie naar de verzameling masters in de
        // doelpresentatie
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kloon de gewenste masterslide van de bronpresentatie naar de verzameling masters in de
        // doelpresentatie
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // verzameling dia's in de doelpresentatie
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Sla de doelpresentatie op naar schijf
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia aan het einde van een opgegeven sectie**
Als u een dia wilt klonen en vervolgens in hetzelfde presentatiebestand, maar in een andere sectie, wilt gebruiken, gebruik dan de [**addClone**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑methode die door de [**ISlideCollection**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlideCollection) interface wordt blootgesteld. Aspose.Slides for Java maakt het mogelijk om een dia uit de eerste sectie te klonen en vervolgens die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment laat zien hoe u een dia kunt klonen en de gekloonde dia in een opgegeven sectie kunt invoegen.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Sla de doelpresentatie op naar schijf
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Veelgestelde vragen**

**Worden spreker‑notities en beoordelings­commentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren zijn inbegrepen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkboek), wordt die koppeling behouden als een [OLE‑object](/slides/nl/java/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/java/slide-section/). Als de doelsectie nog niet bestaat, maak deze dan eerst aan en verplaats vervolgens de dia ernaar.