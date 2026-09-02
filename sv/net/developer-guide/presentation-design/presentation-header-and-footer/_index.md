---
title: Hantera presentationers sidhuvuden och sidfötter i .NET
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/net/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- sätt sidhuvud
- sätt sidfot
- handout
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du hanterar platshållare för sidfot, datum/tid, bildnummer och sidhuvud på bilder, anteckningssidor och handouts med Aspose.Slides för .NET."
---
## **Översikt**

PowerPoint använder olika platshållare för sidhuvud och sidfot beroende på sidtyp. Aspose.Slides för .NET låter dig kontrollera texten och synligheten för dessa platshållare via gränssnitt för sidhuvuds‑/sidfotshanterare.

De tillgängliga platshållarna beror på omfattningen:

| Omfång | Sidhuvud | Sidfot | Datum/tid | Bild-/sidnummer |
|---|---|---|---|---|
| Regular slide | No | Yes | Yes | Yes |
| Notes master | Yes | Yes | Yes | Yes |
| Notes slide | Yes | Yes | Yes | Yes |
| Handout master | Yes | Yes | Yes | Yes |

En vanlig bild i en presentation har ingen platshållare för sidhuvud. Sidhuvuden är tillgängliga på notes‑sidor och handouts. För vanliga bilder använder du platshållarna för sidfot, datum/tid och bildnummer istället.

Omfattningen av en ändring beror på vilken manager du använder. Gränssnittet [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/islideheaderfootermanager/) styr en vanlig bild. Gränssnittet [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/inotesslideheaderfootermanager/) styr en notes‑bild. Master‑ och layout‑managers kan också propagera inställningar till beroende bilder, medan gränssnittet [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslideheaderfootermanager/) styr handout‑mastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att komma åt varje bilds sidhuvuds‑/sidfotshanterare, sätta sidfot‑ och datum/tid‑text, aktivera de erforderliga platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`SetFooterText`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) och [`SetDateTimeText`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) för att ange text, och använd [`SetFooterVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) samt [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) för att visa motsvarande platshållare.

Följande end‑to‑end‑exempel tillämpar samma sidfot, datum/tid‑text och bildnummer‑synlighet på alla vanliga bilder:

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

Om du bara behöver uppdatera en bild, kom åt den bilden direkt via samlingen [`Slides`](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/) i stället för att iterera över hela samlingen.

## **Ställ in sidhuvuden och sidfötter på Notes master**

Notes‑mastern definierar gemensam formatering och platshållarbeteende för notes‑sidor. Använd gränssnittet [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslideheaderfootermanager/) när du endast vill ändra själva notes‑mastern.

Följande exempel sätter sidhuvud, sidfot och datum/tid‑text på notes‑mastern och gör alla stödjade platshållare synliga på den mastern:

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

Egenskapen [`MasterNotesSlide`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslidemanager/masternotesslide/) returnerar `null` när presentationen inte innehåller någon notes‑master.

## **Tillämpa Notes master‑inställningar på underordnade Notes‑sidor**

En notes‑master kan tillämpa sidhuvuds‑ och sidfotinställningar på sig själv och på alla beroende notes‑sidor. Använd de dedikerade propageringsmetoderna på [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslideheaderfootermanager/) när samma inställning ska gälla över hela notes‑hierarkin.

Till exempel uppdaterar [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) och [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) notes‑master‑sidhuvudet och alla underordnade sidhuvuden. Motsvarande metoder finns för sidfötter, datum/tid och bildnummer.

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

Propageringsmetoderna som användes ovan är [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) och [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ställ in sidhuvuden och sidfötter på en enskild Notes‑bild**

En notes‑bild tillhör en specifik vanlig bild. Använd dess [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/inotesslideheaderfootermanager/) när du vill anpassa endast den notes‑sidan.

Metoden [`AddNotesSlide`](https://reference.aspose.com/slides/sv/net/aspose.slides/inotesslidemanager/addnotesslide/) returnerar notes‑bilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar notes‑sidan som är kopplad till den första presentationsbilden:

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

Om du först propagerar inställningar från notes‑mastern och sedan ändrar en enskild notes‑bild, låter de senare per‑bild‑inställningarna dig anpassa den notes‑sidan oberoende.

## **Ställ in sidhuvuden och sidfötter på Handout master**

Handout‑sidor använder handout‑mastern för sina platshållare för sidhuvud, sidfot, datum/tid och sidnummer. Till skillnad från notes‑sidor hanteras handout‑inställningarna via handout‑mastern snarare än individuella handout‑bilder.

Använd egenskapen [`MasterHandoutSlide`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) för att komma åt handout‑mastern. Om den inte finns, anropa [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) för att skapa standardhandout‑mastern.

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

## **Förstå omfattning och arv**

Välj den sidhuvuds‑/sidfotshanterare som matchar den omfattning du vill ändra:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/islideheaderfootermanager/) ändrar sidfot, datum/tid och bildnummerinställningar för en vanlig bild.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslideheaderfootermanager/) styr en layout‑bild och kan propagera stödjade inställningar till beroende bilder.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslideheaderfootermanager/) styr en vanlig bild‑master och kan propagera stödjade inställningar till beroende bilder.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasternotesslideheaderfootermanager/) styr notes‑mastern och kan propagera inställningar till alla beroende notes‑bilder.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/inotesslideheaderfootermanager/) ändrar en notes‑bild och stöder ett sidhuvuds‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterhandoutslideheaderfootermanager/) ändrar handout‑mastern och stöder alla fyra platshållartyper.

Använd propagering från en master eller layout när samma inställning ska gälla genom hela hierarkin. Använd en individuell bild‑ eller notes‑bild‑manager när du behöver en lokal inställning för en enskild sida.

## **FAQ**

**Kan jag lägga till ett sidhuvud på en vanlig bild?**

Nej. PowerPoint definierar ingen platshållare för sidhuvud på vanliga bilder. På vanliga bilder använder du sidfot-, datum/tid‑ och bildnummer‑platshållare. Sidhuvuds‑platshållare finns på notes‑sidor och handouts.

**Vad händer om en sidfot-, datum/tid‑ eller bildnummer‑platshållare inte är synlig?**

Använd den motsvarande sidhuvuds‑/sidfotshanteraren för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`IsFooterVisible`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) om en sidfot‑platshållare finns, och [`SetFooterVisibility`](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ändrar dess synlighet.

**Hur startar jag bildnummerering från ett värde annat än 1?**

Ställ in presentationens egenskap [`FirstSlideNumber`](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/firstslidenumber/). Bildnummer‑platshållarna använder då den uppdaterade numreringssekvensen.

**Vad händer med sidhuvuden och sidfötter vid export till PDF, bilder eller HTML?**

Synliga sidhuvuds‑ och sidfotselement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. deras utseende beror på vilken sidtyp som exporteras och de motsvarande platshållarens synlighetsinställningar.