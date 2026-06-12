---
title: PowerPoint-presentaties converteren naar HTML in PHP
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/php-java/convert-powerpoint-to-html/
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
- PHP
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar HTML in PHP. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides voor PHP via Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit één enkele [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) die wordt geladen en een `save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/) wanneer u de geëxporteerde layout, lettertypes, afbeeldingen, notities, opmerkingen, SVG‑output of gekoppelde bronnen wilt beheren.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Export van een hele presentatie of geselecteerde dia’s.
- Genereren van vaste‑layout, responsive of SVG‑gebaseerde HTML.
- Inclusief spreker‑notities en opmerkingen.
- Beheersen van de beeldkwaliteit en bijgesneden beeldgegevens.
- Lettertypes insluiten of lettertypebestanden apart opslaan.
- Kiezen hoe externe bronnen en mediabestanden worden weggeschreven en verwezen.

Standaard produceert HTML‑export een zelf‑behorende HTML‑document waarbij de meeste bronnen zijn ingesloten. Dit is handig voor het delen van één bestand, maar kan de outputgrootte vergroten. Voor publicatie op het web, overweeg externe bronnen, een lagere DPI voor afbeeldingen, en alleen insluiten van lettertypes die niet betrouwbaar beschikbaar zijn in de doelomgeving.

## **Een Presentatie naar HTML converteren**

Om een presentatie naar HTML te exporteren, laadt u deze met [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) en slaat u deze op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Dit voorbeeld schrijft één HTML‑bestand. Het presentatiedobject wordt vrijgegeven in het `finally`‑blok, waardoor bestands‑handles en renderresources na de export worden vrijgelaten.

## **HtmlOptions gebruiken**

[HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/) is de hoofdconfiguratieklasse voor HTML‑export. Veelvoorkomende instellingen omvatten:

- `SlidesLayoutOptions`: voegt notities, opmerkingen, hand‑outs, of andere layout‑informatie toe.
- `HtmlFormatter`: wijzigt de HTML‑documentstructuur of delegeert de opmaak aan een controller.
- `SlideImageFormat`: verandert hoe dia's worden weergegeven, bijvoorbeeld als SVG.
- `PicturesCompression`: regelt de DPI van afbeeldingen en de outputgrootte.
- `DeletePicturesCroppedAreas`: behoudt of verwijdert bijgesneden beeldgegevens.
- `SvgResponsiveLayout`: zorgt ervoor dat geëxporteerde SVG‑inhoud zich aanpast aan de container.
- `ShowHiddenSlides`: neemt verborgen dia's op wanneer vereist.

De volgende secties tonen de meest voorkomende opties afzonderlijk zodat u alleen die kunt combineren die uw workflow nodig heeft.

## **Geselecteerde dia's naar HTML converteren**

De `save`‑overload die dia‑nummers accepteert, gebruikt 1‑gebaseerde dia‑posities. De onderstaande lus slaat elke dia op in een afzonderlijk HTML‑bestand.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde layout moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/) instantie aan en geef deze door aan elke `save`‑aanroep.

## **Responsive HTML creëren**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/responsivehtmlcontroller/) levert responsive HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmlformatter/). Gebruik het wanneer de geëxporteerde pagina zich beter moet aanpassen aan de breedte van de browser.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Voor SVG‑gebaseerde responsive layout, stel `SvgResponsiveLayout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/). Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **Spreker‑notities en opmerkingen opnemen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` om spreker‑notities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij u hun positie kiest.

Stel dat de bronpresentatie spreker‑notities bevat:

![Dia met spreker‑notities in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met spreker‑notities onder de dia.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

De geëxporteerde HTML bevat het notitiegebied:

![HTML‑output met de dia en spreker‑notities](HTML_with_notes.png)

Om opmerkingen te exporteren, stel `CommentsPosition` in, bijvoorbeeld op `CommentsPositions.Right` of `CommentsPositions.Bottom`. Als u alleen opmerkingen nodig heeft, laat `NotesPosition` weg. Als u zowel notities als opmerkingen nodig heeft, stel beide eigenschappen in.

## **Beheer van beeldkwaliteit en bijgesneden gebieden**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `PicturesCompression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturescompression/) wanneer u hogere beeldkwaliteit nodig heeft.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Standaard kunnen bijgesneden delen van afbeeldingen uit de geëxporteerde output worden verwijderd. Houd bijgesneden gegevens alleen wanneer gebruikers die verborgen beeldonderdelen moeten kunnen terughalen of inspecteren. Het behouden ervan kan de HTML‑grootte verhogen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **CSS toevoegen**

Voor eenvoudige opmaak, geef een CSS‑string door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmlformatter/) via `createDocumentFormatter`. Dit wijzigt het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Voor een aangepaste document‑header, een gekoppeld CSS‑bestand, of aangepaste markup rond dia’s en vormen, gebruik een aangepaste formatteringscontroller en geef deze door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmlformatter/) met `createCustomFormatter`.

## **Lettertypes insluiten**

Als de doelomgeving mogelijk niet over de presentatie‑lettertypes beschikt, sluit dan lettertypes in de HTML in met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de outputgrootte.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Sluit lettertypes uit alleen wanneer u zeker weet dat de doel‑browsers of -systemen deze al leveren. Voor merk‑lettertypes of minder gangbare lettertypes is insluiten meestal veiliger.

## **Lettertypebestanden linken in plaats van insluiten**

Om de HTML‑bestandsgrootte te verkleinen, kunt u lettertype‑data naar afzonderlijke WOFF‑bestanden schrijven en `@font-face`‑regels toevoegen aan de HTML. In PHP via Java wordt dit scenario meestal gerealiseerd met een kleine Java‑helperklasse die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedallfontshtmlcontroller/) uitbreidt, lettertypebytes naar een output‑directory schrijft, en `@font-face`‑regels in de gegenereerde HTML injecteert. Compileer die helper, voeg deze toe aan de PHP‑Java‑Bridge classpath, en instantieer hem vervolgens vanuit PHP met `new Java(...)`.

Wanneer u zo’n helper bouwt, kies dan twee paden bewust:

- Het bestandssysteem‑outputpad, waar gegenereerde lettertypebestanden worden weggeschreven.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die lettertypebestanden te laden.

## **Bronnen extern opslaan**

Zelf‑behorende HTML is makkelijk te verplaatsen, maar ingesloten Base64‑bronnen kunnen het bestand groot maken. Als uw applicatie externe afbeeldingsbestanden nodig heeft, geef dan een aangepaste link/inkapsel‑controller door aan de constructor van [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/).

Wanneer u bronnen externaliseert, kies dan twee paden bewust:

- Het bestandssysteem‑outputpad, waar uw applicatie gegenereerde afbeeldingen, lettertypes, audio of video schrijft.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

Houd deze paden consistent met uw deployment‑layout zodat de gegenereerde HTML zijn externe bronnen kan laden nadat hij is verplaatst naar een webserver of een andere map.

## **Mediabestanden exporteren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor neemt:

- `path`: de output‑directory die door het gegenereerde HTML‑ en mediabestand wordt gebruikt.
- `fileName`: de naam van het HTML‑bestand dat wordt gegenereerd.
- `baseUri`: het absolute URI‑prefix dat in de HTML‑links naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is, moet `path` verwijzen naar `html-output`, en moet `baseUri` verwijzen naar dezelfde map vanuit het perspectief van de browser. Voor lokale preview kunt u een `file:///`‑URI uit de output‑directory bouwen. Voor een gedeployed applicatie gebruikt u de absolute URL van de gepubliceerde output‑directory.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

Gebruik output‑directories die uniek zijn per export‑taak, vooral in server‑applicaties. Gedeelde output‑paden kunnen ervoor zorgen dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resource‑beheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugengebruik hangen af van het aantal dia’s, de beeldresolutie, lettertypes, effecten, diagrammen en ingebedde media. Hogere `PicturesCompression`‑DPI‑waarden, ingesloten lettertypes, SVG‑output en behouden bijgesneden beeldgebieden kunnen de getrouwheid verbeteren maar meestal de outputgrootte verhogen.

Voor batch‑conversie:

- Maak elke [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) instantie snel vrij.
- Gebruik afzonderlijke output‑directories voor verschillende taken.
- Vermijd het insluiten van gangbare lettertypes tenzij de getrouwheid dit vereist.
- Verlaag de afbeelding‑DPI wanneer de HTML alleen voor preview of thumbnails wordt gebruikt.
- Houd de bronpresentatie, gegenereerde HTML en externe bronnen samen tot de uiteindelijke deployment‑paden bekend zijn.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) instantie over threads. Verwerk verschillende bestanden met afzonderlijke presentatie‑instanties, aparte streams en aparte output‑directories.

**Is een Presentatie‑object thread‑safe?**

Nee. Een enkele [Presentatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) instantie moet op één thread worden geladen, bewerkt, opgeslagen en vrijgegeven. Voor parallel werk, maak een onafhankelijke instantie per thread of proces.

**Waarom is het gegenereerde HTML‑bestand groot?**

De standaardexport kan bronnen direct in de HTML insluiten. Ingesloten lettertypes, hoge‑DPI‑afbeeldingen, media, SVG‑inhoud en behouden bijgesneden beeldgebieden vergroten ook de grootte. Gebruik externe bronnen, sluit veelvoorkomende lettertypes uit en verlaag `PicturesCompression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom wordt een PowerPoint‑lettergrootte van 24 pt weergegeven als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekengroottes op in typografische punten gebaseerd op 72 DPI, terwijl HTML‑layout is gebaseerd op CSS‑pixels in een 96 DPI‑model. Wanneer Aspose.Slides een presentatie naar HTML exporteert, wordt de lettergrootte vertaald tussen deze systemen, en kan de conversie kleine afrondingsverschillen introduceren.

Deze waarden duiden niet op een echte visuele wijziging van de lettergrootte. Ze zijn slechts een wiskundig neveneffect van het omrekenen van tekst‑metingen tussen PowerPoint en HTML.

**Hoe kies ik baseUri voor media‑export?**

Kies `baseUri` vanuit het perspectief van de browser en geef het door als een absolute URI. Voor lokale preview kunt u deze afleiden van de output‑directory met een Java‑bestand‑URI. Voor deployment gebruikt u de absolute URL van de gepubliceerde mediamap. Het bestandssysteem‑`path` en de browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar ze moeten naar dezelfde resource‑locatie verwijzen.

**Kan ik verborgen dia’s opnemen?**

Ja. Stel `ShowHiddenSlides` in op `true` op [HtmlOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/htmloptions/) wanneer verborgen dia’s moeten worden geëxporteerd.