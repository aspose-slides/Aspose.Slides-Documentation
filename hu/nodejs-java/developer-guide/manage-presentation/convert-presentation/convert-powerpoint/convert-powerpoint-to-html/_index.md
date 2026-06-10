---
title: PowerPoint prezentációk konvertálása HTML-re Node.js-ben
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint prezentációkat konvertál HTML-re Node.js-ben. Használja az Aspose.Slides for Node.js via Java-t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes PowerPoint‑prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alapvető konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) betöltése és egy `save` hívás a [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) segítségével. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) osztályt, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató gyakorlati HTML‑export szcenáriókra fókuszál:

- Teljes prezentáció vagy kiválasztott diák exportálása.
- Fix‑elrendezésű, responszív vagy SVG‑alapú HTML generálása.
- Előadói jegyzetek és megjegyzések belefoglalása.
- Képek minőségének és a levágott képadatok szabályozása.
- Betűtípusok beágyazása vagy betűtípus‑fájlok külön mentése.
- Az externális erőforrások és médiafájlok írási és hivatkozási módjának kiválasztása.

Alapértelmezés szerint az HTML export egy önálló HTML‑dokumentumot hoz létre, ahol a legtöbb erőforrás be van ágyazva. Ez kényelmes egyetlen fájl megosztásához, de növelheti a kimenet méretét. Webes közzététel esetén vegye fontolóra az externális erőforrásokat, alacsonyabb DPI‑t képekhez, és csak azoknak a betűtípusoknak a beágyazását, amelyek nem biztosan állnak rendelkezésre a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

Egy prezentáció HTML‑re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, majd mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) használatával.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Ez a példakód egy HTML fájlt ír. A prezentáció objektum a `finally` blokkban kerül felszabadításra, amely a fájlkezelőket és renderelési erőforrásokat az export után felszabadítja.

## **HtmlOptions használata**

A [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) a fő konfigurációs osztály az HTML exporthoz. Gyakori beállítások:

- `SlidesLayoutOptions`: jegyzetek, megjegyzések, füzetek vagy egyéb elrendezési információk hozzáadása.
- `HtmlFormatter`: az HTML dokumentum struktúrájának módosítása vagy a formázás delegálása egy vezérlőnek.
- `SlideImageFormat`: a diák ábrázolásának módosítása, például SVG‑ként.
- `PicturesCompression`: képek DPI‑jának és kimeneti méretének szabályozása.
- `DeletePicturesCroppedAreas`: a levágott képadatok megtartása vagy eltávolítása.
- `SvgResponsiveLayout`: az exportált SVG tartalom alkalmazkodik a tárolóhoz.
- `ShowHiddenSlides`: rejtett diák belefoglalása, ha szükséges.

Az alábbi szakaszok a leggyakoribb beállításokat mutatják külön-külön, hogy csak a munkafolyamatához szükséges opciókat kombinálhassa.

## **Kiválasztott diák konvertálása HTML‑re**

A `Presentation.save` túlterhelés, amely diák számát fogadja, 1‑től induló diaközök szerint működik. Az alábbi ciklus minden diát külön HTML fájlba ment.

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

Ezt a mintát használja, ha egy weboldal vagy alkalmazás minden diához egy HTML oldalt igényel. Ha minden diának ugyanaz az elrendezése, hozza létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) példányt, és adja át minden `save` hívásnak.

## **Responszív HTML létrehozása**

A [ResponsiveHtmlController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/responsivehtmlcontroller/) responszív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmlformatter/) segítségével. Használja, ha az exportált oldal jobban kell, hogy alkalmazkodjon a böngésző szélességéhez.

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

SVG‑alapú responszív elrendezéshez állítsa be a `SvgResponsiveLayout` értéket a [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) objektumban. Ez akkor hasznos, amikor a diák tartalma skálázható SVG‑ként kerül exportálásra.

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

## **Előadói jegyzetek és megjegyzések belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notescommentslayoutingoptions/) osztályt a `HtmlOptions.setSlidesLayoutOptions` metóduson keresztül, hogy előadói jegyzeteket vagy megjegyzéseket vegyen fel. A jegyzetek és megjegyzések alapértelmezésben rejtve vannak, hacsak nem adja meg azok pozícióját.

Tegyük fel, hogy a forrás‑prezentáció tartalmaz előadói jegyzeteket:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Az alábbi kód a diát a jegyzetekkel együtt, a dia alatti részben exportálja.

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

Az exportált HTML tartalmazza a jegyzetterületet:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Megjegyzések exportálásához állítsa be a `CommentsPosition` értékét, például `CommentsPositions.Right` vagy `CommentsPositions.Bottom`. Ha csak megjegyzéseket szeretne, hagyja el a `NotesPosition` beállítást. Ha mindkettőt akarja, állítsa be mindkét tulajdonságot.

## **Képek minőségének és levágott területek szabályozása**

Az HTML export képes összenyomni a diákképeket a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression` értékét a [PicturesCompression](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturescompression/) enumerációból, ha magasabb képminőségre van szüksége.

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

Alapértelmezésben a képek levágott területei eltávolításra kerülhetnek az exportált kimenetből. Tartsa meg a levágott adatokat csak akkor, ha a felhasználóknak képesnek kell lenniük visszaállítani vagy megvizsgálni ezeket a rejtett kép részeket. A megtartás növelheti a HTML méretét.

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

## **CSS hozzáadása**

Egyszerű stílusoláshoz adjon át egy CSS karakterláncot a `HtmlFormatter.createDocumentFormatter` metódusnak. Ez módosítja a környező HTML dokumentumot, miközben az Aspose.Slides továbbra is a dia tartalmát rendereli.

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

Egy egyedi dokumentumfejléc, egy hivatkozott CSS fájl vagy egyedi markup a diák és alakzatok körül a [HtmlFormatter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmlformatter/) használatával, egy formázó vezérlővel valósítható meg.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nem biztos, hogy a prezentáció betűtípusai telepítve vannak, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hűséget, de növeli a kimenet méretét.

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

Csak akkor hagyja ki a betűtípusokat, ha biztos abban, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűtípusok vagy kevésbé elterjedt betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípus‑fájlok hivatkozása beágyazás helyett**

A HTML fájlméret csökkentése érdekében a betűtípus‑adatokat külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Node.js via Java esetén ezt a szcenáriót általában egy kis Java segédosztállyal valósítják meg, amely kiterjeszti a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) osztályt, a betűtípus‑bájtokat egy kimeneti könyvtárba írja, és `@font-face` szabályokat injektál a generált HTML‑be. Fordítsa le a segédosztályt, adja hozzá a Node.js modul osztályútvonalához, majd példányosítsa JavaScriptből a `java.newInstanceSync` segítségével.

Segédosztály építésekor szándékosan válasszon ki két útvonalat:

- A fájlrendszer kimeneti útvonala, ahol a generált betűtípus‑fájlok kerülnek mentésre.
- Az URL‑útvonal, amelyet a böngésző a HTML dokumentumból használ a betűtípus‑fájlok betöltéséhez.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagyra növelhetik a fájlt. Ha az alkalmazásnak külső képek, betűtípusok, hang‑ vagy videofájlok szükségesek, használjon egy export‑vezérlőt, amely az erőforrásokat egy kiválasztott könyvtárba írja, és a böngésző által látható URL‑eket adja ki. Tartsa a fájlrendszer‑útvonalat és az URL‑útvonalat összhangban a telepítési struktúrával.

## **Médiafájlok exportálása**

A [VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) videó‑ és hangfájlokat exportál, és olyan HTML‑t generál, amely a böngészőben le tudja játszani őket. Konstruktorja a következő paramétereket várja:

- `path`: a könyvtár, ahova a generált médiafájlok kerülnek mentésre.
- `fileName`: a generálandó HTML fájl neve.
- `baseUri`: az abszolút URI előtag, amely a HTML hivatkozásokban a médiafájlokra mutat.

Ha a HTML fájl `html-output/presentation.html`, a médiafájlok pedig a `html-output/media` könyvtárban vannak, a `path`‑nek a lemezen lévő média könyvtárra, a `baseUri`‑nek pedig a böngésző nézőpontjából ugyanarra a könyvtárra kell mutatnia. Helyi előnézethez építhet `file:///` URI‑t a média könyvtárból. Telepített alkalmazáshoz használja a publikált média könyvtár abszolút URL‑jét.

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

Használjon olyan kimeneti könyvtárakat, amelyek egyértelműen egy export feladathoz tartoznak, különösen szerveralkalmazásoknál. Közös kimeneti útvonalak esetén a különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás‑kezelés**

Az HTML konverzió egy renderelési művelet, ezért a feldolgozási idő és memóriahasználat a diákszám, a képek felbontása, a betűtípusok, effektusok, diagramok és beágyazott média függvénye. Magasabb `PicturesCompression` DPI értékek, beágyazott betűtípusok, SVG kimenet és a megtartott levágott képadatok javíthatják a hűséget, de jellemzően növelik a kimenet méretét.

Kötegelt konverzió esetén:

- Szabadítsa fel gyorsan minden [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt.
- Használjon külön kimeneti könyvtárakat a külön feladatokhoz.
- Kerülje a gyakran használt betűtípusok beágyazását, hacsak a hűség megköveteli.
- Alacsonyabb DPI‑t állítson be, ha a HTML előnézethez vagy bélyegképekhez készült.
- Tartsa együtt a forrás‑prezentációt, a generált HTML‑t és az externális erőforrásokat, amíg a telepítési útvonalak véglegesek.

## **GYIK**

**Megmaradnak a hiperhivatkozások a HTML‑kimenetben?**

Igen. A prezentáció hiperhivatkozásai exportálásra kerülnek HTML‑be, és kattinthatóak maradnak, amíg a cél‑URL érvényes.

**Konvertálhatok prezentációkat HTML‑re párhuzamosan?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt a munkavégzők között. Külön fájlokat dolgozzon fel külön prezentáció‑példányokkal, külön adatfolyamokkal és külön kimeneti könyvtárakkal. Lásd a [multithreading guidance](/slides/hu/nodejs-java/multithreading/) részleteket.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt csak egy munkavégzőn belül szabad betölteni, módosítani, menteni és felszabadítani. Párhuzamos munkához hozzon létre független példányt minden munkavégző vagy folyamat számára.

**Miért nagy a generált HTML fájl?**

Az alapértelmezett export beágyazhat erőforrásokat közvetlenül a HTML‑be. A beágyazott betűtípusok, magas DPI‑jú képek, média, SVG tartalom és a megtartott levágott képadatok is növelik a méretet. Használjon externális erőforrásokat, hagyja ki a gyakori betűtípusok beágyazását, és csökkentse a `PicturesCompression` értékét, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért jelenik meg egy PowerPoint‑betűméret, például 24 pt, HTML‑ben 17,999819 pt‑ként?**

Ez azért fordulhat elő, mert a PowerPoint és a HTML külön DPI‑modelleket használ. A PowerPoint a szövegméreteket tipográfiai pontban (72 DPI) tárolja, míg a HTML elrendezés CSS‑pixelen (96 DPI) alapul. Amikor az Aspose.Slides egy prezentációt HTML‑re exportál, a betűméret átalakul ezek között a rendszerek között, és a konverzió kis kerekítési eltéréseket okozhat.

Ezek az értékek nem jeleznek valódi vizuális betűméret‑változást. Csak a szövegmetrikák PowerPoint és HTML közötti átalakításának matematikai mellékhatásai.

**Hogyan válasszam ki a baseUri‑t a média exporthoz?**

Válasszon `baseUri`‑t a böngésző nézőpontjából, és adja meg abszolút URI‑ként. Helyi előnézethez levezethető az kimeneti könyvtárból egy `file:///` URI. Telepítéskor használja a publikált média könyvtár abszolút URL‑jét. A fájlrendszer‑`path` és a böngésző‑`baseUri` nem kell, hogy ugyanaz a karakterlánc legyen, de ugyanarra a erőforrás‑helyre kell mutatniuk.

**Bele lehet foglalni a rejtett diákot?**

Igen. Állítsa a `ShowHiddenSlides` értékét `true`‑ra a [HtmlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/htmloptions/) esetén, ha a rejtett diák exportálása szükséges.