---
title: PowerPoint prezentációk HTML‑re konvertálása PHP‑ben
linktitle: PowerPoint HTML‑re
type: docs
weight: 30
url: /hu/php-java/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint HTML‑re
- prezentáció HTML‑re
- dia HTML‑re
- PPT HTML‑re
- PPTX HTML‑re
- PowerPoint mentése HTML‑ként
- prezentáció mentése HTML‑ként
- dia mentése HTML‑ként
- PPT mentése HTML‑ként
- PPTX mentése HTML‑ként
- PPT exportálása HTML‑re
- PPTX exportálása HTML‑re
- PHP
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása HTML‑re PHP‑ben. Az Aspose.Slides segítségével exportálhatja a PPT és PPTX fájlokat, kiválasztott diákat, jegyzeteket, betűtípusokat, képeket, SVG‑t és médiát."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes PowerPoint prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alap konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) betöltése és egy `save` hívás a [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) használatával. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) lehetőséget, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató a gyakorlati HTML export szcenáriókra összpontosít:

- Exportálja az egész prezentációt vagy a kiválasztott diákat.
- Állandó elrendezésű, reszponzív vagy SVG‑alapú HTML generálása.
- Előadói jegyzetek és megjegyzések belefoglalása.
- Képek minőségének és a levágott képadatok szabályozása.
- Betűtípusok beágyazása vagy a betűtípus fájlok külön mentése.
- Válassza ki, hogyan kerülnek kiírásra és hivatkozásra a külső erőforrások és médiafájlok.

Alapértelmezés szerint a HTML export egy önálló HTML dokumentumot hoz létre, ahol a legtöbb erőforrás be van ágyazva. Ez kényelmes egyetlen fájl megosztásához, de növelheti a kimeneti méretet. Webes közzététel esetén fontolja meg a külső erőforrások használatát, az alacsonyabb képpontszámú (DPI) képeket, és csak azoknak a betűtípusoknak a beágyazását, amelyek nem állnak megbízhatóan rendelkezésre a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

A prezentáció HTML‑be exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) segítségével, és mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) használatával.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

Ez a példa egy HTML fájlt ír. A prezentáció objektum a `finally` blokkban kerül eldobásra, amely az export után felszabadítja a fájlkezelőket és a renderelő erőforrásokat.

## **HtmlOptions használata**

A [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) a fő konfigurációs osztály a HTML exporthoz. Gyakori beállítások a következők:

- `SlidesLayoutOptions`: jegyzeteket, megjegyzéseket, kézibontásokat vagy egyéb elrendezési információkat ad hozzá.
- `HtmlFormatter`: megváltoztatja a HTML dokumentum szerkezetét vagy a formázást egy vezérlőnek adja át.
- `SlideImageFormat`: megváltoztatja a diák ábrázolás módját, például SVG‑ként.
- `PicturesCompression`: szabályozza a képek DPI‑jét és a kimeneti méretet.
- `DeletePicturesCroppedAreas`: megtartja vagy eltávolítja a levágott képadatokat.
- `SvgResponsiveLayout`: a exportált SVG tartalmat a konténeréhez igazítja.
- `ShowHiddenSlides`: szükség esetén a rejtett diák beillesztése.

A következő szakaszok külön-külön bemutatják a leggyakoribb beállításokat, így csak a munkafolyamatához szükségeseket kombinálhatja.

## **Kijelölt diák konvertálása HTML‑re**

A diák számát fogadó `save` túlterhelés 1‑től induló diapozíciókat használ. Az alábbi ciklus minden diát külön HTML fájlba ment.

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

Használja ezt a mintát, ha egy webhelynek vagy alkalmazásnak minden diára egy HTML oldalt kell biztosítania. Ha minden diának ugyanazt az elrendezést kell használnia, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) példányt, és adja át minden `save` híváshoz.

## **Reszponzív HTML létrehozása**

A [ResponsiveHtmlController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/responsivehtmlcontroller/) reszponzív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

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

SVG‑alapú reszponzív elrendezéshez állítsa be a `SvgResponsiveLayout` értéket a [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) esetén. Ez akkor hasznos, ha a dia tartalma skálázható SVG jelölésként exportálódik.

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

## **Előadói jegyzetek és megjegyzések belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) lehetőséget a `HtmlOptions.SlidesLayoutOptions`‑on keresztül az előadói jegyzetek vagy megjegyzések belefoglalásához. A jegyzetek és megjegyzések alapértelmezés szerint rejtve vannak, hacsak nem adja meg a pozíciójukat.

Feltételezve, hogy a forrás prezentáció előadói jegyzeteket tartalmaz:

![Dia előadói jegyzetekkel a PowerPointban](slide_with_notes.png)

Az alábbi kód a dia tartalmát az előadói jegyzetekkel a dia alá exportálja.

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

Az exportált HTML tartalmazza a jegyzetek területét:

![HTML kimenet a diával és előadói jegyzetekkel](HTML_with_notes.png)

A megjegyzések exportálásához állítsa be a `CommentsPosition` értékét, például `CommentsPositions.Right` vagy `CommentsPositions.Bottom`. Ha csak megjegyzéseket szeretne, hagyja el a `NotesPosition` beállítást. Ha mind a jegyzetek, mind a megjegyzések szükségesek, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek szabályozása**

A HTML export képes tömöríteni a diaképeket a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression` értékét a [PicturesCompression](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturescompression/) egyik értékére, ha nagyobb képminőségre van szükség.

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

Alapértelmezés szerint a képek levágott területei eltávolításra kerülhetnek az exportált kimenetből. A levágott adatokat csak akkor tartsa meg, ha a felhasználóknak vissza kell tudni állítani vagy megvizsgálni ezeket a rejtett képrészeket. A megtartás növelheti a HTML méretét.

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

## **CSS hozzáadása**

Egyszerű stílusoláshoz adjon át egy CSS karakterláncot a [HtmlFormatter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmlformatter/) segítségével a `createDocumentFormatter`‑en keresztül. Ez módosítja a környező HTML dokumentumot, míg az Aspose.Slides továbbra is rendereli a dia tartalmát.

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

Egyedi dokumentumfejléc, kapcsolt CSS fájl vagy egyedi jelölés a diák és alakzatok körül esetén használjon egy egyedi formázó vezérlőt, és adja át a [HtmlFormatter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmlformatter/) `createCustomFormatter` metódusával.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nem biztos, hogy a prezentáció betűtípusai telepítve vannak, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/embedallfontshtmlcontroller/) használatával. A beágyazás javítja a vizuális hitelességet, de növeli a kimeneti méretet.

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

A betűtípusok kizárása csak akkor javasolt, ha meggyőződött arról, hogy a célböngészők vagy -rendszerek már rendelkeznek velük. Márka‑ vagy ritkábban használt betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípus fájlok hivatkozása beágyazás helyett**

A HTML fájlméret csökkentéséhez a betűtípus adatokat külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. PHP‑on keresztül Java‑ban ez a szituáció általában egy kis Java segédosztállyal valósítható meg, amely kiterjeszti a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/embedallfontshtmlcontroller/), a betűtípus bájtjait egy kimeneti könyvtárba írja, és `@font-face` szabályokat injektál az előállított HTML‑be. Fordítsa le ezt a segédet, adja hozzá a PHP Java Bridge osztályútvonalához, majd hozza létre PHP‑ból a `new Java(...)` segítségével.

Ha ilyen segédet épít, tudatosan válasszon két útvonalat:

- A fájlrendszer kimeneti útvonala, ahol a generált betűtípus fájlok kerülnek írásra.
- Az URL útvonal, amelyet a böngésző a HTML dokumentumból használ a betűtípus fájlok betöltéséhez.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagy fájlt eredményezhetnek. Ha az alkalmazásnak külső képfájlokra van szüksége, adjon meg egy egyedi link/beágyazó vezérlőt a [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) konstruktorában.

Ha az erőforrásokat elkülöníti, tudatosan válasszon két útvonalat:

- A fájlrendszer kimeneti útvonala, ahol az alkalmazás generált képeket, betűtípusokat, hang‑ vagy videofájlokat ír.
- Az URL útvonal, amelyet a böngésző a HTML dokumentumból használ a fájlok betöltéséhez.

Tartsa ezeket az útvonalakat összhangban a telepítési elrendezésével, hogy a generált HTML a külső erőforrásokat betölthesse, miután egy webkiszolgálóra vagy egy másik könyvtárba került.

## **Médiafájlok exportálása**

A [VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoplayerhtmlcontroller/) videó- és hangfájlokat exportál, és olyan HTML‑t ír, amely a böngészőben le tudja játszani őket. A konstruktorja a következőket veszi be:

- `path`: a generált HTML és médiafájlok által használt kimeneti könyvtár.
- `fileName`: a generált HTML fájl neve.
- `baseUri`: a médiafájlokra mutató HTML hivatkozásokban használt abszolút URI előtag.

Ha a HTML fájl `html-output/presentation.html`, akkor a `path` a `html-output` könyvtárra mutasson, a `baseUri` pedig a böngésző nézőpontjából ugyanarra a könyvtárra mutasson. Helyi előnézethez egy `file:///` URI‑t építhet a kimeneti könyvtárból. Telepített alkalmazás esetén használja a közzétett kimeneti könyvtár abszolút URL‑jét.

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

Használjon kimeneti könyvtárakat, amelyek az egyes export feladatokhoz egyediek, különösen szerveralkalmazásoknál. A megosztott kimeneti útvonalak miatt a különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás‑kezelés**

A HTML konverzió egy renderelési művelet, így a feldolgozási idő és a memóriahasználat a diák számától, a képfelbontástól, a betűtípusoktól, hatásoktól, diagramoktól és a beágyazott médiától függ. A magasabb `PicturesCompression` DPI értékek, a beágyazott betűtípusok, az SVG kimenet és a megtartott levágott képrészek javíthatják a hűséget, de általában növelik a kimeneti méretet.

Kötegelt konverzió esetén:

- Azonnal dobja el minden [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt.
- Használjon külön kimeneti könyvtárakat a külön feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, hacsak a hűség nem követeli.
- Csökkentse a képek DPI‑jét, ha a HTML előnézethez vagy bélyegképekhez készült.
- Tartsa a forrás prezentációt, a generált HTML‑t és a külső erőforrásokat együtt, amíg a telepítési útvonalak véglegesek nem lesznek.

## **FAQ**

**Megtartja a hiperláncok a HTML kimenetben?**

Igen. A prezentáció hiperláncai exportálásra kerülnek HTML‑be, és kattinthatóak maradnak, ha a cél‑URL érvényes.

**Konvertálhatok prezentációkat párhuzamosan HTML‑re?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt szálak között. Különböző fájlokat külön prezentációs példányokkal, külön adatfolyamokkal és külön kimeneti könyvtárakkal dolgozzon fel.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt egy szálon kell betölteni, módosítani, menteni és eldobni. Párhuzamos munka esetén hozzon létre egy független példányt szálanként vagy folyamatanként.

**Miért nagy a generált HTML fájl?**

Az alapértelmezett export erőforrásokat közvetlenül a HTML‑be ágyazhat. A beágyazott betűtípusok, nagy DPI‑jú képek, média, SVG tartalom és a megtartott levágott képrészek szintén megnövelik a méretet. Használjon külső erőforrásokat, hagyja ki a gyakori betűtípusok beágyazását, és csökkentse a `PicturesCompression` értéket, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért jelenik meg a PowerPoint 24 pt betűmérete 17,999819 pt‑ként a HTML‑ben?**

Ez előfordulhat, mivel a PowerPoint és a HTML különböző DPI‑modelleket használ. A PowerPoint a szövegméreteket 72 DPI‑en alapuló tipográfiai pontokban tárolja, míg a HTML elrendezés a CSS pixeleken alapul egy 96 DPI‑es modellben. Amikor az Aspose.Slides egy prezentációt HTML‑re exportál, a betűméret ezen rendszerek között kerül átalakításra, és a konverzió kis kerekítési eltéréseket eredményezhet.

Ezek az értékek nem jelzik a valódi vizuális betűméret‑változást. Csak a PowerPoint és a HTML közötti szövegmérők konvertálásának matematikai mellékhatása.

**Hogyan válasszam ki a baseUri értéket a média exportálásához?**

Válassza a `baseUri`‑t a böngésző nézőpontjából, és adja meg abszolút URI‑ként. Helyi előnézethez a kimeneti könyvtárból származtathatja egy Java fájl‑URI‑val. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path` és a böngésző `baseUri` nem kell, hogy ugyanaz a karakterlánc legyen, de ugyanazt a erőforrás‑helyet kell leírniuk.

**Belefoglalhatom a rejtett diákat?**

Igen. Állítsa a `ShowHiddenSlides` értékét `true`‑ra a [HtmlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/htmloptions/) esetén, ha a rejtett diákat is exportálni kell.