---
title: PowerPoint-prezentációk konvertálása HTML-re Java-ban
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/java/convert-powerpoint-to-html/
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
- PPT exportálása HTML-be
- PPTX exportálása HTML-be
- Java
- Aspose.Slides
description: "PowerPoint-prezentációk konvertálása HTML-re Java-ban. Használja az Aspose.Slides-t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Az Aspose.Slides for Java képes PowerPoint‑prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alapvető konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) betöltéséből és egy `save` hívásból áll a [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) használatával. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) beállítást, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG‑kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató a gyakorlati HTML‑export szcenáriókra összpontosít:

- Exportáljon egy egész prezentációt vagy kiválasztott diát.
- Generáljon rögzített elrendezésű, reszponzív vagy SVG‑alapú HTML‑t.
- Vegye bele az előadói jegyzeteket és megjegyzéseket.
- Szabályozza a képek minőségét és a levágott képadatokat.
- Ágyazza be a betűtípusokat, vagy mentse a betűtípus‑fájlokat külön.
- Válassza ki, hogyan kerülnek kiírásra és hivatkozásra a külső erőforrások és médiafájlok.

Alapértelmezés szerint a HTML‑export egy önmagában álló HTML‑dokumentumot hoz létre, ahol a legtöbb erőforrás beágyazott. Ez kényelmes egyetlen fájl megosztásához, de megnövelheti a kimeneti méretet. Webes közzététel esetén vegye fontolóra a külső erőforrások használatát, az alacsonyabb képdpi‑t, és csak azokat a betűtípusokat ágyazza be, amelyek nem érhetők el megbízhatóan a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

Egy prezentáció HTML‑re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektummal, és mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) segítségével.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ez a példa egy HTML‑fájlt ír. A prezentáció objektumot a `finally` blokkban szabadítják fel, amely az exportálás után bezárja a fájlkezelőket és a renderelési erőforrásokat.

## **HtmlOptions használata**

[HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) a fő konfigurációs osztály a HTML‑exporthoz. Gyakori beállítások a következők:

- `SlidesLayoutOptions`: jegyzeteket, megjegyzéseket, kézikönyveket vagy egyéb elrendezési információkat ad hozzá.
- `HtmlFormatter`: megváltoztatja a HTML‑dokumentum szerkezetét vagy a formázást egy vezérlőnek adja.
- `SlideImageFormat`: megváltoztatja a diák ábrázolásának módját, például SVG‑ként.
- `PicturesCompression`: szabályozza a kép DPI‑ját és a kimeneti méretet.
- `DeletePicturesCroppedAreas`: megtartja vagy eltávolítja a levágott képadatokat.
- `SvgResponsiveLayout`: a exportált SVG‑t a tartályához igazítja.
- `ShowHiddenSlides`: szükség esetén belefoglalja a rejtett diákat.

Az alábbi szakaszok külön mutatják be a leggyakoribb beállításokat, hogy csak a munkafolyamata számára szükségeseket kombinálhassa.

## **Kiválasztott diák konvertálása HTML‑re**

A `Presentation.save` túlterhelés, amely diaszámokat fogad, 1‑alapú dia pozíciókat használ. Az alábbi ciklus minden diát külön HTML‑fájlba ment.

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

Használja ezt a mintát, ha egy weboldalnak vagy alkalmazásnak diánként egy HTML‑oldalra van szüksége. Ha minden diának ugyanaz az elrendezésnek kell lennie, hozza létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) példányt, és adja át minden `save` hívásnak.

## **Reszponzív HTML létrehozása**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/responsivehtmlcontroller/) reszponzív HTML‑kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

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

SVG‑alapú reszponzív elrendezéshez állítsa be a `SvgResponsiveLayout` értéket a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) objektumon. Ez akkor hasznos, ha a dia tartalma skálázható SVG‑jelölésként kerül exportálásra.

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

## **Előadói jegyzetek és megjegyzések hozzáadása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/notescommentslayoutingoptions/) osztályt a `HtmlOptions.setSlidesLayoutOptions` segítségével, hogy előadói jegyzeteket vagy megjegyzéseket adjon hozzá. A jegyzetek és a megjegyzések alapértelmezés szerint rejtve vannak, hacsak nem adja meg a pozícióikat.

Tegyük fel, hogy a forrásprezentáció előadói jegyzeteket tartalmaz:

![Diák előadói jegyzetekkel a PowerPointban](slide_with_notes.png)

A következő kód a dia tartalmát exportálja a dia alatti előadói jegyzetekkel.

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

![HTML‑kimenet a diával és előadói jegyzetekkel](HTML_with_notes.png)

A megjegyzések exportálásához állítsa be a `CommentsPosition` értékét, például `CommentsPositions.Right` vagy `CommentsPositions.Bottom`. Ha csak a megjegyzéseket szeretné, hagyja ki a `NotesPosition` beállítást. Ha mind a jegyzeteket, mind a megjegyzéseket akarja, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek szabályozása**

A HTML‑export képes a dia képeket tömöríteni a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression` értékét a [PicturesCompression](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturescompression/) egyik értékére, ha nagyobb képminőségre van szükség.

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

Alapértelmezés szerint a képek levágott területei eltávolíthatók az exportált kimenetből. A levágott adatokat csak akkor tartsa meg, ha a felhasználóknak vissza kell tudni állítani vagy meg kell vizsgálni ezeket a rejtett képrészleteket. A megtartás növelheti a HTML méretét.

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

Egyszerű stílushoz adjon át egy CSS karakterláncot a `HtmlFormatter.createDocumentFormatter` metódusnak. Ez megváltoztatja a környező HTML‑dokumentumot, miközben az Aspose.Slides továbbra is rendereli a dia tartalmát.

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

Egy egyedi dokumentumfejléc, egy hivatkozott CSS‑fájl vagy egyedi jelölők a diák és alakzatok körül a [IHtmlFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihtmlformattingcontroller/) implementálásával, majd a [HtmlFormatter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmlformatter/) `createCustomFormatter` metódusával adható át.

## **Betűtípusok beágyazása**

Ha a célkörnyezet nem biztos, hogy a prezentáció betűtípusait telepítve tartja, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hűséget, de növeli a kimeneti méretet.

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

Zárja ki a betűtípusokat csak akkor, ha biztos benne, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűtípusok vagy ritkábban használt betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípus fájlok hivatkozása a beágyazás helyett**

A HTML‑fájl méretének csökkentése érdekében a betűtípus adatot külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Az alábbi segédprogram kiterjeszti a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/embedallfontshtmlcontroller/) osztályt és felülírja a `writeFont` metódust.

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

Ebben a példában a betűtípusfájlok a `html-output/fonts` könyvtárba mentődnek, és a HTML a `fonts/BrandFont-normal-400.woff` típusú URL‑ekkel hivatkozik rájuk. Ha a HTML‑fájlt és a betűtípusokat más helyre telepíti, válassza a `fontUrlPrefix` értékét úgy, hogy az egyezzen a telepített URL‑úttal.

## **Erőforrások külső mentése**

Az önmagában álló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagyméretűvé tehetik a fájlt. Ha az alkalmazásnak külső képfájlokra van szüksége, implementálja a [ILinkEmbedController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinkembedcontroller/) interfészt, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) konstruktorának.

Erőforrások külsővé tételekor tudatosan válasszon ki két útvonalat:

- A fájlrendszer kimeneti útvonala, ahová az alkalmazás a generált képeket, betűtípusokat, hangot vagy videót írja.
- Az URL‑útvonal, amelyet a böngésző a HTML‑dokumentumból a fájlok betöltéséhez használ.

## **Médiafájlok exportálása**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/videoplayerhtmlcontroller/) videó és hangfájlokat exportál, és olyan HTML‑t ír, amely a böngészőben le tudja játszani őket. Konstruktorához a következőket adja:

- `path`: a könyvtár, ahová a generált médiafájlok kerülnek.
- `fileName`: a generált HTML‑fájl neve.
- `baseUri`: a HTML‑linkekhez használt abszolút URI előtag a médiafájlokhoz.

Ha a HTML‑fájl a `html-output/presentation.html`, és a médiafájlok a `html-output/media` könyvtárban vannak, akkor a `path` a lemezen lévő média könyvtárra kell mutasson, míg a `baseUri` a böngésző szemszögéből ugyanarra a könyvtárra kell mutasson. Helyi előnézethez felépíthet egy `file:///` URI‑t a média könyvtárból. Egy telepített alkalmazáshoz használja a közzétett média könyvtár abszolút URL‑jét.

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

Használjon kimeneti könyvtárakat, amelyek exportálásonként egyediek, különösen szerveralkalmazásoknál. A megosztott kimeneti útvonalak miatt különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás‑kezelés**

A HTML‑konverzió egy renderelési művelet, ezért a feldolgozási idő és a memóriahasználat a dia számától, a kép felbontásától, a betűtípusoktól, a hatásoktól, a diagramoktól és a beágyazott médiától függ. A magasabb `PicturesCompression` DPI értékek, a beágyazott betűtípusok, az SVG‑kimenet és a megtartott levágott képrészletek javíthatják a hűséget, de általában növelik a kimeneti méretet.

Batch‑konverzió esetén:

- Azonnal szabadítsa fel minden [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt.
- Használjon külön kimeneti könyvtárakat a különálló feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, hacsak nem szükséges a hűséghez.
- Csökkentse a kép DPI‑ját, ha a HTML előnézet vagy bélyegkép céljára szolgál.
- Tartsa a forrásprezentációt, a generált HTML‑t és a külső erőforrásokat együtt, amíg a telepítési útvonalak véglegesek.

## **GYIK**

**Megmaradnak a hiperhivatkozások a HTML‑kimenetben?**

Igen. A prezentáció hiperhivatkozásai exportálva vannak HTML‑be, és kattinthatóak maradnak, ha a cél URL érvényes.

**Konvertálhatok prezentációkat párhuzamosan HTML‑re?**

Igen, de ne ossza meg egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt a szálak között. Különböző fájlokat külön prezentációs példányokkal, külön stream‑ekkel és külön kimeneti könyvtárakkal dolgozzon fel. A részletekért tekintse meg a [multithreading guidance](/slides/hu/java/multithreading/) útmutatót.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt egy szálon kell betölteni, módosítani, menteni és felszabadítani. Párhuzamos munkához hozzon létre egy független példányt szálanként vagy folyamatként.

**Miért nagy a generált HTML‑fájl?**

Az alapértelmezett export beágyazhatja az erőforrásokat közvetlenül a HTML‑be. A beágyazott betűtípusok, a nagy DPI‑ű képek, a média, az SVG‑tartalom és a megtartott levágott képrészletek is növelik a méretet. Használjon külső erőforrásokat, zárja ki a gyakori betűtípusok beágyazását, és csökkentse a `PicturesCompression` értéket, ha a kisebb kimenet fontosabb, mint a maximális hűség.

**Miért jelenik meg a PowerPoint betűméret, például 24 pt, 17.999819 pt‑ként a HTML‑ben?**

Ez előfordulhat, mert a PowerPoint és a HTML különböző DPI‑modelleket használ. A PowerPoint a szövegméreteket tipográfiai pontban tárolja, amely a 72 DPI‑n alapul, míg a HTML elrendezés a CSS‑pixeleken alapul egy 96 DPI‑s modellben. Amikor az Aspose.Slides egy prezentációt exportál HTML‑be, a betűméretet ezek között a rendszerek között konvertálja, és a konverzió kicsi kerekítési eltéréseket okozhat.

Ezek az értékek nem jelentenek valós vizuális betűméret‑változást. Csak a PowerPoint és a HTML közötti szövegmértékek átalakításának matematikai mellékhatásai.

**Hogyan válasszam ki a baseUri‑t a médiaexporthoz?**

Válassza a `baseUri` értékét a böngésző szemszögéből, és adja meg abszolút URI‑ként. Helyi előnézethez levezethető a kimeneti könyvtárból a `mediaDirectory.toUri().toString()` metódussal. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path` és a böngésző `baseUri` nem kell, hogy ugyanaz legyen, de ugyanazt a erőforrás helyet kell leírja.

**Bele lehet foglalni a rejtett diákat?**

Igen. Állítsa a `ShowHiddenSlides` értékét `true`‑ra a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) esetén, ha a rejtett diákat exportálni kell.