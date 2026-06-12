---
title: Beheer presentatie‑koppen en‑voetteksten in PHP
linktitle: Kop en Voettekst
type: docs
weight: 140
url: /nl/php-java/presentation-header-and-footer/
keywords:
- koptekst
- kopteksttekst
- voettekst
- voetteksttekst
- koptekst instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gebruik Aspose.Slides voor PHP via Java om kop- en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides stelt je in staat om de instellingen voor kop- en voetteksten in PowerPoint‑presentaties te beheren. Kop‑ en voetteksten worden op het niveau van de presentatiemaster afgehandeld, en de API biedt methoden om voetteksttekst in te stellen, de zichtbaarheid van de voettekst te wijzigen en de kopteksttekst op master‑notitieslides bij te werken.

Je kunt eveneens kop- en voetteksten beheren voor hand‑out‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en de tekst van de koptekst‑, voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen voor de notities‑master, alle onderliggende notitieslides, of een individuele notitieslide.

## **Beheer kop- en voetteksten in een presentatie**

Notities van een bepaalde dia kunnen worden verwijderd zoals in het onderstaande voorbeeld wordt getoond:

```php
  # Laad presentatie
  $pres = new Presentation("headerTest.pptx");
  try {
    # Instellen voettekst
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Toegang tot en bijwerken van koptekst
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Opslaan presentatie
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Beheer kop- en voetteksten op hand‑out‑ en notitieslides**
Aspose.Slides voor PHP via Java ondersteunt kop‑ en voetteksten in hand‑out‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) die een video bevat.
- Wijzig de kop‑ en voettekstinstellingen voor de notities‑master en alle notitieslides.
- Maak de master‑notitieslide en alle onderliggende voettekst‑plaatsaanduidingen zichtbaar.
- Maak de master‑notitieslide en alle onderliggende datum‑en‑tijd‑plaatsaanduidingen zichtbaar.
- Wijzig de kop‑ en voettekstinstellingen alleen voor de eerste notitieslide.
- Maak de notitieslide‑koptekst‑plaatsaanduiding zichtbaar.
- Stel tekst in voor de koptekst‑plaatsaanduiding van de notitieslide.
- Stel tekst in voor de datum‑tijd‑plaatsaanduiding van de notitieslide.
- Schrijf het aangepaste presentatie‑bestand weg.

Code‑fragment wordt hieronder weergegeven.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Wijzig kop- en voettekstinstellingen voor notities-master en alle notitieslides
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// maak de master-notitieslide en alle onderliggende voettekst-plaatsaanduidingen zichtbaar

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// maak de master-notitieslide en alle onderliggende koptekst-plaatsaanduidingen zichtbaar

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// maak de master-notitieslide en alle onderliggende dia-nummer-plaatsaanduidingen zichtbaar

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// maak de master-notitieslide en alle onderliggende datum-tijd-plaatsaanduidingen zichtbaar

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// stel tekst in voor de master-notitieslide en alle onderliggende koptekst-plaatsaanduidingen

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// stel tekst in voor de master-notitieslide en alle onderliggende voettekst-plaatsaanduidingen

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// stel tekst in voor de master-notitieslide en alle onderliggende datum-tijd-plaatsaanduidingen

    }
    # Wijzig kop- en voettekstinstellingen alleen voor de eerste notitieslide
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// maak deze notitieslide koptekst-plaatsaanduiding zichtbaar

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// maak deze notitieslide voettekst-plaatsaanduiding zichtbaar

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// maak deze notitieslide dia-nummer-plaatsaanduiding zichtbaar

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// maak deze notitieslide datum-tijd-plaatsaanduiding zichtbaar

      $headerFooterManager->setHeaderText("New header text");// stel tekst in voor de notitieslide koptekst-plaatsaanduiding

      $headerFooterManager->setFooterText("New footer text");// stel tekst in voor de notitieslide voettekst-plaatsaanduiding

      $headerFooterManager->setDateTimeText("New date and time text");// stel tekst in voor de notitieslide datum-tijd-plaatsaanduiding

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Kan ik een "header" toevoegen aan gewone dia's?**

In PowerPoint bestaat een “Header” alleen voor notities en hand‑outs; op gewone dia's zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides gelden dezelfde beperkingen: header alleen voor Notes/Handout, en op dia's — Footer/DateTime/SlideNumber.

**Wat gebeurt er als de lay-out geen voettekstgebied bevat—kan ik de zichtbaarheid “inschakelen”?**

Ja. Controleer de zichtbaarheid via de kop‑/voettekst‑beheerder en schakel deze in indien nodig. Deze API‑indicatoren en -methoden zijn bedoeld voor situaties waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe laat ik het dia‑nummer starten vanaf een andere waarde dan 1?**

Stel het [first slide number](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/setfirstslidenumber/) van de presentatie in; daarna wordt alle nummering opnieuw berekend. Bijvoorbeeld, je kunt starten bij 0 of 10, en het nummer op de titel‑dia verbergen.

**Wat gebeurt er met kop‑ en voetteksten bij het exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Met andere woorden, als de elementen zichtbaar zijn op dia’s/notities‑pagina’s, verschijnen ze ook in het uitvoerformaat, samen met de rest van de inhoud.