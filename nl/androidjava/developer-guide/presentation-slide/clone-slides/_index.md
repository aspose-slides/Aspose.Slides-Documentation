---
title: "Kloon presentatie-dia's op Android"
linktitle: "Kloon dia's"
type: docs
weight: 35
url: /nl/androidjava/clone-slides/
keywords:
- kloon dia
- kopieer dia
- sla dia op
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Dupliceer PowerPoint-dia's met Aspose.Slides voor Android. Volg onze duidelijke Java-codevoorbeelden om PPT-creatie in seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides voor Android via Java maakt het ook mogelijk om een kopie of kloon van een dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de originele dia te wijzigen. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides voor Android via Java biedt de (een verzameling van [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide) objecten) die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object de methoden [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) en [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) om bovenstaande typen dia‑klonen uit te voeren

## **Kloon een dia aan het einde van een presentatie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken, gebruikt u de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door te verwijzen naar de Slides‑verzameling die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia als parameter door aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
1. Schrijf het aangepaste presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (die zich op de eerste positie – index nul – van de presentatie bevindt) gekloond naar het einde van de presentatie.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Schrijf de aangepaste presentatie naar schijf
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon een dia naar een andere positie binnen een presentatie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand maar op een andere positie wilt gebruiken, gebruikt u de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
1. Instantieer de klasse door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) verzameling die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia samen met de index voor de nieuwe positie als parameter door aan de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (die zich op index nul – positie 1 – van de presentatie bevindt) gekloond naar index 1 – positie 2 – van de presentatie.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Kloon de gewenste dia naar het einde van de verzameling dia's in dezelfde presentatie
    ISlideCollection slds = pres.getSlides();

    // Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schrijf de aangepaste presentatie naar schijf
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon een dia aan het einde van een andere presentatie**
Als u een dia uit één presentatie wilt klonen en deze in een andere presentatiedocument wilt gebruiken, aan het einde van de bestaande dia’s:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de presentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de doelpresentatie bevat waaraan de dia moet worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) klasse door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) verzameling die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie als parameter door aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
1. Schrijf het aangepaste doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) gekloond naar het einde van de doelpresentatie.

```java
// Instantieer Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer Presentation-klasse voor de doel-PPTX (waar de dia naartoe moet worden gekloond)
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
Als u een dia uit één presentatie wilt klonen en deze in een andere presentatiedocument wilt gebruiken, op een specifieke positie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de presentatie bevat waaraan de dia moet worden toegevoegd.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door te verwijzen naar de Slides‑verzameling die wordt blootgesteld door het Presentation‑object van de doelpresentatie.
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter door aan de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode.
1. Schrijf het aangepaste doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van index nul van de bronpresentatie) gekloond naar index 1 (positie 2) van de doelpresentatie.

```java
// Instantieer Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer Presentation-klasse voor de doel-PPTX (waar de dia naartoe moet worden gekloond)
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
Als u een dia met een masterdia moet klonen van een bronpresentatie naar een andere presentatie, moet u eerst de gewenste masterdia van de bronpresentatie naar de doelpresentatie klonen. Vervolgens gebruikt u die masterdia om de dia met master te klonen. De [**addClone(ISlide,IMasterSlide,boolean)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) verwacht een masterdia uit de doelpresentatie in plaats van uit de bronpresentatie. Om de dia met een master te klonen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia wordt gekloond.
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de doelpresentatie bevat waarnaar de dia wordt gekloond.
1. Open de te klonen dia samen met de masterdia.
1. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterSlideCollection) klasse door te verwijzen naar de Masters‑verzameling die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object van de doelpresentatie.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterSlideCollection) object en geef de master uit de bron‑PPTX door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
1. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door de referentie naar de Slides‑verzameling in te stellen die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object van de doelpresentatie.
1. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie die moet worden gekloond en de masterdia als parameters aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides/ISlide-) methode.
1. Schrijf het aangepaste doelpresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met een master (die zich op index nul van de bronpresentatie bevindt) gekloond naar het einde van de doelpresentatie met een master van de bron‑dia.

```java
// Instantieer Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantieer Presentation-klasse voor de doelpresentatie (waar de dia naartoe moet worden gekloond)
    Presentation destPres = new Presentation();
    try {
        // Instantieer ISlide uit de verzameling dia's in de bronpresentatie samen met
        // Masterdia
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kloon de gewenste masterdia van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kloon de gewenste masterdia van de bronpresentatie naar de verzameling masters in de
        // Doelpresentatie
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // Verzameling dia's in de doelpresentatie
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

## **Kloon een dia aan het einde van een gespecificeerde sectie**
Als u een dia wilt klonen en vervolgens in hetzelfde presentatie‑bestand maar in een andere sectie wilt plaatsen, gebruik dan de [**addClone**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) methode die wordt blootgesteld door de [**ISlideCollection**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) interface. Aspose.Slides voor Android via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en vervolgens die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment toont hoe u een dia kunt klonen en de gekloonde dia in een gespecificeerde sectie kunt invoegen.

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

## **FAQ**

**Worden aantekeningen voor de spreker en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren worden meegenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/androidjava/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingebedde gegevens worden gekopieerd. Als de grafiek was gekoppeld aan een externe bron (bijv. een OLE‑ingebedde werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/androidjava/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon beheersen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/androidjava/slide-section/). Als de doelsectie nog niet bestaat, maakt u deze eerst aan en verplaatst u de dia daarna erin.