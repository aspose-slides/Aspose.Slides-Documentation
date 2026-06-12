---
title: Toegang tot presentatiedia's in JavaScript
linktitle: Dia toegang
type: docs
weight: 20
url: /nl/nodejs-java/access-slide-in-presentation/
keywords:
- toegang tot dia
- dia-index
- dia-id
- dia-positie
- positie wijzigen
- dia-eigenschappen
- dia-nummer
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u dia's in PowerPoint- en OpenDocument-presentaties kunt benaderen en beheren met Aspose.Slides voor Node.js. Verhoog de productiviteit met codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u dia's in een presentatie kunt benaderen en beheren met Aspose.Slides. Het toont hoe u dia's kunt ophalen op basis van hun nul‑gebaseerde index uit de dia‑collectie en hoe u een dia kunt benaderen via zijn unieke ID met de `getSlideById`‑methode.

U leert ook hoe u de positie van een dia kunt wijzigen met de `setSlideNumber`‑methode en hoe u het beginnende diapernummer voor een presentatie kunt instellen met de `setFirstSlideNumber`‑methode. De voorbeelden laten zien hoe u een presentatie laadt, dia‑referenties verkrijgt, de volgorde of nummering van dia's bijwerkt, en de aangepaste presentatie opslaat.

## **Dia benaderen op index**

Alle dia's in een presentatie worden numeriek gerangschikt op basis van de diapositie, beginnend bij 0. De eerste dia is toegankelijk via index 0; de tweede dia via index 1; enzovoort.

De Presentation‑klasse, die een presentatiebestand vertegenwoordigt, maakt alle dia's beschikbaar als een [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/)‑collectie (een verzameling van [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/)‑objecten). Deze JavaScript‑code laat zien hoe u een dia via zijn index kunt benaderen:

```javascript
// Maakt een Presentation-object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Benadert een dia via zijn dia-index
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Dia benaderen op ID**

Elke dia in een presentatie heeft een uniek ID. U kunt de [getSlideById](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSlideById-long-)‑methode (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse) gebruiken om dat ID te targeten. Deze JavaScript‑code laat zien hoe u een geldig dia‑ID opgeeft en die dia benadert via de [getSlideById](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSlideById-long-)‑methode:

```javascript
// Maakt een Presentation-object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Haalt een dia-ID op
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Benadert de dia via zijn ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Dia‑positie wijzigen**

Aspose.Slides stelt u in staat om de positie van een dia te wijzigen. Bijvoorbeeld, u kunt aangeven dat de eerste dia de tweede dia moet worden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal de referentie van de dia (waarvan u de positie wilt wijzigen) op via diens index
1. Stel een nieuwe positie voor de dia in via de [setSlideNumber](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#setSlideNumber-int-)‑eigenschap.
1. Sla de aangepaste presentatie op.

Deze JavaScript‑code demonstreert een bewerking waarbij de dia op positie 1 wordt verplaatst naar positie 2:

```javascript
// Maakt een Presentation-object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Haalt de dia op waarvan de positie zal worden gewijzigd
    var sld = pres.getSlides().get_Item(0);
    // Stelt de nieuwe positie voor de dia in
    sld.setSlideNumber(2);
    // Slaat de gewijzigde presentatie op
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

De eerste dia werd de tweede; de tweede dia werd de eerste. Wanneer u de positie van een dia wijzigt, worden de overige dia's automatisch aangepast.

## **Dia‑nummer instellen**

Met behulp van de [setFirstSlideNumber](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-)‑eigenschap (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse) kunt u een nieuw nummer voor de eerste dia in een presentatie opgeven. Deze bewerking zorgt ervoor dat de nummers van de overige dia's opnieuw worden berekend.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Haal het diapernummer op.
1. Stel het diapernummer in.
1. Sla de aangepaste presentatie op.

Deze JavaScript‑code demonstreert een bewerking waarbij het nummer van de eerste dia wordt ingesteld op 10:

```javascript
// Maakt een Presentation-object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Haalt het diapernummer op
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Stelt het diapernummer in
    pres.setFirstSlideNumber(10);
    // Slaat de gewijzigde presentatie op
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Als u de eerste dia wilt overslaan, kunt u de nummering starten vanaf de tweede dia (en de nummering voor de eerste dia verbergen) op de volgende manier:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Stelt het nummer in voor de eerste presentatiedia
    presentation.setFirstSlideNumber(0);
    // Toont dianummers voor alle dia's
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Verbergt het dianummer voor de eerste dia
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Slaat de gewijzigde presentatie op
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Veelgestelde vragen**

**Komt het diapernummer dat een gebruiker ziet overeen met de nul‑gebaseerde index van de collectie?**

Het nummer dat op een dia wordt weergegeven kan beginnen bij een willekeurige waarde (bijv. 10) en hoeft niet overeen te komen met de index; de relatie wordt bepaald door de instelling van het [first slide number](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) van de presentatie.

**Hebben verborgen dia's invloed op de indexering?**

Ja. Een verborgen dia blijft aanwezig in de collectie en wordt meegeteld bij de indexering; "verborgen" heeft betrekking op weergave, niet op de positie in de collectie.

**Verandert de index van een dia wanneer andere dia's worden toegevoegd of verwijderd?**

Ja. Indexen weerspiegelen altijd de huidige volgorde van de dia's en worden opnieuw berekend bij invoeg-, verwijder‑ en verplaats‑bewerkingen.