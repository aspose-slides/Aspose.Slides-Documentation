---
title: Převod prezentací PowerPoint do HTML v .NET
linktitle: PowerPoint do HTML
type: docs
weight: 30
url: /cs/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Převod prezentací PowerPoint do HTML v .NET. Použijte Aspose.Slides k exportu souborů PPT a PPTX, vybraných snímků, poznámek, písem, obrázků, SVG a médií."
---
## **Přehled**

Aspose.Slides pro .NET dokáže uložit prezentace PowerPointu jako HTML bez Microsoft PowerPoint. Základní konverze spočívá v jednorázovém načtení [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a volání [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) s [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/). Použijte [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) pokud potřebujete řídit exportovaný rozvržení, písma, obrázky, poznámky, komentáře, výstup SVG nebo propojené zdroje.

Tento průvodce se zaměřuje na praktické scénáře exportu do HTML:

- Export celé prezentace nebo vybraných snímků.
- Vytvořit HTML s pevnou šablonou, responzivní nebo založené na SVG.
- Zahrnout poznámky prezentujícího a komentáře.
- Řídit kvalitu obrázků a data o oříznutých obrázcích.
- Vkládat písma nebo ukládat soubory písem samostatně.
- Zvolit, jak jsou externí zdroje a mediální soubory zapisovány a odkazovány.

Ve výchozím nastavení export do HTML vytváří samostatný HTML dokument, kde jsou většina zdrojů vloženy. To je pohodlné pro sdílení jediného souboru, ale může zvětšit velikost výstupu. Pro publikování na webu zvažte externí zdroje, nižší DPI obrázků a vkládání pouze těch písem, která nejsou spolehlivě dostupná v cílovém prostředí.

## **Převod prezentace do HTML**

Pro export prezentace do HTML ji načtěte pomocí [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a uložte pomocí [SaveFormat.Html](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Tento příklad zapisuje jeden soubor HTML. Objekt prezentace je uvolněn deklarací `using`, která po exportu uvolní souborové handly a zdroje vykreslování.

## **Použití HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) je hlavní konfigurační třída pro export do HTML. Mezi běžná nastavení patří:

- `SlidesLayoutOptions`: přidává poznámky, komentáře, podklady nebo jiné informace o rozvržení.
- `HtmlFormatter`: mění strukturu HTML dokumentu nebo deleguje formátování na kontrolér.
- `SlideImageFormat`: mění způsob, jakým jsou snímky reprezentovány, například jako SVG.
- `PicturesCompression`: řídí DPI obrázků a velikost výstupu.
- `DeletePicturesCroppedAreas`: zachovává nebo odstraňuje data o oříznutých částech obrázků.
- `SvgResponsiveLayout`: umožňuje exportovanému SVG obsahu přizpůsobit se svému kontejneru.
- `ShowHiddenSlides`: zahrnuje skryté snímky, pokud je to potřeba.

Následující sekce ukazují nejčastější možnosti odděleně, abyste mohli kombinovat jen ty, které vaše pracovní postupy potřebují.

## **Převod vybraných snímků do HTML**

Přetížení [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) které přijímá čísla snímků používá pozice snímků číslované od 1. Smyčka níže ukládá každý snímek do samostatného souboru HTML.

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

Použijte tento vzor, když webová stránka nebo aplikace potřebuje jednu HTML stránku na snímek. Pokud má každý snímek mít stejné rozvržení, vytvořte jednu instanci [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) a předávejte ji každému volání `Save`.

## **Vytvoření responzivního HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/responsivehtmlcontroller/) poskytuje responzivní výstup HTML prostřednictvím [HtmlFormatter](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmlformatter/). Použijte jej, když má exportovaná stránka lépe přizpůsobovat šířce prohlížeče.

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

Pro responzivní rozvržení založené na SVG nastavte `SvgResponsiveLayout` na [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/). To je užitečné, když je obsah snímku exportován jako škálovatelný SVG markup.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Zahrnutí poznámek prezentujícího a komentářů**

Použijte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) přes `HtmlOptions.SlidesLayoutOptions` pro zahrnutí poznámek prezentujícího nebo komentářů. Poznámky a komentáře jsou ve výchozím nastavení skryté, pokud si nevyberete jejich umístění.

Předpokládejme, že zdrojová prezentace obsahuje poznámky prezentujícího:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Následující kód exportuje obsah snímku s poznámkami prezentujícího pod snímkem.

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

Exportovaný HTML obsahuje oblast poznámek:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Pro export komentářů nastavte `CommentsPosition`, například na `CommentsPositions.Right` nebo `CommentsPositions.Bottom`. Pokud potřebujete jen komentáře, vynechte `NotesPosition`. Pokud potřebujete jak poznámky, tak komentáře, nastavte obě vlastnosti.

## **Řízení kvality obrázků a oříznutých oblastí**

Export do HTML může komprimovat obrázky snímků, aby se snížila velikost výstupu. Nastavte `PicturesCompression` na hodnotu z [PicturesCompression](https://reference.aspose.com/slides/cs/net/aspose.slides.export/picturescompression/) pokud potřebujete vyšší kvalitu obrázku.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Ve výchozím nastavení mohou být oříznuté oblasti obrázků odstraněny z exportovaného výstupu. Zachovejte oříznutá data pouze tehdy, když uživatelé musí mít možnost obnovit nebo prozkoumat tyto skryté části obrázku. Uchování může zvýšit velikost HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Přidání CSS**

Pro jednoduché stylování předáte řetězec CSS metodě [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmlformatter/createdocumentformatter/). To změní okolní HTML dokument, zatímco Aspose.Slides nadále vykresluje obsah snímku.

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

Pro vlastní záhlaví dokumentu, odkazovaný soubor CSS nebo vlastní značkování kolem snímků a tvarů implementujte [IHtmlFormattingController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ihtmlformattingcontroller/) a předávejte jej do [HtmlFormatter](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmlformatter/) pomocí `CreateCustomFormatter`.

## **Vkládání písem**

Pokud cílové prostředí nemusí mít nainstalována písma použité v prezentaci, vložte písma do HTML pomocí [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedallfontshtmlcontroller/). Vkládání zlepšuje vizuální věrnost, ale zvětšuje velikost výstupu.

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

Písma vylučujte pouze tehdy, když jste si jisti, že cílové prohlížeče nebo systémy je již poskytují. Pro firemní písma nebo méně běžná písma je vkládání obvykle bezpečnější.

## **Odkazovat soubory písem místo jejich vkládání**

Pro snížení velikosti souboru HTML můžete data písem zapsat do samostatných souborů WOFF a přidat pravidla `@font-face` do HTML. Pomocník níže rozšiřuje [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedallfontshtmlcontroller/) a přepisuje `WriteFont`.

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

V tomto příkladu jsou soubory písem uloženy do `html-output/fonts` a HTML je odkazuje pomocí URL jako `fonts/BrandFont-normal-400.woff`. Pokud jsou HTML soubor a písma nasazeny na jiné místo, zvolte `fontUrlPrefix`, aby odpovídal nasazené cestě URL.

## **Ukládání zdrojů externě**

Samostatné HTML je snadno přenositelné, ale vložené Base64 zdroje mohou soubor zvětšit. Pokud vaše aplikace potřebuje externí soubory obrázků, implementujte [ILinkEmbedController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ilinkembedcontroller/) a předávejte jej do konstruktoru [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/htmloptions/).

Když externalizujete zdroje, zvolte dva cesty úmyslně:

- Cesta výstupu v souborovém systému, kam vaše aplikace zapisuje vygenerované obrázky, písma, audio nebo video.
- Cesta URL, kterou prohlížeč používá z HTML dokumentu k načtení těchto souborů.

Pro úplnou implementaci propojování obrázků viz [Exportovat prezentace do HTML s externě propojenými obrázky](/slides/cs/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Export mediálních souborů**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/cs/net/aspose.slides.export/videoplayerhtmlcontroller/) exportuje video a audio soubory a zapisuje HTML, které je může přehrávat v prohlížeči. Jeho konstruktor přijímá:

- `path`: adresář, kam budou zapisovány generované mediální soubory.
- `fileName`: název generovaného HTML souboru.
- `baseUri`: absolutní prefix URI používaný v HTML odkazech na mediální soubory.

Pokud je HTML soubor `html-output/presentation.html` a mediální soubory jsou uloženy v `html-output/media`, `path` by měl ukazovat na mediální adresář na disku, zatímco `baseUri` by měl ukazovat na stejný adresář z pohledu prohlížeče. Pro místní náhled můžete vytvořit URI `file:///` z mediálního adresáře. Pro nasazenou aplikaci použijte absolutní URL publikovaného mediálního adresáře.

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

Používejte výstupní adresáře jedinečné pro každý export, zejména v serverových aplikacích. Sdílené výstupní cesty mohou způsobit přepisování souborů z různých konverzí.

## **Výkon a správa zdrojů**

Konverze do HTML je operace vykreslování, takže doba zpracování a využití paměti závisí na počtu snímků, rozlišení obrázků, písech, efektech, grafech a vložených médiích. Vyšší hodnoty DPI v `PicturesCompression`, vložená písma, výstup SVG a zachování oříznutých oblastí obrázků mohou zlepšit věrnost, ale obvykle zvětší velikost výstupu.

Pro hromadnou konverzi:

- Okamžitě uvolněte každou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
- Používejte oddělené výstupní adresáře pro jednotlivé úlohy.
- Vyhněte se vkládání běžných písem, pokud to není vyžadováno pro věrnost.
- Snižte DPI obrázků, když je HTML určeno pro náhled nebo miniatury.
- Uchovávejte zdrojovou prezentaci, vygenerované HTML a externí zdroje společně, dokud nejsou finální cesty nasazení.

## **Často kladené otázky**

**Zůstávají hypertextové odkazy v HTML výstupu?**

Ano. Hypertextové odkazy v prezentaci jsou exportovány do HTML a zůstávají klikatelné, pokud je cílová URL platná.

**Mohu převádět prezentace do HTML paralelně?**

Ano, ale nesdílejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) mezi vlákny. Zpracovávejte různé soubory s oddělenými instancemi prezentací, oddělenými proudy a oddělenými výstupními adresáři. Podrobnosti najdete v [průvodci vícevláknovým zpracováním](/slides/cs/net/multithreading/).

**Je objekt Presentation vláknově bezpečný?**

Ne. Jedna instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) by měla být načtena, upravena, uložena a uvolněna v jednom vlákně. Pro paralelní práci vytvořte nezávislou instanci pro každé vlákno nebo proces.

**Proč je vygenerovaný HTML soubor velký?**

Výchozí export může vložit zdroje přímo do HTML. Vložená písma, obrázky s vysokým DPI, média, SVG obsah a zachování oříznutých oblastí obrázků také zvětšují velikost. Použijte externí zdroje, vylučte běžná písma z vkládání a snižte `PicturesCompression`, když je menší výstup důležitější než maximální věrnost.

**Proč se velikost písma v PowerPointu, např. 24 pt, v HTML zobrazuje jako 17,999819 pt?**

K tomu může dojít, protože PowerPoint a HTML používají odlišné modely DPI. PowerPoint ukládá velikosti textu v typografických bodech na základě 72 DPI, zatímco HTML layout je založen na CSS pixelech v modelu 96 DPI. Při exportu prezentace do HTML Aspose.Slides převádí velikost písma mezi těmito systémy a převod může zavést malé zaokrouhlovací rozdíly.

Tyto hodnoty neznamenají skutečnou vizuální změnu velikosti písma. Jedná se pouze o matematický vedlejší efekt konverze textových metrik mezi PowerPointem a HTML.

**Jak bych měl zvolit baseUri pro export médií?**

Zvolte `baseUri` tak, aby odpovídalo pohledu prohlížeče, a předávejte jej jako absolutní URI. Pro místní náhled můžete odvodit `baseUri` z výstupního adresáře pomocí `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Pro nasazení použijte absolutní URL publikovaného mediálního adresáře. Souborový `path` a prohlížečový `baseUri` nemusí být stejné řetězce, ale musí popisovat stejnou lokaci zdroje.

**Mohu zahrnout skryté snímky?**

Ano. Nastavte `ShowHiddenSlides = true` na [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) když je nutné exportovat skryté snímky.