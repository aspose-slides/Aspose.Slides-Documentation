---
title: Beheer van presentatiekoppen en -voetteksten in .NET
linktitle: Koptekst en voettekst
type: docs
weight: 140
url: /nl/net/presentation-header-and-footer/
keywords:
- koptekst
- koptekst
- voettekst
- voetteksttekst
- koptekst instellen
- voettekst instellen
- handout
- notities
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u voettekst-, datum-tijd-, dia-nummer- en koptekst-plaatshouders op dia's, notitiepagina's en handouts kunt beheren met Aspose.Slides voor .NET."
---
## **Overzicht**

PowerPoint gebruikt verschillende kop‑ en voettekst‑plaatshouders afhankelijk van het paginatype. Aspose.Slides for .NET laat u de tekst en zichtbaarheid van deze plaatshouders beheren via kop‑/voettekst‑manager‑interfaces.

De beschikbare plaatshouders hangen af van de scope:

| Scope | Kop | Voettekst | Datum/tijd | Dia-/paginanummer |
|---|---|---|---|---|
| Reguliere dia | Nee | Ja | Ja | Ja |
| Notitie‑master | Ja | Ja | Ja | Ja |
| Notities‑dia | Ja | Ja | Ja | Ja |
| Handout‑master | Ja | Ja | Ja | Ja |

Een reguliere presentatiedia heeft geen kop‑plaatshouder. Koppen zijn beschikbaar op notitie‑pagina’s en handouts. Voor reguliere dia’s gebruikt u de voettekst‑, datum/tijd‑ en dia‑nummer‑plaatshouders.

De scope van een wijziging hangt af van de manager die u gebruikt. De[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/islideheaderfootermanager/)‑interface beheert één reguliere dia. De[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/inotesslideheaderfootermanager/)‑interface beheert één notities‑dia. Master‑ en lay‑out‑managers kunnen instellingen ook doorvoeren naar afhankelijke dia’s, terwijl de[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslideheaderfootermanager/)‑interface het handout‑master beheert.

## **Voettekst, datum/tijd en dia‑nummers instellen op reguliere dia’s**

Voor reguliere dia’s is de basisworkflow om de header/footer‑manager van elke dia te benaderen, de voettekst‑ en datum/tijd‑tekst in te stellen, de benodigde plaatshouders in te schakelen en de presentatie op te slaan. Dia‑nummers worden door de presentatie gegenereerd, dus u hoeft alleen de zichtbaarheid te regelen.

Gebruik[`SetFooterText`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) en[`SetDateTimeText`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) om tekst in te stellen, en[`SetFooterVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/),[`SetDateTimeVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) en[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) om de overeenkomstige plaatshouders te tonen.

Het volgende end‑to‑end‑voorbeeld past dezelfde voettekst, datum/tijd‑tekst en dia‑nummervisibiliteit toe op alle reguliere dia’s:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Als u slechts één dia wilt bijwerken, benader die dia direct via de[`Slides`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/)‑collectie in plaats van door de volledige collectie te itereren.

## **Koppen en voetteksten instellen op de notitie‑master**

De notitie‑master definieert gemeenschappelijke opmaak en plaatshouder‑gedrag voor notitie‑pagina’s. Gebruik de[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslideheaderfootermanager/)‑interface wanneer u alleen de notitie‑master zelf wilt wijzigen.

Het volgende voorbeeld stelt kop, voettekst en datum/tijd‑tekst in op de notitie‑master en maakt alle ondersteunde plaatshouders zichtbaar op die master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

De[`MasterNotesSlide`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslidemanager/masternotesslide/)‑eigenschap geeft `null` terug wanneer de presentatie geen notitie‑master bevat.

## **Instellingen van de notitie‑master toepassen op onderliggende notities‑dia’s**

Een notitie‑master kan kop‑ en voettekst‑instellingen doorvoeren naar zichzelf en naar alle afhankelijke notities‑dia’s. Gebruik de speciale propagatiemethoden op[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslideheaderfootermanager/) wanneer dezelfde instellingen door de hele notitie‑hiërarchie moeten gelden.

Bijvoorbeeld[`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) en[`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) updaten de notitie‑master‑kop en alle onderliggende koppen. Gelijksoortige methoden zijn beschikbaar voor voetteksten, datum/tijd en dia‑nummers.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

De hierboven gebruikte propagatiemethoden zijn[`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/),[`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/),[`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/),[`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), en[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Koppen en voetteksten instellen op een individuele notities‑dia**

Een notities‑dia behoort tot een specifieke reguliere dia. Gebruik de[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/inotesslideheaderfootermanager/)‑interface wanneer u alleen die notitie‑pagina wilt aanpassen.

De[`AddNotesSlide`](https://reference.aspose.com/slides/nl/net/aspose.slides/inotesslidemanager/addnotesslide/)‑methode retourneert de notities‑dia voor de huidige dia en maakt er één aan als deze nog niet bestaat. Het volgende voorbeeld configureert de notitie‑pagina die gekoppeld is aan de eerste presentatiedia:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Als u eerst instellingen van de notitie‑master doorvoert en daarna een individuele notities‑dia wijzigt, laten de latere per‑dia‑instellingen u die notitie‑pagina onafhankelijk aanpassen.

## **Koppen en voetteksten instellen op het handout‑master**

Handout‑pagina’s gebruiken het handout‑master voor hun kop‑, voettekst‑, datum/tijd‑ en paginanummer‑plaatshouders. In tegenstelling tot notitie‑pagina’s worden handout‑instellingen beheerd via het handout‑master in plaats van via individuele handout‑dia’s.

Gebruik de[`MasterHandoutSlide`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/)‑eigenschap om toegang te krijgen tot het handout‑master. Als deze niet aanwezig is, roep[`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) aan om het standaard handout‑master aan te maken.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Begrijpen van scope en overerving**

Kies de kop‑/voettekst‑manager die overeenkomt met de scope die u wilt wijzigen:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/islideheaderfootermanager/) wijzigt voettekst-, datum/tijd‑ en dia‑nummersetting voor één reguliere dia.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslideheaderfootermanager/) beheert een lay‑out‑dia en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslideheaderfootermanager/) beheert een reguliere slide‑master en kan ondersteunde instellingen doorvoeren naar afhankelijke dia’s.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasternotesslideheaderfootermanager/) beheert de notitie‑master en kan instellingen doorvoeren naar alle afhankelijke notities‑dia’s.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/inotesslideheaderfootermanager/) wijzigt één notities‑dia en ondersteunt een kop‑plaatshouder naast voettekst, datum/tijd en dia‑nummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterhandoutslideheaderfootermanager/) wijzigt het handout‑master en ondersteunt alle vier de plaatshoudertypes.

Gebruik propagatie vanaf een master of lay‑out wanneer dezelfde instelling door de gehele hiërarchie moet gelden. Gebruik een individuele dia‑ of notities‑dia‑manager wanneer u een lokale instelling voor één pagina nodig hebt.

## **FAQ**

**Kan ik een kop toevoegen aan een reguliere dia?**

Nee. PowerPoint definieert geen kop‑plaatshouder voor reguliere dia’s. Gebruik op reguliere dia’s de voettekst‑, datum/tijd‑ en dia‑nummervoorzieningen. Kop‑plaatshouders zijn beschikbaar op notitie‑pagina’s en handouts.

**Wat als een voettekst‑, datum/tijd‑ of dia‑nummervoorziening niet zichtbaar is?**

Gebruik de overeenkomstige kop‑/voettekst‑manager om de zichtbaarheid te controleren en schakel deze in wanneer nodig. Bijvoorbeeld[`IsFooterVisible`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) geeft aan of een voettekst‑plaatshouder aanwezig is, en[`SetFooterVisibility`](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) wijzigt de zichtbaarheid.

**Hoe begin ik met dia‑nummering vanaf een andere waarde dan 1?**

Stel de[`FirstSlideNumber`](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/firstslidenumber/)‑eigenschap van de presentatie in. De dia‑nummervoorzieningen gebruiken dan de bijgewerkte nummeringsreeks.

**Wat gebeurt er met koppen en voetteksten bij het exporteren naar PDF, afbeeldingen of HTML?**

Zichtbare kop‑ en voettekst‑elementen worden samen met de rest van de presentatiewaarde gerenderd in het uitvoerformaat. Hun weergave hangt af van het type pagina dat wordt geëxporteerd en de bijbehorende plaatshouder‑zichtbaarheidsinstellingen.