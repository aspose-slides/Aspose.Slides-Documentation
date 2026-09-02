---
title: Kloon presentatiedia's op Android
linktitle: Dia's klonen
type: docs
weight: 35
url: /nl/androidjava/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Dupliceer PowerPoint-dia's met Aspose.Slides voor Android. Volg onze heldere Java-codevoorbeelden om PPT-creatie in seconden te automatiseren en handmatig werk te elimineren."
---
## **Introductie**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for Android via Java maakt het ook mogelijk om een kopie of kloon van een dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het klonen van een dia creëert een nieuwe dia die door ontwikkelaars kan worden bewerkt zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for Android via Java biedt de (een verzameling van [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide) objecten) die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object de methoden [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) en [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) om de bovenstaande soorten dia‑klonen uit te voeren.

## **Kloon een dia aan het einde van een presentatie**
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door te refereren naar de Slides‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object.
3. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia als parameter aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
4. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (die zich op de eerste positie – index nul – van de presentatie bevindt) gekloond naar het einde van de presentatie.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand voorstelt
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
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand maar op een andere positie wilt gebruiken, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Instantieer de klasse door te refereren naar de [**Slides**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object.
3. Roep de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de te klonen dia samen met de index voor de nieuwe positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (die zich op index 1 – positie 2 – van de presentatie bevindt) gekloond naar index 2 – positie 3 – van de presentatie.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Haal de collectie dia's op in dezelfde presentatie
    ISlideCollection slds = pres.getSlides();

    // Kloon de gewenste dia naar de gespecificeerde index in dezelfde presentatie
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Schrijf de aangepaste presentatie naar schijf
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kloon een dia aan het einde van een andere presentatie**
Als je een dia uit één presentatie wilt klonen en in een andere presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond wordt.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bestemmingspresentatie bevat waaraan de dia toegevoegd zal worden.
3. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) klasse door te refereren naar de [**Slides**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) collectie die wordt blootgesteld door het Presentation‑object van de bestemmingspresentatie.
4. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie als parameter aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
5. Schrijf het gewijzigde bestemmings‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) gekloond naar het einde van de bestemmingspresentatie.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
    Presentation destPres = new Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar het einde van de verzameling dia's in de bestemmingspresentatie
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Schrijf de bestemmingspresentatie naar schijf
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia naar een andere positie in een andere presentatie**
Als je een dia uit één presentatie wilt klonen en in een andere presentatiedocument op een specifieke positie wilt gebruiken:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond wordt.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bestemmingspresentatie bevat waaraan de dia toegevoegd zal worden.
3. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door te refereren naar de Slides‑collectie die wordt blootgesteld door het Presentation‑object van de bestemmingspresentatie.
4. Roep de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methode.
5. Schrijf het gewijzigde bestemmings‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (van index 0 van de bronpresentatie) gekloond naar index 1 (positie 2) van de bestemmingspresentatie.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
    Presentation destPres = new Presentation();
    try {
        // Kloon de gewenste dia van de bronpresentatie naar de gespecificeerde index in de bestemmingspresentatie
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Schrijf de bestemmingspresentatie naar schijf
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia op een specifieke positie in een andere presentatie**
Als je een dia met een masterslide wilt klonen van de ene presentatie naar de andere, moet je eerst de gewenste masterslide van de bronpresentatie naar de bestemmingspresentatie klonen. Vervolgens gebruik je die masterslide voor het klonen van de dia met masterslide. De [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) verwacht een masterslide uit de bestemmingspresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bronpresentatie bevat waaruit de dia gekloond wordt.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die de bestemmingspresentatie bevat waarnaar de dia gekloond wordt.
3. Toegang tot de te klonen dia samen met de masterslide.
4. Instantieer de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterSlideCollection) klasse door te refereren naar de Masters‑collectie die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object van de bestemmingspresentatie.
5. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IMasterSlideCollection) object en geef de master uit de bron‑PPTX die gekloond moet worden als parameter aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
6. Instantieer de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) klasse door de referentie naar de Slides‑collectie te zetten die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) object van de bestemmingspresentatie.
7. Roep de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode aan die wordt blootgesteld door het [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) object en geef zowel de dia uit de bronpresentatie als de masterslide als parameters aan de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode.
8. Schrijf het gewijzigde bestemmings‑presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met master (die zich op index 0 van de bronpresentatie bevindt) naar het einde van de bestemmingspresentatie gekloond met een master van de bron‑dia.

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instantieer de Presentation-klasse voor de bestemmingspresentatie (waar de dia gekloond moet worden)
    Presentation destPres = new Presentation();
    try {
        // Instantieer ISlide uit de collectie dia's in de bronpresentatie samen met
        // Master-dia
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
        // bestemmingspresentatie
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
        // collectie dia's in de bestemmingspresentatie
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Sla de bestemmingspresentatie op naar schijf
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Kloon een dia aan het einde van een opgegeven sectie**
Als je een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand maar in een andere sectie wilt plaatsen, gebruik dan de [**addClone**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) methode die wordt blootgesteld door de [**ISlideCollection**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) interface. Aspose.Slides for Android via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment laat zien hoe je een dia kloont en de gekloonde dia in een opgegeven sectie invoegt.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Sla de bestemmingspresentatie op naar schijf
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Zorg voor overeenkomende dia‑grootte**

Wanneer je dia’s kloont naar een andere presentatie, zorg er dan voor dat de bestemmingspresentatie dezelfde dia‑grootte heeft als de bron. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde vormen niet automatisch – hun oorspronkelijke coördinaten en afmetingen blijven behouden, waardoor de inhoud mogelijk misaligned raakt of buiten de dia‑grenzen uitsteekt.

Je kunt de dia‑grootte van de bestemmingspresentatie op de bron afstemmen vóór het klonen van de master en de dia:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Doe dit vóór het klonen van de master en de dia.

## **FAQ**

**Worden spreker‑notities en beoordelings‑commentaren gekloond?**

Ja. De notitie‑pagina en beoordelings‑commentaren zijn inbegrepen in de kloon. Als je ze niet wilt, [verwijder ze](/slides/nl/androidjava/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten data worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/androidjava/manage-ole/). Controleer na het verplaatsen tussen bestanden de beschikbaarheid van de data en het vernieuwingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. Je kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/androidjava/slide-section/). Als de doelsectie nog niet bestaat, maak die eerst aan en verplaats vervolgens de dia erheen.