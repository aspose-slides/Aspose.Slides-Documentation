---
title: Beheer kop- en voetteksten van presentaties op Android
linktitle: Koptekst & Voettekst
type: docs
weight: 140
url: /nl/androidjava/presentation-header-and-footer/
keywords:
- koptekst
- koptekst
- voettekst
- voettekst
- koptekst instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides voor Android via Java om kop- en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Met Aspose.Slides kunt u de instellingen voor kop- en voetteksten beheren in PowerPoint‑presentaties. Kop‑ en voetteksten worden op masterniveau van de presentatie afgehandeld, en de API biedt methoden om voetteksttekst in te stellen, de zichtbaarheid van de voettekst te wijzigen en de kopteksttekst bij te werken op master‑notitieslides.

U kunt ook kop‑ en voetteksten beheren voor afdruk‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en tekst van kop‑, voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen voor de notitie‑master, alle onderliggende notitieslides, of een individuele notitieslide.

## **Kop‑ en voetteksten beheren in een presentatie**
Notities van een specifieke dia kunnen worden verwijderd zoals weergegeven in het onderstaande voorbeeld:

```java
// Presentatie laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Voettekst instellen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Koptekst benaderen en bijwerken
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
// Methode om kop- en voettekst in te stellen
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

## **Kop‑ en voetteksten beheren op afdruk‑ en notitieslides**
Aspose.Slides voor Android via Java ondersteunt Kop‑ en voettekst op afdruk‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) die een video bevat.
- Wijzig de Kop‑ en voetteksten‑instellingen voor de notitie‑master en alle notitieslides.
- Zet de master‑notitieslide en alle onderliggende voettekst‑plaatsaanduidingen zichtbaar.
- Zet de master‑notitieslide en alle onderliggende datum‑ en tijd‑plaatsaanduidingen zichtbaar.
- Wijzig de Kop‑ en voetteksten‑instellingen alleen voor de eerste notitieslide.
- Zet de Kop‑plaatsaanduiding van de notitieslide zichtbaar.
- Stel de tekst in voor de Kop‑plaatsaanduiding van de notitieslide.
- Stel de tekst in voor de datum‑tijd‑plaatsaanduiding van de notitieslide.
- Schrijf het gewijzigde presentatiebestand.

Codefragment wordt hieronder gegeven.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Verander instellingen voor kop- en voettekst voor notitie-master en alle notitieslides
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

    // Verander instellingen voor kop- en voettekst voor alleen de eerste notitieslide
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

**Kan ik een "kop" toevoegen aan normale dia's?**

In PowerPoint bestaat een "Kop" alleen voor notities en hand-outs; op normale dia's zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides gelden dezelfde beperkingen: kop alleen voor Notities/Handout, en op dia's—Voettekst/Datum‑tijd/Dia‑nummer.

**Wat als de lay-out geen voettekstgebied bevat—kan ik de zichtbaarheid "inschakelen"?**

Ja. Controleer de zichtbaarheid via de kop-/voettekst-beheerder en schakel deze in indien nodig. Deze API-indicatoren en methoden zijn ontworpen voor situaties waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe kan ik het dia‑nummer laten starten vanaf een andere waarde dan 1?**

Stel het [eerste dia‑nummer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld starten op 0 of 10, en het nummer op de titeldia verbergen.

**Wat gebeurt er met kop-/voetteksten bij het exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Dat wil zeggen, als de elementen zichtbaar zijn op dia-/notitiepagina’s, verschijnen ze ook in het uitvoerformaat samen met de rest van de inhoud.