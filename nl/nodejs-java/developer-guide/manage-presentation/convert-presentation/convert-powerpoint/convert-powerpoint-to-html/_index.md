---
title: PowerPoint-presentaties converteren naar HTML in Node.js
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/nodejs-java/convert-powerpoint-to-html/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- PowerPoint opslaan als HTML
- presentatie opslaan als HTML
- dia opslaan als HTML
- PPT opslaan als HTML
- PPTX opslaan als HTML
- PPT exporteren naar HTML
- PPTX exporteren naar HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar HTML in Node.js. Gebruik Aspose.Slides voor Node.js via Java om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit één enkele [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑load en een `save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) wanneer je controle wilt over de geëxporteerde lay‑out, lettertypen, afbeeldingen, notities, opmerkingen, SVG‑output of gekoppelde bronnen.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Een volledige presentatie of geselecteerde dia’s exporteren.
- Vast‑lay‑out, responsieve of op SVG gebaseerde HTML genereren.
- Sprekersnotities en opmerkingen opnemen.
- De beeldkwaliteit en bijgesneden beeldgegevens regelen.
- Lettertypen insluiten of lettertypebestanden apart opslaan.
- Kiezen hoe externe bronnen en mediabestanden worden weggeschreven en gerefereerd.

Standaard produceert HTML‑export een zelfstandig HTML‑document waarbij de meeste bronnen zijn ingesloten. Dit is handig voor het delen van één bestand, maar kan de outputgrootte verhogen. Voor publicatie op het web kun je overwegen externe bronnen te gebruiken, de DPI van afbeeldingen te verlagen en alleen lettertypen in te sluiten die niet betrouwbaar beschikbaar zijn in de doelsituatie.

## **Een presentatie naar HTML converteren**

Om een presentatie naar HTML te exporteren, laad je deze met [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) en sla je deze op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dit voorbeeld schrijft één HTML‑bestand. Het presentatiedobject wordt in het `finally`‑blok vrijgegeven, waardoor bestands­handles en renderingsbronnen na de export worden vrijgelaten.

## **HtmlOptions gebruiken**

[HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelvoorkomende instellingen zijn:

- `SlidesLayoutOptions`: voegt notities, opmerkingen, hand-outs of andere lay‑out‑informatie toe.
- `HtmlFormatter`: wijzigt de HTML‑documentstructuur of delegeert de opmaak aan een controller.
- `SlideImageFormat`: bepaalt hoe dia’s worden weergegeven, bijvoorbeeld als SVG.
- `PicturesCompression`: regelt de DPI van afbeeldingen en de outputgrootte.
- `DeletePicturesCroppedAreas`: behoudt of verwijdert bijgesneden beeldgegevens.
- `SvgResponsiveLayout`: laat geëxporteerde SVG‑inhoud zich aanpassen aan de container.
- `ShowHiddenSlides`: voegt verborgen dia’s toe wanneer dat vereist is.

De volgende secties tonen de meest voorkomende opties afzonderlijk, zodat je alleen die kunt combineren die jouw workflow nodig heeft.

## **Geselecteerde dia’s naar HTML converteren**

De `Presentation.save`‑overload die dia‑nummers accepteert, gebruikt 1‑gebaseerde dia‑posities. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak je één instantie van [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) en geef je die door aan elke `save`‑aanroep.

## **Responsieve HTML maken**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/responsivehtmlcontroller/) biedt responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmlformatter/). Gebruik deze wanneer de geëxporteerde pagina beter moet aanpassen aan de breedte van de browser.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Voor een op SVG gebaseerde responsieve lay‑out, stel je `SvgResponsiveLayout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/). Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Sprekersnotities en opmerkingen opnemen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.setSlidesLayoutOptions` om sprekersnotities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij je hun positie kiest.

Stel dat de bronpresentatie sprekersnotities bevat:

![Dia met sprekersnotities in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met sprekersnotities onder de dia.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

De geëxporteerde HTML bevat het notitie‑gebied:

![HTML‑output met de dia en sprekersnotities](HTML_with_notes.png)

Om opmerkingen te exporteren, stel je `CommentsPosition` in, bijvoorbeeld op `CommentsPositions.Right` of `CommentsPositions.Bottom`. Als je alleen opmerkingen wilt, laat je `NotesPosition` weg. Als je zowel notities als opmerkingen wilt, stel je beide eigenschappen in.

## **Beeldkwaliteit en bijgesneden gebieden regelen**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `PicturesCompression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturescompression/) wanneer je een hogere beeldkwaliteit nodig hebt.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Standaard kunnen bijgesneden delen van afbeeldingen uit de geëxporteerde output worden verwijderd. Behoud bijgesneden gegevens alleen wanneer gebruikers die verborgen afbeeldingsdelen moeten kunnen herstellen of inspecteren. Het behouden ervan kan de HTML‑grootte verhogen.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS toevoegen**

Voor eenvoudige opmaak kun je een CSS‑string doorgeven aan `HtmlFormatter.createDocumentFormatter`. Dit wijzigt het omvattende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Voor een aangepaste documentheader, een gekoppeld CSS‑bestand of aangepaste markup rond dia’s en vormen, gebruik je [HtmlFormatter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmlformatter/) met een formatteringscontroller.

## **Lettertypen insluiten**

Als de doelsituatie de presentatie‑lettertypen mogelijk niet geïnstalleerd heeft, kun je lettertypen insluiten in de HTML met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de outputgrootte.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sluit lettertypen alleen uit wanneer je zeker weet dat de doel‑browsers of -systemen ze al leveren. Voor merk‑ of minder gangbare lettertypen is insluiten meestal veiliger.

## **Lettertypebestanden linken in plaats van insluiten**

Om de HTML‑bestandsgrootte te verkleinen, kun je lettertype‑data naar afzonderlijke WOFF‑bestanden schrijven en `@font-face`‑regels aan de HTML toevoegen. In Node.js via Java wordt dit scenario meestal geïmplementeerd met een kleine Java‑helperklasse die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) uitbreidt, lettertypebytes naar een uitvoermap schrijft en `@font-face`‑regels in de gegenereerde HTML injecteert. Compileer die helper, voeg hem toe aan het classpath van de Node.js‑module en instantiateer hem vervolgens vanuit JavaScript met `java.newInstanceSync`.

Wanneer je zo’n helper bouwt, kies je twee paden bewust:

- Het bestandssysteempad waar de gegenereerde lettertypebestanden worden weggeschreven.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die lettertypebestanden te laden.

## **Bronnen extern opslaan**

Zelfstandige HTML is makkelijk te verplaatsen, maar ingesloten Base64‑bronnen kunnen het bestand groot maken. Als je applicatie externe afbeelding‑, lettertype‑, audio‑ of videobestanden nodig heeft, gebruik dan een exportcontroller die bronnen naar een gekozen map schrijft en browser‑zichtbare URL’s genereert. Houd het bestandssysteempad en het URL‑pad in overeenstemming met je implementatielay‑out.

## **Mediabestanden exporteren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor accepteert:

- `path`: de map waar gegenereerde mediabestanden worden weggeschreven.
- `fileName`: de HTML‑bestandsnaam die wordt gegenereerd.
- `baseUri`: het absolute URI‑voorvoegsel dat in de HTML‑links naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is en mediabestanden worden opgeslagen in `html-output/media`, moet `path` verwijzen naar de mediamap op schijf, terwijl `baseUri` moet verwijzen naar dezelfde map vanuit het perspectief van de browser. Voor een lokale preview kun je een `file:///`‑URI uit de mediamap bouwen. Voor een gedeployde applicatie gebruik je de absolute URL van de gepubliceerde mediamap.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gebruik uitvoermappen die uniek zijn per exporttaak, vooral in server‑applicaties. Gedeelde uitvoer­paden kunnen ertoe leiden dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resource‑beheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugenverbruik hangen af van het aantal dia’s, de resolutie van afbeeldingen, lettertypen, effecten, grafieken en ingesloten media. Hogere `PicturesCompression`‑DPI‑waarden, ingesloten lettertypen, SVG‑output en behouden bijgesneden beeldgebieden kunnen de getrouwheid verbeteren maar meestal de outputgrootte verhogen.

Voor batch‑conversie:

- Ruim elke [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie direct op.
- Gebruik aparte uitvoermappen voor verschillende taken.
- Vermijd het insluiten van veelvoorkomende lettertypen tenzij de getrouwheid dit vereist.
- Verlaag de DPI van afbeeldingen wanneer de HTML alleen voor preview of miniaturen wordt gebruikt.
- Houd de bronpresentatie, de gegenereerde HTML en de externe bronnen samen tot de implementatie‑paden definitief zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie tussen workers. Verwerk verschillende bestanden met aparte presentatie‑instanties, aparte streams en aparte uitvoermappen. Zie de [multithreading guidance](/slides/nl/nodejs-java/multithreading/) voor details.

**Is een Presentation‑object thread‑safe?**

Nee. Een enkele [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie moet worden geladen, bewerkt, opgeslagen en opgeschoond in één worker. Voor parallel werk, maak een onafhankelijke instantie per worker of proces.

**Waarom is het gegenereerde HTML‑bestand groot?**

De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypen, hoge‑DPI‑afbeeldingen, media, SVG‑inhoud en behouden bijgesneden beeldgebieden verhogen eveneens de grootte. Gebruik externe bronnen, sluit veelvoorkomende lettertypen uit en verlaag `PicturesCompression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom verschijnt een PowerPoint‑lettergrootte van 24 pt als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekstgroottes op in typografische punten gebaseerd op 72 DPI, terwijl HTML‑lay‑out is gebaseerd op CSS‑pixels in een 96 DPI‑model. Wanneer Aspose.Slides een presentatie naar HTML exporteert, wordt de lettergrootte tussen deze systemen vertaald, en kan de conversie kleine afrondingsverschillen introduceren.

Deze waarden geven geen reële visuele wijziging in de lettergrootte weer. Ze zijn slechts een wiskundig neveneffect van het omrekenen van tekstmetriek tussen PowerPoint en HTML.

**Hoe kies ik baseUri voor media‑export?**

Kies `baseUri` vanuit het perspectief van de browser en geef deze door als een absolute URI. Voor lokale preview kun je deze afleiden van de uitvoermap met een `file:///`‑URI. Voor implementatie gebruik je de absolute URL van de gepubliceerde mediamap. Het bestandssysteempad `path` en het browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar moeten naar dezelfde locatie verwijzen.

**Kan ik verborgen dia’s opnemen?**

Ja. Stel `ShowHiddenSlides` in op `true` op [HtmlOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/htmloptions/) wanneer verborgen dia’s moeten worden geëxporteerd.