---
title: Toegang tot presentatiedia's op Android
linktitle: Dia openen
type: docs
weight: 20
url: /nl/androidjava/access-slide-in-presentation/
keywords:
- dia openen
- dia index
- dia id
- dia positie
- positie wijzigen
- dia eigenschappen
- dia nummer
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u dia's kunt openen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android. Verhoog de productiviteit met Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u dia's in een presentatie kunt openen en beheren met Aspose.Slides. Het laat zien hoe u dia's kunt ophalen op hun nulgebaseerde index uit de dia‑collectie en hoe u een dia kunt benaderen op zijn unieke ID met de `getSlideById`‑methode.

U leert ook hoe u de positie van een dia kunt wijzigen met de `setSlideNumber`‑methode en hoe u het start‑dia‑nummer voor een presentatie kunt definiëren met de `setFirstSlideNumber`‑methode. De voorbeelden demonstreren het laden van een presentatie, het verkrijgen van dia‑referenties, het bijwerken van de volgorde of nummering van dia's, en het opslaan van de aangepaste presentatie.

## **Een dia benaderen op index**

Alle dia's in een presentatie zijn numeriek gerangschikt op basis van hun positie, beginnend bij 0. De eerste dia is toegankelijk via index 0; de tweede dia via index 1; enzovoort.

De Presentation‑klasse, die een presentatie‑bestand representeert, stelt alle dia's beschikbaar als een [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) (collectie van [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) objecten). Deze Java‑code toont hoe u een dia via zijn index kunt benaderen:

```java
// Maakt een Presentation-object aan dat een presentatie‑bestand voorstelt
Presentation pres = new Presentation("demo.pptx");
try {
    // Benadert een dia via zijn dia‑index
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Een dia benaderen op ID**

Elke dia in een presentatie heeft een uniek ID. U kunt de [getSlideById](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideById-long-)‑methode (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse) gebruiken om dat ID te targeten. Deze Java‑code toont hoe u een geldig dia‑ID opgeeft en die dia benadert via de [getSlideById](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlideById-long-)‑methode:

```java
// Maakt een Presentation-object aan dat een presentatie‑bestand voorstelt
Presentation pres = new Presentation("demo.pptx");
try {
    // Haalt een dia‑ID op
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Benadert de dia via zijn ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Positie van de dia wijzigen**

Aspose.Slides maakt het mogelijk om de positie van een dia te wijzigen. U kunt bijvoorbeeld aangeven dat de eerste dia de tweede dia moet worden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal de referentie van de dia (wiens positie u wilt wijzigen) op via zijn index.
1. Stel een nieuwe positie in voor de dia via de [setSlideNumber](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#setSlideNumber-int-)‑eigenschap.
1. Sla de aangepaste presentatie op.

Deze Java‑code demonstreert een bewerking waarbij de dia op positie 1 wordt verplaatst naar positie 2:

```java
// Maakt een Presentation-object aan dat een presentatie‑bestand voorstelt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Haalt de dia op waarvan de positie wordt gewijzigd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Stelt de nieuwe positie voor de dia in
    sld.setSlideNumber(2);
    
    // Slaat de gewijzigde presentatie op
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

De eerste dia werd de tweede; de tweede dia werd de eerste. Wanneer u de positie van een dia wijzigt, worden de andere dia's automatisch aangepast.

## **Dia-nummer instellen**

Met de [setFirstSlideNumber](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-)‑eigenschap (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse) kunt u een nieuw nummer opgeven voor de eerste dia in een presentatie. Deze bewerking zorgt ervoor dat de overige dia‑nummers opnieuw worden berekend.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Haal het dia‑nummer op.
1. Stel het dia‑nummer in.
1. Sla de aangepaste presentatie op.

Deze Java‑code demonstreert een bewerking waarbij het eerste dia‑nummer wordt ingesteld op 10:

```java
// Maakt een Presentation-object aan dat een presentatie‑bestand voorstelt
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Haalt het dia‑nummer op
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Stelt het dia‑nummer in
    pres.setFirstSlideNumber(10);
	
    // Slaat de gewijzigde presentatie op
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Als u de eerste dia wilt overslaan, kunt u de nummering laten beginnen bij de tweede dia (en de nummering voor de eerste dia verbergen) op deze manier:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Stelt het nummer in voor de eerste dia van de presentatie
    presentation.setFirstSlideNumber(0);

    // Toont dianummers voor alle dia's
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Verbergt het dianummer voor de eerste dia
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Slaat de gewijzigde presentatie op
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Komt het dia‑nummer dat een gebruiker ziet overeen met de nulgebaseerde index van de collectie?**

Het op een dia weergegeven nummer kan vanaf een willekeurige waarde starten (bijv. 10) en hoeft niet overeen te komen met de index; de relatie wordt bepaald door de instelling van het [eerste dia‑nummer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) van de presentatie.

**Hebben verborgen dia's invloed op de indexering?**

Ja. Een verborgen dia blijft in de collectie aanwezig en wordt meegeteld bij het indexeren; “verborgen” heeft betrekking op de weergave, niet op de positie in de collectie.

**Verandert de index van een dia wanneer andere dia's worden toegevoegd of verwijderd?**

Ja. Indexen reflecteren altijd de huidige volgorde van de dia's en worden herberekend bij invoegen, verwijderen en verplaatsen.