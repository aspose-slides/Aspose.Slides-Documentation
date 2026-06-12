---
title: Beheer presentatie-koppen en -voetteksten in Java
linktitle: Kop en Voettekst
type: docs
weight: 140
url: /nl/java/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voettekst
- kop instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Java om kop- en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides stelt u in staat om kop‑ en voettekstinstellingen te beheren in PowerPoint‑presentaties. Koppen en voetteksten worden beheerd op het niveau van de presentatiemeester, en de API biedt methoden om voettekst in te stellen, de zichtbaarheid van de voettekst te wijzigen en de koptekst op master‑notitieslides bij te werken.

U kunt ook koppen en voetteksten beheren voor handout‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en de tekst van de kop‑, voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen voor de notities‑master, alle onderliggende notitieslides of een individuele notitieslide.

## **Koppen en voetteksten beheren in een presentatie**
Aantekeningen van een specifieke dia kunnen worden verwijderd zoals weergegeven in het voorbeeld hieronder:

```java
// Presentatie laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Voettekst instellen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Toegang en Koptekst bijwerken
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Presentatie opslaan
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Methode om Kop/Voettekst tekst in te stellen
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Koppen en voetteksten beheren op handout‑ en notitieslides**
Aspose.Slides voor Java ondersteunt Kop en Voettekst in handout‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentatie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) die een video bevat.
- Wijzig de Kop‑ en Voettekst‑instellingen voor de notities‑master en alle notitieslides.
- Maak de voettekst‑plaatsaanduidingen van de master‑notitieslide en alle onderliggende zichtbaar.
- Maak de datum‑ en tijd‑plaatsaanduidingen van de master‑notitieslide en alle onderliggende zichtbaar.
- Wijzig de Kop‑ en Voettekst‑instellingen alleen voor de eerste notitieslide.
- Maak de Kop‑plaatsaanduiding van de notitieslide zichtbaar.
- Stel de tekst in voor de Kop‑plaatsaanduiding van de notitieslide.
- Stel de tekst in voor de Datum‑tijd‑plaatsaanduiding van de notitieslide.
- Schrijf het gewijzigde presentatie‑bestand weg.

Codefragment is geleverd in het onderstaande voorbeeld.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Kop- en voettekstinstellingen wijzigen voor notities‑master en alle notitieslides
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // maak de master‑notitieslide en alle onderliggende Footer‑plaatsaanduidingen zichtbaar
        headerFooterManager.setFooterAndChildFootersVisibility(true); // maak de master‑notitieslide en alle onderliggende Header‑plaatsaanduidingen zichtbaar
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // maak de master‑notitieslide en alle onderliggende SlideNumber‑plaatsaanduidingen zichtbaar
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // maak de master‑notitieslide en alle onderliggende Datum‑en‑tijd‑plaatsaanduidingen zichtbaar

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // stel tekst in voor master‑notitieslide en alle onderliggende Header‑plaatsaanduidingen
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // stel tekst in voor master‑notitieslide en alle onderliggende Footer‑plaatsaanduidingen
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // stel tekst in voor master‑notitieslide en alle onderliggende Datum‑en‑tijd‑plaatsaanduidingen
    }

    // Kop- en voettekstinstellingen wijzigen voor alleen de eerste notitieslide
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // maak deze notitieslide Header‑plaatsaanduiding zichtbaar

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // maak deze notitieslide Footer‑plaatsaanduiding zichtbaar

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // maak deze notitieslide SlideNumber‑plaatsaanduiding zichtbaar

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // maak deze notitieslide Datum‑tijd‑plaatsaanduiding zichtbaar

        headerFooterManager.setHeaderText("New header text"); // stel tekst in voor notitieslide Header‑plaatsaanduiding
        headerFooterManager.setFooterText("New footer text"); // stel tekst in voor notitieslide Footer‑plaatsaanduiding
        headerFooterManager.setDateTimeText("New date and time text"); // stel tekst in voor notitieslide Datum‑tijd‑plaatsaanduiding
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik een "header" toevoegen aan gewone dia's?**

In PowerPoint bestaat een “Header” alleen voor notities en handouts; op gewone dia's zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides geldt dezelfde beperking: header alleen voor Notities/Handout, en op dia’s – Voettekst/Datum‑tijd/Dia‑nummer.

**Wat als de lay-out geen voettekstgebied bevat—kan ik de zichtbaarheid “inschakelen”?**

Ja. Controleer de zichtbaarheid via de kop‑/voettekst‑beheerder en schakel deze in indien nodig. Deze API‑indicatoren en methoden zijn bedoeld voor gevallen waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe kan ik het dia‑nummer laten beginnen vanaf een andere waarde dan 1?**

Stel het [eerste dia‑nummer](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld starten bij 0 of 10, en het nummer verbergen op de titel‑dia.

**Wat gebeurt er met koppen/voetteksten bij het exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone tekstelementen van de presentatie. Dat wil zeggen, als de elementen zichtbaar zijn op dia’s/notitiespagina’s, verschijnen ze ook in het geëxporteerde formaat samen met de rest van de inhoud.