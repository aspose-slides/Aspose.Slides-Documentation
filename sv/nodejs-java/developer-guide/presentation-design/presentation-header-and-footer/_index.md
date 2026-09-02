---
title: Hantera presentationens sidhuvuden och sidfötter i JavaScript
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/nodejs-java/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ange sidhuvud
- ange sidfot
- utdelning
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar sidfot-, datum-tid-, bild-nummer- och sidhuvud-platshållare på bilder, anteckningssidor och utdelningar med Aspose.Slides för Node.js via Java."
---
## **Översikt**

PowerPoint använder olika platshållare för sidhuvud och sidfot beroende på sidtyp. Aspose.Slides för Node.js via Java låter dig kontrollera texten och synligheten för dessa platshållare via klasser för sidhuvud/sidfots‑hanterare.

De tillgängliga platshållarna beror på omfånget:

| Omfång | Sidhuvud | Sidfot | Datum/tid | Bild/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Anteckningsmaster | Ja | Ja | Ja | Ja |
| Anteckningsbild | Ja | Ja | Ja | Ja |
| Utdelnings‑master | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har ingen sidhuvuds‑platshållare. Sidhuvuden finns på anteckningssidor och utdelningar. För vanliga bilder använder du sidfot, datum/tid och bild‑/sidnummer‑platshållare istället.

Omfånget för en ändring beror på vilken manager du använder. Klassen [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideheaderfootermanager/) styr en vanlig bild. Klassen [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslideheaderfootermanager/) styr en anteckningsbild. Master‑ och layout‑managers kan också sprida inställningar till beroende bilder, medan klassen [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) styr utdelnings‑mastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande arbetsflödet att komma åt varje bilds sidhuvud/sidfots‑manager, sätta sidfot‑ och datum/tid‑text, aktivera de nödvändiga platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`setFooterText`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) och [`setDateTimeText`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) för att ange text, och använd [`setFooterVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) och [`setSlideNumberVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) för att visa motsvarande platshållare.

Följande end‑to‑end‑exempel tillämpar samma sidfot, datum/tid‑text och bildnummer‑synlighet på alla vanliga bilder:

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

Om du bara behöver uppdatera en bild, kom åt den bilden direkt via metoden [`getSlides`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslides/) istället för att iterera genom hela samlingen.

## **Ställ in sidhuvud och sidfot på antecknings‑mastern**

Antecknings‑mastern definierar gemensam formatering och platshållarbeteende för anteckningssidor. Använd klassen [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) när du vill ändra endast antecknings‑mastern.

Följande exempel sätter sidhuvud, sidfot och datum/tid‑text på antecknings‑mastern och gör alla stödjade platshållare synliga på den mastern:

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

Metoden [`getMasterNotesSlide`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) returnerar `null` när presentationen inte innehåller någon antecknings‑master.

## **Tillämpa antecknings‑masterinställningar på underordnade anteckningsbilder**

En antecknings‑master kan tillämpa sidhuvuds‑ och sidfotsinställningar på sig själv och på alla beroende anteckningsbilder. Använd de dedikerade spridningsmetoderna på [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) när samma inställningar ska gälla i hela anteckningshierarkin.

Till exempel uppdaterar [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) och [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) antecknings‑masterns sidhuvud och alla underordnade sidhuvuden. Motsvarande metoder finns för sidfötter, datum/tid och bildnummer.

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

Spridningsmetoderna som används ovan är [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) och [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ställ in sidhuvud och sidfot på en individuell anteckningsbild**

En anteckningsbild tillhör en specifik vanlig bild. Använd dess [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslideheaderfootermanager/) när du vill anpassa endast den anteckningssidan.

Metoden [`addNotesSlide`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) returnerar anteckningsbilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

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

Om du först sprider inställningar från antecknings‑mastern och sedan ändrar en individuell anteckningsbild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan oberoende.

## **Ställ in sidhuvud och sidfot på utdelnings‑mastern**

Utdelningssidor använder utdelnings‑mastern för sina sidhuvuds‑, sidfots‑, datum/tid‑ och sidnummer‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningarna via utdelnings‑mastern snarare än genom enskilda utdelningsbilder.

Använd [`getMasterHandoutSlide`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) för att komma åt utdelnings‑mastern. Om den inte finns, anropa [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) för att skapa standard‑utdelnings‑master.

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

## **Förstå omfång och arv**

Välj den sidhuvud/sidfots‑manager som matchar det omfång du vill ändra:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideheaderfootermanager/) ändrar sidfot, datum/tid och bild‑nummer‑inställningar för en vanlig bild.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) styr en layout‑bild och kan sprida stödjade inställningar till beroende bilder.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslideheaderfootermanager/) styr en vanlig bild‑master och kan sprida stödjade inställningar till beroende bilder.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) styr antecknings‑mastern och kan sprida inställningar till alla beroende anteckningsbilder.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notesslideheaderfootermanager/) ändrar en anteckningsbild och stödjer en sidhuvuds‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändrar utdelnings‑mastern och stödjer alla fyra platshållartyper.

Använd spridning från en master eller layout när samma inställning ska gälla genom hela dess hierarki. Använd en individuell bild‑ eller antecknings‑bild‑manager när du behöver en lokal inställning för en sida.

## **FAQ**

**Kan jag lägga till ett sidhuvud på en vanlig bild?**

Nej. PowerPoint definierar ingen sidhuvuds‑platshållare för vanliga bilder. På vanliga bilder använder du sidfot, datum/tid och bild‑/sidnummer‑platshållare. Sidhuvuds‑platshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot, datum/tid eller bild‑/sidnummer‑platshållare inte är synlig?**

Använd den motsvarande sidhuvud/sidfots‑managern för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`isFooterVisible`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) om en sidfot‑platshållare finns, och [`setFooterVisibility`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) ändrar dess synlighet.

**Hur startar jag bildnumrering från ett annat värde än 1?**

Anropa presentationens [`setFirstSlideNumber`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) metod. Bild‑/sidnummer‑platshållarna använder då den uppdaterade numreringssekvensen.

**Vad händer med sidhuvuden och sidfötter vid export till PDF, bilder eller HTML?**

Synliga sidhuvuds‑ och sidfotselement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på vilken sidtyp som exporteras och de motsvarande platshållar‑synlighetsinställningarna.