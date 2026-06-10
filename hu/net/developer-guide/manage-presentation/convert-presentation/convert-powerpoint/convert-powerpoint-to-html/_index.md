---
title: PowerPoint prezentációk konvertálása HTML-re .NET-ben
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint prezentációk konvertálása HTML-re .NET-ben. Használja az Aspose.Slides‑t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Aspose.Slides for .NET képes PowerPoint prezentációkat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alapvető konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) betöltése és egy [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) hívás a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) használatával. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) osztályt, ha szabályozni szeretné a exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG kimenetet vagy a hivatkozott erőforrásokat.

Ez az útmutató gyakorlati HTML export szcenáriókra összpontosít:

- Teljes prezentáció vagy kiválasztott diák exportálása.
- Rögzített elrendezésű, reszponzív vagy SVG‑alapú HTML generálása.
- Előadói jegyzetek és megjegyzések belefoglalása.
- Képminőség és levágott képrészlet adatainak vezérlése.
- Betűtípusok beágyazása vagy külön fájlokként mentése.
- Kiválasztása, hogy a külső erőforrások és médiafájlok hogyan legyenek írva és hivatkozva.

Alapértelmezés szerint a HTML export önálló HTML dokumentumot hoz létre, amelyben a legtöbb erőforrás beágyazott. Ez kényelmes egyetlen fájl megosztásához, de növelheti a kimenet méretét. Webes közzétételhez fontolja meg a külső erőforrások használatát, az alacsonyabb kép DPI‑t, és csak azoknak a betűtípusoknak a beágyazását, amelyek nem biztos, hogy elérhetők a célkörnyezetben.

## **Prezentáció konvertálása HTML‑re**

Egy prezentáció HTML‑re exportálásához töltse be a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal, és mentse a [SaveFormat.Html](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) használatával.

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Ez a példa egy HTML fájlt ír. A prezentáció objektumot a `using` deklaráció gondoskodik a felszabadításról, amely az exportálás után felszabadítja a fájlkezelőket és a renderelési erőforrásokat.

## **HtmlOptions használata**

A [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) a fő konfigurációs osztály a HTML exporthoz. A gyakori beállítások:

- `SlidesLayoutOptions`: jegyzetek, megjegyzések, előadáslapok vagy egyéb elrendezési információk hozzáadása.
- `HtmlFormatter`: a HTML dokumentum struktúrájának módosítása vagy formázás delegálása egy vezérlőnek.
- `SlideImageFormat`: meghatározza, hogyan jelennek meg a diák, például SVG‑ként.
- `PicturesCompression`: szabályozza a kép DPI‑t és a kimeneti méretet.
- `DeletePicturesCroppedAreas`: megtartja vagy eltávolítja a levágott képrészlet adatokat.
- `SvgResponsiveLayout`: a exportált SVG tartalom alkalmazkodik a tárolóhoz.
- `ShowHiddenSlides`: szükség esetén a rejtett diák belefoglalása.

Az alábbi szekciók a leggyakoribb beállításokat mutatják külön, hogy csak a munkafolyamatához szükségeseket kombinálhassa.

## **Kiválasztott diák konvertálása HTML‑re**

A [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) olyan túlterhelése, amely diák számát fogadja, 1‑től induló diapozíciókat használ. Az alábbi ciklus minden diát külön HTML fájlba ment.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Használja ezt a mintát, ha egy weboldal vagy alkalmazás egy HTML oldalt igényel diánként. Ha minden diához ugyanaz az elrendezés szükséges, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) példányt, és adja át minden `Save` hívásnak.

## **Reszponzív HTML létrehozása**

A [ResponsiveHtmlController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/responsivehtmlcontroller/) reszponzív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

SVG‑alapú reszponzív elrendezéshez állítsa be a `SvgResponsiveLayout` értéket a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) objektumban. Ez akkor hasznos, ha a dia tartalma méretezhető SVG jelölőnyelvként kerül exportálásra.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Előadói jegyzetek és megjegyzések belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztályt a `HtmlOptions.SlidesLayoutOptions`‑on keresztül, hogy előadói jegyzeteket vagy megjegyzéseket vegyen fel. A jegyzetek és megjegyzések alapértelmezés szerint rejtve vannak, hacsak nem határozza meg a pozíciójukat.

Tegyük fel, hogy a forrásprezentáció előadói jegyzeteket tartalmaz:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Az alábbi kód a dia tartalmát a dia alatti előadói jegyzetekkel exportálja.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Az exportált HTML tartalmazza a jegyzetek területét:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

A megjegyzések exportálásához állítsa be a `CommentsPosition` értékét, például `CommentsPositions.Right` vagy `CommentsPositions.Bottom`. Ha csak megjegyzéseket akar, hagyja ki a `NotesPosition` beállítást. Ha mindkettőt szeretné, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek vezérlése**

A HTML export tömörítheti a dia képeket a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression` értékét a [PicturesCompression](https://reference.aspose.com/slides/hu/net/aspose.slides.export/picturescompression/) enum egyik értékére, ha magasabb képminőségre van szükség.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Alapértelmezés szerint a képek levágott területei eltávolításra kerülhetnek az exportált kimenetből. Tartsa meg a levágott adatokat csak akkor, ha a felhasználóknak vissza kell tudni állítani vagy megvizsgálni ezeket a rejtett kép részeket. A megtartás növelheti a HTML méretét.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS hozzáadása**

Egyszerű stílusoláshoz adjon át egy CSS karakterláncot a [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmlformatter/createdocumentformatter/) metódusnak. Ez megváltoztatja a környező HTML dokumentumot, miközben az Aspose.Slides továbbra is a dia tartalmát rendereli.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Egyedi dokumentumfejléc, linkelt CSS fájl vagy egyedi jelölőnyelv a diák és alakzatok körül megvalósítható a [IHtmlFormattingController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ihtmlformattingcontroller/) implementálásával, majd a [HtmlFormatter](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmlformatter/) számára a `CreateCustomFormatter` segítségével.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nem garantált a prezentáció betűtípusainak telepítése, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hűséget, de növeli a kimenet méretét.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Csak akkor hagyja ki a betűtípusokat, ha biztos abban, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűtípusok vagy kevésbé elterjedt betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípusfájlok hivatkozása beágyazás helyett**

A HTML fájl méretének csökkentéséhez a betűtípus adatokat külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Az alábbi segédfüggvény kiterjeszti a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedallfontshtmlcontroller/) osztályt, és felülírja a `WriteFont` metódust.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Ebben a példában a betűtípusfájlok a `html-output/fonts` mappába kerülnek mentésre, a HTML pedig `fonts/BrandFont-normal-400.woff` típusú URL‑ekkel hivatkozik rájuk. Ha a HTML fájlt és a betűtípusokat más helyre telepíti, állítsa be a `fontUrlPrefix`‑et úgy, hogy az megegyezzen a telepített URL elérési útjával.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozgat̂ható, de a beágyazott Base64 erőforrások nagy fájlt eredményezhetnek. Ha az alkalmazásának külső képfájlokra van szüksége, implementálja a [ILinkEmbedController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ilinkembedcontroller/) interfészt, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/htmloptions/) konstruktorának.

Erőforrások külsővé tételekor két útvonalat kell tudatosan kiválasztani:

- A fájlrendszer kimeneti útvonala, ahová az alkalmazás a generált képeket, betűtípusokat, hang- vagy videofájlokat írja.
- Az URL útvonal, amelyet a böngésző a HTML dokumentumból használ a fájlok betöltéséhez.

A teljes kép‑linkelési megvalósításhoz lásd a [Export Presentations to HTML with Externally Linked Images](/slides/hu/net/exporting-presentations-to-html-with-externally-linked-images/) cikket.

## **Médiafájlok exportálása**

A [VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/net/aspose.slides.export/videoplayerhtmlcontroller/) videó- és hangfájlokat exportál, és olyan HTML‑t ír, amely képes lejátszani őket a böngészőben. A konstruktor a következőket várja:

- `path`: a könyvtár, ahová a generált médiafájlok kerülnek.
- `fileName`: a generált HTML fájl neve.
- `baseUri`: az abszolút URI előtoldal, amelyet a HTML a médiafájlokra mutató hivatkozásokban használ.

Ha a HTML fájl `html-output/presentation.html` és a médiafájlok a `html-output/media` könyvtárban vannak, a `path`‑nek a lemezre mutató média könyvtárra, a `baseUri`‑nek pedig a böngészőből elérhető ugyanarra a könyvtárra kell mutatnia. Helyi előnézethez készíthet `file:///` URI‑t a média könyvtárból. Telepített alkalmazásnál használja a közzétett média könyvtár abszolút URL‑jét.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Használjon olyan kimeneti könyvtárakat, amelyek egyediek egy export feladatra, különösen szerveralkalmazások esetén. A megosztott kimeneti útvonalak különböző konverziók fájljainak felülírásához vezethetnek.

## **Teljesítmény és erőforrás-kezelés**

A HTML konverzió renderelési művelet, így a feldolgozási idő és memóriahasználat a dia számától, a kép felbontásától, a betűtípusoktól, effektusoktól, diagramoktól és a beágyazott médiától függ. A magasabb `PicturesCompression` DPI értékek, beágyazott betűtípusok, SVG kimenet és a megtartott levágott képrészletek javíthatják a hűséget, de általában növelik a kimenet méretét.

Kötegelt konverzióhoz:

- Gyorsan dobja el minden [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
- Használjon külön kimeneti könyvtárakat külön feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, hacsak a hűség megköveteli.
- Csökkentse a kép DPI‑t, ha a HTML előnézet vagy miniaturák számára készült.
- Tartsa a forrásprezentációt, a generált HTML‑t és a külső erőforrásokat együtt mindaddig, amíg a telepítési útvonalak véglegesek.

## **GYIK**

**Megmaradnak-e a hiperhivatkozások a HTML kimenetben?**

Igen. A prezentáció hiperhivatkozásai exportálásra kerülnek HTML‑be, és kattinthatóak maradnak, ha a cél URL érvényes.

**Konvertálhatók-e a prezentációk párhuzamosan HTML‑re?**

Igen, de ne osszon meg egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt szálak között. Különböző fájlokat külön prezentációs példányokkal, külön adatfolyamokkal és külön kimeneti könyvtárakkal dolgozzon fel. Lásd a [multithreading guidance](/slides/hu/net/multithreading/) részleteket.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt egy szálon kell betölteni, módosítani, menteni és eldobni. Párhuzamos munka esetén hozzon létre független példányt szálanként vagy folyamatonként.

**Miért nagy a generált HTML fájl?**

Az alapértelmezett export beágyazhat erőforrásokat közvetlenül a HTML‑be. A beágyazott betűtípusok, nagy DPI‑jú képek, média, SVG tartalom és a megtartott levágott képrészletek is növelik a méretet. Használjon külső erőforrásokat, hagyja ki a gyakori betűtípusok beágyazását, és csökkentse a `PicturesCompression`‑t, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért jelenik meg egy PowerPoint 24 pt betűméret 17,999819 pt‑ként a HTML‑ben?**

Ez azért fordulhat elő, mert a PowerPoint és a HTML különböző DPI modelleket használ. A PowerPoint a tipográfiai pontokat 72 DPI alapján tárolja, míg a HTML elrendezés CSS pixelen alapul 96 DPI‑s modellben. Amikor az Aspose.Slides prezentációt HTML‑re exportálja, a betűméret átalakul ezek között a rendszerek között, és a konverzió apró kerekítési eltéréseket eredményezhet.

Ezek az értékek nem jelentenek valós vizuális betűméret‑változást. Csak a szövegmetrikák PowerPoint és HTML közötti átalakításának matematikai mellékhatásai.

**Hogyan válasszam ki a baseUri‑t a média exporthoz?**

Válassza a `baseUri`‑t úgy, ahogy a böngésző látja, és adja meg abszolút URI‑ként. Helyi előnézethez származtathatja a kimeneti könyvtárból a `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` kóddal. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path` és a böngésző `baseUri` nem kell, hogy ugyanaz legyen, de ugyanarra a erőforráshelyre kell mutatniuk.

**Beleszámíthatók-e a rejtett diák?**

Igen. Állítsa a `ShowHiddenSlides = true` értéket a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/)‑on, ha a rejtett diák exportálása szükséges.