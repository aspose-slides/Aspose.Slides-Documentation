---
title: PowerPoint-presentaties converteren naar HTML in Java
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "PowerPoint-presentaties converteren naar HTML in Java. Gebruik Aspose.Slides om PPT- en PPTX-bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides for Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit één [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑load en een `save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/) wanneer je de geëxporteerde lay‑out, lettertypen, afbeeldingen, notities, opmerkingen, SVG‑output of gekoppelde bronnen wilt controleren.

Deze gids richt zich op praktische HTML‑exportscenario’s:

- Exporteer een hele presentatie of geselecteerde dia’s.
- Genereer vaste lay‑out, responsieve of op SVG gebaseerde HTML.
- Neem spreker‑notities en opmerkingen op.
- Beheers de beeldkwaliteit en bijgesneden beeldgegevens.
- Embed lettertypen of sla lettertypebestanden apart op.
- Kies hoe externe bronnen en mediabestanden worden weggeschreven en gerefereerd.

Standaard produceert HTML‑export een zelfvoorzienend HTML‑document waarbij de meeste bronnen zijn ingebed. Dit is handig om één bestand te delen, maar kan de outputgrootte vergroten. Voor publicatie op het web kun je overwegen externe bronnen te gebruiken, de DPI van afbeeldingen te verlagen en alleen lettertypen in te sluiten die niet betrouwbaar beschikbaar zijn in de doelsituatie.

## **Een presentatie naar HTML converteren**

Om een presentatie naar HTML te exporteren, laad je deze met [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) en sla je hem op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dit voorbeeld schrijft één HTML‑bestand. Het presentatiedobject wordt in het `finally`‑blok vernietigd, waardoor bestands­handvatten en render­resources na de export vrijkomen.

## **HtmlOptions gebruiken**

[HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelvoorkomende instellingen omvatten:

- `SlidesLayoutOptions`: voegt notities, opmerkingen, hand-outs of andere lay‑outinformatie toe.
- `HtmlFormatter`: wijzigt de HTML‑documentstructuur of delegeert formattering naar een controller.
- `SlideImageFormat`: verandert hoe dia’s worden weergegeven, bijvoorbeeld als SVG.
- `PicturesCompression`: regelt de DPI van afbeeldingen en de outputgrootte.
- `DeletePicturesCroppedAreas`: behoudt of verwijdert bijgesneden beeldgegevens.
- `SvgResponsiveLayout`: laat geëxporteerde SVG‑content zich aanpassen aan de container.
- `ShowHiddenSlides`: neemt verborgen dia’s op wanneer dat nodig is.

De volgende secties tonen de meest gangbare opties afzonderlijk, zodat je alleen die kunt combineren die jouw workflow vereist.

## **Geselecteerde dia’s naar HTML converteren**

De overload `Presentation.save` die dia‑nummers accepteert, werkt met 1‑gebaseerde posities. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/)‑instantie en geef die door aan elke `save`‑aanroep.

## **Responsieve HTML maken**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/responsivehtmlcontroller/) biedt responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmlformatter/). Gebruik deze wanneer de geëxporteerde pagina beter moet inspelen op de breedte van de browser.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Voor een op SVG gebaseerde responsieve lay‑out, stel `SvgResponsiveLayout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/). Dit is handig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Spreker‑notities en opmerkingen opnemen**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.setSlidesLayoutOptions` om spreker‑notities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen, tenzij je hun posities opgeeft.

Stel dat de bronpresentatie spreker‑notities bevat:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

De volgende code exporteert de dia‑inhoud met de spreker‑notities onder de dia.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

De geëxporteerde HTML bevat het notitie‑gebied:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Om opmerkingen te exporteren, stel `CommentsPosition` in, bijvoorbeeld op `CommentsPositions.Right` of `CommentsPositions.Bottom`. Als je alleen opmerkingen nodig hebt, laat je `NotesPosition` weg. Als je zowel notities als opmerkingen wilt, stel je beide eigenschappen in.

## **Beeldkwaliteit en bijgesneden gebieden beheren**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `PicturesCompression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturescompression/) wanneer je hogere beeldkwaliteit nodig hebt.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Standaard kunnen bijgesneden delen van afbeeldingen uit de geëxporteerde output worden verwijderd. Bewaar bijgesneden gegevens alleen wanneer gebruikers die verborgen beelddelen moeten kunnen herstellen of inspecteren. Het behouden kan de HTML‑grootte doen toenemen.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **CSS toevoegen**

Voor eenvoudige styling kun je een CSS‑string doorgeven aan `HtmlFormatter.createDocumentFormatter`. Hiermee wijzig je het omringende HTML‑document, terwijl Aspose.Slides de dia‑inhoud blijft renderen.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Voor een aangepast document‑header, een gekoppeld CSS‑bestand of aangepaste markup rond dia’s en vormen, implementeer [IHtmlFormattingController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihtmlformattingcontroller/) en geef die door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmlformatter/) via `createCustomFormatter`.

## **Lettertypen insluiten**

Als de doelsituatie de presentatie‑lettertypen mogelijk niet geïnstalleerd heeft, kun je lettertypen insluiten in de HTML met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid, maar vergroot de outputgrootte.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sluit lettertypen alleen uit wanneer je er zeker van bent dat de doel‑browsers of -systemen ze reeds aanbieden. Voor merklett­typen of minder gangbare lettertypen is insluiten doorgaans veiliger.

## **Lettertypebestanden koppelen i.p.v. insluiten**

Om de HTML‑bestandsgrootte te verkleinen, kun je lettertype‑data naar aparte WOFF‑bestanden schrijven en `@font-face`‑regels aan de HTML toevoegen. De helper hieronder breidt [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedallfontshtmlcontroller/) uit en overschrijft `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In dit voorbeeld worden lettertype‑bestanden opgeslagen in `html-output/fonts`, en verwijst de HTML ernaar met URL’s zoals `fonts/BrandFont-normal-400.woff`. Als het HTML‑bestand en de lettertypen op een andere locatie worden ingezet, kies je `fontUrlPrefix` zodat die overeenkomt met het gepubliceerde URL‑pad.

## **Bronnen extern opslaan**

Zelfvoorzienende HTML is makkelijk te verplaatsen, maar ingebedde Base64‑bronnen kunnen het bestand flink vergroten. Als je applicatie externe afbeeldingsbestanden nodig heeft, implementeer [ILinkEmbedController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilinkembedcontroller/) en geef die door aan de [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/)‑constructor.

Wanneer je bronnen externaliseert, kies je twee paden bewust:

- Het besturingssysteem‑uitvoerpad, waar je applicatie gegenereerde afbeeldingen, lettertypen, audio‑ of videobestanden opschrijft.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

## **Mediabestanden exporteren**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en genereert HTML die ze in een browser kan afspelen. De constructor neemt:

- `path`: de map waar de gegenereerde mediabestanden worden weggeschreven.
- `fileName`: de naam van het HTML‑bestand dat wordt gegenereerd.
- `baseUri`: het absolute URI‑voorvoegsel dat in de HTML‑links naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is en mediabestanden worden opgeslagen in `html-output/media`, moet `path` naar de mediamap op schijf wijzen, terwijl `baseUri` naar dezelfde map moet wijzen vanuit het perspectief van de browser. Voor lokale preview kun je een `file:///`‑URI uit de mediamap bouwen. Voor een gedeployde applicatie gebruik je de absolute URL van de gepubliceerde mediamap.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gebruik uitvoermappen die uniek zijn per export‑taak, vooral in server‑applicaties. Gedeelde uitvoerpaden kunnen ertoe leiden dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resource‑beheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugenverbruik hangen af van het aantal dia’s, de beeldresolutie, lettertypen, effecten, grafieken en ingesloten media. Hogere `PicturesCompression`‑DPI‑waarden, ingesloten lettertypen, SVG‑output en behouden bijgesneden beeldgebieden kunnen de getrouwheid verbeteren, maar verhogen doorgaans de outputgrootte.

Voor batch‑conversie:

- Vernietig elke [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie direct na gebruik.
- Gebruik aparte uitvoermappen voor afzonderlijke taken.
- Vermijd het insluiten van veelvoorkomende lettertypen tenzij de getrouwheid het vereist.
- Verlaag de DPI van afbeeldingen wanneer de HTML alleen voor preview of thumbnails is bedoeld.
- Houd de bronpresentatie, de gegenereerde HTML en externe bronnen samen totdat de uiteindelijke deploy‑paden zijn vastgesteld.

## **FAQ**

**Worden hyperlinks behouden in de HTML‑output?**

Ja. Hyperlinks uit de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie tussen threads. Verwerk verschillende bestanden met afzonderlijke presentaties, streams en uitvoermappen. Zie de [multithreading guidance](/slides/nl/java/multithreading/) voor details.

**Is een Presentation‑object thread‑safe?**

Nee. Een enkele [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie moet geladen, aangepast, opgeslagen en vernietigd worden op één thread. Voor parallel werk maak je een onafhankelijke instantie per thread of proces.

**Waarom is het gegenereerde HTML‑bestand groot?**

De standaard‑export kan resources direct in de HTML insluiten. Ingesloten lettertypen, afbeeldingen met hoge DPI, media, SVG‑content en behouden bijgesneden beeldgebieden vergroten de grootte. Gebruik externe bronnen, sluit veelvoorkomende lettertypen uit en verlaag `PicturesCompression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom verschijnt een PowerPoint‑lettergrootte van 24 pt als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekstgroottes op in typografische points gebaseerd op 72 DPI, terwijl HTML‑layout werkt met CSS‑pixels in een 96 DPI‑model. Wanneer Aspose.Slides een presentatie naar HTML exporteert, wordt de lettergrootte tussen deze systemen vertaald, en kan de conversie kleine afrondingsverschillen introduceren.

Deze waarden duiden niet op een werkelijk visueel verschil in lettergrootte. Het betreft alleen een wiskundig bijeffect van de omzetting van tekst‑metriek tussen PowerPoint en HTML.

**Hoe moet ik baseUri kiezen voor mediabestanden?**

Kies `baseUri` vanuit het perspectief van de browser en geef deze op als een absolute URI. Voor lokale preview kun je deze afleiden van de uitvoermap met `mediaDirectory.toUri().toString()`. Voor deployment gebruik je de absolute URL van de gepubliceerde mediamap. Het besturingssysteem‑`path` en de browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar moeten naar dezelfde resource‑locatie verwijzen.

**Kan ik verborgen dia’s opnemen?**

Ja. Stel `ShowHiddenSlides` in op `true` op [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/) wanneer verborgen dia’s moeten worden geëxporteerd.