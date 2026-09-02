---
title: Beheer presentatie-headers en footers in PHP
linktitle: Header en Footer
type: docs
weight: 140
url: /nl/php-java/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voettekst-tekst
- header instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u footer-, datum-tijd-, dia-nummer- en header-plaatsvervangers op dia's, notitiepagina's en handouts beheert met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

PowerPoint gebruikt verschillende header- en footer‑plaatsvervangers, afhankelijk van het paginatype. Aspose.Slides voor PHP via Java stelt je in staat de tekst en zichtbaarheid van deze plaatsvervangers te beheren via header/footer‑managerklassen.

De beschikbare plaatsvervangers hangen af van de scope:

| Scope | Header | Footer | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notitie‑dia | Ja | Ja | Ja | Ja |
| Handout‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen header‑plaatsvervanger. Headers zijn beschikbaar op notitiepagina’s en handouts. Voor reguliere dia’s gebruik je in plaats daarvan de footer-, datum/tijd‑ en dia‑nummer‑plaatsvervangers.

De scope van een wijziging hangt af van de manager die je gebruikt. De [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideheaderfootermanager/)‑klasse beheert één reguliere dia. De [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslideheaderfootermanager/)‑klasse beheert één notitiedia. Master‑ en layout‑managers kunnen instellingen ook doorvoeren naar afhankelijke dia’s, terwijl de [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterhandoutslideheaderfootermanager/)‑klasse het handout‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s bestaat de basale werkstroom uit het benaderen van de header/footer‑manager van elke dia, het instellen van de voettekst‑ en datum/tijd‑tekst, het inschakelen van de vereiste plaatsvervangers, en het opslaan van de presentatie. Dia‑nummers worden door de presentatie gegenereerd, dus je hoeft alleen hun zichtbaarheid te beheren.

Gebruik [`setFooterText`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) en [`setDateTimeText`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) om tekst in te stellen, en gebruik [`setFooterVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) en [`setSlideNumberVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) om de overeenkomstige plaatsvervangers te tonen.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummer‑zichtbaarheid toe op alle reguliere dia’s:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Als je slechts één dia wilt bijwerken, benader die dia direct via de [`getSlides`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslides/)‑methode in plaats van door de volledige collectie te itereren.

## **Headers en footers instellen op de notitie‑master**

De notitie‑master definieert gemeenschappelijke opmaak en plaatsvervanger‑gedrag voor notitiepagina’s. Gebruik de [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/)‑klasse wanneer je alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt header, footer en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatsvervangers zichtbaar op die master:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De [`getMasterNotesSlide`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/)‑methode retourneert `null` wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van notitie‑master toepassen op onderliggende notitie‑dia’s**

Een notitie‑master kan header‑ en footer‑instellingen toepassen op zichzelf en op alle afhankelijke notitiedia’s. Gebruik de toegewijde propagatiemethoden op de [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/)‑klasse wanneer dezelfde instellingen over de notitie‑hiërarchie moeten worden toegepast.

Bijvoorbeeld, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) en [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) updaten de header van de notitie‑master en alle onderliggende headers. Equivalente methoden zijn beschikbaar voor footers, datum/tijd en dia‑nummers.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De hierboven gebruikte propagatiemethoden zijn [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) en [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Headers en footers instellen op een individuele notitiedia**

Een notitiedia behoort tot een specifieke reguliere dia. Gebruik de [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslideheaderfootermanager/)‑klasse wanneer je alleen die notitiepagina wilt aanpassen.

De [`addNotesSlide`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslidemanager/addnotesslide/)‑methode retourneert de notitiedia voor de huidige dia en maakt er één aan als deze nog niet bestaat. Het volgende voorbeeld configureert de notitiepagina die bij de eerste presentatiedia hoort:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Als je eerst instellingen vanuit de notitie‑master doorgeeft en daarna een individuele notitiedia wijzigt, laten de latere per‑dia‑instellingen je die notitiepagina onafhankelijk aanpassen.

## **Headers en footers instellen op de handout‑master**

Handout‑pagina’s gebruiken de handout‑master voor hun header‑, footer‑, datum/tijd‑ en paginanummer‑plaatsvervangers. In tegenstelling tot notitiepagina’s worden handout‑instellingen beheerd via de handout‑master in plaats van individuele handout‑dia’s.

Gebruik de [`getMasterHandoutSlide`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/)‑methode om de handout‑master te benaderen. Als deze niet aanwezig is, roep dan [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) aan om de standaard handout‑master te creëren.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Scope en overerving begrijpen**

Kies de header/footer‑manager die overeenkomt met de scope die je wilt wijzigen:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideheaderfootermanager/) verandert de footer-, datum/tijd- en dia‑nummer‑instellingen voor één reguliere dia.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslideheaderfootermanager/) beheert een layout‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslideheaderfootermanager/) beheert een reguliere dia‑master en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masternotesslideheaderfootermanager/) beheert de notitie‑master en kan instellingen doorvoeren naar alle afhankelijke notitiedia’s.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notesslideheaderfootermanager/) wijzigt één notitiedia en ondersteunt een header‑plaatsvervanger naast footer, datum/tijd en dia‑nummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) wijzigt de handout‑master en ondersteunt alle vier plaatsvervanger‑typen.

Gebruik propagatie vanuit een master‑ of layout‑manager wanneer dezelfde instelling door de hele hiërarchie heen moet gelden. Gebruik een individuele dia‑ of notitiedia‑manager wanneer je een lokale instelling voor één pagina nodig hebt.

## **FAQ**

**Kan ik een header toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen header‑plaatsvervanger voor reguliere dia’s. Op reguliere dia’s gebruik je de footer-, datum/tijd- en dia‑nummer‑plaatsvervangers. Header‑plaatsvervangers zijn beschikbaar op notitiepagina’s en handouts.

**Wat als een footer-, datum/tijd- of dia‑nummer‑plaatsvervanger niet zichtbaar is?**

Gebruik de overeenkomstige header/footer‑manager om de zichtbaarheid te controleren en deze indien nodig in te schakelen. Bijvoorbeeld, [`isFooterVisible`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) geeft aan of er een footer‑plaatsvervanger aanwezig is, en [`setFooterVisibility`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) wijzigt de zichtbaarheid.

**Hoe start ik de dia‑nummering vanaf een andere waarde dan 1?**

Roep de [`setFirstSlideNumber`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/setfirstslidenumber/)‑methode van de presentatie aan. De dia‑nummer‑plaatsvervangers gebruiken vervolgens de bijgewerkte nummeringsreeks.

**Wat gebeurt er met headers en footers bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare header‑ en footerelementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Hun uiterlijk hangt af van het geëxporteerde paginatype en de bijbehorende plaatsvervanger‑zichtbaarheidsinstellingen.