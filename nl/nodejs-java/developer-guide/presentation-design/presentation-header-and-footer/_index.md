---
title: Beheer presentatiekoppen en -voetteksten in JavaScript
linktitle: Koptekst & Voettekst
type: docs
weight: 140
url: /nl/nodejs-java/presentation-header-and-footer/
keywords:
  - koptekst
  - koptekst tekst
  - voettekst
  - voettekst tekst
  - koptekst instellen
  - voettekst instellen
  - hand-out
  - notities
  - PowerPoint
  - OpenDocument
  - presentatie
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Gebruik JavaScript en Aspose.Slides voor Node.js om kop- en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides stelt u in staat de instellingen voor kop- en voetteksten in PowerPoint‑presentaties te beheren. Kop‑ en voetteksten worden op het niveau van de présentatiemaster beheerd, en de API biedt methoden om de voettekst in te stellen, de zichtbaarheid van de voettekst te wijzigen en de koptekst op master‑notitieslides bij te werken.

U kunt ook kop‑ en voetteksten beheren voor hand‑out‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en tekst van kop‑, voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduiders voor de notities‑master, alle onderliggende notitieslides of een individuele notitieslide.

## **Kop‑ en voettekst beheren in presentatie**
Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```javascript
// Presentatie laden
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Voettekst instellen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Koptekst openen en bijwerken
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Presentatie opslaan
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Kop‑ en voettekst beheren in hand‑out‑ en notitieslides**
Aspose.Slides voor Node.js via Java ondersteunt kop‑ en voettekst in hand‑out‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) die een video bevat.
- Wijzig de kop‑ en voettekstinstellingen voor de notities‑master en alle notitieslides.
- Maak de voettekst‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Maak de datum‑en‑tijd‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Wijzig de kop‑ en voettekstinstellingen alleen voor de eerste notitieslide.
- Maak de kop‑plaatsaanduiding op de notitieslide zichtbaar.
- Stel de tekst in voor de kop‑plaatsaanduiding van de notitieslide.
- Stel de tekst in voor de datum‑tijd‑plaatsaanduiding van de notitieslide.
- Schrijf het gewijzigde presentatiebestand.

Code‑fragment wordt hieronder gegeven.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Wijzig kop- en voettekstinstellingen voor de notities-master en alle notitieslides
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// maak de master-notitieslide en alle onderliggende voettekst-plaatsaanduidingen zichtbaar
        headerFooterManager.setFooterAndChildFootersVisibility(true);// maak de master-notitieslide en alle onderliggende koptekst-plaatsaanduidingen zichtbaar
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// maak de master-notitieslide en alle onderliggende dia-nummer-plaatsaanduidingen zichtbaar
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// maak de master-notitieslide en alle onderliggende datum-en-tijd-plaatsaanduidingen zichtbaar
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// stel tekst in voor de master-notitieslide en alle onderliggende koptekst-plaatsaanduidingen
        headerFooterManager.setFooterAndChildFootersText("Footer text");// stel tekst in voor de master-notitieslide en alle onderliggende voettekst-plaatsaanduidingen
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// stel tekst in voor de master-notitieslide en alle onderliggende datum-en-tijd-plaatsaanduidingen
    }
    // Wijzig kop- en voettekstinstellingen alleen voor de eerste notitieslide
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// maak deze notitieslide-koptekst-plaatsaanduiding zichtbaar
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// maak deze notitieslide-voettekst-plaatsaanduiding zichtbaar
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// maak deze notitieslide-dia-nummer-plaatsaanduiding zichtbaar
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// maak deze notitieslide-datum-tijd-plaatsaanduiding zichtbaar
        headerFooterManager.setHeaderText("New header text");// stel tekst in voor de notitieslide-koptekst-plaatsaanduiding
        headerFooterManager.setFooterText("New footer text");// stel tekst in voor de notitieslide-voettekst-plaatsaanduiding
        headerFooterManager.setDateTimeText("New date and time text");// stel tekst in voor de notitieslide-datum-tijd-plaatsaanduiding
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik een “kop” toevoegen aan gewone slides?**

In PowerPoint bestaat een “kop” alleen voor notities en hand‑outs; op gewone slides zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides is dit dezelfde beperking: kop alleen voor Notes/Handout, en op slides – Footer/DateTime/SlideNumber.

**Wat als de lay‑out geen voettekstgebied bevat — kan ik de zichtbaarheid “activeren”?**

Ja. Controleer de zichtbaarheid via de kop‑/voettekst‑beheerder en schakel deze in indien nodig. Deze API‑indicatoren en methoden zijn bedoeld voor situaties waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe kan ik het dia‑nummer laten beginnen bij een waarde anders dan 1?**

Stel het eerste dia‑nummer van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld beginnen bij 0 of 10 en het nummer op de titel‑slide verbergen.

**Wat gebeurt er met kop‑ en voetteksten bij export naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Dat wil zeggen, als de elementen zichtbaar zijn op dia‑/notitiespagina’s, verschijnen ze ook in het uitvoerformaat, samen met de rest van de inhoud.