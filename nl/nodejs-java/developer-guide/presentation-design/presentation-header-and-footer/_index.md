---
title: Beheer presentatiekopt- en voetteksten in JavaScript
linktitle: Koptekst en Voettekst
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
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u koptekst-, voettekst-, datum-tijd- en dia-nummer-plaatsaanduidingen op dia's, notitiepagina's en handouts kunt beheren met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop‑ en voettekst‑plaatsaanduidingen afhankelijk van het paginatype. Aspose.Slides voor Node.js via Java stelt u in staat de tekst en zichtbaarheid van deze plaatsaanduidingen te beheersen via kop‑/voettekst‑managerklassen.

De beschikbare plaatsaanduidingen hangen af van de reikwijdte:

| Bereik | Koptekst | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitiedia | Ja | Ja | Ja | Ja |
| Handout‑master | Ja | Ja | Ja | Ja |

Een regulier presentatiedia heeft geen koptekst‑plaatsaanduiding. Kopteksten zijn beschikbaar op notitiepagina’s en handouts. Voor reguliere dia’s gebruikt u in plaats daarvan de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen.

De reikwijdte van een wijziging hangt af van de manager die u gebruikt. De [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideheaderfootermanager/) klasse stuurt één regulier dia aan. De [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) klasse stuurt één notitiedia aan. Master‑ en layout‑managers kunnen de instellingen ook doorvoeren naar afhankelijke dia’s, terwijl de [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) klasse de handout‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s bestaat de basisworkflow uit het benaderen van de kop‑/voettekst‑manager van elke dia, het instellen van de voettekst‑ en datum/tijd‑tekst, het inschakelen van de benodigde plaatsaanduidingen, en het opslaan van de presentatie. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen hun zichtbaarheid te regelen.

Gebruik [`setFooterText`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) en [`setDateTimeText`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) om tekst in te stellen, en gebruik [`setFooterVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) en [`setSlideNumberVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) om de overeenkomstige plaatsaanduidingen weer te geven.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummer‑zichtbaarheid toe op alle reguliere dia’s:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één dia wilt bijwerken, benader dan die dia rechtstreeks via de [`getSlides`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslides/)‑methode in plaats van door de volledige collectie te itereren.

## **Kop‑ en voetteksten instellen op de notitie‑master**

De notitie‑master bepaalt gemeenschappelijke opmaak en plaatsaanduidingsgedrag voor notitiepagina’s. Gebruik de [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) klasse wanneer u alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt koptekst, voettekst en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatsaanduidingen zichtbaar op die master:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [`getMasterNotesSlide`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) methode retourneert `null` wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van de notitie‑master toepassen op onderliggende notitiedia’s**

Een notitie‑master kan de kop‑ en voettekstinstellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de speciale propagatiemethoden op de [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) wanneer dezelfde instellingen over de hele notitie‑hiërarchie moeten worden toegepast.

Bijvoorbeeld, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) en [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) werken de notitie‑master‑koptekst en alle onderliggende kopteksten bij. Gelijkwaardige methoden zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De propagatiemethoden die hierboven werden gebruikt, zijn [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) en [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Kop‑ en voetteksten instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) klasse wanneer u alleen die notitiepagina wilt aanpassen.

De [`addNotesSlide`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) methode retourneert de notitiedia voor de huidige dia en maakt er een aan als deze nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die bij de eerste presentatiedia hoort:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u eerst instellingen van de notitie‑master doorvoert en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen u die notitiepagina onafhankelijk aanpassen.

## **Kop‑ en voetteksten instellen op de handout‑master**

Handout‑pagina’s gebruiken de handout‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatsaanduidingen. In tegenstelling tot notitiepagina’s worden handout‑instellingen beheerd via de handout‑master in plaats van via individuele handout‑dia’s.

Gebruik [`getMasterHandoutSlide`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) om de handout‑master te benaderen. Als deze niet aanwezig is, roep dan [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) aan om de standaard handout‑master te creëren.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Begrijp reikwijdte en overerving**

Kies de kop‑/voettekst‑manager die overeenkomt met de reikwijdte die u wilt wijzigen:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideheaderfootermanager/) wijzigt voettekst-, datum/tijd- en dia‑nummerinstellingen voor één reguliere dia.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) beheert een layout‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) beheert een reguliere dia‑master en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) beheert de notitie‑master en kan instellingen doorvoeren naar alle afhankelijke notitiedia’s.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een koptekst‑plaatsaanduiding naast voettekst, datum/tijd en dia‑nummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) wijzigt de handout‑master en ondersteunt alle vier de plaatsaanduidingstypen.

Gebruik propagatie vanaf een master of layout wanneer dezelfde instelling door de hele hiërarchie moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer u een lokale instelling voor één pagina nodig heeft.

## **FAQ**

**Kan ik een koptekst toevoegen aan een regulier dia?**

Nee. PowerPoint definieert geen koptekst‑plaatsaanduiding voor reguliere dia’s. Op reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatsaanduidingen. Koptekst‑plaatsaanduidingen zijn beschikbaar op notitiepagina’s en handouts.

**Wat als een voettekst‑, datum/tijd‑ of dia‑nummer‑plaatsaanduiding niet zichtbaar is?**

Gebruik de overeenkomstige kop‑/voettekst‑manager om de zichtbaarheid te controleren en deze in te schakelen wanneer nodig. Bijvoorbeeld, [`isFooterVisible`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) meldt of een voettekst‑plaatsaanduiding aanwezig is, en [`setFooterVisibility`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) wijzigt de zichtbaarheid.

**Hoe start ik de dia‑nummering vanaf een andere waarde dan 1?**

Roep de [`setFirstSlideNumber`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/setfirstslidenumber/)‑methode van de presentatie aan. De dia‑nummer‑plaatsaanduidingen gebruiken vervolgens de bijgewerkte nummeringsreeks.

**Wat gebeurt er met kop‑ en voetteksten bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekstelementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Hun weergave hangt af van het paginatype dat wordt geëxporteerd en de bijbehorende plaatsaanduiding‑zichtbaarheidsinstellingen.