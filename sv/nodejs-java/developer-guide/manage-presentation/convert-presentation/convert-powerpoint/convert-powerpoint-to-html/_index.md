---
title: Konvertera PowerPoint-presentationer till HTML i Node.js
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML i Node.js. Använd Aspose.Slides för Node.js via Java för att exportera PPT- och PPTX-filer, valda bilder, anteckningar, teckensnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan spara PowerPoint-presentationer som HTML utan Microsoft PowerPoint. Den grundläggande konverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) laddning och ett `save`‑anrop med [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/) när du behöver styra den exporterade layouten, teckensnitt, bilder, anteckningar, kommentarer, SVG‑utmatning eller länkade resurser.

Den här guiden fokuserar på praktiska HTML‑exportscenarier:

- Exportera en hel presentation eller valda bilder.
- Generera HTML med fast layout, responsiv eller SVG‑baserad.
- Inkludera talaranteckningar och kommentarer.
- Styr bildkvalitet och beskurna bilddata.
- Bädda in teckensnitt eller spara teckensnitts‑filer separat.
- Välj hur externa resurser och mediafiler skrivs och refereras.

Som standard producerar HTML‑export ett självständigt HTML‑dokument där de flesta resurser är inbäddade. Detta är bekvämt för att dela en fil, men det kan öka utdata­storleken. För webbpublicering, överväg externa resurser, lägre bild‑DPI och endast inbäddning av teckensnitt som inte är pålitligt tillgängliga i målmiljön.

## **Konvertera en presentation till HTML**

För att exportera en presentation till HTML, ladda den med [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och spara den med [SaveFormat.Html](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Detta exempel skriver en HTML‑fil. Presentations‑objektet disponeras i `finally`‑blocket, vilket frigör filhandtag och renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/) är huvudkonfigurationsklassen för HTML‑export. Vanliga inställningar inkluderar:

- `SlidesLayoutOptions`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `HtmlFormatter`: ändrar HTML‑dokumentstrukturen eller delegater formatering till en kontroller.
- `SlideImageFormat`: ändrar hur bilder representeras, t.ex. som SVG.
- `PicturesCompression`: styr bild‑DPI och utdata­storlek.
- `DeletePicturesCroppedAreas`: behåller eller tar bort beskurna bilddata.
- `SvgResponsiveLayout`: får exporterad SVG‑innehåll att anpassa sig till sin behållare.
- `ShowHiddenSlides`: inkluderar dolda bilder när det krävs.

Följande avsnitt visar de vanligaste alternativen separat så att du kan kombinera endast de som ditt arbetsflöde behöver.

## **Konvertera valda bilder till HTML**

`Presentation.save`‑överladdningen som accepterar bildnummer använder 1‑baserade bildpositioner. Loopen nedan sparar varje bild till en separat HTML‑fil.

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

Använd detta mönster när en webbplats eller applikation behöver en HTML‑sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions]‑instans och skicka den till varje `save`‑anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/responsivehtmlcontroller/) tillhandahåller responsiv HTML‑utmatning via [HtmlFormatter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmlformatter/). Använd den när den exporterade sidan bör anpassa sig bättre till webbläsarens bredd.

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

För SVG‑baserad responsiv layout, sätt `SvgResponsiveLayout` på [HtmlOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmloptions/). Detta är användbart när bildinnehållet exporteras som skalbar SVG‑markup.

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

## **Inkludera talaranteckningar och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.setSlidesLayoutOptions` för att inkludera talaranteckningar eller kommentarer. Anteckningar och kommentarer är dolda som standard om du inte väljer deras positioner.

Anta att källpresentationen innehåller talaranteckningar:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Följande kod exporterar bildinnehållet med talaranteckningar under bilden.

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

Den exporterade HTML‑koden inkluderar anteckningsområdet:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

För att exportera kommentarer, sätt `CommentsPosition`, till exempel till `CommentsPositions.Right` eller `CommentsPositions.Bottom`. Om du bara behöver kommentarer, utelämna `NotesPosition`. Om du behöver både anteckningar och kommentarer, sätt båda egenskaperna.

## **Styr bildkvalitet och beskurna områden**

HTML‑export kan komprimera bildbilder för att minska utdata­storleken. Sätt `PicturesCompression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturescompression/) när du behöver högre bildkvalitet.

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

Som standard kan beskurna områden av bilder tas bort från den exporterade utdata. Behåll beskurna data endast när användare måste kunna återställa eller inspektera dessa dolda bilddelar. Att behålla dem kan öka HTML‑storleken.

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

## **Lägg till CSS**

För enkel styling, skicka en CSS‑sträng till `HtmlFormatter.createDocumentFormatter`. Detta förändrar det omgivande HTML‑dokumentet medan Aspose.Slides fortsätter att rendera bildinnehållet.

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

För ett anpassat dokumenthuvud, en länkad CSS‑fil eller anpassad markup runt bilder och former, använd [HtmlFormatter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/htmlformatter/) med en formateringskontroller.

## **Bädda in teckensnitt**

Om målmiljön kanske inte har presentationens teckensnitt installerade, bädda in teckensnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Inbäddning förbättrar visuellt återgivning men ökar utdata­storleken.

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

Uteslut teckensnitt endast när du är säker på att målwebbläsare eller system redan tillhandahåller dem. För varumärkesteckensnitt eller mindre vanliga teckensnitt är inbäddning vanligtvis säkrare.

## **Länka teckensnittsfiler istället för att bädda in dem**

För att minska HTML‑filens storlek kan du skriva teckensnittsdata till separata WOFF‑filer och lägga till `@font-face`‑regler i HTML. I Node.js via Java implementeras detta scenario vanligtvis med en liten Java‑hjälparklass som ärver [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), skriver teckensnitts‑bytes till en utmatningskatalog och injicerar `@font-face`‑regler i den genererade HTML‑koden. Kompilera den hjälparen, lägg till den i Node.js‑modulens klassväg och skapa sedan en instans från JavaScript med `java.newInstanceSync`.

När du bygger en sådan hjälpare, välj två sökvägar med avsikt:

- Filsystemets utskrifts‑sökväg, där genererade teckensnittsfiler skrivs.
- URL‑sökvägen, vilket är vad webbläsaren använder från HTML‑dokumentet för att ladda dessa teckensnittsfiler.

## **Spara resurser externt**

Självständigt HTML är lätt att flytta, men inbäddade Base64‑resurser kan göra filen stor. Om din applikation behöver externa bild‑, teckensnitt‑, ljud‑ eller videofiler, använd en exportkontroller som skriver resurser till en vald katalog och avger webbläsar‑synliga URL‑er. Håll filsökvägen och URL‑sökvägen i linje med din distributionslayout.

## **Exportera mediefiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exporterar video‑ och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: katalogen där genererade mediefiler kommer att skrivas.
- `fileName`: HTML‑filnamnet som genereras.
- `baseUri`: det absoluta URI‑prefixet som används i HTML‑länkarna till mediefiler.

Om HTML‑filen är `html-output/presentation.html` och mediefiler sparas i `html-output/media`, bör `path` peka på media‑katalogen på disken, medan `baseUri` ska peka på samma katalog ur webbläsarens perspektiv. För lokal förhandsgranskning kan du skapa en `file:///`‑URI från mediekatalogen. För en distribuerad applikation, använd den absoluta URL‑en till den publicerade media‑katalogen.

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

Använd utmatningskataloger som är unika per exportjobb, särskilt i serverapplikationer. Delade utmatningssökvägar kan leda till att filer från olika konverteringar skriver över varandra.

## **Prestanda och resurshantering**

HTML‑konvertering är en renderingsoperation, så bearbetningstid och minnesanvändning beror på bildantal, bildupplösning, teckensnitt, effekter, diagram och inbäddade media. Högre `PicturesCompression`‑DPI‑värden, inbäddade teckensnitt, SVG‑utmatning och behållna beskurna bildområden kan förbättra återgivning men ökar vanligtvis utdata­storleken.

För batchkonvertering:

- Dispose varje [Presentation]‑instans omedelbart.
- Använd separata utmatningskataloger för separata jobb.
- Undvik att inbädda vanliga teckensnitt om inte återgivning kräver det.
- Sänk bild‑DPI när HTML är för förhandsgranskning eller miniatyrer.
- Behåll källpresentationen, genererad HTML och externa resurser tillsammans tills distributionsvägarna är slutgiltiga.

## **FAQ**

**Bevaras hyperlänkar i HTML‑utdata?**

Ja. Presentations‑hyperlänkar exporteras till HTML och förblir klickbara när mål‑URL:en är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation]‑instans mellan arbetare. Processa olika filer med separata presentations‑instanser, separata strömmar och separata utmatningskataloger. Se [multithreading guidance](/slides/sv/nodejs-java/multithreading/) för detaljer.

**Är ett Presentation‑objekt trådsäkert?**

Nej. En enskild [Presentation]‑instans bör laddas, modifieras, sparas och disponeras i en arbetare. För parallellt arbete, skapa en oberoende instans per arbetare eller process.

**Varför är den genererade HTML‑filen stor?**

Den förvalda exporten kan bädda in resurser direkt i HTML. Inbäddade teckensnitt, hög‑DPI‑bilder, media, SVG‑innehåll och behållna beskurna bildområden ökar också storleken. Använd externa resurser, uteslut vanliga teckensnitt från inbäddning och sänk `PicturesCompression` när en mindre utdata är viktigare än maximal återgivning.

**Varför visas en PowerPoint‑teckensnittsstorlek som 24 pt som 17.999819 pt i HTML?**

Detta kan inträffa eftersom PowerPoint och HTML använder olika DPI‑modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserade på 72 DPI, medan HTML‑layout är baserad på CSS‑pixlar i en 96 DPI‑modell. När Aspose.Slides exporterar en presentation till HTML, översätts teckensnittsstorleken mellan dessa system, och konverteringen kan introducera små avrundningsskillnader.

Dessa värden indikerar inte en faktisk visuell förändring av teckensnittsstorleken. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur ska jag välja baseUri för mediaexport?**

Välj `baseUri` ur webbläsarens perspektiv och skicka den som en absolut URI. För lokal förhandsgranskning kan du härleda den från utmatningskatalogen med en `file:///`‑URI. För distribution, använd den absoluta URL‑en till den publicerade media‑katalogen. Fil‑systemets `path` och webbläsarens `baseUri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `ShowHiddenSlides` till `true` på [HtmlOptions] när dolda bilder måste exporteras.