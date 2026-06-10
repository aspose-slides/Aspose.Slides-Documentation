---
title: PowerPoint prezentációk konvertálása HTML-re Androidon
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/androidjava/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint HTML-re
- prezentáció HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- PowerPoint mentése HTML-ként
- prezentáció mentése HTML-ként
- dia mentése HTML-ként
- PPT mentése HTML-ként
- PPTX mentése HTML-ként
- PPT exportálása HTML-re
- PPTX exportálása HTML-re
- Android
- Java
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása HTML-re Androidon. Használja az Aspose.Slides for Android via Java-t a PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes PowerPoint‑prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alapvető átalakítás egyetlen [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) betöltésből és egy `save` hívásból áll a [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) segítségével. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/)‑t, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, megjegyzéseket, kommentárokat, SVG‑kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató a gyakorlati HTML‑export szituációkra összpontosít:

- Exportáljon egy teljes prezentációt vagy kiválasztott diákot.
- Készítsen rögzített elrendezésű, reszponzív vagy SVG‑alapú HTML‑t.
- Tartalmazzon előadói jegyzeteket és kommentárokat.
- Szabályozza a képek minőségét és a levágott képadatokat.
- Beágyazza a betűkészleteket, vagy mentse a betűkészlet‑fájlokat külön.
- Válassza ki, hogyan kerülnek írásra és hivatkozásra a külső erőforrások és médiafájlok.

Alapértelmezés szerint a HTML‑export önálló HTML‑dokumentumot hoz létre, ahol a legtöbb erőforrás beágyazott. Ez praktikus egyetlen fájl megosztásához, de növelheti a kimenet méretét. Webes közzététel esetén fontolja meg a külső erőforrások használatát, az alacsonyabb képdPI‑t, és csak azoknak a betűkészleteknek a beágyazását, amelyek nem állnak megbízhatóan rendelkezésre a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

A prezentáció HTML‑re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) segítségével, és mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) használatával.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ez a példa egy HTML‑fájlt ír. A prezentáció objektumot a `finally` blokkban dispozálják, ezáltal az export után felszabadulnak a fájlkezelők és a renderelési erőforrások.

## **HtmlOptions használata**

A [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/) a HTML‑export fő konfigurációs osztálya. Gyakori beállítások:

- `SlidesLayoutOptions`: megjegyzéseket, kommentárokat, kézikönyveket vagy egyéb elrendezési információkat ad hozzá.
- `HtmlFormatter`: módosítja a HTML‑dokumentum struktúráját vagy egy vezérlőhöz delegálja a formázást.
- `SlideImageFormat`: megváltoztatja, hogyan jelennek meg a diák, például SVG‑ként.
- `PicturesCompression`: szabályozza a képek DPI‑ját és a kimeneti méretet.
- `DeletePicturesCroppedAreas`: megtartja vagy eltávolítja a levágott képadatokat.
- `SvgResponsiveLayout`: a kiexportált SVG‑tartalmat a tárolójához igazítja.
- `ShowHiddenSlides`: szükség esetén belefoglalja a rejtett diákat.

Az alábbi szakaszok a leggyakoribb opciókat mutatják be külön-külön, hogy csak a munkafolyamatához szükségeseket kombinálhassa.

## **Kiválasztott diák konvertálása HTML‑re**

A `Presentation.save` túlterhelés, amely diák számait fogadja, 1‑alindult diaposztíciókat használ. Az alábbi ciklus minden diát külön HTML‑fájlba ment.

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

Ezt a mintát használja, ha egy weboldal vagy alkalmazás minden diához egy HTML‑oldalt igényel. Ha minden diának azonos elrendezésre van szüksége, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/) példányt, és adja át minden `save` hívásnak.

## **Reszponzív HTML létrehozása**

A [ResponsiveHtmlController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/responsivehtmlcontroller/) reszponzív HTML‑kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

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

SVG‑alapú reszponzív elrendezéshez állítsa be a `SvgResponsiveLayout`‑ot a [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/)‑on. Ez akkor hasznos, ha a diatartalom skálázható SVG‑markupként kerül exportálásra.

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

## **Előadói jegyzetek és kommentárok belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑t a `HtmlOptions.SlidesLayoutOptions`‑on keresztül, hogy előadói jegyzeteket vagy kommentárokat vegyen fel. A jegyzetek és kommentárok alapértelmezés szerint rejtve vannak, hacsak nem választja meg a pozíciójukat.

Tegyük fel, hogy a forrás‑prezentáció tartalmaz előadói jegyzeteket:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Az alábbi kód a diatartalmat a jegyzetekkel együtt exportálja, a diák alatti területen.

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

Az exportált HTML tartalmazza a jegyzetek területét:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

A kommentárok exportálásához állítsa be a `CommentsPosition`‑t, például `CommentsPositions.Right` vagy `CommentsPositions.Bottom`. Ha csak kommentárokra van szükség, hagyja ki a `NotesPosition`‑t. Ha mindkettőre, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek szabályozása**

A HTML‑export képes a diaképeket tömöríteni a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression`‑t a [PicturesCompression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturescompression/) egyik értékére, ha magasabb képminőségre van szükség.

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

Alapértelmezés szerint a képek levágott területei eltávolíthatók az exportált kimenetből. Csak akkor tartsa meg a levágott adatokat, ha a felhasználóknak szükségük van a rejtett kép részleteinek visszaállítására vagy megtekintésére. Ennek megtartása növelheti a HTML méretét.

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

## **CSS hozzáadása**

Egyszerű stílusokhoz adjon egy CSS‑karakterláncot a `HtmlFormatter.createDocumentFormatter`‑nek. Ez módosítja a környező HTML‑dokumentumot, miközben az Aspose.Slides továbbra is rendereli a diatartalmat.

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

Egy egyedi dokumentumfejléc, egy linkelt CSS‑fájl vagy egyedi markup a diák és alakzatok körül érdekében valósítsa meg a [IHtmlFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihtmlformattingcontroller/)‑t, és adja át a [HtmlFormatter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmlformatter/)‑nek a `createCustomFormatter`‑rel.

## **Betűkészletek beágyazása**

Ha a célkörnyezet nem biztos, hogy a prezentáció betűkészleteit telepítve tartja, ágyazza be a betűkészleteket a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hitelességet, de növeli a kimenet méretét.

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

Csak akkor hagyja ki a betűkészleteket, ha biztos abban, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűk vagy kevésbé elterjedt betűk esetén a beágyazás általában biztonságosabb.

## **Betűkészlet‑fájlok hivatkozása beágyazás helyett**

A HTML‑fájl méretének csökkentése érdekében a betűkészlet adatokat külön WOFF‑fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Az alábbi segédprogram a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/embedallfontshtmlcontroller/)‑t bővíti, és felülírja a `writeFont`‑ot.

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

Ebben a példában a betűkészlet‑fájlok a `html-output/fonts` könyvtárba kerülnek, a HTML pedig olyan URL‑ekre hivatkozik, mint `fonts/BrandFont-normal-400.woff`. Ha a HTML‑fájl és a betűkészletek más helyre kerülnek telepítésre, állítsa be a `fontUrlPrefix`‑et úgy, hogy az a telepített URL‑útvonalnak megfelelő legyen.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagy fájlt eredményezhetnek. Ha alkalmazása külső képfájlokat igényel, valósítsa meg az [ILinkEmbedController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinkembedcontroller/)‑t, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/) konstruktorának.

Erőforrások külsővé tételekor két útvonalat kell tudatosan megadni:

- A fájlrendszer kimeneti útvonalát, ahová az alkalmazás a generált képeket, betűkészleteket, hang- vagy videofájlokat írja.
- Az URL‑útvonalat, amelyet a böngésző a HTML‑dokumentumból használ a fájlok betöltéséhez.

## **Médiafájlok exportálása**

A [VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) videó‑ és hangfájlokat exportál, és olyan HTML‑t ír, amely a böngészőben lejátszható. Konstruktorja a következőket veszi:

- `path`: a könyvtár, ahová a generált médiafájlok kerülnek.
- `fileName`: a generálásra kerülő HTML‑fájl neve.
- `baseUri`: az abszolút URI‑előtag, amelyet a HTML‑hivatkozások a médiafájlokhoz használnak.

Ha a HTML‑fájl `html-output/presentation.html`, a médiafájlok pedig `html-output/media` könyvtárban vannak, akkor a `path`‑nak a média könyvtárra kell mutatnia a lemezen, míg a `baseUri`‑nak a böngésző nézőpontjából ugyanarra a könyvtárra kell mutatnia. Helyi előnézethez építhet `file:///` URI‑t a média könyvtárból. Telepített alkalmazásban használja a közzétett média könyvtár abszolút URL‑jét.

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

Használjon kimeneti könyvtárakat, amelyek egyediek az egyes exportálási feladatokhoz, különösen szerveralkalmazásoknál. A megosztott kimeneti útvonalak miatt a különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás‑kezelés**

A HTML‑konverzió renderelési művelet, így a feldolgozási idő és a memóriahasználat a dia számától, a képfelbontástól, a betűkészletektől, hatásoktól, diagramoktól és a beágyazott médiától függ. A magasabb `PicturesCompression` DPI‑értékek, a beágyazott betűkészletek, az SVG‑kimenet és a megtartott levágott képrészletek javíthatják a hűséget, de általában növelik a kimenet méretét.

Kötegelt konverzió esetén:

- Minden [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt gyorsan disposáljon.
- Használjon külön kimeneti könyvtárakat a külön munkákhoz.
- Kerülje a gyakori betűkészletek beágyazását, hacsak a hűség megköveteli.
- Csökkentse a képek DPI‑ját, ha a HTML csak előnézet vagy bélyegkép céljából készült.
- Tartsa együtt a forrás‑prezentációt, a generált HTML‑t és a külső erőforrásokat, amíg a telepítési útvonalak véglegesek nem lesznek.

## **GYIK**

**Megmaradnak a hiperhivatkozások a HTML‑kimenetben?**

Igen. A prezentáció hiperhivatkozásai exportálva lesznek HTML‑re, és kattinthatóak maradnak, ha a cél‑URL érvényes.

**Lehet párhuzamosan konvertálni a prezentációkat HTML‑re?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt szálak között. Különböző fájlokhoz használjon külön prezentáció‑példányokat, külön stream‑eket és külön kimeneti könyvtárakat. Lásd a [multithreading guidance](/slides/hu/androidjava/multithreading/) részleteket.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt csak egy szálon szabad betölteni, módosítani, menteni és dispozálni. Párhuzamos munka esetén hozzon létre független példányt szálanként vagy folyamatosan.

**Miért nagy a generált HTML‑fájl?**

Az alapértelmezett export beágyazhat erőforrásokat közvetlenül a HTML‑be. A beágyazott betűkészletek, nagy‑DPI‑képek, média, SVG‑tartalom és a megtartott levágott képrészletek is növelik a méretet. Használjon külső erőforrásokat, hagyja ki a gyakori betűkészletek beágyazását, és csökkentse a `PicturesCompression`‑t, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért jelenik meg egy PowerPoint 24 pt betűméret 17,999819 pt‑ként HTML‑ben?**

Ez azért fordulhat elő, mert a PowerPoint és a HTML külön DPI‑modelleket használ. A PowerPoint a tipográfiai pontokat 72 DPI‑ alapján tárolja, míg a HTML elrendezés a CSS‑pixeleket 96 DPI‑ modellben használja. Amikor az Aspose.Slides egy prezentációt HTML‑re exportál, a betűméret átalakul ezek között a rendszerek között, és a konverzió kis kerekítési eltéréseket eredményezhet.

Ezek az értékek nem jelentenek valós vizuális betűméret‑változást. Csak a szövegmértékek konvertálása közbeni matematikai mellékhatásról van szó.

**Hogyan válasszam ki a baseUri‑t a média exportálásához?**

A `baseUri`‑t a böngésző szemszögéből válassza ki, és adja meg abszolút URI‑ként. Helyi előnézetnél származtathatja a kimeneti könyvtárból a `mediaDirectory.toUri().toString()`‑mal. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path`‑nak és a böngésző `baseUri`‑nak nem kell ugyanaz a karakterlánc, de ugyanarra a erőforrás‑helyre kell mutatniuk.

**Bele lehet foglalni a rejtett diákat?**

Igen. Állítsa a `ShowHiddenSlides`‑t `true`‑ra a [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/)‑on, ha a rejtett diákat is exportálni kell.