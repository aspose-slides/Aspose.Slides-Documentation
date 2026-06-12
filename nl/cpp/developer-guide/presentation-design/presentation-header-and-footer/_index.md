---
title: Beheer presentatiekoppen en -voetteksten in C++
linktitle: Kop en voettekst
type: docs
weight: 140
url: /nl/cpp/presentation-header-and-footer/
keywords:
- kop
- koptekst
- voettekst
- voetteksttekst
- kop instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Gebruik Aspose.Slides voor C++ om koppen en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides stelt u in staat om de instellingen voor kop‑ en voetteksten in PowerPoint‑presentaties te beheren. Kop‑ en voetteksten worden op het master‑niveau van de presentatie afgehandeld, en de API biedt methoden om voetteksttekst in te stellen, de zichtbaarheid van de voettekst te wijzigen en de kopteksttekst bij te werken op master‑notitieslides.

U kunt ook kop‑ en voetteksten beheren voor hand‑out‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en de tekst van de kop‑, voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen voor de notities‑master, alle onderliggende notitieslides, of een individuele notitieslide.

## **Kop‑ en voettekst beheren**

Notities van een bepaalde dia kunnen worden bijgewerkt zoals weergegeven in het onderstaande voorbeeld:

``` cpp
// Functie om kop-/voettekst in te stellen
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Presentatie laden
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Voettekst instellen
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Toegang tot en bijwerken van koptekst
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Presentatie opslaan
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Kop‑ en voetteksten beheren op hand‑out‑ en notitieslides**
Aspose.Slides voor C++ ondersteunt Kop‑ en voetteksten in hand‑out‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentatie](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)die een video bevat.
- Wijzig de kop‑ en voettekstinstellingen voor de notities‑master en alle notitieslides.
- Maak de voettekst‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Maak de datum‑en‑tijd‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Wijzig de kop‑ en voettekstinstellingen alleen voor de eerste notitieslide.
- Maak de kop‑plaatsaanduiding op de notitieslide zichtbaar.
- Stel de tekst in voor de kop‑plaatsaanduiding op de notitieslide.
- Stel de tekst in voor de datum‑tijd‑plaatsaanduiding op de notitieslide.
- Schrijf het gewijzigde presentatie‑bestand weg.

Code‑fragment is gegeven in het onderstaande voorbeeld.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Wijzig de instellingen voor kop‑ en voetteksten voor de notities‑master en alle notitieslides
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    // maak de master‑notitieslide en alle onderliggende voettekst‑plaatsaanduidingen zichtbaar
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
    // maak de master‑notitieslide en alle onderliggende kop‑plaatsaanduidingen zichtbaar
    headerFooterManager->SetFooterAndChildFootersVisibility(true);
    // maak de master‑notitieslide en alle onderliggende dia‑nummer‑plaatsaanduidingen zichtbaar
    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
    // maak de master‑notitieslide en alle onderliggende datum‑tijd‑plaatsaanduidingen zichtbaar
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    // stel tekst in voor de master‑notitieslide en alle onderliggende kop‑plaatsaanduidingen
    headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
    // stel tekst in voor de master‑notitieslide en alle onderliggende voettekst‑plaatsaanduidingen
    headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
    // stel tekst in voor de master‑notitieslide en alle onderliggende datum‑tijd‑plaatsaanduidingen
    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Wijzig de kop‑ en voettekstinstellingen alleen voor de eerste notitieslide
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
    auto headerFooterManager = notesSlide->get_HeaderFooterManager();
    if (!headerFooterManager->get_IsHeaderVisible())
    {
        // maak deze notitieslide‑kop‑plaatsaanduiding zichtbaar
        headerFooterManager->SetHeaderVisibility(true);
    }

    if (!headerFooterManager->get_IsFooterVisible())
    {
        // maak deze notitieslide‑voettekst‑plaatsaanduiding zichtbaar
        headerFooterManager->SetFooterVisibility(true);
    }

    if (!headerFooterManager->get_IsSlideNumberVisible())
    {
        // maak deze notitieslide‑dia‑nummer‑plaatsaanduiding zichtbaar
        headerFooterManager->SetSlideNumberVisibility(true);
    }
    
    if (!headerFooterManager->get_IsDateTimeVisible())
    {
        // maak deze notitieslide‑datum‑tijd‑plaatsaanduiding zichtbaar
        headerFooterManager->SetDateTimeVisibility(true);
    }
    
    // stel tekst in voor de notitieslide‑kop‑plaatsaanduiding
    headerFooterManager->SetHeaderText(u"New header text");
    // stel tekst in voor de notitieslide‑voettekst‑plaatsaanduiding
    headerFooterManager->SetFooterText(u"New footer text");
    // stel tekst in voor de notitieslide‑datum‑tijd‑plaatsaanduiding
    headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **Veelgestelde vragen**

**Kan ik een "kop" toevoegen aan reguliere dia's?**

In PowerPoint bestaat een "kop" alleen voor notities en hand‑outs; op reguliere dia's zijn de ondersteunde elementen de voettekst, datum/tijd en dia‑nummer. In Aspose.Slides geldt dezelfde beperking: kop alleen voor Notities/Hand‑out, en op dia's — Voettekst/Datum‑tijd/Dia‑nummer.

**Wat als de lay‑out geen voettekstgebied bevat—kan ik de zichtbaarheid "inschakelen"?**

Ja. Controleer de zichtbaarheid via de kop‑/voettekst‑beheerder en schakel deze in indien nodig. Deze API‑indicatoren en methoden zijn ontworpen voor situaties waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe zorg ik ervoor dat het dia‑nummer begint bij een andere waarde dan 1?**

Stel het [eerste dia‑nummer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/set_firstslidenumber/) van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld beginnen bij 0 of 10, en het nummer op de titel‑dia verbergen.

**Wat gebeurt er met kop‑ en voetteksten bij het exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Dat wil zeggen, als de elementen zichtbaar zijn op dia’s/notitiespagina’s, verschijnen ze ook in het uitvoerformaat samen met de rest van de inhoud.