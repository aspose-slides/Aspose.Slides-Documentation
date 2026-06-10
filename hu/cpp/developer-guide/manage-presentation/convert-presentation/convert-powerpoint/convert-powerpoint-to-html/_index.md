---
title: PowerPoint bemutatók konvertálása HTML-re C++-ban
linktitle: PowerPoint HTML-re
type: docs
weight: 30
url: /hu/cpp/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint HTML-re
- bemutató HTML-re
- dia HTML-re
- PPT HTML-re
- PPTX HTML-re
- PowerPoint mentése HTML-ként
- bemutató mentése HTML-ként
- dia mentése HTML-ként
- PPT mentése HTML-ként
- PPTX mentése HTML-ként
- PPT exportálása HTML-re
- PPTX exportálása HTML-re
- C++
- Aspose.Slides
description: "PowerPoint bemutatókat konvertál HTML-re C++-ban. Használja az Aspose.Slides-t PPT és PPTX fájlok, kiválasztott diák, jegyzetek, betűtípusok, képek, SVG és média exportálásához."
---
## **Áttekintés**

Aspose.Slides for C++ képes PowerPoint bemutatókat HTML‑ként menteni a Microsoft PowerPoint nélkül. Az alapvető konverzió egyetlen [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) betöltése és egy `Save` hívás a [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) segítségével. Használja a [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/)‑t, ha szabályozni szeretné az exportált elrendezést, betűtípusokat, képeket, jegyzeteket, megjegyzéseket, SVG kimenetet vagy a kapcsolt erőforrásokat.

Ez az útmutató a gyakorlati HTML export szcenáriókra összpontosít:

- Exportálja az egész bemutatót vagy a kiválasztott diákot.
- Készítsen fix‑elrendezésű, reszponzív vagy SVG‑alapú HTML‑t.
- Tartalmazza az előadói jegyzeteket és megjegyzéseket.
- Szabályozza a képminőséget és a levágott képadatokat.
- Beágyazza a betűtípusokat vagy mentse a betűtípusfájlokat külön.
- Válassza ki, hogyan írják és hivatkozzák a külső erőforrásokat és médiafájlokat.

Alapértelmezés szerint a HTML export egy önálló HTML dokumentumot hoz létre, amelyben a legtöbb erőforrás beágyazott. Ez kényelmes egyetlen fájl megosztásához, de növelheti a kimeneti méretet. Webes közzététel esetén fontolja meg a külső erőforrások használatát, alacsonyabb képpont sűrűség (DPI) alkalmazását, és csak azoknak a betűtípusoknak a beágyazását, amelyek a célkörnyezetben nem biztosan elérhetők.

## **Prezentáció konvertálása HTML‑re**

HTML‑ként exportáláshoz töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) segítségével, és mentse a `SaveFormat::Html` használatával.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Ez a példakód egy HTML fájlt ír. A `Dispose` hívás felszabadítja a fájlkezelőket és a renderelési erőforrásokat az export után.

## **HtmlOptions használata**

[HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) a fő konfigurációs osztály a HTML exporthoz. Gyakori beállítások közé tartozik:

- `SlidesLayoutOptions`: jegyzeteket, megjegyzéseket, kiadványokat vagy egyéb elrendezési információkat ad hozzá.
- `HtmlFormatter`: megváltoztatja a HTML dokumentum szerkezetét, vagy a formázást egy vezérlőnek adja át.
- `SlideImageFormat`: megváltoztatja a diák ábrázolási módját, például SVG‑ként.
- `PicturesCompression`: szabályozza a képek DPI értékét és a kimeneti méretet.
- `DeletePicturesCroppedAreas`: megőrzi vagy eltávolítja a levágott kép adatokat.
- `SvgResponsiveLayout`: a exportált SVG tartalmat a tárolóhoz igazítja.
- `ShowHiddenSlides`: szükség esetén belefoglalja a rejtett diákat.

A következő szakaszokban a leggyakoribb beállításokat külön mutatjuk be, így csak azokat kombinálhatja, amelyekre a munkafolyamatnak szüksége van.

## **Kiválasztott diák konvertálása HTML‑re**

A diák számát elfogadó `Presentation::Save` túlterhelés 1‑től kezdődő diaszámokat használ. Az alábbi ciklus minden diát külön HTML fájlba ment.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Ezt a mintát akkor használja, ha egy weboldal vagy alkalmazás minden dia számára egy HTML oldalt igényel. Ha minden diának ugyanazt az elrendezést kell használnia, hozzon létre egy [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) példányt, és adja át minden `Save` híváshoz.

## **Reszponzív HTML létrehozása**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/responsivehtmlcontroller/) reszponzív HTML kimenetet biztosít a [HtmlFormatter](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmlformatter/) segítségével. Használja, ha az exportált oldalnak jobban kell alkalmazkodnia a böngésző szélességéhez.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

SVG‑alapú reszponzív elrendezéshez állítsa be a `SvgResponsiveLayout` értékét a [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/)‑n. Ez akkor hasznos, ha a diák tartalma skálázható SVG jelölőnyelvként kerül exportálásra.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Előadói jegyzetek és megjegyzések belefoglalása**

Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑t a `HtmlOptions.SlidesLayoutOptions`‑on keresztül az előadói jegyzetek vagy megjegyzések belefoglalásához. A jegyzetek és a megjegyzések alapértelmezés szerint rejtve vannak, hacsak nem állítja be azok pozícióját.

Tegyük fel, hogy a forrás bemutató előadói jegyzeteket tartalmaz:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

A következő kód a diák tartalmát a diát alatti előadói jegyzetekkel exportálja.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Az exportált HTML tartalmazza a jegyzetek területét:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

A megjegyzések exportálásához állítsa be a `CommentsPosition`‑t, például `CommentsPositions::Right` vagy `CommentsPositions::Bottom`. Ha csak a megjegyzésekre van szükség, hagyja ki a `NotesPosition`‑t. Ha mind a jegyzetekre, mind a megjegyzésekre szükség van, állítsa be mindkét tulajdonságot.

## **Képminőség és levágott területek szabályozása**

A HTML export képes tömöríteni a diaképeket a kimeneti méret csökkentése érdekében. Állítsa be a `PicturesCompression` értékét a [PicturesCompression](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/picturescompression/)‑ból, ha magasabb képminőségre van szükség.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Alapértelmezés szerint a képek levágott területei eltávolításra kerülhetnek az exportált kimenetből. A levágott adatokat csak akkor tartsa meg, ha a felhasználóknak vissza kell tudni nyerni vagy megvizsgálni ezeket a rejtett képrészleteket. A megtartás növelheti a HTML méretét.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS hozzáadása**

Egy egyszerű stílushoz adjon át egy CSS karakterláncot a `HtmlFormatter::CreateDocumentFormatter`‑nek. Ez módosítja a környező HTML dokumentumot, miközben az Aspose.Slides továbbra is rendereli a dia tartalmát.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Egyedi dokumentumfejléc, csatolt CSS fájl vagy egyedi jelölőnyelv a diák és alakzatok körül számára implementálja a [IHtmlFormattingController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ihtmlformattingcontroller/)‑t, és adja át a [HtmlFormatter](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmlformatter/)‑nek a `CreateCustomFormatter`‑nal.

## **Betűtípusok beágyazása**

Ha a célkörnyezetben nem biztos, hogy a bemutató betűtípusai telepítve vannak, ágyazza be a betűtípusokat a HTML‑be a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedallfontshtmlcontroller/) segítségével. A beágyazás javítja a vizuális hűséget, de növeli a kimeneti méretet.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Ne ágyazza be a betűtípusokat csak akkor, ha biztos benne, hogy a célböngészők vagy rendszerek már rendelkeznek velük. Márkabetűtípusok vagy kevésbé gyakori betűtípusok esetén a beágyazás általában biztonságosabb.

## **Betűtípusfájlok hivatkozása beágyazás helyett**

Az HTML fájl méretének csökkentése érdekében a betűtípus adatokat külön WOFF fájlokba írhatja, és `@font-face` szabályokat adhat a HTML‑hez. Az alábbi segédprogram a [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedallfontshtmlcontroller/)‑t bővíti, és felülírja a `WriteFont`‑ot.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Ebben a példában a betűtípusfájlok a `html-output/fonts` könyvtárba mentődnek, és a HTML olyan URL‑ekkel hivatkozik rájuk, mint a `fonts/BrandFont-normal-400.woff`. Ha az HTML fájlt és a betűtípusokat egy másik helyre telepíti, válassza a `fontUrlPrefix` értékét úgy, hogy az egyezzen a telepített URL útvonallal.

## **Erőforrások külső mentése**

Az önálló HTML könnyen mozgatható, de a beágyazott Base64 erőforrások nagy fájlt eredményezhetnek. Ha az alkalmazásnak külső kép fájlokra van szüksége, implementálja az [ILinkEmbedController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ilinkembedcontroller/)‑t, és adja át a [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) konstruktorának.

Amikor externalizálja az erőforrásokat, gondosan válasszon két útvonalat:

- A fájlrendszer kimeneti útvonala, ahová az alkalmazás a generált képeket, betűtípusokat, hangot vagy videót írja.
- Az URL útvonal, amelyet a böngésző a HTML dokumentumból használ az adott fájlok betöltéséhez.

## **Médiafájlok exportálása**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/videoplayerhtmlcontroller/) videó- és hangfájlokat exportál, és olyan HTML‑t ír, amely böngészőben le tudja játszani őket. A konstruktorja a következőket veszi:

- `path`: a könyvtár, ahová a generált médiafájlok íródnak.
- `fileName`: a generált HTML fájl neve.
- `baseUri`: az abszolút URI előtag, amely a HTML hivatkozásokban a médiafájlokra kerül felhasználásra.

Ha a HTML fájl `html-output/presentation.html`, és a médiafájlok a `html-output/media` könyvtárba mentődnek, akkor a `path` a lemezen a média könyvtárra mutasson, míg a `baseUri` a böngésző szempontjából ugyanarra a könyvtárra mutasson. Helyi előnézethez a média könyvtárból építhet `file:///` URI‑t. Telepített alkalmazáshoz használja a közzétett média könyvtár abszolút URL‑jét.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Használjon olyan kimeneti könyvtárakat, amelyek minden exportfeladathoz egyediek, különösen szerveralkalmazásokban. A megosztott kimeneti útvonalak miatt különböző konverziók fájljai felülírhatják egymást.

## **Teljesítmény és erőforrás-kezelés**

A HTML konverzió egy renderelési művelet, így a feldolgozási idő és a memóriahasználat a diák számától, a kép felbontásától, a betűtípusoktól, hatásoktól, diagramoktól és a beágyazott médiától függ. A magasabb `PicturesCompression` DPI értékek, a beágyazott betűtípusok, az SVG kimenet és a megtartott levágott képrészletek javíthatják a hűséget, de általában növelik a kimeneti méretet.

Kötegelt konverzió esetén:

- A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt azonnal dobja el (Dispose).
- Használjon külön kimeneti könyvtárakat a külön feladatokhoz.
- Kerülje a gyakori betűtípusok beágyazását, hacsak a hűség nem igényli.
- Csökkentse a képek DPI értékét, ha a HTML előnézet vagy miniatűr számára készül.
- Tartsa a forrás bemutatót, a generált HTML‑t és a külső erőforrásokat együtt, amíg a telepítési útvonalak véglegesek.

## **FAQ**

**Megmaradnak‑e a hiperhivatkozások a HTML kimenetben?**

Igen. A bemutató hiperhivatkozásai HTML‑re exportálódnak, és kattinthatóak maradnak, ha a cél‑URL érvényes.

**Konvertálhatok‑e bemutatókat párhuzamosan HTML‑re?**

Igen, de ne ossza meg egy [Presentation] példányt szálak között. Külön fájlok feldolgozásához használjon külön prezentációs példányokat, külön adatfolyamokat és külön kimeneti könyvtárakat. A részletekért lásd a [multithreading guidance](/slides/hu/cpp/multithreading/) oldalát.

**A Presentation objektum szálbiztos?**

Nem. Egyetlen [Presentation] példányt egy szálon kell betölteni, módosítani, menteni és eldobni. Párhuzamos munkához hozzon létre minden szálhoz vagy folyamathoz egy független példányt.

**Miért nagy a generált HTML fájl?**

Az alapértelmezett export közvetlenül beágyazhat erőforrásokat a HTML‑be. A beágyazott betűtípusok, nagy DPI‑ú képek, média, SVG tartalom és a megtartott levágott kép területek is növelik a méretet. Használjon külső erőforrásokat, hagyja ki a gyakori betűtípusok beágyazását, és csökkentse a `PicturesCompression`‑t, ha a kisebb kimenet fontosabb a maximális hűségnél.

**Miért jelenik meg a PowerPoint 24 pt betűmérete 17,999819 pt‑ként a HTML-ben?**

Ez azért fordulhat elő, mert a PowerPoint és a HTML különböző DPI modelleket használ. A PowerPoint a szövegméreteket tipográfiai pontokban tárolja, amely 72 DPI‑on alapul, míg a HTML elrendezés a CSS pixelen alapul, 96 DPI modellt használva. Amikor az Aspose.Slides egy bemutatót HTML‑re exportál, a betűméret átváltásra kerül ezek között a rendszerek között, és a konverzió apró kerekítési eltéréseket okozhat.

Ezek az értékek nem jelentenek valódi vizuális betűméret‑változást. Csak a PowerPoint és a HTML közti szövegmetrikák átalakításának matematikai mellékhatása.

**Hogyan válasszam ki a baseUri‑t a média exporthoz?**

Válassza a `baseUri`‑t a böngésző szempontjából, és adja át abszolút URI‑ként. Helyi előnézethez a kimeneti könyvtárból származtathatja a `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` segítségével. Telepítéskor használja a közzétett média könyvtár abszolút URL‑jét. A fájlrendszer `path` és a böngésző `baseUri` nem kell, hogy azonos karakterlánc legyen, de ugyanazt a erőforráshelyet kell leírniuk.

**Be tudok‑e vonni rejtett diákat?**

Igen. Állítsa a `ShowHiddenSlides`‑t `true` értékre a [HtmlOptions] (https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/)‑n, ha a rejtett diákat is exportálni kell.