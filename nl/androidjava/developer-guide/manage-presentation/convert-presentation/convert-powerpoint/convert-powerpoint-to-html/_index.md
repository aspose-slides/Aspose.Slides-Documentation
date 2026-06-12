---
title: PowerPoint‑presentaties converteren naar HTML op Android
linktitle: PowerPoint naar HTML
type: docs
weight: 30
url: /nl/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint‑presentaties omzetten naar HTML op Android. Gebruik Aspose.Slides voor Android via Java om PPT‑ en PPTX‑bestanden, geselecteerde dia's, notities, lettertypen, afbeeldingen, SVG en media te exporteren."
---
## **Overzicht**

Aspose.Slides voor Android via Java kan PowerPoint‑presentaties opslaan als HTML zonder Microsoft PowerPoint. De basisconversie bestaat uit een enkele [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑load en een `save`‑aanroep met [SaveFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/). Gebruik [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/) wanneer u de geëxporteerde lay‑out, lettertypen, afbeeldingen, notities, opmerkingen, SVG‑uitvoer of gekoppelde bronnen wilt beheersen.

Dit overzicht richt zich op praktische HTML‑exportscenario's:

- Exporteer een volledige presentatie of geselecteerde dia's.
- Genereer vaste lay‑out, responsieve of SVG‑gebaseerde HTML.
- Neem presentatornotities en opmerkingen op.
- Beheer de beeldkwaliteit en bijgesneden afbeeldingsgegevens.
- Integreer lettertypen of sla lettertypebestanden afzonderlijk op.
- Kies hoe externe bronnen en mediabestanden worden weggeschreven en verwezen.

Standaard produceert HTML‑export een zelf‑containend HTML‑document waarbij de meeste bronnen zijn ingebed. Dit is handig voor het delen van één bestand, maar kan de outputgrootte vergroten. Voor webpublicatie overweeg externe bronnen, een lagere beeld‑DPI en alleen het inbedden van lettertypen die niet betrouwbaar beschikbaar zijn in de doellocatie.

## **Converteer een presentatie naar HTML**

Om een presentatie naar HTML te exporteren, laadt u deze met [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en slaat u deze op met [SaveFormat.Html](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Dit voorbeeld schrijft één HTML‑bestand. Het presentatie‑object wordt vrijgegeven in de `finally`‑blok, die bestands‑handles en renderingsbronnen na de export vrijmaakt.

## **Gebruik HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/) is de belangrijkste configuratieklasse voor HTML‑export. Veelvoorkomende instellingen omvatten:

- `SlidesLayoutOptions`: voegt notities, opmerkingen, hand‑outs of andere lay‑outinformatie toe.
- `HtmlFormatter`: wijzigt de HTML‑documentstructuur of delegeert opmaak aan een controller.
- `SlideImageFormat`: verandert hoe dia's worden weergegeven, bijvoorbeeld als SVG.
- `PicturesCompression`: beheert de beeld‑DPI en de outputgrootte.
- `DeletePicturesCroppedAreas`: behoudt of verwijdert bijgesneden afbeeldingsgegevens.
- `SvgResponsiveLayout`: laat de geëxporteerde SVG‑inhoud zich aanpassen aan de container.
- `ShowHiddenSlides`: neemt verborgen dia's op wanneer dat vereist is.

De volgende secties tonen de meest voorkomende opties afzonderlijk, zodat u alleen die kunt combineren die uw workflow nodig heeft.

## **Converteer geselecteerde dia's naar HTML**

De `Presentation.save`‑overload die slidennummers accepteert, gebruikt 1‑gebaseerde slide‑posities. De onderstaande lus slaat elke dia op in een apart HTML‑bestand.

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

Gebruik dit patroon wanneer een website of applicatie één HTML‑pagina per dia nodig heeft. Als elke dia dezelfde lay‑out moet hebben, maak dan één [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/)‑instantie aan en geef deze door aan elke `save`‑aanroep.

## **Maak responsieve HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/responsivehtmlcontroller/) levert responsieve HTML‑output via [HtmlFormatter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmlformatter/). Gebruik het wanneer de geëxporteerde pagina beter moet aanpassen aan de breedte van de browser.

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

Voor een SVG‑gebaseerde responsieve lay‑out stelt u `SvgResponsiveLayout` in op [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/). Dit is nuttig wanneer de dia‑inhoud wordt geëxporteerd als schaalbare SVG‑markup.

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

## **Neem presentatornotities en opmerkingen op**

Gebruik [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` om presentatornotities of opmerkingen op te nemen. Notities en opmerkingen zijn standaard verborgen tenzij u hun posities kiest.

Stel dat de bronpresentatie presentatornotities bevat:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

De onderstaande code exporteert de dia‑inhoud met presentatornotities onder de dia.

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

De geëxporteerde HTML bevat het notitiegebied:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Om opmerkingen te exporteren, stel `CommentsPosition` in, bijvoorbeeld op `CommentsPositions.Right` of `CommentsPositions.Bottom`. Als u alleen opmerkingen nodig heeft, laat `NotesPosition` weg. Als u zowel notities als opmerkingen nodig heeft, stel beide eigenschappen in.

## **Beheer afbeeldingskwaliteit en bijgesneden gebieden**

HTML‑export kan dia‑afbeeldingen comprimeren om de outputgrootte te verkleinen. Stel `PicturesCompression` in op een waarde uit [PicturesCompression](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturescompression/) wanneer u een hogere afbeeldingskwaliteit nodig heeft.

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

Standaard kunnen bijgesneden delen van afbeeldingen worden verwijderd uit de geëxporteerde output. Houd bijgesneden gegevens alleen vast wanneer gebruikers die verborgen afbeeldingsdelen moeten kunnen herstellen of inspecteren. Het behouden ervan kan de HTML‑grootte vergroten.

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

## **Voeg CSS toe**

Voor eenvoudige vormgeving geeft u een CSS‑string door aan `HtmlFormatter.createDocumentFormatter`. Dit wijzigt het omringende HTML‑document terwijl Aspose.Slides de dia‑inhoud blijft renderen.

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

Voor een aangepast document‑header, een gekoppeld CSS‑bestand, of aangepaste markup rond dia's en vormen, implementeer [IHtmlFormattingController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihtmlformattingcontroller/) en geef deze door aan [HtmlFormatter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmlformatter/) met `createCustomFormatter`.

## **Lettertypen insluiten**

Als de doelomgeving mogelijk niet de presentatie‑lettertypen geïnstalleerd heeft, sluit dan lettertypen in in de HTML met [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Insluiten verbetert de visuele getrouwheid maar vergroot de outputgrootte.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Sluit lettertypen uit alleen wanneer u er zeker van bent dat de doelbrowsers of -systemen ze al leveren. Voor merk‑lettertypen of minder gangbare lettertypen is insluiten doorgaans veiliger.

## **Koppel lettertype‑bestanden in plaats van ze in te sluiten**

Om de HTML‑bestandsgrootte te verkleinen, kunt u lettertype‑gegevens naar afzonderlijke WOFF‑bestanden schrijven en `@font-face`‑regels aan de HTML toevoegen. De helper hieronder breidt [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) uit en overschrijft `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In dit voorbeeld worden lettertypebestanden opgeslagen in `html-output/fonts`, en verwijst de HTML ernaar met URL’s zoals `fonts/BrandFont-normal-400.woff`. Als het HTML‑bestand en de lettertypen naar een andere locatie worden gedeployed, kies dan `fontUrlPrefix` zodat deze overeenkomt met het gepubliceerde URL‑pad.

## **Sla bronnen extern op**

Zelf‑containende HTML is makkelijk te verplaatsen, maar ingebedde Base64‑bronnen kunnen het bestand groot maken. Als uw applicatie externe afbeeldingsbestanden nodig heeft, implementeer dan [ILinkEmbedController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilinkembedcontroller/) en geef deze door aan de constructor van [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/).

Wanneer u bronnen extern maakt, kies twee paden bewust:

- Het bestandssysteem‑outputpad, waar uw applicatie gegenereerde afbeeldingen, lettertypen, audio of video schrijft.
- Het URL‑pad, dat de browser gebruikt vanuit het HTML‑document om die bestanden te laden.

## **Exporteer mediabestanden**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exporteert video‑ en audiobestanden en schrijft HTML die ze in een browser kan afspelen. De constructor neemt:

- `path`: de directory waar gegenereerde mediabestanden worden weggeschreven.
- `fileName`: de te genereren HTML‑bestandsnaam.
- `baseUri`: het absolute URI‑prefix dat in de HTML‑links naar mediabestanden wordt gebruikt.

Als het HTML‑bestand `html-output/presentation.html` is en mediabestanden worden opgeslagen in `html-output/media`, moet `path` naar de mediadirectory op schijf wijzen, terwijl `baseUri` naar dezelfde directory moet wijzen vanuit het perspectief van de browser. Voor lokale preview kunt u een `file:///`‑URI uit de mediadirectory opbouwen. Voor een gedeployed applicatie gebruikt u de absolute URL van de gepubliceerde mediadirectory.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Gebruik output‑directories die uniek zijn per exporttaak, vooral in server‑applicaties. Gedeelde output‑paden kunnen ervoor zorgen dat bestanden van verschillende conversies elkaar overschrijven.

## **Prestaties en resourcebeheer**

HTML‑conversie is een render‑operatie, dus verwerkingstijd en geheugenverbruik hangen af van het aantal dia's, de resolutie van afbeeldingen, lettertypen, effecten, diagrammen en ingebedde media. Hogere `PicturesCompression`‑DPI‑waarden, ingesloten lettertypen, SVG‑output en behouden bijgesneden afbeeldingsgebieden kunnen de getrouwheid verbeteren maar vergroten meestal de outputgrootte.

Voor batch‑conversie:

- Maak elke [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie onmiddellijk vrij.
- Gebruik aparte output‑directories voor afzonderlijke taken.
- Vermijd het insluiten van algemene lettertypen tenzij getrouwheid dat vereist.
- Verlaag de beeld‑DPI wanneer de HTML dient als preview of thumbnails.
- Houd de bronpresentatie, gegenereerde HTML en externe bronnen samen totdat de deploy‑paden definitief zijn.

## **FAQ**

**Worden hyperlinks bewaard in de HTML‑output?**

Ja. Hyperlinks in de presentatie worden geëxporteerd naar HTML en blijven klikbaar wanneer de doel‑URL geldig is.

**Kan ik presentaties parallel naar HTML converteren?**

Ja, maar deel geen enkele [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie over threads. Verwerk verschillende bestanden met afzonderlijke presentatie‑instanties, afzonderlijke streams en afzonderlijke output‑directories. Zie de [multithreading guidance](/slides/nl/androidjava/multithreading/) voor details.

**Is een Presentation‑object thread‑veilig?**

Nee. Een enkele [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie moet op één thread worden geladen, gewijzigd, opgeslagen en vrijgegeven. Voor parallel werk maakt u een onafhankelijke instantie per thread of proces.

**Waarom is het gegenereerde HTML‑bestand groot?**

Standaard kan de export bronnen direct in de HTML insluiten. Ingesloten lettertypen, hoge‑DPI‑afbeeldingen, media, SVG‑inhoud en behouden bijgesneden afbeeldingsgebieden vergroten ook de grootte. Gebruik externe bronnen, sluit algemene lettertypen uit en verlaag `PicturesCompression` wanneer een kleinere output belangrijker is dan maximale getrouwheid.

**Waarom verschijnt een PowerPoint‑lettergrootte van 24 pt als 17.999819 pt in HTML?**

Dit kan gebeuren omdat PowerPoint en HTML verschillende DPI‑modellen gebruiken. PowerPoint slaat tekstgroottes op in typografische punten gebaseerd op 72 DPI, terwijl HTML‑layout gebaseerd is op CSS‑pixels in een 96 DPI‑model. Bij het exporteren vertaalt Aspose.Slides de lettergrootte tussen deze systemen, wat kleine afrondingsverschillen kan veroorzaken.

Deze waarden geven geen echte visuele verandering in lettergrootte aan. Het is slechts een wiskundig neveneffect van de conversie van tekstmetriek tussen PowerPoint en HTML.

**Hoe moet ik baseUri kiezen voor mediasexport?**

Kies `baseUri` vanuit het perspectief van de browser en geef het op als een absolute URI. Voor lokale preview kunt u het afleiden van de output‑directory met `mediaDirectory.toUri().toString()`. Voor deployment gebruikt u de absolute URL van de gepubliceerde mediadirectory. Het bestandssysteem‑`path` en de browser‑`baseUri` hoeven niet dezelfde tekenreeks te zijn, maar moeten dezelfde resource‑locatie beschrijven.

**Kan ik verborgen dia's opnemen?**

Ja. Stel `ShowHiddenSlides` in op `true` op [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/) wanneer verborgen dia's moeten worden geëxporteerd.