---
title: Převod prezentací PowerPoint do HTML v C++
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/cpp/convert-powerpoint-to-html/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- uložit PowerPoint jako HTML
- uložit prezentaci jako HTML
- uložit snímek jako HTML
- uložit PPT jako HTML
- uložit PPTX jako HTML
- exportovat PPT do HTML
- exportovat PPTX do HTML
- C++
- Aspose.Slides
description: "Převod prezentací PowerPoint do HTML v C++. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides for C++ může ukládat prezentace PowerPoint jako HTML bez Microsoft PowerPoint. Základní konverze spočívá v načtení jedné [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a volání `Save` s [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/) když potřebujete řídit exportovaný vzhled, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu HTML:

- Export celé prezentace nebo vybraných snímků.
- Generování HTML s pevnou šířkou, responzivního nebo založeného na SVG.
- Zahrnutí poznámek řečníka a komentářů.
- Řízení kvality obrázků a oříznutých částí obrázků.
- Vložení písem nebo jejich samostatné uložení.
- Volba, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je praktické pro sdílení jednoho souboru, ale může zvýšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vkládání pouze těch písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML načtěte ji pomocí [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a uložte ji pomocí `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Tento příklad zapíše jeden HTML soubor. Volání `Dispose` uvolní souborové handly a zdroje vykreslování po exportu.

## **Použití HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/) je hlavní konfigurační třída pro export HTML. Běžná nastavení zahrnují:

- `SlidesLayoutOptions`: přidá poznámky, komentáře, podklady nebo jiné informace o rozložení.
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na řadič.
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `PicturesCompression`: řídí DPI obrázku a velikost výstupu.
- `DeletePicturesCroppedAreas`: ponechává nebo odstraňuje oříznutá data obrázků.
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- `ShowHiddenSlides`: zahrnuje skryté snímky, pokud je to požadováno.

Následující sekce ukazují nejčastěji používané možnosti samostatně, aby bylo možné kombinovat jen ty, které váš workflow vyžaduje.

## **Převod vybraných snímků do HTML**

Přetížená metoda `Presentation::Save`, která přijímá čísla snímků, používá 1‑základní pozice snímků. Smyčka níže ukládá každý snímek do samostatného HTML souboru.

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

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má každý snímek mít stejné rozložení, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/) a předávejte ji každému volání `Save`.

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/responsivehtmlcontroller/) poskytuje responzivní HTML výstup přes [HtmlFormatter](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmlformatter/). Použijte jej, když má exportovaná stránka lépe reagovat na šířku prohlížeče.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Pro responzivní rozložení založené na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Zahrnutí poznámek řečníka a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) přes `HtmlOptions.SlidesLayoutOptions` pro zahrnutí poznámek řečníka nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud nevyberete jejich umístění.

Předpokládejme, že zdrojová prezentace obsahuje poznámky řečníka:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami řečníka pod snímkem.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Exportovaný HTML obsahuje oblast poznámek:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions::Right` nebo `CommentsPositions::Bottom`. Pokud potřebujete jen komentáře, vynechte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Řízení kvality obrázků a oříznutých oblastí**

Export HTML může komprimovat obrázky snímků pro snížení velikosti výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/picturescompression/), když potřebujete vyšší kvalitu obrázků.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků z výstupu odebrány. Zachovejte oříznutá data jen tehdy, když uživatelé musí mít možnost je obnovit nebo prozkoumat skryté části obrázku. Ponechání těchto dat může zvýšit velikost HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Přidání CSS**

Pro jednoduché stylování předávejte řetězec CSS do `HtmlFormatter::CreateDocumentFormatter`. Tím se změní obklopující HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímků.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Pro vlastní hlavičku dokumentu, odkazovaný CSS soubor nebo vlastní markup kolem snímků a tvarů implementujte [IHtmlFormattingController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ihtmlformattingcontroller/) a předávejte jej [HtmlFormatter](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmlformatter/) pomocí `CreateCustomFormatter`.

## **Vložení písem**

Pokud cílové prostředí nemusí mít písma prezentace nainstalována, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvyšuje velikost výstupu.

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

Vylučujte písma pouze tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro značková písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Odkaz na soubory písem místo jejich vložení**

Pro snížení velikosti HTML souboru můžete data písem zapisovat do samostatných WOFF souborů a přidat pravidla `@font-face` do HTML. Pomocná třída níže rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/embedallfontshtmlcontroller/) a přepisuje `WriteFont`.

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

V tomto příkladu jsou soubory písem uloženy do `html-output/fonts` a HTML na ně odkazuje pomocí URL jako `fonts/BrandFont-normal-400.woff`. Pokud jsou HTML soubor a písma nasazeny na jiné místo, zvolte `fontUrlPrefix` tak, aby odpovídalo nasazené cestě URL.

## **Ukládání zdrojů externě**

Samostatný HTML je snadno přenosný, ale vložené Base64 zdroje mohou soubor značně zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte [ILinkEmbedController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ilinkembedcontroller/) a předávejte jej konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/).

Při externalizaci zdrojů zvolte dvě cesty úmyslně:

- Cesta výstupu souborového systému, kde vaše aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- URL cesta, kterou prohlížeč použije z HTML dokumentu k načtení těchto souborů.

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je dokáže přehrát v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou zapisovány generované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní URI předpona používaná v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro lokální náhled můžete vytvořit `file:///` URI z mediálního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

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

Používejte výstupní adresáře, které jsou jedinečné pro každý export, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit, že soubory z různých konverzí přepíší navzájem.

## **Výkon a správa zdrojů**

Konverze HTML je operace vykreslování, takže doba zpracování a využití paměti závisí na počtu snímků, rozlišení obrázků, písm, efektech, grafech a vložených médiích. Vyšší hodnoty DPI v `PicturesCompression`, vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro dávkovou konverzi:

- Okamžitě uvolněte každou instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
- Používejte samostatné výstupní adresáře pro samostatné úlohy.
- Vyhýbejte se vkládání běžných písem, pokud to není nezbytné pro věrnost.
- Snižte DPI obrázků, když je HTML určené pouze pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální nasazovací cesty.

## **Často kladené otázky**

**Jsou hypertextové odkazy zachovány ve výstupu HTML?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu konvertovat prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentace, oddělenými proudy a oddělenými výstupními adresáři. Viz [multithreading guidance](/slides/cs/cpp/multithreading/) pro podrobnosti.

**Je objekt Presentation vláknově bezpečný?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci na každé vlákno nebo proces.

**Proč je vygenerovaný soubor HTML velký?**

Výchozí export může vkládat zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také zvyšují velikost. Použijte externí zdroje, vylučte běžná písma z vkládání a snižte `PicturesCompression`, pokud je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma PowerPointu 24 pt zobrazuje v HTML jako 17,999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné DPI modely. PowerPoint ukládá velikosti textu v typografických bodech na základě 72 DPI, zatímco rozvržení HTML je založeno na CSS pixelech v modelu 96 DPI. Při exportu prezentace do HTML Aspose.Slides provádí převod velikosti písma mezi těmito systémy a konverze může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jsou pouze matematickým vedlejším efektem převodu textových měřítek mezi PowerPoint a HTML.

**Jak bych měl zvolit baseUri pro export médií?**

Zvolte `baseUri` z pohledu prohlížeče a předávejte jej jako absolutní URI. Pro lokální náhled ji můžete odvodit z výstupního adresáře pomocí `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový `path` a `baseUri` prohlížeče nemusí být stejný řetězec, ale musí popisovat stejnou lokaci zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides` na `true` v [HtmlOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/htmloptions/), když musí být skryté snímky exportovány.