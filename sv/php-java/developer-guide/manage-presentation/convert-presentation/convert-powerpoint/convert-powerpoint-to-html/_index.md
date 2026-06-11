---
title: Konvertera PowerPoint-presentationer till HTML i PHP
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/php-java/convert-powerpoint-to-html/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- spara PowerPoint som HTML
- spara presentation som HTML
- spara bild som HTML
- spara PPT som HTML
- spara PPTX som HTML
- exportera PPT till HTML
- exportera PPTX till HTML
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML i PHP. Använd Aspose.Slides för att exportera PPT- och PPTX-filer, valda bilder, noteringar, teckensnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides for PHP via Java kan spara PowerPoint-presentationer som HTML utan Microsoft PowerPoint. Den grundläggande konverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) laddning och ett `save`-anrop med [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) när du behöver kontrollera den exporterade layouten, teckensnitt, bilder, anteckningar, kommentarer, SVG-utdata eller länkade resurser.

Denna guide fokuserar på praktiska scenarier för HTML-export:

- Exportera en hel presentation eller utvalda bilder.
- Generera fast layout, responsiv eller SVG-baserad HTML.
- Inkludera talarnoteringar och kommentarer.
- Kontrollera bildkvalitet och beskärda bilddata.
- Bädda in teckensnitt eller spara teckensnittsfiler separat.
- Välj hur externa resurser och mediafiler skrivs och refereras.

Som standard producerar HTML-export ett självständigt HTML-dokument där de flesta resurser är inbäddade. Detta är bekvämt för att dela en enda fil, men det kan öka utdatafilens storlek. För webbpublicering, överväg externa resurser, lägre bild-DPI och endast inbäddning av teckensnitt som inte är pålitligt tillgängliga i målmiljön.

## **Konvertera en presentation till HTML**

För att exportera en presentation till HTML, ladda den med [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och spara den med [SaveFormat.Html](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/).

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Detta exempel skriver en HTML-fil. presentationsobjektet avyttras i `finally`-blocket, vilket frigör filhandtag och renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) är huvudkonfigurationsklassen för HTML-export. Vanliga inställningar inkluderar:

- `SlidesLayoutOptions`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `HtmlFormatter`: ändrar HTML-dokumentets struktur eller delegerar formatering till en kontroller.
- `SlideImageFormat`: ändrar hur bilder representeras, till exempel som SVG.
- `PicturesCompression`: styr bild-DPI och utdatafilens storlek.
- `DeletePicturesCroppedAreas`: behåller eller tar bort beskärda bilddata.
- `SvgResponsiveLayout`: får exporterad SVG-innehåll att anpassa sig till sin behållare.
- `ShowHiddenSlides`: inkluderar dolda bilder när det behövs.

Följande avsnitt visar de vanligaste alternativen separat så att du kan kombinera endast de som ditt arbetsflöde behöver.

## **Konvertera valda bilder till HTML**

`save`-överladdningen som accepterar bildnummer använder 1-baserade positionsnummer. Loopen nedan sparar varje bild till en separat HTML-fil.

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

Använd detta mönster när en webbplats eller applikation kräver en HTML-sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) instans och skicka den till varje `save`-anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/responsivehtmlcontroller/) ger responsiv HTML-utmatning via [HtmlFormatter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmlformatter/). Använd den när den exporterade sidan ska anpassa sig bättre till webbläsarens bredd.

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

För SVG-baserad responsiv layout, sätt `SvgResponsiveLayout` på [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/). Detta är användbart när bildinnehållet exporteras som skalbar SVG-markup.

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

## **Inkludera talarnoteringar och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` för att inkludera talarnoteringar eller kommentarer. Noteringar och kommentarer är dolda som standard om du inte väljer deras positioner.

Anta att källpresentationen innehåller talarnoteringar:

![Bild med talarnoteringar i PowerPoint](slide_with_notes.png)

Följande kod exporterar bildinnehållet med talarnoteringar under bilden.

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

![HTML-utdata med bilden och talarnoteringar](HTML_with_notes.png)

För att exportera kommentarer, sätt `CommentsPosition`, till exempel till `CommentsPositions.Right` eller `CommentsPositions.Bottom`. Om du bara behöver kommentarer, utelämna `NotesPosition`. Om du behöver både noteringar och kommentarer, sätt båda egenskaperna.

## **Kontrollera bildkvalitet och beskärda områden**

HTML-export kan komprimera bildbilder för att minska utdatafilens storlek. Sätt `PicturesCompression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturescompression/) när du behöver högre bildkvalitet.

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

Som standard kan beskärda områden av bilder tas bort från den exporterade utdata. Behåll beskärda data endast när användare måste kunna återställa eller inspektera dessa dolda bilddelar. Att behålla dem kan öka HTML-storleken.

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

## **Lägg till CSS**

För enkel styling, skicka en CSS-sträng till [HtmlFormatter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmlformatter/) via `createDocumentFormatter`. Detta ändrar det omgivande HTML-dokumentet medan Aspose.Slides fortsätter rendera bildinnehållet.

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

För ett anpassat dokumenthuvud, en länkad CSS-fil eller anpassad markup runt bilder och former, använd en anpassad formateringskontroller och skicka den till [HtmlFormatter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmlformatter/) med `createCustomFormatter`.

## **Bädda in teckensnitt**

Om målmiljön kanske inte har presentationens teckensnitt installerade, bädda in teckensnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedallfontshtmlcontroller/). Inbäddning förbättrar visuell trohet men ökar utdatafilens storlek.

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

Undanta teckensnitt bara när du är säker på att målwebbläsarna eller systemen redan tillhandahåller dem. För varumärkesteckensnitt eller mindre vanliga teckensnitt är inbäddning vanligtvis säkrare.

## **Länka teckensnitts-filer istället för att bädda in dem**

För att minska HTML-filens storlek kan du skriva teckensnittsdata till separata WOFF-filer och lägga till `@font-face`-regler i HTML. I PHP via Java implementeras detta vanligtvis med en liten Java-hjälparklass som utökar [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/embedallfontshtmlcontroller/), skriver teckensnittsbytes till en utdatamapp och injicerar `@font-face`-regler i den genererade HTML:n. Kompilera den hjälparklassen, lägg till den i PHP Java Bridge-klassvägen och instansiera den sedan från PHP med `new Java(...)`.

När du bygger en sådan hjälparklass, välj två sökvägar medvetet:

- Filsystemets utdatamapp, där de genererade teckensnittsfilena skrivs.
- URL-sökvägen, som webbläsaren använder från HTML-dokumentet för att läsa in dessa teckensnitts-filer.

## **Spara resurser externt**

Självständigt HTML är lätt att flytta, men inbäddade Base64-resurser kan göra filen stor. Om din applikation behöver externa bildfiler, tillhandahåll en anpassad länk-/inbäddningskontroller till [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) konstruktor.

När du externtiserar resurser, välj två sökvägar medvetet:

- Filsystemets utdatamapp, där din applikation skriver genererade bilder, teckensnitt, ljud eller video.
- URL-sökvägen, som webbläsaren använder från HTML-dokumentet för att läsa in dessa filer.

Håll dessa sökvägar konsekventa med din distributionslayout så att den genererade HTML:n kan läsa in sina externa resurser efter att den flyttats till en webbserver eller annan katalog.

## **Exportera mediafiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoplayerhtmlcontroller/) exporterar video- och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: utdatamappen som används av den genererade HTML:n och mediafilerna.
- `fileName`: HTML-filnamnet som genereras.
- `baseUri`: den absoluta URI-prefixen som används i HTML-länkarna till mediafiler.

Om HTML-filen är `html-output/presentation.html`, bör `path` peka på `html-output`, och `baseUri` bör peka på samma katalog ur webbläsarens perspektiv. För lokal förhandsgranskning kan du bygga en `file:///`-URI från utdatamappen. För en distribuerad applikation, använd den absoluta URL:en till den publicerade utdatamappen.

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

Använd utdatamappar som är unika per exportjobb, särskilt i serverapplikationer. Delade utdatamappar kan orsaka att filer från olika konverteringar skriver över varandra.

## **Prestanda och resursadministration**

HTML-konvertering är en renderingsoperation, så bearbetningstid och minnesanvändning beror på antal bilder, bildupplösning, teckensnitt, effekter, diagram och inbäddade media. Högre `PicturesCompression` DPI-värden, inbäddade teckensnitt, SVG-utdata och behållna beskärda bildområden kan förbättra troheten men ökar vanligtvis storleken på utdata.

För batchkonvertering:

- Avyttra varje [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans omedelbart.
- Använd separata utdatamappar för separata jobb.
- Undvik att bädda in vanliga teckensnitt om inte trohet kräver det.
- Sänk bild-DPI när HTML:n är för förhandsgranskning eller miniatyrbilder.
- Behåll källpresentationen, den genererade HTML:n och externa resurser tillsammans tills distributionsvägarna är slutgiltiga.

## **Vanliga frågor**

**Behålls hyperlänkar i HTML-utdata?**

Ja. Presentationshyperlänkar exporteras till HTML och förblir klickbara när mål-URL:en är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans över trådar. Bearbeta olika filer med separata presentationsinstanser, separata strömmar och separata utdatamappar.

**Är ett Presentation-objekt trådsäkert?**

Nej. En enskild [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) instans bör laddas, modifieras, sparas och avyttras på en enda tråd. För parallellt arbete, skapa en oberoende instans per tråd eller process.

**Varför är den genererade HTML-filen stor?**

Standardexporten kan bädda in resurser direkt i HTML. Inbäddade teckensnitt, hög-DPI-bilder, media, SVG-innehåll och behållna beskärda bildområden ökar också storleken. Använd externa resurser, exkludera vanliga teckensnitt från inbäddning, och sänk `PicturesCompression` när en mindre fil är viktigare än maximal trohet.

**Varför visas en PowerPoint-teckenstorlek som 24 pt som 17.999819 pt i HTML?**

Detta kan hända eftersom PowerPoint och HTML använder olika DPI-modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserat på 72 DPI, medan HTML-layout är baserad på CSS-pixlar i en 96 DPI-modell. När Aspose.Slides exporterar en presentation till HTML, översätts teckenstorleken mellan dessa system, och konverteringen kan introducera små avrundningsskillnader.

Dessa värden indikerar inte en verklig visuell förändring av teckenstorleken. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur bör jag välja baseUri för mediaexport?**

Välj `baseUri` ur webbläsarens perspektiv och skicka den som en absolut URI. För lokal förhandsgranskning kan du härleda den från utdatamappen med en Java-fil-URI. För distribution, använd den absoluta URL:en till den publicerade mediakatalogen. Filsystemets `path` och webbläsarens `baseUri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `ShowHiddenSlides` till `true` på [HtmlOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/htmloptions/) när dolda bilder måste exporteras.