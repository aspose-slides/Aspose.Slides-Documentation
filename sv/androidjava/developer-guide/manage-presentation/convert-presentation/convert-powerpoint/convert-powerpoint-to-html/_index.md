---
title: Konvertera PowerPoint-presentationer till HTML på Android
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML på Android. Använd Aspose.Slides för Android via Java för att exportera PPT- och PPTX-filer, valda bilder, anteckningar, teckensnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides för Android via Java kan spara PowerPoint-presentationer som HTML utan Microsoft PowerPoint. Den grundläggande konverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑laddning och ett `save`‑anrop med [SaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/) när du behöver kontrollera det exporterade layouten, teckensnitt, bilder, anteckningar, kommentarer, SVG‑utmatning eller länkade resurser.

Denna guide fokuserar på praktiska scenarier för HTML‑export:

- Exportera en hel presentation eller valda bilder.
- Generera fast layout, responsiv eller SVG‑baserad HTML.
- Inkludera talarnoter och kommentarer.
- Styr bildkvalitet och beskurna bilddata.
- Bädda in teckensnitt eller spara teckensnittsfiler separat.
- Välj hur externa resurser och medi filer skrivs och refereras.

Som standard producerar HTML‑export ett självständigt HTML‑dokument där de flesta resurser är inbäddade. Detta är bekvämt för att dela en enda fil, men kan öka filens storlek. För webbpublicering, överväg externa resurser, lägre bild‑DPI och att bara bädda in teckensnitt som inte är tillförlitligt tillgängliga i målmiljön.

## **Konvertera en Presentation till HTML**

För att exportera en presentation till HTML, laddar du den med [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och sparar den med [SaveFormat.Html](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Detta exempel skriver en HTML‑fil. Presentation‑objektet disponeras i `finally`‑blocket, vilket frigör filhandtag och renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/) är huvudkonfigurationsklassen för HTML‑export. Vanliga inställningar inkluderar:

- `SlidesLayoutOptions`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `HtmlFormatter`: ändrar HTML‑dokumentets struktur eller delegerar formatering till en kontroller.
- `SlideImageFormat`: ändrar hur bilder representeras, till exempel som SVG.
- `PicturesCompression`: styr bild‑DPI och utskriftsstorlek.
- `DeletePicturesCroppedAreas`: behåller eller tar bort beskurna bilddata.
- `SvgResponsiveLayout`: får exporterad SVG‑innehåll att anpassa sig till sin behållare.
- `ShowHiddenSlides`: inkluderar dolda bilder när så krävs.

Följande avsnitt visar de vanligaste alternativen separat så att du kan kombinera endast de som ditt arbetsflöde behöver.

## **Konvertera utvalda bilder till HTML**

`Presentation.save`‑överladdningen som accepterar bildnummer använder 1‑baserade bildpositioner. Loopen nedan sparar varje bild till en separat HTML‑fil.

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

Använd detta mönster när en webbplats eller applikation behöver en HTML‑sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/)‑instans och skicka den till varje `save`‑anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/responsivehtmlcontroller/) erbjuder responsiv HTML‑utmatning via [HtmlFormatter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmlformatter/). Använd den när den exporterade sidan ska anpassa sig bättre till webbläsarens bredd.

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

För SVG‑baserad responsiv layout, sätt `SvgResponsiveLayout` på [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/). Detta är användbart när bildens innehåll exporteras som skalbar SVG‑markup.

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

## **Inkludera talarnoter och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` för att inkludera talarnoter eller kommentarer. Noter och kommentarer är dolda som standard om du inte väljer deras positioner.

Anta att källpresentationen innehåller talarnoter:

![Bild med talarnoter i PowerPoint](slide_with_notes.png)

Följande kod exporterar bildens innehåll med talarnoter under bilden.

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

Den exporterade HTML‑en inkluderar anteckningsområdet:

![HTML‑utdata med bilden och talarnoter](HTML_with_notes.png)

För att exportera kommentarer, ställ in `CommentsPosition`, till exempel på `CommentsPositions.Right` eller `CommentsPositions.Bottom`. Om du bara behöver kommentarer, utelämna `NotesPosition`. Om du behöver både noter och kommentarer, sätt båda egenskaperna.

## **Styr bildkvalitet och beskurna områden**

HTML‑export kan komprimera bilderna för att minska utskriftsstorleken. Ställ in `PicturesCompression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/picturescompression/) när du behöver högre bildkvalitet.

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

Som standard kan beskärda områden av bilder tas bort från den exporterade utskriften. Behåll beskärda data endast när användare måste kunna återställa eller inspektera de dolda bilddelarna. Att behålla dem kan öka HTML‑storleken.

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

## **Lägg till CSS**

För enkel formatering, skicka en CSS‑sträng till `HtmlFormatter.createDocumentFormatter`. Detta ändrar det omgivande HTML‑dokumentet medan Aspose.Slides fortsätter rendera bildens innehåll.

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

För ett anpassat dokumenthuvud, en länkad CSS‑fil eller anpassad markup runt bilder och former, implementera [IHtmlFormattingController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihtmlformattingcontroller/) och skicka den till [HtmlFormatter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmlformatter/) med `createCustomFormatter`.

## **Bädda in teckensnitt**

Om målmiljön kanske inte har presentationens teckensnitt installerade, bädda in teckensnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/embedallfontshtmlcontroller/). Inbäddning förbättrar visuell trohet men ökar filstorleken.

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

Exkludera teckensnitt endast när du är säker på att mål‑webbläsare eller system redan tillhandahåller dem. För varumärkesteckensnitt eller mindre vanliga teckensnitt är inbäddning vanligtvis säkrare.

## **Länka teckensnittsfiler istället för att bädda in dem**

För att minska HTML‑filens storlek kan du skriva teckensnittsdata till separata WOFF‑filer och lägga till `@font-face`‑regler i HTML. Hjälparen nedan utökar [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) och åsidosätter `writeFont`.

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

I detta exempel sparas teckensnittsfilerna till `html-output/fonts`, och HTML refererar dem med URL‑er som `fonts/BrandFont-normal-400.woff`. Om HTML‑filen och teckensnitten distribueras till en annan plats, välj `fontUrlPrefix` så att det matchar den distribuerade URL‑sökvägen.

## **Spara resurser externt**

Självständigt HTML är enkelt att flytta, men inbäddade Base64‑resurser kan göra filen stor. Om din applikation behöver externa bildfiler, implementera [ILinkEmbedController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinkembedcontroller/) och skicka den till [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/)-konstruktorn.

När du externaliserar resurser, välj två sökvägar medvetet:

- Filsystemets utdatamapp, där din applikation skriver genererade bilder, teckensnitt, ljud eller video.
- URL‑sökvägen, vilket är vad webbläsaren använder från HTML‑dokumentet för att ladda dessa filer.

## **Exportera mediefiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) exporterar video‑ och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: katalogen där genererade mediefiler kommer att skrivas.
- `fileName`: HTML‑filnamnet som genereras.
- `baseUri`: den absoluta URI‑prefixen som används i HTML‑länkarna till mediefiler.

Om HTML‑filen är `html-output/presentation.html` och mediefilerna sparas i `html-output/media`, bör `path` peka på mediakatalogen på disk, medan `baseUri` ska peka på samma katalog ur webbläsarens perspektiv. För lokal förhandsgranskning kan du bygga en `file:///`‑URI från mediakatalogen. För en distribuerad applikation, använd den absoluta URL‑en för den publicerade mediakatalogen.

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

Använd utdatamappar som är unika per exportjobb, särskilt i serverapplikationer. Delade utdatamappar kan leda till att filer från olika konverteringar skriver över varandra.

## **Prestanda och resurshantering**

HTML‑konvertering är en renderingsoperation, så bearbetningstid och minnesanvändning beror på bildantal, bildupplösning, teckensnitt, effekter, diagram och inbäddade media. Högre `PicturesCompression`‑DPI‑värden, inbäddade teckensnitt, SVG‑utmatning och bevarade beskärda bildområden kan förbättra troheten men ökar vanligtvis utskriftsstorleken.

För batch‑konvertering:

- Disporera varje [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans omedelbart.
- Använd separata utdatamappar för separata jobb.
- Undvik att bädda in vanliga teckensnitt om inte bildkvaliteten kräver det.
- Sänk bild‑DPI när HTML‑en är för förhandsgranskning eller miniatyrer.
- Behåll källpresentationen, genererad HTML och externa resurser tillsammans tills distributionssökvägarna är färdiga.

## **FAQ**

**Behålls hyperlänkar i HTML‑utdata?**

Ja. Hyperlänkar i presentationen exporteras till HTML och förblir klickbara när mål‑URL:en är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans mellan trådar. Processa olika filer med separata presentation‑instanser, separata strömmar och separata utdatamappar. Se [multithreading guidance](/slides/sv/androidjava/multithreading/) för detaljer.

**Är ett Presentation‑objekt trådsäkert?**

Nej. En enskild [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans bör laddas, modifieras, sparas och disponeras på en enda tråd. För parallellt arbete, skapa en oberoende instans per tråd eller process.

**Varför är den genererade HTML‑filen stor?**

Standardexporten kan bädda in resurser direkt i HTML. Inbäddade teckensnitt, hög‑DPI‑bilder, media, SVG‑innehåll och bevarade beskärda bildområden ökar också storleken. Använd externa resurser, exkludera vanliga teckensnitt från inbäddning och sänk `PicturesCompression` när en mindre fil är viktigare än maximal trohet.

**Varför visas en PowerPoint‑teckenstorlek som 24 pt som 17,999819 pt i HTML?**

Detta kan ske eftersom PowerPoint och HTML använder olika DPI‑modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserade på 72 DPI, medan HTML‑layout bygger på CSS‑pixlar i en 96 DPI‑modell. När Aspose.Slides exporterar en presentation till HTML översätts teckenstorleken mellan dessa system, och konverteringen kan introducera små avrundningsskillnader.

Dessa värden indikerar ingen verklig visuell teckenstorleksförändring. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur bör jag välja baseUri för media‑export?**

Välj `baseUri` utifrån webbläsarens perspektiv och skicka den som en absolut URI. För lokal förhandsgranskning kan du härleda den från utdatamappen med `mediaDirectory.toUri().toString()`. För distribution, använd den absoluta URL‑en för den publicerade mediakatalogen. Filsystemets `path` och webbläsarens `baseUri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `ShowHiddenSlides` till `true` på [HtmlOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/) när dolda bilder måste exporteras.