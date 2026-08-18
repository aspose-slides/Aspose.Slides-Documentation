---
title: Hantera presentationssidhuvuden och -sidfötter i PHP
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/php-java/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ställ in sidhuvud
- ställ in sidfot
- handout
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar sidfot-, datum-tid-, bild-nummer- och sidhuvud-platshållare på bilder, anteckningssidor och handout med Aspose.Slides för PHP via Java."
---
## **Översikt**

PowerPoint använder olika sidhuvud‑ och sidfotplatshållare beroende på sidtyp. Aspose.Slides för PHP via Java låter dig kontrollera texten och synligheten för dessa platshållare genom header/footer‑hanterarklasser.

De tillgängliga platshållarna beror på omfånget:

| Omfång | Sidhuvud | Sidfot | Datum/tid | Bild-/sidnummer |
|---|---|---|---|---|
| Vanlig bild | Nej | Ja | Ja | Ja |
| Antecknings‑master | Ja | Ja | Ja | Ja |
| Antecknings‑bild | Ja | Ja | Ja | Ja |
| Utdelnings‑master | Ja | Ja | Ja | Ja |

En vanlig presentationsbild har inte en sidhuvud‑platshållare. Sidhuvuden finns på anteckningssidor och utdelningar. För vanliga bilder, använd sidfot‑, datum/tid‑ och bild‑nummer‑platshållare istället.

Omfånget för en ändring beror på vilken manager du använder. Klassen [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideheaderfootermanager/) styr en vanlig bild. Klassen [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslideheaderfootermanager/) styr en antecknings‑bild. Master‑ och layout‑managers kan också propagera inställningar till beroende bilder, medan klassen [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) styr utdelnings‑mastern.

## **Ställ in sidfot, datum/tid och bildnummer på vanliga bilder**

För vanliga bilder är det grundläggande flödet att komma åt varje bilds header/footer‑manager, ange sidfot‑ och datum/tid‑text, aktivera de behövda platshållarna och spara presentationen. Bildnummer genereras av presentationen, så du behöver bara kontrollera deras synlighet.

Använd [`setFooterText`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) och [`setDateTimeText`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) för att ange text, och använd [`setFooterVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) samt [`setSlideNumberVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) för att visa motsvarande platshållare.

Följande end‑to‑end‑exempel tillämpar samma sidfot, datum/tid‑text och bild‑nummer‑synlighet på alla vanliga bilder:

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

Om du bara behöver uppdatera en bild, kom åt den bilden direkt via metoden [`getSlides`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getslides/) i stället för att iterera genom hela samlingen.

## **Ställ in sidhuvuden och sidfötter på antecknings‑mastern**

Antecknings‑mastern definierar gemensam formatering och platshållarbeteende för anteckningssidor. Använd klassen [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/) när du vill ändra endast antecknings‑mastern själv.

Följande exempel anger sidhuvud, sidfot och datum/tid‑text på antecknings‑mastern och gör alla stödjade platshållare synliga på den mastern:

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

Metoden [`getMasterNotesSlide`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) returnerar `null` när presentationen inte innehåller en antecknings‑master.

## **Applicera inställningar från antecknings‑mastern på underordnade antecknings‑bilder**

En antecknings‑master kan tillämpa sidhuvud‑ och sidfotinställningar på sig själv och på alla beroende antecknings‑bilder. Använd de dedikerade propagationsmetoderna på [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/) när samma inställningar ska tillämpas över hela anteckningshierarkin.

Till exempel uppdaterar [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) och [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) antecknings‑masterns sidhuvud och alla underordnade sidhuvuden. Motsvarande metoder finns för sidfötter, datum/tid och bildnummer.

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

Propagationsmetoderna som används ovan är [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) och [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ställ in sidhuvuden och sidfötter på en enskild antecknings‑bild**

En antecknings‑bild tillhör en specifik vanlig bild. Använd dess [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslideheaderfootermanager/) när du vill anpassa endast den anteckningssidan.

Metoden [`addNotesSlide`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslidemanager/addnotesslide/) returnerar antecknings‑bilden för den aktuella bilden och skapar en om den inte redan finns. Följande exempel konfigurerar anteckningssidan som är kopplad till den första presentationsbilden:

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

Om du först propagar inställningar från antecknings‑mastern och sedan ändrar en enskild antecknings‑bild, låter de senare per‑bild‑inställningarna dig anpassa den anteckningssidan oberoende.

## **Ställ in sidhuvuden och sidfötter på handout‑mastern**

Utdelningssidor använder handout‑mastern för sina sidhuvud‑, sidfot‑, datum/tid‑ och sidnummer‑platshållare. Till skillnad från anteckningssidor hanteras utdelningsinställningar via handout‑mastern snarare än via enskilda utdelningsbilder.

Använd metoden [`getMasterHandoutSlide`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) för att komma åt handout‑mastern. Om den inte finns, anropa [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) för att skapa standard‑handout‑mastern.

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

## **Förstå omfång och arv**

Välj den header/footer‑manager som matchar det omfång du vill ändra:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideheaderfootermanager/) ändrar sidfot-, datum/tid‑ och bild‑nummer‑inställningar för en vanlig bild.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslideheaderfootermanager/) styr en layout‑bild och kan propagera stödjade inställningar till beroende bilder.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterslideheaderfootermanager/) styr en vanlig bild‑master och kan propagera stödjade inställningar till beroende bilder.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masternotesslideheaderfootermanager/) styr antecknings‑mastern och kan propagera inställningar till alla beroende antecknings‑bilder.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notesslideheaderfootermanager/) ändrar en antecknings‑bild och stödjer ett sidhuvud‑platshållare utöver sidfot, datum/tid och bildnummer.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) ändrar handout‑mastern och stödjer alla fyra platshållartyper.

Använd propagation från en master eller layout när samma inställning ska gälla genom hela dess hierarki. Använd en individuell bild‑ eller antecknings‑bild‑manager när du behöver en lokal inställning för en sida.

## **FAQ**

**Kan jag lägga till ett sidhuvud på en vanlig bild?**

Nej. PowerPoint definierar ingen sidhuvud‑platshållare för vanliga bilder. På vanliga bilder, använd sidfot‑, datum/tid‑ och bild‑nummer‑platshållare. Sidhuvud‑platshållare finns på anteckningssidor och utdelningar.

**Vad händer om en sidfot-, datum/tid‑ eller bild‑nummer‑platshållare inte är synlig?**

Använd den motsvarande header/footer‑managern för att kontrollera dess synlighet och aktivera den vid behov. Till exempel rapporterar [`isFooterVisible`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) om en sidfot‑platshållare finns, och [`setFooterVisibility`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) ändrar dess synlighet.

**Hur startar jag bildnumrering från ett annat värde än 1?**

Anropa presentationens metod [`setFirstSlideNumber`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/setfirstslidenumber/). Bild‑nummer‑platshållarna använder då den uppdaterade sekvensen.

**Vad händer med sidhuvuden och sidfötter vid export till PDF, bilder eller HTML?**

Synliga sidhuvuds‑ och sidfotselement renderas tillsammans med resten av presentationsinnehållet i det exporterade formatet. Deras utseende beror på den sidtyp som exporteras och de motsvarande platshållar‑synlighetsinställningarna.